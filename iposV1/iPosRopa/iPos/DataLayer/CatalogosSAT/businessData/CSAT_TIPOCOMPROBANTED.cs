

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



    public class CSAT_TIPOCOMPROBANTED
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


        public CSAT_TIPOCOMPROBANTEBE AgregarSAT_TIPOCOMPROBANTED(CSAT_TIPOCOMPROBANTEBE oCSAT_TIPOCOMPROBANTE, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_TIPOCOMPROBANTE.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_TIPOCOMPROBANTE.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_TIPOCOMPROBANTE.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_TIPOCOMPROBANTE.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_TIPOCOMPROBANTE.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_TIPOCOMPROBANTE.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_CLAVE", FbDbType.VarChar);
                if (!(bool)oCSAT_TIPOCOMPROBANTE.isnull["ISAT_CLAVE"])
                {
                    auxPar.Value = oCSAT_TIPOCOMPROBANTE.ISAT_CLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCSAT_TIPOCOMPROBANTE.isnull["ISAT_DESCRIPCION"])
                {
                    auxPar.Value = oCSAT_TIPOCOMPROBANTE.ISAT_DESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_VALORMAXIMO", FbDbType.Integer);
                if (!(bool)oCSAT_TIPOCOMPROBANTE.isnull["ISAT_VALORMAXIMO"])
                {
                    auxPar.Value = oCSAT_TIPOCOMPROBANTE.ISAT_VALORMAXIMO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_FECHAINICIO", FbDbType.Date);
                if (!(bool)oCSAT_TIPOCOMPROBANTE.isnull["ISAT_FECHAINICIO"])
                {
                    auxPar.Value = oCSAT_TIPOCOMPROBANTE.ISAT_FECHAINICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_FECHAFIN", FbDbType.Date);
                if (!(bool)oCSAT_TIPOCOMPROBANTE.isnull["ISAT_FECHAFIN"])
                {
                    auxPar.Value = oCSAT_TIPOCOMPROBANTE.ISAT_FECHAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_NS", FbDbType.VarChar);
                if (!(bool)oCSAT_TIPOCOMPROBANTE.isnull["ISAT_NS"])
                {
                    auxPar.Value = oCSAT_TIPOCOMPROBANTE.ISAT_NS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_NDS", FbDbType.VarChar);
                if (!(bool)oCSAT_TIPOCOMPROBANTE.isnull["ISAT_NDS"])
                {
                    auxPar.Value = oCSAT_TIPOCOMPROBANTE.ISAT_NDS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO SAT_TIPOCOMPROBANTE
      (
    
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

SAT_CLAVE,

SAT_DESCRIPCION,

SAT_VALORMAXIMO,

SAT_FECHAINICIO,

SAT_FECHAFIN,

SAT_NS,

SAT_NDS
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@SAT_CLAVE,

@SAT_DESCRIPCION,

@SAT_VALORMAXIMO,

@SAT_FECHAINICIO,

@SAT_FECHAFIN,

@SAT_NS,

@SAT_NDS
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCSAT_TIPOCOMPROBANTE;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSAT_TIPOCOMPROBANTED(CSAT_TIPOCOMPROBANTEBE oCSAT_TIPOCOMPROBANTE, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_TIPOCOMPROBANTE.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from SAT_TIPOCOMPROBANTE
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


        public bool CambiarSAT_TIPOCOMPROBANTED(CSAT_TIPOCOMPROBANTEBE oCSAT_TIPOCOMPROBANTENuevo, CSAT_TIPOCOMPROBANTEBE oCSAT_TIPOCOMPROBANTEAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_TIPOCOMPROBANTENuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_TIPOCOMPROBANTENuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_TIPOCOMPROBANTENuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_TIPOCOMPROBANTENuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_TIPOCOMPROBANTENuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_TIPOCOMPROBANTENuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_CLAVE", FbDbType.VarChar);
                if (!(bool)oCSAT_TIPOCOMPROBANTENuevo.isnull["ISAT_CLAVE"])
                {
                    auxPar.Value = oCSAT_TIPOCOMPROBANTENuevo.ISAT_CLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCSAT_TIPOCOMPROBANTENuevo.isnull["ISAT_DESCRIPCION"])
                {
                    auxPar.Value = oCSAT_TIPOCOMPROBANTENuevo.ISAT_DESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_VALORMAXIMO", FbDbType.Integer);
                if (!(bool)oCSAT_TIPOCOMPROBANTENuevo.isnull["ISAT_VALORMAXIMO"])
                {
                    auxPar.Value = oCSAT_TIPOCOMPROBANTENuevo.ISAT_VALORMAXIMO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_FECHAINICIO", FbDbType.Date);
                if (!(bool)oCSAT_TIPOCOMPROBANTENuevo.isnull["ISAT_FECHAINICIO"])
                {
                    auxPar.Value = oCSAT_TIPOCOMPROBANTENuevo.ISAT_FECHAINICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_FECHAFIN", FbDbType.Date);
                if (!(bool)oCSAT_TIPOCOMPROBANTENuevo.isnull["ISAT_FECHAFIN"])
                {
                    auxPar.Value = oCSAT_TIPOCOMPROBANTENuevo.ISAT_FECHAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_NS", FbDbType.VarChar);
                if (!(bool)oCSAT_TIPOCOMPROBANTENuevo.isnull["ISAT_NS"])
                {
                    auxPar.Value = oCSAT_TIPOCOMPROBANTENuevo.ISAT_NS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_NDS", FbDbType.VarChar);
                if (!(bool)oCSAT_TIPOCOMPROBANTENuevo.isnull["ISAT_NDS"])
                {
                    auxPar.Value = oCSAT_TIPOCOMPROBANTENuevo.ISAT_NDS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCSAT_TIPOCOMPROBANTEAnterior.isnull["IID"])
                {
                    auxPar.Value = oCSAT_TIPOCOMPROBANTEAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  SAT_TIPOCOMPROBANTE
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

SAT_CLAVE=@SAT_CLAVE,

SAT_DESCRIPCION=@SAT_DESCRIPCION,

SAT_VALORMAXIMO=@SAT_VALORMAXIMO,

SAT_FECHAINICIO=@SAT_FECHAINICIO,

SAT_FECHAFIN=@SAT_FECHAFIN,

SAT_NS=@SAT_NS,

SAT_NDS=@SAT_NDS
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


        public CSAT_TIPOCOMPROBANTEBE seleccionarSAT_TIPOCOMPROBANTE(CSAT_TIPOCOMPROBANTEBE oCSAT_TIPOCOMPROBANTE, FbTransaction st)
        {




            CSAT_TIPOCOMPROBANTEBE retorno = new CSAT_TIPOCOMPROBANTEBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_TIPOCOMPROBANTE where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_TIPOCOMPROBANTE.IID;
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

                    if (dr["SAT_FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAINICIO = (DateTime)(dr["SAT_FECHAINICIO"]);
                    }

                    if (dr["SAT_FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAFIN = (DateTime)(dr["SAT_FECHAFIN"]);
                    }

                    if (dr["SAT_NS"] != System.DBNull.Value)
                    {
                        retorno.ISAT_NS = (string)(dr["SAT_NS"]);
                    }

                    if (dr["SAT_NDS"] != System.DBNull.Value)
                    {
                        retorno.ISAT_NDS = (string)(dr["SAT_NDS"]);
                    }

                    if (dr["SAT_VALORMAXIMO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_VALORMAXIMO = int.Parse(dr["SAT_VALORMAXIMO"].ToString());
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




        public CSAT_TIPOCOMPROBANTEBE seleccionarSAT_TIPOCOMPROBANTE_X_CLAVE(CSAT_TIPOCOMPROBANTEBE oCSAT_TIPOCOMPROBANTE, FbTransaction st)
        {
            CSAT_TIPOCOMPROBANTEBE retorno = new CSAT_TIPOCOMPROBANTEBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_TIPOCOMPROBANTE where SAT_CLAVE=@SAT_CLAVE  ";


                auxPar = new FbParameter("@SAT_CLAVE", FbDbType.VarChar);
                auxPar.Value = oCSAT_TIPOCOMPROBANTE.ISAT_CLAVE;
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

                    if (dr["SAT_FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAINICIO = (DateTime)(dr["SAT_FECHAINICIO"]);
                    }

                    if (dr["SAT_FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAFIN = (DateTime)(dr["SAT_FECHAFIN"]);
                    }

                    if (dr["SAT_NS"] != System.DBNull.Value)
                    {
                        retorno.ISAT_NS = (string)(dr["SAT_NS"]);
                    }

                    if (dr["SAT_NDS"] != System.DBNull.Value)
                    {
                        retorno.ISAT_NDS = (string)(dr["SAT_NDS"]);
                    }

                    if (dr["SAT_VALORMAXIMO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_VALORMAXIMO = int.Parse(dr["SAT_VALORMAXIMO"].ToString());
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




        public DataSet enlistarSAT_TIPOCOMPROBANTE()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_SAT_TIPOCOMPROBANTE_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoSAT_TIPOCOMPROBANTE()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_SAT_TIPOCOMPROBANTE_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExisteSAT_TIPOCOMPROBANTE(CSAT_TIPOCOMPROBANTEBE oCSAT_TIPOCOMPROBANTE, FbTransaction st)
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
                auxPar.Value = oCSAT_TIPOCOMPROBANTE.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from SAT_TIPOCOMPROBANTE where

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




        public CSAT_TIPOCOMPROBANTEBE AgregarSAT_TIPOCOMPROBANTE(CSAT_TIPOCOMPROBANTEBE oCSAT_TIPOCOMPROBANTE, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_TIPOCOMPROBANTE(oCSAT_TIPOCOMPROBANTE, st);
                if (iRes == 1)
                {
                    this.IComentario = "El SAT_TIPOCOMPROBANTE ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarSAT_TIPOCOMPROBANTED(oCSAT_TIPOCOMPROBANTE, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSAT_TIPOCOMPROBANTE(CSAT_TIPOCOMPROBANTEBE oCSAT_TIPOCOMPROBANTE, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_TIPOCOMPROBANTE(oCSAT_TIPOCOMPROBANTE, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_TIPOCOMPROBANTE no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarSAT_TIPOCOMPROBANTED(oCSAT_TIPOCOMPROBANTE, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarSAT_TIPOCOMPROBANTE(CSAT_TIPOCOMPROBANTEBE oCSAT_TIPOCOMPROBANTENuevo, CSAT_TIPOCOMPROBANTEBE oCSAT_TIPOCOMPROBANTEAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_TIPOCOMPROBANTE(oCSAT_TIPOCOMPROBANTEAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_TIPOCOMPROBANTE no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarSAT_TIPOCOMPROBANTED(oCSAT_TIPOCOMPROBANTENuevo, oCSAT_TIPOCOMPROBANTEAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }



        public CSAT_TIPOCOMPROBANTED(string cadenaConexion)
        {
            this.sCadenaConexion = cadenaConexion;
        }

        public CSAT_TIPOCOMPROBANTED()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
