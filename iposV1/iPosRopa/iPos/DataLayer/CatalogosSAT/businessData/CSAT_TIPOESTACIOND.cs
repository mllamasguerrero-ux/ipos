

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




    public class CSAT_TIPOESTACIOND
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



        public CSAT_TIPOESTACIONBE AgregarSAT_TIPOESTACIOND(CSAT_TIPOESTACIONBE oCSAT_TIPOESTACION, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_TIPOESTACION.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_TIPOESTACION.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_TIPOESTACION.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_TIPOESTACION.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_TIPOESTACION.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_TIPOESTACION.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCSAT_TIPOESTACION.isnull["ICLAVE"])
                {
                    auxPar.Value = oCSAT_TIPOESTACION.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCSAT_TIPOESTACION.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCSAT_TIPOESTACION.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVESTRANSPORTE", FbDbType.VarChar);
                if (!(bool)oCSAT_TIPOESTACION.isnull["ICLAVESTRANSPORTE"])
                {
                    auxPar.Value = oCSAT_TIPOESTACION.ICLAVESTRANSPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAINICIO", FbDbType.Date);
                if (!(bool)oCSAT_TIPOESTACION.isnull["IFECHAINICIO"])
                {
                    auxPar.Value = oCSAT_TIPOESTACION.IFECHAINICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAFIN", FbDbType.Date);
                if (!(bool)oCSAT_TIPOESTACION.isnull["IFECHAFIN"])
                {
                    auxPar.Value = oCSAT_TIPOESTACION.IFECHAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO SAT_TIPOESTACION
      (

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

CLAVE,

DESCRIPCION,

CLAVESTRANSPORTE,

FECHAINICIO,

FECHAFIN
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@CLAVE,

@DESCRIPCION,

@CLAVESTRANSPORTE,

@FECHAINICIO,

@FECHAFIN
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCSAT_TIPOESTACION;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }



        public bool BorrarSAT_TIPOESTACIOND(CSAT_TIPOESTACIONBE oCSAT_TIPOESTACION, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_TIPOESTACION.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from SAT_TIPOESTACION
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



        public bool CambiarSAT_TIPOESTACIOND(CSAT_TIPOESTACIONBE oCSAT_TIPOESTACIONNuevo, CSAT_TIPOESTACIONBE oCSAT_TIPOESTACIONAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_TIPOESTACIONNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_TIPOESTACIONNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_TIPOESTACIONNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_TIPOESTACIONNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCSAT_TIPOESTACIONNuevo.isnull["ICLAVE"])
                {
                    auxPar.Value = oCSAT_TIPOESTACIONNuevo.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCSAT_TIPOESTACIONNuevo.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCSAT_TIPOESTACIONNuevo.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVESTRANSPORTE", FbDbType.VarChar);
                if (!(bool)oCSAT_TIPOESTACIONNuevo.isnull["ICLAVESTRANSPORTE"])
                {
                    auxPar.Value = oCSAT_TIPOESTACIONNuevo.ICLAVESTRANSPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAINICIO", FbDbType.Date);
                if (!(bool)oCSAT_TIPOESTACIONNuevo.isnull["IFECHAINICIO"])
                {
                    auxPar.Value = oCSAT_TIPOESTACIONNuevo.IFECHAINICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAFIN", FbDbType.Date);
                if (!(bool)oCSAT_TIPOESTACIONNuevo.isnull["IFECHAFIN"])
                {
                    auxPar.Value = oCSAT_TIPOESTACIONNuevo.IFECHAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCSAT_TIPOESTACIONAnterior.isnull["IID"])
                {
                    auxPar.Value = oCSAT_TIPOESTACIONAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  SAT_TIPOESTACION
  set

ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

CLAVE=@CLAVE,

DESCRIPCION=@DESCRIPCION,

CLAVESTRANSPORTE=@CLAVESTRANSPORTE,

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



        public CSAT_TIPOESTACIONBE seleccionarSAT_TIPOESTACION(CSAT_TIPOESTACIONBE oCSAT_TIPOESTACION, FbTransaction st)
        {




            CSAT_TIPOESTACIONBE retorno = new CSAT_TIPOESTACIONBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_TIPOESTACION where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_TIPOESTACION.IID;
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

                    if (dr["CLAVESTRANSPORTE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVESTRANSPORTE = (string)(dr["CLAVESTRANSPORTE"]);
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





        public CSAT_TIPOESTACIONBE seleccionarSAT_TIPOESTACION_X_CLAVE(CSAT_TIPOESTACIONBE oCSAT_TIPOESTACION, FbTransaction st)
        {




            CSAT_TIPOESTACIONBE retorno = new CSAT_TIPOESTACIONBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_TIPOESTACION where
 CLAVE=@CLAVE  ";


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                auxPar.Value = oCSAT_TIPOESTACION.ICLAVE;
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

                    if (dr["CLAVESTRANSPORTE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVESTRANSPORTE = (string)(dr["CLAVESTRANSPORTE"]);
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






        public DataSet enlistarSAT_TIPOESTACION()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_SAT_TIPOESTACION_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }





        public DataSet enlistarCortoSAT_TIPOESTACION()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_SAT_TIPOESTACION_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public int ExisteSAT_TIPOESTACION(CSAT_TIPOESTACIONBE oCSAT_TIPOESTACION, FbTransaction st)
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
                auxPar.Value = oCSAT_TIPOESTACION.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from SAT_TIPOESTACION where

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




        public CSAT_TIPOESTACIONBE AgregarSAT_TIPOESTACION(CSAT_TIPOESTACIONBE oCSAT_TIPOESTACION, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_TIPOESTACION(oCSAT_TIPOESTACION, st);
                if (iRes == 1)
                {
                    this.IComentario = "El SAT_TIPOESTACION ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarSAT_TIPOESTACIOND(oCSAT_TIPOESTACION, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSAT_TIPOESTACION(CSAT_TIPOESTACIONBE oCSAT_TIPOESTACION, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_TIPOESTACION(oCSAT_TIPOESTACION, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_TIPOESTACION no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarSAT_TIPOESTACIOND(oCSAT_TIPOESTACION, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarSAT_TIPOESTACION(CSAT_TIPOESTACIONBE oCSAT_TIPOESTACIONNuevo, CSAT_TIPOESTACIONBE oCSAT_TIPOESTACIONAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_TIPOESTACION(oCSAT_TIPOESTACIONAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_TIPOESTACION no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarSAT_TIPOESTACIOND(oCSAT_TIPOESTACIONNuevo, oCSAT_TIPOESTACIONAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CSAT_TIPOESTACIOND(string cadenaConexion)
        {
            this.sCadenaConexion = cadenaConexion;
        }


        public CSAT_TIPOESTACIOND()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
