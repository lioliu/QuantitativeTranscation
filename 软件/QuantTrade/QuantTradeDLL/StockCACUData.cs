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
            DBUtility.OleDb.ExecuteSQL("delete from STOCK_CACU_DATA where TO_CHAR(DAYS,'YYYYMMDD') = TO_CHAR(SYSDATE,'YYYYMMDD')");

            foreach (var stock in stockList)
            {
                double nowPrice = Convert.ToDouble(SnapData.GetSnap(stock).Result[0].Data.NowPri);
                DataTable data = DBUtility.OleDb.GetData($"SELECT * from STOCK_HIS_DATA WHERE CODE = '{stock}' ORDER BY DAYS ").Tables[0];
                double MA5 = nowPrice;
                double MA10 = nowPrice;
                double MA20 = nowPrice;
                double MA30 = nowPrice;
                for (int i = 1; i < 5; i++)
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
                for (int i = 1; i < 10; i++)
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
                for (int i = 1; i < 20; i++)
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
                for (int i = 1; i < 30; i++)
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
        public static int Load(string stock)
        {
            DBUtility.OleDb.ExecuteSQL($"delete from STOCK_CACU_DATA where TO_CHAR(DAYS,'YYYYMMDD') = TO_CHAR(SYSDATE,'YYYYMMDD') and code = '{stock}'");

            double nowPrice = Convert.ToDouble(SnapData.GetSnap(stock).Result[0].Data.NowPri);
            DataTable data = DBUtility.OleDb.GetData($"SELECT * from STOCK_HIS_DATA WHERE CODE = '{stock}' ORDER BY DAYS ").Tables[0];
            double MA5 = nowPrice;
            double MA10 = nowPrice;
            double MA20 = nowPrice;
            double MA30 = nowPrice;
            for (int i = 1; i < 5; i++)
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
            for (int i = 1; i < 10; i++)
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
            for (int i = 1; i < 20; i++)
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
            for (int i = 1; i < 30; i++)
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

            return 0;
        }
    }
}
