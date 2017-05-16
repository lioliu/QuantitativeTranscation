using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuantTradeDLL.Crawler;
using System.Data;
namespace QuantTradeDLL
{
    public class StockCACUData
    {
        /// <summary>
        /// 计算并插入数据库
        /// </summary>
        /// <returns></returns>
        public static int Load()
        {
            string[] stockList = StockList.GetCode();
            foreach (var stock in stockList)
            {
                DataTable data = DBUtility.OleDb.GetData($"SELECT * from STOCK_HIS_DATA WHERE CODE = '{stock}' ORDER BY DAYS ").Tables[0];
                double MA5 = 0;
                double MA10 = 0;
                double MA20 = 0;
                double MA30 = 0;
                for (int i = 0; i < 5; i++)
                {
                    try
                    {
                        MA5 += Convert.ToDouble(data.Rows[i]["CLOSE"].ToString());
                    }
                    catch (Exception)
                    {
                        MA5 = -5;
                        break;
                    }
                }
                MA5 /= 5;
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        MA10 += Convert.ToDouble(data.Rows[i]["CLOSE"].ToString());
                    }
                    catch (Exception)
                    {
                        MA10 = -10;
                        break;
                    }
                }
                MA10 /= 10;
                for (int i = 0; i < 20; i++)
                {
                    try
                    {
                        MA20 += Convert.ToDouble(data.Rows[i]["CLOSE"].ToString());
                    }
                    catch (Exception)
                    {
                        MA20 = -20;
                        break;
                    }
                }
                MA20 /= 20;
                for (int i = 0; i < 30; i++)
                {
                    try
                    {
                        MA30 += Convert.ToDouble(data.Rows[i]["CLOSE"].ToString());
                    }
                    catch (Exception)
                    {
                        MA30 = -30;
                        break;
                    }
                }
                MA30 /= 30;
                DBUtility.OleDb.ExecuteSQL($"INSERT INTO STOCK_CACU_DATA VALUES ('{stock}',{MA5},{MA10},{MA20},{MA30},sysdate)");
            }
            return 0;
        }
    }
}
