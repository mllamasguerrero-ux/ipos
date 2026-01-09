using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace DataLayer.Utilerias
{
    public class ExcelHelper
    {
        private string rutaArchivo;

        private string comentario;
        public ExcelHelper()
        {

        }

        public string RutaArchivo { get => rutaArchivo; set => rutaArchivo = value; }
        public string Comentario { get => comentario; set => comentario = value; }

        private string ObtenerCadenaConexion()
        {
            Dictionary<string, string> componentes = new Dictionary<string, string>();

            // XLSX - Excel 2007, 2010, 2012, 2013
            componentes["Provider"] = "Microsoft.ACE.OLEDB.12.0;";
            componentes["Extended Properties"] = "Excel 12.0 XML";
            componentes["Data Source"] = rutaArchivo;

            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, string> componente in componentes)
            {
                sb.Append(componente.Key);
                sb.Append('=');
                sb.Append(componente.Value);
                sb.Append(';');
            }

            return sb.ToString();
        }

        private List<string> ObtenerColumnas()
        {
            List<string> columnas = new List<string>();
            columnas.Add("LINEACLAVE");
            columnas.Add("LINEANOMBRE");
            columnas.Add("MARCACLAVE");
            columnas.Add("MARCANOMBRE");
            columnas.Add("PRODUCTOCLAVE");
            columnas.Add("PRODUCTONOMBRE");
            columnas.Add("PRODUCTODESCRIPCION");
            columnas.Add("PRODUCTODESCRIPCION1");
            columnas.Add("CLAVESAT");

            return columnas;
        }

        private string ObtenerParteColumnas(bool crearTabla)
        {
            StringBuilder stringBuilder = new StringBuilder();
            List<string> columnas = ObtenerColumnas();

            for (int i = 0; i < columnas.Count; i++)
            {
                stringBuilder.Append(columnas[i]);

                if (crearTabla)
                    stringBuilder.Append(" VARCHAR");

                if (i < columnas.Count - 1)
                    stringBuilder.Append(" ,");
                else
                    stringBuilder.Append(" )");
            }

            return stringBuilder.ToString();
        }

        private string ObtenerParteValores(Dictionary<string, string> valores)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(" VALUES(");
            for(int i = 0; i < valores.Count(); i++)
            {
                KeyValuePair<string, string> valor = valores.ElementAt(i);

                string value = valor.Value;
                if (value.Contains("'"))
                    value = value.Replace("'", "''");

                stringBuilder.Append("'" + value);

                if (i < valores.Count - 1)
                    stringBuilder.Append("', ");
                else
                    stringBuilder.Append("')");
            }

            return stringBuilder.ToString();
        }

        private string ObtenerQueryCreacion()
        {
            StringBuilder stringBuilder = new StringBuilder();
            List<string> columnas = ObtenerColumnas();

            stringBuilder.Append("CREATE TABLE [PRODUCTOSAT] (");
            string parteColumnas = ObtenerParteColumnas(true);

            stringBuilder.Append(parteColumnas);

            return stringBuilder.ToString();
        }

        private string ObtenerQueryInsercion(Dictionary<string, string> registro)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("INSERT INTO [PRODUCTOSAT$](");

            string parteColumnas = ObtenerParteColumnas(false);
            stringBuilder.Append(parteColumnas);

            string parteValores = ObtenerParteValores(registro);
            stringBuilder.Append(parteValores);            

            return stringBuilder.ToString();
        }

        public bool ExportarDatos(List<Dictionary<string, string>> datos)
        {
            try
            {
                string cadenaConexion = ObtenerCadenaConexion();

                using (OleDbConnection conexion = new OleDbConnection(cadenaConexion))
                {
                    conexion.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = conexion;

                    cmd.CommandText = ObtenerQueryCreacion();
                    cmd.ExecuteNonQuery();

                    foreach (Dictionary<string, string> dato in datos)
                    {
                        cmd.CommandText = ObtenerQueryInsercion(dato);
                        cmd.ExecuteNonQuery();
                    }

                    conexion.Close();
                }

                return true;
            }
            catch(Exception e)
            {
                comentario = e.Message;
                return false;
            }
        }

        public DataSet ImportarDatos()
        {
            try
            {
                DataSet ds = new DataSet();

                string cadenaConexion = ObtenerCadenaConexion();

                using (OleDbConnection conn = new OleDbConnection(cadenaConexion))
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = conn;

                    // Get all Sheets in Excel File
                    DataTable dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    // Loop through all Sheets to get data
                    foreach (DataRow dr in dtSheet.Rows)
                    {
                        string sheetName = dr["TABLE_NAME"].ToString();

                        if (!sheetName.EndsWith("$"))
                            continue;

                        // Get all rows from the Sheet
                        cmd.CommandText = "SELECT * FROM [" + sheetName + "]";

                        DataTable dt = new DataTable();
                        dt.TableName = sheetName;

                        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                        da.Fill(dt);

                        ds.Tables.Add(dt);
                    }

                    cmd = null;
                    conn.Close();
                }

                return ds;
            }
            catch(Exception e)
            {
                comentario = e.Message;
                return null;
            }
            
        }
    }
}
