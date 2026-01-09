

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



    public class CSAT_PAISD
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


        public CSAT_PAISBE AgregarSAT_PAISD(CSAT_PAISBE oCSAT_PAIS, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_PAIS.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_PAIS.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_PAIS.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_PAIS.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_PAIS.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_PAIS.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_CLAVE", FbDbType.VarChar);
                if (!(bool)oCSAT_PAIS.isnull["ISAT_CLAVE"])
                {
                    auxPar.Value = oCSAT_PAIS.ISAT_CLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCSAT_PAIS.isnull["ISAT_DESCRIPCION"])
                {
                    auxPar.Value = oCSAT_PAIS.ISAT_DESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_FORMATOCP", FbDbType.VarChar);
                if (!(bool)oCSAT_PAIS.isnull["ISAT_FORMATOCP"])
                {
                    auxPar.Value = oCSAT_PAIS.ISAT_FORMATOCP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_FORMATORIT", FbDbType.VarChar);
                if (!(bool)oCSAT_PAIS.isnull["ISAT_FORMATORIT"])
                {
                    auxPar.Value = oCSAT_PAIS.ISAT_FORMATORIT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_VALIDACIONRIT", FbDbType.VarChar);
                if (!(bool)oCSAT_PAIS.isnull["ISAT_VALIDACIONRIT"])
                {
                    auxPar.Value = oCSAT_PAIS.ISAT_VALIDACIONRIT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_AGRUPACIONES", FbDbType.VarChar);
                if (!(bool)oCSAT_PAIS.isnull["ISAT_AGRUPACIONES"])
                {
                    auxPar.Value = oCSAT_PAIS.ISAT_AGRUPACIONES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO SAT_PAIS
      (
    
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

SAT_CLAVE,

SAT_DESCRIPCION,

SAT_FORMATOCP,

SAT_FORMATORIT,

SAT_VALIDACIONRIT,

SAT_AGRUPACIONES
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@SAT_CLAVE,

@SAT_DESCRIPCION,

@SAT_FORMATOCP,

@SAT_FORMATORIT,

@SAT_VALIDACIONRIT,

@SAT_AGRUPACIONES
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCSAT_PAIS;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSAT_PAISD(CSAT_PAISBE oCSAT_PAIS, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_PAIS.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from SAT_PAIS
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


        public bool CambiarSAT_PAISD(CSAT_PAISBE oCSAT_PAISNuevo, CSAT_PAISBE oCSAT_PAISAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_PAISNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_PAISNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_PAISNuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_PAISNuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_PAISNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_PAISNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_CLAVE", FbDbType.VarChar);
                if (!(bool)oCSAT_PAISNuevo.isnull["ISAT_CLAVE"])
                {
                    auxPar.Value = oCSAT_PAISNuevo.ISAT_CLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCSAT_PAISNuevo.isnull["ISAT_DESCRIPCION"])
                {
                    auxPar.Value = oCSAT_PAISNuevo.ISAT_DESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_FORMATOCP", FbDbType.VarChar);
                if (!(bool)oCSAT_PAISNuevo.isnull["ISAT_FORMATOCP"])
                {
                    auxPar.Value = oCSAT_PAISNuevo.ISAT_FORMATOCP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_FORMATORIT", FbDbType.VarChar);
                if (!(bool)oCSAT_PAISNuevo.isnull["ISAT_FORMATORIT"])
                {
                    auxPar.Value = oCSAT_PAISNuevo.ISAT_FORMATORIT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_VALIDACIONRIT", FbDbType.VarChar);
                if (!(bool)oCSAT_PAISNuevo.isnull["ISAT_VALIDACIONRIT"])
                {
                    auxPar.Value = oCSAT_PAISNuevo.ISAT_VALIDACIONRIT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_AGRUPACIONES", FbDbType.VarChar);
                if (!(bool)oCSAT_PAISNuevo.isnull["ISAT_AGRUPACIONES"])
                {
                    auxPar.Value = oCSAT_PAISNuevo.ISAT_AGRUPACIONES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCSAT_PAISAnterior.isnull["IID"])
                {
                    auxPar.Value = oCSAT_PAISAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  SAT_PAIS
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

SAT_CLAVE=@SAT_CLAVE,

SAT_DESCRIPCION=@SAT_DESCRIPCION,

SAT_FORMATOCP=@SAT_FORMATOCP,

SAT_FORMATORIT=@SAT_FORMATORIT,

SAT_VALIDACIONRIT=@SAT_VALIDACIONRIT,

SAT_AGRUPACIONES=@SAT_AGRUPACIONES
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


        public CSAT_PAISBE seleccionarSAT_PAIS(CSAT_PAISBE oCSAT_PAIS, FbTransaction st)
        {




            CSAT_PAISBE retorno = new CSAT_PAISBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_PAIS where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_PAIS.IID;
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

                    if (dr["SAT_DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.ISAT_DESCRIPCION = (string)(dr["SAT_DESCRIPCION"]);
                    }

                    if (dr["SAT_FORMATOCP"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FORMATOCP = (string)(dr["SAT_FORMATOCP"]);
                    }

                    if (dr["SAT_FORMATORIT"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FORMATORIT = (string)(dr["SAT_FORMATORIT"]);
                    }

                    if (dr["SAT_VALIDACIONRIT"] != System.DBNull.Value)
                    {
                        retorno.ISAT_VALIDACIONRIT = (string)(dr["SAT_VALIDACIONRIT"]);
                    }

                    if (dr["SAT_AGRUPACIONES"] != System.DBNull.Value)
                    {
                        retorno.ISAT_AGRUPACIONES = (string)(dr["SAT_AGRUPACIONES"]);
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




        public CSAT_PAISBE seleccionarSAT_PAIS_X_CLAVE(CSAT_PAISBE oCSAT_PAIS, FbTransaction st)
        {




            CSAT_PAISBE retorno = new CSAT_PAISBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_PAIS where SAT_CLAVE = @SAT_CLAVE  ";


                auxPar = new FbParameter("@SAT_CLAVE", FbDbType.VarChar);
                auxPar.Value = oCSAT_PAIS.ISAT_CLAVE;
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

                    if (dr["SAT_DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.ISAT_DESCRIPCION = (string)(dr["SAT_DESCRIPCION"]);
                    }

                    if (dr["SAT_FORMATOCP"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FORMATOCP = (string)(dr["SAT_FORMATOCP"]);
                    }

                    if (dr["SAT_FORMATORIT"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FORMATORIT = (string)(dr["SAT_FORMATORIT"]);
                    }

                    if (dr["SAT_VALIDACIONRIT"] != System.DBNull.Value)
                    {
                        retorno.ISAT_VALIDACIONRIT = (string)(dr["SAT_VALIDACIONRIT"]);
                    }

                    if (dr["SAT_AGRUPACIONES"] != System.DBNull.Value)
                    {
                        retorno.ISAT_AGRUPACIONES = (string)(dr["SAT_AGRUPACIONES"]);
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






        public DataSet enlistarSAT_PAIS()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_SAT_PAIS_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoSAT_PAIS()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_SAT_PAIS_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExisteSAT_PAIS(CSAT_PAISBE oCSAT_PAIS, FbTransaction st)
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
                auxPar.Value = oCSAT_PAIS.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from SAT_PAIS where

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




        public CSAT_PAISBE AgregarSAT_PAIS(CSAT_PAISBE oCSAT_PAIS, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_PAIS(oCSAT_PAIS, st);
                if (iRes == 1)
                {
                    this.IComentario = "El SAT_PAIS ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarSAT_PAISD(oCSAT_PAIS, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSAT_PAIS(CSAT_PAISBE oCSAT_PAIS, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_PAIS(oCSAT_PAIS, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_PAIS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarSAT_PAISD(oCSAT_PAIS, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarSAT_PAIS(CSAT_PAISBE oCSAT_PAISNuevo, CSAT_PAISBE oCSAT_PAISAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_PAIS(oCSAT_PAISAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_PAIS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarSAT_PAISD(oCSAT_PAISNuevo, oCSAT_PAISAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public CSAT_PAISD(string cadenaConexion)
        {
            this.sCadenaConexion = cadenaConexion;
        }


        public CSAT_PAISD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
