

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

    


    public class CMENSAJEADJUNTOSD
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


        
        public CMENSAJEADJUNTOSBE AgregarMENSAJEADJUNTOSD(CMENSAJEADJUNTOSBE oCMENSAJEADJUNTOS, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;





                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMENSAJEADJUNTOS.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMENSAJEADJUNTOS.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMENSAJEADJUNTOS.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCMENSAJEADJUNTOS.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMENSAJEADJUNTOS.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMENSAJEADJUNTOS.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDMENSAJE", FbDbType.BigInt);
                if (!(bool)oCMENSAJEADJUNTOS.isnull["IIDMENSAJE"])
                {
                    auxPar.Value = oCMENSAJEADJUNTOS.IIDMENSAJE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RUTAADJUNTO", FbDbType.VarChar);
                if (!(bool)oCMENSAJEADJUNTOS.isnull["IRUTAADJUNTO"])
                {
                    auxPar.Value = oCMENSAJEADJUNTOS.IRUTAADJUNTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBREARCHIVO", FbDbType.VarChar);
                if (!(bool)oCMENSAJEADJUNTOS.isnull["INOMBREARCHIVO"])
                {
                    auxPar.Value = oCMENSAJEADJUNTOS.INOMBREARCHIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FTPADJUNTO", FbDbType.VarChar);
                if (!(bool)oCMENSAJEADJUNTOS.isnull["IFTPADJUNTO"])
                {
                    auxPar.Value = oCMENSAJEADJUNTOS.IFTPADJUNTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO MENSAJEADJUNTOS
      (
    

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

IDMENSAJE,

RUTAADJUNTO,

NOMBREARCHIVO,

FTPADJUNTO
         )

Values (


@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@IDMENSAJE,

@RUTAADJUNTO,

@NOMBREARCHIVO,

@FTPADJUNTO
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCMENSAJEADJUNTOS;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        
        public bool BorrarMENSAJEADJUNTOSD(CMENSAJEADJUNTOSBE oCMENSAJEADJUNTOS, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMENSAJEADJUNTOS.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from MENSAJEADJUNTOS
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


        
        public bool CambiarMENSAJEADJUNTOSD(CMENSAJEADJUNTOSBE oCMENSAJEADJUNTOSNuevo, CMENSAJEADJUNTOSBE oCMENSAJEADJUNTOSAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMENSAJEADJUNTOSNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMENSAJEADJUNTOSNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMENSAJEADJUNTOSNuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCMENSAJEADJUNTOSNuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMENSAJEADJUNTOSNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMENSAJEADJUNTOSNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDMENSAJE", FbDbType.BigInt);
                if (!(bool)oCMENSAJEADJUNTOSNuevo.isnull["IIDMENSAJE"])
                {
                    auxPar.Value = oCMENSAJEADJUNTOSNuevo.IIDMENSAJE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@RUTAADJUNTO", FbDbType.VarChar);
                if (!(bool)oCMENSAJEADJUNTOSNuevo.isnull["IRUTAADJUNTO"])
                {
                    auxPar.Value = oCMENSAJEADJUNTOSNuevo.IRUTAADJUNTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBREARCHIVO", FbDbType.VarChar);
                if (!(bool)oCMENSAJEADJUNTOSNuevo.isnull["INOMBREARCHIVO"])
                {
                    auxPar.Value = oCMENSAJEADJUNTOSNuevo.INOMBREARCHIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FTPADJUNTO", FbDbType.VarChar);
                if (!(bool)oCMENSAJEADJUNTOSNuevo.isnull["IFTPADJUNTO"])
                {
                    auxPar.Value = oCMENSAJEADJUNTOSNuevo.IFTPADJUNTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCMENSAJEADJUNTOSAnterior.isnull["IID"])
                {
                    auxPar.Value = oCMENSAJEADJUNTOSAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  MENSAJEADJUNTOS
  set


ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

IDMENSAJE=@IDMENSAJE,

RUTAADJUNTO=@RUTAADJUNTO,

NOMBREARCHIVO = @NOMBREARCHIVO,

FTPADJUNTO = @FTPADJUNTO
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




        public bool CambiarFTPADJUNTOD(CMENSAJEADJUNTOSBE oCMENSAJEADJUNTOSNuevo, CMENSAJEADJUNTOSBE oCMENSAJEADJUNTOSAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;





                auxPar = new FbParameter("@FTPADJUNTO", FbDbType.VarChar);
                if (!(bool)oCMENSAJEADJUNTOSNuevo.isnull["IFTPADJUNTO"])
                {
                    auxPar.Value = oCMENSAJEADJUNTOSNuevo.IFTPADJUNTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCMENSAJEADJUNTOSAnterior.isnull["IID"])
                {
                    auxPar.Value = oCMENSAJEADJUNTOSAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  MENSAJEADJUNTOS
  set


FTPADJUNTO = @FTPADJUNTO
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


        public List<CMENSAJEADJUNTOSBE> getMensajeAdj(long mensajeID, FbTransaction st)
        {
            List<CMENSAJEADJUNTOSBE> retorno = new List<CMENSAJEADJUNTOSBE>();
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@IDMENSAJE", FbDbType.BigInt);
                auxPar.Value = mensajeID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"SELECT * from  MENSAJEADJUNTOS where IDMENSAJE =  @IDMENSAJE;";



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);



                while (dr.Read())
                {
                    CMENSAJEADJUNTOSBE menadj = new CMENSAJEADJUNTOSBE();
                    if (dr["ID"] != System.DBNull.Value)
                    {
                        menadj.IID = (long)(dr["ID"]);
                    }

                    if (dr["ACTIVO"] != System.DBNull.Value)
                    {
                        menadj.IACTIVO = (string)(dr["ACTIVO"]);
                    }

                    if (dr["CREADO"] != System.DBNull.Value)
                    {
                        menadj.ICREADO = (object)(dr["CREADO"]);
                    }

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        menadj.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADO"] != System.DBNull.Value)
                    {
                        menadj.IMODIFICADO = (object)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        menadj.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["IDMENSAJE"] != System.DBNull.Value)
                    {
                        menadj.IIDMENSAJE = (long)(dr["IDMENSAJE"]);
                    }

                    if (dr["RUTAADJUNTO"] != System.DBNull.Value)
                    {
                        menadj.IRUTAADJUNTO = (string)(dr["RUTAADJUNTO"]);
                    }


                    if (dr["NOMBREARCHIVO"] != System.DBNull.Value)
                    {
                        menadj.INOMBREARCHIVO = (string)(dr["NOMBREARCHIVO"]);
                    }

                    if (dr["FTPADJUNTO"] != System.DBNull.Value)
                    {
                        menadj.IFTPADJUNTO = (string)(dr["FTPADJUNTO"]);
                    }

                    retorno.Add(menadj);
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

        
        public CMENSAJEADJUNTOSBE seleccionarMENSAJEADJUNTOS(CMENSAJEADJUNTOSBE oCMENSAJEADJUNTOS, FbTransaction st)
        {




            CMENSAJEADJUNTOSBE retorno = new CMENSAJEADJUNTOSBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from MENSAJEADJUNTOS where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMENSAJEADJUNTOS.IID;
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

                    if (dr["IDMENSAJE"] != System.DBNull.Value)
                    {
                        retorno.IIDMENSAJE = (long)(dr["IDMENSAJE"]);
                    }

                    if (dr["RUTAADJUNTO"] != System.DBNull.Value)
                    {
                        retorno.IRUTAADJUNTO = (string)(dr["RUTAADJUNTO"]);
                    }


                    if (dr["NOMBREARCHIVO"] != System.DBNull.Value)
                    {
                        retorno.INOMBREARCHIVO = (string)(dr["NOMBREARCHIVO"]);
                    }

                    if (dr["FTPADJUNTO"] != System.DBNull.Value)
                    {
                        retorno.IFTPADJUNTO = (string)(dr["FTPADJUNTO"]);
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









        
        public DataSet enlistarMENSAJEADJUNTOS()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_MENSAJEADJUNTOS_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        
        public DataSet enlistarCortoMENSAJEADJUNTOS()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_MENSAJEADJUNTOS_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        
        public int ExisteMENSAJEADJUNTOS(CMENSAJEADJUNTOSBE oCMENSAJEADJUNTOS, FbTransaction st)
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
                auxPar.Value = oCMENSAJEADJUNTOS.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from MENSAJEADJUNTOS where

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




        public CMENSAJEADJUNTOSBE AgregarMENSAJEADJUNTOS(CMENSAJEADJUNTOSBE oCMENSAJEADJUNTOS, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMENSAJEADJUNTOS(oCMENSAJEADJUNTOS, st);
                if (iRes == 1)
                {
                    this.IComentario = "El MENSAJEADJUNTOS ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarMENSAJEADJUNTOSD(oCMENSAJEADJUNTOS, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarMENSAJEADJUNTOS(CMENSAJEADJUNTOSBE oCMENSAJEADJUNTOS, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMENSAJEADJUNTOS(oCMENSAJEADJUNTOS, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MENSAJEADJUNTOS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarMENSAJEADJUNTOSD(oCMENSAJEADJUNTOS, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarMENSAJEADJUNTOS(CMENSAJEADJUNTOSBE oCMENSAJEADJUNTOSNuevo, CMENSAJEADJUNTOSBE oCMENSAJEADJUNTOSAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMENSAJEADJUNTOS(oCMENSAJEADJUNTOSAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MENSAJEADJUNTOS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarMENSAJEADJUNTOSD(oCMENSAJEADJUNTOSNuevo, oCMENSAJEADJUNTOSAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CMENSAJEADJUNTOSD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
