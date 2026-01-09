
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



    public class CQ_LINED
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


        public bool AgregarQ_LINED(CQ_LINEBE oCQ_LINE, string strFileName, OleDbTransaction st, string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@LINEA", OleDbType.VarChar);
                if (!(bool)oCQ_LINE.isnull["ILINEA"])
                {
                    auxPar.Value = oCQ_LINE.ILINEA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                if (!(bool)oCQ_LINE.isnull["INOMBRE"])
                {
                    auxPar.Value = oCQ_LINE.INOMBRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                if (!(bool)oCQ_LINE.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCQ_LINE.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Double);
                if (!(bool)oCQ_LINE.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCQ_LINE.IIMPORTE;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PLAZO", OleDbType.VarChar);
                if (!(bool)oCQ_LINE.isnull["IPLAZO"])
                {
                    auxPar.Value = oCQ_LINE.IPLAZO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCQ_LINE.isnull["IID"])
                {
                    auxPar.Value = oCQ_LINE.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCQ_LINE.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCQ_LINE.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCQ_LINE.isnull["IID_HORA"])
                {
                    auxPar.Value = oCQ_LINE.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTRATEGIC", OleDbType.VarChar);
                if (!(bool)oCQ_LINE.isnull["IESTRATEGIC"])
                {
                    auxPar.Value = oCQ_LINE.IESTRATEGIC;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PCLIENTE", OleDbType.VarChar);
                if (!(bool)oCQ_LINE.isnull["IPCLIENTE"])
                {
                    auxPar.Value = oCQ_LINE.IPCLIENTE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PPRODUCTO", OleDbType.VarChar);
                if (!(bool)oCQ_LINE.isnull["IPPRODUCTO"])
                {
                    auxPar.Value = oCQ_LINE.IPPRODUCTO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PVENDEDOR", OleDbType.VarChar);
                if (!(bool)oCQ_LINE.isnull["IPVENDEDOR"])
                {
                    auxPar.Value = oCQ_LINE.IPVENDEDOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PMARCA", OleDbType.VarChar);
                if (!(bool)oCQ_LINE.isnull["IPMARCA"])
                {
                    auxPar.Value = oCQ_LINE.IPMARCA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PPROVEEDOR", OleDbType.VarChar);
                if (!(bool)oCQ_LINE.isnull["IPPROVEEDOR"])
                {
                    auxPar.Value = oCQ_LINE.IPPROVEEDOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PCIUDAD", OleDbType.VarChar);
                if (!(bool)oCQ_LINE.isnull["IPCIUDAD"])
                {
                    auxPar.Value = oCQ_LINE.IPCIUDAD;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO " + strFileName  +  @"
      (
    
LINEA,

NOMBRE,

CANTIDAD,

IMPORTE,

PLAZO,

ID,

ID_FECHA,

ID_HORA,

ESTRATEGIC,

PCLIENTE,

PPRODUCTO,

PVENDEDOR,

PMARCA,

PPROVEEDOR,

PCIUDAD
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

        


        public CQ_LINED()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
