using ConexionesBD;
using DataLayer.Utilerias.Respuestas.CatalogoSat;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Utilerias.bussinesData
{
    public class DAOGenerico
    {
        private string sCadenaConexion;

        private string iComentario;
        public string IComentario
        {
            get
            {
                return iComentario;
            }
            set
            {
                iComentario = value;
            }
        }

        public DAOGenerico()
        {
            sCadenaConexion = ConexionBD.ConexionString();
        }

        public DAOGenerico(string conexion)
        {
            sCadenaConexion = conexion;
        }

        private string ConvertirFecha(string date, string type)
        {
            string retorno = String.Empty;

            if (date.Equals(String.Empty))
            {
                if (type.Equals("datetime"))
                    return "01.01.2017 00:00:00";
                else
                    return  "01.01.2017";
            }

            string[] componentes = date.Split(' ');
            componentes[0] = componentes[0].Replace("/", ".");

            if (type.Equals("datetime"))
                retorno = componentes[0] + " " + componentes[1];
            else
                retorno = componentes[0];

            return retorno;
        }

        private string PrepararQueryInsertUpdate(List<Field> registro, List<ColumnInfo> columnas, string tabla)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("UPDATE OR INSERT INTO ");
            stringBuilder.Append(tabla + "(");

            for(int i = 0; i < columnas.Count; i++)
            {
                ColumnInfo column = columnas[i];

                if (column.Name.Equals("RID_SUCURSAL")) continue;

                stringBuilder.Append(column.Name);

                if (i < columnas.Count - 1)
                    stringBuilder.Append(",");
            }

            stringBuilder.Append(") VALUES(");

            for(int i = 0; i < registro.Count; i++)
            {
                Field campo = registro[i];

                if (campo.Key.Equals("RID_SUCURSAL")) continue;

                ColumnInfo infoColumna = columnas.Find(e => e.Name.Equals(campo.Key));

                string valor = campo.Value == null ? String.Empty : campo.Value;

                if (infoColumna.DataType.Equals("datetime") || 
                    infoColumna.DataType.Equals("nvarchar") ||
                    infoColumna.DataType.Equals("varchar") || 
                    infoColumna.DataType.Equals("char") ||
                    infoColumna.DataType.Equals("date"))
                {
                    if (infoColumna.DataType.Equals("datetime"))
                        valor = ConvertirFecha(valor, "datetime");
                    else if (infoColumna.DataType.Equals("date"))
                        valor = ConvertirFecha(valor, "date");
                    else
                        if (valor.Contains("'"))
                            valor = valor.Replace("'", "''");

                    stringBuilder.Append("'" + valor + "'");
                }
                else
                {
                    if (valor.Equals(String.Empty))
                        valor = "0";

                    valor = valor.Replace(",",".");
                    
                    stringBuilder.Append(valor);
                }

                if (i < registro.Count - 1)
                    stringBuilder.Append(",");
            }

            stringBuilder.Append(") MATCHING(ID)");

            return stringBuilder.ToString();
        }

        public bool AgregarCambios(TableData cambio, FbTransaction fbTransaction)
        {
            try
            {
                foreach (List<Field> registro in cambio.Records)
                {
                    string query = PrepararQueryInsertUpdate(registro, cambio.Columns, cambio.Name);

                    if (fbTransaction == null)
                        SqlHelper.ExecuteNonQuery(sCadenaConexion, CommandType.Text, query);
                    else
                        SqlHelper.ExecuteNonQuery(fbTransaction, CommandType.Text, query);
                }
                return true;
            }
            catch (Exception e)
            {
                iComentario = e.Message;
                return false;
            }
        }
    }
}
