

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



    public class CR_DOCTOPAGOMOVILD
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


        public CR_DOCTOPAGOMOVILBE AgregarR_DOCTOPAGOMOVILD(CR_DOCTOPAGOMOVILBE oCR_DOCTOPAGOMOVIL, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCR_DOCTOPAGOMOVIL.isnull["IACTIVO"])
                {
                    auxPar.Value = oCR_DOCTOPAGOMOVIL.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCR_DOCTOPAGOMOVIL.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCR_DOCTOPAGOMOVIL.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCR_DOCTOPAGOMOVIL.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCR_DOCTOPAGOMOVIL.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PAGOMOVILID", FbDbType.BigInt);
                if (!(bool)oCR_DOCTOPAGOMOVIL.isnull["IPAGOMOVILID"])
                {
                    auxPar.Value = oCR_DOCTOPAGOMOVIL.IPAGOMOVILID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COBRANZAID", FbDbType.BigInt);
                if (!(bool)oCR_DOCTOPAGOMOVIL.isnull["ICOBRANZAID"])
                {
                    auxPar.Value = oCR_DOCTOPAGOMOVIL.ICOBRANZAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUS", FbDbType.BigInt);
                if (!(bool)oCR_DOCTOPAGOMOVIL.isnull["IESTATUS"])
                {
                    auxPar.Value = oCR_DOCTOPAGOMOVIL.IESTATUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCR_DOCTOPAGOMOVIL.isnull["IFECHA"])
                {
                    auxPar.Value = oCR_DOCTOPAGOMOVIL.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                if (!(bool)oCR_DOCTOPAGOMOVIL.isnull["ICORTEID"])
                {
                    auxPar.Value = oCR_DOCTOPAGOMOVIL.ICORTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTE", FbDbType.Numeric);
                if (!(bool)oCR_DOCTOPAGOMOVIL.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCR_DOCTOPAGOMOVIL.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REVERTIDO", FbDbType.Char);
                if (!(bool)oCR_DOCTOPAGOMOVIL.isnull["IREVERTIDO"])
                {
                    auxPar.Value = oCR_DOCTOPAGOMOVIL.IREVERTIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@R_DOCTOPAGOMOVILREFID", FbDbType.BigInt);
                if (!(bool)oCR_DOCTOPAGOMOVIL.isnull["IR_DOCTOPAGOMOVILREFID"])
                {
                    auxPar.Value = oCR_DOCTOPAGOMOVIL.IR_DOCTOPAGOMOVILREFID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOPAGOID", FbDbType.BigInt);
                if (!(bool)oCR_DOCTOPAGOMOVIL.isnull["ITIPOPAGOID"])
                {
                    auxPar.Value = oCR_DOCTOPAGOMOVIL.ITIPOPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENTACOBRANZA", FbDbType.VarChar);
                if (!(bool)oCR_DOCTOPAGOMOVIL.isnull["IVENTACOBRANZA"])
                {
                    auxPar.Value = oCR_DOCTOPAGOMOVIL.IVENTACOBRANZA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SALDOANTERIOR", FbDbType.Numeric);
                if (!(bool)oCR_DOCTOPAGOMOVIL.isnull["ISALDOANTERIOR"])
                {
                    auxPar.Value = oCR_DOCTOPAGOMOVIL.ISALDOANTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SALDONUEVO", FbDbType.Numeric);
                if (!(bool)oCR_DOCTOPAGOMOVIL.isnull["ISALDONUEVO"])
                {
                    auxPar.Value = oCR_DOCTOPAGOMOVIL.ISALDONUEVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SALDOPAGO", FbDbType.Numeric);
                if (!(bool)oCR_DOCTOPAGOMOVIL.isnull["ISALDOPAGO"])
                {
                    auxPar.Value = oCR_DOCTOPAGOMOVIL.ISALDOPAGO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO R_DOCTOPAGOMOVIL
      (
    
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

PAGOMOVILID,

COBRANZAID,

ESTATUS,

FECHA,

CORTEID,

IMPORTE,

REVERTIDO,

R_DOCTOPAGOMOVILREFID,

TIPOPAGOID,

VENTACOBRANZA,

SALDOANTERIOR,

SALDONUEVO,

SALDOPAGO
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@PAGOMOVILID,

@COBRANZAID,

@ESTATUS,

@FECHA,

@CORTEID,

@IMPORTE,

@REVERTIDO,

@R_DOCTOPAGOMOVILREFID,

@TIPOPAGOID,

@VENTACOBRANZA,

@SALDOANTERIOR,

@SALDONUEVO,

@SALDOPAGO
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCR_DOCTOPAGOMOVIL;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarR_DOCTOPAGOMOVILD(CR_DOCTOPAGOMOVILBE oCR_DOCTOPAGOMOVIL, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCR_DOCTOPAGOMOVIL.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from R_DOCTOPAGOMOVIL
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



        public bool BorrarR_DOCTOPAGOMOVIL_x_PAGOMOVILID(long pagoMovilId, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@PAGOMOVILID", FbDbType.BigInt);
                auxPar.Value = pagoMovilId;
                parts.Add(auxPar);



                string commandText = @"  Delete from R_DOCTOPAGOMOVIL where PAGOMOVILID = @PAGOMOVILID ;";

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


        public bool CambiarR_DOCTOPAGOMOVILD(CR_DOCTOPAGOMOVILBE oCR_DOCTOPAGOMOVILNuevo, CR_DOCTOPAGOMOVILBE oCR_DOCTOPAGOMOVILAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCR_DOCTOPAGOMOVILNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCR_DOCTOPAGOMOVILNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCR_DOCTOPAGOMOVILNuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCR_DOCTOPAGOMOVILNuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCR_DOCTOPAGOMOVILNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCR_DOCTOPAGOMOVILNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PAGOMOVILID", FbDbType.BigInt);
                if (!(bool)oCR_DOCTOPAGOMOVILNuevo.isnull["IPAGOMOVILID"])
                {
                    auxPar.Value = oCR_DOCTOPAGOMOVILNuevo.IPAGOMOVILID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@COBRANZAID", FbDbType.BigInt);
                if (!(bool)oCR_DOCTOPAGOMOVILNuevo.isnull["ICOBRANZAID"])
                {
                    auxPar.Value = oCR_DOCTOPAGOMOVILNuevo.ICOBRANZAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESTATUS", FbDbType.BigInt);
                if (!(bool)oCR_DOCTOPAGOMOVILNuevo.isnull["IESTATUS"])
                {
                    auxPar.Value = oCR_DOCTOPAGOMOVILNuevo.IESTATUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCR_DOCTOPAGOMOVILNuevo.isnull["IFECHA"])
                {
                    auxPar.Value = oCR_DOCTOPAGOMOVILNuevo.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                if (!(bool)oCR_DOCTOPAGOMOVILNuevo.isnull["ICORTEID"])
                {
                    auxPar.Value = oCR_DOCTOPAGOMOVILNuevo.ICORTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPORTE", FbDbType.Numeric);
                if (!(bool)oCR_DOCTOPAGOMOVILNuevo.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCR_DOCTOPAGOMOVILNuevo.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@REVERTIDO", FbDbType.Char);
                if (!(bool)oCR_DOCTOPAGOMOVILNuevo.isnull["IREVERTIDO"])
                {
                    auxPar.Value = oCR_DOCTOPAGOMOVILNuevo.IREVERTIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@R_DOCTOPAGOMOVILREFID", FbDbType.BigInt);
                if (!(bool)oCR_DOCTOPAGOMOVILNuevo.isnull["IR_DOCTOPAGOMOVILREFID"])
                {
                    auxPar.Value = oCR_DOCTOPAGOMOVILNuevo.IR_DOCTOPAGOMOVILREFID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOPAGOID", FbDbType.BigInt);
                if (!(bool)oCR_DOCTOPAGOMOVILNuevo.isnull["ITIPOPAGOID"])
                {
                    auxPar.Value = oCR_DOCTOPAGOMOVILNuevo.ITIPOPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENTACOBRANZA", FbDbType.VarChar);
                if (!(bool)oCR_DOCTOPAGOMOVILNuevo.isnull["IVENTACOBRANZA"])
                {
                    auxPar.Value = oCR_DOCTOPAGOMOVILNuevo.IVENTACOBRANZA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SALDOANTERIOR", FbDbType.Numeric);
                if (!(bool)oCR_DOCTOPAGOMOVILNuevo.isnull["ISALDOANTERIOR"])
                {
                    auxPar.Value = oCR_DOCTOPAGOMOVILNuevo.ISALDOANTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SALDONUEVO", FbDbType.Numeric);
                if (!(bool)oCR_DOCTOPAGOMOVILNuevo.isnull["ISALDONUEVO"])
                {
                    auxPar.Value = oCR_DOCTOPAGOMOVILNuevo.ISALDONUEVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SALDOPAGO", FbDbType.Numeric);
                if (!(bool)oCR_DOCTOPAGOMOVILNuevo.isnull["ISALDOPAGO"])
                {
                    auxPar.Value = oCR_DOCTOPAGOMOVILNuevo.ISALDOPAGO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCR_DOCTOPAGOMOVILAnterior.isnull["IID"])
                {
                    auxPar.Value = oCR_DOCTOPAGOMOVILAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  R_DOCTOPAGOMOVIL
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

PAGOMOVILID=@PAGOMOVILID,

COBRANZAID=@COBRANZAID,

ESTATUS=@ESTATUS,

FECHA=@FECHA,

CORTEID=@CORTEID,

IMPORTE=@IMPORTE,

REVERTIDO=@REVERTIDO,

R_DOCTOPAGOMOVILREFID=@R_DOCTOPAGOMOVILREFID,

TIPOPAGOID=@TIPOPAGOID,

VENTACOBRANZA=@VENTACOBRANZA,

SALDOANTERIOR=@SALDOANTERIOR,

SALDONUEVO=@SALDONUEVO,

SALDOPAGO=@SALDOPAGO
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


        public CR_DOCTOPAGOMOVILBE seleccionarR_DOCTOPAGOMOVIL(CR_DOCTOPAGOMOVILBE oCR_DOCTOPAGOMOVIL, FbTransaction st)
        {




            CR_DOCTOPAGOMOVILBE retorno = new CR_DOCTOPAGOMOVILBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from R_DOCTOPAGOMOVIL where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCR_DOCTOPAGOMOVIL.IID;
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

                    if (dr["R_DOCTOPAGOMOVILREFID"] != System.DBNull.Value)
                    {
                        retorno.IR_DOCTOPAGOMOVILREFID = (long)(dr["R_DOCTOPAGOMOVILREFID"]);
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



        public List<CR_DOCTOPAGOMOVILBE> seleccionarR_DOCTOPAGOMOVIL_ID_POR_VENDEDOR(string vendedor, FbTransaction st)
        {

            List<CR_DOCTOPAGOMOVILBE> retorno = new List<CR_DOCTOPAGOMOVILBE>();
            CR_DOCTOPAGOMOVILBE auxPago = new CR_DOCTOPAGOMOVILBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select

       r_pagomovil.id,
       r_pagomovil.personaclave,
       persona.nombre  nombrecliente,
       r_doctopagomovil.ventacobranza,
       r_doctopagomovil.saldoanterior,
       r_doctopagomovil.importe,
       r_doctopagomovil.saldonuevo,
       case when r_pagomovil.formapagoid = 1 then r_doctopagomovil.importe else 0 end efectivo, 
       case when r_pagomovil.formapagoid = 3 then r_doctopagomovil.importe else 0 end cheque



       from  r_pagomovil
          left join r_doctopagomovil on r_doctopagomovil.pagomovilid = r_pagomovil.id
        left join persona on persona.tipopersonaid = 50 and
            persona.clave = r_pagomovil.personaclave
        where (r_pagomovil.procesado is null or  r_pagomovil.procesado <> 'S')
           and r_pagomovil.vendedor = @vendedor ";


                auxPar = new FbParameter("@vendedor", FbDbType.VarChar);
                auxPar.Value = vendedor;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                while (dr.Read())
                {
                    auxPago = new CR_DOCTOPAGOMOVILBE();

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        auxPago.IID = (long)(dr["ID"]);
                    }

                    retorno.Add(auxPago);

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





        public DataSet enlistarR_DOCTOPAGOMOVIL()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_R_DOCTOPAGOMOVIL_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }






        public DataSet enlistarCortoR_DOCTOPAGOMOVIL()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_R_DOCTOPAGOMOVIL_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExisteR_DOCTOPAGOMOVIL(CR_DOCTOPAGOMOVILBE oCR_DOCTOPAGOMOVIL, FbTransaction st)
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
                auxPar.Value = oCR_DOCTOPAGOMOVIL.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from R_DOCTOPAGOMOVIL where

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




        public CR_DOCTOPAGOMOVILBE AgregarR_DOCTOPAGOMOVIL(CR_DOCTOPAGOMOVILBE oCR_DOCTOPAGOMOVIL, FbTransaction st)
        {
            try
            {
                int iRes = ExisteR_DOCTOPAGOMOVIL(oCR_DOCTOPAGOMOVIL, st);
                if (iRes == 1)
                {
                    this.IComentario = "El R_DOCTOPAGOMOVIL ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarR_DOCTOPAGOMOVILD(oCR_DOCTOPAGOMOVIL, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarR_DOCTOPAGOMOVIL(CR_DOCTOPAGOMOVILBE oCR_DOCTOPAGOMOVIL, FbTransaction st)
        {
            try
            {
                int iRes = ExisteR_DOCTOPAGOMOVIL(oCR_DOCTOPAGOMOVIL, st);
                if (iRes == 0)
                {
                    this.IComentario = "El R_DOCTOPAGOMOVIL no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarR_DOCTOPAGOMOVILD(oCR_DOCTOPAGOMOVIL, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarR_DOCTOPAGOMOVIL(CR_DOCTOPAGOMOVILBE oCR_DOCTOPAGOMOVILNuevo, CR_DOCTOPAGOMOVILBE oCR_DOCTOPAGOMOVILAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteR_DOCTOPAGOMOVIL(oCR_DOCTOPAGOMOVILAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El R_DOCTOPAGOMOVIL no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarR_DOCTOPAGOMOVILD(oCR_DOCTOPAGOMOVILNuevo, oCR_DOCTOPAGOMOVILAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }




        public CR_DOCTOPAGOMOVILBE[] seleccionarR_DOCTOPAGOMOVIL_DEPAGO(long pagoMovilId, FbTransaction st)
        {



            ArrayList retArray = new ArrayList();

            CR_DOCTOPAGOMOVILBE retorno = new CR_DOCTOPAGOMOVILBE();
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from R_DOCTOPAGOMOVIL where
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
                    retorno = new CR_DOCTOPAGOMOVILBE();
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

                    if (dr["R_DOCTOPAGOMOVILREFID"] != System.DBNull.Value)
                    {
                        retorno.IR_DOCTOPAGOMOVILREFID = (long)(dr["R_DOCTOPAGOMOVILREFID"]);
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



                CR_DOCTOPAGOMOVILBE[] ret = new CR_DOCTOPAGOMOVILBE[retArray.Count];
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




        public CR_DOCTOPAGOMOVILD(string conn)
        {
            this.sCadenaConexion = conn;
        }


            public CR_DOCTOPAGOMOVILD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
