using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Collections;
using System.Data.Common;
using IposV3.Model;
using Microsoft.EntityFrameworkCore;
using NpgsqlTypes;
using FirebirdSql.Data.FirebirdClient;
using System.Data;

namespace IposV3.Services
{

    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class ImpoExpoField
    {
        public string LocalField { get; set; }
        public string ExternalField { get; set; }

        public int FieldSize { get; set; }
        public int FieldPrecision { get; set; }

        public OleDbType OleType { get; set; }

        public Type FieldType { get; set; }

        public string DbfType { get; set; }

        public NpgsqlDbType NpgsqlType { get; set; }


        public ImpoExpoField(string localField, string externalField, 
                             int fieldSize, int fieldPrecision,
                             OleDbType oleType, Type fieldType, string dbfType)
        {
            LocalField = localField;
            ExternalField = externalField;
            FieldSize = fieldSize;
            FieldPrecision = fieldPrecision;
            OleType = oleType;
            FieldType = fieldType;
            DbfType = dbfType;
        }


        public ImpoExpoField(string localField, string externalField,
                             int fieldSize, int fieldPrecision,
                              NpgsqlDbType npgsqlType, Type fieldType)
        {
            LocalField = localField;
            ExternalField = externalField;
            FieldSize = fieldSize;
            FieldPrecision = fieldPrecision;
            FieldType = fieldType;
            NpgsqlType = npgsqlType;

            OleType = getEquivalentOleDbType(npgsqlType);
            DbfType = getEquivalentDBFTypeText();
        }

        public ImpoExpoField(string localField, int fieldSize, int fieldPrecision,
                             OleDbType oleType, Type fieldType, string dbfType)
        {

            LocalField = localField;
            ExternalField = (localField.Length < 10 ? localField : localField.Substring(0, 10)).ToLower();
            FieldSize = fieldSize;
            FieldPrecision = fieldPrecision;
            OleType = oleType;
            FieldType = fieldType;
            DbfType = dbfType;
        }

        public ImpoExpoField(string localField) : this(localField, 254, 0, OleDbType.VarChar, typeof(String), "varchar(254)")
        {

        }


        public OleDbType getEquivalentOleDbType(NpgsqlDbType sqlType)
        {
            switch (sqlType)
            {
                case NpgsqlDbType.Bigint:
                    return OleDbType.Numeric;
                case NpgsqlDbType.Char:
                    return OleDbType.Char;
                case NpgsqlDbType.Date:
                    return OleDbType.Date;
                case NpgsqlDbType.Double:
                    return OleDbType.Numeric;
                case NpgsqlDbType.Integer:
                    return OleDbType.Numeric;
                case NpgsqlDbType.Numeric:
                    return OleDbType.Numeric;
                case NpgsqlDbType.Smallint:
                    return OleDbType.Numeric;
                case NpgsqlDbType.Text:
                    return OleDbType.VarChar;
                case NpgsqlDbType.Varchar:
                    return OleDbType.VarChar;


                case NpgsqlDbType.Boolean:
                case NpgsqlDbType.Box:
                case NpgsqlDbType.Bytea:
                case NpgsqlDbType.Circle:
                case NpgsqlDbType.Line:
                case NpgsqlDbType.LSeg:
                case NpgsqlDbType.Money:
                case NpgsqlDbType.Path:
                case NpgsqlDbType.Point:
                case NpgsqlDbType.Polygon:
                case NpgsqlDbType.Real:
                case NpgsqlDbType.Time:
                case NpgsqlDbType.Timestamp:
                case NpgsqlDbType.Refcursor:
                case NpgsqlDbType.Inet:
                case NpgsqlDbType.Bit:
                case NpgsqlDbType.Uuid:
                case NpgsqlDbType.Xml:
                case NpgsqlDbType.Oidvector:
                case NpgsqlDbType.Interval:
                case NpgsqlDbType.Name:
                case NpgsqlDbType.MacAddr:
                case NpgsqlDbType.Json:
                case NpgsqlDbType.Jsonb:
                case NpgsqlDbType.Hstore:
                case NpgsqlDbType.InternalChar:
                case NpgsqlDbType.Varbit:
                case NpgsqlDbType.Unknown:
                case NpgsqlDbType.Oid:
                case NpgsqlDbType.Xid:
                case NpgsqlDbType.Cid:
                case NpgsqlDbType.Cidr:
                case NpgsqlDbType.TsVector:
                case NpgsqlDbType.TsQuery:
                case NpgsqlDbType.Regtype:
                case NpgsqlDbType.Geometry:
                case NpgsqlDbType.Citext:
                case NpgsqlDbType.Int2Vector:
                case NpgsqlDbType.Tid:
                case NpgsqlDbType.MacAddr8:
                case NpgsqlDbType.Geography:
                case NpgsqlDbType.Regconfig:
                    return OleDbType.VarChar;

                default:
                    return OleDbType.VarChar;
            }
        }
        public string getEquivalentDBFTypeText()
        {


            switch (this.NpgsqlType)
            {
                case NpgsqlDbType.Bigint:
                    return "numeric" + "(18,0)";
                case NpgsqlDbType.Char:
                    return "char" + "(" + FieldSize.ToString() + ")";
                case NpgsqlDbType.Date:
                    return "date";
                case NpgsqlDbType.Double:
                    return "numeric" + "(18," + FieldPrecision.ToString() + ")";
                case NpgsqlDbType.Integer:
                    return "numeric" + "(12,0)";
                case NpgsqlDbType.Numeric:
                    return "numeric" + "(" + FieldSize.ToString() + "," + FieldPrecision.ToString() + ")";
                case NpgsqlDbType.Smallint:
                    return "numeric" + "(8,0)";
                case NpgsqlDbType.Text:
                    return "char" + "(" + FieldSize.ToString() + ")";
                case NpgsqlDbType.Varchar:
                    return "char" + "(" + FieldSize.ToString() + ")";


                case NpgsqlDbType.Boolean:
                case NpgsqlDbType.Box:
                case NpgsqlDbType.Bytea:
                case NpgsqlDbType.Circle:
                case NpgsqlDbType.Line:
                case NpgsqlDbType.LSeg:
                case NpgsqlDbType.Money:
                case NpgsqlDbType.Path:
                case NpgsqlDbType.Point:
                case NpgsqlDbType.Polygon:
                case NpgsqlDbType.Real:
                case NpgsqlDbType.Time:
                case NpgsqlDbType.Timestamp:
                case NpgsqlDbType.Refcursor:
                case NpgsqlDbType.Inet:
                case NpgsqlDbType.Bit:
                case NpgsqlDbType.Uuid:
                case NpgsqlDbType.Xml:
                case NpgsqlDbType.Oidvector:
                case NpgsqlDbType.Interval:
                case NpgsqlDbType.Name:
                case NpgsqlDbType.MacAddr:
                case NpgsqlDbType.Json:
                case NpgsqlDbType.Jsonb:
                case NpgsqlDbType.Hstore:
                case NpgsqlDbType.InternalChar:
                case NpgsqlDbType.Varbit:
                case NpgsqlDbType.Unknown:
                case NpgsqlDbType.Oid:
                case NpgsqlDbType.Xid:
                case NpgsqlDbType.Cid:
                case NpgsqlDbType.Cidr:
                case NpgsqlDbType.TsVector:
                case NpgsqlDbType.TsQuery:
                case NpgsqlDbType.Regtype:
                case NpgsqlDbType.Geometry:
                case NpgsqlDbType.Citext:
                case NpgsqlDbType.Int2Vector:
                case NpgsqlDbType.Tid:
                case NpgsqlDbType.MacAddr8:
                case NpgsqlDbType.Geography:
                case NpgsqlDbType.Regconfig:
                    return "varchar" + "(" + FieldSize.ToString() + ")";

                default:
                    return "varchar" + "(" + FieldSize.ToString() + ")";
            }


        }
    }

