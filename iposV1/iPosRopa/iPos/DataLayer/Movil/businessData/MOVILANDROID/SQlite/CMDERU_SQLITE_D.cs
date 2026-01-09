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

    public class CMDERU_SQLITE_D : IMDERUD
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


        public bool CreateTableMDERU_MOVIL(string strOleDbConn)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(strOleDbConn);
            try
            {

                m_dbConnection.Open();

                string sql = @"CREATE TABLE DerechoUsuario ( 
                                                        ClaveDerecho   TEXT,
                                                        ClaveUsuario   TEXT



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

        public bool AgregarM_DER_UD(CM_DER_UBE oCM_DER_U, string strFileName,
                                    //OleDbTransaction st, 
                                    string strOleDbConn)
        {



            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                SQLiteParameter auxPar;




                auxPar = new SQLiteParameter("$ClaveDerecho", DbType.String);
                if (!(bool)oCM_DER_U.isnull["ICLAVEDERECHO"])
                {
                    auxPar.Value = oCM_DER_U.ICLAVEDERECHO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$ClaveUsuario", DbType.String);
                if (!(bool)oCM_DER_U.isnull["ICLAVEUSUARIO"])
                {
                    auxPar.Value = oCM_DER_U.ICLAVEUSUARIO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);





                string commandText = @"
        INSERT INTO   DerechoUsuario
      (
    
ClaveDerecho,
ClaveUsuario

         )

Values (

$ClaveDerecho,
$ClaveUsuario

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
