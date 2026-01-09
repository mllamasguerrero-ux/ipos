

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




    public class CSAT_MUNICIPIOD
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



        public CSAT_MUNICIPIOBE AgregarSAT_MUNICIPIOD(CSAT_MUNICIPIOBE oCSAT_MUNICIPIO, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_MUNICIPIO.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_MUNICIPIO.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_MUNICIPIO.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_MUNICIPIO.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_MUNICIPIO.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_MUNICIPIO.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE_MUNICIPIO", FbDbType.VarChar);
                if (!(bool)oCSAT_MUNICIPIO.isnull["ICLAVE_MUNICIPIO"])
                {
                    auxPar.Value = oCSAT_MUNICIPIO.ICLAVE_MUNICIPIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE_ESTADO", FbDbType.VarChar);
                if (!(bool)oCSAT_MUNICIPIO.isnull["ICLAVE_ESTADO"])
                {
                    auxPar.Value = oCSAT_MUNICIPIO.ICLAVE_ESTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCSAT_MUNICIPIO.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCSAT_MUNICIPIO.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO SAT_MUNICIPIO
      (
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

CLAVE_MUNICIPIO,

CLAVE_ESTADO,

DESCRIPCION
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@CLAVE_MUNICIPIO,

@CLAVE_ESTADO,

@DESCRIPCION
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCSAT_MUNICIPIO;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }



        public bool BorrarSAT_MUNICIPIOD(CSAT_MUNICIPIOBE oCSAT_MUNICIPIO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_MUNICIPIO.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from SAT_MUNICIPIO
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



        public bool CambiarSAT_MUNICIPIOD(CSAT_MUNICIPIOBE oCSAT_MUNICIPIONuevo, CSAT_MUNICIPIOBE oCSAT_MUNICIPIOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_MUNICIPIONuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_MUNICIPIONuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_MUNICIPIONuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_MUNICIPIONuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVE_MUNICIPIO", FbDbType.VarChar);
                if (!(bool)oCSAT_MUNICIPIONuevo.isnull["ICLAVE_MUNICIPIO"])
                {
                    auxPar.Value = oCSAT_MUNICIPIONuevo.ICLAVE_MUNICIPIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVE_ESTADO", FbDbType.VarChar);
                if (!(bool)oCSAT_MUNICIPIONuevo.isnull["ICLAVE_ESTADO"])
                {
                    auxPar.Value = oCSAT_MUNICIPIONuevo.ICLAVE_ESTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCSAT_MUNICIPIONuevo.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCSAT_MUNICIPIONuevo.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCSAT_MUNICIPIOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCSAT_MUNICIPIOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  SAT_MUNICIPIO
  set

ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

CLAVE_MUNICIPIO=@CLAVE_MUNICIPIO,

CLAVE_ESTADO=@CLAVE_ESTADO,

DESCRIPCION=@DESCRIPCION
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



        public CSAT_MUNICIPIOBE seleccionarSAT_MUNICIPIO(CSAT_MUNICIPIOBE oCSAT_MUNICIPIO, FbTransaction st)
        {




            CSAT_MUNICIPIOBE retorno = new CSAT_MUNICIPIOBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_MUNICIPIO where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_MUNICIPIO.IID;
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

                    if (dr["CLAVE_MUNICIPIO"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE_MUNICIPIO = (string)(dr["CLAVE_MUNICIPIO"]);
                    }

                    if (dr["CLAVE_ESTADO"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE_ESTADO = (string)(dr["CLAVE_ESTADO"]);
                    }

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
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




        public CSAT_MUNICIPIOBE seleccionarSAT_MUNICIPIO_X_CLAVE(CSAT_MUNICIPIOBE oCSAT_MUNICIPIO, FbTransaction st)
        {




            CSAT_MUNICIPIOBE retorno = new CSAT_MUNICIPIOBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_MUNICIPIO where
 CLAVE_ESTADO=@CLAVE_ESTADO and CLAVE_MUNICIPIO = @CLAVE_MUNICIPIO  ";


                auxPar = new FbParameter("@CLAVE_ESTADO", FbDbType.VarChar);
                auxPar.Value = oCSAT_MUNICIPIO.ICLAVE_ESTADO;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVE_MUNICIPIO", FbDbType.VarChar);
                auxPar.Value = oCSAT_MUNICIPIO.ICLAVE_MUNICIPIO;
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

                    if (dr["CLAVE_MUNICIPIO"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE_MUNICIPIO = (string)(dr["CLAVE_MUNICIPIO"]);
                    }

                    if (dr["CLAVE_ESTADO"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE_ESTADO = (string)(dr["CLAVE_ESTADO"]);
                    }

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
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










        public DataSet enlistarSAT_MUNICIPIO()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_SAT_MUNICIPIO_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }





        public DataSet enlistarCortoSAT_MUNICIPIO()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_SAT_MUNICIPIO_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public int ExisteSAT_MUNICIPIO(CSAT_MUNICIPIOBE oCSAT_MUNICIPIO, FbTransaction st)
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
                auxPar.Value = oCSAT_MUNICIPIO.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from SAT_MUNICIPIO where

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




        public CSAT_MUNICIPIOBE AgregarSAT_MUNICIPIO(CSAT_MUNICIPIOBE oCSAT_MUNICIPIO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_MUNICIPIO(oCSAT_MUNICIPIO, st);
                if (iRes == 1)
                {
                    this.IComentario = "El SAT_MUNICIPIO ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarSAT_MUNICIPIOD(oCSAT_MUNICIPIO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSAT_MUNICIPIO(CSAT_MUNICIPIOBE oCSAT_MUNICIPIO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_MUNICIPIO(oCSAT_MUNICIPIO, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_MUNICIPIO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarSAT_MUNICIPIOD(oCSAT_MUNICIPIO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarSAT_MUNICIPIO(CSAT_MUNICIPIOBE oCSAT_MUNICIPIONuevo, CSAT_MUNICIPIOBE oCSAT_MUNICIPIOAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_MUNICIPIO(oCSAT_MUNICIPIOAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_MUNICIPIO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarSAT_MUNICIPIOD(oCSAT_MUNICIPIONuevo, oCSAT_MUNICIPIOAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }



        public CSAT_MUNICIPIOD(string cadenaConexion)
        {
            this.sCadenaConexion = cadenaConexion;
        }



        public CSAT_MUNICIPIOD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