    public class ImpoExpoValor
    {

        public string LocalField { get; set; }
        public object? Valor { get; set; }
        public object? ValorDefault { get; set; }

        public ImpoExpoValor(string localField, object? valor, object? valorDefault)
        {
            LocalField = localField;
            Valor = valor;
            ValorDefault = valorDefault;
        }

    }


#pragma warning disable CA1416
    public class BaseImpoExpoService
    {



        public delegate bool ImportFromReaderDelegate(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                                      OleDbDataReader dr, List<ImpoExpoField> fields, ApplicationDbContext localContext);


        public delegate bool ImportFromFirebirdReaderDelegate(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               FbDataReader dataReader, ApplicationDbContext localContext);


        public string GetConnection(string path)
        {
            return @"Provider=VFPOLEDB.1;Data Source=" + path + @"\";
        }
        public string ReplaceEscape(string str)
        {
            str = str.Replace("'", "''");
            return str;
        }

        public void Export(long empresaId, long sucursalId, string fileName, string pathDB, ApplicationDbContext localContext, long? doctoId = null)
        {
            IQueryable<List<ImpoExpoValor>>? valoresItem = ObtainImpoExpoValores(empresaId, sucursalId, doctoId,  localContext);
            List<ImpoExpoField>? fields = ObtainImpoExpoFields();

            if (valoresItem == null || fields == null)
                throw new Exception("No hay suficiente informacion a exportar");

            ExportToDBF(fileName, pathDB, valoresItem, fields);

        }

