

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



    public class CR_PAGOMOVILD
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


        public CR_PAGOMOVILBE AgregarR_PAGOMOVILD(CR_PAGOMOVILBE oCR_PAGOMOVIL, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCR_PAGOMOVIL.isnull["IACTIVO"])
                {
                    auxPar.Value = oCR_PAGOMOVIL.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCR_PAGOMOVIL.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCR_PAGOMOVIL.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCR_PAGOMOVIL.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCR_PAGOMOVIL.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOPAGOID", FbDbType.BigInt);
                if (!(bool)oCR_PAGOMOVIL.isnull["ITIPOPAGOID"])
                {
                    auxPar.Value = oCR_PAGOMOVIL.ITIPOPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUS", FbDbType.BigInt);
                if (!(bool)oCR_PAGOMOVIL.isnull["IESTATUS"])
                {
                    auxPar.Value = oCR_PAGOMOVIL.IESTATUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@USUARIOID", FbDbType.BigInt);
                if (!(bool)oCR_PAGOMOVIL.isnull["IUSUARIOID"])
                {
                    auxPar.Value = oCR_PAGOMOVIL.IUSUARIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCR_PAGOMOVIL.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCR_PAGOMOVIL.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FORMAPAGOID", FbDbType.BigInt);
                if (!(bool)oCR_PAGOMOVIL.isnull["IFORMAPAGOID"])
                {
                    auxPar.Value = oCR_PAGOMOVIL.IFORMAPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCR_PAGOMOVIL.isnull["IFECHA"])
                {
                    auxPar.Value = oCR_PAGOMOVIL.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                if (!(bool)oCR_PAGOMOVIL.isnull["ICORTEID"])
                {
                    auxPar.Value = oCR_PAGOMOVIL.ICORTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTE", FbDbType.Numeric);
                if (!(bool)oCR_PAGOMOVIL.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCR_PAGOMOVIL.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTERECIBIDO", FbDbType.Numeric);
                if (!(bool)oCR_PAGOMOVIL.isnull["IIMPORTERECIBIDO"])
                {
                    auxPar.Value = oCR_PAGOMOVIL.IIMPORTERECIBIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTECAMBIO", FbDbType.Numeric);
                if (!(bool)oCR_PAGOMOVIL.isnull["IIMPORTECAMBIO"])
                {
                    auxPar.Value = oCR_PAGOMOVIL.IIMPORTECAMBIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@BANCO", FbDbType.BigInt);
                if (!(bool)oCR_PAGOMOVIL.isnull["IBANCO"])
                {
                    auxPar.Value = oCR_PAGOMOVIL.IBANCO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIABANCARIA", FbDbType.VarChar);
                if (!(bool)oCR_PAGOMOVIL.isnull["IREFERENCIABANCARIA"])
                {
                    auxPar.Value = oCR_PAGOMOVIL.IREFERENCIABANCARIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOTAS", FbDbType.VarChar);
                if (!(bool)oCR_PAGOMOVIL.isnull["INOTAS"])
                {
                    auxPar.Value = oCR_PAGOMOVIL.INOTAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAELABORACION", FbDbType.Date);
                if (!(bool)oCR_PAGOMOVIL.isnull["IFECHAELABORACION"])
                {
                    auxPar.Value = oCR_PAGOMOVIL.IFECHAELABORACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHARECEPCION", FbDbType.Date);
                if (!(bool)oCR_PAGOMOVIL.isnull["IFECHARECEPCION"])
                {
                    auxPar.Value = oCR_PAGOMOVIL.IFECHARECEPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@R_PAGOMOVILREFID", FbDbType.BigInt);
                if (!(bool)oCR_PAGOMOVIL.isnull["IR_PAGOMOVILREFID"])
                {
                    auxPar.Value = oCR_PAGOMOVIL.IR_PAGOMOVILREFID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PERSONACLAVE", FbDbType.VarChar);
                if (!(bool)oCR_PAGOMOVIL.isnull["IPERSONACLAVE"])
                {
                    auxPar.Value = oCR_PAGOMOVIL.IPERSONACLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@APLICADO", FbDbType.Numeric);
                if (!(bool)oCR_PAGOMOVIL.isnull["IAPLICADO"])
                {
                    auxPar.Value = oCR_PAGOMOVIL.IAPLICADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ENVIADOWS", FbDbType.Char);
                if (!(bool)oCR_PAGOMOVIL.isnull["IENVIADOWS"])
                {
                    auxPar.Value = oCR_PAGOMOVIL.IENVIADOWS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@BANCOTEXT", FbDbType.VarChar);
                if (!(bool)oCR_PAGOMOVIL.isnull["IBANCOTEXT"])
                {
                    auxPar.Value = oCR_PAGOMOVIL.IBANCOTEXT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOTEXT", FbDbType.VarChar);
                if (!(bool)oCR_PAGOMOVIL.isnull["ITIPOTEXT"])
                {
                    auxPar.Value = oCR_PAGOMOVIL.ITIPOTEXT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDOR", FbDbType.VarChar);
                if (!(bool)oCR_PAGOMOVIL.isnull["IVENDEDOR"])
                {
                    auxPar.Value = oCR_PAGOMOVIL.IVENDEDOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PROCESADO", FbDbType.Char);
                if (!(bool)oCR_PAGOMOVIL.isnull["IPROCESADO"])
                {
                    auxPar.Value = oCR_PAGOMOVIL.IPROCESADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PAGOIDORIGINAL", FbDbType.BigInt);
                if (!(bool)oCR_PAGOMOVIL.isnull["IPAGOIDORIGINAL"])
                {
                    auxPar.Value = oCR_PAGOMOVIL.IPAGOIDORIGINAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO R_PAGOMOVIL
      (
    
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

TIPOPAGOID,

ESTATUS,

USUARIOID,

PERSONAID,

FORMAPAGOID,

FECHA,

CORTEID,

IMPORTE,

IMPORTERECIBIDO,

IMPORTECAMBIO,

BANCO,

REFERENCIABANCARIA,

NOTAS,

FECHAELABORACION,

FECHARECEPCION,

R_PAGOMOVILREFID,

PERSONACLAVE,

APLICADO,

ENVIADOWS,

BANCOTEXT,

TIPOTEXT,

VENDEDOR,

PROCESADO,

PAGOIDORIGINAL
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@TIPOPAGOID,

@ESTATUS,

@USUARIOID,

@PERSONAID,

@FORMAPAGOID,

@FECHA,

@CORTEID,

@IMPORTE,

@IMPORTERECIBIDO,

@IMPORTECAMBIO,

@BANCO,

@REFERENCIABANCARIA,

@NOTAS,

@FECHAELABORACION,

@FECHARECEPCION,

@R_PAGOMOVILREFID,

@PERSONACLAVE,

@APLICADO,

@ENVIADOWS,

@BANCOTEXT,

@TIPOTEXT,

@VENDEDOR,

@PROCESADO,

@PAGOIDORIGINAL
) RETURNING ID; ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                Object result = null;


                if (st == null)
                    result = SqlHelper.ExecuteScalar(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    result = SqlHelper.ExecuteScalar(st, CommandType.Text, commandText, arParms);


                oCR_PAGOMOVIL.IID = (long)result;






                return oCR_PAGOMOVIL;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarR_PAGOMOVILD(CR_PAGOMOVILBE oCR_PAGOMOVIL, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCR_PAGOMOVIL.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from R_PAGOMOVIL
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



        public bool BorrarR_PAGOMOVIL_x_REFID(long refPagoId, string vendedor, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@R_PAGOMOVILREFID", FbDbType.BigInt);
                auxPar.Value = refPagoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDOR", FbDbType.VarChar);
                auxPar.Value = vendedor;
                parts.Add(auxPar);


                string commandText = @"  Delete from R_PAGOMOVIL where R_PAGOMOVILREFID = @R_PAGOMOVILREFID AND VENDEDOR = @VENDEDOR;";

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


        public bool CambiarR_PAGOMOVILD(CR_PAGOMOVILBE oCR_PAGOMOVILNuevo, CR_PAGOMOVILBE oCR_PAGOMOVILAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCR_PAGOMOVILNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCR_PAGOMOVILNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCR_PAGOMOVILNuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCR_PAGOMOVILNuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCR_PAGOMOVILNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCR_PAGOMOVILNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOPAGOID", FbDbType.BigInt);
                if (!(bool)oCR_PAGOMOVILNuevo.isnull["ITIPOPAGOID"])
                {
                    auxPar.Value = oCR_PAGOMOVILNuevo.ITIPOPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESTATUS", FbDbType.BigInt);
                if (!(bool)oCR_PAGOMOVILNuevo.isnull["IESTATUS"])
                {
                    auxPar.Value = oCR_PAGOMOVILNuevo.IESTATUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@USUARIOID", FbDbType.BigInt);
                if (!(bool)oCR_PAGOMOVILNuevo.isnull["IUSUARIOID"])
                {
                    auxPar.Value = oCR_PAGOMOVILNuevo.IUSUARIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCR_PAGOMOVILNuevo.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCR_PAGOMOVILNuevo.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FORMAPAGOID", FbDbType.BigInt);
                if (!(bool)oCR_PAGOMOVILNuevo.isnull["IFORMAPAGOID"])
                {
                    auxPar.Value = oCR_PAGOMOVILNuevo.IFORMAPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCR_PAGOMOVILNuevo.isnull["IFECHA"])
                {
                    auxPar.Value = oCR_PAGOMOVILNuevo.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                if (!(bool)oCR_PAGOMOVILNuevo.isnull["ICORTEID"])
                {
                    auxPar.Value = oCR_PAGOMOVILNuevo.ICORTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPORTE", FbDbType.Numeric);
                if (!(bool)oCR_PAGOMOVILNuevo.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCR_PAGOMOVILNuevo.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPORTERECIBIDO", FbDbType.Numeric);
                if (!(bool)oCR_PAGOMOVILNuevo.isnull["IIMPORTERECIBIDO"])
                {
                    auxPar.Value = oCR_PAGOMOVILNuevo.IIMPORTERECIBIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPORTECAMBIO", FbDbType.Numeric);
                if (!(bool)oCR_PAGOMOVILNuevo.isnull["IIMPORTECAMBIO"])
                {
                    auxPar.Value = oCR_PAGOMOVILNuevo.IIMPORTECAMBIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@BANCO", FbDbType.BigInt);
                if (!(bool)oCR_PAGOMOVILNuevo.isnull["IBANCO"])
                {
                    auxPar.Value = oCR_PAGOMOVILNuevo.IBANCO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@REFERENCIABANCARIA", FbDbType.VarChar);
                if (!(bool)oCR_PAGOMOVILNuevo.isnull["IREFERENCIABANCARIA"])
                {
                    auxPar.Value = oCR_PAGOMOVILNuevo.IREFERENCIABANCARIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOTAS", FbDbType.VarChar);
                if (!(bool)oCR_PAGOMOVILNuevo.isnull["INOTAS"])
                {
                    auxPar.Value = oCR_PAGOMOVILNuevo.INOTAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAELABORACION", FbDbType.Date);
                if (!(bool)oCR_PAGOMOVILNuevo.isnull["IFECHAELABORACION"])
                {
                    auxPar.Value = oCR_PAGOMOVILNuevo.IFECHAELABORACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHARECEPCION", FbDbType.Date);
                if (!(bool)oCR_PAGOMOVILNuevo.isnull["IFECHARECEPCION"])
                {
                    auxPar.Value = oCR_PAGOMOVILNuevo.IFECHARECEPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@R_PAGOMOVILREFID", FbDbType.BigInt);
                if (!(bool)oCR_PAGOMOVILNuevo.isnull["IR_PAGOMOVILREFID"])
                {
                    auxPar.Value = oCR_PAGOMOVILNuevo.IR_PAGOMOVILREFID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PERSONACLAVE", FbDbType.VarChar);
                if (!(bool)oCR_PAGOMOVILNuevo.isnull["IPERSONACLAVE"])
                {
                    auxPar.Value = oCR_PAGOMOVILNuevo.IPERSONACLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@APLICADO", FbDbType.Numeric);
                if (!(bool)oCR_PAGOMOVILNuevo.isnull["IAPLICADO"])
                {
                    auxPar.Value = oCR_PAGOMOVILNuevo.IAPLICADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ENVIADOWS", FbDbType.Char);
                if (!(bool)oCR_PAGOMOVILNuevo.isnull["IENVIADOWS"])
                {
                    auxPar.Value = oCR_PAGOMOVILNuevo.IENVIADOWS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@BANCOTEXT", FbDbType.VarChar);
                if (!(bool)oCR_PAGOMOVILNuevo.isnull["IBANCOTEXT"])
                {
                    auxPar.Value = oCR_PAGOMOVILNuevo.IBANCOTEXT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOTEXT", FbDbType.VarChar);
                if (!(bool)oCR_PAGOMOVILNuevo.isnull["ITIPOTEXT"])
                {
                    auxPar.Value = oCR_PAGOMOVILNuevo.ITIPOTEXT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENDEDOR", FbDbType.VarChar);
                if (!(bool)oCR_PAGOMOVILNuevo.isnull["IVENDEDOR"])
                {
                    auxPar.Value = oCR_PAGOMOVILNuevo.IVENDEDOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PROCESADO", FbDbType.Char);
                if (!(bool)oCR_PAGOMOVILNuevo.isnull["IPROCESADO"])
                {
                    auxPar.Value = oCR_PAGOMOVILNuevo.IPROCESADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PAGOIDORIGINAL", FbDbType.BigInt);
                if (!(bool)oCR_PAGOMOVILNuevo.isnull["IPAGOIDORIGINAL"])
                {
                    auxPar.Value = oCR_PAGOMOVILNuevo.IPAGOIDORIGINAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCR_PAGOMOVILAnterior.isnull["IID"])
                {
                    auxPar.Value = oCR_PAGOMOVILAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  R_PAGOMOVIL
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

TIPOPAGOID=@TIPOPAGOID,

ESTATUS=@ESTATUS,

USUARIOID=@USUARIOID,

PERSONAID=@PERSONAID,

FORMAPAGOID=@FORMAPAGOID,

FECHA=@FECHA,

CORTEID=@CORTEID,

IMPORTE=@IMPORTE,

IMPORTERECIBIDO=@IMPORTERECIBIDO,

IMPORTECAMBIO=@IMPORTECAMBIO,

BANCO=@BANCO,

REFERENCIABANCARIA=@REFERENCIABANCARIA,

NOTAS=@NOTAS,

FECHAELABORACION=@FECHAELABORACION,

FECHARECEPCION=@FECHARECEPCION,

R_PAGOMOVILREFID=@R_PAGOMOVILREFID,

PERSONACLAVE=@PERSONACLAVE,

APLICADO=@APLICADO,

ENVIADOWS=@ENVIADOWS,

BANCOTEXT=@BANCOTEXT,

TIPOTEXT=@TIPOTEXT,

VENDEDOR=@VENDEDOR,

PROCESADO=@PROCESADO,

PAGOIDORIGINAL = @PAGOIDORIGINAL
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






        public bool CambiarR_PAGOMOVIL_PROCESADO(CR_PAGOMOVILBE oCR_PAGOMOVILNuevo, CR_PAGOMOVILBE oCR_PAGOMOVILAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                

                auxPar = new FbParameter("@PROCESADO", FbDbType.Char);
                if (!(bool)oCR_PAGOMOVILNuevo.isnull["IPROCESADO"])
                {
                    auxPar.Value = oCR_PAGOMOVILNuevo.IPROCESADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCR_PAGOMOVILAnterior.isnull["IID"])
                {
                    auxPar.Value = oCR_PAGOMOVILAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  R_PAGOMOVIL
  set


PROCESADO=@PROCESADO
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



        public bool CambiarR_PAGOMOVIL_REFINTERNO(CR_PAGOMOVILBE oCR_PAGOMOVILNuevo, CR_PAGOMOVILBE oCR_PAGOMOVILAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@REFINTERNO", FbDbType.Char);
                if (!(bool)oCR_PAGOMOVILNuevo.isnull["IREFINTERNO"])
                {
                    auxPar.Value = oCR_PAGOMOVILNuevo.IREFINTERNO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCR_PAGOMOVILAnterior.isnull["IID"])
                {
                    auxPar.Value = oCR_PAGOMOVILAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  R_PAGOMOVIL
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




        public CR_PAGOMOVILBE seleccionarR_PAGOMOVIL(CR_PAGOMOVILBE oCR_PAGOMOVIL, FbTransaction st)
        {




            CR_PAGOMOVILBE retorno = new CR_PAGOMOVILBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from R_PAGOMOVIL where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCR_PAGOMOVIL.IID;
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

                    if (dr["TIPOPAGOID"] != System.DBNull.Value)
                    {
                        retorno.ITIPOPAGOID = (long)(dr["TIPOPAGOID"]);
                    }

                    if (dr["ESTATUS"] != System.DBNull.Value)
                    {
                        retorno.IESTATUS = (long)(dr["ESTATUS"]);
                    }

                    if (dr["USUARIOID"] != System.DBNull.Value)
                    {
                        retorno.IUSUARIOID = (long)(dr["USUARIOID"]);
                    }

                    if (dr["PERSONAID"] != System.DBNull.Value)
                    {
                        retorno.IPERSONAID = (long)(dr["PERSONAID"]);
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

                    if (dr["R_PAGOMOVILREFID"] != System.DBNull.Value)
                    {
                        retorno.IR_PAGOMOVILREFID = (long)(dr["R_PAGOMOVILREFID"]);
                    }

                    if (dr["PERSONACLAVE"] != System.DBNull.Value)
                    {
                        retorno.IPERSONACLAVE = (string)(dr["PERSONACLAVE"]);
                    }

                    if (dr["APLICADO"] != System.DBNull.Value)
                    {
                        retorno.IAPLICADO = (decimal)(dr["APLICADO"]);
                    }

                    if (dr["ENVIADOWS"] != System.DBNull.Value)
                    {
                        retorno.IENVIADOWS = (string)(dr["ENVIADOWS"]);
                    }

                    if (dr["BANCOTEXT"] != System.DBNull.Value)
                    {
                        retorno.IBANCOTEXT = (string)(dr["BANCOTEXT"]);
                    }

                    if (dr["TIPOTEXT"] != System.DBNull.Value)
                    {
                        retorno.ITIPOTEXT = (string)(dr["TIPOTEXT"]);
                    }

                    if (dr["VENDEDOR"] != System.DBNull.Value)
                    {
                        retorno.IVENDEDOR = (string)(dr["VENDEDOR"]);
                    }

                    if (dr["PROCESADO"] != System.DBNull.Value)
                    {
                        retorno.IPROCESADO = (string)(dr["PROCESADO"]);
                    }

                    if (dr["PAGOIDORIGINAL"] != System.DBNull.Value)
                    {
                        retorno.IPAGOIDORIGINAL = (long)(dr["PAGOIDORIGINAL"]);
                    }

                    if (dr["REFINTERNO"] != System.DBNull.Value)
                    {
                        retorno.IREFINTERNO = (string)(dr["REFINTERNO"]);
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







        public CR_PAGOMOVILBE seleccionarR_PAGOMOVIL_x_REFID(long refPagoId, string vendedor, FbTransaction st)
        {




            CR_PAGOMOVILBE retorno = new CR_PAGOMOVILBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from R_PAGOMOVIL  where R_PAGOMOVILREFID = @R_PAGOMOVILREFID AND VENDEDOR = @VENDEDOR;";


                auxPar = new FbParameter("@R_PAGOMOVILREFID", FbDbType.BigInt);
                auxPar.Value = refPagoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDOR", FbDbType.VarChar);
                auxPar.Value = vendedor;
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

                    if (dr["TIPOPAGOID"] != System.DBNull.Value)
                    {
                        retorno.ITIPOPAGOID = (long)(dr["TIPOPAGOID"]);
                    }

                    if (dr["ESTATUS"] != System.DBNull.Value)
                    {
                        retorno.IESTATUS = (long)(dr["ESTATUS"]);
                    }

                    if (dr["USUARIOID"] != System.DBNull.Value)
                    {
                        retorno.IUSUARIOID = (long)(dr["USUARIOID"]);
                    }

                    if (dr["PERSONAID"] != System.DBNull.Value)
                    {
                        retorno.IPERSONAID = (long)(dr["PERSONAID"]);
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

                    if (dr["R_PAGOMOVILREFID"] != System.DBNull.Value)
                    {
                        retorno.IR_PAGOMOVILREFID = (long)(dr["R_PAGOMOVILREFID"]);
                    }

                    if (dr["PERSONACLAVE"] != System.DBNull.Value)
                    {
                        retorno.IPERSONACLAVE = (string)(dr["PERSONACLAVE"]);
                    }

                    if (dr["APLICADO"] != System.DBNull.Value)
                    {
                        retorno.IAPLICADO = (decimal)(dr["APLICADO"]);
                    }

                    if (dr["ENVIADOWS"] != System.DBNull.Value)
                    {
                        retorno.IENVIADOWS = (string)(dr["ENVIADOWS"]);
                    }

                    if (dr["BANCOTEXT"] != System.DBNull.Value)
                    {
                        retorno.IBANCOTEXT = (string)(dr["BANCOTEXT"]);
                    }

                    if (dr["TIPOTEXT"] != System.DBNull.Value)
                    {
                        retorno.ITIPOTEXT = (string)(dr["TIPOTEXT"]);
                    }

                    if (dr["VENDEDOR"] != System.DBNull.Value)
                    {
                        retorno.IVENDEDOR = (string)(dr["VENDEDOR"]);
                    }

                    if (dr["PROCESADO"] != System.DBNull.Value)
                    {
                        retorno.IPROCESADO = (string)(dr["PROCESADO"]);
                    }

                    if (dr["PAGOIDORIGINAL"] != System.DBNull.Value)
                    {
                        retorno.IPAGOIDORIGINAL = (long)(dr["PAGOIDORIGINAL"]);
                    }


                    if (dr["REFINTERNO"] != System.DBNull.Value)
                    {
                        retorno.IREFINTERNO = (string)(dr["REFINTERNO"]);
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




        public List<CR_PAGOMOVILBE> seleccionarR_PAGOMOVIL_X_ENVIAR(int cantidadReg, bool bConsiderarConError, FbTransaction st)
        {



            List<CR_PAGOMOVILBE> retornoList = new List<CR_PAGOMOVILBE>();

            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                string adicionalEstado = bConsiderarConError ? ", 'E' " : "";
                String CmdTxt = @"select first " + cantidadReg.ToString() + @" * from R_PAGOMOVIL where COALESCE(PROCESADO, '') IN ('','L'" + adicionalEstado + ") order by id ";
                
                
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                while(dr.Read())
                {
                    CR_PAGOMOVILBE retorno = new CR_PAGOMOVILBE();


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

                    if (dr["TIPOPAGOID"] != System.DBNull.Value)
                    {
                        retorno.ITIPOPAGOID = (long)(dr["TIPOPAGOID"]);
                    }

                    if (dr["ESTATUS"] != System.DBNull.Value)
                    {
                        retorno.IESTATUS = (long)(dr["ESTATUS"]);
                    }

                    if (dr["USUARIOID"] != System.DBNull.Value)
                    {
                        retorno.IUSUARIOID = (long)(dr["USUARIOID"]);
                    }

                    if (dr["PERSONAID"] != System.DBNull.Value)
                    {
                        retorno.IPERSONAID = (long)(dr["PERSONAID"]);
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

                    if (dr["R_PAGOMOVILREFID"] != System.DBNull.Value)
                    {
                        retorno.IR_PAGOMOVILREFID = (long)(dr["R_PAGOMOVILREFID"]);
                    }

                    if (dr["PERSONACLAVE"] != System.DBNull.Value)
                    {
                        retorno.IPERSONACLAVE = (string)(dr["PERSONACLAVE"]);
                    }

                    if (dr["APLICADO"] != System.DBNull.Value)
                    {
                        retorno.IAPLICADO = (decimal)(dr["APLICADO"]);
                    }

                    if (dr["ENVIADOWS"] != System.DBNull.Value)
                    {
                        retorno.IENVIADOWS = (string)(dr["ENVIADOWS"]);
                    }

                    if (dr["BANCOTEXT"] != System.DBNull.Value)
                    {
                        retorno.IBANCOTEXT = (string)(dr["BANCOTEXT"]);
                    }

                    if (dr["TIPOTEXT"] != System.DBNull.Value)
                    {
                        retorno.ITIPOTEXT = (string)(dr["TIPOTEXT"]);
                    }

                    if (dr["VENDEDOR"] != System.DBNull.Value)
                    {
                        retorno.IVENDEDOR = (string)(dr["VENDEDOR"]);
                    }

                    if (dr["PROCESADO"] != System.DBNull.Value)
                    {
                        retorno.IPROCESADO = (string)(dr["PROCESADO"]);
                    }

                    if (dr["PAGOIDORIGINAL"] != System.DBNull.Value)
                    {
                        retorno.IPAGOIDORIGINAL = (long)(dr["PAGOIDORIGINAL"]);
                    }


                    if (dr["REFINTERNO"] != System.DBNull.Value)
                    {
                        retorno.IREFINTERNO = (string)(dr["REFINTERNO"]);
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





        public DataSet enlistarR_PAGOMOVIL()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_R_PAGOMOVIL_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoR_PAGOMOVIL()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_R_PAGOMOVIL_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExisteR_PAGOMOVIL(CR_PAGOMOVILBE oCR_PAGOMOVIL, FbTransaction st)
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
                auxPar.Value = oCR_PAGOMOVIL.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from R_PAGOMOVIL where

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



        public int ExisteR_PAGOMOVILXORIGINALID(CR_PAGOMOVILBE oCR_PAGOMOVIL, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@PAGOIDORIGINAL", FbDbType.BigInt);
                auxPar.Value = oCR_PAGOMOVIL.IPAGOIDORIGINAL;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from R_PAGOMOVIL where

  PAGOIDORIGINAL = @PAGOIDORIGINAL  
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


        public CR_PAGOMOVILBE AgregarR_PAGOMOVIL(CR_PAGOMOVILBE oCR_PAGOMOVIL, FbTransaction st)
        {
            try
            {
                int iRes = ExisteR_PAGOMOVIL(oCR_PAGOMOVIL, st);
                if (iRes == 1)
                {
                    this.IComentario = "El R_PAGOMOVIL ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarR_PAGOMOVILD(oCR_PAGOMOVIL, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarR_PAGOMOVIL(CR_PAGOMOVILBE oCR_PAGOMOVIL, FbTransaction st)
        {
            try
            {
                int iRes = ExisteR_PAGOMOVIL(oCR_PAGOMOVIL, st);
                if (iRes == 0)
                {
                    this.IComentario = "El R_PAGOMOVIL no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarR_PAGOMOVILD(oCR_PAGOMOVIL, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarR_PAGOMOVIL(CR_PAGOMOVILBE oCR_PAGOMOVILNuevo, CR_PAGOMOVILBE oCR_PAGOMOVILAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteR_PAGOMOVIL(oCR_PAGOMOVILAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El R_PAGOMOVIL no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarR_PAGOMOVILD(oCR_PAGOMOVILNuevo, oCR_PAGOMOVILAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }




        public bool MOVILPAGO_PROCESAR(long pagoMovilId, long vendedorId, FbTransaction st)
        {

            try
            {


                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@R_PAGOMOVILID", FbDbType.BigInt);
                auxPar.Value = pagoMovilId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = vendedorId;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"MOVILPAGO_PROCESAR";

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
                        this.iComentario = "Hubo un error : " + strMensajeErr;
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





        public List<long> seleccionarPAGOMOVILPendiente(FbTransaction st)
        {

            List<long> retornoList = new List<long>();


            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;


            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select ID FROM R_PAGOMOVIL WHERE COALESCE(PROCESADO,'') <> 'S'";







                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                while (dr.Read())
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






        public List<CR_PAGOMOVILBE> seleccionarPAGOMOVILPendienteXVendedor(string vendedor, DateTime fecha, FbTransaction st)
        {

            List<CR_PAGOMOVILBE> retornoList = new List<CR_PAGOMOVILBE>();


            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;


            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select ID FROM R_PAGOMOVIL WHERE VENDEDOR = @VENDEDOR AND COALESCE(PROCESADO,'') <> 'S' and FECHA = @FECHA";





                auxPar = new FbParameter("@VENDEDOR", FbDbType.VarChar);
                auxPar.Value = vendedor;
                parts.Add(auxPar);



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
                    CR_PAGOMOVILBE retorno = new CR_PAGOMOVILBE();


                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno.IID = (long)(dr["ID"]);
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





        public CR_PAGOMOVILD(string conn)
        {
            this.sCadenaConexion = conn;
        }


            public CR_PAGOMOVILD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
