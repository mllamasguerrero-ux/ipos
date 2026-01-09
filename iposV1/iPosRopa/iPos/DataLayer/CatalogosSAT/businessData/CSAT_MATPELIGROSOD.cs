

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
    


    public class CSAT_MATPELIGROSOD
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

        
        public CSAT_MATPELIGROSOBE AgregarSAT_MATPELIGROSOD(CSAT_MATPELIGROSOBE oCSAT_MATPELIGROSO, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_MATPELIGROSO.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_MATPELIGROSO.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_MATPELIGROSO.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_MATPELIGROSO.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_MATPELIGROSO.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_MATPELIGROSO.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCSAT_MATPELIGROSO.isnull["ICLAVE"])
                {
                    auxPar.Value = oCSAT_MATPELIGROSO.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCSAT_MATPELIGROSO.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCSAT_MATPELIGROSO.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLASE", FbDbType.VarChar);
                if (!(bool)oCSAT_MATPELIGROSO.isnull["ICLASE"])
                {
                    auxPar.Value = oCSAT_MATPELIGROSO.ICLASE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PELIGRO_SECUNDARIO", FbDbType.VarChar);
                if (!(bool)oCSAT_MATPELIGROSO.isnull["IPELIGRO_SECUNDARIO"])
                {
                    auxPar.Value = oCSAT_MATPELIGROSO.IPELIGRO_SECUNDARIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRE_TECNICO", FbDbType.VarChar);
                if (!(bool)oCSAT_MATPELIGROSO.isnull["INOMBRE_TECNICO"])
                {
                    auxPar.Value = oCSAT_MATPELIGROSO.INOMBRE_TECNICO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAINICIO", FbDbType.Date);
                if (!(bool)oCSAT_MATPELIGROSO.isnull["IFECHAINICIO"])
                {
                    auxPar.Value = oCSAT_MATPELIGROSO.IFECHAINICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAFIN", FbDbType.Date);
                if (!(bool)oCSAT_MATPELIGROSO.isnull["IFECHAFIN"])
                {
                    auxPar.Value = oCSAT_MATPELIGROSO.IFECHAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO SAT_MATPELIGROSO
      (

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

CLAVE,

DESCRIPCION,

CLASE,

PELIGRO_SECUNDARIO,

NOMBRE_TECNICO,

FECHAINICIO,

FECHAFIN
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@CLAVE,

@DESCRIPCION,

@CLASE,

@PELIGRO_SECUNDARIO,

@NOMBRE_TECNICO,

@FECHAINICIO,

@FECHAFIN
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCSAT_MATPELIGROSO;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarSAT_MATPELIGROSOD(CSAT_MATPELIGROSOBE oCSAT_MATPELIGROSO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_MATPELIGROSO.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from SAT_MATPELIGROSO
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


        [AutoComplete]
        public bool CambiarSAT_MATPELIGROSOD(CSAT_MATPELIGROSOBE oCSAT_MATPELIGROSONuevo, CSAT_MATPELIGROSOBE oCSAT_MATPELIGROSOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                
                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_MATPELIGROSONuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_MATPELIGROSONuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_MATPELIGROSONuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_MATPELIGROSONuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCSAT_MATPELIGROSONuevo.isnull["ICLAVE"])
                {
                    auxPar.Value = oCSAT_MATPELIGROSONuevo.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCSAT_MATPELIGROSONuevo.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCSAT_MATPELIGROSONuevo.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLASE", FbDbType.VarChar);
                if (!(bool)oCSAT_MATPELIGROSONuevo.isnull["ICLASE"])
                {
                    auxPar.Value = oCSAT_MATPELIGROSONuevo.ICLASE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PELIGRO_SECUNDARIO", FbDbType.VarChar);
                if (!(bool)oCSAT_MATPELIGROSONuevo.isnull["IPELIGRO_SECUNDARIO"])
                {
                    auxPar.Value = oCSAT_MATPELIGROSONuevo.IPELIGRO_SECUNDARIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRE_TECNICO", FbDbType.VarChar);
                if (!(bool)oCSAT_MATPELIGROSONuevo.isnull["INOMBRE_TECNICO"])
                {
                    auxPar.Value = oCSAT_MATPELIGROSONuevo.INOMBRE_TECNICO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAINICIO", FbDbType.Date);
                if (!(bool)oCSAT_MATPELIGROSONuevo.isnull["IFECHAINICIO"])
                {
                    auxPar.Value = oCSAT_MATPELIGROSONuevo.IFECHAINICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAFIN", FbDbType.Date);
                if (!(bool)oCSAT_MATPELIGROSONuevo.isnull["IFECHAFIN"])
                {
                    auxPar.Value = oCSAT_MATPELIGROSONuevo.IFECHAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCSAT_MATPELIGROSOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCSAT_MATPELIGROSOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  SAT_MATPELIGROSO
  set

ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

CLAVE=@CLAVE,

DESCRIPCION=@DESCRIPCION,

CLASE=@CLASE,

PELIGRO_SECUNDARIO=@PELIGRO_SECUNDARIO,

NOMBRE_TECNICO=@NOMBRE_TECNICO,

FECHAINICIO=@FECHAINICIO,

FECHAFIN=@FECHAFIN
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

        
        public CSAT_MATPELIGROSOBE seleccionarSAT_MATPELIGROSO(CSAT_MATPELIGROSOBE oCSAT_MATPELIGROSO, FbTransaction st)
        {




            CSAT_MATPELIGROSOBE retorno = new CSAT_MATPELIGROSOBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_MATPELIGROSO where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_MATPELIGROSO.IID;
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

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
                    }

                    if (dr["CLASE"] != System.DBNull.Value)
                    {
                        retorno.ICLASE = (string)(dr["CLASE"]);
                    }

                    if (dr["PELIGRO_SECUNDARIO"] != System.DBNull.Value)
                    {
                        retorno.IPELIGRO_SECUNDARIO = (string)(dr["PELIGRO_SECUNDARIO"]);
                    }

                    if (dr["NOMBRE_TECNICO"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE_TECNICO = (string)(dr["NOMBRE_TECNICO"]);
                    }

                    if (dr["FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.IFECHAINICIO = (DateTime)(dr["FECHAINICIO"]);
                    }

                    if (dr["FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.IFECHAFIN = (DateTime)(dr["FECHAFIN"]);
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






        public CSAT_MATPELIGROSOBE seleccionarSAT_MATPELIGROSO_X_CLAVE(CSAT_MATPELIGROSOBE oCSAT_MATPELIGROSO, FbTransaction st)
        {




            CSAT_MATPELIGROSOBE retorno = new CSAT_MATPELIGROSOBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_MATPELIGROSO where CLAVE = @CLAVE  ";


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                auxPar.Value = oCSAT_MATPELIGROSO.ICLAVE;
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

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
                    }

                    if (dr["CLASE"] != System.DBNull.Value)
                    {
                        retorno.ICLASE = (string)(dr["CLASE"]);
                    }

                    if (dr["PELIGRO_SECUNDARIO"] != System.DBNull.Value)
                    {
                        retorno.IPELIGRO_SECUNDARIO = (string)(dr["PELIGRO_SECUNDARIO"]);
                    }

                    if (dr["NOMBRE_TECNICO"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE_TECNICO = (string)(dr["NOMBRE_TECNICO"]);
                    }

                    if (dr["FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.IFECHAINICIO = (DateTime)(dr["FECHAINICIO"]);
                    }

                    if (dr["FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.IFECHAFIN = (DateTime)(dr["FECHAFIN"]);
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
        public DataSet enlistarSAT_MATPELIGROSO()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_SAT_MATPELIGROSO_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoSAT_MATPELIGROSO()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_SAT_MATPELIGROSO_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteSAT_MATPELIGROSO(CSAT_MATPELIGROSOBE oCSAT_MATPELIGROSO, FbTransaction st)
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
                auxPar.Value = oCSAT_MATPELIGROSO.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from SAT_MATPELIGROSO where

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




        public CSAT_MATPELIGROSOBE AgregarSAT_MATPELIGROSO(CSAT_MATPELIGROSOBE oCSAT_MATPELIGROSO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_MATPELIGROSO(oCSAT_MATPELIGROSO, st);
                if (iRes == 1)
                {
                    this.IComentario = "El SAT_MATPELIGROSO ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarSAT_MATPELIGROSOD(oCSAT_MATPELIGROSO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSAT_MATPELIGROSO(CSAT_MATPELIGROSOBE oCSAT_MATPELIGROSO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_MATPELIGROSO(oCSAT_MATPELIGROSO, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_MATPELIGROSO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarSAT_MATPELIGROSOD(oCSAT_MATPELIGROSO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarSAT_MATPELIGROSO(CSAT_MATPELIGROSOBE oCSAT_MATPELIGROSONuevo, CSAT_MATPELIGROSOBE oCSAT_MATPELIGROSOAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_MATPELIGROSO(oCSAT_MATPELIGROSOAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_MATPELIGROSO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarSAT_MATPELIGROSOD(oCSAT_MATPELIGROSONuevo, oCSAT_MATPELIGROSOAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }




        public CSAT_MATPELIGROSOD(string cadenaConexion)
        {
            this.sCadenaConexion = cadenaConexion;
        }

        public CSAT_MATPELIGROSOD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
