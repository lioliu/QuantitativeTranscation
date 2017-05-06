//using OleDb.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
namespace QuantTradeDLL.DBUtility
{
    /// <summary>
    ///  connect to the database  unable to return couser
    /// </summary>
    public class OleDb
    {
        /// <summary>
        ///  connect string  normal for Query , power connect for Update\Delete\Insert   Oracle
        /// </summary>
        private static string PowerConnect = "Provider=OraOLEDB.Oracle.1;Server=localhost;Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = 180.169.93.178)(PORT = 1521)))(CONNECT_DATA = (SERVICE_NAME = DATACENTER)));User ID = WEI; Password = 20134831517; ";
        #region Execute sql
        /// <summary>
        /// Execute SQL statement 
        /// </summary>
        /// <param name="sql">Statement to be executed</param>
        /// <returns> affected rows</returns>
        public static int ExecuteSQL(string sql)
        {
            int count = 0;
            OleDbConnection con = new OleDbConnection(PowerConnect);
            try
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand(sql, con);
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return count;
        }
        /// <summary>
        /// Execute SQL statement
        /// </summary>
        /// <param name="sqlList">the list of Statements to be executed</param>
        /// <returns> affected rows</returns>
        public static int ExecuteSQL(List<string> sqlList)
        {
            int count = 0;
            OleDbConnection con = new OleDbConnection(PowerConnect);
            con.Open();
            OleDbCommand cmd = new OleDbCommand()
            {
                Connection = con
            };
            OleDbTransaction transaction = con.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                foreach (string sql in sqlList)
                {
                    cmd.CommandText = sql;
                    count += cmd.ExecuteNonQuery();
                }
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw e;
            }
            finally
            {
                con.Close();
                con.Dispose();
                transaction.Dispose();
                cmd.Dispose();
            }
            return count;
        }
        #endregion
        #region GetData
        /// <summary>
        /// get the data by execute the sql
        /// </summary>
        /// <param name="sql">query statement</param>
        /// <returns>result data</returns>
        public static DataSet GetData(string sql)
        {
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            OleDbDataAdapter oda = null;
            try
            {
                oda = new OleDbDataAdapter(sql, PowerConnect);
                oda.Fill(dataTable);
                dataSet.Tables.Add(dataTable);
                oda.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                oda.Dispose();
                dataTable.Dispose();
            }
            return dataSet;
        }
        /// <summary>
        /// Execute SQL statement 
        /// </summary>
        /// <param name="sqlList">the list of the statements to be execute</param>
        /// <returns>result data</returns>
        public static DataSet GetData(List<string> sqlList)
        {
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            OleDbDataAdapter oda = null;
            OleDbConnection con = new OleDbConnection(PowerConnect);
            try
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand()
                {
                    Connection = con
                };
                foreach (string sql in sqlList)
                {
                    cmd.CommandText = sql;
                    oda = new OleDbDataAdapter(cmd);
                    oda.Fill(dataTable);
                    dataSet.Tables.Add(dataTable);
                    dataTable = new DataTable();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Dispose();
                oda.Dispose();
                dataTable.Dispose();
            }
            return dataSet;
        }
        #endregion
        /// <summary>
        /// 执行存储过程返回数据存储在OleDbParameter中
        /// </summary>
        /// <param name="ProName">存储过程名称</param>
        /// <param name="parm">输入参数</param>
        /// <returns>OleDbParameter集</returns>
        public static OleDbParameter[] ProceureToParameter(string ProName, OleDbParameter[] parm)
        {
            DataTable dt = new DataTable();
            OleDbConnection con = new OleDbConnection(PowerConnect);
            OleDbCommand cmd = new OleDbCommand()
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = ProName
            };
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                cmd.Connection = con;
                for (int i = 0; i < parm.Length; i++)
                {
                    cmd.Parameters.Add(parm[i]);
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                con.Dispose();
                cmd.Parameters.Clear();
                cmd.Dispose();
            }
            return parm;
        }

    }
}