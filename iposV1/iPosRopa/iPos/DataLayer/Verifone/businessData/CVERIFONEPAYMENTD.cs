
using System;
using Microsoft.ApplicationBlocks.Data;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Collections;
using ConexionesBD;
using iPosBusinessEntity;
using System.Collections.Generic;

namespace iPosData
{
    


    public class CVERIFONEPAYMENTD
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


        public CVERIFONEPAYMENTBE AgregarVERIFONEPAYMENTD(CVERIFONEPAYMENTBE oCVERIFONEPAYMENT, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCVERIFONEPAYMENT.isnull["IID"])
                {
                    auxPar.Value = oCVERIFONEPAYMENT.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCVERIFONEPAYMENT.isnull["IACTIVO"])
                {
                    auxPar.Value = oCVERIFONEPAYMENT.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCVERIFONEPAYMENT.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCVERIFONEPAYMENT.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCVERIFONEPAYMENT.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCVERIFONEPAYMENT.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOPAGOID", FbDbType.BigInt);
                if (!(bool)oCVERIFONEPAYMENT.isnull["IDOCTOPAGOID"])
                {
                    auxPar.Value = oCVERIFONEPAYMENT.IDOCTOPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@APPSPECIFICDATA", FbDbType.VarChar);
                if (!(bool)oCVERIFONEPAYMENT.isnull["IAPPSPECIFICDATA"])
                {
                    auxPar.Value = oCVERIFONEPAYMENT.IAPPSPECIFICDATA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@INVOICEID", FbDbType.VarChar);
                if (!(bool)oCVERIFONEPAYMENT.isnull["IINVOICEID"])
                {
                    auxPar.Value = oCVERIFONEPAYMENT.IINVOICEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SESSIONID", FbDbType.VarChar);
                if (!(bool)oCVERIFONEPAYMENT.isnull["ISESSIONID"])
                {
                    auxPar.Value = oCVERIFONEPAYMENT.ISESSIONID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PAYMENTID", FbDbType.VarChar);
                if (!(bool)oCVERIFONEPAYMENT.isnull["IPAYMENTID"])
                {
                    auxPar.Value = oCVERIFONEPAYMENT.IPAYMENTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                


                auxPar = new FbParameter("@MENSAJE", FbDbType.VarChar);
                if (!(bool)oCVERIFONEPAYMENT.isnull["IMENSAJE"])
                {
                    auxPar.Value = oCVERIFONEPAYMENT.IMENSAJE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@STATUS", FbDbType.Integer);
                if (!(bool)oCVERIFONEPAYMENT.isnull["ISTATUS"])
                {
                    auxPar.Value = oCVERIFONEPAYMENT.ISTATUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@OPERACION", FbDbType.VarChar);
                if (!(bool)oCVERIFONEPAYMENT.isnull["IOPERACION"])
                {
                    auxPar.Value = oCVERIFONEPAYMENT.IOPERACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@AUTHCODE", FbDbType.VarChar);
                if (!(bool)oCVERIFONEPAYMENT.isnull["IAUTHCODE"])
                {
                    auxPar.Value = oCVERIFONEPAYMENT.IAUTHCODE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TERMINAL", FbDbType.VarChar);
                if (!(bool)oCVERIFONEPAYMENT.isnull["ITERMINAL"])
                {
                    auxPar.Value = oCVERIFONEPAYMENT.ITERMINAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@AFILIACION", FbDbType.VarChar);
                if (!(bool)oCVERIFONEPAYMENT.isnull["IAFILIACION"])
                {
                    auxPar.Value = oCVERIFONEPAYMENT.IAFILIACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@AID", FbDbType.VarChar);
                if (!(bool)oCVERIFONEPAYMENT.isnull["IAID"])
                {
                    auxPar.Value = oCVERIFONEPAYMENT.IAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CARDBRAND", FbDbType.VarChar);
                if (!(bool)oCVERIFONEPAYMENT.isnull["ICARDBRAND"])
                {
                    auxPar.Value = oCVERIFONEPAYMENT.ICARDBRAND;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CARDTYPE", FbDbType.VarChar);
                if (!(bool)oCVERIFONEPAYMENT.isnull["ICARDTYPE"])
                {
                    auxPar.Value = oCVERIFONEPAYMENT.ICARDTYPE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO", FbDbType.Numeric);
                if (!(bool)oCVERIFONEPAYMENT.isnull["IMONTO"])
                {
                    auxPar.Value = oCVERIFONEPAYMENT.IMONTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCVERIFONEPAYMENT.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCVERIFONEPAYMENT.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOTRANSACCION", FbDbType.VarChar);
                if (!(bool)oCVERIFONEPAYMENT.isnull["ITIPOTRANSACCION"])
                {
                    auxPar.Value = oCVERIFONEPAYMENT.ITIPOTRANSACCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTADOTRANSACCIONID", FbDbType.BigInt);
                if (!(bool)oCVERIFONEPAYMENT.isnull["IESTADOTRANSACCIONID"])
                {
                    auxPar.Value = oCVERIFONEPAYMENT.IESTADOTRANSACCIONID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFID", FbDbType.BigInt);
                if (!(bool)oCVERIFONEPAYMENT.isnull["IREFID"])
                {
                    auxPar.Value = oCVERIFONEPAYMENT.IREFID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO VERIFONEPAYMENT
      (
    
ID,

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

DOCTOPAGOID,

APPSPECIFICDATA,

INVOICEID,

SESSIONID,

PAYMENTID,

MENSAJE,

STATUS,

OPERACION,

AUTHCODE,

TERMINAL,

AFILIACION,

AID,

CARDBRAND,

CARDTYPE,

MONTO,

DOCTOID,

TIPOTRANSACCION,

ESTADOTRANSACCIONID,

REFID
         )

Values (

@ID,

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@DOCTOPAGOID,

@APPSPECIFICDATA,

@INVOICEID,

@SESSIONID,

@PAYMENTID,

@MENSAJE,

@STATUS,

@OPERACION,

@AUTHCODE,

@TERMINAL,

@AFILIACION,

@AID,

@CARDBRAND,

@CARDTYPE,

@MONTO,

@DOCTOID,

@TIPOTRANSACCION,

@ESTADOTRANSACCIONID,

@REFID
)
RETURNING ID ; ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                Object result = null;

                if (st == null)
                    result = SqlHelper.ExecuteScalar(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    result = SqlHelper.ExecuteScalar(st, CommandType.Text, commandText, arParms);


                oCVERIFONEPAYMENT.IID = (long)result;

                oCVERIFONEPAYMENT.IACTIVO = "S";






                return oCVERIFONEPAYMENT;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }

        
        public bool BorrarVERIFONEPAYMENTD(CVERIFONEPAYMENTBE oCVERIFONEPAYMENT, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCVERIFONEPAYMENT.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from VERIFONEPAYMENT
  where

  ID=@ID
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

        
        public bool CambiarVERIFONEPAYMENTD(CVERIFONEPAYMENTBE oCVERIFONEPAYMENTNuevo, CVERIFONEPAYMENTBE oCVERIFONEPAYMENTAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCVERIFONEPAYMENTNuevo.isnull["IID"])
                {
                    auxPar.Value = oCVERIFONEPAYMENTNuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCVERIFONEPAYMENTNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCVERIFONEPAYMENTNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCVERIFONEPAYMENTNuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCVERIFONEPAYMENTNuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCVERIFONEPAYMENTNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCVERIFONEPAYMENTNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOPAGOID", FbDbType.BigInt);
                if (!(bool)oCVERIFONEPAYMENTNuevo.isnull["IDOCTOPAGOID"])
                {
                    auxPar.Value = oCVERIFONEPAYMENTNuevo.IDOCTOPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@APPSPECIFICDATA", FbDbType.VarChar);
                if (!(bool)oCVERIFONEPAYMENTNuevo.isnull["IAPPSPECIFICDATA"])
                {
                    auxPar.Value = oCVERIFONEPAYMENTNuevo.IAPPSPECIFICDATA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@INVOICEID", FbDbType.VarChar);
                if (!(bool)oCVERIFONEPAYMENTNuevo.isnull["IINVOICEID"])
                {
                    auxPar.Value = oCVERIFONEPAYMENTNuevo.IINVOICEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SESSIONID", FbDbType.VarChar);
                if (!(bool)oCVERIFONEPAYMENTNuevo.isnull["ISESSIONID"])
                {
                    auxPar.Value = oCVERIFONEPAYMENTNuevo.ISESSIONID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PAYMENTID", FbDbType.VarChar);
                if (!(bool)oCVERIFONEPAYMENTNuevo.isnull["IPAYMENTID"])
                {
                    auxPar.Value = oCVERIFONEPAYMENTNuevo.IPAYMENTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                

                auxPar = new FbParameter("@MENSAJE", FbDbType.VarChar);
                if (!(bool)oCVERIFONEPAYMENTNuevo.isnull["IMENSAJE"])
                {
                    auxPar.Value = oCVERIFONEPAYMENTNuevo.IMENSAJE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@STATUS", FbDbType.Integer);
                if (!(bool)oCVERIFONEPAYMENTNuevo.isnull["ISTATUS"])
                {
                    auxPar.Value = oCVERIFONEPAYMENTNuevo.ISTATUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@OPERACION", FbDbType.VarChar);
                if (!(bool)oCVERIFONEPAYMENTNuevo.isnull["IOPERACION"])
                {
                    auxPar.Value = oCVERIFONEPAYMENTNuevo.IOPERACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@AUTHCODE", FbDbType.VarChar);
                if (!(bool)oCVERIFONEPAYMENTNuevo.isnull["IAUTHCODE"])
                {
                    auxPar.Value = oCVERIFONEPAYMENTNuevo.IAUTHCODE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TERMINAL", FbDbType.VarChar);
                if (!(bool)oCVERIFONEPAYMENTNuevo.isnull["ITERMINAL"])
                {
                    auxPar.Value = oCVERIFONEPAYMENTNuevo.ITERMINAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@AFILIACION", FbDbType.VarChar);
                if (!(bool)oCVERIFONEPAYMENTNuevo.isnull["IAFILIACION"])
                {
                    auxPar.Value = oCVERIFONEPAYMENTNuevo.IAFILIACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@AID", FbDbType.VarChar);
                if (!(bool)oCVERIFONEPAYMENTNuevo.isnull["IAID"])
                {
                    auxPar.Value = oCVERIFONEPAYMENTNuevo.IAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CARDBRAND", FbDbType.VarChar);
                if (!(bool)oCVERIFONEPAYMENTNuevo.isnull["ICARDBRAND"])
                {
                    auxPar.Value = oCVERIFONEPAYMENTNuevo.ICARDBRAND;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CARDTYPE", FbDbType.VarChar);
                if (!(bool)oCVERIFONEPAYMENTNuevo.isnull["ICARDTYPE"])
                {
                    auxPar.Value = oCVERIFONEPAYMENTNuevo.ICARDTYPE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTO", FbDbType.Numeric);
                if (!(bool)oCVERIFONEPAYMENTNuevo.isnull["IMONTO"])
                {
                    auxPar.Value = oCVERIFONEPAYMENTNuevo.IMONTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCVERIFONEPAYMENTNuevo.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCVERIFONEPAYMENTNuevo.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOTRANSACCION", FbDbType.VarChar);
                if (!(bool)oCVERIFONEPAYMENTNuevo.isnull["ITIPOTRANSACCION"])
                {
                    auxPar.Value = oCVERIFONEPAYMENTNuevo.ITIPOTRANSACCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESTADOTRANSACCIONID", FbDbType.BigInt);
                if (!(bool)oCVERIFONEPAYMENTNuevo.isnull["IESTADOTRANSACCIONID"])
                {
                    auxPar.Value = oCVERIFONEPAYMENTNuevo.IESTADOTRANSACCIONID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@REFID", FbDbType.BigInt);
                if (!(bool)oCVERIFONEPAYMENTNuevo.isnull["IREFID"])
                {
                    auxPar.Value = oCVERIFONEPAYMENTNuevo.IREFID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCVERIFONEPAYMENTAnterior.isnull["IID"])
                {
                    auxPar.Value = oCVERIFONEPAYMENTAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  VERIFONEPAYMENT
  set

ID=@ID,

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

DOCTOPAGOID=@DOCTOPAGOID,

APPSPECIFICDATA=@APPSPECIFICDATA,

INVOICEID=@INVOICEID,

SESSIONID=@SESSIONID,

PAYMENTID=@PAYMENTID,

MENSAJE=@MENSAJE,

STATUS=@STATUS,

OPERACION=@OPERACION,

AUTHCODE=@AUTHCODE,

TERMINAL=@TERMINAL,

AFILIACION=@AFILIACION,

AID=@AID,

CARDBRAND=@CARDBRAND,

CARDTYPE=@CARDTYPE,

MONTO=@MONTO,

DOCTOID=@DOCTOID,

TIPOTRANSACCION=@TIPOTRANSACCION,

ESTADOTRANSACCIONID=@ESTADOTRANSACCIONID,

REFID=@REFID
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


        public bool CambiarVERIFONEPAYMENT_ESTADO_Y_REFID(CVERIFONEPAYMENTBE oCVERIFONEPAYMENTNuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ESTADOTRANSACCIONID", FbDbType.VarChar);
                if (!(bool)oCVERIFONEPAYMENTNuevo.isnull["IESTADOTRANSACCIONID"])
                {
                    auxPar.Value = oCVERIFONEPAYMENTNuevo.IESTADOTRANSACCIONID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@REFID", FbDbType.VarChar);
                if (!(bool)oCVERIFONEPAYMENTNuevo.isnull["IREFID"])
                {
                    auxPar.Value = oCVERIFONEPAYMENTNuevo.IREFID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCVERIFONEPAYMENTNuevo.isnull["IID"])
                {
                    auxPar.Value = oCVERIFONEPAYMENTNuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update VERIFONEPAYMENT
  set
ESTADOTRANSACCIONID = @ESTADOTRANSACCIONID,
REFID = @REFID
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


        public CVERIFONEPAYMENTBE seleccionarVERIFONEPAYMENT(CVERIFONEPAYMENTBE oCVERIFONEPAYMENT, FbTransaction st)
        {




            CVERIFONEPAYMENTBE retorno = new CVERIFONEPAYMENTBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from VERIFONEPAYMENT where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCVERIFONEPAYMENT.IID;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    retorno = ObtenerDeReader(dr);
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



        private CVERIFONEPAYMENTBE ObtenerDeReader(FbDataReader dr)
        {

            CVERIFONEPAYMENTBE retorno = new CVERIFONEPAYMENTBE();

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

            if (dr["DOCTOPAGOID"] != System.DBNull.Value)
            {
                retorno.IDOCTOPAGOID = (long)(dr["DOCTOPAGOID"]);
            }

            if (dr["APPSPECIFICDATA"] != System.DBNull.Value)
            {
                retorno.IAPPSPECIFICDATA = (string)(dr["APPSPECIFICDATA"]);
            }

            if (dr["INVOICEID"] != System.DBNull.Value)
            {
                retorno.IINVOICEID = (string)(dr["INVOICEID"]);
            }

            if (dr["SESSIONID"] != System.DBNull.Value)
            {
                retorno.ISESSIONID = (string)(dr["SESSIONID"]);
            }

            if (dr["PAYMENTID"] != System.DBNull.Value)
            {
                retorno.IPAYMENTID = (string)(dr["PAYMENTID"]);
            }

            if (dr["MENSAJE"] != System.DBNull.Value)
            {
                retorno.IMENSAJE = (string)(dr["MENSAJE"]);
            }

            if (dr["OPERACION"] != System.DBNull.Value)
            {
                retorno.IOPERACION = (string)(dr["OPERACION"]);
            }

            if (dr["AUTHCODE"] != System.DBNull.Value)
            {
                retorno.IAUTHCODE = (string)(dr["AUTHCODE"]);
            }

            if (dr["TERMINAL"] != System.DBNull.Value)
            {
                retorno.ITERMINAL = (string)(dr["TERMINAL"]);
            }

            if (dr["AFILIACION"] != System.DBNull.Value)
            {
                retorno.IAFILIACION = (string)(dr["AFILIACION"]);
            }

            if (dr["AID"] != System.DBNull.Value)
            {
                retorno.IAID = (string)(dr["AID"]);
            }

            if (dr["CARDBRAND"] != System.DBNull.Value)
            {
                retorno.ICARDBRAND = (string)(dr["CARDBRAND"]);
            }

            if (dr["CARDTYPE"] != System.DBNull.Value)
            {
                retorno.ICARDTYPE = (string)(dr["CARDTYPE"]);
            }

            if (dr["MONTO"] != System.DBNull.Value)
            {
                retorno.IMONTO = (decimal)(dr["MONTO"]);
            }

            if (dr["DOCTOID"] != System.DBNull.Value)
            {
                retorno.IDOCTOID = (long)(dr["DOCTOID"]);
            }

            if (dr["TIPOTRANSACCION"] != System.DBNull.Value)
            {
                retorno.ITIPOTRANSACCION = (string)(dr["TIPOTRANSACCION"]);
            }

            if (dr["ESTADOTRANSACCIONID"] != System.DBNull.Value)
            {
                retorno.IESTADOTRANSACCIONID = (long)(dr["ESTADOTRANSACCIONID"]);
            }

            if (dr["REFID"] != System.DBNull.Value)
            {
                retorno.IREFID = (long)(dr["REFID"]);
            }

            if (dr["STATUS"] != System.DBNull.Value)
            {
                retorno.ISTATUS = int.Parse(dr["STATUS"].ToString());
            }

            return retorno;
        }


        public List<CVERIFONEPAYMENTBE> seleccionarVERIFONEPAYMENT_PORDOCTO_Simple(CVERIFONEPAYMENTBE oCVERIFONEPAYMENT, FbTransaction st)
        {



            List<CVERIFONEPAYMENTBE> lista = new List<CVERIFONEPAYMENTBE>();
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from VERIFONEPAYMENT where DOCTOID = @DOCTOID AND ESTADOTRANSACCIONID = @ESTADOTRANSACCIONID AND TIPOTRANSACCION = @TIPOTRANSACCION  ";


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCVERIFONEPAYMENT.IDOCTOID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESTADOTRANSACCIONID", FbDbType.BigInt);
                auxPar.Value = oCVERIFONEPAYMENT.IESTADOTRANSACCIONID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOTRANSACCION", FbDbType.VarChar);
                auxPar.Value = oCVERIFONEPAYMENT.ITIPOTRANSACCION;
                parts.Add(auxPar);



                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                while (dr.Read())
                {
                    CVERIFONEPAYMENTBE buffer = ObtenerDeReader(dr);
                    lista.Add(buffer);
                }




                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return lista;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarVERIFONEPAYMENT()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_VERIFONEPAYMENT_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoVERIFONEPAYMENT()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_VERIFONEPAYMENT_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteVERIFONEPAYMENT(CVERIFONEPAYMENTBE oCVERIFONEPAYMENT, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCVERIFONEPAYMENT.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from VERIFONEPAYMENT where

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




        public CVERIFONEPAYMENTBE AgregarVERIFONEPAYMENT(CVERIFONEPAYMENTBE oCVERIFONEPAYMENT, FbTransaction st)
        {
            try
            {
                int iRes = ExisteVERIFONEPAYMENT(oCVERIFONEPAYMENT, st);
                if (iRes == 1)
                {
                    this.IComentario = "El VERIFONEPAYMENT ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarVERIFONEPAYMENTD(oCVERIFONEPAYMENT, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarVERIFONEPAYMENT(CVERIFONEPAYMENTBE oCVERIFONEPAYMENT, FbTransaction st)
        {
            try
            {
                int iRes = ExisteVERIFONEPAYMENT(oCVERIFONEPAYMENT, st);
                if (iRes == 0)
                {
                    this.IComentario = "El VERIFONEPAYMENT no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarVERIFONEPAYMENTD(oCVERIFONEPAYMENT, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarVERIFONEPAYMENT(CVERIFONEPAYMENTBE oCVERIFONEPAYMENTNuevo, CVERIFONEPAYMENTBE oCVERIFONEPAYMENTAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteVERIFONEPAYMENT(oCVERIFONEPAYMENTAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El VERIFONEPAYMENT no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarVERIFONEPAYMENTD(oCVERIFONEPAYMENTNuevo, oCVERIFONEPAYMENTAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CVERIFONEPAYMENTD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
