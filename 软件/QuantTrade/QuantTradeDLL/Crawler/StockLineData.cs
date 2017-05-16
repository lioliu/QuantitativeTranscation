using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Threading;
using QuantTradeDLL.DBUtility;
namespace QuantTradeDLL.Crawler
{
    public class StockLineData
    {
        public string Code { set; get; }
        public string PreClose { set; get; }
        public string Date { set; get; }
        public string Time { set; get; }
        public string Total { set; get; }
        public string Begin { set; get; }
        public string End { set; get; }
        public Line[] Line { set; get; }
        //take 4 mins
        
        public static DataTable ToDataTable(StockLineData data)
        {
            DataTable dt = new DataTable("Line_data");
            dt.Columns.Add("CODE", Type.GetType("System.String"));
            dt.Columns.Add("DAYS", Type.GetType("System.String"));
            dt.Columns.Add("TIME", Type.GetType("System.String"));
            dt.Columns.Add("PRICE", Type.GetType("System.Double"));
            dt.Columns.Add("VOLUME", Type.GetType("System.Double"));
            DataRow Newrow;
            foreach (var item in data.Line)
            {
                Newrow = dt.NewRow();
                Newrow["CODE"] = data.Code;
                Newrow["DAYS"] = data.Date;
                Newrow["TIME"] = item.Time; ;
                Newrow["PRICE"] = item.Price;
                Newrow["VOLUME"] = item.Volume;
                dt.Rows.Add(Newrow);
            }
            return dt;
        }
        public static DataTable ForCharts(StockLineData data)
        {
            DataTable dt = new DataTable("Line_data");
            dt.Columns.Add("CODE", Type.GetType("System.String"));
            dt.Columns.Add("TIME", Type.GetType("System.String"));
            dt.Columns.Add("PRICE", Type.GetType("System.Double"));
            dt.Columns.Add("VOLUME", Type.GetType("System.Double"));
            DataRow Newrow;
            foreach (var item in data.Line)
            {
                Newrow = dt.NewRow();
                Newrow["CODE"] = data.Code;
                Newrow["TIME"] = item.Time.Substring(0, item.Time.Length - 4)+":"+ item.Time.Substring(item.Time.Length - 4, 2);
                Newrow["PRICE"] = item.Price;
                Newrow["VOLUME"] = item.Volume;
                dt.Rows.Add(Newrow);
            }
            return dt;
        }
        public static StockLineData GetLineDataObject(string code)
        {
            Random rnd = new Random();
            BaseCrawler crawler = new BaseCrawler();
            string URL = $"http://yunhq.sse.com.cn:32041/v1/sh1/line/{code}?callback=&begin=0&end=-1&select=time%2Cprice%2Cvolume&_={rnd.Next()}";
            string json = crawler.Run(URL);
            //Console.WriteLine(json);
            json = JsonFormater.LineData.Formater(json);
            return JsonConvert.DeserializeObject<StockLineData>(json);
        }
        public static int SaveToDB(DataTable dt)
        {
            string insert = string.Empty;
            List<string> insertscript = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                insert = $"INSERT INTO STOCK_LINE_DATA VALUES{$"('{dt.Rows[i]["CODE"]}','{dt.Rows[i]["DAYS"]}','{dt.Rows[i]["TIME"]}','{dt.Rows[i]["PRICE"]}','{dt.Rows[i]["VOLUME"]}')"}";
                insertscript.Add(insert);
            }
            int result = OracleClient.ExecuteSQL(insertscript);
            //Console.WriteLine(result);
            return result;
        }
        public static int SaveToDB(StockLineData data)
        {
            string insert = string.Empty;
            List<string> insertscript = new List<string>();
            DataTable dt = ToDataTable(data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                insert = $"INSERT INTO STOCK_LINE_DATA VALUES{$"('{dt.Rows[i]["CODE"]}','{dt.Rows[i]["DAYS"]}','{dt.Rows[i]["TIME"]}','{dt.Rows[i]["PRICE"]}','{dt.Rows[i]["VOLUME"]}')"}";
                insertscript.Add(insert);
            }
            int result = OracleClient.ExecuteSQL(insertscript);
            //Console.WriteLine(result);
            return result;
        }
    }
}