using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ConexionesBD;
using FirebirdSql.Data.FirebirdClient;
namespace iPos
{
    class DataTablesParaGridRpt
    {

        public static DataTable GetDataFb(string FbCommand)
        {
            string connectionString = iPosReporting.Properties.Settings.Default.iPosString;//ConexionBD.ConexionString();
            FbConnection northwindConnection = new FbConnection(connectionString);
            FbCommand command = new FbCommand(FbCommand, northwindConnection);
            FbDataAdapter adapter = new FbDataAdapter();
            adapter.SelectCommand = command;
            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            adapter.Fill(table);
            return table;
        }
        public static DataTable GetData(FbCommand command)
        {
            string connectionString = iPosReporting.Properties.Settings.Default.iPosString; 
            return GetData(command, connectionString);
        }
        public static DataTable GetData(FbCommand command, string connectionString)
        {

            FbConnection northwindConnection = new FbConnection(connectionString);
            command.Connection = northwindConnection;
            FbDataAdapter adapter = new FbDataAdapter();
            adapter.SelectCommand = command;
            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            adapter.Fill(table);
            return table;
        }
    }
}
