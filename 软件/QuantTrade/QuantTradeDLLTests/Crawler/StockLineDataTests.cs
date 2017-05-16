using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantTradeDLL.Crawler;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QuantTradeDLL.Crawler.Tests
{
    [TestClass()]
    public class StockLineDataTests
    {
        [TestMethod()]
        public void GetLineDataObjectTest()
        {
            StockLineData lineData = StockLineData.GetLineDataObject("600000");
            Assert.AreEqual(lineData.Code, "600000");
        }
        [TestMethod()]
        public void SaveToDBTest()
        {
            DBUtility.OracleClient.ExecuteSQL("delete from stock_line_data where days ='20170502' and code= '600000'");
            StockLineData lineData = StockLineData.GetLineDataObject("600000");
            DataTable dt = new DataTable("Line_data");
            dt.Columns.Add("CODE", Type.GetType("System.String"));
            dt.Columns.Add("DAYS", Type.GetType("System.String"));
            dt.Columns.Add("TIME", Type.GetType("System.String"));
            dt.Columns.Add("PRICE", Type.GetType("System.Double"));
            dt.Columns.Add("VOLUME", Type.GetType("System.Double"));
            DataRow Newrow;
            foreach (var item in lineData.Line)
            {
                Newrow = dt.NewRow();
                Newrow["CODE"] = lineData.Code;
                Newrow["DAYS"] = lineData.Date;
                Newrow["TIME"] = item.Time; ;
                Newrow["PRICE"] = item.Price;
                Newrow["VOLUME"] = item.Volume;
                dt.Rows.Add(Newrow);
            }
            Assert.AreEqual(StockLineData.SaveToDB(dt), 241);
        }
        [TestMethod()]
        public void SaveToDBTest1()
        {
            //
            DBUtility.OracleClient.ExecuteSQL("delete from stock_line_data where days ='20170502' and code= '600000'");
            StockLineData lineData = StockLineData.GetLineDataObject("600000");
            Assert.AreEqual(StockLineData.SaveToDB(lineData), 241);
        }
    }
}