
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


    public class CPRODD: IPRODD
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
        public bool AgregarPRODD(CPRODBE oCPROD,  string strFileName, OleDbTransaction st, string strOleDbConn)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCPROD.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESC1", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IDESC1"])
                {
                    auxPar.Value = oCPROD.IDESC1;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO1", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPRECIO1"])
                {
                    auxPar.Value = oCPROD.IPRECIO1;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESCUENTO1", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IDESCUENTO1"])
                {
                    auxPar.Value = oCPROD.IDESCUENTO1;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@U_EMPAQUE", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IU_EMPAQUE"])
                {
                    auxPar.Value = oCPROD.IU_EMPAQUE;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MONEDA", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IMONEDA"])
                {
                    auxPar.Value = oCPROD.IMONEDA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@UNIDAD", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IUNIDAD"])
                {
                    auxPar.Value = oCPROD.IUNIDAD;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SERIE", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ISERIE"])
                {
                    auxPar.Value = oCPROD.ISERIE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LOTE", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ILOTE"])
                {
                    auxPar.Value = oCPROD.ILOTE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PROVEEDOR", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IPROVEEDOR"])
                {
                    auxPar.Value = oCPROD.IPROVEEDOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PROVEEDOR2", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IPROVEEDOR2"])
                {
                    auxPar.Value = oCPROD.IPROVEEDOR2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LINEA", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ILINEA"])
                {
                    auxPar.Value = oCPROD.ILINEA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MARCA", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IMARCA"])
                {
                    auxPar.Value = oCPROD.IMARCA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESC2", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IDESC2"])
                {
                    auxPar.Value = oCPROD.IDESC2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESC3", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IDESC3"])
                {
                    auxPar.Value = oCPROD.IDESC3;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO2", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPRECIO2"])
                {
                    auxPar.Value = oCPROD.IPRECIO2;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO3", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPRECIO3"])
                {
                    auxPar.Value = oCPROD.IPRECIO3;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO4", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPRECIO4"])
                {
                    auxPar.Value = oCPROD.IPRECIO4;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO5", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPRECIO5"])
                {
                    auxPar.Value = oCPROD.IPRECIO5;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO6", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPRECIO6"])
                {
                    auxPar.Value = oCPROD.IPRECIO6;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO7", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPRECIO7"])
                {
                    auxPar.Value = oCPROD.IPRECIO7;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CODIGO", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ICODIGO"])
                {
                    auxPar.Value = oCPROD.ICODIGO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CARGOS_U", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ICARGOS_U"])
                {
                    auxPar.Value = oCPROD.ICARGOS_U;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTO_REPO", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ICOSTO_REPO"])
                {
                    auxPar.Value = oCPROD.ICOSTO_REPO;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPRIMIR", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IIMPRIMIR"])
                {
                    auxPar.Value = oCPROD.IIMPRIMIR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@INVENTARIO", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IINVENTARIO"])
                {
                    auxPar.Value = oCPROD.IINVENTARIO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPUESTO", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IIMPUESTO"])
                {
                    auxPar.Value = oCPROD.IIMPUESTO;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NEGATIVOS", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["INEGATIVOS"])
                {
                    auxPar.Value = oCPROD.INEGATIVOS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMODIN", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ICOMODIN"])
                {
                    auxPar.Value = oCPROD.ICOMODIN;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LIMITE1", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ILIMITE1"])
                {
                    auxPar.Value = oCPROD.ILIMITE1;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESCUENTO2", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IDESCUENTO2"])
                {
                    auxPar.Value = oCPROD.IDESCUENTO2;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LIMITE2", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ILIMITE2"])
                {
                    auxPar.Value = oCPROD.ILIMITE2;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESCUENTO3", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IDESCUENTO3"])
                {
                    auxPar.Value = oCPROD.IDESCUENTO3;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@KIT", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IKIT"])
                {
                    auxPar.Value = oCPROD.IKIT;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PIEZAS", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPIEZAS"])
                {
                    auxPar.Value = oCPROD.IPIEZAS;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LPIEZAS", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ILPIEZAS"])
                {
                    auxPar.Value = oCPROD.ILPIEZAS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMISION", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ICOMISION"])
                {
                    auxPar.Value = oCPROD.ICOMISION;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMISION_E", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ICOMISION_E"])
                {
                    auxPar.Value = oCPROD.ICOMISION_E;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PROMOCION", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IPROMOCION"])
                {
                    auxPar.Value = oCPROD.IPROMOCION;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IID"])
                {
                    auxPar.Value = oCPROD.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCPROD.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCPROD.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IID_HORA"])
                {
                    auxPar.Value = oCPROD.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SUSTITUTO", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ISUSTITUTO"])
                {
                    auxPar.Value = oCPROD.ISUSTITUTO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CBARRAS", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ICBARRAS"])
                {
                    auxPar.Value = oCPROD.ICBARRAS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EMPAQUE", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IEMPAQUE"])
                {
                    auxPar.Value = oCPROD.IEMPAQUE;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PESO", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPESO"])
                {
                    auxPar.Value = oCPROD.IPESO;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO8", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPRECIO8"])
                {
                    auxPar.Value = oCPROD.IPRECIO8;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO9", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPRECIO9"])
                {
                    auxPar.Value = oCPROD.IPRECIO9;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@U_CAJA", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IU_CAJA"])
                {
                    auxPar.Value = oCPROD.IU_CAJA;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CUENTA", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ICUENTA"])
                {
                    auxPar.Value = oCPROD.ICUENTA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@RANKING", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IRANKING"])
                {
                    auxPar.Value = oCPROD.IRANKING;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TIPOABC", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ITIPOABC"])
                {
                    auxPar.Value = oCPROD.ITIPOABC;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TRAFICO", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ITRAFICO"])
                {
                    auxPar.Value = oCPROD.ITRAFICO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@UNIDAD2", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IUNIDAD2"])
                {
                    auxPar.Value = oCPROD.IUNIDAD2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@U_VENTA2", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IU_VENTA2"])
                {
                    auxPar.Value = oCPROD.IU_VENTA2;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VOLUMEN", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IVOLUMEN"])
                {
                    auxPar.Value = oCPROD.IVOLUMEN;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ABO", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IABO"])
                {
                    auxPar.Value = oCPROD.IABO;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LOC", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ILOC"])
                {
                    auxPar.Value = oCPROD.ILOC;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTO_ULTI", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ICOSTO_ULTI"])
                {
                    auxPar.Value = oCPROD.ICOSTO_ULTI;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTOULTUS", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ICOSTOULTUS"])
                {
                    auxPar.Value = oCPROD.ICOSTOULTUS;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@C_P_I", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IC_P_I"])
                {
                    auxPar.Value = oCPROD.IC_P_I;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@C_R_I", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IC_R_I"])
                {
                    auxPar.Value = oCPROD.IC_R_I;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@C_U_I", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IC_U_I"])
                {
                    auxPar.Value = oCPROD.IC_U_I;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTOREPUS", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ICOSTOREPUS"])
                {
                    auxPar.Value = oCPROD.ICOSTOREPUS;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ORDEN", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IORDEN"])
                {
                    auxPar.Value = oCPROD.IORDEN;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FORDEN", OleDbType.Date);
                if (!(bool)oCPROD.isnull["IFORDEN"])
                {
                    auxPar.Value = oCPROD.IFORDEN;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@APARTAKIT", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IAPARTAKIT"])
                {
                    auxPar.Value = oCPROD.IAPARTAKIT;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FMAXDIA", OleDbType.Date);
                if (!(bool)oCPROD.isnull["IFMAXDIA"])
                {
                    auxPar.Value = oCPROD.IFMAXDIA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PZACAJA", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPZACAJA"])
                {
                    auxPar.Value = oCPROD.IPZACAJA;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CEMPAQUE", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ICEMPAQUE"])
                {
                    auxPar.Value = oCPROD.ICEMPAQUE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MAYOXKG", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IMAYOXKG"])
                {
                    auxPar.Value = oCPROD.IMAYOXKG;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FCAMBIO", OleDbType.Date);
                if (!(bool)oCPROD.isnull["IFCAMBIO"])
                {
                    auxPar.Value = oCPROD.IFCAMBIO;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@INIMAYO", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IINIMAYO"])
                {
                    auxPar.Value = oCPROD.IINIMAYO;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CVETASAIVA", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ICVETASAIVA"])
                {
                    auxPar.Value = oCPROD.ICVETASAIVA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["INOMBRE"])
                {
                    auxPar.Value = oCPROD.INOMBRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRODPADRE", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IPRODPADRE"])
                {
                    auxPar.Value = oCPROD.IPRODPADRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);




                auxPar = new OleDbParameter("@TEXTO1", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ITEXTO1"])
                {
                    auxPar.Value = oCPROD.ITEXTO1;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@TEXTO2", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ITEXTO2"])
                {
                    auxPar.Value = oCPROD.ITEXTO2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TEXTO3", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ITEXTO3"])
                {
                    auxPar.Value = oCPROD.ITEXTO3;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TEXTO4", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ITEXTO4"])
                {
                    auxPar.Value = oCPROD.ITEXTO4;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TEXTO5", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ITEXTO5"])
                {
                    auxPar.Value = oCPROD.ITEXTO5;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TEXTO6", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ITEXTO6"])
                {
                    auxPar.Value = oCPROD.ITEXTO6;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@NUMERO1", OleDbType.Double);
                if (!(bool)oCPROD.isnull["INUMERO1"])
                {
                    auxPar.Value = oCPROD.INUMERO1;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@NUMERO2", OleDbType.Double);
                if (!(bool)oCPROD.isnull["INUMERO2"])
                {
                    auxPar.Value = oCPROD.INUMERO2;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);




                auxPar = new OleDbParameter("@NUMERO3", OleDbType.Double);
                if (!(bool)oCPROD.isnull["INUMERO3"])
                {
                    auxPar.Value = oCPROD.INUMERO3;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@NUMERO4", OleDbType.Double);
                if (!(bool)oCPROD.isnull["INUMERO4"])
                {
                    auxPar.Value = oCPROD.INUMERO4;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);





                auxPar = new OleDbParameter("@FECHA1", OleDbType.Date);
                if (!(bool)oCPROD.isnull["IFECHA1"])
                {
                    auxPar.Value = oCPROD.IFECHA1;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FECHA2", OleDbType.Date);
                if (!(bool)oCPROD.isnull["IFECHA2"])
                {
                    auxPar.Value = oCPROD.IFECHA2;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ESPADRE", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IESPADRE"])
                {
                    auxPar.Value = oCPROD.IESPADRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ESFINAL", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IESFINAL"])
                {
                    auxPar.Value = oCPROD.IESFINAL;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ESSUBPROD", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IESSUBPROD"])
                {
                    auxPar.Value = oCPROD.IESSUBPROD;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PRECPADRE", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IPRECPADRE"])
                {
                    auxPar.Value = oCPROD.IPRECPADRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@COMIPADRE", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ICOMIPADRE"])
                {
                    auxPar.Value = oCPROD.ICOMIPADRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@OFEPADRE", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IOFEPADRE"])
                {
                    auxPar.Value = oCPROD.IOFEPADRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@OFERTA", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IOFERTA"])
                {
                    auxPar.Value = oCPROD.IOFERTA;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESC", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IDESC"])
                {
                    auxPar.Value = oCPROD.IDESC;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CAMBIARPRE", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ICAMBIARPRE"])
                {
                    auxPar.Value = oCPROD.ICAMBIARPRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PLUG", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IPLUG"])
                {
                    auxPar.Value = oCPROD.IPLUG;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTOPROUS", OleDbType.Double);
                auxPar.Value = 0.00;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TASAIEPS", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ITASAIEPS"])
                {
                    auxPar.Value = oCPROD.ITASAIEPS;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MINUTIL", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IMINUTIL"])
                {
                    auxPar.Value = oCPROD.IMINUTIL;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@SPRECIO1", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ISPRECIO1"])
                {
                    auxPar.Value = oCPROD.ISPRECIO1;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SPRECIO2", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ISPRECIO2"])
                {
                    auxPar.Value = oCPROD.ISPRECIO2;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SPRECIO3", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ISPRECIO3"])
                {
                    auxPar.Value = oCPROD.ISPRECIO3;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SPRECIO4", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ISPRECIO4"])
                {
                    auxPar.Value = oCPROD.ISPRECIO4;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SPRECIO5", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ISPRECIO5"])
                {
                    auxPar.Value = oCPROD.ISPRECIO5;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);




                auxPar = new OleDbParameter("@RRECETA", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IRRECETA"])
                {
                    auxPar.Value = oCPROD.IRRECETA;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PRECTOPE", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPRECTOPE"])
                {
                    auxPar.Value = oCPROD.IPRECTOPE;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIOMAT", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IPRECIOMAT"])
                {
                    auxPar.Value = oCPROD.IPRECIOMAT;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@MENUDEO", OleDbType.Integer);
                if (!(bool)oCPROD.isnull["IMENUDEO"])
                {
                    auxPar.Value = oCPROD.IMENUDEO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLAVE_CONT", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ICLAVE_CONT"])
                {
                    auxPar.Value = oCPROD.ICLAVE_CONT;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CONTENIDO", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ICONTENIDO"])
                {
                    auxPar.Value = oCPROD.ICONTENIDO;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLASIFICA", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ICLASIFICA"])
                {
                    auxPar.Value = oCPROD.ICLASIFICA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANTXPIEZA", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ICANTXPIEZA"])
                {
                    auxPar.Value = oCPROD.ICANTXPIEZA;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LOTEIMPO", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ILOTEIMPO"])
                {
                    auxPar.Value = oCPROD.ILOTEIMPO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTOUSD", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ICOSTOUSD"])
                {
                    auxPar.Value = oCPROD.ICOSTOUSD;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PLAZO", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IPLAZO"])
                {
                    auxPar.Value = oCPROD.IPLAZO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CLAVESAT", OleDbType.VarChar);
                if(!(bool)oCPROD.isnull["ICLAVESAT"])
                {
                    auxPar.Value = oCPROD.ICLAVESAT;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESPRODPROM", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IESPRODPROM"])
                {
                    auxPar.Value = oCPROD.IESPRODPROM;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@BASEPROM", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IBASEPROM"])
                {
                    auxPar.Value = oCPROD.IBASEPROM;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VIGPROM", OleDbType.Date);
                if (!(bool)oCPROD.isnull["IVIGPROM"])
                {
                    auxPar.Value = oCPROD.IVIGPROM;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VIGKIT", OleDbType.Date);
                if (!(bool)oCPROD.isnull["IVIGKIT"])
                {
                    auxPar.Value = oCPROD.IVIGKIT;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@KITCVIG", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IKITCVIG"])
                {
                    auxPar.Value = oCPROD.IKITCVIG;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VALXSUC", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IVALXSUC"])
                {
                    auxPar.Value = oCPROD.IVALXSUC;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@DESGKIT", OleDbType.Boolean);
                if (!(bool)oCPROD.isnull["IDESGKIT"])
                {
                    auxPar.Value = oCPROD.IDESGKIT;
                }
                else
                {
                    auxPar.Value = false;
                }
                parts.Add(auxPar);




                auxPar = new OleDbParameter("@PUPRECIO1", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPUPRECIO1"])
                {
                    auxPar.Value = oCPROD.IPUPRECIO1;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PUPRECIO2", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPUPRECIO2"])
                {
                    auxPar.Value = oCPROD.IPUPRECIO2;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PUPRECIO3", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPUPRECIO3"])
                {
                    auxPar.Value = oCPROD.IPUPRECIO3;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PUPRECIO4", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPUPRECIO4"])
                {
                    auxPar.Value = oCPROD.IPUPRECIO4;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PUPRECIO5", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPUPRECIO5"])
                {
                    auxPar.Value = oCPROD.IPUPRECIO5;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPCOM", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IIMPCOM"])
                {
                    auxPar.Value = oCPROD.IIMPCOM;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LMEDMAY", OleDbType.Integer);
                if (!(bool)oCPROD.isnull["ILMEDMAY"])
                {
                    auxPar.Value = oCPROD.ILMEDMAY;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LMAYO", OleDbType.Integer);
                if (!(bool)oCPROD.isnull["ILMAYO"])
                {
                    auxPar.Value = oCPROD.ILMAYO;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@CMEDMAY", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ICMEDMAY"])
                {
                    auxPar.Value = oCPROD.ICMEDMAY;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CMAYO", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ICMAYO"])
                {
                    auxPar.Value = oCPROD.ICMAYO;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);




                auxPar = new OleDbParameter("@TIPOEMB", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ITIPOEMB"])
                {
                    auxPar.Value = oCPROD.ITIPOEMB;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@CVEUPESO", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ICVEUPESO"])
                {
                    auxPar.Value = oCPROD.ICVEUPESO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESPELIG", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IESPELIG"])
                {
                    auxPar.Value = oCPROD.IESPELIG;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@MATPELI", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IMATPELI"])
                {
                    auxPar.Value = oCPROD.IMATPELI;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESOFERTA", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IESOFERTA"])
                {
                    auxPar.Value = oCPROD.IESOFERTA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                string commandText = @"
        INSERT INTO  " + strFileName + @" 
      (
    
PRODUCTO,

DESC1,

PRECIO1,

DESCUENTO1,

U_EMPAQUE,

MONEDA,

UNIDAD,

SERIE,

LOTE,

PROVEEDOR,

PROVEEDOR2,

LINEA,

MARCA,

DESC2,

DESC3,

PRECIO2,

PRECIO3,

PRECIO4,

PRECIO5,

PRECIO6,

PRECIO7,

CODIGO,

CARGOS_U,

COSTO_REPO,

IMPRIMIR,

INVENTARIO,

IMPUESTO,

NEGATIVOS,

COMODIN,

LIMITE1,

DESCUENTO2,

LIMITE2,

DESCUENTO3,

KIT,

PIEZAS,

LPIEZAS,

COMISION,

COMISION_E,

PROMOCION,

ID,

ID_FECHA,

ID_HORA,

SUSTITUTO,

CBARRAS,

EMPAQUE,

PESO,

PRECIO8,

PRECIO9,

U_CAJA,

CUENTA,

RANKING,

TIPOABC,

TRAFICO,

UNIDAD2,

U_VENTA2,

VOLUMEN,

ABO,

LOC,

COSTO_ULTI,

COSTOULTUS,

C_P_I,

C_R_I,

C_U_I,

COSTOREPUS,

ORDEN,

FORDEN,

APARTAKIT,

FMAXDIA,

PZACAJA,

CEMPAQUE,

MAYOXKG,

FCAMBIO,

INIMAYO,

CVETASAIVA,

NOMBRE,

PRODPADRE,

TEXTO1,
TEXTO2,
TEXTO3,
TEXTO4,
TEXTO5,
TEXTO6,

NUMERO1,
NUMERO2,
NUMERO3,
NUMERO4,

FECHA1,
FECHA2,

ESPADRE,
ESFINAL,
ESSUBPROD,
PRECPADRE,
COMIPADRE,
OFEPADRE,

OFERTA,
DESC,

CAMBIARPRE,

PLUG,

COSTOPROUS,

TASAIEPS,

MINUTIL,

SPRECIO1,

SPRECIO2,

SPRECIO3,

SPRECIO4,

SPRECIO5,

RRECETA,

PRECTOPE,

PRECIOMAT,

MENUDEO,

CLAVE_CONT,

CONTENIDO,

CLASIFICA,

CANTXPIEZA,

LOTEIMPO,

COSTOUSD,

PLAZO,

CLAVESAT,

ESPRODPROM,
BASEPROM,
VIGPROM,

VIGKIT,

KITCVIG,

VALXSUC,

DESGKIT,

PUPRECIO1,

PUPRECIO2,

PUPRECIO3,

PUPRECIO4,

PUPRECIO5,

IMPCOM,



LMEDMAY,

LMAYO,

CMEDMAY,

CMAYO,


TIPOEMB,

CVEUPESO,

ESPELIG,

MATPELI,


ESOFERTA


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

                if (st == null)
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




       //public bool AgregarPROD_MOVIL(CPRODBE oCPROD, string strFileName, OleDbTransaction st, string strOleDbConn)
        public bool AgregarPROD_MOVIL(CPRODBE oCPROD, string strFileName,  string strOleDbConn)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCPROD.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESC1", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IDESC1"])
                {
                    auxPar.Value = oCPROD.IDESC1;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO1", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPRECIO1"])
                {
                    auxPar.Value = oCPROD.IPRECIO1;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESCUENTO1", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IDESCUENTO1"])
                {
                    auxPar.Value = oCPROD.IDESCUENTO1;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@U_EMPAQUE", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IU_EMPAQUE"])
                {
                    auxPar.Value = oCPROD.IU_EMPAQUE;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MONEDA", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IMONEDA"])
                {
                    auxPar.Value = oCPROD.IMONEDA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@UNIDAD", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IUNIDAD"])
                {
                    auxPar.Value = oCPROD.IUNIDAD;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SERIE", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ISERIE"])
                {
                    auxPar.Value = oCPROD.ISERIE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LOTE", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ILOTE"])
                {
                    auxPar.Value = oCPROD.ILOTE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PROVEEDOR", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IPROVEEDOR"])
                {
                    auxPar.Value = oCPROD.IPROVEEDOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PROVEEDOR2", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IPROVEEDOR2"])
                {
                    auxPar.Value = oCPROD.IPROVEEDOR2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LINEA", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ILINEA"])
                {
                    auxPar.Value = oCPROD.ILINEA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MARCA", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IMARCA"])
                {
                    auxPar.Value = oCPROD.IMARCA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESC2", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IDESC2"])
                {
                    auxPar.Value = oCPROD.IDESC2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESC3", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IDESC3"])
                {
                    auxPar.Value = oCPROD.IDESC3;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO2", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPRECIO2"])
                {
                    auxPar.Value = oCPROD.IPRECIO2;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO3", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPRECIO3"])
                {
                    auxPar.Value = oCPROD.IPRECIO3;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO4", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPRECIO4"])
                {
                    auxPar.Value = oCPROD.IPRECIO4;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO5", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPRECIO5"])
                {
                    auxPar.Value = oCPROD.IPRECIO5;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO6", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPRECIO6"])
                {
                    auxPar.Value = oCPROD.IPRECIO6;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO7", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPRECIO7"])
                {
                    auxPar.Value = oCPROD.IPRECIO7;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CODIGO", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ICODIGO"])
                {
                    auxPar.Value = oCPROD.ICODIGO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CARGOS_U", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ICARGOS_U"])
                {
                    auxPar.Value = oCPROD.ICARGOS_U;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTO_REPO", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ICOSTO_REPO"])
                {
                    auxPar.Value = oCPROD.ICOSTO_REPO;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPRIMIR", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IIMPRIMIR"])
                {
                    auxPar.Value = oCPROD.IIMPRIMIR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@INVENTARIO", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IINVENTARIO"])
                {
                    auxPar.Value = oCPROD.IINVENTARIO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPUESTO", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IIMPUESTO"])
                {
                    auxPar.Value = oCPROD.IIMPUESTO;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NEGATIVOS", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["INEGATIVOS"])
                {
                    auxPar.Value = oCPROD.INEGATIVOS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMODIN", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ICOMODIN"])
                {
                    auxPar.Value = oCPROD.ICOMODIN;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LIMITE1", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ILIMITE1"])
                {
                    auxPar.Value = oCPROD.ILIMITE1;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESCUENTO2", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IDESCUENTO2"])
                {
                    auxPar.Value = oCPROD.IDESCUENTO2;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LIMITE2", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ILIMITE2"])
                {
                    auxPar.Value = oCPROD.ILIMITE2;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESCUENTO3", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IDESCUENTO3"])
                {
                    auxPar.Value = oCPROD.IDESCUENTO3;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@KIT", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IKIT"])
                {
                    auxPar.Value = oCPROD.IKIT;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PIEZAS", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPIEZAS"])
                {
                    auxPar.Value = oCPROD.IPIEZAS;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LPIEZAS", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ILPIEZAS"])
                {
                    auxPar.Value = oCPROD.ILPIEZAS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMISION", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ICOMISION"])
                {
                    auxPar.Value = oCPROD.ICOMISION;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMISION_E", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ICOMISION_E"])
                {
                    auxPar.Value = oCPROD.ICOMISION_E;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PROMOCION", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IPROMOCION"])
                {
                    auxPar.Value = oCPROD.IPROMOCION;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IID"])
                {
                    auxPar.Value = oCPROD.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCPROD.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCPROD.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IID_HORA"])
                {
                    auxPar.Value = oCPROD.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SUSTITUTO", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ISUSTITUTO"])
                {
                    auxPar.Value = oCPROD.ISUSTITUTO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CBARRAS", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ICBARRAS"])
                {
                    auxPar.Value = oCPROD.ICBARRAS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EMPAQUE", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IEMPAQUE"])
                {
                    auxPar.Value = oCPROD.IEMPAQUE;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PESO", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPESO"])
                {
                    auxPar.Value = oCPROD.IPESO;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO8", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPRECIO8"])
                {
                    auxPar.Value = oCPROD.IPRECIO8;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO9", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPRECIO9"])
                {
                    auxPar.Value = oCPROD.IPRECIO9;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@U_CAJA", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IU_CAJA"])
                {
                    auxPar.Value = oCPROD.IU_CAJA;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CUENTA", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ICUENTA"])
                {
                    auxPar.Value = oCPROD.ICUENTA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@RANKING", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IRANKING"])
                {
                    auxPar.Value = oCPROD.IRANKING;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TIPOABC", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ITIPOABC"])
                {
                    auxPar.Value = oCPROD.ITIPOABC;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TRAFICO", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ITRAFICO"])
                {
                    auxPar.Value = oCPROD.ITRAFICO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@UNIDAD2", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IUNIDAD2"])
                {
                    auxPar.Value = oCPROD.IUNIDAD2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@U_VENTA2", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IU_VENTA2"])
                {
                    auxPar.Value = oCPROD.IU_VENTA2;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VOLUMEN", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IVOLUMEN"])
                {
                    auxPar.Value = oCPROD.IVOLUMEN;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ABO", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IABO"])
                {
                    auxPar.Value = oCPROD.IABO;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LOC", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ILOC"])
                {
                    auxPar.Value = oCPROD.ILOC;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTO_ULTI", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ICOSTO_ULTI"])
                {
                    auxPar.Value = oCPROD.ICOSTO_ULTI;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTOULTUS", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ICOSTOULTUS"])
                {
                    auxPar.Value = oCPROD.ICOSTOULTUS;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@C_P_I", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IC_P_I"])
                {
                    auxPar.Value = oCPROD.IC_P_I;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@C_R_I", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IC_R_I"])
                {
                    auxPar.Value = oCPROD.IC_R_I;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@C_U_I", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IC_U_I"])
                {
                    auxPar.Value = oCPROD.IC_U_I;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTOREPUS", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ICOSTOREPUS"])
                {
                    auxPar.Value = oCPROD.ICOSTOREPUS;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ORDEN", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IORDEN"])
                {
                    auxPar.Value = oCPROD.IORDEN;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FORDEN", OleDbType.Date);
                if (!(bool)oCPROD.isnull["IFORDEN"])
                {
                    auxPar.Value = oCPROD.IFORDEN;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@APARTAKIT", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IAPARTAKIT"])
                {
                    auxPar.Value = oCPROD.IAPARTAKIT;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FMAXDIA", OleDbType.Date);
                if (!(bool)oCPROD.isnull["IFMAXDIA"])
                {
                    auxPar.Value = oCPROD.IFMAXDIA;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PZACAJA", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPZACAJA"])
                {
                    auxPar.Value = oCPROD.IPZACAJA;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CEMPAQUE", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ICEMPAQUE"])
                {
                    auxPar.Value = oCPROD.ICEMPAQUE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MAYOXKG", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IMAYOXKG"])
                {
                    auxPar.Value = oCPROD.IMAYOXKG;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FCAMBIO", OleDbType.Date);
                if (!(bool)oCPROD.isnull["IFCAMBIO"])
                {
                    auxPar.Value = oCPROD.IFCAMBIO;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@INIMAYO", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IINIMAYO"])
                {
                    auxPar.Value = oCPROD.IINIMAYO;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CVETASAIVA", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ICVETASAIVA"])
                {
                    auxPar.Value = oCPROD.ICVETASAIVA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@NOMBRE", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["INOMBRE"])
                {
                    auxPar.Value = oCPROD.INOMBRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRODPADRE", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IPRODPADRE"])
                {
                    auxPar.Value = oCPROD.IPRODPADRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);




                auxPar = new OleDbParameter("@TEXTO1", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ITEXTO1"])
                {
                    auxPar.Value = oCPROD.ITEXTO1;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@TEXTO2", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ITEXTO2"])
                {
                    auxPar.Value = oCPROD.ITEXTO2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TEXTO3", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ITEXTO3"])
                {
                    auxPar.Value = oCPROD.ITEXTO3;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TEXTO4", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ITEXTO4"])
                {
                    auxPar.Value = oCPROD.ITEXTO4;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TEXTO5", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ITEXTO5"])
                {
                    auxPar.Value = oCPROD.ITEXTO5;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TEXTO6", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ITEXTO6"])
                {
                    auxPar.Value = oCPROD.ITEXTO6;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@NUMERO1", OleDbType.Double);
                if (!(bool)oCPROD.isnull["INUMERO1"])
                {
                    auxPar.Value = oCPROD.INUMERO1;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@NUMERO2", OleDbType.Double);
                if (!(bool)oCPROD.isnull["INUMERO2"])
                {
                    auxPar.Value = oCPROD.INUMERO2;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);




                auxPar = new OleDbParameter("@NUMERO3", OleDbType.Double);
                if (!(bool)oCPROD.isnull["INUMERO3"])
                {
                    auxPar.Value = oCPROD.INUMERO3;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@NUMERO4", OleDbType.Double);
                if (!(bool)oCPROD.isnull["INUMERO4"])
                {
                    auxPar.Value = oCPROD.INUMERO4;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);





                auxPar = new OleDbParameter("@FECHA1", OleDbType.Date);
                if (!(bool)oCPROD.isnull["IFECHA1"])
                {
                    auxPar.Value = oCPROD.IFECHA1;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FECHA2", OleDbType.Date);
                if (!(bool)oCPROD.isnull["IFECHA2"])
                {
                    auxPar.Value = oCPROD.IFECHA2;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ESPADRE", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IESPADRE"])
                {
                    auxPar.Value = oCPROD.IESPADRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ESFINAL", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IESFINAL"])
                {
                    auxPar.Value = oCPROD.IESFINAL;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@ESSUBPROD", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IESSUBPROD"])
                {
                    auxPar.Value = oCPROD.IESSUBPROD;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PRECPADRE", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IPRECPADRE"])
                {
                    auxPar.Value = oCPROD.IPRECPADRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@COMIPADRE", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ICOMIPADRE"])
                {
                    auxPar.Value = oCPROD.ICOMIPADRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@OFEPADRE", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IOFEPADRE"])
                {
                    auxPar.Value = oCPROD.IOFEPADRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@OFERTA", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IOFERTA"])
                {
                    auxPar.Value = oCPROD.IOFERTA;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESC", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IDESC"])
                {
                    auxPar.Value = oCPROD.IDESC;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CAMBIARPRE", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ICAMBIARPRE"])
                {
                    auxPar.Value = oCPROD.ICAMBIARPRE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PLUG", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IPLUG"])
                {
                    auxPar.Value = oCPROD.IPLUG;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTOPROUS", OleDbType.Double);
                auxPar.Value = 0.00;
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TASAIEPS", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ITASAIEPS"])
                {
                    auxPar.Value = oCPROD.ITASAIEPS;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MINUTIL", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IMINUTIL"])
                {
                    auxPar.Value = oCPROD.IMINUTIL;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@SPRECIO1", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ISPRECIO1"])
                {
                    auxPar.Value = oCPROD.ISPRECIO1;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SPRECIO2", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ISPRECIO2"])
                {
                    auxPar.Value = oCPROD.ISPRECIO2;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SPRECIO3", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ISPRECIO3"])
                {
                    auxPar.Value = oCPROD.ISPRECIO3;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SPRECIO4", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ISPRECIO4"])
                {
                    auxPar.Value = oCPROD.ISPRECIO4;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SPRECIO5", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ISPRECIO5"])
                {
                    auxPar.Value = oCPROD.ISPRECIO5;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);




                auxPar = new OleDbParameter("@RRECETA", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IRRECETA"])
                {
                    auxPar.Value = oCPROD.IRRECETA;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PRECTOPE", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPRECTOPE"])
                {
                    auxPar.Value = oCPROD.IPRECTOPE;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIOMAT", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IPRECIOMAT"])
                {
                    auxPar.Value = oCPROD.IPRECIOMAT;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@MENUDEO", OleDbType.Integer);
                if (!(bool)oCPROD.isnull["IMENUDEO"])
                {
                    auxPar.Value = oCPROD.IMENUDEO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLAVE_CONT", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ICLAVE_CONT"])
                {
                    auxPar.Value = oCPROD.ICLAVE_CONT;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CONTENIDO", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ICONTENIDO"])
                {
                    auxPar.Value = oCPROD.ICONTENIDO;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLASIFICA", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ICLASIFICA"])
                {
                    auxPar.Value = oCPROD.ICLASIFICA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CANTXPIEZA", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ICANTXPIEZA"])
                {
                    auxPar.Value = oCPROD.ICANTXPIEZA;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LOTEIMPO", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ILOTEIMPO"])
                {
                    auxPar.Value = oCPROD.ILOTEIMPO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTOUSD", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ICOSTOUSD"])
                {
                    auxPar.Value = oCPROD.ICOSTOUSD;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PLAZO", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IPLAZO"])
                {
                    auxPar.Value = oCPROD.IPLAZO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CLAVESAT", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["ICLAVESAT"])
                {
                    auxPar.Value = oCPROD.ICLAVESAT;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESPRODPROM", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IESPRODPROM"])
                {
                    auxPar.Value = oCPROD.IESPRODPROM;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@BASEPROM", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IBASEPROM"])
                {
                    auxPar.Value = oCPROD.IBASEPROM;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@VIGPROM", OleDbType.Date);
                if (!(bool)oCPROD.isnull["IVIGPROM"])
                {
                    auxPar.Value = oCPROD.IVIGPROM;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@EXIS1", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IEXIS1"])
                {
                    auxPar.Value = oCPROD.IEXIS1;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@VIGKIT", OleDbType.Date);
                if (!(bool)oCPROD.isnull["IVIGKIT"])
                {
                    auxPar.Value = oCPROD.IVIGKIT;
                }
                else
                {
                    auxPar.Value = DateTime.MinValue;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@KITCVIG", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IKITCVIG"])
                {
                    auxPar.Value = oCPROD.IKITCVIG;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@VALXSUC", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IVALXSUC"])
                {
                    auxPar.Value = oCPROD.IVALXSUC;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@DESGKIT", OleDbType.Boolean);
                if (!(bool)oCPROD.isnull["IDESGKIT"])
                {
                    auxPar.Value = oCPROD.IDESGKIT;
                }
                else
                {
                    auxPar.Value = false;
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@PUPRECIO1", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPUPRECIO1"])
                {
                    auxPar.Value = oCPROD.IPUPRECIO1;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PUPRECIO2", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPUPRECIO2"])
                {
                    auxPar.Value = oCPROD.IPUPRECIO2;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PUPRECIO3", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPUPRECIO3"])
                {
                    auxPar.Value = oCPROD.IPUPRECIO3;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PUPRECIO4", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPUPRECIO4"])
                {
                    auxPar.Value = oCPROD.IPUPRECIO4;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PUPRECIO5", OleDbType.Double);
                if (!(bool)oCPROD.isnull["IPUPRECIO5"])
                {
                    auxPar.Value = oCPROD.IPUPRECIO5;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPCOM", OleDbType.VarChar);
                if (!(bool)oCPROD.isnull["IIMPCOM"])
                {
                    auxPar.Value = oCPROD.IIMPCOM;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@LMEDMAY", OleDbType.Integer);
                if (!(bool)oCPROD.isnull["ILMEDMAY"])
                {
                    auxPar.Value = oCPROD.ILMEDMAY;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LMAYO", OleDbType.Integer);
                if (!(bool)oCPROD.isnull["ILMAYO"])
                {
                    auxPar.Value = oCPROD.ILMAYO;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);



                auxPar = new OleDbParameter("@CMEDMAY", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ICMEDMAY"])
                {
                    auxPar.Value = oCPROD.ICMEDMAY;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CMAYO", OleDbType.Double);
                if (!(bool)oCPROD.isnull["ICMAYO"])
                {
                    auxPar.Value = oCPROD.ICMAYO;
                }
                else
                {
                    auxPar.Value = 0.00;
                }
                parts.Add(auxPar);



                string commandText = @"
        INSERT INTO  " + strFileName + @" 
      (
    
PRODUCTO,

DESC1,

PRECIO1,

DESCUENTO1,

U_EMPAQUE,

MONEDA,

UNIDAD,

SERIE,

LOTE,

PROVEEDOR,

PROVEEDOR2,

LINEA,

MARCA,

DESC2,

DESC3,

PRECIO2,

PRECIO3,

PRECIO4,

PRECIO5,

PRECIO6,

PRECIO7,

CODIGO,

CARGOS_U,

COSTO_REPO,

IMPRIMIR,

INVENTARIO,

IMPUESTO,

NEGATIVOS,

COMODIN,

LIMITE1,

DESCUENTO2,

LIMITE2,

DESCUENTO3,

KIT,

PIEZAS,

LPIEZAS,

COMISION,

COMISION_E,

PROMOCION,

ID,

ID_FECHA,

ID_HORA,

SUSTITUTO,

CBARRAS,

EMPAQUE,

PESO,

PRECIO8,

PRECIO9,

U_CAJA,

CUENTA,

RANKING,

TIPOABC,

TRAFICO,

UNIDAD2,

U_VENTA2,

VOLUMEN,

ABO,

LOC,

COSTO_ULTI,

COSTOULTUS,

C_P_I,

C_R_I,

C_U_I,

COSTOREPUS,

ORDEN,

FORDEN,

APARTAKIT,

FMAXDIA,

PZACAJA,

CEMPAQUE,

MAYOXKG,

FCAMBIO,

INIMAYO,

CVETASAIVA,

NOMBRE,

PRODPADRE,

TEXTO1,
TEXTO2,
TEXTO3,
TEXTO4,
TEXTO5,
TEXTO6,

NUMERO1,
NUMERO2,
NUMERO3,
NUMERO4,

FECHA1,
FECHA2,

ESPADRE,
ESFINAL,
ESSUBPROD,
PRECPADRE,
COMIPADRE,
OFEPADRE,

OFERTA,
DESC,

CAMBIARPRE,

PLUG,

COSTOPROUS,

TASAIEPS,

MINUTIL,

SPRECIO1,

SPRECIO2,

SPRECIO3,

SPRECIO4,

SPRECIO5,

RRECETA,

PRECTOPE,

PRECIOMAT,

MENUDEO,

CLAVE_CONT,

CONTENIDO,

CLASIFICA,

CANTXPIEZA,

LOTEIMPO,

COSTOUSD,

PLAZO,

CLAVESAT,

ESPRODPROM,
BASEPROM,
VIGPROM,
EXIS1,

VIGKIT,

KITCVIG,

VALXSUC,

DESGKIT,

PUPRECIO1,

PUPRECIO2,

PUPRECIO3,

PUPRECIO4,

PUPRECIO5,

IMPCOM,



LMEDMAY,

LMAYO,

CMEDMAY,

CMAYO

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


        [AutoComplete]
        public bool BorrarPRODD(CPRODBE oCPROD, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                auxPar.Value = oCPROD.IPRODUCTO;
                parts.Add(auxPar);



                string commandText = @"  Delete from PROD
  where

  PRODUCTO=@PRODUCTO
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
        public bool CambiarPRODD(CPRODBE oCPRODNuevo, CPRODBE oCPRODAnterior, OleDbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCPRODNuevo.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@DESC1", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["IDESC1"])
                {
                    auxPar.Value = oCPRODNuevo.IDESC1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PRECIO1", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["IPRECIO1"])
                {
                    auxPar.Value = oCPRODNuevo.IPRECIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@DESCUENTO1", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["IDESCUENTO1"])
                {
                    auxPar.Value = oCPRODNuevo.IDESCUENTO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@U_EMPAQUE", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["IU_EMPAQUE"])
                {
                    auxPar.Value = oCPRODNuevo.IU_EMPAQUE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@MONEDA", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["IMONEDA"])
                {
                    auxPar.Value = oCPRODNuevo.IMONEDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@UNIDAD", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["IUNIDAD"])
                {
                    auxPar.Value = oCPRODNuevo.IUNIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SERIE", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["ISERIE"])
                {
                    auxPar.Value = oCPRODNuevo.ISERIE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@LOTE", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["ILOTE"])
                {
                    auxPar.Value = oCPRODNuevo.ILOTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PROVEEDOR", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["IPROVEEDOR"])
                {
                    auxPar.Value = oCPRODNuevo.IPROVEEDOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PROVEEDOR2", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["IPROVEEDOR2"])
                {
                    auxPar.Value = oCPRODNuevo.IPROVEEDOR2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@LINEA", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["ILINEA"])
                {
                    auxPar.Value = oCPRODNuevo.ILINEA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@MARCA", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["IMARCA"])
                {
                    auxPar.Value = oCPRODNuevo.IMARCA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@DESC2", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["IDESC2"])
                {
                    auxPar.Value = oCPRODNuevo.IDESC2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@DESC3", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["IDESC3"])
                {
                    auxPar.Value = oCPRODNuevo.IDESC3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PRECIO2", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["IPRECIO2"])
                {
                    auxPar.Value = oCPRODNuevo.IPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PRECIO3", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["IPRECIO3"])
                {
                    auxPar.Value = oCPRODNuevo.IPRECIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PRECIO4", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["IPRECIO4"])
                {
                    auxPar.Value = oCPRODNuevo.IPRECIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PRECIO5", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["IPRECIO5"])
                {
                    auxPar.Value = oCPRODNuevo.IPRECIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PRECIO6", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["IPRECIO6"])
                {
                    auxPar.Value = oCPRODNuevo.IPRECIO6;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PRECIO7", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["IPRECIO7"])
                {
                    auxPar.Value = oCPRODNuevo.IPRECIO7;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CODIGO", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["ICODIGO"])
                {
                    auxPar.Value = oCPRODNuevo.ICODIGO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CARGOS_U", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["ICARGOS_U"])
                {
                    auxPar.Value = oCPRODNuevo.ICARGOS_U;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COSTO_REPO", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["ICOSTO_REPO"])
                {
                    auxPar.Value = oCPRODNuevo.ICOSTO_REPO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IMPRIMIR", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["IIMPRIMIR"])
                {
                    auxPar.Value = oCPRODNuevo.IIMPRIMIR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@INVENTARIO", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["IINVENTARIO"])
                {
                    auxPar.Value = oCPRODNuevo.IINVENTARIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@IMPUESTO", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["IIMPUESTO"])
                {
                    auxPar.Value = oCPRODNuevo.IIMPUESTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@NEGATIVOS", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["INEGATIVOS"])
                {
                    auxPar.Value = oCPRODNuevo.INEGATIVOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COMODIN", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["ICOMODIN"])
                {
                    auxPar.Value = oCPRODNuevo.ICOMODIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@LIMITE1", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["ILIMITE1"])
                {
                    auxPar.Value = oCPRODNuevo.ILIMITE1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@DESCUENTO2", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["IDESCUENTO2"])
                {
                    auxPar.Value = oCPRODNuevo.IDESCUENTO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@LIMITE2", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["ILIMITE2"])
                {
                    auxPar.Value = oCPRODNuevo.ILIMITE2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@DESCUENTO3", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["IDESCUENTO3"])
                {
                    auxPar.Value = oCPRODNuevo.IDESCUENTO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@KIT", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["IKIT"])
                {
                    auxPar.Value = oCPRODNuevo.IKIT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PIEZAS", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["IPIEZAS"])
                {
                    auxPar.Value = oCPRODNuevo.IPIEZAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@LPIEZAS", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["ILPIEZAS"])
                {
                    auxPar.Value = oCPRODNuevo.ILPIEZAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COMISION", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["ICOMISION"])
                {
                    auxPar.Value = oCPRODNuevo.ICOMISION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COMISION_E", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["ICOMISION_E"])
                {
                    auxPar.Value = oCPRODNuevo.ICOMISION_E;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PROMOCION", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["IPROMOCION"])
                {
                    auxPar.Value = oCPRODNuevo.IPROMOCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["IID"])
                {
                    auxPar.Value = oCPRODNuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCPRODNuevo.IID_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["IID_HORA"])
                {
                    auxPar.Value = oCPRODNuevo.IID_HORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@SUSTITUTO", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["ISUSTITUTO"])
                {
                    auxPar.Value = oCPRODNuevo.ISUSTITUTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CBARRAS", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["ICBARRAS"])
                {
                    auxPar.Value = oCPRODNuevo.ICBARRAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@EMPAQUE", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["IEMPAQUE"])
                {
                    auxPar.Value = oCPRODNuevo.IEMPAQUE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PESO", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["IPESO"])
                {
                    auxPar.Value = oCPRODNuevo.IPESO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PRECIO8", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["IPRECIO8"])
                {
                    auxPar.Value = oCPRODNuevo.IPRECIO8;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PRECIO9", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["IPRECIO9"])
                {
                    auxPar.Value = oCPRODNuevo.IPRECIO9;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@U_CAJA", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["IU_CAJA"])
                {
                    auxPar.Value = oCPRODNuevo.IU_CAJA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CUENTA", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["ICUENTA"])
                {
                    auxPar.Value = oCPRODNuevo.ICUENTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@RANKING", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["IRANKING"])
                {
                    auxPar.Value = oCPRODNuevo.IRANKING;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TIPOABC", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["ITIPOABC"])
                {
                    auxPar.Value = oCPRODNuevo.ITIPOABC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@TRAFICO", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["ITRAFICO"])
                {
                    auxPar.Value = oCPRODNuevo.ITRAFICO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@UNIDAD2", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["IUNIDAD2"])
                {
                    auxPar.Value = oCPRODNuevo.IUNIDAD2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@U_VENTA2", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["IU_VENTA2"])
                {
                    auxPar.Value = oCPRODNuevo.IU_VENTA2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@VOLUMEN", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["IVOLUMEN"])
                {
                    auxPar.Value = oCPRODNuevo.IVOLUMEN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ABO", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["IABO"])
                {
                    auxPar.Value = oCPRODNuevo.IABO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@LOC", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["ILOC"])
                {
                    auxPar.Value = oCPRODNuevo.ILOC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COSTO_ULTI", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["ICOSTO_ULTI"])
                {
                    auxPar.Value = oCPRODNuevo.ICOSTO_ULTI;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COSTOULTUS", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["ICOSTOULTUS"])
                {
                    auxPar.Value = oCPRODNuevo.ICOSTOULTUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@C_P_I", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["IC_P_I"])
                {
                    auxPar.Value = oCPRODNuevo.IC_P_I;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@C_R_I", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["IC_R_I"])
                {
                    auxPar.Value = oCPRODNuevo.IC_R_I;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@C_U_I", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["IC_U_I"])
                {
                    auxPar.Value = oCPRODNuevo.IC_U_I;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@COSTOREPUS", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["ICOSTOREPUS"])
                {
                    auxPar.Value = oCPRODNuevo.ICOSTOREPUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@ORDEN", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["IORDEN"])
                {
                    auxPar.Value = oCPRODNuevo.IORDEN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@FORDEN", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["IFORDEN"])
                {
                    auxPar.Value = oCPRODNuevo.IFORDEN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@APARTAKIT", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["IAPARTAKIT"])
                {
                    auxPar.Value = oCPRODNuevo.IAPARTAKIT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@FMAXDIA", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["IFMAXDIA"])
                {
                    auxPar.Value = oCPRODNuevo.IFMAXDIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PZACAJA", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["IPZACAJA"])
                {
                    auxPar.Value = oCPRODNuevo.IPZACAJA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CEMPAQUE", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["ICEMPAQUE"])
                {
                    auxPar.Value = oCPRODNuevo.ICEMPAQUE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@MAYOXKG", OleDbType.VarChar);
                if (!(bool)oCPRODNuevo.isnull["IMAYOXKG"])
                {
                    auxPar.Value = oCPRODNuevo.IMAYOXKG;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@FCAMBIO", OleDbType.Date);
                if (!(bool)oCPRODNuevo.isnull["IFCAMBIO"])
                {
                    auxPar.Value = oCPRODNuevo.IFCAMBIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@INIMAYO", OleDbType.Double);
                if (!(bool)oCPRODNuevo.isnull["IINIMAYO"])
                {
                    auxPar.Value = oCPRODNuevo.IINIMAYO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@PRODUCTOAnt", OleDbType.VarChar);
                if (!(bool)oCPRODAnterior.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCPRODAnterior.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new OleDbParameter("@CLAVESAT", OleDbType.VarChar);
                if(!(bool)oCPRODNuevo.isnull["ICLAVESAT"])
                {
                    auxPar.Value = oCPRODNuevo.ICLAVESAT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                string commandText = @"
  update  PROD
  set

PRODUCTO=@PRODUCTO,

DESC1=@DESC1,

PRECIO1=@PRECIO1,

DESCUENTO1=@DESCUENTO1,

U_EMPAQUE=@U_EMPAQUE,

MONEDA=@MONEDA,

UNIDAD=@UNIDAD,

SERIE=@SERIE,

LOTE=@LOTE,

PROVEEDOR=@PROVEEDOR,

PROVEEDOR2=@PROVEEDOR2,

LINEA=@LINEA,

MARCA=@MARCA,

DESC2=@DESC2,

DESC3=@DESC3,

PRECIO2=@PRECIO2,

PRECIO3=@PRECIO3,

PRECIO4=@PRECIO4,

PRECIO5=@PRECIO5,

PRECIO6=@PRECIO6,

PRECIO7=@PRECIO7,

CODIGO=@CODIGO,

CARGOS_U=@CARGOS_U,

COSTO_REPO=@COSTO_REPO,

IMPRIMIR=@IMPRIMIR,

INVENTARIO=@INVENTARIO,

IMPUESTO=@IMPUESTO,

NEGATIVOS=@NEGATIVOS,

COMODIN=@COMODIN,

LIMITE1=@LIMITE1,

DESCUENTO2=@DESCUENTO2,

LIMITE2=@LIMITE2,

DESCUENTO3=@DESCUENTO3,

KIT=@KIT,

PIEZAS=@PIEZAS,

LPIEZAS=@LPIEZAS,

COMISION=@COMISION,

COMISION_E=@COMISION_E,

PROMOCION=@PROMOCION,

ID=@ID,

ID_FECHA=@ID_FECHA,

ID_HORA=@ID_HORA,

SUSTITUTO=@SUSTITUTO,

CBARRAS=@CBARRAS,

EMPAQUE=@EMPAQUE,

PESO=@PESO,

PRECIO8=@PRECIO8,

PRECIO9=@PRECIO9,

U_CAJA=@U_CAJA,

CUENTA=@CUENTA,

RANKING=@RANKING,

TIPOABC=@TIPOABC,

TRAFICO=@TRAFICO,

UNIDAD2=@UNIDAD2,

U_VENTA2=@U_VENTA2,

VOLUMEN=@VOLUMEN,

ABO=@ABO,

LOC=@LOC,

COSTO_ULTI=@COSTO_ULTI,

COSTOULTUS=@COSTOULTUS,

C_P_I=@C_P_I,

C_R_I=@C_R_I,

C_U_I=@C_U_I,

COSTOREPUS=@COSTOREPUS,

ORDEN=@ORDEN,

FORDEN=@FORDEN,

APARTAKIT=@APARTAKIT,

FMAXDIA=@FMAXDIA,

PZACAJA=@PZACAJA,

CEMPAQUE=@CEMPAQUE,

MAYOXKG=@MAYOXKG,

FCAMBIO=@FCAMBIO,

INIMAYO=@INIMAYO,

CLAVESAT=@CLAVESAT

  where 

PRODUCTO=@PRODUCTOAnt
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
        public CPRODBE seleccionarPROD(CPRODBE oCPROD, OleDbTransaction st)
        {
            CPRODBE retorno = new CPRODBE();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;

                String CmdTxt = @"select * from PROD where
 PRODUCTO=@PRODUCTO  ";


                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                auxPar.Value = oCPROD.IPRODUCTO;
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

                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTO = (string)(dr["PRODUCTO"]);
                    }

                    if (dr["DESC1"] != System.DBNull.Value)
                    {
                        retorno.IDESC1 = (string)(dr["DESC1"]);
                    }

                    if (dr["PRECIO1"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO1 = (double)(dr["PRECIO1"]);
                    }

                    if (dr["DESCUENTO1"] != System.DBNull.Value)
                    {
                        retorno.IDESCUENTO1 = (double)(dr["DESCUENTO1"]);
                    }

                    if (dr["U_EMPAQUE"] != System.DBNull.Value)
                    {
                        retorno.IU_EMPAQUE = (double)(dr["U_EMPAQUE"]);
                    }

                    if (dr["MONEDA"] != System.DBNull.Value)
                    {
                        retorno.IMONEDA = (string)(dr["MONEDA"]);
                    }

                    if (dr["UNIDAD"] != System.DBNull.Value)
                    {
                        retorno.IUNIDAD = (string)(dr["UNIDAD"]);
                    }

                    if (dr["SERIE"] != System.DBNull.Value)
                    {
                        retorno.ISERIE = (string)(dr["SERIE"]);
                    }

                    if (dr["LOTE"] != System.DBNull.Value)
                    {
                        retorno.ILOTE = (string)(dr["LOTE"]);
                    }

                    if (dr["PROVEEDOR"] != System.DBNull.Value)
                    {
                        retorno.IPROVEEDOR = (string)(dr["PROVEEDOR"]);
                    }

                    if (dr["PROVEEDOR2"] != System.DBNull.Value)
                    {
                        retorno.IPROVEEDOR2 = (string)(dr["PROVEEDOR2"]);
                    }

                    if (dr["LINEA"] != System.DBNull.Value)
                    {
                        retorno.ILINEA = (string)(dr["LINEA"]);
                    }

                    if (dr["MARCA"] != System.DBNull.Value)
                    {
                        retorno.IMARCA = (string)(dr["MARCA"]);
                    }

                    if (dr["DESC2"] != System.DBNull.Value)
                    {
                        retorno.IDESC2 = (string)(dr["DESC2"]);
                    }

                    if (dr["DESC3"] != System.DBNull.Value)
                    {
                        retorno.IDESC3 = (string)(dr["DESC3"]);
                    }

                    if (dr["PRECIO2"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO2 = (double)(dr["PRECIO2"]);
                    }

                    if (dr["PRECIO3"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO3 = (double)(dr["PRECIO3"]);
                    }

                    if (dr["PRECIO4"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO4 = (double)(dr["PRECIO4"]);
                    }

                    if (dr["PRECIO5"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO5 = (double)(dr["PRECIO5"]);
                    }

                    if (dr["PRECIO6"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO6 = (double)(dr["PRECIO6"]);
                    }

                    if (dr["PRECIO7"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO7 = (double)(dr["PRECIO7"]);
                    }

                    if (dr["CODIGO"] != System.DBNull.Value)
                    {
                        retorno.ICODIGO = (string)(dr["CODIGO"]);
                    }

                    if (dr["CARGOS_U"] != System.DBNull.Value)
                    {
                        retorno.ICARGOS_U = (double)(dr["CARGOS_U"]);
                    }

                    if (dr["COSTO_REPO"] != System.DBNull.Value)
                    {
                        retorno.ICOSTO_REPO = (double)(dr["COSTO_REPO"]);
                    }

                    if (dr["IMPRIMIR"] != System.DBNull.Value)
                    {
                        retorno.IIMPRIMIR = (string)(dr["IMPRIMIR"]);
                    }

                    if (dr["INVENTARIO"] != System.DBNull.Value)
                    {
                        retorno.IINVENTARIO = (string)(dr["INVENTARIO"]);
                    }

                    if (dr["IMPUESTO"] != System.DBNull.Value)
                    {
                        retorno.IIMPUESTO = (double)(dr["IMPUESTO"]);
                    }

                    if (dr["NEGATIVOS"] != System.DBNull.Value)
                    {
                        retorno.INEGATIVOS = (string)(dr["NEGATIVOS"]);
                    }

                    if (dr["COMODIN"] != System.DBNull.Value)
                    {
                        retorno.ICOMODIN = (string)(dr["COMODIN"]);
                    }

                    if (dr["LIMITE1"] != System.DBNull.Value)
                    {
                        retorno.ILIMITE1 = (double)(dr["LIMITE1"]);
                    }

                    if (dr["DESCUENTO2"] != System.DBNull.Value)
                    {
                        retorno.IDESCUENTO2 = (double)(dr["DESCUENTO2"]);
                    }

                    if (dr["LIMITE2"] != System.DBNull.Value)
                    {
                        retorno.ILIMITE2 = (double)(dr["LIMITE2"]);
                    }

                    if (dr["DESCUENTO3"] != System.DBNull.Value)
                    {
                        retorno.IDESCUENTO3 = (double)(dr["DESCUENTO3"]);
                    }

                    if (dr["KIT"] != System.DBNull.Value)
                    {
                        retorno.IKIT = (string)(dr["KIT"]);
                    }

                    if (dr["PIEZAS"] != System.DBNull.Value)
                    {
                        retorno.IPIEZAS = (double)(dr["PIEZAS"]);
                    }

                    if (dr["LPIEZAS"] != System.DBNull.Value)
                    {
                        retorno.ILPIEZAS = (string)(dr["LPIEZAS"]);
                    }

                    if (dr["COMISION"] != System.DBNull.Value)
                    {
                        retorno.ICOMISION = (double)(dr["COMISION"]);
                    }

                    if (dr["COMISION_E"] != System.DBNull.Value)
                    {
                        retorno.ICOMISION_E = (double)(dr["COMISION_E"]);
                    }

                    if (dr["PROMOCION"] != System.DBNull.Value)
                    {
                        retorno.IPROMOCION = (string)(dr["PROMOCION"]);
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

                    if (dr["SUSTITUTO"] != System.DBNull.Value)
                    {
                        retorno.ISUSTITUTO = (string)(dr["SUSTITUTO"]);
                    }

                    if (dr["CBARRAS"] != System.DBNull.Value)
                    {
                        retorno.ICBARRAS = (string)(dr["CBARRAS"]);
                    }

                    if (dr["EMPAQUE"] != System.DBNull.Value)
                    {
                        retorno.IEMPAQUE = (double)(dr["EMPAQUE"]);
                    }

                    if (dr["PESO"] != System.DBNull.Value)
                    {
                        retorno.IPESO = (double)(dr["PESO"]);
                    }

                    if (dr["PRECIO8"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO8 = (double)(dr["PRECIO8"]);
                    }

                    if (dr["PRECIO9"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO9 = (double)(dr["PRECIO9"]);
                    }

                    if (dr["U_CAJA"] != System.DBNull.Value)
                    {
                        retorno.IU_CAJA = (double)(dr["U_CAJA"]);
                    }

                    if (dr["CUENTA"] != System.DBNull.Value)
                    {
                        retorno.ICUENTA = (string)(dr["CUENTA"]);
                    }

                    if (dr["RANKING"] != System.DBNull.Value)
                    {
                        retorno.IRANKING = (double)(dr["RANKING"]);
                    }

                    if (dr["TIPOABC"] != System.DBNull.Value)
                    {
                        retorno.ITIPOABC = (string)(dr["TIPOABC"]);
                    }

                    if (dr["TRAFICO"] != System.DBNull.Value)
                    {
                        retorno.ITRAFICO = (string)(dr["TRAFICO"]);
                    }

                    if (dr["UNIDAD2"] != System.DBNull.Value)
                    {
                        retorno.IUNIDAD2 = (string)(dr["UNIDAD2"]);
                    }

                    if (dr["U_VENTA2"] != System.DBNull.Value)
                    {
                        retorno.IU_VENTA2 = (double)(dr["U_VENTA2"]);
                    }

                    if (dr["VOLUMEN"] != System.DBNull.Value)
                    {
                        retorno.IVOLUMEN = (double)(dr["VOLUMEN"]);
                    }

                    if (dr["ABO"] != System.DBNull.Value)
                    {
                        retorno.IABO = (double)(dr["ABO"]);
                    }

                    if (dr["LOC"] != System.DBNull.Value)
                    {
                        retorno.ILOC = (string)(dr["LOC"]);
                    }

                    if (dr["COSTO_ULTI"] != System.DBNull.Value)
                    {
                        retorno.ICOSTO_ULTI = (double)(dr["COSTO_ULTI"]);
                    }

                    if (dr["COSTOULTUS"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOULTUS = (double)(dr["COSTOULTUS"]);
                    }

                    if (dr["C_P_I"] != System.DBNull.Value)
                    {
                        retorno.IC_P_I = (double)(dr["C_P_I"]);
                    }

                    if (dr["C_R_I"] != System.DBNull.Value)
                    {
                        retorno.IC_R_I = (double)(dr["C_R_I"]);
                    }

                    if (dr["C_U_I"] != System.DBNull.Value)
                    {
                        retorno.IC_U_I = (double)(dr["C_U_I"]);
                    }

                    if (dr["COSTOREPUS"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOREPUS = (double)(dr["COSTOREPUS"]);
                    }

                    if (dr["ORDEN"] != System.DBNull.Value)
                    {
                        retorno.IORDEN = (double)(dr["ORDEN"]);
                    }

                    if (dr["FORDEN"] != System.DBNull.Value)
                    {
                        retorno.IFORDEN = (DateTime)(dr["FORDEN"]);
                    }

                    if (dr["APARTAKIT"] != System.DBNull.Value)
                    {
                        retorno.IAPARTAKIT = (double)(dr["APARTAKIT"]);
                    }

                    if (dr["FMAXDIA"] != System.DBNull.Value)
                    {
                        retorno.IFMAXDIA = (DateTime)(dr["FMAXDIA"]);
                    }

                    if (dr["PZACAJA"] != System.DBNull.Value)
                    {
                        retorno.IPZACAJA = (double)(dr["PZACAJA"]);
                    }

                    if (dr["CEMPAQUE"] != System.DBNull.Value)
                    {
                        retorno.ICEMPAQUE = (string)(dr["CEMPAQUE"]);
                    }

                    if (dr["MAYOXKG"] != System.DBNull.Value)
                    {
                        retorno.IMAYOXKG = (string)(dr["MAYOXKG"]);
                    }

                    if (dr["FCAMBIO"] != System.DBNull.Value)
                    {
                        retorno.IFCAMBIO = (DateTime)(dr["FCAMBIO"]);
                    }

                    if (dr["INIMAYO"] != System.DBNull.Value)
                    {
                        retorno.IINIMAYO = (double)(dr["INIMAYO"]);
                    }

                    if (dr["ULTIMAVENTA"] != System.DBNull.Value)
                    {
                        retorno.IULTIMAVENTA = (DateTime)(dr["ULTIMAVENTA"]);
                    }

                    if (dr["ULTIMACOMPRA"] != System.DBNull.Value)
                    {
                        retorno.IULTIMACOMPRA = (DateTime)(dr["ULTIMACOMPRA"]);
                    }
                    if(dr["CLAVESAT"] != System.DBNull.Value)
                    {
                        retorno.ICLAVESAT = dr["CLAVESAT"].ToString();
                    }


                    if (dr["IMPCOM"] != System.DBNull.Value)
                    {
                        retorno.IIMPCOM = (string)(dr["IMPCOM"]);
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
        public DataSet enlistarPROD()
        {

            DataSet retorno;
            try
            {
                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PROD_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoPROD()
        {
            DataSet retorno;
            try
            {

                retorno = OleDbHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PROD_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExistePROD(CPRODBE oCPROD, OleDbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                auxPar.Value = oCPROD.IPRODUCTO;
                parts.Add(auxPar);

                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from PROD where

  PRODUCTO=@PRODUCTO  
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




        public CPRODBE AgregarPROD(CPRODBE oCPROD, OleDbTransaction st)
        {
            try
            {
                int iRes = ExistePROD(oCPROD, st);
                if (iRes == 1)
                {
                    this.IComentario = "El PROD ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return null;// AgregarPRODD(oCPROD, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarPROD(CPRODBE oCPROD, OleDbTransaction st)
        {
            try
            {
                int iRes = ExistePROD(oCPROD, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PROD no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarPRODD(oCPROD, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarPROD(CPRODBE oCPRODNuevo, CPRODBE oCPRODAnterior, OleDbTransaction st)
        {
            try
            {
                int iRes = ExistePROD(oCPRODAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PROD no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarPRODD(oCPRODNuevo, oCPRODAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CPRODD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
