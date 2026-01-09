using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Npgsql;
using System.Linq;
using System.Threading.Tasks;
using NpgsqlTypes;

namespace BIPOS.Database
{
  public class BaseDataAccess
  {
    protected string Message { get; set; }
    protected string ConnectionString { get; set; }

    protected NpgsqlConnection Connection { get; set; }

    protected Func<string> ConnectionMethod { get; set; }

    protected bool IsConnected { get; set; }

    public BaseDataAccess()
    {
      IsConnected = false;
    }

    public BaseDataAccess(string connectionString)
    {
      this.ConnectionString = connectionString;
      this.Connection = null;
      this.ConnectionMethod = null;
      IsConnected = false;
    }



    public BaseDataAccess(NpgsqlConnection connection)
    {
      if (connection != null)
      {
        this.ConnectionString = connection.ConnectionString;
        this.Connection = connection;
        this.ConnectionMethod = null;
        IsConnected = true;
      }
    }


    public BaseDataAccess(Func<string> connectionMethod)
    {
            this.ConnectionString = connectionMethod();
            this.ConnectionMethod = connectionMethod;
            this.Connection = null;
            IsConnected = false;
    }

    public NpgsqlConnection GetConnection()
    {
      try
      {
        
        if(this.ConnectionString != null && this.ConnectionMethod != null && 
                    this.ConnectionString != this.ConnectionMethod() && 
                    this.Connection != null )
        {
                    try
                    {
                        this.Connection.Close();
                    }
                    catch { }
                    this.Connection = null;    
        }

        if (this.Connection != null)
        {
          if (this.Connection.State == ConnectionState.Open)
          {
            return this.Connection;
          }
          else
          {
            NpgsqlConnection connection = new NpgsqlConnection(this.ConnectionString);
            if (connection.State != ConnectionState.Open)
              connection.Open();
            return connection;
          }
        }

        else
        {
          string connectionStr = this.ConnectionMethod != null ? this.ConnectionMethod() :  this.ConnectionString;

          NpgsqlConnection connection = new NpgsqlConnection(connectionStr);
          if (connection.State != ConnectionState.Open)
            connection.Open();
          return connection;
        }
      }
      catch (Exception e)
      {
        this.Message = e.Message + " " + e.StackTrace;
        return null;
      }
    }

    public DbCommand GetCommand(DbConnection connection, string commandText, CommandType commandType)
    {
      NpgsqlCommand command = new NpgsqlCommand(commandText, connection as NpgsqlConnection);
      command.CommandType = commandType;
      return command;
    }

    public DbCommand GetCommand(DbTransaction transaction, string commandText, CommandType commandType)
    {
      NpgsqlCommand command = new NpgsqlCommand(commandText, transaction.Connection as NpgsqlConnection, transaction as NpgsqlTransaction);
      command.CommandType = commandType;
      return command;
    }

    public NpgsqlParameter GetParameter(string parameter, object value)
    {
      NpgsqlParameter parameterObject = new NpgsqlParameter(parameter, value != null ? value : DBNull.Value);
      parameterObject.Direction = ParameterDirection.Input;
      return parameterObject;
    }


    public NpgsqlParameter GetParameter(string parameter, NpgsqlDbType type, object value = null, ParameterDirection parameterDirection = ParameterDirection.InputOutput)
    {
      NpgsqlParameter parameterObject = new NpgsqlParameter(parameter, type);

      if (type == NpgsqlDbType.Varchar  || type == NpgsqlDbType.Text )
      {
        parameterObject.Size = -1;
      }

      parameterObject.Direction = parameterDirection;

      if (value != null)
      {
        parameterObject.Value = value;
      }
      else
      {
        parameterObject.Value = DBNull.Value;
      }

      return parameterObject;
    }

    public NpgsqlParameter GetParameterOut(string parameter, NpgsqlDbType type, object value = null, ParameterDirection parameterDirection = ParameterDirection.InputOutput)
    {
      return GetParameter(parameter, type, value, parameterDirection);
    }



    public int ExecuteNonQuery(string query, List<DbParameter> parameters, CommandType commandType, NpgsqlTransaction transaction)
    {
      int returnValue = -1;

      try
      {
        DbCommand cmd = this.GetCommand(transaction, query, commandType);



        if (parameters != null && parameters.Count > 0)
        {
          cmd.Parameters.AddRange(parameters.ToArray());
        }

        returnValue = cmd.ExecuteNonQuery();

      }
      catch (Exception ex)
      {
        //LogException("Failed to ExecuteNonQuery for " + procedureName, ex, parameters);
        throw ex;
      }

      return returnValue;
    }

    public int ExecuteNonQuery(string query, List<DbParameter> parameters, CommandType commandType)
    {
      int returnValue = -1;

      try
      {
        using (NpgsqlConnection connection = this.GetConnection())
        {
          DbCommand cmd = this.GetCommand(connection, query, commandType);

          if (parameters != null && parameters.Count > 0)
          {
            cmd.Parameters.AddRange(parameters.ToArray());
          }

          returnValue = cmd.ExecuteNonQuery();
        }
      }
      catch (Exception ex)
      {
        //LogException("Failed to ExecuteNonQuery for " + procedureName, ex, parameters);
        throw ex;
      }

      return returnValue;
    }

    public object ExecuteScalar(string procedureName, List<NpgsqlParameter> parameters)
    {
      object returnValue = null;

      try
      {
        using (DbConnection connection = this.GetConnection())
        {
          DbCommand cmd = this.GetCommand(connection, procedureName, CommandType.StoredProcedure);

          if (parameters != null && parameters.Count > 0)
          {
            cmd.Parameters.AddRange(parameters.ToArray());
          }

          returnValue = cmd.ExecuteScalar();
        }
      }
      catch (Exception ex)
      {
        //LogException("Failed to ExecuteScalar for " + procedureName, ex, parameters);
        throw ex;
      }

      return returnValue;
    }

     public DbDataReader GetDataReader(string query, List<DbParameter> parameters, CommandType commandType)
     {
            return GetDataReader(null, query, parameters, commandType);
     }

     public DbDataReader GetDataReader(NpgsqlTransaction st, string query, List<DbParameter> parameters, CommandType commandType)
    {
      DbDataReader ds;

      try
      {
        DbConnection connection = st != null ?  st.Connection : this.GetConnection();
        {
          DbCommand cmd = st != null  ? this.GetCommand(st, query, commandType) : this.GetCommand(connection, query, commandType);
          if (parameters != null && parameters.Count > 0)
          {
            cmd.Parameters.AddRange(parameters.ToArray());
          }

          ds = st != null ? cmd.ExecuteReader() :  cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
      }
      catch (Exception ex)
      {
        //LogException("Failed to GetDataReader for " + procedureName, ex, parameters);
        throw ex;
      }

      return ds;
    }
  }
}
