﻿using QuantTradeDLL.Crawler;
using System;
using System.ServiceProcess;
using System.Threading.Tasks;
namespace Clawer_Service
{
    public partial class Service1 : ServiceBase
    {
        public bool flag { set; get; }
        private System.Timers.Timer timer1;
        const string LOG_FILE_PATH = "C:\\Crawler-Service-log.txt";
        public Service1()
        {
            InitializeComponent();
            timer1 = new System.Timers.Timer()
            {
                Interval = 60000  //设置计时器事件间隔执行时间
            };
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Elapsed);
            flag = true;
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(LOG_FILE_PATH, true))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "init.");
            }
        }
        protected override void OnStart(string[] args)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(LOG_FILE_PATH, true))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "Start.");
            }
            timer1.Enabled = true;
        }
        protected override void OnStop()
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(LOG_FILE_PATH, true))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "Stop.");
            }
            timer1.Enabled = false;
        }
        private Boolean TradeDay(string sysdate)
        {
            return StockLineData.GetLineDataObject("000001").Date.ToString().Equals(sysdate) ? true : false;
        }
        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime NowTime = DateTime.Now;
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(LOG_FILE_PATH, true))
            {
                sw.WriteLine(NowTime.ToString("yyyy-MM-dd HH:mm:ss ") + "预警采集发送中.");
            }
            //判断时间 执行不同操作
            if (NowTime.Hour == 9 && NowTime.Minute == 30)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(LOG_FILE_PATH, true))
                {
                    sw.WriteLine(NowTime.ToString("yyyy-MM-dd HH:mm:ss ") + "修改状态.");
                }
                flag = TradeDay(NowTime.ToString("yyyyMMdd"));
            }
            if (NowTime.Minute % 10 == 0 && flag)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(LOG_FILE_PATH, true))
                {
                    sw.WriteLine(NowTime.ToString("yyyy-MM-dd HH:mm:ss ") + "抓取SNap.");
                }
                string[] list = StockList.GetCode();
                foreach (var item in list)
                {
                    SnapData data = SnapData.GetSnap(item);
                    Task.Factory.StartNew(() => SnapData.SaveToDB(data));
                }
            }
            if (NowTime.Minute % 30 == 0 && flag)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(LOG_FILE_PATH, true))
                {
                    sw.WriteLine(NowTime.ToString("yyyy-MM-dd HH:mm:ss ") + "抓取公告.");
                }
                Announcement.Load();
            }
            if (NowTime.Hour == 16 && NowTime.Minute == 0 && flag)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(LOG_FILE_PATH, true))
                {
                    sw.WriteLine(NowTime.ToString("yyyy-MM-dd HH:mm:ss ") + "固定script.");
                }
                string[] stock_list = StockList.GetCode();
                for (int i = 0; i < stock_list.Length; i++)
                {
                    StockLineData data = StockLineData.GetLineDataObject(stock_list[i]);
                    Task.Factory.StartNew(() => StockLineData.SaveToDB(data));
                }
                ECNOData.Insert();
                QuantTradeDLL.StockCACUData.Load();
            }
            if (NowTime.Hour == 16 && NowTime.Minute == 30 && flag)
            {
                StockHisData.ConvertLine();
                flag = false;
            }
        }
    }
}
