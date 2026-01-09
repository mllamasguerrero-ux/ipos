
using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
//using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Data.OleDb;
using DataLayer;
using System.Collections;
using ConexionesBD;

namespace iPosData
{



    public class CQ_KITSD
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


        public bool AgregarQ_KITSD(CQ_KITSBE oCQ_KITS, string strFileName, OleDbTransaction st, string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                if (!(bool)oCQ_KITS.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCQ_KITS.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PARTE", OleDbType.VarChar);
                if (!(bool)oCQ_KITS.isnull["IPARTE"])
                {
                    auxPar.Value = oCQ_KITS.IPARTE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                if (!(bool)oCQ_KITS.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCQ_KITS.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTO", OleDbType.Double);
                if (!(bool)oCQ_KITS.isnull["ICOSTO"])
                {
                    auxPar.Value = oCQ_KITS.ICOSTO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ARMAR", OleDbType.VarChar);
                if (!(bool)oCQ_KITS.isnull["IARMAR"])
                {
                    auxPar.Value = oCQ_KITS.IARMAR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FALTANTE", OleDbType.Double);
                if (!(bool)oCQ_KITS.isnull["IFALTANTE"])
                {
                    auxPar.Value = oCQ_KITS.IFALTANTE;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCQ_KITS.isnull["IID"])
                {
                    auxPar.Value = oCQ_KITS.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCQ_KITS.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCQ_KITS.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCQ_KITS.isnull["IID_HORA"])
                {
                    auxPar.Value = oCQ_KITS.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO " + strFileName + @"
      (
    
PRODUCTO,

PARTE,

CANTIDAD,

COSTO,

ARMAR,

FALTANTE,

ID,

ID_FECHA,

ID_HORA
         )

Values (

?,

?,

?,

?,

?,

?,

?,

?,

?
); ";

                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    OleDbHelper.ExecuteNonQuery(strOleDbConn, CommandType.Text, commandText, arParms);
                else
                    OleDbHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        

        public CQ_KITSD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
