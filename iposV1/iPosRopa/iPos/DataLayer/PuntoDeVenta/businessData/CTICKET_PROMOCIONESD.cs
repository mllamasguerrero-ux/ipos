
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

    [Transaction(TransactionOption.Supported)]


    public class CTICKET_PROMOCIONESD
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



        public CTICKET_PROMOCIONESBE[] seleccionarTICKET_PROMOCIONES(long doctoId,  FbTransaction st)
        {

            CTICKET_PROMOCIONESBE retorno;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            System.Collections.ArrayList buffDetails = new ArrayList();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from  TICKET_PROMOCIONESAPLICADAS" + @" where DOCTOID=@DOCTOID ";


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);





                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                while (dr.Read())
                {
                    retorno = new CTICKET_PROMOCIONESBE();

                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOID = (long)(dr["DOCTOID"]);
                    }

                    if (dr["MOVTOID"] != System.DBNull.Value)
                    {
                        retorno.IMOVTOID = (long)(dr["MOVTOID"]);
                    }

                    
                    if (dr["DESCRIPCION1"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION1 = (string)(dr["DESCRIPCION1"]);
                    }

                    if (dr["DESCRIPCION2"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION2 = (string)(dr["DESCRIPCION2"]);
                    }

                    if (dr["PROMOCIONDESGLOSE"] != System.DBNull.Value)
                    {
                        retorno.IPROMOCIONDESGLOSE = (string)(dr["PROMOCIONDESGLOSE"]);
                    }


                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDAD = (decimal)(dr["CANTIDAD"]);
                    }

                    if (dr["PRECIO"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO = (decimal)(dr["PRECIO"]);
                    }

                    if (dr["PRECIOSINDESCUENTO"] != System.DBNull.Value)
                    {
                        retorno.IPRECIOSINDESCUENTO = (decimal)(dr["PRECIOSINDESCUENTO"]);
                    }

                    if (dr["TOTAL"] != System.DBNull.Value)
                    {
                        retorno.ITOTAL = (decimal)(dr["TOTAL"]);
                    }

                    if (dr["TOTALSINDESCUENTO"] != System.DBNull.Value)
                    {
                        retorno.ITOTALSINDESCUENTO = (decimal)(dr["TOTALSINDESCUENTO"]);
                    }

                    buffDetails.Add(retorno);

                }

                CTICKET_PROMOCIONESBE[] detailList = new CTICKET_PROMOCIONESBE[buffDetails.Count];
                buffDetails.CopyTo(detailList, 0);


                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return detailList;


            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }








        public CTICKET_PROMOCIONESD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
