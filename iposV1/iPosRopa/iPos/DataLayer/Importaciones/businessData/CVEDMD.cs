

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


    public class CVEDMD
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
        public bool AgregarVEDMD(CVEDMBE oCVEDM, string strFileName, OleDbTransaction st, string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@VENTA", OleDbType.VarChar);
                if (!(bool)oCVEDM.isnull["IVENTA"])
                {
                    auxPar.Value = oCVEDM.IVENTA;
                }
                else
                {
                    auxPar.Value = "";// System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                if (!(bool)oCVEDM.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCVEDM.ICLIENTE;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Decimal);
                if (!(bool)oCVEDM.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCVEDM.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = 0;// System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                if (!(bool)oCVEDM.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCVEDM.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@REQUERIDO", OleDbType.Decimal);
                if (!(bool)oCVEDM.isnull["IREQUERIDO"])
                {
                    auxPar.Value = oCVEDM.IREQUERIDO;
                }
                else
                {
                    auxPar.Value = 0;//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PROVEEDOR", OleDbType.VarChar);
                if (!(bool)oCVEDM.isnull["IPROVEEDOR"])
                {
                    auxPar.Value = oCVEDM.IPROVEEDOR;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LINEA", OleDbType.VarChar);
                if (!(bool)oCVEDM.isnull["ILINEA"])
                {
                    auxPar.Value = oCVEDM.ILINEA;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MARCA", OleDbType.VarChar);
                if (!(bool)oCVEDM.isnull["IMARCA"])
                {
                    auxPar.Value = oCVEDM.IMARCA;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VENDEDOR", OleDbType.VarChar);
                if (!(bool)oCVEDM.isnull["IVENDEDOR"])
                {
                    auxPar.Value = oCVEDM.IVENDEDOR;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TIPO", OleDbType.VarChar);
                if (!(bool)oCVEDM.isnull["ITIPO"])
                {
                    auxPar.Value = oCVEDM.ITIPO;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLASIFICA", OleDbType.VarChar);
                if (!(bool)oCVEDM.isnull["ICLASIFICA"])
                {
                    auxPar.Value = oCVEDM.ICLASIFICA;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SERIE", OleDbType.VarChar);
                if (!(bool)oCVEDM.isnull["ISERIE"])
                {
                    auxPar.Value = oCVEDM.ISERIE;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO", OleDbType.Decimal);
                if (!(bool)oCVEDM.isnull["IPRECIO"])
                {
                    auxPar.Value = oCVEDM.IPRECIO;
                }
                else
                {
                    auxPar.Value = 0;//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PREC_LISTA", OleDbType.Decimal);
                if (!(bool)oCVEDM.isnull["IPREC_LISTA"])
                {
                    auxPar.Value = oCVEDM.IPREC_LISTA;
                }
                else
                {
                    auxPar.Value = 0;//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIOUS", OleDbType.Decimal);
                if (!(bool)oCVEDM.isnull["IPRECIOUS"])
                {
                    auxPar.Value = oCVEDM.IPRECIOUS;
                }
                else
                {
                    auxPar.Value = 0;//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FECHA", OleDbType.Date);
                if (!(bool)oCVEDM.isnull["IFECHA"])
                {
                    auxPar.Value = oCVEDM.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTATUS", OleDbType.VarChar);
                if (!(bool)oCVEDM.isnull["IESTATUS"])
                {
                    auxPar.Value = oCVEDM.IESTATUS;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Decimal);
                if (!(bool)oCVEDM.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCVEDM.IIMPORTE;
                }
                else
                {
                    auxPar.Value = 0;//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTNETO", OleDbType.Decimal);
                if (!(bool)oCVEDM.isnull["IIMPORTNETO"])
                {
                    auxPar.Value = oCVEDM.IIMPORTNETO;
                }
                else
                {
                    auxPar.Value = 0;//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CARGOS_U", OleDbType.Decimal);
                if (!(bool)oCVEDM.isnull["ICARGOS_U"])
                {
                    auxPar.Value = oCVEDM.ICARGOS_U;
                }
                else
                {
                    auxPar.Value = 0;//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTO_PU", OleDbType.Decimal);
                if (!(bool)oCVEDM.isnull["ICOSTO_PU"])
                {
                    auxPar.Value = oCVEDM.ICOSTO_PU;
                }
                else
                {
                    auxPar.Value = 0;//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MIN1", OleDbType.Decimal);
                if (!(bool)oCVEDM.isnull["IMIN1"])
                {
                    auxPar.Value = oCVEDM.IMIN1;
                }
                else
                {
                    auxPar.Value = 0;//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MAX1", OleDbType.Decimal);
                if (!(bool)oCVEDM.isnull["IMAX1"])
                {
                    auxPar.Value = oCVEDM.IMAX1;
                }
                else
                {
                    auxPar.Value = 0;//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TIENDA", OleDbType.Decimal);
                if (!(bool)oCVEDM.isnull["ITIENDA"])
                {
                    auxPar.Value = oCVEDM.ITIENDA;
                }
                else
                {
                    auxPar.Value = 0;//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTOTAL", OleDbType.Decimal);
                if (!(bool)oCVEDM.isnull["ICOSTOTAL"])
                {
                    auxPar.Value = oCVEDM.ICOSTOTAL;
                }
                else
                {
                    auxPar.Value = 0;//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTEUS", OleDbType.Decimal);
                if (!(bool)oCVEDM.isnull["IIMPORTEUS"])
                {
                    auxPar.Value = oCVEDM.IIMPORTEUS;
                }
                else
                {
                    auxPar.Value = 0;//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTOTOTUS", OleDbType.Decimal);
                if (!(bool)oCVEDM.isnull["ICOSTOTOTUS"])
                {
                    auxPar.Value = oCVEDM.ICOSTOTOTUS;
                }
                else
                {
                    auxPar.Value = 0;//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PIEZAS", OleDbType.Decimal);
                if (!(bool)oCVEDM.isnull["IPIEZAS"])
                {
                    auxPar.Value = oCVEDM.IPIEZAS;
                }
                else
                {
                    auxPar.Value = 0;//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESCUENTO", OleDbType.Decimal);
                if (!(bool)oCVEDM.isnull["IDESCUENTO"])
                {
                    auxPar.Value = oCVEDM.IDESCUENTO;
                }
                else
                {
                    auxPar.Value = 0;//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMISION", OleDbType.Decimal);
                if (!(bool)oCVEDM.isnull["ICOMISION"])
                {
                    auxPar.Value = oCVEDM.ICOMISION;
                }
                else
                {
                    auxPar.Value = 0;//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PAGADO", OleDbType.VarChar);
                if (!(bool)oCVEDM.isnull["IPAGADO"])
                {
                    auxPar.Value = oCVEDM.IPAGADO;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ORIGEN", OleDbType.VarChar);
                if (!(bool)oCVEDM.isnull["IORIGEN"])
                {
                    auxPar.Value = oCVEDM.IORIGEN;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SURTIDO", OleDbType.Decimal);
                if (!(bool)oCVEDM.isnull["ISURTIDO"])
                {
                    auxPar.Value = oCVEDM.ISURTIDO;
                }
                else
                {
                    auxPar.Value = 0;//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LOC", OleDbType.VarChar);
                if (!(bool)oCVEDM.isnull["ILOC"])
                {
                    auxPar.Value = oCVEDM.ILOC;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DEVUELTAS", OleDbType.Decimal);
                if (!(bool)oCVEDM.isnull["IDEVUELTAS"])
                {
                    auxPar.Value = oCVEDM.IDEVUELTAS;
                }
                else
                {
                    auxPar.Value = 0;// System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PARTIDA", OleDbType.Decimal);
                if (!(bool)oCVEDM.isnull["IPARTIDA"])
                {
                    auxPar.Value = oCVEDM.IPARTIDA;
                }
                else
                {
                    auxPar.Value = 0;//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TRANSA", OleDbType.Decimal);
                if (!(bool)oCVEDM.isnull["ITRANSA"])
                {
                    auxPar.Value = oCVEDM.ITRANSA;
                }
                else
                {
                    auxPar.Value = 0;//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TRANS_LOTE", OleDbType.Decimal);
                if (!(bool)oCVEDM.isnull["ITRANS_LOTE"])
                {
                    auxPar.Value = oCVEDM.ITRANS_LOTE;
                }
                else
                {
                    auxPar.Value = 0;//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EXPORTADO", OleDbType.VarChar);
                if (!(bool)oCVEDM.isnull["IEXPORTADO"])
                {
                    auxPar.Value = oCVEDM.IEXPORTADO;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SURTIR", OleDbType.Decimal);
                if (!(bool)oCVEDM.isnull["ISURTIR"])
                {
                    auxPar.Value = oCVEDM.ISURTIR;
                }
                else
                {
                    auxPar.Value = 0;//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EXPORTTADC", OleDbType.SmallInt);
                if (!(bool)oCVEDM.isnull["IEXPORTTADC"])
                {
                    auxPar.Value = oCVEDM.IEXPORTTADC;
                }
                else
                {
                    auxPar.Value = 0;//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MONEDA", OleDbType.VarChar);
                if (!(bool)oCVEDM.isnull["IMONEDA"])
                {
                    auxPar.Value = oCVEDM.IMONEDA;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@POLITICA", OleDbType.VarChar);
                if (!(bool)oCVEDM.isnull["IPOLITICA"])
                {
                    auxPar.Value = oCVEDM.IPOLITICA;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCVEDM.isnull["IID"])
                {
                    auxPar.Value = oCVEDM.IID;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCVEDM.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCVEDM.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCVEDM.isnull["IID_HORA"])
                {
                    auxPar.Value = oCVEDM.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PROMOCION", OleDbType.VarChar);
                if (!(bool)oCVEDM.isnull["IPROMOCION"])
                {
                    auxPar.Value = oCVEDM.IPROMOCION;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MOVIMIENTO", OleDbType.VarChar);
                if (!(bool)oCVEDM.isnull["IMOVIMIENTO"])
                {
                    auxPar.Value = oCVEDM.IMOVIMIENTO;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESC2", OleDbType.VarChar);
                if (!(bool)oCVEDM.isnull["IDESC2"])
                {
                    auxPar.Value = oCVEDM.IDESC2;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PIEZA", OleDbType.Decimal);
                if (!(bool)oCVEDM.isnull["IPIEZA"])
                {
                    auxPar.Value = oCVEDM.IPIEZA;
                }
                else
                {
                    auxPar.Value = 0;//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CAJAS", OleDbType.Decimal);
                if (!(bool)oCVEDM.isnull["ICAJAS"])
                {
                    auxPar.Value = oCVEDM.ICAJAS;
                }
                else
                {
                    auxPar.Value = 0;//System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PREC_MAYO", OleDbType.VarChar);
                if (!(bool)oCVEDM.isnull["IPREC_MAYO"])
                {
                    auxPar.Value = oCVEDM.IPREC_MAYO;
                }
                else
                {
                    auxPar.Value = "";//System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO " + strFileName + @" 
      (
    
VENTA,

CLIENTE,

CANTIDAD,

PRODUCTO,

REQUERIDO,

PROVEEDOR,

LINEA,

MARCA,

VENDEDOR,

TIPO,

CLASIFICA,

SERIE,

PRECIO,

PREC_LISTA,

PRECIOUS,

FECHA,

ESTATUS,

IMPORTE,

IMPORTNETO,

CARGOS_U,

COSTO_PU,

MIN1,

MAX1,

TIENDA,

COSTOTAL,

IMPORTEUS,

COSTOTOTUS,

PIEZAS,

DESCUENTO,

COMISION,

PAGADO,

ORIGEN,

SURTIDO,

LOC,

DEVUELTAS,

PARTIDA,

TRANSA,

TRANS_LOTE,

EXPORTADO,

SURTIR,

EXPORTTADC,

MONEDA,

POLITICA,

ID,

ID_FECHA,

ID_HORA,

PROMOCION,

MOVIMIENTO,

DESC2,

PIEZA,

CAJAS,

PREC_MAYO
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
        public bool BorrarVEDMD(CVEDMBE oCVEDM, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@VENTA", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IVENTA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                auxPar.Value = oCVEDM.ICLIENTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ICANTIDAD;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IPRODUCTO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@REQUERIDO", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IREQUERIDO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PROVEEDOR", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IPROVEEDOR;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LINEA", OleDbType.VarChar);
                auxPar.Value = oCVEDM.ILINEA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MARCA", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IMARCA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VENDEDOR", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IVENDEDOR;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TIPO", OleDbType.VarChar);
                auxPar.Value = oCVEDM.ITIPO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLASIFICA", OleDbType.VarChar);
                auxPar.Value = oCVEDM.ICLASIFICA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SERIE", OleDbType.VarChar);
                auxPar.Value = oCVEDM.ISERIE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IPRECIO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PREC_LISTA", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IPREC_LISTA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIOUS", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IPRECIOUS;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FECHA", OleDbType.Date);
                auxPar.Value = oCVEDM.IFECHA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTATUS", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IESTATUS;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IIMPORTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTNETO", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IIMPORTNETO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CARGOS_U", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ICARGOS_U;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTO_PU", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ICOSTO_PU;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MIN1", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IMIN1;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MAX1", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IMAX1;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TIENDA", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ITIENDA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTOTAL", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ICOSTOTAL;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTEUS", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IIMPORTEUS;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTOTOTUS", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ICOSTOTOTUS;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PIEZAS", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IPIEZAS;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESCUENTO", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IDESCUENTO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMISION", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ICOMISION;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PAGADO", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IPAGADO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ORIGEN", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IORIGEN;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SURTIDO", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ISURTIDO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LOC", OleDbType.VarChar);
                auxPar.Value = oCVEDM.ILOC;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DEVUELTAS", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IDEVUELTAS;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PARTIDA", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IPARTIDA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TRANSA", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ITRANSA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TRANS_LOTE", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ITRANS_LOTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EXPORTADO", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IEXPORTADO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SURTIR", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ISURTIR;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EXPORTTADC", OleDbType.SmallInt);
                auxPar.Value = oCVEDM.IEXPORTTADC;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MONEDA", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IMONEDA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@POLITICA", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IPOLITICA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IID;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                auxPar.Value = oCVEDM.IID_FECHA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IID_HORA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PROMOCION", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IPROMOCION;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MOVIMIENTO", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IMOVIMIENTO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESC2", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IDESC2;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PIEZA", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IPIEZA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CAJAS", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ICAJAS;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PREC_MAYO", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IPREC_MAYO;
                parts.Add(auxPar);



                string commandText = @"  Delete from VEDM
  where

  VENTA=@VENTA and 

  CLIENTE=@CLIENTE and 

  CANTIDAD=@CANTIDAD and 

  PRODUCTO=@PRODUCTO and 

  REQUERIDO=@REQUERIDO and 

  PROVEEDOR=@PROVEEDOR and 

  LINEA=@LINEA and 

  MARCA=@MARCA and 

  VENDEDOR=@VENDEDOR and 

  TIPO=@TIPO and 

  CLASIFICA=@CLASIFICA and 

  SERIE=@SERIE and 

  PRECIO=@PRECIO and 

  PREC_LISTA=@PREC_LISTA and 

  PRECIOUS=@PRECIOUS and 

  FECHA=@FECHA and 

  ESTATUS=@ESTATUS and 

  IMPORTE=@IMPORTE and 

  IMPORTNETO=@IMPORTNETO and 

  CARGOS_U=@CARGOS_U and 

  COSTO_PU=@COSTO_PU and 

  MIN1=@MIN1 and 

  MAX1=@MAX1 and 

  TIENDA=@TIENDA and 

  COSTOTAL=@COSTOTAL and 

  IMPORTEUS=@IMPORTEUS and 

  COSTOTOTUS=@COSTOTOTUS and 

  PIEZAS=@PIEZAS and 

  DESCUENTO=@DESCUENTO and 

  COMISION=@COMISION and 

  PAGADO=@PAGADO and 

  ORIGEN=@ORIGEN and 

  SURTIDO=@SURTIDO and 

  LOC=@LOC and 

  DEVUELTAS=@DEVUELTAS and 

  PARTIDA=@PARTIDA and 

  TRANSA=@TRANSA and 

  TRANS_LOTE=@TRANS_LOTE and 

  EXPORTADO=@EXPORTADO and 

  SURTIR=@SURTIR and 

  EXPORTTADC=@EXPORTTADC and 

  MONEDA=@MONEDA and 

  POLITICA=@POLITICA and 

  ID=@ID and 

  ID_FECHA=@ID_FECHA and 

  ID_HORA=@ID_HORA and 

  PROMOCION=@PROMOCION and 

  MOVIMIENTO=@MOVIMIENTO and 

  DESC2=@DESC2 and 

  PIEZA=@PIEZA and 

  CAJAS=@CAJAS and 

  PREC_MAYO=@PREC_MAYO
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
        public bool CambiarVEDMD(CVEDMBE oCVEDMNuevo, CVEDMBE oCVEDMAnterior, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@VENTA", OleDbType.VarChar);
                if (!(bool)oCVEDMNuevo.isnull["IVENTA"])
                {
                    auxPar.Value = oCVEDMNuevo.IVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                if (!(bool)oCVEDMNuevo.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCVEDMNuevo.ICLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Decimal);
                if (!(bool)oCVEDMNuevo.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCVEDMNuevo.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                if (!(bool)oCVEDMNuevo.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCVEDMNuevo.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@REQUERIDO", OleDbType.Decimal);
                if (!(bool)oCVEDMNuevo.isnull["IREQUERIDO"])
                {
                    auxPar.Value = oCVEDMNuevo.IREQUERIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PROVEEDOR", OleDbType.VarChar);
                if (!(bool)oCVEDMNuevo.isnull["IPROVEEDOR"])
                {
                    auxPar.Value = oCVEDMNuevo.IPROVEEDOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@LINEA", OleDbType.VarChar);
                if (!(bool)oCVEDMNuevo.isnull["ILINEA"])
                {
                    auxPar.Value = oCVEDMNuevo.ILINEA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@MARCA", OleDbType.VarChar);
                if (!(bool)oCVEDMNuevo.isnull["IMARCA"])
                {
                    auxPar.Value = oCVEDMNuevo.IMARCA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@VENDEDOR", OleDbType.VarChar);
                if (!(bool)oCVEDMNuevo.isnull["IVENDEDOR"])
                {
                    auxPar.Value = oCVEDMNuevo.IVENDEDOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TIPO", OleDbType.VarChar);
                if (!(bool)oCVEDMNuevo.isnull["ITIPO"])
                {
                    auxPar.Value = oCVEDMNuevo.ITIPO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CLASIFICA", OleDbType.VarChar);
                if (!(bool)oCVEDMNuevo.isnull["ICLASIFICA"])
                {
                    auxPar.Value = oCVEDMNuevo.ICLASIFICA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SERIE", OleDbType.VarChar);
                if (!(bool)oCVEDMNuevo.isnull["ISERIE"])
                {
                    auxPar.Value = oCVEDMNuevo.ISERIE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PRECIO", OleDbType.Decimal);
                if (!(bool)oCVEDMNuevo.isnull["IPRECIO"])
                {
                    auxPar.Value = oCVEDMNuevo.IPRECIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PREC_LISTA", OleDbType.Decimal);
                if (!(bool)oCVEDMNuevo.isnull["IPREC_LISTA"])
                {
                    auxPar.Value = oCVEDMNuevo.IPREC_LISTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PRECIOUS", OleDbType.Decimal);
                if (!(bool)oCVEDMNuevo.isnull["IPRECIOUS"])
                {
                    auxPar.Value = oCVEDMNuevo.IPRECIOUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@FECHA", OleDbType.Date);
                if (!(bool)oCVEDMNuevo.isnull["IFECHA"])
                {
                    auxPar.Value = oCVEDMNuevo.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ESTATUS", OleDbType.VarChar);
                if (!(bool)oCVEDMNuevo.isnull["IESTATUS"])
                {
                    auxPar.Value = oCVEDMNuevo.IESTATUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Decimal);
                if (!(bool)oCVEDMNuevo.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCVEDMNuevo.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IMPORTNETO", OleDbType.Decimal);
                if (!(bool)oCVEDMNuevo.isnull["IIMPORTNETO"])
                {
                    auxPar.Value = oCVEDMNuevo.IIMPORTNETO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CARGOS_U", OleDbType.Decimal);
                if (!(bool)oCVEDMNuevo.isnull["ICARGOS_U"])
                {
                    auxPar.Value = oCVEDMNuevo.ICARGOS_U;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COSTO_PU", OleDbType.Decimal);
                if (!(bool)oCVEDMNuevo.isnull["ICOSTO_PU"])
                {
                    auxPar.Value = oCVEDMNuevo.ICOSTO_PU;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@MIN1", OleDbType.Decimal);
                if (!(bool)oCVEDMNuevo.isnull["IMIN1"])
                {
                    auxPar.Value = oCVEDMNuevo.IMIN1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@MAX1", OleDbType.Decimal);
                if (!(bool)oCVEDMNuevo.isnull["IMAX1"])
                {
                    auxPar.Value = oCVEDMNuevo.IMAX1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TIENDA", OleDbType.Decimal);
                if (!(bool)oCVEDMNuevo.isnull["ITIENDA"])
                {
                    auxPar.Value = oCVEDMNuevo.ITIENDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COSTOTAL", OleDbType.Decimal);
                if (!(bool)oCVEDMNuevo.isnull["ICOSTOTAL"])
                {
                    auxPar.Value = oCVEDMNuevo.ICOSTOTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IMPORTEUS", OleDbType.Decimal);
                if (!(bool)oCVEDMNuevo.isnull["IIMPORTEUS"])
                {
                    auxPar.Value = oCVEDMNuevo.IIMPORTEUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COSTOTOTUS", OleDbType.Decimal);
                if (!(bool)oCVEDMNuevo.isnull["ICOSTOTOTUS"])
                {
                    auxPar.Value = oCVEDMNuevo.ICOSTOTOTUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PIEZAS", OleDbType.Decimal);
                if (!(bool)oCVEDMNuevo.isnull["IPIEZAS"])
                {
                    auxPar.Value = oCVEDMNuevo.IPIEZAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@DESCUENTO", OleDbType.Decimal);
                if (!(bool)oCVEDMNuevo.isnull["IDESCUENTO"])
                {
                    auxPar.Value = oCVEDMNuevo.IDESCUENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COMISION", OleDbType.Decimal);
                if (!(bool)oCVEDMNuevo.isnull["ICOMISION"])
                {
                    auxPar.Value = oCVEDMNuevo.ICOMISION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PAGADO", OleDbType.VarChar);
                if (!(bool)oCVEDMNuevo.isnull["IPAGADO"])
                {
                    auxPar.Value = oCVEDMNuevo.IPAGADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ORIGEN", OleDbType.VarChar);
                if (!(bool)oCVEDMNuevo.isnull["IORIGEN"])
                {
                    auxPar.Value = oCVEDMNuevo.IORIGEN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SURTIDO", OleDbType.Decimal);
                if (!(bool)oCVEDMNuevo.isnull["ISURTIDO"])
                {
                    auxPar.Value = oCVEDMNuevo.ISURTIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@LOC", OleDbType.VarChar);
                if (!(bool)oCVEDMNuevo.isnull["ILOC"])
                {
                    auxPar.Value = oCVEDMNuevo.ILOC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@DEVUELTAS", OleDbType.Decimal);
                if (!(bool)oCVEDMNuevo.isnull["IDEVUELTAS"])
                {
                    auxPar.Value = oCVEDMNuevo.IDEVUELTAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PARTIDA", OleDbType.Decimal);
                if (!(bool)oCVEDMNuevo.isnull["IPARTIDA"])
                {
                    auxPar.Value = oCVEDMNuevo.IPARTIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TRANSA", OleDbType.Decimal);
                if (!(bool)oCVEDMNuevo.isnull["ITRANSA"])
                {
                    auxPar.Value = oCVEDMNuevo.ITRANSA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TRANS_LOTE", OleDbType.Decimal);
                if (!(bool)oCVEDMNuevo.isnull["ITRANS_LOTE"])
                {
                    auxPar.Value = oCVEDMNuevo.ITRANS_LOTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@EXPORTADO", OleDbType.VarChar);
                if (!(bool)oCVEDMNuevo.isnull["IEXPORTADO"])
                {
                    auxPar.Value = oCVEDMNuevo.IEXPORTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SURTIR", OleDbType.Decimal);
                if (!(bool)oCVEDMNuevo.isnull["ISURTIR"])
                {
                    auxPar.Value = oCVEDMNuevo.ISURTIR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@EXPORTTADC", OleDbType.SmallInt);
                if (!(bool)oCVEDMNuevo.isnull["IEXPORTTADC"])
                {
                    auxPar.Value = oCVEDMNuevo.IEXPORTTADC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@MONEDA", OleDbType.VarChar);
                if (!(bool)oCVEDMNuevo.isnull["IMONEDA"])
                {
                    auxPar.Value = oCVEDMNuevo.IMONEDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@POLITICA", OleDbType.VarChar);
                if (!(bool)oCVEDMNuevo.isnull["IPOLITICA"])
                {
                    auxPar.Value = oCVEDMNuevo.IPOLITICA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCVEDMNuevo.isnull["IID"])
                {
                    auxPar.Value = oCVEDMNuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCVEDMNuevo.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCVEDMNuevo.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCVEDMNuevo.isnull["IID_HORA"])
                {
                    auxPar.Value = oCVEDMNuevo.IID_HORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PROMOCION", OleDbType.VarChar);
                if (!(bool)oCVEDMNuevo.isnull["IPROMOCION"])
                {
                    auxPar.Value = oCVEDMNuevo.IPROMOCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@MOVIMIENTO", OleDbType.VarChar);
                if (!(bool)oCVEDMNuevo.isnull["IMOVIMIENTO"])
                {
                    auxPar.Value = oCVEDMNuevo.IMOVIMIENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@DESC2", OleDbType.VarChar);
                if (!(bool)oCVEDMNuevo.isnull["IDESC2"])
                {
                    auxPar.Value = oCVEDMNuevo.IDESC2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PIEZA", OleDbType.Decimal);
                if (!(bool)oCVEDMNuevo.isnull["IPIEZA"])
                {
                    auxPar.Value = oCVEDMNuevo.IPIEZA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CAJAS", OleDbType.Decimal);
                if (!(bool)oCVEDMNuevo.isnull["ICAJAS"])
                {
                    auxPar.Value = oCVEDMNuevo.ICAJAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PREC_MAYO", OleDbType.VarChar);
                if (!(bool)oCVEDMNuevo.isnull["IPREC_MAYO"])
                {
                    auxPar.Value = oCVEDMNuevo.IPREC_MAYO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@VENTAAnt", OleDbType.VarChar);
                if (!(bool)oCVEDMAnterior.isnull["IVENTA"])
                {
                    auxPar.Value = oCVEDMAnterior.IVENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CLIENTEAnt", OleDbType.VarChar);
                if (!(bool)oCVEDMAnterior.isnull["ICLIENTE"])
                {
                    auxPar.Value = oCVEDMAnterior.ICLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CANTIDADAnt", OleDbType.Decimal);
                if (!(bool)oCVEDMAnterior.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCVEDMAnterior.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PRODUCTOAnt", OleDbType.VarChar);
                if (!(bool)oCVEDMAnterior.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCVEDMAnterior.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@REQUERIDOAnt", OleDbType.Decimal);
                if (!(bool)oCVEDMAnterior.isnull["IREQUERIDO"])
                {
                    auxPar.Value = oCVEDMAnterior.IREQUERIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PROVEEDORAnt", OleDbType.VarChar);
                if (!(bool)oCVEDMAnterior.isnull["IPROVEEDOR"])
                {
                    auxPar.Value = oCVEDMAnterior.IPROVEEDOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@LINEAAnt", OleDbType.VarChar);
                if (!(bool)oCVEDMAnterior.isnull["ILINEA"])
                {
                    auxPar.Value = oCVEDMAnterior.ILINEA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@MARCAAnt", OleDbType.VarChar);
                if (!(bool)oCVEDMAnterior.isnull["IMARCA"])
                {
                    auxPar.Value = oCVEDMAnterior.IMARCA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@VENDEDORAnt", OleDbType.VarChar);
                if (!(bool)oCVEDMAnterior.isnull["IVENDEDOR"])
                {
                    auxPar.Value = oCVEDMAnterior.IVENDEDOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TIPOAnt", OleDbType.VarChar);
                if (!(bool)oCVEDMAnterior.isnull["ITIPO"])
                {
                    auxPar.Value = oCVEDMAnterior.ITIPO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CLASIFICAAnt", OleDbType.VarChar);
                if (!(bool)oCVEDMAnterior.isnull["ICLASIFICA"])
                {
                    auxPar.Value = oCVEDMAnterior.ICLASIFICA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SERIEAnt", OleDbType.VarChar);
                if (!(bool)oCVEDMAnterior.isnull["ISERIE"])
                {
                    auxPar.Value = oCVEDMAnterior.ISERIE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PRECIOAnt", OleDbType.Decimal);
                if (!(bool)oCVEDMAnterior.isnull["IPRECIO"])
                {
                    auxPar.Value = oCVEDMAnterior.IPRECIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PREC_LISTAAnt", OleDbType.Decimal);
                if (!(bool)oCVEDMAnterior.isnull["IPREC_LISTA"])
                {
                    auxPar.Value = oCVEDMAnterior.IPREC_LISTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PRECIOUSAnt", OleDbType.Decimal);
                if (!(bool)oCVEDMAnterior.isnull["IPRECIOUS"])
                {
                    auxPar.Value = oCVEDMAnterior.IPRECIOUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@FECHAAnt", OleDbType.Date);
                if (!(bool)oCVEDMAnterior.isnull["IFECHA"])
                {
                    auxPar.Value = oCVEDMAnterior.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ESTATUSAnt", OleDbType.VarChar);
                if (!(bool)oCVEDMAnterior.isnull["IESTATUS"])
                {
                    auxPar.Value = oCVEDMAnterior.IESTATUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IMPORTEAnt", OleDbType.Decimal);
                if (!(bool)oCVEDMAnterior.isnull["IIMPORTE"])
                {
                    auxPar.Value = oCVEDMAnterior.IIMPORTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IMPORTNETOAnt", OleDbType.Decimal);
                if (!(bool)oCVEDMAnterior.isnull["IIMPORTNETO"])
                {
                    auxPar.Value = oCVEDMAnterior.IIMPORTNETO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CARGOS_UAnt", OleDbType.Decimal);
                if (!(bool)oCVEDMAnterior.isnull["ICARGOS_U"])
                {
                    auxPar.Value = oCVEDMAnterior.ICARGOS_U;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COSTO_PUAnt", OleDbType.Decimal);
                if (!(bool)oCVEDMAnterior.isnull["ICOSTO_PU"])
                {
                    auxPar.Value = oCVEDMAnterior.ICOSTO_PU;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@MIN1Ant", OleDbType.Decimal);
                if (!(bool)oCVEDMAnterior.isnull["IMIN1"])
                {
                    auxPar.Value = oCVEDMAnterior.IMIN1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@MAX1Ant", OleDbType.Decimal);
                if (!(bool)oCVEDMAnterior.isnull["IMAX1"])
                {
                    auxPar.Value = oCVEDMAnterior.IMAX1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TIENDAAnt", OleDbType.Decimal);
                if (!(bool)oCVEDMAnterior.isnull["ITIENDA"])
                {
                    auxPar.Value = oCVEDMAnterior.ITIENDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COSTOTALAnt", OleDbType.Decimal);
                if (!(bool)oCVEDMAnterior.isnull["ICOSTOTAL"])
                {
                    auxPar.Value = oCVEDMAnterior.ICOSTOTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IMPORTEUSAnt", OleDbType.Decimal);
                if (!(bool)oCVEDMAnterior.isnull["IIMPORTEUS"])
                {
                    auxPar.Value = oCVEDMAnterior.IIMPORTEUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COSTOTOTUSAnt", OleDbType.Decimal);
                if (!(bool)oCVEDMAnterior.isnull["ICOSTOTOTUS"])
                {
                    auxPar.Value = oCVEDMAnterior.ICOSTOTOTUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PIEZASAnt", OleDbType.Decimal);
                if (!(bool)oCVEDMAnterior.isnull["IPIEZAS"])
                {
                    auxPar.Value = oCVEDMAnterior.IPIEZAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@DESCUENTOAnt", OleDbType.Decimal);
                if (!(bool)oCVEDMAnterior.isnull["IDESCUENTO"])
                {
                    auxPar.Value = oCVEDMAnterior.IDESCUENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COMISIONAnt", OleDbType.Decimal);
                if (!(bool)oCVEDMAnterior.isnull["ICOMISION"])
                {
                    auxPar.Value = oCVEDMAnterior.ICOMISION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PAGADOAnt", OleDbType.VarChar);
                if (!(bool)oCVEDMAnterior.isnull["IPAGADO"])
                {
                    auxPar.Value = oCVEDMAnterior.IPAGADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ORIGENAnt", OleDbType.VarChar);
                if (!(bool)oCVEDMAnterior.isnull["IORIGEN"])
                {
                    auxPar.Value = oCVEDMAnterior.IORIGEN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SURTIDOAnt", OleDbType.Decimal);
                if (!(bool)oCVEDMAnterior.isnull["ISURTIDO"])
                {
                    auxPar.Value = oCVEDMAnterior.ISURTIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@LOCAnt", OleDbType.VarChar);
                if (!(bool)oCVEDMAnterior.isnull["ILOC"])
                {
                    auxPar.Value = oCVEDMAnterior.ILOC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@DEVUELTASAnt", OleDbType.Decimal);
                if (!(bool)oCVEDMAnterior.isnull["IDEVUELTAS"])
                {
                    auxPar.Value = oCVEDMAnterior.IDEVUELTAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PARTIDAAnt", OleDbType.Decimal);
                if (!(bool)oCVEDMAnterior.isnull["IPARTIDA"])
                {
                    auxPar.Value = oCVEDMAnterior.IPARTIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TRANSAAnt", OleDbType.Decimal);
                if (!(bool)oCVEDMAnterior.isnull["ITRANSA"])
                {
                    auxPar.Value = oCVEDMAnterior.ITRANSA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TRANS_LOTEAnt", OleDbType.Decimal);
                if (!(bool)oCVEDMAnterior.isnull["ITRANS_LOTE"])
                {
                    auxPar.Value = oCVEDMAnterior.ITRANS_LOTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@EXPORTADOAnt", OleDbType.VarChar);
                if (!(bool)oCVEDMAnterior.isnull["IEXPORTADO"])
                {
                    auxPar.Value = oCVEDMAnterior.IEXPORTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SURTIRAnt", OleDbType.Decimal);
                if (!(bool)oCVEDMAnterior.isnull["ISURTIR"])
                {
                    auxPar.Value = oCVEDMAnterior.ISURTIR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@EXPORTTADCAnt", OleDbType.SmallInt);
                if (!(bool)oCVEDMAnterior.isnull["IEXPORTTADC"])
                {
                    auxPar.Value = oCVEDMAnterior.IEXPORTTADC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@MONEDAAnt", OleDbType.VarChar);
                if (!(bool)oCVEDMAnterior.isnull["IMONEDA"])
                {
                    auxPar.Value = oCVEDMAnterior.IMONEDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@POLITICAAnt", OleDbType.VarChar);
                if (!(bool)oCVEDMAnterior.isnull["IPOLITICA"])
                {
                    auxPar.Value = oCVEDMAnterior.IPOLITICA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IDAnt", OleDbType.VarChar);
                if (!(bool)oCVEDMAnterior.isnull["IID"])
                {
                    auxPar.Value = oCVEDMAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_FECHAAnt", OleDbType.Date);
                if (!(bool)oCVEDMAnterior.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCVEDMAnterior.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_HORAAnt", OleDbType.VarChar);
                if (!(bool)oCVEDMAnterior.isnull["IID_HORA"])
                {
                    auxPar.Value = oCVEDMAnterior.IID_HORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PROMOCIONAnt", OleDbType.VarChar);
                if (!(bool)oCVEDMAnterior.isnull["IPROMOCION"])
                {
                    auxPar.Value = oCVEDMAnterior.IPROMOCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@MOVIMIENTOAnt", OleDbType.VarChar);
                if (!(bool)oCVEDMAnterior.isnull["IMOVIMIENTO"])
                {
                    auxPar.Value = oCVEDMAnterior.IMOVIMIENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@DESC2Ant", OleDbType.VarChar);
                if (!(bool)oCVEDMAnterior.isnull["IDESC2"])
                {
                    auxPar.Value = oCVEDMAnterior.IDESC2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PIEZAAnt", OleDbType.Decimal);
                if (!(bool)oCVEDMAnterior.isnull["IPIEZA"])
                {
                    auxPar.Value = oCVEDMAnterior.IPIEZA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CAJASAnt", OleDbType.Decimal);
                if (!(bool)oCVEDMAnterior.isnull["ICAJAS"])
                {
                    auxPar.Value = oCVEDMAnterior.ICAJAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PREC_MAYOAnt", OleDbType.VarChar);
                if (!(bool)oCVEDMAnterior.isnull["IPREC_MAYO"])
                {
                    auxPar.Value = oCVEDMAnterior.IPREC_MAYO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  VEDM
  set

VENTA=@VENTA,

CLIENTE=@CLIENTE,

CANTIDAD=@CANTIDAD,

PRODUCTO=@PRODUCTO,

REQUERIDO=@REQUERIDO,

PROVEEDOR=@PROVEEDOR,

LINEA=@LINEA,

MARCA=@MARCA,

VENDEDOR=@VENDEDOR,

TIPO=@TIPO,

CLASIFICA=@CLASIFICA,

SERIE=@SERIE,

PRECIO=@PRECIO,

PREC_LISTA=@PREC_LISTA,

PRECIOUS=@PRECIOUS,

FECHA=@FECHA,

ESTATUS=@ESTATUS,

IMPORTE=@IMPORTE,

IMPORTNETO=@IMPORTNETO,

CARGOS_U=@CARGOS_U,

COSTO_PU=@COSTO_PU,

MIN1=@MIN1,

MAX1=@MAX1,

TIENDA=@TIENDA,

COSTOTAL=@COSTOTAL,

IMPORTEUS=@IMPORTEUS,

COSTOTOTUS=@COSTOTOTUS,

PIEZAS=@PIEZAS,

DESCUENTO=@DESCUENTO,

COMISION=@COMISION,

PAGADO=@PAGADO,

ORIGEN=@ORIGEN,

SURTIDO=@SURTIDO,

LOC=@LOC,

DEVUELTAS=@DEVUELTAS,

PARTIDA=@PARTIDA,

TRANSA=@TRANSA,

TRANS_LOTE=@TRANS_LOTE,

EXPORTADO=@EXPORTADO,

SURTIR=@SURTIR,

EXPORTTADC=@EXPORTTADC,

MONEDA=@MONEDA,

POLITICA=@POLITICA,

ID=@ID,

ID_FECHA=@ID_FECHA,

ID_HORA=@ID_HORA,

PROMOCION=@PROMOCION,

MOVIMIENTO=@MOVIMIENTO,

DESC2=@DESC2,

PIEZA=@PIEZA,

CAJAS=@CAJAS,

PREC_MAYO=@PREC_MAYO
  where 

VENTA=@VENTAAnt and

CLIENTE=@CLIENTEAnt and

CANTIDAD=@CANTIDADAnt and

PRODUCTO=@PRODUCTOAnt and

REQUERIDO=@REQUERIDOAnt and

PROVEEDOR=@PROVEEDORAnt and

LINEA=@LINEAAnt and

MARCA=@MARCAAnt and

VENDEDOR=@VENDEDORAnt and

TIPO=@TIPOAnt and

CLASIFICA=@CLASIFICAAnt and

SERIE=@SERIEAnt and

PRECIO=@PRECIOAnt and

PREC_LISTA=@PREC_LISTAAnt and

PRECIOUS=@PRECIOUSAnt and

FECHA=@FECHAAnt and

ESTATUS=@ESTATUSAnt and

IMPORTE=@IMPORTEAnt and

IMPORTNETO=@IMPORTNETOAnt and

CARGOS_U=@CARGOS_UAnt and

COSTO_PU=@COSTO_PUAnt and

MIN1=@MIN1Ant and

MAX1=@MAX1Ant and

TIENDA=@TIENDAAnt and

COSTOTAL=@COSTOTALAnt and

IMPORTEUS=@IMPORTEUSAnt and

COSTOTOTUS=@COSTOTOTUSAnt and

PIEZAS=@PIEZASAnt and

DESCUENTO=@DESCUENTOAnt and

COMISION=@COMISIONAnt and

PAGADO=@PAGADOAnt and

ORIGEN=@ORIGENAnt and

SURTIDO=@SURTIDOAnt and

LOC=@LOCAnt and

DEVUELTAS=@DEVUELTASAnt and

PARTIDA=@PARTIDAAnt and

TRANSA=@TRANSAAnt and

TRANS_LOTE=@TRANS_LOTEAnt and

EXPORTADO=@EXPORTADOAnt and

SURTIR=@SURTIRAnt and

EXPORTTADC=@EXPORTTADCAnt and

MONEDA=@MONEDAAnt and

POLITICA=@POLITICAAnt and

ID=@IDAnt and

ID_FECHA=@ID_FECHAAnt and

ID_HORA=@ID_HORAAnt and

PROMOCION=@PROMOCIONAnt and

MOVIMIENTO=@MOVIMIENTOAnt and

DESC2=@DESC2Ant and

PIEZA=@PIEZAAnt and

CAJAS=@CAJASAnt and

PREC_MAYO=@PREC_MAYOAnt
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
        public CVEDMBE seleccionarVEDM(CVEDMBE oCVEDM, OleDbTransaction st)
        {




            CVEDMBE retorno = new CVEDMBE();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;

                String CmdTxt = @"select * from VEDM where
 VENTA=@VENTA    and
 CLIENTE=@CLIENTE    and
 CANTIDAD=@CANTIDAD    and
 PRODUCTO=@PRODUCTO    and
 REQUERIDO=@REQUERIDO    and
 PROVEEDOR=@PROVEEDOR    and
 LINEA=@LINEA    and
 MARCA=@MARCA    and
 VENDEDOR=@VENDEDOR    and
 TIPO=@TIPO    and
 CLASIFICA=@CLASIFICA    and
 SERIE=@SERIE    and
 PRECIO=@PRECIO    and
 PREC_LISTA=@PREC_LISTA    and
 PRECIOUS=@PRECIOUS    and
 FECHA=@FECHA    and
 ESTATUS=@ESTATUS    and
 IMPORTE=@IMPORTE    and
 IMPORTNETO=@IMPORTNETO    and
 CARGOS_U=@CARGOS_U    and
 COSTO_PU=@COSTO_PU    and
 MIN1=@MIN1    and
 MAX1=@MAX1    and
 TIENDA=@TIENDA    and
 COSTOTAL=@COSTOTAL    and
 IMPORTEUS=@IMPORTEUS    and
 COSTOTOTUS=@COSTOTOTUS    and
 PIEZAS=@PIEZAS    and
 DESCUENTO=@DESCUENTO    and
 COMISION=@COMISION    and
 PAGADO=@PAGADO    and
 ORIGEN=@ORIGEN    and
 SURTIDO=@SURTIDO    and
 LOC=@LOC    and
 DEVUELTAS=@DEVUELTAS    and
 PARTIDA=@PARTIDA    and
 TRANSA=@TRANSA    and
 TRANS_LOTE=@TRANS_LOTE    and
 EXPORTADO=@EXPORTADO    and
 SURTIR=@SURTIR    and
 EXPORTTADC=@EXPORTTADC    and
 MONEDA=@MONEDA    and
 POLITICA=@POLITICA    and
 ID=@ID    and
 ID_FECHA=@ID_FECHA    and
 ID_HORA=@ID_HORA    and
 PROMOCION=@PROMOCION    and
 MOVIMIENTO=@MOVIMIENTO    and
 DESC2=@DESC2    and
 PIEZA=@PIEZA    and
 CAJAS=@CAJAS    and
 PREC_MAYO=@PREC_MAYO  ";


                auxPar = new OleDbParameter("@VENTA", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IVENTA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                auxPar.Value = oCVEDM.ICLIENTE;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ICANTIDAD;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IPRODUCTO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@REQUERIDO", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IREQUERIDO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PROVEEDOR", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IPROVEEDOR;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@LINEA", OleDbType.VarChar);
                auxPar.Value = oCVEDM.ILINEA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@MARCA", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IMARCA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@VENDEDOR", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IVENDEDOR;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@TIPO", OleDbType.VarChar);
                auxPar.Value = oCVEDM.ITIPO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@CLASIFICA", OleDbType.VarChar);
                auxPar.Value = oCVEDM.ICLASIFICA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@SERIE", OleDbType.VarChar);
                auxPar.Value = oCVEDM.ISERIE;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PRECIO", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IPRECIO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PREC_LISTA", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IPREC_LISTA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PRECIOUS", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IPRECIOUS;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@FECHA", OleDbType.Date);
                auxPar.Value = oCVEDM.IFECHA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ESTATUS", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IESTATUS;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IIMPORTE;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@IMPORTNETO", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IIMPORTNETO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@CARGOS_U", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ICARGOS_U;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@COSTO_PU", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ICOSTO_PU;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@MIN1", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IMIN1;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@MAX1", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IMAX1;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@TIENDA", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ITIENDA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@COSTOTAL", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ICOSTOTAL;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@IMPORTEUS", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IIMPORTEUS;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@COSTOTOTUS", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ICOSTOTOTUS;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PIEZAS", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IPIEZAS;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@DESCUENTO", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IDESCUENTO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@COMISION", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ICOMISION;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PAGADO", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IPAGADO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ORIGEN", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IORIGEN;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@SURTIDO", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ISURTIDO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@LOC", OleDbType.VarChar);
                auxPar.Value = oCVEDM.ILOC;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@DEVUELTAS", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IDEVUELTAS;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PARTIDA", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IPARTIDA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@TRANSA", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ITRANSA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@TRANS_LOTE", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ITRANS_LOTE;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@EXPORTADO", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IEXPORTADO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@SURTIR", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ISURTIR;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@EXPORTTADC", OleDbType.SmallInt);
                auxPar.Value = oCVEDM.IEXPORTTADC;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@MONEDA", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IMONEDA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@POLITICA", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IPOLITICA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IID;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                auxPar.Value = oCVEDM.IID_FECHA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IID_HORA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PROMOCION", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IPROMOCION;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@MOVIMIENTO", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IMOVIMIENTO;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@DESC2", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IDESC2;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PIEZA", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IPIEZA;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@CAJAS", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ICAJAS;
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PREC_MAYO", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IPREC_MAYO;
                parts.Add(auxPar);




                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                OleDbDataReader dr;
                //if(st==null)
                dr = OleDbHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, arParms);
                //else
                //dr = OleDbHelper.ExecuteReader(st,CommandType.Text, CmdTxt,arParms);


                if (dr.Read())
                {

                    if (dr["VENTA"] != System.DBNull.Value)
                    {
                        retorno.IVENTA = (string)(dr["VENTA"]);
                    }

                    if (dr["CLIENTE"] != System.DBNull.Value)
                    {
                        retorno.ICLIENTE = (string)(dr["CLIENTE"]);
                    }

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDAD = (decimal)(dr["CANTIDAD"]);
                    }

                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTO = (string)(dr["PRODUCTO"]);
                    }

                    if (dr["REQUERIDO"] != System.DBNull.Value)
                    {
                        retorno.IREQUERIDO = (decimal)(dr["REQUERIDO"]);
                    }

                    if (dr["PROVEEDOR"] != System.DBNull.Value)
                    {
                        retorno.IPROVEEDOR = (string)(dr["PROVEEDOR"]);
                    }

                    if (dr["LINEA"] != System.DBNull.Value)
                    {
                        retorno.ILINEA = (string)(dr["LINEA"]);
                    }

                    if (dr["MARCA"] != System.DBNull.Value)
                    {
                        retorno.IMARCA = (string)(dr["MARCA"]);
                    }

                    if (dr["VENDEDOR"] != System.DBNull.Value)
                    {
                        retorno.IVENDEDOR = (string)(dr["VENDEDOR"]);
                    }

                    if (dr["TIPO"] != System.DBNull.Value)
                    {
                        retorno.ITIPO = (string)(dr["TIPO"]);
                    }

                    if (dr["CLASIFICA"] != System.DBNull.Value)
                    {
                        retorno.ICLASIFICA = (string)(dr["CLASIFICA"]);
                    }

                    if (dr["SERIE"] != System.DBNull.Value)
                    {
                        retorno.ISERIE = (string)(dr["SERIE"]);
                    }

                    if (dr["PRECIO"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO = (decimal)(dr["PRECIO"]);
                    }

                    if (dr["PREC_LISTA"] != System.DBNull.Value)
                    {
                        retorno.IPREC_LISTA = (decimal)(dr["PREC_LISTA"]);
                    }

                    if (dr["PRECIOUS"] != System.DBNull.Value)
                    {
                        retorno.IPRECIOUS = (decimal)(dr["PRECIOUS"]);
                    }

                    if (dr["FECHA"] != System.DBNull.Value)
                    {
                        retorno.IFECHA = (DateTime)(dr["FECHA"]);
                    }

                    if (dr["ESTATUS"] != System.DBNull.Value)
                    {
                        retorno.IESTATUS = (string)(dr["ESTATUS"]);
                    }

                    if (dr["IMPORTE"] != System.DBNull.Value)
                    {
                        retorno.IIMPORTE = (decimal)(dr["IMPORTE"]);
                    }

                    if (dr["IMPORTNETO"] != System.DBNull.Value)
                    {
                        retorno.IIMPORTNETO = (decimal)(dr["IMPORTNETO"]);
                    }

                    if (dr["CARGOS_U"] != System.DBNull.Value)
                    {
                        retorno.ICARGOS_U = (decimal)(dr["CARGOS_U"]);
                    }

                    if (dr["COSTO_PU"] != System.DBNull.Value)
                    {
                        retorno.ICOSTO_PU = (decimal)(dr["COSTO_PU"]);
                    }

                    if (dr["MIN1"] != System.DBNull.Value)
                    {
                        retorno.IMIN1 = (decimal)(dr["MIN1"]);
                    }

                    if (dr["MAX1"] != System.DBNull.Value)
                    {
                        retorno.IMAX1 = (decimal)(dr["MAX1"]);
                    }

                    if (dr["TIENDA"] != System.DBNull.Value)
                    {
                        retorno.ITIENDA = (decimal)(dr["TIENDA"]);
                    }

                    if (dr["COSTOTAL"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOTAL = (decimal)(dr["COSTOTAL"]);
                    }

                    if (dr["IMPORTEUS"] != System.DBNull.Value)
                    {
                        retorno.IIMPORTEUS = (decimal)(dr["IMPORTEUS"]);
                    }

                    if (dr["COSTOTOTUS"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOTOTUS = (decimal)(dr["COSTOTOTUS"]);
                    }

                    if (dr["PIEZAS"] != System.DBNull.Value)
                    {
                        retorno.IPIEZAS = (decimal)(dr["PIEZAS"]);
                    }

                    if (dr["DESCUENTO"] != System.DBNull.Value)
                    {
                        retorno.IDESCUENTO = (decimal)(dr["DESCUENTO"]);
                    }

                    if (dr["COMISION"] != System.DBNull.Value)
                    {
                        retorno.ICOMISION = (decimal)(dr["COMISION"]);
                    }

                    if (dr["PAGADO"] != System.DBNull.Value)
                    {
                        retorno.IPAGADO = (string)(dr["PAGADO"]);
                    }

                    if (dr["ORIGEN"] != System.DBNull.Value)
                    {
                        retorno.IORIGEN = (string)(dr["ORIGEN"]);
                    }

                    if (dr["SURTIDO"] != System.DBNull.Value)
                    {
                        retorno.ISURTIDO = (decimal)(dr["SURTIDO"]);
                    }

                    if (dr["LOC"] != System.DBNull.Value)
                    {
                        retorno.ILOC = (string)(dr["LOC"]);
                    }

                    if (dr["DEVUELTAS"] != System.DBNull.Value)
                    {
                        retorno.IDEVUELTAS = (decimal)(dr["DEVUELTAS"]);
                    }

                    if (dr["PARTIDA"] != System.DBNull.Value)
                    {
                        retorno.IPARTIDA = (decimal)(dr["PARTIDA"]);
                    }

                    if (dr["TRANSA"] != System.DBNull.Value)
                    {
                        retorno.ITRANSA = (decimal)(dr["TRANSA"]);
                    }

                    if (dr["TRANS_LOTE"] != System.DBNull.Value)
                    {
                        retorno.ITRANS_LOTE = (decimal)(dr["TRANS_LOTE"]);
                    }

                    if (dr["EXPORTADO"] != System.DBNull.Value)
                    {
                        retorno.IEXPORTADO = (string)(dr["EXPORTADO"]);
                    }

                    if (dr["SURTIR"] != System.DBNull.Value)
                    {
                        retorno.ISURTIR = (decimal)(dr["SURTIR"]);
                    }

                    if (dr["MONEDA"] != System.DBNull.Value)
                    {
                        retorno.IMONEDA = (string)(dr["MONEDA"]);
                    }

                    if (dr["POLITICA"] != System.DBNull.Value)
                    {
                        retorno.IPOLITICA = (string)(dr["POLITICA"]);
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

                    if (dr["PROMOCION"] != System.DBNull.Value)
                    {
                        retorno.IPROMOCION = (string)(dr["PROMOCION"]);
                    }

                    if (dr["MOVIMIENTO"] != System.DBNull.Value)
                    {
                        retorno.IMOVIMIENTO = (string)(dr["MOVIMIENTO"]);
                    }

                    if (dr["DESC2"] != System.DBNull.Value)
                    {
                        retorno.IDESC2 = (string)(dr["DESC2"]);
                    }

                    if (dr["PIEZA"] != System.DBNull.Value)
                    {
                        retorno.IPIEZA = (decimal)(dr["PIEZA"]);
                    }

                    if (dr["CAJAS"] != System.DBNull.Value)
                    {
                        retorno.ICAJAS = (decimal)(dr["CAJAS"]);
                    }

                    if (dr["PREC_MAYO"] != System.DBNull.Value)
                    {
                        retorno.IPREC_MAYO = (string)(dr["PREC_MAYO"]);
                    }

                    if (dr["EXPORTTADC"] != System.DBNull.Value)
                    {
                        retorno.IEXPORTTADC = short.Parse(dr["EXPORTTADC"].ToString());
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
        public int ExisteVEDM(CVEDMBE oCVEDM, OleDbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@VENTA", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IVENTA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLIENTE", OleDbType.VarChar);
                auxPar.Value = oCVEDM.ICLIENTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANTIDAD", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ICANTIDAD;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IPRODUCTO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@REQUERIDO", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IREQUERIDO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PROVEEDOR", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IPROVEEDOR;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LINEA", OleDbType.VarChar);
                auxPar.Value = oCVEDM.ILINEA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MARCA", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IMARCA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VENDEDOR", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IVENDEDOR;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TIPO", OleDbType.VarChar);
                auxPar.Value = oCVEDM.ITIPO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLASIFICA", OleDbType.VarChar);
                auxPar.Value = oCVEDM.ICLASIFICA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SERIE", OleDbType.VarChar);
                auxPar.Value = oCVEDM.ISERIE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IPRECIO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PREC_LISTA", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IPREC_LISTA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIOUS", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IPRECIOUS;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FECHA", OleDbType.Date);
                auxPar.Value = oCVEDM.IFECHA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTATUS", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IESTATUS;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTE", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IIMPORTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTNETO", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IIMPORTNETO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CARGOS_U", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ICARGOS_U;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTO_PU", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ICOSTO_PU;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MIN1", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IMIN1;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MAX1", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IMAX1;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TIENDA", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ITIENDA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTOTAL", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ICOSTOTAL;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPORTEUS", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IIMPORTEUS;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTOTOTUS", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ICOSTOTOTUS;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PIEZAS", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IPIEZAS;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESCUENTO", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IDESCUENTO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMISION", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ICOMISION;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PAGADO", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IPAGADO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ORIGEN", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IORIGEN;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SURTIDO", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ISURTIDO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LOC", OleDbType.VarChar);
                auxPar.Value = oCVEDM.ILOC;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DEVUELTAS", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IDEVUELTAS;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PARTIDA", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IPARTIDA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TRANSA", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ITRANSA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TRANS_LOTE", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ITRANS_LOTE;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EXPORTADO", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IEXPORTADO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SURTIR", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ISURTIR;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EXPORTTADC", OleDbType.SmallInt);
                auxPar.Value = oCVEDM.IEXPORTTADC;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MONEDA", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IMONEDA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@POLITICA", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IPOLITICA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IID;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                auxPar.Value = oCVEDM.IID_FECHA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IID_HORA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PROMOCION", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IPROMOCION;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MOVIMIENTO", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IMOVIMIENTO;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESC2", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IDESC2;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PIEZA", OleDbType.Decimal);
                auxPar.Value = oCVEDM.IPIEZA;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CAJAS", OleDbType.Decimal);
                auxPar.Value = oCVEDM.ICAJAS;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PREC_MAYO", OleDbType.VarChar);
                auxPar.Value = oCVEDM.IPREC_MAYO;
                parts.Add(auxPar);

                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from VEDM where

  VENTA=@VENTA    and

  CLIENTE=@CLIENTE    and

  CANTIDAD=@CANTIDAD    and

  PRODUCTO=@PRODUCTO    and

  REQUERIDO=@REQUERIDO    and

  PROVEEDOR=@PROVEEDOR    and

  LINEA=@LINEA    and

  MARCA=@MARCA    and

  VENDEDOR=@VENDEDOR    and

  TIPO=@TIPO    and

  CLASIFICA=@CLASIFICA    and

  SERIE=@SERIE    and

  PRECIO=@PRECIO    and

  PREC_LISTA=@PREC_LISTA    and

  PRECIOUS=@PRECIOUS    and

  FECHA=@FECHA    and

  ESTATUS=@ESTATUS    and

  IMPORTE=@IMPORTE    and

  IMPORTNETO=@IMPORTNETO    and

  CARGOS_U=@CARGOS_U    and

  COSTO_PU=@COSTO_PU    and

  MIN1=@MIN1    and

  MAX1=@MAX1    and

  TIENDA=@TIENDA    and

  COSTOTAL=@COSTOTAL    and

  IMPORTEUS=@IMPORTEUS    and

  COSTOTOTUS=@COSTOTOTUS    and

  PIEZAS=@PIEZAS    and

  DESCUENTO=@DESCUENTO    and

  COMISION=@COMISION    and

  PAGADO=@PAGADO    and

  ORIGEN=@ORIGEN    and

  SURTIDO=@SURTIDO    and

  LOC=@LOC    and

  DEVUELTAS=@DEVUELTAS    and

  PARTIDA=@PARTIDA    and

  TRANSA=@TRANSA    and

  TRANS_LOTE=@TRANS_LOTE    and

  EXPORTADO=@EXPORTADO    and

  SURTIR=@SURTIR    and

  EXPORTTADC=@EXPORTTADC    and

  MONEDA=@MONEDA    and

  POLITICA=@POLITICA    and

  ID=@ID    and

  ID_FECHA=@ID_FECHA    and

  ID_HORA=@ID_HORA    and

  PROMOCION=@PROMOCION    and

  MOVIMIENTO=@MOVIMIENTO    and

  DESC2=@DESC2    and

  PIEZA=@PIEZA    and

  CAJAS=@CAJAS    and

  PREC_MAYO=@PREC_MAYO  
  );";






                OleDbDataReader dr;
                //if(st==null)
                dr = OleDbHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                //else
                //dr = OleDbHelper.ExecuteReader(st,CommandType.Text, commandText,arParms);



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




        //public bool AgregarVEDM(CVEDMBE oCVEDM, OleDbTransaction st)
        //{
        //    try
        //    {
        //        int iRes = ExisteVEDM(oCVEDM, st);
        //        if (iRes == 1)
        //        {
        //            this.IComentario = "El VEDM ya existe";
        //            return false;
        //        }
        //        else if (iRes == -1)
        //        {
        //            return false;
        //        }
        //        return AgregarVEDMD(oCVEDM, st);
        //    }
        //    catch (Exception e)
        //    {
        //        this.iComentario = e.Message + e.StackTrace;
        //        return false;
        //    }
        //}


        public bool BorrarVEDM(CVEDMBE oCVEDM, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteVEDM(oCVEDM, st);
                if (iRes == 0)
                {
                    this.IComentario = "El VEDM no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarVEDMD(oCVEDM, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarVEDM(CVEDMBE oCVEDMNuevo, CVEDMBE oCVEDMAnterior, OleDbTransaction st)
        {
            try
            {
                int iRes = ExisteVEDM(oCVEDMAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El VEDM no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarVEDMD(oCVEDMNuevo, oCVEDMAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CVEDMD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
