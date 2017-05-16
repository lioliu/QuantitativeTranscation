using QuantTradeDLL.Crawler;
using QuantTradeDLL.DBUtility;
using QuantTradeDLL;
using System;
using System.Data;
using System.ServiceProcess;
namespace Warn_Service
{
    public partial class Service1 : ServiceBase
    {
        private System.Timers.Timer timer1;
        const string LOG_FILE_PATH = "C:\\Warning-Service-log.txt";
        public Service1()
        {
            InitializeComponent();
            timer1 = new System.Timers.Timer()
            {
                Interval = 60000  //设置计时器事件间隔执行时间
            };
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Elapsed);
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
        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(LOG_FILE_PATH, true))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "推送公告.");
            }
            //推送公告
            DataTable stock_list = OleDb.GetData("select * from  ANNOUNCEMENT where  code in (select code from PUSH_LIST) and alarmed = 0").Tables[0];
            string EmailAdress = OleDb.GetData("select email from base_infor").Tables[0].Rows[0][0].ToString();
            string PhoneNumber = OleDb.GetData("select phone from base_infor").Tables[0].Rows[0][0].ToString();
            string message = string.Empty;
            for (int i = 0; i < stock_list.Rows.Count; i++)
            {
                message = $"股票公告通知:\n 股票代码:{stock_list.Rows[i]["CODE"].ToString()} \n 标题为: {stock_list.Rows[i]["TITLE"].ToString()} \n 点击链接查看详情:{stock_list.Rows[i]["URL"].ToString()}";
                Email.Sent(EmailAdress, message);
            }
            OleDb.GetData("update ANNOUNCEMENT set alarmed = 1");
            //股票预警
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(LOG_FILE_PATH, true))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "预警股票.");
            }
            DataTable warning_list = OleDb.GetData("select * from stock_warning where state = 'open'").Tables[0];
            for (int i = 0; i < warning_list.Rows.Count; i++)
            {
                // crawl the  data imm
                SnapData.SaveToDB(SnapData.GetSnap(warning_list.Rows[i]["CODE"].ToString()));
                //caculate the MA
                StockCACUData.Load(warning_list.Rows[i]["CODE"].ToString());
                if (OleDb.GetData(warning_list.Rows[i]["LOGISTICS"].ToString()).Tables[0].Rows[0][0].ToString().Equals("1"))
                {
                    //组织message
                    message = $"股票预警:\n 股票代码:{warning_list.Rows[i]["CODE"].ToString()} \n 标题为: {warning_list.Rows[i]["NAME"].ToString()} 的预警被触发 \n 详细说明为:{warning_list.Rows[i]["EXPLAIN"].ToString()}\n 请及时进行处理";
                    //满足条件进行预警
                    switch (warning_list.Rows[i]["ways"].ToString())
                    {
                        case "phone":
                            Message.Send(PhoneNumber, message);
                            break;
                        case "email":
                            Email.Sent(EmailAdress, message);
                            break;
                        default:
                            break;
                    }
                    //关闭已预警
                    OleDb.ExecuteSQL($"UPdate stock_warning set state = 'close' where id = '{warning_list.Rows[i]["ID"].ToString()}' ");
                }
            }
        }
    }
}
