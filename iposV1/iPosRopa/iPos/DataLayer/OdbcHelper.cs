using System;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Collections;

namespace DataLayer
{
    ///  
    /// Summary description for OdbcHelper. 
    ///  
    public class OdbcHelper
    {
        ///  
        /// Execute a database query which does not include a select 
        ///  
        /// Connection string to database 
        /// Command type either stored procedure or SQL 
        /// Acutall SQL Command 
        /// Parameters to bind to the command 
        ///  
        public static int ExecuteNonQuery(string connString, CommandType cmdType, string cmdText, params OdbcParameter[] cmdParms)
        {

            // Create a new Odbc command 
            OdbcCommand cmd = new OdbcCommand();

            //Create a connection 
            using (OdbcConnection conn = new OdbcConnection(connString))
            {

                //Prepare the command 
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);

                //Execute the command 
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        ///  
        /// Execute an OdbcCommand (that returns no resultset) against an existing database transaction  
        /// using the provided parameters. 
        ///  
        ///  
        /// e.g.:   
        ///  int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "PublishOrders", new OdbcParameter(":prodid", 24)); 
        ///  
        /// an existing database transaction 
        /// the CommandType (stored procedure, text, etc.) 
        /// the stored procedure name or PL/SQL command 
        /// an array of OdbcParamters used to execute the command 
        /// an int representing the number of rows affected by the command 
        public static int ExecuteNonQuery(OdbcTransaction trans, CommandType cmdType, string cmdText, params OdbcParameter[] cmdParms)
        {
            OdbcCommand cmd = new OdbcCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, cmdParms);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        ///  
        /// Execute an OdbcCommand (that returns no resultset) against an existing database connection  
        /// using the provided parameters. 
        ///  
        ///  
        /// e.g.:   
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new OdbcParameter(":prodid", 24)); 
        ///  
        /// an existing database connection 
        /// the CommandType (stored procedure, text, etc.) 
        /// the stored procedure name or PL/SQL command 
        /// an array of OdbcParamters used to execute the command 
        /// an int representing the number of rows affected by the command 
        public static int ExecuteNonQuery(OdbcConnection conn, CommandType cmdType, string cmdText, params OdbcParameter[] cmdParms)
        {

            OdbcCommand cmd = new OdbcCommand();

            PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        ///  
        /// Execute a select query that will return a result set 
        ///  
        /// Connection string 
        //// the CommandType (stored procedure, text, etc.) 
        /// the stored procedure name or PL/SQL command 
        /// an array of OdbcParamters used to execute the command 
        ///  
        public static OdbcDataReader ExecuteReader(string connString, CommandType cmdType, string cmdText, params OdbcParameter[] cmdParms)
        {

            //Create the command and connection 
            OdbcCommand cmd = new OdbcCommand();
            OdbcConnection conn = new OdbcConnection(connString);

            try
            {
                //Prepare the command to execute 
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);

                //Execute the query, stating that the connection should close when the resulting datareader has been read 
                OdbcDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;

            }
            catch (Exception e)
            {

                //If an error occurs close the connection as the reader will not be used and we expect it to close the connection 
                conn.Close();
                throw e;
            }
        }

        ///  
        /// Execute an OdbcCommand that returns the first column of the first record against the database specified in the connection string  
        /// using the provided parameters. 
        ///  
        ///  
        /// e.g.:   
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new OdbcParameter(":prodid", 24)); 
        ///  
        /// a valid connection string for a SqlConnection 
        /// the CommandType (stored procedure, text, etc.) 
        /// the stored procedure name or PL/SQL command 
        /// an array of OdbcParamters used to execute the command 
        /// An object that should be converted to the expected type using Convert.To{Type} 
        public static object ExecuteScalar(string connString, CommandType cmdType, string cmdText, params OdbcParameter[] cmdParms)
        {
            OdbcCommand cmd = new OdbcCommand();

            using (OdbcConnection conn = new OdbcConnection(connString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        ///  
        /// Execute an OdbcCommand that returns the first column of the first record against an existing database connection  
        /// using the provided parameters. 
        ///  
        ///  
        /// e.g.:   
        ///  Object obj = ExecuteScalar(conn, CommandType.StoredProcedure, "PublishOrders", new OdbcParameter(":prodid", 24)); 
        ///  
        /// an existing database connection 
        /// the CommandType (stored procedure, text, etc.) 
        /// the stored procedure name or PL/SQL command 
        /// an array of OdbcParamters used to execute the command 
        /// An object that should be converted to the expected type using Convert.To{Type} 
        public static object ExecuteScalar(OdbcConnection conn, CommandType cmdType, string cmdText, params OdbcParameter[] cmdParms)
        {

            OdbcCommand cmd = new OdbcCommand();

            PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }

        ///  
        /// Add a set of parameters to the cached 
        ///  
        /// Key value to look up the parameters 
        /// Actual parameters to cached 
        //public static void CacheParameters(string cacheKey, params OdbcParameter[] cmdParms)
        //{
        //    DBHelper.paramCache[cacheKey] = cmdParms;
        //}

        ///  
        /// Fetch parameters from the cache 
        ///  
        /// Key to look up the parameters 
        ///  
        //public static OdbcParameter[] GetCachedParameters(string cacheKey)
        //{
        //    OdbcParameter[] cachedParms = (OdbcParameter[])DBHelper.paramCache[cacheKey];

        //    if (cachedParms == null)
        //        return null;

        //    // If the parameters are in the cache 
        //    OdbcParameter[] clonedParms = new OdbcParameter[cachedParms.Length];

        //    // return a copy of the parameters 
        //    for (int i = 0, j = cachedParms.Length; i < j; i++)
        //        clonedParms[i] = (OdbcParameter)((ICloneable)cachedParms[i]).Clone();

        //    return clonedParms;
        //}

        ///  
        /// Internal function to prepare a command for execution by the database 
        ///  
        /// Existing command object 
        /// Database connection object 
        /// Optional transaction object 
        /// Command type, e.g. stored procedure 
        /// Command test 
        /// Parameters for the command 
        private static void PrepareCommand(OdbcCommand cmd, OdbcConnection conn, OdbcTransaction trans, CommandType cmdType, string cmdText, OdbcParameter[] cmdParms)
        {

            //Open the connection if required 
            if (conn.State != ConnectionState.Open)
                conn.Open();

            //Set up the command 
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = cmdType;

            //Bind it to the transaction if it exists 
            if (trans != null)
                cmd.Transaction = trans;

            // Bind the parameters passed in 
            if (cmdParms != null)
            {
                foreach (OdbcParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
    }
}
