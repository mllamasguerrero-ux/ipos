using iPosBusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Collections;
using System.Data;


namespace iPosData
{

    public class CMPARM_SQLITE_D : IMPARMD
    {

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


        public bool CreateTableMPARM_MOVIL(string strOleDbConn)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(strOleDbConn);
            try
            {

                m_dbConnection.Open();

                string sql = @"CREATE TABLE Parametro ( 
                                                        MinUtilidad   DECIMAL,
                                                        DesgloseIeps   TEXT,
                                                        ListaPrecioMinimo INTEGER


                                        ); ";

                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                m_dbConnection.Close();
                m_dbConnection.Dispose();
                command.Dispose();

                GC.Collect();

            }
            catch { }
            finally { try { m_dbConnection.Close(); } catch { } }
            return true;
        }

        public bool AgregarM_PARMD(CM_PARMBE oCM_PARM, string strFileName,
                                    //OleDbTransaction st, 
                                    string strOleDbConn)
        {



            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                SQLiteParameter auxPar;



                auxPar = new SQLiteParameter("$MinUtilidad", DbType.Decimal);
                if (!(bool)oCM_PARM.isnull["IMINUTILIDAD"])
                {
                    auxPar.Value = oCM_PARM.IMINUTILIDAD;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$DesgloseIeps", DbType.String);
                if (!(bool)oCM_PARM.isnull["IDESGLOSEIEPS"])
                {
                    auxPar.Value = oCM_PARM.IDESGLOSEIEPS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new SQLiteParameter("$ListaPrecioMinimo", DbType.Int32);
                if (!(bool)oCM_PARM.isnull["ILISTAPRECIOMINIMO"])
                {
                    auxPar.Value = oCM_PARM.ILISTAPRECIOMINIMO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                string commandText = @"
        INSERT INTO   Parametro
      (
    
MinUtilidad,
DesgloseIeps,
ListaPrecioMinimo
         )

Values (

$MinUtilidad,
$DesgloseIeps,
$ListaPrecioMinimo

); ";

                SQLiteParameter[] arParms = new SQLiteParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                using (SQLiteConnection conn = new SQLiteConnection(strOleDbConn))
                {
                    conn.Open();
                    using (var cmd = new SQLiteCommand(commandText, conn))
                    {
                        using (SQLiteHelper sq = new SQLiteHelper(cmd))
                        {
                            sq.Execute(commandText, arParms);
                        }
                    }
                    conn.Close();
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
