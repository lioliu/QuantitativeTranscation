using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantTradeDLL.DBUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;

namespace QuantTradeDLL.DBUtility.Tests
{
    [TestClass()]
    public class OracleClientTests
    {
        [TestMethod()]
        public void ExecuteSQLTest()
        {
            
            Assert.AreEqual(OracleClient.ExecuteSQL("SELECT SYSDATE FROM DUAL"), -1);

        }

        [TestMethod()]
        public void ExecuteSQLTest1()
        {
            List<string> sqlList = new List<string>
            {
                "SELECT SYSDATE FROM DUAL"
            };
            Assert.AreEqual(OracleClient.ExecuteSQL(sqlList), -1);
        }

        [TestMethod()]
        public void GetDataTest()
        {
            StringAssert.Contains("2017-04-05", OracleClient.GetData("SELECT '2017-04-05' FROM DUAL").Tables[0].Rows[0][0].ToString());
        }

        [TestMethod()]
        public void GetDataTest1()
        {
            List<string> sqlList = new List<string>
            {
                "SELECT '2017-04-05' FROM DUAL",
                "SELECT '2017-04-06' FROM DUAL"
            };
            DataSet dataSet = OracleClient.GetData(sqlList);
            StringAssert.Contains("2017-04-05", dataSet.Tables[0].Rows[0][0].ToString());
            StringAssert.Contains("2017-04-06", dataSet.Tables[1].Rows[0][0].ToString());
        }

        [TestMethod()]
        public void ProceureToParameterTest()
        {
            OracleParameter[] parameter = new OracleParameter[1];
            parameter[0] = new OracleParameter("PARAM1", OracleDbType.Varchar2, 200);
            parameter[0].Direction = ParameterDirection.Output;
            OracleClient.ProceureToParameter("LIOLIU.TESTSET.TEST", parameter);
            StringAssert.Contains("success", parameter[0].Value.ToString());
        }

        [TestMethod()]
        public void ProceureToTableTest()
        {
            OracleParameter[] parameter = new OracleParameter[1];
            parameter[0] = new OracleParameter("PARAM1", OracleDbType.RefCursor)    
            {
                Direction = ParameterDirection.Output
            };
            DataSet dataSet = OracleClient.ProceureToTable("LIOLIU.TESTSET.TEST2", parameter);
            StringAssert.Contains("success", dataSet.Tables[0].Rows[0][0].ToString());
        }
    }
}