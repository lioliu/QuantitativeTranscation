using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantTradeDLL.Crawler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Threading;
namespace QuantTradeDLL.Crawler.Tests
{
    [TestClass()]
    public class SnapDataTests
    {
        [TestMethod()]
        public void GetSnapTest()
        {
            SnapData data =  SnapData.GetSnap("600000");
            StringAssert.Contains(data.Result[0].Data.Gid, "sh600000");
        }
        [TestMethod()]
        public void GetSnapTest1()
        {
            //without thread takes 3 min
            string[] list = StockList.GetCode();
        
            
            SnapData data = SnapData.GetSnap("600000");
            StringAssert.Contains(data.Result[0].Data.Gid, "sh600000");
        }
    }
}