using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ConexionesBD;
using FirebirdSql.Data.FirebirdClient;
namespace iPos
{
    class DataTablesParaGrid
    {
       
        public static DataTable GetDataFb(string FbCommand)
        {

            DataTable table = new DataTable();
            FbConnection northwindConnection = null;
            try
            {
                string connectionString = ConexionBD.ConexionString();
                northwindConnection = new FbConnection(connectionString);
                FbCommand command = new FbCommand(FbCommand, northwindConnection);
                FbDataAdapter adapter = new FbDataAdapter();
                adapter.SelectCommand = command;
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                adapter.Fill(table);
                northwindConnection.Close();
            }
            catch
            {
                if (northwindConnection != null)
                {
                    northwindConnection.Close();
                }
            }
            finally
            {

                if (northwindConnection != null)
                {
                    northwindConnection.Close();
                }
            }
            return table;
        }
        public static DataTable GetData(FbCommand command)
        {
            string connectionString = ConexionBD.ConexionString();
            return GetData( command, connectionString);
        }
        public static DataTable GetData(FbCommand command, string connectionString)
        {

            DataTable table = new DataTable();
            FbConnection northwindConnection = null;
            try{

                northwindConnection = new FbConnection(connectionString);
                command.Connection = northwindConnection;
                FbDataAdapter adapter = new FbDataAdapter();
                adapter.SelectCommand = command;
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                adapter.Fill(table);
                northwindConnection.Close();
            }
            catch
            {
                if (northwindConnection != null)
                {
                    northwindConnection.Close();
                }
            }
            finally
            {

                if (northwindConnection != null)
                {
                    northwindConnection.Close();
                }
            }
            return table;
        }
    }
}
