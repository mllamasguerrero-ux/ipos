

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



    public class CSAT_REGIMENFISCALD
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


        public CSAT_REGIMENFISCALBE AgregarSAT_REGIMENFISCALD(CSAT_REGIMENFISCALBE oCSAT_REGIMENFISCAL, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_REGIMENFISCAL.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_REGIMENFISCAL.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_REGIMENFISCAL.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_REGIMENFISCAL.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_REGIMENFISCAL.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_REGIMENFISCAL.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_CLAVE", FbDbType.VarChar);
                if (!(bool)oCSAT_REGIMENFISCAL.isnull["ISAT_CLAVE"])
                {
                    auxPar.Value = oCSAT_REGIMENFISCAL.ISAT_CLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCSAT_REGIMENFISCAL.isnull["ISAT_DESCRIPCION"])
                {
                    auxPar.Value = oCSAT_REGIMENFISCAL.ISAT_DESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_PERSONAFISICA", FbDbType.VarChar);
                if (!(bool)oCSAT_REGIMENFISCAL.isnull["ISAT_PERSONAFISICA"])
                {
                    auxPar.Value = oCSAT_REGIMENFISCAL.ISAT_PERSONAFISICA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_PERSONAMORAL", FbDbType.VarChar);
                if (!(bool)oCSAT_REGIMENFISCAL.isnull["ISAT_PERSONAMORAL"])
                {
                    auxPar.Value = oCSAT_REGIMENFISCAL.ISAT_PERSONAMORAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_FECHAINICIO", FbDbType.Date);
                if (!(bool)oCSAT_REGIMENFISCAL.isnull["ISAT_FECHAINICIO"])
                {
                    auxPar.Value = oCSAT_REGIMENFISCAL.ISAT_FECHAINICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_FECHAFIN", FbDbType.Integer);
                if (!(bool)oCSAT_REGIMENFISCAL.isnull["ISAT_FECHAFIN"])
                {
                    auxPar.Value = oCSAT_REGIMENFISCAL.ISAT_FECHAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO SAT_REGIMENFISCAL
      (
    
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

SAT_CLAVE,

SAT_DESCRIPCION,

SAT_PERSONAFISICA,

SAT_PERSONAMORAL,

SAT_FECHAINICIO,

SAT_FECHAFIN
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@SAT_CLAVE,

@SAT_DESCRIPCION,

@SAT_PERSONAFISICA,

@SAT_PERSONAMORAL,

@SAT_FECHAINICIO,

@SAT_FECHAFIN
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCSAT_REGIMENFISCAL;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSAT_REGIMENFISCALD(CSAT_REGIMENFISCALBE oCSAT_REGIMENFISCAL, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_REGIMENFISCAL.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from SAT_REGIMENFISCAL
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


        public bool CambiarSAT_REGIMENFISCALD(CSAT_REGIMENFISCALBE oCSAT_REGIMENFISCALNuevo, CSAT_REGIMENFISCALBE oCSAT_REGIMENFISCALAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_REGIMENFISCALNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_REGIMENFISCALNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_REGIMENFISCALNuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_REGIMENFISCALNuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_REGIMENFISCALNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_REGIMENFISCALNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_CLAVE", FbDbType.VarChar);
                if (!(bool)oCSAT_REGIMENFISCALNuevo.isnull["ISAT_CLAVE"])
                {
                    auxPar.Value = oCSAT_REGIMENFISCALNuevo.ISAT_CLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCSAT_REGIMENFISCALNuevo.isnull["ISAT_DESCRIPCION"])
                {
                    auxPar.Value = oCSAT_REGIMENFISCALNuevo.ISAT_DESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_PERSONAFISICA", FbDbType.VarChar);
                if (!(bool)oCSAT_REGIMENFISCALNuevo.isnull["ISAT_PERSONAFISICA"])
                {
                    auxPar.Value = oCSAT_REGIMENFISCALNuevo.ISAT_PERSONAFISICA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_PERSONAMORAL", FbDbType.VarChar);
                if (!(bool)oCSAT_REGIMENFISCALNuevo.isnull["ISAT_PERSONAMORAL"])
                {
                    auxPar.Value = oCSAT_REGIMENFISCALNuevo.ISAT_PERSONAMORAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_FECHAINICIO", FbDbType.Date);
                if (!(bool)oCSAT_REGIMENFISCALNuevo.isnull["ISAT_FECHAINICIO"])
                {
                    auxPar.Value = oCSAT_REGIMENFISCALNuevo.ISAT_FECHAINICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_FECHAFIN", FbDbType.Integer);
                if (!(bool)oCSAT_REGIMENFISCALNuevo.isnull["ISAT_FECHAFIN"])
                {
                    auxPar.Value = oCSAT_REGIMENFISCALNuevo.ISAT_FECHAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCSAT_REGIMENFISCALAnterior.isnull["IID"])
                {
                    auxPar.Value = oCSAT_REGIMENFISCALAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  SAT_REGIMENFISCAL
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

SAT_CLAVE=@SAT_CLAVE,

SAT_DESCRIPCION=@SAT_DESCRIPCION,

SAT_PERSONAFISICA=@SAT_PERSONAFISICA,

SAT_PERSONAMORAL=@SAT_PERSONAMORAL,

SAT_FECHAINICIO=@SAT_FECHAINICIO,

SAT_FECHAFIN=@SAT_FECHAFIN
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


        public CSAT_REGIMENFISCALBE seleccionarSAT_REGIMENFISCAL(CSAT_REGIMENFISCALBE oCSAT_REGIMENFISCAL, FbTransaction st)
        {
            CSAT_REGIMENFISCALBE retorno = new CSAT_REGIMENFISCALBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_REGIMENFISCAL where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_REGIMENFISCAL.IID;
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

                    if (dr["SAT_PERSONAFISICA"] != System.DBNull.Value)
                    {
                        retorno.ISAT_PERSONAFISICA = (string)(dr["SAT_PERSONAFISICA"]);
                    }

                    if (dr["SAT_PERSONAMORAL"] != System.DBNull.Value)
                    {
                        retorno.ISAT_PERSONAMORAL = (string)(dr["SAT_PERSONAMORAL"]);
                    }

                    if (dr["SAT_FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAINICIO = (DateTime)(dr["SAT_FECHAINICIO"]);
                    }

                    if (dr["SAT_FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAFIN = (DateTime)dr["SAT_FECHAFIN"];
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




        public CSAT_REGIMENFISCALBE seleccionarSAT_REGIMENFISCAL_X_CLAVE(CSAT_REGIMENFISCALBE oCSAT_REGIMENFISCAL, FbTransaction st)
        {
            CSAT_REGIMENFISCALBE retorno = new CSAT_REGIMENFISCALBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_REGIMENFISCAL where SAT_CLAVE=@SAT_CLAVE  ";


                auxPar = new FbParameter("@SAT_CLAVE", FbDbType.VarChar);
                auxPar.Value = oCSAT_REGIMENFISCAL.ISAT_CLAVE;
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

                    if (dr["SAT_PERSONAFISICA"] != System.DBNull.Value)
                    {
                        retorno.ISAT_PERSONAFISICA = (string)(dr["SAT_PERSONAFISICA"]);
                    }

                    if (dr["SAT_PERSONAMORAL"] != System.DBNull.Value)
                    {
                        retorno.ISAT_PERSONAMORAL = (string)(dr["SAT_PERSONAMORAL"]);
                    }

                    if (dr["SAT_FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAINICIO = (DateTime)(dr["SAT_FECHAINICIO"]);
                    }

                    if (dr["SAT_FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAFIN = (DateTime)(dr["SAT_FECHAFIN"]);
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




        public DataSet enlistarSAT_REGIMENFISCAL()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_SAT_REGIMENFISCAL_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoSAT_REGIMENFISCAL()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_SAT_REGIMENFISCAL_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExisteSAT_REGIMENFISCAL(CSAT_REGIMENFISCALBE oCSAT_REGIMENFISCAL, FbTransaction st)
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
                auxPar.Value = oCSAT_REGIMENFISCAL.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from SAT_REGIMENFISCAL where

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




        public CSAT_REGIMENFISCALBE AgregarSAT_REGIMENFISCAL(CSAT_REGIMENFISCALBE oCSAT_REGIMENFISCAL, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_REGIMENFISCAL(oCSAT_REGIMENFISCAL, st);
                if (iRes == 1)
                {
                    this.IComentario = "El SAT_REGIMENFISCAL ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarSAT_REGIMENFISCALD(oCSAT_REGIMENFISCAL, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSAT_REGIMENFISCAL(CSAT_REGIMENFISCALBE oCSAT_REGIMENFISCAL, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_REGIMENFISCAL(oCSAT_REGIMENFISCAL, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_REGIMENFISCAL no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarSAT_REGIMENFISCALD(oCSAT_REGIMENFISCAL, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarSAT_REGIMENFISCAL(CSAT_REGIMENFISCALBE oCSAT_REGIMENFISCALNuevo, CSAT_REGIMENFISCALBE oCSAT_REGIMENFISCALAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_REGIMENFISCAL(oCSAT_REGIMENFISCALAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_REGIMENFISCAL no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarSAT_REGIMENFISCALD(oCSAT_REGIMENFISCALNuevo, oCSAT_REGIMENFISCALAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public CSAT_REGIMENFISCALD(string cadenaConexion)
        {
            this.sCadenaConexion = cadenaConexion;
        }


        public CSAT_REGIMENFISCALD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
