
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


    public class CMERCHANTPAGOSERVICIOD
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


        public CMERCHANTPAGOSERVICIOBE AgregarMERCHANTPAGOSERVICIOD(CMERCHANTPAGOSERVICIOBE oCMERCHANTPAGOSERVICIO, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMERCHANTPAGOSERVICIO.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMERCHANTPAGOSERVICIO.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMERCHANTPAGOSERVICIO.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCMERCHANTPAGOSERVICIO.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMERCHANTPAGOSERVICIO.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMERCHANTPAGOSERVICIO.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MERCHANTID", FbDbType.VarChar);
                if (!(bool)oCMERCHANTPAGOSERVICIO.isnull["IMERCHANTID"])
                {
                    auxPar.Value = oCMERCHANTPAGOSERVICIO.IMERCHANTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUCURSALCLAVE", FbDbType.VarChar);
                if (!(bool)oCMERCHANTPAGOSERVICIO.isnull["ISUCURSALCLAVE"])
                {
                    auxPar.Value = oCMERCHANTPAGOSERVICIO.ISUCURSALCLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (!(bool)oCMERCHANTPAGOSERVICIO.isnull["ISUCURSALID"])
                {
                    auxPar.Value = oCMERCHANTPAGOSERVICIO.ISUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESSERVICIO", FbDbType.VarChar);
                if (!(bool)oCMERCHANTPAGOSERVICIO.isnull["IESSERVICIO"])
                {
                    auxPar.Value = oCMERCHANTPAGOSERVICIO.IESSERVICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO MERCHANTPAGOSERVICIO
      (
    

ACTIVO,


CREADOPOR_USERID,

MODIFICADOPOR_USERID,

MERCHANTID,

SUCURSALCLAVE,

SUCURSALID,

ESSERVICIO
         )

Values (


@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@MERCHANTID,

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






                return oCMERCHANTPAGOSERVICIO;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarMERCHANTPAGOSERVICIOD(CMERCHANTPAGOSERVICIOBE oCMERCHANTPAGOSERVICIO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMERCHANTPAGOSERVICIO.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from MERCHANTPAGOSERVICIO
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


        public bool CambiarMERCHANTPAGOSERVICIOD(CMERCHANTPAGOSERVICIOBE oCMERCHANTPAGOSERVICIONuevo, CMERCHANTPAGOSERVICIOBE oCMERCHANTPAGOSERVICIOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMERCHANTPAGOSERVICIONuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMERCHANTPAGOSERVICIONuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMERCHANTPAGOSERVICIONuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCMERCHANTPAGOSERVICIONuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMERCHANTPAGOSERVICIONuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMERCHANTPAGOSERVICIONuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MERCHANTID", FbDbType.VarChar);
                if (!(bool)oCMERCHANTPAGOSERVICIONuevo.isnull["IMERCHANTID"])
                {
                    auxPar.Value = oCMERCHANTPAGOSERVICIONuevo.IMERCHANTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUCURSALCLAVE", FbDbType.VarChar);
                if (!(bool)oCMERCHANTPAGOSERVICIONuevo.isnull["ISUCURSALCLAVE"])
                {
                    auxPar.Value = oCMERCHANTPAGOSERVICIONuevo.ISUCURSALCLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (!(bool)oCMERCHANTPAGOSERVICIONuevo.isnull["ISUCURSALID"])
                {
                    auxPar.Value = oCMERCHANTPAGOSERVICIONuevo.ISUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ESSERVICIO", FbDbType.VarChar);
                if (!(bool)oCMERCHANTPAGOSERVICIONuevo.isnull["IESSERVICIO"])
                {
                    auxPar.Value = oCMERCHANTPAGOSERVICIONuevo.IESSERVICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCMERCHANTPAGOSERVICIOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCMERCHANTPAGOSERVICIOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  MERCHANTPAGOSERVICIO
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

MERCHANTID=@MERCHANTID,

SUCURSALCLAVE=@SUCURSALCLAVE,

SUCURSALID=@SUCURSALID,

ESSERVICIO = @ESSERVICIO
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


        public CMERCHANTPAGOSERVICIOBE seleccionarMERCHANTPAGOSERVICIO(CMERCHANTPAGOSERVICIOBE oCMERCHANTPAGOSERVICIO, FbTransaction st)
        {




            CMERCHANTPAGOSERVICIOBE retorno = new CMERCHANTPAGOSERVICIOBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from MERCHANTPAGOSERVICIO where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMERCHANTPAGOSERVICIO.IID;
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

                    if (dr["MERCHANTID"] != System.DBNull.Value)
                    {
                        retorno.IMERCHANTID = (string)(dr["MERCHANTID"]);
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






        public CMERCHANTPAGOSERVICIOBE seleccionarMERCHANTPAGOSERVICIOxMERCHANTID(CMERCHANTPAGOSERVICIOBE oCMERCHANTPAGOSERVICIO, FbTransaction st)
        {




            CMERCHANTPAGOSERVICIOBE retorno = new CMERCHANTPAGOSERVICIOBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from MERCHANTPAGOSERVICIO where MERCHANTID=@MERCHANTID  AND (ESSERVICIO = @ESSERVICIO OR (@ESSERVICIO = 'N' AND ESSERVICIO IS NULL) ) ";


                auxPar = new FbParameter("@MERCHANTID", FbDbType.VarChar);
                auxPar.Value = oCMERCHANTPAGOSERVICIO.IMERCHANTID;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ESSERVICIO", FbDbType.VarChar);
                auxPar.Value = oCMERCHANTPAGOSERVICIO.IESSERVICIO;
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

                    if (dr["MERCHANTID"] != System.DBNull.Value)
                    {
                        retorno.IMERCHANTID = (string)(dr["MERCHANTID"]);
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
        public DataSet enlistarMERCHANTPAGOSERVICIO()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_MERCHANTPAGOSERVICIO_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoMERCHANTPAGOSERVICIO()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_MERCHANTPAGOSERVICIO_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteMERCHANTPAGOSERVICIO(CMERCHANTPAGOSERVICIOBE oCMERCHANTPAGOSERVICIO, FbTransaction st)
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
                auxPar.Value = oCMERCHANTPAGOSERVICIO.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from MERCHANTPAGOSERVICIO where

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




        public CMERCHANTPAGOSERVICIOBE AgregarMERCHANTPAGOSERVICIO(CMERCHANTPAGOSERVICIOBE oCMERCHANTPAGOSERVICIO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMERCHANTPAGOSERVICIO(oCMERCHANTPAGOSERVICIO, st);
                if (iRes == 1)
                {
                    this.IComentario = "El MERCHANTPAGOSERVICIO ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarMERCHANTPAGOSERVICIOD(oCMERCHANTPAGOSERVICIO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarMERCHANTPAGOSERVICIO(CMERCHANTPAGOSERVICIOBE oCMERCHANTPAGOSERVICIO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMERCHANTPAGOSERVICIO(oCMERCHANTPAGOSERVICIO, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MERCHANTPAGOSERVICIO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarMERCHANTPAGOSERVICIOD(oCMERCHANTPAGOSERVICIO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarMERCHANTPAGOSERVICIO(CMERCHANTPAGOSERVICIOBE oCMERCHANTPAGOSERVICIONuevo, CMERCHANTPAGOSERVICIOBE oCMERCHANTPAGOSERVICIOAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMERCHANTPAGOSERVICIO(oCMERCHANTPAGOSERVICIOAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MERCHANTPAGOSERVICIO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarMERCHANTPAGOSERVICIOD(oCMERCHANTPAGOSERVICIONuevo, oCMERCHANTPAGOSERVICIOAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CMERCHANTPAGOSERVICIOD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
