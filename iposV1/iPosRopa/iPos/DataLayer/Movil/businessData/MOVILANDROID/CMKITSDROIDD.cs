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
    public class CMKITSDROIDD
    {
        private string iComentario;
        private string sCadenaConexion;
        private List<CKITDROIDBE> kits;
        private const string conexion = @"User = SYSDBA; 
                                Password = masterkey; 
                                Database = C:\IposProject\iPosRopa\iPos\iPos\bin\Debug\sampdata\VENMOVDROID.fdb; 
                                DataSource = localhost;";

        public CMKITSDROIDD()
        {
            sCadenaConexion = ConexionBD.ConexionString();
            kits = new List<CKITDROIDBE>();
        }

        public CMKITSDROIDD(string conexion)
        {
            sCadenaConexion = conexion;
            kits = new List<CKITDROIDBE>();
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

                CmdTxt = @"SELECT * FROM KITDEFINICION";

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    CKITDROIDBE kit = new CKITDROIDBE();

                    if (dr["PRODUCTOKITCLAVE"] != System.DBNull.Value)
                    {
                        kit.Producto= (string)(dr["PRODUCTOKITCLAVE"]);
                    }

                    if (dr["PRODUCTOPARTECLAVE"] != System.DBNull.Value)
                    {
                        kit.Parte = (string)(dr["PRODUCTOPARTECLAVE"]);

                    }

                    if (dr["CANTIDADPARTE"] != System.DBNull.Value)
                    {
                        try
                        {
                            kit.Cantidad = double.Parse(dr["CANTIDADPARTE"].ToString());
                        }
                        catch
                        {
                            kit.Cantidad = 0.00;
                        }
                    }


                    if (dr["COSTOPARTE"] != System.DBNull.Value)
                    {
                        try
                        {
                            kit.Costo = double.Parse(dr["COSTOPARTE"].ToString());
                        }
                        catch
                        {
                            kit.Costo = 0.00;
                        }
                    }

                    kits.Add(kit);
                }
                return true;
            }
            catch (Exception e)
            {
                iComentario = e.Message + e.StackTrace;
                return false;
            }
            finally
            {
                SqlHelper.CloseReader(dr, pcn);
            }
        }

        public bool LimpiarTabla(FbTransaction st)
        {
            try
            {
                sCadenaConexion = conexion;
                ArrayList parts = new ArrayList();

                string commandText = @"DELETE FROM MKITSDROID;";
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

        public bool InsertarKit(CKITDROIDBE kit, FbTransaction st)
        {
            try
            {
                sCadenaConexion = conexion;
                ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@PRODUCTO", FbDbType.VarChar);
                auxPar.Value = kit.Producto;
                parts.Add(auxPar);

                auxPar = new FbParameter("@PARTE", FbDbType.VarChar);
                auxPar.Value = kit.Parte;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                auxPar.Value = kit.Cantidad;
                parts.Add(auxPar);

                auxPar = new FbParameter("@COSTO", FbDbType.Numeric);
                auxPar.Value = kit.Costo;
                parts.Add(auxPar);

                string commandText = @"INSERT INTO MKITSDROID(
                                            PRODUCTO,
                                            PARTE,
                                            CANTIDAD,
                                            COSTO
                                       )
                                       Values(
                                            @PRODUCTO,
                                            @PARTE,
                                            @CANTIDAD,
                                            @COSTO
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

                foreach (CKITDROIDBE kit in kits)
                {
                    if (!InsertarKit(kit, fbTransaction))
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
