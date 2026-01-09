

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



    public class CSAT_PEDIMENTOSD
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


        public CSAT_PEDIMENTOSBE AgregarSAT_PEDIMENTOSD(CSAT_PEDIMENTOSBE oCSAT_PEDIMENTOS, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_PEDIMENTOS.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_PEDIMENTOS.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_PEDIMENTOS.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_PEDIMENTOS.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_PEDIMENTOS.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_PEDIMENTOS.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_CLAVEADUANA", FbDbType.Integer);
                if (!(bool)oCSAT_PEDIMENTOS.isnull["ISAT_CLAVEADUANA"])
                {
                    auxPar.Value = oCSAT_PEDIMENTOS.ISAT_CLAVEADUANA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_PATENTE", FbDbType.Integer);
                if (!(bool)oCSAT_PEDIMENTOS.isnull["ISAT_PATENTE"])
                {
                    auxPar.Value = oCSAT_PEDIMENTOS.ISAT_PATENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_EJERCICIO", FbDbType.Integer);
                if (!(bool)oCSAT_PEDIMENTOS.isnull["ISAT_EJERCICIO"])
                {
                    auxPar.Value = oCSAT_PEDIMENTOS.ISAT_EJERCICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_CANTIDAD", FbDbType.VarChar);
                if (!(bool)oCSAT_PEDIMENTOS.isnull["ISAT_CANTIDAD"])
                {
                    auxPar.Value = oCSAT_PEDIMENTOS.ISAT_CANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_FECHAINICIO", FbDbType.Date);
                if (!(bool)oCSAT_PEDIMENTOS.isnull["ISAT_FECHAINICIO"])
                {
                    auxPar.Value = oCSAT_PEDIMENTOS.ISAT_FECHAINICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_FECHAFIN", FbDbType.Date);
                if (!(bool)oCSAT_PEDIMENTOS.isnull["ISAT_FECHAFIN"])
                {
                    auxPar.Value = oCSAT_PEDIMENTOS.ISAT_FECHAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO SAT_PEDIMENTOS
      (
    
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

SAT_CLAVEADUANA,

SAT_PATENTE,

SAT_EJERCICIO,

SAT_CANTIDAD,

SAT_FECHAINICIO,

SAT_FECHAFIN
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@SAT_CLAVEADUANA,

@SAT_PATENTE,

@SAT_EJERCICIO,

@SAT_CANTIDAD,

@SAT_FECHAINICIO,

@SAT_FECHAFIN
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCSAT_PEDIMENTOS;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSAT_PEDIMENTOSD(CSAT_PEDIMENTOSBE oCSAT_PEDIMENTOS, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_PEDIMENTOS.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from SAT_PEDIMENTOS
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


        public bool CambiarSAT_PEDIMENTOSD(CSAT_PEDIMENTOSBE oCSAT_PEDIMENTOSNuevo, CSAT_PEDIMENTOSBE oCSAT_PEDIMENTOSAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_PEDIMENTOSNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_PEDIMENTOSNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_PEDIMENTOSNuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_PEDIMENTOSNuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_PEDIMENTOSNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_PEDIMENTOSNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_CLAVEADUANA", FbDbType.Integer);
                if (!(bool)oCSAT_PEDIMENTOSNuevo.isnull["ISAT_CLAVEADUANA"])
                {
                    auxPar.Value = oCSAT_PEDIMENTOSNuevo.ISAT_CLAVEADUANA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_PATENTE", FbDbType.Integer);
                if (!(bool)oCSAT_PEDIMENTOSNuevo.isnull["ISAT_PATENTE"])
                {
                    auxPar.Value = oCSAT_PEDIMENTOSNuevo.ISAT_PATENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_EJERCICIO", FbDbType.Integer);
                if (!(bool)oCSAT_PEDIMENTOSNuevo.isnull["ISAT_EJERCICIO"])
                {
                    auxPar.Value = oCSAT_PEDIMENTOSNuevo.ISAT_EJERCICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_CANTIDAD", FbDbType.VarChar);
                if (!(bool)oCSAT_PEDIMENTOSNuevo.isnull["ISAT_CANTIDAD"])
                {
                    auxPar.Value = oCSAT_PEDIMENTOSNuevo.ISAT_CANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_FECHAINICIO", FbDbType.Date);
                if (!(bool)oCSAT_PEDIMENTOSNuevo.isnull["ISAT_FECHAINICIO"])
                {
                    auxPar.Value = oCSAT_PEDIMENTOSNuevo.ISAT_FECHAINICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_FECHAFIN", FbDbType.Date);
                if (!(bool)oCSAT_PEDIMENTOSNuevo.isnull["ISAT_FECHAFIN"])
                {
                    auxPar.Value = oCSAT_PEDIMENTOSNuevo.ISAT_FECHAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCSAT_PEDIMENTOSAnterior.isnull["IID"])
                {
                    auxPar.Value = oCSAT_PEDIMENTOSAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  SAT_PEDIMENTOS
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

SAT_CLAVEADUANA=@SAT_CLAVEADUANA,

SAT_PATENTE=@SAT_PATENTE,

SAT_EJERCICIO=@SAT_EJERCICIO,

SAT_CANTIDAD=@SAT_CANTIDAD,

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


        public CSAT_PEDIMENTOSBE seleccionarSAT_PEDIMENTOS(CSAT_PEDIMENTOSBE oCSAT_PEDIMENTOS, FbTransaction st)
        {




            CSAT_PEDIMENTOSBE retorno = new CSAT_PEDIMENTOSBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_PEDIMENTOS where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_PEDIMENTOS.IID;
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

                    if (dr["SAT_CANTIDAD"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CANTIDAD = (string)(dr["SAT_CANTIDAD"]);
                    }

                    if (dr["SAT_FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAINICIO = (DateTime)(dr["SAT_FECHAINICIO"]);
                    }

                    if (dr["SAT_FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAFIN = (DateTime)(dr["SAT_FECHAFIN"]);
                    }

                    if (dr["SAT_CLAVEADUANA"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CLAVEADUANA = int.Parse(dr["SAT_CLAVEADUANA"].ToString());
                    }

                    if (dr["SAT_PATENTE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_PATENTE = int.Parse(dr["SAT_PATENTE"].ToString());
                    }

                    if (dr["SAT_EJERCICIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_EJERCICIO = int.Parse(dr["SAT_EJERCICIO"].ToString());
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






        public CSAT_PEDIMENTOSBE seleccionarSAT_PEDIMENTOS_X_CLAVE_X_PATENTE_X_EJERCICIO_X_CANT(CSAT_PEDIMENTOSBE oCSAT_PEDIMENTOS, FbTransaction st)
        {




            CSAT_PEDIMENTOSBE retorno = new CSAT_PEDIMENTOSBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_PEDIMENTOS where SAT_CLAVEADUANA = @SAT_CLAVEADUANA AND SAT_PATENTE = @SAT_PATENTE AND SAT_EJERCICIO = @SAT_EJERCICIO AND SAT_CANTIDAD = @SAT_CANTIDAD  ";


                auxPar = new FbParameter("@SAT_CLAVEADUANA", FbDbType.VarChar);
                auxPar.Value = oCSAT_PEDIMENTOS.ISAT_CLAVEADUANA;
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_PATENTE", FbDbType.VarChar);
                auxPar.Value = oCSAT_PEDIMENTOS.ISAT_PATENTE;
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_EJERCICIO", FbDbType.VarChar);
                auxPar.Value = oCSAT_PEDIMENTOS.ISAT_EJERCICIO;
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_CANTIDAD", FbDbType.VarChar);
                auxPar.Value = oCSAT_PEDIMENTOS.ISAT_CANTIDAD;
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

                    if (dr["SAT_CANTIDAD"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CANTIDAD = (string)(dr["SAT_CANTIDAD"]);
                    }

                    if (dr["SAT_FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAINICIO = (DateTime)(dr["SAT_FECHAINICIO"]);
                    }

                    if (dr["SAT_FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAFIN = (DateTime)(dr["SAT_FECHAFIN"]);
                    }

                    if (dr["SAT_CLAVEADUANA"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CLAVEADUANA = int.Parse(dr["SAT_CLAVEADUANA"].ToString());
                    }

                    if (dr["SAT_PATENTE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_PATENTE = int.Parse(dr["SAT_PATENTE"].ToString());
                    }

                    if (dr["SAT_EJERCICIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_EJERCICIO = int.Parse(dr["SAT_EJERCICIO"].ToString());
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





        public DataSet enlistarSAT_PEDIMENTOS()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_SAT_PEDIMENTOS_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoSAT_PEDIMENTOS()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_SAT_PEDIMENTOS_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExisteSAT_PEDIMENTOS(CSAT_PEDIMENTOSBE oCSAT_PEDIMENTOS, FbTransaction st)
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
                auxPar.Value = oCSAT_PEDIMENTOS.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from SAT_PEDIMENTOS where

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




        public CSAT_PEDIMENTOSBE AgregarSAT_PEDIMENTOS(CSAT_PEDIMENTOSBE oCSAT_PEDIMENTOS, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_PEDIMENTOS(oCSAT_PEDIMENTOS, st);
                if (iRes == 1)
                {
                    this.IComentario = "El SAT_PEDIMENTOS ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarSAT_PEDIMENTOSD(oCSAT_PEDIMENTOS, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSAT_PEDIMENTOS(CSAT_PEDIMENTOSBE oCSAT_PEDIMENTOS, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_PEDIMENTOS(oCSAT_PEDIMENTOS, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_PEDIMENTOS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarSAT_PEDIMENTOSD(oCSAT_PEDIMENTOS, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarSAT_PEDIMENTOS(CSAT_PEDIMENTOSBE oCSAT_PEDIMENTOSNuevo, CSAT_PEDIMENTOSBE oCSAT_PEDIMENTOSAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_PEDIMENTOS(oCSAT_PEDIMENTOSAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_PEDIMENTOS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarSAT_PEDIMENTOSD(oCSAT_PEDIMENTOSNuevo, oCSAT_PEDIMENTOSAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }



        public CSAT_PEDIMENTOSD(string conexion)
        {
            this.sCadenaConexion = conexion;
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }



        public CSAT_PEDIMENTOSD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
