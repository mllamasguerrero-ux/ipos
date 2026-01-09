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



    public class CGUIAD
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


        public CGUIABE AgregarGUIAD(CGUIABE oCGUIA, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCGUIA.isnull["IID"])
                {
                    auxPar.Value = oCGUIA.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCGUIA.isnull["IACTIVO"])
                {
                    auxPar.Value = oCGUIA.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCGUIA.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCGUIA.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCGUIA.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCGUIA.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FOLIO", FbDbType.Integer);
                if (!(bool)oCGUIA.isnull["IFOLIO"])
                {
                    auxPar.Value = oCGUIA.IFOLIO;
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
                if (!(bool)oCGUIA.isnull["IESTADOGUIAID"])
                {
                    auxPar.Value = oCGUIA.IESTADOGUIAID;
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


                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                if (!(bool)oCGUIA.isnull["ICORTEID"])
                {
                    auxPar.Value = oCGUIA.ICORTEID;
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


                string commandText = @"
        INSERT INTO GUIA
      (
    
ID,

ACTIVO,

CREADO,

CREADOPOR_USERID,

MODIFICADO,

MODIFICADOPOR_USERID,

FOLIO,

ENCARGADOGUIAID,

ESTADOGUIAID,

CAJEROID,

CORTEID,

FECHA,

FECHAHORA,

NOTA,

NOTARECEPCION
         )

Values (

@ID,

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@FOLIO,

@ENCARGADOGUIAID,

@ESTADOGUIAID,

@CAJEROID,

@CORTEID,

@FECHA,

@NOTA,

@NOTARECEPCION
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCGUIA;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarGUIAD(CGUIABE oCGUIA, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCGUIA.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from GUIA
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


        public bool CambiarGUIAD(CGUIABE oCGUIANuevo, CGUIABE oCGUIAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCGUIANuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCGUIANuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCGUIANuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCGUIANuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCGUIANuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCGUIANuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FOLIO", FbDbType.Integer);
                if (!(bool)oCGUIANuevo.isnull["IFOLIO"])
                {
                    auxPar.Value = oCGUIANuevo.IFOLIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ENCARGADOGUIAID", FbDbType.BigInt);
                if (!(bool)oCGUIANuevo.isnull["IENCARGADOGUIAID"])
                {
                    auxPar.Value = oCGUIANuevo.IENCARGADOGUIAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESTADOGUIAID", FbDbType.BigInt);
                if (!(bool)oCGUIANuevo.isnull["IESTADOGUIAID"])
                {
                    auxPar.Value = oCGUIANuevo.IESTADOGUIAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAJEROID", FbDbType.BigInt);
                if (!(bool)oCGUIANuevo.isnull["ICAJEROID"])
                {
                    auxPar.Value = oCGUIANuevo.ICAJEROID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                if (!(bool)oCGUIANuevo.isnull["ICORTEID"])
                {
                    auxPar.Value = oCGUIANuevo.ICORTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCGUIANuevo.isnull["IFECHA"])
                {
                    auxPar.Value = oCGUIANuevo.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOTA", FbDbType.VarChar);
                if (!(bool)oCGUIANuevo.isnull["INOTA"])
                {
                    auxPar.Value = oCGUIANuevo.INOTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@TIPOENTREGAID", FbDbType.BigInt);
                if (!(bool)oCGUIANuevo.isnull["ITIPOENTREGAID"])
                {
                    auxPar.Value = oCGUIANuevo.ITIPOENTREGAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@GUIAPAQUETERIA", FbDbType.VarChar);
                if (!(bool)oCGUIANuevo.isnull["IGUIAPAQUETERIA"])
                {
                    auxPar.Value = oCGUIANuevo.IGUIAPAQUETERIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@VEHICULOID", FbDbType.BigInt);
                if (!(bool)oCGUIANuevo.isnull["IVEHICULOID"])
                {
                    auxPar.Value = oCGUIANuevo.IVEHICULOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAESTIMADAREC", FbDbType.Date);
                if (!(bool)oCGUIANuevo.isnull["IFECHAESTIMADAREC"])
                {
                    auxPar.Value = oCGUIANuevo.IFECHAESTIMADAREC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@HORAESTIMADREC", FbDbType.TimeStamp);
                if (!(bool)oCGUIANuevo.isnull["IHORAESTIMADREC"])
                {
                    auxPar.Value = oCGUIANuevo.IHORAESTIMADREC;
                }
                else
                {
                    auxPar.Value = DateTime.Now;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@NOTARECEPCION", FbDbType.VarChar);
                if (!(bool)oCGUIANuevo.isnull["INOTARECEPCION"])
                {
                    auxPar.Value = oCGUIANuevo.INOTARECEPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCGUIAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCGUIAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  GUIA
  set


ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

FOLIO=@FOLIO,

ENCARGADOGUIAID=@ENCARGADOGUIAID,

ESTADOGUIAID=@ESTADOGUIAID,

CAJEROID=@CAJEROID,

CORTEID=@CORTEID,

FECHA=@FECHA,

NOTA=@NOTA,

TIPOENTREGAID = @TIPOENTREGAID,

GUIAPAQUETERIA = @GUIAPAQUETERIA,

VEHICULOID = @VEHICULOID,

FECHAESTIMADAREC = @FECHAESTIMADAREC

HORAESTIMADREC = @HORAESTIMADREC,

NOTARECEPCION = @NOTARECEPCION
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




        public bool CambiarEditablesGUIAD(CGUIABE oCGUIANuevo, CGUIABE oCGUIAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@NOTA", FbDbType.VarChar);
                if (!(bool)oCGUIANuevo.isnull["INOTA"])
                {
                    auxPar.Value = oCGUIANuevo.INOTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@GUIAPAQUETERIA", FbDbType.VarChar);
                if (!(bool)oCGUIANuevo.isnull["IGUIAPAQUETERIA"])
                {
                    auxPar.Value = oCGUIANuevo.IGUIAPAQUETERIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@VEHICULOID", FbDbType.BigInt);
                if (!(bool)oCGUIANuevo.isnull["IVEHICULOID"])
                {
                    auxPar.Value = oCGUIANuevo.IVEHICULOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                



                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCGUIAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCGUIAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  GUIA
  set


NOTA=@NOTA,

GUIAPAQUETERIA = @GUIAPAQUETERIA,

VEHICULOID = @VEHICULOID
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


        public bool CambiarNotaRecepcionGUIAD(CGUIABE oCGUIANuevo, CGUIABE oCGUIAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@NOTARECEPCION", FbDbType.VarChar);
                if (!(bool)oCGUIANuevo.isnull["INOTARECEPCION"])
                {
                    auxPar.Value = oCGUIANuevo.INOTARECEPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                




                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCGUIAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCGUIAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  GUIA
  set


NOTARECEPCION=@NOTARECEPCION
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


        public CGUIABE seleccionarGUIA(CGUIABE oCGUIA, FbTransaction st)
        {




            CGUIABE retorno = new CGUIABE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from GUIA where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCGUIA.IID;
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

                    if (dr["ENCARGADOGUIAID"] != System.DBNull.Value)
                    {
                        retorno.IENCARGADOGUIAID = (long)(dr["ENCARGADOGUIAID"]);
                    }

                    if (dr["ESTADOGUIAID"] != System.DBNull.Value)
                    {
                        retorno.IESTADOGUIAID = (long)(dr["ESTADOGUIAID"]);
                    }

                    if (dr["CAJEROID"] != System.DBNull.Value)
                    {
                        retorno.ICAJEROID = (long)(dr["CAJEROID"]);
                    }

                    if (dr["CORTEID"] != System.DBNull.Value)
                    {
                        retorno.ICORTEID = (long)(dr["CORTEID"]);
                    }

                    if (dr["FECHA"] != System.DBNull.Value)
                    {
                        retorno.IFECHA = (DateTime)(dr["FECHA"]);
                    }

                    if (dr["FECHAHORA"] != System.DBNull.Value)
                    {
                        retorno.IFECHAHORA = (DateTime)(dr["FECHAHORA"]);
                    }

                    if (dr["NOTA"] != System.DBNull.Value)
                    {
                        retorno.INOTA = (string)(dr["NOTA"]);
                    }

                    if (dr["FOLIO"] != System.DBNull.Value)
                    {
                        retorno.IFOLIO = int.Parse(dr["FOLIO"].ToString());
                    }


                    if (dr["TIPOENTREGAID"] != System.DBNull.Value)
                    {
                        retorno.ITIPOENTREGAID = long.Parse(dr["TIPOENTREGAID"].ToString());
                    }


                    if (dr["GUIAPAQUETERIA"] != System.DBNull.Value)
                    {
                        retorno.IGUIAPAQUETERIA = (string)(dr["GUIAPAQUETERIA"]);
                    }


                    if (dr["VEHICULOID"] != System.DBNull.Value)
                    {
                        retorno.IVEHICULOID = long.Parse(dr["VEHICULOID"].ToString());
                    }

                    if (dr["FECHAESTIMADAREC"] != System.DBNull.Value)
                    {
                        retorno.IFECHAESTIMADAREC = (DateTime)(dr["FECHAESTIMADAREC"]);
                    }

                    if (dr["HORAESTIMADREC"] != System.DBNull.Value)
                    {
                        retorno.IHORAESTIMADREC = (DateTime)(dr["HORAESTIMADREC"]);
                    }

                    if (dr["NOTARECEPCION"] != System.DBNull.Value)
                    {
                        retorno.INOTARECEPCION = (string)(dr["NOTARECEPCION"]);
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








        public DataSet enlistarGUIA()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_GUIA_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public DataSet enlistarCortoGUIA()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_GUIA_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }


        public int ExisteGUIA(CGUIABE oCGUIA, FbTransaction st)
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
                auxPar.Value = oCGUIA.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from GUIA where

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




        public CGUIABE AgregarGUIA(CGUIABE oCGUIA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteGUIA(oCGUIA, st);
                if (iRes == 1)
                {
                    this.IComentario = "El GUIA ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarGUIAD(oCGUIA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarGUIA(CGUIABE oCGUIA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteGUIA(oCGUIA, st);
                if (iRes == 0)
                {
                    this.IComentario = "El GUIA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarGUIAD(oCGUIA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarGUIA(CGUIABE oCGUIANuevo, CGUIABE oCGUIAAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteGUIA(oCGUIAAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El GUIA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarGUIAD(oCGUIANuevo, oCGUIAAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }

        public bool GUIA_INSERT( ref CGUIABE oCGUIA, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

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
                if (!(bool)oCGUIA.isnull["IESTADOGUIAID"])
                {
                    auxPar.Value = oCGUIA.IESTADOGUIAID;
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

                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                if (!(bool)oCGUIA.isnull["ICORTEID"])
                {
                    auxPar.Value = oCGUIA.ICORTEID;
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

                auxPar = new FbParameter("@NOTA", FbDbType.BigInt);
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



                auxPar = new FbParameter("@GUIAID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"GUIA_INSERT";

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
                    oCGUIA.IID = retorno;
                }





                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool GUIA_DELETE(CGUIABE oCGUIA, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@GUIAID", FbDbType.BigInt);
                if (!(bool)oCGUIA.isnull["IID"])
                {
                    auxPar.Value = oCGUIA.IID;
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


                string commandText = @"GUIA_DELETE";

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

                if (oCGUIA.IID == 0 && !(arParms[arParms.Length - 3].Value == System.DBNull.Value))
                {
                    long retorno = (long)arParms[arParms.Length - 3].Value;
                    oCGUIA.IID = retorno;
                }



                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public bool GUIA_CANCEL(CGUIABE oCGUIA, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@GUIAID", FbDbType.BigInt);
                if (!(bool)oCGUIA.isnull["IID"])
                {
                    auxPar.Value = oCGUIA.IID;
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


                string commandText = @"GUIA_CANCEL";

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

                if (oCGUIA.IID == 0 && !(arParms[arParms.Length - 3].Value == System.DBNull.Value))
                {
                    long retorno = (long)arParms[arParms.Length - 3].Value;
                    oCGUIA.IID = retorno;
                }



                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public CGUIAD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
