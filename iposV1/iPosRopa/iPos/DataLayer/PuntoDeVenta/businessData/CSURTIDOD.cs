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
    public class CSURTIDOD
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





        public bool SURTIDO_CAMBIAR_LOTE_PREPARE(long firstMovtoid,  decimal cantidad, string lote, DateTime fechavence , string surtible, decimal maxsurtible, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@FIRSTMOVTOID", FbDbType.BigInt);
                auxPar.Value = firstMovtoid;
                parts.Add(auxPar);

                auxPar = new FbParameter("@FIRSTCANTIDAD", FbDbType.Decimal);
                auxPar.Value = cantidad;
                parts.Add(auxPar);
                

                auxPar = new FbParameter("@FIRSTLOTE", FbDbType.VarChar);
                auxPar.Value = lote;
                parts.Add(auxPar);
                

                auxPar = new FbParameter("@FIRSTFECHAVENCE", FbDbType.Date);
                auxPar.Value = fechavence;
                parts.Add(auxPar);


                auxPar = new FbParameter("@FIRSTSURTIBLE", FbDbType.VarChar);
                auxPar.Value = surtible;
                parts.Add(auxPar);

                auxPar = new FbParameter("@FIRSTMAXSURTIBLE", FbDbType.Decimal);
                auxPar.Value = maxsurtible;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"SURTIDO_CAMBIAR_LOTE_PREPARE";

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
                        this.iComentario = "Hubo un error";
                        return false;
                    }
                }


                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }






        public bool SURTIDO_CAMBIAR_LOTE_PREPOST(long firstMovtoid, decimal cantidad, string lote, DateTime fechavence, string surtible, decimal maxsurtible, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@FIRSTMOVTOID", FbDbType.BigInt);
                auxPar.Value = firstMovtoid;
                parts.Add(auxPar);

                auxPar = new FbParameter("@FIRSTCANTIDAD", FbDbType.Decimal);
                auxPar.Value = cantidad;
                parts.Add(auxPar);


                auxPar = new FbParameter("@FIRSTLOTE", FbDbType.VarChar);
                auxPar.Value = lote;
                parts.Add(auxPar);


                auxPar = new FbParameter("@FIRSTFECHAVENCE", FbDbType.Date);
                auxPar.Value = fechavence;
                parts.Add(auxPar);


                auxPar = new FbParameter("@FIRSTSURTIBLE", FbDbType.VarChar);
                auxPar.Value = surtible;
                parts.Add(auxPar);

                auxPar = new FbParameter("@FIRSTMAXSURTIBLE", FbDbType.Decimal);
                auxPar.Value = maxsurtible;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"SURTIDO_CAMBIAR_LOTE_PREPOST";

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
                        this.iComentario = "Hubo un error";
                        return false;
                    }
                }


                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool SURTIDO_CAMBIAR_LOTE_FINISH(long firstMovtoid, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@FIRSTMOVTOID", FbDbType.BigInt);
                auxPar.Value = firstMovtoid;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"SURTIDO_CAMBIAR_LOTE_FINISH";

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
                        this.iComentario = "Hubo un error";
                        return false;
                    }
                }


                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool SURTIDO_CAMBIAR_LOTE_ADD(long firstMovtoid, decimal cantidad, string lote, DateTime fechavence, string surtible, decimal maxsurtible, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@FIRSTMOVTOID", FbDbType.BigInt);
                auxPar.Value = firstMovtoid;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CANTIDAD", FbDbType.Decimal);
                auxPar.Value = cantidad;
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOTE", FbDbType.VarChar);
                auxPar.Value = lote;
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAVENCE", FbDbType.Date);
                auxPar.Value = fechavence;
                parts.Add(auxPar);



                auxPar = new FbParameter("@SURTIBLE", FbDbType.VarChar);
                auxPar.Value = surtible;
                parts.Add(auxPar);

                auxPar = new FbParameter("@MAXSURTIBLE", FbDbType.Decimal);
                auxPar.Value = maxsurtible;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"SURTIDO_CAMBIAR_LOTE_ADD";

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
                        this.iComentario = "Hubo un error";
                        return false;
                    }
                }


                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool SURTIDOPREV_ASIGNARESTADO(long doctoId, string notasurtido, long estadosurtidoid, long personaIdSurtido, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTADOSURTIDOID", FbDbType.BigInt);
                auxPar.Value = estadosurtidoid;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PERSONAIDSURTIDO", FbDbType.BigInt);
                auxPar.Value = personaIdSurtido;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"SURTIDOPREV_ASIGNARESTADO";

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
                        this.iComentario = "Hubo un error " + ((int)arParms[arParms.Length - 1].Value).ToString();
                        return false;
                    }
                }


                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool SURTIDO_ASIGNARESTADO(long doctoId, string notasurtido, long estadosurtidoid, long personaIdSurtido, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOTASURTIDO", FbDbType.VarChar);
                auxPar.Value = notasurtido;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTADOSURTIDOID", FbDbType.BigInt);
                auxPar.Value = estadosurtidoid;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PERSONAIDSURTIDO", FbDbType.BigInt);
                auxPar.Value = personaIdSurtido;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"SURTIDO_ASIGNARESTADO";

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
                        this.iComentario = "Hubo un error " + ((int)arParms[arParms.Length - 1].Value).ToString();
                        return false;
                    }
                }


                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool SURTIDO_RECREARVENTA(long doctoId, long vendedorId, ref long newDoctoId,FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOCANCELARID", FbDbType.BigInt);
                auxPar.Value = doctoId;
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

                string commandText = @"SURTIDO_RECREARVENTA";

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
                    if ((long)arParms[arParms.Length - 2].Value != 0)
                    {
                        newDoctoId = (long)arParms[arParms.Length - 2].Value;
                    }
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public CSURTIDOD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
        }


    }
}
