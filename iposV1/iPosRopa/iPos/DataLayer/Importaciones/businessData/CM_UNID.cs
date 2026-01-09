
using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Data;
using System.Data.OleDb;
using DataLayer;
using System.Collections;
using ConexionesBD;


namespace iPosData
{


    [Transaction(TransactionOption.Supported)]


    public class CM_UNID
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
        public bool AgregarM_UNID(CM_UNIBE oCM_UNI, string strFileName, OleDbTransaction st, string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@CLAVE", OleDbType.VarChar);
                if (!(bool)oCM_UNI.isnull["ICLAVE"])
                {
                    auxPar.Value = oCM_UNI.ICLAVE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                if (!(bool)oCM_UNI.isnull["INOMBRE"])
                {
                    auxPar.Value = oCM_UNI.INOMBRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);





                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_UNI.isnull["IID"])
                {
                    auxPar.Value = oCM_UNI.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCM_UNI.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_UNI.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCM_UNI.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_UNI.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANTDEC", OleDbType.Numeric);
                if (!(bool)oCM_UNI.isnull["ICANTDEC"])
                {
                    auxPar.Value = oCM_UNI.ICANTDEC;
                }
                else
                {
                    auxPar.Value = 2;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CLAVESAT", OleDbType.VarChar);
                if (!(bool)oCM_UNI.isnull["ICLAVESAT"])
                {
                    auxPar.Value = oCM_UNI.ICLAVESAT;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO   " + strFileName + @" 
      (
    
CLAVE,

NOMBRE,

ID,

ID_FECHA,

ID_HORA,

CANTDEC, 

CLAVESAT
         )

Values (

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


       










        [AutoComplete]
        public DataSet enlistarCortoM_UNI()
        {
            DataSet retorno;
            try
            {

                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_M_UNI_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }






        public CM_UNID()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
        }
    }
}
