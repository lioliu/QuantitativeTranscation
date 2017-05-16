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
        //static System.Timers.Timer timer1;
        static void Main(string[] args)
        {
            //StockCACUData.Load(); 

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
                          QuantTradeDLL.Crawler.StockHisData.ConvertLine();
            //QuantTradeDLL.Crawler.StockHisData data = QuantTradeDLL.Crawler.StockHisData.GetHisData("600112");
            //QuantTradeDLL.Crawler.StockHisData.SaveToDB(data);


            Console.Read();
            return;
        }

      
    }
}