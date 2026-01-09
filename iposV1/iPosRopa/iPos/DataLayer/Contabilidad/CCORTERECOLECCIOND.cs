

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



    public class CCORTERECOLECCIOND
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
        public CCORTERECOLECCIONBE AgregarCORTERECOLECCIOND(CCORTERECOLECCIONBE oCCORTERECOLECCION, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCCORTERECOLECCION.isnull["IID"])
                {
                    auxPar.Value = oCCORTERECOLECCION.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCCORTERECOLECCION.isnull["IACTIVO"])
                {
                    auxPar.Value = oCCORTERECOLECCION.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCORTERECOLECCION.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCCORTERECOLECCION.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCORTERECOLECCION.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCCORTERECOLECCION.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ENCARGADOID", FbDbType.BigInt);
                if (!(bool)oCCORTERECOLECCION.isnull["IENCARGADOID"])
                {
                    auxPar.Value = oCCORTERECOLECCION.IENCARGADOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO", FbDbType.Numeric);
                if (!(bool)oCCORTERECOLECCION.isnull["IMONTO"])
                {
                    auxPar.Value = oCCORTERECOLECCION.IMONTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@OBSERVACIONES", FbDbType.VarChar);
                if (!(bool)oCCORTERECOLECCION.isnull["IOBSERVACIONES"])
                {
                    auxPar.Value = oCCORTERECOLECCION.IOBSERVACIONES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO CORTERECOLECCION
      (
    
ID,

ACTIVO,

CREADO,

CREADOPOR_USERID,

MODIFICADO,

MODIFICADOPOR_USERID,

ENCARGADOID,

FECHAHORA,

MONTO,

OBSERVACIONES
         )

Values (

@ID,

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@ENCARGADOID,

@MONTO,

@OBSERVACIONES
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCCORTERECOLECCION;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }



        public bool CORTERECOLECCION_INSERT(CCORTERECOLECCIONBE oCCORTERECOLECCION, ref long CORTERECOLECCIONID, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCORTERECOLECCION.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCCORTERECOLECCION.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCCORTERECOLECCION.isnull["IACTIVO"])
                {
                    auxPar.Value = oCCORTERECOLECCION.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                


                auxPar = new FbParameter("@ENCARGADOID", FbDbType.BigInt);
                if (!(bool)oCCORTERECOLECCION.isnull["IENCARGADOID"])
                {
                    auxPar.Value = oCCORTERECOLECCION.IENCARGADOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FECHAHORA", FbDbType.TimeStamp);
                if (!(bool)oCCORTERECOLECCION.isnull["IFECHAHORA"])
                {
                    auxPar.Value = oCCORTERECOLECCION.IFECHAHORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@MONTO", FbDbType.Numeric);
                if (!(bool)oCCORTERECOLECCION.isnull["IMONTO"])
                {
                    auxPar.Value = oCCORTERECOLECCION.IMONTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@OBSERVACIONES", FbDbType.VarChar);
                if (!(bool)oCCORTERECOLECCION.isnull["IOBSERVACIONES"])
                {
                    auxPar.Value = oCCORTERECOLECCION.IOBSERVACIONES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CORTERECOLECCIONID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                
                string commandText = @"CORTERECOLECCION_INSERT";

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
                        CORTERECOLECCIONID = (long)arParms[arParms.Length - 2].Value;
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
        public bool BorrarCORTERECOLECCIOND(CCORTERECOLECCIONBE oCCORTERECOLECCION, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCCORTERECOLECCION.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from CORTERECOLECCION
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
        public bool CambiarCORTERECOLECCIOND(CCORTERECOLECCIONBE oCCORTERECOLECCIONNuevo, CCORTERECOLECCIONBE oCCORTERECOLECCIONAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCCORTERECOLECCIONNuevo.isnull["IID"])
                {
                    auxPar.Value = oCCORTERECOLECCIONNuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCCORTERECOLECCIONNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCCORTERECOLECCIONNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCORTERECOLECCIONNuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCCORTERECOLECCIONNuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCORTERECOLECCIONNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCCORTERECOLECCIONNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ENCARGADOID", FbDbType.BigInt);
                if (!(bool)oCCORTERECOLECCIONNuevo.isnull["IENCARGADOID"])
                {
                    auxPar.Value = oCCORTERECOLECCIONNuevo.IENCARGADOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTO", FbDbType.Numeric);
                if (!(bool)oCCORTERECOLECCIONNuevo.isnull["IMONTO"])
                {
                    auxPar.Value = oCCORTERECOLECCIONNuevo.IMONTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@OBSERVACIONES", FbDbType.VarChar);
                if (!(bool)oCCORTERECOLECCIONNuevo.isnull["IOBSERVACIONES"])
                {
                    auxPar.Value = oCCORTERECOLECCIONNuevo.IOBSERVACIONES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCCORTERECOLECCIONAnterior.isnull["IID"])
                {
                    auxPar.Value = oCCORTERECOLECCIONAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  CORTERECOLECCION
  set

ID=@ID,

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

ENCARGADOID=@ENCARGADOID,

MONTO=@MONTO,

OBSERVACIONES = @OBSERVACIONES
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




        public bool CORTERECOLECCION_UPDATE(CCORTERECOLECCIONBE oCCORTERECOLECCIONNuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCCORTERECOLECCIONNuevo.isnull["IID"])
                {
                    auxPar.Value = oCCORTERECOLECCIONNuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                

                auxPar = new FbParameter("@ENCARGADOID", FbDbType.BigInt);
                if (!(bool)oCCORTERECOLECCIONNuevo.isnull["IENCARGADOID"])
                {
                    auxPar.Value = oCCORTERECOLECCIONNuevo.IENCARGADOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FECHAHORA", FbDbType.TimeStamp);
                if (!(bool)oCCORTERECOLECCIONNuevo.isnull["IFECHAHORA"])
                {
                    auxPar.Value = oCCORTERECOLECCIONNuevo.IFECHAHORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                

                auxPar = new FbParameter("@OBSERVACIONES", FbDbType.VarChar);
                if (!(bool)oCCORTERECOLECCIONNuevo.isnull["IOBSERVACIONES"])
                {
                    auxPar.Value = oCCORTERECOLECCIONNuevo.IOBSERVACIONES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                

                string commandText = @"CORTERECOLECCION_UPDATE";

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



                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }






        public bool CORTERECOLECCION_CORTEINSERTAR(long corteRecoleccionId, long corteId, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@CORTERECOLECCIONID", FbDbType.BigInt);
                auxPar.Value = corteRecoleccionId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                auxPar.Value = corteId;
                parts.Add(auxPar);

                


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);



                string commandText = @"CORTERECOLECCION_CORTEINSERTAR";

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



                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool CORTERECOLECCION_CORTEELIMINAR(long corteRecoleccionId, long corteId, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@CORTERECOLECCIONID", FbDbType.BigInt);
                auxPar.Value = corteRecoleccionId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                auxPar.Value = corteId;
                parts.Add(auxPar);




                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);



                string commandText = @"CORTERECOLECCION_CORTEELIMINAR";

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



                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool CORTERECOLECCION_CANCEL(long corteRecoleccionId,  FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = corteRecoleccionId;
                parts.Add(auxPar);
                



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);



                string commandText = @"CORTERECOLECCION_CANCEL";

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



                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        [AutoComplete]
        public CCORTERECOLECCIONBE seleccionarCORTERECOLECCION(CCORTERECOLECCIONBE oCCORTERECOLECCION, FbTransaction st)
        {




            CCORTERECOLECCIONBE retorno = new CCORTERECOLECCIONBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from CORTERECOLECCION where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCCORTERECOLECCION.IID;
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

                    if (dr["ENCARGADOID"] != System.DBNull.Value)
                    {
                        retorno.IENCARGADOID = (long)(dr["ENCARGADOID"]);
                    }

                    if (dr["FECHAHORA"] != System.DBNull.Value)
                    {
                        retorno.IFECHAHORA = (DateTime)(dr["FECHAHORA"]);
                    }

                    if (dr["MONTO"] != System.DBNull.Value)
                    {
                        retorno.IMONTO = (decimal)(dr["MONTO"]);
                    }
                    if (dr["FECHAHORA"] != System.DBNull.Value)
                    {
                        retorno.IFECHAHORA = (DateTime)(dr["FECHAHORA"]);
                    }
                    if (dr["OBSERVACIONES"] != System.DBNull.Value)
                    {
                        retorno.IOBSERVACIONES = dr["OBSERVACIONES"].ToString();
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
        public DataSet enlistarCORTERECOLECCION()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_CORTERECOLECCION_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoCORTERECOLECCION()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_CORTERECOLECCION_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteCORTERECOLECCION(CCORTERECOLECCIONBE oCCORTERECOLECCION, FbTransaction st)
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
                auxPar.Value = oCCORTERECOLECCION.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from CORTERECOLECCION where

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




        public CCORTERECOLECCIONBE AgregarCORTERECOLECCION(CCORTERECOLECCIONBE oCCORTERECOLECCION, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCORTERECOLECCION(oCCORTERECOLECCION, st);
                if (iRes == 1)
                {
                    this.IComentario = "El CORTERECOLECCION ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarCORTERECOLECCIOND(oCCORTERECOLECCION, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarCORTERECOLECCION(CCORTERECOLECCIONBE oCCORTERECOLECCION, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCORTERECOLECCION(oCCORTERECOLECCION, st);
                if (iRes == 0)
                {
                    this.IComentario = "El CORTERECOLECCION no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarCORTERECOLECCIOND(oCCORTERECOLECCION, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarCORTERECOLECCION(CCORTERECOLECCIONBE oCCORTERECOLECCIONNuevo, CCORTERECOLECCIONBE oCCORTERECOLECCIONAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCORTERECOLECCION(oCCORTERECOLECCIONAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El CORTERECOLECCION no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarCORTERECOLECCIOND(oCCORTERECOLECCIONNuevo, oCCORTERECOLECCIONAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CCORTERECOLECCIOND()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
