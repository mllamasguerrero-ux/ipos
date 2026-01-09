

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



    public class CSAT_CODIGOPOSTALD
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


        public CSAT_CODIGOPOSTALBE AgregarSAT_CODIGOPOSTALD(CSAT_CODIGOPOSTALBE oCSAT_CODIGOPOSTAL, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_CODIGOPOSTAL.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_CODIGOPOSTAL.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_CODIGOPOSTAL.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_CODIGOPOSTAL.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_CODIGOPOSTAL.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_CODIGOPOSTAL.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_CLAVE", FbDbType.VarChar);
                if (!(bool)oCSAT_CODIGOPOSTAL.isnull["ISAT_CLAVE"])
                {
                    auxPar.Value = oCSAT_CODIGOPOSTAL.ISAT_CLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_ESTADO", FbDbType.VarChar);
                if (!(bool)oCSAT_CODIGOPOSTAL.isnull["ISAT_ESTADO"])
                {
                    auxPar.Value = oCSAT_CODIGOPOSTAL.ISAT_ESTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_MUNICIPIO", FbDbType.VarChar);
                if (!(bool)oCSAT_CODIGOPOSTAL.isnull["ISAT_MUNICIPIO"])
                {
                    auxPar.Value = oCSAT_CODIGOPOSTAL.ISAT_MUNICIPIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_LOCALIDAD", FbDbType.VarChar);
                if (!(bool)oCSAT_CODIGOPOSTAL.isnull["ISAT_LOCALIDAD"])
                {
                    auxPar.Value = oCSAT_CODIGOPOSTAL.ISAT_LOCALIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO SAT_CODIGOPOSTAL
      (
    
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

SAT_CLAVE,

SAT_ESTADO,

SAT_MUNICIPIO,

SAT_LOCALIDAD
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@SAT_CLAVE,

@SAT_ESTADO,

@SAT_MUNICIPIO,

@SAT_LOCALIDAD
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCSAT_CODIGOPOSTAL;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSAT_CODIGOPOSTALD(CSAT_CODIGOPOSTALBE oCSAT_CODIGOPOSTAL, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_CODIGOPOSTAL.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from SAT_CODIGOPOSTAL
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


        public bool CambiarSAT_CODIGOPOSTALD(CSAT_CODIGOPOSTALBE oCSAT_CODIGOPOSTALNuevo, CSAT_CODIGOPOSTALBE oCSAT_CODIGOPOSTALAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_CODIGOPOSTALNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_CODIGOPOSTALNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_CODIGOPOSTALNuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_CODIGOPOSTALNuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_CODIGOPOSTALNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_CODIGOPOSTALNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_CLAVE", FbDbType.VarChar);
                if (!(bool)oCSAT_CODIGOPOSTALNuevo.isnull["ISAT_CLAVE"])
                {
                    auxPar.Value = oCSAT_CODIGOPOSTALNuevo.ISAT_CLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_ESTADO", FbDbType.VarChar);
                if (!(bool)oCSAT_CODIGOPOSTALNuevo.isnull["ISAT_ESTADO"])
                {
                    auxPar.Value = oCSAT_CODIGOPOSTALNuevo.ISAT_ESTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_MUNICIPIO", FbDbType.VarChar);
                if (!(bool)oCSAT_CODIGOPOSTALNuevo.isnull["ISAT_MUNICIPIO"])
                {
                    auxPar.Value = oCSAT_CODIGOPOSTALNuevo.ISAT_MUNICIPIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_LOCALIDAD", FbDbType.VarChar);
                if (!(bool)oCSAT_CODIGOPOSTALNuevo.isnull["ISAT_LOCALIDAD"])
                {
                    auxPar.Value = oCSAT_CODIGOPOSTALNuevo.ISAT_LOCALIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCSAT_CODIGOPOSTALAnterior.isnull["IID"])
                {
                    auxPar.Value = oCSAT_CODIGOPOSTALAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  SAT_CODIGOPOSTAL
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

SAT_CLAVE=@SAT_CLAVE,

SAT_ESTADO=@SAT_ESTADO,

SAT_MUNICIPIO=@SAT_MUNICIPIO,

SAT_LOCALIDAD=@SAT_LOCALIDAD
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


        public CSAT_CODIGOPOSTALBE seleccionarSAT_CODIGOPOSTAL(CSAT_CODIGOPOSTALBE oCSAT_CODIGOPOSTAL, FbTransaction st)
        {




            CSAT_CODIGOPOSTALBE retorno = new CSAT_CODIGOPOSTALBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_CODIGOPOSTAL where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_CODIGOPOSTAL.IID;
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

                    if (dr["SAT_CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CLAVE = (string)(dr["SAT_CLAVE"]);
                    }

                    if (dr["SAT_ESTADO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_ESTADO = (string)(dr["SAT_ESTADO"]);
                    }

                    if (dr["SAT_MUNICIPIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_MUNICIPIO = (string)(dr["SAT_MUNICIPIO"]);
                    }

                    if (dr["SAT_LOCALIDAD"] != System.DBNull.Value)
                    {
                        retorno.ISAT_LOCALIDAD = (string)(dr["SAT_LOCALIDAD"]);
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



        /**
         *  TODO: Agregar funcion para leer datos del reader y no repetir 
         */
        public CSAT_CODIGOPOSTALBE seleccionarSAT_CODIGOPOSTAL_X_CLAVE_X_ESTADO(CSAT_CODIGOPOSTALBE oCSAT_CODIGOPOSTAL, FbTransaction st)
        {




            CSAT_CODIGOPOSTALBE retorno = new CSAT_CODIGOPOSTALBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_CODIGOPOSTAL where SAT_CLAVE = @SAT_CLAVE AND SAT_ESTADO = @SAT_ESTADO ";


                auxPar = new FbParameter("@SAT_CLAVE", FbDbType.VarChar);
                auxPar.Value = oCSAT_CODIGOPOSTAL.ISAT_CLAVE;
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_ESTADO", FbDbType.VarChar);
                auxPar.Value = oCSAT_CODIGOPOSTAL.ISAT_ESTADO;
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

                    if (dr["SAT_CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CLAVE = (string)(dr["SAT_CLAVE"]);
                    }

                    if (dr["SAT_ESTADO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_ESTADO = (string)(dr["SAT_ESTADO"]);
                    }

                    if (dr["SAT_MUNICIPIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_MUNICIPIO = (string)(dr["SAT_MUNICIPIO"]);
                    }

                    if (dr["SAT_LOCALIDAD"] != System.DBNull.Value)
                    {
                        retorno.ISAT_LOCALIDAD = (string)(dr["SAT_LOCALIDAD"]);
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






        public DataSet enlistarSAT_CODIGOPOSTAL()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_SAT_CODIGOPOSTAL_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoSAT_CODIGOPOSTAL()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_SAT_CODIGOPOSTAL_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExisteSAT_CODIGOPOSTAL(CSAT_CODIGOPOSTALBE oCSAT_CODIGOPOSTAL, FbTransaction st)
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
                auxPar.Value = oCSAT_CODIGOPOSTAL.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from SAT_CODIGOPOSTAL where

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



        public int ExisteSAT_CODIGOPOSTALXCLAVE(CSAT_CODIGOPOSTALBE oCSAT_CODIGOPOSTAL, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@SAT_CLAVE", FbDbType.VarChar);
                auxPar.Value = oCSAT_CODIGOPOSTAL.ISAT_CLAVE;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from SAT_CODIGOPOSTAL where

  SAT_CLAVE=@SAT_CLAVE  
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


        public CSAT_CODIGOPOSTALBE AgregarSAT_CODIGOPOSTAL(CSAT_CODIGOPOSTALBE oCSAT_CODIGOPOSTAL, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_CODIGOPOSTAL(oCSAT_CODIGOPOSTAL, st);
                if (iRes == 1)
                {
                    this.IComentario = "El SAT_CODIGOPOSTAL ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarSAT_CODIGOPOSTALD(oCSAT_CODIGOPOSTAL, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSAT_CODIGOPOSTAL(CSAT_CODIGOPOSTALBE oCSAT_CODIGOPOSTAL, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_CODIGOPOSTAL(oCSAT_CODIGOPOSTAL, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_CODIGOPOSTAL no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarSAT_CODIGOPOSTALD(oCSAT_CODIGOPOSTAL, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarSAT_CODIGOPOSTAL(CSAT_CODIGOPOSTALBE oCSAT_CODIGOPOSTALNuevo, CSAT_CODIGOPOSTALBE oCSAT_CODIGOPOSTALAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_CODIGOPOSTAL(oCSAT_CODIGOPOSTALAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_CODIGOPOSTAL no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarSAT_CODIGOPOSTALD(oCSAT_CODIGOPOSTALNuevo, oCSAT_CODIGOPOSTALAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }




        public CSAT_CODIGOPOSTALD(string conexion)
        {
            this.sCadenaConexion = conexion;
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }

        public CSAT_CODIGOPOSTALD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
