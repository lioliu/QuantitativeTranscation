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
    public class StockHisDataTests
    {
        [TestMethod()]
        public void GetHisDataTest()
        {
            StockHisData temp = StockHisData.GetHisData("600000");
            StringAssert.Equals("600000", temp.Code);
        }

        [TestMethod()]
        public void GetHisDataTest1()
        {
            StockHisData temp = StockHisData.GetHisData("600004", "0", "1");
            StringAssert.Equals("600004", temp.Code);
            Assert.AreEqual(temp.Kline.Length, 1);
        }

        [TestMethod()]
        public void ConvertLineTest()
        {

        }

        [TestMethod()]
        public void ConvertLineTest1()
        {

        }
    }
}