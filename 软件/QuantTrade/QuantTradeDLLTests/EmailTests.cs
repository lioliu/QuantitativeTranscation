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
    public class EmailTests
    {
        [TestMethod()]
        public void SentTest()
        {
            //right email adress
            Assert.IsTrue(Email.Sent("744596028@qq.com", "Unit test"));
            //wrong email adress
            Assert.IsFalse(Email.Sent("7028@qq.com", "Unit test"));
           
        }
    }
}