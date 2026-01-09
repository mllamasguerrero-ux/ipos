
using System;
using System.Data;
using System.Xml;
using System.Collections;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Configuration;
using FirebirdSql.Data.FirebirdClient;
namespace Microsoft.ApplicationBlocks.Data
{
	
	
	
	
	public sealed class SqlHelper
	{
		#region private utility methods & constructors
		
		
		private SqlHelper() { }
		
		
		
		
		
		
		
		
		
		
		
		
		private static void AttachParameters(FbCommand command, FbParameter[] commandParameters)
		{
			if (command == null) throw new ArgumentNullException("command");
			if (commandParameters != null)
			{
				foreach (FbParameter p in commandParameters)
				{
					if (p != null)
					{
						
						if ((p.Direction == ParameterDirection.InputOutput ||
							p.Direction == ParameterDirection.Input) &&
							(p.Value == null))
						{
							p.Value = DBNull.Value;
						}
						command.Parameters.Add(p);
					}
				}
			}
		}
		
		
		
		
		
		private static void AssignParameterValues(FbParameter[] commandParameters, DataRow dataRow)
		{
			if ((commandParameters == null) || (dataRow == null))
			{
				
				return;
			}
			int i = 0;
			
			foreach (FbParameter commandParameter in commandParameters)
			{
				
				if (commandParameter.ParameterName == null ||
					commandParameter.ParameterName.Length <= 1)
					throw new Exception(
						string.Format(
							"Please provide a valid parameter name on the parameter #{0}, the ParameterName property has the following value: '{1}'.",
							i, commandParameter.ParameterName));
				if (dataRow.Table.Columns.IndexOf(commandParameter.ParameterName.Substring(1)) != -1)
					commandParameter.Value = dataRow[commandParameter.ParameterName.Substring(1)];
				i++;
			}
		}
		
		
		
		
		
		private static void AssignParameterValues(FbParameter[] commandParameters, object[] parameterValues)
		{
			if ((commandParameters == null) || (parameterValues == null))
			{
				
				return;
			}
			
			if (commandParameters.Length != parameterValues.Length)
			{
				throw new ArgumentException("Parameter count does not match Parameter Value count.");
			}
			
			
			for (int i = 0, j = commandParameters.Length; i < j; i++)
			{
				
				if (parameterValues[i] is IDbDataParameter)
				{
					IDbDataParameter paramInstance = (IDbDataParameter)parameterValues[i];
					if (paramInstance.Value == null)
					{
						commandParameters[i].Value = DBNull.Value;
					}
					else
					{
						commandParameters[i].Value = paramInstance.Value;
					}
				}
				else if (parameterValues[i] == null)
				{
					commandParameters[i].Value = DBNull.Value;
				}
				else
				{
					commandParameters[i].Value = parameterValues[i];
				}
			}
		}
		
		
		
		
		
		
		
		
		
		
		
		private static void PrepareCommand(FbCommand command, FbConnection connection, FbTransaction transaction, CommandType commandType, string commandText, FbParameter[] commandParameters, out bool mustCloseConnection)
		{
			if (command == null) throw new ArgumentNullException("command");
			if (commandText == null || commandText.Length == 0) throw new ArgumentNullException("commandText");
			
			if (connection.State != ConnectionState.Open)
			{
				mustCloseConnection = true;
				connection.Open();
			}
			else
			{
				mustCloseConnection = false;
			}
			
			command.Connection = connection;
			
			command.CommandText = commandText;
			
			if (transaction != null)
			{
				if (transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
				command.Transaction = transaction;
			}
			
			command.CommandType = commandType;
			
			if (commandParameters != null)
			{
				AttachParameters(command, commandParameters);
			}
			return;
		}
		#endregion private utility methods & constructors
		#region ExecuteNonQuery
		
		
		
		
		
		
		
		
		
		
		
		
		public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText)
		{
			
			return ExecuteNonQuery(connectionString, commandType, commandText, (FbParameter[])null);
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params FbParameter[] commandParameters)
		{
            int retorno = 0;
			if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
			
			using (FbConnection connection = new FbConnection(connectionString))
			{
				connection.Open();
               
                
				
				retorno = ExecuteNonQuery(connection, commandType, commandText, commandParameters);
                try
                {
                    connection.Close();
                }
                catch
                {
                }
                return retorno;
			}
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static int ExecuteNonQuery(string connectionString, string spName, params object[] parameterValues)
		{
			if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			
			if ((parameterValues != null) && (parameterValues.Length > 0))
			{
				
				FbParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);
				
				AssignParameterValues(commandParameters, parameterValues);
				
				return ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				
				return ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName);
			}
		}
		
		
		
		
		
		
		
		
		
		
		
