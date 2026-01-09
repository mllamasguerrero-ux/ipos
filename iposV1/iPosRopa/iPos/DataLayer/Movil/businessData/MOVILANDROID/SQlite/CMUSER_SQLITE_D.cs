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

    public class CMUSER_SQLITE_D: IMUSERD
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


        public bool CreateTableMUSER_MOVIL(string strOleDbConn)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(strOleDbConn);
            try
            {

                m_dbConnection.Open();

                string sql = @"CREATE TABLE Usuario (     Clave   TEXT,
                                                        Nombre   TEXT,
                                                        ExportAut   TEXT,
                                                        Impresora   TEXT,
                                                        Vendedor   TEXT,
                                                        Password   TEXT,
                                                        CajasBotellas TEXT



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

        public bool AgregarM_USERD(CM_USERBE oCM_USER, string strFileName,
                                    //OleDbTransaction st, 
                                    string strOleDbConn)
        {



            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                SQLiteParameter auxPar;




                auxPar = new SQLiteParameter("$Clave", DbType.String);
                if (!(bool)oCM_USER.isnull["ICLAVE"])
                {
                    auxPar.Value = oCM_USER.ICLAVE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$Nombre", DbType.String);
                if (!(bool)oCM_USER.isnull["INOMBRE"])
                {
                    auxPar.Value = oCM_USER.INOMBRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$ExportAut", DbType.String);
                if (!(bool)oCM_USER.isnull["IEXPORTAUT"])
                {
                    auxPar.Value = oCM_USER.IEXPORTAUT;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$Impresora", DbType.String);
                if (!(bool)oCM_USER.isnull["IIMPRESORA"])
                {
                    auxPar.Value = oCM_USER.IIMPRESORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$Vendedor", DbType.String);
                if (!(bool)oCM_USER.isnull["IVENDEDOR"])
                {
                    auxPar.Value = oCM_USER.IVENDEDOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$Password", DbType.String);
                if (!(bool)oCM_USER.isnull["IPASSWORD"])
                {
                    auxPar.Value = oCM_USER.IPASSWORD;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$CajasBotellas", DbType.String);
                if (!(bool)oCM_USER.isnull["ICAJASBOTELLAS"])
                {
                    auxPar.Value = oCM_USER.ICAJASBOTELLAS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                string commandText = @"
        INSERT INTO   Usuario
      (
    
Clave,
Nombre,
ExportAut,
Impresora,
Vendedor,
Password,
CajasBotellas
         )

Values (

$Clave,
$Nombre,
$ExportAut,
$Impresora,
$Vendedor,
$Password,
$CajasBotellas

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
