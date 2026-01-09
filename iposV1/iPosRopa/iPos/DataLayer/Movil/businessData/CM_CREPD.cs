


using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Data;
using System.Collections;
using ConexionesBD;
using System.Data.OleDb;
using DataLayer;

namespace iPosData
{



    public class CM_CREPD: IMCREPD
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



        public bool AgregarM_CREPD(CM_CREPBE oCM_CREP, string strFileName, 
                                    //OleDbTransaction st, 
                                    string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@COBRANZA", OleDbType.VarChar);
                if (!(bool)oCM_CREP.isnull["ICOBRANZA"])
                {
                    auxPar.Value = oCM_CREP.ICOBRANZA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VENDEDOR", OleDbType.VarChar);
                if (!(bool)oCM_CREP.isnull["IVENDEDOR"])
                {
                    auxPar.Value = oCM_CREP.IVENDEDOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VENTA", OleDbType.VarChar);
                if (!(bool)oCM_CREP.isnull["IVENTA"])
                {
                    auxPar.Value = oCM_CREP.IVENTA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EMPRESA", OleDbType.VarChar);
                if (!(bool)oCM_CREP.isnull["IEMPRESA"])
                {
                    auxPar.Value = oCM_CREP.IEMPRESA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                if (!(bool)oCM_CREP.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCM_CREP.ICLIENTE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                if (!(bool)oCM_CREP.isnull["INOMBRE"])
                {
                    auxPar.Value = oCM_CREP.INOMBRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FACTURA", OleDbType.VarChar);
                if (!(bool)oCM_CREP.isnull["IFACTURA"])
                {
                    auxPar.Value = oCM_CREP.IFACTURA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTATUS", OleDbType.VarChar);
                if (!(bool)oCM_CREP.isnull["IESTATUS"])
                {
                    auxPar.Value = oCM_CREP.IESTATUS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@OBS", OleDbType.VarChar);
                if (!(bool)oCM_CREP.isnull["IOBS"])
                {
                    auxPar.Value = oCM_CREP.IOBS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@F_FACTURA", OleDbType.Date);
                if (!(bool)oCM_CREP.isnull["IF_FACTURA"])
                {
                    auxPar.Value = oCM_CREP.IF_FACTURA;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@F_PAGO", OleDbType.Date);
                if (!(bool)oCM_CREP.isnull["IF_PAGO"])
                {
                    auxPar.Value = oCM_CREP.IF_PAGO;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DIAS", OleDbType.Double);
                if (!(bool)oCM_CREP.isnull["IDIAS"])
                {
                    auxPar.Value = (double)oCM_CREP.IDIAS;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TOTAL", OleDbType.Double);
                if (!(bool)oCM_CREP.isnull["ITOTAL"])
                {
                    auxPar.Value = (double)oCM_CREP.ITOTAL;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@A_CUENTA", OleDbType.Double);
                if (!(bool)oCM_CREP.isnull["IA_CUENTA"])
                {
                    auxPar.Value = (double)oCM_CREP.IA_CUENTA;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SALDO", OleDbType.Double);
                if (!(bool)oCM_CREP.isnull["ISALDO"])
                {
                    auxPar.Value = (double)oCM_CREP.ISALDO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@INT_COB", OleDbType.Double);
                if (!(bool)oCM_CREP.isnull["IINT_COB"])
                {
                    auxPar.Value = (double)oCM_CREP.IINT_COB;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@INTERESES", OleDbType.Double);
                if (!(bool)oCM_CREP.isnull["IINTERESES"])
                {
                    auxPar.Value = (double)oCM_CREP.IINTERESES;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPOR_NETO", OleDbType.Double);
                if (!(bool)oCM_CREP.isnull["IIMPOR_NETO"])
                {
                    auxPar.Value = (double)oCM_CREP.IIMPOR_NETO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PAGO", OleDbType.Double);
                if (!(bool)oCM_CREP.isnull["IPAGO"])
                {
                    auxPar.Value = (double)oCM_CREP.IPAGO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EFECTIVO", OleDbType.Double);
                if (!(bool)oCM_CREP.isnull["IEFECTIVO"])
                {
                    auxPar.Value = (double)oCM_CREP.IEFECTIVO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DIFERENCIA", OleDbType.Double);
                if (!(bool)oCM_CREP.isnull["IDIFERENCIA"])
                {
                    auxPar.Value = (double)oCM_CREP.IDIFERENCIA;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMP_CHEQUE", OleDbType.Double);
                if (!(bool)oCM_CREP.isnull["IIMP_CHEQUE"])
                {
                    auxPar.Value = (double)oCM_CREP.IIMP_CHEQUE;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@BANCO", OleDbType.VarChar);
                if (!(bool)oCM_CREP.isnull["IBANCO"])
                {
                    auxPar.Value = oCM_CREP.IBANCO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NUM_CHEQ", OleDbType.Double);
                if (!(bool)oCM_CREP.isnull["INUM_CHEQ"])
                {
                    auxPar.Value = (double)oCM_CREP.INUM_CHEQ;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@INTERES", OleDbType.Double);
                if (!(bool)oCM_CREP.isnull["IINTERES"])
                {
                    auxPar.Value = (double)oCM_CREP.IINTERES;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CAPITAL", OleDbType.Double);
                if (!(bool)oCM_CREP.isnull["ICAPITAL"])
                {
                    auxPar.Value = (double)oCM_CREP.ICAPITAL;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@OLLA", OleDbType.VarChar);
                if (!(bool)oCM_CREP.isnull["IOLLA"])
                {
                    auxPar.Value = oCM_CREP.IOLLA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@BLOQUEADO", OleDbType.VarChar);
                if (!(bool)oCM_CREP.isnull["IBLOQUEADO"])
                {
                    auxPar.Value = oCM_CREP.IBLOQUEADO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FECHA", OleDbType.Date);
                if (!(bool)oCM_CREP.isnull["IFECHA"])
                {
                    auxPar.Value = oCM_CREP.IFECHA;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LLEVAR", OleDbType.VarChar);
                if (!(bool)oCM_CREP.isnull["ILLEVAR"])
                {
                    auxPar.Value = oCM_CREP.ILLEVAR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_CREP.isnull["IID"])
                {
                    auxPar.Value = oCM_CREP.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCM_CREP.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_CREP.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
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
        INSERT INTO   " + strFileName + @"
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

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

?,

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

                //if (st == null)
                    OleDbHelper.ExecuteNonQuery(strOleDbConn, CommandType.Text, commandText, arParms);
                //else
                //    OleDbHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }





        public CM_CREPBE enlistarM_CREP(CM_CREPBE oCM_CREP, string strTableName, OleDbTransaction st, string strOleDbConn)
        {




            CM_CREPBE retorno = new CM_CREPBE();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                //OleDbParameter auxPar;

                String CmdTxt = @"select * from '" + strTableName + @"' ";

                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                OleDbDataReader dr;
                if (st == null)
                    dr = OleDbHelper.ExecuteReader(strOleDbConn, CommandType.Text, CmdTxt, arParms);
                else
                    dr = OleDbHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["COBRANZA"] != System.DBNull.Value)
                    {
                        retorno.ICOBRANZA = (string)(dr["COBRANZA"]);
                    }

                    if (dr["VENDEDOR"] != System.DBNull.Value)
                    {
                        retorno.IVENDEDOR = (string)(dr["VENDEDOR"]);
                    }

                    if (dr["VENTA"] != System.DBNull.Value)
                    {
                        retorno.IVENTA = (string)(dr["VENTA"]);
                    }

                    if (dr["EMPRESA"] != System.DBNull.Value)
                    {
                        retorno.IEMPRESA = (string)(dr["EMPRESA"]);
                    }

                    if (dr["CLIENTE"] != System.DBNull.Value)
                    {
                        retorno.ICLIENTE = (string)(dr["CLIENTE"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["FACTURA"] != System.DBNull.Value)
                    {
                        retorno.IFACTURA = (string)(dr["FACTURA"]);
                    }

                    if (dr["ESTATUS"] != System.DBNull.Value)
                    {
                        retorno.IESTATUS = (string)(dr["ESTATUS"]);
                    }

                    if (dr["OBS"] != System.DBNull.Value)
                    {
                        retorno.IOBS = (string)(dr["OBS"]);
                    }

                    if (dr["F_FACTURA"] != System.DBNull.Value)
                    {
                        retorno.IF_FACTURA = (DateTime)(dr["F_FACTURA"]);
                    }

                    if (dr["F_PAGO"] != System.DBNull.Value)
                    {
                        retorno.IF_PAGO = (DateTime)(dr["F_PAGO"]);
                    }

                    if (dr["TOTAL"] != System.DBNull.Value)
                    {
                        retorno.ITOTAL = (decimal)(dr["TOTAL"]);
                    }

                    if (dr["A_CUENTA"] != System.DBNull.Value)
                    {
                        retorno.IA_CUENTA = (decimal)(dr["A_CUENTA"]);
                    }

                    if (dr["SALDO"] != System.DBNull.Value)
                    {
                        retorno.ISALDO = (decimal)(dr["SALDO"]);
                    }

                    if (dr["INT_COB"] != System.DBNull.Value)
                    {
                        retorno.IINT_COB = (decimal)(dr["INT_COB"]);
                    }

                    if (dr["INTERESES"] != System.DBNull.Value)
                    {
                        retorno.IINTERESES = (decimal)(dr["INTERESES"]);
                    }

                    if (dr["IMPOR_NETO"] != System.DBNull.Value)
                    {
                        retorno.IIMPOR_NETO = (decimal)(dr["IMPOR_NETO"]);
                    }

                    if (dr["PAGO"] != System.DBNull.Value)
                    {
                        retorno.IPAGO = (decimal)(dr["PAGO"]);
                    }

                    if (dr["EFECTIVO"] != System.DBNull.Value)
                    {
                        retorno.IEFECTIVO = (decimal)(dr["EFECTIVO"]);
                    }

                    if (dr["DIFERENCIA"] != System.DBNull.Value)
                    {
                        retorno.IDIFERENCIA = (decimal)(dr["DIFERENCIA"]);
                    }

                    if (dr["IMP_CHEQUE"] != System.DBNull.Value)
                    {
                        retorno.IIMP_CHEQUE = (decimal)(dr["IMP_CHEQUE"]);
                    }

                    if (dr["BANCO"] != System.DBNull.Value)
                    {
                        retorno.IBANCO = (string)(dr["BANCO"]);
                    }

                    if (dr["INTERES"] != System.DBNull.Value)
                    {
                        retorno.IINTERES = (decimal)(dr["INTERES"]);
                    }

                    if (dr["CAPITAL"] != System.DBNull.Value)
                    {
                        retorno.ICAPITAL = (decimal)(dr["CAPITAL"]);
                    }

                    if (dr["OLLA"] != System.DBNull.Value)
                    {
                        retorno.IOLLA = (string)(dr["OLLA"]);
                    }

                    if (dr["BLOQUEADO"] != System.DBNull.Value)
                    {
                        retorno.IBLOQUEADO = (string)(dr["BLOQUEADO"]);
                    }

                    if (dr["FECHA"] != System.DBNull.Value)
                    {
                        retorno.IFECHA = (DateTime)(dr["FECHA"]);
                    }

                    if (dr["LLEVAR"] != System.DBNull.Value)
                    {
                        retorno.ILLEVAR = (string)(dr["LLEVAR"]);
                    }

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno.IID = (string)(dr["ID"]);
                    }

                    if (dr["ID_FECHA"] != System.DBNull.Value)
                    {
                        retorno.IID_FECHA = (DateTime)(dr["ID_FECHA"]);
                    }

                    if (dr["ID_HORA"] != System.DBNull.Value)
                    {
                        retorno.IID_HORA = (string)(dr["ID_HORA"]);
                    }

                    if (dr["DIAS"] != System.DBNull.Value)
                    {
                        retorno.IDIAS = int.Parse(dr["DIAS"].ToString());
                    }

                    if (dr["NUM_CHEQ"] != System.DBNull.Value)
                    {
                        retorno.INUM_CHEQ = int.Parse(dr["NUM_CHEQ"].ToString());
                    }

                }
                else
                {
                    retorno = null;
                }




                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }











        public CM_CREPD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
        }
    }
}
