using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantTradeDLL.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
namespace QuantTradeDLL.DBUtility.Tests
{
    [TestClass()]
    public class OleDbTests
    {
        [TestMethod()]
        public void ExecuteSQLTest()
        {
            Assert.AreEqual(OleDb.ExecuteSQL("SELECT SYSDATE FROM DUAL"), 0);
        }
        [TestMethod()]
        public void ExecuteSQLTest1()
        {
            List<string> sqlList = new List<string>
            {
                "SELECT SYSDATE FROM DUAL"
            };
            Assert.AreEqual(OleDb.ExecuteSQL(sqlList), 0);
        }
        [TestMethod()]
        public void GetDataTest()
        {
            StringAssert.Contains("2017-04-05", OleDb.GetData("SELECT '2017-04-05' FROM DUAL").Tables[0].Rows[0][0].ToString());
        }
        [TestMethod()]
        public void GetDataTest1()
        {
            List<string> sqlList = new List<string>
            {
                "SELECT '2017-04-05' FROM DUAL",
                "SELECT '2017-04-06' FROM DUAL"
            };
            DataSet dataSet = OleDb.GetData(sqlList);
            StringAssert.Contains("2017-04-05", dataSet.Tables[0].Rows[0][0].ToString());
            StringAssert.Contains("2017-04-06", dataSet.Tables[1].Rows[0][0].ToString());
        }
        [TestMethod()]
        public void ProceureToParameterTest()
        {
            OleDbParameter[] parameter = new OleDbParameter[1];
            parameter[0] = new OleDbParameter("PARAM1", OleDbType.VarChar, 200)
            {
                Direction = ParameterDirection.Output
            };
            OleDb.ProceureToParameter("LIOLIU.TESTSET.TEST", parameter);
            StringAssert.Contains("success", parameter[0].Value.ToString());
        }
        
    }
}