using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace QuantTradeDLL.Crawler
{
    public class StockList
    {




       
        //wait to develop
        public static string[] GetCode()
        {
            DataSet ds = DBUtility.OracleClient.GetData("select Code  from stock_list");
            string[] list = new string[ds.Tables[0].Rows.Count];
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                list[i] = ds.Tables[0].Rows[i][0].ToString();
            }
            return list;
            
        }
        public static string[] GetFocusCode()
        {
            DataSet ds = DBUtility.OracleClient.GetData("select Code  from focus_list");
            string[] list = new string[ds.Tables[0].Rows.Count];
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                list[i] = ds.Tables[0].Rows[i][0].ToString();
            }
            return list;

        }




    }
}
