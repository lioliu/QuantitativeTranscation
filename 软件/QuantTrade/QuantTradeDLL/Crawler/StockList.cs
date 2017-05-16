using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace QuantTradeDLL.Crawler
{
    public class StockList
    {
        /// <summary>
        /// 获取所有的股票代码
        /// </summary>
        /// <returns></returns>
        public static string[] GetCode()
        {
            DataSet ds = DBUtility.OleDb.GetData("select Code  from stock_list order by code");
            string[] list = new string[ds.Tables[0].Rows.Count];
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                list[i] = ds.Tables[0].Rows[i][0].ToString();
            }
            return list;
            
        }
        /// <summary>
        /// 获取关注列表
        /// </summary>
        /// <returns></returns>
        public static string[] GetFocusCode()
        {
            DataSet ds = DBUtility.OleDb.GetData("select Code  from focus_list order by code");
            string[] list = new string[ds.Tables[0].Rows.Count];
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                list[i] = ds.Tables[0].Rows[i][0].ToString();
            }
            return list;
        }
    }
}
