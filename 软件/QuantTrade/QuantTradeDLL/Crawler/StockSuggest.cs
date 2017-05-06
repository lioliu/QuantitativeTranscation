using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data;
using System.Collections;

namespace QuantTradeDLL.Crawler
{
    public class StockSuggest
    {
        public Suggest[] suggest { set; get; }


        public static StockSuggest Get()
        {
            BaseCrawler crawler = new BaseCrawler();
            string json = crawler.Run("http://www.sse.com.cn/js/common/ssesuggestdata.js");
            json = JsonFormater.SuggestList.Formater(json);
            return JsonConvert.DeserializeObject<StockSuggest>(json);

        }

        private static DataTable ToDataTable(StockSuggest data)
        {
            DataTable dt = new DataTable("StockSuggest");
            dt.Columns.Add("CODE", Type.GetType("System.String"));
            dt.Columns.Add("NAME", Type.GetType("System.String"));
            dt.Columns.Add("PY", Type.GetType("System.String"));
      
            DataRow Newrow;
            foreach (var item in data.suggest)
            {
                Newrow = dt.NewRow();
                Newrow["CODE"] = item.code;
                Newrow["NAME"] = item.name;
                Newrow["PY"] = item.py;
              
                dt.Rows.Add(Newrow);
            }
            return dt;
        }

        public static int SaveToDB(StockSuggest data)
        {
            string[] list = StockList.GetCode();
            string insert = string.Empty;
            List<string> insertscript = new List<string>();
            DataTable dt = ToDataTable(data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (list.Contains(dt.Rows[i]["CODE"]))
                {
                    insert = "INSERT INTO STOCKSUGGEST VALUES" + $"('{dt.Rows[i]["CODE"]}','{dt.Rows[i]["NAME"]}','{dt.Rows[i]["PY"]}')";
                    insertscript.Add(insert);
                }
            }
            return DBUtility.OleDb.ExecuteSQL(insertscript);
        }



    }

 

}
