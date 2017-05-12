using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuantTradeDLL;
using System.Data;
using System.Threading;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using QuantTradeDLL.DBUtility;
using QuantTradeDLL.Crawler;
namespace ConsoleDemo
{
    class Program
    {
        static System.Timers.Timer timer1;
        static void Main(string[] args)
        {
            timer1 = new System.Timers.Timer()
            {
                Interval = 300000/2  //设置计时器事件间隔执行时间
            };
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Elapsed);
            timer1.Enabled = true;

            //QuantTradeDLL.Crawler.Announcement.Load();
            ///QuantTradeDLL.Crawler.StockSuggest.SaveToDB(QuantTradeDLL.Crawler.StockSuggest.Get());
            /////
            //QuantTradeDLL.Crawler.ECNOData.Insert();
            ////Console.Read();
            //string[] list = QuantTradeDLL.Crawler.StockList.GetCode();
            //foreach (var item in list)
            //{
            //    QuantTradeDLL.Crawler.SnapData data = QuantTradeDLL.Crawler.SnapData.GetSnap(item);
            //    Task.Factory.StartNew(() => QuantTradeDLL.Crawler.SnapData.SaveToDB(data));
            //}


            //foreach (var item in list)
            //{

            //    QuantTradeDLL.Crawler.StockLineData data = QuantTradeDLL.Crawler.StockLineData.GetLineDataObject(item);

            //    Task.Factory.StartNew(() => QuantTradeDLL.Crawler.StockLineData.SaveToDB(
            //    data));
            //    Console.WriteLine(item);
            //}
            //string target = "600059";
            //bool flag = false;
            //string[] list = QuantTradeDLL.Crawler.StockList.GetCode();
            //foreach (var item in list)
            //{
            //    if (item == target)
            //    {
            //        flag = true;
            //    }

            //    if(flag == true)
            //    {
            //        QuantTradeDLL.Crawler.StockHisData data = QuantTradeDLL.Crawler.StockHisData.GetHisData(item);
            //        Task.Factory.StartNew(() => QuantTradeDLL.Crawler.StockHisData.SaveToDB(data));

            //        Console.WriteLine(item);
            //    }
            //    else
            //    {
            //        Console.WriteLine("Skip" + item);
            //    }

            //}
            //QuantTradeDLL.Crawler.StockHisData.ConvertLine();
            //QuantTradeDLL.Crawler.StockHisData data = QuantTradeDLL.Crawler.StockHisData.GetHisData("600112");
            //QuantTradeDLL.Crawler.StockHisData.SaveToDB(data);


            Console.Read();
            return;
        }

        private static void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //推送公告
            DataTable stock_list = OleDb.GetData("select * from  ANNOUNCEMENT where  code in (select code from PUSH_LIST) and alarmed = 0").Tables[0];

            string EmailAdress = OleDb.GetData("select email from base_infor").Tables[0].Rows[0][0].ToString();
            string PhoneNumber = OleDb.GetData("select phone from base_infor").Tables[0].Rows[0][0].ToString();
            string message = string.Empty;
            for (int i = 0; i < stock_list.Rows.Count; i++)
            {
                message = $"股票公告通知:\n 股票代码:{stock_list.Rows[i]["CODE"].ToString()} \n 标题为: {stock_list.Rows[i]["TITLE"].ToString()} \n 点击链接查看详情:{stock_list.Rows[i]["URL"].ToString()}";
                QuantTradeDLL.Email.Sent(EmailAdress, message);
            }
            OleDb.GetData("update ANNOUNCEMENT set alarmed = 1");

            //股票预警

            DataTable warning_list = OleDb.GetData("select * from stock_warning where state = 'open'").Tables[0];
            for (int i = 0; i < warning_list.Rows.Count; i++)
            {
                // crawl the  data imm
                SnapData.SaveToDB(SnapData.GetSnap(warning_list.Rows[i]["CODE"].ToString()));
                if (OleDb.GetData(warning_list.Rows[i]["LOGISTICS"].ToString()).Tables[0].Rows[0][0].ToString().Equals("1"))
                {
                    //组织message
                    message = $"股票预警:\n 股票代码:{warning_list.Rows[i]["CODE"].ToString()} \n 标题为: {warning_list.Rows[i]["NAME"].ToString()} 的预警被触发 \n 详细说明为:{warning_list.Rows[i]["EXPLAIN"].ToString()}\n 请及时进行处理";


                    //满足条件进行预警
                    switch (warning_list.Rows[i]["ways"].ToString())
                    {
                        case "phone":
                            QuantTradeDLL.Message.Send(PhoneNumber, message);
                            break;
                        case "email":
                            QuantTradeDLL.Email.Sent(EmailAdress, message);
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