

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



    public class CSAT_PATENTEADUANALD
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


        public CSAT_PATENTEADUANALBE AgregarSAT_PATENTEADUANALD(CSAT_PATENTEADUANALBE oCSAT_PATENTEADUANAL, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_PATENTEADUANAL.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_PATENTEADUANAL.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_PATENTEADUANAL.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_PATENTEADUANAL.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_PATENTEADUANAL.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_PATENTEADUANAL.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_CLAVE", FbDbType.Integer);
                if (!(bool)oCSAT_PATENTEADUANAL.isnull["ISAT_CLAVE"])
                {
                    auxPar.Value = oCSAT_PATENTEADUANAL.ISAT_CLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_FECHAINICIO", FbDbType.Date);
                if (!(bool)oCSAT_PATENTEADUANAL.isnull["ISAT_FECHAINICIO"])
                {
                    auxPar.Value = oCSAT_PATENTEADUANAL.ISAT_FECHAINICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_FECHAFIN", FbDbType.Date);
                if (!(bool)oCSAT_PATENTEADUANAL.isnull["ISAT_FECHAFIN"])
                {
                    auxPar.Value = oCSAT_PATENTEADUANAL.ISAT_FECHAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO SAT_PATENTEADUANAL
      (
    
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

SAT_CLAVE,

SAT_FECHAINICIO,

SAT_FECHAFIN
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@SAT_CLAVE,

@SAT_FECHAINICIO,

@SAT_FECHAFIN
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCSAT_PATENTEADUANAL;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSAT_PATENTEADUANALD(CSAT_PATENTEADUANALBE oCSAT_PATENTEADUANAL, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_PATENTEADUANAL.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from SAT_PATENTEADUANAL
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


        public bool CambiarSAT_PATENTEADUANALD(CSAT_PATENTEADUANALBE oCSAT_PATENTEADUANALNuevo, CSAT_PATENTEADUANALBE oCSAT_PATENTEADUANALAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_PATENTEADUANALNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_PATENTEADUANALNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_PATENTEADUANALNuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_PATENTEADUANALNuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_PATENTEADUANALNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_PATENTEADUANALNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_CLAVE", FbDbType.Integer);
                if (!(bool)oCSAT_PATENTEADUANALNuevo.isnull["ISAT_CLAVE"])
                {
                    auxPar.Value = oCSAT_PATENTEADUANALNuevo.ISAT_CLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_FECHAINICIO", FbDbType.Date);
                if (!(bool)oCSAT_PATENTEADUANALNuevo.isnull["ISAT_FECHAINICIO"])
                {
                    auxPar.Value = oCSAT_PATENTEADUANALNuevo.ISAT_FECHAINICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_FECHAFIN", FbDbType.Date);
                if (!(bool)oCSAT_PATENTEADUANALNuevo.isnull["ISAT_FECHAFIN"])
                {
                    auxPar.Value = oCSAT_PATENTEADUANALNuevo.ISAT_FECHAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCSAT_PATENTEADUANALAnterior.isnull["IID"])
                {
                    auxPar.Value = oCSAT_PATENTEADUANALAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  SAT_PATENTEADUANAL
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

SAT_CLAVE=@SAT_CLAVE,

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


        public CSAT_PATENTEADUANALBE seleccionarSAT_PATENTEADUANAL_X_CLAVE(CSAT_PATENTEADUANALBE oCSAT_PATENTEADUANAL, FbTransaction st)
        {




            CSAT_PATENTEADUANALBE retorno = new CSAT_PATENTEADUANALBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_PATENTEADUANAL where SAT_CLAVE = @SAT_CLAVE  ";


                auxPar = new FbParameter("@SAT_CLAVE", FbDbType.VarChar);
                auxPar.Value = oCSAT_PATENTEADUANAL.ISAT_CLAVE;
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

                    if (dr["SAT_FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAINICIO = (DateTime)(dr["SAT_FECHAINICIO"]);
                    }

                    if (dr["SAT_FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAFIN = (DateTime)(dr["SAT_FECHAFIN"]);
                    }

                    if (dr["SAT_CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CLAVE = int.Parse(dr["SAT_CLAVE"].ToString());
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









        public DataSet enlistarSAT_PATENTEADUANAL()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_SAT_PATENTEADUANAL_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoSAT_PATENTEADUANAL()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_SAT_PATENTEADUANAL_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExisteSAT_PATENTEADUANAL(CSAT_PATENTEADUANALBE oCSAT_PATENTEADUANAL, FbTransaction st)
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
                auxPar.Value = oCSAT_PATENTEADUANAL.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from SAT_PATENTEADUANAL where

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




        public CSAT_PATENTEADUANALBE AgregarSAT_PATENTEADUANAL(CSAT_PATENTEADUANALBE oCSAT_PATENTEADUANAL, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_PATENTEADUANAL(oCSAT_PATENTEADUANAL, st);
                if (iRes == 1)
                {
                    this.IComentario = "El SAT_PATENTEADUANAL ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarSAT_PATENTEADUANALD(oCSAT_PATENTEADUANAL, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSAT_PATENTEADUANAL(CSAT_PATENTEADUANALBE oCSAT_PATENTEADUANAL, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_PATENTEADUANAL(oCSAT_PATENTEADUANAL, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_PATENTEADUANAL no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarSAT_PATENTEADUANALD(oCSAT_PATENTEADUANAL, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarSAT_PATENTEADUANAL(CSAT_PATENTEADUANALBE oCSAT_PATENTEADUANALNuevo, CSAT_PATENTEADUANALBE oCSAT_PATENTEADUANALAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_PATENTEADUANAL(oCSAT_PATENTEADUANALAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_PATENTEADUANAL no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarSAT_PATENTEADUANALD(oCSAT_PATENTEADUANALNuevo, oCSAT_PATENTEADUANALAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public CSAT_PATENTEADUANALD(string cadenaConexion)
        {
            this.sCadenaConexion = cadenaConexion;
        }


        public CSAT_PATENTEADUANALD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
