using ConexionesBD;
using DataLayer;
using iPosBusinessEntity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPosData
{
    public class CM_PLAZOD
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

        public bool AgregarM_PLAZOD(CM_PLAZOBE oCM_BANK, string strFileName, OleDbTransaction st, string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;


                auxPar = new OleDbParameter("@ACTIVO", OleDbType.Char);
                if (!(bool)oCM_BANK.isnull["IACTIVO"])
                {
                    auxPar.Value = oCM_BANK.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLAVE", OleDbType.VarChar);
                if (!(bool)oCM_BANK.isnull["ICLAVE"])
                {
                    auxPar.Value = oCM_BANK.ICLAVE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                if (!(bool)oCM_BANK.isnull["INOMBRE"])
                {
                    auxPar.Value = oCM_BANK.INOMBRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ICOMISIONST", OleDbType.VarChar);
                if (!(bool)oCM_BANK.isnull["ICOMISIONST"])
                {
                    auxPar.Value = oCM_BANK.ICOMISIONST;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@LEYENDA", OleDbType.VarChar);
                if (!(bool)oCM_BANK.isnull["ILEYENDA"])
                {
                    auxPar.Value = oCM_BANK.ILEYENDA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DIAS", OleDbType.Integer);
                if (!(bool)oCM_BANK.isnull["IDIAS"])
                {
                    auxPar.Value = oCM_BANK.IDIAS;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO   " + strFileName + @" 
      (
ACTIVO,    

CLAVE,

NOMBRE,

COMISIONST,

LEYENDA,

DIAS
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

        public CM_PLAZOD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
        }
    }
}