		public static int ExecuteNonQuery(FbConnection connection, CommandType commandType, string commandText)
		{
			
			return ExecuteNonQuery(connection, commandType, commandText, (FbParameter[])null);
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static int ExecuteNonQuery(FbConnection connection, CommandType commandType, string commandText, params FbParameter[] commandParameters)
		{
			if (connection == null) throw new ArgumentNullException("connection");
			
			FbCommand cmd = new FbCommand();
			bool mustCloseConnection = false;
			PrepareCommand(cmd, connection, (FbTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);
			
			int retval = cmd.ExecuteNonQuery();
			
			cmd.Parameters.Clear();
			if (mustCloseConnection)
				connection.Close();
			return retval;
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static int ExecuteNonQuery(FbConnection connection, string spName, params object[] parameterValues)
		{
			if (connection == null) throw new ArgumentNullException("connection");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			
			if ((parameterValues != null) && (parameterValues.Length > 0))
			{
				
				FbParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection, spName);
				
				AssignParameterValues(commandParameters, parameterValues);
				
				return ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				
				return ExecuteNonQuery(connection, CommandType.StoredProcedure, spName);
			}
		}
		
		
		
		
		
		
		
		
		
		
		
		public static int ExecuteNonQuery(FbTransaction transaction, CommandType commandType, string commandText)
		{
			
			return ExecuteNonQuery(transaction, commandType, commandText, (FbParameter[])null);
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static int ExecuteNonQuery(FbTransaction transaction, CommandType commandType, string commandText, params FbParameter[] commandParameters)
		{
			if (transaction == null) throw new ArgumentNullException("transaction");
			if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			
			FbCommand cmd = new FbCommand();
			bool mustCloseConnection = false;
			PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);
			
			int retval = cmd.ExecuteNonQuery();
			
			cmd.Parameters.Clear();
			return retval;
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static int ExecuteNonQuery(FbTransaction transaction, string spName, params object[] parameterValues)
		{
			if (transaction == null) throw new ArgumentNullException("transaction");
			if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			
			if ((parameterValues != null) && (parameterValues.Length > 0))
			{
				
				FbParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName);
				
				AssignParameterValues(commandParameters, parameterValues);
				
				return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				
				return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName);
			}
		}
		#endregion ExecuteNonQuery
		#region ExecuteDataset
		
		
		
		
		
		
		
		
		
		
		
		
		public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText)
		{
			
			return ExecuteDataset(connectionString, commandType, commandText, (FbParameter[])null);
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText, params FbParameter[] commandParameters)
		{
			if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
			
			using (FbConnection connection = new FbConnection(connectionString))
			{
				connection.Open();
				
				DataSet retorno =  ExecuteDataset(connection, commandType, commandText, commandParameters);
                connection.Close();
                return retorno;
			}
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static DataSet ExecuteDataset(string connectionString, string spName, params object[] parameterValues)
		{
			if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			
			if ((parameterValues != null) && (parameterValues.Length > 0))
			{
				
				FbParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);
				
				AssignParameterValues(commandParameters, parameterValues);
				
				return ExecuteDataset(connectionString, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				
				return ExecuteDataset(connectionString, CommandType.StoredProcedure, spName);
			}
		}
		
		
		
		
		
		
		
		
		
		
		
		public static DataSet ExecuteDataset(FbConnection connection, CommandType commandType, string commandText)
		{
			
			return ExecuteDataset(connection, commandType, commandText, (FbParameter[])null);
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static DataSet ExecuteDataset(FbConnection connection, CommandType commandType, string commandText, params FbParameter[] commandParameters)
		{
			if (connection == null) throw new ArgumentNullException("connection");
			
			FbCommand cmd = new FbCommand();
			bool mustCloseConnection = false;
			PrepareCommand(cmd, connection, (FbTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);
			
			using (FbDataAdapter da = new FbDataAdapter(cmd))
			{
				DataSet ds = new DataSet();
				
				da.Fill(ds);
				
				cmd.Parameters.Clear();
				if (mustCloseConnection)
					connection.Close();
				
				return ds;
			}
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static DataSet ExecuteDataset(FbConnection connection, string spName, params object[] parameterValues)
		{
			if (connection == null) throw new ArgumentNullException("connection");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			
			if ((parameterValues != null) && (parameterValues.Length > 0))
			{
				
				FbParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection, spName);
				
				AssignParameterValues(commandParameters, parameterValues);
				
				return ExecuteDataset(connection, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				
				return ExecuteDataset(connection, CommandType.StoredProcedure, spName);
			}
		}
		
		
		
		
		
		
		
		
		
		
		
		public static DataSet ExecuteDataset(FbTransaction transaction, CommandType commandType, string commandText)
		{
			
			return ExecuteDataset(transaction, commandType, commandText, (FbParameter[])null);
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static DataSet ExecuteDataset(FbTransaction transaction, CommandType commandType, string commandText, params FbParameter[] commandParameters)
		{
			if (transaction == null) throw new ArgumentNullException("transaction");
			if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			
			FbCommand cmd = new FbCommand();
			bool mustCloseConnection = false;
			PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);
			
			using (FbDataAdapter da = new FbDataAdapter(cmd))
			{
				DataSet ds = new DataSet();
				
				da.Fill(ds);
				
				cmd.Parameters.Clear();
				
				return ds;
			}
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static DataSet ExecuteDataset(FbTransaction transaction, string spName, params object[] parameterValues)
		{
			if (transaction == null) throw new ArgumentNullException("transaction");
			if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			
			if ((parameterValues != null) && (parameterValues.Length > 0))
			{
				
				FbParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName);
				
				AssignParameterValues(commandParameters, parameterValues);
				
				return ExecuteDataset(transaction, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				
				return ExecuteDataset(transaction, CommandType.StoredProcedure, spName);
			}
		}
		#endregion ExecuteDataset
		#region ExecuteReader
		
		
		
		
		private enum FbConnectionOwnership
		{
			
			Internal,
			
			External
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		private static FbDataReader ExecuteReader(FbConnection connection, FbTransaction transaction, CommandType commandType, string commandText, FbParameter[] commandParameters, FbConnectionOwnership connectionOwnership)
		{
			if (connection == null) throw new ArgumentNullException("connection");
			bool mustCloseConnection = false;
			
			FbCommand cmd = new FbCommand();
			try
			{
				PrepareCommand(cmd, connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);
				
				FbDataReader dataReader;
				
				if (connectionOwnership == FbConnectionOwnership.External)
				{
					dataReader = cmd.ExecuteReader();
				}
				else
				{
					dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
				}
				
				
				
				
				
				bool canClear = true;
				foreach (FbParameter commandParameter in cmd.Parameters)
				{
					if (commandParameter.Direction != ParameterDirection.Input)
						canClear = false;
				}
				if (canClear)
				{
					cmd.Parameters.Clear();
				}
				return dataReader;
			}
			catch
			{
				if (mustCloseConnection)
					connection.Close();
				throw;
			}
		}
		
		
		
		
		
		
		
		
		
		
		
		
		public static FbDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText)
		{
			
			return ExecuteReader(connectionString, commandType, commandText, (FbParameter[])null);
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		private static FbDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText, params FbParameter[] commandParameters)
		{
			if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
			FbConnection connection = null;
			try
			{
				connection = new FbConnection(connectionString);
				connection.Open();
				
				return ExecuteReader(connection, null, commandType, commandText, commandParameters, FbConnectionOwnership.Internal);
			}
			catch
			{
				
				if (connection != null) connection.Close();
				throw;
			}
		}



        public static FbDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText, out FbConnection connection , params FbParameter[] commandParameters)
        {
            connection = null;
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            try
            {
                connection = new FbConnection(connectionString);
                connection.Open();

                return ExecuteReader(connection, null, commandType, commandText, commandParameters, FbConnectionOwnership.Internal);
            }
            catch(Exception ex)
            {

                if (connection != null) connection.Close();
                throw;
            }
        }
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static FbDataReader ExecuteReader(string connectionString, string spName, params object[] parameterValues)
		{
			if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			
			if ((parameterValues != null) && (parameterValues.Length > 0))
			{
				FbParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);
				AssignParameterValues(commandParameters, parameterValues);
				return ExecuteReader(connectionString, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				
				return ExecuteReader(connectionString, CommandType.StoredProcedure, spName);
			}
		}
		
		
		
		
		
		
		
		
		
		
		
		public static FbDataReader ExecuteReader(FbConnection connection, CommandType commandType, string commandText)
		{
			
			return ExecuteReader(connection, commandType, commandText, (FbParameter[])null);
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static FbDataReader ExecuteReader(FbConnection connection, CommandType commandType, string commandText, params FbParameter[] commandParameters)
		{
			
			return ExecuteReader(connection, (FbTransaction)null, commandType, commandText, commandParameters, FbConnectionOwnership.External);
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static FbDataReader ExecuteReader(FbConnection connection, string spName, params object[] parameterValues)
		{
			if (connection == null) throw new ArgumentNullException("connection");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			
			if ((parameterValues != null) && (parameterValues.Length > 0))
			{
				FbParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection, spName);
				AssignParameterValues(commandParameters, parameterValues);
				return ExecuteReader(connection, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				
				return ExecuteReader(connection, CommandType.StoredProcedure, spName);
			}
		}
		
		
		
		
		
		
		
		
		
		
		
		public static FbDataReader ExecuteReader(FbTransaction transaction, CommandType commandType, string commandText)
		{
			
			return ExecuteReader(transaction, commandType, commandText, (FbParameter[])null);
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static FbDataReader ExecuteReader(FbTransaction transaction, CommandType commandType, string commandText, params FbParameter[] commandParameters)
		{
			if (transaction == null) throw new ArgumentNullException("transaction");
			if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			
			return ExecuteReader(transaction.Connection, transaction, commandType, commandText, commandParameters, FbConnectionOwnership.External);
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static FbDataReader ExecuteReader(FbTransaction transaction, string spName, params object[] parameterValues)
		{
			if (transaction == null) throw new ArgumentNullException("transaction");
			if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			
			if ((parameterValues != null) && (parameterValues.Length > 0))
			{
				FbParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName);
				AssignParameterValues(commandParameters, parameterValues);
				return ExecuteReader(transaction, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				
				return ExecuteReader(transaction, CommandType.StoredProcedure, spName);
			}
		}
		#endregion ExecuteReader
		#region ExecuteScalar
		
		
		
		
		
		
		
		
		
		
		
		
		public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText)
		{
			
			return ExecuteScalar(connectionString, commandType, commandText, (FbParameter[])null);
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params FbParameter[] commandParameters)
		{
			if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
			
			using (FbConnection connection = new FbConnection(connectionString))
			{
				connection.Open();
				
				return ExecuteScalar(connection, commandType, commandText, commandParameters);
			}
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static object ExecuteScalar(string connectionString, string spName, params object[] parameterValues)
		{
			if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			
			if ((parameterValues != null) && (parameterValues.Length > 0))
			{
				
				FbParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);
				
				AssignParameterValues(commandParameters, parameterValues);
				
				return ExecuteScalar(connectionString, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				
				return ExecuteScalar(connectionString, CommandType.StoredProcedure, spName);
			}
		}
		
		
		
		
		
		
		
		
		
		
		
		public static object ExecuteScalar(FbConnection connection, CommandType commandType, string commandText)
		{
			
			return ExecuteScalar(connection, commandType, commandText, (FbParameter[])null);
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static object ExecuteScalar(FbConnection connection, CommandType commandType, string commandText, params FbParameter[] commandParameters)
		{
			if (connection == null) throw new ArgumentNullException("connection");
			
			FbCommand cmd = new FbCommand();
			bool mustCloseConnection = false;
			PrepareCommand(cmd, connection, (FbTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);
			
			object retval = cmd.ExecuteScalar();
			
			cmd.Parameters.Clear();
			if (mustCloseConnection)
				connection.Close();
			return retval;
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static object ExecuteScalar(FbConnection connection, string spName, params object[] parameterValues)
		{
			if (connection == null) throw new ArgumentNullException("connection");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			
			if ((parameterValues != null) && (parameterValues.Length > 0))
			{
				
				FbParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection, spName);
				
				AssignParameterValues(commandParameters, parameterValues);
				
				return ExecuteScalar(connection, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				
				return ExecuteScalar(connection, CommandType.StoredProcedure, spName);
			}
		}
		
		
		
		
		
		
		
		
		
		
		
		public static object ExecuteScalar(FbTransaction transaction, CommandType commandType, string commandText)
		{
			
			return ExecuteScalar(transaction, commandType, commandText, (FbParameter[])null);
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static object ExecuteScalar(FbTransaction transaction, CommandType commandType, string commandText, params FbParameter[] commandParameters)
		{
			if (transaction == null) throw new ArgumentNullException("transaction");
			if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			
			FbCommand cmd = new FbCommand();
			bool mustCloseConnection = false;
			PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);
			
			object retval = cmd.ExecuteScalar();
			
			cmd.Parameters.Clear();
			return retval;
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static object ExecuteScalar(FbTransaction transaction, string spName, params object[] parameterValues)
		{
			if (transaction == null) throw new ArgumentNullException("transaction");
			if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			
			if ((parameterValues != null) && (parameterValues.Length > 0))
			{
				
				FbParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName);
				
				AssignParameterValues(commandParameters, parameterValues);
				
				return ExecuteScalar(transaction, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				
				return ExecuteScalar(transaction, CommandType.StoredProcedure, spName);
			}
		}
		#endregion ExecuteScalar
		#region ExecuteXmlReader
		
		
		
		
		
		
		
		
		
		
		
		public static XmlReader ExecuteXmlReader(FbConnection connection, CommandType commandType, string commandText)
		{
			
			return ExecuteXmlReader(connection, commandType, commandText, (FbParameter[])null);
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static XmlReader ExecuteXmlReader(FbConnection connection, CommandType commandType, string commandText, params FbParameter[] commandParameters)
		{
			if (connection == null) throw new ArgumentNullException("connection");
			bool mustCloseConnection = false;
			
			FbCommand cmd = new FbCommand();
			try
			{
				PrepareCommand(cmd, connection, (FbTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);
				
				XmlReader retval = null;
				
				cmd.Parameters.Clear();
				return retval;
			}
			catch
			{
				if (mustCloseConnection)
					connection.Close();
				throw;
			}
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static XmlReader ExecuteXmlReader(FbConnection connection, string spName, params object[] parameterValues)
		{
			if (connection == null) throw new ArgumentNullException("connection");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			
			if ((parameterValues != null) && (parameterValues.Length > 0))
			{
				
				FbParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection, spName);
				
				AssignParameterValues(commandParameters, parameterValues);
				
				return ExecuteXmlReader(connection, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				
				return ExecuteXmlReader(connection, CommandType.StoredProcedure, spName);
			}
		}
		
		
		
		
		
		
		
		
		
		
		
		public static XmlReader ExecuteXmlReader(FbTransaction transaction, CommandType commandType, string commandText)
		{
			
			return ExecuteXmlReader(transaction, commandType, commandText, (FbParameter[])null);
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static XmlReader ExecuteXmlReader(FbTransaction transaction, CommandType commandType, string commandText, params FbParameter[] commandParameters)
		{
			if (transaction == null) throw new ArgumentNullException("transaction");
			if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			
			FbCommand cmd = new FbCommand();
			bool mustCloseConnection = false;
			PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);
			
			XmlReader retval = null; 
			
			cmd.Parameters.Clear();
			return retval;
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static XmlReader ExecuteXmlReader(FbTransaction transaction, string spName, params object[] parameterValues)
		{
			if (transaction == null) throw new ArgumentNullException("transaction");
			if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			
			if ((parameterValues != null) && (parameterValues.Length > 0))
			{
				
				FbParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName);
				
				AssignParameterValues(commandParameters, parameterValues);
				
				return ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				
				return ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName);
			}
		}
		#endregion ExecuteXmlReader
		#region FillDataset
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static void FillDataset(string connectionString, CommandType commandType, string commandText, DataSet dataSet, string[] tableNames)
		{
			if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
			if (dataSet == null) throw new ArgumentNullException("dataSet");
			
			using (FbConnection connection = new FbConnection(connectionString))
			{
				connection.Open();
				
				FillDataset(connection, commandType, commandText, dataSet, tableNames);
			}
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static void FillDataset(string connectionString, CommandType commandType,
			string commandText, DataSet dataSet, string[] tableNames,
			params FbParameter[] commandParameters)
		{
			if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
			if (dataSet == null) throw new ArgumentNullException("dataSet");
			
			using (FbConnection connection = new FbConnection(connectionString))
			{
				connection.Open();
				
				FillDataset(connection, commandType, commandText, dataSet, tableNames, commandParameters);
			}
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static void FillDataset(string connectionString, string spName,
			DataSet dataSet, string[] tableNames,
			params object[] parameterValues)
		{
			if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
			if (dataSet == null) throw new ArgumentNullException("dataSet");
			
			using (FbConnection connection = new FbConnection(connectionString))
			{
				connection.Open();
				
				FillDataset(connection, spName, dataSet, tableNames, parameterValues);
			}
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static void FillDataset(FbConnection connection, CommandType commandType,
			string commandText, DataSet dataSet, string[] tableNames)
		{
			FillDataset(connection, commandType, commandText, dataSet, tableNames, null);
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static void FillDataset(FbConnection connection, CommandType commandType,
			string commandText, DataSet dataSet, string[] tableNames,
			params FbParameter[] commandParameters)
		{
			FillDataset(connection, null, commandType, commandText, dataSet, tableNames, commandParameters);
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static void FillDataset(FbConnection connection, string spName,
			DataSet dataSet, string[] tableNames,
			params object[] parameterValues)
		{
			if (connection == null) throw new ArgumentNullException("connection");
			if (dataSet == null) throw new ArgumentNullException("dataSet");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			
			if ((parameterValues != null) && (parameterValues.Length > 0))
			{
				
				FbParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection, spName);
				
				AssignParameterValues(commandParameters, parameterValues);
				
				FillDataset(connection, CommandType.StoredProcedure, spName, dataSet, tableNames, commandParameters);
			}
			else
			{
				
				FillDataset(connection, CommandType.StoredProcedure, spName, dataSet, tableNames);
			}
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static void FillDataset(FbTransaction transaction, CommandType commandType,
			string commandText,
			DataSet dataSet, string[] tableNames)
		{
			FillDataset(transaction, commandType, commandText, dataSet, tableNames, null);
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static void FillDataset(FbTransaction transaction, CommandType commandType,
			string commandText, DataSet dataSet, string[] tableNames,
			params FbParameter[] commandParameters)
		{
			FillDataset(transaction.Connection, transaction, commandType, commandText, dataSet, tableNames, commandParameters);
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static void FillDataset(FbTransaction transaction, string spName,
			DataSet dataSet, string[] tableNames,
			params object[] parameterValues)
		{
			if (transaction == null) throw new ArgumentNullException("transaction");
			if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			if (dataSet == null) throw new ArgumentNullException("dataSet");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			
			if ((parameterValues != null) && (parameterValues.Length > 0))
			{
				
				FbParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName);
				
				AssignParameterValues(commandParameters, parameterValues);
				
				FillDataset(transaction, CommandType.StoredProcedure, spName, dataSet, tableNames, commandParameters);
			}
			else
			{
				
				FillDataset(transaction, CommandType.StoredProcedure, spName, dataSet, tableNames);
			}
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		private static void FillDataset(FbConnection connection, FbTransaction transaction, CommandType commandType,
			string commandText, DataSet dataSet, string[] tableNames,
			params FbParameter[] commandParameters)
		{
			if (connection == null) throw new ArgumentNullException("connection");
			if (dataSet == null) throw new ArgumentNullException("dataSet");
			
			FbCommand command = new FbCommand();
			bool mustCloseConnection = false;
			PrepareCommand(command, connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);
			
			using (FbDataAdapter dataAdapter = new FbDataAdapter(command))
			{
				
				if (tableNames != null && tableNames.Length > 0)
				{
					string tableName = "Table";
					for (int index = 0; index < tableNames.Length; index++)
					{
						if (tableNames[index] == null || tableNames[index].Length == 0) throw new ArgumentException("The tableNames parameter must contain a list of tables, a value was provided as null or empty string.", "tableNames");
						dataAdapter.TableMappings.Add(tableName, tableNames[index]);
						tableName += (index + 1).ToString();
					}
				}
				
				dataAdapter.Fill(dataSet);
				
				command.Parameters.Clear();
			}
			if (mustCloseConnection)
				connection.Close();
		}
		#endregion
		#region UpdateDataset
		
		
		
		
		
		
		
		
		
		
		
		
		public static void UpdateDataset(FbCommand insertCommand, FbCommand deleteCommand, FbCommand updateCommand, DataSet dataSet, string tableName)
		{
			if (insertCommand == null) throw new ArgumentNullException("insertCommand");
			if (deleteCommand == null) throw new ArgumentNullException("deleteCommand");
			if (updateCommand == null) throw new ArgumentNullException("updateCommand");
			if (tableName == null || tableName.Length == 0) throw new ArgumentNullException("tableName");
			
			using (FbDataAdapter dataAdapter = new FbDataAdapter())
			{
				
				dataAdapter.UpdateCommand = updateCommand;
				dataAdapter.InsertCommand = insertCommand;
				dataAdapter.DeleteCommand = deleteCommand;
				
				dataAdapter.Update(dataSet, tableName);
				
				dataSet.AcceptChanges();
			}
		}
		#endregion
		#region CreateCommand
		
		
		
		
		
		
		
		
		
		
		
		
		public static FbCommand CreateCommand(FbConnection connection, string spName, params string[] sourceColumns)
		{
			if (connection == null) throw new ArgumentNullException("connection");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			
			FbCommand cmd = new FbCommand(spName, connection);
			cmd.CommandType = CommandType.StoredProcedure;
			
			if ((sourceColumns != null) && (sourceColumns.Length > 0))
			{
				
				FbParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection, spName);
				
				for (int index = 0; index < sourceColumns.Length; index++)
					commandParameters[index].SourceColumn = sourceColumns[index];
				
				AttachParameters(cmd, commandParameters);
			}
			return cmd;
		}
		#endregion
		#region ExecuteNonQueryTypedParams
		
		
		
		
		
		
		
		
		
		
		public static int ExecuteNonQueryTypedParams(String connectionString, String spName, DataRow dataRow)
		{
			if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			
			if (dataRow != null && dataRow.ItemArray.Length > 0)
			{
				
				FbParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);
				
				AssignParameterValues(commandParameters, dataRow);
				return SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				return SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName);
			}
		}
		
		
		
		
		
		
		
		
		
		
		public static int ExecuteNonQueryTypedParams(FbConnection connection, String spName, DataRow dataRow)
		{
			if (connection == null) throw new ArgumentNullException("connection");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			
			if (dataRow != null && dataRow.ItemArray.Length > 0)
			{
				
				FbParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection, spName);
				
				AssignParameterValues(commandParameters, dataRow);
				return SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				return SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName);
			}
		}
		
		
		
		
		
		
		
		
		
		
		public static int ExecuteNonQueryTypedParams(FbTransaction transaction, String spName, DataRow dataRow)
		{
			if (transaction == null) throw new ArgumentNullException("transaction");
			if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			
			if (dataRow != null && dataRow.ItemArray.Length > 0)
			{
				
				FbParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName);
				
				AssignParameterValues(commandParameters, dataRow);
				return SqlHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				return SqlHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName);
			}
		}
		#endregion
		#region ExecuteDatasetTypedParams
		
		
		
		
		
		
		
		
		
		
		public static DataSet ExecuteDatasetTypedParams(string connectionString, String spName, DataRow dataRow)
		{
			if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			
			if (dataRow != null && dataRow.ItemArray.Length > 0)
			{
				
				FbParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);
				
				AssignParameterValues(commandParameters, dataRow);
				return SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				return SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, spName);
			}
		}
		
		
		
		
		
		
		
		
		
		
		public static DataSet ExecuteDatasetTypedParams(FbConnection connection, String spName, DataRow dataRow)
		{
			if (connection == null) throw new ArgumentNullException("connection");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			
			if (dataRow != null && dataRow.ItemArray.Length > 0)
			{
				
				FbParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection, spName);
				
				AssignParameterValues(commandParameters, dataRow);
				return SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				return SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName);
			}
		}
		
		
		
		
		
		
		
		
		
		
		public static DataSet ExecuteDatasetTypedParams(FbTransaction transaction, String spName, DataRow dataRow)
		{
			if (transaction == null) throw new ArgumentNullException("transaction");
			if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			
			if (dataRow != null && dataRow.ItemArray.Length > 0)
			{
				
				FbParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName);
				
				AssignParameterValues(commandParameters, dataRow);
				return SqlHelper.ExecuteDataset(transaction, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				return SqlHelper.ExecuteDataset(transaction, CommandType.StoredProcedure, spName);
			}
		}
		#endregion
		#region ExecuteReaderTypedParams
		
		
		
		
		
		
		
		
		
		
		public static FbDataReader ExecuteReaderTypedParams(String connectionString, String spName, DataRow dataRow)
		{
			if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			
			if (dataRow != null && dataRow.ItemArray.Length > 0)
			{
				
				FbParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);
				
				AssignParameterValues(commandParameters, dataRow);
				return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, spName);
			}
		}
		
		
		
		
		
		
		
		
		
		
		public static FbDataReader ExecuteReaderTypedParams(FbConnection connection, String spName, DataRow dataRow)
		{
			if (connection == null) throw new ArgumentNullException("connection");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			
			if (dataRow != null && dataRow.ItemArray.Length > 0)
			{
				
				FbParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection, spName);
				
				AssignParameterValues(commandParameters, dataRow);
				return SqlHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				return SqlHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName);
			}
		}
		
		
		
		
		
		
		
		
		
		
		public static FbDataReader ExecuteReaderTypedParams(FbTransaction transaction, String spName, DataRow dataRow)
		{
			if (transaction == null) throw new ArgumentNullException("transaction");
			if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			
			if (dataRow != null && dataRow.ItemArray.Length > 0)
			{
				
				FbParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName);
				
				AssignParameterValues(commandParameters, dataRow);
				return SqlHelper.ExecuteReader(transaction, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				return SqlHelper.ExecuteReader(transaction, CommandType.StoredProcedure, spName);
			}
		}
		#endregion
		#region ExecuteScalarTypedParams
		
		
		
		
		
		
		
		
		
		
		public static object ExecuteScalarTypedParams(String connectionString, String spName, DataRow dataRow)
		{
			if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			
			if (dataRow != null && dataRow.ItemArray.Length > 0)
			{
				
				FbParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);
				
				AssignParameterValues(commandParameters, dataRow);
				return SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				return SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, spName);
			}
		}
		
		
		
		
		
		
		
		
		
		
		public static object ExecuteScalarTypedParams(FbConnection connection, String spName, DataRow dataRow)
		{
			if (connection == null) throw new ArgumentNullException("connection");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			
			if (dataRow != null && dataRow.ItemArray.Length > 0)
			{
				
				FbParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection, spName);
				
				AssignParameterValues(commandParameters, dataRow);
				return SqlHelper.ExecuteScalar(connection, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				return SqlHelper.ExecuteScalar(connection, CommandType.StoredProcedure, spName);
			}
		}
		
		
		
		
		
		
		
		
		
		
		public static object ExecuteScalarTypedParams(FbTransaction transaction, String spName, DataRow dataRow)
		{
			if (transaction == null) throw new ArgumentNullException("transaction");
			if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			
			if (dataRow != null && dataRow.ItemArray.Length > 0)
			{
				
				FbParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName);
				
				AssignParameterValues(commandParameters, dataRow);
				return SqlHelper.ExecuteScalar(transaction, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				return SqlHelper.ExecuteScalar(transaction, CommandType.StoredProcedure, spName);
			}
		}
		#endregion
		#region ExecuteXmlReaderTypedParams
		
		
		
		
		
		
		
		
		
		
		public static XmlReader ExecuteXmlReaderTypedParams(FbConnection connection, String spName, DataRow dataRow)
		{
			if (connection == null) throw new ArgumentNullException("connection");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			
			if (dataRow != null && dataRow.ItemArray.Length > 0)
			{
				
				FbParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection, spName);
				
				AssignParameterValues(commandParameters, dataRow);
				return SqlHelper.ExecuteXmlReader(connection, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				return SqlHelper.ExecuteXmlReader(connection, CommandType.StoredProcedure, spName);
			}
		}
		
		
		
		
		
		
		
		
		
		
		public static XmlReader ExecuteXmlReaderTypedParams(FbTransaction transaction, String spName, DataRow dataRow)
		{
			if (transaction == null) throw new ArgumentNullException("transaction");
			if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			
			if (dataRow != null && dataRow.ItemArray.Length > 0)
			{
				
				FbParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName);
				
				AssignParameterValues(commandParameters, dataRow);
				return SqlHelper.ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName, commandParameters);
			}
			else
			{
				return SqlHelper.ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName);
			}
		}
		#endregion




        public static void CloseReader(FbDataReader dr, FbConnection pcn)
        {
            if (dr != null && !dr.IsClosed)
            {
                
                dr.Close();
            }

            if(pcn != null /*&& pcn.State != ConnectionState.Closed*/)
            {
                pcn.Close();
            }
        }
	}
	
	
	
	
	public sealed class SqlHelperParameterCache
	{
		#region private methods, variables, and constructors
		
		
		private SqlHelperParameterCache() { }
		private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());
		
		
		
		
		
		
		
