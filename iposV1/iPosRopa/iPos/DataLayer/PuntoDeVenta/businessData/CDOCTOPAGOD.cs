

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

    [Transaction(TransactionOption.Supported)]


    public class CDOCTOPAGOD
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
        public CDOCTOPAGOBE AgregarDOCTOPAGOD(CDOCTOPAGOBE oCDOCTOPAGO, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGO.isnull["IID"])
                {
                    auxPar.Value = oCDOCTOPAGO.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCDOCTOPAGO.isnull["IACTIVO"])
                {
                    auxPar.Value = oCDOCTOPAGO.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGO.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCDOCTOPAGO.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGO.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCDOCTOPAGO.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGO.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCDOCTOPAGO.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FORMAPAGOID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGO.isnull["IFORMAPAGOID"])
                {
                    auxPar.Value = oCDOCTOPAGO.IFORMAPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCDOCTOPAGO.isnull["IFECHA"])
                {
                    auxPar.Value = oCDOCTOPAGO.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGO.isnull["ICORTEID"])
                {
                    auxPar.Value = oCDOCTOPAGO.ICORTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTE", FbDbType.Numeric);
                if (!(bool)oCDOCTOPAGO.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCDOCTOPAGO.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FORMAPAGOSATID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGO.isnull["IFORMAPAGOSATID"])
                {
                    auxPar.Value = oCDOCTOPAGO.IFORMAPAGOSATID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                string commandText = @"
        INSERT INTO DOCTOPAGO
      (
    
ID,

ACTIVO,

CREADO,

CREADOPOR_USERID,

MODIFICADO,

MODIFICADOPOR_USERID,

DOCTOID,

FORMAPAGOID,

FECHA,

FECHAHORA,

CORTEID,

IMPORTE,

FORMAPAGOSATID
         )

Values (

@ID,

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@DOCTOID,

@FORMAPAGOID,

@FECHA,

@CORTEID,

@IMPORTE,

@FORMAPAGOSATID
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCDOCTOPAGO;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarDOCTOPAGOD(CDOCTOPAGOBE oCDOCTOPAGO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCDOCTOPAGO.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from DOCTOPAGO
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


        [AutoComplete]
        public bool CambiarDOCTOPAGOD(CDOCTOPAGOBE oCDOCTOPAGONuevo, CDOCTOPAGOBE oCDOCTOPAGOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTOPAGONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCDOCTOPAGONuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCDOCTOPAGONuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGONuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCDOCTOPAGONuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGONuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCDOCTOPAGONuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGONuevo.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCDOCTOPAGONuevo.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FORMAPAGOID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGONuevo.isnull["IFORMAPAGOID"])
                {
                    auxPar.Value = oCDOCTOPAGONuevo.IFORMAPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCDOCTOPAGONuevo.isnull["IFECHA"])
                {
                    auxPar.Value = oCDOCTOPAGONuevo.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGONuevo.isnull["ICORTEID"])
                {
                    auxPar.Value = oCDOCTOPAGONuevo.ICORTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPORTE", FbDbType.Numeric);
                if (!(bool)oCDOCTOPAGONuevo.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCDOCTOPAGONuevo.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FORMAPAGOSATID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGONuevo.isnull["IFORMAPAGOSATID"])
                {
                    auxPar.Value = oCDOCTOPAGONuevo.IFORMAPAGOSATID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCDOCTOPAGOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTOPAGO
  set

ID=@ID,

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

DOCTOID=@DOCTOID,

FORMAPAGOID=@FORMAPAGOID,

FECHA=@FECHA,

CORTEID=@CORTEID,

IMPORTE=@IMPORTE

FORMAPAGOSATID=@FORMAPAGOSATID,
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

        public List<long> SeleccionarPagosPendientesPorDoctoId(long doctoId, FbTransaction st)
        {
            try
            {
                FbDataReader dr = null;
                FbConnection pcn = null;
                List<long> pagos = new List<long>();

                ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String query = @"select * from DOCTOPAGO where (DOCTOID = @DOCTOID  or DOCTOSALIDAID = @DOCTOID)";


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, query, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, query, arParms);

                if(dr.Read())
                {
                    long pagoId = dr["PAGOID"] != DBNull.Value ? (long)dr["PAGOID"] : 0;
                    pagos.Add(pagoId);
                }

                return pagos;
            }
            catch(Exception e)
            {
                iComentario = e.Message + "-" + e.StackTrace;
                return null;
            }
        }

        [AutoComplete]
        public CDOCTOPAGOBE seleccionarDOCTOPAGO(CDOCTOPAGOBE oCDOCTOPAGO, FbTransaction st)
        {
            CDOCTOPAGOBE retorno = new CDOCTOPAGOBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from DOCTOPAGO where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCDOCTOPAGO.IID;
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

                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOID = (long)(dr["DOCTOID"]);
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
                        retorno.IFECHAHORA = (DateTime)(dr["FECHAHORA"]);
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

                    if (dr["DOCTOSALIDAID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOSALIDAID = (long)(dr["DOCTOSALIDAID"]);
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
                    if (dr["ESAPARTADO"] != System.DBNull.Value)
                    {
                        retorno.IESAPARTADO = (string)(dr["ESAPARTADO"]);
                    }

                    if (dr["ESPAGOINICIAL"] != System.DBNull.Value)
                    {
                        retorno.IESPAGOINICIAL = (string)(dr["ESPAGOINICIAL"]);
                    }



                    if (dr["DOCTOPAGOREFID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOPAGOREFID = (long)(dr["DOCTOPAGOREFID"]);
                    }
                    if (dr["TIPOABONOID"] != System.DBNull.Value)
                    {
                        retorno.ITIPOABONOID = (long)(dr["TIPOABONOID"]);
                    }
                    if (dr["REVERTIDO"] != System.DBNull.Value)
                    {
                        retorno.IREVERTIDO = (string)(dr["REVERTIDO"]);
                    }


                    if (dr["FORMAPAGOSATID"] != System.DBNull.Value)
                    {
                        retorno.IFORMAPAGOSATID = (long)(dr["FORMAPAGOSATID"]);
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

                    if (dr["CUENTABANCOEMPRESAID"] != System.DBNull.Value)
                    {
                        retorno.ICUENTABANCOEMPRESAID = (long)(dr["CUENTABANCOEMPRESAID"]);
                    }

                    if (dr["PAGOID"] != System.DBNull.Value)
                    {
                        retorno.IPAGOID = (long)(dr["PAGOID"]);
                    }

                    if (dr["APLICADO"] != System.DBNull.Value)
                    {
                        retorno.IAPLICADO = (string)(dr["APLICADO"]);
                    }

                    if (dr["FECHAAPLICADO"] != System.DBNull.Value)
                    {
                        retorno.IFECHAAPLICADO = (DateTime)(dr["FECHAAPLICADO"]);
                    }

                    if (dr["SUBTIPOPAGOID"] != System.DBNull.Value)
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
                        retorno.IDOCTODEVID = (long)(dr["DOCTODEVID"]);
                    }
                    
                    if (dr["COMISION2"] != System.DBNull.Value)
                    {
                        retorno.ICOMISION2 = (decimal)(dr["COMISION2"]);
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





        public CDOCTOPAGOBE seleccionarPrimerDOCTOPAGO(CDOCTOBE oCDOCTO, FbTransaction st)
        {




            CDOCTOPAGOBE retorno = new CDOCTOPAGOBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select first 1 * from DOCTOPAGO where doctoid = @DOCTOID";


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

                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOID = (long)(dr["DOCTOID"]);
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
                        retorno.IFECHAHORA = (DateTime)(dr["FECHAHORA"]);
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

                    if (dr["DOCTOSALIDAID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOSALIDAID = (long)(dr["DOCTOSALIDAID"]);
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
                    if (dr["ESAPARTADO"] != System.DBNull.Value)
                    {
                        retorno.IESAPARTADO = (string)(dr["ESAPARTADO"]);
                    }

                    if (dr["ESPAGOINICIAL"] != System.DBNull.Value)
                    {
                        retorno.IESPAGOINICIAL = (string)(dr["ESPAGOINICIAL"]);
                    }



                    if (dr["DOCTOPAGOREFID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOPAGOREFID = (long)(dr["DOCTOPAGOREFID"]);
                    }
                    if (dr["TIPOABONOID"] != System.DBNull.Value)
                    {
                        retorno.ITIPOABONOID = (long)(dr["TIPOABONOID"]);
                    }
                    if (dr["REVERTIDO"] != System.DBNull.Value)
                    {
                        retorno.IREVERTIDO = (string)(dr["REVERTIDO"]);
                    }

                    if (dr["FORMAPAGOSATID"] != System.DBNull.Value)
                    {
                        retorno.IFORMAPAGOSATID = (long)(dr["FORMAPAGOSATID"]);
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


                    if (dr["CUENTABANCOEMPRESAID"] != System.DBNull.Value)
                    {
                        retorno.ICUENTABANCOEMPRESAID = (long)(dr["CUENTABANCOEMPRESAID"]);
                    }

                    if (dr["PAGOID"] != System.DBNull.Value)
                    {
                        retorno.IPAGOID = (long)(dr["PAGOID"]);
                    }



                    if (dr["APLICADO"] != System.DBNull.Value)
                    {
                        retorno.IAPLICADO = (string)(dr["APLICADO"]);
                    }

                    if (dr["FECHAAPLICADO"] != System.DBNull.Value)
                    {
                        retorno.IFECHAAPLICADO = (DateTime)(dr["FECHAAPLICADO"]);
                    }

                    if (dr["SUBTIPOPAGOID"] != System.DBNull.Value)
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
                        retorno.IDOCTODEVID = (long)(dr["DOCTODEVID"]);
                    }
                    
                    if (dr["COMISION2"] != System.DBNull.Value)
                    {
                        retorno.ICOMISION2 = (decimal)(dr["COMISION2"]);
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


        public CDOCTOPAGOBE seleccionarPrimerDOCTOPAGOxReciboElectronico(CDOCTOBE oCDOCTO, FbTransaction st)
        {




            CDOCTOPAGOBE retorno = new CDOCTOPAGOBE();
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select first 1 * from DOCTOPAGO where RECIBOELECTRONICOID = @DOCTOID";


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

                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOID = (long)(dr["DOCTOID"]);
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
                        retorno.IFECHAHORA = (DateTime)(dr["FECHAHORA"]);
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

                    if (dr["DOCTOSALIDAID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOSALIDAID = (long)(dr["DOCTOSALIDAID"]);
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
                    if (dr["ESAPARTADO"] != System.DBNull.Value)
                    {
                        retorno.IESAPARTADO = (string)(dr["ESAPARTADO"]);
                    }

                    if (dr["ESPAGOINICIAL"] != System.DBNull.Value)
                    {
                        retorno.IESPAGOINICIAL = (string)(dr["ESPAGOINICIAL"]);
                    }



                    if (dr["DOCTOPAGOREFID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOPAGOREFID = (long)(dr["DOCTOPAGOREFID"]);
                    }
                    if (dr["TIPOABONOID"] != System.DBNull.Value)
                    {
                        retorno.ITIPOABONOID = (long)(dr["TIPOABONOID"]);
                    }
                    if (dr["REVERTIDO"] != System.DBNull.Value)
                    {
                        retorno.IREVERTIDO = (string)(dr["REVERTIDO"]);
                    }

                    if (dr["FORMAPAGOSATID"] != System.DBNull.Value)
                    {
                        retorno.IFORMAPAGOSATID = (long)(dr["FORMAPAGOSATID"]);
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


                    if (dr["CUENTABANCOEMPRESAID"] != System.DBNull.Value)
                    {
                        retorno.ICUENTABANCOEMPRESAID = (long)(dr["CUENTABANCOEMPRESAID"]);
                    }


                    if (dr["PAGOID"] != System.DBNull.Value)
                    {
                        retorno.IPAGOID = (long)(dr["PAGOID"]);
                    }


                    if (dr["APLICADO"] != System.DBNull.Value)
                    {
                        retorno.IAPLICADO = (string)(dr["APLICADO"]);
                    }

                    if (dr["FECHAAPLICADO"] != System.DBNull.Value)
                    {
                        retorno.IFECHAAPLICADO = (DateTime)(dr["FECHAAPLICADO"]);
                    }

                    if (dr["SUBTIPOPAGOID"] != System.DBNull.Value)
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
                        retorno.IDOCTODEVID = (long)(dr["DOCTODEVID"]);
                    }

                    
                    if (dr["COMISION2"] != System.DBNull.Value)
                    {
                        retorno.ICOMISION2 = (decimal)(dr["COMISION2"]);
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



        public string obtenNombreFormaPago(CDOCTOPAGOBE oCDOCTOPAGO, FbTransaction st)
        {




            String retorno = "";
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from FORMAPAGO where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCDOCTOPAGO.IFORMAPAGOID;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno = (string)(dr["NOMBRE"]);
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




        public string obtenNombreFormaPagoXId(long formaPagoId, FbTransaction st)
        {




            String retorno = "";
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from FORMAPAGO where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = formaPagoId;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno = (string)(dr["NOMBRE"]);
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



        public string obtenNombreFormaPagoSatXId(long formaPagoId, FbTransaction st)
        {




            String retorno = "";
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from FORMAPAGOSAT where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = formaPagoId;
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
                        retorno = (string)(dr["CLAVE"]);
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


        public string obtenNombreFormaPagoSat(CDOCTOPAGOBE oCDOCTOPAGO, FbTransaction st)
        {




            String retorno = "";
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from FORMAPAGOSAT where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCDOCTOPAGO.IFORMAPAGOSATID;
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
                        retorno = (string)(dr["CLAVE"]);
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
        public DataSet enlistarDOCTOPAGO()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_DOCTOPAGO_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoDOCTOPAGO()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_DOCTOPAGO_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteDOCTOPAGO(CDOCTOPAGOBE oCDOCTOPAGO, FbTransaction st)
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
                auxPar.Value = oCDOCTOPAGO.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from DOCTOPAGO where

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




        public CDOCTOPAGOBE AgregarDOCTOPAGO(CDOCTOPAGOBE oCDOCTOPAGO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteDOCTOPAGO(oCDOCTOPAGO, st);
                if (iRes == 1)
                {
                    this.IComentario = "El DOCTOPAGO ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarDOCTOPAGOD(oCDOCTOPAGO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarDOCTOPAGO(CDOCTOPAGOBE oCDOCTOPAGO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteDOCTOPAGO(oCDOCTOPAGO, st);
                if (iRes == 0)
                {
                    this.IComentario = "El DOCTOPAGO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarDOCTOPAGOD(oCDOCTOPAGO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarDOCTOPAGO(CDOCTOPAGOBE oCDOCTOPAGONuevo, CDOCTOPAGOBE oCDOCTOPAGOAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteDOCTOPAGO(oCDOCTOPAGOAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El DOCTOPAGO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarDOCTOPAGOD(oCDOCTOPAGONuevo, oCDOCTOPAGOAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CDOCTOPAGOBE InsertarDOCTOPAGOD(CDOCTOPAGOBE oCDOCTOPAGO, FbTransaction st)
        {

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGO.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCDOCTOPAGO.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FORMAPAGOID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGO.isnull["IFORMAPAGOID"])
                {
                    auxPar.Value = oCDOCTOPAGO.IFORMAPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCDOCTOPAGO.isnull["IFECHA"])
                {
                    auxPar.Value = oCDOCTOPAGO.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAHORA", FbDbType.Date);
                if (!(bool)oCDOCTOPAGO.isnull["IFECHAHORA"])
                {
                    auxPar.Value = oCDOCTOPAGO.IFECHAHORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGO.isnull["ICORTEID"])
                {
                    auxPar.Value = oCDOCTOPAGO.ICORTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTE", FbDbType.Numeric);
                if (!(bool)oCDOCTOPAGO.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCDOCTOPAGO.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTERECIBIDO", FbDbType.Numeric);
                if (!(bool)oCDOCTOPAGO.isnull["IIMPORTERECIBIDO"])
                {
                    auxPar.Value = oCDOCTOPAGO.IIMPORTERECIBIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTECAMBIO", FbDbType.Numeric);
                if (!(bool)oCDOCTOPAGO.isnull["IIMPORTECAMBIO"])
                {
                    auxPar.Value = oCDOCTOPAGO.IIMPORTECAMBIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                
                auxPar = new FbParameter("@TIPOPAGOID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGO.isnull["ITIPOPAGOID"])
                {
                    auxPar.Value = oCDOCTOPAGO.ITIPOPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                
                auxPar = new FbParameter("@DOCTOSALIDAID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGO.isnull["IDOCTOSALIDAID"])
                {
                    auxPar.Value = oCDOCTOPAGO.IDOCTOSALIDAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                
                auxPar = new FbParameter("@ESAPARTADO", FbDbType.VarChar);
                if (!(bool)oCDOCTOPAGO.isnull["IESAPARTADO"])
                {
                    auxPar.Value = oCDOCTOPAGO.IESAPARTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                
                auxPar = new FbParameter("@TIPOAPLICACIONCREDITOID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGO.isnull["ITIPOAPLICACIONCREDITOID"])
                {
                    auxPar.Value = oCDOCTOPAGO.ITIPOAPLICACIONCREDITOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@BANCO", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGO.isnull["IBANCO"])
                {
                    auxPar.Value = oCDOCTOPAGO.IBANCO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIABANCARIA", FbDbType.VarChar);
                if (!(bool)oCDOCTOPAGO.isnull["IREFERENCIABANCARIA"])
                {
                    auxPar.Value = oCDOCTOPAGO.IREFERENCIABANCARIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOTAS", FbDbType.VarChar);
                if (!(bool)oCDOCTOPAGO.isnull["INOTAS"])
                {
                    auxPar.Value = oCDOCTOPAGO.INOTAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FECHAELABORACION", FbDbType.Date);
                if (!(bool)oCDOCTOPAGO.isnull["IFECHAELABORACION"])
                {
                    auxPar.Value = oCDOCTOPAGO.IFECHAELABORACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHARECEPCION", FbDbType.Date);
                if (!(bool)oCDOCTOPAGO.isnull["IFECHARECEPCION"])
                {
                    auxPar.Value = oCDOCTOPAGO.IFECHARECEPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESPAGOINICIAL", FbDbType.VarChar);
                if (!(bool)oCDOCTOPAGO.isnull["IESPAGOINICIAL"])
                {
                    auxPar.Value = oCDOCTOPAGO.IESPAGOINICIAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@TIPOABONOID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGO.isnull["ITIPOABONOID"])
                {
                    auxPar.Value = oCDOCTOPAGO.ITIPOABONOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DOCTOPAGOREFID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGO.isnull["IDOCTOPAGOREFID"])
                {
                    auxPar.Value = oCDOCTOPAGO.IDOCTOPAGOREFID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FORMAPAGOSATID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGO.isnull["IFORMAPAGOSATID"])
                {
                    auxPar.Value = oCDOCTOPAGO.IFORMAPAGOSATID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@BANCOMERPARAMID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGO.isnull["IBANCOMERPARAMID"])
                {
                    auxPar.Value = oCDOCTOPAGO.IBANCOMERPARAMID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@COMISION", FbDbType.Numeric);
                if (!(bool)oCDOCTOPAGO.isnull["ICOMISION"])
                {
                    auxPar.Value = oCDOCTOPAGO.ICOMISION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CUENTAPAGOCREDITO", FbDbType.VarChar);
                if (!(bool)oCDOCTOPAGO.isnull["ICUENTAPAGOCREDITO"])
                {
                    auxPar.Value = oCDOCTOPAGO.ICUENTAPAGOCREDITO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CUENTABANCOEMPRESAID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGO.isnull["ICUENTABANCOEMPRESAID"])
                {
                    auxPar.Value = oCDOCTOPAGO.ICUENTABANCOEMPRESAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@APLICADO", FbDbType.VarChar);
                if (!(bool)oCDOCTOPAGO.isnull["IAPLICADO"])
                {
                    auxPar.Value = oCDOCTOPAGO.IAPLICADO;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAAPLICADO", FbDbType.Date);
                if (!(bool)oCDOCTOPAGO.isnull["IFECHAAPLICADO"])
                {
                    auxPar.Value = oCDOCTOPAGO.IFECHAAPLICADO;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PAGOID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGO.isnull["IPAGOID"])
                {
                    auxPar.Value = oCDOCTOPAGO.IPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@SUBTIPOPAGOID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGO.isnull["ISUBTIPOPAGOID"])
                {
                    auxPar.Value = oCDOCTOPAGO.ISUBTIPOPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@VERIFONEPAYMENTID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGO.isnull["IVERIFONEPAYMENTID"])
                {
                    auxPar.Value = oCDOCTOPAGO.IVERIFONEPAYMENTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOPAGOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);



                string commandText = @"DOCTOPAGO_INSERT";

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
                        this.iComentario = "ERROR : " + (strMensajeErr != null ? strMensajeErr : "");
                        return null;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    oCDOCTOPAGO.IID = (long)arParms[arParms.Length - 2].Value;
                }

                return oCDOCTOPAGO;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }



       



        public bool DOCTO_PAGO_SP(CDOCTOPAGOBE oCDOCTOPAGO, 
                                            decimal? IMPORTETOTALAPAGAR,
                                            decimal? IMPORTEEFECTIVO ,
                                            decimal? IMPORTETARJETA ,
                                            decimal? IMPORTECHEQUE ,
                                            decimal? IMPORTECREDITO ,
                                            decimal? IMPORTEVALE,
                                            decimal? IMPORTEEFECTIVORECIBIDO,
                                            decimal? IMPORTECAMBIOCHEQUE,
                                            decimal? IMPORTECREDITOAUTOMATICO,
                                            decimal? IMPORTECREDITOMANUAL,
                                            decimal? IMPORTECREDITOREVERTIDO,
                                            long VENDEDORID,
                                            long BANCOTARJETA,
                                            string REFERENCIABANCARIATARJETA,
                                            long BANCOCHEQUE,
                                            string REFERENCIABANCARIACHEQUE,
                                            decimal? IMPORTEMONEDERO,
                                            string REFERENCIAMONEDERO,
                                            decimal? IMPORTETRANSFERENCIA,
                                            long BANCOTRANSFERENCIA,
                                            string REFERENCIABANCARIATRANSFERENCIA,
                                            long TARJETAFORMAPAGOSATID,
                                            long BANCOMERPARAMID,
                                            long VERIFONEPAYMENTID,
                                            FbTransaction st)
        {
            
                long DOCTOPAGOIDEFECTIVO = 0;
                long DOCTOPAGOIDTARJETA = 0;
                long DOCTOPAGOIDCHEQUE = 0;


                return DOCTO_PAGO_SP(oCDOCTOPAGO,
                                             IMPORTETOTALAPAGAR,
                                             IMPORTEEFECTIVO,
                                             IMPORTETARJETA,
                                             IMPORTECHEQUE,
                                             IMPORTECREDITO,
                                             IMPORTEVALE,
                                             IMPORTEEFECTIVORECIBIDO,
                                             IMPORTECAMBIOCHEQUE,
                                             IMPORTECREDITOAUTOMATICO,
                                             IMPORTECREDITOMANUAL,
                                             IMPORTECREDITOREVERTIDO,
                                             VENDEDORID,
                                             BANCOTARJETA,
                                             REFERENCIABANCARIATARJETA,
                                             BANCOCHEQUE,
                                             REFERENCIABANCARIACHEQUE,
                                             IMPORTEMONEDERO,
                                             REFERENCIAMONEDERO,
                                             IMPORTETRANSFERENCIA,
                                             BANCOTRANSFERENCIA,
                                             REFERENCIABANCARIATRANSFERENCIA,
                                             TARJETAFORMAPAGOSATID,
                                             BANCOMERPARAMID,
                                             VERIFONEPAYMENTID,
                                             ref DOCTOPAGOIDEFECTIVO,
                                             ref DOCTOPAGOIDTARJETA,
                                             ref DOCTOPAGOIDCHEQUE,
                                             st);

        }
        /*
                                             "",
                                             0,
                                             "",
                                             0,
                                             "",
                                             0,*/


        public bool DOCTO_PAGO_SP(CDOCTOPAGOBE oCDOCTOPAGO,
                                            decimal? IMPORTETOTALAPAGAR,
                                            decimal? IMPORTEEFECTIVO,
                                            decimal? IMPORTETARJETA,
                                            decimal? IMPORTECHEQUE,
                                            decimal? IMPORTECREDITO,
                                            decimal? IMPORTEVALE,
                                            decimal? IMPORTEEFECTIVORECIBIDO,
                                            decimal? IMPORTECAMBIOCHEQUE,
                                            decimal? IMPORTECREDITOAUTOMATICO,
                                            decimal? IMPORTECREDITOMANUAL,
                                            decimal? IMPORTECREDITOREVERTIDO,
                                            long VENDEDORID,
                                            long BANCOTARJETA,
                                            string REFERENCIABANCARIATARJETA,
                                            long BANCOCHEQUE,
                                            string REFERENCIABANCARIACHEQUE,
                                            decimal? IMPORTEMONEDERO,
                                            string REFERENCIAMONEDERO,
                                            decimal? IMPORTETRANSFERENCIA,
                                            long BANCOTRANSFERENCIA,
                                            string REFERENCIABANCARIATRANSFERENCIA,
                                            long TARJETAFORMAPAGOSATID,
                                            long BANCOMERPARAMID,
                                            long VERIFONEPAYMENTID,


                                            ref long DOCTOPAGOIDEFECTIVO,
                                            ref long DOCTOPAGOIDTARJETA,
                                            ref long DOCTOPAGOIDCHEQUE,

                                            
                                            FbTransaction st)
        {
            


            return DOCTO_PAGO_SP(oCDOCTOPAGO,
                                         IMPORTETOTALAPAGAR,
                                         IMPORTEEFECTIVO,
                                         IMPORTETARJETA,
                                         IMPORTECHEQUE,
                                         IMPORTECREDITO,
                                         IMPORTEVALE,
                                         IMPORTEEFECTIVORECIBIDO,
                                         IMPORTECAMBIOCHEQUE,
                                         IMPORTECREDITOAUTOMATICO,
                                         IMPORTECREDITOMANUAL,
                                         IMPORTECREDITOREVERTIDO,
                                         VENDEDORID,
                                         BANCOTARJETA,
                                         REFERENCIABANCARIATARJETA,
                                         BANCOCHEQUE,
                                         REFERENCIABANCARIACHEQUE,
                                         IMPORTEMONEDERO,
                                         REFERENCIAMONEDERO,
                                         IMPORTETRANSFERENCIA,
                                         BANCOTRANSFERENCIA,
                                         REFERENCIABANCARIATRANSFERENCIA,
                                         TARJETAFORMAPAGOSATID,
                                         BANCOMERPARAMID,
                                         "",
                                         0,
                                         "",
                                         0,
                                         "",
                                         0,
                                         VERIFONEPAYMENTID,
                                         ref DOCTOPAGOIDEFECTIVO,
                                         ref DOCTOPAGOIDTARJETA,
                                         ref DOCTOPAGOIDCHEQUE,
                                         st);

        }


        public bool DOCTO_PAGO_SP(CDOCTOPAGOBE oCDOCTOPAGO, 
                                            decimal? IMPORTETOTALAPAGAR,
                                            decimal? IMPORTEEFECTIVO ,
                                            decimal? IMPORTETARJETA ,
                                            decimal? IMPORTECHEQUE ,
                                            decimal? IMPORTECREDITO ,
                                            decimal? IMPORTEVALE,
                                            decimal? IMPORTEEFECTIVORECIBIDO,
                                            decimal? IMPORTECAMBIOCHEQUE,
                                            decimal? IMPORTECREDITOAUTOMATICO,
                                            decimal? IMPORTECREDITOMANUAL,
                                            decimal? IMPORTECREDITOREVERTIDO,
                                            long VENDEDORID,
                                            long BANCOTARJETA,
                                            string REFERENCIABANCARIATARJETA,
                                            long BANCOCHEQUE,
                                            string REFERENCIABANCARIACHEQUE,
                                            decimal? IMPORTEMONEDERO,
                                            string REFERENCIAMONEDERO,
                                            decimal? IMPORTETRANSFERENCIA,
                                            long BANCOTRANSFERENCIA,
                                            string REFERENCIABANCARIATRANSFERENCIA,
                                            long TARJETAFORMAPAGOSATID,
                                            long BANCOMERPARAMID,

                                            string CHEQUE_CUENTAPAGOCREDITO,
                                            long CHEQUE_CUENTABANCOEMPRESAID ,
                                            string TRANS_CUENTAPAGOCREDITO,
                                            long TRANS_CUENTABANCOEMPRESAID,
                                            string TARJ_CUENTAPAGOCREDITO,
                                            long TARJ_CUENTABANCOEMPRESAID,

                                            long VERIFONEPAYMENTID,

                                            ref long DOCTOPAGOIDEFECTIVO,
                                            ref long DOCTOPAGOIDTARJETA,
                                            ref long DOCTOPAGOIDCHEQUE,





                                            FbTransaction st)
        {

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                
                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGO.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCDOCTOPAGO.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCDOCTOPAGO.isnull["IFECHA"])
                {
                    auxPar.Value = oCDOCTOPAGO.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAHORA", FbDbType.Date);
                if (!(bool)oCDOCTOPAGO.isnull["IFECHAHORA"])
                {
                    auxPar.Value = oCDOCTOPAGO.IFECHAHORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = VENDEDORID;
                parts.Add(auxPar);

                
                auxPar = new FbParameter("@IMPORTETOTALAPAGAR", FbDbType.Numeric);
                if (IMPORTETOTALAPAGAR.HasValue)
                {
                    auxPar.Value = IMPORTETOTALAPAGAR.Value;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTEEFECTIVO", FbDbType.Numeric);
                if (IMPORTEEFECTIVO.HasValue)
                {
                    auxPar.Value = IMPORTEEFECTIVO.Value;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTETARJETA", FbDbType.Numeric);
                if (IMPORTETARJETA.HasValue)
                {
                    auxPar.Value = IMPORTETARJETA.Value;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@BANCOTARJETA", FbDbType.BigInt);
                if (BANCOTARJETA != 0)
                {
                    auxPar.Value = BANCOTARJETA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                

                auxPar = new FbParameter("@IMPORTECREDITO", FbDbType.Numeric);
                if (IMPORTECREDITO.HasValue)
                {
                    auxPar.Value = IMPORTECREDITO.Value;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTEVALE", FbDbType.Numeric);
                if (IMPORTEVALE.HasValue)
                {
                    auxPar.Value = IMPORTEVALE.Value;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPORTEEFECTIVORECIBIDO", FbDbType.Numeric);
                if (IMPORTEEFECTIVORECIBIDO.HasValue)
                {
                    auxPar.Value = IMPORTEEFECTIVORECIBIDO.Value;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                

                auxPar = new FbParameter("@IMPORTECAMBIOCHEQUE", FbDbType.Numeric);
                if (IMPORTECAMBIOCHEQUE.HasValue)
                {
                    auxPar.Value = IMPORTECAMBIOCHEQUE.Value;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOPAGOID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGO.isnull["ITIPOPAGOID"])
                {
                    auxPar.Value = oCDOCTOPAGO.ITIPOPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOSALIDAID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGO.isnull["IDOCTOSALIDAID"])
                {
                    auxPar.Value = oCDOCTOPAGO.IDOCTOSALIDAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ESAPARTADO", FbDbType.VarChar);
                if (!(bool)oCDOCTOPAGO.isnull["IESAPARTADO"])
                {
                    auxPar.Value = oCDOCTOPAGO.IESAPARTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                
                auxPar = new FbParameter("@IMPORTECREDITOAUTOMATICO", FbDbType.Numeric);
                if (IMPORTECREDITOAUTOMATICO.HasValue)
                {
                    auxPar.Value = IMPORTECREDITOAUTOMATICO.Value;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                
                auxPar = new FbParameter("@IMPORTECREDITOMANUAL", FbDbType.Numeric);
                if (IMPORTECREDITOMANUAL.HasValue)
                {
                    auxPar.Value = IMPORTECREDITOMANUAL.Value;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@IMPORTECREDITOREVERTIDO", FbDbType.Numeric);
                if (IMPORTECREDITOREVERTIDO.HasValue)
                {
                    auxPar.Value = IMPORTECREDITOREVERTIDO.Value;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                
                auxPar = new FbParameter("@REFERENCIABANCARIATARJETA", FbDbType.VarChar);
                if (REFERENCIABANCARIATARJETA != "")
                {
                    auxPar.Value = REFERENCIABANCARIATARJETA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                 
                 
                auxPar = new FbParameter("@IMPORTECHEQUE", FbDbType.Numeric);
                if (IMPORTECHEQUE.HasValue)
                {
                    auxPar.Value = IMPORTECHEQUE.Value;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                  
                
                
                auxPar = new FbParameter("@BANCOCHEQUE", FbDbType.BigInt);
                if (BANCOCHEQUE != 0)
                {
                    auxPar.Value = BANCOCHEQUE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                
                auxPar = new FbParameter("@REFERENCIABANCARIACHEQUE", FbDbType.VarChar);
                if (REFERENCIABANCARIACHEQUE != "")
                {
                    auxPar.Value = REFERENCIABANCARIACHEQUE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESPAGOINICIAL", FbDbType.VarChar);
                if (!(bool)oCDOCTOPAGO.isnull["IESPAGOINICIAL"])
                {
                    auxPar.Value = oCDOCTOPAGO.IESPAGOINICIAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@IMPORTEMONEDERO", FbDbType.Numeric);
                if (IMPORTEMONEDERO.HasValue)
                {
                    auxPar.Value = IMPORTEMONEDERO.Value;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIAMONEDERO", FbDbType.Char);
                if (REFERENCIAMONEDERO.Trim() != "")
                {
                    auxPar.Value = REFERENCIAMONEDERO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@IMPORTETRANSFERENCIA", FbDbType.Numeric);
                if (IMPORTETRANSFERENCIA.HasValue)
                {
                    auxPar.Value = IMPORTETRANSFERENCIA.Value;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@BANCOTRANSFERENCIA", FbDbType.BigInt);
                if (BANCOTRANSFERENCIA != 0)
                {
                    auxPar.Value = BANCOTRANSFERENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIABANCARIATRANSFERENCIA", FbDbType.VarChar);
                if (REFERENCIABANCARIATRANSFERENCIA != "")
                {
                    auxPar.Value = REFERENCIABANCARIATRANSFERENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TARJETAFORMAPAGOSATID", FbDbType.BigInt);
                if (TARJETAFORMAPAGOSATID != 0)
                {
                    auxPar.Value = TARJETAFORMAPAGOSATID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@BANCOMERPARAMID", FbDbType.BigInt);
                if (BANCOMERPARAMID != 0)
                {
                    auxPar.Value = BANCOMERPARAMID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CHEQUE_CUENTAPAGOCREDITO", FbDbType.VarChar);
                if (CHEQUE_CUENTAPAGOCREDITO != "")
                {
                    auxPar.Value = CHEQUE_CUENTAPAGOCREDITO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CHEQUE_CUENTABANCOEMPRESAID", FbDbType.BigInt);
                if (CHEQUE_CUENTABANCOEMPRESAID != 0)
                {
                    auxPar.Value = CHEQUE_CUENTABANCOEMPRESAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TRANS_CUENTAPAGOCREDITO", FbDbType.VarChar);
                if (TRANS_CUENTAPAGOCREDITO != "")
                {
                    auxPar.Value = TRANS_CUENTAPAGOCREDITO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TRANS_CUENTABANCOEMPRESAID", FbDbType.BigInt);
                if (TRANS_CUENTABANCOEMPRESAID != 0)
                {
                    auxPar.Value = TRANS_CUENTABANCOEMPRESAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@TARJ_CUENTAPAGOCREDITO", FbDbType.VarChar);
                if (TARJ_CUENTAPAGOCREDITO != "")
                {
                    auxPar.Value = TARJ_CUENTAPAGOCREDITO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TARJ_CUENTABANCOEMPRESAID", FbDbType.BigInt);
                if (TARJ_CUENTABANCOEMPRESAID != 0)
                {
                    auxPar.Value = TARJ_CUENTABANCOEMPRESAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VERIFONEPAYMENTID", FbDbType.BigInt);
                if (VERIFONEPAYMENTID != 0)
                {
                    auxPar.Value = VERIFONEPAYMENTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@DOCTOPAGOIDEFECTIVO", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOPAGOIDCHEQUE", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOPAGOIDTARJETA", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);



                string commandText = @"DOCTO_PAGOS";

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


                if (!(arParms[arParms.Length - 4].Value == System.DBNull.Value))
                {
                    DOCTOPAGOIDEFECTIVO = (long)arParms[arParms.Length - 4].Value;
                }

                if (!(arParms[arParms.Length - 3].Value == System.DBNull.Value))
                {
                    DOCTOPAGOIDCHEQUE = (long)arParms[arParms.Length - 3].Value;
                }

                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    DOCTOPAGOIDTARJETA = (long)arParms[arParms.Length - 2].Value;
                }



                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }





        public bool AjustarSaldosPersona(long personaId, FbTransaction st)
        {

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                auxPar.Value = personaId;
                parts.Add(auxPar);




                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);



                string commandText = @"PERSONA_AJUSTAR_SALDOS";

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


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

            return true;
        }



        public bool AjustarSaldosPersonaApartado(long personaApartadoId, FbTransaction st)
        {

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@PERSONAAPARTADOID", FbDbType.BigInt);
                auxPar.Value = personaApartadoId;
                parts.Add(auxPar);




                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);



                string commandText = @"PERSONAAPARTADO_AJUSTAR_SALDOS";

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


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

            return true;
        }



        public bool CambiarReferenciaDOCTOPAGOD(CDOCTOPAGOBE oCDOCTOPAGONuevo, CDOCTOPAGOBE oCDOCTOPAGOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@REFERENCIABANCARIA", FbDbType.Char);
                if (!(bool)oCDOCTOPAGONuevo.isnull["IREFERENCIABANCARIA"])
                {
                    auxPar.Value = oCDOCTOPAGONuevo.IREFERENCIABANCARIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCDOCTOPAGOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTOPAGO
  set

REFERENCIABANCARIA = @REFERENCIABANCARIA
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




        public bool CambiarCUENTAPAGOCREDITO_DOCTOPAGOD(CDOCTOPAGOBE oCDOCTOPAGONuevo, CDOCTOPAGOBE oCDOCTOPAGOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@CUENTAPAGOCREDITO", FbDbType.VarChar);
                if (!(bool)oCDOCTOPAGONuevo.isnull["ICUENTAPAGOCREDITO"])
                {
                    auxPar.Value = oCDOCTOPAGONuevo.ICUENTAPAGOCREDITO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCDOCTOPAGOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTOPAGO
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




        public bool CambiarREFINTERNO_DOCTOPAGOD(CDOCTOPAGOBE oCDOCTOPAGONuevo, CDOCTOPAGOBE oCDOCTOPAGOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@REFINTERNO", FbDbType.VarChar);
                if (!(bool)oCDOCTOPAGONuevo.isnull["IREFINTERNO"])
                {
                    auxPar.Value = oCDOCTOPAGONuevo.IREFINTERNO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCDOCTOPAGOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTOPAGO
  set

REFINTERNO = @REFINTERNO
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



        public bool CambiarBANCOMERPARAMID(CDOCTOPAGOBE oCDOCTOPAGONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@BANCOMERPARAMID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGONuevo.isnull["IBANCOMERPARAMID"])
                {
                    auxPar.Value = oCDOCTOPAGONuevo.IBANCOMERPARAMID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTOPAGONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTOPAGO
  set

BANCOMERPARAMID = @BANCOMERPARAMID
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



        public bool CambiarCOMISION(CDOCTOPAGOBE oCDOCTOPAGONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@COMISION", FbDbType.Decimal);
                if (!(bool)oCDOCTOPAGONuevo.isnull["ICOMISION"])
                {
                    auxPar.Value = oCDOCTOPAGONuevo.ICOMISION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTOPAGONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTOPAGO
  set

COMISION = @COMISION
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


        public bool CambiarREVERTIDO(CDOCTOPAGOBE oCDOCTOPAGONuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@REVERTIDO", FbDbType.Decimal);
                if (!(bool)oCDOCTOPAGONuevo.isnull["IREVERTIDO"])
                {
                    auxPar.Value = oCDOCTOPAGONuevo.IREVERTIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGONuevo.isnull["IID"])
                {
                    auxPar.Value = oCDOCTOPAGONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTOPAGO
  set

REVERTIDO = @REVERTIDO
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



        public bool BorrarXDoctoIdDOCTOPAGOD(CDOCTOBE oCDOCTO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);



                string commandText = @"DOCTOPAGOS_DELETE";

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





        public CDOCTOPAGOD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }




        public bool ASIGNARPAGO_FACTELECTRONICA(long doctoId, long formaPagoId, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@FORMAPAGOID", FbDbType.BigInt);
                auxPar.Value = formaPagoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"ASIGNARPAGO_FACTELECTRONICA";

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


    }
}
