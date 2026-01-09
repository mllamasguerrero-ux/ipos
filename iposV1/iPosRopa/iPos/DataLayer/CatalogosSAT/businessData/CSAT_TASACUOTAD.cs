

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



    public class CSAT_TASACUOTAD
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


        public CSAT_TASACUOTABE AgregarSAT_TASACUOTAD(CSAT_TASACUOTABE oCSAT_TASACUOTA, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_TASACUOTA.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_TASACUOTA.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_TASACUOTA.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_TASACUOTA.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_TASACUOTA.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_TASACUOTA.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_RANGOFIJO", FbDbType.VarChar);
                if (!(bool)oCSAT_TASACUOTA.isnull["ISAT_RANGOFIJO"])
                {
                    auxPar.Value = oCSAT_TASACUOTA.ISAT_RANGOFIJO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_VALORMINIMO", FbDbType.Numeric);
                if (!(bool)oCSAT_TASACUOTA.isnull["ISAT_VALORMINIMO"])
                {
                    auxPar.Value = oCSAT_TASACUOTA.ISAT_VALORMINIMO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_VALORMAXIMO", FbDbType.Numeric);
                if (!(bool)oCSAT_TASACUOTA.isnull["ISAT_VALORMAXIMO"])
                {
                    auxPar.Value = oCSAT_TASACUOTA.ISAT_VALORMAXIMO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_IMPUESTO", FbDbType.VarChar);
                if (!(bool)oCSAT_TASACUOTA.isnull["ISAT_IMPUESTO"])
                {
                    auxPar.Value = oCSAT_TASACUOTA.ISAT_IMPUESTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_FACTOR", FbDbType.VarChar);
                if (!(bool)oCSAT_TASACUOTA.isnull["ISAT_FACTOR"])
                {
                    auxPar.Value = oCSAT_TASACUOTA.ISAT_FACTOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_TRASLADO", FbDbType.VarChar);
                if (!(bool)oCSAT_TASACUOTA.isnull["ISAT_TRASLADO"])
                {
                    auxPar.Value = oCSAT_TASACUOTA.ISAT_TRASLADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_RETENCION", FbDbType.VarChar);
                if (!(bool)oCSAT_TASACUOTA.isnull["ISAT_RETENCION"])
                {
                    auxPar.Value = oCSAT_TASACUOTA.ISAT_RETENCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_FECHAINICIO", FbDbType.Date);
                if (!(bool)oCSAT_TASACUOTA.isnull["ISAT_FECHAINICIO"])
                {
                    auxPar.Value = oCSAT_TASACUOTA.ISAT_FECHAINICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_FECHAFIN", FbDbType.Date);
                if (!(bool)oCSAT_TASACUOTA.isnull["ISAT_FECHAFIN"])
                {
                    auxPar.Value = oCSAT_TASACUOTA.ISAT_FECHAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO SAT_TASACUOTA
      (
    
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

SAT_RANGOFIJO,

SAT_VALORMINIMO,

SAT_VALORMAXIMO,

SAT_IMPUESTO,

SAT_FACTOR,

SAT_TRASLADO,

SAT_RETENCION,

SAT_FECHAINICIO,

SAT_FECHAFIN
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@SAT_RANGOFIJO,

@SAT_VALORMINIMO,

@SAT_VALORMAXIMO,

@SAT_IMPUESTO,

@SAT_FACTOR,

@SAT_TRASLADO,

@SAT_RETENCION,

@SAT_FECHAINICIO,

@SAT_FECHAFIN
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCSAT_TASACUOTA;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSAT_TASACUOTAD(CSAT_TASACUOTABE oCSAT_TASACUOTA, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_TASACUOTA.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from SAT_TASACUOTA
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


        public bool CambiarSAT_TASACUOTAD(CSAT_TASACUOTABE oCSAT_TASACUOTANuevo, CSAT_TASACUOTABE oCSAT_TASACUOTAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_TASACUOTANuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_TASACUOTANuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_TASACUOTANuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_TASACUOTANuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_TASACUOTANuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_TASACUOTANuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_RANGOFIJO", FbDbType.VarChar);
                if (!(bool)oCSAT_TASACUOTANuevo.isnull["ISAT_RANGOFIJO"])
                {
                    auxPar.Value = oCSAT_TASACUOTANuevo.ISAT_RANGOFIJO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_VALORMINIMO", FbDbType.Numeric);
                if (!(bool)oCSAT_TASACUOTANuevo.isnull["ISAT_VALORMINIMO"])
                {
                    auxPar.Value = oCSAT_TASACUOTANuevo.ISAT_VALORMINIMO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_VALORMAXIMO", FbDbType.Numeric);
                if (!(bool)oCSAT_TASACUOTANuevo.isnull["ISAT_VALORMAXIMO"])
                {
                    auxPar.Value = oCSAT_TASACUOTANuevo.ISAT_VALORMAXIMO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_IMPUESTO", FbDbType.VarChar);
                if (!(bool)oCSAT_TASACUOTANuevo.isnull["ISAT_IMPUESTO"])
                {
                    auxPar.Value = oCSAT_TASACUOTANuevo.ISAT_IMPUESTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_FACTOR", FbDbType.VarChar);
                if (!(bool)oCSAT_TASACUOTANuevo.isnull["ISAT_FACTOR"])
                {
                    auxPar.Value = oCSAT_TASACUOTANuevo.ISAT_FACTOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_TRASLADO", FbDbType.VarChar);
                if (!(bool)oCSAT_TASACUOTANuevo.isnull["ISAT_TRASLADO"])
                {
                    auxPar.Value = oCSAT_TASACUOTANuevo.ISAT_TRASLADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_RETENCION", FbDbType.VarChar);
                if (!(bool)oCSAT_TASACUOTANuevo.isnull["ISAT_RETENCION"])
                {
                    auxPar.Value = oCSAT_TASACUOTANuevo.ISAT_RETENCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_FECHAINICIO", FbDbType.Date);
                if (!(bool)oCSAT_TASACUOTANuevo.isnull["ISAT_FECHAINICIO"])
                {
                    auxPar.Value = oCSAT_TASACUOTANuevo.ISAT_FECHAINICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_FECHAFIN", FbDbType.Date);
                if (!(bool)oCSAT_TASACUOTANuevo.isnull["ISAT_FECHAFIN"])
                {
                    auxPar.Value = oCSAT_TASACUOTANuevo.ISAT_FECHAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCSAT_TASACUOTAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCSAT_TASACUOTAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  SAT_TASACUOTA
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

SAT_RANGOFIJO=@SAT_RANGOFIJO,

SAT_VALORMINIMO=@SAT_VALORMINIMO,

SAT_VALORMAXIMO=@SAT_VALORMAXIMO,

SAT_IMPUESTO=@SAT_IMPUESTO,

SAT_FACTOR=@SAT_FACTOR,

SAT_TRASLADO=@SAT_TRASLADO,

SAT_RETENCION=@SAT_RETENCION,

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


        public CSAT_TASACUOTABE seleccionarSAT_TASACUOTA(CSAT_TASACUOTABE oCSAT_TASACUOTA, FbTransaction st)
        {
            CSAT_TASACUOTABE retorno = new CSAT_TASACUOTABE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_TASACUOTA where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_TASACUOTA.IID;
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

                    if (dr["SAT_RANGOFIJO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_RANGOFIJO = (string)(dr["SAT_RANGOFIJO"]);
                    }

                    if (dr["SAT_VALORMINIMO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_VALORMINIMO = (decimal)(dr["SAT_VALORMINIMO"]);
                    }

                    if (dr["SAT_VALORMAXIMO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_VALORMAXIMO = (decimal)(dr["SAT_VALORMAXIMO"]);
                    }

                    if (dr["SAT_IMPUESTO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_IMPUESTO = (string)(dr["SAT_IMPUESTO"]);
                    }

                    if (dr["SAT_FACTOR"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FACTOR = (string)(dr["SAT_FACTOR"]);
                    }

                    if (dr["SAT_TRASLADO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_TRASLADO = (string)(dr["SAT_TRASLADO"]);
                    }

                    if (dr["SAT_RETENCION"] != System.DBNull.Value)
                    {
                        retorno.ISAT_RETENCION = (string)(dr["SAT_RETENCION"]);
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




        public CSAT_TASACUOTABE seleccionarSAT_TASACUOTA_X_SAT_RANGOFIJO_SAT_VALORMAXIMO_SAT_IMPUESTO_SAT_FACTOR(CSAT_TASACUOTABE oCSAT_TASACUOTA, FbTransaction st)
        {
            CSAT_TASACUOTABE retorno = new CSAT_TASACUOTABE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_TASACUOTA where SAT_RANGOFIJO=@SAT_RANGOFIJO
                                  AND SAT_VALORMAXIMO = @SAT_VALORMAXIMO AND SAT_IMPUESTO = @SAT_IMPUESTO
                                  AND SAT_FACTOR = @SAT_FACTOR";


                auxPar = new FbParameter("@SAT_RANGOFIJO", FbDbType.VarChar);
                auxPar.Value = oCSAT_TASACUOTA.ISAT_RANGOFIJO;
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_VALORMAXIMO", FbDbType.Decimal);
                auxPar.Value = oCSAT_TASACUOTA.ISAT_VALORMAXIMO;
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_IMPUESTO", FbDbType.VarChar);
                auxPar.Value = oCSAT_TASACUOTA.ISAT_IMPUESTO;
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_FACTOR", FbDbType.VarChar);
                auxPar.Value = oCSAT_TASACUOTA.ISAT_FACTOR;
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

                    if (dr["SAT_RANGOFIJO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_RANGOFIJO = (string)(dr["SAT_RANGOFIJO"]);
                    }

                    if (dr["SAT_VALORMINIMO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_VALORMINIMO = (decimal)(dr["SAT_VALORMINIMO"]);
                    }

                    if (dr["SAT_VALORMAXIMO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_VALORMAXIMO = (decimal)(dr["SAT_VALORMAXIMO"]);
                    }

                    if (dr["SAT_IMPUESTO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_IMPUESTO = (string)(dr["SAT_IMPUESTO"]);
                    }

                    if (dr["SAT_FACTOR"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FACTOR = (string)(dr["SAT_FACTOR"]);
                    }

                    if (dr["SAT_TRASLADO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_TRASLADO = (string)(dr["SAT_TRASLADO"]);
                    }

                    if (dr["SAT_RETENCION"] != System.DBNull.Value)
                    {
                        retorno.ISAT_RETENCION = (string)(dr["SAT_RETENCION"]);
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




        public DataSet enlistarSAT_TASACUOTA()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_SAT_TASACUOTA_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoSAT_TASACUOTA()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_SAT_TASACUOTA_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExisteSAT_TASACUOTA(CSAT_TASACUOTABE oCSAT_TASACUOTA, FbTransaction st)
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
                auxPar.Value = oCSAT_TASACUOTA.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from SAT_TASACUOTA where

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




        public CSAT_TASACUOTABE AgregarSAT_TASACUOTA(CSAT_TASACUOTABE oCSAT_TASACUOTA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_TASACUOTA(oCSAT_TASACUOTA, st);
                if (iRes == 1)
                {
                    this.IComentario = "El SAT_TASACUOTA ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarSAT_TASACUOTAD(oCSAT_TASACUOTA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSAT_TASACUOTA(CSAT_TASACUOTABE oCSAT_TASACUOTA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_TASACUOTA(oCSAT_TASACUOTA, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_TASACUOTA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarSAT_TASACUOTAD(oCSAT_TASACUOTA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarSAT_TASACUOTA(CSAT_TASACUOTABE oCSAT_TASACUOTANuevo, CSAT_TASACUOTABE oCSAT_TASACUOTAAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_TASACUOTA(oCSAT_TASACUOTAAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_TASACUOTA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarSAT_TASACUOTAD(oCSAT_TASACUOTANuevo, oCSAT_TASACUOTAAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public CSAT_TASACUOTAD(string cadenaConexion)
        {
            this.sCadenaConexion = cadenaConexion;
        }


        public CSAT_TASACUOTAD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
