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
    public class CMKIT_SQLITE_D : IMKITSD
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


        public bool CreateTableMKITS_MOVIL(string strOleDbConn)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(strOleDbConn);
            try
            {

                m_dbConnection.Open();

                string sql = @"CREATE TABLE MKITS ( PRODUCTO TEXT,
                                                    PARTE TEXT,
                                                    CANTIDAD NUMERIC,
                                                    COSTO NUMERIC,
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

        public bool AgregarM_KITSD(CM_KITSBE oCM_KITS, string strFileName,
                                    string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                SQLiteParameter auxPar;



                auxPar = new SQLiteParameter("$PRODUCTO", DbType.String);
                if (!(bool)oCM_KITS.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCM_KITS.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$PARTE", DbType.String);
                if (!(bool)oCM_KITS.isnull["IPARTE"])
                {
                    auxPar.Value = oCM_KITS.IPARTE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$CANTIDAD", DbType.Double);
                if (!(bool)oCM_KITS.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCM_KITS.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = 0.0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$COSTO", DbType.Double);
                if (!(bool)oCM_KITS.isnull["ICOSTO"])
                {
                    auxPar.Value = oCM_KITS.ICOSTO;
                }
                else
                {
                    auxPar.Value = 0.0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$ID", DbType.String);
                if (!(bool)oCM_KITS.isnull["IID"])
                {
                    auxPar.Value = oCM_KITS.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$ID_FECHA", DbType.Date);
                if (!(bool)oCM_KITS.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_KITS.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$ID_HORA", DbType.String);
                if (!(bool)oCM_KITS.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_KITS.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO MKITS
      (
    
PRODUCTO,
PARTE,
CANTIDAD,
COSTO,
ID,
ID_FECHA,
ID_HORA
         )

Values (
$PRODUCTO ,
$PARTE ,
$CANTIDAD ,
$COSTO ,
$ID ,
$ID_FECHA ,
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
                }





                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return true;
            }
        }
    }
}
