using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantTradeDLL.JsonFormater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantTradeDLL.JsonFormater.Tests
{
    [TestClass()]
    public class SuggestListTests
    {
        [TestMethod()]
        public void FormaterTest()
        {
            Crawler.BaseCrawler crawler = new Crawler.BaseCrawler();
            
            string temp = SuggestList.Formater(crawler.Run("http://www.sse.com.cn/js/common/ssesuggestdata.js"));
            //may fail when the list update
#region   
            StringAssert.Contains(temp, "{\"suggest\":[{\"code\":");
#endregion
        }
    }
}