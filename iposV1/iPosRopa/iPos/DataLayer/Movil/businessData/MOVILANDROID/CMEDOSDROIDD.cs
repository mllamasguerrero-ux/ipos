using ConexionesBD;
using DataLayer.Movil.businessEntity.MOVILANDROID;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Movil.businessData.MOVILANDROID
{
    public class CMEDOSDROIDD
    {
        private string iComentario;
        private string sCadenaConexion;
        private List<CEDOSDROIDBE> estados;
        private const string conexion = @"User = SYSDBA; 
                                Password = masterkey; 
                                Database = C:\IposProject\iPosRopa\iPos\iPos\bin\Debug\sampdata\VENMOVDROID.fdb; 
                                DataSource = localhost;";

        public CMEDOSDROIDD()
        {
            sCadenaConexion = ConexionBD.ConexionString();
            estados = new List<CEDOSDROIDBE>();
        }

        public CMEDOSDROIDD(string conexion)
        {
            sCadenaConexion = conexion;
            estados = new List<CEDOSDROIDBE>();
        }

        public string IComentario { get => iComentario; set => iComentario = value; }

        public bool ObtenerRegistros(FbTransaction st)
        {
            ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                sCadenaConexion = ConexionBD.ConexionString();
                parts = new ArrayList();

                CmdTxt = @"SELECT * FROM ESTADO";


                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    CEDOSDROIDBE edo = new CEDOSDROIDBE();

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        edo.Clave = (string)(dr["CLAVE"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        edo.Nombre = (string)(dr["NOMBRE"]);
                    }

                    estados.Add(edo);
                }

                SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                SqlHelper.CloseReader(dr, pcn);
                IComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public bool LimpiarTabla(FbTransaction st)
        {
            try
            {
                sCadenaConexion = conexion;

                ArrayList parts = new ArrayList();

                string commandText = @"DELETE FROM MEDOSDROID;";
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);

                return true;
            }
            catch (Exception e)
            {
                iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public bool InsertarEstado(CEDOSDROIDBE edo, FbTransaction st)
        {
            try
            {
                sCadenaConexion = conexion;
                ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                auxPar.Value = edo.Clave;
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                auxPar.Value = edo.Nombre;
                parts.Add(auxPar);

                string commandText = @"INSERT INTO MEDOSDROID(
                                            CLAVE,
                                            NOMBRE
                                       )
                                       Values(
                                            @CLAVE,
                                            @NOMBRE
                                        ); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;

            }
            catch (Exception e)
            {
                iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public bool LlenarTabla()
        {
            FbConnection fbConnection = new FbConnection(conexion);
            FbTransaction fbTransaction = null;
            bool retorno;

            try
            {
                fbConnection.Open();
                fbTransaction = fbConnection.BeginTransaction();

                if (!LimpiarTabla(null))
                    throw new Exception(iComentario);

                ObtenerRegistros(null);

                foreach (CEDOSDROIDBE edo in estados)
                {
                    if (!InsertarEstado(edo, fbTransaction))
                        throw new Exception(iComentario);
                }

                fbTransaction.Commit();

                retorno = true;
            }
            catch (Exception e)
            {
                fbTransaction.Rollback();
                iComentario = e.Message;
                retorno = false;
            }
            finally
            {
                fbConnection.Close();
            }

            return retorno;
        }
    }
}
