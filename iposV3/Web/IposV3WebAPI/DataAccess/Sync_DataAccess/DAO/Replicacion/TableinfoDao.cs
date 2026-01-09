using BIPOS.Database.DAO;
using DataAccess;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Data.OleDb;
using System.Data.Common;
using System.Collections;
using IposV3.Model.Syncr;
using IposV3.Model;
using NpgsqlTypes;
using IposV3.DataAccess;

namespace BIPOS.Database.DAO
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class TableinfoDao : TableinfoGeneratedDao
    {

        public TableinfoDao():base("")
        {
        }
        public TableinfoDao(string connectionString) : base(connectionString)
        {
        }
        public TableinfoDao(NpgsqlConnection sqlConnection) : base(sqlConnection) { }
        public TableinfoDao(Func<string> connectionMethod) : base(connectionMethod) { }




        public string equivalenciasTipoForms(string tipoEnBase)
        {
            Hashtable list_eq = new Hashtable();
            list_eq.Add("BOOLEAN", "Boolean");
            list_eq.Add("SMALLINT", "Int16");
            list_eq.Add("INTEGER", "Int32");
            list_eq.Add("BIGINT", "Int64");
            list_eq.Add("REAL", "double");
            list_eq.Add("DOUBLE PRECISION", "double");
            list_eq.Add("NUMERIC", "decimal");
            list_eq.Add("MONEY", "decimal");
            list_eq.Add("TEXT", "String");
            list_eq.Add("CHAR", "String");
            list_eq.Add("VARCHAR", "String");
            list_eq.Add("CITEXT", "String");
            list_eq.Add("JSON", "String");
            list_eq.Add("JSONB", "String");
            list_eq.Add("XML", "String");
            list_eq.Add("POINT", "NpgsqlPoint");
            list_eq.Add("LSEG", "NpgsqlLSeg");
            list_eq.Add("PATH", "NpgsqlPath");
            list_eq.Add("POLYGON", "NpgsqlPolygon");
            list_eq.Add("LINE", "NpgsqlLine");
            list_eq.Add("CIRCLE", "NpgsqlCircle");
            list_eq.Add("BOX", "NpgsqlBox");
            list_eq.Add("BIT", "Boolean");
            list_eq.Add("BIT VARYING", "Boolean");
            list_eq.Add("UUID", "Guid");
            list_eq.Add("MACADDR", "PhysicalAddress");
            list_eq.Add("TSQUERY", "NpgsqlTsQuery");
            list_eq.Add("TSVECTOR", "NpgsqlTsVector");
            list_eq.Add("DATE", "DateTime");
            list_eq.Add("INTERVAL", "String");
            list_eq.Add("TIMESTAMP", "DateTime");
            list_eq.Add("TIMESTAMP WITH TIME ZONE", "String");
            list_eq.Add("TIMESTAMP WITHOUT TIME ZONE", "DateTime");
            list_eq.Add("TIME", "DateTime");
            list_eq.Add("TIME WITH TIME ZONE", "String");
            list_eq.Add("BYTEA", "byte[]");
            list_eq.Add("OID", "uint");
            list_eq.Add("XID", "uint");
            list_eq.Add("CID", "uint");
            list_eq.Add("OIDVECTOR", "uint[]");
            list_eq.Add("NAME", "string");
            list_eq.Add("(INTERNAL) CHAR", "byte");


            if (list_eq.ContainsKey(tipoEnBase.ToUpper()))
            {
                return list_eq[tipoEnBase.ToUpper()]?.ToString() ?? "String";
            }
            else
            {
                return "String";
            }


        }


        public string getEquivalentDBFTypeText(string? sqlType, int fieldSize, int fieldScale, int fieldPrecision)
        {


            switch (sqlType)
            {
                case "BIGINT":
                    return "numeric" + "(18,0)";
                case "CHAR":
                case "VARCHAR":
                    return "char" + "(" + fieldSize.ToString() + ")";
                case "DATE":
                    return "date";
                case "DOUBLE PRECISION":
                case "FLOAT8":
                    return "numeric" + "(18," + fieldScale.ToString() + ")";
                case "INTEGER":
                    return "numeric" + "(12,0)";
                case "NUMERIC":
                    return "numeric" + "(" + fieldPrecision.ToString() + "," + fieldScale.ToString() + ")";
                case "SMALLINT":
                    return "numeric" + "(8,0)";
                case "TEXT":
                    return "char" + "(" + fieldSize.ToString() + ")";
                case "TIMESTAMP WITHOUT TIME ZONE":
                    return "char" + "(50)";

                case "TIMESTAMP WITH TIME ZONE":
                    return "char" + "(60)";


                case "BOOLEAN":
                case "BOX":
                case "BYTEA":
                case "CIRCLE":
                case "LINE":
                case "LSEG":
                case "MONEY":
                case "PATH":
                case "POINT":
                case "POLYGON":
                case "REAL":
                case "TIME":
                case "TIMESTAMP":
                case "REFCURSOR":
                case "INET":
                case "BIT":
                case "UUID":
                case "XML":
                case "OIDVECTOR":
                case "INTERVAL":
                case "NAME":
                case "MACADDR":
                case "JSON":
                case "JSONB":
                case "HSTORE":
                case "INTERNALCHAR":
                case "VARBIT":
                case "UNKNOWN":
                case "OID":
                case "XID":
                case "CID":
                case "CIDR":
                case "TSVECTOR":
                case "TSQUERY":
                case "REGTYPE":
                case "GEOMETRY":
                case "CITEXT":
                case "INT2VECTOR":
                case "TID":
                case "MACADDR8":
                case "GEOGRAPHY":
                case "REGCONFIG":
                    return "varchar" + "(" + fieldSize.ToString() + ")";

                default:
                    return "varchar" + "(" + fieldSize.ToString() + ")";
            }


        }

        public OleDbType getEquivalentOleDbType(string? sqlType)
        {
            switch (sqlType)
            {
                case "BIGINT":
                    return OleDbType.Numeric;
                case "CHAR":
                case "VARCHAR":
                    return OleDbType.Char;
                case "DATE":
                    return OleDbType.Date;
                case "DOUBLE PRECISION":
                case "FLOAT8":
                case "DOUBLE":
                    return OleDbType.Numeric;
                case "INTEGER":
                    return OleDbType.Numeric;
                case "NUMERIC":
                    return OleDbType.Numeric;
                case "SMALLINT":
                    return OleDbType.Numeric;
                case "TEXT":
                    return OleDbType.VarChar;
                case "TIMESTAMP WITHOUT TIME ZONE":
                    return OleDbType.Char;


                case "BOOLEAN":
                case "BOX":
                case "BYTEA":
                case "CIRCLE":
                case "LINE":
                case "LSEG":
                case "MONEY":
                case "PATH":
                case "POINT":
                case "POLYGON":
                case "REAL":
                case "TIME":
                case "TIMESTAMP":
                case "REFCURSOR":
                case "INET":
                case "BIT":
                case "UUID":
                case "XML":
                case "OIDVECTOR":
                case "INTERVAL":
                case "NAME":
                case "MACADDR":
                case "JSON":
                case "JSONB":
                case "HSTORE":
                case "INTERNALCHAR":
                case "VARBIT":
                case "UNKNOWN":
                case "OID":
                case "XID":
                case "CID":
                case "CIDR":
                case "TSVECTOR":
                case "TSQUERY":
                case "REGTYPE":
                case "GEOMETRY":
                case "CITEXT":
                case "INT2VECTOR":
                case "TID":
                case "MACADDR8":
                case "GEOGRAPHY":
                case "REGCONFIG":
                    return OleDbType.VarChar;


                default:
                    return OleDbType.VarChar;
            }
        }


        private string getRealTableNameForEFCore(string? fullTableName)
        {
            if (fullTableName == null)
                return "";

            var bufferSplit = fullTableName.Split('.');
            var tableName = bufferSplit.Last().Contains(@"""") ? bufferSplit.Last() : @"""" + bufferSplit.Last() + @"""";
            if(bufferSplit.Length > 1)
                return bufferSplit.First() + "." + tableName;

            return tableName;

        }

        private string getRealFieldNameForEFCore(string? fieldName)
        {
            if (fieldName == null)
                return "";

            return fieldName.Contains(@"""") ? fieldName : @"""" + fieldName + @"""";

        }

        public void LlenarDatosTableForExport(string pathDB, OleTable oleTable, List<OleField> oleFields)
        {

            using (OleDbConnection con = new OleDbConnection(GetDbfConnection(pathDB)))
            {
                try
                {


                    System.Collections.ArrayList parts = new ArrayList();
                    OleDbParameter auxPar;
                    OleDbParameter[] arParms;

                    //string oleDbCommandText = @" INSERT INTO fields (id, tableid, realfnme, dbffnme, fsize , fscale,ftype) values (?,  ? , ?, ?, ?, ?, ?);";

                    string oleDbCommandText = "INSERT INTO " + oleTable.Dbfname + " (";
                    string oleDBValuesQueryText = " VALUES( ";
                    foreach (var fieldInfo in oleFields)
                    {
                        string dbfType = getEquivalentDBFTypeText(fieldInfo.Ftype, fieldInfo.Fsize, fieldInfo.Fscale, fieldInfo.Fprec);
                        oleDbCommandText = oleDbCommandText + fieldInfo.Dbffnme + " ,";
                        oleDBValuesQueryText = oleDBValuesQueryText + " ? ,";

                    }

                    oleDbCommandText = oleDbCommandText.Substring(0, oleDbCommandText.Length - 1) + ")";
                    oleDBValuesQueryText = oleDBValuesQueryText.Substring(0, oleDBValuesQueryText.Length - 1) + ")";
                    oleDbCommandText = oleDbCommandText + oleDBValuesQueryText;

                    var tableRealName = getRealTableNameForEFCore(oleTable.Realname);

                    string commandSelectText = @"select t.* from public.""Replmov"" replmov
                                          inner join public.""Repltabla"" repltabla on replmov.""Repltablaid"" = repltabla.""Id""
                                          inner join " + tableRealName + @" t ";

                    bool tieneCampoEmpresaId = oleFields.Any(o => o.Realfnme?.ToLower() == "empresaid");
                    bool tieneCampoSucursalId = oleFields.Any(o => o.Realfnme?.ToLower() == "sucursalid");

                    if (!tieneCampoEmpresaId && !tieneCampoSucursalId)
                    {
                        commandSelectText += @" on  replmov.""Idregistro"" = t.""Id""  " ;
                    }
                    else if (tieneCampoEmpresaId && !tieneCampoSucursalId)
                    {

                        commandSelectText += @" on t.""EmpresaId"" = replmov.""EmpresaId"" and " +
                                          @"      replmov.""Idregistro"" = t.""Id""  " ;
                    }
                    else
                    {
                        commandSelectText += @" on t.""EmpresaId"" = replmov.""EmpresaId"" and " +
                                          @"     t.""SucursalId"" = replmov.""SucursalId"" and replmov.""Idregistro"" = t.""Id""  " ;
                    }

                    commandSelectText += @" where repltabla.""Nombre"" = '" + oleTable.Realname + "' limit 1000";

                    using (DbDataReader dataReader = GetDataReader(commandSelectText, new List<DbParameter>(), System.Data.CommandType.Text))
                    {
                        if (dataReader != null && dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {

                                parts = new ArrayList();

                                foreach (var fieldInfo in oleFields)
                                {
                                    if (fieldInfo.Realfnme == null)
                                        throw new Exception("EL nombre real del campo no esta definido");

                                    var realfnme = getRealFieldNameForEFCore(fieldInfo.Realfnme);

                                    auxPar = new OleDbParameter("@" + fieldInfo.Dbffnme, getEquivalentOleDbType(fieldInfo.Ftype));

                                    switch(fieldInfo.Ftype)
                                    {
                                        case "TIMESTAMP WITHOUT TIME ZONE":
                                        case "TIMESTAMP":
                                        case "TIMESTAMP WITH TIME ZONE":
                                        case "TIME":
                                        case "TIME WITH TIME ZONE":

                                            if (dataReader[fieldInfo.Realfnme] == System.DBNull.Value)
                                                auxPar.Value = DBNull.Value;
                                            else

                                            auxPar.Value =  ((DateTime?)dataReader[fieldInfo.Realfnme]).Value.ToString("yyyy-MM-dd'T'HH:mm:ss.fff") ;
                                            break;

                                        default:
                                            auxPar.Value = dataReader[fieldInfo.Realfnme] != System.DBNull.Value ? dataReader[fieldInfo.Realfnme] : DBNull.Value; 
                                            break;
                                    }

                                    parts.Add(auxPar);



                                }

                                arParms = new OleDbParameter[parts.Count];
                                parts.CopyTo(arParms, 0);
                                OleDbHelper.ExecuteNonQuery(con, System.Data.CommandType.Text, oleDbCommandText, arParms);


                            }
                        }
                    }

                   


                }
                catch (Exception e)
                {
                    DevComment = e.Message + " " + e.StackTrace;
                    Comment = "Ocurrio un error al obtener el registro, vea la consola del explorador para mas detalles";
                    throw;
                }
                finally
                {
                    con.Close();
                }

            }
        }

        public void CreateDBFTableForExport(string pathDB, OleTable oleTable)
        {

            if (File.Exists(pathDB + oleTable.Dbfname + ".dbf"))
            {
                File.Delete(pathDB + oleTable.Dbfname + ".dbf");
            }

            var fields = OleFieldsForReplication(pathDB, oleTable.Id);

            string createSql = "create table " + oleTable.Dbfname + " (";

            foreach (var fieldInfo in fields)
            {
                string dbfType = getEquivalentDBFTypeText(fieldInfo.Ftype, fieldInfo.Fsize, fieldInfo.Fscale, fieldInfo.Fprec);
                createSql = createSql + fieldInfo.Dbffnme + " " + dbfType + " ,";

            }

            createSql = createSql.Substring(0, createSql.Length - 1) + ")";


            using (OleDbConnection con = new OleDbConnection(GetDbfConnection(pathDB)))
            {
                try
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = createSql;
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

            }
            LlenarDatosTableForExport(pathDB, oleTable, fields);


    }

        public void CreateDBFTablesForExport(string pathDB)
        {

            var listTables = OleTablesForReplication(pathDB);
            foreach (var table in listTables)
            {
                CreateDBFTableForExport(pathDB, table);
            }

        }

        public void CreateDBFFieldsControlFilesForExport(string pathDB)
        {
            string fileName = "fields";

            if (File.Exists(pathDB + fileName + ".dbf"))
            {
                File.Delete(pathDB + fileName + ".dbf");
            }
            string createSql = "create table " + fileName + " (id numeric(10,0), tableid numeric(10,0),  realfnme char(250),  dbffnme char(250),  fsize numeric(10,0),  fscale numeric(10,0), ftype char(250),  fprec numeric(10,0));";
            using (OleDbConnection con = new OleDbConnection(GetDbfConnection(pathDB)))
            {
                try
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = createSql;
                    cmd.ExecuteNonQuery();



                    var listTables = OleTablesForReplication(pathDB);

                    System.Collections.ArrayList parts = new ArrayList();
                    OleDbParameter auxPar;
                    OleDbParameter[] arParms;
                    int iCountField = 1;
                    int iConsecutive = 1;

                    string oleDbCommandText = @" INSERT INTO fields (id, tableid, realfnme, dbffnme, fsize , fscale,ftype, fprec) values (?,  ? , ?, ?, ?, ?, ?, ?);";



                    foreach (var table in listTables)
                    {
                        var bufferTableNames = table.Realname?.Split('.');
                        var tableName = bufferTableNames?[1];
                        var schemaName = bufferTableNames?[0];

                        var fieldInfoList = Select_V_field_info_List(null, new V_field_infoParam(0, 0) { P_tablename = tableName, P_schemaname = schemaName, P_activo = "S" }, null);

                        iCountField = 1;

                        foreach (var fieldInfo in fieldInfoList)
                        {

                            parts = new ArrayList();

                            auxPar = new OleDbParameter("@id", OleDbType.Numeric);
                            auxPar.Value = iConsecutive;
                            parts.Add(auxPar);


                            auxPar = new OleDbParameter("@tableid", OleDbType.Numeric);
                            auxPar.Value = table.Id;
                            parts.Add(auxPar);

                            auxPar = new OleDbParameter("@realfnme", OleDbType.Char, 250);
                            auxPar.Value = fieldInfo.Column_name;
                            parts.Add(auxPar);


                            auxPar = new OleDbParameter("@dbffnme", OleDbType.Char, 250);
                            auxPar.Value = "_" + iCountField.ToString().PadLeft(6, '0');
                            parts.Add(auxPar);


                            auxPar = new OleDbParameter("@fsize", OleDbType.Numeric);
                            auxPar.Value = fieldInfo.Size;
                            parts.Add(auxPar);


                            auxPar = new OleDbParameter("@fscale", OleDbType.Numeric);
                            auxPar.Value = fieldInfo.Numeric_scale;
                            parts.Add(auxPar);


                            auxPar = new OleDbParameter("@ftype", OleDbType.Char, 250);
                            auxPar.Value = fieldInfo.Data_type;
                            parts.Add(auxPar);

                            auxPar = new OleDbParameter("@fprec", OleDbType.Numeric);
                            auxPar.Value = fieldInfo.Numeric_precision ?? 0;
                            parts.Add(auxPar);


                            arParms = new OleDbParameter[parts.Count];
                            parts.CopyTo(arParms, 0);
                            OleDbHelper.ExecuteNonQuery(con, System.Data.CommandType.Text, oleDbCommandText, arParms);

                            iCountField++;
                            iConsecutive++;

                        }
                    }


                }
                catch (Exception e)
                {
                    DevComment = e.Message + " " + e.StackTrace;
                    Comment = "Ocurrio un error al obtener el registro, vea la consola del explorador para mas detalles";
                    throw;
                }
                finally
                {
                    con.Close();
                }

            }
        }


        public void CreateDBFTableControlFilesForExport(string pathDB, List<string> tableNames)
        {
            string fileName = "tables";

            if (File.Exists(pathDB + fileName + ".dbf"))
            {
                File.Delete(pathDB + fileName + ".dbf");
            }
            string createSql = "create table " + fileName + " (id numeric(10,0), realname char(250),  dbfname char(250));";
            using (OleDbConnection con = new OleDbConnection(GetDbfConnection(pathDB)))
            {
                try
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = createSql;
                    cmd.ExecuteNonQuery();




                    System.Collections.ArrayList parts = new ArrayList();
                    OleDbParameter auxPar;
                    OleDbParameter[] arParms;
                    int iCountTable = 1;

                    string oleDbCommandText = @" INSERT INTO tables (id, realname, dbfname) values (?,  ? , ?);";

                    foreach (var table in tableNames)
                    {

                        parts = new ArrayList();

                        auxPar = new OleDbParameter("@id", OleDbType.Numeric);
                        auxPar.Value = iCountTable;
                        parts.Add(auxPar);


                        auxPar = new OleDbParameter("@realname", OleDbType.Char, 250);
                        auxPar.Value = table.Replace(@"""","");
                        parts.Add(auxPar);


                        auxPar = new OleDbParameter("@dbfname", OleDbType.Char, 250);
                        auxPar.Value = "_" + iCountTable.ToString().PadLeft(6,'0');
                        parts.Add(auxPar);


                        arParms = new OleDbParameter[parts.Count];
                        parts.CopyTo(arParms, 0);
                        OleDbHelper.ExecuteNonQuery(con, System.Data.CommandType.Text, oleDbCommandText, arParms);

                        iCountTable++;
                    }


                }
                catch (Exception e)
                {
                    DevComment = e.Message + " " + e.StackTrace;
                    Comment = "Ocurrio un error al obtener el registro, vea la consola del explorador para mas detalles";
                    throw;
                }
                finally
                {
                    con.Close();
                }

            }
        }


        public List<OleTable> OleTablesForReplication(string pathDB)
        {

            var oleTables = new List<OleTable>();

            string fileName = "tables";
            string selectSql = "select * from " + fileName + " ";
            using (OleDbConnection con = new OleDbConnection(GetDbfConnection(pathDB)))
            {
                try
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    con.Open();

                    cmd.CommandText = selectSql;

                    using (var dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader != null && dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                var item = new OleTable();
                                item.Id = (int)(dataReader["id"] != System.DBNull.Value ? (decimal)dataReader["id"] : (decimal)0);
                                item.Realname = dataReader["realname"] != System.DBNull.Value ? ((string)dataReader["realname"]).Trim() : "";
                                item.Dbfname = dataReader["dbfname"] != System.DBNull.Value ? ((string)dataReader["dbfname"]).Trim() : "";
                                oleTables.Add(item);

                            }
                        }
                    }


                }
                catch (Exception e)
                {
                    DevComment = e.Message + " " + e.StackTrace;
                    Comment = "Ocurrio un error al obtener el registro, vea la consola del explorador para mas detalles";
                    throw;
                }
                finally
                {
                    con.Close();
                }
                return oleTables;
            }
        }



        public List<OleField> OleFieldsForReplication(string pathDB, int tableId)
        {

            var oleFields = new List<OleField>();

            string fileName = "fields";
            string selectSql = "select * from " + fileName + " where tableid = " + tableId.ToString() + "";
            using (OleDbConnection con = new OleDbConnection(GetDbfConnection(pathDB)))
            {
                try
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    con.Open();

                    cmd.CommandText = selectSql;

                    using (var dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader != null && dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                var item = new OleField();
                                item.Id = (int)(dataReader["id"] != System.DBNull.Value ? (decimal)dataReader["id"] : (decimal)0);
                                item.Tableid = (int)(dataReader["tableid"] != System.DBNull.Value ? (decimal)dataReader["tableid"] : (decimal)0);
                                item.Realfnme = dataReader["realfnme"] != System.DBNull.Value ? ((string)dataReader["realfnme"]).Trim() : "";
                                item.Dbffnme = dataReader["dbffnme"] != System.DBNull.Value ? ((string)dataReader["dbffnme"]).Trim() : "";
                                item.Fsize = (int)(dataReader["fsize"] != System.DBNull.Value ? (decimal)dataReader["fsize"] : (decimal)0);
                                item.Fscale = (int)(dataReader["fscale"] != System.DBNull.Value ? (decimal)dataReader["fscale"] : (decimal)0);
                                item.Ftype = dataReader["ftype"] != System.DBNull.Value ? ((string)dataReader["ftype"]).Trim() : "";

                                try
                                {
                                    item.Fprec = (int)(dataReader["fprec"] != System.DBNull.Value ? (decimal)dataReader["fprec"] : (decimal)0);
                                }
                                catch {
                                    item.Fprec = 0;
                                }

                                oleFields.Add(item);

                            }
                        }
                    }


                }
                catch (Exception e)
                {
                    DevComment = e.Message + " " + e.StackTrace;
                    Comment = "Ocurrio un error al obtener el registro, vea la consola del explorador para mas detalles";
                    throw;
                }
                finally
                {
                    con.Close();
                }
                return oleFields;
            }
        }


        public void ExportChangesToDBF(string pathDB, List<string> tableNames)
        {
            //CreateDBFTableControlFilesForExport(pathDB, tableNames);
            //CreateDBFFieldsControlFilesForExport(pathDB);
            CreateDBFTablesForExport(pathDB);
        }

        protected static string GetDbfConnection(string path)
        {
            return @"Provider=VFPOLEDB.1;Data Source=" + path + @"\";
        }

    }
}
