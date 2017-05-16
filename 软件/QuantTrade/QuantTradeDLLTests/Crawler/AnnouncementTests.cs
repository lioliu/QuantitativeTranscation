using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantTradeDLL.Crawler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QuantTradeDLL.Crawler.Tests
{
    [TestClass()]
    public class AnnouncementTests
    {
        [TestMethod()]
        public void LoadTest()
        {
            Assert.AreEqual(Announcement.Load(), true);
        }
        [TestMethod()]
        public void GetTest()
        {
            DataTable dt = Announcement.Get("600000");
            StringAssert.Contains(dt.Rows[0][0].ToString(), "600000");
 
        }
    }
}