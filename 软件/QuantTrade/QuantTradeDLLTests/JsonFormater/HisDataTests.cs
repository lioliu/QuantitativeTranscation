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
    public class HisDataTests
    {
        [TestMethod()]
        public void FormaterTest()
        {
            string oldString = "({\"code\":\"600000\",\"total\":4105,\"begin\":0,\"end\":1,\"kline\":[[19991110,29.50,29.80,27.00,27.75,174085000]]})";
            string newString = HisData.Formater(oldString);
            string targetString = "{\"code\":\"600000\",\"total\":\"4105\",\"begin\":\"0\",\"end\":\"1\",\"kline\":[{\"date\":\"19991110\",\"open\":\"29.50\",\"high\":\"29.80\",\"low\":\"27.00\",\"close\":\"27.75\",\"amount\":\"174085000\"}]}";
            StringAssert.Contains(newString, targetString);
            //StringAssert.Contains(newString, oldString);
        }
    }
}