
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

    


    public class CMENSAJEAREAD
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


        
        public CMENSAJEAREABE AgregarMENSAJEAREAD(CMENSAJEAREABE oCMENSAJEAREA, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;





                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMENSAJEAREA.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMENSAJEAREA.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMENSAJEAREA.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCMENSAJEAREA.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMENSAJEAREA.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMENSAJEAREA.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDMENSAJE", FbDbType.BigInt);
                if (!(bool)oCMENSAJEAREA.isnull["IIDMENSAJE"])
                {
                    auxPar.Value = oCMENSAJEAREA.IIDMENSAJE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAREA", FbDbType.BigInt);
                if (!(bool)oCMENSAJEAREA.isnull["IIDAREA"])
                {
                    auxPar.Value = oCMENSAJEAREA.IIDAREA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVEAREA", FbDbType.VarChar);
                if (!(bool)oCMENSAJEAREA.isnull["ICLAVEAREA"])
                {
                    auxPar.Value = oCMENSAJEAREA.ICLAVEAREA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO MENSAJEAREA
      (
   

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

IDMENSAJE,

IDAREA,

CLAVEAREA
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@IDMENSAJE,

@IDAREA,

@CLAVEAREA
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCMENSAJEAREA;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        
        public bool BorrarMENSAJEAREAD(CMENSAJEAREABE oCMENSAJEAREA, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMENSAJEAREA.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from MENSAJEAREA
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


        
        public bool CambiarMENSAJEAREAD(CMENSAJEAREABE oCMENSAJEAREANuevo, CMENSAJEAREABE oCMENSAJEAREAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMENSAJEAREANuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMENSAJEAREANuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMENSAJEAREANuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCMENSAJEAREANuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMENSAJEAREANuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMENSAJEAREANuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDMENSAJE", FbDbType.BigInt);
                if (!(bool)oCMENSAJEAREANuevo.isnull["IIDMENSAJE"])
                {
                    auxPar.Value = oCMENSAJEAREANuevo.IIDMENSAJE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAREA", FbDbType.BigInt);
                if (!(bool)oCMENSAJEAREANuevo.isnull["IIDAREA"])
                {
                    auxPar.Value = oCMENSAJEAREANuevo.IIDAREA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVEAREA", FbDbType.VarChar);
                if (!(bool)oCMENSAJEAREANuevo.isnull["ICLAVEAREA"])
                {
                    auxPar.Value = oCMENSAJEAREANuevo.ICLAVEAREA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCMENSAJEAREAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCMENSAJEAREAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  MENSAJEAREA
  set


ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

IDMENSAJE=@IDMENSAJE,

IDAREA=@IDAREA,

CLAVEAREA=@CLAVEAREA
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



        public List<CMENSAJEAREABE> getMensajeAdj(long mensajeID, FbTransaction st)
        {
            List<CMENSAJEAREABE> retorno = new List<CMENSAJEAREABE>();
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

                string commandText = @"SELECT * from  MENSAJEAREA where IDMENSAJE =  @IDMENSAJE;";



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);



                while (dr.Read())
                {
                    CMENSAJEAREABE menarea = new CMENSAJEAREABE();
                    if (dr["ID"] != System.DBNull.Value)
                    {
                        menarea.IID = (long)(dr["ID"]);
                    }

                    if (dr["ACTIVO"] != System.DBNull.Value)
                    {
                        menarea.IACTIVO = (string)(dr["ACTIVO"]);
                    }

                    if (dr["CREADO"] != System.DBNull.Value)
                    {
                        menarea.ICREADO = (object)(dr["CREADO"]);
                    }

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        menarea.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADO"] != System.DBNull.Value)
                    {
                        menarea.IMODIFICADO = (object)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        menarea.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["IDMENSAJE"] != System.DBNull.Value)
                    {
                        menarea.IIDMENSAJE = (long)(dr["IDMENSAJE"]);
                    }

                    if (dr["IDAREA"] != System.DBNull.Value)
                    {
                        menarea.IIDAREA = (long)(dr["IDAREA"]);
                    }

                    if (dr["CLAVEAREA"] != System.DBNull.Value)
                    {
                        menarea.ICLAVEAREA = (string)(dr["CLAVEAREA"]);
                    }

                    retorno.Add(menarea);
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

        
        public CMENSAJEAREABE seleccionarMENSAJEAREA(CMENSAJEAREABE oCMENSAJEAREA, FbTransaction st)
        {




            CMENSAJEAREABE retorno = new CMENSAJEAREABE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from MENSAJEAREA where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMENSAJEAREA.IID;
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

                    if (dr["IDAREA"] != System.DBNull.Value)
                    {
                        retorno.IIDAREA = (long)(dr["IDAREA"]);
                    }

                    if (dr["CLAVEAREA"] != System.DBNull.Value)
                    {
                        retorno.ICLAVEAREA = (string)(dr["CLAVEAREA"]);
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









        
        public DataSet enlistarMENSAJEAREA()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_MENSAJEAREA_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        
        public DataSet enlistarCortoMENSAJEAREA()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_MENSAJEAREA_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        
        public int ExisteMENSAJEAREA(CMENSAJEAREABE oCMENSAJEAREA, FbTransaction st)
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
                auxPar.Value = oCMENSAJEAREA.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from MENSAJEAREA where

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




        public CMENSAJEAREABE AgregarMENSAJEAREA(CMENSAJEAREABE oCMENSAJEAREA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMENSAJEAREA(oCMENSAJEAREA, st);
                if (iRes == 1)
                {
                    this.IComentario = "El MENSAJEAREA ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarMENSAJEAREAD(oCMENSAJEAREA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarMENSAJEAREA(CMENSAJEAREABE oCMENSAJEAREA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMENSAJEAREA(oCMENSAJEAREA, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MENSAJEAREA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarMENSAJEAREAD(oCMENSAJEAREA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarMENSAJEAREA(CMENSAJEAREABE oCMENSAJEAREANuevo, CMENSAJEAREABE oCMENSAJEAREAAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMENSAJEAREA(oCMENSAJEAREAAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MENSAJEAREA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarMENSAJEAREAD(oCMENSAJEAREANuevo, oCMENSAJEAREAAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CMENSAJEAREAD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
