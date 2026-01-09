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

    public class CEMIDAREQUESTD
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

        public CEMIDAREQUESTBE AgregarEMIDAREQUESTD(CEMIDAREQUESTBE oCEMIDAREQUEST, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCEMIDAREQUEST.isnull["IACTIVO"])
                {
                    auxPar.Value = oCEMIDAREQUEST.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCEMIDAREQUEST.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCEMIDAREQUEST.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCEMIDAREQUEST.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCEMIDAREQUEST.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VERSION", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUEST.isnull["IVERSION"])
                {
                    auxPar.Value = oCEMIDAREQUEST.IVERSION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SITEID", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUEST.isnull["ISITEID"])
                {
                    auxPar.Value = oCEMIDAREQUEST.ISITEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLERKID", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUEST.isnull["ICLERKID"])
                {
                    auxPar.Value = oCEMIDAREQUEST.ICLERKID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTID", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUEST.isnull["IPRODUCTID"])
                {
                    auxPar.Value = oCEMIDAREQUEST.IPRODUCTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACCOUNTID", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUEST.isnull["IACCOUNTID"])
                {
                    auxPar.Value = oCEMIDAREQUEST.IACCOUNTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@AMOUNT", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUEST.isnull["IAMOUNT"])
                {
                    auxPar.Value = oCEMIDAREQUEST.IAMOUNT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@INVOICENO", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUEST.isnull["IINVOICENO"])
                {
                    auxPar.Value = oCEMIDAREQUEST.IINVOICENO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LANGUAGEOPTION", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUEST.isnull["ILANGUAGEOPTION"])
                {
                    auxPar.Value = oCEMIDAREQUEST.ILANGUAGEOPTION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESPONSECODE", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUEST.isnull["IRESPONSECODE"])
                {
                    auxPar.Value = oCEMIDAREQUEST.IRESPONSECODE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PIN", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUEST.isnull["IPIN"])
                {
                    auxPar.Value = oCEMIDAREQUEST.IPIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CONTROLNO", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUEST.isnull["ICONTROLNO"])
                {
                    auxPar.Value = oCEMIDAREQUEST.ICONTROLNO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CARRIERCONTROLNO", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUEST.isnull["ICARRIERCONTROLNO"])
                {
                    auxPar.Value = oCEMIDAREQUEST.ICARRIERCONTROLNO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CUSTOMERSERVICENO", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUEST.isnull["ICUSTOMERSERVICENO"])
                {
                    auxPar.Value = oCEMIDAREQUEST.ICUSTOMERSERVICENO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TRANSACTIONDATETIME", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUEST.isnull["ITRANSACTIONDATETIME"])
                {
                    auxPar.Value = oCEMIDAREQUEST.ITRANSACTIONDATETIME;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESULTCODE", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUEST.isnull["IRESULTCODE"])
                {
                    auxPar.Value = oCEMIDAREQUEST.IRESULTCODE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESPONSEMESSAGE", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUEST.isnull["IRESPONSEMESSAGE"])
                {
                    auxPar.Value = oCEMIDAREQUEST.IRESPONSEMESSAGE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TRANSACTIONID", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUEST.isnull["ITRANSACTIONID"])
                {
                    auxPar.Value = oCEMIDAREQUEST.ITRANSACTIONID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@H2HRESULTCODE", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUEST.isnull["IH2HRESULTCODE"])
                {
                    auxPar.Value = oCEMIDAREQUEST.IH2HRESULTCODE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@COMISION", FbDbType.Decimal);
                if (!(bool)oCEMIDAREQUEST.isnull["ICOMISION"])
                {
                    auxPar.Value = oCEMIDAREQUEST.ICOMISION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESSERVICIO", FbDbType.Char);
                if (!(bool)oCEMIDAREQUEST.isnull["IESSERVICIO"])
                {
                    auxPar.Value = oCEMIDAREQUEST.IESSERVICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                /*
                auxPar = new FbParameter("@IDNEW", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);*/


                string commandText = @"
        INSERT INTO EMIDAREQUEST
      (

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

VERSION,

SITEID,

CLERKID,

PRODUCTID,

ACCOUNTID,

AMOUNT,

INVOICENO,

LANGUAGEOPTION,

RESPONSECODE,

PIN,

CONTROLNO,

CARRIERCONTROLNO,

CUSTOMERSERVICENO,

TRANSACTIONDATETIME,

RESULTCODE,

RESPONSEMESSAGE,

TRANSACTIONID,

H2HRESULTCODE,

COMISION,

ESSERVICIO
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@VERSION,

@SITEID,

@CLERKID,

@PRODUCTID,

@ACCOUNTID,

@AMOUNT,

@INVOICENO,

@LANGUAGEOPTION,

@RESPONSECODE,

@PIN,

@CONTROLNO,

@CARRIERCONTROLNO,

@CUSTOMERSERVICENO,

@TRANSACTIONDATETIME,

@RESULTCODE,

@RESPONSEMESSAGE,

@TRANSACTIONID,

@H2HRESULTCODE,

@COMISION,

@ESSERVICIO
) RETURNING ID ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                Object result = null;

                if (st == null)
                    result = SqlHelper.ExecuteScalar(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    result = SqlHelper.ExecuteScalar(st, CommandType.Text, commandText, arParms);


                oCEMIDAREQUEST.IID = (long)result;

                oCEMIDAREQUEST.IACTIVO = "S";

               /* if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    oCEMIDAREQUEST.IID = (long)arParms[arParms.Length - 1].Value;
                }*/



                return oCEMIDAREQUEST;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarEMIDAREQUESTD(CEMIDAREQUESTBE oCEMIDAREQUEST, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCEMIDAREQUEST.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from EMIDAREQUEST
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

        public bool CambiarEMIDAREQUESTD(CEMIDAREQUESTBE oCEMIDAREQUESTNuevo, CEMIDAREQUESTBE oCEMIDAREQUESTAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;





                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCEMIDAREQUESTNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCEMIDAREQUESTNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCEMIDAREQUESTNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCEMIDAREQUESTNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VERSION", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUESTNuevo.isnull["IVERSION"])
                {
                    auxPar.Value = oCEMIDAREQUESTNuevo.IVERSION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SITEID", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUESTNuevo.isnull["ISITEID"])
                {
                    auxPar.Value = oCEMIDAREQUESTNuevo.ISITEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLERKID", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUESTNuevo.isnull["ICLERKID"])
                {
                    auxPar.Value = oCEMIDAREQUESTNuevo.ICLERKID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRODUCTID", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUESTNuevo.isnull["IPRODUCTID"])
                {
                    auxPar.Value = oCEMIDAREQUESTNuevo.IPRODUCTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ACCOUNTID", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUESTNuevo.isnull["IACCOUNTID"])
                {
                    auxPar.Value = oCEMIDAREQUESTNuevo.IACCOUNTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@AMOUNT", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUESTNuevo.isnull["IAMOUNT"])
                {
                    auxPar.Value = oCEMIDAREQUESTNuevo.IAMOUNT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@INVOICENO", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUESTNuevo.isnull["IINVOICENO"])
                {
                    auxPar.Value = oCEMIDAREQUESTNuevo.IINVOICENO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LANGUAGEOPTION", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUESTNuevo.isnull["ILANGUAGEOPTION"])
                {
                    auxPar.Value = oCEMIDAREQUESTNuevo.ILANGUAGEOPTION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@RESPONSECODE", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUESTNuevo.isnull["IRESPONSECODE"])
                {
                    auxPar.Value = oCEMIDAREQUESTNuevo.IRESPONSECODE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PIN", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUESTNuevo.isnull["IPIN"])
                {
                    auxPar.Value = oCEMIDAREQUESTNuevo.IPIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CONTROLNO", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUESTNuevo.isnull["ICONTROLNO"])
                {
                    auxPar.Value = oCEMIDAREQUESTNuevo.ICONTROLNO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CARRIERCONTROLNO", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUESTNuevo.isnull["ICARRIERCONTROLNO"])
                {
                    auxPar.Value = oCEMIDAREQUESTNuevo.ICARRIERCONTROLNO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CUSTOMERSERVICENO", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUESTNuevo.isnull["ICUSTOMERSERVICENO"])
                {
                    auxPar.Value = oCEMIDAREQUESTNuevo.ICUSTOMERSERVICENO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TRANSACTIONDATETIME", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUESTNuevo.isnull["ITRANSACTIONDATETIME"])
                {
                    auxPar.Value = oCEMIDAREQUESTNuevo.ITRANSACTIONDATETIME;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@RESULTCODE", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUESTNuevo.isnull["IRESULTCODE"])
                {
                    auxPar.Value = oCEMIDAREQUESTNuevo.IRESULTCODE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@RESPONSEMESSAGE", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUESTNuevo.isnull["IRESPONSEMESSAGE"])
                {
                    auxPar.Value = oCEMIDAREQUESTNuevo.IRESPONSEMESSAGE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TRANSACTIONID", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUESTNuevo.isnull["ITRANSACTIONID"])
                {
                    auxPar.Value = oCEMIDAREQUESTNuevo.ITRANSACTIONID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@H2HRESULTCODE", FbDbType.VarChar);
                if (!(bool)oCEMIDAREQUESTNuevo.isnull["IH2HRESULTCODE"])
                {
                    auxPar.Value = oCEMIDAREQUESTNuevo.IH2HRESULTCODE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@COMISION", FbDbType.Decimal);
                if (!(bool)oCEMIDAREQUESTNuevo.isnull["ICOMISION"])
                {
                    auxPar.Value = oCEMIDAREQUESTNuevo.ICOMISION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESSERVICIO", FbDbType.Char);
                if (!(bool)oCEMIDAREQUESTNuevo.isnull["IESSERVICIO"])
                {
                    auxPar.Value = oCEMIDAREQUESTNuevo.IESSERVICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCEMIDAREQUESTAnterior.isnull["IID"])
                {
                    auxPar.Value = oCEMIDAREQUESTAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  EMIDAREQUEST
  set

ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

VERSION=@VERSION,

SITEID=@SITEID,

CLERKID=@CLERKID,

PRODUCTID=@PRODUCTID,

ACCOUNTID=@ACCOUNTID,

AMOUNT=@AMOUNT,

INVOICENO=@INVOICENO,

LANGUAGEOPTION=@LANGUAGEOPTION,

RESPONSECODE=@RESPONSECODE,

PIN=@PIN,

CONTROLNO=@CONTROLNO,

CARRIERCONTROLNO=@CARRIERCONTROLNO,

CUSTOMERSERVICENO=@CUSTOMERSERVICENO,

TRANSACTIONDATETIME=@TRANSACTIONDATETIME,

RESULTCODE=@RESULTCODE,

RESPONSEMESSAGE=@RESPONSEMESSAGE,

TRANSACTIONID=@TRANSACTIONID,

H2HRESULTCODE=@H2HRESULTCODE,

COMISION = @COMISION,

ESSERVICIO = @ESSERVICIO
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



        public bool CambiarEMIDAREQUEST_MOVTOID(CEMIDAREQUESTBE oCEMIDAREQUEST, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;





                auxPar = new FbParameter("@MOVTOID", FbDbType.BigInt);
                if (!(bool)oCEMIDAREQUEST.isnull["IMOVTOID"])
                {
                    auxPar.Value = oCEMIDAREQUEST.IMOVTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCEMIDAREQUEST.isnull["IID"])
                {
                    auxPar.Value = oCEMIDAREQUEST.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
                update  EMIDAREQUEST
                set

                    MOVTOID = @MOVTOID
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


        [AutoComplete]
        public CEMIDAREQUESTBE seleccionarEMIDAREQUEST(CEMIDAREQUESTBE oCEMIDAREQUEST, FbTransaction st)
        {




            CEMIDAREQUESTBE retorno = new CEMIDAREQUESTBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from EMIDAREQUEST where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCEMIDAREQUEST.IID;
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

                    if (dr["VERSION"] != System.DBNull.Value)
                    {
                        retorno.IVERSION = (string)(dr["VERSION"]);
                    }

                    if (dr["SITEID"] != System.DBNull.Value)
                    {
                        retorno.ISITEID = (string)(dr["SITEID"]);
                    }

                    if (dr["CLERKID"] != System.DBNull.Value)
                    {
                        retorno.ICLERKID = (string)(dr["CLERKID"]);
                    }

                    if (dr["PRODUCTID"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTID = (string)(dr["PRODUCTID"]);
                    }

                    if (dr["ACCOUNTID"] != System.DBNull.Value)
                    {
                        retorno.IACCOUNTID = (string)(dr["ACCOUNTID"]);
                    }

                    if (dr["AMOUNT"] != System.DBNull.Value)
                    {
                        retorno.IAMOUNT = (string)(dr["AMOUNT"]);
                    }

                    if (dr["INVOICENO"] != System.DBNull.Value)
                    {
                        retorno.IINVOICENO = (string)(dr["INVOICENO"]);
                    }

                    if (dr["LANGUAGEOPTION"] != System.DBNull.Value)
                    {
                        retorno.ILANGUAGEOPTION = (string)(dr["LANGUAGEOPTION"]);
                    }

                    if (dr["RESPONSECODE"] != System.DBNull.Value)
                    {
                        retorno.IRESPONSECODE = (string)(dr["RESPONSECODE"]);
                    }

                    if (dr["PIN"] != System.DBNull.Value)
                    {
                        retorno.IPIN = (string)(dr["PIN"]);
                    }

                    if (dr["CONTROLNO"] != System.DBNull.Value)
                    {
                        retorno.ICONTROLNO = (string)(dr["CONTROLNO"]);
                    }

                    if (dr["CARRIERCONTROLNO"] != System.DBNull.Value)
                    {
                        retorno.ICARRIERCONTROLNO = (string)(dr["CARRIERCONTROLNO"]);
                    }

                    if (dr["CUSTOMERSERVICENO"] != System.DBNull.Value)
                    {
                        retorno.ICUSTOMERSERVICENO = (string)(dr["CUSTOMERSERVICENO"]);
                    }

                    if (dr["TRANSACTIONDATETIME"] != System.DBNull.Value)
                    {
                        retorno.ITRANSACTIONDATETIME = (string)(dr["TRANSACTIONDATETIME"]);
                    }

                    if (dr["RESULTCODE"] != System.DBNull.Value)
                    {
                        retorno.IRESULTCODE = (string)(dr["RESULTCODE"]);
                    }

                    if (dr["RESPONSEMESSAGE"] != System.DBNull.Value)
                    {
                        retorno.IRESPONSEMESSAGE = (string)(dr["RESPONSEMESSAGE"]);
                    }

                    if (dr["TRANSACTIONID"] != System.DBNull.Value)
                    {
                        retorno.ITRANSACTIONID = (string)(dr["TRANSACTIONID"]);
                    }

                    if (dr["H2HRESULTCODE"] != System.DBNull.Value)
                    {
                        retorno.IH2HRESULTCODE = (string)(dr["H2HRESULTCODE"]);
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









        [AutoComplete]
        public DataSet enlistarEMIDAREQUEST()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_EMIDAREQUEST_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoEMIDAREQUEST()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_EMIDAREQUEST_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteEMIDAREQUEST(CEMIDAREQUESTBE oCEMIDAREQUEST, FbTransaction st)
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
                auxPar.Value = oCEMIDAREQUEST.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from EMIDAREQUEST where

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




        public CEMIDAREQUESTBE AgregarEMIDAREQUEST(CEMIDAREQUESTBE oCEMIDAREQUEST, FbTransaction st)
        {
            try
            {
                int iRes = ExisteEMIDAREQUEST(oCEMIDAREQUEST, st);
                if (iRes == 1)
                {
                    this.IComentario = "El EMIDAREQUEST ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarEMIDAREQUESTD(oCEMIDAREQUEST, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarEMIDAREQUEST(CEMIDAREQUESTBE oCEMIDAREQUEST, FbTransaction st)
        {
            try
            {
                int iRes = ExisteEMIDAREQUEST(oCEMIDAREQUEST, st);
                if (iRes == 0)
                {
                    this.IComentario = "El EMIDAREQUEST no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarEMIDAREQUESTD(oCEMIDAREQUEST, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarEMIDAREQUEST(CEMIDAREQUESTBE oCEMIDAREQUESTNuevo, CEMIDAREQUESTBE oCEMIDAREQUESTAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteEMIDAREQUEST(oCEMIDAREQUESTAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El EMIDAREQUEST no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarEMIDAREQUESTD(oCEMIDAREQUESTNuevo, oCEMIDAREQUESTAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CEMIDAREQUESTD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }

        public bool TERMINAL_CONSECUTIVO(string terminal, ref int consecutivo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@TERMINAL", FbDbType.VarChar);
                auxPar.Value = terminal;
                parts.Add(auxPar);



                auxPar = new FbParameter("@CONSECUTIVO", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"TERMINAL_CONSECUTIVO";

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
                        this.iComentario = "Hubo un error" + ((int)arParms[arParms.Length - 1].Value).ToString();
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                        consecutivo = (int)arParms[arParms.Length - 2].Value;
                       
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool TERMINALSERVICIO_CONSECUTIVO(string terminal, ref int consecutivo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@TERMINAL", FbDbType.VarChar);
                auxPar.Value = terminal;
                parts.Add(auxPar);



                auxPar = new FbParameter("@CONSECUTIVO", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"TERMINALSERVICIO_CONSECUTIVO";

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
                        this.iComentario = "Hubo un error" + ((int)arParms[arParms.Length - 1].Value).ToString();
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    consecutivo = (int)arParms[arParms.Length - 2].Value;

                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool EMIDA_GETPRODUCTOMOVTO(int emidaProductId, long userId, ref int productoId, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@EMIDAPRODUCTOID", FbDbType.BigInt);
                auxPar.Value = emidaProductId;
                parts.Add(auxPar);



                auxPar = new FbParameter("@USERID", FbDbType.BigInt);
                auxPar.Value = userId;
                parts.Add(auxPar);



                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"EMIDA_GETPRODUCTOMOVTO";

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
                        this.iComentario = "Hubo un error" + ((int)arParms[arParms.Length - 1].Value).ToString();
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    productoId= int.Parse(((long)arParms[arParms.Length - 2].Value).ToString());

                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

       /* public bool EMIDA_GETPRODUCTOMOVTO(int emidaProductId, int userId, ref int productoId, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@EMIDAPRODUCTOID", FbDbType.BigInt);
                auxPar.Value = emidaProductId;
                parts.Add(auxPar);



                auxPar = new FbParameter("@USERID", FbDbType.BigInt);
                auxPar.Value = userId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"EMIDA_GETPRODUCTOMOVTO";

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
                        this.iComentario = "Hubo un error" + ((int)arParms[arParms.Length - 1].Value).ToString();
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    productoId = (int)arParms[arParms.Length - 2].Value;

                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }*/

        public bool EMIDA_GETPRODUCTOMOVTO(int emidaProductId, int userId, ref int productoId, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@EMIDAPRODUCTOID", FbDbType.BigInt);
                auxPar.Value = emidaProductId;
                parts.Add(auxPar);



                auxPar = new FbParameter("@USERID", FbDbType.BigInt);
                auxPar.Value = userId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"EMIDA_GETPRODUCTOMOVTO";

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
                        this.iComentario = "Hubo un error" + ((int)arParms[arParms.Length - 1].Value).ToString();
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    productoId = (int)arParms[arParms.Length - 2].Value;

                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public bool EMIDA_GENERARVENTA(int emidaProductId, long userId, long clienteId, int productoId, decimal precio, long emidaRequestId, string emidaInvoiceNo, string numeroTelefono, string esServicio, decimal comision, ref int doctoId, ref int movtoId, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@EMIDAPRODUCTOID", FbDbType.BigInt);
                auxPar.Value = emidaProductId;
                parts.Add(auxPar);



                auxPar = new FbParameter("@USERID", FbDbType.BigInt);
                auxPar.Value = userId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLIENTEID", FbDbType.BigInt);
                auxPar.Value = clienteId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                auxPar.Value = productoId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIO", FbDbType.Numeric);
                auxPar.Value = precio;
                parts.Add(auxPar);

                auxPar = new FbParameter("@EMIDAREQUESTID", FbDbType.BigInt);
                auxPar.Value = emidaRequestId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@EMIDAINVOICENO", FbDbType.VarChar);
                auxPar.Value = emidaInvoiceNo;
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMEROTELEFONO", FbDbType.VarChar);
                auxPar.Value = numeroTelefono;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESSERVICIO", FbDbType.VarChar);
                auxPar.Value = esServicio;
                parts.Add(auxPar);


                auxPar = new FbParameter("@COMISION", FbDbType.Decimal);
                auxPar.Value = comision;
                parts.Add(auxPar);

                auxPar = new FbParameter("@MOVTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"EMIDA_GENERARVENTA";

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
                        this.iComentario = "Hubo un error" + ((int)arParms[arParms.Length - 1].Value).ToString();
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    doctoId = int.Parse(((long)arParms[arParms.Length - 2].Value).ToString());

                }


                if (!(arParms[arParms.Length - 3].Value == System.DBNull.Value))
                {
                    movtoId = int.Parse(((long)arParms[arParms.Length - 3].Value).ToString());

                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool EMIDA_VENTASCORTE_INCONCLUSAS(long cajeroId, ref int cuentaInconclusos, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@CAJEROID", FbDbType.BigInt);
                auxPar.Value = cajeroId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CUENTAINCONCLUSOS", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"EMIDA_VENTASCORTE_INCONCLUSAS";

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
                    cuentaInconclusos =  (int)arParms[arParms.Length - 2].Value;
                }


                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }
        


        public CEMIDARESPCODEBE seleccionarEMIDARESPCODE(CEMIDARESPCODEBE oCEMIDAREQUEST, FbTransaction st)
        {




            CEMIDARESPCODEBE retorno = new CEMIDARESPCODEBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from EMIDARESPCODE where
 CODIGO=@CODIGO  ";


                auxPar = new FbParameter("@CODIGO", FbDbType.BigInt);
                auxPar.Value = oCEMIDAREQUEST.ICODIGO;
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

                    if (dr["CODIGO"] != System.DBNull.Value)
                    {
                        retorno.ICODIGO = (int)(dr["CODIGO"]);
                    }

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
                    }

                    if (dr["NOTAS"] != System.DBNull.Value)
                    {
                        retorno.INOTAS = (string)(dr["NOTAS"]);
                    }

                    if (dr["MENSAJECLIENTE"] != System.DBNull.Value)
                    {
                        retorno.IMENSAJECLIENTE = (string)(dr["MENSAJECLIENTE"]);
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
    }
}
