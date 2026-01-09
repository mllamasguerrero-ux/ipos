
using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
//using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Data.OleDb;
using DataLayer;
using System.Collections;
using ConexionesBD;


namespace iPosData
{

    [Transaction(TransactionOption.Supported)]


    public class CPEDIDOENVIOD
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
        public bool AgregarPEDIDOENVIOD(CPEDIDOENVIOBE oCPEDIDOENVIO,  string strFileName, OleDbTransaction st, string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@VENTA", OleDbType.VarChar);
                if (!(bool)oCPEDIDOENVIO.isnull["IVENTA"])
                {
                    auxPar.Value = oCPEDIDOENVIO.IVENTA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMPRA", OleDbType.Double);
                if (!(bool)oCPEDIDOENVIO.isnull["ICOMPRA"])
                {
                    auxPar.Value = oCPEDIDOENVIO.ICOMPRA;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                if (!(bool)oCPEDIDOENVIO.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCPEDIDOENVIO.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESC1", OleDbType.VarChar);
                if (!(bool)oCPEDIDOENVIO.isnull["IDESC1"])
                {
                    auxPar.Value = oCPEDIDOENVIO.IDESC1;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LINEA", OleDbType.VarChar);
                if (!(bool)oCPEDIDOENVIO.isnull["ILINEA"])
                {
                    auxPar.Value = oCPEDIDOENVIO.ILINEA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MARCA", OleDbType.VarChar);
                if (!(bool)oCPEDIDOENVIO.isnull["IMARCA"])
                {
                    auxPar.Value = oCPEDIDOENVIO.IMARCA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PROVEEDOR", OleDbType.VarChar);
                if (!(bool)oCPEDIDOENVIO.isnull["IPROVEEDOR"])
                {
                    auxPar.Value = oCPEDIDOENVIO.IPROVEEDOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                if (!(bool)oCPEDIDOENVIO.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCPEDIDOENVIO.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SURTIDA", OleDbType.Double);
                if (!(bool)oCPEDIDOENVIO.isnull["ISURTIDA"])
                {
                    auxPar.Value = oCPEDIDOENVIO.ISURTIDA;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FALTANTE", OleDbType.Double);
                if (!(bool)oCPEDIDOENVIO.isnull["IFALTANTE"])
                {
                    auxPar.Value = oCPEDIDOENVIO.IFALTANTE;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTO", OleDbType.Double);
                if (!(bool)oCPEDIDOENVIO.isnull["ICOSTO"])
                {
                    auxPar.Value = oCPEDIDOENVIO.ICOSTO;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CARGOS_U", OleDbType.Double);
                if (!(bool)oCPEDIDOENVIO.isnull["ICARGOS_U"])
                {
                    auxPar.Value = oCPEDIDOENVIO.ICARGOS_U;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Double);
                if (!(bool)oCPEDIDOENVIO.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCPEDIDOENVIO.IIMPORTE;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTNETO", OleDbType.Double);
                if (!(bool)oCPEDIDOENVIO.isnull["IIMPORTNETO"])
                {
                    auxPar.Value = oCPEDIDOENVIO.IIMPORTNETO;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FECHA", OleDbType.Date);
                if (!(bool)oCPEDIDOENVIO.isnull["IFECHA"])
                {
                    auxPar.Value = oCPEDIDOENVIO.IFECHA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTATUS", OleDbType.VarChar);
                if (!(bool)oCPEDIDOENVIO.isnull["IESTATUS"])
                {
                    auxPar.Value = oCPEDIDOENVIO.IESTATUS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PIEZAS", OleDbType.Double);
                if (!(bool)oCPEDIDOENVIO.isnull["IPIEZAS"])
                {
                    auxPar.Value = oCPEDIDOENVIO.IPIEZAS;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PARTIDA", OleDbType.Double);
                if (!(bool)oCPEDIDOENVIO.isnull["IPARTIDA"])
                {
                    auxPar.Value = oCPEDIDOENVIO.IPARTIDA;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TRANSA", OleDbType.Double);
                if (!(bool)oCPEDIDOENVIO.isnull["ITRANSA"])
                {
                    auxPar.Value = oCPEDIDOENVIO.ITRANSA;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESCUENTO", OleDbType.Double);
                if (!(bool)oCPEDIDOENVIO.isnull["IDESCUENTO"])
                {
                    auxPar.Value = oCPEDIDOENVIO.IDESCUENTO;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MONEDA", OleDbType.VarChar);
                if (!(bool)oCPEDIDOENVIO.isnull["IMONEDA"])
                {
                    auxPar.Value = oCPEDIDOENVIO.IMONEDA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTO_INI", OleDbType.Double);
                if (!(bool)oCPEDIDOENVIO.isnull["ICOSTO_INI"])
                {
                    auxPar.Value = oCPEDIDOENVIO.ICOSTO_INI;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCPEDIDOENVIO.isnull["IID"])
                {
                    auxPar.Value = oCPEDIDOENVIO.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCPEDIDOENVIO.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCPEDIDOENVIO.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCPEDIDOENVIO.isnull["IID_HORA"])
                {
                    auxPar.Value = oCPEDIDOENVIO.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TRANS_LOTE", OleDbType.VarChar);
                if (!(bool)oCPEDIDOENVIO.isnull["ITRANS_LOTE"])
                {
                    auxPar.Value = oCPEDIDOENVIO.ITRANS_LOTE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                if (!(bool)oCPEDIDOENVIO.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCPEDIDOENVIO.ICLIENTE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LOTE", OleDbType.VarChar);
                if (!(bool)oCPEDIDOENVIO.isnull["ILOTE"])
                {
                    auxPar.Value = oCPEDIDOENVIO.ILOTE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@F_CADUCA", OleDbType.Date);
                if (!(bool)oCPEDIDOENVIO.isnull["IF_CADUCA"])
                {
                    auxPar.Value = oCPEDIDOENVIO.IF_CADUCA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANT_FAC", OleDbType.Double);
                if (!(bool)oCPEDIDOENVIO.isnull["ICANT_FAC"])
                {
                    auxPar.Value = oCPEDIDOENVIO.ICANT_FAC;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANT_REM", OleDbType.Double);
                if (!(bool)oCPEDIDOENVIO.isnull["ICANT_REM"])
                {
                    auxPar.Value = oCPEDIDOENVIO.ICANT_REM;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANT_IND", OleDbType.Double);
                if (!(bool)oCPEDIDOENVIO.isnull["ICANT_IND"])
                {
                    auxPar.Value = oCPEDIDOENVIO.ICANT_IND;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECREC", OleDbType.Double);
                if (!(bool)oCPEDIDOENVIO.isnull["IPRECREC"])
                {
                    auxPar.Value = oCPEDIDOENVIO.IPRECREC;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);




                auxPar = new OleDbParameter("@IMP_PED", OleDbType.VarChar);
                if (!(bool)oCPEDIDOENVIO.isnull["IIMP_PED"])
                {
                    auxPar.Value = oCPEDIDOENVIO.IIMP_PED;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@IMP_FEC", OleDbType.Date);
                if (!(bool)oCPEDIDOENVIO.isnull["IIMP_FEC"])
                {
                    auxPar.Value = oCPEDIDOENVIO.IIMP_FEC;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;// System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMP_ADU", OleDbType.VarChar);
                if (!(bool)oCPEDIDOENVIO.isnull["IIMP_ADU"])
                {
                    auxPar.Value = oCPEDIDOENVIO.IIMP_ADU;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMP_TC", OleDbType.Double);
                if (!(bool)oCPEDIDOENVIO.isnull["IIMP_TC"])
                {
                    auxPar.Value = oCPEDIDOENVIO.IIMP_TC;
                }
                else
                {
                    auxPar.Value = 1;
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@SUCURSAL", OleDbType.VarChar);
                if (!(bool)oCPEDIDOENVIO.isnull["ISUCURSAL"])
                {
                    auxPar.Value = oCPEDIDOENVIO.ISUCURSAL;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                //strOleDbConn = "Provider=VFPOLEDB.1;Data Source=\"C:\\IposProject\\IposRopa\\Ipos\\iPos\\bin\\Debug\\sampdata\\matriz\\enviossucursales\\0009\";User ID=admin";

                string commandText = @"
INSERT INTO " + strFileName + @" 
      (
    
VENTA,

COMPRA,

PRODUCTO,

DESC1,

LINEA,

MARCA,

PROVEEDOR,

CANTIDAD,

SURTIDA,

FALTANTE,

COSTO,

CARGOS_U,

IMPORTE,

IMPORTNETO,

FECHA,

ESTATUS,

PIEZAS,

PARTIDA,

TRANSA,

DESCUENTO,

MONEDA,

COSTO_INI,

ID,

ID_FECHA,

ID_HORA,

TRANS_LOTE,

CLIENTE,

LOTE,

F_CADUCA,

CANT_FAC,

CANT_REM,

CANT_IND,

PRECREC,

IMP_PED,

IMP_FEC,

IMP_ADU,

IMP_TC,

SUCURSAL
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
?,
?,
?,
?,
?,
?


); ";



                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (strOleDbConn != "")
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


        [AutoComplete]
        public bool BorrarPEDIDOENVIOD(CPEDIDOENVIOBE oCPEDIDOENVIO, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@VENTA", OleDbType.VarChar);
                auxPar.Value = oCPEDIDOENVIO.IVENTA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                auxPar.Value = oCPEDIDOENVIO.IPRODUCTO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PARTIDA", OleDbType.Double);
                auxPar.Value = oCPEDIDOENVIO.IPARTIDA;
                parts.Add(auxPar);



                string commandText = @"  Delete from PEDIDOENVIO
  where

  VENTA=@VENTA and 

  PRODUCTO=@PRODUCTO and 

  PARTIDA=@PARTIDA
  ;";

                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    OleDbHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
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


        [AutoComplete]
        public bool CambiarPEDIDOENVIOD(CPEDIDOENVIOBE oCPEDIDOENVIONuevo, CPEDIDOENVIOBE oCPEDIDOENVIOAnterior, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@VENTA", OleDbType.VarChar);
                if (!(bool)oCPEDIDOENVIONuevo.isnull["IVENTA"])
                {
                    auxPar.Value = oCPEDIDOENVIONuevo.IVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COMPRA", OleDbType.Double);
                if (!(bool)oCPEDIDOENVIONuevo.isnull["ICOMPRA"])
                {
                    auxPar.Value = oCPEDIDOENVIONuevo.ICOMPRA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                if (!(bool)oCPEDIDOENVIONuevo.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCPEDIDOENVIONuevo.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@DESC1", OleDbType.VarChar);
                if (!(bool)oCPEDIDOENVIONuevo.isnull["IDESC1"])
                {
                    auxPar.Value = oCPEDIDOENVIONuevo.IDESC1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@LINEA", OleDbType.VarChar);
                if (!(bool)oCPEDIDOENVIONuevo.isnull["ILINEA"])
                {
                    auxPar.Value = oCPEDIDOENVIONuevo.ILINEA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@MARCA", OleDbType.VarChar);
                if (!(bool)oCPEDIDOENVIONuevo.isnull["IMARCA"])
                {
                    auxPar.Value = oCPEDIDOENVIONuevo.IMARCA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PROVEEDOR", OleDbType.VarChar);
                if (!(bool)oCPEDIDOENVIONuevo.isnull["IPROVEEDOR"])
                {
                    auxPar.Value = oCPEDIDOENVIONuevo.IPROVEEDOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                if (!(bool)oCPEDIDOENVIONuevo.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCPEDIDOENVIONuevo.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SURTIDA", OleDbType.Double);
                if (!(bool)oCPEDIDOENVIONuevo.isnull["ISURTIDA"])
                {
                    auxPar.Value = oCPEDIDOENVIONuevo.ISURTIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@FALTANTE", OleDbType.Double);
                if (!(bool)oCPEDIDOENVIONuevo.isnull["IFALTANTE"])
                {
                    auxPar.Value = oCPEDIDOENVIONuevo.IFALTANTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COSTO", OleDbType.Double);
                if (!(bool)oCPEDIDOENVIONuevo.isnull["ICOSTO"])
                {
                    auxPar.Value = oCPEDIDOENVIONuevo.ICOSTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CARGOS_U", OleDbType.Double);
                if (!(bool)oCPEDIDOENVIONuevo.isnull["ICARGOS_U"])
                {
                    auxPar.Value = oCPEDIDOENVIONuevo.ICARGOS_U;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Double);
                if (!(bool)oCPEDIDOENVIONuevo.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCPEDIDOENVIONuevo.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IMPORTNETO", OleDbType.Double);
                if (!(bool)oCPEDIDOENVIONuevo.isnull["IIMPORTNETO"])
                {
                    auxPar.Value = oCPEDIDOENVIONuevo.IIMPORTNETO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@FECHA", OleDbType.Date);
                if (!(bool)oCPEDIDOENVIONuevo.isnull["IFECHA"])
                {
                    auxPar.Value = oCPEDIDOENVIONuevo.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ESTATUS", OleDbType.VarChar);
                if (!(bool)oCPEDIDOENVIONuevo.isnull["IESTATUS"])
                {
                    auxPar.Value = oCPEDIDOENVIONuevo.IESTATUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PIEZAS", OleDbType.Double);
                if (!(bool)oCPEDIDOENVIONuevo.isnull["IPIEZAS"])
                {
                    auxPar.Value = oCPEDIDOENVIONuevo.IPIEZAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PARTIDA", OleDbType.Double);
                if (!(bool)oCPEDIDOENVIONuevo.isnull["IPARTIDA"])
                {
                    auxPar.Value = oCPEDIDOENVIONuevo.IPARTIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TRANSA", OleDbType.Double);
                if (!(bool)oCPEDIDOENVIONuevo.isnull["ITRANSA"])
                {
                    auxPar.Value = oCPEDIDOENVIONuevo.ITRANSA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@DESCUENTO", OleDbType.Double);
                if (!(bool)oCPEDIDOENVIONuevo.isnull["IDESCUENTO"])
                {
                    auxPar.Value = oCPEDIDOENVIONuevo.IDESCUENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@MONEDA", OleDbType.VarChar);
                if (!(bool)oCPEDIDOENVIONuevo.isnull["IMONEDA"])
                {
                    auxPar.Value = oCPEDIDOENVIONuevo.IMONEDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COSTO_INI", OleDbType.Double);
                if (!(bool)oCPEDIDOENVIONuevo.isnull["ICOSTO_INI"])
                {
                    auxPar.Value = oCPEDIDOENVIONuevo.ICOSTO_INI;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCPEDIDOENVIONuevo.isnull["IID"])
                {
                    auxPar.Value = oCPEDIDOENVIONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCPEDIDOENVIONuevo.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCPEDIDOENVIONuevo.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCPEDIDOENVIONuevo.isnull["IID_HORA"])
                {
                    auxPar.Value = oCPEDIDOENVIONuevo.IID_HORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TRANS_LOTE", OleDbType.VarChar);
                if (!(bool)oCPEDIDOENVIONuevo.isnull["ITRANS_LOTE"])
                {
                    auxPar.Value = oCPEDIDOENVIONuevo.ITRANS_LOTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                if (!(bool)oCPEDIDOENVIONuevo.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCPEDIDOENVIONuevo.ICLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@LOTE", OleDbType.VarChar);
                if (!(bool)oCPEDIDOENVIONuevo.isnull["ILOTE"])
                {
                    auxPar.Value = oCPEDIDOENVIONuevo.ILOTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@F_CADUCA", OleDbType.Date);
                if (!(bool)oCPEDIDOENVIONuevo.isnull["IF_CADUCA"])
                {
                    auxPar.Value = oCPEDIDOENVIONuevo.IF_CADUCA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@VENTAAnt", OleDbType.VarChar);
                if (!(bool)oCPEDIDOENVIOAnterior.isnull["IVENTA"])
                {
                    auxPar.Value = oCPEDIDOENVIOAnterior.IVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PRODUCTOAnt", OleDbType.VarChar);
                if (!(bool)oCPEDIDOENVIOAnterior.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCPEDIDOENVIOAnterior.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PARTIDAAnt", OleDbType.Double);
                if (!(bool)oCPEDIDOENVIOAnterior.isnull["IPARTIDA"])
                {
                    auxPar.Value = oCPEDIDOENVIOAnterior.IPARTIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  PEDIDOENVIO
  set

VENTA=@VENTA,

COMPRA=@COMPRA,

PRODUCTO=@PRODUCTO,

DESC1=@DESC1,

LINEA=@LINEA,

MARCA=@MARCA,

PROVEEDOR=@PROVEEDOR,

CANTIDAD=@CANTIDAD,

SURTIDA=@SURTIDA,

FALTANTE=@FALTANTE,

COSTO=@COSTO,

CARGOS_U=@CARGOS_U,

IMPORTE=@IMPORTE,

IMPORTNETO=@IMPORTNETO,

FECHA=@FECHA,

ESTATUS=@ESTATUS,

PIEZAS=@PIEZAS,

PARTIDA=@PARTIDA,

TRANSA=@TRANSA,

DESCUENTO=@DESCUENTO,

MONEDA=@MONEDA,

COSTO_INI=@COSTO_INI,

ID=@ID,

ID_FECHA=@ID_FECHA,

ID_HORA=@ID_HORA,

TRANS_LOTE=@TRANS_LOTE,

CLIENTE=@CLIENTE,

LOTE=@LOTE,

F_CADUCA=@F_CADUCA
  where 

VENTA=@VENTAAnt and

PRODUCTO=@PRODUCTOAnt and

PARTIDA=@PARTIDAAnt
  ;";

                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    OleDbHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
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


        [AutoComplete]
        public CPEDIDOENVIOBE seleccionarPEDIDOENVIO(CPEDIDOENVIOBE oCPEDIDOENVIO, OleDbTransaction st)
        {




            CPEDIDOENVIOBE retorno = new CPEDIDOENVIOBE();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;

                String CmdTxt = @"select * from PEDIDOENVIO where
 VENTA=@VENTA    and
 PRODUCTO=@PRODUCTO    and
 PARTIDA=@PARTIDA  ";


                auxPar = new OleDbParameter("@VENTA", OleDbType.VarChar);
                auxPar.Value = oCPEDIDOENVIO.IVENTA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                auxPar.Value = oCPEDIDOENVIO.IPRODUCTO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PARTIDA", OleDbType.Double);
                auxPar.Value = oCPEDIDOENVIO.IPARTIDA;
                parts.Add(auxPar);




                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                OleDbDataReader dr;
                if (st == null)
                    dr = OleDbHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, arParms);
                else
                    dr = OleDbHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["VENTA"] != System.DBNull.Value)
                    {
                        retorno.IVENTA = (string)(dr["VENTA"]);
                    }

                    if (dr["COMPRA"] != System.DBNull.Value)
                    {
                        retorno.ICOMPRA = (double)(dr["COMPRA"]);
                    }

                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTO = (string)(dr["PRODUCTO"]);
                    }

                    if (dr["DESC1"] != System.DBNull.Value)
                    {
                        retorno.IDESC1 = (string)(dr["DESC1"]);
                    }

                    if (dr["LINEA"] != System.DBNull.Value)
                    {
                        retorno.ILINEA = (string)(dr["LINEA"]);
                    }

                    if (dr["MARCA"] != System.DBNull.Value)
                    {
                        retorno.IMARCA = (string)(dr["MARCA"]);
                    }

                    if (dr["PROVEEDOR"] != System.DBNull.Value)
                    {
                        retorno.IPROVEEDOR = (string)(dr["PROVEEDOR"]);
                    }

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDAD = (double)(dr["CANTIDAD"]);
                    }

                    if (dr["SURTIDA"] != System.DBNull.Value)
                    {
                        retorno.ISURTIDA = (double)(dr["SURTIDA"]);
                    }

                    if (dr["FALTANTE"] != System.DBNull.Value)
                    {
                        retorno.IFALTANTE = (double)(dr["FALTANTE"]);
                    }

                    if (dr["COSTO"] != System.DBNull.Value)
                    {
                        retorno.ICOSTO = (double)(dr["COSTO"]);
                    }

                    if (dr["CARGOS_U"] != System.DBNull.Value)
                    {
                        retorno.ICARGOS_U = (double)(dr["CARGOS_U"]);
                    }

                    if (dr["IMPORTE"] != System.DBNull.Value)
                    {
                        retorno.IIMPORTE = (double)(dr["IMPORTE"]);
                    }

                    if (dr["IMPORTNETO"] != System.DBNull.Value)
                    {
                        retorno.IIMPORTNETO = (double)(dr["IMPORTNETO"]);
                    }

                    if (dr["FECHA"] != System.DBNull.Value)
                    {
                        retorno.IFECHA = (DateTime)(dr["FECHA"]);
                    }

                    if (dr["ESTATUS"] != System.DBNull.Value)
                    {
                        retorno.IESTATUS = (string)(dr["ESTATUS"]);
                    }

                    if (dr["PIEZAS"] != System.DBNull.Value)
                    {
                        retorno.IPIEZAS = (double)(dr["PIEZAS"]);
                    }

                    if (dr["PARTIDA"] != System.DBNull.Value)
                    {
                        retorno.IPARTIDA = (double)(dr["PARTIDA"]);
                    }

                    if (dr["TRANSA"] != System.DBNull.Value)
                    {
                        retorno.ITRANSA = (double)(dr["TRANSA"]);
                    }

                    if (dr["DESCUENTO"] != System.DBNull.Value)
                    {
                        retorno.IDESCUENTO = (double)(dr["DESCUENTO"]);
                    }

                    if (dr["MONEDA"] != System.DBNull.Value)
                    {
                        retorno.IMONEDA = (string)(dr["MONEDA"]);
                    }

                    if (dr["COSTO_INI"] != System.DBNull.Value)
                    {
                        retorno.ICOSTO_INI = (double)(dr["COSTO_INI"]);
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

                    if (dr["TRANS_LOTE"] != System.DBNull.Value)
                    {
                        retorno.ITRANS_LOTE = (string)(dr["TRANS_LOTE"]);
                    }

                    if (dr["CLIENTE"] != System.DBNull.Value)
                    {
                        retorno.ICLIENTE = (string)(dr["CLIENTE"]);
                    }

                    if (dr["LOTE"] != System.DBNull.Value)
                    {
                        retorno.ILOTE = (string)(dr["LOTE"]);
                    }

                    if (dr["F_CADUCA"] != System.DBNull.Value)
                    {
                        retorno.IF_CADUCA = (DateTime)(dr["F_CADUCA"]);
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









        [AutoComplete]
        public DataSet enlistarPEDIDOENVIO()
        {

            DataSet retorno;
            try
            {
                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PEDIDOENVIO_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoPEDIDOENVIO()
        {
            DataSet retorno;
            try
            {

                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PEDIDOENVIO_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExistePEDIDOENVIO(CPEDIDOENVIOBE oCPEDIDOENVIO, OleDbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@VENTA", OleDbType.VarChar);
                auxPar.Value = oCPEDIDOENVIO.IVENTA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                auxPar.Value = oCPEDIDOENVIO.IPRODUCTO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PARTIDA", OleDbType.Double);
                auxPar.Value = oCPEDIDOENVIO.IPARTIDA;
                parts.Add(auxPar);

                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from PEDIDOENVIO where

  VENTA=@VENTA    and

  PRODUCTO=@PRODUCTO    and

  PARTIDA=@PARTIDA  
  );";






                OleDbDataReader dr;
                if (st == null)
                    dr = OleDbHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    dr = OleDbHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);



                if (dr.Read())
                {
                    retorno = 1;
                }
                else
                {
                    retorno = 0;
                }

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return -1;
            }
        }




        public CPEDIDOENVIOBE AgregarPEDIDOENVIO(CPEDIDOENVIOBE oCPEDIDOENVIO, OleDbTransaction st)
        {
            try
            {
                int iRes = ExistePEDIDOENVIO(oCPEDIDOENVIO, st);
                if (iRes == 1)
                {
                    this.IComentario = "El PEDIDOENVIO ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return null;// AgregarPEDIDOENVIOD(oCPEDIDOENVIO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarPEDIDOENVIO(CPEDIDOENVIOBE oCPEDIDOENVIO, OleDbTransaction st)
        {
            try
            {
                int iRes = ExistePEDIDOENVIO(oCPEDIDOENVIO, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PEDIDOENVIO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarPEDIDOENVIOD(oCPEDIDOENVIO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarPEDIDOENVIO(CPEDIDOENVIOBE oCPEDIDOENVIONuevo, CPEDIDOENVIOBE oCPEDIDOENVIOAnterior, OleDbTransaction st)
        {
            try
            {
                int iRes = ExistePEDIDOENVIO(oCPEDIDOENVIOAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PEDIDOENVIO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarPEDIDOENVIOD(oCPEDIDOENVIONuevo, oCPEDIDOENVIOAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CPEDIDOENVIOD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
