

using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Collections;
using ConexionesBD;
using System.Data.Odbc;
using DataLayer;
using DataLayer.Utilerias.bussinesData;
using System.Collections.Generic;

namespace iPosData
{

    [Transaction(TransactionOption.Supported)]


    public class CDOCTOD
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


        [AutoComplete]
        public CDOCTOBE AgregarDOCTOD(CDOCTOBE oCDOCTO, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["IID"])
                {
                    auxPar.Value = oCDOCTO.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCDOCTO.isnull["IACTIVO"])
                {
                    auxPar.Value = oCDOCTO.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCDOCTO.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCDOCTO.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ALMACENID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["IALMACENID"])
                {
                    auxPar.Value = oCDOCTO.IALMACENID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["ISUCURSALID"])
                {
                    auxPar.Value = oCDOCTO.ISUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPODOCTOID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["ITIPODOCTOID"])
                {
                    auxPar.Value = oCDOCTO.ITIPODOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUSDOCTOID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["IESTATUSDOCTOID"])
                {
                    auxPar.Value = oCDOCTO.IESTATUSDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUSDOCTOPAGOID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["IESTATUSDOCTOPAGOID"])
                {
                    auxPar.Value = oCDOCTO.IESTATUSDOCTOPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCDOCTO.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAJEROID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["ICAJEROID"])
                {
                    auxPar.Value = oCDOCTO.ICAJEROID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["IVENDEDORID"])
                {
                    auxPar.Value = oCDOCTO.IVENDEDORID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["ICORTEID"])
                {
                    auxPar.Value = oCDOCTO.ICORTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCDOCTO.isnull["IFECHA"])
                {
                    auxPar.Value = oCDOCTO.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SERIE", FbDbType.VarChar);
                if (!(bool)oCDOCTO.isnull["ISERIE"])
                {
                    auxPar.Value = oCDOCTO.ISERIE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FOLIO", FbDbType.Integer);
                if (!(bool)oCDOCTO.isnull["IFOLIO"])
                {
                    auxPar.Value = oCDOCTO.IFOLIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PLAZO", FbDbType.SmallInt);
                if (!(bool)oCDOCTO.isnull["IPLAZO"])
                {
                    auxPar.Value = oCDOCTO.IPLAZO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENCE", FbDbType.Date);
                if (!(bool)oCDOCTO.isnull["IVENCE"])
                {
                    auxPar.Value = oCDOCTO.IVENCE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIA", FbDbType.VarChar);
                if (!(bool)oCDOCTO.isnull["IREFERENCIA"])
                {
                    auxPar.Value = oCDOCTO.IREFERENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIAS", FbDbType.VarChar);
                if (!(bool)oCDOCTO.isnull["IREFERENCIAS"])
                {
                    auxPar.Value = oCDOCTO.IREFERENCIAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCDOCTO.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCDOCTO.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@OBSERVACION", FbDbType.VarChar);
                if (!(bool)oCDOCTO.isnull["IOBSERVACION"])
                {
                    auxPar.Value = oCDOCTO.IOBSERVACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@OBSERVACIONES", FbDbType.Text);
                if (!(bool)oCDOCTO.isnull["IOBSERVACIONES"])
                {
                    auxPar.Value = oCDOCTO.IOBSERVACIONES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTE", FbDbType.Numeric);
                if (!(bool)oCDOCTO.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCDOCTO.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCUENTO", FbDbType.Numeric);
                if (!(bool)oCDOCTO.isnull["IDESCUENTO"])
                {
                    auxPar.Value = oCDOCTO.IDESCUENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUBTOTAL", FbDbType.Numeric);
                if (!(bool)oCDOCTO.isnull["ISUBTOTAL"])
                {
                    auxPar.Value = oCDOCTO.ISUBTOTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IVA", FbDbType.Numeric);
                if (!(bool)oCDOCTO.isnull["IIVA"])
                {
                    auxPar.Value = oCDOCTO.IIVA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TOTAL", FbDbType.Numeric);
                if (!(bool)oCDOCTO.isnull["ITOTAL"])
                {
                    auxPar.Value = oCDOCTO.ITOTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CARGO", FbDbType.Numeric);
                if (!(bool)oCDOCTO.isnull["ICARGO"])
                {
                    auxPar.Value = oCDOCTO.ICARGO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ABONO", FbDbType.Numeric);
                if (!(bool)oCDOCTO.isnull["IABONO"])
                {
                    auxPar.Value = oCDOCTO.IABONO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SALDO", FbDbType.Numeric);
                if (!(bool)oCDOCTO.isnull["ISALDO"])
                {
                    auxPar.Value = oCDOCTO.ISALDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAJAID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["ICAJAID"])
                {
                    auxPar.Value = oCDOCTO.ICAJAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO DOCTO
      (
    
ID,

ACTIVO,

CREADO,

CREADOPOR_USERID,

MODIFICADO,

MODIFICADOPOR_USERID,

ALMACENID,

SUCURSALID,

TIPODOCTOID,

ESTATUSDOCTOID,

ESTATUSDOCTOPAGOID,

PERSONAID,

CAJEROID,

VENDEDORID,

CORTEID,

FECHA,

FECHAHORA,

SERIE,

FOLIO,

PLAZO,

VENCE,

REFERENCIA,

REFERENCIAS,

DESCRIPCION,

OBSERVACION,

OBSERVACIONES,

IMPORTE,

DESCUENTO,

SUBTOTAL,

IVA,

TOTAL,

CARGO,

ABONO,

SALDO,

CAJAID
         )

Values (

@ID,

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@ALMACENID,

@SUCURSALID,

@TIPODOCTOID,

@ESTATUSDOCTOID,

@ESTATUSDOCTOPAGOID,

@PERSONAID,

@CAJEROID,

@VENDEDORID,

@CORTEID,

@FECHA,

@SERIE,

@FOLIO,

@PLAZO,

@VENCE,

@REFERENCIA,

@REFERENCIAS,

@DESCRIPCION,

@OBSERVACION,

@OBSERVACIONES,

@IMPORTE,

@DESCUENTO,

@SUBTOTAL,

@IVA,

@TOTAL,

@CARGO,

@ABONO,

@SALDO,

@CAJAID
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);

                return oCDOCTO;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarDOCTOD(CDOCTOBE oCDOCTO, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"DOCTO_DELETE";

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
                        this.iComentario = "Hubo un error " + ((int)arParms[arParms.Length - 1].Value).ToString() ;
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




        public bool IgnorarTrasladoDOCTOD(CDOCTOBE oCDOCTO, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"IGNORA_TRASLADO";

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


        public bool CancelarDOCTOD(CDOCTOBE oCDOCTO, long vendedorId, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOCANCELARID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = vendedorId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"DOCTO_CANCEL";

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




        public bool CancelarCompraD(CDOCTOBE oCDOCTO, CPERSONABE userBE, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOCANCELARID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = userBE.IID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"COMPRA_CANCEL";

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
                        this.iComentario = "Hubo un error " + strMensajeErr;
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



        public bool CancelarDevolucionD(CDOCTOBE oCDOCTO, CPERSONABE userBE, ref long doctoIdCancelacion, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOCANCELARID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = userBE.IID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"DEVOLUCION_CANCEL_INICIAR";

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
                        this.iComentario = "Hubo un error " + strMensajeErr;
                        return false;
                    }
                }
                
                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    doctoIdCancelacion = (long)arParms[arParms.Length - 2].Value;
                }



                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool EditarDevolucionD(CDOCTOBE oCDOCTO, CPERSONABE userBE, ref long doctoIdEdicion, long vendedorId, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOEDITARID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = vendedorId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"DEVOLUCION_EDIT_INICIAR";

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

                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    doctoIdEdicion = (long)arParms[arParms.Length - 2].Value;
                }



                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool CancelarApartadoD(CDOCTOBE oCDOCTO, CPERSONABE userBE, ref long doctoIdCancelacion, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOCANCELARID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = userBE.IID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"APARTADA_CANCEL_INICIAR";

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

                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    doctoIdCancelacion = (long)arParms[arParms.Length - 2].Value;
                }



                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool CancelarTraspasoAlmacenD(CDOCTOBE oCDOCTO,  FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOCANCELARID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"TRASPASOALMACEN_CANCEL";

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




        public bool EditarApartadoD(CDOCTOBE oCDOCTO, CPERSONABE userBE, ref long doctoIdEdicion, long vendedorId, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOEDITARID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = vendedorId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"APARTADA_EDIT_INICIAR";

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

                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    doctoIdEdicion = (long)arParms[arParms.Length - 2].Value;
                }



                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool CancelarCompraDevolucionD(CDOCTOBE oCDOCTO, CPERSONABE userBE, ref long doctoIdCancelacion, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOCANCELARID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = userBE.IID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"COMPRADEVO_CANCEL_INICIAR";

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

                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    doctoIdCancelacion = (long)arParms[arParms.Length - 2].Value;
                }



                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool EditarCompraDevolucionD(CDOCTOBE oCDOCTO, CPERSONABE userBE, ref long doctoIdEdicion, long vendedorId, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOEDITARID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = vendedorId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"COMPRADEVO_EDIT_INICIAR";

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

                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    doctoIdEdicion = (long)arParms[arParms.Length - 2].Value;
                }



                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        


        public bool CancelarVentaD(CDOCTOBE oCDOCTO, CPERSONABE userBE, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOCANCELARID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = userBE.IID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"VENTA_CANCEL";

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

                        long errorCode = (long)((int)arParms[arParms.Length - 1].Value);
                        string strMensajeErr = "";

                        if (errorCode == DBValues._ERRORCODE_NOPUEDECANCELARSEPORPAGOSTIMBRADOS)
                        {
                            strMensajeErr = "Hay pagos timbrados que necesitan cancelarse. Vaya a Operaciones->Clientes->Abonos de cliente y cancele los pagos que no esten aun cancelados y tienen folio sat ";
                        }
                        else
                        {
                            strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.sCadenaConexion, null);

                        }



                        this.iComentario = "Hubo un error " + strMensajeErr;
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



        public bool PreCancelarVentaD(CDOCTOBE oCDOCTO, CPERSONABE userBE, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOCANCELARID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = userBE.IID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"VENTA_PRECANCEL";

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

                        long errorCode = (long)((int)arParms[arParms.Length - 1].Value);
                        string strMensajeErr = "";

                        if (errorCode == DBValues._ERRORCODE_NOPUEDECANCELARSEPORPAGOSTIMBRADOS)
                        {
                            strMensajeErr = "Hay pagos timbrados que necesitan cancelarse. Vaya a Operaciones->Clientes->Abonos de cliente y cancele los pagos que no esten aun cancelados y tienen folio sat ";
                        }
                        else
                        {
                            strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.sCadenaConexion, null);

                        }



                        this.iComentario = "Hubo un error " + strMensajeErr;
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


        public bool NOTACREDITO_DEVOLVERTODAVENTA(long ventaADevolver, long vendedorId, ref long? devolucionActual, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTODEVOLVERID", FbDbType.BigInt);
                auxPar.Value = ventaADevolver;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = vendedorId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTONCID", FbDbType.BigInt);
                if (devolucionActual != null && devolucionActual.HasValue && devolucionActual.Value != 0)
                    auxPar.Value = devolucionActual.Value;
                else
                    auxPar.Value = DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"NOTACREDITO_DEVOLVERTODAVENTA ";

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
                        this.iComentario = "Hubo un error " + strMensajeErr;
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    devolucionActual = (long)arParms[arParms.Length - 2].Value;
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool SUSTITUCION_CREAR(long doctoId, long vendedorId, ref long newDoctoId, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOCANCELARID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = vendedorId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"SUSTITUCION_CREAR";

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
                        this.iComentario = "Hubo un error " + strMensajeErr;
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    if ((long)arParms[arParms.Length - 2].Value != 0)
                    {
                        newDoctoId = (long)arParms[arParms.Length - 2].Value;
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




        public bool ConvierteApartadoD(CDOCTOBE oCDOCTO, long personaApartadoId, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PERSONAAPARTADOID", FbDbType.BigInt);
                auxPar.Value = personaApartadoId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"VENTA_CONVIERTEAPARTADO";

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




        [AutoComplete]
        public bool CambiarDOCTOD(CDOCTOBE oCDOCTONuevo, CDOCTOBE oCDOCTOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCDOCTONuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCDOCTONuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCDOCTONuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCDOCTONuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ALMACENID", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IALMACENID"])
                {
                    auxPar.Value = oCDOCTONuevo.IALMACENID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["ISUCURSALID"])
                {
                    auxPar.Value = oCDOCTONuevo.ISUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPODOCTOID", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["ITIPODOCTOID"])
                {
                    auxPar.Value = oCDOCTONuevo.ITIPODOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESTATUSDOCTOID", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IESTATUSDOCTOID"])
                {
                    auxPar.Value = oCDOCTONuevo.IESTATUSDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESTATUSDOCTOPAGOID", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IESTATUSDOCTOPAGOID"])
                {
                    auxPar.Value = oCDOCTONuevo.IESTATUSDOCTOPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCDOCTONuevo.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAJEROID", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["ICAJEROID"])
                {
                    auxPar.Value = oCDOCTONuevo.ICAJEROID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IVENDEDORID"])
                {
                    auxPar.Value = oCDOCTONuevo.IVENDEDORID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["ICORTEID"])
                {
                    auxPar.Value = oCDOCTONuevo.ICORTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCDOCTONuevo.isnull["IFECHA"])
                {
                    auxPar.Value = oCDOCTONuevo.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SERIE", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["ISERIE"])
                {
                    auxPar.Value = oCDOCTONuevo.ISERIE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FOLIO", FbDbType.Integer);
                if (!(bool)oCDOCTONuevo.isnull["IFOLIO"])
                {
                    auxPar.Value = oCDOCTONuevo.IFOLIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PLAZO", FbDbType.SmallInt);
                if (!(bool)oCDOCTONuevo.isnull["IPLAZO"])
                {
                    auxPar.Value = oCDOCTONuevo.IPLAZO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENCE", FbDbType.Date);
                if (!(bool)oCDOCTONuevo.isnull["IVENCE"])
                {
                    auxPar.Value = oCDOCTONuevo.IVENCE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@REFERENCIA", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["IREFERENCIA"])
                {
                    auxPar.Value = oCDOCTONuevo.IREFERENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@REFERENCIAS", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["IREFERENCIAS"])
                {
                    auxPar.Value = oCDOCTONuevo.IREFERENCIAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCDOCTONuevo.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@OBSERVACION", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["IOBSERVACION"])
                {
                    auxPar.Value = oCDOCTONuevo.IOBSERVACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@OBSERVACIONES", FbDbType.Text);
                if (!(bool)oCDOCTONuevo.isnull["IOBSERVACIONES"])
                {
                    auxPar.Value = oCDOCTONuevo.IOBSERVACIONES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPORTE", FbDbType.Numeric);
                if (!(bool)oCDOCTONuevo.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCDOCTONuevo.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCUENTO", FbDbType.Numeric);
                if (!(bool)oCDOCTONuevo.isnull["IDESCUENTO"])
                {
                    auxPar.Value = oCDOCTONuevo.IDESCUENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUBTOTAL", FbDbType.Numeric);
                if (!(bool)oCDOCTONuevo.isnull["ISUBTOTAL"])
                {
                    auxPar.Value = oCDOCTONuevo.ISUBTOTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IVA", FbDbType.Numeric);
                if (!(bool)oCDOCTONuevo.isnull["IIVA"])
                {
                    auxPar.Value = oCDOCTONuevo.IIVA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TOTAL", FbDbType.Numeric);
                if (!(bool)oCDOCTONuevo.isnull["ITOTAL"])
                {
                    auxPar.Value = oCDOCTONuevo.ITOTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CARGO", FbDbType.Numeric);
                if (!(bool)oCDOCTONuevo.isnull["ICARGO"])
                {
                    auxPar.Value = oCDOCTONuevo.ICARGO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ABONO", FbDbType.Numeric);
                if (!(bool)oCDOCTONuevo.isnull["IABONO"])
                {
                    auxPar.Value = oCDOCTONuevo.IABONO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SALDO", FbDbType.Numeric);
                if (!(bool)oCDOCTONuevo.isnull["ISALDO"])
                {
                    auxPar.Value = oCDOCTONuevo.ISALDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAJAID", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["ICAJAID"])
                {
                    auxPar.Value = oCDOCTONuevo.ICAJAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCDOCTOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set

ID=@ID,

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

ALMACENID=@ALMACENID,

SUCURSALID=@SUCURSALID,

TIPODOCTOID=@TIPODOCTOID,

ESTATUSDOCTOID=@ESTATUSDOCTOID,

ESTATUSDOCTOPAGOID=@ESTATUSDOCTOPAGOID,

PERSONAID=@PERSONAID,

CAJEROID=@CAJEROID,

VENDEDORID=@VENDEDORID,

CORTEID=@CORTEID,

FECHA=@FECHA,

SERIE=@SERIE,

FOLIO=@FOLIO,

PLAZO=@PLAZO,

VENCE=@VENCE,

REFERENCIA=@REFERENCIA,

REFERENCIAS=@REFERENCIAS,

DESCRIPCION=@DESCRIPCION,

OBSERVACION=@OBSERVACION,

OBSERVACIONES=@OBSERVACIONES,

IMPORTE=@IMPORTE,

DESCUENTO=@DESCUENTO,

SUBTOTAL=@SUBTOTAL,

IVA=@IVA,

TOTAL=@TOTAL,

CARGO=@CARGO,

ABONO=@ABONO,

SALDO=@SALDO,

CAJAID=@CAJAID
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }





        public bool CambiarTIMBRADODOCTOD(CDOCTOBE oCDOCTONuevo, CDOCTOBE oCDOCTOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@TIMBRADOUUID", FbDbType.Char);
                if (!(bool)oCDOCTONuevo.isnull["ITIMBRADOUUID"])
                {
                    auxPar.Value = oCDOCTONuevo.ITIMBRADOUUID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@TIMBRADOCERTSAT", FbDbType.Char);
                if (!(bool)oCDOCTONuevo.isnull["ITIMBRADOCERTSAT"])
                {
                    auxPar.Value = oCDOCTONuevo.ITIMBRADOCERTSAT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIMBRADOFECHA", FbDbType.Char);
                if (!(bool)oCDOCTONuevo.isnull["ITIMBRADOFECHA"])
                {
                    auxPar.Value = oCDOCTONuevo.ITIMBRADOFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIMBRADOSELLOSAT", FbDbType.Char);
                if (!(bool)oCDOCTONuevo.isnull["ITIMBRADOSELLOSAT"])
                {
                    auxPar.Value = oCDOCTONuevo.ITIMBRADOSELLOSAT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIMBRADOSELLOCFDI", FbDbType.Char);
                if (!(bool)oCDOCTONuevo.isnull["ITIMBRADOSELLOCFDI"])
                {
                    auxPar.Value = oCDOCTONuevo.ITIMBRADOSELLOCFDI;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOPAGOSAT", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IDOCTOPAGOSAT"])
                {
                    auxPar.Value = oCDOCTONuevo.IDOCTOPAGOSAT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@TIMBRADOFECHAFACTURA", FbDbType.TimeStamp);
                if (!(bool)oCDOCTONuevo.isnull["ITIMBRADOFECHAFACTURA"])
                {
                    auxPar.Value = oCDOCTONuevo.ITIMBRADOFECHAFACTURA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@TIMBRADOFORMAPAGOSAT", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["ITIMBRADOFORMAPAGOSAT"])
                {
                    auxPar.Value = oCDOCTONuevo.ITIMBRADOFORMAPAGOSAT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                /*auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCDOCTONuevo.isnull["IFECHA"])
                {
                    auxPar.Value = oCDOCTONuevo.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FECHAHORA", FbDbType.TimeStamp);
                if (!(bool)oCDOCTONuevo.isnull["IFECHAHORA"])
                {
                    auxPar.Value = oCDOCTONuevo.IFECHAHORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);*/

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCDOCTOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set
TIMBRADOUUID  = @TIMBRADOUUID,
TIMBRADOCERTSAT  = @TIMBRADOCERTSAT,
TIMBRADOFECHA  = @TIMBRADOFECHA,
TIMBRADOSELLOSAT = @TIMBRADOSELLOSAT,
TIMBRADOSELLOCFDI = @TIMBRADOSELLOCFDI,
DOCTOPAGOSAT = @DOCTOPAGOSAT,
TIMBRADOFECHAFACTURA = @TIMBRADOFECHAFACTURA,
TIMBRADOFORMAPAGOSAT = @TIMBRADOFORMAPAGOSAT

  where 

ID=@IDAnt
  ;";

                /*,
FECHA = @FECHA,
FECHAHORA = @FECHAHORA*/

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }





        public bool CambiarTIMBRADODOCTOFORMAPAGOSATD(CDOCTOBE oCDOCTONuevo, CDOCTOBE oCDOCTOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                



                auxPar = new FbParameter("@TIMBRADOFORMAPAGOSAT", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["ITIMBRADOFORMAPAGOSAT"])
                {
                    auxPar.Value = oCDOCTONuevo.ITIMBRADOFORMAPAGOSAT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCDOCTOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set
TIMBRADOFORMAPAGOSAT = @TIMBRADOFORMAPAGOSAT

  where 

ID=@IDAnt
  ;";

                

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }





        public bool CambiarDOCTOPAGOSAT(CDOCTOBE oCDOCTONuevo, CDOCTOBE oCDOCTOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@DOCTOPAGOSAT", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IDOCTOPAGOSAT"])
                {
                    auxPar.Value = oCDOCTONuevo.IDOCTOPAGOSAT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCDOCTOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set
DOCTOPAGOSAT = @DOCTOPAGOSAT
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public long seleccionarDEVOLUCIONCOMPRAIMPORTADAxDOCTOREFID(long doctoId, FbTransaction st)
        {




            long retorno = 0;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from DOCTO where DOCTOREFID = @DOCTOREFID AND TIPODOCTOID = 12  ";


                auxPar = new FbParameter("@DOCTOREFID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno = (long)(dr["ID"]);
                    }

                }
                else
                {
                    retorno = 0;
                }


                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);


                return retorno;
            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return -1;
            }



        }




        [AutoComplete]
        public CDOCTOBE seleccionarDOCTO(CDOCTOBE oCDOCTO, FbTransaction st)
        {




            CDOCTOBE retorno = new CDOCTOBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from DOCTO where ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {
                    
                    retorno = parseFromReader(dr);
                }
                else
                {
                    retorno = null;
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






        public CDOCTOBE SeleccionarXTIPOYFOLIO(CDOCTOBE oCDOCTO, FbTransaction st)
        {

            CDOCTOBE retorno = new CDOCTOBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from DOCTO  where folio = @FOLIO and (tipodoctoid = @TIPODOCTOID or (@TIPODOCTOID = 0 AND tipodoctoid in (21,25)) )  ";



                auxPar = new FbParameter("@FOLIO", FbDbType.Integer);
                auxPar.Value = oCDOCTO.IFOLIO;
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPODOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.ITIPODOCTOID;
                parts.Add(auxPar);



                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);



                if (dr.Read())
                {


                    retorno = parseFromReader(dr);
                }
                else
                {
                    retorno = null;
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



        public CDOCTOBE SeleccionarXTIPOYREFID(CDOCTOBE oCDOCTO, FbTransaction st)
        {

            CDOCTOBE retorno = new CDOCTOBE();
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from DOCTO  where DOCTOREFID = @DOCTOREFID and TIPODOCTOID = @TIPODOCTOID ";



                auxPar = new FbParameter("@DOCTOREFID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IDOCTOREFID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPODOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.ITIPODOCTOID;
                parts.Add(auxPar);



                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);



                if (dr.Read())
                {

                    retorno = parseFromReader(dr);
                }
                else
                {
                    retorno = null;
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



        public CDOCTOBE SeleccionarXTIPOYFOLIOYSUCDEST(CDOCTOBE oCDOCTO, FbTransaction st)
        {

            CDOCTOBE retorno = new CDOCTOBE();
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from DOCTO  where folio = @FOLIO and (tipodoctoid = @TIPODOCTOID or (@TIPODOCTOID = 0 AND tipodoctoid in (21,25)) ) and (sucursaltid = @SUCURSALTID OR @SUCURSALTID = 0)";



                auxPar = new FbParameter("@FOLIO", FbDbType.Integer);
                auxPar.Value = oCDOCTO.IFOLIO;
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPODOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.ITIPODOCTOID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUCURSALTID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.ISUCURSALTID;
                parts.Add(auxPar);


                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);



                if (dr.Read())
                {
                    retorno = parseFromReader(dr);
                }
                else
                {
                    retorno = null;
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



        private CDOCTOBE parseFromReader(FbDataReader dr)
        {

            CDOCTOBE retorno = new CDOCTOBE();

            if (dr["ID"] != System.DBNull.Value)
            {
                retorno.IID = (long)(dr["ID"]);
            }

            if (dr["ACTIVO"] != System.DBNull.Value)
            {
                retorno.IACTIVO = (string)(dr["ACTIVO"]);
            }

            if (dr["CREADO"] != System.DBNull.Value)
            {
                retorno.ICREADO = (object)(dr["CREADO"]);
            }

            if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
            {
                retorno.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
            }

            if (dr["MODIFICADO"] != System.DBNull.Value)
            {
                retorno.IMODIFICADO = (object)(dr["MODIFICADO"]);
            }

            if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
            {
                retorno.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
            }

            if (dr["ALMACENID"] != System.DBNull.Value)
            {
                retorno.IALMACENID = (long)(dr["ALMACENID"]);
            }

            if (dr["SUCURSALID"] != System.DBNull.Value)
            {
                retorno.ISUCURSALID = (long)(dr["SUCURSALID"]);
            }

            if (dr["TIPODOCTOID"] != System.DBNull.Value)
            {
                retorno.ITIPODOCTOID = (long)(dr["TIPODOCTOID"]);
            }

            if (dr["ESTATUSDOCTOID"] != System.DBNull.Value)
            {
                retorno.IESTATUSDOCTOID = (long)(dr["ESTATUSDOCTOID"]);
            }

            if (dr["ESTATUSDOCTOPAGOID"] != System.DBNull.Value)
            {
                retorno.IESTATUSDOCTOPAGOID = (long)(dr["ESTATUSDOCTOPAGOID"]);
            }

            if (dr["PERSONAID"] != System.DBNull.Value)
            {
                retorno.IPERSONAID = (long)(dr["PERSONAID"]);
            }

            if (dr["CAJEROID"] != System.DBNull.Value)
            {
                retorno.ICAJEROID = (long)(dr["CAJEROID"]);
            }

            if (dr["VENDEDORID"] != System.DBNull.Value)
            {
                retorno.IVENDEDORID = (long)(dr["VENDEDORID"]);
            }

            if (dr["CORTEID"] != System.DBNull.Value)
            {
                retorno.ICORTEID = (long)(dr["CORTEID"]);
            }

            if (dr["FECHA"] != System.DBNull.Value)
            {
                retorno.IFECHA = (DateTime)(dr["FECHA"]);
            }

            if (dr["FECHAHORA"] != System.DBNull.Value)
            {
                retorno.IFECHAHORA = (DateTime)(dr["FECHAHORA"]);
            }

            if (dr["SERIE"] != System.DBNull.Value)
            {
                retorno.ISERIE = (string)(dr["SERIE"]);
            }

            if (dr["VENCE"] != System.DBNull.Value)
            {
                retorno.IVENCE = (DateTime)(dr["VENCE"]);
            }

            if (dr["REFERENCIA"] != System.DBNull.Value)
            {
                retorno.IREFERENCIA = (string)(dr["REFERENCIA"]);
            }

            if (dr["REFERENCIAS"] != System.DBNull.Value)
            {
                retorno.IREFERENCIAS = (string)(dr["REFERENCIAS"]);
            }

            if (dr["DESCRIPCION"] != System.DBNull.Value)
            {
                retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
            }

            if (dr["OBSERVACION"] != System.DBNull.Value)
            {
                retorno.IOBSERVACION = (string)(dr["OBSERVACION"]);
            }

            if (dr["OBSERVACIONES"] != System.DBNull.Value)
            {
                retorno.IOBSERVACIONES = (string)(dr["OBSERVACIONES"]);
            }

            if (dr["IMPORTE"] != System.DBNull.Value)
            {
                retorno.IIMPORTE = (decimal)(dr["IMPORTE"]);
            }

            if (dr["DESCUENTO"] != System.DBNull.Value)
            {
                retorno.IDESCUENTO = (decimal)(dr["DESCUENTO"]);
            }

            if (dr["SUBTOTAL"] != System.DBNull.Value)
            {
                retorno.ISUBTOTAL = (decimal)(dr["SUBTOTAL"]);
            }

            if (dr["IVA"] != System.DBNull.Value)
            {
                retorno.IIVA = (decimal)(dr["IVA"]);
            }

            if (dr["TOTAL"] != System.DBNull.Value)
            {
                retorno.ITOTAL = (decimal)(dr["TOTAL"]);
            }

            if (dr["CARGO"] != System.DBNull.Value)
            {
                retorno.ICARGO = (decimal)(dr["CARGO"]);
            }

            if (dr["ABONO"] != System.DBNull.Value)
            {
                retorno.IABONO = (decimal)(dr["ABONO"]);
            }

            if (dr["SALDO"] != System.DBNull.Value)
            {
                retorno.ISALDO = (decimal)(dr["SALDO"]);
            }

            if (dr["CAJAID"] != System.DBNull.Value)
            {
                retorno.ICAJAID = (long)(dr["CAJAID"]);
            }

            if (dr["FOLIO"] != System.DBNull.Value)
            {
                retorno.IFOLIO = int.Parse(dr["FOLIO"].ToString());
            }

            if (dr["PLAZO"] != System.DBNull.Value)
            {
                retorno.IPLAZO = short.Parse(dr["PLAZO"].ToString());
            }


            if (dr["ORIGENFISCALID"] != System.DBNull.Value)
            {
                retorno.IORIGENFISCALID = (long)(dr["ORIGENFISCALID"]);
            }

            if (dr["MONTOORIGENFACTURADO"] != System.DBNull.Value)
            {
                retorno.IMONTOORIGENFACTURADO = (decimal)(dr["MONTOORIGENFACTURADO"]);
            }

            if (dr["VENDEDORFINAL"] != System.DBNull.Value)
            {
                retorno.IVENDEDORFINAL = (long)(dr["VENDEDORFINAL"]);
            }

            if (dr["FOLIOORIGENFACTURADO"] != System.DBNull.Value)
            {
                retorno.IFOLIOORIGENFACTURADO = int.Parse(dr["FOLIOORIGENFACTURADO"].ToString());
            }

            if (dr["APLICADOREF"] != System.DBNull.Value)
            {
                retorno.IAPLICADOREF = (string)(dr["APLICADOREF"]);
            }

            if (dr["DOCTOREFID"] != System.DBNull.Value)
            {
                retorno.IDOCTOREFID = (long)(dr["DOCTOREFID"]);
            }

            if (dr["MERCANCIAENTREGADA"] != System.DBNull.Value)
            {
                retorno.IMERCANCIAENTREGADA = (string)(dr["MERCANCIAENTREGADA"]);
            }

            if (dr["PERSONAAPARTADOID"] != System.DBNull.Value)
            {
                retorno.IPERSONAAPARTADOID = (long)(dr["PERSONAAPARTADOID"]);
            }


            if (dr["TIMBRADOUUID"] != System.DBNull.Value)
            {
                retorno.ITIMBRADOUUID = (string)(dr["TIMBRADOUUID"]);
            }
            if (dr["TIMBRADOCERTSAT"] != System.DBNull.Value)
            {
                retorno.ITIMBRADOCERTSAT = (string)(dr["TIMBRADOCERTSAT"]);
            }
            if (dr["TIMBRADOFECHA"] != System.DBNull.Value)
            {
                retorno.ITIMBRADOFECHA = (string)(dr["TIMBRADOFECHA"]);
            }

            if (dr["TIMBRADOSELLOSAT"] != System.DBNull.Value)
            {
                retorno.ITIMBRADOSELLOSAT = (string)(dr["TIMBRADOSELLOSAT"]);
            }
            if (dr["TIMBRADOSELLOCFDI"] != System.DBNull.Value)
            {
                retorno.ITIMBRADOSELLOCFDI = (string)(dr["TIMBRADOSELLOCFDI"]);
            }



            if (dr["SERIESAT"] != System.DBNull.Value)
            {
                retorno.ISERIESAT = (string)(dr["SERIESAT"]);
            }

            if (dr["FOLIOSAT"] != System.DBNull.Value)
            {
                retorno.IFOLIOSAT = (int)(dr["FOLIOSAT"]);
            }

            if (dr["DOCTOPAGOSAT"] != System.DBNull.Value)
            {
                retorno.IDOCTOPAGOSAT = (long)(dr["DOCTOPAGOSAT"]);
            }

            if (dr["ESAPARTADO"] != System.DBNull.Value)
            {
                retorno.IESAPARTADO = (string)(dr["ESAPARTADO"]);
            }

            if (dr["ESFACTURAELECTRONICA"] != System.DBNull.Value)
            {
                retorno.IESFACTURAELECTRONICA = (string)(dr["ESFACTURAELECTRONICA"]);
            }


            if (dr["SUCURSALTID"] != System.DBNull.Value)
            {
                retorno.ISUCURSALTID = (long)(dr["SUCURSALTID"]);
            }
            if (dr["TRASLADOAFTP"] != System.DBNull.Value)
            {
                retorno.ITRASLADOAFTP = (string)(dr["TRASLADOAFTP"]);
            }

            if (dr["SUBTIPODOCTOID"] != System.DBNull.Value)
            {
                retorno.ISUBTIPODOCTOID = (long)(dr["SUBTIPODOCTOID"]);
            }

            if (dr["FECHAINI"] != System.DBNull.Value)
            {
                retorno.IFECHAINI = (DateTime)(dr["FECHAINI"]);
            }
            if (dr["FECHAFIN"] != System.DBNull.Value)
            {
                retorno.IFECHAFIN = (DateTime)(dr["FECHAFIN"]);
            }
            if (dr["SUPERVISORID"] != System.DBNull.Value)
            {
                retorno.ISUPERVISORID = (long)(dr["SUPERVISORID"]);
            }

            if (dr["USARDATOSENTREGA"] != System.DBNull.Value)
            {
                retorno.IUSARDATOSENTREGA = (string)(dr["USARDATOSENTREGA"]);
            }


            if (dr["IVARETENIDO"] != System.DBNull.Value)
            {
                retorno.IIVARETENIDO = (decimal)(dr["IVARETENIDO"]);
            }


            if (dr["ISRRETENIDO"] != System.DBNull.Value)
            {
                retorno.IISRRETENIDO = (decimal)(dr["ISRRETENIDO"]);
            }

            if (dr["MONEDAID"] != System.DBNull.Value)
            {
                retorno.IMONEDAID = (long)(dr["MONEDAID"]);
            }

            if (dr["TIPOCAMBIO"] != System.DBNull.Value)
            {
                retorno.ITIPOCAMBIO = (decimal)(dr["TIPOCAMBIO"]);
            }

            if (dr["IEPS"] != System.DBNull.Value)
            {
                retorno.IIEPS = (decimal)(dr["IEPS"]);
            }

            if (dr["IMPUESTO"] != System.DBNull.Value)
            {
                retorno.IIMPUESTO = (decimal)(dr["IMPUESTO"]);
            }




            if (dr["TOTALANTICIPO"] != System.DBNull.Value)
            {
                retorno.ITOTALANTICIPO = (decimal)(dr["TOTALANTICIPO"]);
            }

            if (dr["ESTATUSANTICIPOID"] != System.DBNull.Value)
            {
                retorno.IESTATUSANTICIPOID = (long)(dr["ESTATUSANTICIPOID"]);
            }


            if (dr["FECHAFACTURA"] != System.DBNull.Value)
            {
                retorno.IFECHAFACTURA = (DateTime)(dr["FECHAFACTURA"]);
            }

            if (dr["NOTAPAGO"] != System.DBNull.Value)
            {
                retorno.INOTAPAGO = (string)(dr["NOTAPAGO"]);
            }

            if (dr["MANEJORECETA"] != System.DBNull.Value)
            {
                retorno.IMANEJORECETA = (string)(dr["MANEJORECETA"]);
            }

            if (dr["TRANREGSERVER"] != System.DBNull.Value)
            {
                retorno.ITRANREGSERVER = (string)(dr["TRANREGSERVER"]);
            }

            if (dr["MOVILPLAZOS"] != System.DBNull.Value)
            {
                retorno.IMOVILPLAZOS = (string)(dr["MOVILPLAZOS"]);
            }
            if (dr["MOVILCONTADO"] != System.DBNull.Value)
            {
                retorno.IMOVILCONTADO = (string)(dr["MOVILCONTADO"]);
            }


            if (dr["TIMBRADOCANCELADO"] != System.DBNull.Value)
            {
                retorno.ITIMBRADOCANCELADO = (string)(dr["TIMBRADOCANCELADO"]);
            }

            if (dr["TIMBRADOFECHACANCELACION"] != System.DBNull.Value)
            {
                retorno.ITIMBRADOFECHACANCELACION = (DateTime)(dr["TIMBRADOFECHACANCELACION"]);
            }

            if (dr["TIMBRADOUUIDCANCELACION"] != System.DBNull.Value)
            {
                retorno.ITIMBRADOUUIDCANCELACION = (string)(dr["TIMBRADOUUIDCANCELACION"]);
            }

            if (dr["TIMBRADOFECHAFACTURA"] != System.DBNull.Value)
            {
                retorno.ITIMBRADOFECHAFACTURA = (DateTime)(dr["TIMBRADOFECHAFACTURA"]);
            }

            if (dr["ALMACENTID"] != System.DBNull.Value)
            {
                retorno.IALMACENTID = (long)(dr["ALMACENTID"]);
            }


            if (dr["TOTALCONREBAJA"] != System.DBNull.Value)
            {
                retorno.ITOTALCONREBAJA = (decimal)(dr["TOTALCONREBAJA"]);
            }


            if (dr["MONTOREBAJA"] != System.DBNull.Value)
            {
                retorno.IMONTOREBAJA = (decimal)(dr["MONTOREBAJA"]);
            }


            if (dr["PROCESOSURTIDO"] != System.DBNull.Value)
            {
                retorno.IPROCESOSURTIDO = (string)(dr["PROCESOSURTIDO"]);
            }


            if (dr["PENDMAXFECHA"] != System.DBNull.Value)
            {
                retorno.IPENDMAXFECHA = (DateTime)(dr["PENDMAXFECHA"]);
            }


            if (dr["ESTADOSURTIDOID"] != System.DBNull.Value)
            {
                retorno.IESTADOSURTIDOID = (long)(dr["ESTADOSURTIDOID"]);
            }

            if (dr["FACTCONSID"] != System.DBNull.Value)
            {
                retorno.IFACTCONSID = (long)(dr["FACTCONSID"]);
            }

            if (dr["DEVCONSID"] != System.DBNull.Value)
            {
                retorno.IDEVCONSID = (long)(dr["DEVCONSID"]);
            }


            if (dr["TIPODESCUENTOVALE"] != System.DBNull.Value)
            {
                retorno.ITIPODESCUENTOVALE = (long)(dr["TIPODESCUENTOVALE"]);
            }

            if (dr["MONTOBILLETESID"] != System.DBNull.Value)
            {
                retorno.IMONTOBILLETESID = (long)(dr["MONTOBILLETESID"]);
            }



            if (dr["PAGOCONTARJETA"] != System.DBNull.Value)
            {
                retorno.IPAGOCONTARJETA = (string)(dr["PAGOCONTARJETA"]);
            }

            if (dr["COMISIONPAGOTARJETA"] != System.DBNull.Value)
            {
                retorno.ICOMISIONPAGOTARJETA = (decimal)(dr["COMISIONPAGOTARJETA"]);
            }


            if (dr["TIMBRADOFORMAPAGOSAT"] != System.DBNull.Value)
            {
                retorno.ITIMBRADOFORMAPAGOSAT = (string)(dr["TIMBRADOFORMAPAGOSAT"]);
            }


            if (dr["VENTAFUTUID"] != System.DBNull.Value)
            {
                retorno.IVENTAFUTUID = (long)(dr["VENTAFUTUID"]);
            }


            if (dr["RUTAEMBARQUEID"] != System.DBNull.Value)
            {
                retorno.IRUTAEMBARQUEID = (long)(dr["RUTAEMBARQUEID"]);
            }

            if (dr["ESTADOGUIAID"] != System.DBNull.Value)
            {
                retorno.IESTADOGUIAID = (long)(dr["ESTADOGUIAID"]);
            }

            if (dr["GUIAID"] != System.DBNull.Value)
            {
                retorno.IGUIAID = (long)(dr["GUIAID"]);
            }

            if (dr["PAGOBANCOMERAPLICADO"] != System.DBNull.Value)
            {
                retorno.IPAGOBANCOMERAPLICADO = (string)(dr["PAGOBANCOMERAPLICADO"]);
            }

            if (dr["PAGOACREDITO"] != System.DBNull.Value)
            {
                retorno.IPAGOACREDITO = (string)(dr["PAGOACREDITO"]);
            }


            if (dr["ORDENCOMPRA"] != System.DBNull.Value)
            {
                retorno.IORDENCOMPRA = (string)(dr["ORDENCOMPRA"]);
            }

            if (dr["LOTEIMPORTADO"] != System.DBNull.Value)
            {
                retorno.ILOTEIMPORTADO = (long)(dr["LOTEIMPORTADO"]);
            }

            if (dr["VENDEDOREJECUTIVOID"] != System.DBNull.Value)
            {
                retorno.IVENDEDOREJECUTIVOID = (long)(dr["VENDEDOREJECUTIVOID"]);
            }

            if (dr["DOCTOPLAZOORIGENID"] != System.DBNull.Value)
            {
                retorno.IDOCTOPLAZOORIGENID = (long)(dr["DOCTOPLAZOORIGENID"]);
            }
            if (dr["DOCTOIMPORTADOID"] != System.DBNull.Value)
            {
                retorno.IDOCTOIMPORTADOID = (long)(dr["DOCTOIMPORTADOID"]);
            }
            if (dr["AUTORIZOALERTAID"] != System.DBNull.Value)
            {
                retorno.IAUTORIZOALERTAID = (long)(dr["AUTORIZOALERTAID"]);
            }
            if (dr["SAT_USOCFDIID"] != System.DBNull.Value)
            {
                retorno.ISAT_USOCFDIID = (long)(dr["SAT_USOCFDIID"]);
            }

            if (dr["PAGOSAT"] != System.DBNull.Value)
            {
                retorno.IPAGOSAT = (long)(dr["PAGOSAT"]);
            }

            if (dr["DOCTOSUSTITUTOID"] != System.DBNull.Value)
            {
                retorno.IDOCTOSUSTITUTOID = (long)(dr["DOCTOSUSTITUTOID"]);
            }
            if (dr["DOCTOASUSTITUIRID"] != System.DBNull.Value)
            {
                retorno.IDOCTOASUSTITUIRID = (long)(dr["DOCTOASUSTITUIRID"]);
            }
            if (dr["CFDIID"] != System.DBNull.Value)
            {
                retorno.ICFDIID = (long)(dr["CFDIID"]);
            }


            if (dr["KITDESGLOSADO"] != System.DBNull.Value)
            {
                retorno.IKITDESGLOSADO = (string)(dr["KITDESGLOSADO"]);
            }

            if (dr["PLAZOID"] != System.DBNull.Value)
            {
                retorno.IPLAZOID = (long)(dr["PLAZOID"]);
            }

            if (dr["ESSERVDOMICILIO"] != System.DBNull.Value)
            {
                retorno.IESSERVDOMICILIO = (string)(dr["ESSERVDOMICILIO"]);
            }

            if (dr["ABONONOAPLICADO"] != System.DBNull.Value)
            {
                retorno.IABONONOAPLICADO = (decimal)(dr["ABONONOAPLICADO"]);
            }


            if (dr["COMISION"] != System.DBNull.Value)
            {
                retorno.ICOMISION = (decimal)(dr["COMISION"]);
            }

            if (dr["ESTADOREVISADOID"] != System.DBNull.Value)
            {
                retorno.IESTADOREVISADOID = (long)(dr["ESTADOREVISADOID"]);
            }


            if (dr["COMISIONPAGOTARJETADEB"] != System.DBNull.Value)
            {
                retorno.ICOMISIONPAGOTARJETADEB = (decimal)(dr["COMISIONPAGOTARJETADEB"]);
            }

            if (dr["CONTRARECIBOID"] != System.DBNull.Value)
            {
                retorno.ICONTRARECIBOID = (long)(dr["CONTRARECIBOID"]);
            }

            if (dr["ESTADOREBAJA"] != System.DBNull.Value)
            {
                retorno.IESTADOREBAJA = (long)(dr["ESTADOREBAJA"]);
            }

            if (dr["TIPODIFERENCIAINVENTARIOID"] != System.DBNull.Value)
            {
                retorno.ITIPODIFERENCIAINVENTARIOID = (long)(dr["TIPODIFERENCIAINVENTARIOID"]);
            }

            if (dr["UTILIDAD"] != System.DBNull.Value)
            {
                retorno.IUTILIDAD = (decimal)(dr["UTILIDAD"]);
            }

            if (dr["PAGOVERIFONEAPLICADO"] != System.DBNull.Value)
            {
                retorno.IPAGOVERIFONEAPLICADO = (string)(dr["PAGOVERIFONEAPLICADO"]);
            }

            if (dr["ESVENTAESPECIAL"] != System.DBNull.Value)
            {
                retorno.IESVENTAESPECIAL = (string)(dr["ESVENTAESPECIAL"]);
            }

            if (dr["COTI_ENRUTADA"] != System.DBNull.Value)
            {
                retorno.ICOTI_ENRUTADA = (string)(dr["COTI_ENRUTADA"]);
            }

            if (dr["DOM_ENTREGAID"] != System.DBNull.Value)
            {
                retorno.IDOM_ENTREGAID = (long)(dr["DOM_ENTREGAID"]);
            }

            return retorno;
        }


        public decimal TotalSinRebaja(long doctoId, FbTransaction st)
        {

            decimal retorno = 0;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select sum(gridpv.TOTALCONTOPE) TOTALCONTOPE from GRIDPV where DOCTOID = @DOCTOID  ";



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);
                



                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);



                if (dr.Read())
                {
                    
                    if (dr["TOTALCONTOPE"] != System.DBNull.Value)
                    {
                        retorno = (decimal)(dr["TOTALCONTOPE"]);
                    }
                }
                else
                {
                    retorno = 0;
                }


                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);


                return retorno;
            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return 0;
            }



        }


        public CDOCTOBE SeleccionarXTIPOYFOLIOFacturaElectronica(CDOCTOBE oCDOCTO, FbTransaction st)
        {

            CDOCTOBE retorno = new CDOCTOBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from DOCTO  where foliosat = @FOLIOSAT AND seriesat = @SERIESAT and (tipodoctoid = @TIPODOCTOID or (@TIPODOCTOID = 0 AND tipodoctoid in (21,25)) )  ";



                auxPar = new FbParameter("@FOLIOSAT", FbDbType.Integer);
                auxPar.Value = oCDOCTO.IFOLIOSAT;
                parts.Add(auxPar);


                auxPar = new FbParameter("@SERIESAT", FbDbType.VarChar);
                auxPar.Value = oCDOCTO.ISERIESAT;
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPODOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.ITIPODOCTOID;
                parts.Add(auxPar);



                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);



                if (dr.Read())
                {

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno.IID = (long)(dr["ID"]);
                    }

                    if (dr["ACTIVO"] != System.DBNull.Value)
                    {
                        retorno.IACTIVO = (string)(dr["ACTIVO"]);
                    }

                    if (dr["CREADO"] != System.DBNull.Value)
                    {
                        retorno.ICREADO = (object)(dr["CREADO"]);
                    }

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADO"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADO = (object)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["ALMACENID"] != System.DBNull.Value)
                    {
                        retorno.IALMACENID = (long)(dr["ALMACENID"]);
                    }

                    if (dr["SUCURSALID"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSALID = (long)(dr["SUCURSALID"]);
                    }

                    if (dr["TIPODOCTOID"] != System.DBNull.Value)
                    {
                        retorno.ITIPODOCTOID = (long)(dr["TIPODOCTOID"]);
                    }

                    if (dr["ESTATUSDOCTOID"] != System.DBNull.Value)
                    {
                        retorno.IESTATUSDOCTOID = (long)(dr["ESTATUSDOCTOID"]);
                    }

                    if (dr["ESTATUSDOCTOPAGOID"] != System.DBNull.Value)
                    {
                        retorno.IESTATUSDOCTOPAGOID = (long)(dr["ESTATUSDOCTOPAGOID"]);
                    }

                    if (dr["PERSONAID"] != System.DBNull.Value)
                    {
                        retorno.IPERSONAID = (long)(dr["PERSONAID"]);
                    }

                    if (dr["CAJEROID"] != System.DBNull.Value)
                    {
                        retorno.ICAJEROID = (long)(dr["CAJEROID"]);
                    }

                    if (dr["VENDEDORID"] != System.DBNull.Value)
                    {
                        retorno.IVENDEDORID = (long)(dr["VENDEDORID"]);
                    }

                    if (dr["CORTEID"] != System.DBNull.Value)
                    {
                        retorno.ICORTEID = (long)(dr["CORTEID"]);
                    }

                    if (dr["FECHA"] != System.DBNull.Value)
                    {
                        retorno.IFECHA = (DateTime)(dr["FECHA"]);
                    }

                    if (dr["FECHAHORA"] != System.DBNull.Value)
                    {
                        retorno.IFECHAHORA = (DateTime)(dr["FECHAHORA"]);
                    }

                    if (dr["SERIE"] != System.DBNull.Value)
                    {
                        retorno.ISERIE = (string)(dr["SERIE"]);
                    }

                    if (dr["VENCE"] != System.DBNull.Value)
                    {
                        retorno.IVENCE = (DateTime)(dr["VENCE"]);
                    }

                    if (dr["REFERENCIA"] != System.DBNull.Value)
                    {
                        retorno.IREFERENCIA = (string)(dr["REFERENCIA"]);
                    }

                    if (dr["REFERENCIAS"] != System.DBNull.Value)
                    {
                        retorno.IREFERENCIAS = (string)(dr["REFERENCIAS"]);
                    }

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
                    }

                    if (dr["OBSERVACION"] != System.DBNull.Value)
                    {
                        retorno.IOBSERVACION = (string)(dr["OBSERVACION"]);
                    }

                    if (dr["OBSERVACIONES"] != System.DBNull.Value)
                    {
                        retorno.IOBSERVACIONES = (string)(dr["OBSERVACIONES"]);
                    }

                    if (dr["IMPORTE"] != System.DBNull.Value)
                    {
                        retorno.IIMPORTE = (decimal)(dr["IMPORTE"]);
                    }

                    if (dr["DESCUENTO"] != System.DBNull.Value)
                    {
                        retorno.IDESCUENTO = (decimal)(dr["DESCUENTO"]);
                    }

                    if (dr["SUBTOTAL"] != System.DBNull.Value)
                    {
                        retorno.ISUBTOTAL = (decimal)(dr["SUBTOTAL"]);
                    }

                    if (dr["IVA"] != System.DBNull.Value)
                    {
                        retorno.IIVA = (decimal)(dr["IVA"]);
                    }

                    if (dr["TOTAL"] != System.DBNull.Value)
                    {
                        retorno.ITOTAL = (decimal)(dr["TOTAL"]);
                    }

                    if (dr["CARGO"] != System.DBNull.Value)
                    {
                        retorno.ICARGO = (decimal)(dr["CARGO"]);
                    }

                    if (dr["ABONO"] != System.DBNull.Value)
                    {
                        retorno.IABONO = (decimal)(dr["ABONO"]);
                    }

                    if (dr["SALDO"] != System.DBNull.Value)
                    {
                        retorno.ISALDO = (decimal)(dr["SALDO"]);
                    }

                    if (dr["CAJAID"] != System.DBNull.Value)
                    {
                        retorno.ICAJAID = (long)(dr["CAJAID"]);
                    }

                    if (dr["FOLIO"] != System.DBNull.Value)
                    {
                        retorno.IFOLIO = int.Parse(dr["FOLIO"].ToString());
                    }

                    if (dr["PLAZO"] != System.DBNull.Value)
                    {
                        retorno.IPLAZO = short.Parse(dr["PLAZO"].ToString());
                    }


                    if (dr["ORIGENFISCALID"] != System.DBNull.Value)
                    {
                        retorno.IORIGENFISCALID = (long)(dr["ORIGENFISCALID"]);
                    }

                    if (dr["MONTOORIGENFACTURADO"] != System.DBNull.Value)
                    {
                        retorno.IMONTOORIGENFACTURADO = (decimal)(dr["MONTOORIGENFACTURADO"]);
                    }

                    if (dr["VENDEDORFINAL"] != System.DBNull.Value)
                    {
                        retorno.IVENDEDORFINAL = (long)(dr["VENDEDORFINAL"]);
                    }

                    if (dr["FOLIOORIGENFACTURADO"] != System.DBNull.Value)
                    {
                        retorno.IFOLIOORIGENFACTURADO = int.Parse(dr["FOLIOORIGENFACTURADO"].ToString());
                    }

                    if (dr["APLICADOREF"] != System.DBNull.Value)
                    {
                        retorno.IAPLICADOREF = (string)(dr["APLICADOREF"]);
                    }


                    if (dr["DOCTOREFID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOREFID = (long)(dr["DOCTOREFID"]);
                    }

                    if (dr["MERCANCIAENTREGADA"] != System.DBNull.Value)
                    {
                        retorno.IMERCANCIAENTREGADA = (string)(dr["MERCANCIAENTREGADA"]);
                    }

                    if (dr["PERSONAAPARTADOID"] != System.DBNull.Value)
                    {
                        retorno.IPERSONAAPARTADOID = (long)(dr["PERSONAAPARTADOID"]);
                    }

                    if (dr["TIMBRADOUUID"] != System.DBNull.Value)
                    {
                        retorno.ITIMBRADOUUID = (string)(dr["TIMBRADOUUID"]);
                    }
                    if (dr["TIMBRADOCERTSAT"] != System.DBNull.Value)
                    {
                        retorno.ITIMBRADOCERTSAT = (string)(dr["TIMBRADOCERTSAT"]);
                    }
                    if (dr["TIMBRADOFECHA"] != System.DBNull.Value)
                    {
                        retorno.ITIMBRADOFECHA = (string)(dr["TIMBRADOFECHA"]);
                    }

                    if (dr["TIMBRADOSELLOSAT"] != System.DBNull.Value)
                    {
                        retorno.ITIMBRADOSELLOSAT = (string)(dr["TIMBRADOSELLOSAT"]);
                    }
                    if (dr["TIMBRADOSELLOCFDI"] != System.DBNull.Value)
                    {
                        retorno.ITIMBRADOSELLOCFDI = (string)(dr["TIMBRADOSELLOCFDI"]);
                    }


                    if (dr["SERIESAT"] != System.DBNull.Value)
                    {
                        retorno.ISERIESAT = (string)(dr["SERIESAT"]);
                    }

                    if (dr["FOLIOSAT"] != System.DBNull.Value)
                    {
                        retorno.IFOLIOSAT = (int)(dr["FOLIOSAT"]);
                    }

                    if (dr["DOCTOPAGOSAT"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOPAGOSAT = (long)(dr["DOCTOPAGOSAT"]);
                    }

                    if (dr["ESAPARTADO"] != System.DBNull.Value)
                    {
                        retorno.IESAPARTADO = (string)(dr["ESAPARTADO"]);
                    }

                    if (dr["ESFACTURAELECTRONICA"] != System.DBNull.Value)
                    {
                        retorno.IESFACTURAELECTRONICA = (string)(dr["ESFACTURAELECTRONICA"]);
                    }

                    if (dr["SUCURSALTID"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSALTID = (long)(dr["SUCURSALTID"]);
                    }
                    if (dr["TRASLADOAFTP"] != System.DBNull.Value)
                    {
                        retorno.ITRASLADOAFTP = (string)(dr["TRASLADOAFTP"]);
                    }

                    if (dr["SUBTIPODOCTOID"] != System.DBNull.Value)
                    {
                        retorno.ISUBTIPODOCTOID = (long)(dr["SUBTIPODOCTOID"]);
                    }

                    if (dr["FECHAINI"] != System.DBNull.Value)
                    {
                        retorno.IFECHAINI = (DateTime)(dr["FECHAINI"]);
                    }
                    if (dr["FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.IFECHAFIN = (DateTime)(dr["FECHAFIN"]);
                    }

                    if (dr["SUPERVISORID"] != System.DBNull.Value)
                    {
                        retorno.ISUPERVISORID = (long)(dr["SUPERVISORID"]);
                    }

                    if (dr["USARDATOSENTREGA"] != System.DBNull.Value)
                    {
                        retorno.IUSARDATOSENTREGA = (string)(dr["USARDATOSENTREGA"]);
                    }

                    if (dr["IVARETENIDO"] != System.DBNull.Value)
                    {
                        retorno.IIVARETENIDO = (decimal)(dr["IVARETENIDO"]);
                    }


                    if (dr["ISRRETENIDO"] != System.DBNull.Value)
                    {
                        retorno.IISRRETENIDO = (decimal)(dr["ISRRETENIDO"]);
                    }



                    if (dr["MONEDAID"] != System.DBNull.Value)
                    {
                        retorno.IMONEDAID = (long)(dr["MONEDAID"]);
                    }

                    if (dr["TIPOCAMBIO"] != System.DBNull.Value)
                    {
                        retorno.ITIPOCAMBIO = (decimal)(dr["TIPOCAMBIO"]);
                    }


                    if (dr["IEPS"] != System.DBNull.Value)
                    {
                        retorno.IIEPS = (decimal)(dr["IEPS"]);
                    }

                    if (dr["IMPUESTO"] != System.DBNull.Value)
                    {
                        retorno.IIMPUESTO = (decimal)(dr["IMPUESTO"]);
                    }

                    if (dr["TOTALANTICIPO"] != System.DBNull.Value)
                    {
                        retorno.ITOTALANTICIPO = (decimal)(dr["TOTALANTICIPO"]);
                    }

                    if (dr["ESTATUSANTICIPOID"] != System.DBNull.Value)
                    {
                        retorno.IESTATUSANTICIPOID = (long)(dr["ESTATUSANTICIPOID"]);
                    }




                    if (dr["FECHAFACTURA"] != System.DBNull.Value)
                    {
                        retorno.IFECHAFACTURA = (DateTime)(dr["FECHAFACTURA"]);
                    }

                    if (dr["NOTAPAGO"] != System.DBNull.Value)
                    {
                        retorno.INOTAPAGO = (string)(dr["NOTAPAGO"]);
                    }

                    if (dr["MANEJORECETA"] != System.DBNull.Value)
                    {
                        retorno.IMANEJORECETA = (string)(dr["MANEJORECETA"]);
                    }

                    if (dr["MOVILPLAZOS"] != System.DBNull.Value)
                    {
                        retorno.IMOVILPLAZOS = (string)(dr["MOVILPLAZOS"]);
                    }
                    if (dr["MOVILCONTADO"] != System.DBNull.Value)
                    {
                        retorno.IMOVILCONTADO = (string)(dr["MOVILCONTADO"]);
                    }

                    if (dr["TIMBRADOCANCELADO"] != System.DBNull.Value)
                    {
                        retorno.ITIMBRADOCANCELADO = (string)(dr["TIMBRADOCANCELADO"]);
                    }

                    if (dr["TIMBRADOFECHACANCELACION"] != System.DBNull.Value)
                    {
                        retorno.ITIMBRADOFECHACANCELACION = (DateTime)(dr["TIMBRADOFECHACANCELACION"]);
                    }

                    if (dr["TIMBRADOUUIDCANCELACION"] != System.DBNull.Value)
                    {
                        retorno.ITIMBRADOUUIDCANCELACION = (string)(dr["TIMBRADOUUIDCANCELACION"]);
                    }

                    if (dr["TIMBRADOFECHAFACTURA"] != System.DBNull.Value)
                    {
                        retorno.ITIMBRADOFECHAFACTURA = (DateTime)(dr["TIMBRADOFECHAFACTURA"]);
                    }

                    if (dr["ALMACENTID"] != System.DBNull.Value)
                    {
                        retorno.IALMACENTID = (long)(dr["ALMACENTID"]);
                    }



                    if (dr["TOTALCONREBAJA"] != System.DBNull.Value)
                    {
                        retorno.ITOTALCONREBAJA = (decimal)(dr["TOTALCONREBAJA"]);
                    }


                    if (dr["MONTOREBAJA"] != System.DBNull.Value)
                    {
                        retorno.IMONTOREBAJA = (decimal)(dr["MONTOREBAJA"]);
                    }


                    if (dr["PROCESOSURTIDO"] != System.DBNull.Value)
                    {
                        retorno.IPROCESOSURTIDO = (string)(dr["PROCESOSURTIDO"]);
                    }

                    if (dr["PENDMAXFECHA"] != System.DBNull.Value)
                    {
                        retorno.IPENDMAXFECHA = (DateTime)(dr["PENDMAXFECHA"]);
                    }


                    if (dr["ESTADOSURTIDOID"] != System.DBNull.Value)
                    {
                        retorno.IESTADOSURTIDOID = (long)(dr["ESTADOSURTIDOID"]);
                    }

                    if (dr["FACTCONSID"] != System.DBNull.Value)
                    {
                        retorno.IFACTCONSID = (long)(dr["FACTCONSID"]);
                    }

                    if (dr["DEVCONSID"] != System.DBNull.Value)
                    {
                        retorno.IDEVCONSID = (long)(dr["DEVCONSID"]);
                    }

                    if (dr["TIPODESCUENTOVALE"] != System.DBNull.Value)
                    {
                        retorno.ITIPODESCUENTOVALE = (long)(dr["TIPODESCUENTOVALE"]);
                    }
                    if (dr["MONTOBILLETESID"] != System.DBNull.Value)
                    {
                        retorno.IMONTOBILLETESID = (long)(dr["MONTOBILLETESID"]);
                    }

                    if (dr["PAGOCONTARJETA"] != System.DBNull.Value)
                    {
                        retorno.IPAGOCONTARJETA = (string)(dr["PAGOCONTARJETA"]);
                    }

                    if (dr["COMISIONPAGOTARJETA"] != System.DBNull.Value)
                    {
                        retorno.ICOMISIONPAGOTARJETA = (decimal)(dr["COMISIONPAGOTARJETA"]);
                    }

                    if (dr["TIMBRADOFORMAPAGOSAT"] != System.DBNull.Value)
                    {
                        retorno.ITIMBRADOFORMAPAGOSAT = (string)(dr["TIMBRADOFORMAPAGOSAT"]);
                    }

                    if (dr["VENTAFUTUID"] != System.DBNull.Value)
                    {
                        retorno.IVENTAFUTUID = (long)(dr["VENTAFUTUID"]);
                    }

                    if (dr["RUTAEMBARQUEID"] != System.DBNull.Value)
                    {
                        retorno.IRUTAEMBARQUEID = (long)(dr["RUTAEMBARQUEID"]);
                    }

                    if (dr["ESTADOGUIAID"] != System.DBNull.Value)
                    {
                        retorno.IESTADOGUIAID = (long)(dr["ESTADOGUIAID"]);
                    }

                    if (dr["GUIAID"] != System.DBNull.Value)
                    {
                        retorno.IGUIAID = (long)(dr["GUIAID"]);
                    }


                    if (dr["PAGOBANCOMERAPLICADO"] != System.DBNull.Value)
                    {
                        retorno.IPAGOBANCOMERAPLICADO = (string)(dr["PAGOBANCOMERAPLICADO"]);
                    }

                    if (dr["PAGOACREDITO"] != System.DBNull.Value)
                    {
                        retorno.IPAGOACREDITO = (string)(dr["PAGOACREDITO"]);
                    }


                    if (dr["ORDENCOMPRA"] != System.DBNull.Value)
                    {
                        retorno.IORDENCOMPRA = (string)(dr["ORDENCOMPRA"]);
                    }

                    if (dr["LOTEIMPORTADO"] != System.DBNull.Value)
                    {
                        retorno.ILOTEIMPORTADO = (long)(dr["LOTEIMPORTADO"]);
                    }


                    if (dr["VENDEDOREJECUTIVOID"] != System.DBNull.Value)
                    {
                        retorno.IVENDEDOREJECUTIVOID = (long)(dr["VENDEDOREJECUTIVOID"]);
                    }


                    if (dr["DOCTOPLAZOORIGENID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOPLAZOORIGENID = (long)(dr["DOCTOPLAZOORIGENID"]);
                    }

                    if (dr["DOCTOIMPORTADOID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOIMPORTADOID = (long)(dr["DOCTOIMPORTADOID"]);
                    }
                    if (dr["AUTORIZOALERTAID"] != System.DBNull.Value)
                    {
                        retorno.IAUTORIZOALERTAID = (long)(dr["AUTORIZOALERTAID"]);
                    }
                    if (dr["SAT_USOCFDIID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_USOCFDIID = (long)(dr["SAT_USOCFDIID"]);
                    }
                
                    if (dr["PAGOSAT"] != System.DBNull.Value)
                    {
                        retorno.IPAGOSAT = (long)(dr["PAGOSAT"]);
                    }

                    if (dr["DOCTOSUSTITUTOID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOSUSTITUTOID = (long)(dr["DOCTOSUSTITUTOID"]);
                    }
                    if (dr["DOCTOASUSTITUIRID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOASUSTITUIRID = (long)(dr["DOCTOASUSTITUIRID"]);
                    }
                    if (dr["CFDIID"] != System.DBNull.Value)
                    {
                        retorno.ICFDIID = (long)(dr["CFDIID"]);
                    }
                    if (dr["KITDESGLOSADO"] != System.DBNull.Value)
                    {
                        retorno.IKITDESGLOSADO = (string)(dr["KITDESGLOSADO"]);
                    }
                    if (dr["PLAZOID"] != System.DBNull.Value)
                    {
                        retorno.IPLAZOID = (long)(dr["PLAZOID"]);
                    }
                    if (dr["ESSERVDOMICILIO"] != System.DBNull.Value)
                    {
                        retorno.IESSERVDOMICILIO = (string)(dr["ESSERVDOMICILIO"]);
                    }
                    if (dr["ABONONOAPLICADO"] != System.DBNull.Value)
                    {
                        retorno.IABONONOAPLICADO = (decimal)(dr["ABONONOAPLICADO"]);
                    }
                    if (dr["COMISION"] != System.DBNull.Value)
                    {
                        retorno.ICOMISION = (decimal)(dr["COMISION"]);
                    }

                    if (dr["ESTADOREVISADOID"] != System.DBNull.Value)
                    {
                        retorno.IESTADOREVISADOID = (long)(dr["ESTADOREVISADOID"]);
                    }

                    if (dr["COMISIONPAGOTARJETADEB"] != System.DBNull.Value)
                    {
                        retorno.ICOMISIONPAGOTARJETADEB = (decimal)(dr["COMISIONPAGOTARJETADEB"]);
                    }
                    if (dr["ESTADOREBAJA"] != System.DBNull.Value)
                    {
                        retorno.IESTADOREBAJA = (long)(dr["ESTADOREBAJA"]);
                    }
                    if (dr["TIPODIFERENCIAINVENTARIOID"] != System.DBNull.Value)
                    {
                        retorno.ITIPODIFERENCIAINVENTARIOID = (long)(dr["TIPODIFERENCIAINVENTARIOID"]);
                    }

                    if (dr["UTILIDAD"] != System.DBNull.Value)
                    {
                        retorno.IUTILIDAD = (decimal)(dr["UTILIDAD"]);
                    }

                    if (dr["PAGOVERIFONEAPLICADO"] != System.DBNull.Value)
                    {
                        retorno.IPAGOVERIFONEAPLICADO = (string)(dr["PAGOVERIFONEAPLICADO"]);
                    }

                    if (dr["ESVENTAESPECIAL"] != System.DBNull.Value)
                    {
                        retorno.IESVENTAESPECIAL = (string)(dr["ESVENTAESPECIAL"]);
                    }

                    if (dr["COTI_ENRUTADA"] != System.DBNull.Value)
                    {
                        retorno.ICOTI_ENRUTADA = (string)(dr["COTI_ENRUTADA"]);
                    }

                    if (dr["DOM_ENTREGAID"] != System.DBNull.Value)
                    {
                        retorno.IDOM_ENTREGAID = (long)(dr["DOM_ENTREGAID"]);
                    }
                }
                else
                {
                    retorno = null;
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




        public ArrayList seleccionarDOCTOSIDAFACTURACIONMOVIL(DateTime fecha, FbTransaction st)
        {



            ArrayList retorno = new ArrayList();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select ID from DOCTO where FECHA = @FECHA AND TIPODOCTOID = 21 AND ESTATUSDOCTOID = 1 AND SUBTIPODOCTOID = 15 AND ESFACTURAELECTRONICA = 'S' AND (TIMBRADOUUID IS NULL or TIMBRADOUUID = '') and (FOLIOSAT IS NULL OR FOLIOSAT > -3)";


                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                auxPar.Value = fecha;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                while (dr.Read())
                {
                    if (dr["ID"] != System.DBNull.Value)
                    {
                         retorno.Add((long)(dr["ID"]));
                    }


                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                dr.Close();




                return retorno;
            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public ArrayList seleccionarDOCTOSIDAENVARRECIBOMOVIL(DateTime fecha, FbTransaction st)
        {



            ArrayList retorno = new ArrayList();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select ID from DOCTO where FECHA = @FECHA AND TIPODOCTOID = 21 AND ESTATUSDOCTOID = 1 AND SUBTIPODOCTOID = 15 AND (TRANREGSERVER IS NULL OR TRANREGSERVER <> 'S')";


                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                auxPar.Value = fecha;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                while (dr.Read())
                {
                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno.Add((long)(dr["ID"]));
                    }


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




        public long seleccionarDOCTOFINALAEnviarXFolio(int folio, long tipoDoctoId, FbTransaction st)
        {


            long retorno = 0;

            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;


            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select FIRST 1 COALESCE(F.ID,DOCTO.ID) ID from DOCTO left join DOCTO F ON F.ID = DOCTO.DOCTOREFID AND DOCTO.SUBTIPODOCTOID IN (7,8) where DOCTO.folio = @FOLIO and DOCTO.tipodoctoid = @TIPODOCTOID and DOCTO.ESTATUSDOCTOID = 1";


                auxPar = new FbParameter("@FOLIO", FbDbType.Integer);
                auxPar.Value = folio;
                parts.Add(auxPar);



                auxPar = new FbParameter("@TIPODOCTOID", FbDbType.BigInt);
                auxPar.Value = tipoDoctoId;
                parts.Add(auxPar);



                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {
                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno = (long)(dr["ID"]);
                    }


                }



                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);


                return retorno;
            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return retorno;
            }



        }



        public long seleccionarDOCTOFINALAEnviarXId(long doctoId, long tipoDoctoId, FbTransaction st)
        {


            long retorno = 0;

            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;


            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select FIRST 1 COALESCE(F.ID,DOCTO.ID) ID from DOCTO left join DOCTO F ON F.ID = DOCTO.DOCTOREFID AND DOCTO.SUBTIPODOCTOID IN (7,8) where DOCTO.ID = @DOCTOID and DOCTO.tipodoctoid = @TIPODOCTOID and DOCTO.ESTATUSDOCTOID = 1";


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);



                auxPar = new FbParameter("@TIPODOCTOID", FbDbType.BigInt);
                auxPar.Value = tipoDoctoId;
                parts.Add(auxPar);



                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {
                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno = (long)(dr["ID"]);
                    }


                }



                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);


                return retorno;
            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return retorno;
            }



        }





        public List<long> seleccionarDOCTOPEDIDOMOVILPendiente( FbTransaction st)
        {

            List<long> retornoList = new List<long>();
            

            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;


            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select ID FROM DOCTO WHERE DOCTO.TIPODOCTOID = 331 and DOCTO.ESTATUSDOCTOID = 0";

                


                


                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {
                    long retorno = 0;
                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno = (long)(dr["ID"]);
                    }

                    retornoList.Add(retorno);
                }



                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);


                return retornoList;
            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }


        public string ObtenerClaveSucDestXTIPOYFOLIO(CDOCTOBE oCDOCTO, FbTransaction st)
        {

            string retorno = "";
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select s.clave CLAVE from DOCTO d left join sucursal s on s.id = d.sucursaltid  where folio = @FOLIO and tipodoctoid = @TIPODOCTOID  ";



                auxPar = new FbParameter("@FOLIO", FbDbType.Integer);
                auxPar.Value = oCDOCTO.IFOLIO;
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPODOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.ITIPODOCTOID;
                parts.Add(auxPar);





                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {
                    
                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno = dr["CLAVE"].ToString().Trim();
                    }
                }
                else
                {
                    retorno = "";
                }



                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return retorno;
            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return "";
            }



        }





        [AutoComplete]
        public DataSet enlistarDOCTO()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_DOCTO_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoDOCTO()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_DOCTO_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteDOCTO(CDOCTOBE oCDOCTO, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from DOCTO where

  ID=@ID  
  );";






                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);



                if (dr.Read())
                {
                    retorno = 1;
                }
                else
                {
                    retorno = 0;
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return retorno;
            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return -1;
            }
        }




        public CDOCTOBE AgregarDOCTO(CDOCTOBE oCDOCTO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteDOCTO(oCDOCTO, st);
                if (iRes == 1)
                {
                    this.IComentario = "El DOCTO ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarDOCTOD(oCDOCTO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarDOCTO(CDOCTOBE oCDOCTO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteDOCTO(oCDOCTO, st);
                if (iRes == 0)
                {
                    this.IComentario = "El DOCTO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarDOCTOD(oCDOCTO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarDOCTO(CDOCTOBE oCDOCTONuevo, CDOCTOBE oCDOCTOAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteDOCTO(oCDOCTOAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El DOCTO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarDOCTOD(oCDOCTONuevo, oCDOCTOAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }




        public bool CerrarDOCTOD(CDOCTOBE oCDOCTO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"DOCTO_SAVE";

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


        public bool ReabrirDOCTOD(CDOCTOBE oCDOCTO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"DOCTO_UNSAVE";

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

        public bool CerrarOrdenDeCompraDOCTOD(CDOCTOBE oCDOCTO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"ORDENCOMPRA_SAVE";

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
                        this.iComentario = "Hubo un error " + ((int)arParms[arParms.Length - 1].Value).ToString();
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




        public bool CopiarMovtoOrdenDeCompra(CMOVTOBE movtoBE, long movtoRefId, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@MOVTOREFID", FbDbType.BigInt);
                auxPar.Value = movtoRefId;
                parts.Add(auxPar);
                
                auxPar = new FbParameter("@LOTE", FbDbType.VarChar);
                if(!(bool)movtoBE.isnull["ILOTE"])
                    auxPar.Value = movtoBE.ILOTE;
                else
                    auxPar.Value = DBNull.Value;
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAVENCE", FbDbType.Date);
                if(!(bool)movtoBE.isnull["IFECHAVENCE"])
                    auxPar.Value = movtoBE.IFECHAVENCE;
                else
                    auxPar.Value = DBNull.Value;
                parts.Add(auxPar);
                
                auxPar = new FbParameter("@CANTIDADSURTIDA", FbDbType.Numeric);
                if(!(bool)movtoBE.isnull["ICANTIDADSURTIDA"])
                    auxPar.Value = movtoBE.ICANTIDADSURTIDA;
                else
                    auxPar.Value = DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOTEIMPORTADO", FbDbType.BigInt);
                if (!(bool)movtoBE.isnull["ILOTEIMPORTADO"])
                {
                    auxPar.Value = movtoBE.ILOTEIMPORTADO;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIOMANUAL", FbDbType.Numeric);
                if (!(bool)movtoBE.isnull["IPRECIO"])
                    auxPar.Value = movtoBE.IPRECIO;
                else
                    auxPar.Value = DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"RECEPCIONORDENCOMPRA_COPYMOVTO";

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



        public bool RECEPCIONORDENCOMPRA_RECIMOVTO(CMOVTOBE movtoBE,  FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@MOVTOID", FbDbType.BigInt);
                if (!(bool)movtoBE.isnull["IID"])
                    auxPar.Value = movtoBE.IID;
                else
                    auxPar.Value = DBNull.Value;
                parts.Add(auxPar);

                auxPar = new FbParameter("@LOTE", FbDbType.VarChar);
                if (!(bool)movtoBE.isnull["ILOTE"])
                    auxPar.Value = movtoBE.ILOTE;
                else
                    auxPar.Value = DBNull.Value;
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAVENCE", FbDbType.Date);
                if (!(bool)movtoBE.isnull["IFECHAVENCE"])
                    auxPar.Value = movtoBE.IFECHAVENCE;
                else
                    auxPar.Value = DBNull.Value;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CANTIDADSURTIDA", FbDbType.Numeric);
                if (!(bool)movtoBE.isnull["ICANTIDADSURTIDA"])
                    auxPar.Value = movtoBE.ICANTIDADSURTIDA;
                else
                    auxPar.Value = DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOTEIMPORTADO", FbDbType.BigInt);
                if (!(bool)movtoBE.isnull["ILOTEIMPORTADO"])
                {
                    auxPar.Value = movtoBE.ILOTEIMPORTADO;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIOMANUAL", FbDbType.Numeric);
                if (!(bool)movtoBE.isnull["IPRECIO"])
                    auxPar.Value = movtoBE.IPRECIO;
                else
                    auxPar.Value = DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                if (!(bool)movtoBE.isnull["ICANTIDAD"])
                {
                    auxPar.Value = movtoBE.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPODIFERENCIAINVENTARIOID", FbDbType.BigInt);
                if (!(bool)movtoBE.isnull["ITIPODIFERENCIAINVENTARIOID"])
                {
                    auxPar.Value = movtoBE.ITIPODIFERENCIAINVENTARIOID;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"RECEPCIONORDENCOMPRA_RECIMOVTO";

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


        public bool COMPRA_COMPLETAR(CDOCTOBE oCDOCTO, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);


                  
                auxPar = new FbParameter("@OBSERVACION", FbDbType.VarChar);
                if (!(bool)oCDOCTO.isnull["IOBSERVACION"])
                {
                    auxPar.Value = oCDOCTO.IOBSERVACION;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["IVENDEDORID"])
                {
                    auxPar.Value = oCDOCTO.IVENDEDORID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"COMPRA_COMPLETAR";

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
                        this.iComentario = "Hubo un error " + ((int)arParms[arParms.Length - 1].Value).ToString();
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




        public bool ORDENCOMPRA_COMPLETAR(CDOCTOBE oCDOCTO, bool bMantenerAbierta, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);
                

                auxPar = new FbParameter("@OBSERVACION", FbDbType.VarChar);
                if (!(bool)oCDOCTO.isnull["IOBSERVACION"])
                {
                    auxPar.Value = oCDOCTO.IOBSERVACION;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIAS", FbDbType.VarChar);
                if (!(bool)oCDOCTO.isnull["IREFERENCIAS"])
                {
                    auxPar.Value = oCDOCTO.IREFERENCIAS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["IVENDEDORID"])
                {
                    auxPar.Value = oCDOCTO.IVENDEDORID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MANTENERRESTANTE", FbDbType.VarChar);
                auxPar.Value = bMantenerAbierta ? "S" : "N";
                parts.Add(auxPar);


                auxPar = new FbParameter("@ALMACENID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IALMACENID;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"ORDENCOMPRA_COMPLETAR";

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
                        this.iComentario = "Hubo un error " + ((int)arParms[arParms.Length - 1].Value).ToString();
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





        public bool VENTAFUTUROAPLICAR_COPYMOVTO(ref CMOVTOBE movtoBE, long movtoRefId, long vendedorId, long doctoRefId, ref string sProblemaConExis, FbTransaction st)
        {

            sProblemaConExis = "N";

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@MOVTOREFID", FbDbType.BigInt);
                auxPar.Value = movtoRefId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@LOTE", FbDbType.VarChar);
                if (!(bool)movtoBE.isnull["ILOTE"])
                    auxPar.Value = movtoBE.ILOTE;
                else
                    auxPar.Value = DBNull.Value;
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAVENCE", FbDbType.Date);
                if (!(bool)movtoBE.isnull["IFECHAVENCE"])
                    auxPar.Value = movtoBE.IFECHAVENCE;
                else
                    auxPar.Value = DBNull.Value;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CANTIDADSURTIDA", FbDbType.Numeric);
                if (!(bool)movtoBE.isnull["ICANTIDADSURTIDA"])
                    auxPar.Value = movtoBE.ICANTIDADSURTIDA;
                else
                    auxPar.Value = DBNull.Value;
                parts.Add(auxPar);



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)movtoBE.isnull["IDOCTOID"])
                    auxPar.Value = movtoBE.IDOCTOID;
                else
                    auxPar.Value = DBNull.Value;
                parts.Add(auxPar);




                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = vendedorId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOREFID", FbDbType.BigInt);
                auxPar.Value = doctoRefId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (!(bool)movtoBE.isnull["IPRODUCTOID"])
                    auxPar.Value = movtoBE.IPRODUCTOID;
                else
                    auxPar.Value = DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOTEIMPORTADO", FbDbType.BigInt);
                if (!(bool)movtoBE.isnull["ILOTEIMPORTADO"])
                    auxPar.Value = movtoBE.ILOTEIMPORTADO;
                else
                    auxPar.Value = DBNull.Value;
                parts.Add(auxPar);



                auxPar = new FbParameter("@PROBLEMACONEXIS", FbDbType.VarChar);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@NEWDOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"VENTAFUTUROAPLICAR_COPYMOVTO";

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


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    if ((long)arParms[arParms.Length - 2].Value != 0)
                    {
                        movtoBE.IDOCTOID = (long)arParms[arParms.Length - 2].Value;
                    }
                }


                
                if (!(arParms[arParms.Length - 3].Value == System.DBNull.Value))
                {
                    sProblemaConExis = (string)arParms[arParms.Length - 3].Value;
                }

                

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool VENTAFUTUAPL_PRECOMPLETAR(CDOCTOBE oCDOCTO,  FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);




                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"VENTAFUTUAPL_PRECOMPLETAR";

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
                        this.iComentario = "Hubo un error " + ((int)arParms[arParms.Length - 1].Value).ToString();
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



        public bool VENTAFUTUROAPLICACION_COMPLETAR(CDOCTOBE oCDOCTO, bool bMantenerAbierta, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);



                auxPar = new FbParameter("@OBSERVACION", FbDbType.VarChar);
                if (!(bool)oCDOCTO.isnull["IOBSERVACION"])
                {
                    auxPar.Value = oCDOCTO.IOBSERVACION;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIAS", FbDbType.VarChar);
                if (!(bool)oCDOCTO.isnull["IREFERENCIAS"])
                {
                    auxPar.Value = oCDOCTO.IREFERENCIAS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["IVENDEDORID"])
                {
                    auxPar.Value = oCDOCTO.IVENDEDORID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@MANTENERRESTANTE", FbDbType.VarChar);
                auxPar.Value = bMantenerAbierta ? "S" : "N";
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"VENTAFUTUROAPLICACION_COMPLETAR";

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
                        this.iComentario = "Hubo un error " + ((int)arParms[arParms.Length - 1].Value).ToString();
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


        public bool VENTAFUTUROFINALIZAR(long doctoId, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"VENTAFUTUROFINALIZAR";

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
                        this.iComentario = "Hubo un error " + ((int)arParms[arParms.Length - 1].Value).ToString();
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




        public bool VENTAFUTURO_SALDOANTICIPOS(long doctoId, ref decimal saldoAnticipos, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@SALDOANTICIPOS", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"VENTAFUTURO_SALDOANTICIPOS";

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
                        this.iComentario = "Hubo un error " + ((int)arParms[arParms.Length - 1].Value).ToString();
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    if ((decimal)arParms[arParms.Length - 2].Value != 0)
                    {
                        saldoAnticipos = (decimal)arParms[arParms.Length - 2].Value;
                        
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


        public bool IMPORTAR_SALDOS_CLIENTES(long vendedorId, CSALDOCLIENTEBE saldoCliente, ref long errorCodeS, ref long doctoId, string soloValidar, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@CLIENTECLAVE", FbDbType.VarChar);
                auxPar.Value = saldoCliente.ICLIENTECLAVE;
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRODUCTOCLAVE", FbDbType.VarChar);
                auxPar.Value = saldoCliente.IPRODUCTOCLAVE;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                auxPar.Value = saldoCliente.ICANTIDAD;
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPORTE", FbDbType.Numeric);
                auxPar.Value = saldoCliente.IIMPORTE;
                parts.Add(auxPar);

                auxPar = new FbParameter("@REFERENCIA", FbDbType.VarChar);
                auxPar.Value = saldoCliente.IREFERENCIASISTEMAANT;
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRODUCTODESCRIPCION", FbDbType.VarChar);
                auxPar.Value = saldoCliente.IDESCRIPCION;
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = vendedorId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENCE", FbDbType.Date);
                auxPar.Value = saldoCliente.IFECHAVENCE;
                parts.Add(auxPar);

                auxPar = new FbParameter("@SOLOVALIDAR", FbDbType.VarChar);
                auxPar.Value = soloValidar;
                parts.Add(auxPar);



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"IMPORTAR_SALDOS_CLIENTES";

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
                        this.iComentario = "Hubo un error " + CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), sCadenaConexion, st);// ((int)arParms[arParms.Length - 1].Value).ToString();
                        errorCodeS = (int)arParms[arParms.Length - 1].Value;
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    if ((long)arParms[arParms.Length - 2].Value != 0)
                    {
                        doctoId = (long)arParms[arParms.Length - 2].Value;

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


        public bool IMPORTAR_SALDOS_PROVEEDORES(long vendedorId, CSALDOPROVEEDORBE saldoProveedor, ref long errorCodeS, ref long doctoId, string soloValidar, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@PROVEEDORCLAVE", FbDbType.VarChar);
                auxPar.Value = saldoProveedor.IPROVEEDORCLAVE;
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRODUCTOCLAVE", FbDbType.VarChar);
                auxPar.Value = saldoProveedor.IPRODUCTOCLAVE;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                auxPar.Value = saldoProveedor.ICANTIDAD;
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPORTE", FbDbType.Numeric);
                auxPar.Value = saldoProveedor.IIMPORTE;
                parts.Add(auxPar);

                auxPar = new FbParameter("@REFERENCIA", FbDbType.VarChar);
                auxPar.Value = saldoProveedor.IREFERENCIASISTEMAANT;
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRODUCTODESCRIPCION", FbDbType.VarChar);
                auxPar.Value = saldoProveedor.IDESCRIPCION;
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = vendedorId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENCE", FbDbType.Date);
                auxPar.Value = saldoProveedor.IFECHAVENCE;
                parts.Add(auxPar);

                auxPar = new FbParameter("@SOLOVALIDAR", FbDbType.VarChar);
                auxPar.Value = soloValidar;
                parts.Add(auxPar);



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"IMPORTAR_SALDOS_PROVEEDORES";

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
                        this.iComentario = "Hubo un error " + CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), sCadenaConexion, st);// ((int)arParms[arParms.Length - 1].Value).ToString();
                        errorCodeS = (int)arParms[arParms.Length - 1].Value;
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    if ((long)arParms[arParms.Length - 2].Value != 0)
                    {
                        doctoId = (long)arParms[arParms.Length - 2].Value;

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


        public bool ELIMINAR_BORRADORES_VIEJOS(DateTime date,FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                auxPar.Value = date;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"ELIMINAR_BORRADORES_VIEJOS";

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


        public bool TRASLADO_COMPLETAR(CDOCTOBE oCDOCTO, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@OBSERVACION", FbDbType.VarChar);
                if (!(bool)oCDOCTO.isnull["IOBSERVACION"])
                {
                    auxPar.Value = oCDOCTO.IOBSERVACION;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["IVENDEDORID"])
                {
                    auxPar.Value = oCDOCTO.IVENDEDORID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"TRASPASO_COMPLETAR";

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
                        this.iComentario = "Hubo un error " + ((int)arParms[arParms.Length - 1].Value).ToString();
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





        public bool TRASLADODEVO_COMPLETAR(CDOCTOBE oCDOCTO, ref long  lDoctoNotaCredito, FbTransaction st)
        {
            try
            {

                lDoctoNotaCredito = 0;

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@OBSERVACION", FbDbType.VarChar);
                if (!(bool)oCDOCTO.isnull["IOBSERVACION"])
                {
                    auxPar.Value = oCDOCTO.IOBSERVACION;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["IVENDEDORID"])
                {
                    auxPar.Value = oCDOCTO.IVENDEDORID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOTRASLAID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["IDOCTOIMPORTADOID"])
                {
                    try
                    {

                        auxPar.Value = oCDOCTO.IDOCTOIMPORTADOID;
                    }
                    catch(Exception ex)
                    {
                        auxPar.Value = null;
                    }
                }
                else
                {
                    auxPar.Value = null;
                }

                parts.Add(auxPar);



                auxPar = new FbParameter("@DOCTONOTACREDITOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"TRASPASODEVO_COMPLETAR";

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
                        this.iComentario = "Hubo un error " + ((int)arParms[arParms.Length - 1].Value).ToString();
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    lDoctoNotaCredito = ((long)arParms[arParms.Length - 2].Value);
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool PEDIDODEVO_COMPLETAR(CDOCTOBE oCDOCTO, ref long lDoctoNotaCredito, FbTransaction st)
        {
            try
            {

                lDoctoNotaCredito = 0;

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@OBSERVACION", FbDbType.VarChar);
                if (!(bool)oCDOCTO.isnull["IOBSERVACION"])
                {
                    auxPar.Value = oCDOCTO.IOBSERVACION;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["IVENDEDORID"])
                {
                    auxPar.Value = oCDOCTO.IVENDEDORID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DOCTOTRASLAID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["IDOCTOIMPORTADOID"])
                {
                    try
                    {

                        auxPar.Value = oCDOCTO.IDOCTOIMPORTADOID;
                    }
                    catch (Exception ex)
                    {
                        auxPar.Value = null;
                    }
                }
                else
                {
                    auxPar.Value = null;
                }

                parts.Add(auxPar);



                auxPar = new FbParameter("@DOCTONOTACREDITOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"PEDIDODEVO_COMPLETAR";

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
                        this.iComentario = "Hubo un error " + ((int)arParms[arParms.Length - 1].Value).ToString();
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    lDoctoNotaCredito = ((long)arParms[arParms.Length - 2].Value);
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool MATRIZ_ENVIOPEDIDO_COMPLETAR(CDOCTOBE oCDOCTO, ref long doctoVenta, bool esFacturaElectronica,  FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IVENDEDORID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@OBSERVACION", FbDbType.VarChar);
                if (!(bool)oCDOCTO.isnull["IOBSERVACION"])
                {
                    auxPar.Value = oCDOCTO.IOBSERVACION;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESFACTURAELECTRONICA", FbDbType.VarChar);
                auxPar.Value = esFacturaElectronica ? "S" : "N" ;
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOVENTAID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"MATRIZ_ENVIOPEDIDO_COMPLETAR";

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
                        this.iComentario = "Hubo un error " + strMensajeErr;
                        return false;
                    }
                }

                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    if ((long)arParms[arParms.Length - 2].Value != 0)
                    {
                        doctoVenta = (long)arParms[arParms.Length - 2].Value;
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









        public bool CambiarTranRegServerDOCTOD(CDOCTOBE oCDOCTONuevo,  FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@TRANREGSERVER", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["ITRANREGSERVER"])
                {
                    auxPar.Value = oCDOCTONuevo.ITRANREGSERVER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set
TRANREGSERVER = @TRANREGSERVER
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool CambiarLoteImportadoDOCTOD(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@LOTEIMPORTADO", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["ILOTEIMPORTADO"])
                {
                    auxPar.Value = oCDOCTONuevo.ILOTEIMPORTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set
LOTEIMPORTADO = @LOTEIMPORTADO
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }





        public bool CambiarVendedorEjecutivoDOCTOD(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@VENDEDOREJECUTIVOID", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IVENDEDOREJECUTIVOID"])
                {
                    auxPar.Value = oCDOCTONuevo.IVENDEDOREJECUTIVOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set
VENDEDOREJECUTIVOID = @VENDEDOREJECUTIVOID
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool CambiarVendedorCajeroDOCTOD(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IVENDEDORID"])
                {
                    auxPar.Value = oCDOCTONuevo.IVENDEDORID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set
VENDEDORID = @VENDEDORID
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool CambiarSubTipoDOCTOD(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@SUBTIPODOCTOID", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["ISUBTIPODOCTOID"])
                {
                    auxPar.Value = oCDOCTONuevo.ISUBTIPODOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set
SUBTIPODOCTOID = @SUBTIPODOCTOID
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool CambiarTipoDiferenciaInventario(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@TIPODIFERENCIAINVENTARIOID", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["ITIPODIFERENCIAINVENTARIOID"])
                {
                    auxPar.Value = oCDOCTONuevo.ITIPODIFERENCIAINVENTARIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set
TIPODIFERENCIAINVENTARIOID = @TIPODIFERENCIAINVENTARIOID
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool CambiarDomicilioEntrega(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOM_ENTREGAID", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IDOM_ENTREGAID"])
                {
                    auxPar.Value = oCDOCTONuevo.IDOM_ENTREGAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set
DOM_ENTREGAID = @DOM_ENTREGAID
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool CambiarFOLIOSATDOCTOD(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@FOLIOSAT", FbDbType.Integer);
                if (!(bool)oCDOCTONuevo.isnull["IFOLIOSAT"])
                {
                    auxPar.Value = oCDOCTONuevo.IFOLIOSAT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set
FOLIOSAT = @FOLIOSAT
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool CambiarPENDMAXFECHA(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@PENDMAXFECHA", FbDbType.Date);
                if (!(bool)oCDOCTONuevo.isnull["IPENDMAXFECHA"])
                {
                    auxPar.Value = oCDOCTONuevo.IPENDMAXFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set
PENDMAXFECHA = @PENDMAXFECHA
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool CambiarProcesoSurtidoDOCTOD(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@PROCESOSURTIDO", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["IPROCESOSURTIDO"])
                {
                    auxPar.Value = oCDOCTONuevo.IPROCESOSURTIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set
PROCESOSURTIDO = @PROCESOSURTIDO
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool CambiarESSERVDOMICILIO(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ESSERVDOMICILIO", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["IESSERVDOMICILIO"])
                {
                    auxPar.Value = oCDOCTONuevo.IESSERVDOMICILIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set
ESSERVDOMICILIO = @ESSERVDOMICILIO
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool CambiarESSERVDOMICILIO_DIVIDIDOSPLAZO(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ESSERVDOMICILIO", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["IESSERVDOMICILIO"])
                {
                    auxPar.Value = oCDOCTONuevo.IESSERVDOMICILIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set
ESSERVDOMICILIO = @ESSERVDOMICILIO
  where 
(DOCTO.ID >= @IDAnt) AND(DOCTO.DOCTOPLAZOORIGENID = @IDAnt)
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        


        public bool CambiarKITDESGLOSADODOCTOD(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTONuevo.IID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@KITDESGLOSADO", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["IKITDESGLOSADO"])
                {
                    auxPar.Value = oCDOCTONuevo.IKITDESGLOSADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);




                string commandText = @"INVKIT_CAMBIARDEGLOSADO";

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
                        this.iComentario = "Hubo un error " + arParms[arParms.Length - 1].Value.ToString();
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



        public bool CambiarESTADOSURTIDOID(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@ESTADOSURTIDOID", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IESTADOSURTIDOID"])
                {
                    auxPar.Value = oCDOCTONuevo.IESTADOSURTIDOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
  update  DOCTO
  set
ESTADOSURTIDOID = @ESTADOSURTIDOID
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool CambiarESTATUSDOCTOPEDIDOID(long doctoId, long estatusDoctoPedidoId, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@ESTATUSDOCTOPEDIDOID", FbDbType.BigInt);
                auxPar.Value = estatusDoctoPedidoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);


                string commandText = @"
  update  DOCTO
  set
ESTATUSDOCTOPEDIDOID = @ESTATUSDOCTOPEDIDOID
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool CambiarESTADOREVISADOID(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@ESTADOREVISADOID", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IESTADOREVISADOID"])
                {
                    auxPar.Value = oCDOCTONuevo.IESTADOREVISADOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
  update  DOCTO
  set
ESTADOREVISADOID = @ESTADOREVISADOID
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool CambiarACTIVO(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@ACTIVO", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCDOCTONuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
  update  DOCTO
  set
ACTIVO = @ACTIVO
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool CambiarSupervisorAutorizacionDOCTOD(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@SUPERVISORID", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["ISUPERVISORID"])
                {
                    auxPar.Value = oCDOCTONuevo.ISUPERVISORID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set
SUPERVISORID = @SUPERVISORID
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool CambiarEnviadoFTPDOCTOD(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@TRASLADOAFTP", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["ITRASLADOAFTP"])
                {
                    auxPar.Value = oCDOCTONuevo.ITRASLADOAFTP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set
TRASLADOAFTP = @TRASLADOAFTP
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool CambiarSubtipoDoctoD(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@SUBTIPODOCTOID", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["ISUBTIPODOCTOID"])
                {
                    auxPar.Value = oCDOCTONuevo.ISUBTIPODOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set
SUBTIPODOCTOID = @SUBTIPODOCTOID
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool CambiarSucdestinoD(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@SUCURSALTID", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["ISUCURSALTID"])
                {
                    auxPar.Value = oCDOCTONuevo.ISUCURSALTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set
SUCURSALTID = @SUCURSALTID
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool CambiarAUTORIZOALERTAIDD(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@AUTORIZOALERTAID", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IAUTORIZOALERTAID"])
                {
                    auxPar.Value = oCDOCTONuevo.IAUTORIZOALERTAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set
AUTORIZOALERTAID = @AUTORIZOALERTAID
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool CambiarSAT_USOCFDIIDD(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@SAT_USOCFDIID", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["ISAT_USOCFDIID"])
                {
                    auxPar.Value = oCDOCTONuevo.ISAT_USOCFDIID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set
SAT_USOCFDIID = @SAT_USOCFDIID
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public bool CambiarUsarDatosEntregaDOCTOD(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@USARDATOSENTREGA", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["IUSARDATOSENTREGA"])
                {
                    auxPar.Value = oCDOCTONuevo.IUSARDATOSENTREGA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set
USARDATOSENTREGA = @USARDATOSENTREGA
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }





        public bool CambiarPAGOCONTARJETADOCTOD(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@PAGOCONTARJETA", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["IPAGOCONTARJETA"])
                {
                    auxPar.Value = oCDOCTONuevo.IPAGOCONTARJETA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@COMISIONPAGOTARJETA", FbDbType.Decimal);
                if (!(bool)oCDOCTONuevo.isnull["ICOMISIONPAGOTARJETA"])
                {
                    auxPar.Value = oCDOCTONuevo.ICOMISIONPAGOTARJETA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COMISIONPAGOTARJETADEB", FbDbType.Decimal);
                if (!(bool)oCDOCTONuevo.isnull["ICOMISIONPAGOTARJETADEB"])
                {
                    auxPar.Value = oCDOCTONuevo.ICOMISIONPAGOTARJETADEB;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set
PAGOCONTARJETA = @PAGOCONTARJETA,
COMISIONPAGOTARJETA = @COMISIONPAGOTARJETA,
COMISIONPAGOTARJETADEB = @COMISIONPAGOTARJETADEB
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool CambiarPAGOACREDITO(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@PAGOACREDITO", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["IPAGOACREDITO"])
                {
                    auxPar.Value = oCDOCTONuevo.IPAGOACREDITO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set
PAGOACREDITO = @PAGOACREDITO
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool CambiarMOVILCONTADO(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                

                auxPar = new FbParameter("@MOVILCONTADO", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["IMOVILCONTADO"])
                {
                    auxPar.Value = oCDOCTONuevo.IMOVILCONTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                

                string commandText = @"
  update  DOCTO
  set
MOVILCONTADO = @MOVILCONTADO
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool CambiarESFACTURAELECTRONICA(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@ESFACTURAELECTRONICA", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["IESFACTURAELECTRONICA"])
                {
                    auxPar.Value = oCDOCTONuevo.IESFACTURAELECTRONICA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
  update  DOCTO
  set
ESFACTURAELECTRONICA = @ESFACTURAELECTRONICA
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool CambiarObservaciones(CDOCTOBE oCDOCTONuevo, CDOCTOBE oCDOCTOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@OBSERVACIONES", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["IOBSERVACIONES"])
                {
                    auxPar.Value = oCDOCTONuevo.IOBSERVACIONES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCDOCTOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set OBSERVACIONES = @OBSERVACIONES
  where ID=@IDAnt 
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool CambiarFECHA(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@FECHA", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["IFECHA"])
                {
                    auxPar.Value = oCDOCTONuevo.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set
FECHA = @FECHA
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool CambiarRutaEmbarqueDOCTOD(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@RUTAEMBARQUEID", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IRUTAEMBARQUEID"])
                {
                    auxPar.Value = oCDOCTONuevo.IRUTAEMBARQUEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set
RUTAEMBARQUEID = @RUTAEMBARQUEID
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        
        public bool CambiarRutaEmbarqueDOCTO_DIVIDIDOSPLAZO(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@RUTAEMBARQUEID", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IRUTAEMBARQUEID"])
                {
                    auxPar.Value = oCDOCTONuevo.IRUTAEMBARQUEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set
RUTAEMBARQUEID = @RUTAEMBARQUEID
  where 

(DOCTO.ID >= @IDAnt) AND(DOCTO.DOCTOPLAZOORIGENID = @IDAnt)
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool CambiarPAGOBANCOMERAPLICADO(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@PAGOBANCOMERAPLICADO", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["IPAGOBANCOMERAPLICADO"])
                {
                    auxPar.Value = oCDOCTONuevo.IPAGOBANCOMERAPLICADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
  update  DOCTO
  set
PAGOBANCOMERAPLICADO = @PAGOBANCOMERAPLICADO
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool CambiarPAGOVERIFONEAPLICADO(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@PAGOVERIFONEAPLICADO", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["IPAGOVERIFONEAPLICADO"])
                {
                    auxPar.Value = oCDOCTONuevo.IPAGOVERIFONEAPLICADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
  update  DOCTO
  set
PAGOVERIFONEAPLICADO = @PAGOVERIFONEAPLICADO
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool CambiarESVENTAESPECIAL(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@ESVENTAESPECIAL", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["IESVENTAESPECIAL"])
                {
                    auxPar.Value = oCDOCTONuevo.IESVENTAESPECIAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
  update  DOCTO
  set
ESVENTAESPECIAL = @ESVENTAESPECIAL
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool CambiarCOTI_ENRUTADA(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@COTI_ENRUTADA", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["ICOTI_ENRUTADA"])
                {
                    auxPar.Value = oCDOCTONuevo.ICOTI_ENRUTADA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
  update  DOCTO
  set
COTI_ENRUTADA = @COTI_ENRUTADA
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool CambiarALMACENID(long doctoId, long almacenId, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ALMACENID", FbDbType.BigInt);
                auxPar.Value = almacenId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);




                string commandText = @" update  DOCTO
                                        set ALMACENID = @ALMACENID 
                                        where ID = @DOCTOID ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }





        public bool APLICAR_DESCUENTO_VALEDoctoD(CDOCTOBE oCDOCTO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMEROVALE", FbDbType.VarChar);
                auxPar.Value = oCDOCTO.IREFERENCIAS;
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPODESCUENTOVALE", FbDbType.VarChar);
                auxPar.Value = oCDOCTO.ITIPODESCUENTOVALE;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"APLICAR_DESCUENTO_VALE";

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



        public bool DOCTO_ASIGNAR_FOLIO(CDOCTOBE oCDOCTO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTO_ASIGNAR_FOLIO", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);




                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"DOCTO_ASIGNAR_FOLIO";

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
                        this.iComentario = "Hubo un error " + ((int)arParms[arParms.Length - 1].Value).ToString();
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



        public bool DOCTO_GET_TOTALESUSD(CDOCTOBE oCDOCTO,  ref decimal totalUSD,   FbTransaction st)
        {
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            totalUSD = 0;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);

                string commandText = @"select sum(coalesce(movto.cantidad,0) * coalesce(movto.costoendolar,0))  TOTAL

                                             FROM MOVTO LEFT JOIN PRODUCTO ON MOVTO.PRODUCTOID = PRODUCTO.ID
                                              WHERE MOVTO.DOCTOID = @DOCTOID";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);

               

                if (dr.Read())
                {


                    if (dr["TOTAL"] != System.DBNull.Value)
                    {
                        totalUSD = (decimal)(dr["TOTAL"]);
                    }

                }




                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;

            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool ContieneRecargas(CDOCTOBE oCDOCTO, FbTransaction st)
        {
            bool retorno = false;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);

                string commandText = @"select count(*) cuenta from  movto inner join producto on producto.id = movto.productoid
                                      inner join linea on producto.lineaid = linea.id
         where movto.doctoid = @DOCTOID and (linea.tiporecarga is not null and (linea.tiporecarga = 'SIMPLE' OR linea.tiporecarga = 'MULTIPLE'))";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
                else
                   dr = SqlHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);

                if (dr.Read())
                {
                    retorno = (((int)dr[0])>0)?true:false;
                }



                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return retorno;

            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool ContieneCartaPorte(CDOCTOBE oCDOCTO, FbTransaction st)
        {
            bool retorno = false;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);

                string commandText = @"select count(*)  from  cartaporte where doctoid = @DOCTOID ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);

                if (dr.Read())
                {
                    retorno = (((int)dr[0]) > 0) ? true : false;
                }



                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return retorno;

            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public bool ContieneComprobante(CDOCTOBE oCDOCTO, string tipoComprobante, FbTransaction st)
        {
            bool retorno = false;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOCOMPROBANTE", FbDbType.VarChar);
                auxPar.Value = tipoComprobante;
                parts.Add(auxPar);


                string commandText = @"select count(*)  from  DOCTOCOMPROBANTE where doctoid = @DOCTOID and tipocomprobante = @TIPOCOMPROBANTE ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);

                if (dr.Read())
                {
                    retorno = (((int)dr[0]) > 0) ? true : false;
                }



                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return retorno;

            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool ActualizarClienteDOCTOD(CDOCTOBE oCDOCTO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IPERSONAID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"DOCTO_ACTUALIZAR_CLIENTE";

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




        public bool ASIGNARPEDIMENTO_DOCTO(CDOCTOBE oCDOCTO, bool completarDoctoDeImportacion, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@COMPLETARDOCTO", FbDbType.VarChar);
                auxPar.Value = completarDoctoDeImportacion ? "S" : "N";
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"ASIGNARPEDIMENTO_DOCTO";

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



        public bool DESASIGNARPEDIMENTOTEMP_DOCTO(CDOCTOBE oCDOCTO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"DESASIGNARPEDIMENTOTEMP_DOCTO";

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




        public bool DOCTO_RECALCULAR_DETALLES(CDOCTOBE oCDOCTO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTORECALCULARID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"DOCTO_RECALCULAR_DETALLES";

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




        public bool DOCTO_RECALCULAR_GASTOSADIC(CDOCTOBE oCDOCTO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTORECALCULARID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"DOCTO_RECALCULAR_GASTOSADIC";

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



     


        public bool DOCTO_RECALCULAR_PROMOMONTOMIN(CDOCTOBE oCDOCTO, ref string huboMovimientos, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTORECALCULARID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);



                auxPar = new FbParameter("@HUBOMOVIMIENTOS", FbDbType.VarChar);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);
                

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"DOCTO_RECALCULAR_PROMOMONTOMIN";

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


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    huboMovimientos = (string)arParms[arParms.Length - 2].Value;
                }


                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool LLENAR_FOLIO_FACTURAELECTRONICA(CDOCTOBE oCDOCTO, string tipoComprobante, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOCOMPROBANTE", FbDbType.VarChar);
                auxPar.Value = tipoComprobante;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"LLENAR_FOLIO_FACTURAELECTRONICA";

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
                        this.iComentario = "Hubo un error " + ((int)arParms[arParms.Length - 1].Value).ToString();
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




        public bool RETIRO_INSERTAR(ref CDOCTOBE oCDOCTO, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ALMACENID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IALMACENID;
                parts.Add(auxPar);
                
                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.ISUCURSALID;
                parts.Add(auxPar);
                
                auxPar = new FbParameter("@TIPODOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.ITIPODOCTOID;
                parts.Add(auxPar);
                
                
                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IVENDEDORID;
                parts.Add(auxPar);
                
                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IPERSONAID;
                parts.Add(auxPar);
                
                auxPar = new FbParameter("@CAJAID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.ICAJAID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIA", FbDbType.VarChar);
                if (!(bool)oCDOCTO.isnull["IREFERENCIA"])
                {
                    auxPar.Value = oCDOCTO.IREFERENCIA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                
                auxPar = new FbParameter("@REFERENCIAS", FbDbType.VarChar);
                if (!(bool)oCDOCTO.isnull["IREFERENCIAS"])
                {
                    auxPar.Value = oCDOCTO.IREFERENCIAS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                

                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCDOCTO.isnull["IFECHA"])
                {
                    auxPar.Value = oCDOCTO.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                

                auxPar = new FbParameter("@VENCE", FbDbType.Date);
                if (!(bool)oCDOCTO.isnull["IVENCE"])
                {
                    auxPar.Value = oCDOCTO.IVENCE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                
                auxPar = new FbParameter("@TOTAL", FbDbType.Numeric);
                if (!(bool)oCDOCTO.isnull["ITOTAL"])
                {
                    auxPar.Value = oCDOCTO.ITOTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                
                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"RETIRO_INSERT";

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


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    if ((long)arParms[arParms.Length - 2].Value != 0)
                    {
                        oCDOCTO.IID = (long)arParms[arParms.Length - 2].Value;
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


        public bool FONDEO_INSERT(ref CDOCTOBE oCDOCTO, FbTransaction st)
        {
            try
            {
                ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@ALMACENID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IALMACENID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.ISUCURSALID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPODOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.ITIPODOCTOID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IVENDEDORID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IPERSONAID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAJAID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.ICAJAID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@REFERENCIA", FbDbType.VarChar);
                if (!(bool)oCDOCTO.isnull["IREFERENCIA"])
                {
                    auxPar.Value = oCDOCTO.IREFERENCIA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIAS", FbDbType.VarChar);
                if (!(bool)oCDOCTO.isnull["IREFERENCIAS"])
                {
                    auxPar.Value = oCDOCTO.IREFERENCIAS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCDOCTO.isnull["IFECHA"])
                {
                    auxPar.Value = oCDOCTO.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@VENCE", FbDbType.Date);
                if (!(bool)oCDOCTO.isnull["IVENCE"])
                {
                    auxPar.Value = oCDOCTO.IVENCE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TOTAL", FbDbType.Numeric);
                if (!(bool)oCDOCTO.isnull["ITOTAL"])
                {
                    auxPar.Value = oCDOCTO.ITOTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"FONDEO_INSERT";

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

                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    if ((long)arParms[arParms.Length - 2].Value != 0)
                    {
                        oCDOCTO.IID = (long)arParms[arParms.Length - 2].Value;
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


        public bool DEPOSITO_INSERT(ref CDOCTOBE oCDOCTO, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ALMACENID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IALMACENID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.ISUCURSALID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPODOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.ITIPODOCTOID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IVENDEDORID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IPERSONAID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAJAID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.ICAJAID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIA", FbDbType.VarChar);
                if (!(bool)oCDOCTO.isnull["IREFERENCIA"])
                {
                    auxPar.Value = oCDOCTO.IREFERENCIA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIAS", FbDbType.VarChar);
                if (!(bool)oCDOCTO.isnull["IREFERENCIAS"])
                {
                    auxPar.Value = oCDOCTO.IREFERENCIAS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCDOCTO.isnull["IFECHA"])
                {
                    auxPar.Value = oCDOCTO.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@VENCE", FbDbType.Date);
                if (!(bool)oCDOCTO.isnull["IVENCE"])
                {
                    auxPar.Value = oCDOCTO.IVENCE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TOTAL", FbDbType.Numeric);
                if (!(bool)oCDOCTO.isnull["ITOTAL"])
                {
                    auxPar.Value = oCDOCTO.ITOTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"DEPOSITO_INSERT";

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


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    if ((long)arParms[arParms.Length - 2].Value != 0)
                    {
                        oCDOCTO.IID = (long)arParms[arParms.Length - 2].Value;
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

        public bool FONDEO_CANCEL(CDOCTOBE oCDOCTO, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOCANCELARID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IVENDEDORID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"FONDEO_CANCEL";

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
                        this.iComentario = "Hubo un error " + ((int)arParms[arParms.Length - 1].Value).ToString();
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

        public bool DEPOSITO_CANCEL(CDOCTOBE oCDOCTO, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOCANCELARID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);



                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IVENDEDORID;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"DEPOSITO_CANCEL";

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
                        this.iComentario = "Hubo un error " + ((int)arParms[arParms.Length - 1].Value).ToString();
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





        public bool CambiarMONTOBILLETESIDDOCTOD(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@MONTOBILLETESID", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IMONTOBILLETESID"])
                {
                    auxPar.Value = oCDOCTONuevo.IMONTOBILLETESID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set
MONTOBILLETESID = @MONTOBILLETESID
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }





        public bool GET_DOCTO_MONTOTIPOAPLICACION(long doctoId, ref decimal aplicado, ref decimal pagado, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);


                auxPar = new FirebirdSql.Data.FirebirdClient.FbParameter("@APLICADO", FirebirdSql.Data.FirebirdClient.FbDbType.Numeric, 32, System.Data.ParameterDirection.Output, true, 18, 2, null, System.Data.DataRowVersion.Current, null);
                parts.Add(auxPar);


                auxPar = new FirebirdSql.Data.FirebirdClient.FbParameter("@PAGADO", FirebirdSql.Data.FirebirdClient.FbDbType.Numeric, 32, System.Data.ParameterDirection.Output, true, 18, 2, null, System.Data.DataRowVersion.Current, null);
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"GET_DOCTO_MONTOTIPOAPLICACION";

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

                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    pagado = (decimal)arParms[arParms.Length - 2].Value;
                }
                if (!(arParms[arParms.Length - 3].Value == System.DBNull.Value))
                {
                    aplicado = (decimal)arParms[arParms.Length - 3].Value;
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }





        public bool DOCTO_ASIGNARCLIENTEXSUCURSALT(long doctoId, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"DOCTO_ASIGNARCLIENTEXSUCURSALT";

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




        public bool CambiarDOCTONOTASET(
                long DOCTOID,
                long TIPODOCTONOTAID,
                DateTime FECHAHORA,
                long USUARIOID,
                string NOTA, 
                FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = DOCTOID;
                parts.Add(auxPar);


                auxPar = new FbParameter("TIPODOCTONOTAID", FbDbType.BigInt);
                auxPar.Value = TIPODOCTONOTAID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAHORA", FbDbType.TimeStamp);
                auxPar.Value = FECHAHORA;
                parts.Add(auxPar);

                auxPar = new FbParameter("@USUARIOID", FbDbType.BigInt);
                auxPar.Value = USUARIOID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOTA", FbDbType.VarChar);
                auxPar.Value = NOTA;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"DOCTONOTASET";

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



        public bool ANTICIPODOCTO_INSERTAR(ref CDOCTOBE oCDOCTO, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ALMACENID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IALMACENID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.ISUCURSALID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPODOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.ITIPODOCTOID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IVENDEDORID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IPERSONAID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAJAID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.ICAJAID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIA", FbDbType.VarChar);
                if (!(bool)oCDOCTO.isnull["IREFERENCIA"])
                {
                    auxPar.Value = oCDOCTO.IREFERENCIA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIAS", FbDbType.VarChar);
                if (!(bool)oCDOCTO.isnull["IREFERENCIAS"])
                {
                    auxPar.Value = oCDOCTO.IREFERENCIAS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCDOCTO.isnull["IFECHA"])
                {
                    auxPar.Value = oCDOCTO.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@VENCE", FbDbType.Date);
                if (!(bool)oCDOCTO.isnull["IVENCE"])
                {
                    auxPar.Value = oCDOCTO.IVENCE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@VENTAFUTUID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["IVENTAFUTUID"])
                {
                    auxPar.Value = oCDOCTO.IVENTAFUTUID;
                }
                else
                {
                    auxPar.Value = null;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"ANTICIPODOCTO_INSERT";

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
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), ConexionBD.ConexionString(), st);
                        this.iComentario = "ERROR : " + strMensajeErr;
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    if ((long)arParms[arParms.Length - 2].Value != 0)
                    {
                        oCDOCTO.IID = (long)arParms[arParms.Length - 2].Value;
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





        public bool ActualizarTotalAnticipo(CDOCTOBE oCDOCTONuevo, CDOCTOBE oCDOCTOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCDOCTOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set TOTALANTICIPO = ABONO, ESTATUSANTICIPOID = 0
  where 

ID=@IDAnt and (ESTATUSANTICIPOID IS NULL OR ESTATUSANTICIPOID = 0)
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool CompletarAnticipo(CDOCTOBE oCDOCTONuevo, CDOCTOBE oCDOCTOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@REFERENCIAS", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["IREFERENCIAS"])
                {
                    auxPar.Value = oCDOCTONuevo.IREFERENCIAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCDOCTOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set TOTALANTICIPO = ABONO, ESTATUSANTICIPOID = 1, REFERENCIAS = @REFERENCIAS
  where 

ID=@IDAnt  and (ESTATUSANTICIPOID IS NULL OR ESTATUSANTICIPOID = 0)
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool CancelarAnticipoCliente(CDOCTOBE oCDOCTO, CPERSONABE userBE, ref long doctoIdCancelacion, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOCANCELARID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = userBE.IID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"ANTICIPOCLIENTE_CANCEL_INICIAR";

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
                        this.iComentario = "Hubo un error " + strMensajeErr;
                        return false;
                    }
                }

                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    doctoIdCancelacion = (long)arParms[arParms.Length - 2].Value;
                }



                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool CancelarAnticipoProveedor(CDOCTOBE oCDOCTO, CPERSONABE userBE, ref long doctoIdCancelacion, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOCANCELARID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = userBE.IID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"ANTICIPOPROVE_CANCEL_INICIAR";

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
                        this.iComentario = "Hubo un error " + strMensajeErr;
                        return false;
                    }
                }

                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    doctoIdCancelacion = (long)arParms[arParms.Length - 2].Value;
                }



                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }







        public bool CambiarNotaPago(CDOCTOBE oCDOCTONuevo, CDOCTOBE oCDOCTOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@NOTAPAGO", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["INOTAPAGO"])
                {
                    auxPar.Value = oCDOCTONuevo.INOTAPAGO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCDOCTOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set NOTAPAGO = @NOTAPAGO
  where ID=@IDAnt 
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool CambiarReferencias(CDOCTOBE oCDOCTONuevo, CDOCTOBE oCDOCTOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@REFERENCIAS", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["IREFERENCIAS"])
                {
                    auxPar.Value = oCDOCTONuevo.IREFERENCIAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCDOCTOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set REFERENCIAS = @REFERENCIAS
  where ID=@IDAnt 
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool CambiarPersonaApartadoId(CDOCTOBE oCDOCTONuevo, CDOCTOBE oCDOCTOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@PERSONAAPARTADOID", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IPERSONAAPARTADOID"])
                {
                    auxPar.Value = oCDOCTONuevo.IPERSONAAPARTADOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCDOCTOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set PERSONAAPARTADOID = @PERSONAAPARTADOID
  where ID=@IDAnt 
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool CompletarTraspasoAlmacenDOCTOD(CDOCTOBE oCDOCTO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOCOMPLETARID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"TRASPASOALMACEN_COMPLETAR";

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



        public bool CAMBIARMANEJORECETA(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@MANEJORECETA", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["IMANEJORECETA"])
                {
                    auxPar.Value = oCDOCTONuevo.IMANEJORECETA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set MANEJORECETA = @MANEJORECETA
  where ID=@IDAnt 
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }





        public string GetFranquiciaSucursal(CDOCTOBE oCDOCTO, FbTransaction st)
        {

            string retorno = "";
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"SELECT SUCURSAL.ESFRANQUICIA FROM DOCTO INNER JOIN SUCURSAL ON SUCURSAL.ID = DOCTO.SUCURSALTID WHERE DOCTO.ID = @DOCTOID  ";




                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);





                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["ESFRANQUICIA"] != System.DBNull.Value)
                    {
                        retorno = dr["ESFRANQUICIA"].ToString().Trim();
                    }
                }
                else
                {
                    retorno = "N";
                }


                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);


                return retorno;
            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return "N";
            }



        }



        public bool GetPiezasCajasXDocto(long doctoId, ref decimal cajas, ref decimal piezas, FbTransaction st)
        {


            piezas = 0;
            cajas = 0;

            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"SELECT

        sum(case
            when  producto.unidad = 'KG' then
                 (CASE WHEN (docto.tipodoctoid in  (41)) THEN cast(movto.cantidadsurtida as numeric(18,3)) ELSE cast(movto.cantidad as numeric(18,3)) END )
           
            else
                0.00

        end)  KILOGRAMOS,

        sum(case
            when  producto.unidad = 'KG' then
                 0.00
            when  ( coalesce(producto.pzacaja,0) = 0 or  coalesce(producto.pzacaja,0) = 1 ) then
                 0.00
            else
                trunc(coalesce(     (CASE WHEN (docto.tipodoctoid in  (41)) THEN movto.cantidadsurtida ELSE movto.cantidad END   )   ,0)/coalesce(producto.pzacaja,1))
        end )  CAJAS ,

        sum(case
            when  producto.unidad = 'KG' then
                 0.00
            when  ( coalesce(producto.pzacaja,0) = 0 or  coalesce(producto.pzacaja,0) = 1 ) then
                 (CASE WHEN (docto.tipodoctoid in  (41)) THEN movto.cantidadsurtida ELSE movto.cantidad END )
            else
                mod(coalesce(    (CASE WHEN (docto.tipodoctoid in  (41)) THEN movto.cantidadsurtida ELSE movto.cantidad END )   ,0),coalesce(producto.pzacaja,1))
        end ) PIEZAS





        FROM
        docto
        left join MOVTO on docto.id = movto.doctoid
        left JOIN PRODUCTO ON MOVTO.productoid = PRODUCTO.ID
        left join parametro on 1 = 1



where docto.id = @doctoid ";




                auxPar = new FbParameter("@doctoid", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);





                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["PIEZAS"] != System.DBNull.Value)
                    {
                        piezas = (decimal)dr["PIEZAS"];
                    }

                    if (dr["CAJAS"] != System.DBNull.Value)
                    {
                        cajas = (decimal)dr["CAJAS"];
                    }
                }


                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);


                return true;
            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }



        }






        public decimal GetSumaGastosAdic(CDOCTOBE oCDOCTO, FbTransaction st)
        {

            decimal retorno = 0;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"SELECT SUM(movtogastosadic.monto) - COALESCE(DOCTO.GASTOSADICAPLICADOS,0) MONTO FROM DOCTO INNER JOIN MOVTOGASTOSADIC ON MOVTOGASTOSADIC.DOCTOID = DOCTO.ID WHERE DOCTO.ID = @DOCTOID GROUP BY  COALESCE(DOCTO.GASTOSADICAPLICADOS,0) ";




                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);





                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["MONTO"] != System.DBNull.Value)
                    {
                        retorno = (decimal)(dr["MONTO"]);
                    }
                }
                else
                {
                    retorno = 0;
                }


                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);


                return retorno;
            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return 0;
            }



        }



        public bool TRASPASOSALIDA_COMPLETAR(CDOCTOBE oCDOCTO, ref long doctoVenta, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IVENDEDORID;
                parts.Add(auxPar);



                auxPar = new FbParameter("@DOCTOVENTAID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"TRASPASOSALIDA_COMPLETAR";

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
                        this.iComentario = "Hubo un error " + strMensajeErr;
                        return false;
                    }
                }

                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    if ((long)arParms[arParms.Length - 2].Value != 0)
                    {
                        doctoVenta = (long)arParms[arParms.Length - 2].Value;
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



        public bool TRASPASOSALIDA_CERRARDOCTOD(CDOCTOBE oCDOCTO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"TRASPASOSALIDA_CERRAR";

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




        public bool TRASPASOSALIDA_PRECIERRE(CDOCTOBE oCDOCTO, ref string prepagoHecho, ref string defaultFactura, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);



                auxPar = new FbParameter("@DEFAULTFACTURA", FbDbType.VarChar);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@PREPAGOHECHO", FbDbType.VarChar);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"TRASPASOSALIDA_PRECIERRE";

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

                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    prepagoHecho = arParms[arParms.Length - 2].Value.ToString(); ;

                }

                if (!(arParms[arParms.Length - 3].Value == System.DBNull.Value))
                {
                    defaultFactura = arParms[arParms.Length - 3].Value.ToString(); ;

                }
                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool ENVIOMOVIL_LASTMODIF(CDOCTOBE oCDOCTONuevo, FbTransaction st){


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@OBSERVACION", FbDbType.VarChar,512);
                if (!(bool)oCDOCTONuevo.isnull["IOBSERVACION"])
                {
                    auxPar.Value = oCDOCTONuevo.IOBSERVACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar, 255);
                if (!(bool)oCDOCTONuevo.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCDOCTONuevo.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ORIGENFISCALID", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IORIGENFISCALID"])
                {
                    auxPar.Value = oCDOCTONuevo.IORIGENFISCALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MOVILPLAZOS", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["IMOVILPLAZOS"])
                {
                    auxPar.Value = oCDOCTONuevo.IMOVILPLAZOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MOVILCONTADO", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["IMOVILCONTADO"])
                {
                    auxPar.Value = oCDOCTONuevo.IMOVILCONTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set OBSERVACION = @OBSERVACION,
DESCRIPCION = @DESCRIPCION,
ORIGENFISCALID = @ORIGENFISCALID,
MOVILPLAZOS = @MOVILPLAZOS,
MOVILCONTADO = @MOVILCONTADO
  where ID=@IDAnt 
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }







        public bool ACTUALIZARCANCELACIONENSAT(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@TIMBRADOCANCELADO", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["ITIMBRADOCANCELADO"])
                {
                    auxPar.Value = oCDOCTONuevo.ITIMBRADOCANCELADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIMBRADOFECHACANCELACION", FbDbType.Date);
                if (!(bool)oCDOCTONuevo.isnull["ITIMBRADOFECHACANCELACION"])
                {
                    auxPar.Value = oCDOCTONuevo.ITIMBRADOFECHACANCELACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIMBRADOUUIDCANCELACION", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["ITIMBRADOUUIDCANCELACION"])
                {
                    auxPar.Value = oCDOCTONuevo.ITIMBRADOUUIDCANCELACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
                    update  DOCTO
                        set     TIMBRADOCANCELADO = @TIMBRADOCANCELADO,
                                TIMBRADOFECHACANCELACION = @TIMBRADOFECHACANCELACION,
                                TIMBRADOUUIDCANCELACION = @TIMBRADOUUIDCANCELACION
                                where ID=@IDAnt 
                                ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool ACTUALIZARFECHASAT(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@TIMBRADOFECHAFACTURA", FbDbType.TimeStamp);
                if (!(bool)oCDOCTONuevo.isnull["ITIMBRADOFECHAFACTURA"])
                {
                    auxPar.Value = oCDOCTONuevo.ITIMBRADOFECHAFACTURA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
                    update  DOCTO
                        set     TIMBRADOFECHAFACTURA = @TIMBRADOFECHAFACTURA
                                where ID=@IDAnt 
                                ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool ACTUALIZARESFACTURAELECTRONICAANDUUID(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@ESFACTURAELECTRONICA", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["IESFACTURAELECTRONICA"])
                {
                    auxPar.Value = oCDOCTONuevo.IESFACTURAELECTRONICA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@TIMBRADOUUID", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["ITIMBRADOUUID"])
                {
                    auxPar.Value = oCDOCTONuevo.ITIMBRADOUUID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
                    update  DOCTO
                        set     ESFACTURAELECTRONICA = @ESFACTURAELECTRONICA,
                                TIMBRADOUUID = @TIMBRADOUUID
                                where ID=@IDAnt 
                                ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool ACTUALIZARESFACTURAELECTRONICA(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@ESFACTURAELECTRONICA", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["IESFACTURAELECTRONICA"])
                {
                    auxPar.Value = oCDOCTONuevo.IESFACTURAELECTRONICA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                
                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
                    update  DOCTO
                        set     ESFACTURAELECTRONICA = @ESFACTURAELECTRONICA
                                where ID=@IDAnt 
                                ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public bool ACTUALIZARPERSONAID(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@PERSONAID", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCDOCTONuevo.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
                    update  DOCTO
                        set     PERSONAID = @PERSONAID
                                where ID=@IDAnt 
                                ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool CAMBIARVENCIMIENTO(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@VENCE", FbDbType.Date);
                if (!(bool)oCDOCTONuevo.isnull["IVENCE"])
                {
                    auxPar.Value = oCDOCTONuevo.IVENCE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PLAZO", FbDbType.SmallInt);
                if (!(bool)oCDOCTONuevo.isnull["IPLAZO"])
                {
                    auxPar.Value = oCDOCTONuevo.IPLAZO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
                    update  DOCTO
                        set     VENCE = @VENCE,
                                PLAZO = @PLAZO
                                where ID=@IDAnt 
                                ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool DOCTO_PROMOVER_REBAJA(CDOCTOBE oCDOCTO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOPROMOVERREBAJAID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"DOCTO_PROMOVER_REBAJA";

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






        public bool REBAJA_PREPARANC(ref CDOCTOBE oCDOCTO, long doctoARebajarId, long vendedorId, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOAREBAJARID",  FbDbType.BigInt);
                auxPar.Value = doctoARebajarId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = vendedorId;
                parts.Add(auxPar);



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"REBAJA_PREPARANC";

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
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), ConexionBD.ConexionString(), st);
                        this.iComentario = "ERROR : " + strMensajeErr;
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    if ((long)arParms[arParms.Length - 2].Value != 0)
                    {
                        oCDOCTO.IID = (long)arParms[arParms.Length - 2].Value;
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



        public bool REBAJA_CERRARNC(CDOCTOBE oCDOCTO, long corteId, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                auxPar.Value = corteId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"REBAJA_CERRARNC";

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



        public bool REBAJA_AUTORIZADETALLE(long movtoRefId, long doctoId, decimal cantidad, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@MOVTOREFID", FbDbType.BigInt);
                auxPar.Value = movtoRefId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                auxPar.Value = cantidad;
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"REBAJA_AUTORIZA_DETALLE";

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



        public bool QUITARPENDIENTEREBAJA(long movtoId, long doctoId, decimal cantidad, FbTransaction st)
        {

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;





                auxPar = new FbParameter("@MOVTOREFID", FbDbType.BigInt);
                auxPar.Value = movtoId;
                parts.Add(auxPar);



                auxPar = new FbParameter("@CANTIDAD", FbDbType.BigInt);
                auxPar.Value = cantidad;
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.Decimal);
                auxPar.Value = doctoId;
                parts.Add(auxPar);



                string commandText = @"REBAJA_RECHAZA_DETALLE";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);



                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }





        public bool VENTAMOVIL_ASIGNARPAGOCREDITO( long doctoId, long vendedorId,  FbTransaction st)
        {

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;







                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);



                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = vendedorId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"VENTAMOVIL_ASIGNARPAGOCREDITO";

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
                        this.iComentario = "Hubo un error " + ((int)arParms[arParms.Length - 1].Value).ToString();
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






        public bool PLAZO_DIVIDIRPLAZOSMEZCLADOS(long doctoId, ref long doctoplazoorigenid, FbTransaction st)
        {

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;







                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);



                auxPar = new FbParameter("@DOCTOPLAZOORIGENID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"PLAZO_DIVIDIRPLAZOSMEZCLADOS";

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
                        this.iComentario = "Hubo un error " + ((int)arParms[arParms.Length - 1].Value).ToString();
                        return false;
                    }
                }

                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    doctoplazoorigenid = (long)arParms[arParms.Length - 2].Value;
                }

                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool PLAZO_HAYPLAZOSMEZCLADOS(long doctoId, ref bool hayPlazosMezclados, FbTransaction st)
        {

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);



                auxPar = new FbParameter("@HAYPLAZOSMEZCLADOS", FbDbType.VarChar);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"PLAZO_HAYPLAZOSMEZCLADOS";

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
                        this.iComentario = "Hubo un error " + ((int)arParms[arParms.Length - 1].Value).ToString();
                        return false;
                    }
                }

                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    string strHayPlazosMezclados = arParms[arParms.Length - 2].Value.ToString();
                    hayPlazosMezclados = strHayPlazosMezclados == "S";
                }

                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public bool RECIBOELECTRONICO_GENERAR(long doctoPagoId, long vendedorId, ref long doctoId, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOPAGOID", FbDbType.BigInt);
                auxPar.Value = doctoPagoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = vendedorId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"RECIBOELECTRONICO_GENERAR";

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
                        this.iComentario = "Hubo un error " + ((int)arParms[arParms.Length - 1].Value).ToString();
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    doctoId = (long)arParms[arParms.Length - 2].Value;
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool RECIBOELECTRONICO_GENERAR_33(long doctoPagoId, long vendedorId, ref long doctoId, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOPAGOID", FbDbType.BigInt);
                auxPar.Value = doctoPagoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = vendedorId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"RECIBOELECTRONICO_GENERAR_33";

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
                        this.iComentario = "Hubo un error " + ((int)arParms[arParms.Length - 1].Value).ToString();
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    doctoId = (long)arParms[arParms.Length - 2].Value;
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool RECIBOELECTRONICO_P_GENERAR_33(long pagoId, long vendedorId, ref long doctoId, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOPAGOID", FbDbType.BigInt);
                auxPar.Value = pagoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = vendedorId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"RECIBOELECTRONICO_P_GENERAR_33";

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
                        this.iComentario = "Hubo un error " + ((int)arParms[arParms.Length - 1].Value).ToString();
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    doctoId = (long)arParms[arParms.Length - 2].Value;
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool RECIBOELECTRONICO_CANCELAR(long doctoPagoId, long vendedorId, ref long doctoId, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOPAGOID", FbDbType.BigInt);
                auxPar.Value = doctoPagoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = vendedorId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"RECIBOELECTRONICO_CANCELAR";

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
                        this.iComentario = "Hubo un error " + ((int)arParms[arParms.Length - 1].Value).ToString();
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    doctoId = (long)arParms[arParms.Length - 2].Value;
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool RECIBOELECTRONICO_P_CANCELAR(long pagoId, long vendedorId, ref long doctoId, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@PAGOID", FbDbType.BigInt);
                auxPar.Value = pagoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = vendedorId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"RECIBOELECTRONICO_P_CANCELAR";

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
                        this.iComentario = "Hubo un error " + ((int)arParms[arParms.Length - 1].Value).ToString();
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    doctoId = (long)arParms[arParms.Length - 2].Value;
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool CALCULAR_TIMBRADOFORMAPAGOSAT(CDOCTOBE oCDOCTO, ref string TIMBRADOFORMAPAGOSAT, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);




                auxPar = new FbParameter("@TIMBRADOFORMAPAGOSAT", FbDbType.VarChar);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"CALCULAR_TIMBRADOFORMAPAGOSAT";

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


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    TIMBRADOFORMAPAGOSAT = (string)arParms[arParms.Length - 2].Value;
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }





        public bool DOCTO_INSERT(ref CDOCTOBE oCDOCTO, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCDOCTO.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ALMACENID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["IALMACENID"])
                {
                    auxPar.Value = oCDOCTO.IALMACENID;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["ISUCURSALID"])
                {
                    auxPar.Value = oCDOCTO.ISUCURSALID;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPODOCTOID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["ITIPODOCTOID"])
                {
                    auxPar.Value = oCDOCTO.ITIPODOCTOID;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUSDOCTOID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["IESTATUSDOCTOID"])
                {
                    auxPar.Value = oCDOCTO.IESTATUSDOCTOID;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ESTATUSDOCTOPAGOID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["IESTATUSDOCTOPAGOID"])
                {
                    auxPar.Value = oCDOCTO.IESTATUSDOCTOPAGOID;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCDOCTO.IPERSONAID;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["IVENDEDORID"])
                {
                    auxPar.Value = oCDOCTO.IVENDEDORID;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAJAID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["ICAJAID"])
                {
                    auxPar.Value = oCDOCTO.ICAJAID;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIA", FbDbType.VarChar);
                if (!(bool)oCDOCTO.isnull["IREFERENCIA"])
                {
                    auxPar.Value = oCDOCTO.IREFERENCIA;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIAS", FbDbType.VarChar);
                if (!(bool)oCDOCTO.isnull["IREFERENCIAS"])
                {
                    auxPar.Value = oCDOCTO.IREFERENCIAS;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@SUCURSALTID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["ISUCURSALTID"])
                {
                    auxPar.Value = oCDOCTO.ISUCURSALTID;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ALAMCENTID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["IALMACENTID"])
                {
                    auxPar.Value = oCDOCTO.IALMACENTID;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCDOCTO.isnull["IFECHA"])
                {
                    auxPar.Value = oCDOCTO.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@VENCE", FbDbType.Date);
                if (!(bool)oCDOCTO.isnull["IVENCE"])
                {
                    auxPar.Value = oCDOCTO.IVENCE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DOCTOREFID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["IDOCTOREFID"])
                {
                    auxPar.Value = oCDOCTO.IDOCTOREFID;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);

                


                auxPar = new FbParameter("@MERCANCIAENTREGADA", FbDbType.VarChar);
                if (!(bool)oCDOCTO.isnull["IMERCANCIAENTREGADA"])
                {
                    auxPar.Value = oCDOCTO.IMERCANCIAENTREGADA;
                }
                else
                {
                    auxPar.Value = "S";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ORIGENFISCALID", FbDbType.BigInt);
                if (!(bool)oCDOCTO.isnull["IORIGENFISCALID"])
                {
                    auxPar.Value = oCDOCTO.IORIGENFISCALID;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);

                
     

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"DOCTO_INSERT";

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
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), ConexionBD.ConexionString(), st);
                        this.iComentario = "ERROR : " + strMensajeErr;
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    if ((long)arParms[arParms.Length - 2].Value != 0)
                    {
                        oCDOCTO.IID = (long)arParms[arParms.Length - 2].Value;
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

        public bool CAMBIARORDENCOMPRA(CDOCTOBE oCDOCTONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@ORDENCOMPRA", FbDbType.VarChar);
                if (!(bool)oCDOCTONuevo.isnull["IORDENCOMPRA"])
                {
                    auxPar.Value = oCDOCTONuevo.IORDENCOMPRA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTO
  set ORDENCOMPRA = @ORDENCOMPRA
  where ID=@IDAnt 
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool IMPORTAR_DBFLINE_PAGO(long doctoId, decimal montoTarjeta, decimal montoCredito, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTOTARJETA", FbDbType.Numeric);
                auxPar.Value = montoTarjeta;
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTOCREDITO", FbDbType.Numeric);
                auxPar.Value = montoCredito;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"IMPORTAR_DBFLINE_PAGO";

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


        public bool TRASLADOPROMOCION_AJUSTXFINVIG()
        {

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            try
            {

                fConn.Open();
                fTrans = fConn.BeginTransaction();

                if(!TRASLADOPROMOCION_AJUSTXFINVIG(fTrans))
                {
                    fTrans.Rollback();
                    fConn.Close();
                    return false;
                }

                fTrans.Commit();
            }
            catch
            {
                fConn.Close();
            }
            finally
            {
                fConn.Close();
            }

            return true;
        }

        public bool TRASLADOPROMOCION_AJUSTXFINVIG( FbTransaction st)
        {

            try
            {
                ArrayList parts = new ArrayList();
                FbParameter auxPar;
                

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"TRASLADOPROMOCION_AJUSTXFINVIG";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);




                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {

                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), ConexionBD.ConexionString(), null);
                        this.IComentario = "Hubo un error : " + strMensajeErr;
                        return false;
                    }
                }

                return true;

            }
            catch (Exception e)
            {
                this.IComentario =  e.Message + e.StackTrace;
                return false;
            }

        }



        public bool PAGO_MARCAR_SATPUE_SIAPLICA(long doctoId, ref string REQUIEREAPLICARPAGOS, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@REQUIEREAPLICARPAGOS", FbDbType.VarChar);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"PAGO_MARCAR_SATPUE_SIAPLICA";

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

                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    REQUIEREAPLICARPAGOS = (string)arParms[arParms.Length - 2].Value;
                }
                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool DEVO_REASIGNARCORTEYFECHA(long doctoId, DateTime fecha, long vendedorId, string opcionVendedor, string opcionFecha, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                auxPar.Value = fecha;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = vendedorId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@OPCIONVENDEDOR", FbDbType.VarChar);
                auxPar.Value = opcionVendedor;
                parts.Add(auxPar);

                auxPar = new FbParameter("@OPCIONFECHA", FbDbType.VarChar);
                auxPar.Value = opcionFecha;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"DEVO_REASIGNARCORTEYFECHA";

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




        public bool ASIGNARTOTALESSINVALE_FECHAS(DateTime fechaInicial, DateTime fechaFinal, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@FECHAINICIAL", FbDbType.Date);
                auxPar.Value = fechaInicial;
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAFINAL", FbDbType.Date);
                auxPar.Value = fechaFinal;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"ASIGNARTOTALESSINVALE_FECHAS";

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
                        this.iComentario = "Hubo un error " + ((int)arParms[arParms.Length - 1].Value).ToString();
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


        public bool LIMPIARVENTASPENDIENTES(FbTransaction st)
        {

            try
            {
                ArrayList parts = new ArrayList();
                //FbParameter auxPar;

                string commandText = @"LIMPIARVENTASPENDIENTES";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(ConexionesBD.ConexionBD.ConexionString(), CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);

                return true;

            }
            catch (Exception e)
            {
                iComentario = e.Message + " " + e.StackTrace;
                return false;
            }

        }



        public bool MOVILREBAJA_APROBACION(long movtoId, decimal cantidad, decimal precio, string aprobado, FbTransaction st)
        {

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;





                auxPar = new FbParameter("@MOVTOID", FbDbType.BigInt);
                auxPar.Value = movtoId;
                parts.Add(auxPar);



                auxPar = new FbParameter("@CANTIDADNUEVA", FbDbType.Decimal);
                auxPar.Value = cantidad;
                parts.Add(auxPar);



                auxPar = new FbParameter("@PRECIONUEVO", FbDbType.Decimal);
                auxPar.Value = precio;
                parts.Add(auxPar);


                auxPar = new FbParameter("@APROBADO", FbDbType.VarChar);
                auxPar.Value = aprobado;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"MOVILREBAJA_APROBACION";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);



                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool MOVILREBAJA_PRECMIN_APROBACION(long movtoId, decimal cantidad, decimal precio, string aprobado, long userId, FbTransaction st)
        {

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;





                auxPar = new FbParameter("@MOVTOID", FbDbType.BigInt);
                auxPar.Value = movtoId;
                parts.Add(auxPar);



                auxPar = new FbParameter("@CANTIDADNUEVA", FbDbType.Decimal);
                auxPar.Value = cantidad;
                parts.Add(auxPar);



                auxPar = new FbParameter("@PRECIONUEVO", FbDbType.Decimal);
                auxPar.Value = precio;
                parts.Add(auxPar);


                auxPar = new FbParameter("@APROBADO", FbDbType.VarChar);
                auxPar.Value = aprobado;
                parts.Add(auxPar);




                auxPar = new FbParameter("@USERID", FbDbType.BigInt);
                auxPar.Value = userId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"MOVILREBAJA_PRECMIN_APROBACION";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);



                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool MOVIL_PEDIDO_CAMBIARNOTAS(CDOCTOBE doctoBE, FbTransaction st)
        {

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;





                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoBE.IID;
                parts.Add(auxPar);
                
                auxPar = new FbParameter("@OBSERVACION", FbDbType.VarChar);
                auxPar.Value = doctoBE.IOBSERVACION == null || doctoBE.IOBSERVACION.Trim().Length == 0 ? "" : doctoBE.IOBSERVACION;
                parts.Add(auxPar);

                auxPar = new FbParameter("@MOVILCONTADO", FbDbType.VarChar);
                auxPar.Value = doctoBE.IMOVILCONTADO == null || doctoBE.IMOVILCONTADO.Trim().Length == 0 ? "N" : doctoBE.IMOVILCONTADO;
                parts.Add(auxPar);

                auxPar = new FbParameter("@MOVILPLAZOS", FbDbType.VarChar);
                auxPar.Value = doctoBE.IMOVILPLAZOS == null || doctoBE.IMOVILPLAZOS.Trim().Length == 0 ? "N" : doctoBE.IMOVILPLAZOS;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"MOVIL_PEDIDO_CAMBIARNOTAS";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);



                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public bool MOVILCREDITO_APROBACION(long doctoId, decimal montoAprobado, string aprobado, long usuarioId, FbTransaction st)
        {

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;





                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);

                


                auxPar = new FbParameter("@MONTOAPROBADO", FbDbType.Decimal);
                auxPar.Value = montoAprobado;
                parts.Add(auxPar);


                auxPar = new FbParameter("@APROBADO", FbDbType.VarChar);
                auxPar.Value = aprobado;
                parts.Add(auxPar);


                auxPar = new FbParameter("@USUARIOID", FbDbType.BigInt);
                auxPar.Value = usuarioId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"MOVILCREDITO_APROBACION";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);



                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool MOVILCREDITO_PENDIENTE(long doctoId,  long usuarioId, FbTransaction st)
        {

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;





                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);

                


                auxPar = new FbParameter("@USUARIOID", FbDbType.BigInt);
                auxPar.Value = usuarioId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"MOVILCREDITO_PONERPENDIENTE";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);



                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public CDOCTOD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            
        }
    }
}