		private static FbParameter[] DiscoverSpParameterSet(FbConnection connection, string spName, bool includeReturnValueParameter)
		{
			if (connection == null) throw new ArgumentNullException("connection");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			FbCommand cmd = new FbCommand(spName, connection);
			cmd.CommandType = CommandType.StoredProcedure;
			connection.Open();
			FbCommandBuilder.DeriveParameters(cmd);
			connection.Close();
			if (!includeReturnValueParameter)
			{
				cmd.Parameters.RemoveAt(0);
			}
			FbParameter[] discoveredParameters = new FbParameter[cmd.Parameters.Count];
			cmd.Parameters.CopyTo(discoveredParameters, 0);
			
			foreach (FbParameter discoveredParameter in discoveredParameters)
			{
				discoveredParameter.Value = DBNull.Value;
			}
			return discoveredParameters;
		}
		
		
		
		
		
		private static FbParameter[] CloneParameters(FbParameter[] originalParameters)
		{
			FbParameter[] clonedParameters = new FbParameter[originalParameters.Length];
			for (int i = 0, j = originalParameters.Length; i < j; i++)
			{
				clonedParameters[i] = (FbParameter)((ICloneable)originalParameters[i]).Clone();
			}
			return clonedParameters;
		}
		#endregion private methods, variables, and constructors
		#region caching functions
		
		
		
		
		
		
		public static void CacheParameterSet(string connectionString, string commandText, params FbParameter[] commandParameters)
		{
			if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
			if (commandText == null || commandText.Length == 0) throw new ArgumentNullException("commandText");
			string hashKey = connectionString + ":" + commandText;
			paramCache[hashKey] = commandParameters;
		}
		
		
		
		
		
		
		public static FbParameter[] GetCachedParameterSet(string connectionString, string commandText)
		{
			if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
			if (commandText == null || commandText.Length == 0) throw new ArgumentNullException("commandText");
			string hashKey = connectionString + ":" + commandText;
			FbParameter[] cachedParameters = paramCache[hashKey] as FbParameter[];
			if (cachedParameters == null)
			{
				return null;
			}
			else
			{
				return CloneParameters(cachedParameters);
			}
		}
		#endregion caching functions
		#region Parameter Discovery Functions
		
		
		
		
		
		
		
		
		
