using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuantTradeDLL;
using System.Data;
using System.Threading;

namespace ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        { 
                //clearn the data in database 
                QuantTradeDLL.DBUtility.OracleClient.ExecuteSQL("DELETE FROM STOCK_HIS_DATA");

                //get the stock list
                string[] stockList = QuantTradeDLL.Crawler.StockList.GetCode();
            string temp;
                for (int i = 0; i < stockList.Length; i++)
                {
                temp = stockList[i];
                Console.WriteLine(temp.ToString());
                Thread.Sleep(1000);
                Task.Factory.StartNew(() => funcation(temp));

                }
                Task.WaitAll();

          
            Console.ReadLine();
        }

        private static void funcation(string code)
        {
            QuantTradeDLL.Crawler.StockHisData.SaveToDB(QuantTradeDLL.Crawler.StockHisData.GetHisData(code));
                Console.WriteLine($"{code} finished");
            
        }
    }
}
