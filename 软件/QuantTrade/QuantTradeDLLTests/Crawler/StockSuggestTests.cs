using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantTradeDLL.Crawler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QuantTradeDLL.Crawler.Tests
{
    [TestClass()]
    public class StockSuggestTests
    {
        [TestMethod()]
        public void StockSuggestTest()
        {
            StockSuggest data = StockSuggest.Get();
            Assert.AreEqual(StockSuggest.SaveToDB(data),1303);
        }
    }
}