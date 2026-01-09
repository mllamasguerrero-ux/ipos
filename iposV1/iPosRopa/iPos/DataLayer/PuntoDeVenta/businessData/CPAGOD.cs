

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



    public class CPAGOD
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


        public CPAGOBE AgregarPAGOD(CPAGOBE oCPAGO, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCPAGO.isnull["IACTIVO"])
                {
                    auxPar.Value = oCPAGO.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPAGO.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCPAGO.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPAGO.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCPAGO.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FORMAPAGOID", FbDbType.BigInt);
                if (!(bool)oCPAGO.isnull["IFORMAPAGOID"])
                {
                    auxPar.Value = oCPAGO.IFORMAPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCPAGO.isnull["IFECHA"])
                {
                    auxPar.Value = oCPAGO.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                if (!(bool)oCPAGO.isnull["ICORTEID"])
                {
                    auxPar.Value = oCPAGO.ICORTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTE", FbDbType.Numeric);
                if (!(bool)oCPAGO.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCPAGO.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTERECIBIDO", FbDbType.Numeric);
                if (!(bool)oCPAGO.isnull["IIMPORTERECIBIDO"])
                {
                    auxPar.Value = oCPAGO.IIMPORTERECIBIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTECAMBIO", FbDbType.Numeric);
                if (!(bool)oCPAGO.isnull["IIMPORTECAMBIO"])
                {
                    auxPar.Value = oCPAGO.IIMPORTECAMBIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOPAGOID", FbDbType.BigInt);
                if (!(bool)oCPAGO.isnull["ITIPOPAGOID"])
                {
                    auxPar.Value = oCPAGO.ITIPOPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESAPARTADO", FbDbType.Char);
                if (!(bool)oCPAGO.isnull["IESAPARTADO"])
                {
                    auxPar.Value = oCPAGO.IESAPARTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOAPLICACIONCREDITOID", FbDbType.BigInt);
                if (!(bool)oCPAGO.isnull["ITIPOAPLICACIONCREDITOID"])
                {
                    auxPar.Value = oCPAGO.ITIPOAPLICACIONCREDITOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@BANCO", FbDbType.BigInt);
                if (!(bool)oCPAGO.isnull["IBANCO"])
                {
                    auxPar.Value = oCPAGO.IBANCO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIABANCARIA", FbDbType.VarChar);
                if (!(bool)oCPAGO.isnull["IREFERENCIABANCARIA"])
                {
                    auxPar.Value = oCPAGO.IREFERENCIABANCARIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOTAS", FbDbType.VarChar);
                if (!(bool)oCPAGO.isnull["INOTAS"])
                {
                    auxPar.Value = oCPAGO.INOTAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAELABORACION", FbDbType.Date);
                if (!(bool)oCPAGO.isnull["IFECHAELABORACION"])
                {
                    auxPar.Value = oCPAGO.IFECHAELABORACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHARECEPCION", FbDbType.Date);
                if (!(bool)oCPAGO.isnull["IFECHARECEPCION"])
                {
                    auxPar.Value = oCPAGO.IFECHARECEPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESPAGOINICIAL", FbDbType.Char);
                if (!(bool)oCPAGO.isnull["IESPAGOINICIAL"])
                {
                    auxPar.Value = oCPAGO.IESPAGOINICIAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOABONOID", FbDbType.BigInt);
                if (!(bool)oCPAGO.isnull["ITIPOABONOID"])
                {
                    auxPar.Value = oCPAGO.ITIPOABONOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PAGOREFID", FbDbType.BigInt);
                if (!(bool)oCPAGO.isnull["IPAGOREFID"])
                {
                    auxPar.Value = oCPAGO.IPAGOREFID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REVERTIDO", FbDbType.Char);
                if (!(bool)oCPAGO.isnull["IREVERTIDO"])
                {
                    auxPar.Value = oCPAGO.IREVERTIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CORTETRANSCANCELADA", FbDbType.BigInt);
                if (!(bool)oCPAGO.isnull["ICORTETRANSCANCELADA"])
                {
                    auxPar.Value = oCPAGO.ICORTETRANSCANCELADA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FORMAPAGOSATID", FbDbType.BigInt);
                if (!(bool)oCPAGO.isnull["IFORMAPAGOSATID"])
                {
                    auxPar.Value = oCPAGO.IFORMAPAGOSATID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FACTCONSID", FbDbType.BigInt);
                if (!(bool)oCPAGO.isnull["IFACTCONSID"])
                {
                    auxPar.Value = oCPAGO.IFACTCONSID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RECIBOELECTRONICOID", FbDbType.BigInt);
                if (!(bool)oCPAGO.isnull["IRECIBOELECTRONICOID"])
                {
                    auxPar.Value = oCPAGO.IRECIBOELECTRONICOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CUENTAPAGOCREDITO", FbDbType.VarChar);
                if (!(bool)oCPAGO.isnull["ICUENTAPAGOCREDITO"])
                {
                    auxPar.Value = oCPAGO.ICUENTAPAGOCREDITO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@BANCOMERPARAMID", FbDbType.BigInt);
                if (!(bool)oCPAGO.isnull["IBANCOMERPARAMID"])
                {
                    auxPar.Value = oCPAGO.IBANCOMERPARAMID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COMISION", FbDbType.Numeric);
                if (!(bool)oCPAGO.isnull["ICOMISION"])
                {
                    auxPar.Value = oCPAGO.ICOMISION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PAGODOCTOSATID", FbDbType.BigInt);
                if (!(bool)oCPAGO.isnull["IPAGODOCTOSATID"])
                {
                    auxPar.Value = oCPAGO.IPAGODOCTOSATID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CUENTABANCOEMPRESAID", FbDbType.BigInt);
                if (!(bool)oCPAGO.isnull["ICUENTABANCOEMPRESAID"])
                {
                    auxPar.Value = oCPAGO.ICUENTABANCOEMPRESAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@APLICADO", FbDbType.VarChar);
                if (!(bool)oCPAGO.isnull["IAPLICADO"])
                {
                    auxPar.Value = oCPAGO.IAPLICADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FECHAAPLICADO", FbDbType.Date);
                if (!(bool)oCPAGO.isnull["IFECHAAPLICADO"])
                {
                    auxPar.Value = oCPAGO.IFECHAAPLICADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUBTIPOPAGOID", FbDbType.BigInt);
                if (!(bool)oCPAGO.isnull["ISUBTIPOPAGOID"])
                {
                    auxPar.Value = oCPAGO.ISUBTIPOPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VERIFONEPAYMENTID", FbDbType.BigInt);
                if (!(bool)oCPAGO.isnull["IVERIFONEPAYMENTID"])
                {
                    auxPar.Value = oCPAGO.IVERIFONEPAYMENTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                string commandText = @"
        INSERT INTO PAGO
      (
    
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

FORMAPAGOID,

FECHA,

CORTEID,

IMPORTE,

IMPORTERECIBIDO,

IMPORTECAMBIO,

TIPOPAGOID,

ESAPARTADO,

TIPOAPLICACIONCREDITOID,

BANCO,

REFERENCIABANCARIA,

NOTAS,

FECHAELABORACION,

FECHARECEPCION,

ESPAGOINICIAL,

TIPOABONOID,

PAGOREFID,

REVERTIDO,

CORTETRANSCANCELADA,

FORMAPAGOSATID,

FACTCONSID,

RECIBOELECTRONICOID,

CUENTAPAGOCREDITO,

BANCOMERPARAMID,

COMISION,

PAGODOCTOSATID,

CUENTABANCOEMPRESAID,

PERSONAID,

APLICADO,

FECHAAPLICADO,

SUBTIPOPAGOID,

VERIFONEPAYMENTID
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@FORMAPAGOID,

@FECHA,

@CORTEID,

@IMPORTE,

@IMPORTERECIBIDO,

@IMPORTECAMBIO,

@TIPOPAGOID,

@ESAPARTADO,

@TIPOAPLICACIONCREDITOID,

@BANCO,

@REFERENCIABANCARIA,

@NOTAS,

@FECHAELABORACION,

@FECHARECEPCION,

@ESPAGOINICIAL,

@TIPOABONOID,

@PAGOREFID,

@REVERTIDO,

@CORTETRANSCANCELADA,

@FORMAPAGOSATID,

@FACTCONSID,

@RECIBOELECTRONICOID,

@CUENTAPAGOCREDITO,

@BANCOMERPARAMID,

@COMISION,

@PAGODOCTOSATID,

@CUENTABANCOEMPRESAID,

@PERSONAID,

@APLICADO,

@FECHAAPLICADO,

@SUBTIPOPAGOID,

@VERIFONEPAYMENTID
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCPAGO;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarPAGOD(CPAGOBE oCPAGO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPAGO.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from PAGO
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


        public bool CambiarPAGOD(CPAGOBE oCPAGONuevo, CPAGOBE oCPAGOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCPAGONuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCPAGONuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPAGONuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCPAGONuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPAGONuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCPAGONuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FORMAPAGOID", FbDbType.BigInt);
                if (!(bool)oCPAGONuevo.isnull["IFORMAPAGOID"])
                {
                    auxPar.Value = oCPAGONuevo.IFORMAPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCPAGONuevo.isnull["IFECHA"])
                {
                    auxPar.Value = oCPAGONuevo.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                if (!(bool)oCPAGONuevo.isnull["ICORTEID"])
                {
                    auxPar.Value = oCPAGONuevo.ICORTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPORTE", FbDbType.Numeric);
                if (!(bool)oCPAGONuevo.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCPAGONuevo.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPORTERECIBIDO", FbDbType.Numeric);
                if (!(bool)oCPAGONuevo.isnull["IIMPORTERECIBIDO"])
                {
                    auxPar.Value = oCPAGONuevo.IIMPORTERECIBIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPORTECAMBIO", FbDbType.Numeric);
                if (!(bool)oCPAGONuevo.isnull["IIMPORTECAMBIO"])
                {
                    auxPar.Value = oCPAGONuevo.IIMPORTECAMBIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOPAGOID", FbDbType.BigInt);
                if (!(bool)oCPAGONuevo.isnull["ITIPOPAGOID"])
                {
                    auxPar.Value = oCPAGONuevo.ITIPOPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESAPARTADO", FbDbType.Char);
                if (!(bool)oCPAGONuevo.isnull["IESAPARTADO"])
                {
                    auxPar.Value = oCPAGONuevo.IESAPARTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOAPLICACIONCREDITOID", FbDbType.BigInt);
                if (!(bool)oCPAGONuevo.isnull["ITIPOAPLICACIONCREDITOID"])
                {
                    auxPar.Value = oCPAGONuevo.ITIPOAPLICACIONCREDITOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@BANCO", FbDbType.BigInt);
                if (!(bool)oCPAGONuevo.isnull["IBANCO"])
                {
                    auxPar.Value = oCPAGONuevo.IBANCO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@REFERENCIABANCARIA", FbDbType.VarChar);
                if (!(bool)oCPAGONuevo.isnull["IREFERENCIABANCARIA"])
                {
                    auxPar.Value = oCPAGONuevo.IREFERENCIABANCARIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOTAS", FbDbType.VarChar);
                if (!(bool)oCPAGONuevo.isnull["INOTAS"])
                {
                    auxPar.Value = oCPAGONuevo.INOTAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAELABORACION", FbDbType.Date);
                if (!(bool)oCPAGONuevo.isnull["IFECHAELABORACION"])
                {
                    auxPar.Value = oCPAGONuevo.IFECHAELABORACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHARECEPCION", FbDbType.Date);
                if (!(bool)oCPAGONuevo.isnull["IFECHARECEPCION"])
                {
                    auxPar.Value = oCPAGONuevo.IFECHARECEPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESPAGOINICIAL", FbDbType.Char);
                if (!(bool)oCPAGONuevo.isnull["IESPAGOINICIAL"])
                {
                    auxPar.Value = oCPAGONuevo.IESPAGOINICIAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOABONOID", FbDbType.BigInt);
                if (!(bool)oCPAGONuevo.isnull["ITIPOABONOID"])
                {
                    auxPar.Value = oCPAGONuevo.ITIPOABONOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PAGOREFID", FbDbType.BigInt);
                if (!(bool)oCPAGONuevo.isnull["IPAGOREFID"])
                {
                    auxPar.Value = oCPAGONuevo.IPAGOREFID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@REVERTIDO", FbDbType.Char);
                if (!(bool)oCPAGONuevo.isnull["IREVERTIDO"])
                {
                    auxPar.Value = oCPAGONuevo.IREVERTIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CORTETRANSCANCELADA", FbDbType.BigInt);
                if (!(bool)oCPAGONuevo.isnull["ICORTETRANSCANCELADA"])
                {
                    auxPar.Value = oCPAGONuevo.ICORTETRANSCANCELADA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FORMAPAGOSATID", FbDbType.BigInt);
                if (!(bool)oCPAGONuevo.isnull["IFORMAPAGOSATID"])
                {
                    auxPar.Value = oCPAGONuevo.IFORMAPAGOSATID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FACTCONSID", FbDbType.BigInt);
                if (!(bool)oCPAGONuevo.isnull["IFACTCONSID"])
                {
                    auxPar.Value = oCPAGONuevo.IFACTCONSID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@RECIBOELECTRONICOID", FbDbType.BigInt);
                if (!(bool)oCPAGONuevo.isnull["IRECIBOELECTRONICOID"])
                {
                    auxPar.Value = oCPAGONuevo.IRECIBOELECTRONICOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CUENTAPAGOCREDITO", FbDbType.VarChar);
                if (!(bool)oCPAGONuevo.isnull["ICUENTAPAGOCREDITO"])
                {
                    auxPar.Value = oCPAGONuevo.ICUENTAPAGOCREDITO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@BANCOMERPARAMID", FbDbType.BigInt);
                if (!(bool)oCPAGONuevo.isnull["IBANCOMERPARAMID"])
                {
                    auxPar.Value = oCPAGONuevo.IBANCOMERPARAMID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@COMISION", FbDbType.Numeric);
                if (!(bool)oCPAGONuevo.isnull["ICOMISION"])
                {
                    auxPar.Value = oCPAGONuevo.ICOMISION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PAGODOCTOSATID", FbDbType.BigInt);
                if (!(bool)oCPAGONuevo.isnull["IPAGODOCTOSATID"])
                {
                    auxPar.Value = oCPAGONuevo.IPAGODOCTOSATID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CUENTABANCOEMPRESAID", FbDbType.BigInt);
                if (!(bool)oCPAGONuevo.isnull["ICUENTABANCOEMPRESAID"])
                {
                    auxPar.Value = oCPAGONuevo.ICUENTABANCOEMPRESAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCPAGONuevo.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCPAGONuevo.IPERSONAID;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@APLICADO", FbDbType.VarChar);
                if (!(bool)oCPAGONuevo.isnull["IAPLICADO"])
                {
                    auxPar.Value = oCPAGONuevo.IAPLICADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FECHAAPLICADO", FbDbType.Date);
                if (!(bool)oCPAGONuevo.isnull["IFECHAAPLICADO"])
                {
                    auxPar.Value = oCPAGONuevo.IFECHAAPLICADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@SUBTIPOPAGOID", FbDbType.BigInt);
                if (!(bool)oCPAGONuevo.isnull["ISUBTIPOPAGOID"])
                {
                    auxPar.Value = oCPAGONuevo.ISUBTIPOPAGOID;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@VERIFONEPAYMENTID", FbDbType.BigInt);
                if (!(bool)oCPAGONuevo.isnull["IVERIFONEPAYMENTID"])
                {
                    auxPar.Value = oCPAGONuevo.IVERIFONEPAYMENTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCPAGOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCPAGOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  PAGO
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

FORMAPAGOID=@FORMAPAGOID,

FECHA=@FECHA,

CORTEID=@CORTEID,

IMPORTE=@IMPORTE,

IMPORTERECIBIDO=@IMPORTERECIBIDO,

IMPORTECAMBIO=@IMPORTECAMBIO,

TIPOPAGOID=@TIPOPAGOID,

ESAPARTADO=@ESAPARTADO,

TIPOAPLICACIONCREDITOID=@TIPOAPLICACIONCREDITOID,

BANCO=@BANCO,

REFERENCIABANCARIA=@REFERENCIABANCARIA,

NOTAS=@NOTAS,

FECHAELABORACION=@FECHAELABORACION,

FECHARECEPCION=@FECHARECEPCION,

ESPAGOINICIAL=@ESPAGOINICIAL,

TIPOABONOID=@TIPOABONOID,

PAGOREFID=@PAGOREFID,

REVERTIDO=@REVERTIDO,

CORTETRANSCANCELADA=@CORTETRANSCANCELADA,

FORMAPAGOSATID=@FORMAPAGOSATID,

FACTCONSID=@FACTCONSID,

RECIBOELECTRONICOID=@RECIBOELECTRONICOID,

CUENTAPAGOCREDITO=@CUENTAPAGOCREDITO,

BANCOMERPARAMID=@BANCOMERPARAMID,

COMISION=@COMISION,

PAGODOCTOSATID=@PAGODOCTOSATID,

CUENTABANCOEMPRESAID = @CUENTABANCOEMPRESAID,

PERSONAID = @PERSONAID,

APLICADO = @APLICADO,

FECHAAPLICADO = @FECHAAPLICADO,

SUBTIPOPAGOID = @SUBTIPOPAGOID,

VERIFONEPAYMENTID = @VERIFONEPAYMENTID


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

        public CPAGOBE seleccionarPAGO(CPAGOBE oCPAGO, FbTransaction st)
        {
            CPAGOBE retorno = new CPAGOBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from PAGO where ID=@ID  ";

                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPAGO.IID;
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

                    if (dr["FORMAPAGOID"] != System.DBNull.Value)
                    {
                        retorno.IFORMAPAGOID = (long)(dr["FORMAPAGOID"]);
                    }

                    if (dr["FECHA"] != System.DBNull.Value)
                    {
                        retorno.IFECHA = (DateTime)(dr["FECHA"]);
                    }

                    if (dr["FECHAHORA"] != System.DBNull.Value)
                    {
                        retorno.IFECHAHORA = (object)(dr["FECHAHORA"]);
                    }

                    if (dr["CORTEID"] != System.DBNull.Value)
                    {
                        retorno.ICORTEID = (long)(dr["CORTEID"]);
                    }

                    if (dr["IMPORTE"] != System.DBNull.Value)
                    {
                        retorno.IIMPORTE = (decimal)(dr["IMPORTE"]);
                    }

                    if (dr["IMPORTERECIBIDO"] != System.DBNull.Value)
                    {
                        retorno.IIMPORTERECIBIDO = (decimal)(dr["IMPORTERECIBIDO"]);
                    }

                    if (dr["IMPORTECAMBIO"] != System.DBNull.Value)
                    {
                        retorno.IIMPORTECAMBIO = (decimal)(dr["IMPORTECAMBIO"]);
                    }

                    if (dr["TIPOPAGOID"] != System.DBNull.Value)
                    {
                        retorno.ITIPOPAGOID = (long)(dr["TIPOPAGOID"]);
                    }

                    if (dr["ESAPARTADO"] != System.DBNull.Value)
                    {
                        retorno.IESAPARTADO = (string)(dr["ESAPARTADO"]);
                    }

                    if (dr["TIPOAPLICACIONCREDITOID"] != System.DBNull.Value)
                    {
                        retorno.ITIPOAPLICACIONCREDITOID = (long)(dr["TIPOAPLICACIONCREDITOID"]);
                    }

                    if (dr["BANCO"] != System.DBNull.Value)
                    {
                        retorno.IBANCO = (long)(dr["BANCO"]);
                    }

                    if (dr["REFERENCIABANCARIA"] != System.DBNull.Value)
                    {
                        retorno.IREFERENCIABANCARIA = (string)(dr["REFERENCIABANCARIA"]);
                    }

                    if (dr["NOTAS"] != System.DBNull.Value)
                    {
                        retorno.INOTAS = (string)(dr["NOTAS"]);
                    }

                    if (dr["FECHAELABORACION"] != System.DBNull.Value)
                    {
                        retorno.IFECHAELABORACION = (DateTime)(dr["FECHAELABORACION"]);
                    }

                    if (dr["FECHARECEPCION"] != System.DBNull.Value)
                    {
                        retorno.IFECHARECEPCION = (DateTime)(dr["FECHARECEPCION"]);
                    }

                    if (dr["ESPAGOINICIAL"] != System.DBNull.Value)
                    {
                        retorno.IESPAGOINICIAL = (string)(dr["ESPAGOINICIAL"]);
                    }

                    if (dr["TIPOABONOID"] != System.DBNull.Value)
                    {
                        retorno.ITIPOABONOID = (long)(dr["TIPOABONOID"]);
                    }

                    if (dr["PAGOREFID"] != System.DBNull.Value)
                    {
                        retorno.IPAGOREFID = (long)(dr["PAGOREFID"]);
                    }

                    if (dr["REVERTIDO"] != System.DBNull.Value)
                    {
                        retorno.IREVERTIDO = (string)(dr["REVERTIDO"]);
                    }

                    if (dr["CORTETRANSCANCELADA"] != System.DBNull.Value)
                    {
                        retorno.ICORTETRANSCANCELADA = (long)(dr["CORTETRANSCANCELADA"]);
                    }

                    if (dr["FORMAPAGOSATID"] != System.DBNull.Value)
                    {
                        retorno.IFORMAPAGOSATID = (long)(dr["FORMAPAGOSATID"]);
                    }

                    if (dr["FACTCONSID"] != System.DBNull.Value)
                    {
                        retorno.IFACTCONSID = (long)(dr["FACTCONSID"]);
                    }

                    if (dr["RECIBOELECTRONICOID"] != System.DBNull.Value)
                    {
                        retorno.IRECIBOELECTRONICOID = (long)(dr["RECIBOELECTRONICOID"]);
                    }

                    if (dr["CUENTAPAGOCREDITO"] != System.DBNull.Value)
                    {
                        retorno.ICUENTAPAGOCREDITO = (string)(dr["CUENTAPAGOCREDITO"]);
                    }

                    if (dr["BANCOMERPARAMID"] != System.DBNull.Value)
                    {
                        retorno.IBANCOMERPARAMID = (long)(dr["BANCOMERPARAMID"]);
                    }

                    if (dr["COMISION"] != System.DBNull.Value)
                    {
                        retorno.ICOMISION = (decimal)(dr["COMISION"]);
                    }

                    if (dr["PAGODOCTOSATID"] != System.DBNull.Value)
                    {
                        retorno.IPAGODOCTOSATID = (long)(dr["PAGODOCTOSATID"]);
                    }

                    if (dr["CUENTABANCOEMPRESAID"] != System.DBNull.Value)
                    {
                        retorno.ICUENTABANCOEMPRESAID = (long)(dr["CUENTABANCOEMPRESAID"]);
                    }

                    if(dr["PERSONAID"] != DBNull.Value)
                    {
                        retorno.IPERSONAID = (long)(dr["PERSONAID"]);
                    }



                    if (dr["APLICADO"] != System.DBNull.Value)
                    {
                        retorno.IAPLICADO = (string)(dr["APLICADO"]);
                    }

                    if (dr["FECHAAPLICADO"] != System.DBNull.Value)
                    {
                        retorno.IFECHAAPLICADO = (DateTime)(dr["FECHAAPLICADO"]);
                    }

                    if (dr["SUBTIPOPAGOID"] != DBNull.Value)
                    {
                        retorno.ISUBTIPOPAGOID = (long)(dr["SUBTIPOPAGOID"]);
                    }
                    if (dr["MOTIVO_CAMFEC_ID"] != DBNull.Value)
                    {
                        retorno.IMOTIVO_CAMFEC_ID = (long)(dr["MOTIVO_CAMFEC_ID"]);
                    }

                    if (dr["DEVUELTO"] != System.DBNull.Value)
                    {
                        retorno.IDEVUELTO = (string)(dr["DEVUELTO"]);
                    }

                    if (dr["FECHAPROCESADO"] != System.DBNull.Value)
                    {
                        retorno.IFECHAPROCESADO = (DateTime)(dr["FECHAPROCESADO"]);
                    }
                    if (dr["DOCTODEVID"] != DBNull.Value)
                    {
                        retorno.IDOCTODEVID  = (long)(dr["DOCTODEVID"]);
                    }

                    if (dr["FECHADEVUELTO"] != System.DBNull.Value)
                    {
                        retorno.IFECHADEVUELTO = (DateTime)(dr["FECHADEVUELTO"]);
                    }

                    if (dr["REFINTERNO"] != System.DBNull.Value)
                    {
                        retorno.IREFINTERNO = (string)(dr["REFINTERNO"]);
                    }

                    if (dr["VERIFONEPAYMENTID"] != System.DBNull.Value)
                    {
                        retorno.IVERIFONEPAYMENTID = (long)(dr["VERIFONEPAYMENTID"]);
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





        public bool esPAGOCOMPUESTO(long pagoId, FbTransaction st)
        {
            CPAGOBE retorno = new CPAGOBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            int cuentaDoctoPago = 0;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select count(*) CUENTA from DOCTOPAGO where PAGOID = @PAGOID  ";

                auxPar = new FbParameter("@PAGOID", FbDbType.BigInt);
                auxPar.Value = pagoId;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["CUENTA"] != System.DBNull.Value)
                    {
                        cuentaDoctoPago = (int)(dr["CUENTA"]);
                    }
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return cuentaDoctoPago > 1;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return true;
            }
        }





        public DataSet enlistarPAGO()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_PAGO_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoPAGO()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_PAGO_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExistePAGO(CPAGOBE oCPAGO, FbTransaction st)
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
                auxPar.Value = oCPAGO.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from PAGO where

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




        public CPAGOBE AgregarPAGO(CPAGOBE oCPAGO, FbTransaction st)
        {
            try
            {
                int iRes = ExistePAGO(oCPAGO, st);
                if (iRes == 1)
                {
                    this.IComentario = "El PAGO ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarPAGOD(oCPAGO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarPAGO(CPAGOBE oCPAGO, FbTransaction st)
        {
            try
            {
                int iRes = ExistePAGO(oCPAGO, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PAGO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarPAGOD(oCPAGO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarPAGO(CPAGOBE oCPAGONuevo, CPAGOBE oCPAGOAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExistePAGO(oCPAGOAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PAGO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarPAGOD(oCPAGONuevo, oCPAGOAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CPAGOBE InsertarPAGOD(CPAGOBE oCPAGO, FbTransaction st)
        {

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;





                auxPar = new FbParameter("@FORMAPAGOID", FbDbType.BigInt);
                if (!(bool)oCPAGO.isnull["IFORMAPAGOID"])
                {
                    auxPar.Value = oCPAGO.IFORMAPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCPAGO.isnull["IFECHA"])
                {
                    auxPar.Value = oCPAGO.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAHORA", FbDbType.Date);
                if (!(bool)oCPAGO.isnull["IFECHAHORA"])
                {
                    auxPar.Value = oCPAGO.IFECHAHORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                if (!(bool)oCPAGO.isnull["ICORTEID"])
                {
                    auxPar.Value = oCPAGO.ICORTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTE", FbDbType.Numeric);
                if (!(bool)oCPAGO.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCPAGO.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTERECIBIDO", FbDbType.Numeric);
                if (!(bool)oCPAGO.isnull["IIMPORTERECIBIDO"])
                {
                    auxPar.Value = oCPAGO.IIMPORTERECIBIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTECAMBIO", FbDbType.Numeric);
                if (!(bool)oCPAGO.isnull["IIMPORTECAMBIO"])
                {
                    auxPar.Value = oCPAGO.IIMPORTECAMBIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@TIPOPAGOID", FbDbType.BigInt);
                if (!(bool)oCPAGO.isnull["ITIPOPAGOID"])
                {
                    auxPar.Value = oCPAGO.ITIPOPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@ESAPARTADO", FbDbType.VarChar);
                if (!(bool)oCPAGO.isnull["IESAPARTADO"])
                {
                    auxPar.Value = oCPAGO.IESAPARTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOAPLICACIONCREDITOID", FbDbType.BigInt);
                if (!(bool)oCPAGO.isnull["ITIPOAPLICACIONCREDITOID"])
                {
                    auxPar.Value = oCPAGO.ITIPOAPLICACIONCREDITOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@BANCO", FbDbType.BigInt);
                if (!(bool)oCPAGO.isnull["IBANCO"])
                {
                    auxPar.Value = oCPAGO.IBANCO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIABANCARIA", FbDbType.VarChar);
                if (!(bool)oCPAGO.isnull["IREFERENCIABANCARIA"])
                {
                    auxPar.Value = oCPAGO.IREFERENCIABANCARIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOTAS", FbDbType.VarChar);
                if (!(bool)oCPAGO.isnull["INOTAS"])
                {
                    auxPar.Value = oCPAGO.INOTAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FECHAELABORACION", FbDbType.Date);
                if (!(bool)oCPAGO.isnull["IFECHAELABORACION"])
                {
                    auxPar.Value = oCPAGO.IFECHAELABORACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHARECEPCION", FbDbType.Date);
                if (!(bool)oCPAGO.isnull["IFECHARECEPCION"])
                {
                    auxPar.Value = oCPAGO.IFECHARECEPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESPAGOINICIAL", FbDbType.VarChar);
                if (!(bool)oCPAGO.isnull["IESPAGOINICIAL"])
                {
                    auxPar.Value = oCPAGO.IESPAGOINICIAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@TIPOABONOID", FbDbType.BigInt);
                if (!(bool)oCPAGO.isnull["ITIPOABONOID"])
                {
                    auxPar.Value = oCPAGO.ITIPOABONOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PAGOREFID", FbDbType.BigInt);
                if (!(bool)oCPAGO.isnull["IPAGOREFID"])
                {
                    auxPar.Value = oCPAGO.IPAGOREFID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FORMAPAGOSATID", FbDbType.BigInt);
                if (!(bool)oCPAGO.isnull["IFORMAPAGOSATID"])
                {
                    auxPar.Value = oCPAGO.IFORMAPAGOSATID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@BANCOMERPARAMID", FbDbType.BigInt);
                if (!(bool)oCPAGO.isnull["IBANCOMERPARAMID"])
                {
                    auxPar.Value = oCPAGO.IBANCOMERPARAMID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@COMISION", FbDbType.Numeric);
                if (!(bool)oCPAGO.isnull["ICOMISION"])
                {
                    auxPar.Value = oCPAGO.ICOMISION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CUENTAPAGOCREDITO", FbDbType.VarChar);
                if (!(bool)oCPAGO.isnull["ICUENTAPAGOCREDITO"])
                {
                    auxPar.Value = oCPAGO.ICUENTAPAGOCREDITO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CUENTABANCOEMPRESAID", FbDbType.BigInt);
                if (!(bool)oCPAGO.isnull["ICUENTABANCOEMPRESAID"])
                {
                    auxPar.Value = oCPAGO.ICUENTABANCOEMPRESAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCPAGO.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCPAGO.IPERSONAID;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@APLICADO", FbDbType.VarChar);
                if (!(bool)oCPAGO.isnull["IAPLICADO"])
                {
                    auxPar.Value = oCPAGO.IAPLICADO;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAAPLICADO", FbDbType.Date);
                if (!(bool)oCPAGO.isnull["IFECHAAPLICADO"])
                {
                    auxPar.Value = oCPAGO.IFECHAAPLICADO;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUBTIPOPAGOID", FbDbType.BigInt);
                if (!(bool)oCPAGO.isnull["ISUBTIPOPAGOID"])
                {
                    auxPar.Value = oCPAGO.ISUBTIPOPAGOID;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFINTERNO", FbDbType.VarChar);
                if (!(bool)oCPAGO.isnull["IREFINTERNO"])
                {
                    auxPar.Value = oCPAGO.IREFINTERNO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VERIFONEPAYMENTID", FbDbType.BigInt);
                if (!(bool)oCPAGO.isnull["IVERIFONEPAYMENTID"])
                {
                    auxPar.Value = oCPAGO.IVERIFONEPAYMENTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PAGOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"PAGO_INSERT";

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
                        return null;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    oCPAGO.IID = (long)arParms[arParms.Length - 2].Value;
                }

                return oCPAGO;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }



        public bool RevertirPAGOD(long pagoId, long vendedorId, bool checarReapartamiento, string notaPago, ref long pagoRevertidoId, FbTransaction st)
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


                auxPar = new FbParameter("@CHECARREAPARTAMIENTO", FbDbType.VarChar);
                auxPar.Value = checarReapartamiento ? "S" : "N";
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOTAPAGO", FbDbType.VarChar);
                auxPar.Value = notaPago;
                parts.Add(auxPar);

                auxPar = new FbParameter("@PAGOREVERTIDOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"PAGO_REVERTIR";

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
                    pagoRevertidoId = (long)arParms[arParms.Length - 2].Value;
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool CambiarCUENTAPAGOCREDITO_PAGOD(CPAGOBE oCPAGONuevo, CPAGOBE oCPAGOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@CUENTAPAGOCREDITO", FbDbType.VarChar);
                if (!(bool)oCPAGONuevo.isnull["ICUENTAPAGOCREDITO"])
                {
                    auxPar.Value = oCPAGONuevo.ICUENTAPAGOCREDITO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCPAGOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCPAGOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  PAGO
  set

CUENTAPAGOCREDITO = @CUENTAPAGOCREDITO
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





        public bool CambiarAPLICADO_PAGOD(CPAGOBE oCPAGONuevo, CPAGOBE oCPAGOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCPAGOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCPAGOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@APLICADO", FbDbType.VarChar);
                if (!(bool)oCPAGONuevo.isnull["IAPLICADO"])
                {
                    auxPar.Value = oCPAGONuevo.IAPLICADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAAPLICADO", FbDbType.Date);
                if (!(bool)oCPAGONuevo.isnull["IFECHAAPLICADO"])
                {
                    auxPar.Value = oCPAGONuevo.IFECHAAPLICADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@MOTIVO_CAMFEC_ID", FbDbType.BigInt);
                if (!(bool)oCPAGOAnterior.isnull["IMOTIVO_CAMFEC_ID"])
                {
                    auxPar.Value = oCPAGOAnterior.IMOTIVO_CAMFEC_ID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);



                string commandText = @"PAGO_CAMBIARAPLICADO";

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


        public bool PAGO_DEVOLVER(CPAGOBE oCPAGO, long userId,FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCPAGO.isnull["IID"])
                {
                    auxPar.Value = oCPAGO.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@USERID", FbDbType.BigInt);
                auxPar.Value = userId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);



                string commandText = @"PAGO_DEVOLVER";

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



        public CPAGOD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
