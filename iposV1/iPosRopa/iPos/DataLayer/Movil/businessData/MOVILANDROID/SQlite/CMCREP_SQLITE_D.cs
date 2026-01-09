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
    public class CMCREP_SQLITE_D:IMCREPD
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


        public bool CreateTableMCREP_MOVIL(string strOleDbConn)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(strOleDbConn);
            try
            {

                m_dbConnection.Open();

                string sql = @"CREATE TABLE MCREP ( COBRANZA TEXT ,
                                                    VENDEDOR TEXT ,
                                                    VENTA TEXT ,
                                                    EMPRESA TEXT ,
                                                    CLIENTE TEXT ,
                                                    NOMBRE TEXT ,
                                                    FACTURA TEXT ,
                                                    ESTATUS TEXT ,
                                                    OBS TEXT ,
                                                    F_FACTURA TEXT ,
                                                    F_PAGO TEXT ,
                                                    DIAS NUMERIC ,
                                                    TOTAL NUMERIC ,
                                                    A_CUENTA NUMERIC ,
                                                    SALDO NUMERIC ,
                                                    INT_COB NUMERIC ,
                                                    INTERESES NUMERIC ,
                                                    IMPOR_NETO NUMERIC ,
                                                    PAGO NUMERIC ,
                                                    EFECTIVO NUMERIC ,
                                                    DIFERENCIA NUMERIC ,
                                                    IMP_CHEQUE NUMERIC ,
                                                    BANCO TEXT ,
                                                    NUM_CHEQ NUMERIC ,
                                                    INTERES NUMERIC ,
                                                    CAPITAL NUMERIC ,
                                                    OLLA TEXT ,
                                                    BLOQUEADO TEXT ,
                                                    FECHA TEXT ,
                                                    LLEVAR TEXT ,
                                                    ID TEXT ,
                                                    ID_FECHA TEXT ,
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



        public bool AgregarM_CREPD(CM_CREPBE oCM_CREP, string strFileName,
                                    string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                SQLiteParameter auxPar;



                auxPar = new SQLiteParameter("$COBRANZA", DbType.String);
                if (!(bool)oCM_CREP.isnull["ICOBRANZA"])
                {
                    auxPar.Value = oCM_CREP.ICOBRANZA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$VENDEDOR", DbType.String);
                if (!(bool)oCM_CREP.isnull["IVENDEDOR"])
                {
                    auxPar.Value = oCM_CREP.IVENDEDOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$VENTA", DbType.String);
                if (!(bool)oCM_CREP.isnull["IVENTA"])
                {
                    auxPar.Value = oCM_CREP.IVENTA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$EMPRESA", DbType.String);
                if (!(bool)oCM_CREP.isnull["IEMPRESA"])
                {
                    auxPar.Value = oCM_CREP.IEMPRESA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$CLIENTE", DbType.String);
                if (!(bool)oCM_CREP.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCM_CREP.ICLIENTE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$NOMBRE", DbType.String);
                if (!(bool)oCM_CREP.isnull["INOMBRE"])
                {
                    auxPar.Value = oCM_CREP.INOMBRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$FACTURA", DbType.String);
                if (!(bool)oCM_CREP.isnull["IFACTURA"])
                {
                    auxPar.Value = oCM_CREP.IFACTURA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$ESTATUS", DbType.String);
                if (!(bool)oCM_CREP.isnull["IESTATUS"])
                {
                    auxPar.Value = oCM_CREP.IESTATUS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$OBS", DbType.String);
                if (!(bool)oCM_CREP.isnull["IOBS"])
                {
                    auxPar.Value = oCM_CREP.IOBS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$F_FACTURA", DbType.Date);
                if (!(bool)oCM_CREP.isnull["IF_FACTURA"])
                {
                    auxPar.Value = oCM_CREP.IF_FACTURA;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$F_PAGO", DbType.Date);
                if (!(bool)oCM_CREP.isnull["IF_PAGO"])
                {
                    auxPar.Value = oCM_CREP.IF_PAGO;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$DIAS", DbType.Double);
                if (!(bool)oCM_CREP.isnull["IDIAS"])
                {
                    auxPar.Value = (double)oCM_CREP.IDIAS;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$TOTAL", DbType.Double);
                if (!(bool)oCM_CREP.isnull["ITOTAL"])
                {
                    auxPar.Value = (double)oCM_CREP.ITOTAL;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$A_CUENTA", DbType.Double);
                if (!(bool)oCM_CREP.isnull["IA_CUENTA"])
                {
                    auxPar.Value = (double)oCM_CREP.IA_CUENTA;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$SALDO", DbType.Double);
                if (!(bool)oCM_CREP.isnull["ISALDO"])
                {
                    auxPar.Value = (double)oCM_CREP.ISALDO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$INT_COB", DbType.Double);
                if (!(bool)oCM_CREP.isnull["IINT_COB"])
                {
                    auxPar.Value = (double)oCM_CREP.IINT_COB;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$INTERESES", DbType.Double);
                if (!(bool)oCM_CREP.isnull["IINTERESES"])
                {
                    auxPar.Value = (double)oCM_CREP.IINTERESES;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$IMPOR_NETO", DbType.Double);
                if (!(bool)oCM_CREP.isnull["IIMPOR_NETO"])
                {
                    auxPar.Value = (double)oCM_CREP.IIMPOR_NETO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$PAGO", DbType.Double);
                if (!(bool)oCM_CREP.isnull["IPAGO"])
                {
                    auxPar.Value = (double)oCM_CREP.IPAGO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$EFECTIVO", DbType.Double);
                if (!(bool)oCM_CREP.isnull["IEFECTIVO"])
                {
                    auxPar.Value = (double)oCM_CREP.IEFECTIVO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$DIFERENCIA", DbType.Double);
                if (!(bool)oCM_CREP.isnull["IDIFERENCIA"])
                {
                    auxPar.Value = (double)oCM_CREP.IDIFERENCIA;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$IMP_CHEQUE", DbType.Double);
                if (!(bool)oCM_CREP.isnull["IIMP_CHEQUE"])
                {
                    auxPar.Value = (double)oCM_CREP.IIMP_CHEQUE;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$BANCO", DbType.String);
                if (!(bool)oCM_CREP.isnull["IBANCO"])
                {
                    auxPar.Value = oCM_CREP.IBANCO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$NUM_CHEQ", DbType.Double);
                if (!(bool)oCM_CREP.isnull["INUM_CHEQ"])
                {
                    auxPar.Value = (double)oCM_CREP.INUM_CHEQ;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$INTERES", DbType.Double);
                if (!(bool)oCM_CREP.isnull["IINTERES"])
                {
                    auxPar.Value = (double)oCM_CREP.IINTERES;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$CAPITAL", DbType.Double);
                if (!(bool)oCM_CREP.isnull["ICAPITAL"])
                {
                    auxPar.Value = (double)oCM_CREP.ICAPITAL;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$OLLA", DbType.String);
                if (!(bool)oCM_CREP.isnull["IOLLA"])
                {
                    auxPar.Value = oCM_CREP.IOLLA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$BLOQUEADO", DbType.String);
                if (!(bool)oCM_CREP.isnull["IBLOQUEADO"])
                {
                    auxPar.Value = oCM_CREP.IBLOQUEADO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$FECHA", DbType.Date);
                if (!(bool)oCM_CREP.isnull["IFECHA"])
                {
                    auxPar.Value = oCM_CREP.IFECHA;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$LLEVAR", DbType.String);
                if (!(bool)oCM_CREP.isnull["ILLEVAR"])
                {
                    auxPar.Value = oCM_CREP.ILLEVAR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$ID", DbType.String);
                if (!(bool)oCM_CREP.isnull["IID"])
                {
                    auxPar.Value = oCM_CREP.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$ID_FECHA", DbType.Date);
                if (!(bool)oCM_CREP.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_CREP.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new SQLiteParameter("$ID_HORA", DbType.String);
                if (!(bool)oCM_CREP.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_CREP.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO   MCREP 
      (
    
COBRANZA,

VENDEDOR,

VENTA,

EMPRESA,

CLIENTE,

NOMBRE,

FACTURA,

ESTATUS,

OBS,

F_FACTURA,

F_PAGO,

DIAS,

TOTAL,

A_CUENTA,

SALDO,

INT_COB,

INTERESES,

IMPOR_NETO,

PAGO,

EFECTIVO,

DIFERENCIA,

IMP_CHEQUE,

BANCO,

NUM_CHEQ,

INTERES,

CAPITAL,

OLLA,

BLOQUEADO,

FECHA,

LLEVAR,

ID,

ID_FECHA,

ID_HORA
         )

Values (

$COBRANZA ,
$VENDEDOR ,
$VENTA ,
$EMPRESA ,
$CLIENTE ,
$NOMBRE ,
$FACTURA ,
$ESTATUS ,
$OBS ,
$F_FACTURA ,
$F_PAGO ,
$DIAS ,
$TOTAL ,
$A_CUENTA ,
$SALDO ,
$INT_COB ,
$INTERESES ,
$IMPOR_NETO ,
$PAGO ,
$EFECTIVO ,
$DIFERENCIA ,
$IMP_CHEQUE ,
$BANCO ,
$NUM_CHEQ ,
$INTERES ,
$CAPITAL ,
$OLLA ,
$BLOQUEADO ,
$FECHA ,
$LLEVAR ,
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
