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
    public class CGASTOCAJAD
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






        public bool EjecutarAddMOVTO(  long? DOCTOACTUALID,
                                       long? CREADOPOR_USERID,
                                       long? ALMACENID,
                                       long? SUCURSALID,
                                       long? TIPODOCTOID,
                                       long? ESTATUSDOCTOID,
                                       long? ESTATUSDOCTOPAGOID,
                                       long? PERSONAID,
                                       long? VENDEDORID,
                                       long? CAJEROID,
                                       long? SUPERVISORID,
                                       long? CAJAID,
                                       long? PARTIDAID,
                                       long? GASTOID,
                                       decimal? IMPORTE,
                                       long? DOCTOREFID,
                                       string REFERENCIA,
                                       string REFERENCIAS,
                                       DateTime? FECHA,
                                       DateTime? VENCE,
                                       string CORTEACTUAL,
                                       long ORIGENFISCALID,
                                       DateTime? FECHACORTE,
                                       long? CORTEAPLICARID,
                                       long? CENTROCOSTOID,
                                       ref long? IDDOCTO,
                                       ref long? MOVTOID,
                                       ref long? IDCORTE,
                                        FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOACTUALID", FbDbType.BigInt);
                if (DOCTOACTUALID.HasValue)
                {
                    auxPar.Value = (long)DOCTOACTUALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (CREADOPOR_USERID.HasValue)
                {
                    auxPar.Value = (long)CREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ALMACENID", FbDbType.BigInt);
                if (ALMACENID.HasValue)
                {
                    auxPar.Value = (long)ALMACENID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (SUCURSALID.HasValue)
                {
                    auxPar.Value = (long)SUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPODOCTOID", FbDbType.BigInt);
                if (TIPODOCTOID.HasValue)
                {
                    auxPar.Value = (long)TIPODOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESTATUSDOCTOID", FbDbType.BigInt);
                if (ESTATUSDOCTOID.HasValue)
                {
                    auxPar.Value = (long)ESTATUSDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESTATUSDOCTOPAGOID", FbDbType.BigInt);
                if (ESTATUSDOCTOPAGOID.HasValue)
                {
                    auxPar.Value = (long)ESTATUSDOCTOPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (PERSONAID.HasValue)
                {
                    auxPar.Value = (long)PERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                if (VENDEDORID.HasValue)
                {
                    auxPar.Value = (long)VENDEDORID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAJAID", FbDbType.BigInt);
                if (CAJAID.HasValue)
                {
                    auxPar.Value = (long)CAJAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PARTIDAID", FbDbType.BigInt);
                if (PARTIDAID.HasValue)
                {
                    auxPar.Value = (long)PARTIDAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@GASTOID", FbDbType.BigInt);
                if (GASTOID.HasValue)
                {
                    auxPar.Value = (long)GASTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPORTE", FbDbType.Numeric);
                if (IMPORTE.HasValue)
                {
                    auxPar.Value = (decimal)IMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOREFID", FbDbType.BigInt);
                if (DOCTOREFID.HasValue)
                {
                    auxPar.Value = (long)DOCTOREFID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@REFERENCIA", FbDbType.VarChar);
                if (REFERENCIA != null)
                {
                    auxPar.Value = REFERENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@REFERENCIAS", FbDbType.VarChar);
                if (REFERENCIAS != null)
                {
                    auxPar.Value = REFERENCIAS ;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (FECHA.HasValue)
                {
                    auxPar.Value = (DateTime)FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENCE", FbDbType.Date);
                if (VENCE.HasValue)
                {
                    auxPar.Value = (DateTime)VENCE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CORTEACTUAL", FbDbType.VarChar);
                if (CORTEACTUAL != null)
                {
                    auxPar.Value = CORTEACTUAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHACORTE", FbDbType.Date);
                if (FECHACORTE.HasValue)
                {
                    auxPar.Value = (DateTime)FECHACORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CORTEAPLICARID", FbDbType.BigInt);
                if (CORTEAPLICARID.HasValue)
                {
                    auxPar.Value = (long)CORTEAPLICARID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CAJEROID", FbDbType.BigInt);
                if (CAJEROID.HasValue)
                {
                    auxPar.Value = (long)CAJEROID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@SUPERVISORID", FbDbType.BigInt);
                if (SUPERVISORID.HasValue)
                {
                    auxPar.Value = (long)SUPERVISORID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ORIGENFISCALID", FbDbType.BigInt);
                auxPar.Value = (long)ORIGENFISCALID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CENTROCOSTOID", FbDbType.BigInt);
                if (CENTROCOSTOID.HasValue)
                {
                    auxPar.Value = (long)CENTROCOSTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@MOVTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);





                string commandText = @"MOVTOGASTO_INSERT";
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
                        string strMensajeErr = "";
                        long longMensajeErr = (long)((int)arParms[arParms.Length - 1].Value);
                         strMensajeErr = CERRORCODED.ObtenerMensajeError(longMensajeErr, this.sCadenaConexion, st);
                       
                        this.iComentario = "ERROR : " + strMensajeErr;
                        return false;
                    }
                }

                MOVTOID = (long)arParms[arParms.Length - 2].Value;
                IDDOCTO = (long)arParms[arParms.Length - 3].Value;
                IDCORTE = (long)arParms[arParms.Length - 4].Value;
                return true;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }




        public bool MOVTOGASTO_DELETE(long movtoId, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@MOVTOID", FbDbType.BigInt);
                auxPar.Value = movtoId;
                parts.Add(auxPar);





                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"MOVTOGASTO_DELETE";

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





        public bool GASTO_CANCEL(long doctoCancelarId,long vendedorId, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOCANCELARID", FbDbType.BigInt);
                auxPar.Value = doctoCancelarId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = vendedorId;
                parts.Add(auxPar);




                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"GASTO_CANCEL";

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




        public bool GASTO_RECREARPARAEDICION(long doctoCancelarId, long vendedorId, ref long doctoRecreateId, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOCANCELARID", FbDbType.BigInt);
                auxPar.Value = doctoCancelarId;
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

                string commandText = @"GASTO_RECREARPARAEDICION";

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


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    doctoRecreateId = (long)arParms[arParms.Length - 2].Value;
                }


                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public CGASTOCAJAD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            
        }

    }
}
