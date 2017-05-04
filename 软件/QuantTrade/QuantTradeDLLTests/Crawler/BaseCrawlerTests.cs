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
    public class BaseCrawlerTests
    {
        [TestMethod()]
        public void RunTest()
        {
            StringAssert.Contains(new BaseCrawler().Run(), "上证指数");


        }

        [TestMethod()]
        public void RunTest1()
        {
            StringAssert.Contains(new BaseCrawler().Run("http://yunhq.sse.com.cn:32041/v1/sh1/list/self/000001?select=code%2Cname%2Clast%2Cchg_rate%2Camount%2Copen%2Cprev_close").ToString(), "上证指数");

            //StringAssert.Contains(new BaseCrawler().Run("http://www.sse.com.cn/js/common/ssesuggestdata.js"), "上证指数");

        }

    }
}