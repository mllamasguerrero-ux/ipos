

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




    public class CSAT_LOCALIDADD
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



        public CSAT_LOCALIDADBE AgregarSAT_LOCALIDADD(CSAT_LOCALIDADBE oCSAT_LOCALIDAD, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_LOCALIDAD.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_LOCALIDAD.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_LOCALIDAD.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_LOCALIDAD.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_LOCALIDAD.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_LOCALIDAD.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE_LOCALIDAD", FbDbType.VarChar);
                if (!(bool)oCSAT_LOCALIDAD.isnull["ICLAVE_LOCALIDAD"])
                {
                    auxPar.Value = oCSAT_LOCALIDAD.ICLAVE_LOCALIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE_ESTADO", FbDbType.VarChar);
                if (!(bool)oCSAT_LOCALIDAD.isnull["ICLAVE_ESTADO"])
                {
                    auxPar.Value = oCSAT_LOCALIDAD.ICLAVE_ESTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCSAT_LOCALIDAD.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCSAT_LOCALIDAD.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO SAT_LOCALIDAD
      (

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

CLAVE_LOCALIDAD,

CLAVE_ESTADO,

DESCRIPCION
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@CLAVE_LOCALIDAD,

@CLAVE_ESTADO,

@DESCRIPCION
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCSAT_LOCALIDAD;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }



        public bool BorrarSAT_LOCALIDADD(CSAT_LOCALIDADBE oCSAT_LOCALIDAD, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_LOCALIDAD.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from SAT_LOCALIDAD
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



        public bool CambiarSAT_LOCALIDADD(CSAT_LOCALIDADBE oCSAT_LOCALIDADNuevo, CSAT_LOCALIDADBE oCSAT_LOCALIDADAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_LOCALIDADNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_LOCALIDADNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_LOCALIDADNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_LOCALIDADNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVE_LOCALIDAD", FbDbType.VarChar);
                if (!(bool)oCSAT_LOCALIDADNuevo.isnull["ICLAVE_LOCALIDAD"])
                {
                    auxPar.Value = oCSAT_LOCALIDADNuevo.ICLAVE_LOCALIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVE_ESTADO", FbDbType.VarChar);
                if (!(bool)oCSAT_LOCALIDADNuevo.isnull["ICLAVE_ESTADO"])
                {
                    auxPar.Value = oCSAT_LOCALIDADNuevo.ICLAVE_ESTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCSAT_LOCALIDADNuevo.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCSAT_LOCALIDADNuevo.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCSAT_LOCALIDADAnterior.isnull["IID"])
                {
                    auxPar.Value = oCSAT_LOCALIDADAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  SAT_LOCALIDAD
  set


ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

CLAVE_LOCALIDAD=@CLAVE_LOCALIDAD,

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



        public CSAT_LOCALIDADBE seleccionarSAT_LOCALIDAD(CSAT_LOCALIDADBE oCSAT_LOCALIDAD, FbTransaction st)
        {




            CSAT_LOCALIDADBE retorno = new CSAT_LOCALIDADBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_LOCALIDAD where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_LOCALIDAD.IID;
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

                    if (dr["CLAVE_LOCALIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE_LOCALIDAD = (string)(dr["CLAVE_LOCALIDAD"]);
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



        public CSAT_LOCALIDADBE seleccionarSAT_LOCALIDAD_X_CLAVE(CSAT_LOCALIDADBE oCSAT_LOCALIDAD, FbTransaction st)
        {




            CSAT_LOCALIDADBE retorno = new CSAT_LOCALIDADBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_LOCALIDAD where
 CLAVE_ESTADO=@CLAVE_ESTADO AND CLAVE_LOCALIDAD=@CLAVE_LOCALIDAD  ";


                auxPar = new FbParameter("@CLAVE_ESTADO", FbDbType.VarChar);
                auxPar.Value = oCSAT_LOCALIDAD.ICLAVE_ESTADO;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVE_LOCALIDAD", FbDbType.VarChar);
                auxPar.Value = oCSAT_LOCALIDAD.ICLAVE_LOCALIDAD;
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

                    if (dr["CLAVE_LOCALIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE_LOCALIDAD = (string)(dr["CLAVE_LOCALIDAD"]);
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








        public DataSet enlistarSAT_LOCALIDAD()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_SAT_LOCALIDAD_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }





        public DataSet enlistarCortoSAT_LOCALIDAD()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_SAT_LOCALIDAD_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public int ExisteSAT_LOCALIDAD(CSAT_LOCALIDADBE oCSAT_LOCALIDAD, FbTransaction st)
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
                auxPar.Value = oCSAT_LOCALIDAD.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from SAT_LOCALIDAD where

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




        public CSAT_LOCALIDADBE AgregarSAT_LOCALIDAD(CSAT_LOCALIDADBE oCSAT_LOCALIDAD, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_LOCALIDAD(oCSAT_LOCALIDAD, st);
                if (iRes == 1)
                {
                    this.IComentario = "El SAT_LOCALIDAD ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarSAT_LOCALIDADD(oCSAT_LOCALIDAD, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSAT_LOCALIDAD(CSAT_LOCALIDADBE oCSAT_LOCALIDAD, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_LOCALIDAD(oCSAT_LOCALIDAD, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_LOCALIDAD no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarSAT_LOCALIDADD(oCSAT_LOCALIDAD, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarSAT_LOCALIDAD(CSAT_LOCALIDADBE oCSAT_LOCALIDADNuevo, CSAT_LOCALIDADBE oCSAT_LOCALIDADAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_LOCALIDAD(oCSAT_LOCALIDADAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_LOCALIDAD no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarSAT_LOCALIDADD(oCSAT_LOCALIDADNuevo, oCSAT_LOCALIDADAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }



        public CSAT_LOCALIDADD(string cadenaConexion)
        {
            this.sCadenaConexion = cadenaConexion;
        }



        public CSAT_LOCALIDADD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
