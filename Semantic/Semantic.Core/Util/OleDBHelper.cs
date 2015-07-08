using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;

namespace CodeHelper.Core.Util
{
    /**/
    /// <summary>
    /// The OleDbHelper class is intended to encapsulate high performance, 
    /// scalable best practices for common uses of OleDb.
    /// </summary>
    public abstract class OleDbHelper
    {

        //Database connection strings
        public static string ConnectionStr
        {
            get;
            set;
        }
        //public static readonly string strConnection = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        //public static readonly string ConnectionStringInventoryDistributedTransaction = ConfigurationManager.ConnectionStrings["OleDbConnString2"].ConnectionString;
        //public static readonly string ConnectionStringOrderDistributedTransaction = ConfigurationManager.ConnectionStrings["OleDbConnString3"].ConnectionString;
        //public static readonly string ConnectionStringProfile = ConfigurationManager.ConnectionStrings["OleDbProfileConnString"].ConnectionString;

        // Hashtable to store cached parameters
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        #region ExecuteNonQuery
        /**/
        /// <summary>
        /// Execute a OleDbCommand (that returns no resultset) against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a OleDbConnection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-OleDb command</param>
        /// <param name="commandParameters">an array of OleDbParamters used to execute the command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params OleDbParameter[] commandParameters)
        {

            OleDbCommand cmd = new OleDbCommand();

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /**/
        /// <summary>
        /// 使用默认连接
        /// </summary>
        /// <param name="cmdType">命令文本类型</param>
        /// <param name="cmdText">命令文本</param>
        /// <param name="commandParameters">参数集</param>
        /// <returns>int</returns>
        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params OleDbParameter[] commandParameters)
        {
            OleDbCommand cmd = new OleDbCommand();

            using (OleDbConnection conn = new OleDbConnection(ConnectionStr))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /**/
        /// <summary>
        /// 使用默认连接,CommandType默认为StoredProcedure
        /// </summary>
        /// <param name="cmdText">存储过程名</param>
        /// <param name="commandParameters">参数集</param>
        /// <returns>int</returns>
        public static int ExecuteNonQuery(string cmdText, params OleDbParameter[] commandParameters)
        {

            OleDbCommand cmd = new OleDbCommand();

            using (OleDbConnection conn = new OleDbConnection(ConnectionStr))
            {
                PrepareCommand(cmd, conn, null, CommandType.StoredProcedure, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }
        /**/
        /// <summary>
        /// Execute a OleDbCommand (that returns no resultset) against an existing database connection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="conn">an existing database connection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-OleDb command</param>
        /// <param name="commandParameters">an array of OleDbParamters used to execute the command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(OleDbConnection connection, CommandType cmdType, string cmdText, params OleDbParameter[] commandParameters)
        {

            OleDbCommand cmd = new OleDbCommand();

            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        /**/
        /// <summary>
        /// Execute a OleDbCommand (that returns no resultset) using an existing OleDb Transaction 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="trans">an existing OleDb transaction</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-OleDb command</param>
        /// <param name="commandParameters">an array of OleDbParamters used to execute the command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(OleDbTransaction trans, CommandType cmdType, string cmdText, params OleDbParameter[] commandParameters)
        {
            OleDbCommand cmd = new OleDbCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        /**/
        /// <summary>
        /// Execute a OleDbCommand that returns a resultset against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  OleDbDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a OleDbConnection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-OleDb command</param>
        /// <param name="commandParameters">an array of OleDbParamters used to execute the command</param>
        /// <returns>A OleDbDataReader containing the results</returns>

        #endregion

        #region ExecuteReader
        public static OleDbDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params OleDbParameter[] commandParameters)
        {
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection conn = new OleDbConnection(connectionString);

            // we use a try/catch here because if the method throws an exception we want to 
            // close the connection throw code, because no datareader will exist, hence the 
            // commandBehaviour.CloseConnection will not work
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                OleDbDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        /**/
        /// <summary>
        /// 使用默认连接
        /// </summary>
        /// <param name="cmdType">命令文本类型</param>
        /// <param name="cmdText">命令文本</param>
        /// <param name="commandParameters">参数集</param>
        /// <returns>OleDbDataReader</returns>
        public static OleDbDataReader ExecuteReader(CommandType cmdType, string cmdText, params OleDbParameter[] commandParameters)
        {
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection conn = new OleDbConnection(ConnectionStr);

            // we use a try/catch here because if the method throws an exception we want to 
            // close the connection throw code, because no datareader will exist, hence the 
            // commandBehaviour.CloseConnection will not work
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                OleDbDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        /**/
        /// <summary>
        /// 使用默认连接,CommandType默认为StoredProcedure
        /// </summary>
        /// <param name="cmdText">存储过程名</param>
        /// <param name="commandParameters">参数集</param>
        /// <returns>OleDbDataReader</returns>
        public static OleDbDataReader ExecuteReader(string cmdText, params OleDbParameter[] commandParameters)
        {
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection conn = new OleDbConnection(ConnectionStr);

            // we use a try/catch here because if the method throws an exception we want to 
            // close the connection throw code, because no datareader will exist, hence the 
            // commandBehaviour.CloseConnection will not work
            try
            {
                PrepareCommand(cmd, conn, null, CommandType.StoredProcedure, cmdText, commandParameters);
                OleDbDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }
        #endregion

        #region ExecuteScalar
        /**/
        /// <summary>
        /// Execute a OleDbCommand that returns the first column of the first record against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a OleDbConnection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-OleDb command</param>
        /// <param name="commandParameters">an array of OleDbParamters used to execute the command</param>
        /// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>
        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params OleDbParameter[] commandParameters)
        {
            OleDbCommand cmd = new OleDbCommand();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }
        /**/
        /// <summary>
        /// 使用定义好的连接字符串
        /// </summary>
        /// <param name="cmdType">命令文本类型</param>
        /// <param name="cmdText">命令文本</param>
        /// <param name="commandParameters">参数集</param>
        /// <returns>object</returns>
        public static object ExecuteScalar(CommandType cmdType, string cmdText, params OleDbParameter[] commandParameters)
        {
            OleDbCommand cmd = new OleDbCommand();

            using (OleDbConnection connection = new OleDbConnection(ConnectionStr))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }
        /**/
        /// <summary>
        /// 使用定义好的连接字符串,CommandType默认为StoredProcedure
        /// </summary>
        /// <param name="cmdText">存储过程名</param>
        /// <param name="commandParameters">参数集</param>
        /// <returns>object</returns>
        public static object ExecuteScalar(string cmdText, params OleDbParameter[] commandParameters)
        {
            OleDbCommand cmd = new OleDbCommand();

            using (OleDbConnection connection = new OleDbConnection(ConnectionStr))
            {
                PrepareCommand(cmd, connection, null, CommandType.StoredProcedure, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }
        /**/
        /// <summary>
        /// Execute a OleDbCommand that returns the first column of the first record against an existing database connection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="conn">an existing database connection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-OleDb command</param>
        /// <param name="commandParameters">an array of OleDbParamters used to execute the command</param>
        /// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>
        public static object ExecuteScalar(OleDbConnection connection, CommandType cmdType, string cmdText, params OleDbParameter[] commandParameters)
        {

            OleDbCommand cmd = new OleDbCommand();

            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }

        #endregion

        #region ExecuteDataSet
        /**/
        /// <summary>
        /// 返加dataset
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="cmdType">命令类型，如StoredProcedure,Text</param>
        /// <param name="cmdText">the stored procedure name or T-OleDb command</param>
        /// <returns>DataSet</returns>
        public static DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText)
        {
            OleDbConnection OleDbDataConn = new OleDbConnection(connectionString);
            OleDbCommand OleDbComm = new OleDbCommand(cmdText, OleDbDataConn);
            OleDbComm.CommandType = cmdType;
            OleDbDataAdapter OleDbDA = new OleDbDataAdapter(OleDbComm);
            DataSet DS = new DataSet();
            OleDbDA.Fill(DS);
            return DS;
        }

        /**/
        /// <summary>
        /// 使用定义好的连接字符串
        /// </summary>
        /// <param name="cmdType">命令文本类型</param>
        /// <param name="cmdText">命令文本</param>
        /// <returns>DataSet</returns>
        public static DataSet ExecuteDataSet(CommandType cmdType, string cmdText)
        {
            OleDbConnection OleDbDataConn = new OleDbConnection(ConnectionStr);
            OleDbCommand OleDbComm = new OleDbCommand(cmdText, OleDbDataConn);
            OleDbComm.CommandType = cmdType;
            OleDbDataAdapter OleDbDA = new OleDbDataAdapter(OleDbComm);
            DataSet DS = new DataSet();
            OleDbDA.Fill(DS);
            return DS;
        }
        /**/
        /// <summary>
        /// 使用定义好的连接字符串,CommandType默认为StoredProcedure
        /// </summary>
        /// <param name="cmdText">存储过程名</param>
        /// <returns>object</returns>
        public static DataSet ExecuteDataSet(string cmdText)
        {
            OleDbConnection OleDbDataConn = new OleDbConnection(ConnectionStr);
            OleDbCommand OleDbComm = new OleDbCommand(cmdText, OleDbDataConn);
            OleDbComm.CommandType = CommandType.StoredProcedure;
            OleDbDataAdapter OleDbDA = new OleDbDataAdapter(OleDbComm);
            DataSet DS = new DataSet();
            OleDbDA.Fill(DS);
            return DS;
        }
        /**/
        /// <summary>
        /// 返加dataset
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="cmdType">命令类型，如StoredProcedure,Text</param>
        /// <param name="cmdText">the stored procedure name or T-OleDb command</param>
        /// <param name="OleDbparams">参数集</param>
        /// <returns>DataSet</returns>
        public static DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText, params OleDbParameter[] OleDbparams)
        {
            OleDbConnection OleDbDataConn = new OleDbConnection(connectionString);
            OleDbCommand OleDbComm = AddOleDbParas(OleDbparams, cmdText, cmdType, OleDbDataConn);
            OleDbDataAdapter OleDbDA = new OleDbDataAdapter(OleDbComm);
            DataSet DS = new DataSet();
            OleDbDA.Fill(DS);
            return DS;
        }

        public static DataSet ExecuteDataSet(CommandType cmdType, string cmdText, params OleDbParameter[] OleDbparams)
        {
            OleDbConnection OleDbDataConn = new OleDbConnection(ConnectionStr);
            OleDbCommand OleDbComm = AddOleDbParas(OleDbparams, cmdText, cmdType, OleDbDataConn);
            OleDbDataAdapter OleDbDA = new OleDbDataAdapter(OleDbComm);
            DataSet DS = new DataSet();
            OleDbDA.Fill(DS);
            return DS;
        }
        /**/
        /// <summary>
        /// 使用定义好的连接字符串,CommandType默认为StoredProcedure
        /// </summary>
        /// <param name="cmdText">存储过程名</param>
        /// <param name="commandParameters">参数集</param>
        /// <returns>DataSet</returns>
        public static DataSet ExecuteDataSet(string cmdText, params OleDbParameter[] OleDbparams)
        {
            OleDbConnection OleDbDataConn = new OleDbConnection(ConnectionStr);
            OleDbCommand OleDbComm = AddOleDbParas(OleDbparams, cmdText, CommandType.StoredProcedure, OleDbDataConn);
            OleDbDataAdapter OleDbDA = new OleDbDataAdapter(OleDbComm);
            DataSet DS = new DataSet();
            OleDbDA.Fill(DS);
            return DS;
        }
        #endregion

        #region CacheParameters
        /**/
        /// <summary>
        /// add parameter array to the cache
        /// </summary>
        /// <param name="cacheKey">Key to the parameter cache</param>
        /// <param name="cmdParms">an array of OleDbParamters to be cached</param>
        public static void CacheParameters(string cacheKey, params OleDbParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }

        #endregion

        #region GetCachedParameters
        /**/
        /// <summary>
        /// Retrieve cached parameters
        /// </summary>
        /// <param name="cacheKey">key used to lookup parameters</param>
        /// <returns>Cached OleDbParamters array</returns>
        public static OleDbParameter[] GetCachedParameters(string cacheKey)
        {
            OleDbParameter[] cachedParms = (OleDbParameter[])parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            OleDbParameter[] clonedParms = new OleDbParameter[cachedParms.Length];

            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (OleDbParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }

        #endregion

        #region PrepareCommand
        /**/
        /// <summary>
        /// Prepare a command for execution
        /// </summary>
        /// <param name="cmd">OleDbCommand object</param>
        /// <param name="conn">OleDbConnection object</param>
        /// <param name="trans">OleDbTransaction object</param>
        /// <param name="cmdType">Cmd type e.g. stored procedure or text</param>
        /// <param name="cmdText">Command text, e.g. Select * from Products</param>
        /// <param name="cmdParms">OleDbParameters to use in the command</param>
        private static void PrepareCommand(OleDbCommand cmd, OleDbConnection conn, OleDbTransaction trans, CommandType cmdType, string cmdText, OleDbParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (OleDbParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        #endregion

        #region AddOleDbParas
        /**/
        /// <summary>
        /// 获得一个完整的Command
        /// </summary>
        /// <param name="OleDbParas">OleDb的参数数组</param>
        /// <param name="CommandText">命令文本</param>
        /// <param name="IsStoredProcedure">命令文本是否是存储过程</param>
        /// <param name="OleDbDataConn">数据连接</param>
        /// <returns></returns>
        private static OleDbCommand AddOleDbParas(OleDbParameter[] OleDbParas, string cmdText, CommandType cmdType, OleDbConnection OleDbDataConn)
        {
            OleDbCommand OleDbComm = new OleDbCommand(cmdText, OleDbDataConn);
            OleDbComm.CommandType = cmdType;
            if (OleDbParas != null)
            {
                foreach (OleDbParameter p in OleDbParas)
                {
                    OleDbComm.Parameters.Add(p);
                }
            }
            return OleDbComm;
        }
        #endregion
    }
}



