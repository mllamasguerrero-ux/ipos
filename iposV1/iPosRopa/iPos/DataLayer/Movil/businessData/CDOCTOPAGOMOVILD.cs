


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

    [Transaction(TransactionOption.Supported)]


    public class CDOCTOPAGOMOVILD
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




        public bool RegistrarPagoMovil(CDOCTOPAGOMOVILBE oCDOCTOPAGOMOVIL, FbTransaction st)
        {
            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@PAGOMOVILID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGOMOVIL.isnull["IPAGOMOVILID"])
                {
                    auxPar.Value = oCDOCTOPAGOMOVIL.IPAGOMOVILID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COBRANZAID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGOMOVIL.isnull["ICOBRANZAID"])
                {
                    auxPar.Value = oCDOCTOPAGOMOVIL.ICOBRANZAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCDOCTOPAGOMOVIL.isnull["IFECHA"])
                {
                    auxPar.Value = oCDOCTOPAGOMOVIL.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGOMOVIL.isnull["ICORTEID"])
                {
                    auxPar.Value = oCDOCTOPAGOMOVIL.ICORTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTE", FbDbType.Numeric);
                if (!(bool)oCDOCTOPAGOMOVIL.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCDOCTOPAGOMOVIL.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@VENTACOBRANZA", FbDbType.VarChar);
                if (!(bool)oCDOCTOPAGOMOVIL.isnull["IVENTACOBRANZA"])
                {
                    auxPar.Value = oCDOCTOPAGOMOVIL.IVENTACOBRANZA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SALDOANTERIOR", FbDbType.Numeric);
                if (!(bool)oCDOCTOPAGOMOVIL.isnull["ISALDOANTERIOR"])
                {
                    auxPar.Value = oCDOCTOPAGOMOVIL.ISALDOANTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SALDONUEVO", FbDbType.Numeric);
                if (!(bool)oCDOCTOPAGOMOVIL.isnull["ISALDONUEVO"])
                {
                    auxPar.Value = oCDOCTOPAGOMOVIL.ISALDONUEVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SALDOPAGO", FbDbType.Numeric);
                if (!(bool)oCDOCTOPAGOMOVIL.isnull["ISALDOPAGO"])
                {
                    auxPar.Value = oCDOCTOPAGOMOVIL.ISALDOPAGO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);



                string commandText = @"DOCTOPAGOMOVIL_REGISTRAR";

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





        public CDOCTOPAGOMOVILBE AgregarDOCTOPAGOMOVILD(CDOCTOPAGOMOVILBE oCDOCTOPAGOMOVIL, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@PAGOMOVILID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGOMOVIL.isnull["IPAGOMOVILID"])
                {
                    auxPar.Value = oCDOCTOPAGOMOVIL.IPAGOMOVILID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COBRANZAID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGOMOVIL.isnull["ICOBRANZAID"])
                {
                    auxPar.Value = oCDOCTOPAGOMOVIL.ICOBRANZAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUS", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGOMOVIL.isnull["IESTATUS"])
                {
                    auxPar.Value = oCDOCTOPAGOMOVIL.IESTATUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCDOCTOPAGOMOVIL.isnull["IFECHA"])
                {
                    auxPar.Value = oCDOCTOPAGOMOVIL.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGOMOVIL.isnull["ICORTEID"])
                {
                    auxPar.Value = oCDOCTOPAGOMOVIL.ICORTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTE", FbDbType.Numeric);
                if (!(bool)oCDOCTOPAGOMOVIL.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCDOCTOPAGOMOVIL.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REVERTIDO", FbDbType.Char);
                if (!(bool)oCDOCTOPAGOMOVIL.isnull["IREVERTIDO"])
                {
                    auxPar.Value = oCDOCTOPAGOMOVIL.IREVERTIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOPAGOMOVILREFID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGOMOVIL.isnull["IDOCTOPAGOMOVILREFID"])
                {
                    auxPar.Value = oCDOCTOPAGOMOVIL.IDOCTOPAGOMOVILREFID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOPAGOID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGOMOVIL.isnull["ITIPOPAGOID"])
                {
                    auxPar.Value = oCDOCTOPAGOMOVIL.ITIPOPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENTACOBRANZA", FbDbType.VarChar);
                if (!(bool)oCDOCTOPAGOMOVIL.isnull["IVENTACOBRANZA"])
                {
                    auxPar.Value = oCDOCTOPAGOMOVIL.IVENTACOBRANZA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO DOCTOPAGOMOVIL
      (
    


PAGOMOVILID,

COBRANZAID,

ESTATUS,

FECHA,

FECHAHORA,

CORTEID,

IMPORTE,

REVERTIDO,

DOCTOPAGOMOVILREFID,

TIPOPAGOID,

VENTACOBRANZA
         )

Values (


@PAGOMOVILID,

@COBRANZAID,

@ESTATUS,

@FECHA,

@CORTEID,

@IMPORTE,

@REVERTIDO,

@DOCTOPAGOMOVILREFID,

@TIPOPAGOID,

@VENTACOBRANZA
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCDOCTOPAGOMOVIL;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarDOCTOPAGOMOVILD(CDOCTOPAGOMOVILBE oCDOCTOPAGOMOVIL, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCDOCTOPAGOMOVIL.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from DOCTOPAGOMOVIL
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
        public bool CambiarDOCTOPAGOMOVILD(CDOCTOPAGOMOVILBE oCDOCTOPAGOMOVILNuevo, CDOCTOPAGOMOVILBE oCDOCTOPAGOMOVILAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@PAGOMOVILID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGOMOVILNuevo.isnull["IPAGOMOVILID"])
                {
                    auxPar.Value = oCDOCTOPAGOMOVILNuevo.IPAGOMOVILID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@COBRANZAID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGOMOVILNuevo.isnull["ICOBRANZAID"])
                {
                    auxPar.Value = oCDOCTOPAGOMOVILNuevo.ICOBRANZAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESTATUS", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGOMOVILNuevo.isnull["IESTATUS"])
                {
                    auxPar.Value = oCDOCTOPAGOMOVILNuevo.IESTATUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCDOCTOPAGOMOVILNuevo.isnull["IFECHA"])
                {
                    auxPar.Value = oCDOCTOPAGOMOVILNuevo.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGOMOVILNuevo.isnull["ICORTEID"])
                {
                    auxPar.Value = oCDOCTOPAGOMOVILNuevo.ICORTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPORTE", FbDbType.Numeric);
                if (!(bool)oCDOCTOPAGOMOVILNuevo.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCDOCTOPAGOMOVILNuevo.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@REVERTIDO", FbDbType.Char);
                if (!(bool)oCDOCTOPAGOMOVILNuevo.isnull["IREVERTIDO"])
                {
                    auxPar.Value = oCDOCTOPAGOMOVILNuevo.IREVERTIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOPAGOMOVILREFID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGOMOVILNuevo.isnull["IDOCTOPAGOMOVILREFID"])
                {
                    auxPar.Value = oCDOCTOPAGOMOVILNuevo.IDOCTOPAGOMOVILREFID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOPAGOID", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGOMOVILNuevo.isnull["ITIPOPAGOID"])
                {
                    auxPar.Value = oCDOCTOPAGOMOVILNuevo.ITIPOPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENTACOBRANZA", FbDbType.VarChar);
                if (!(bool)oCDOCTOPAGOMOVILNuevo.isnull["IVENTACOBRANZA"])
                {
                    auxPar.Value = oCDOCTOPAGOMOVILNuevo.IVENTACOBRANZA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTOPAGOMOVILAnterior.isnull["IID"])
                {
                    auxPar.Value = oCDOCTOPAGOMOVILAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTOPAGOMOVIL
  set



PAGOMOVILID=@PAGOMOVILID,

COBRANZAID=@COBRANZAID,

ESTATUS=@ESTATUS,

FECHA=@FECHA,

CORTEID=@CORTEID,

IMPORTE=@IMPORTE,

REVERTIDO=@REVERTIDO,

DOCTOPAGOMOVILREFID=@DOCTOPAGOMOVILREFID,

TIPOPAGOID=@TIPOPAGOID,

VENTACOBRANZA=@VENTACOBRANZA
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
        public CDOCTOPAGOMOVILBE seleccionarDOCTOPAGOMOVIL(CDOCTOPAGOMOVILBE oCDOCTOPAGOMOVIL, FbTransaction st)
        {




            CDOCTOPAGOMOVILBE retorno = new CDOCTOPAGOMOVILBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from DOCTOPAGOMOVIL where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCDOCTOPAGOMOVIL.IID;
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

                    if (dr["PAGOMOVILID"] != System.DBNull.Value)
                    {
                        retorno.IPAGOMOVILID = (long)(dr["PAGOMOVILID"]);
                    }

                    if (dr["COBRANZAID"] != System.DBNull.Value)
                    {
                        retorno.ICOBRANZAID = (long)(dr["COBRANZAID"]);
                    }

                    if (dr["ESTATUS"] != System.DBNull.Value)
                    {
                        retorno.IESTATUS = (long)(dr["ESTATUS"]);
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

                    if (dr["REVERTIDO"] != System.DBNull.Value)
                    {
                        retorno.IREVERTIDO = (string)(dr["REVERTIDO"]);
                    }

                    if (dr["DOCTOPAGOMOVILREFID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOPAGOMOVILREFID = (long)(dr["DOCTOPAGOMOVILREFID"]);
                    }

                    if (dr["TIPOPAGOID"] != System.DBNull.Value)
                    {
                        retorno.ITIPOPAGOID = (long)(dr["TIPOPAGOID"]);
                    }

                    if (dr["VENTACOBRANZA"] != System.DBNull.Value)
                    {
                        retorno.IVENTACOBRANZA = (string)(dr["VENTACOBRANZA"]);
                    }
                    if (dr["SALDOANTERIOR"] != System.DBNull.Value)
                    {
                        retorno.ISALDOANTERIOR = (decimal)(dr["SALDOANTERIOR"]);
                    }
                    if (dr["SALDONUEVO"] != System.DBNull.Value)
                    {
                        retorno.ISALDONUEVO = (decimal)(dr["SALDONUEVO"]);
                    }

                    if (dr["SALDOPAGO"] != System.DBNull.Value)
                    {
                        retorno.ISALDOPAGO = (decimal)(dr["SALDOPAGO"]);
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




        public CDOCTOPAGOMOVILBE[] seleccionarDOCTOPAGOMOVIL_DEPAGO(long pagoMovilId, FbTransaction st)
        {


            
            ArrayList retArray = new ArrayList();

            CDOCTOPAGOMOVILBE retorno = new CDOCTOPAGOMOVILBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from DOCTOPAGOMOVIL where
 PAGOMOVILID=@PAGOMOVILID  ";


                auxPar = new FbParameter("@PAGOMOVILID", FbDbType.BigInt);
                auxPar.Value = pagoMovilId;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                while (dr.Read())
                {
                     retorno = new CDOCTOPAGOMOVILBE();
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

                    if (dr["PAGOMOVILID"] != System.DBNull.Value)
                    {
                        retorno.IPAGOMOVILID = (long)(dr["PAGOMOVILID"]);
                    }

                    if (dr["COBRANZAID"] != System.DBNull.Value)
                    {
                        retorno.ICOBRANZAID = (long)(dr["COBRANZAID"]);
                    }

                    if (dr["ESTATUS"] != System.DBNull.Value)
                    {
                        retorno.IESTATUS = (long)(dr["ESTATUS"]);
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

                    if (dr["REVERTIDO"] != System.DBNull.Value)
                    {
                        retorno.IREVERTIDO = (string)(dr["REVERTIDO"]);
                    }

                    if (dr["DOCTOPAGOMOVILREFID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOPAGOMOVILREFID = (long)(dr["DOCTOPAGOMOVILREFID"]);
                    }

                    if (dr["TIPOPAGOID"] != System.DBNull.Value)
                    {
                        retorno.ITIPOPAGOID = (long)(dr["TIPOPAGOID"]);
                    }

                    if (dr["VENTACOBRANZA"] != System.DBNull.Value)
                    {
                        retorno.IVENTACOBRANZA = (string)(dr["VENTACOBRANZA"]);
                    }

                    if (dr["SALDOANTERIOR"] != System.DBNull.Value)
                    {
                        retorno.ISALDOANTERIOR = (decimal)(dr["SALDOANTERIOR"]);
                    }
                    if (dr["SALDONUEVO"] != System.DBNull.Value)
                    {
                        retorno.ISALDONUEVO = (decimal)(dr["SALDONUEVO"]);
                    }

                    if (dr["SALDOPAGO"] != System.DBNull.Value)
                    {
                        retorno.ISALDOPAGO = (decimal)(dr["SALDOPAGO"]);
                    }

                    retArray.Add(retorno);

                }



                CDOCTOPAGOMOVILBE[] ret = new CDOCTOPAGOMOVILBE[retArray.Count];
                retArray.CopyTo(ret, 0);


                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return ret;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }







        [AutoComplete]
        public DataSet enlistarDOCTOPAGOMOVIL()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_DOCTOPAGOMOVIL_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoDOCTOPAGOMOVIL()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_DOCTOPAGOMOVIL_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteDOCTOPAGOMOVIL(CDOCTOPAGOMOVILBE oCDOCTOPAGOMOVIL, FbTransaction st)
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
                auxPar.Value = oCDOCTOPAGOMOVIL.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from DOCTOPAGOMOVIL where

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




        public CDOCTOPAGOMOVILBE AgregarDOCTOPAGOMOVIL(CDOCTOPAGOMOVILBE oCDOCTOPAGOMOVIL, FbTransaction st)
        {
            try
            {
                int iRes = ExisteDOCTOPAGOMOVIL(oCDOCTOPAGOMOVIL, st);
                if (iRes == 1)
                {
                    this.IComentario = "El DOCTOPAGOMOVIL ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarDOCTOPAGOMOVILD(oCDOCTOPAGOMOVIL, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarDOCTOPAGOMOVIL(CDOCTOPAGOMOVILBE oCDOCTOPAGOMOVIL, FbTransaction st)
        {
            try
            {
                int iRes = ExisteDOCTOPAGOMOVIL(oCDOCTOPAGOMOVIL, st);
                if (iRes == 0)
                {
                    this.IComentario = "El DOCTOPAGOMOVIL no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarDOCTOPAGOMOVILD(oCDOCTOPAGOMOVIL, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarDOCTOPAGOMOVIL(CDOCTOPAGOMOVILBE oCDOCTOPAGOMOVILNuevo, CDOCTOPAGOMOVILBE oCDOCTOPAGOMOVILAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteDOCTOPAGOMOVIL(oCDOCTOPAGOMOVILAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El DOCTOPAGOMOVIL no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarDOCTOPAGOMOVILD(oCDOCTOPAGOMOVILNuevo, oCDOCTOPAGOMOVILAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CDOCTOPAGOMOVILD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
