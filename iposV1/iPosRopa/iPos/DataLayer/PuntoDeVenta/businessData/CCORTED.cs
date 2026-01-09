

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


    public class CCORTED
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


//        [AutoComplete]
//        public CCORTEBE AgregarCORTED(CCORTEBE oCCORTE, FbTransaction st)
//        {


//            try
//            {



//                System.Collections.ArrayList parts = new ArrayList();
//                FbParameter auxPar;



//                auxPar = new FbParameter("@ID", FbDbType.BigInt);
//                if (!(bool)oCCORTE.isnull["IID"])
//                {
//                    auxPar.Value = oCCORTE.IID;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
//                if (!(bool)oCCORTE.isnull["IACTIVO"])
//                {
//                    auxPar.Value = oCCORTE.IACTIVO;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
//                if (!(bool)oCCORTE.isnull["ICREADOPOR_USERID"])
//                {
//                    auxPar.Value = oCCORTE.ICREADOPOR_USERID;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
//                if (!(bool)oCCORTE.isnull["IMODIFICADOPOR_USERID"])
//                {
//                    auxPar.Value = oCCORTE.IMODIFICADOPOR_USERID;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
//                if (!(bool)oCCORTE.isnull["ISUCURSALID"])
//                {
//                    auxPar.Value = oCCORTE.ISUCURSALID;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                auxPar = new FbParameter("@CAJAID", FbDbType.BigInt);
//                if (!(bool)oCCORTE.isnull["ICAJAID"])
//                {
//                    auxPar.Value = oCCORTE.ICAJAID;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                auxPar = new FbParameter("@CAJEROID", FbDbType.BigInt);
//                if (!(bool)oCCORTE.isnull["ICAJEROID"])
//                {
//                    auxPar.Value = oCCORTE.ICAJEROID;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                auxPar = new FbParameter("@TURNOID", FbDbType.BigInt);
//                if (!(bool)oCCORTE.isnull["ITURNOID"])
//                {
//                    auxPar.Value = oCCORTE.ITURNOID;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                auxPar = new FbParameter("@FECHACORTE", FbDbType.Date);
//                if (!(bool)oCCORTE.isnull["IFECHACORTE"])
//                {
//                    auxPar.Value = oCCORTE.IFECHACORTE;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                auxPar = new FbParameter("@SALDOINICIAL", FbDbType.Numeric);
//                if (!(bool)oCCORTE.isnull["ISALDOINICIAL"])
//                {
//                    auxPar.Value = oCCORTE.ISALDOINICIAL;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                auxPar = new FbParameter("@INGRESO", FbDbType.Numeric);
//                if (!(bool)oCCORTE.isnull["IINGRESO"])
//                {
//                    auxPar.Value = oCCORTE.IINGRESO;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                auxPar = new FbParameter("@EGRESO", FbDbType.Numeric);
//                if (!(bool)oCCORTE.isnull["IEGRESO"])
//                {
//                    auxPar.Value = oCCORTE.IEGRESO;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                auxPar = new FbParameter("@DEVOLUCION", FbDbType.Numeric);
//                if (!(bool)oCCORTE.isnull["IDEVOLUCION"])
//                {
//                    auxPar.Value = oCCORTE.IDEVOLUCION;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                auxPar = new FbParameter("@APORTACION", FbDbType.Numeric);
//                if (!(bool)oCCORTE.isnull["IAPORTACION"])
//                {
//                    auxPar.Value = oCCORTE.IAPORTACION;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                auxPar = new FbParameter("@RETIRO", FbDbType.Numeric);
//                if (!(bool)oCCORTE.isnull["IRETIRO"])
//                {
//                    auxPar.Value = oCCORTE.IRETIRO;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                auxPar = new FbParameter("@SALDOFINAL", FbDbType.Numeric);
//                if (!(bool)oCCORTE.isnull["ISALDOFINAL"])
//                {
//                    auxPar.Value = oCCORTE.ISALDOFINAL;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                auxPar = new FbParameter("@NUMEROTICKETS", FbDbType.Integer);
//                if (!(bool)oCCORTE.isnull["INUMEROTICKETS"])
//                {
//                    auxPar.Value = oCCORTE.INUMEROTICKETS;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                auxPar = new FbParameter("@NUMERODEVOLUCIONES", FbDbType.Integer);
//                if (!(bool)oCCORTE.isnull["INUMERODEVOLUCIONES"])
//                {
//                    auxPar.Value = oCCORTE.INUMERODEVOLUCIONES;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                auxPar = new FbParameter("@SALDOREAL", FbDbType.Numeric);
//                if (!(bool)oCCORTE.isnull["ISALDOREAL"])
//                {
//                    auxPar.Value = oCCORTE.ISALDOREAL;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                auxPar = new FbParameter("@DIFERENCIA", FbDbType.Numeric);
//                if (!(bool)oCCORTE.isnull["IDIFERENCIA"])
//                {
//                    auxPar.Value = oCCORTE.IDIFERENCIA;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);


//                string commandText = @"
//        INSERT INTO CORTE
//      (
//    
//ID,
//
//ACTIVO,
//
//CREADO,
//
//CREADOPOR_USERID,
//
//MODIFICADO,
//
//MODIFICADOPOR_USERID,
//
//SUCURSALID,
//
//CAJAID,
//
//CAJEROID,
//
//TURNOID,
//
//FECHACORTE,
//
//INICIA,
//
//TERMINA,
//
//SALDOINICIAL,
//
//INGRESO,
//
//EGRESO,
//
//DEVOLUCION,
//
//APORTACION,
//
//RETIRO,
//
//SALDOFINAL,
//
//NUMEROTICKETS,
//
//NUMERODEVOLUCIONES,
//
//SALDOREAL,
//
//DIFERENCIA
//         )
//
//Values (
//
//@ID,
//
//@ACTIVO,
//
//@CREADOPOR_USERID,
//
//@MODIFICADOPOR_USERID,
//
//@SUCURSALID,
//
//@CAJAID,
//
//@CAJEROID,
//
//@TURNOID,
//
//@FECHACORTE,
//
//@SALDOINICIAL,
//
//@INGRESO,
//
//@EGRESO,
//
//@DEVOLUCION,
//
//@APORTACION,
//
//@RETIRO,
//
//@SALDOFINAL,
//
//@NUMEROTICKETS,
//
//@NUMERODEVOLUCIONES,
//
//@SALDOREAL,
//
//@DIFERENCIA
//); ";

//                FbParameter[] arParms = new FbParameter[parts.Count];
//                parts.CopyTo(arParms, 0);

//                if (st == null)
//                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
//                else
//                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






//                return oCCORTE;

