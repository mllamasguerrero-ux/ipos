
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

    [Transaction(TransactionOption.Supported)]


    public class CM_ARDRD
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


        [AutoComplete]
        public bool AgregarM_ARDRD(CM_ARDRBE oCM_ARDR, string strFileName, OleDbTransaction st, string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@AREA", OleDbType.VarChar);
                if (!(bool)oCM_ARDR.isnull["IAREA"])
                {
                    auxPar.Value = oCM_ARDR.IAREA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DERECHO", OleDbType.Numeric);
                if (!(bool)oCM_ARDR.isnull["IDERECHO"])
                {
                    auxPar.Value = oCM_ARDR.IDERECHO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_ARDR.isnull["IID"])
                {
                    auxPar.Value = oCM_ARDR.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCM_ARDR.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_ARDR.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCM_ARDR.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_ARDR.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);








                string commandText = @"
        INSERT INTO M_ARDR
      (
    
AREA,

DERECHO,

ID,

ID_FECHA,

ID_HORA

         )

Values (

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








        public CM_ARDRD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
