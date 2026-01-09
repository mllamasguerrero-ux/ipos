
using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Data.OleDb;
using DataLayer;
using System.Collections;
using ConexionesBD;


namespace iPosData
{

    [Transaction(TransactionOption.Supported)]


    public class CM_TRASD
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
        public CM_TRASBE AgregarM_TRASD(CM_TRASBE oCM_TRAS, string strTableName, OleDbTransaction st, string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@VENTA", OleDbType.VarChar);
                if (!(bool)oCM_TRAS.isnull["IVENTA"])
                {
                    auxPar.Value = oCM_TRAS.IVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMPRA", OleDbType.Double);
                if (!(bool)oCM_TRAS.isnull["ICOMPRA"])
                {
                    auxPar.Value = oCM_TRAS.ICOMPRA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                if (!(bool)oCM_TRAS.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCM_TRAS.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LINEA", OleDbType.VarChar);
                if (!(bool)oCM_TRAS.isnull["ILINEA"])
                {
                    auxPar.Value = oCM_TRAS.ILINEA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MARCA", OleDbType.VarChar);
                if (!(bool)oCM_TRAS.isnull["IMARCA"])
                {
                    auxPar.Value = oCM_TRAS.IMARCA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PROVEEDOR", OleDbType.VarChar);
                if (!(bool)oCM_TRAS.isnull["IPROVEEDOR"])
                {
                    auxPar.Value = oCM_TRAS.IPROVEEDOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                if (!(bool)oCM_TRAS.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCM_TRAS.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SURTIDA", OleDbType.Double);
                if (!(bool)oCM_TRAS.isnull["ISURTIDA"])
                {
                    auxPar.Value = oCM_TRAS.ISURTIDA;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FALTANTE", OleDbType.Double);
                if (!(bool)oCM_TRAS.isnull["IFALTANTE"])
                {
                    auxPar.Value = oCM_TRAS.IFALTANTE;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTO", OleDbType.Double);
                if (!(bool)oCM_TRAS.isnull["ICOSTO"])
                {
                    auxPar.Value = oCM_TRAS.ICOSTO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CARGOS_U", OleDbType.Double);
                if (!(bool)oCM_TRAS.isnull["ICARGOS_U"])
                {
                    auxPar.Value = oCM_TRAS.ICARGOS_U;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Double);
                if (!(bool)oCM_TRAS.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCM_TRAS.IIMPORTE;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTNETO", OleDbType.Double);
                if (!(bool)oCM_TRAS.isnull["IIMPORTNETO"])
                {
                    auxPar.Value = oCM_TRAS.IIMPORTNETO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);




                auxPar = new OleDbParameter("@FECHA", OleDbType.Date);
                if (!(bool)oCM_TRAS.isnull["IFECHA"])
                {
                    auxPar.Value = oCM_TRAS.IFECHA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTATUS", OleDbType.VarChar);
                if (!(bool)oCM_TRAS.isnull["IESTATUS"])
                {
                    auxPar.Value = oCM_TRAS.IESTATUS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PIEZAS", OleDbType.Double);
                if (!(bool)oCM_TRAS.isnull["IPIEZAS"])
                {
                    auxPar.Value = oCM_TRAS.IPIEZAS;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PARTIDA", OleDbType.Double);
                if (!(bool)oCM_TRAS.isnull["IPARTIDA"])
                {
                    auxPar.Value = oCM_TRAS.IPARTIDA;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TRANSA", OleDbType.Double);
                if (!(bool)oCM_TRAS.isnull["ITRANSA"])
                {
                    auxPar.Value = oCM_TRAS.ITRANSA;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESCUENTO", OleDbType.Double);
                if (!(bool)oCM_TRAS.isnull["IDESCUENTO"])
                {
                    auxPar.Value = oCM_TRAS.IDESCUENTO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MONEDA", OleDbType.VarChar);
                if (!(bool)oCM_TRAS.isnull["IMONEDA"])
                {
                    auxPar.Value = oCM_TRAS.IMONEDA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTO_INI", OleDbType.Double);
                if (!(bool)oCM_TRAS.isnull["ICOSTO_INI"])
                {
                    auxPar.Value = oCM_TRAS.ICOSTO_INI;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_TRAS.isnull["IID"])
                {
                    auxPar.Value = oCM_TRAS.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCM_TRAS.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_TRAS.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;// System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCM_TRAS.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_TRAS.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TRANS_LOTE", OleDbType.VarChar);
                if (!(bool)oCM_TRAS.isnull["ITRANS_LOTE"])
                {
                    auxPar.Value = oCM_TRAS.ITRANS_LOTE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                if (!(bool)oCM_TRAS.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCM_TRAS.ICLIENTE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LOTE", OleDbType.VarChar);
                if (!(bool)oCM_TRAS.isnull["ILOTE"])
                {
                    auxPar.Value = oCM_TRAS.ILOTE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@F_CADUCA", OleDbType.Date);
                if (!(bool)oCM_TRAS.isnull["IF_CADUCA"])
                {
                    auxPar.Value = oCM_TRAS.IF_CADUCA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;// System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANT_FAC", OleDbType.Double);
                if (!(bool)oCM_TRAS.isnull["ICANT_FAC"])
                {
                    auxPar.Value = oCM_TRAS.ICANT_FAC;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANT_REM", OleDbType.Double);
                if (!(bool)oCM_TRAS.isnull["ICANT_REM"])
                {
                    auxPar.Value = oCM_TRAS.ICANT_REM;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANT_IND", OleDbType.Double);
                if (!(bool)oCM_TRAS.isnull["ICANT_IND"])
                {
                    auxPar.Value = oCM_TRAS.ICANT_IND;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PRECREC", OleDbType.Double);
                if (!(bool)oCM_TRAS.isnull["IPRECREC"])
                {
                    auxPar.Value = oCM_TRAS.IPRECREC;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CVEUSER", OleDbType.VarChar);
                if (!(bool)oCM_TRAS.isnull["ICVEUSER"])
                {
                    auxPar.Value = oCM_TRAS.ICVEUSER;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);




                auxPar = new OleDbParameter("@IMP_PED", OleDbType.VarChar);
                if (!(bool)oCM_TRAS.isnull["IIMP_PED"])
                {
                    auxPar.Value = oCM_TRAS.IIMP_PED;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@IMP_FEC", OleDbType.Date);
                if (!(bool)oCM_TRAS.isnull["IIMP_FEC"])
                {
                    auxPar.Value = oCM_TRAS.IIMP_FEC;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;// System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMP_ADU", OleDbType.VarChar);
                if (!(bool)oCM_TRAS.isnull["IIMP_ADU"])
                {
                    auxPar.Value = oCM_TRAS.IIMP_ADU;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMP_TC", OleDbType.Double);
                if (!(bool)oCM_TRAS.isnull["IIMP_TC"])
                {
                    auxPar.Value = oCM_TRAS.IIMP_TC;
                }
                else
                {
                    auxPar.Value = 1;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SUCURSAL", OleDbType.VarChar);
                if (!(bool)oCM_TRAS.isnull["ISUCURSAL"])
                {
                    auxPar.Value = oCM_TRAS.ISUCURSAL;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                string commandText = @"
        INSERT INTO '" + strTableName + @"' 
      (
    
VENTA,

COMPRA,

PRODUCTO,

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

CVEUSER,

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

                return oCM_TRAS;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarM_TRASD(CM_TRASBE oCM_TRAS, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@VENTA", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.IVENTA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMPRA", OleDbType.Double);
                auxPar.Value = oCM_TRAS.ICOMPRA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.IPRODUCTO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LINEA", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.ILINEA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MARCA", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.IMARCA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PROVEEDOR", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.IPROVEEDOR;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                auxPar.Value = oCM_TRAS.ICANTIDAD;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SURTIDA", OleDbType.Double);
                auxPar.Value = oCM_TRAS.ISURTIDA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FALTANTE", OleDbType.Double);
                auxPar.Value = oCM_TRAS.IFALTANTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTO", OleDbType.Double);
                auxPar.Value = oCM_TRAS.ICOSTO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CARGOS_U", OleDbType.Double);
                auxPar.Value = oCM_TRAS.ICARGOS_U;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Double);
                auxPar.Value = oCM_TRAS.IIMPORTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTNETO", OleDbType.Double);
                auxPar.Value = oCM_TRAS.IIMPORTNETO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FECHA", OleDbType.Date);
                auxPar.Value = oCM_TRAS.IFECHA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTATUS", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.IESTATUS;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PIEZAS", OleDbType.Double);
                auxPar.Value = oCM_TRAS.IPIEZAS;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PARTIDA", OleDbType.Double);
                auxPar.Value = oCM_TRAS.IPARTIDA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TRANSA", OleDbType.Double);
                auxPar.Value = oCM_TRAS.ITRANSA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESCUENTO", OleDbType.Double);
                auxPar.Value = oCM_TRAS.IDESCUENTO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MONEDA", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.IMONEDA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTO_INI", OleDbType.Double);
                auxPar.Value = oCM_TRAS.ICOSTO_INI;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.IID;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                auxPar.Value = oCM_TRAS.IID_FECHA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.IID_HORA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TRANS_LOTE", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.ITRANS_LOTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.ICLIENTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LOTE", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.ILOTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@F_CADUCA", OleDbType.Date);
                auxPar.Value = oCM_TRAS.IF_CADUCA;
                parts.Add(auxPar);



                string commandText = @"  Delete from M_TRAS
  where

  VENTA=@VENTA and 

  COMPRA=@COMPRA and 

  PRODUCTO=@PRODUCTO and 

  LINEA=@LINEA and 

  MARCA=@MARCA and 

  PROVEEDOR=@PROVEEDOR and 

  CANTIDAD=@CANTIDAD and 

  SURTIDA=@SURTIDA and 

  FALTANTE=@FALTANTE and 

  COSTO=@COSTO and 

  CARGOS_U=@CARGOS_U and 

  IMPORTE=@IMPORTE and 

  IMPORTNETO=@IMPORTNETO and 

  FECHA=@FECHA and 

  ESTATUS=@ESTATUS and 

  PIEZAS=@PIEZAS and 

  PARTIDA=@PARTIDA and 

  TRANSA=@TRANSA and 

  DESCUENTO=@DESCUENTO and 

  MONEDA=@MONEDA and 

  COSTO_INI=@COSTO_INI and 

  ID=@ID and 

  ID_FECHA=@ID_FECHA and 

  ID_HORA=@ID_HORA and 

  TRANS_LOTE=@TRANS_LOTE and 

  CLIENTE=@CLIENTE and 

  LOTE=@LOTE and 

  F_CADUCA=@F_CADUCA
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
        public bool CambiarM_TRASD(CM_TRASBE oCM_TRASNuevo, CM_TRASBE oCM_TRASAnterior, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@VENTA", OleDbType.VarChar);
                if (!(bool)oCM_TRASNuevo.isnull["IVENTA"])
                {
                    auxPar.Value = oCM_TRASNuevo.IVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COMPRA", OleDbType.Double);
                if (!(bool)oCM_TRASNuevo.isnull["ICOMPRA"])
                {
                    auxPar.Value = oCM_TRASNuevo.ICOMPRA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                if (!(bool)oCM_TRASNuevo.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCM_TRASNuevo.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@LINEA", OleDbType.VarChar);
                if (!(bool)oCM_TRASNuevo.isnull["ILINEA"])
                {
                    auxPar.Value = oCM_TRASNuevo.ILINEA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@MARCA", OleDbType.VarChar);
                if (!(bool)oCM_TRASNuevo.isnull["IMARCA"])
                {
                    auxPar.Value = oCM_TRASNuevo.IMARCA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PROVEEDOR", OleDbType.VarChar);
                if (!(bool)oCM_TRASNuevo.isnull["IPROVEEDOR"])
                {
                    auxPar.Value = oCM_TRASNuevo.IPROVEEDOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                if (!(bool)oCM_TRASNuevo.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCM_TRASNuevo.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SURTIDA", OleDbType.Double);
                if (!(bool)oCM_TRASNuevo.isnull["ISURTIDA"])
                {
                    auxPar.Value = oCM_TRASNuevo.ISURTIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@FALTANTE", OleDbType.Double);
                if (!(bool)oCM_TRASNuevo.isnull["IFALTANTE"])
                {
                    auxPar.Value = oCM_TRASNuevo.IFALTANTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COSTO", OleDbType.Double);
                if (!(bool)oCM_TRASNuevo.isnull["ICOSTO"])
                {
                    auxPar.Value = oCM_TRASNuevo.ICOSTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CARGOS_U", OleDbType.Double);
                if (!(bool)oCM_TRASNuevo.isnull["ICARGOS_U"])
                {
                    auxPar.Value = oCM_TRASNuevo.ICARGOS_U;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Double);
                if (!(bool)oCM_TRASNuevo.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCM_TRASNuevo.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IMPORTNETO", OleDbType.Double);
                if (!(bool)oCM_TRASNuevo.isnull["IIMPORTNETO"])
                {
                    auxPar.Value = oCM_TRASNuevo.IIMPORTNETO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ESTATUS", OleDbType.VarChar);
                if (!(bool)oCM_TRASNuevo.isnull["IESTATUS"])
                {
                    auxPar.Value = oCM_TRASNuevo.IESTATUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PIEZAS", OleDbType.Double);
                if (!(bool)oCM_TRASNuevo.isnull["IPIEZAS"])
                {
                    auxPar.Value = oCM_TRASNuevo.IPIEZAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PARTIDA", OleDbType.Double);
                if (!(bool)oCM_TRASNuevo.isnull["IPARTIDA"])
                {
                    auxPar.Value = oCM_TRASNuevo.IPARTIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TRANSA", OleDbType.Double);
                if (!(bool)oCM_TRASNuevo.isnull["ITRANSA"])
                {
                    auxPar.Value = oCM_TRASNuevo.ITRANSA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@DESCUENTO", OleDbType.Double);
                if (!(bool)oCM_TRASNuevo.isnull["IDESCUENTO"])
                {
                    auxPar.Value = oCM_TRASNuevo.IDESCUENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@MONEDA", OleDbType.VarChar);
                if (!(bool)oCM_TRASNuevo.isnull["IMONEDA"])
                {
                    auxPar.Value = oCM_TRASNuevo.IMONEDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COSTO_INI", OleDbType.Double);
                if (!(bool)oCM_TRASNuevo.isnull["ICOSTO_INI"])
                {
                    auxPar.Value = oCM_TRASNuevo.ICOSTO_INI;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCM_TRASNuevo.isnull["IID"])
                {
                    auxPar.Value = oCM_TRASNuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCM_TRASNuevo.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_TRASNuevo.IID_HORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TRANS_LOTE", OleDbType.VarChar);
                if (!(bool)oCM_TRASNuevo.isnull["ITRANS_LOTE"])
                {
                    auxPar.Value = oCM_TRASNuevo.ITRANS_LOTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                if (!(bool)oCM_TRASNuevo.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCM_TRASNuevo.ICLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@LOTE", OleDbType.VarChar);
                if (!(bool)oCM_TRASNuevo.isnull["ILOTE"])
                {
                    auxPar.Value = oCM_TRASNuevo.ILOTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@VENTAAnt", OleDbType.VarChar);
                if (!(bool)oCM_TRASAnterior.isnull["IVENTA"])
                {
                    auxPar.Value = oCM_TRASAnterior.IVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COMPRAAnt", OleDbType.Double);
                if (!(bool)oCM_TRASAnterior.isnull["ICOMPRA"])
                {
                    auxPar.Value = oCM_TRASAnterior.ICOMPRA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PRODUCTOAnt", OleDbType.VarChar);
                if (!(bool)oCM_TRASAnterior.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCM_TRASAnterior.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@LINEAAnt", OleDbType.VarChar);
                if (!(bool)oCM_TRASAnterior.isnull["ILINEA"])
                {
                    auxPar.Value = oCM_TRASAnterior.ILINEA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@MARCAAnt", OleDbType.VarChar);
                if (!(bool)oCM_TRASAnterior.isnull["IMARCA"])
                {
                    auxPar.Value = oCM_TRASAnterior.IMARCA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PROVEEDORAnt", OleDbType.VarChar);
                if (!(bool)oCM_TRASAnterior.isnull["IPROVEEDOR"])
                {
                    auxPar.Value = oCM_TRASAnterior.IPROVEEDOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CANTIDADAnt", OleDbType.Double);
                if (!(bool)oCM_TRASAnterior.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCM_TRASAnterior.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SURTIDAAnt", OleDbType.Double);
                if (!(bool)oCM_TRASAnterior.isnull["ISURTIDA"])
                {
                    auxPar.Value = oCM_TRASAnterior.ISURTIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@FALTANTEAnt", OleDbType.Double);
                if (!(bool)oCM_TRASAnterior.isnull["IFALTANTE"])
                {
                    auxPar.Value = oCM_TRASAnterior.IFALTANTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COSTOAnt", OleDbType.Double);
                if (!(bool)oCM_TRASAnterior.isnull["ICOSTO"])
                {
                    auxPar.Value = oCM_TRASAnterior.ICOSTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CARGOS_UAnt", OleDbType.Double);
                if (!(bool)oCM_TRASAnterior.isnull["ICARGOS_U"])
                {
                    auxPar.Value = oCM_TRASAnterior.ICARGOS_U;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IMPORTEAnt", OleDbType.Double);
                if (!(bool)oCM_TRASAnterior.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCM_TRASAnterior.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IMPORTNETOAnt", OleDbType.Double);
                if (!(bool)oCM_TRASAnterior.isnull["IIMPORTNETO"])
                {
                    auxPar.Value = oCM_TRASAnterior.IIMPORTNETO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@FECHAAnt", OleDbType.Date);
                if (!(bool)oCM_TRASAnterior.isnull["IFECHA"])
                {
                    auxPar.Value = oCM_TRASAnterior.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ESTATUSAnt", OleDbType.VarChar);
                if (!(bool)oCM_TRASAnterior.isnull["IESTATUS"])
                {
                    auxPar.Value = oCM_TRASAnterior.IESTATUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PIEZASAnt", OleDbType.Double);
                if (!(bool)oCM_TRASAnterior.isnull["IPIEZAS"])
                {
                    auxPar.Value = oCM_TRASAnterior.IPIEZAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PARTIDAAnt", OleDbType.Double);
                if (!(bool)oCM_TRASAnterior.isnull["IPARTIDA"])
                {
                    auxPar.Value = oCM_TRASAnterior.IPARTIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TRANSAAnt", OleDbType.Double);
                if (!(bool)oCM_TRASAnterior.isnull["ITRANSA"])
                {
                    auxPar.Value = oCM_TRASAnterior.ITRANSA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@DESCUENTOAnt", OleDbType.Double);
                if (!(bool)oCM_TRASAnterior.isnull["IDESCUENTO"])
                {
                    auxPar.Value = oCM_TRASAnterior.IDESCUENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@MONEDAAnt", OleDbType.VarChar);
                if (!(bool)oCM_TRASAnterior.isnull["IMONEDA"])
                {
                    auxPar.Value = oCM_TRASAnterior.IMONEDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COSTO_INIAnt", OleDbType.Double);
                if (!(bool)oCM_TRASAnterior.isnull["ICOSTO_INI"])
                {
                    auxPar.Value = oCM_TRASAnterior.ICOSTO_INI;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IDAnt", OleDbType.VarChar);
                if (!(bool)oCM_TRASAnterior.isnull["IID"])
                {
                    auxPar.Value = oCM_TRASAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_FECHAAnt", OleDbType.Date);
                if (!(bool)oCM_TRASAnterior.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCM_TRASAnterior.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_HORAAnt", OleDbType.VarChar);
                if (!(bool)oCM_TRASAnterior.isnull["IID_HORA"])
                {
                    auxPar.Value = oCM_TRASAnterior.IID_HORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TRANS_LOTEAnt", OleDbType.VarChar);
                if (!(bool)oCM_TRASAnterior.isnull["ITRANS_LOTE"])
                {
                    auxPar.Value = oCM_TRASAnterior.ITRANS_LOTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CLIENTEAnt", OleDbType.VarChar);
                if (!(bool)oCM_TRASAnterior.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCM_TRASAnterior.ICLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@LOTEAnt", OleDbType.VarChar);
                if (!(bool)oCM_TRASAnterior.isnull["ILOTE"])
                {
                    auxPar.Value = oCM_TRASAnterior.ILOTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@F_CADUCAAnt", OleDbType.Date);
                if (!(bool)oCM_TRASAnterior.isnull["IF_CADUCA"])
                {
                    auxPar.Value = oCM_TRASAnterior.IF_CADUCA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  M_TRAS
  set

VENTA=@VENTA,

COMPRA=@COMPRA,

PRODUCTO=@PRODUCTO,

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

ESTATUS=@ESTATUS,

PIEZAS=@PIEZAS,

PARTIDA=@PARTIDA,

TRANSA=@TRANSA,

DESCUENTO=@DESCUENTO,

MONEDA=@MONEDA,

COSTO_INI=@COSTO_INI,

ID=@ID,

ID_HORA=@ID_HORA,

TRANS_LOTE=@TRANS_LOTE,

CLIENTE=@CLIENTE,

LOTE=@LOTE
  where 

VENTA=@VENTAAnt and

COMPRA=@COMPRAAnt and

PRODUCTO=@PRODUCTOAnt and

LINEA=@LINEAAnt and

MARCA=@MARCAAnt and

PROVEEDOR=@PROVEEDORAnt and

CANTIDAD=@CANTIDADAnt and

SURTIDA=@SURTIDAAnt and

FALTANTE=@FALTANTEAnt and

COSTO=@COSTOAnt and

CARGOS_U=@CARGOS_UAnt and

IMPORTE=@IMPORTEAnt and

IMPORTNETO=@IMPORTNETOAnt and

FECHA=@FECHAAnt and

ESTATUS=@ESTATUSAnt and

PIEZAS=@PIEZASAnt and

PARTIDA=@PARTIDAAnt and

TRANSA=@TRANSAAnt and

DESCUENTO=@DESCUENTOAnt and

MONEDA=@MONEDAAnt and

COSTO_INI=@COSTO_INIAnt and

ID=@IDAnt and

ID_FECHA=@ID_FECHAAnt and

ID_HORA=@ID_HORAAnt and

TRANS_LOTE=@TRANS_LOTEAnt and

CLIENTE=@CLIENTEAnt and

LOTE=@LOTEAnt and

F_CADUCA=@F_CADUCAAnt
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
        public CM_TRASBE seleccionarM_TRAS(CM_TRASBE oCM_TRAS, OleDbTransaction st)
        {




            CM_TRASBE retorno = new CM_TRASBE();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;

                String CmdTxt = @"select * from M_TRAS where
 VENTA=@VENTA    and
 COMPRA=@COMPRA    and
 PRODUCTO=@PRODUCTO    and
 LINEA=@LINEA    and
 MARCA=@MARCA    and
 PROVEEDOR=@PROVEEDOR    and
 CANTIDAD=@CANTIDAD    and
 SURTIDA=@SURTIDA    and
 FALTANTE=@FALTANTE    and
 COSTO=@COSTO    and
 CARGOS_U=@CARGOS_U    and
 IMPORTE=@IMPORTE    and
 IMPORTNETO=@IMPORTNETO    and
 FECHA=@FECHA    and
 ESTATUS=@ESTATUS    and
 PIEZAS=@PIEZAS    and
 PARTIDA=@PARTIDA    and
 TRANSA=@TRANSA    and
 DESCUENTO=@DESCUENTO    and
 MONEDA=@MONEDA    and
 COSTO_INI=@COSTO_INI    and
 ID=@ID    and
 ID_FECHA=@ID_FECHA    and
 ID_HORA=@ID_HORA    and
 TRANS_LOTE=@TRANS_LOTE    and
 CLIENTE=@CLIENTE    and
 LOTE=@LOTE    and
 F_CADUCA=@F_CADUCA  ";


                auxPar = new OleDbParameter("@VENTA", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.IVENTA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@COMPRA", OleDbType.Double);
                auxPar.Value = oCM_TRAS.ICOMPRA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.IPRODUCTO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@LINEA", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.ILINEA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@MARCA", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.IMARCA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PROVEEDOR", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.IPROVEEDOR;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                auxPar.Value = oCM_TRAS.ICANTIDAD;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@SURTIDA", OleDbType.Double);
                auxPar.Value = oCM_TRAS.ISURTIDA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@FALTANTE", OleDbType.Double);
                auxPar.Value = oCM_TRAS.IFALTANTE;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@COSTO", OleDbType.Double);
                auxPar.Value = oCM_TRAS.ICOSTO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@CARGOS_U", OleDbType.Double);
                auxPar.Value = oCM_TRAS.ICARGOS_U;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Double);
                auxPar.Value = oCM_TRAS.IIMPORTE;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@IMPORTNETO", OleDbType.Double);
                auxPar.Value = oCM_TRAS.IIMPORTNETO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@FECHA", OleDbType.Date);
                auxPar.Value = oCM_TRAS.IFECHA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ESTATUS", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.IESTATUS;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PIEZAS", OleDbType.Double);
                auxPar.Value = oCM_TRAS.IPIEZAS;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PARTIDA", OleDbType.Double);
                auxPar.Value = oCM_TRAS.IPARTIDA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@TRANSA", OleDbType.Double);
                auxPar.Value = oCM_TRAS.ITRANSA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@DESCUENTO", OleDbType.Double);
                auxPar.Value = oCM_TRAS.IDESCUENTO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@MONEDA", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.IMONEDA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@COSTO_INI", OleDbType.Double);
                auxPar.Value = oCM_TRAS.ICOSTO_INI;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.IID;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                auxPar.Value = oCM_TRAS.IID_FECHA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.IID_HORA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@TRANS_LOTE", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.ITRANS_LOTE;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.ICLIENTE;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@LOTE", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.ILOTE;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@F_CADUCA", OleDbType.Date);
                auxPar.Value = oCM_TRAS.IF_CADUCA;
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
        public DataSet enlistarM_TRAS()
        {

            DataSet retorno;
            try
            {
                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_M_TRAS_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoM_TRAS()
        {
            DataSet retorno;
            try
            {

                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_M_TRAS_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteM_TRAS(CM_TRASBE oCM_TRAS, OleDbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@VENTA", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.IVENTA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMPRA", OleDbType.Double);
                auxPar.Value = oCM_TRAS.ICOMPRA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.IPRODUCTO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LINEA", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.ILINEA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MARCA", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.IMARCA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PROVEEDOR", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.IPROVEEDOR;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Double);
                auxPar.Value = oCM_TRAS.ICANTIDAD;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SURTIDA", OleDbType.Double);
                auxPar.Value = oCM_TRAS.ISURTIDA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FALTANTE", OleDbType.Double);
                auxPar.Value = oCM_TRAS.IFALTANTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTO", OleDbType.Double);
                auxPar.Value = oCM_TRAS.ICOSTO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CARGOS_U", OleDbType.Double);
                auxPar.Value = oCM_TRAS.ICARGOS_U;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Double);
                auxPar.Value = oCM_TRAS.IIMPORTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTNETO", OleDbType.Double);
                auxPar.Value = oCM_TRAS.IIMPORTNETO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FECHA", OleDbType.Date);
                auxPar.Value = oCM_TRAS.IFECHA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTATUS", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.IESTATUS;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PIEZAS", OleDbType.Double);
                auxPar.Value = oCM_TRAS.IPIEZAS;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PARTIDA", OleDbType.Double);
                auxPar.Value = oCM_TRAS.IPARTIDA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TRANSA", OleDbType.Double);
                auxPar.Value = oCM_TRAS.ITRANSA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESCUENTO", OleDbType.Double);
                auxPar.Value = oCM_TRAS.IDESCUENTO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MONEDA", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.IMONEDA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTO_INI", OleDbType.Double);
                auxPar.Value = oCM_TRAS.ICOSTO_INI;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.IID;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                auxPar.Value = oCM_TRAS.IID_FECHA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.IID_HORA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TRANS_LOTE", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.ITRANS_LOTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.ICLIENTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LOTE", OleDbType.VarChar);
                auxPar.Value = oCM_TRAS.ILOTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@F_CADUCA", OleDbType.Date);
                auxPar.Value = oCM_TRAS.IF_CADUCA;
                parts.Add(auxPar);

                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from M_TRAS where

  VENTA=@VENTA    and

  COMPRA=@COMPRA    and

  PRODUCTO=@PRODUCTO    and

  LINEA=@LINEA    and

  MARCA=@MARCA    and

  PROVEEDOR=@PROVEEDOR    and

  CANTIDAD=@CANTIDAD    and

  SURTIDA=@SURTIDA    and

  FALTANTE=@FALTANTE    and

  COSTO=@COSTO    and

  CARGOS_U=@CARGOS_U    and

  IMPORTE=@IMPORTE    and

  IMPORTNETO=@IMPORTNETO    and

  FECHA=@FECHA    and

  ESTATUS=@ESTATUS    and

  PIEZAS=@PIEZAS    and

  PARTIDA=@PARTIDA    and

  TRANSA=@TRANSA    and

  DESCUENTO=@DESCUENTO    and

  MONEDA=@MONEDA    and

  COSTO_INI=@COSTO_INI    and

  ID=@ID    and

  ID_FECHA=@ID_FECHA    and

  ID_HORA=@ID_HORA    and

  TRANS_LOTE=@TRANS_LOTE    and

  CLIENTE=@CLIENTE    and

  LOTE=@LOTE    and

  F_CADUCA=@F_CADUCA  
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




        public CM_TRASBE AgregarM_TRAS(CM_TRASBE oCM_TRAS, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteM_TRAS(oCM_TRAS, st);
                if (iRes == 1)
                {
                    this.IComentario = "El M_TRAS ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarM_TRASD(oCM_TRAS, "", st,"");
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarM_TRAS(CM_TRASBE oCM_TRAS, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteM_TRAS(oCM_TRAS, st);
                if (iRes == 0)
                {
                    this.IComentario = "El M_TRAS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarM_TRASD(oCM_TRAS, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarM_TRAS(CM_TRASBE oCM_TRASNuevo, CM_TRASBE oCM_TRASAnterior, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteM_TRAS(oCM_TRASAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El M_TRAS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarM_TRASD(oCM_TRASNuevo, oCM_TRASAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CM_TRASD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