		public static FbParameter[] GetSpParameterSet(string connectionString, string spName)
		{
			return GetSpParameterSet(connectionString, spName, false);
		}
		
		
		
		
		
		
		
		
		
		
		public static FbParameter[] GetSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
		{
			if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			using (FbConnection connection = new FbConnection(connectionString))
			{
				return GetSpParameterSetInternal(connection, spName, includeReturnValueParameter);
			}
		}
		
		
		
		
		
		
		
		
		
		internal static FbParameter[] GetSpParameterSet(FbConnection connection, string spName)
		{
			return GetSpParameterSet(connection, spName, false);
		}
		
		
		
		
		
		
		
		
		
		
		internal static FbParameter[] GetSpParameterSet(FbConnection connection, string spName, bool includeReturnValueParameter)
		{
			if (connection == null) throw new ArgumentNullException("connection");
			using (FbConnection clonedConnection = (FbConnection)((ICloneable)connection).Clone())
			{
				return GetSpParameterSetInternal(clonedConnection, spName, includeReturnValueParameter);
			}
		}
		
		
		
		
		
		
		
		private static FbParameter[] GetSpParameterSetInternal(FbConnection connection, string spName, bool includeReturnValueParameter)
		{
			if (connection == null) throw new ArgumentNullException("connection");
			if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
			string hashKey = connection.ConnectionString + ":" + spName + (includeReturnValueParameter ? ":include ReturnValue Parameter" : "");
			FbParameter[] cachedParameters;
			cachedParameters = paramCache[hashKey] as FbParameter[];
			if (cachedParameters == null)
			{
				FbParameter[] spParameters = DiscoverSpParameterSet(connection, spName, includeReturnValueParameter);
				paramCache[hashKey] = spParameters;
				cachedParameters = spParameters;
			}
			return CloneParameters(cachedParameters);
		}
		#endregion Parameter Discovery Functions
	}
	#region IniFile Class
	public class IniFile
	{
		public string Path;
		#region Win32
		[DllImport("kernel32")]
		private static extern decimal WritePrivateProfileString(string section,
			string key, string val, string filePath);
		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section,
				 string key, string def, StringBuilder retVal,
			int size, string filePath);
		#endregion
		#region Constructors
		public IniFile(string path)
		{
			Path = path;
		}
		#endregion
		#region Set Key
		public void SetKey(string section, string key, string value)
		{
			WritePrivateProfileString(section, key, value, this.Path);
		}
		#endregion
		#region Get Key
		public string GetKey(string section, string key)
		{
			StringBuilder temp = new StringBuilder(255);
			int i = GetPrivateProfileString(section, key, "", temp, 255, this.Path);
			return temp.ToString();
		}
		#endregion
	}
	#endregion
	#region SQLHelp Class
	public class SQLHelp
	{
		#region Helper Methods
		#region Common Methods
		
		#endregion
		#region Application Properties
		#region Folder Path
		
		public static string FolderApp
		{
			get { return AppDomain.CurrentDomain.BaseDirectory; }
		}
		
		public static string FolderRoot
		{
			get { return Path.GetFullPath(@"..\..\"); }
		}
		public static string FolderBin
		{
			get { return Path.GetFullPath(@".\"); }
		}
		public static string GetAppFolder(string name)
		{
			string path = SQLHelp.FolderApp + name + @"\";
			if (!Directory.Exists(path) || Directory.GetFiles(path).Length < 1)
			{
				path = SQLHelp.FolderRoot + name + @"\";
			}
			return path;
		}
		public static string FolderData
		{
			get { return SQLHelp.GetAppFolder("Data"); }
		}
		public static string FolderQuery
		{
			get { return SQLHelp.GetAppFolder("Query"); }
		}
		public static string FileFdb
		{
			get { return SQLHelp.FolderData + @"EMPLOYEE.FDB"; }
		}
		public static string FileQueryIni
		{
			get { return SQLHelp.FolderQuery + @"Query.ini"; }
		}
		#endregion
		#region Connectionstring
		public static string Connectionstring
		{
			get
			{
				return "ServerType=1;User=SYSDBA;Password=masterkey;Database=" + SQLHelp.FileFdb;
			}
		}
		#endregion
		#endregion
		#region String Helpers
		public static string Quote(string s)
		{
			return "\'" + s + "\'";
		}
		public static string SQuote(string s)
		{
			return " \'" + s + "\' ";
		}
		public static string DQuote(string s)
		{
			return "\"" + s + "\"";
		}
		public static string DSQuote(string s)
		{
			return " \"" + s + "\" ";
		}
		public static string Bracket(string s)
		{
			return "[" + s + "]";
		}
		public static string Parenthesis(string s)
		{
			return "(" + s + ")";
		}
		public static string Space(string s)
		{
			return " " + s + " ";
		}
		public static string Timestamp()
		{
			return DateTime.Now.ToString();
		}
		public static string BracketNonBlank(string s)
		{
			if (s.Trim() != "")
			{
				return SQLHelp.Bracket(s);
			}
			return s;
		}
		public static bool IsEmpty(string s)
		{
			return s == "";
		}
		public static bool IsAnyEmpty(params object[] vals)
		{
			for (int i = 0; i <= vals.Length; i++)
			{
				if (vals.GetValue(i).ToString() == "")
				{
					return true;
				}
			}
			return false;
		}
		public static bool IsNonEmpty(string s)
		{
			return s != "";
		}
		public static string LogStr(string s)
		{
			return "[" + s + "]";
		}
		public static string RemoveLast(string s)
		{
			return SQLHelp.RemoveLast(s, 1);
		}
		public static string RemoveLast(string s, int count)
		{
			return s.Remove(s.Length - count, count);
		}
		#endregion
		#endregion
	}
	#endregion
}
