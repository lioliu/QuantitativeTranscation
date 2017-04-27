using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantTradeDLL.Crawler
{
    public class Announcement
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Days { get; set; }


        public static bool Load()
        {
            string[] stockList = StockList.GetCode();
            foreach (var item in stockList)
            {
                Load(item);
            }
            return true;
        }

        public static DataTable Get(string Code)
        {

            return DBUtility.OracleClient.GetData($"Select * from (select * from announcement where code ='{Code}' order by days desc) where rownum<=10").Tables[0];
        }

        public static bool Load(string code)
        {
            HtmlWeb web = new HtmlWeb()
            {
                OverrideEncoding = Encoding.Default
            };
            HtmlDocument doc = web.Load($"http://quote.eastmoney.com/sh{code}.html");
            HtmlNode Document, Time;
            Announcement data;
            int tag = 1;
            for (tag = 1; tag <= 5; tag++)
            {
                Document = doc.DocumentNode.SelectSingleNode($"/html/body/div[13]/div[2]/div[3]/div[2]/div[2]/div/ul/li[{tag}]/a");
                Time = doc.DocumentNode.SelectSingleNode($"/html/body/div[13]/div[2]/div[3]/div[2]/div[2]/div/ul/li[{tag}]/span");
                try
                {
                    data = new Announcement()
                    {
                        Code = code,
                        Title = Document.Attributes["title"].Value,
                        Url = Document.Attributes["href"].Value,
                        Days = Time.InnerHtml
                    };
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                    continue;
                }


                if (DBUtility.OracleClient.GetData($"SELECT COUNT(*) FROM Announcement where Code = '{data.Code}' and Url = '{data.Url}' ").Tables[0].Rows[0][0].ToString() == "0")
                {
                    
                    //formate the date;
                    string date = DateTime.Now.Year.ToString() + "-" + data.Days;
                    //Console.WriteLine(insert);
                    DBUtility.OleDb.ExecuteSQL($"Insert INTO Announcement VALUES ('{data.Code}','{data.Title}','{data.Url}',TO_DATE('{date}','YYYY-MM-DD'),'0')");
                    Console.WriteLine(code + " " + tag  );
                }
                else
                {
                    Console.WriteLine(code + " nomore announcement");
                    break;
                }
            }
            return true;
        }
    }
}
