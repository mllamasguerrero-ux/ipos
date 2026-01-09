using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Collections;
using ConexionesBD;
namespace iPosData
{
    public class CComprasD
    {

        #region Class Variables and objects
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

        #endregion

        #region Funciones para obtener datos de la base de datos

        public CPRODUCTOBE buscarPRODUCTOSPV(string producto, CPARAMETROBE parametro, FbTransaction st)
        {

            CPRODUCTOD productoD = new CPRODUCTOD();           
            CPRODUCTOBE retorno = new CPRODUCTOBE();
            decimal cantidadAux = 1;
            bool bPreguntaCantidad = false;

            bool esEmpaque = false;
            bool esCaja = false;
            bool tienePrefijoBascula = false;

            retorno = productoD.buscarPRODUCTOSLineaComando(producto, ref cantidadAux, ref bPreguntaCantidad, parametro, ref  esEmpaque, ref  esCaja, ref tienePrefijoBascula, st);
            this.IComentario = productoD.IComentario;
            return retorno;
        }




        public CPRODUCTOBE buscarPRODUCTOSPV(string producto, CPARAMETROBE parametro, ref bool esEmpaque, ref bool esCaja, FbTransaction st)
        {

            CPRODUCTOD productoD = new CPRODUCTOD();
            CPRODUCTOBE retorno = new CPRODUCTOBE();
            decimal cantidadAux = 1;
            bool bPreguntaCantidad = false;
            bool tienePrefijoBascula = false;

            retorno = productoD.buscarPRODUCTOSLineaComando(producto, ref cantidadAux, ref bPreguntaCantidad, parametro, ref  esEmpaque, ref  esCaja, ref tienePrefijoBascula, st);
            this.IComentario = productoD.IComentario;
            return retorno;
        }



        public CDOCTOBE ObtenerTransaccion(CDOCTOBE doctoBE, FbTransaction st)
        {
            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoRetorno = new CDOCTOBE();
            doctoRetorno = doctoD.seleccionarDOCTO(doctoBE, st);
            if (doctoRetorno == null)
                this.IComentario = doctoD.IComentario;

            return doctoRetorno;

        }


        public CCAJABE ObtenerDatosCaja(long cajaId)
        {
            CCAJAD cajaD = new CCAJAD();
            CCAJABE cajaBE = new CCAJABE();

            cajaBE.IID = cajaId;

            cajaBE = cajaD.seleccionarCAJA(cajaBE, null);

            if (cajaBE == null)
                this.IComentario = cajaD.IComentario;

            return cajaBE;
        }




        public bool GetExistencia(CPRODUCTOBE productBE, ref int reg_count, ref decimal cantidad, ref string lote, ref DateTime fechaVence, long? almacenId, FbTransaction st)
        {

            CPRODUCTOD productoD = new CPRODUCTOD();
            bool retorno;
            retorno = productoD.GetExistencia(productBE, ref  reg_count, ref  cantidad, ref  lote, ref fechaVence, almacenId,  st);
            return retorno;
        }

        #endregion

        #region Validacion


        public bool HayCorteActivo(ref DateTime fechaCorte, long cajeroId)
        {
            CCORTED corteD = new CCORTED();
            CCORTEBE corteBE = new CCORTEBE();
            return corteD.HayCorteActivo(cajeroId, null, ref fechaCorte);
        }



