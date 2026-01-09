
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
    public class CRETIRODECAJAD
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




        public bool RETIRO_CAJA_INSERT(ref CDOCTOBE oCDOCTO,
                                       string CORTEACTUAL,
                                       DateTime? FECHACORTE,
                                       long? CAJEROID, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ALMACENID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IALMACENID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.ISUCURSALID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPODOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.ITIPODOCTOID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = CAJEROID.HasValue  && CAJEROID.Value > 0 ? CAJEROID.Value : oCDOCTO.IVENDEDORID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IPERSONAID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAJAID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.ICAJAID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIA", FbDbType.VarChar);
                if (!(bool)oCDOCTO.isnull["IREFERENCIA"])
                {
                    auxPar.Value = oCDOCTO.IREFERENCIA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIAS", FbDbType.VarChar);
                if (!(bool)oCDOCTO.isnull["IREFERENCIAS"])
                {
                    auxPar.Value = oCDOCTO.IREFERENCIAS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCDOCTO.isnull["IFECHA"])
                {
                    auxPar.Value = oCDOCTO.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@VENCE", FbDbType.Date);
                if (!(bool)oCDOCTO.isnull["IVENCE"])
                {
                    auxPar.Value = oCDOCTO.IVENCE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CORTEAPLICARID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.ICORTEID;
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



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"RETIRO_CAJA_INSERT";

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


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    if ((long)arParms[arParms.Length - 2].Value != 0)
                    {
                        oCDOCTO.IID = (long)arParms[arParms.Length - 2].Value;
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




        public bool RETIRO_CAJA_COMPLETAR(ref CDOCTOBE oCDOCTO, decimal efectivo, decimal cheque, decimal vale, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);



                auxPar = new FbParameter("@TOTALEFECTIVO", FbDbType.Decimal);
                auxPar.Value = efectivo;
                parts.Add(auxPar);



                auxPar = new FbParameter("@TOTALCHEQUE", FbDbType.Decimal);
                auxPar.Value = cheque;
                parts.Add(auxPar);

                auxPar = new FbParameter("@TOTALVALE", FbDbType.Decimal);
                auxPar.Value = vale;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"RETIRO_CAJA_COMPLETAR";

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



        public bool RETIRO_CAJA_DESDECORTE(long corteId, long cajeroId, long cajaId, ref long doctoId, ref long montobilletesId, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                auxPar.Value = corteId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAJEROID", FbDbType.BigInt);
                auxPar.Value = cajeroId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAJAID", FbDbType.BigInt);
                auxPar.Value = cajaId;
                parts.Add(auxPar);



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUEVOMONTOBILLETESID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"RETIRO_CAJA_DESDECORTE";

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


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    montobilletesId = (long) arParms[arParms.Length - 2].Value;
                }


                if (!(arParms[arParms.Length - 3].Value == System.DBNull.Value))
                {
                    doctoId = (long)arParms[arParms.Length - 3].Value;
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool RETIRO_CAJA_DELETE(CDOCTOBE oCDOCTO, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);




                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"RETIRO_CAJA_DELETE";

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




        public bool RETIRO_CAJA_CANCEL(CDOCTOBE oCDOCTO, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOCANCELARID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IID;
                parts.Add(auxPar);



                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = oCDOCTO.IVENDEDORID;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"RETIRO_CAJA_CANCEL";

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







        public bool RETIRO_CAJA_DELETEPENDIENTES(long corteId, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@CORTEID", FbDbType.BigInt);
                auxPar.Value = corteId;
                parts.Add(auxPar);




                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"RETIRO_CAJA_DELETEPENDIENTES";

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






        public bool RETIRO_MONTOSUPEROMAXIMO(long cajeroId, ref decimal totalCaja,  FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@CAJEROID", FbDbType.BigInt);
                auxPar.Value = cajeroId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTOSUPEROMAXIMO", FbDbType.VarChar);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@TOTALCAJA", FbDbType.Decimal);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"RETIRO_MONTOSUPEROMAXIMO";

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



                if (!(arParms[arParms.Length - 3].Value == System.DBNull.Value))
                {
                    totalCaja = (decimal)arParms[arParms.Length - 2].Value;
                    return arParms[arParms.Length - 3].Value.ToString() == "S";
                }


                return false;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }
        
        public CRETIRODECAJAD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            
        }

    }
}
