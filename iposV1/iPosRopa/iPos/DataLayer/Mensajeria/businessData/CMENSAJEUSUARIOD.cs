

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

    


    public class CMENSAJEUSUARIOD
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


        
        public CMENSAJEUSUARIOBE AgregarMENSAJEUSUARIOD(CMENSAJEUSUARIOBE oCMENSAJEUSUARIO, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;





                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMENSAJEUSUARIO.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMENSAJEUSUARIO.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMENSAJEUSUARIO.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCMENSAJEUSUARIO.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMENSAJEUSUARIO.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMENSAJEUSUARIO.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDMENSAJE", FbDbType.BigInt);
                if (!(bool)oCMENSAJEUSUARIO.isnull["IIDMENSAJE"])
                {
                    auxPar.Value = oCMENSAJEUSUARIO.IIDMENSAJE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCMENSAJEUSUARIO.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCMENSAJEUSUARIO.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MENSAJEESTADOID", FbDbType.BigInt);
                if (!(bool)oCMENSAJEUSUARIO.isnull["IMENSAJEESTADOID"])
                {
                    auxPar.Value = oCMENSAJEUSUARIO.IMENSAJEESTADOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO MENSAJEUSUARIO
      (
    
ACTIVO,


CREADOPOR_USERID,

MODIFICADOPOR_USERID,

IDMENSAJE,

PERSONAID,

MENSAJEESTADOID
         )

Values (


@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@IDMENSAJE,

@PERSONAID,

@MENSAJEESTADOID
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCMENSAJEUSUARIO;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        
        public bool BorrarMENSAJEUSUARIOD(CMENSAJEUSUARIOBE oCMENSAJEUSUARIO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMENSAJEUSUARIO.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from MENSAJEUSUARIO
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


        
        public bool CambiarMENSAJEUSUARIOD(CMENSAJEUSUARIOBE oCMENSAJEUSUARIONuevo, CMENSAJEUSUARIOBE oCMENSAJEUSUARIOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMENSAJEUSUARIONuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMENSAJEUSUARIONuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMENSAJEUSUARIONuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCMENSAJEUSUARIONuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMENSAJEUSUARIONuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMENSAJEUSUARIONuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDMENSAJE", FbDbType.BigInt);
                if (!(bool)oCMENSAJEUSUARIONuevo.isnull["IIDMENSAJE"])
                {
                    auxPar.Value = oCMENSAJEUSUARIONuevo.IIDMENSAJE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCMENSAJEUSUARIONuevo.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCMENSAJEUSUARIONuevo.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MENSAJEESTADOID", FbDbType.BigInt);
                if (!(bool)oCMENSAJEUSUARIONuevo.isnull["IMENSAJEESTADOID"])
                {
                    auxPar.Value = oCMENSAJEUSUARIONuevo.IMENSAJEESTADOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCMENSAJEUSUARIOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCMENSAJEUSUARIOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  MENSAJEUSUARIO
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

IDMENSAJE=@IDMENSAJE,

PERSONAID=@PERSONAID,

MENSAJEESTADOID=@MENSAJEESTADOID
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


        
        public CMENSAJEUSUARIOBE seleccionarMENSAJEUSUARIO(CMENSAJEUSUARIOBE oCMENSAJEUSUARIO, FbTransaction st)
        {




            CMENSAJEUSUARIOBE retorno = new CMENSAJEUSUARIOBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from MENSAJEUSUARIO where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMENSAJEUSUARIO.IID;
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

                    if (dr["PERSONAID"] != System.DBNull.Value)
                    {
                        retorno.IPERSONAID = (long)(dr["PERSONAID"]);
                    }

                    if (dr["MENSAJEESTADOID"] != System.DBNull.Value)
                    {
                        retorno.IMENSAJEESTADOID = (long)(dr["MENSAJEESTADOID"]);
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









        
        public DataSet enlistarMENSAJEUSUARIO()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_MENSAJEUSUARIO_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        
        public DataSet enlistarCortoMENSAJEUSUARIO()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_MENSAJEUSUARIO_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        
        public int ExisteMENSAJEUSUARIO(CMENSAJEUSUARIOBE oCMENSAJEUSUARIO, FbTransaction st)
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
                auxPar.Value = oCMENSAJEUSUARIO.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from MENSAJEUSUARIO where

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




        public CMENSAJEUSUARIOBE AgregarMENSAJEUSUARIO(CMENSAJEUSUARIOBE oCMENSAJEUSUARIO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMENSAJEUSUARIO(oCMENSAJEUSUARIO, st);
                if (iRes == 1)
                {
                    this.IComentario = "El MENSAJEUSUARIO ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarMENSAJEUSUARIOD(oCMENSAJEUSUARIO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarMENSAJEUSUARIO(CMENSAJEUSUARIOBE oCMENSAJEUSUARIO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMENSAJEUSUARIO(oCMENSAJEUSUARIO, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MENSAJEUSUARIO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarMENSAJEUSUARIOD(oCMENSAJEUSUARIO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarMENSAJEUSUARIO(CMENSAJEUSUARIOBE oCMENSAJEUSUARIONuevo, CMENSAJEUSUARIOBE oCMENSAJEUSUARIOAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMENSAJEUSUARIO(oCMENSAJEUSUARIOAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MENSAJEUSUARIO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarMENSAJEUSUARIOD(oCMENSAJEUSUARIONuevo, oCMENSAJEUSUARIOAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CMENSAJEUSUARIOD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
