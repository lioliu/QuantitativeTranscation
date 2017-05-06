using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Data;
namespace QuantTradeDLL.DBUtility
{   

    /// <summary>
    /// meet the proble of encoding
    /// </summary>
    public class OracleClient
    {
        private static string PowerConnect = "Data Source=( DESCRIPTION = ( ADDRESS = ( PROTOCOL = TCP ) ( HOST = 180.169.93.178 ) ( PORT = 1521 ) ) ( CONNECT_DATA = ( SERVICE_NAME=DATACENTER ) ) );user id=WEI;password=20134831517;";

        #region Execute sql
        /// <summary>
        /// Execute SQL statement 
        /// </summary>
        /// <param name="sql">Statement to be executed</param>
        /// <returns> affected rows</returns>
        public static int ExecuteSQL(string sql)
        {
            int count = 0;
            OracleConnection con = new OracleConnection(PowerConnect);
            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand(sql, con);
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
            OracleConnection con = new OracleConnection(PowerConnect);
            con.Open();
            OracleCommand cmd = new OracleCommand()
            {
                Connection = con
            };
            OracleTransaction transaction = con.BeginTransaction();
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
# region GetData
        /// <summary>
        /// get the data by execute the sql
        /// </summary>
        /// <param name="sql">query statement</param>
        /// <returns>result data</returns>
        public static DataSet GetData(string sql)
        {
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            OracleDataAdapter oda = null;
            try
            {
                oda = new OracleDataAdapter(sql, PowerConnect);
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
            OracleDataAdapter oda = null;
            OracleConnection con = new OracleConnection(PowerConnect);
            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand()
                {
                    Connection = con
                };
                foreach (string sql in sqlList)
                {
                    cmd.CommandText = sql;
                    oda = new OracleDataAdapter(cmd);
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
        /// 执行存储过程返回数据存储在OracleParameter中
        /// </summary>
        /// <param name="ProName">存储过程名称</param>
        /// <param name="parm">输入参数</param>
        /// <returns>OracleParameter集</returns>
        public static OracleParameter[] ProceureToParameter(string ProName, OracleParameter[] parm)
        {
            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(PowerConnect);
            OracleCommand cmd = new OracleCommand()
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
        /// <summary>
        /// 执行存储过程返回数据放在DataSet中
        /// </summary>
        /// <param name="ProName">存储过程名称</param>
        /// <param name="parm">输入参数</param>
        /// <returns>表格集</returns>
        public static DataSet ProceureToTable(string ProName, OracleParameter[] parm)
        {
            DataTable dt = new DataTable();
            OracleDataAdapter dr = new OracleDataAdapter();
            OracleConnection con = new OracleConnection(PowerConnect);
            OracleCommand cmd = new OracleCommand()
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
                
                dr.SelectCommand = cmd;
                //cmd.ExecuteNonQuery();
                dr.Fill(ds);
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
            return ds;
        }


    }
}
