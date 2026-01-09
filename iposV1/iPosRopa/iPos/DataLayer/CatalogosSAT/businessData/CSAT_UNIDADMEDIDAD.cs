

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



    public class CSAT_UNIDADMEDIDAD
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


        public CSAT_UNIDADMEDIDABE AgregarSAT_UNIDADMEDIDAD(CSAT_UNIDADMEDIDABE oCSAT_UNIDADMEDIDA, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_UNIDADMEDIDA.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_UNIDADMEDIDA.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_UNIDADMEDIDA.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_UNIDADMEDIDA.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_UNIDADMEDIDA.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_UNIDADMEDIDA.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_CLAVE", FbDbType.VarChar);
                if (!(bool)oCSAT_UNIDADMEDIDA.isnull["ISAT_CLAVE"])
                {
                    auxPar.Value = oCSAT_UNIDADMEDIDA.ISAT_CLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_NOMBRE", FbDbType.VarChar);
                if (!(bool)oCSAT_UNIDADMEDIDA.isnull["ISAT_NOMBRE"])
                {
                    auxPar.Value = oCSAT_UNIDADMEDIDA.ISAT_NOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCSAT_UNIDADMEDIDA.isnull["ISAT_DESCRIPCION"])
                {
                    auxPar.Value = oCSAT_UNIDADMEDIDA.ISAT_DESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_FECHAINICIO", FbDbType.Date);
                if (!(bool)oCSAT_UNIDADMEDIDA.isnull["ISAT_FECHAINICIO"])
                {
                    auxPar.Value = oCSAT_UNIDADMEDIDA.ISAT_FECHAINICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_FECHAFIN", FbDbType.Date);
                if (!(bool)oCSAT_UNIDADMEDIDA.isnull["ISAT_FECHAFIN"])
                {
                    auxPar.Value = oCSAT_UNIDADMEDIDA.ISAT_FECHAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_SIMBOLO", FbDbType.VarChar);
                if (!(bool)oCSAT_UNIDADMEDIDA.isnull["ISAT_SIMBOLO"])
                {
                    auxPar.Value = oCSAT_UNIDADMEDIDA.ISAT_SIMBOLO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO SAT_UNIDADMEDIDA
      (
    
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

SAT_CLAVE,

SAT_NOMBRE,

SAT_DESCRIPCION,

SAT_FECHAINICIO,

SAT_FECHAFIN,

SAT_SIMBOLO
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@SAT_CLAVE,

@SAT_NOMBRE,

@SAT_DESCRIPCION,

@SAT_FECHAINICIO,

@SAT_FECHAFIN,

@SAT_SIMBOLO
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCSAT_UNIDADMEDIDA;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSAT_UNIDADMEDIDAD(CSAT_UNIDADMEDIDABE oCSAT_UNIDADMEDIDA, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_UNIDADMEDIDA.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from SAT_UNIDADMEDIDA
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


        public bool CambiarSAT_UNIDADMEDIDAD(CSAT_UNIDADMEDIDABE oCSAT_UNIDADMEDIDANuevo, CSAT_UNIDADMEDIDABE oCSAT_UNIDADMEDIDAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_UNIDADMEDIDANuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_UNIDADMEDIDANuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_UNIDADMEDIDANuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_UNIDADMEDIDANuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_UNIDADMEDIDANuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_UNIDADMEDIDANuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_CLAVE", FbDbType.VarChar);
                if (!(bool)oCSAT_UNIDADMEDIDANuevo.isnull["ISAT_CLAVE"])
                {
                    auxPar.Value = oCSAT_UNIDADMEDIDANuevo.ISAT_CLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_NOMBRE", FbDbType.VarChar);
                if (!(bool)oCSAT_UNIDADMEDIDANuevo.isnull["ISAT_NOMBRE"])
                {
                    auxPar.Value = oCSAT_UNIDADMEDIDANuevo.ISAT_NOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCSAT_UNIDADMEDIDANuevo.isnull["ISAT_DESCRIPCION"])
                {
                    auxPar.Value = oCSAT_UNIDADMEDIDANuevo.ISAT_DESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_FECHAINICIO", FbDbType.Date);
                if (!(bool)oCSAT_UNIDADMEDIDANuevo.isnull["ISAT_FECHAINICIO"])
                {
                    auxPar.Value = oCSAT_UNIDADMEDIDANuevo.ISAT_FECHAINICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_FECHAFIN", FbDbType.Date);
                if (!(bool)oCSAT_UNIDADMEDIDANuevo.isnull["ISAT_FECHAFIN"])
                {
                    auxPar.Value = oCSAT_UNIDADMEDIDANuevo.ISAT_FECHAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_SIMBOLO", FbDbType.VarChar);
                if (!(bool)oCSAT_UNIDADMEDIDANuevo.isnull["ISAT_SIMBOLO"])
                {
                    auxPar.Value = oCSAT_UNIDADMEDIDANuevo.ISAT_SIMBOLO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCSAT_UNIDADMEDIDAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCSAT_UNIDADMEDIDAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  SAT_UNIDADMEDIDA
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

SAT_CLAVE=@SAT_CLAVE,

SAT_NOMBRE=@SAT_NOMBRE,

SAT_DESCRIPCION=@SAT_DESCRIPCION,

SAT_FECHAINICIO=@SAT_FECHAINICIO,

SAT_FECHAFIN=@SAT_FECHAFIN,

SAT_SIMBOLO=@SAT_SIMBOLO
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


        public CSAT_UNIDADMEDIDABE seleccionarSAT_UNIDADMEDIDA_X_SAT_CLAVE(CSAT_UNIDADMEDIDABE oCSAT_UNIDADMEDIDA, FbTransaction st)
        {

            CSAT_UNIDADMEDIDABE retorno = new CSAT_UNIDADMEDIDABE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_UNIDADMEDIDA where SAT_CLAVE=@SAT_CLAVE";


                auxPar = new FbParameter("@SAT_CLAVE", FbDbType.VarChar);
                auxPar.Value = oCSAT_UNIDADMEDIDA.ISAT_CLAVE;
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

                    if (dr["SAT_NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_NOMBRE = (string)(dr["SAT_NOMBRE"]);
                    }

                    if (dr["SAT_DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.ISAT_DESCRIPCION = (string)(dr["SAT_DESCRIPCION"]);
                    }

                    if (dr["SAT_FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAINICIO = (DateTime)(dr["SAT_FECHAINICIO"]);
                    }

                    if (dr["SAT_FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAFIN = (DateTime)(dr["SAT_FECHAFIN"]);
                    }

                    if (dr["SAT_SIMBOLO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_SIMBOLO = (string)(dr["SAT_SIMBOLO"]);
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



        public CSAT_UNIDADMEDIDABE seleccionarSAT_UNIDADMEDIDA(CSAT_UNIDADMEDIDABE oCSAT_UNIDADMEDIDA, FbTransaction st)
        {

            CSAT_UNIDADMEDIDABE retorno = new CSAT_UNIDADMEDIDABE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_UNIDADMEDIDA where ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_UNIDADMEDIDA.IID;
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

                    if (dr["SAT_NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_NOMBRE = (string)(dr["SAT_NOMBRE"]);
                    }

                    if (dr["SAT_DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.ISAT_DESCRIPCION = (string)(dr["SAT_DESCRIPCION"]);
                    }

                    if (dr["SAT_FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAINICIO = (DateTime)(dr["SAT_FECHAINICIO"]);
                    }

                    if (dr["SAT_FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAFIN = (DateTime)(dr["SAT_FECHAFIN"]);
                    }

                    if (dr["SAT_SIMBOLO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_SIMBOLO = (string)(dr["SAT_SIMBOLO"]);
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






        public DataSet enlistarSAT_UNIDADMEDIDA()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_SAT_UNIDADMEDIDA_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoSAT_UNIDADMEDIDA()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_SAT_UNIDADMEDIDA_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExisteSAT_UNIDADMEDIDA(CSAT_UNIDADMEDIDABE oCSAT_UNIDADMEDIDA, FbTransaction st)
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
                auxPar.Value = oCSAT_UNIDADMEDIDA.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from SAT_UNIDADMEDIDA where

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




        public CSAT_UNIDADMEDIDABE AgregarSAT_UNIDADMEDIDA(CSAT_UNIDADMEDIDABE oCSAT_UNIDADMEDIDA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_UNIDADMEDIDA(oCSAT_UNIDADMEDIDA, st);
                if (iRes == 1)
                {
                    this.IComentario = "El SAT_UNIDADMEDIDA ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarSAT_UNIDADMEDIDAD(oCSAT_UNIDADMEDIDA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSAT_UNIDADMEDIDA(CSAT_UNIDADMEDIDABE oCSAT_UNIDADMEDIDA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_UNIDADMEDIDA(oCSAT_UNIDADMEDIDA, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_UNIDADMEDIDA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarSAT_UNIDADMEDIDAD(oCSAT_UNIDADMEDIDA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarSAT_UNIDADMEDIDA(CSAT_UNIDADMEDIDABE oCSAT_UNIDADMEDIDANuevo, CSAT_UNIDADMEDIDABE oCSAT_UNIDADMEDIDAAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_UNIDADMEDIDA(oCSAT_UNIDADMEDIDAAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_UNIDADMEDIDA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarSAT_UNIDADMEDIDAD(oCSAT_UNIDADMEDIDANuevo, oCSAT_UNIDADMEDIDAAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public CSAT_UNIDADMEDIDAD(string cadenaConexion)
        {
            this.sCadenaConexion = cadenaConexion;
        }


        public CSAT_UNIDADMEDIDAD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
