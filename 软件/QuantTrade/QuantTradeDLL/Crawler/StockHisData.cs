using QuantTradeDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data;

namespace QuantTradeDLL.Crawler
{

    public class StockHisData
    {
        public string Code { set; get; }
        public string Total { set; get; }
        public string Begin { set; get; }
        public string End { set; get; }
        public Kline[] Kline { set; get; }

        /// <summary>
        /// Convert today's Line data to His data 
        /// </summary>
        /// <returns></returns>
        private int ConvertLine()
        {
            return  DBUtility.OracleClient.ExecuteSQL("insert into STOCK_HIS_DATA select base.code, base.days, op.price, max(base.price), min(base.price), cl.price, sum(volume)" +
                    "from STOCK_LINE_DATA base left join " +
                    "(select code, price from stock_line_data where days = to_char(sysdate, 'yyyymmdd') and time = '93000') op on base.code = op.code " +
                    "left join (select code, price from stock_line_data where days = to_char(sysdate, 'yyyymmdd') and time = '150000')cl " +
                    "on  base.code = cl.code where base.days = to_char(sysdate, 'yyyymmdd') group by base.code, days, op.price, cl.price");            
        }
        /// <summary>
        /// Convert Line data to His data at the given date
        /// </summary>
        /// <param name="date">formated as yyyymmdd</param>
        /// <returns></returns>
        private int ConvertLine(string date)
        {
            return DBUtility.OracleClient.ExecuteSQL($"insert into STOCK_HIS_DATA select base.code, base.days, op.price, max(base.price), min(base.price), cl.price, sum(volume)" +
                    "from STOCK_LINE_DATA base left join " +
                    $"(select code, price from stock_line_data where days = '{date}' and time = '93000') op on base.code = op.code " +
                    $"left join (select code, price from stock_line_data where days =  '{date}' and time = '150000')cl " +
                    $"on  base.code = cl.code where base.days =  '{date}' group by base.code, days, op.price, cl.price");
        }

        /// <summary>
        /// Get all stock Kline data by given code
        /// </summary>
        /// <param name="code">stock code</param>
        /// <returns></returns>
        public static StockHisData GetHisData(string code)
        {
            BaseCrawler crawler = new BaseCrawler();
            string json = crawler.Run($"http://yunhq.sse.com.cn:32041/v1/sh1/dayk/{code}?callback=&select=date%2Copen%2Chigh%2Clow%2Cclose%2Cvolume&begin=0&end=-1");
            json = JsonFormater.HisData.Formater(json);
            return JsonConvert.DeserializeObject<StockHisData>(json);
        }
        /// <summary>
        /// load 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static StockHisData GetHisData(string code,string begin,string end)
        {
            BaseCrawler crawl = new BaseCrawler();
            string json = crawl.Run($"http://yunhq.sse.com.cn:32041/v1/sh1/dayk/{code}?callback=&select=date%2Copen%2Chigh%2Clow%2Cclose%2Cvolume&begin={begin}&end={end}");
            json = JsonFormater.HisData.Formater(json);
            return JsonConvert.DeserializeObject<StockHisData>(json);
        }

        private static int SaveToDB(StockHisData hisData)
        {
            string insert = string.Empty;
            List<string> insertscript = new List<string>();
            DataTable dt = ToDataTable(hisData);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                insert = "INSERT INTO STOCK_HIS_DATA VALUES" + $"('{dt.Rows[i]["CODE"]}','{dt.Rows[i]["DAYS"]}','{dt.Rows[i]["OPEN"]}','{dt.Rows[i]["HIGH"]}','{dt.Rows[i]["LOW"]}','{dt.Rows[i]["CLOSE"]}','{dt.Rows[i]["AMOUNT"]}')";
                insertscript.Add(insert);
            }
            return DBUtility.OracleClient.ExecuteSQL(insertscript);
        }

        private static int SaveToDB(DataTable dt)
        {
            string insert = string.Empty;
            List<string> insertscript = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                insert = "INSERT INTO STOCK_HIS_DATA VALUES" + $"('{dt.Rows[i]["CODE"]}','{dt.Rows[i]["DAYS"]}','{dt.Rows[i]["OPEN"]}','{dt.Rows[i]["HIGH"]}','{dt.Rows[i]["LOW"]}','{dt.Rows[i]["CLOSE"]}','{dt.Rows[i]["AMOUNT"]}')";
                insertscript.Add(insert);
            }
            return DBUtility.OracleClient.ExecuteSQL(insertscript);
        }



        private static DataTable ToDataTable(StockHisData data)
        {
            DataTable dt = new DataTable("StockData");
            dt.Columns.Add("CODE", Type.GetType("System.String"));
            dt.Columns.Add("DAYS", Type.GetType("System.String"));
            dt.Columns.Add("OPEN", Type.GetType("System.Double"));
            dt.Columns.Add("HIGH", Type.GetType("System.Double"));
            dt.Columns.Add("LOW", Type.GetType("System.Double"));
            dt.Columns.Add("CLOSE", Type.GetType("System.Double"));
            dt.Columns.Add("AMOUNT", Type.GetType("System.Double"));
            DataRow Newrow;
            foreach (var item in data.Kline)
            {
                Newrow = dt.NewRow();
                Newrow["CODE"] = data.Code;
                Newrow["DAYS"] = item.Date;
                Newrow["OPEN"] = Convert.ToDouble(item.Open);
                Newrow["HIGH"] = Convert.ToDouble(item.High);
                Newrow["LOW"] = Convert.ToDouble(item.Low);
                Newrow["CLOSE"] = Convert.ToDouble(item.Close);
                Newrow["AMOUNT"] = Convert.ToDouble(item.Amount);
                dt.Rows.Add(Newrow);
            }
            return dt;
        }


    }



}
