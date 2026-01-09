using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Collections;
using ConexionesBD;
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


    public class CUTILERIASD
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



        public CUTILERIASD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();

        }

        public bool DOCTO_PAGOS_PROCESO_RANGO(long tipoDoctoId, 
                                              long subTipoDoctoId, 
                                              DateTime fechaInicial, 
                                              DateTime fechaFinal, 
                                              long vendedorId, 
                                              long personaId, 
                                              String notas, 
                                              decimal montoMax, 
                                              FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@TIPODOCTOID", FbDbType.BigInt);
                auxPar.Value = tipoDoctoId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUBTIPODOCTOID", FbDbType.BigInt);
                auxPar.Value = subTipoDoctoId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAINICIAL", FbDbType.Date);
                auxPar.Value = fechaInicial;
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAFINAL", FbDbType.Date);
                auxPar.Value = fechaFinal;
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = vendedorId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                auxPar.Value = personaId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOTAS", FbDbType.VarChar);
                auxPar.Value = notas;
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTOMAX", FbDbType.Numeric);
                auxPar.Value = montoMax;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"DOCTO_PAGOS_PROCESO_RANGO";

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
    }
}

