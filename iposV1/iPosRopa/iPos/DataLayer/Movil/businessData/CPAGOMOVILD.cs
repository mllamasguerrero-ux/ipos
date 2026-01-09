


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


    public class CPAGOMOVILD
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
        public CPAGOMOVILBE AgregarPAGOMOVILD(CPAGOMOVILBE oCPAGOMOVIL, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@TIPOPAGOID", FbDbType.BigInt);
                if (!(bool)oCPAGOMOVIL.isnull["ITIPOPAGOID"])
                {
                    auxPar.Value = oCPAGOMOVIL.ITIPOPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUS", FbDbType.BigInt);
                if (!(bool)oCPAGOMOVIL.isnull["IESTATUS"])
                {
                    auxPar.Value = oCPAGOMOVIL.IESTATUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@USUARIOID", FbDbType.BigInt);
                if (!(bool)oCPAGOMOVIL.isnull["IUSUARIOID"])
                {
                    auxPar.Value = oCPAGOMOVIL.IUSUARIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCPAGOMOVIL.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCPAGOMOVIL.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FORMAPAGOID", FbDbType.BigInt);
                if (!(bool)oCPAGOMOVIL.isnull["IFORMAPAGOID"])
                {
                    auxPar.Value = oCPAGOMOVIL.IFORMAPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCPAGOMOVIL.isnull["IFECHA"])
                {
                    auxPar.Value = oCPAGOMOVIL.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                if (!(bool)oCPAGOMOVIL.isnull["ICORTEID"])
                {
                    auxPar.Value = oCPAGOMOVIL.ICORTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTE", FbDbType.Numeric);
                if (!(bool)oCPAGOMOVIL.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCPAGOMOVIL.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTERECIBIDO", FbDbType.Numeric);
                if (!(bool)oCPAGOMOVIL.isnull["IIMPORTERECIBIDO"])
                {
                    auxPar.Value = oCPAGOMOVIL.IIMPORTERECIBIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPORTECAMBIO", FbDbType.Numeric);
                if (!(bool)oCPAGOMOVIL.isnull["IIMPORTECAMBIO"])
                {
                    auxPar.Value = oCPAGOMOVIL.IIMPORTECAMBIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@BANCO", FbDbType.BigInt);
                if (!(bool)oCPAGOMOVIL.isnull["IBANCO"])
                {
                    auxPar.Value = oCPAGOMOVIL.IBANCO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIABANCARIA", FbDbType.VarChar);
                if (!(bool)oCPAGOMOVIL.isnull["IREFERENCIABANCARIA"])
                {
                    auxPar.Value = oCPAGOMOVIL.IREFERENCIABANCARIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOTAS", FbDbType.VarChar);
                if (!(bool)oCPAGOMOVIL.isnull["INOTAS"])
                {
                    auxPar.Value = oCPAGOMOVIL.INOTAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAELABORACION", FbDbType.Date);
                if (!(bool)oCPAGOMOVIL.isnull["IFECHAELABORACION"])
                {
                    auxPar.Value = oCPAGOMOVIL.IFECHAELABORACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHARECEPCION", FbDbType.Date);
                if (!(bool)oCPAGOMOVIL.isnull["IFECHARECEPCION"])
                {
                    auxPar.Value = oCPAGOMOVIL.IFECHARECEPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PAGOMOVILREFID", FbDbType.BigInt);
                if (!(bool)oCPAGOMOVIL.isnull["IPAGOMOVILREFID"])
                {
                    auxPar.Value = oCPAGOMOVIL.IPAGOMOVILREFID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PERSONACLAVE", FbDbType.VarChar);
                if (!(bool)oCPAGOMOVIL.isnull["IPERSONACLAVE"])
                {
                    auxPar.Value = oCPAGOMOVIL.IPERSONACLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@APLICADO", FbDbType.Numeric);
                if (!(bool)oCPAGOMOVIL.isnull["IAPLICADO"])
                {
                    auxPar.Value = oCPAGOMOVIL.IAPLICADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@BANCOTEXT", FbDbType.VarChar);
                if (!(bool)oCPAGOMOVIL.isnull["IBANCOTEXT"])
                {
                    auxPar.Value = oCPAGOMOVIL.IBANCOTEXT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOTEXT", FbDbType.VarChar);
                if (!(bool)oCPAGOMOVIL.isnull["ITIPOTEXT"])
                {
                    auxPar.Value = oCPAGOMOVIL.ITIPOTEXT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PAGOMOVILID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"PAGOMOVIL_INSERT";

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
                        return null;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    oCPAGOMOVIL.IID = (long)arParms[arParms.Length - 2].Value;
                }




                return oCPAGOMOVIL;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }




       public bool CancelarPAGOMOVILD(CPAGOMOVILBE oCPAGOMOVIL, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@PAGOMOVILID", FbDbType.BigInt);
                if (!(bool)oCPAGOMOVIL.isnull["IID"])
                {
                    auxPar.Value = oCPAGOMOVIL.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                if (!(bool)oCPAGOMOVIL.isnull["ICORTEID"])
                {
                    auxPar.Value = oCPAGOMOVIL.ICORTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"DOCTOPAGOMOVIL_CANCELAR";

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
        public bool BorrarPAGOMOVILD(CPAGOMOVILBE oCPAGOMOVIL, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPAGOMOVIL.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from PAGOMOVIL
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



        public bool CambiarPARAAPLICARPAGOMOVILD(CPAGOMOVILBE oCPAGOMOVILNuevo, CPAGOMOVILBE oCPAGOMOVILAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@ESTATUS", FbDbType.BigInt);
                if (!(bool)oCPAGOMOVILNuevo.isnull["IESTATUS"])
                {
                    auxPar.Value = oCPAGOMOVILNuevo.IESTATUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@IMPORTECAMBIO", FbDbType.Decimal);
                if (!(bool)oCPAGOMOVILNuevo.isnull["IIMPORTECAMBIO"])
                {
                    auxPar.Value = oCPAGOMOVILNuevo.IIMPORTECAMBIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCPAGOMOVILAnterior.isnull["IID"])
                {
                    auxPar.Value = oCPAGOMOVILAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  PAGOMOVIL
  set

ESTATUS=@ESTATUS, IMPORTECAMBIO = @IMPORTECAMBIO
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
        public bool CambiarPAGOMOVILD(CPAGOMOVILBE oCPAGOMOVILNuevo, CPAGOMOVILBE oCPAGOMOVILAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@TIPOPAGOID", FbDbType.BigInt);
                if (!(bool)oCPAGOMOVILNuevo.isnull["ITIPOPAGOID"])
                {
                    auxPar.Value = oCPAGOMOVILNuevo.ITIPOPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESTATUS", FbDbType.BigInt);
                if (!(bool)oCPAGOMOVILNuevo.isnull["IESTATUS"])
                {
                    auxPar.Value = oCPAGOMOVILNuevo.IESTATUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@USUARIOID", FbDbType.BigInt);
                if (!(bool)oCPAGOMOVILNuevo.isnull["IUSUARIOID"])
                {
                    auxPar.Value = oCPAGOMOVILNuevo.IUSUARIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCPAGOMOVILNuevo.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCPAGOMOVILNuevo.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FORMAPAGOID", FbDbType.BigInt);
                if (!(bool)oCPAGOMOVILNuevo.isnull["IFORMAPAGOID"])
                {
                    auxPar.Value = oCPAGOMOVILNuevo.IFORMAPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCPAGOMOVILNuevo.isnull["IFECHA"])
                {
                    auxPar.Value = oCPAGOMOVILNuevo.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                if (!(bool)oCPAGOMOVILNuevo.isnull["ICORTEID"])
                {
                    auxPar.Value = oCPAGOMOVILNuevo.ICORTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPORTE", FbDbType.Numeric);
                if (!(bool)oCPAGOMOVILNuevo.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCPAGOMOVILNuevo.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPORTERECIBIDO", FbDbType.Numeric);
                if (!(bool)oCPAGOMOVILNuevo.isnull["IIMPORTERECIBIDO"])
                {
                    auxPar.Value = oCPAGOMOVILNuevo.IIMPORTERECIBIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPORTECAMBIO", FbDbType.Numeric);
                if (!(bool)oCPAGOMOVILNuevo.isnull["IIMPORTECAMBIO"])
                {
                    auxPar.Value = oCPAGOMOVILNuevo.IIMPORTECAMBIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@BANCO", FbDbType.BigInt);
                if (!(bool)oCPAGOMOVILNuevo.isnull["IBANCO"])
                {
                    auxPar.Value = oCPAGOMOVILNuevo.IBANCO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@REFERENCIABANCARIA", FbDbType.VarChar);
                if (!(bool)oCPAGOMOVILNuevo.isnull["IREFERENCIABANCARIA"])
                {
                    auxPar.Value = oCPAGOMOVILNuevo.IREFERENCIABANCARIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOTAS", FbDbType.VarChar);
                if (!(bool)oCPAGOMOVILNuevo.isnull["INOTAS"])
                {
                    auxPar.Value = oCPAGOMOVILNuevo.INOTAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAELABORACION", FbDbType.Date);
                if (!(bool)oCPAGOMOVILNuevo.isnull["IFECHAELABORACION"])
                {
                    auxPar.Value = oCPAGOMOVILNuevo.IFECHAELABORACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHARECEPCION", FbDbType.Date);
                if (!(bool)oCPAGOMOVILNuevo.isnull["IFECHARECEPCION"])
                {
                    auxPar.Value = oCPAGOMOVILNuevo.IFECHARECEPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PAGOMOVILREFID", FbDbType.BigInt);
                if (!(bool)oCPAGOMOVILNuevo.isnull["IPAGOMOVILREFID"])
                {
                    auxPar.Value = oCPAGOMOVILNuevo.IPAGOMOVILREFID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PERSONACLAVE", FbDbType.VarChar);
                if (!(bool)oCPAGOMOVILNuevo.isnull["IPERSONACLAVE"])
                {
                    auxPar.Value = oCPAGOMOVILNuevo.IPERSONACLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@APLICADO", FbDbType.Numeric);
                if (!(bool)oCPAGOMOVILNuevo.isnull["IAPLICADO"])
                {
                    auxPar.Value = oCPAGOMOVILNuevo.IAPLICADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCPAGOMOVILAnterior.isnull["IID"])
                {
                    auxPar.Value = oCPAGOMOVILAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  PAGOMOVIL
  set

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

PAGOMOVILREFID=@PAGOMOVILREFID,

PERSONACLAVE=@PERSONACLAVE,

APLICADO = @APLICADO
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




        public bool CambiarEnviadoWS(CPAGOMOVILBE pagoMovil, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ENVIADOWS", FbDbType.VarChar);
                if (!(bool)pagoMovil.isnull["IENVIADOWS"])
                {
                    auxPar.Value = pagoMovil.IENVIADOWS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)pagoMovil.isnull["IID"])
                {
                    auxPar.Value = pagoMovil.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  PAGOMOVIL
  set
ENVIADOWS = @ENVIADOWS
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
        public CPAGOMOVILBE seleccionarPAGOMOVIL(CPAGOMOVILBE oCPAGOMOVIL, FbTransaction st)
        {




            CPAGOMOVILBE retorno = new CPAGOMOVILBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from PAGOMOVIL where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPAGOMOVIL.IID;
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

                    if (dr["PAGOMOVILREFID"] != System.DBNull.Value)
                    {
                        retorno.IPAGOMOVILREFID = (long)(dr["PAGOMOVILREFID"]);
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
        public DataSet enlistarPAGOMOVIL()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PAGOMOVIL_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoPAGOMOVIL()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PAGOMOVIL_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExistePAGOMOVIL(CPAGOMOVILBE oCPAGOMOVIL, FbTransaction st)
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
                auxPar.Value = oCPAGOMOVIL.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from PAGOMOVIL where

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




        public CPAGOMOVILBE AgregarPAGOMOVIL(CPAGOMOVILBE oCPAGOMOVIL, FbTransaction st)
        {
            try
            {
                int iRes = ExistePAGOMOVIL(oCPAGOMOVIL, st);
                if (iRes == 1)
                {
                    this.IComentario = "El PAGOMOVIL ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarPAGOMOVILD(oCPAGOMOVIL, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarPAGOMOVIL(CPAGOMOVILBE oCPAGOMOVIL, FbTransaction st)
        {
            try
            {
                int iRes = ExistePAGOMOVIL(oCPAGOMOVIL, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PAGOMOVIL no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarPAGOMOVILD(oCPAGOMOVIL, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarPAGOMOVIL(CPAGOMOVILBE oCPAGOMOVILNuevo, CPAGOMOVILBE oCPAGOMOVILAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExistePAGOMOVIL(oCPAGOMOVILAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PAGOMOVIL no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarPAGOMOVILD(oCPAGOMOVILNuevo, oCPAGOMOVILAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }







        public CPAGOMOVILD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
