
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
    
    public class CM_TRCLD
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
        
        public bool AgregarM_TRCLD(CM_TRCLBE oCM_TRCL, string strFileName, OleDbTransaction st, string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                if (!(bool)oCM_TRCL.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCM_TRCL.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PROD2", OleDbType.VarChar);
                if (!(bool)oCM_TRCL.isnull["IPROD2"])
                {
                    auxPar.Value = oCM_TRCL.IPROD2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                


                auxPar = new OleDbParameter("@FECHA", OleDbType.Date);
                if (!(bool)oCM_TRCL.isnull["IFECHA"])
                {
                    auxPar.Value = oCM_TRCL.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_TRCL.isnull["IID"])
                {
                    auxPar.Value = oCM_TRCL.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCM_TRCL.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_TRCL.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCM_TRCL.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_TRCL.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO   " + strFileName + @" 
      (
    
PRODUCTO,

PROD2,

FECHA,

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

        

        

        public CM_TRCLD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
