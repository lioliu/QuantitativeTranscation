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
    public class MessageTests
    {
        [TestMethod()]
        public void SendTest()
        {
            Assert.IsTrue(Message.Send("18616835920", "test"));

            Assert.IsFalse(Message.Send("1861685555", "test"));
        }
    }
}