        public bool ValidarFechaSistema(FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"VALIDAR_FECHASISTEMA";

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

                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.sCadenaConexion, st);
                        this.iComentario = "ERROR : " + strMensajeErr;
                        return false;
                    }
                }

                return true;




            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        #endregion


        #region Operaciones

        #region Cancelaciones
        public bool CancelarTransaccion(CDOCTOBE cDocto, long vendedorId, FbTransaction st)
        {
            this.IComentario = "";
            try
            {
                this.IComentario = "";
                CDOCTOD doctoD = new CDOCTOD();
                CDOCTOBE doctoBE = new CDOCTOBE();
                bool iResult;


                doctoBE.IID = cDocto.IID;
                ObtenerTransaccion(doctoBE,st);

                if (cDocto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR)
                    iResult = doctoD.BorrarDOCTOD(doctoBE, st);
                else
                    iResult = doctoD.CancelarDOCTOD(doctoBE, vendedorId, st);
                    
                if (!iResult)
                {
                    this.IComentario = doctoD.IComentario;
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool CancelarCompra(CDOCTOBE cDocto, CPERSONABE userBE, FbTransaction st)
        {
            this.IComentario = "";
            bool retorno = false;

            FbConnection fConn = null;
            FbTransaction fTrans = st;


            if (st == null)
            {
                fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            }


            fConn.Close();


            try
            {
                if (st == null)
                {

                    fConn.Open();
                    fTrans = fConn.BeginTransaction();
                }

                this.IComentario = "";
                CDOCTOD doctoD = new CDOCTOD();
                CDOCTOBE doctoBE = new CDOCTOBE();
                bool iResult;


                doctoBE.IID = cDocto.IID;


                ObtenerTransaccion(doctoBE, st);

                if (cDocto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR)
                    iResult = doctoD.BorrarDOCTOD(doctoBE, st);
                else
                    iResult = doctoD.CancelarCompraD(doctoBE, userBE, fTrans);

                if (!iResult)
                {
                    this.IComentario = doctoD.IComentario;
                    fTrans.Rollback();
                    //fTrans.Commit();
                    retorno = false;
                }
                else
                {
                    fTrans.Commit();
                    retorno = true;
                }
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                retorno = false;


                fTrans.Rollback();
            }
            finally
            {
                if (fConn != null)
                {
                    fConn.Close();
                }
            }
            return retorno;
        }

        #endregion

        #region Pagar/Cerrar 
        public bool CerrarTransaccion(CDOCTOBE docto, FbTransaction st)
        {
            CDOCTOD doctoD = new CDOCTOD();
            if (!doctoD.CerrarDOCTOD(docto,st))
            {
                this.IComentario = doctoD.IComentario;
                return false;
            }
            else
            {
                return true;
            }
        }


        public bool CerrarTransaccionOrdenDeCompra(CDOCTOBE docto, FbTransaction st)
        {
            CDOCTOD doctoD = new CDOCTOD();
            if (!doctoD.CerrarOrdenDeCompraDOCTOD(docto, st))
            {
                this.IComentario = doctoD.IComentario;
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region LInea de comando

        public bool EjecutarAddMOVTO(       ref long?         P_IDDOCTO,
                                                decimal?      P_CANTIDAD,
                                                long?         P_IDPRODUCTO,
                                                long?         P_PERSONAID,
                                                long?          P_USERID,
                                                string        P_LOTE,
                                                int?          US_SUPERVISOR,
                                                int?          ALMACENID,
                                                long?         SUCURSALID,
                                                DateTime      P_FECHAVENCE,
                                                long          P_TIPO_DOCTO,
                                                long?         P_SUCURSALTID,
                                                long?         P_ALMACENTID,
                                                string        P_PROMOCION,
                                                long? P_TIPODIFERENCIAINVENTARIOID,
                                                decimal? P_COSTO,
                                                string        P_REFERENCIA,
                                                string        P_REFERENCIAS,
                                                DateTime      P_DOCTO_FECHA,
                                                DateTime      P_DOCTO_FECHAVENCE,
                                                decimal? P_DESCUENTO,
                                                long P_CAJAID,
                                                long? P_DOCTOREFID,
                                                ref long? P_MOVTOID,
                                                long? P_MOVTOREFID,
                                                long? P_LOTEIMPORTADO,
                                                string P_DESCRIPCION1,
                                                string P_DESCRIPCION2,
                                                string P_DESCRIPCION3,
                                                FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
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
                if (P_PERSONAID.HasValue)
                {
                    auxPar.Value = P_PERSONAID;
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
                auxPar.Value = P_CAJAID;
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
                if(P_FECHAVENCE > DateTime.MinValue)
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
                    auxPar.Value = 1;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADSURTIDA", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
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


                //auxPar = new FbParameter("@PRECIO", FbDbType.Numeric);
                //auxPar.Value = System.DBNull.Value;
                auxPar = new FbParameter("@PRECIO", FbDbType.Numeric);
                /*if (P_COSTO.HasValue)
                {
                    auxPar.Value = P_COSTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }*/
                auxPar.Value = -0.02;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUSMOVTOID", FbDbType.BigInt);
                auxPar.Value = (long)DBValues._MOVTO_ESTATUS_BORRADOR;
                parts.Add(auxPar);



                auxPar = new FbParameter("@REFERENCIA", FbDbType.VarChar);
                if(P_REFERENCIA != "")
                    auxPar.Value = P_REFERENCIA;
                else
                    auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIAS", FbDbType.VarChar);
                if (P_REFERENCIAS != "")
                    auxPar.Value = P_REFERENCIAS;
                else
                    auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTO", FbDbType.Numeric);
                if (P_COSTO.HasValue)
                {
                    auxPar.Value = P_COSTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
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
                    parts.Add(auxPar);
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
                if (P_DOCTO_FECHA > DateTime.MinValue)
                    auxPar.Value = P_DOCTO_FECHA;
                else
                    auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENCE", FbDbType.Date);
                if (P_DOCTO_FECHAVENCE > DateTime.MinValue)
                    auxPar.Value = P_DOCTO_FECHAVENCE;
                else
                    auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);



                auxPar = new FbParameter("@PORCENTAJEDESCUENTO", FbDbType.Numeric);

                if (P_DESCUENTO.HasValue)
                {
                    auxPar.Value = P_DESCUENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOREFID", FbDbType.BigInt);
                if (P_DOCTOREFID.HasValue)
                {
                    auxPar.Value = P_DOCTOREFID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ANAQUELID", FbDbType.BigInt);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);

                
                auxPar = new FbParameter("@LOCALIDAD", FbDbType.VarChar);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@P_MOVTOID", FbDbType.BigInt);
                if (P_MOVTOID.HasValue)
                {
                    auxPar.Value = P_MOVTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@P_MOVTOREFID", FbDbType.BigInt);
                if (P_MOVTOREFID.HasValue)
                {
                    auxPar.Value = P_MOVTOREFID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION1", FbDbType.VarChar);
                if (P_DESCRIPCION1 != null && P_DESCRIPCION1 != "")
                {
                    auxPar.Value = P_DESCRIPCION1.Trim();
                }
                else
                {
                    auxPar.Value = ""; ;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION2", FbDbType.VarChar);
                if (P_DESCRIPCION2 != null && P_DESCRIPCION2 != "")
                {
                    auxPar.Value = P_DESCRIPCION2.Trim();
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DESCRIPCION3", FbDbType.VarChar);
                if (P_DESCRIPCION3 != null && P_DESCRIPCION3 != "")
                {
                    auxPar.Value = P_DESCRIPCION3.Trim();
                }
                else
                {
                    auxPar.Value = "";
                }
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
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);

                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.sCadenaConexion, st);
                        this.iComentario = "ERROR : " + strMensajeErr;
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    P_MOVTOID = (long)arParms[arParms.Length - 2].Value;
                    
                }

                P_IDDOCTO = (long)arParms[arParms.Length - 3].Value;
                return true;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        #endregion

        #region Eliminar Detalle
        public bool BorrarMOVTOVENTAS(CMOVTOBE oCMOVTO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@MOVTOID", FbDbType.BigInt);
                auxPar.Value = oCMOVTO.IID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESPROMOCION", FbDbType.Char);
                auxPar.Value = "N";
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"MOVTO_DELETE";

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
                        this.iComentario = "Hubo un error";
                        return false;
                    }
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }
        #endregion

        #endregion






        public bool COMPRA_PRECIERRE(CDOCTOBE doctoBE, FbTransaction st, ref int errorCode)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoBE.IID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ORIGENFISCALID", FbDbType.BigInt);
                auxPar.Value = doctoBE.IORIGENFISCALID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENCE", FbDbType.Date);
                auxPar.Value = doctoBE.IVENCE;
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIA", FbDbType.VarChar);        
                if(!(bool)doctoBE.isnull["IREFERENCIA"])
                    auxPar.Value = doctoBE.IREFERENCIA;
                else
                    auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIAS", FbDbType.VarChar);
                if (!(bool)doctoBE.isnull["IREFERENCIAS"])
                    auxPar.Value = doctoBE.IREFERENCIAS;
                else
                    auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAFACTURA", FbDbType.Date);
                if (!(bool)doctoBE.isnull["IFECHAFACTURA"])
                    auxPar.Value = doctoBE.IFECHAFACTURA;
                else
                    auxPar.Value = DateTime.Today;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"COMPRA_PRECIERRE";

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
                        errorCode = (int)arParms[arParms.Length - 1].Value;

                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)errorCode, this.sCadenaConexion, st);
                        this.iComentario = "ERROR : " + strMensajeErr;
                        return false;
                    }
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }





        public bool CancelarCompraDevolucion(CDOCTOBE cDocto, CPERSONABE userBE, ref long doctoIDCancelacion, FbTransaction st)
        {
            this.IComentario = "";
            try
            {
                this.IComentario = "";
                CDOCTOD doctoD = new CDOCTOD();
                CDOCTOBE doctoBE = new CDOCTOBE();
                bool iResult;


                doctoBE.IID = cDocto.IID;
                ObtenerTransaccion(doctoBE, st);

                if (cDocto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR)
                    iResult = doctoD.BorrarDOCTOD(doctoBE, st);
                else
                    iResult = doctoD.CancelarCompraDevolucionD(doctoBE, userBE,ref doctoIDCancelacion, st);

                if (!iResult)
                {
                    this.IComentario = doctoD.IComentario;
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool EditarCompraDevolucion(CDOCTOBE cDocto, CPERSONABE userBE, ref long doctoIDEdicion, long vendedorId, FbTransaction st)
        {
            this.IComentario = "";
            try
            {
                this.IComentario = "";
                CDOCTOD doctoD = new CDOCTOD();
                CDOCTOBE doctoBE = new CDOCTOBE();
                bool iResult;


                doctoBE.IID = cDocto.IID;
                ObtenerTransaccion(doctoBE, st);

                iResult = doctoD.EditarCompraDevolucionD(doctoBE, userBE, ref doctoIDEdicion, vendedorId, st);

                if (!iResult)
                {
                    this.IComentario = doctoD.IComentario;
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }






        public bool COMPRA_REASIGNAR_PROVEE(long doctoId, long proveedorId, long usuarioId, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PROVEEDORID", FbDbType.BigInt);
                auxPar.Value = proveedorId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.Date);
                auxPar.Value = usuarioId;
                parts.Add(auxPar);

                

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"COMPRA_REASIGNAR_PROVEE";

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

                        string strMensajeErr = " Al cambiar de proveedor : " + ((int)arParms[arParms.Length - 1].Value).ToString();//CERRORCODED.ObtenerMensajeError((long)errorCode, this.sCadenaConexion, st);
                        this.iComentario = "ERROR : " + strMensajeErr;
                        return false;
                    }
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }





        public bool COMPRA_REASIGNAR_DATOS(long doctoId, long proveedorId, long usuarioId,
                                           long origenFiscalId, DateTime fechaFactura, string referencia, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PROVEEDORID", FbDbType.BigInt);
                auxPar.Value = proveedorId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = usuarioId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ORIGENFISCALID", FbDbType.BigInt);
                auxPar.Value = origenFiscalId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAFACTURA", FbDbType.Date);
                auxPar.Value = fechaFactura;
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIA", FbDbType.VarChar);
                auxPar.Value = referencia;
                parts.Add(auxPar);

                


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"COMPRA_REASIGNAR_DATOS";

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

                        string strMensajeErr = " Al cambiar de proveedor : " + ((int)arParms[arParms.Length - 1].Value).ToString();//CERRORCODED.ObtenerMensajeError((long)errorCode, this.sCadenaConexion, st);
                        this.iComentario = "ERROR : " + strMensajeErr;
                        return false;
                    }
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public CComprasD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
        }







    }
}
