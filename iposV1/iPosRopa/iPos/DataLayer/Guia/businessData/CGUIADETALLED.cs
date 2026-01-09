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



    public class CGUIADETALLED
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


        public CGUIADETALLEBE AgregarGUIADETALLED(CGUIADETALLEBE oCGUIADETALLE, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCGUIADETALLE.isnull["IID"])
                {
                    auxPar.Value = oCGUIADETALLE.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCGUIADETALLE.isnull["IACTIVO"])
                {
                    auxPar.Value = oCGUIADETALLE.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCGUIADETALLE.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCGUIADETALLE.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCGUIADETALLE.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCGUIADETALLE.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@GUIAID", FbDbType.BigInt);
                if (!(bool)oCGUIADETALLE.isnull["IGUIAID"])
                {
                    auxPar.Value = oCGUIADETALLE.IGUIAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCGUIADETALLE.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCGUIADETALLE.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTADOGUIAID", FbDbType.BigInt);
                if (!(bool)oCGUIADETALLE.isnull["IESTADOGUIAID"])
                {
                    auxPar.Value = oCGUIADETALLE.IESTADOGUIAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO GUIADETALLE
      (
    
ID,

ACTIVO,

CREADO,

CREADOPOR_USERID,

MODIFICADO,

MODIFICADOPOR_USERID,

GUIAID,

DOCTOID,

ESTADOGUIAID
         )

Values (

@ID,

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@GUIAID,

@DOCTOID,

@ESTADOGUIAID
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCGUIADETALLE;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }





        public bool GUIADETALLE_INSERT(ref CGUIADETALLEBE oCGUIADETALLE, ref CGUIABE oCGUIA, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@GUIAID", FbDbType.BigInt);
                if (!(bool)oCGUIADETALLE.isnull["IGUIAID"])
                {
                    auxPar.Value = oCGUIADETALLE.IGUIAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCGUIADETALLE.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCGUIADETALLE.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ENCARGADOGUIAID", FbDbType.BigInt);
                if (!(bool)oCGUIA.isnull["IENCARGADOGUIAID"])
                {
                    auxPar.Value = oCGUIA.IENCARGADOGUIAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTADOGUIAID", FbDbType.BigInt);
                if (!(bool)oCGUIADETALLE.isnull["IESTADOGUIAID"])
                {
                    auxPar.Value = oCGUIADETALLE.IESTADOGUIAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAJEROID", FbDbType.BigInt);
                if (!(bool)oCGUIA.isnull["ICAJEROID"])
                {
                    auxPar.Value = oCGUIA.ICAJEROID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCGUIA.isnull["IFECHA"])
                {
                    auxPar.Value = oCGUIA.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAHORA", FbDbType.TimeStamp);
                if (!(bool)oCGUIA.isnull["IFECHAHORA"])
                {
                    auxPar.Value = oCGUIA.IFECHAHORA;
                }
                else
                {
                    auxPar.Value = DateTime.Now;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOTA", FbDbType.VarChar);
                if (!(bool)oCGUIA.isnull["INOTA"])
                {
                    auxPar.Value = oCGUIA.INOTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOENTREGAID", FbDbType.BigInt);
                if (!(bool)oCGUIA.isnull["ITIPOENTREGAID"])
                {
                    auxPar.Value = oCGUIA.ITIPOENTREGAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@GUIAPAQUETERIA", FbDbType.VarChar);
                if (!(bool)oCGUIA.isnull["IGUIAPAQUETERIA"])
                {
                    auxPar.Value = oCGUIA.IGUIAPAQUETERIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@VEHICULOID", FbDbType.BigInt);
                if (!(bool)oCGUIA.isnull["IVEHICULOID"])
                {
                    auxPar.Value = oCGUIA.IVEHICULOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FECHAESTIMADAREC", FbDbType.Date);
                if (!(bool)oCGUIA.isnull["IFECHAESTIMADAREC"])
                {
                    auxPar.Value = oCGUIA.IFECHAESTIMADAREC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@HORAESTIMADREC", FbDbType.TimeStamp);
                if (!(bool)oCGUIA.isnull["IHORAESTIMADREC"])
                {
                    auxPar.Value = oCGUIA.IHORAESTIMADREC;
                }
                else
                {
                    auxPar.Value = DateTime.Now;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOTARECEPCION", FbDbType.VarChar);
                if (!(bool)oCGUIA.isnull["INOTARECEPCION"])
                {
                    auxPar.Value = oCGUIA.INOTARECEPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@GUIAIDRETORNO", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@GUIADETALLEID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"GUIADETALLE_INSERT";

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
                        int errorvalue = (int)arParms[arParms.Length - 1].Value;
                        this.iComentario = "Hubo un error " + errorvalue.ToString();
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    long retorno = (long)arParms[arParms.Length - 2].Value;
                    oCGUIADETALLE.IID = retorno;
                }


                if ( oCGUIA.IID == 0 && !(arParms[arParms.Length - 3].Value == System.DBNull.Value))
                {
                    long retorno = (long)arParms[arParms.Length - 3].Value;
                    oCGUIA.IID = retorno;
                    oCGUIA.IESTADOGUIAID = oCGUIADETALLE.IESTADOGUIAID;
                }



                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public bool GUIADETALLE_DELETE(CGUIADETALLEBE oCGUIADETALLE, CGUIABE oCGUIA, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@GUIADETALLEID", FbDbType.BigInt);
                if (!(bool)oCGUIADETALLE.isnull["IID"])
                {
                    auxPar.Value = oCGUIADETALLE.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAJEROID", FbDbType.BigInt);
                if (!(bool)oCGUIA.isnull["ICAJEROID"])
                {
                    auxPar.Value = oCGUIA.ICAJEROID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"GUIADETALLE_DELETE";

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
                        int errorvalue = (int)arParms[arParms.Length - 1].Value;
                        this.iComentario = "Hubo un error " + errorvalue.ToString();
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
        
        public bool GUIADETALLE_RECIBIR(CGUIADETALLEBE oCGUIADETALLE, CGUIABE oCGUIA, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@GUIADETALLEID", FbDbType.BigInt);
                if (!(bool)oCGUIADETALLE.isnull["IID"])
                {
                    auxPar.Value = oCGUIADETALLE.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESTADOGUIAID", FbDbType.BigInt);
                if (!(bool)oCGUIADETALLE.isnull["IESTADOGUIAID"])
                {
                    auxPar.Value = oCGUIADETALLE.IESTADOGUIAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAJEROID", FbDbType.BigInt);
                if (!(bool)oCGUIA.isnull["ICAJEROID"])
                {
                    auxPar.Value = oCGUIA.ICAJEROID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"GUIADETALLE_RECIBIR";

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
                        int errorvalue = (int)arParms[arParms.Length - 1].Value;
                        this.iComentario = "Hubo un error " + errorvalue.ToString();
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

        public bool BorrarGUIADETALLED(CGUIADETALLEBE oCGUIADETALLE, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCGUIADETALLE.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from GUIADETALLE
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


        public bool CambiarGUIADETALLED(CGUIADETALLEBE oCGUIADETALLENuevo, CGUIADETALLEBE oCGUIADETALLEAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCGUIADETALLENuevo.isnull["IID"])
                {
                    auxPar.Value = oCGUIADETALLENuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCGUIADETALLENuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCGUIADETALLENuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCGUIADETALLENuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCGUIADETALLENuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCGUIADETALLENuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCGUIADETALLENuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@GUIAID", FbDbType.BigInt);
                if (!(bool)oCGUIADETALLENuevo.isnull["IGUIAID"])
                {
                    auxPar.Value = oCGUIADETALLENuevo.IGUIAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCGUIADETALLENuevo.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCGUIADETALLENuevo.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESTADOGUIAID", FbDbType.BigInt);
                if (!(bool)oCGUIADETALLENuevo.isnull["IESTADOGUIAID"])
                {
                    auxPar.Value = oCGUIADETALLENuevo.IESTADOGUIAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCGUIADETALLEAnterior.isnull["IID"])
                {
                    auxPar.Value = oCGUIADETALLEAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  GUIADETALLE
  set

ID=@ID,

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

GUIAID=@GUIAID,

DOCTOID=@DOCTOID,

ESTADOGUIAID=@ESTADOGUIAID
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


        public CGUIADETALLEBE seleccionarGUIADETALLE(CGUIADETALLEBE oCGUIADETALLE, FbTransaction st)
        {




            CGUIADETALLEBE retorno = new CGUIADETALLEBE();

            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from GUIADETALLE where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCGUIADETALLE.IID;
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

                    if (dr["GUIAID"] != System.DBNull.Value)
                    {
                        retorno.IGUIAID = (long)(dr["GUIAID"]);
                    }

                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOID = (long)(dr["DOCTOID"]);
                    }

                    if (dr["ESTADOGUIAID"] != System.DBNull.Value)
                    {
                        retorno.IESTADOGUIAID = (long)(dr["ESTADOGUIAID"]);
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







        public DataSet enlistarGUIADETALLE()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_GUIADETALLE_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public DataSet enlistarCortoGUIADETALLE()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_GUIADETALLE_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }


        public int ExisteGUIADETALLE(CGUIADETALLEBE oCGUIADETALLE, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;

            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCGUIADETALLE.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from GUIADETALLE where

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




        public CGUIADETALLEBE AgregarGUIADETALLE(CGUIADETALLEBE oCGUIADETALLE, FbTransaction st)
        {
            try
            {
                int iRes = ExisteGUIADETALLE(oCGUIADETALLE, st);
                if (iRes == 1)
                {
                    this.IComentario = "El GUIADETALLE ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarGUIADETALLED(oCGUIADETALLE, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarGUIADETALLE(CGUIADETALLEBE oCGUIADETALLE, FbTransaction st)
        {
            try
            {
                int iRes = ExisteGUIADETALLE(oCGUIADETALLE, st);
                if (iRes == 0)
                {
                    this.IComentario = "El GUIADETALLE no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarGUIADETALLED(oCGUIADETALLE, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarGUIADETALLE(CGUIADETALLEBE oCGUIADETALLENuevo, CGUIADETALLEBE oCGUIADETALLEAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteGUIADETALLE(oCGUIADETALLEAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El GUIADETALLE no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarGUIADETALLED(oCGUIADETALLENuevo, oCGUIADETALLEAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }




        public CGUIADETALLED()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
