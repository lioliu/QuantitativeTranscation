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
namespace ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            //QuantTradeDLL.Crawler.Announcement.Load();
            ///QuantTradeDLL.Crawler.StockSuggest.SaveToDB(QuantTradeDLL.Crawler.StockSuggest.Get());
            ///
            //QuantTradeDLL.Crawler.ECNOData.Insert();
            //Console.Read();
            string[] list  = QuantTradeDLL.Crawler.StockList.GetCode();
            foreach (var item in list)
            {
                QuantTradeDLL.Crawler.StockLineData.SaveToDB(
                QuantTradeDLL.Crawler.StockLineData.GetLineDataObject(item));
                Console.WriteLine(item);
            }
            Console.Read();
                return;
        }
    }
}
