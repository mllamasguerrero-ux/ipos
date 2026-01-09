using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Collections;
using ConexionesBD;
using System.Collections.Generic;

namespace iPosData
{
    public class CINVENTARIOD
    {

        private string sCadenaConexion;

        private string iComentario;
        public string IComentario
        {
            get
            {
                return this.iComentario;
            }
            set
            {
                this.iComentario = value;
            }
        }

        protected string iComentarioAdicional;
        public string IComentarioAdicional
        {
            get
            {
                return this.iComentarioAdicional;
            }
            set
            {
                this.iComentarioAdicional = value;
            }
        }

        public bool PRODUCTO_CAMBIOMANEJALOTE(long lProductoId, string sNuevoManejaLote, long cajeroId, ref long lDoctoRefId, FbTransaction st)
        {

            try
            {
                ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                auxPar.Value = lProductoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUEVOMANEJALOTE", FbDbType.VarChar);
                auxPar.Value = sNuevoManejaLote;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAJEROID", FbDbType.BigInt);
                auxPar.Value = cajeroId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOREFERENCIAID", FbDbType.BigInt);
                auxPar.Value = lDoctoRefId;
                parts.Add(auxPar);




                auxPar = new FbParameter("@DOCTOREFERENCIAIDRET", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"PRODUCTO_CAMBIOMANEJALOTE";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);






                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {

                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.sCadenaConexion, null);
                        this.iComentario = ("Hubo un error : " + strMensajeErr);
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                     lDoctoRefId = (long)arParms[arParms.Length - 2].Value ;
                    
                }


                return true;

            }
            catch (Exception e)
            {
                this.iComentario = (e.Message + e.StackTrace);
                return false;
            }

        }




