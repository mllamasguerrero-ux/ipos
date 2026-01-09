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
    public class CMEDOS_SQLITE_D : IMEDOSD
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


        public bool CreateTableMEDOS_MOVIL(string strOleDbConn)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(strOleDbConn);
            try
            {

                m_dbConnection.Open();

                string sql = @"CREATE TABLE MEDOS ( 
                                        CLAVE TEXT,
                                        NOMBRE TEXT,
                                        ID TEXT,
                                        ID_FECHA TEXT,
                                        ID_HORA TEXT


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

        public bool AgregarM_EDOSD(CM_EDOSBE oCM_EDOS, string strFileName,
                                    //OleDbTransaction st, 
                                    string strOleDbConn)
        {



            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                SQLiteParameter auxPar;



                auxPar = new SQLiteParameter("$CLAVE", DbType.String);
                if (!(bool)oCM_EDOS.isnull["ICLAVE"])
                {
                    auxPar.Value = oCM_EDOS.ICLAVE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$NOMBRE", DbType.String);
                if (!(bool)oCM_EDOS.isnull["INOMBRE"])
                {
                    auxPar.Value = oCM_EDOS.INOMBRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new SQLiteParameter("$ID", DbType.String);
                if (!(bool)oCM_EDOS.isnull["IID"])
                {
                    auxPar.Value = oCM_EDOS.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$ID_FECHA", DbType.Date);
                if (!(bool)oCM_EDOS.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_EDOS.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$ID_HORA", DbType.String);
                if (!(bool)oCM_EDOS.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_EDOS.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO   MEDOS
      (
    
CLAVE,
NOMBRE,
ID,
ID_FECHA,
ID_HORA
         )

Values (

$CLAVE,
$NOMBRE,
$ID,
$ID_FECHA,
$ID_HORA

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
