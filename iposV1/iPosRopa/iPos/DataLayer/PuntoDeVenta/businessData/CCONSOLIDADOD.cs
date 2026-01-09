using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Collections;
using ConexionesBD;
using System.Data.Odbc;
using DataLayer;

namespace iPosData
{
    public class CCONSOLIDADOD
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







        public bool CONSOLIDADO_GENERAR(DateTime fechaInicial, DateTime fechaFinal, long vendedorId, ref long doctoId, string OMITIRVENTASAFRANQUICIAS, string INCLUIRGASTOS, decimal MAXIMOMONTO, string OMITIRVALES, long GRUPOUSUARIOID, string OMITIRCLIENTESRFC, decimal MAXIMOPORCENTAJE, string grupoFiltroFolios, ref int errorCode, FbTransaction st)
        {

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;





                auxPar = new FbParameter("@FECHAINICIAL", FbDbType.Date);
                auxPar.Value = fechaInicial;
                parts.Add(auxPar);



                auxPar = new FbParameter("@FECHAFINAL", FbDbType.Date);
                auxPar.Value = fechaFinal;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = vendedorId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@OMITIRVENTASAFRANQUICIAS", FbDbType.BigInt);
                auxPar.Value = OMITIRVENTASAFRANQUICIAS;
                parts.Add(auxPar);


                auxPar = new FbParameter("@INCLUIRGASTOS", FbDbType.BigInt);
                auxPar.Value = INCLUIRGASTOS;
                parts.Add(auxPar);


                auxPar = new FbParameter("@MAXIMOMONTO", FbDbType.Numeric);
                auxPar.Value = MAXIMOMONTO;
                parts.Add(auxPar);


                auxPar = new FbParameter("@OMITIRVALES", FbDbType.VarChar);
                auxPar.Value = OMITIRVALES;
                parts.Add(auxPar);


                auxPar = new FbParameter("@GRUPOUSUARIOID", FbDbType.BigInt);
                auxPar.Value = GRUPOUSUARIOID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@OMITIRCLIENTESRFC", FbDbType.VarChar);
                auxPar.Value = OMITIRCLIENTESRFC;
                parts.Add(auxPar);


                auxPar = new FbParameter("@MAXIMOPORCENTAJE", FbDbType.Numeric);
                auxPar.Value = MAXIMOPORCENTAJE;
                parts.Add(auxPar);

                auxPar = new FbParameter("@GRUPOFILTROFOLIOS", FbDbType.VarChar);

                if (grupoFiltroFolios != null)
                    auxPar.Value = grupoFiltroFolios;
                else
                    auxPar.Value = DBNull.Value;

                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);





                string commandText = @"CONSOLIDADO_GENERAR";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);




                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        errorCode = (int)arParms[arParms.Length - 1].Value;
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)(errorCode), this.sCadenaConexion, null);
                        this.iComentario = "Hubo un error " + strMensajeErr;
                        return false;
                    }
                }

                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    doctoId = (long)arParms[arParms.Length - 2].Value;
                }


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool CONSOLIDADO_DEVOLVER(long doctoDevolucionId, long vendedorId, ref long doctoId, FbTransaction st)
        {

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("DOCTODEVOLUCIONID", FbDbType.BigInt);
                auxPar.Value = doctoDevolucionId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = vendedorId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);





                string commandText = @"CONSOLIDADO_DEVOLVER";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);




                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.sCadenaConexion, null);
                        this.iComentario = "Hubo un error " + strMensajeErr;
                        return false;
                    }
                }

                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    doctoId = (long)arParms[arParms.Length - 2].Value;
                }


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool CONSOLIDADO_CHECARPOSIBILIDAD_CANCELAR(long doctoConsolidadoId, long vendedorId,   FbTransaction st)
        {
            long doctoId = 0;
            return CONSOLIDADO_CANCELAR(doctoConsolidadoId,  vendedorId, true, ref doctoId,  st);
        }


        public bool CONSOLIDADO_CANCELAR(long doctoConsolidadoId, long vendedorId, ref long doctoId, FbTransaction st)
        {
            return CONSOLIDADO_CANCELAR(doctoConsolidadoId, vendedorId, false, ref doctoId, st);
        }

        public bool CONSOLIDADO_CANCELAR(long doctoConsolidadoId, long vendedorId, bool bSoloValidarPosibilidad, ref long doctoId, FbTransaction st)
        {

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("DOCTOCONSOLIDADOID", FbDbType.BigInt);
                auxPar.Value = doctoConsolidadoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = vendedorId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@SOLOVALIDARPOSIBILIDAD", FbDbType.VarChar);
                auxPar.Value = bSoloValidarPosibilidad ? "S" : "N";
                parts.Add(auxPar);



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);





                string commandText = @"CONSOLIDADO_CANCELAR";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);




                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.sCadenaConexion, null);
                        this.iComentario = "Hubo un error " + strMensajeErr;
                        return false;
                    }
                }

                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    doctoId = (long)arParms[arParms.Length - 2].Value;
                }


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool CONSOLIDADO_ESDEVOLUCIONCONS(long doctoId, ref string esDevolucionCons, FbTransaction st)
        {

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESDEVOLUCIONCONS", FbDbType.VarChar);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);





                string commandText = @"CONSOLIDADO_ESDEVOLUCIONCONS";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);




                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.sCadenaConexion, null);
                        this.iComentario = "Hubo un error " + strMensajeErr;
                        return false;
                    }
                }

                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    esDevolucionCons = (string)arParms[arParms.Length - 2].Value;
                }


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }





        public bool CONSOLIDADO_ESVENTACONS(long doctoId, ref string esVentaCons, FbTransaction st)
        {

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESVENTACONS", FbDbType.VarChar);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);





                string commandText = @"CONSOLIDADO_ESVENTACONS";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);




                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.sCadenaConexion, null);
                        this.iComentario = "Hubo un error " + strMensajeErr;
                        return false;
                    }
                }

                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    esVentaCons = (string)arParms[arParms.Length - 2].Value;
                }


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public CCONSOLIDADOD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
        }

    }
}