        public bool INVFIS_UNICOLOTE_APLICARSALIDAS(long lDoctoID, FbTransaction st)
        {

            try
            {
                ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOREFERENCIAID", FbDbType.BigInt);
                auxPar.Value = lDoctoID;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"INVFIS_UNICOLOTE_APLICARSALIDAS";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);



                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {

                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.sCadenaConexion, null);
                        this.iComentario = ("Hubo un error : " + strMensajeErr);
                        return false;
                    }
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = (e.Message + e.StackTrace);
                return false;
            }

        }




        public bool INVFIS_UNICOLOTE_APLICARENTRADAS(long lDoctoID, FbTransaction st)
        {

            try
            {
                ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOREFERENCIAID", FbDbType.BigInt);
                auxPar.Value = lDoctoID;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"INVFIS_UNICOLOTE_APLICARENTRADA";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);



                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {

                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.sCadenaConexion, null);
                        this.iComentario = ("Hubo un error : " + strMensajeErr);
                        return false;
                    }
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = (e.Message + e.StackTrace);
                return false;
            }

        }


        public List<CINVMOVPRODUCTOSUCURSALBE> getProductsInv(string sucursal, FbTransaction st)
        {
            List<CINVMOVPRODUCTOSUCURSALBE> retorno = new List<CINVMOVPRODUCTOSUCURSALBE>();
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"SELECT 
                            PRODUCTO.CLAVE, PRODUCTO.NOMBRE, PRODUCTO.DESCRIPCION, PRODUCTO.DESCRIPCION1, PRODUCTO.DESCRIPCION2, 
                            PRODUCTO.EXISTENCIA,
                            PRODUCTO.INVENTARIABLE, PRODUCTO.MANEJALOTE, PRODUCTO.UNIDAD, COALESCE(PRODUCTO.EXISTENCIAAPARTADO,0) EXISTENCIAAPARTADO,
                            LINEA.CLAVE LINEACLAVE, (LINEA.NOMBRE  || ' ||' || PRODUCTO.CBARRAS)   LINEANOMBRE,
                            MARCA.CLAVE MARCACLAVE, MARCA.NOMBRE MARCANOMBRE,
                            PRODUCTO.EAN, PRODUCTO.PZACAJA

                            FROM PRODUCTO
                            LEFT JOIN LINEA ON LINEA.ID = PRODUCTO.LINEAID
                            LEFT JOIN MARCA ON MARCA.ID = PRODUCTO.MARCAID

                            WHERE PRODUCTO.INVENTARIABLE = 'S'

                            ";


                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);



                while (dr.Read())
                {
                    CINVMOVPRODUCTOSUCURSALBE auxProdInv = new CINVMOVPRODUCTOSUCURSALBE();

                    if (dr["Clave"] != System.DBNull.Value)
                    {
                        auxProdInv.ICLAVE = (string)(dr["Clave"]);
                    }

                    if (dr["Nombre"] != System.DBNull.Value)
                    {
                        auxProdInv.INOMBRE = (string)(dr["Nombre"]);
                    }

                    if (dr["Descripcion"] != System.DBNull.Value)
                    {
                        auxProdInv.IDESCRIPCION = (string)(dr["Descripcion"]);
                    }

                    if (dr["Descripcion1"] != System.DBNull.Value)
                    {
                        auxProdInv.IDESCRIPCION1 = (string)(dr["Descripcion1"]);
                    }

                    if (dr["Descripcion2"] != System.DBNull.Value)
                    {
                        auxProdInv.IDESCRIPCION2 = (string)(dr["Descripcion2"]);
                    }

                    if (dr["Existencia"] != System.DBNull.Value)
                    {
                        auxProdInv.IEXISTENCIA = (decimal)(dr["Existencia"]);
                    }

                    if (dr["Inventariable"] != System.DBNull.Value)
                    {
                        auxProdInv.IINVENTARIABLE = (string)(dr["Inventariable"]);
                    }

                    if (dr["ManejaLote"] != System.DBNull.Value)
                    {
                        auxProdInv.IMANEJALOTE = (string)(dr["ManejaLote"]);
                    }

                    if (dr["Unidad"] != System.DBNull.Value)
                    {
                        auxProdInv.IUNIDAD = (string)(dr["Unidad"]);
                    }


                    if (dr["ExistenciaApartado"] != System.DBNull.Value)
                    {
                        auxProdInv.IEXISTENCIAAPARTADO = (decimal)(dr["ExistenciaApartado"]);
                    }


                    if (dr["LineaClave"] != System.DBNull.Value)
                    {
                        auxProdInv.ILINEACLAVE = (string)(dr["LineaClave"]);
                    }

                    if (dr["LineaNombre"] != System.DBNull.Value)
                    {
                        auxProdInv.ILINEANOMBRE = (string)(dr["LineaNombre"]);
                    }

                    if (dr["MarcaClave"] != System.DBNull.Value)
                    {
                        auxProdInv.IMARCACLAVE = (string)(dr["MarcaClave"]);
                    }


                    if (dr["MarcaNombre"] != System.DBNull.Value)
                    {
                        auxProdInv.IMARCANOMBRE = (string)(dr["MarcaNombre"]);
                    }

                    if (dr["Ean"] != System.DBNull.Value)
                    {
                        auxProdInv.IEAN = (string)(dr["Ean"]);
                    }


                    if (dr["PZACAJA"] != System.DBNull.Value)
                    {
                        auxProdInv.IPZACAJA = (decimal)(dr["PZACAJA"]);
                    }

                    if (sucursal != null && sucursal != "")
                    {
                        auxProdInv.ISUCURSALCLAVE = sucursal;
                    }

                    retorno.Add(auxProdInv);
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }

        public List<CINVMOVALMACENSUCURSALBE> getAlmacenInv(string sucursal, FbTransaction st)
        {
            List<CINVMOVALMACENSUCURSALBE> retorno = new List<CINVMOVALMACENSUCURSALBE>();
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"SELECT ALMACEN.ID ALMACENID, ALMACEN.CLAVE, ALMACEN.NOMBRE
                            FROM ALMACEN
                            ";


                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);



                while (dr.Read())
                {
                    CINVMOVALMACENSUCURSALBE auxAlmacenInv = new CINVMOVALMACENSUCURSALBE();

                    if (dr["ALMACENID"] != System.DBNull.Value)
                    {
                        auxAlmacenInv.IID = (long)(dr["ALMACENID"]);
                    }

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        auxAlmacenInv.ICLAVE = (string)(dr["CLAVE"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        auxAlmacenInv.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (sucursal != null && sucursal != "")
                    {
                        auxAlmacenInv.ISUCURSALCLAVE = sucursal;
                    }

                    retorno.Add(auxAlmacenInv);
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public List<CINVMOVINVENTARIOSSUCURSALBE> getInventario(string sucursal, FbTransaction st)
        {
            List<CINVMOVINVENTARIOSSUCURSALBE> retorno = new List<CINVMOVINVENTARIOSSUCURSALBE>();
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"SELECT 

                                coalesce(ALMACEN.CLAVE,'TIENDA') ALMACENCLAVE,
                                PRODUCTO.CLAVE,
                                INVENTARIO.LOTE,
                                INVENTARIO.FECHAVENCE,
                                SUM(COALESCE(INVENTARIO.CANTIDAD,0)) CANTIDAD

                                FROM INVENTARIO
                                INNER JOIN PRODUCTO ON PRODUCTO.ID = INVENTARIO.PRODUCTOID
                                LEFT JOIN ALMACEN ON ALMACEN.ID = INVENTARIO.ALMACENID
                                GROUP BY INVENTARIO.ALMACENID, ALMACEN.CLAVE,  INVENTARIO.PRODUCTOID, PRODUCTO.CLAVE, INVENTARIO.LOTE, INVENTARIO.FECHAVENCE


                            ";



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);



                while (dr.Read())
                {
                    CINVMOVINVENTARIOSSUCURSALBE auxInv = new CINVMOVINVENTARIOSSUCURSALBE();

                    if (dr["ALMACENCLAVE"] != System.DBNull.Value)
                    {
                        auxInv.IALMACENCLAVE = (string)(dr["ALMACENCLAVE"]);
                    }

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        auxInv.ICLAVE = (string)(dr["CLAVE"]);
                    }

                    if (dr["LOTE"] != System.DBNull.Value)
                    {
                        auxInv.ILOTE = (string)(dr["LOTE"]);
                    }

                    if (dr["FECHAVENCE"] != System.DBNull.Value)
                    {
                        auxInv.IFECHAVENCE = (DateTime)dr["FECHAVENCE"];
                    }

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        auxInv.ICANTIDAD = (decimal)dr["CANTIDAD"];
                    }

                    if (sucursal != null && sucursal != "")
                    {
                        auxInv.ISUCURSALCLAVE = sucursal;
                    }

                    retorno.Add(auxInv);
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }




        public List<CINVMOVPRODLOCATIONBE> getProdLocation(string sucursal, FbTransaction st)
        {
            List<CINVMOVPRODLOCATIONBE> retorno = new List<CINVMOVPRODLOCATIONBE>();
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"SELECT

    SUCURSAL.CLAVE SUCURSALCLAVE      ,
    ALMACEN.CLAVE ALMACENCLAVE       ,
    PRODUCTOLOCATIONS.ANAQUEL            ,
    PRODUCTOLOCATIONS.LOCALIDAD          ,
    PRODUCTO.CLAVE PRODUCTOCLAVE

    FROM PRODUCTOLOCATIONS
    left join parametro on 1 = 1
    left join sucursal on sucursal.id = parametro.sucursalid
    LEFT JOIN ALMACEN ON ALMACEN.ID = COALESCE(PRODUCTOLOCATIONS.ALMACENID,1)
    LEFT JOIN PRODUCTO ON PRODUCTO.ID = PRODUCTOLOCATIONS.PRODUCTOID
    WHERE PRODUCTOLOCATIONS.ACTIVO = 'S'
                            ";



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);



                while (dr.Read())
                {
                    CINVMOVPRODLOCATIONBE auxInv = new CINVMOVPRODLOCATIONBE();





                    if (sucursal != null && sucursal != "")
                    {
                        auxInv.ISUCURSALCLAVE = sucursal;
                    }

                    if (dr["ALMACENCLAVE"] != System.DBNull.Value)
                    {
                        auxInv.IALMACENCLAVE = (string)(dr["ALMACENCLAVE"]);
                    }
                    if (dr["ANAQUEL"] != System.DBNull.Value)
                    {
                        auxInv.IANAQUEL = (string)(dr["ANAQUEL"]);
                    }

                    if (dr["LOCALIDAD"] != System.DBNull.Value)
                    {
                        auxInv.ILOCALIDAD = (string)(dr["LOCALIDAD"]);
                    }
                    if (dr["PRODUCTOCLAVE"] != System.DBNull.Value)
                    {
                        auxInv.IPRODUCTOCLAVE = (string)(dr["PRODUCTOCLAVE"]);
                    }

                    retorno.Add(auxInv);
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }



        public List<Usuario> getUsuariosInv(string sucursal, FbTransaction st)
        {
            List<Usuario> retorno = new List<Usuario>();
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"SELECT P.USERNAME, P.CLAVEACCESO FROM PERSONA  P
LEFT JOIN usuario_perfil UP ON UP.up_personaid =  P.ID
LEFT JOIN PERFIL_DER PD ON PD.pd_perfil = UP.up_perfil
WHERE TIPOPERSONAID = 20  AND PD.pd_derecho = 220
GROUP BY  P.USERNAME, P.CLAVEACCESO ";



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);



                while (dr.Read())
                {
                    Usuario auxUser = new Usuario();

                    if (dr["USERNAME"] != System.DBNull.Value)
                    {
                        auxUser.UserName = (string)(dr["USERNAME"]);
                    }

                    if (dr["CLAVEACCESO"] != System.DBNull.Value)
                    {
                        auxUser.Password = (string)(dr["CLAVEACCESO"]);
                    }


                    if (sucursal != null && sucursal != "")
                    {
                        auxUser.SucursalClave = sucursal;
                    }

                    retorno.Add(auxUser);
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }

        public List<CSUCURSALINVBE> getSucursalesInv(FbTransaction st)
        {
            List<CSUCURSALINVBE> retorno = new List<CSUCURSALINVBE>();
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"SELECT 

                                CLAVE, NOMBRE

                                FROM SUCURSAL
                            ";



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);



                while (dr.Read())
                {
                    CSUCURSALINVBE auxInv = new CSUCURSALINVBE();

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        auxInv.Clave = (string)(dr["CLAVE"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        auxInv.Nombre = (string)(dr["NOMBRE"]);
                    }

                    retorno.Add(auxInv);
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }

        public bool EjecutarAddMOVTO(ref long? P_IDDOCTO,
                                       decimal? P_CANTIDAD,
                                       long? P_IDPRODUCTO,
                                       string P_VD_VENDEDOR,
                                       long? P_USERID,
                                       string P_LOTE,
                                       int? US_SUPERVISOR,
                                       int? ALMACENID,
                                       long? SUCURSALID,
                                       DateTime P_FECHAVENCE,
                                       long P_TIPO_DOCTO,
                                       long? P_SUCURSALTID,
                                       long? P_ALMACENTID,
                                       string P_PROMOCION,
                                       long? P_TIPODIFERENCIAINVENTARIOID,
                                       decimal? P_CANTIDAD_SURTIDA,
                                       long? P_LOTEIMPORTADO,
                                       string referencia,
                                       ref string refMessage,
                                       long caja,
                                       FbTransaction st)
        {
            try
            {
                ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@DOCTOACTUALID", FbDbType.BigInt);
                if (P_IDDOCTO.HasValue)
                {
                    auxPar.Value = (long)P_IDDOCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (P_USERID.HasValue)
                {
                    auxPar.Value = (long)P_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ALMACENID", FbDbType.BigInt);
                if (ALMACENID.HasValue)
                {
                    auxPar.Value = (long)ALMACENID;
                }
                else
                {
                    parts.Add(auxPar);
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (SUCURSALID.HasValue)
                {
                    auxPar.Value = (long)SUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPODOCTOID", FbDbType.BigInt);
                auxPar.Value = P_TIPO_DOCTO;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUSDOCTOID", FbDbType.BigInt);
                auxPar.Value = DBValues._DOCTO_ESTATUS_BORRADOR;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUSDOCTOPAGOID", FbDbType.BigInt);
                auxPar.Value = DBValues._DOCTO_ESTATUS_PAGO_BORRADOR;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (P_USERID.HasValue)
                {
                    auxPar.Value = P_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                if (P_USERID.HasValue)
                {
                    auxPar.Value = (long)P_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAJAID", FbDbType.BigInt);
                auxPar.Value = //iPos.CurrentUserID.CurrentCompania.IEM_CAJA;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PARTIDA", FbDbType.SmallInt);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (P_IDPRODUCTO.HasValue)
                {
                    auxPar.Value = (long)P_IDPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOTE", FbDbType.VarChar);
                if (P_LOTE != null && P_LOTE != "")
                {
                    auxPar.Value = P_LOTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAVENCE", FbDbType.Date);
                if (P_FECHAVENCE > DateTime.MinValue)
                    auxPar.Value = P_FECHAVENCE;
                else
                    auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                if (P_CANTIDAD.HasValue)
                {
                    auxPar.Value = (decimal)P_CANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADSURTIDA", FbDbType.Numeric);
                if (P_CANTIDAD_SURTIDA.HasValue)
                {
                    auxPar.Value = (decimal)P_CANTIDAD_SURTIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADFALTANTE", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADDEVUELTA", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADSALDO", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUSMOVTOID", FbDbType.BigInt);
                auxPar.Value = (long)DBValues._MOVTO_ESTATUS_BORRADOR;
                parts.Add(auxPar);



                auxPar = new FbParameter("@REFERENCIA", FbDbType.VarChar);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIAS", FbDbType.VarChar);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTO", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);





                auxPar = new FbParameter("@SUCURSALTID", FbDbType.BigInt);
                if (P_SUCURSALTID.HasValue)
                {
                    auxPar.Value = (long)P_SUCURSALTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@ALMACENTID", FbDbType.BigInt);
                if (P_ALMACENTID.HasValue)
                {
                    auxPar.Value = (long)P_ALMACENTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@PROMOCION", FbDbType.Char);
                auxPar.Value = P_PROMOCION;
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPODIFERENCIAINVENTARIOID", FbDbType.BigInt);
                if (P_TIPODIFERENCIAINVENTARIOID.HasValue)
                {
                    auxPar.Value = (long)P_TIPODIFERENCIAINVENTARIOID;
                }
                else
                {
                    parts.Add(auxPar);
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENCE", FbDbType.Date);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PORCENTAJEDESCUENTO", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOREFID", FbDbType.BigInt);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ANAQUELID", FbDbType.BigInt);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOCALIDAD", FbDbType.VarChar);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@P_MOVTOID", FbDbType.BigInt);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@P_MOVTOREFID", FbDbType.BigInt);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION1", FbDbType.VarChar);
                auxPar.Value = "";
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION2", FbDbType.VarChar);
                auxPar.Value = "";
                parts.Add(auxPar);



                auxPar = new FbParameter("@DESCRIPCION3", FbDbType.VarChar);
                auxPar.Value = "";
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIOYAVALIDADO", FbDbType.VarChar);
                auxPar.Value = "N";
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOTEIMPORTADO", FbDbType.BigInt);
                if (P_LOTEIMPORTADO.HasValue)
                {
                    auxPar.Value = (long)P_LOTEIMPORTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CARGOTARJPRECIOMANUAL", FbDbType.VarChar);
                auxPar.Value = "N";
                parts.Add(auxPar);

                auxPar = new FbParameter("@AGRUPAPORPARAMETRO", FbDbType.VarChar);
                auxPar.Value = "N";
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@MOVTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);





                string commandText = @"MOVTO_INSERT";
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    SqlHelper.ExecuteNonQuery(ConexionBD.ConexionString(), CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);

                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), ConexionBD.ConexionString(), st);
                        refMessage = "ERROR : " + strMensajeErr;
                        return false;
                    }
                }

                P_IDDOCTO = (long)arParms[arParms.Length - 3].Value;
                return true;
            }
            catch (Exception e)
            {
                //this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public bool EliminarBorradoresInventario(FbTransaction st)
        {

            try
            {
                ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"INVFIS_DEL_NOTERMINADOS";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                SqlHelper.ExecuteNonQuery(ConexionesBD.ConexionBD.ConexionString(), CommandType.StoredProcedure, commandText, arParms);


                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {

                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), ConexionesBD.ConexionBD.ConexionString(), null);
                        //MessageBox.Show("Hubo un error : " + strMensajeErr);
                        return false;
                    }
                }

                return true;

            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message + e.StackTrace);
                return false;
            }

        }

        public bool KITDEFUNNIVEL_REFRESH_SI_REQ(FbTransaction st)
        {

            try
            {
                ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"KITDEFUNNIVEL_REFRESH_SI_REQ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                SqlHelper.ExecuteNonQuery(ConexionesBD.ConexionBD.ConexionString(), CommandType.StoredProcedure, commandText, arParms);


                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {

                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), ConexionesBD.ConexionBD.ConexionString(), null);
                        //MessageBox.Show("Hubo un error : " + strMensajeErr);
                        return false;
                    }
                }

                return true;

            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message + e.StackTrace);
                return false;
            }

        }


        public CINVENTARIOD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }

    }
}
