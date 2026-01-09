using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Collections;
using ConexionesBD;
using System.Data.OleDb;
using DataLayer;


namespace iPosData
{


    public class CCOBRANZAMOVILD
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


        [AutoComplete]
        public CCOBRANZAMOVILBE AgregarCOBRANZAMOVILD(CCOBRANZAMOVILBE oCCOBRANZAMOVIL, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@COBRANZA", FbDbType.VarChar);
                if (!(bool)oCCOBRANZAMOVIL.isnull["ICOBRANZA"])
                {
                    auxPar.Value = oCCOBRANZAMOVIL.ICOBRANZA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDOR", FbDbType.VarChar);
                if (!(bool)oCCOBRANZAMOVIL.isnull["IVENDEDOR"])
                {
                    auxPar.Value = oCCOBRANZAMOVIL.IVENDEDOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENTA", FbDbType.VarChar);
                if (!(bool)oCCOBRANZAMOVIL.isnull["IVENTA"])
                {
                    auxPar.Value = oCCOBRANZAMOVIL.IVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@EMPRESA", FbDbType.VarChar);
                if (!(bool)oCCOBRANZAMOVIL.isnull["IEMPRESA"])
                {
                    auxPar.Value = oCCOBRANZAMOVIL.IEMPRESA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLIENTE", FbDbType.VarChar);
                if (!(bool)oCCOBRANZAMOVIL.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCCOBRANZAMOVIL.ICLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCCOBRANZAMOVIL.isnull["INOMBRE"])
                {
                    auxPar.Value = oCCOBRANZAMOVIL.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FACTURA", FbDbType.VarChar);
                if (!(bool)oCCOBRANZAMOVIL.isnull["IFACTURA"])
                {
                    auxPar.Value = oCCOBRANZAMOVIL.IFACTURA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUS", FbDbType.VarChar);
                if (!(bool)oCCOBRANZAMOVIL.isnull["IESTATUS"])
                {
                    auxPar.Value = oCCOBRANZAMOVIL.IESTATUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@OBS", FbDbType.VarChar);
                if (!(bool)oCCOBRANZAMOVIL.isnull["IOBS"])
                {
                    auxPar.Value = oCCOBRANZAMOVIL.IOBS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@F_FACTURA", FbDbType.Date);
                if (!(bool)oCCOBRANZAMOVIL.isnull["IF_FACTURA"])
                {
                    auxPar.Value = oCCOBRANZAMOVIL.IF_FACTURA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@F_PAGO", FbDbType.Date);
                if (!(bool)oCCOBRANZAMOVIL.isnull["IF_PAGO"])
                {
                    auxPar.Value = oCCOBRANZAMOVIL.IF_PAGO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DIAS", FbDbType.Integer);
                if (!(bool)oCCOBRANZAMOVIL.isnull["IDIAS"])
                {
                    auxPar.Value = oCCOBRANZAMOVIL.IDIAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TOTAL", FbDbType.Numeric);
                if (!(bool)oCCOBRANZAMOVIL.isnull["ITOTAL"])
                {
                    auxPar.Value = oCCOBRANZAMOVIL.ITOTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@A_CUENTA", FbDbType.Numeric);
                if (!(bool)oCCOBRANZAMOVIL.isnull["IA_CUENTA"])
                {
                    auxPar.Value = oCCOBRANZAMOVIL.IA_CUENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SALDO", FbDbType.Numeric);
                if (!(bool)oCCOBRANZAMOVIL.isnull["ISALDO"])
                {
                    auxPar.Value = oCCOBRANZAMOVIL.ISALDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@INT_COB", FbDbType.Numeric);
                if (!(bool)oCCOBRANZAMOVIL.isnull["IINT_COB"])
                {
                    auxPar.Value = oCCOBRANZAMOVIL.IINT_COB;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@INTERESES", FbDbType.Numeric);
                if (!(bool)oCCOBRANZAMOVIL.isnull["IINTERESES"])
                {
                    auxPar.Value = oCCOBRANZAMOVIL.IINTERESES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPOR_NETO", FbDbType.Numeric);
                if (!(bool)oCCOBRANZAMOVIL.isnull["IIMPOR_NETO"])
                {
                    auxPar.Value = oCCOBRANZAMOVIL.IIMPOR_NETO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PAGO", FbDbType.Numeric);
                if (!(bool)oCCOBRANZAMOVIL.isnull["IPAGO"])
                {
                    auxPar.Value = oCCOBRANZAMOVIL.IPAGO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@EFECTIVO", FbDbType.Numeric);
                if (!(bool)oCCOBRANZAMOVIL.isnull["IEFECTIVO"])
                {
                    auxPar.Value = oCCOBRANZAMOVIL.IEFECTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DIFERENCIA", FbDbType.Numeric);
                if (!(bool)oCCOBRANZAMOVIL.isnull["IDIFERENCIA"])
                {
                    auxPar.Value = oCCOBRANZAMOVIL.IDIFERENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMP_CHEQUE", FbDbType.Numeric);
                if (!(bool)oCCOBRANZAMOVIL.isnull["IIMP_CHEQUE"])
                {
                    auxPar.Value = oCCOBRANZAMOVIL.IIMP_CHEQUE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@BANCO", FbDbType.VarChar);
                if (!(bool)oCCOBRANZAMOVIL.isnull["IBANCO"])
                {
                    auxPar.Value = oCCOBRANZAMOVIL.IBANCO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUM_CHEQ", FbDbType.Integer);
                if (!(bool)oCCOBRANZAMOVIL.isnull["INUM_CHEQ"])
                {
                    auxPar.Value = oCCOBRANZAMOVIL.INUM_CHEQ;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@INTERES", FbDbType.Numeric);
                if (!(bool)oCCOBRANZAMOVIL.isnull["IINTERES"])
                {
                    auxPar.Value = oCCOBRANZAMOVIL.IINTERES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAPITAL", FbDbType.Numeric);
                if (!(bool)oCCOBRANZAMOVIL.isnull["ICAPITAL"])
                {
                    auxPar.Value = oCCOBRANZAMOVIL.ICAPITAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@OLLA", FbDbType.VarChar);
                if (!(bool)oCCOBRANZAMOVIL.isnull["IOLLA"])
                {
                    auxPar.Value = oCCOBRANZAMOVIL.IOLLA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@BLOQUEADO", FbDbType.VarChar);
                if (!(bool)oCCOBRANZAMOVIL.isnull["IBLOQUEADO"])
                {
                    auxPar.Value = oCCOBRANZAMOVIL.IBLOQUEADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCCOBRANZAMOVIL.isnull["IFECHA"])
                {
                    auxPar.Value = oCCOBRANZAMOVIL.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LLEVAR", FbDbType.VarChar);
                if (!(bool)oCCOBRANZAMOVIL.isnull["ILLEVAR"])
                {
                    auxPar.Value = oCCOBRANZAMOVIL.ILLEVAR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SALDOMOVIL", FbDbType.Numeric);
                if (!(bool)oCCOBRANZAMOVIL.isnull["ISALDOMOVIL"])
                {
                    auxPar.Value = oCCOBRANZAMOVIL.ISALDOMOVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ABONOSMOVIL", FbDbType.Numeric);
                if (!(bool)oCCOBRANZAMOVIL.isnull["IABONOSMOVIL"])
                {
                    auxPar.Value = oCCOBRANZAMOVIL.IABONOSMOVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCCOBRANZAMOVIL.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCCOBRANZAMOVIL.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO COBRANZAMOVIL
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

SALDOMOVIL,

ABONOSMOVIL,

PERSONAID
         )

Values (


@COBRANZA,

@VENDEDOR,

@VENTA,

@EMPRESA,

@CLIENTE,

@NOMBRE,

@FACTURA,

@ESTATUS,

@OBS,

@F_FACTURA,

@F_PAGO,

@DIAS,

@TOTAL,

@A_CUENTA,

@SALDO,

@INT_COB,

@INTERESES,

@IMPOR_NETO,

@PAGO,

@EFECTIVO,

@DIFERENCIA,

@IMP_CHEQUE,

@BANCO,

@NUM_CHEQ,

@INTERES,

@CAPITAL,

@OLLA,

@BLOQUEADO,

@FECHA,

@LLEVAR,

@SALDOMOVIL,

@ABONOSMOVIL,

@PERSONAID
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCCOBRANZAMOVIL;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarCOBRANZAMOVILD(CCOBRANZAMOVILBE oCCOBRANZAMOVIL, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCCOBRANZAMOVIL.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from COBRANZAMOVIL
  where

  ID=@ID
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;




            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        [AutoComplete]
        public bool CambiarCOBRANZAMOVILD(CCOBRANZAMOVILBE oCCOBRANZAMOVILNuevo, CCOBRANZAMOVILBE oCCOBRANZAMOVILAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@COBRANZA", FbDbType.VarChar);
                if (!(bool)oCCOBRANZAMOVILNuevo.isnull["ICOBRANZA"])
                {
                    auxPar.Value = oCCOBRANZAMOVILNuevo.ICOBRANZA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENDEDOR", FbDbType.VarChar);
                if (!(bool)oCCOBRANZAMOVILNuevo.isnull["IVENDEDOR"])
                {
                    auxPar.Value = oCCOBRANZAMOVILNuevo.IVENDEDOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENTA", FbDbType.VarChar);
                if (!(bool)oCCOBRANZAMOVILNuevo.isnull["IVENTA"])
                {
                    auxPar.Value = oCCOBRANZAMOVILNuevo.IVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@EMPRESA", FbDbType.VarChar);
                if (!(bool)oCCOBRANZAMOVILNuevo.isnull["IEMPRESA"])
                {
                    auxPar.Value = oCCOBRANZAMOVILNuevo.IEMPRESA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLIENTE", FbDbType.VarChar);
                if (!(bool)oCCOBRANZAMOVILNuevo.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCCOBRANZAMOVILNuevo.ICLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCCOBRANZAMOVILNuevo.isnull["INOMBRE"])
                {
                    auxPar.Value = oCCOBRANZAMOVILNuevo.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FACTURA", FbDbType.VarChar);
                if (!(bool)oCCOBRANZAMOVILNuevo.isnull["IFACTURA"])
                {
                    auxPar.Value = oCCOBRANZAMOVILNuevo.IFACTURA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESTATUS", FbDbType.VarChar);
                if (!(bool)oCCOBRANZAMOVILNuevo.isnull["IESTATUS"])
                {
                    auxPar.Value = oCCOBRANZAMOVILNuevo.IESTATUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@OBS", FbDbType.VarChar);
                if (!(bool)oCCOBRANZAMOVILNuevo.isnull["IOBS"])
                {
                    auxPar.Value = oCCOBRANZAMOVILNuevo.IOBS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@F_FACTURA", FbDbType.Date);
                if (!(bool)oCCOBRANZAMOVILNuevo.isnull["IF_FACTURA"])
                {
                    auxPar.Value = oCCOBRANZAMOVILNuevo.IF_FACTURA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@F_PAGO", FbDbType.Date);
                if (!(bool)oCCOBRANZAMOVILNuevo.isnull["IF_PAGO"])
                {
                    auxPar.Value = oCCOBRANZAMOVILNuevo.IF_PAGO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DIAS", FbDbType.Integer);
                if (!(bool)oCCOBRANZAMOVILNuevo.isnull["IDIAS"])
                {
                    auxPar.Value = oCCOBRANZAMOVILNuevo.IDIAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TOTAL", FbDbType.Numeric);
                if (!(bool)oCCOBRANZAMOVILNuevo.isnull["ITOTAL"])
                {
                    auxPar.Value = oCCOBRANZAMOVILNuevo.ITOTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@A_CUENTA", FbDbType.Numeric);
                if (!(bool)oCCOBRANZAMOVILNuevo.isnull["IA_CUENTA"])
                {
                    auxPar.Value = oCCOBRANZAMOVILNuevo.IA_CUENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SALDO", FbDbType.Numeric);
                if (!(bool)oCCOBRANZAMOVILNuevo.isnull["ISALDO"])
                {
                    auxPar.Value = oCCOBRANZAMOVILNuevo.ISALDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@INT_COB", FbDbType.Numeric);
                if (!(bool)oCCOBRANZAMOVILNuevo.isnull["IINT_COB"])
                {
                    auxPar.Value = oCCOBRANZAMOVILNuevo.IINT_COB;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@INTERESES", FbDbType.Numeric);
                if (!(bool)oCCOBRANZAMOVILNuevo.isnull["IINTERESES"])
                {
                    auxPar.Value = oCCOBRANZAMOVILNuevo.IINTERESES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPOR_NETO", FbDbType.Numeric);
                if (!(bool)oCCOBRANZAMOVILNuevo.isnull["IIMPOR_NETO"])
                {
                    auxPar.Value = oCCOBRANZAMOVILNuevo.IIMPOR_NETO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PAGO", FbDbType.Numeric);
                if (!(bool)oCCOBRANZAMOVILNuevo.isnull["IPAGO"])
                {
                    auxPar.Value = oCCOBRANZAMOVILNuevo.IPAGO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@EFECTIVO", FbDbType.Numeric);
                if (!(bool)oCCOBRANZAMOVILNuevo.isnull["IEFECTIVO"])
                {
                    auxPar.Value = oCCOBRANZAMOVILNuevo.IEFECTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DIFERENCIA", FbDbType.Numeric);
                if (!(bool)oCCOBRANZAMOVILNuevo.isnull["IDIFERENCIA"])
                {
                    auxPar.Value = oCCOBRANZAMOVILNuevo.IDIFERENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMP_CHEQUE", FbDbType.Numeric);
                if (!(bool)oCCOBRANZAMOVILNuevo.isnull["IIMP_CHEQUE"])
                {
                    auxPar.Value = oCCOBRANZAMOVILNuevo.IIMP_CHEQUE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@BANCO", FbDbType.VarChar);
                if (!(bool)oCCOBRANZAMOVILNuevo.isnull["IBANCO"])
                {
                    auxPar.Value = oCCOBRANZAMOVILNuevo.IBANCO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUM_CHEQ", FbDbType.Integer);
                if (!(bool)oCCOBRANZAMOVILNuevo.isnull["INUM_CHEQ"])
                {
                    auxPar.Value = oCCOBRANZAMOVILNuevo.INUM_CHEQ;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@INTERES", FbDbType.Numeric);
                if (!(bool)oCCOBRANZAMOVILNuevo.isnull["IINTERES"])
                {
                    auxPar.Value = oCCOBRANZAMOVILNuevo.IINTERES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAPITAL", FbDbType.Numeric);
                if (!(bool)oCCOBRANZAMOVILNuevo.isnull["ICAPITAL"])
                {
                    auxPar.Value = oCCOBRANZAMOVILNuevo.ICAPITAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@OLLA", FbDbType.VarChar);
                if (!(bool)oCCOBRANZAMOVILNuevo.isnull["IOLLA"])
                {
                    auxPar.Value = oCCOBRANZAMOVILNuevo.IOLLA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@BLOQUEADO", FbDbType.VarChar);
                if (!(bool)oCCOBRANZAMOVILNuevo.isnull["IBLOQUEADO"])
                {
                    auxPar.Value = oCCOBRANZAMOVILNuevo.IBLOQUEADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCCOBRANZAMOVILNuevo.isnull["IFECHA"])
                {
                    auxPar.Value = oCCOBRANZAMOVILNuevo.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LLEVAR", FbDbType.VarChar);
                if (!(bool)oCCOBRANZAMOVILNuevo.isnull["ILLEVAR"])
                {
                    auxPar.Value = oCCOBRANZAMOVILNuevo.ILLEVAR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SALDOMOVIL", FbDbType.Numeric);
                if (!(bool)oCCOBRANZAMOVILNuevo.isnull["ISALDOMOVIL"])
                {
                    auxPar.Value = oCCOBRANZAMOVILNuevo.ISALDOMOVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ABONOSMOVIL", FbDbType.Numeric);
                if (!(bool)oCCOBRANZAMOVILNuevo.isnull["IABONOSMOVIL"])
                {
                    auxPar.Value = oCCOBRANZAMOVILNuevo.IABONOSMOVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCCOBRANZAMOVILNuevo.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCCOBRANZAMOVILNuevo.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCCOBRANZAMOVILAnterior.isnull["IID"])
                {
                    auxPar.Value = oCCOBRANZAMOVILAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  COBRANZAMOVIL
  set

COBRANZA=@COBRANZA,

VENDEDOR=@VENDEDOR,

VENTA=@VENTA,

EMPRESA=@EMPRESA,

CLIENTE=@CLIENTE,

NOMBRE=@NOMBRE,

FACTURA=@FACTURA,

ESTATUS=@ESTATUS,

OBS=@OBS,

F_FACTURA=@F_FACTURA,

F_PAGO=@F_PAGO,

DIAS=@DIAS,

TOTAL=@TOTAL,

A_CUENTA=@A_CUENTA,

SALDO=@SALDO,

INT_COB=@INT_COB,

INTERESES=@INTERESES,

IMPOR_NETO=@IMPOR_NETO,

PAGO=@PAGO,

EFECTIVO=@EFECTIVO,

DIFERENCIA=@DIFERENCIA,

IMP_CHEQUE=@IMP_CHEQUE,

BANCO=@BANCO,

NUM_CHEQ=@NUM_CHEQ,

INTERES=@INTERES,

CAPITAL=@CAPITAL,

OLLA=@OLLA,

BLOQUEADO=@BLOQUEADO,

FECHA=@FECHA,

LLEVAR=@LLEVAR,

SALDOMOVIL=@SALDOMOVIL,

ABONOSMOVIL=@ABONOSMOVIL,

PERSONAID=@PERSONAID
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        [AutoComplete]
        public CCOBRANZAMOVILBE seleccionarCOBRANZAMOVIL(CCOBRANZAMOVILBE oCCOBRANZAMOVIL, FbTransaction st)
        {




            CCOBRANZAMOVILBE retorno = new CCOBRANZAMOVILBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from COBRANZAMOVIL where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCCOBRANZAMOVIL.IID;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno.IID = (long)(dr["ID"]);
                    }

                    if (dr["ACTIVO"] != System.DBNull.Value)
                    {
                        retorno.IACTIVO = (string)(dr["ACTIVO"]);
                    }

                    if (dr["CREADO"] != System.DBNull.Value)
                    {
                        retorno.ICREADO = (object)(dr["CREADO"]);
                    }

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADO"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADO = (object)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

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

                    if (dr["SALDOMOVIL"] != System.DBNull.Value)
                    {
                        retorno.ISALDOMOVIL = (decimal)(dr["SALDOMOVIL"]);
                    }

                    if (dr["ABONOSMOVIL"] != System.DBNull.Value)
                    {
                        retorno.IABONOSMOVIL = (decimal)(dr["ABONOSMOVIL"]);
                    }

                    if (dr["PERSONAID"] != System.DBNull.Value)
                    {
                        retorno.IPERSONAID = (long)(dr["PERSONAID"]);
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

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);


                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }









        [AutoComplete]
        public DataSet enlistarCOBRANZAMOVIL()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_COBRANZAMOVIL_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoCOBRANZAMOVIL()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_COBRANZAMOVIL_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteCOBRANZAMOVIL(CCOBRANZAMOVILBE oCCOBRANZAMOVIL, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCCOBRANZAMOVIL.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from COBRANZAMOVIL where

  ID=@ID  
  );";






                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);



                if (dr.Read())
                {
                    retorno = 1;
                }
                else
                {
                    retorno = 0;
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return -1;
            }
        }




        public CCOBRANZAMOVILBE AgregarCOBRANZAMOVIL(CCOBRANZAMOVILBE oCCOBRANZAMOVIL, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCOBRANZAMOVIL(oCCOBRANZAMOVIL, st);
                if (iRes == 1)
                {
                    this.IComentario = "El COBRANZAMOVIL ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarCOBRANZAMOVILD(oCCOBRANZAMOVIL, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarCOBRANZAMOVIL(CCOBRANZAMOVILBE oCCOBRANZAMOVIL, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCOBRANZAMOVIL(oCCOBRANZAMOVIL, st);
                if (iRes == 0)
                {
                    this.IComentario = "El COBRANZAMOVIL no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarCOBRANZAMOVILD(oCCOBRANZAMOVIL, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarCOBRANZAMOVIL(CCOBRANZAMOVILBE oCCOBRANZAMOVILNuevo, CCOBRANZAMOVILBE oCCOBRANZAMOVILAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCOBRANZAMOVIL(oCCOBRANZAMOVILAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El COBRANZAMOVIL no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarCOBRANZAMOVILD(oCCOBRANZAMOVILNuevo, oCCOBRANZAMOVILAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }



        public bool MOVIL_COMPLETARIMPOCOBRANZA( FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);




                string commandText = @"MOVIL_COMPLETARIMPOCOBRANZA";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);



                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        this.iComentario = "Hubo un error " + arParms[arParms.Length - 1].Value.ToString();
                        return false;
                    }
                }


                return true;




            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }





        public CCOBRANZAMOVILD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
