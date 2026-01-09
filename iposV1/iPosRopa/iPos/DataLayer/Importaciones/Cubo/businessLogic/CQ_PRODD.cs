
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



    public class CQ_PRODD
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


        public bool AgregarQ_PRODD(CQ_PRODBE oCQ_PROD, string strFileName, OleDbTransaction st, string strOleDbConn)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;



                auxPar = new OleDbParameter("@PRODUCTO", OleDbType.VarChar);
                if (!(bool)oCQ_PROD.isnull["IPRODUCTO"])
                {
                    auxPar.Value = oCQ_PROD.IPRODUCTO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESC1", OleDbType.VarChar);
                if (!(bool)oCQ_PROD.isnull["IDESC1"])
                {
                    auxPar.Value = oCQ_PROD.IDESC1;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IPRECIO"])
                {
                    auxPar.Value = oCQ_PROD.IPRECIO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO1", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IPRECIO1"])
                {
                    auxPar.Value = oCQ_PROD.IPRECIO1;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@U_EMPAQUE", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IU_EMPAQUE"])
                {
                    auxPar.Value = oCQ_PROD.IU_EMPAQUE;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MONEDA", OleDbType.VarChar);
                if (!(bool)oCQ_PROD.isnull["IMONEDA"])
                {
                    auxPar.Value = oCQ_PROD.IMONEDA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@SERIE", OleDbType.VarChar);
                if (!(bool)oCQ_PROD.isnull["ISERIE"])
                {
                    auxPar.Value = oCQ_PROD.ISERIE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LOTE", OleDbType.VarChar);
                if (!(bool)oCQ_PROD.isnull["ILOTE"])
                {
                    auxPar.Value = oCQ_PROD.ILOTE;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PROVEEDOR", OleDbType.VarChar);
                if (!(bool)oCQ_PROD.isnull["IPROVEEDOR"])
                {
                    auxPar.Value = oCQ_PROD.IPROVEEDOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PROVEEDOR2", OleDbType.VarChar);
                if (!(bool)oCQ_PROD.isnull["IPROVEEDOR2"])
                {
                    auxPar.Value = oCQ_PROD.IPROVEEDOR2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LINEA", OleDbType.VarChar);
                if (!(bool)oCQ_PROD.isnull["ILINEA"])
                {
                    auxPar.Value = oCQ_PROD.ILINEA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MARCA", OleDbType.VarChar);
                if (!(bool)oCQ_PROD.isnull["IMARCA"])
                {
                    auxPar.Value = oCQ_PROD.IMARCA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESC2", OleDbType.VarChar);
                if (!(bool)oCQ_PROD.isnull["IDESC2"])
                {
                    auxPar.Value = oCQ_PROD.IDESC2;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESC3", OleDbType.VarChar);
                if (!(bool)oCQ_PROD.isnull["IDESC3"])
                {
                    auxPar.Value = oCQ_PROD.IDESC3;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO2", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IPRECIO2"])
                {
                    auxPar.Value = oCQ_PROD.IPRECIO2;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO3", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IPRECIO3"])
                {
                    auxPar.Value = oCQ_PROD.IPRECIO3;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO4", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IPRECIO4"])
                {
                    auxPar.Value = oCQ_PROD.IPRECIO4;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO5", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IPRECIO5"])
                {
                    auxPar.Value = oCQ_PROD.IPRECIO5;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO6", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IPRECIO6"])
                {
                    auxPar.Value = oCQ_PROD.IPRECIO6;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO7", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IPRECIO7"])
                {
                    auxPar.Value = oCQ_PROD.IPRECIO7;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CODIGO", OleDbType.VarChar);
                if (!(bool)oCQ_PROD.isnull["ICODIGO"])
                {
                    auxPar.Value = oCQ_PROD.ICODIGO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CODCAJA", OleDbType.VarChar);
                if (!(bool)oCQ_PROD.isnull["ICODCAJA"])
                {
                    auxPar.Value = oCQ_PROD.ICODCAJA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CARGOS_U", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["ICARGOS_U"])
                {
                    auxPar.Value = oCQ_PROD.ICARGOS_U;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COSTO_REPO", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["ICOSTO_REPO"])
                {
                    auxPar.Value = oCQ_PROD.ICOSTO_REPO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPRIMIR", OleDbType.VarChar);
                if (!(bool)oCQ_PROD.isnull["IIMPRIMIR"])
                {
                    auxPar.Value = oCQ_PROD.IIMPRIMIR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@INVENTARIO", OleDbType.VarChar);
                if (!(bool)oCQ_PROD.isnull["IINVENTARIO"])
                {
                    auxPar.Value = oCQ_PROD.IINVENTARIO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IMPUESTO", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IIMPUESTO"])
                {
                    auxPar.Value = oCQ_PROD.IIMPUESTO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@NEGATIVOS", OleDbType.VarChar);
                if (!(bool)oCQ_PROD.isnull["INEGATIVOS"])
                {
                    auxPar.Value = oCQ_PROD.INEGATIVOS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@COMODIN", OleDbType.VarChar);
                if (!(bool)oCQ_PROD.isnull["ICOMODIN"])
                {
                    auxPar.Value = oCQ_PROD.ICOMODIN;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@KIT", OleDbType.VarChar);
                if (!(bool)oCQ_PROD.isnull["IKIT"])
                {
                    auxPar.Value = oCQ_PROD.IKIT;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PIEZAS", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IPIEZAS"])
                {
                    auxPar.Value = oCQ_PROD.IPIEZAS;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@LPIEZAS", OleDbType.VarChar);
                if (!(bool)oCQ_PROD.isnull["ILPIEZAS"])
                {
                    auxPar.Value = oCQ_PROD.ILPIEZAS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID", OleDbType.VarChar);
                if (!(bool)oCQ_PROD.isnull["IID"])
                {
                    auxPar.Value = oCQ_PROD.IID;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_FECHA", OleDbType.Date);
                if (!(bool)oCQ_PROD.isnull["IID_FECHA"])
                {
                    auxPar.Value = oCQ_PROD.IID_FECHA;
                }
                else
                {
                    auxPar.Value = DateTime.Today;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ID_HORA", OleDbType.VarChar);
                if (!(bool)oCQ_PROD.isnull["IID_HORA"])
                {
                    auxPar.Value = oCQ_PROD.IID_HORA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@BOTCAJA", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IBOTCAJA"])
                {
                    auxPar.Value = oCQ_PROD.IBOTCAJA;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IEPS", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IIEPS"])
                {
                    auxPar.Value = oCQ_PROD.IIEPS;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PLAZO", OleDbType.VarChar);
                if (!(bool)oCQ_PROD.isnull["IPLAZO"])
                {
                    auxPar.Value = oCQ_PROD.IPLAZO;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@IVA", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IIVA"])
                {
                    auxPar.Value = oCQ_PROD.IIVA;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@OFERTA", OleDbType.VarChar);
                if (!(bool)oCQ_PROD.isnull["IOFERTA"])
                {
                    auxPar.Value = oCQ_PROD.IOFERTA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PREC_LIST", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IPREC_LIST"])
                {
                    auxPar.Value = oCQ_PROD.IPREC_LIST;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@FLETE", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IFLETE"])
                {
                    auxPar.Value = oCQ_PROD.IFLETE;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MARGEN", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IMARGEN"])
                {
                    auxPar.Value = oCQ_PROD.IMARGEN;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MPRECIO2", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IMPRECIO2"])
                {
                    auxPar.Value = oCQ_PROD.IMPRECIO2;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MPRECIO3", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IMPRECIO3"])
                {
                    auxPar.Value = oCQ_PROD.IMPRECIO3;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MPRECIO4", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IMPRECIO4"])
                {
                    auxPar.Value = oCQ_PROD.IMPRECIO4;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MPRECIO5", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IMPRECIO5"])
                {
                    auxPar.Value = oCQ_PROD.IMPRECIO5;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MPRECIO6", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IMPRECIO6"])
                {
                    auxPar.Value = oCQ_PROD.IMPRECIO6;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@MPRECIO7", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IMPRECIO7"])
                {
                    auxPar.Value = oCQ_PROD.IMPRECIO7;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CPRECIO2", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["ICPRECIO2"])
                {
                    auxPar.Value = oCQ_PROD.ICPRECIO2;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CPRECIO3", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["ICPRECIO3"])
                {
                    auxPar.Value = oCQ_PROD.ICPRECIO3;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CPRECIO4", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["ICPRECIO4"])
                {
                    auxPar.Value = oCQ_PROD.ICPRECIO4;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CPRECIO5", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["ICPRECIO5"])
                {
                    auxPar.Value = oCQ_PROD.ICPRECIO5;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CPRECIO6", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["ICPRECIO6"])
                {
                    auxPar.Value = oCQ_PROD.ICPRECIO6;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CPRECIO7", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["ICPRECIO7"])
                {
                    auxPar.Value = oCQ_PROD.ICPRECIO7;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CCOSTO_REP", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["ICCOSTO_REP"])
                {
                    auxPar.Value = oCQ_PROD.ICCOSTO_REP;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@GPRECIO2", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IGPRECIO2"])
                {
                    auxPar.Value = oCQ_PROD.IGPRECIO2;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@GPRECIO3", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IGPRECIO3"])
                {
                    auxPar.Value = oCQ_PROD.IGPRECIO3;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@GPRECIO4", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IGPRECIO4"])
                {
                    auxPar.Value = oCQ_PROD.IGPRECIO4;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@GPRECIO5", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IGPRECIO5"])
                {
                    auxPar.Value = oCQ_PROD.IGPRECIO5;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@GPRECIO6", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IGPRECIO6"])
                {
                    auxPar.Value = oCQ_PROD.IGPRECIO6;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@GPRECIO7", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IGPRECIO7"])
                {
                    auxPar.Value = oCQ_PROD.IGPRECIO7;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@GCOSTO_REP", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IGCOSTO_REP"])
                {
                    auxPar.Value = oCQ_PROD.IGCOSTO_REP;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DPRECIO2", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IDPRECIO2"])
                {
                    auxPar.Value = oCQ_PROD.IDPRECIO2;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DPRECIO3", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IDPRECIO3"])
                {
                    auxPar.Value = oCQ_PROD.IDPRECIO3;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DPRECIO4", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IDPRECIO4"])
                {
                    auxPar.Value = oCQ_PROD.IDPRECIO4;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DPRECIO5", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IDPRECIO5"])
                {
                    auxPar.Value = oCQ_PROD.IDPRECIO5;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DPRECIO7", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IDPRECIO7"])
                {
                    auxPar.Value = oCQ_PROD.IDPRECIO7;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DCOSTO_REP", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IDCOSTO_REP"])
                {
                    auxPar.Value = oCQ_PROD.IDCOSTO_REP;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TPRECIO2", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["ITPRECIO2"])
                {
                    auxPar.Value = oCQ_PROD.ITPRECIO2;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TPRECIO3", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["ITPRECIO3"])
                {
                    auxPar.Value = oCQ_PROD.ITPRECIO3;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TPRECIO4", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["ITPRECIO4"])
                {
                    auxPar.Value = oCQ_PROD.ITPRECIO4;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TPRECIO5", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["ITPRECIO5"])
                {
                    auxPar.Value = oCQ_PROD.ITPRECIO5;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TPRECIO6", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["ITPRECIO6"])
                {
                    auxPar.Value = oCQ_PROD.ITPRECIO6;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TPRECIO7", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["ITPRECIO7"])
                {
                    auxPar.Value = oCQ_PROD.ITPRECIO7;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@TCOSTO_REP", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["ITCOSTO_REP"])
                {
                    auxPar.Value = oCQ_PROD.ITCOSTO_REP;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@APRECIO2", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IAPRECIO2"])
                {
                    auxPar.Value = oCQ_PROD.IAPRECIO2;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@APRECIO3", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IAPRECIO3"])
                {
                    auxPar.Value = oCQ_PROD.IAPRECIO3;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@APRECIO4", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IAPRECIO4"])
                {
                    auxPar.Value = oCQ_PROD.IAPRECIO4;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@APRECIO5", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IAPRECIO5"])
                {
                    auxPar.Value = oCQ_PROD.IAPRECIO5;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@APRECIO6", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IAPRECIO6"])
                {
                    auxPar.Value = oCQ_PROD.IAPRECIO6;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@APRECIO7", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IAPRECIO7"])
                {
                    auxPar.Value = oCQ_PROD.IAPRECIO7;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EPRECIO2", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IEPRECIO2"])
                {
                    auxPar.Value = oCQ_PROD.IEPRECIO2;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EPRECIO3", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IEPRECIO3"])
                {
                    auxPar.Value = oCQ_PROD.IEPRECIO3;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EPRECIO4", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IEPRECIO4"])
                {
                    auxPar.Value = oCQ_PROD.IEPRECIO4;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EPRECIO5", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IEPRECIO5"])
                {
                    auxPar.Value = oCQ_PROD.IEPRECIO5;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EPRECIO6", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IEPRECIO6"])
                {
                    auxPar.Value = oCQ_PROD.IEPRECIO6;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@EPRECIO7", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IEPRECIO7"])
                {
                    auxPar.Value = oCQ_PROD.IEPRECIO7;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ACOSOT_REP", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IACOSOT_REP"])
                {
                    auxPar.Value = oCQ_PROD.IACOSOT_REP;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@P_UTL1", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IP_UTL1"])
                {
                    auxPar.Value = oCQ_PROD.IP_UTL1;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@P_UTL2", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IP_UTL2"])
                {
                    auxPar.Value = oCQ_PROD.IP_UTL2;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@P_UTL3", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IP_UTL3"])
                {
                    auxPar.Value = oCQ_PROD.IP_UTL3;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@P_UTL4", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IP_UTL4"])
                {
                    auxPar.Value = oCQ_PROD.IP_UTL4;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@C_UTL1", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IC_UTL1"])
                {
                    auxPar.Value = oCQ_PROD.IC_UTL1;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@C_UTL2", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IC_UTL2"])
                {
                    auxPar.Value = oCQ_PROD.IC_UTL2;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@C_UTL3", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IC_UTL3"])
                {
                    auxPar.Value = oCQ_PROD.IC_UTL3;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@C_UTL4", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IC_UTL4"])
                {
                    auxPar.Value = oCQ_PROD.IC_UTL4;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@C_ULT5", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IC_ULT5"])
                {
                    auxPar.Value = oCQ_PROD.IC_ULT5;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CONTENIDO", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["ICONTENIDO"])
                {
                    auxPar.Value = oCQ_PROD.ICONTENIDO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO8", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IPRECIO8"])
                {
                    auxPar.Value = oCQ_PROD.IPRECIO8;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@PRECIO9", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IPRECIO9"])
                {
                    auxPar.Value = oCQ_PROD.IPRECIO9;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@U_CAJA", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IU_CAJA"])
                {
                    auxPar.Value = oCQ_PROD.IU_CAJA;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLAVE_CONT", OleDbType.VarChar);
                if (!(bool)oCQ_PROD.isnull["ICLAVE_CONT"])
                {
                    auxPar.Value = oCQ_PROD.ICLAVE_CONT;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CLASIFICA", OleDbType.VarChar);
                if (!(bool)oCQ_PROD.isnull["ICLASIFICA"])
                {
                    auxPar.Value = oCQ_PROD.ICLASIFICA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CGO_EXC", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["ICGO_EXC"])
                {
                    auxPar.Value = oCQ_PROD.ICGO_EXC;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@CUENTA", OleDbType.VarChar);
                if (!(bool)oCQ_PROD.isnull["ICUENTA"])
                {
                    auxPar.Value = oCQ_PROD.ICUENTA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@OLLA", OleDbType.VarChar);
                if (!(bool)oCQ_PROD.isnull["IOLLA"])
                {
                    auxPar.Value = oCQ_PROD.IOLLA;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@P_COMO1", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IP_COMO1"])
                {
                    auxPar.Value = oCQ_PROD.IP_COMO1;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@P_COMO2", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IP_COMO2"])
                {
                    auxPar.Value = oCQ_PROD.IP_COMO2;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@C_COMO1", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IC_COMO1"])
                {
                    auxPar.Value = oCQ_PROD.IC_COMO1;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@C_COMO2", OleDbType.Double);
                if (!(bool)oCQ_PROD.isnull["IC_COMO2"])
                {
                    auxPar.Value = oCQ_PROD.IC_COMO2;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@DESGKIT", OleDbType.Boolean);
                if (!(bool)oCQ_PROD.isnull["IDESGKIT"])
                {
                    auxPar.Value = oCQ_PROD.IDESGKIT;
                }
                else
                {
                    auxPar.Value = false;
                }
                parts.Add(auxPar);


                auxPar = new OleDbParameter("@ESTRATEGIC", OleDbType.VarChar);
                if (!(bool)oCQ_PROD.isnull["IESTRATEGIC"])
                {
                    auxPar.Value = oCQ_PROD.IESTRATEGIC;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO " + strFileName + @"
      (
    
PRODUCTO,

DESC1,

PRECIO,

PRECIO1,

U_EMPAQUE,

MONEDA,

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

CODCAJA,

CARGOS_U,

COSTO_REPO,

IMPRIMIR,

INVENTARIO,

IMPUESTO,

NEGATIVOS,

COMODIN,

KIT,

PIEZAS,

LPIEZAS,

ID,

ID_FECHA,

ID_HORA,

BOTCAJA,

IEPS,

PLAZO,

IVA,

OFERTA,

PREC_LIST,

FLETE,

MARGEN,

MPRECIO2,

MPRECIO3,

MPRECIO4,

MPRECIO5,

MPRECIO6,

MPRECIO7,

CPRECIO2,

CPRECIO3,

CPRECIO4,

CPRECIO5,

CPRECIO6,

CPRECIO7,

CCOSTO_REP,

GPRECIO2,

GPRECIO3,

GPRECIO4,

GPRECIO5,

GPRECIO6,

GPRECIO7,

GCOSTO_REP,

DPRECIO2,

DPRECIO3,

DPRECIO4,

DPRECIO5,

DPRECIO7,

DCOSTO_REP,

TPRECIO2,

TPRECIO3,

TPRECIO4,

TPRECIO5,

TPRECIO6,

TPRECIO7,

TCOSTO_REP,

APRECIO2,

APRECIO3,

APRECIO4,

APRECIO5,

APRECIO6,

APRECIO7,

EPRECIO2,

EPRECIO3,

EPRECIO4,

EPRECIO5,

EPRECIO6,

EPRECIO7,

ACOSOT_REP,

P_UTL1,

P_UTL2,

P_UTL3,

P_UTL4,

C_UTL1,

C_UTL2,

C_UTL3,

C_UTL4,

C_ULT5,

CONTENIDO,

PRECIO8,

PRECIO9,

U_CAJA,

CLAVE_CONT,

CLASIFICA,

CGO_EXC,

CUENTA,

OLLA,

P_COMO1,

P_COMO2,

C_COMO1,

C_COMO2,

DESGKIT,

ESTRATEGIC
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

        



        public CQ_PRODD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
