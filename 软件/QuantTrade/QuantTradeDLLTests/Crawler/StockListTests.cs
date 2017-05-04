using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantTradeDLL.Crawler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantTradeDLL.Crawler.Tests
{
    [TestClass()]
    public class StockListTests
    {
        [TestMethod()]
        public void GetCodeTest()
        {
            string[] stockList = StockList.GetCode();
            Assert.AreEqual(stockList.Length, 1248);
        }

        [TestMethod()]
        public void GetFocusCodeTest()
        {
            string[] stockList = StockList.GetFocusCode();
            
            Assert.AreEqual(stockList.Length, Convert.ToInt32(DBUtility.OleDb.GetData("select count(*) from focus_list ").Tables[0].Rows[0][0].ToString()));
        }
    }
}