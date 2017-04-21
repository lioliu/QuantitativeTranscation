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
    }
}