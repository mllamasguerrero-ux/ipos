
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



    public class CCLERKPAGOSERVICIOD
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


        public CCLERKPAGOSERVICIOBE AgregarCLERKPAGOSERVICIOD(CCLERKPAGOSERVICIOBE oCCLERKPAGOSERVICIO, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCCLERKPAGOSERVICIO.isnull["IACTIVO"])
                {
                    auxPar.Value = oCCLERKPAGOSERVICIO.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCLERKPAGOSERVICIO.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCCLERKPAGOSERVICIO.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCLERKPAGOSERVICIO.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCCLERKPAGOSERVICIO.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLERKID", FbDbType.VarChar);
                if (!(bool)oCCLERKPAGOSERVICIO.isnull["ICLERKID"])
                {
                    auxPar.Value = oCCLERKPAGOSERVICIO.ICLERKID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@SUCURSALCLAVE", FbDbType.VarChar);
                if (!(bool)oCCLERKPAGOSERVICIO.isnull["ISUCURSALCLAVE"])
                {
                    auxPar.Value = oCCLERKPAGOSERVICIO.ISUCURSALCLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (!(bool)oCCLERKPAGOSERVICIO.isnull["ISUCURSALID"])
                {
                    auxPar.Value = oCCLERKPAGOSERVICIO.ISUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESSERVICIO", FbDbType.Char);
                if (!(bool)oCCLERKPAGOSERVICIO.isnull["IESSERVICIO"])
                {
                    auxPar.Value = oCCLERKPAGOSERVICIO.IESSERVICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO CLERKPAGOSERVICIO
      (
    

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

CLERKID,

SUCURSALCLAVE,

SUCURSALID,

ESSERVICIO
         )

Values (


@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@CLERKID,

@SUCURSALCLAVE,

@SUCURSALID,

@ESSERVICIO
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCCLERKPAGOSERVICIO;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarCLERKPAGOSERVICIOD(CCLERKPAGOSERVICIOBE oCCLERKPAGOSERVICIO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCCLERKPAGOSERVICIO.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from CLERKPAGOSERVICIO
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


        public bool CambiarCLERKPAGOSERVICIOD(CCLERKPAGOSERVICIOBE oCCLERKPAGOSERVICIONuevo, CCLERKPAGOSERVICIOBE oCCLERKPAGOSERVICIOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCCLERKPAGOSERVICIONuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCCLERKPAGOSERVICIONuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCLERKPAGOSERVICIONuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCCLERKPAGOSERVICIONuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCLERKPAGOSERVICIONuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCCLERKPAGOSERVICIONuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLERKID", FbDbType.VarChar);
                if (!(bool)oCCLERKPAGOSERVICIONuevo.isnull["ICLERKID"])
                {
                    auxPar.Value = oCCLERKPAGOSERVICIONuevo.ICLERKID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUCURSALCLAVE", FbDbType.VarChar);
                if (!(bool)oCCLERKPAGOSERVICIONuevo.isnull["ISUCURSALCLAVE"])
                {
                    auxPar.Value = oCCLERKPAGOSERVICIONuevo.ISUCURSALCLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (!(bool)oCCLERKPAGOSERVICIONuevo.isnull["ISUCURSALID"])
                {
                    auxPar.Value = oCCLERKPAGOSERVICIONuevo.ISUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESSERVICIO", FbDbType.Char);
                if (!(bool)oCCLERKPAGOSERVICIONuevo.isnull["IESSERVICIO"])
                {
                    auxPar.Value = oCCLERKPAGOSERVICIONuevo.IESSERVICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCCLERKPAGOSERVICIOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCCLERKPAGOSERVICIOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
  update  CLERKPAGOSERVICIO
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

CLERKID=@CLERKID,

SUCURSALCLAVE=@SUCURSALCLAVE,

SUCURSALID=@SUCURSALID,

ESSERVICIO=@ESSERVICIO
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


        public CCLERKPAGOSERVICIOBE seleccionarCLERKPAGOSERVICIO(CCLERKPAGOSERVICIOBE oCCLERKPAGOSERVICIO, FbTransaction st)
        {




            CCLERKPAGOSERVICIOBE retorno = new CCLERKPAGOSERVICIOBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from CLERKPAGOSERVICIO where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCCLERKPAGOSERVICIO.IID;
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

                    if (dr["CLERKID"] != System.DBNull.Value)
                    {
                        retorno.ICLERKID = (string)(dr["CLERKID"]);
                    }

                    if (dr["SUCURSALCLAVE"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSALCLAVE = (string)(dr["SUCURSALCLAVE"]);
                    }

                    if (dr["SUCURSALID"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSALID = (long)(dr["SUCURSALID"]);
                    }

                    if (dr["ESSERVICIO"] != System.DBNull.Value)
                    {
                        retorno.IESSERVICIO = (string)(dr["ESSERVICIO"]);
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





        public CCLERKPAGOSERVICIOBE seleccionarCLERKPAGOSERVICIOxCLERKID(CCLERKPAGOSERVICIOBE oCCLERKPAGOSERVICIO, FbTransaction st)
        {




            CCLERKPAGOSERVICIOBE retorno = new CCLERKPAGOSERVICIOBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from CLERKPAGOSERVICIO where CLERKID=@CLERKID  AND (ESSERVICIO = @ESSERVICIO OR (@ESSERVICIO = 'N' AND ESSERVICIO IS NULL) ) ";


                auxPar = new FbParameter("@CLERKID", FbDbType.VarChar);
                auxPar.Value = oCCLERKPAGOSERVICIO.ICLERKID;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ESSERVICIO", FbDbType.VarChar);
                auxPar.Value = oCCLERKPAGOSERVICIO.IESSERVICIO;
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

                    if (dr["CLERKID"] != System.DBNull.Value)
                    {
                        retorno.ICLERKID = (string)(dr["CLERKID"]);
                    }


                    if (dr["SUCURSALCLAVE"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSALCLAVE = (string)(dr["SUCURSALCLAVE"]);
                    }

                    if (dr["SUCURSALID"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSALID = (long)(dr["SUCURSALID"]);
                    }

                    if (dr["ESSERVICIO"] != System.DBNull.Value)
                    {
                        retorno.IESSERVICIO = (string)(dr["ESSERVICIO"]);
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
        public DataSet enlistarCLERKPAGOSERVICIO()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_CLERKPAGOSERVICIO_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoCLERKPAGOSERVICIO()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_CLERKPAGOSERVICIO_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteCLERKPAGOSERVICIO(CCLERKPAGOSERVICIOBE oCCLERKPAGOSERVICIO, FbTransaction st)
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
                auxPar.Value = oCCLERKPAGOSERVICIO.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from CLERKPAGOSERVICIO where

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




        public CCLERKPAGOSERVICIOBE AgregarCLERKPAGOSERVICIO(CCLERKPAGOSERVICIOBE oCCLERKPAGOSERVICIO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCLERKPAGOSERVICIO(oCCLERKPAGOSERVICIO, st);
                if (iRes == 1)
                {
                    this.IComentario = "El CLERKPAGOSERVICIO ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarCLERKPAGOSERVICIOD(oCCLERKPAGOSERVICIO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarCLERKPAGOSERVICIO(CCLERKPAGOSERVICIOBE oCCLERKPAGOSERVICIO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCLERKPAGOSERVICIO(oCCLERKPAGOSERVICIO, st);
                if (iRes == 0)
                {
                    this.IComentario = "El CLERKPAGOSERVICIO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarCLERKPAGOSERVICIOD(oCCLERKPAGOSERVICIO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarCLERKPAGOSERVICIO(CCLERKPAGOSERVICIOBE oCCLERKPAGOSERVICIONuevo, CCLERKPAGOSERVICIOBE oCCLERKPAGOSERVICIOAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCLERKPAGOSERVICIO(oCCLERKPAGOSERVICIOAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El CLERKPAGOSERVICIO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarCLERKPAGOSERVICIOD(oCCLERKPAGOSERVICIONuevo, oCCLERKPAGOSERVICIOAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CCLERKPAGOSERVICIOD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
