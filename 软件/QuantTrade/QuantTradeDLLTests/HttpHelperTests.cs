using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantTradeDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantTradeDLL.Tests
{
    [TestClass()]
    public class HttpHelperTests
    {
        [TestMethod()]
        public void GetHtmlTest()
        {
            HttpItem item = new HttpItem();
            item.URL = "http://yunhq.sse.com.cn:32041/v1/sh1/list/self/000001?select=code%2Cname%2Clast%2Cchg_rate%2Camount%2Copen%2Cprev_close";
            
            StringAssert.Contains(new HttpHelper().GetHtml(item).Html, "上证指数");
        }


    }
}