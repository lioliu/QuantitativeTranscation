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
    public class LineDataTests
    {
        [TestMethod()]
        public void FormaterTest()
        {
            string oldString = "({\"code\":\"600000\",\"prev_close\":15.30,\"date\":20170419,\"time\":142034,\"total\":202,\"begin\":0,\"end\":1,\"line\":[[93000,15.25,95200]]})";
            string newString = LineData.Formater(oldString);
            string targetString = "{\"code\":\"600000\",\"prev_close\":\"15.30\",\"date\":\"20170419\",\"time\":\"142034\",\"total\":\"202\",\"begin\":\"0\",\"end\":\"1\",\"line\":[{\"time\":\"93000\",\"price\":\"15.25\",\"volume\":\"95200\"}]}";
            StringAssert.Contains(newString, targetString);
        }
    }
}