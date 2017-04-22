using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuantTradeDLL.Crawler;
using System.Data;
using System.Threading;

namespace ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {


            //string[] list = StockList.GetCode();
            //foreach (var item in list)
            //{
            //    Task.Factory.StartNew(() => SnapData.GetSnap(item));

            //}
            //   QuantTradeDLL.Crawler.BaseCrawler crawler = new QuantTradeDLL.Crawler.BaseCrawler();
            //  Console.WriteLine(crawler.Run("http://hq.sinajs.cn/list=sh601006"));



            //load all line data
            //string[] stockList = QuantTradeDLL.Crawler.StockList.GetCode();
            //for (int i = 0; i < stockList.Length; i++)
            //{

            //    QuantTradeDLL.Crawler.StockLineData data =  QuantTradeDLL.Crawler.StockLineData.GetLineDataObject(stockList[i]);
            //    Task.Factory.StartNew(() => QuantTradeDLL.Crawler.StockLineData.SaveToDB(data));
            //    Console.WriteLine($"{stockList[i]}");
            //    Thread.Sleep(200);
            //}
            //Task.WaitAll();
            //Console.WriteLine("finished");



            //load all his data


            /*      //clearn the data in database 
                  QuantTradeDLL.DBUtility.OracleClient.ExecuteSQL("DELETE FROM STOCK_HIS_DATA");

                  //get the stock list
                  string[] stockList = QuantTradeDLL.Crawler.StockList.GetCode();
              string temp;
                  for (int i = 0; i < stockList.Length; i++)
                  {
                  temp = stockList[i];
                  DataTable dt = 
                  QuantTradeDLL.Crawler.StockHisData.ToDataTable(
                  QuantTradeDLL.Crawler.StockHisData.GetHisData(temp));
                      Task.Factory.StartNew(() => QuantTradeDLL.Crawler.StockHisData.SaveToDB(dt));
                  // Task.Factory.StartNew(() => funcation(temp));
                  //Thread.Sleep(2000);
                  Console.WriteLine($"{temp}");
                  }
                  Task.WaitAll();

            */
            Console.ReadLine();
        }

 
    }
}
