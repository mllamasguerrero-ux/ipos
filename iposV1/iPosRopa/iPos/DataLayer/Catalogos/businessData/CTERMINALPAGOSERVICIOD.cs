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



    public class CTERMINALPAGOSERVICIOD
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


        public CTERMINALPAGOSERVICIOBE AgregarTERMINALPAGOSERVICIOD(CTERMINALPAGOSERVICIOBE oCTERMINALPAGOSERVICIO, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCTERMINALPAGOSERVICIO.isnull["IID"])
                {
                    auxPar.Value = oCTERMINALPAGOSERVICIO.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCTERMINALPAGOSERVICIO.isnull["IACTIVO"])
                {
                    auxPar.Value = oCTERMINALPAGOSERVICIO.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCTERMINALPAGOSERVICIO.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCTERMINALPAGOSERVICIO.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCTERMINALPAGOSERVICIO.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCTERMINALPAGOSERVICIO.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TERMINAL", FbDbType.VarChar);
                if (!(bool)oCTERMINALPAGOSERVICIO.isnull["ITERMINAL"])
                {
                    auxPar.Value = oCTERMINALPAGOSERVICIO.ITERMINAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUCURSALCLAVE", FbDbType.VarChar);
                if (!(bool)oCTERMINALPAGOSERVICIO.isnull["ISUCURSALCLAVE"])
                {
                    auxPar.Value = oCTERMINALPAGOSERVICIO.ISUCURSALCLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (!(bool)oCTERMINALPAGOSERVICIO.isnull["ISUCURSALID"])
                {
                    auxPar.Value = oCTERMINALPAGOSERVICIO.ISUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CONSECUTIVO", FbDbType.BigInt);
                if (!(bool)oCTERMINALPAGOSERVICIO.isnull["ICONSECUTIVO"])
                {
                    auxPar.Value = oCTERMINALPAGOSERVICIO.ICONSECUTIVO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESSERVICIO", FbDbType.VarChar);
                if (!(bool)oCTERMINALPAGOSERVICIO.isnull["IESSERVICIO"])
                {
                    auxPar.Value = oCTERMINALPAGOSERVICIO.IESSERVICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                string commandText = @"
        INSERT INTO TERMINALPAGOSERVICIO
      (
    
ID,

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

TERMINAL,

SUCURSALCLAVE,

SUCURSALID,

CONSECUTIVO,

ESSERVICIO
         )

Values (

@ID,

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@TERMINAL,

@SUCURSALCLAVE,

@SUCURSALID,

@CONSECUTIVO,

@ESSERVICIO
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCTERMINALPAGOSERVICIO;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarTERMINALPAGOSERVICIOD(CTERMINALPAGOSERVICIOBE oCTERMINALPAGOSERVICIO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCTERMINALPAGOSERVICIO.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from TERMINALPAGOSERVICIO
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


        public bool CambiarTERMINALPAGOSERVICIOD(CTERMINALPAGOSERVICIOBE oCTERMINALPAGOSERVICIONuevo, CTERMINALPAGOSERVICIOBE oCTERMINALPAGOSERVICIOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCTERMINALPAGOSERVICIONuevo.isnull["IID"])
                {
                    auxPar.Value = oCTERMINALPAGOSERVICIONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCTERMINALPAGOSERVICIONuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCTERMINALPAGOSERVICIONuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCTERMINALPAGOSERVICIONuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCTERMINALPAGOSERVICIONuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCTERMINALPAGOSERVICIONuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCTERMINALPAGOSERVICIONuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TERMINAL", FbDbType.VarChar);
                if (!(bool)oCTERMINALPAGOSERVICIONuevo.isnull["ITERMINAL"])
                {
                    auxPar.Value = oCTERMINALPAGOSERVICIONuevo.ITERMINAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUCURSALCLAVE", FbDbType.VarChar);
                if (!(bool)oCTERMINALPAGOSERVICIONuevo.isnull["ISUCURSALCLAVE"])
                {
                    auxPar.Value = oCTERMINALPAGOSERVICIONuevo.ISUCURSALCLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (!(bool)oCTERMINALPAGOSERVICIONuevo.isnull["ISUCURSALID"])
                {
                    auxPar.Value = oCTERMINALPAGOSERVICIONuevo.ISUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESSERVICIO", FbDbType.VarChar);
                if (!(bool)oCTERMINALPAGOSERVICIONuevo.isnull["IESSERVICIO"])
                {
                    auxPar.Value = oCTERMINALPAGOSERVICIONuevo.IESSERVICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                /*auxPar = new FbParameter("@CONSECUTIVO", FbDbType.BigInt);
                if (!(bool)oCTERMINALPAGOSERVICIONuevo.isnull["ICONSECUTIVO"])
                {
                    auxPar.Value = oCTERMINALPAGOSERVICIONuevo.ICONSECUTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);*/

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCTERMINALPAGOSERVICIOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCTERMINALPAGOSERVICIOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  TERMINALPAGOSERVICIO
  set

ID=@ID,

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

TERMINAL=@TERMINAL,

SUCURSALCLAVE=@SUCURSALCLAVE,

SUCURSALID=@SUCURSALID,

ESSERVICIO = @ESSERVICIO
  where 

ID=@IDAnt
  ;";


                //,CONSECUTIVO=@CONSECUTIVO

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


        public CTERMINALPAGOSERVICIOBE seleccionarTERMINALPAGOSERVICIO(CTERMINALPAGOSERVICIOBE oCTERMINALPAGOSERVICIO, FbTransaction st)
        {




            CTERMINALPAGOSERVICIOBE retorno = new CTERMINALPAGOSERVICIOBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from TERMINALPAGOSERVICIO where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCTERMINALPAGOSERVICIO.IID;
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

                    if (dr["TERMINAL"] != System.DBNull.Value)
                    {
                        retorno.ITERMINAL = (string)(dr["TERMINAL"]);
                    }

                    if (dr["SUCURSALCLAVE"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSALCLAVE = (string)(dr["SUCURSALCLAVE"]);
                    }

                    if (dr["SUCURSALID"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSALID = (long)(dr["SUCURSALID"]);
                    }

                    if (dr["CONSECUTIVO"] != System.DBNull.Value)
                    {
                        retorno.ICONSECUTIVO = (long)(dr["CONSECUTIVO"]);
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




        public CTERMINALPAGOSERVICIOBE seleccionarTERMINALPAGOSERVICIOXTERMINAL(CTERMINALPAGOSERVICIOBE oCTERMINALPAGOSERVICIO, FbTransaction st)
        {




            CTERMINALPAGOSERVICIOBE retorno = new CTERMINALPAGOSERVICIOBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from TERMINALPAGOSERVICIO where TERMINAL=@TERMINAL AND (ESSERVICIO = @ESSERVICIO OR (@ESSERVICIO = 'N' AND ESSERVICIO IS NULL) )";


                auxPar = new FbParameter("@TERMINAL", FbDbType.VarChar);
                auxPar.Value = oCTERMINALPAGOSERVICIO.ITERMINAL;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESSERVICIO", FbDbType.VarChar);
                auxPar.Value = oCTERMINALPAGOSERVICIO.IESSERVICIO;
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

                    if (dr["TERMINAL"] != System.DBNull.Value)
                    {
                        retorno.ITERMINAL = (string)(dr["TERMINAL"]);
                    }

                    if (dr["SUCURSALCLAVE"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSALCLAVE = (string)(dr["SUCURSALCLAVE"]);
                    }

                    if (dr["SUCURSALID"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSALID = (long)(dr["SUCURSALID"]);
                    }

                    if (dr["CONSECUTIVO"] != System.DBNull.Value)
                    {
                        retorno.ICONSECUTIVO = (long)(dr["CONSECUTIVO"]);
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





        public DataSet enlistarTERMINALPAGOSERVICIO()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_TERMINALPAGOSERVICIO_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoTERMINALPAGOSERVICIO()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_TERMINALPAGOSERVICIO_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExisteTERMINALPAGOSERVICIO(CTERMINALPAGOSERVICIOBE oCTERMINALPAGOSERVICIO, FbTransaction st)
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
                auxPar.Value = oCTERMINALPAGOSERVICIO.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from TERMINALPAGOSERVICIO where

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




        public CTERMINALPAGOSERVICIOBE AgregarTERMINALPAGOSERVICIO(CTERMINALPAGOSERVICIOBE oCTERMINALPAGOSERVICIO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteTERMINALPAGOSERVICIO(oCTERMINALPAGOSERVICIO, st);
                if (iRes == 1)
                {
                    this.IComentario = "El TERMINALPAGOSERVICIO ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarTERMINALPAGOSERVICIOD(oCTERMINALPAGOSERVICIO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarTERMINALPAGOSERVICIO(CTERMINALPAGOSERVICIOBE oCTERMINALPAGOSERVICIO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteTERMINALPAGOSERVICIO(oCTERMINALPAGOSERVICIO, st);
                if (iRes == 0)
                {
                    this.IComentario = "El TERMINALPAGOSERVICIO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarTERMINALPAGOSERVICIOD(oCTERMINALPAGOSERVICIO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarTERMINALPAGOSERVICIO(CTERMINALPAGOSERVICIOBE oCTERMINALPAGOSERVICIONuevo, CTERMINALPAGOSERVICIOBE oCTERMINALPAGOSERVICIOAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteTERMINALPAGOSERVICIO(oCTERMINALPAGOSERVICIOAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El TERMINALPAGOSERVICIO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarTERMINALPAGOSERVICIOD(oCTERMINALPAGOSERVICIONuevo, oCTERMINALPAGOSERVICIOAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CTERMINALPAGOSERVICIOD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