        public virtual void Import(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                    string fileName, string pathDB, ApplicationDbContext localContext)
        {
            IQueryable<List<ImpoExpoValor>>? valoresItem = ObtainImpoExpoValores(empresaId, sucursalId, doctoId, localContext);
            List<ImpoExpoField>? fields = ObtainImpoExpoFields();

            if (valoresItem == null || fields == null)
                throw new Exception("No hay suficiente informacion a exportar");

            ImportFromDbf(empresaId, sucursalId, usuarioId,ref doctoId,  tipoDoctoId,
                                          fileName, pathDB, fields,
                                          new ImportFromReaderDelegate(ImportFromReader),localContext);

        }




        public virtual void ImportarDeTablaFirebird(long empresaId, long sucursalId, long? usuarioId, 
                                                    ref long? doctoId, long? tipoDoctoId,
                                                    string fbCadenaConexion,
                                                    string? nombreTabla, string? queryPersonalizada,
                                                    ApplicationDbContext localContext)
        {

            this.ImportarDeFirebird(empresaId, sucursalId, usuarioId, ref doctoId, tipoDoctoId,
                                        fbCadenaConexion,
                                        nombreTabla,  queryPersonalizada,
                                        new ImportFromFirebirdReaderDelegate(ImportFromFirebirdReader), localContext);

        }

        public virtual IQueryable<List<ImpoExpoValor>>? ObtainImpoExpoValores(long empresaId, long sucursalId, ApplicationDbContext localContext)
        {
            throw new Exception("Not implemented");
        }

        public virtual IQueryable<List<ImpoExpoValor>>? ObtainImpoExpoValores(long empresaId, long sucursalId, long? doctoId, ApplicationDbContext localContext)
        {
            if (doctoId == null)
            {
                return ObtainImpoExpoValores( empresaId,  sucursalId, localContext);
                
            }

            throw new Exception("Not implemented");
        }

        public virtual List<ImpoExpoField> ObtainImpoExpoFields()
        {

            throw new Exception("Not implemented");
        }

        public virtual bool ImportFromReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId, 
                                             OleDbDataReader dataReader, List<ImpoExpoField> fields, ApplicationDbContext localContext)
        {
            throw new Exception("Not implemented");
        }


