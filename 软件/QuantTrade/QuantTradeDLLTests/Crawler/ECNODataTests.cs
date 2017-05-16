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
    public class ECNODataTests
    {
        [TestMethod()]
        public void UpdateTest()
        {
            Assert.AreEqual(true, ECNOData.Update());
        }
    }
}