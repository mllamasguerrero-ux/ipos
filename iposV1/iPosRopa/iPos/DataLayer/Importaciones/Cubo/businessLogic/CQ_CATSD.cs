
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



    public class CQ_CATSD
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


        public bool AgregarQ_CATSD(CQ_CATSBE oCQ_CATS, string strFileName, OleDbTransaction st, string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                if (!(bool)oCQ_CATS.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCQ_CATS.ICLIENTE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                if (!(bool)oCQ_CATS.isnull["INOMBRE"])
                {
                    auxPar.Value = oCQ_CATS.INOMBRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SUCURSAL", OleDbType.VarChar);
                if (!(bool)oCQ_CATS.isnull["ISUCURSAL"])
                {
                    auxPar.Value = oCQ_CATS.ISUCURSAL;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTAR", OleDbType.Boolean);
                if (!(bool)oCQ_CATS.isnull["IIMPORTAR"])
                {
                    auxPar.Value = oCQ_CATS.IIMPORTAR;
                }
                else
                {
                    auxPar.Value = false;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ACTIVA", OleDbType.VarChar);
                if (!(bool)oCQ_CATS.isnull["IACTIVA"])
                {
                    auxPar.Value = oCQ_CATS.IACTIVA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@BWCOLOR", OleDbType.VarChar);
                if (!(bool)oCQ_CATS.isnull["IBWCOLOR"])
                {
                    auxPar.Value = oCQ_CATS.IBWCOLOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FINSEMANA", OleDbType.VarChar);
                if (!(bool)oCQ_CATS.isnull["IFINSEMANA"])
                {
                    auxPar.Value = oCQ_CATS.IFINSEMANA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCQ_CATS.isnull["IID"])
                {
                    auxPar.Value = oCQ_CATS.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCQ_CATS.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCQ_CATS.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCQ_CATS.isnull["IID_HORA"])
                {
                    auxPar.Value = oCQ_CATS.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SUCU", OleDbType.VarChar);
                if (!(bool)oCQ_CATS.isnull["ISUCU"])
                {
                    auxPar.Value = oCQ_CATS.ISUCU;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTRATEGIC", OleDbType.VarChar);
                if (!(bool)oCQ_CATS.isnull["IESTRATEGIC"])
                {
                    auxPar.Value = oCQ_CATS.IESTRATEGIC;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@BANCOS", OleDbType.VarChar);
                if (!(bool)oCQ_CATS.isnull["IBANCOS"])
                {
                    auxPar.Value = oCQ_CATS.IBANCOS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@BANCOS2", OleDbType.VarChar);
                if (!(bool)oCQ_CATS.isnull["IBANCOS2"])
                {
                    auxPar.Value = oCQ_CATS.IBANCOS2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE2", OleDbType.VarChar);
                if (!(bool)oCQ_CATS.isnull["INOMBRE2"])
                {
                    auxPar.Value = oCQ_CATS.INOMBRE2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@GRUPO", OleDbType.VarChar);
                if (!(bool)oCQ_CATS.isnull["IGRUPO"])
                {
                    auxPar.Value = oCQ_CATS.IGRUPO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMER", OleDbType.VarChar);
                if (!(bool)oCQ_CATS.isnull["ICOMER"])
                {
                    auxPar.Value = oCQ_CATS.ICOMER;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SIS_ANTER", OleDbType.VarChar);
                if (!(bool)oCQ_CATS.isnull["ISIS_ANTER"])
                {
                    auxPar.Value = oCQ_CATS.ISIS_ANTER;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESC", OleDbType.VarChar);
                if (!(bool)oCQ_CATS.isnull["IDESC"])
                {
                    auxPar.Value = oCQ_CATS.IDESC;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO " + strFileName + @"
      (
    
CLIENTE,

NOMBRE,

SUCURSAL,

IMPORTAR,

ACTIVA,

BWCOLOR,

FINSEMANA,

ID,

ID_FECHA,

ID_HORA,

SUCU,

ESTRATEGIC,

BANCOS,

BANCOS2,

NOMBRE2,

GRUPO,

COMER,

SIS_ANTER,

DESC
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
        

        public CQ_CATSD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