//            }
//            catch (Exception e)
//            {
//                this.iComentario = e.Message + e.StackTrace;
//                return null;
//            }
//        }


        [AutoComplete]
        public bool BorrarCORTED(CCORTEBE oCCORTE, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCCORTE.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from CORTE
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


//        [AutoComplete]
//        public bool CambiarCORTED(CCORTEBE oCCORTENuevo, CCORTEBE oCCORTEAnterior, FbTransaction st)
//        {


//            try
//            {
//                System.Collections.ArrayList parts = new ArrayList();
//                FbParameter auxPar;



//                auxPar = new FbParameter("@ID", FbDbType.BigInt);
//                if (!(bool)oCCORTENuevo.isnull["IID"])
//                {
//                    auxPar.Value = oCCORTENuevo.IID;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
//                if (!(bool)oCCORTENuevo.isnull["IACTIVO"])
//                {
//                    auxPar.Value = oCCORTENuevo.IACTIVO;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
//                if (!(bool)oCCORTENuevo.isnull["ICREADOPOR_USERID"])
//                {
//                    auxPar.Value = oCCORTENuevo.ICREADOPOR_USERID;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
//                if (!(bool)oCCORTENuevo.isnull["IMODIFICADOPOR_USERID"])
//                {
//                    auxPar.Value = oCCORTENuevo.IMODIFICADOPOR_USERID;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
//                if (!(bool)oCCORTENuevo.isnull["ISUCURSALID"])
//                {
//                    auxPar.Value = oCCORTENuevo.ISUCURSALID;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@CAJAID", FbDbType.BigInt);
//                if (!(bool)oCCORTENuevo.isnull["ICAJAID"])
//                {
//                    auxPar.Value = oCCORTENuevo.ICAJAID;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@CAJEROID", FbDbType.BigInt);
//                if (!(bool)oCCORTENuevo.isnull["ICAJEROID"])
//                {
//                    auxPar.Value = oCCORTENuevo.ICAJEROID;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@TURNOID", FbDbType.BigInt);
//                if (!(bool)oCCORTENuevo.isnull["ITURNOID"])
//                {
//                    auxPar.Value = oCCORTENuevo.ITURNOID;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@FECHACORTE", FbDbType.Date);
//                if (!(bool)oCCORTENuevo.isnull["IFECHACORTE"])
//                {
//                    auxPar.Value = oCCORTENuevo.IFECHACORTE;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@SALDOINICIAL", FbDbType.Numeric);
//                if (!(bool)oCCORTENuevo.isnull["ISALDOINICIAL"])
//                {
//                    auxPar.Value = oCCORTENuevo.ISALDOINICIAL;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@INGRESO", FbDbType.Numeric);
//                if (!(bool)oCCORTENuevo.isnull["IINGRESO"])
//                {
//                    auxPar.Value = oCCORTENuevo.IINGRESO;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@EGRESO", FbDbType.Numeric);
//                if (!(bool)oCCORTENuevo.isnull["IEGRESO"])
//                {
//                    auxPar.Value = oCCORTENuevo.IEGRESO;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@DEVOLUCION", FbDbType.Numeric);
//                if (!(bool)oCCORTENuevo.isnull["IDEVOLUCION"])
//                {
//                    auxPar.Value = oCCORTENuevo.IDEVOLUCION;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@APORTACION", FbDbType.Numeric);
//                if (!(bool)oCCORTENuevo.isnull["IAPORTACION"])
//                {
//                    auxPar.Value = oCCORTENuevo.IAPORTACION;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@RETIRO", FbDbType.Numeric);
//                if (!(bool)oCCORTENuevo.isnull["IRETIRO"])
//                {
//                    auxPar.Value = oCCORTENuevo.IRETIRO;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@SALDOFINAL", FbDbType.Numeric);
//                if (!(bool)oCCORTENuevo.isnull["ISALDOFINAL"])
//                {
//                    auxPar.Value = oCCORTENuevo.ISALDOFINAL;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@NUMEROTICKETS", FbDbType.Integer);
//                if (!(bool)oCCORTENuevo.isnull["INUMEROTICKETS"])
//                {
//                    auxPar.Value = oCCORTENuevo.INUMEROTICKETS;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@NUMERODEVOLUCIONES", FbDbType.Integer);
//                if (!(bool)oCCORTENuevo.isnull["INUMERODEVOLUCIONES"])
//                {
//                    auxPar.Value = oCCORTENuevo.INUMERODEVOLUCIONES;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@SALDOREAL", FbDbType.Numeric);
//                if (!(bool)oCCORTENuevo.isnull["ISALDOREAL"])
//                {
//                    auxPar.Value = oCCORTENuevo.ISALDOREAL;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@DIFERENCIA", FbDbType.Numeric);
//                if (!(bool)oCCORTENuevo.isnull["IDIFERENCIA"])
//                {
//                    auxPar.Value = oCCORTENuevo.IDIFERENCIA;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);

//                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
//                if (!(bool)oCCORTEAnterior.isnull["IID"])
//                {
//                    auxPar.Value = oCCORTEAnterior.IID;
//                }
//                else
//                {
//                    auxPar.Value = System.DBNull.Value;
//                }
//                parts.Add(auxPar);




//                string commandText = @"
//  update  CORTE
//  set
//
//ID=@ID,
//
//ACTIVO=@ACTIVO,
//
//CREADOPOR_USERID=@CREADOPOR_USERID,
//
//MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,
//
//SUCURSALID=@SUCURSALID,
//
//CAJAID=@CAJAID,
//
//CAJEROID=@CAJEROID,
//
//TURNOID=@TURNOID,
//
//FECHACORTE=@FECHACORTE,
//
//SALDOINICIAL=@SALDOINICIAL,
//
//INGRESO=@INGRESO,
//
//EGRESO=@EGRESO,
//
//DEVOLUCION=@DEVOLUCION,
//
//APORTACION=@APORTACION,
//
//RETIRO=@RETIRO,
//
//SALDOFINAL=@SALDOFINAL,
//
//NUMEROTICKETS=@NUMEROTICKETS,
//
//NUMERODEVOLUCIONES=@NUMERODEVOLUCIONES,
//
//SALDOREAL=@SALDOREAL,
//
//DIFERENCIA=@DIFERENCIA
//  where 
//
//ID=@IDAnt
//  ;";

//                FbParameter[] arParms = new FbParameter[parts.Count];
//                parts.CopyTo(arParms, 0);


//                if (st == null)
//                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
//                else
//                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


//                return true;


//            }
//            catch (Exception e)
//            {
//                this.iComentario = e.Message + e.StackTrace;
//                return false;
//            }
//        }


        [AutoComplete]
        public CCORTEBE seleccionarCORTE(CCORTEBE oCCORTE, FbTransaction st)
        {
            CCORTEBE retorno = new CCORTEBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from CORTE where ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCCORTE.IID;
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

                    if (dr["SUCURSALID"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSALID = (long)(dr["SUCURSALID"]);
                    }

                    if (dr["CAJAID"] != System.DBNull.Value)
                    {
                        retorno.ICAJAID = (long)(dr["CAJAID"]);
                    }

                    if (dr["CAJEROID"] != System.DBNull.Value)
                    {
                        retorno.ICAJEROID = (long)(dr["CAJEROID"]);
                    }

                    if (dr["TURNOID"] != System.DBNull.Value)
                    {
                        retorno.ITURNOID = (long)(dr["TURNOID"]);
                    }

                    if (dr["FECHACORTE"] != System.DBNull.Value)
                    {
                        retorno.IFECHACORTE = (DateTime)(dr["FECHACORTE"]);
                    }

                    if (dr["INICIA"] != System.DBNull.Value)
                    {
                        retorno.IINICIA = (object)(dr["INICIA"]);
                    }

                    if (dr["TERMINA"] != System.DBNull.Value)
                    {
                        retorno.ITERMINA = (object)(dr["TERMINA"]);
                    }

                    if (dr["SALDOINICIAL"] != System.DBNull.Value)
                    {
                        retorno.ISALDOINICIAL = (decimal)(dr["SALDOINICIAL"]);
                    }

                    if (dr["INGRESO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESO = (decimal)(dr["INGRESO"]);
                    }

                    if (dr["EGRESO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESO = (decimal)(dr["EGRESO"]);
                    }

                    if (dr["DEVOLUCION"] != System.DBNull.Value)
                    {
                        retorno.IDEVOLUCION = (decimal)(dr["DEVOLUCION"]);
                    }

                    if (dr["APORTACION"] != System.DBNull.Value)
                    {
                        retorno.IAPORTACION = (decimal)(dr["APORTACION"]);
                    }

                    if (dr["RETIRO"] != System.DBNull.Value)
                    {
                        retorno.IRETIRO = (decimal)(dr["RETIRO"]);
                    }

                    if (dr["SALDOFINAL"] != System.DBNull.Value)
                    {
                        retorno.ISALDOFINAL = (decimal)(dr["SALDOFINAL"]);
                    }

                    if (dr["SALDOREAL"] != System.DBNull.Value)
                    {
                        retorno.ISALDOREAL = (decimal)(dr["SALDOREAL"]);
                    }

                    if (dr["DIFERENCIA"] != System.DBNull.Value)
                    {
                        retorno.IDIFERENCIA = (decimal)(dr["DIFERENCIA"]);
                    }

                    if (dr["NUMEROTICKETS"] != System.DBNull.Value)
                    {
                        retorno.INUMEROTICKETS = int.Parse(dr["NUMEROTICKETS"].ToString());
                    }

                    if (dr["NUMERODEVOLUCIONES"] != System.DBNull.Value)
                    {
                        retorno.INUMERODEVOLUCIONES = int.Parse(dr["NUMERODEVOLUCIONES"].ToString());
                    }


                    if (dr["INGRESOTARJETA"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOTARJETA = (decimal)(dr["INGRESOTARJETA"]);
                    }

                    if (dr["INGRESOEFECTIVO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOEFECTIVO = (decimal)(dr["INGRESOEFECTIVO"]);
                    }

                    if (dr["INGRESOCREDITO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOCREDITO = (decimal)(dr["INGRESOCREDITO"]);
                    }

                    if (dr["INGRESOCHEQUE"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOCHEQUE = (decimal)(dr["INGRESOCHEQUE"]);
                    }

                    if (dr["INGRESOVALE"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOVALE = (decimal)(dr["INGRESOVALE"]);
                    }

                    if (dr["CAMBIOCHEQUE"] != System.DBNull.Value)
                    {
                        retorno.ICAMBIOCHEQUE = (decimal)(dr["CAMBIOCHEQUE"]);
                    }

                    if (dr["PAGOPROVEEDORES"] != System.DBNull.Value)
                    {
                        retorno.IPAGOPROVEEDORES = (decimal)(dr["PAGOPROVEEDORES"]);
                    }

                    if (dr["EGRESOTARJETA"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOTARJETA = (decimal)(dr["EGRESOTARJETA"]);
                    }

                    if (dr["EGRESOEFECTIVO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOEFECTIVO = (decimal)(dr["EGRESOEFECTIVO"]);
                    }

                    if (dr["EGRESOCREDITO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOCREDITO = (decimal)(dr["EGRESOCREDITO"]);
                    }

                    if (dr["EGRESOCHEQUE"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOCHEQUE = (decimal)(dr["EGRESOCHEQUE"]);
                    }


                    if (dr["EGRESOVALE"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOVALE = (decimal)(dr["EGRESOVALE"]);
                    }


                    /*
                    if (dr["INGRESOTARJETACONTADO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOTARJETACONTADO = (decimal)(dr["INGRESOTARJETACONTADO"]);
                    }

                    if (dr["INGRESOEFECTIVOCONTADO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOEFECTIVOCONTADO = (decimal)(dr["INGRESOEFECTIVOCONTADO"]);
                    }

                    if (dr["INGRESOCHEQUECONTADO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOCHEQUECONTADO = (decimal)(dr["INGRESOCHEQUECONTADO"]);
                    }

                    if (dr["INGRESOVALECONTADO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOVALECONTADO = (decimal)(dr["INGRESOVALECONTADO"]);
                    }

                    if (dr["INGRESOTARJETAABONO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOTARJETAABONO = (decimal)(dr["INGRESOTARJETAABONO"]);
                    }

                    if (dr["INGRESOEFECTIVOABONO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOEFECTIVOABONO = (decimal)(dr["INGRESOEFECTIVOABONO"]);
                    }

                    if (dr["INGRESOCHEQUEABONO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOCHEQUEABONO = (decimal)(dr["INGRESOCHEQUEABONO"]);
                    }

                    if (dr["INGRESOVALEABONO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOVALEABONO = (decimal)(dr["INGRESOVALEABONO"]);
                    }

                    if (dr["EGRESOTARJETACONTADO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOTARJETACONTADO = (decimal)(dr["EGRESOTARJETACONTADO"]);
                    }

                    if (dr["EGRESOEFECTIVOCONTADO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOEFECTIVOCONTADO = (decimal)(dr["EGRESOEFECTIVOCONTADO"]);
                    }

                    if (dr["EGRESOCHEQUECONTADO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOCHEQUECONTADO = (decimal)(dr["EGRESOCHEQUECONTADO"]);
                    }

                    if (dr["EGRESOVALECONTADO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOVALECONTADO = (decimal)(dr["EGRESOVALECONTADO"]);
                    }

                    if (dr["EGRESOTARJETAABONO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOTARJETAABONO = (decimal)(dr["EGRESOTARJETAABONO"]);
                    }

                    if (dr["EGRESOEFECTIVOABONO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOEFECTIVOABONO = (decimal)(dr["EGRESOEFECTIVOABONO"]);
                    }

                    if (dr["EGRESOCHEQUEABONO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOCHEQUEABONO = (decimal)(dr["EGRESOCHEQUEABONO"]);
                    }

                    if (dr["EGRESOVALEABONO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOVALEABONO = (decimal)(dr["EGRESOVALEABONO"]);
                    }
                    */

                    if (dr["SALDOREALCREDITO"] != System.DBNull.Value)
                    {
                        retorno.ISALDOREALCREDITO = (decimal)(dr["SALDOREALCREDITO"]);
                    }

                    if (dr["INGRESOMONEDERO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOMONEDERO = (decimal)(dr["INGRESOMONEDERO"]);
                    }
                    if (dr["EGRESOMONEDERO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOMONEDERO = (decimal)(dr["EGRESOMONEDERO"]);
                    }

                    if (dr["INGRESOTRANSFERENCIA"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOTRANSFERENCIA = (decimal)(dr["INGRESOTRANSFERENCIA"]);
                    }
                    if (dr["EGRESOTRANSFERENCIA"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOTRANSFERENCIA = (decimal)(dr["EGRESOTRANSFERENCIA"]);
                    }

                    if (dr["INGRESOINDEFINIDO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOINDEFINIDO = (decimal)(dr["INGRESOINDEFINIDO"]);
                    }
                    if (dr["EGRESOINDEFINIDO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOINDEFINIDO = (decimal)(dr["EGRESOINDEFINIDO"]);
                    }

                    if (dr["TIPOCORTEID"] != System.DBNull.Value)
                    {
                        retorno.ITIPOCORTEID = (long)(dr["TIPOCORTEID"]);
                    }
                    if (dr["RETIROSDECAJA"] != System.DBNull.Value)
                    {
                        retorno.IRETIROSDECAJA = (decimal)(dr["RETIROSDECAJA"]);
                    }



                    if (dr["INGRESOTARJETAVENTATRASLADO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOTARJETAVENTATRASLADO = (decimal)(dr["INGRESOTARJETAVENTATRASLADO"]);
                    }

                    if (dr["INGRESOEFECTIVOVENTATRASLADO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOEFECTIVOVENTATRASLADO = (decimal)(dr["INGRESOEFECTIVOVENTATRASLADO"]);
                    }

                    if (dr["INGRESOCREDITOVENTATRASLADO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOCREDITOVENTATRASLADO = (decimal)(dr["INGRESOCREDITOVENTATRASLADO"]);
                    }

                    if (dr["INGRESOVALEVENTATRASLADO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOVALEVENTATRASLADO = (decimal)(dr["INGRESOVALEVENTATRASLADO"]);
                    }

                    if (dr["INGRESOCHEQUEVENTATRASLADO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOCHEQUEVENTATRASLADO = (decimal)(dr["INGRESOCHEQUEVENTATRASLADO"]);
                    }

                    if (dr["INGRESOMONEDEROVENTATRASLADO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOMONEDEROVENTATRASLADO = (decimal)(dr["INGRESOMONEDEROVENTATRASLADO"]);
                    }

                    if (dr["INGRESOTRANSFVENTATRASLADO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOTRANSFVENTATRASLADO = (decimal)(dr["INGRESOTRANSFVENTATRASLADO"]);
                    }

                    if (dr["EGRESOEFEVENTATRASLADO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOEFEVENTATRASLADO = (decimal)(dr["EGRESOEFEVENTATRASLADO"]);
                    }




                    if (!(dr["INGRESODEPOSITO"] == System.DBNull.Value))
                    {
                        retorno.IINGRESODEPOSITO = (decimal)(dr["INGRESODEPOSITO"]);
                    }

                    if (!(dr["EGRESODEPOSITO"] == System.DBNull.Value))
                    {
                        retorno.IEGRESODEPOSITO = (decimal)(dr["EGRESODEPOSITO"]);
                    }


                    if (!(dr["INGRESODEPOSITOVENTATRASLADO"] == System.DBNull.Value))
                    {
                        retorno.IINGRESODEPOSITOVENTATRASLADO = (decimal)(dr["INGRESODEPOSITOVENTATRASLADO"]);
                    }


                    if (!(dr["INGRESODEPTERCERO"] == System.DBNull.Value))
                    {
                        retorno.IINGRESODEPTERCERO = (decimal)(dr["INGRESODEPTERCERO"]);
                    }

                    if (!(dr["EGRESODEPTERCERO"] == System.DBNull.Value))
                    {
                        retorno.IEGRESODEPTERCERO = (decimal)(dr["EGRESODEPTERCERO"]);
                    }


                    if (!(dr["INGRESODEPTERCEROVENTATRASLADO"] == System.DBNull.Value))
                    {
                        retorno.IINGRESODEPTERCEROVENTATRASLADO = (decimal)(dr["INGRESODEPTERCEROVENTATRASLADO"]);
                    }



                    if (dr["FONDODINAMICO"] != System.DBNull.Value)
                    {
                        retorno.IFONDODINAMICO = (decimal)(dr["FONDODINAMICO"]);
                    }


                    if (dr["FONDODINAMICOFINAL"] != System.DBNull.Value)
                    {
                        retorno.IFONDODINAMICOFINAL = (decimal)(dr["FONDODINAMICOFINAL"]);
                    }


                    if (dr["CORTERECOLECCIONID"] != System.DBNull.Value)
                    {
                        retorno.ICORTERECOLECCIONID = (long)(dr["CORTERECOLECCIONID"]);
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





        public CCORTEBE seleccionarCORTEXDIAyCAJERO(CCORTEBE oCCORTE, FbTransaction st)
        {
            CCORTEBE retorno = new CCORTEBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from CORTE where fechacorte = @FECHACORTE and cajeroid = @CAJEROID order by id desc ";
                //and turnoid = @TURNOID

                auxPar = new FbParameter("@FECHACORTE", FbDbType.Date);
                auxPar.Value = oCCORTE.IFECHACORTE;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAJEROID", FbDbType.BigInt);
                auxPar.Value = oCCORTE.ICAJEROID;
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

                    if (dr["SUCURSALID"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSALID = (long)(dr["SUCURSALID"]);
                    }

                    if (dr["CAJAID"] != System.DBNull.Value)
                    {
                        retorno.ICAJAID = (long)(dr["CAJAID"]);
                    }

                    if (dr["CAJEROID"] != System.DBNull.Value)
                    {
                        retorno.ICAJEROID = (long)(dr["CAJEROID"]);
                    }

                    if (dr["TURNOID"] != System.DBNull.Value)
                    {
                        retorno.ITURNOID = (long)(dr["TURNOID"]);
                    }

                    if (dr["FECHACORTE"] != System.DBNull.Value)
                    {
                        retorno.IFECHACORTE = (DateTime)(dr["FECHACORTE"]);
                    }

                    if (dr["INICIA"] != System.DBNull.Value)
                    {
                        retorno.IINICIA = (object)(dr["INICIA"]);
                    }

                    if (dr["TERMINA"] != System.DBNull.Value)
                    {
                        retorno.ITERMINA = (object)(dr["TERMINA"]);
                    }

                    if (dr["SALDOINICIAL"] != System.DBNull.Value)
                    {
                        retorno.ISALDOINICIAL = (decimal)(dr["SALDOINICIAL"]);
                    }

                    if (dr["INGRESO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESO = (decimal)(dr["INGRESO"]);
                    }

                    if (dr["EGRESO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESO = (decimal)(dr["EGRESO"]);
                    }

                    if (dr["DEVOLUCION"] != System.DBNull.Value)
                    {
                        retorno.IDEVOLUCION = (decimal)(dr["DEVOLUCION"]);
                    }

                    if (dr["APORTACION"] != System.DBNull.Value)
                    {
                        retorno.IAPORTACION = (decimal)(dr["APORTACION"]);
                    }

                    if (dr["RETIRO"] != System.DBNull.Value)
                    {
                        retorno.IRETIRO = (decimal)(dr["RETIRO"]);
                    }

                    if (dr["SALDOFINAL"] != System.DBNull.Value)
                    {
                        retorno.ISALDOFINAL = (decimal)(dr["SALDOFINAL"]);
                    }

                    if (dr["SALDOREAL"] != System.DBNull.Value)
                    {
                        retorno.ISALDOREAL = (decimal)(dr["SALDOREAL"]);
                    }

                    if (dr["DIFERENCIA"] != System.DBNull.Value)
                    {
                        retorno.IDIFERENCIA = (decimal)(dr["DIFERENCIA"]);
                    }

                    if (dr["NUMEROTICKETS"] != System.DBNull.Value)
                    {
                        retorno.INUMEROTICKETS = int.Parse(dr["NUMEROTICKETS"].ToString());
                    }

                    if (dr["NUMERODEVOLUCIONES"] != System.DBNull.Value)
                    {
                        retorno.INUMERODEVOLUCIONES = int.Parse(dr["NUMERODEVOLUCIONES"].ToString());
                    }

                    
                    if (dr["INGRESOTARJETA"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOTARJETA = (decimal)(dr["INGRESOTARJETA"]);
                    }

                    if (dr["INGRESOEFECTIVO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOEFECTIVO = (decimal)(dr["INGRESOEFECTIVO"]);
                    }

                    if (dr["INGRESOCREDITO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOCREDITO = (decimal)(dr["INGRESOCREDITO"]);
                    }

                    if (dr["INGRESOCHEQUE"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOCHEQUE = (decimal)(dr["INGRESOCHEQUE"]);
                    }

                    if (dr["INGRESOVALE"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOVALE = (decimal)(dr["INGRESOVALE"]);
                    }


                    if (dr["CAMBIOCHEQUE"] != System.DBNull.Value)
                    {
                        retorno.ICAMBIOCHEQUE = (decimal)(dr["CAMBIOCHEQUE"]);
                    }

                    if (dr["PAGOPROVEEDORES"] != System.DBNull.Value)
                    {
                        retorno.IPAGOPROVEEDORES = (decimal)(dr["PAGOPROVEEDORES"]);
                    }
                    if (dr["EGRESOTARJETA"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOTARJETA = (decimal)(dr["EGRESOTARJETA"]);
                    }

                    if (dr["EGRESOEFECTIVO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOEFECTIVO = (decimal)(dr["EGRESOEFECTIVO"]);
                    }

                    if (dr["EGRESOCREDITO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOCREDITO = (decimal)(dr["EGRESOCREDITO"]);
                    }

                    if (dr["EGRESOCHEQUE"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOCHEQUE = (decimal)(dr["EGRESOCHEQUE"]);
                    }

                    if (dr["EGRESOVALE"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOVALE = (decimal)(dr["EGRESOVALE"]);
                    }


                    /*
                    if (dr["INGRESOTARJETACONTADO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOTARJETACONTADO = (decimal)(dr["INGRESOTARJETACONTADO"]);
                    }

                    if (dr["INGRESOEFECTIVOCONTADO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOEFECTIVOCONTADO = (decimal)(dr["INGRESOEFECTIVOCONTADO"]);
                    }

                    if (dr["INGRESOCHEQUECONTADO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOCHEQUECONTADO = (decimal)(dr["INGRESOCHEQUECONTADO"]);
                    }

                    if (dr["INGRESOVALECONTADO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOVALECONTADO = (decimal)(dr["INGRESOVALECONTADO"]);
                    }

                    if (dr["INGRESOTARJETAABONO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOTARJETAABONO = (decimal)(dr["INGRESOTARJETAABONO"]);
                    }

                    if (dr["INGRESOEFECTIVOABONO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOEFECTIVOABONO = (decimal)(dr["INGRESOEFECTIVOABONO"]);
                    }

                    if (dr["INGRESOCHEQUEABONO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOCHEQUEABONO = (decimal)(dr["INGRESOCHEQUEABONO"]);
                    }

                    if (dr["INGRESOVALEABONO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOVALEABONO = (decimal)(dr["INGRESOVALEABONO"]);
                    }

                    if (dr["EGRESOTARJETACONTADO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOTARJETACONTADO = (decimal)(dr["EGRESOTARJETACONTADO"]);
                    }

                    if (dr["EGRESOEFECTIVOCONTADO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOEFECTIVOCONTADO = (decimal)(dr["EGRESOEFECTIVOCONTADO"]);
                    }

                    if (dr["EGRESOCHEQUECONTADO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOCHEQUECONTADO = (decimal)(dr["EGRESOCHEQUECONTADO"]);
                    }

                    if (dr["EGRESOVALECONTADO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOVALECONTADO = (decimal)(dr["EGRESOVALECONTADO"]);
                    }

                    if (dr["EGRESOTARJETAABONO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOTARJETAABONO = (decimal)(dr["EGRESOTARJETAABONO"]);
                    }

                    if (dr["EGRESOEFECTIVOABONO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOEFECTIVOABONO = (decimal)(dr["EGRESOEFECTIVOABONO"]);
                    }

                    if (dr["EGRESOCHEQUEABONO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOCHEQUEABONO = (decimal)(dr["EGRESOCHEQUEABONO"]);
                    }

                    if (dr["EGRESOVALEABONO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOVALEABONO = (decimal)(dr["EGRESOVALEABONO"]);
                    }*/

                    if (dr["SALDOREALCREDITO"] != System.DBNull.Value)
                    {
                        retorno.ISALDOREALCREDITO = (decimal)(dr["SALDOREALCREDITO"]);
                    }

                    if (dr["INGRESOMONEDERO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOMONEDERO = (decimal)(dr["INGRESOMONEDERO"]);
                    }
                    if (dr["EGRESOMONEDERO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOMONEDERO = (decimal)(dr["EGRESOMONEDERO"]);
                    }

                    if (dr["INGRESOTRANSFERENCIA"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOTRANSFERENCIA = (decimal)(dr["INGRESOTRANSFERENCIA"]);
                    }
                    if (dr["EGRESOTRANSFERENCIA"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOMONEDERO = (decimal)(dr["EGRESOTRANSFERENCIA"]);
                    }


                    if (dr["INGRESOINDEFINIDO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOINDEFINIDO = (decimal)(dr["INGRESOINDEFINIDO"]);
                    }
                    if (dr["EGRESOINDEFINIDO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOINDEFINIDO = (decimal)(dr["EGRESOINDEFINIDO"]);
                    }

                    if (dr["TIPOCORTEID"] != System.DBNull.Value)
                    {
                        retorno.ITIPOCORTEID = (long)(dr["TIPOCORTEID"]);
                    }

                    if (dr["RETIROSDECAJA"] != System.DBNull.Value)
                    {
                        retorno.IRETIROSDECAJA = (decimal)(dr["RETIROSDECAJA"]);
                    }



                    if (dr["INGRESOTARJETAVENTATRASLADO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOTARJETAVENTATRASLADO = (decimal)(dr["INGRESOTARJETAVENTATRASLADO"]);
                    }

                    if (dr["INGRESOEFECTIVOVENTATRASLADO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOEFECTIVOVENTATRASLADO = (decimal)(dr["INGRESOEFECTIVOVENTATRASLADO"]);
                    }

                    if (dr["INGRESOCREDITOVENTATRASLADO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOCREDITOVENTATRASLADO = (decimal)(dr["INGRESOCREDITOVENTATRASLADO"]);
                    }

                    if (dr["INGRESOVALEVENTATRASLADO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOVALEVENTATRASLADO = (decimal)(dr["INGRESOVALEVENTATRASLADO"]);
                    }

                    if (dr["INGRESOCHEQUEVENTATRASLADO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOCHEQUEVENTATRASLADO = (decimal)(dr["INGRESOCHEQUEVENTATRASLADO"]);
                    }

                    if (dr["INGRESOMONEDEROVENTATRASLADO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOMONEDEROVENTATRASLADO = (decimal)(dr["INGRESOMONEDEROVENTATRASLADO"]);
                    }

                    if (dr["INGRESOTRANSFVENTATRASLADO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOTRANSFVENTATRASLADO = (decimal)(dr["INGRESOTRANSFVENTATRASLADO"]);
                    }


                    if (dr["EGRESOEFEVENTATRASLADO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOEFEVENTATRASLADO = (decimal)(dr["EGRESOEFEVENTATRASLADO"]);
                    }

                    if (dr["FONDODINAMICO"] != System.DBNull.Value)
                    {
                        retorno.IFONDODINAMICO = (decimal)(dr["FONDODINAMICO"]);
                    }
                    if (dr["FONDODINAMICOFINAL"] != System.DBNull.Value)
                    {
                        retorno.IFONDODINAMICOFINAL = (decimal)(dr["FONDODINAMICOFINAL"]);
                    }
                    if (dr["CORTERECOLECCIONID"] != System.DBNull.Value)
                    {
                        retorno.ICORTERECOLECCIONID = (long)(dr["CORTERECOLECCIONID"]);
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




        public CCORTEBE seleccionarCORTEACTIVOXCAJERO(CCORTEBE oCCORTE, FbTransaction st)
        {
            CCORTEBE retorno = new CCORTEBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from CORTE where activo = 'S' and cajeroid = @CAJEROID order by id desc ";
                //and turnoid = @TURNOID

                auxPar = new FbParameter("@FECHACORTE", FbDbType.Date);
                auxPar.Value = oCCORTE.IFECHACORTE;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAJEROID", FbDbType.BigInt);
                auxPar.Value = oCCORTE.ICAJEROID;
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

                    if (dr["SUCURSALID"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSALID = (long)(dr["SUCURSALID"]);
                    }

                    if (dr["CAJAID"] != System.DBNull.Value)
                    {
                        retorno.ICAJAID = (long)(dr["CAJAID"]);
                    }

                    if (dr["CAJEROID"] != System.DBNull.Value)
                    {
                        retorno.ICAJEROID = (long)(dr["CAJEROID"]);
                    }

                    if (dr["TURNOID"] != System.DBNull.Value)
                    {
                        retorno.ITURNOID = (long)(dr["TURNOID"]);
                    }

                    if (dr["FECHACORTE"] != System.DBNull.Value)
                    {
                        retorno.IFECHACORTE = (DateTime)(dr["FECHACORTE"]);
                    }

                    if (dr["INICIA"] != System.DBNull.Value)
                    {
                        retorno.IINICIA = (object)(dr["INICIA"]);
                    }

                    if (dr["TERMINA"] != System.DBNull.Value)
                    {
                        retorno.ITERMINA = (object)(dr["TERMINA"]);
                    }

                    if (dr["SALDOINICIAL"] != System.DBNull.Value)
                    {
                        retorno.ISALDOINICIAL = (decimal)(dr["SALDOINICIAL"]);
                    }

                    if (dr["INGRESO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESO = (decimal)(dr["INGRESO"]);
                    }

                    if (dr["EGRESO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESO = (decimal)(dr["EGRESO"]);
                    }

                    if (dr["DEVOLUCION"] != System.DBNull.Value)
                    {
                        retorno.IDEVOLUCION = (decimal)(dr["DEVOLUCION"]);
                    }

                    if (dr["APORTACION"] != System.DBNull.Value)
                    {
                        retorno.IAPORTACION = (decimal)(dr["APORTACION"]);
                    }

                    if (dr["RETIRO"] != System.DBNull.Value)
                    {
                        retorno.IRETIRO = (decimal)(dr["RETIRO"]);
                    }

                    if (dr["SALDOFINAL"] != System.DBNull.Value)
                    {
                        retorno.ISALDOFINAL = (decimal)(dr["SALDOFINAL"]);
                    }

                    if (dr["SALDOREAL"] != System.DBNull.Value)
                    {
                        retorno.ISALDOREAL = (decimal)(dr["SALDOREAL"]);
                    }

                    if (dr["DIFERENCIA"] != System.DBNull.Value)
                    {
                        retorno.IDIFERENCIA = (decimal)(dr["DIFERENCIA"]);
                    }

                    if (dr["NUMEROTICKETS"] != System.DBNull.Value)
                    {
                        retorno.INUMEROTICKETS = int.Parse(dr["NUMEROTICKETS"].ToString());
                    }

                    if (dr["NUMERODEVOLUCIONES"] != System.DBNull.Value)
                    {
                        retorno.INUMERODEVOLUCIONES = int.Parse(dr["NUMERODEVOLUCIONES"].ToString());
                    }


                    if (dr["INGRESOTARJETA"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOTARJETA = (decimal)(dr["INGRESOTARJETA"]);
                    }

                    if (dr["INGRESOEFECTIVO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOEFECTIVO = (decimal)(dr["INGRESOEFECTIVO"]);
                    }

                    if (dr["INGRESOCREDITO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOCREDITO = (decimal)(dr["INGRESOCREDITO"]);
                    }

                    if (dr["INGRESOCHEQUE"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOCHEQUE = (decimal)(dr["INGRESOCHEQUE"]);
                    }

                    if (dr["INGRESOVALE"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOVALE = (decimal)(dr["INGRESOVALE"]);
                    }


                    if (dr["CAMBIOCHEQUE"] != System.DBNull.Value)
                    {
                        retorno.ICAMBIOCHEQUE = (decimal)(dr["CAMBIOCHEQUE"]);
                    }

                    if (dr["PAGOPROVEEDORES"] != System.DBNull.Value)
                    {
                        retorno.IPAGOPROVEEDORES = (decimal)(dr["PAGOPROVEEDORES"]);
                    }
                    if (dr["EGRESOTARJETA"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOTARJETA = (decimal)(dr["EGRESOTARJETA"]);
                    }

                    if (dr["EGRESOEFECTIVO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOEFECTIVO = (decimal)(dr["EGRESOEFECTIVO"]);
                    }

                    if (dr["EGRESOCREDITO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOCREDITO = (decimal)(dr["EGRESOCREDITO"]);
                    }

                    if (dr["EGRESOCHEQUE"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOCHEQUE = (decimal)(dr["EGRESOCHEQUE"]);
                    }

                    if (dr["EGRESOVALE"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOVALE = (decimal)(dr["EGRESOVALE"]);
                    }


                    /*
                    if (dr["INGRESOTARJETACONTADO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOTARJETACONTADO = (decimal)(dr["INGRESOTARJETACONTADO"]);
                    }

                    if (dr["INGRESOEFECTIVOCONTADO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOEFECTIVOCONTADO = (decimal)(dr["INGRESOEFECTIVOCONTADO"]);
                    }

                    if (dr["INGRESOCHEQUECONTADO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOCHEQUECONTADO = (decimal)(dr["INGRESOCHEQUECONTADO"]);
                    }

                    if (dr["INGRESOVALECONTADO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOVALECONTADO = (decimal)(dr["INGRESOVALECONTADO"]);
                    }

                    if (dr["INGRESOTARJETAABONO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOTARJETAABONO = (decimal)(dr["INGRESOTARJETAABONO"]);
                    }

                    if (dr["INGRESOEFECTIVOABONO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOEFECTIVOABONO = (decimal)(dr["INGRESOEFECTIVOABONO"]);
                    }

                    if (dr["INGRESOCHEQUEABONO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOCHEQUEABONO = (decimal)(dr["INGRESOCHEQUEABONO"]);
                    }

                    if (dr["INGRESOVALEABONO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOVALEABONO = (decimal)(dr["INGRESOVALEABONO"]);
                    }

                    if (dr["EGRESOTARJETACONTADO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOTARJETACONTADO = (decimal)(dr["EGRESOTARJETACONTADO"]);
                    }

                    if (dr["EGRESOEFECTIVOCONTADO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOEFECTIVOCONTADO = (decimal)(dr["EGRESOEFECTIVOCONTADO"]);
                    }

                    if (dr["EGRESOCHEQUECONTADO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOCHEQUECONTADO = (decimal)(dr["EGRESOCHEQUECONTADO"]);
                    }

                    if (dr["EGRESOVALECONTADO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOVALECONTADO = (decimal)(dr["EGRESOVALECONTADO"]);
                    }

                    if (dr["EGRESOTARJETAABONO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOTARJETAABONO = (decimal)(dr["EGRESOTARJETAABONO"]);
                    }

                    if (dr["EGRESOEFECTIVOABONO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOEFECTIVOABONO = (decimal)(dr["EGRESOEFECTIVOABONO"]);
                    }

                    if (dr["EGRESOCHEQUEABONO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOCHEQUEABONO = (decimal)(dr["EGRESOCHEQUEABONO"]);
                    }

                    if (dr["EGRESOVALEABONO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOVALEABONO = (decimal)(dr["EGRESOVALEABONO"]);
                    }*/

                    if (dr["SALDOREALCREDITO"] != System.DBNull.Value)
                    {
                        retorno.ISALDOREALCREDITO = (decimal)(dr["SALDOREALCREDITO"]);
                    }

                    if (dr["INGRESOMONEDERO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOMONEDERO = (decimal)(dr["INGRESOMONEDERO"]);
                    }
                    if (dr["EGRESOMONEDERO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOMONEDERO = (decimal)(dr["EGRESOMONEDERO"]);
                    }

                    if (dr["INGRESOTRANSFERENCIA"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOTRANSFERENCIA = (decimal)(dr["INGRESOTRANSFERENCIA"]);
                    }
                    if (dr["EGRESOTRANSFERENCIA"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOMONEDERO = (decimal)(dr["EGRESOTRANSFERENCIA"]);
                    }


                    if (dr["INGRESOINDEFINIDO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOINDEFINIDO = (decimal)(dr["INGRESOINDEFINIDO"]);
                    }
                    if (dr["EGRESOINDEFINIDO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOINDEFINIDO = (decimal)(dr["EGRESOINDEFINIDO"]);
                    }

                    if (dr["TIPOCORTEID"] != System.DBNull.Value)
                    {
                        retorno.ITIPOCORTEID = (long)(dr["TIPOCORTEID"]);
                    }

                    if (dr["RETIROSDECAJA"] != System.DBNull.Value)
                    {
                        retorno.IRETIROSDECAJA = (decimal)(dr["RETIROSDECAJA"]);
                    }


                    if (dr["INGRESOTARJETAVENTATRASLADO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOTARJETAVENTATRASLADO = (decimal)(dr["INGRESOTARJETAVENTATRASLADO"]);
                    }

                    if (dr["INGRESOEFECTIVOVENTATRASLADO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOEFECTIVOVENTATRASLADO = (decimal)(dr["INGRESOEFECTIVOVENTATRASLADO"]);
                    }

                    if (dr["INGRESOCREDITOVENTATRASLADO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOCREDITOVENTATRASLADO = (decimal)(dr["INGRESOCREDITOVENTATRASLADO"]);
                    }

                    if (dr["INGRESOVALEVENTATRASLADO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOVALEVENTATRASLADO = (decimal)(dr["INGRESOVALEVENTATRASLADO"]);
                    }

                    if (dr["INGRESOCHEQUEVENTATRASLADO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOCHEQUEVENTATRASLADO = (decimal)(dr["INGRESOCHEQUEVENTATRASLADO"]);
                    }

                    if (dr["INGRESOMONEDEROVENTATRASLADO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOMONEDEROVENTATRASLADO = (decimal)(dr["INGRESOMONEDEROVENTATRASLADO"]);
                    }

                    if (dr["INGRESOTRANSFVENTATRASLADO"] != System.DBNull.Value)
                    {
                        retorno.IINGRESOTRANSFVENTATRASLADO = (decimal)(dr["INGRESOTRANSFVENTATRASLADO"]);
                    }

                    if (dr["EGRESOEFEVENTATRASLADO"] != System.DBNull.Value)
                    {
                        retorno.IEGRESOEFEVENTATRASLADO = (decimal)(dr["EGRESOEFEVENTATRASLADO"]);
                    }





                    if (!(dr["INGRESODEPOSITO"] == System.DBNull.Value))
                    {
                        retorno.IINGRESODEPOSITO = (decimal)(dr["INGRESODEPOSITO"]);
                    }

                    if (!(dr["EGRESODEPOSITO"] == System.DBNull.Value))
                    {
                        retorno.IEGRESODEPOSITO = (decimal)(dr["EGRESODEPOSITO"]);
                    }


                    if (!(dr["INGRESODEPOSITOVENTATRASLADO"] == System.DBNull.Value))
                    {
                        retorno.IINGRESODEPOSITOVENTATRASLADO = (decimal)(dr["INGRESODEPOSITOVENTATRASLADO"]);
                    }


                    if (!(dr["INGRESODEPTERCERO"] == System.DBNull.Value))
                    {
                        retorno.IINGRESODEPTERCERO = (decimal)(dr["INGRESODEPTERCERO"]);
                    }

                    if (!(dr["EGRESODEPTERCERO"] == System.DBNull.Value))
                    {
                        retorno.IEGRESODEPTERCERO = (decimal)(dr["EGRESODEPTERCERO"]);
                    }


                    if (!(dr["INGRESODEPTERCEROVENTATRASLADO"] == System.DBNull.Value))
                    {
                        retorno.IINGRESODEPTERCEROVENTATRASLADO = (decimal)(dr["INGRESODEPTERCEROVENTATRASLADO"]);
                    }




                    if (dr["FONDODINAMICO"] != System.DBNull.Value)
                    {
                        retorno.IFONDODINAMICO = (decimal)(dr["FONDODINAMICO"]);
                    }
                    if (dr["FONDODINAMICOFINAL"] != System.DBNull.Value)
                    {
                        retorno.IFONDODINAMICOFINAL = (decimal)(dr["FONDODINAMICOFINAL"]);
                    }
                    if (dr["CORTERECOLECCIONID"] != System.DBNull.Value)
                    {
                        retorno.ICORTERECOLECCIONID = (long)(dr["CORTERECOLECCIONID"]);
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
        public DataSet enlistarCORTE()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_CORTE_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoCORTE()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_CORTE_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteCORTE(CCORTEBE oCCORTE, FbTransaction st)
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
                auxPar.Value = oCCORTE.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from CORTE where

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




        //public CCORTEBE AgregarCORTE(CCORTEBE oCCORTE, FbTransaction st)
        //{
        //    try
        //    {
        //        int iRes = ExisteCORTE(oCCORTE, st);
        //        if (iRes == 1)
        //        {
        //            this.IComentario = "El CORTE ya existe";
        //            return null;
        //        }
        //        else if (iRes == -1)
        //        {
        //            return null;
        //        }
        //        return AgregarCORTED(oCCORTE, st);
        //    }
        //    catch (Exception e)
        //    {
        //        this.iComentario = e.Message + e.StackTrace;
        //        return null;
        //    }
        //}


        public bool BorrarCORTE(CCORTEBE oCCORTE, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCORTE(oCCORTE, st);
                if (iRes == 0)
                {
                    this.IComentario = "El CORTE no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarCORTED(oCCORTE, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        //public bool CambiarCORTE(CCORTEBE oCCORTENuevo, CCORTEBE oCCORTEAnterior, FbTransaction st)
        //{
        //    try
        //    {
        //        int iRes = ExisteCORTE(oCCORTEAnterior, st);
        //        if (iRes == 0)
        //        {
        //            this.IComentario = "El CORTE no existe";
        //            return false;
        //        }
        //        else if (iRes == -1)
        //        {
        //            return false;
        //        }
        //        return CambiarCORTED(oCCORTENuevo, oCCORTEAnterior, st);
        //    }
        //    catch (Exception e)
        //    {
        //        this.iComentario = e.Message + e.StackTrace;
        //        return false;
        //    }

        //}



        public bool HayCorteActivo(long cajeroId, FbTransaction st, ref DateTime fechaCorteActual )
        {
            long corteId = 0;
            return HayCorteActivo(cajeroId,st,ref fechaCorteActual, ref corteId);
        }

        public bool HayCorteActivo(long cajeroId,FbTransaction st,ref DateTime fechaCorteActual, ref long corteId)
        {
            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@CAJEROID", FbDbType.BigInt);
                auxPar.Value = cajeroId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHACORTE", FbDbType.Date);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@HAYCORTEACTIVO", FbDbType.Char);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@corteid", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"HAY_CORTE_ACTIVO";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);


                if ((int)arParms[arParms.Length - 1].Value != 0)
                    return false;

                
                if (arParms[arParms.Length - 2].Value != null)
                    corteId = (long)arParms[arParms.Length - 2].Value;
                else
                    corteId = 0;

                if (arParms[arParms.Length - 4].Value != null)
                    fechaCorteActual = (DateTime)arParms[arParms.Length - 4].Value;
                else
                    fechaCorteActual = DateTime.MinValue;

                
                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }

        public CCORTEBE AbrirCORTED(CCORTEBE oCCORTE, FbTransaction st)
        {
            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@FECHACORTE", FbDbType.Date);
                if (!(bool)oCCORTE.isnull["IFECHACORTE"])
                {
                    auxPar.Value = oCCORTE.IFECHACORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (!(bool)oCCORTE.isnull["ISUCURSALID"])
                {
                    auxPar.Value = oCCORTE.ISUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                /*auxPar = new FbParameter("@CAJAID", FbDbType.BigInt);
                if (!(bool)oCCORTE.isnull["ICAJAID"])
                {
                    auxPar.Value = oCCORTE.ICAJAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);*/


                auxPar = new FbParameter("@CAJEROID", FbDbType.BigInt);
                if (!(bool)oCCORTE.isnull["ICAJEROID"])
                {
                    auxPar.Value = oCCORTE.ICAJEROID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                /*auxPar = new FbParameter("@TURNOID", FbDbType.BigInt);
                if (!(bool)oCCORTE.isnull["ITURNOID"])
                {
                    auxPar.Value = oCCORTE.ITURNOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);*/



                auxPar = new FbParameter("@SALDOINICIAL", FbDbType.Numeric);
                if (!(bool)oCCORTE.isnull["ISALDOINICIAL"])
                {
                    auxPar.Value = oCCORTE.ISALDOINICIAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOCORTEID", FbDbType.BigInt);
                if (!(bool)oCCORTE.isnull["ITIPOCORTEID"])
                {
                    auxPar.Value = oCCORTE.ITIPOCORTEID;
                }
                else
                {
                    auxPar.Value = DBValues._TIPO_CORTENORMAL;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@corteid", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"CORTE_ABRIR";

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

                oCCORTE.IID = (long)arParms[arParms.Length - 2].Value;

                return oCCORTE;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }





        [AutoComplete]
        public CCORTEBE ObtenTotalesCORTE(CCORTEBE oCCORTE, FbTransaction st)
        {
            CCORTEBE retorno = new CCORTEBE();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"CORTE_TOTALES";


                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                auxPar.Value = oCCORTE.ISUCURSALID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAJEROID", FbDbType.BigInt);
                auxPar.Value = oCCORTE.ICAJEROID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHACORTE", FbDbType.Date);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                /*auxPar = new FbParameter("@TURNOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);*/



                auxPar = new FbParameter("@SALDOINICIAL", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@INGRESO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@EGRESO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@DEVOLUCION", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@SALDOFINAL", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@APORTACION", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@RETIRO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@INGRESOTARJETA", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@INGRESOEFECTIVO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@INGRESOCREDITO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@INGRESOCHEQUE", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@INGRESOVALE", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAMBIOCHEQUE", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@SALDOREAL", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@PAGOPROVEEDORES", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@EGRESOTARJETA", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@EGRESOEFECTIVO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@EGRESOCREDITO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@EGRESOCHEQUE", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);



                auxPar = new FbParameter("@EGRESOVALE", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                /*
                auxPar = new FbParameter("@INGRESOTARJETACONTADO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@INGRESOEFECTIVOCONTADO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@INGRESOCHEQUECONTADO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@INGRESOVALECONTADO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@INGRESOTARJETAABONO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@INGRESOEFECTIVOABONO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@INGRESOCHEQUEABONO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@INGRESOVALEABONO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@EGRESOTARJETACONTADO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@EGRESOEFECTIVOCONTADO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@EGRESOCHEQUECONTADO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@EGRESOVALECONTADO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@EGRESOTARJETAABONO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@EGRESOEFECTIVOABONO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@EGRESOCHEQUEABONO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@EGRESOVALEABONO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);
                */


                auxPar = new FbParameter("@SALDOREALCREDITO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);



                auxPar = new FbParameter("@INGRESOMONEDERO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@EGRESOMONEDERO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);




                auxPar = new FbParameter("@INGRESOTRANSFERENCIA", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@EGRESOTRANSFERENCIA", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@INGRESOINDEFINIDO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@EGRESOINDEFINIDO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);



                auxPar = new FbParameter("@INGRESOTARJETAVENTATRASLADO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@INGRESOEFECTIVOVENTATRASLADO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@INGRESOCREDITOVENTATRASLADO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@INGRESOVALEVENTATRASLADO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@INGRESOCHEQUEVENTATRASLADO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@INGRESOMONEDEROVENTATRASLADO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@INGRESOTRANSFVENTATRASLADO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@EGRESOEFEVENTATRASLADO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);



                auxPar = new FbParameter("@INGRESODEPOSITO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@EGRESODEPOSITO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@INGRESODEPOSITOVENTATRASLADO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);



                auxPar = new FbParameter("@INGRESODEPTERCERO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@EGRESODEPTERCERO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@INGRESODEPTERCEROVENTATRASLADO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                
                auxPar = new FbParameter("@INGRESOINDEFVENTATRASLADO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@FONDEOSDECAJA", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@RETIROSDECAJA", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@FONDODINAMICO", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@FONDODINAMICOFINAL", FbDbType.Numeric);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                //FbDataReader dr = null;
                if (st == null)
                    /*dr =*/ SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, CmdTxt, arParms);
                else
                    /*dr =*/SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, CmdTxt, arParms);


                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value || arParms[arParms.Length - 1].Value == null))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        this.iComentario = "Hubo un error";
                        return oCCORTE;
                    }
                }

                
               
                    if (!(arParms[2].Value == System.DBNull.Value))
                    {
                        retorno.IID = (long)(arParms[2].Value);
                    }


                    if (!(arParms[3].Value == System.DBNull.Value))
                    {
                        retorno.IFECHACORTE = (DateTime)(arParms[3].Value);
                    }



                    /*if (!(arParms[4].Value == System.DBNull.Value))
                    {
                        retorno.ITURNOID = (long)(arParms[4].Value);
                    }

                    
                    if (!(arParms[5].Value == System.DBNull.Value))
                    {
                        retorno.ICAJEROID = (long)(arParms[5].Value);
                    }*/
                    
                    if (!(arParms[4].Value == System.DBNull.Value))
                    {
                        retorno.ISALDOINICIAL = (decimal)(arParms[4].Value);
                    }
                    
                    if (!(arParms[5].Value == System.DBNull.Value))
                    {
                        retorno.IINGRESO = (decimal)(arParms[5].Value);
                    }
                    
                    if (!(arParms[6].Value == System.DBNull.Value))
                    {
                        retorno.IEGRESO = (decimal)(arParms[6].Value);
                    }
                    
                    if (!(arParms[7].Value == System.DBNull.Value))
                    {
                        retorno.IDEVOLUCION = (decimal)(arParms[7].Value);
                    }
                    
                    if (!(arParms[8].Value == System.DBNull.Value))
                    {
                        retorno.ISALDOFINAL = (decimal)(arParms[8].Value);
                    }
                    
                    if (!(arParms[9].Value == System.DBNull.Value))
                    {
                        retorno.IAPORTACION = (decimal)(arParms[9].Value);
                    }
                    
                    if (!(arParms[10].Value == System.DBNull.Value))
                    {
                        retorno.IRETIRO = (decimal)(arParms[10].Value);
                    }

                    if (!(arParms[11].Value == System.DBNull.Value))
                    {
                        retorno.IINGRESOTARJETA = (decimal)(arParms[11].Value);
                    }

                    if (!(arParms[12].Value == System.DBNull.Value))
                    {
                        retorno.IINGRESOEFECTIVO = (decimal)(arParms[12].Value);
                    }

                    if (!(arParms[13].Value == System.DBNull.Value))
                    {
                        retorno.IINGRESOCREDITO = (decimal)(arParms[13].Value);
                    }

                    if (!(arParms[14].Value == System.DBNull.Value))
                    {
                        retorno.IINGRESOCHEQUE = (decimal)(arParms[14].Value);
                    }

                    if (!(arParms[15].Value == System.DBNull.Value))
                    {
                        retorno.IINGRESOVALE = (decimal)(arParms[15].Value);
                    }

                    if (!(arParms[16].Value == System.DBNull.Value))
                    {
                        retorno.ICAMBIOCHEQUE = (decimal)(arParms[16].Value);
                    }

                    if (!(arParms[17].Value == System.DBNull.Value))
                    {
                        retorno.ISALDOREAL = (decimal)(arParms[17].Value);
                    }

                    if (!(arParms[18].Value == System.DBNull.Value))
                    {
                        retorno.IPAGOPROVEEDORES = (decimal)(arParms[18].Value);
                    }

                    if (!(arParms[19].Value == System.DBNull.Value))
                    {
                        retorno.IEGRESOTARJETA = (decimal)(arParms[19].Value);
                    }

                    if (!(arParms[20].Value == System.DBNull.Value))
                    {
                        retorno.IEGRESOEFECTIVO = (decimal)(arParms[20].Value);
                    }

                    if (!(arParms[21].Value == System.DBNull.Value))
                    {
                        retorno.IEGRESOCREDITO = (decimal)(arParms[21].Value);
                    }

                    if (!(arParms[22].Value == System.DBNull.Value))
                    {
                        retorno.IEGRESOCHEQUE = (decimal)(arParms[22].Value);
                    }

                    if (!(arParms[23].Value == System.DBNull.Value))
                    {
                        retorno.IEGRESOVALE = (decimal)(arParms[23].Value);
                    }


                    if (!(arParms[24].Value == System.DBNull.Value))
                    {
                        retorno.ISALDOREALCREDITO = (decimal)(arParms[24].Value);
                    }

                    if (!(arParms[25].Value == System.DBNull.Value))
                    {
                        retorno.IINGRESOMONEDERO = (decimal)(arParms[25].Value);
                    }

                    if (!(arParms[26].Value == System.DBNull.Value))
                    {
                        retorno.IEGRESOMONEDERO = (decimal)(arParms[26].Value);
                    }


                    if (!(arParms[27].Value == System.DBNull.Value))
                    {
                        retorno.IINGRESOTRANSFERENCIA = (decimal)(arParms[27].Value);
                    }

                    if (!(arParms[28].Value == System.DBNull.Value))
                    {
                        retorno.IEGRESOTRANSFERENCIA = (decimal)(arParms[28].Value);
                    }

                    if (!(arParms[29].Value == System.DBNull.Value))
                    {
                        retorno.IINGRESOINDEFINIDO = (decimal)(arParms[29].Value);
                    }

                    if (!(arParms[30].Value == System.DBNull.Value))
                    {
                        retorno.IEGRESOINDEFINIDO = (decimal)(arParms[30].Value);
                    }

                    if (!(arParms[31].Value == System.DBNull.Value))
                    {
                        retorno.IINGRESOTARJETAVENTATRASLADO = (decimal)(arParms[31].Value);
                    }

                    if (!(arParms[32].Value == System.DBNull.Value))
                    {
                        retorno.IINGRESOEFECTIVOVENTATRASLADO = (decimal)(arParms[32].Value);
                    }

                    if (!(arParms[33].Value == System.DBNull.Value))
                    {
                        retorno.IINGRESOCREDITOVENTATRASLADO = (decimal)(arParms[33].Value);
                    }

                    if (!(arParms[34].Value == System.DBNull.Value))
                    {
                        retorno.IINGRESOVALEVENTATRASLADO = (decimal)(arParms[34].Value);
                    }

                    if (!(arParms[35].Value == System.DBNull.Value))
                    {
                        retorno.IINGRESOCHEQUEVENTATRASLADO = (decimal)(arParms[35].Value);
                    }

                    if (!(arParms[36].Value == System.DBNull.Value))
                    {
                        retorno.IINGRESOMONEDEROVENTATRASLADO = (decimal)(arParms[36].Value);
                    }

                    if (!(arParms[37].Value == System.DBNull.Value))
                    {
                        retorno.IINGRESOTRANSFVENTATRASLADO = (decimal)(arParms[37].Value);
                    }


                    if (!(arParms[38].Value == System.DBNull.Value))
                    {
                        retorno.IEGRESOEFEVENTATRASLADO = (decimal)(arParms[38].Value);
                    }

                    if (!(arParms[39].Value == System.DBNull.Value))
                    {
                        retorno.IINGRESODEPOSITO = (decimal)(arParms[39].Value);
                    }

                    if (!(arParms[40].Value == System.DBNull.Value))
                    {
                        retorno.IEGRESODEPOSITO = (decimal)(arParms[40].Value);
                    }

                    
                    if (!(arParms[41].Value == System.DBNull.Value))
                    {
                        retorno.IINGRESODEPOSITOVENTATRASLADO = (decimal)(arParms[41].Value);
                    }


                    if (!(arParms[42].Value == System.DBNull.Value))
                    {
                        retorno.IINGRESODEPTERCERO = (decimal)(arParms[42].Value);
                    }

                    if (!(arParms[43].Value == System.DBNull.Value))
                    {
                        retorno.IEGRESODEPTERCERO = (decimal)(arParms[43].Value);
                    }


                    if (!(arParms[44].Value == System.DBNull.Value))
                    {
                        retorno.IINGRESODEPTERCEROVENTATRASLADO = (decimal)(arParms[44].Value);
                    }


                    if (!(arParms[45].Value == System.DBNull.Value))
                    {
                        retorno.IINGRESOINDEFVENTATRASLADO = (decimal)(arParms[45].Value);
                    }


                    if (!(arParms[46].Value == System.DBNull.Value))
                    {
                        retorno.IFONDEOSDECAJA = (decimal)(arParms[46].Value);
                    }

                    if (!(arParms[47].Value == System.DBNull.Value))
                    {
                        retorno.IRETIROSDECAJA = (decimal)(arParms[47].Value);
                    }

                    if (!(arParms[48].Value == System.DBNull.Value))
                    {
                        retorno.IFONDODINAMICO = (decimal)(arParms[48].Value);
                    }

                    if (!(arParms[49].Value == System.DBNull.Value))
                    {
                        retorno.IFONDODINAMICOFINAL = (decimal)(arParms[49].Value);
                    }

                /*
                    if (!(arParms[24].Value == System.DBNull.Value))
                    {
                        retorno.IINGRESOTARJETACONTADO = (decimal)(arParms[24].Value);
                    }

                    if (!(arParms[25].Value == System.DBNull.Value))
                    {
                        retorno.IINGRESOEFECTIVOCONTADO = (decimal)(arParms[25].Value);
                    }

                    if (!(arParms[26].Value == System.DBNull.Value))
                    {
                        retorno.IINGRESOCHEQUECONTADO = (decimal)(arParms[26].Value);
                    }

                    if (!(arParms[27].Value == System.DBNull.Value))
                    {
                        retorno.IINGRESOVALECONTADO = (decimal)(arParms[27].Value);
                    }

                    if (!(arParms[28].Value == System.DBNull.Value))
                    {
                        retorno.IINGRESOTARJETAABONO = (decimal)(arParms[28].Value);
                    }

                    if (!(arParms[29].Value == System.DBNull.Value))
                    {
                        retorno.IINGRESOEFECTIVOABONO = (decimal)(arParms[29].Value);
                    }

                    if (!(arParms[30].Value == System.DBNull.Value))
                    {
                        retorno.IINGRESOCHEQUEABONO = (decimal)(arParms[30].Value);
                    }

                    if (!(arParms[31].Value == System.DBNull.Value))
                    {
                        retorno.IINGRESOVALEABONO = (decimal)(arParms[31].Value);
                    }

                    if (!(arParms[32].Value == System.DBNull.Value))
                    {
                        retorno.IEGRESOTARJETACONTADO = (decimal)(arParms[32].Value);
                    }

                    if (!(arParms[33].Value == System.DBNull.Value))
                    {
                        retorno.IEGRESOEFECTIVOCONTADO = (decimal)(arParms[33].Value);
                    }

                    if (!(arParms[34].Value == System.DBNull.Value))
                    {
                        retorno.IEGRESOCHEQUECONTADO = (decimal)(arParms[34].Value);
                    }

                    if (!(arParms[35].Value == System.DBNull.Value))
                    {
                        retorno.IEGRESOVALECONTADO = (decimal)(arParms[35].Value);
                    }

                    if (!(arParms[36].Value == System.DBNull.Value))
                    {
                        retorno.IEGRESOTARJETAABONO = (decimal)(arParms[36].Value);
                    }

                    if (!(arParms[37].Value == System.DBNull.Value))
                    {
                        retorno.IEGRESOEFECTIVOABONO = (decimal)(arParms[37].Value);
                    }

                    if (!(arParms[38].Value == System.DBNull.Value))
                    {
                        retorno.IEGRESOCHEQUEABONO = (decimal)(arParms[38].Value);
                    }

                    if (!(arParms[39].Value == System.DBNull.Value))
                    {
                        retorno.IEGRESOVALEABONO = (decimal)(arParms[39].Value);
                    }
                  */

                /*else
                {
                    retorno = null;
                }*/

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }

        }





        public CCORTEBE QueryObtenTotalesCORTE_PORID(CCORTEBE oCCORTE, FbTransaction st)
        {
            CCORTEBE retorno = new CCORTEBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                this.iComentario = "";

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"SELECT * FROM CORTE_TOTALES_PORID(@CORTEID);";


                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                auxPar.Value = oCCORTE.IID;
                parts.Add(auxPar);



                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr =SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);

                if (dr.Read())
                {

                    if (dr["ERRORCODE"] != System.DBNull.Value)
                    {
                        int errorCode = (int)dr["ERRORCODE"];
                        if (errorCode != 0)
                        {

                            Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                            this.iComentario = "Hubo un error " + errorCode.ToString();
                            return oCCORTE;
                        }  
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





        public bool CORTE_ACTUALIZAR_DIFERENCIA(CCORTEBE oCCORTE, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                auxPar.Value = oCCORTE.IID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"CORTE_ACTUALIZAR_DIFERENCIA";

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




        public bool CORTE_CAMBIARFONDODINAMICOFINAL(long corteId, decimal fondoDinamicoFinal, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                auxPar.Value = corteId;
                parts.Add(auxPar);

                

                auxPar = new FbParameter("@FONDODINAMICOFINAL", FbDbType.Numeric);
                auxPar.Value = fondoDinamicoFinal;
                parts.Add(auxPar);



                string commandText = @"UPDATE CORTE SET FONDODINAMICOFINAL = @FONDODINAMICOFINAL WHERE ID = @CORTEID";

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

        public CCORTEBE CerrarCORTED(CCORTEBE oCCORTE, ref int errorCode, FbTransaction st)
        {
            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (!(bool)oCCORTE.isnull["ISUCURSALID"])
                {
                    auxPar.Value = oCCORTE.ISUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                /*
                auxPar = new FbParameter("@CAJAID", FbDbType.BigInt);
                if (!(bool)oCCORTE.isnull["ICAJAID"])
                {
                    auxPar.Value = oCCORTE.ICAJAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);*/


                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                if (!(bool)oCCORTE.isnull["IID"])
                {
                    auxPar.Value = oCCORTE.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@FECHACORTE", FbDbType.Date);
                if (!(bool)oCCORTE.isnull["IFECHACORTE"])
                {
                    auxPar.Value = oCCORTE.IFECHACORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CAJEROID", FbDbType.BigInt);
                if (!(bool)oCCORTE.isnull["ICAJEROID"])
                {
                    auxPar.Value = oCCORTE.ICAJEROID;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@SALDOINICIAL", FbDbType.Numeric);
                if (!(bool)oCCORTE.isnull["ISALDOINICIAL"])
                {
                    auxPar.Value = oCCORTE.ISALDOINICIAL;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@INGRESO", FbDbType.Numeric);
                if (!(bool)oCCORTE.isnull["IINGRESO"])
                {
                    auxPar.Value = oCCORTE.IINGRESO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@EGRESO", FbDbType.Numeric);
                if (!(bool)oCCORTE.isnull["IEGRESO"])
                {
                    auxPar.Value = oCCORTE.IEGRESO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DEVOLUCION", FbDbType.Numeric);
                if (!(bool)oCCORTE.isnull["IDEVOLUCION"])
                {
                    auxPar.Value = oCCORTE.IDEVOLUCION;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@APORTACION", FbDbType.Numeric);
                if (!(bool)oCCORTE.isnull["IAPORTACION"])
                {
                    auxPar.Value = oCCORTE.IAPORTACION;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RETIRO", FbDbType.Numeric);
                if (!(bool)oCCORTE.isnull["IRETIRO"])
                {
                    auxPar.Value = oCCORTE.IRETIRO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SALDOFINAL", FbDbType.Numeric);
                if (!(bool)oCCORTE.isnull["ISALDOFINAL"])
                {
                    auxPar.Value = oCCORTE.ISALDOFINAL;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SALDOREAL", FbDbType.Numeric);
                if (!(bool)oCCORTE.isnull["ISALDOREAL"])
                {
                    auxPar.Value = oCCORTE.ISALDOREAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DIFERENCIA", FbDbType.Numeric);
                if (!(bool)oCCORTE.isnull["IDIFERENCIA"])
                {
                    auxPar.Value = oCCORTE.IDIFERENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@SALDOREALCREDITO", FbDbType.Numeric);
                if (!(bool)oCCORTE.isnull["ISALDOREALCREDITO"])
                {
                    auxPar.Value = oCCORTE.ISALDOREALCREDITO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FONDODINAMICOFINAL", FbDbType.Numeric);
                if (!(bool)oCCORTE.isnull["IFONDODINAMICOFINAL"])
                {
                    auxPar.Value = oCCORTE.IFONDODINAMICOFINAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"CORTE_CERRAR";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);


                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    int iError = (int)arParms[arParms.Length - 1].Value;
                    if (iError != 0)
                    {
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.sCadenaConexion, st);
                        this.iComentario = "ERROR : " + strMensajeErr;
                        errorCode = (int)arParms[arParms.Length - 1].Value;
                        return null;
                    }
                }

                //oCCORTE.IID = (long)arParms[arParms.Length - 2].Value;

                return oCCORTE;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }





        public bool CALCULARCORTESABIERTOSFECHA(DateTime fecha, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                auxPar.Value = fecha;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"CALCULARCORTESABIERTOSFECHA";

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



        public bool CORTE_ULTIMOFONDODINAMICO(long cajeroId, DateTime fechaCorte, ref decimal fondoDinamico, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@CAJEROID", FbDbType.BigInt);
                auxPar.Value = cajeroId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHACORTE", FbDbType.Date);
                auxPar.Value = fechaCorte;
                parts.Add(auxPar);

                auxPar = new FbParameter("@FONDODINAMICO", FbDbType.Decimal);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"CORTE_ULTIMOFONDODINAMICO";

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
                    fondoDinamico = (decimal)arParms[arParms.Length - 2].Value;
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool CORTE_REMISIONAR_PEND_BANCOMER(long corteid, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                auxPar.Value = corteid;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"CORTE_REMISIONAR_PEND_BANCOMER";

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

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool GET_VENTASPEND_PAGOS_BANCOMER(long corteid, ref long cantidad, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                auxPar.Value = corteid;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDAD", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"GET_VENTASPEND_PAGOS_BANCOMER";

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
                    cantidad = int.Parse(((long)arParms[arParms.Length - 2].Value).ToString());

                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public CCORTED()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
