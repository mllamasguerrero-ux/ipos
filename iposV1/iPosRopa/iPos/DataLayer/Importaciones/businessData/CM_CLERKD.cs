
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



    public class CM_CLERKD
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


        public bool AgregarM_CLERKD(CM_CLERKBE oCM_CLERK, string strFileName, OleDbTransaction st, string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@CLERK", OleDbType.VarChar);
                if (!(bool)oCM_CLERK.isnull["ICLERK"])
                {
                    auxPar.Value = oCM_CLERK.ICLERK;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SUCCLAVE", OleDbType.VarChar);
                if (!(bool)oCM_CLERK.isnull["ISUCCLAVE"])
                {
                    auxPar.Value = oCM_CLERK.ISUCCLAVE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESSERV", OleDbType.VarChar);
                if (!(bool)oCM_CLERK.isnull["IESSERV"])
                {
                    auxPar.Value = oCM_CLERK.IESSERV;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);




                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_CLERK.isnull["IID"])
                {
                    auxPar.Value = oCM_CLERK.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCM_CLERK.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_CLERK.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCM_CLERK.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_CLERK.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO   " + strFileName + @" 
      (
    
CLERK,

SUCCLAVE,

ESSERV,

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
    }
}