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



    public class CTIPODIFERENCIAINVENTARIOD
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


        public CTIPODIFERENCIAINVENTARIOBE AgregarTIPODIFERENCIAINVENTARIOD(CTIPODIFERENCIAINVENTARIOBE oCTIPODIFERENCIAINVENTARIO, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCTIPODIFERENCIAINVENTARIO.isnull["IID"])
                {
                    auxPar.Value = oCTIPODIFERENCIAINVENTARIO.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCTIPODIFERENCIAINVENTARIO.isnull["IACTIVO"])
                {
                    auxPar.Value = oCTIPODIFERENCIAINVENTARIO.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCTIPODIFERENCIAINVENTARIO.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCTIPODIFERENCIAINVENTARIO.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCTIPODIFERENCIAINVENTARIO.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCTIPODIFERENCIAINVENTARIO.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCTIPODIFERENCIAINVENTARIO.isnull["ICLAVE"])
                {
                    auxPar.Value = oCTIPODIFERENCIAINVENTARIO.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCTIPODIFERENCIAINVENTARIO.isnull["INOMBRE"])
                {
                    auxPar.Value = oCTIPODIFERENCIAINVENTARIO.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCTIPODIFERENCIAINVENTARIO.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCTIPODIFERENCIAINVENTARIO.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MEMO", FbDbType.Text);
                if (!(bool)oCTIPODIFERENCIAINVENTARIO.isnull["IMEMO"])
                {
                    auxPar.Value = oCTIPODIFERENCIAINVENTARIO.IMEMO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@GRUPODIFERENCIAINVENTARIOID", FbDbType.BigInt);
                if (!(bool)oCTIPODIFERENCIAINVENTARIO.isnull["IGRUPODIFERENCIAINVENTARIOID"])
                {
                    auxPar.Value = oCTIPODIFERENCIAINVENTARIO.IGRUPODIFERENCIAINVENTARIOID;
                }
                else
                {
                    auxPar.Value = 1;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO TIPODIFERENCIAINVENTARIO
      (
    
ID,

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

CLAVE,

NOMBRE,

DESCRIPCION,

MEMO,

GRUPODIFERENCIAINVENTARIOID
         )

Values (

@ID,

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@CLAVE,

@NOMBRE,

@DESCRIPCION,

@MEMO,

@GRUPODIFERENCIAINVENTARIOID
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCTIPODIFERENCIAINVENTARIO;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }



        public bool BorrarTIPODIFERENCIAINVENTARIOD(CTIPODIFERENCIAINVENTARIOBE oCTIPODIFERENCIAINVENTARIO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCTIPODIFERENCIAINVENTARIO.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from TIPODIFERENCIAINVENTARIO
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


        public bool CambiarTIPODIFERENCIAINVENTARIOD(CTIPODIFERENCIAINVENTARIOBE oCTIPODIFERENCIAINVENTARIONuevo, CTIPODIFERENCIAINVENTARIOBE oCTIPODIFERENCIAINVENTARIOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCTIPODIFERENCIAINVENTARIONuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCTIPODIFERENCIAINVENTARIONuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCTIPODIFERENCIAINVENTARIONuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCTIPODIFERENCIAINVENTARIONuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCTIPODIFERENCIAINVENTARIONuevo.isnull["ICLAVE"])
                {
                    auxPar.Value = oCTIPODIFERENCIAINVENTARIONuevo.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCTIPODIFERENCIAINVENTARIONuevo.isnull["INOMBRE"])
                {
                    auxPar.Value = oCTIPODIFERENCIAINVENTARIONuevo.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCTIPODIFERENCIAINVENTARIONuevo.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCTIPODIFERENCIAINVENTARIONuevo.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MEMO", FbDbType.Text);
                if (!(bool)oCTIPODIFERENCIAINVENTARIONuevo.isnull["IMEMO"])
                {
                    auxPar.Value = oCTIPODIFERENCIAINVENTARIONuevo.IMEMO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@GRUPODIFERENCIAINVENTARIOID", FbDbType.BigInt);
                if (!(bool)oCTIPODIFERENCIAINVENTARIONuevo.isnull["IGRUPODIFERENCIAINVENTARIOID"])
                {
                    auxPar.Value = oCTIPODIFERENCIAINVENTARIONuevo.IGRUPODIFERENCIAINVENTARIOID;
                }
                else
                {
                    auxPar.Value = 1;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCTIPODIFERENCIAINVENTARIOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCTIPODIFERENCIAINVENTARIOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  TIPODIFERENCIAINVENTARIO
  set


ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

CLAVE=@CLAVE,

NOMBRE=@NOMBRE,

DESCRIPCION=@DESCRIPCION,

MEMO=@MEMO,

GRUPODIFERENCIAINVENTARIOID=@GRUPODIFERENCIAINVENTARIOID

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


        public CTIPODIFERENCIAINVENTARIOBE seleccionarTIPODIFERENCIAINVENTARIO(CTIPODIFERENCIAINVENTARIOBE oCTIPODIFERENCIAINVENTARIO, FbTransaction st)
        {




            CTIPODIFERENCIAINVENTARIOBE retorno = new CTIPODIFERENCIAINVENTARIOBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from TIPODIFERENCIAINVENTARIO where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCTIPODIFERENCIAINVENTARIO.IID;
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

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = (string)(dr["CLAVE"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
                    }

                    if (dr["MEMO"] != System.DBNull.Value)
                    {
                        retorno.IMEMO = (string)(dr["MEMO"]);
                    }

                    if (dr["GRUPODIFERENCIAINVENTARIOID"] != System.DBNull.Value)
                    {
                        retorno.IGRUPODIFERENCIAINVENTARIOID = (long)(dr["GRUPODIFERENCIAINVENTARIOID"]);
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





        public CTIPODIFERENCIAINVENTARIOBE seleccionarTIPODIFERENCIAINVENTARIOXCLAVE(CTIPODIFERENCIAINVENTARIOBE oCTIPODIFERENCIAINVENTARIO, FbTransaction st)
        {




            CTIPODIFERENCIAINVENTARIOBE retorno = new CTIPODIFERENCIAINVENTARIOBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from TIPODIFERENCIAINVENTARIO where CLAVE = @CLAVE";


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                auxPar.Value = oCTIPODIFERENCIAINVENTARIO.ICLAVE;
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

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = (string)(dr["CLAVE"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
                    }

                    if (dr["MEMO"] != System.DBNull.Value)
                    {
                        retorno.IMEMO = (string)(dr["MEMO"]);
                    }

                    if (dr["GRUPODIFERENCIAINVENTARIOID"] != System.DBNull.Value)
                    {
                        retorno.IGRUPODIFERENCIAINVENTARIOID = (long)(dr["GRUPODIFERENCIAINVENTARIOID"]);
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
        public DataSet enlistarTIPODIFERENCIAINVENTARIO()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_TIPODIFERENCIAINVENTARIO_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoTIPODIFERENCIAINVENTARIO()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_TIPODIFERENCIAINVENTARIO_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteTIPODIFERENCIAINVENTARIO(CTIPODIFERENCIAINVENTARIOBE oCTIPODIFERENCIAINVENTARIO, FbTransaction st)
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
                auxPar.Value = oCTIPODIFERENCIAINVENTARIO.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from TIPODIFERENCIAINVENTARIO where

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




        public CTIPODIFERENCIAINVENTARIOBE AgregarTIPODIFERENCIAINVENTARIO(CTIPODIFERENCIAINVENTARIOBE oCTIPODIFERENCIAINVENTARIO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteTIPODIFERENCIAINVENTARIO(oCTIPODIFERENCIAINVENTARIO, st);
                if (iRes == 1)
                {
                    this.IComentario = "El TIPODIFERENCIAINVENTARIO ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarTIPODIFERENCIAINVENTARIOD(oCTIPODIFERENCIAINVENTARIO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarTIPODIFERENCIAINVENTARIO(CTIPODIFERENCIAINVENTARIOBE oCTIPODIFERENCIAINVENTARIO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteTIPODIFERENCIAINVENTARIO(oCTIPODIFERENCIAINVENTARIO, st);
                if (iRes == 0)
                {
                    this.IComentario = "El TIPODIFERENCIAINVENTARIO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarTIPODIFERENCIAINVENTARIOD(oCTIPODIFERENCIAINVENTARIO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarTIPODIFERENCIAINVENTARIO(CTIPODIFERENCIAINVENTARIOBE oCTIPODIFERENCIAINVENTARIONuevo, CTIPODIFERENCIAINVENTARIOBE oCTIPODIFERENCIAINVENTARIOAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteTIPODIFERENCIAINVENTARIO(oCTIPODIFERENCIAINVENTARIOAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El TIPODIFERENCIAINVENTARIO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarTIPODIFERENCIAINVENTARIOD(oCTIPODIFERENCIAINVENTARIONuevo, oCTIPODIFERENCIAINVENTARIOAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CTIPODIFERENCIAINVENTARIOD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
