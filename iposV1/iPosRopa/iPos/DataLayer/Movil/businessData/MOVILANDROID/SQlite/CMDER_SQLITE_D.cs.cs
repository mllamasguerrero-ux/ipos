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

    public class CMDER_SQLITE_D : IMDERD
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


        public bool CreateTableMDER_MOVIL(string strOleDbConn)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(strOleDbConn);
            try
            {

                m_dbConnection.Open();

                string sql = @"CREATE TABLE Derecho ( 
                                                        Clave   TEXT,
                                                        Nombre   TEXT
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

        public bool AgregarM_DERD(CM_DERBE oCM_DER, string strFileName,
                                    //OleDbTransaction st, 
                                    string strOleDbConn)
        {



            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                SQLiteParameter auxPar;




                auxPar = new SQLiteParameter("$Clave", DbType.String);
                if (!(bool)oCM_DER.isnull["ICLAVE"])
                {
                    auxPar.Value = oCM_DER.ICLAVE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$Nombre", DbType.String);
                if (!(bool)oCM_DER.isnull["INOMBRE"])
                {
                    auxPar.Value = oCM_DER.INOMBRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);





                string commandText = @"
        INSERT INTO   Derecho
      (
    
Clave,
Nombre
         )

Values (

$Clave,
$Nombre

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
                    conn.Dispose();
                    GC.Collect();
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
