using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using QuantTradeDLL.Crawler;
using QuantTradeDLL.DBUtility;

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
        }

        protected override void OnStart(string[] args)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(LOG_FILE_PATH, true))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "Start.");
            }
            timer1 = new System.Timers.Timer();
            timer1.Interval = 60000;  //设置计时器事件间隔执行时间
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Elapsed);
            timer1.Enabled = true;
            flag = true;
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
            //判断时间 执行不同操作

            if (DateTime.Now.Hour == 09 && DateTime.Now.Minute == 30)
            {

                flag = TradeDay(DateTime.Now.ToString("yyyyMMdd"));
            }

            if(DateTime.Now.Minute %10 == 0 && flag)
            {
                string[] list = StockList.GetCode();
                foreach (var item in list)
                {
                    SnapData data = SnapData.GetSnap(item);
                    Task.Factory.StartNew(() => SnapData.SaveToDB(data));
                }
            }

            if (DateTime.Now.Minute % 30 == 0 && flag)
            {
                Announcement.Load();
            }

            if (DateTime.Now.Hour == 16 && DateTime.Now.Minute == 0 && flag)
            {
                string[] stock_list = StockList.GetCode();
                for (int i = 0; i < stock_list.Length; i++)
                {
                    StockLineData data = StockLineData.GetLineDataObject(stock_list[i]);
                    Task.Factory.StartNew(() => StockLineData.SaveToDB(data));
                }

                ECNOData.Insert();
               
            }

            if (DateTime.Now.Hour == 16 && DateTime.Now.Minute ==30  && flag)
            {
                StockHisData.ConvertLine();
                flag = false;
            }
        }
    }
}