        public virtual bool ImportFromFirebirdReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               FbDataReader dataReader, ApplicationDbContext localContext)
        {
            throw new Exception("Not implemented");
        }



        public void ExportToDBF(string fileName, string pathDB, IQueryable<List<ImpoExpoValor>> valores, List<ImpoExpoField> fields)
        {


            if (File.Exists(pathDB + fileName + ".dbf"))
            {
                File.Delete(pathDB + fileName + ".dbf");
            }


            string createSql = "create table " + fileName + " (";

            foreach (ImpoExpoField dc in fields)
            {
                string dbfType = dc.DbfType;
                createSql = createSql + "" + dc.ExternalField + "" + " " + dbfType + " ,";

            }

            createSql = createSql.Substring(0, createSql.Length - 1) + ")";


            using (OleDbConnection con = new OleDbConnection(GetConnection(pathDB)))
            {

                try
                {
                    OleDbCommand cmd = new OleDbCommand();

                    cmd.Connection = con;

                    con.Open();

                    cmd.CommandText = createSql;

                    cmd.ExecuteNonQuery();


                    foreach(var valor in valores)
                    {

                        ExecuteExportOleDbCommand(valor, fileName, fields, con);

                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    throw ;
                }
                finally
                {
                    con.Close();
                    System.Data.OleDb.OleDbConnection.ReleaseObjectPool();
                    GC.Collect();  // I know attation
                }

            }


        }

        public bool ExecuteExportOleDbCommand(List<ImpoExpoValor> valoresItem, string fileName, List<ImpoExpoField> fields, OleDbConnection con)
        {

            System.Collections.ArrayList parts = new ArrayList();
            OleDbParameter auxPar;

            foreach (var field in fields)
            {
                ImpoExpoValor? valorItem = valoresItem.FirstOrDefault(v => v.LocalField == field.LocalField);
                if (valorItem == null)
                    continue;

                auxPar = new OleDbParameter("@" + field.ExternalField, field.OleType);
                if (valorItem.Valor != null)
                {
                    auxPar.Value = valorItem.Valor;
                }
                else
                {
                    auxPar.Value = valorItem.ValorDefault;
                }
                parts.Add(auxPar);
            }

            string commandText = @" INSERT INTO " + fileName + @" (";

            foreach (var field in fields)
            {
                commandText = commandText + " " + field.ExternalField + " ,";
            }
            commandText = commandText.Substring(0, commandText.Length - 1) + ") ";

            commandText = commandText + " VALUES(";

            foreach (var field in fields)
            {
                commandText = commandText + " ? ,";
            }
            commandText = commandText.Substring(0, commandText.Length - 1) + "); ";
            

            OleDbParameter[] arParms = new OleDbParameter[parts.Count];
            parts.CopyTo(arParms, 0);
            IposV3.DataAccess.OleDbHelper.ExecuteNonQuery(con, System.Data.CommandType.Text, commandText, arParms);





            return true;
        }



        public virtual void ImportFromDbf(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                          string fileName, string pathDB, List<ImpoExpoField> fields,
                                          ImportFromReaderDelegate importFromReaderDelegate, ApplicationDbContext localContext)
        {

            string selectSql = "select * from " + fileName;

            OleDbConnection con = new OleDbConnection(GetConnection(pathDB) );

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
                             importFromReaderDelegate(empresaId, sucursalId, usuarioId, ref doctoId, tipoDoctoId,
                                                        dataReader, fields, localContext);


                        }
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw ;
            }
            finally
            {
                con.Close();
            }
        }



        public virtual void ImportarDeFirebird(
                          long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                          string fbCadenaConexion,
                          string? nombreTabla, string? queryPersonalizada,
                          ImportFromFirebirdReaderDelegate importFromReaderDelegate, ApplicationDbContext localContext)
        {
            /**/
            FbDataReader? dr = null;
            FbConnection? pcn = null;

            var utf8 = new UTF8Encoding();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();

                String CmdTxt = queryPersonalizada != null ? queryPersonalizada : @"select * from " + (nombreTabla ?? "");

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                dr = FbSqlHelper.ExecuteReader(fbCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);


                while (dr.Read())
                {
                    try
                    {
                        importFromReaderDelegate(empresaId, sucursalId, usuarioId, ref doctoId, tipoDoctoId,
                                             dr, localContext);

                        
                    }
                    catch(Exception ex) {
                        Console.WriteLine(ex.Message);
                        throw;
                    }
                }
                localContext.SaveChanges();
                FbSqlHelper.CloseReader(dr, pcn!);


            }
            catch (Exception e)
            {
                if(dr != null && pcn != null)
                    FbSqlHelper.CloseReader(dr, pcn);

                Console.WriteLine(e.Message);
            }

        }


    }

#pragma warning restore CA1416
}
