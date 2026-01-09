using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Xml;
using System.IO;
using iPosData;
using iPosBusinessEntity;

// agregar Referencia
using System.Runtime.InteropServices;

using Microsoft.Reporting.WinForms;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Threading;

using System.Security;
using System.Security.Permissions;

using FirebirdSql.Data.FirebirdClient;
using System.Drawing.Imaging;
using iPosReporting.VirtualXml.Model;
using iPosReporting.VirtualXml;
using LoginInfo;
using iPos;
using Newtonsoft.Json;
using System.Xml.Serialization;
using iPosReporting.VirtualXml.Utils;

namespace iPosReporting
{


    public partial class WFFacturaElectronica : Form
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public extern static IntPtr LoadLibrary(string librayName);

        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        public const string FileLocalLocation_FE_XML = "\\sampdata\\facturaelectronica\\XML";
        public const string FileLocalLocation_FE_XML_Molde_File = "\\sampdata\\facturaelectronica\\XML\\molde\\cfdi_sintimbrar.xml";
        public const string FileLocalLocation_FE_XML_SinTimbrar = "\\sampdata\\facturaelectronica\\XML\\SinTimbrar";
        public const string FileLocalLocation_FE_XML_Timbrados = "\\sampdata\\facturaelectronica\\XML\\Timbrados";
        public const string FileLocalLocation_FE_PDF = "\\sampdata\\facturaelectronica\\PDF";
        public const string FileLocalLocation_FE_IMG = "\\sampdata\\facturaelectronica\\IMG";
        public const string FileLocalLocation_FE_XML_Cancelaciones = "\\sampdata\\facturaelectronica\\XML\\Cancelaciones";
        public const string FileLocalLocation_FE_PDF_Cancelaciones = "\\sampdata\\facturaelectronica\\PDF\\Cancelaciones";
        public const string FileLocalLocation_FE_XML_ConceptoCompl_File = "\\sampdata\\facturaelectronica\\XML\\molde\\terceros.xml";


        public const string FileLocalLocation_DE_XML = "\\sampdata\\devolucionelectronica\\XML";
        public const string FileLocalLocation_DE_XML_Molde_File = "\\sampdata\\devolucionelectronica\\XML\\molde\\cfdi_sintimbrar.xml";
        public const string FileLocalLocation_DE_XML_SinTimbrar = "\\sampdata\\devolucionelectronica\\XML\\SinTimbrar";
        public const string FileLocalLocation_DE_XML_Timbrados = "\\sampdata\\devolucionelectronica\\XML\\Timbrados";
        public const string FileLocalLocation_DE_PDF = "\\sampdata\\devolucionelectronica\\PDF";
        public const string FileLocalLocation_DE_IMG = "\\sampdata\\devolucionelectronica\\IMG";
        public const string FileLocalLocation_DE_XML_Cancelaciones = "\\sampdata\\devolucionelectronica\\XML\\Cancelaciones";



        public const string FileLocalLocation_AE_XML = "\\sampdata\\abonoselectronicos\\XML";
        public const string FileLocalLocation_AE_XML_Molde_File = "\\sampdata\\abonoselectronicos\\XML\\molde\\cfdi_sintimbrar.xml";
        public const string FileLocalLocation_AE_XML_SinTimbrar = "\\sampdata\\abonoselectronicos\\XML\\SinTimbrar";
        public const string FileLocalLocation_AE_XML_Timbrados = "\\sampdata\\abonoselectronicos\\XML\\Timbrados";
        public const string FileLocalLocation_AE_PDF = "\\sampdata\\abonoselectronicos\\PDF";
        public const string FileLocalLocation_AE_IMG = "\\sampdata\\abonoselectronicos\\IMG";
        public const string FileLocalLocation_AE_XML_Cancelaciones = "\\sampdata\\abonoselectronicos\\XML\\Cancelaciones";
        public const string FileLocalLocation_AE_PDF_Cancelaciones = "\\sampdata\\abonoselectronicos\\PDF\\Cancelaciones";


        public const string FileLocalLocation_CT_XML = "\\sampdata\\comprobantetraslado\\XML";
        public const string FileLocalLocation_CT_XML_Molde_File = "\\sampdata\\comprobantetraslado\\XML\\molde\\cfdi_sintimbrar.xml";
        public const string FileLocalLocation_CT_XML_SinTimbrar = "\\sampdata\\comprobantetraslado\\XML\\SinTimbrar";
        public const string FileLocalLocation_CT_XML_Timbrados = "\\sampdata\\comprobantetraslado\\XML\\Timbrados";
        public const string FileLocalLocation_CT_PDF = "\\sampdata\\comprobantetraslado\\PDF";
        public const string FileLocalLocation_CT_IMG = "\\sampdata\\comprobantetraslado\\IMG";
        public const string FileLocalLocation_CT_XML_Cancelaciones = "\\sampdata\\abonoselectronicos\\XML\\Cancelaciones";
        public const string FileLocalLocation_CT_PDF_Cancelaciones = "\\sampdata\\abonoselectronicos\\PDF\\Cancelaciones";


        [DllImport("CiberPAC.dll", CharSet = CharSet.Unicode, EntryPoint = "CiberPAC_SignXmlW")]
        static extern int CiberPAC_SignXmlW(string szXmlFile, string szCertFile,
           string szKeyFile, string szKeyPass, string szXmlOut, string szUser, string szKey, long flag);

        [DllImport("CiberPAC.dll", CharSet = CharSet.Unicode, EntryPoint = "CiberPAC_GetValueW")]
        static extern String CiberPAC_GetValueW(int p, int flag);

        [DllImport("CiberPAC.dll", EntryPoint = "CiberPAC_Free")]
        static extern void CiberPAC_Free(int p);

        [DllImport("CiberPAC.dll", EntryPoint = "CiberPAC_GetNoError")]
        static extern int CiberPAC_GetNoError(int p);


        [DllImport("CiberPAC.dll", CharSet = CharSet.Unicode, EntryPoint = "CancelaUUIDW")]
        static extern int CancelaUUID(string szUser, string szEmisor, string szCertFile, string szKey, string szKeyPass, string szUuid, string szXmlFile);



        //[DllImport("CiberSAT4.dll", CharSet = CharSet.Unicode, EntryPoint = "CiberSAT_CancelaUUIDW")]
        //static extern int CancelaUUID(String szUser, String szEmisor, String szCert, String szKey, String szPwd, String szUuid, String szOut);


        //[DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_CancelaUUID")]
        //static extern int CancelaUUID(String szUser, String szEmisor, String szCert, String szKey, String szPwd, String szUuid, String szOut);



        CDOCTOBE m_Docto;
        CPARAMETROBE m_empresa;
        bool bShowIva0, bShowIva16;
        bool bDeslosaKits = false;
        CDOCTOPAGOBE m_doctoPago;
        string m_nombreFormaPago;
        public bool m_bForzarImpresionTicket = false;

        int m_mode;
        

        public const int _MODE_DIALOGO_FACTURA_ELECTRONICA_TIMBRAR = 0;
        public const int _MODE_DIALOGO_FACTURA_ELECTRONICA_GENERARPDF = 1;
        public const int _MODE_DIALOGO_FACTURA_ELECTRONICA_CANCELAR = 2;

        public const int _MODE_DIALOGO_FACTURA_ELECTRONICA_IMPRIMIRTICKET = 3;

        public const int _MODE_DIALOGO_FACTURA_ELECTRONICA_COMPROBTRASL = 4;
        public const int _MODE_DIALOGO_FACTURA_ELECTRONICA_GENPDF_COMPROBTRASL = 5;
        public const int _MODE_DIALOGO_COMPROB_TRASL_IMPRIMIRTICKET = 6;

        public bool m_facturacionRealizada;

        public bool m_facturacionCancelada = false;


        public bool m_pagotemporal = false;

        public bool m_usaDatosDeEntregaCuandoExista = true;
        public string m_PREGUNTARDATOSENTREGA = "N";

        //string m_returnUUID;
        //string m_returnFechaTimbrado;
        //string m_returnCertSAT;

        FbTransaction m_fTrans = null;

        CDOCTOBE m_DoctoRef;

        CEMPRESASBE m_compania = null;

        public bool m_silentMode = false;

        public string m_strFileLog = "";


        public long m_vendedorId = -1;

        public string m_formapagosattemporal = "";

        public string m_iComentario = "";

        public bool m_bSeEstaCancelandoVenta = false;

        public bool m_bUsarLibreriaVirtualXML = false;

        public bool m_generarCartaPorte = false;
        public string m_CartaPorteIdccp = null;

        //Inicializar VirtualXmlHelper
        VirtualXmlHelper virtualXmlHelper = new VirtualXmlHelper();

        public int m_currentFolioSat = 0;
        public string m_currentSerieSat = "";

        public WFFacturaElectronica()
        {
            InitializeComponent();
            bShowIva0 = bShowIva16 = false;
            m_doctoPago = null;
            m_nombreFormaPago = "99";//"N / A"/*"No Identificado"*/;
            m_facturacionRealizada = false;
            m_mode = _MODE_DIALOGO_FACTURA_ELECTRONICA_TIMBRAR;
        }

        public WFFacturaElectronica(CDOCTOBE docto, CPARAMETROBE empresa) : this()
        {
            m_Docto = docto;
            m_empresa = empresa;
            m_facturacionRealizada = false;

            if (m_empresa.IVERSIONCFDI != null && (m_empresa.IVERSIONCFDI.Equals("3.3") || m_empresa.IVERSIONCFDI.Equals("4.0")))
                m_bUsarLibreriaVirtualXML = true;

            virtualXmlHelper = new VirtualXmlHelper(empresa.IVERSIONCFDI);
        }

        public WFFacturaElectronica(CDOCTOBE docto, CPARAMETROBE empresa, int mode, CDOCTOBE doctoRef, string PREGUNTARDATOSENTREGA)
            : this(docto, empresa)
        {
            this.m_mode = mode;
            this.m_DoctoRef = doctoRef;
            this.m_PREGUNTARDATOSENTREGA = PREGUNTARDATOSENTREGA;

        }

        public WFFacturaElectronica(CDOCTOBE docto, CPARAMETROBE empresa, int mode, FbTransaction fTrans, CDOCTOBE doctoRef, string PREGUNTARDATOSENTREGA)
            : this(docto, empresa, mode, doctoRef, PREGUNTARDATOSENTREGA)
        {
            this.m_fTrans = fTrans;
        }
        


        public WFFacturaElectronica(CDOCTOBE docto, CPARAMETROBE empresa, int mode, CDOCTOPAGOBE doctoPago, CDOCTOBE doctoRef, string PREGUNTARDATOSENTREGA, string formaPagoSatTemporal)
            : this(docto, empresa, mode, doctoRef, PREGUNTARDATOSENTREGA)
        {
            m_doctoPago = doctoPago;
            m_pagotemporal = true;
            m_formapagosattemporal = formaPagoSatTemporal;
        }



        public WFFacturaElectronica(CDOCTOBE docto, CPARAMETROBE empresa, int mode, CDOCTOPAGOBE doctoPago, CDOCTOBE doctoRef, string PREGUNTARDATOSENTREGA, bool pagoTemporal, string formaPagoSatTemporal)
            : this(docto, empresa, mode, doctoRef, PREGUNTARDATOSENTREGA)
        {
            m_doctoPago = doctoPago;
            m_pagotemporal = pagoTemporal;
            m_formapagosattemporal = formaPagoSatTemporal;
        }


        public WFFacturaElectronica(CDOCTOBE docto, CPARAMETROBE empresa, int mode, CDOCTOPAGOBE doctoPago, CDOCTOBE doctoRef, string PREGUNTARDATOSENTREGA, bool pagoTemporal, string formaPagoSatTemporal, CEMPRESASBE compania)
            : this(docto, empresa, mode, doctoPago, doctoRef, PREGUNTARDATOSENTREGA, pagoTemporal, formaPagoSatTemporal)
        {
            m_compania = compania;
        }

        public void setDesglosaKits(bool desglosaKits)
        {
            this.bDeslosaKits = desglosaKits;
        }



        public WFFacturaElectronica(long doctoId)
            : this()
        {
            SetInformation(doctoId);
        }

        public static string obtainPrefixByTipoComprobante(string tipoComprobante)
        {
            return tipoComprobante != null && tipoComprobante.Equals("T") ? "T_" : "";
        }

        private string obtainTipoComprobanteByMode(int mode)
        {
            switch (this.m_mode)
            {
                case _MODE_DIALOGO_FACTURA_ELECTRONICA_COMPROBTRASL:
                case _MODE_DIALOGO_FACTURA_ELECTRONICA_GENPDF_COMPROBTRASL:
                case _MODE_DIALOGO_COMPROB_TRASL_IMPRIMIRTICKET:
                    return "T";
                default:
                    return " ";

            }
        }

        private bool ComprobanteDeTrasladoExisteYEstaTimbrado()
        {

            CDOCTOCOMPROBANTEBE cDOCTOCOMPROBANTEBE = new CDOCTOCOMPROBANTEBE();
            CDOCTOCOMPROBANTED dOCTOCOMPROBANTED = new CDOCTOCOMPROBANTED();
            cDOCTOCOMPROBANTEBE.IDOCTOID = m_Docto.IID;
            cDOCTOCOMPROBANTEBE.ITIPOCOMPROBANTE = "T";
            cDOCTOCOMPROBANTEBE = dOCTOCOMPROBANTED.seleccionarDOCTOCOMPROBANTExTIPOYDOCTO(cDOCTOCOMPROBANTEBE, m_fTrans);

            return cDOCTOCOMPROBANTEBE != null && cDOCTOCOMPROBANTEBE.ITIMBRADOUUID != null;
        }

        private void fillSerieFactura()
        {


            switch (this.m_mode)
            {
                case _MODE_DIALOGO_FACTURA_ELECTRONICA_COMPROBTRASL:
                case _MODE_DIALOGO_FACTURA_ELECTRONICA_GENPDF_COMPROBTRASL:

                    CDOCTOCOMPROBANTEBE cDOCTOCOMPROBANTEBE = new CDOCTOCOMPROBANTEBE();
                    CDOCTOCOMPROBANTED dOCTOCOMPROBANTED = new CDOCTOCOMPROBANTED();
                    cDOCTOCOMPROBANTEBE.IDOCTOID = m_Docto.IID;
                    cDOCTOCOMPROBANTEBE.ITIPOCOMPROBANTE = "T";
                    cDOCTOCOMPROBANTEBE = dOCTOCOMPROBANTED.seleccionarDOCTOCOMPROBANTExTIPOYDOCTO(cDOCTOCOMPROBANTEBE, m_fTrans);

                    if(cDOCTOCOMPROBANTEBE  != null)
                    {

                        m_currentFolioSat = cDOCTOCOMPROBANTEBE.IFOLIOSAT;
                        m_currentSerieSat = cDOCTOCOMPROBANTEBE.ISERIESAT;
                    }

                    break;
                default:

                    m_currentFolioSat = this.m_Docto.IFOLIOSAT;
                    m_currentSerieSat = this.m_Docto.ISERIESAT;
                    break;

            }
        }


        public void SetInformation(long doctoId)
        {
            CDOCTOD doctoD = new CDOCTOD();
            m_Docto = new CDOCTOBE();
            m_Docto.IID = doctoId;
            m_Docto = doctoD.seleccionarDOCTO(m_Docto, m_fTrans);

            CPARAMETROD parametroD = new CPARAMETROD();
            m_empresa = new CPARAMETROBE();
            m_empresa = parametroD.seleccionarPARAMETROActual(m_fTrans);
        }

        public bool GenerateXMLSinTimbrar(string documentoSinTimbrar)
        {
            //file name
            string filename = "";

            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();
            //Now force thousand separator to be empty string
            nfi.NumberGroupSeparator = "";


            //create new instance of XmlDocument
            XmlDocument doc = new XmlDocument();


            Hashtable htIva = new Hashtable();
            Hashtable htIeps = new Hashtable();
            //htIva[(decimal)0] = (decimal)0.00;

            CCLIENTEBE clienteBE = new CCLIENTEBE();
            CPERSONAD personaD = new CPERSONAD();
            clienteBE.m_PersonaBE.IID = m_Docto.IPERSONAID;
            clienteBE.m_PersonaBE = personaD.seleccionarPERSONA(clienteBE.m_PersonaBE, m_fTrans);


            //tipo de cambio
            CMONEDABE monedaBE = new CMONEDABE();
            CMONEDAD monedaD = new CMONEDAD();
            monedaBE.IID = ((bool)m_Docto.isnull["IMONEDAID"] || m_Docto.IMONEDAID == 0) ? DBValues._MONEDA_PESOS : m_Docto.IMONEDAID;
            monedaBE = monedaD.seleccionarMONEDA(monedaBE, m_fTrans);
            if (monedaBE == null)
            {
                monedaBE = new CMONEDABE();
                monedaBE.ICLAVE = "MN";
            }

            Decimal tipoDeCambio = (((bool)m_Docto.isnull["ITIPOCAMBIO"] || m_Docto.ITIPOCAMBIO == 0) ? 1 : m_Docto.ITIPOCAMBIO);



            filename = System.AppDomain.CurrentDomain.BaseDirectory + getFileLocalLocation_FE_XML_Molde_File(m_empresa);

            ////////// forma de pago credito evitarla
            String referenciaCredito = "";
            string strCuentaPago = "N / A";
            m_nombreFormaPago = formaPagoTratandoEvitarPagoOtros(clienteBE, m_nombreFormaPago, m_doctoPago, ref referenciaCredito);

            if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_RECIBOELECTRONICO && m_doctoPago.ICUENTAPAGOCREDITO != null && m_doctoPago.ICUENTAPAGOCREDITO.Trim().Length > 0)
            {
                strCuentaPago = m_doctoPago.ICUENTAPAGOCREDITO;
            }
            else if (this.m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_CHEQUE || this.m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_TARJETA || this.m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_TRANSFERENCIA)
            {
                strCuentaPago = this.m_doctoPago.IREFERENCIABANCARIA;
            }
            else if (this.m_doctoPago.IFORMAPAGOID == 4 && !referenciaCredito.Equals(""))
            {
                strCuentaPago = referenciaCredito;
            }


            //if (m_nombreFormaPago.Trim().ToLower().Equals(/*"credito"*/"99"))
            //{
            //    if (clienteBE.m_PersonaBE == null)
            //        m_nombreFormaPago = "99";// "N / A"/*"No Identificado"*/;
            //    if ((bool)clienteBE.m_PersonaBE.isnull["ICREDITOFORMAPAGOABONOS"] || clienteBE.m_PersonaBE.ICREDITOFORMAPAGOABONOS == 0 || clienteBE.m_PersonaBE.ICREDITOFORMAPAGOABONOS == 16)
            //        m_nombreFormaPago = "99";// "N / A"/*"No Identificado"*/;
            //    else
            //    {
            //        CDOCTOPAGOD pagoD = new CDOCTOPAGOD();
            //        m_nombreFormaPago = pagoD.obtenNombreFormaPagoSatXId(clienteBE.m_PersonaBE.ICREDITOFORMAPAGOABONOS, m_fTrans);
            //        if (m_nombreFormaPago == "")
            //            m_nombreFormaPago = "99";// "N / A"/*"No Identificado"*/;
            //        else
            //        {
            //            referenciaCredito = clienteBE.m_PersonaBE.ICREDITOREFERENCIAABONOS;
            //        }
            //    }
            //    if (referenciaCredito == null)
            //        referenciaCredito = "";
            //}
            ////




            try
            {
                //load from file
                doc.Load(filename);



                XmlNamespaceManager nsmRequest = new XmlNamespaceManager(doc.NameTable);
                nsmRequest.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3");
                nsmRequest.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");

                XmlNode CiberSatNode = doc.SelectSingleNode("//CiberSAT5", nsmRequest);
                XmlElement elmCiberSatNode = (XmlElement)CiberSatNode;
                elmCiberSatNode.SetAttribute("emisor", /*"AAA010101AAA"*/m_empresa.IRFC);
                elmCiberSatNode.SetAttribute("PAC", (!(bool)m_empresa.isnull["IPACNOMBRE"]) ? m_empresa.IPACNOMBRE : "");
                elmCiberSatNode.SetAttribute("usuario", (!(bool)m_empresa.isnull["IPACUSUARIO"]) ? m_empresa.IPACUSUARIO : "");



                XmlNode ComprobanteNode = doc.SelectSingleNode("//CiberSAT5/cfdi:Comprobante", nsmRequest);
                XmlElement elmComprobanteNode = (XmlElement)ComprobanteNode;

                elmComprobanteNode.SetAttribute("serie", m_currentSerieSat);
                elmComprobanteNode.SetAttribute("folio", this.m_currentFolioSat.ToString());
                elmComprobanteNode.SetAttribute("fecha", m_Docto.ITIMBRADOFECHAFACTURA.AddMinutes(-5).ToString("yyyy-MM-dd'T'HH:mm:ss"));
                elmComprobanteNode.SetAttribute("sello", "");
                elmComprobanteNode.SetAttribute("formaDePago", clienteBE.m_PersonaBE.IPAGOPARCIALIDADES.Equals("S") ? "PAGO EN PARCIALIDADES" : "PAGO EN UNA SOLA EXHIBICION");

                if (this.m_DoctoRef != null && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_RECIBOELECTRONICO)
                {
                    elmComprobanteNode.SetAttribute("SerieFolioFiscalOrig", m_DoctoRef.ISERIESAT);
                    elmComprobanteNode.SetAttribute("FolioFiscalOrig", m_DoctoRef.ITIMBRADOUUID.ToString());
                    elmComprobanteNode.SetAttribute("FechaFolioFiscalOrig", m_DoctoRef.ITIMBRADOFECHAFACTURA.AddMinutes(-5).ToString("yyyy-MM-dd'T'HH:mm:ss"));
                    decimal TotalRef = m_DoctoRef.ITOTAL - m_DoctoRef.IIVARETENIDO - m_DoctoRef.IISRRETENIDO;
                    elmComprobanteNode.SetAttribute("MontoFolioFiscalOrig", (TotalRef / tipoDeCambio).ToString("N2", nfi));
                }

                //string bufferNumCSD = Path.GetFileName(m_empresa.ITIMBRADOARCHIVOCERTIFICADO);
                elmComprobanteNode.SetAttribute("noCertificado", m_empresa.ICERTIFICADOCSD);

                elmComprobanteNode.SetAttribute("certificado", "");
                elmComprobanteNode.SetAttribute("condicionesDePago", "N / A"/*"No Identificado"*/);

                elmComprobanteNode.SetAttribute("subTotal", (clienteBE.m_PersonaBE.IDESGLOSEIEPS.Equals("S") && m_empresa.IDESGLOSEIEPS.Equals("S")) ? (m_Docto.ISUBTOTAL / tipoDeCambio).ToString("N2", nfi) : ((m_Docto.ISUBTOTAL + m_Docto.IIEPS) / tipoDeCambio).ToString("N2", nfi));
                elmComprobanteNode.SetAttribute("descuento", "0.00");
                elmComprobanteNode.SetAttribute("motivoDescuento", "X");
                elmComprobanteNode.SetAttribute("TipoCambio", /*"1.00"*/ tipoDeCambio.ToString("N2", nfi));
                elmComprobanteNode.SetAttribute("Moneda", /*"MN"*/  monedaBE.ICLAVE);


                decimal Total = m_Docto.ITOTAL - m_Docto.IIVARETENIDO - m_Docto.IISRRETENIDO;



                elmComprobanteNode.SetAttribute("total", (Total / tipoDeCambio).ToString("N2", nfi));



                elmComprobanteNode.SetAttribute("metodoDePago", m_nombreFormaPago);
                elmComprobanteNode.SetAttribute("LugarExpedicion", m_empresa.ILOCALIDAD + " , " + m_empresa.IESTADO + " , MEXICO");




                elmComprobanteNode.SetAttribute("NumCtaPago", strCuentaPago);

                string tipoComprobante = "";
                switch (m_Docto.ITIPODOCTOID)
                {
                    case 21:
                    case 25:
                    case DBValues._DOCTO_TIPO_RECIBOELECTRONICO:
                        tipoComprobante = "ingreso";
                        break;
                    case 22:
                    case 23:
                    case 26:
                        tipoComprobante = "egreso";
                        break;
                    default:
                        tipoComprobante = "ingreso";
                        break;
                }

                elmComprobanteNode.SetAttribute("tipoDeComprobante", tipoComprobante);


                XmlNode EmisorNode = doc.SelectSingleNode("//CiberSAT5/cfdi:Comprobante/cfdi:Emisor", nsmRequest);
                XmlElement elmEmisorNode = (XmlElement)EmisorNode;
                elmEmisorNode.SetAttribute("rfc", /*"AAA010101AAA"*/m_empresa.IRFC);
                elmEmisorNode.SetAttribute("nombre", /*"VINICOLA DEL DANZANTE SA DE CV"*/(!(bool)m_empresa.isnull["IFISCALNOMBRE"]) ? m_empresa.IFISCALNOMBRE : m_empresa.INOMBRE);


                XmlNode EmisorDomicilioFiscalNode = doc.SelectSingleNode("//CiberSAT5/cfdi:Comprobante/cfdi:Emisor/cfdi:DomicilioFiscal", nsmRequest);
                XmlElement elmEmisorDomicilioFiscalNode = (XmlElement)EmisorDomicilioFiscalNode;

                elmEmisorDomicilioFiscalNode.SetAttribute("calle", m_empresa.IFISCALCALLE);
                elmEmisorDomicilioFiscalNode.SetAttribute("noExterior", m_empresa.IFISCALNUMEROEXTERIOR);
                //elmEmisorDomicilioFiscalNode.SetAttribute("noInterior", m_empresa.IFISCALNUMEROINTERIOR);
                if ((bool)m_empresa.isnull["IFISCALNUMEROINTERIOR"] || m_empresa.IFISCALNUMEROINTERIOR.Trim().Equals(""))
                {
                    elmEmisorDomicilioFiscalNode.SetAttribute("noInterior", "_");
                }
                else
                {
                    elmEmisorDomicilioFiscalNode.SetAttribute("noInterior", m_empresa.IFISCALNUMEROINTERIOR);
                }
                elmEmisorDomicilioFiscalNode.SetAttribute("colonia", m_empresa.IFISCALCOLONIA);
                elmEmisorDomicilioFiscalNode.SetAttribute("localidad", ".");
                elmEmisorDomicilioFiscalNode.SetAttribute("referencia", ".");
                elmEmisorDomicilioFiscalNode.SetAttribute("municipio", m_empresa.IFISCALMUNICIPIO);
                elmEmisorDomicilioFiscalNode.SetAttribute("estado", m_empresa.IFISCALESTADO);
                elmEmisorDomicilioFiscalNode.SetAttribute("pais", "MEXICO");
                elmEmisorDomicilioFiscalNode.SetAttribute("codigoPostal", m_empresa.IFISCALCODIGOPOSTAL);







                XmlNode EmisorExpedidoEnNode = doc.SelectSingleNode("//CiberSAT5/cfdi:Comprobante/cfdi:Emisor/cfdi:ExpedidoEn", nsmRequest);
                XmlElement elmEmisorExpedidoEnNode = (XmlElement)EmisorExpedidoEnNode;

                if (m_empresa.IUSARFISCALESENEXPEDICION == "S")
                {
                    elmEmisorExpedidoEnNode.SetAttribute("calle", m_empresa.IFISCALCALLE);
                    elmEmisorExpedidoEnNode.SetAttribute("noExterior", m_empresa.IFISCALNUMEROEXTERIOR);
                    //elmEmisorExpedidoEnNode.SetAttribute("noInterior", m_empresa.IFISCALNUMEROINTERIOR);
                    if ((bool)m_empresa.isnull["IFISCALNUMEROINTERIOR"] || m_empresa.IFISCALNUMEROINTERIOR.Trim().Equals(""))
                    {
                        elmEmisorExpedidoEnNode.SetAttribute("noInterior", "_");
                    }
                    else
                    {
                        elmEmisorExpedidoEnNode.SetAttribute("noInterior", m_empresa.IFISCALNUMEROINTERIOR);
                    }
                    elmEmisorExpedidoEnNode.SetAttribute("colonia", m_empresa.IFISCALCOLONIA);
                    elmEmisorExpedidoEnNode.SetAttribute("localidad", ".");
                    elmEmisorExpedidoEnNode.SetAttribute("referencia", ".");
                    elmEmisorExpedidoEnNode.SetAttribute("municipio", m_empresa.IFISCALMUNICIPIO);
                    elmEmisorExpedidoEnNode.SetAttribute("estado", m_empresa.IFISCALESTADO);
                    elmEmisorExpedidoEnNode.SetAttribute("pais", "MEXICO");
                    elmEmisorExpedidoEnNode.SetAttribute("codigoPostal", m_empresa.IFISCALCODIGOPOSTAL);
                }
                else
                {
                    elmEmisorExpedidoEnNode.SetAttribute("calle", m_empresa.ICALLE);
                    elmEmisorExpedidoEnNode.SetAttribute("noExterior", m_empresa.INUMEROEXTERIOR);
                    //elmEmisorExpedidoEnNode.SetAttribute("noInterior", m_empresa.INUMEROINTERIOR);
                    if ((bool)m_empresa.isnull["INUMEROINTERIOR"] || m_empresa.INUMEROINTERIOR.Trim().Equals(""))
                    {
                        elmEmisorExpedidoEnNode.SetAttribute("noInterior", "_");
                    }
                    else
                    {
                        elmEmisorExpedidoEnNode.SetAttribute("noInterior", m_empresa.INUMEROINTERIOR);
                    }
                    elmEmisorExpedidoEnNode.SetAttribute("colonia", m_empresa.ICOLONIA);
                    elmEmisorExpedidoEnNode.SetAttribute("localidad", ".");
                    elmEmisorExpedidoEnNode.SetAttribute("referencia", ".");
                    elmEmisorExpedidoEnNode.SetAttribute("municipio", m_empresa.ILOCALIDAD);
                    elmEmisorExpedidoEnNode.SetAttribute("estado", m_empresa.IESTADO);
                    elmEmisorExpedidoEnNode.SetAttribute("pais", "MEXICO");
                    elmEmisorExpedidoEnNode.SetAttribute("codigoPostal", m_empresa.ICP);
                }

                XmlNode EmisorRegimenFiscalNode = doc.SelectSingleNode("//CiberSAT5/cfdi:Comprobante/cfdi:Emisor/cfdi:RegimenFiscal", nsmRequest);
                XmlElement elmEmisorRegimenFiscalNode = (XmlElement)EmisorRegimenFiscalNode;
                elmEmisorRegimenFiscalNode.SetAttribute("Regimen", m_empresa.IFISCALREGIMEN);




                XmlNode ReceptorNode = doc.SelectSingleNode("//CiberSAT5/cfdi:Comprobante/cfdi:Receptor", nsmRequest);
                XmlElement elmReceptorNode = (XmlElement)ReceptorNode;
                elmReceptorNode.SetAttribute("rfc", /*"SEAS421201CB0"*/clienteBE.m_PersonaBE.IRFC);
                elmReceptorNode.SetAttribute("nombre", /*"SERRANO ALVAREZ SARA"*/clienteBE.m_PersonaBE.INOMBRES + " " + clienteBE.m_PersonaBE.IAPELLIDOS);


                XmlNode ReceptorDomicilioNode = doc.SelectSingleNode("//CiberSAT5/cfdi:Comprobante/cfdi:Receptor/cfdi:Domicilio", nsmRequest);
                XmlElement elmReceptorDomicilioNode = (XmlElement)ReceptorDomicilioNode;
                elmReceptorDomicilioNode.SetAttribute("calle", clienteBE.m_PersonaBE.IDOMICILIO);
                elmReceptorDomicilioNode.SetAttribute("noExterior", clienteBE.m_PersonaBE.INUMEROEXTERIOR);
                //elmReceptorDomicilioNode.SetAttribute("noInterior", clienteBE.m_PersonaBE.INUMEROINTERIOR);
                if ((bool)clienteBE.m_PersonaBE.isnull["INUMEROINTERIOR"] || clienteBE.m_PersonaBE.INUMEROINTERIOR.Trim().Equals(""))
                {
                    elmReceptorDomicilioNode.SetAttribute("noInterior", "_");
                }
                else
                {
                    elmReceptorDomicilioNode.SetAttribute("noInterior", clienteBE.m_PersonaBE.INUMEROINTERIOR);
                }
                elmReceptorDomicilioNode.SetAttribute("colonia", clienteBE.m_PersonaBE.ICOLONIA);
                elmReceptorDomicilioNode.SetAttribute("localidad", clienteBE.m_PersonaBE.ILOCALIDAD == null || clienteBE.m_PersonaBE.ILOCALIDAD.Trim().Length == 0 ? "." : clienteBE.m_PersonaBE.ILOCALIDAD);
                elmReceptorDomicilioNode.SetAttribute("referencia", clienteBE.m_PersonaBE.IREFERENCIADOM == null || clienteBE.m_PersonaBE.IREFERENCIADOM.Trim().Length == 0 ? "." : clienteBE.m_PersonaBE.IREFERENCIADOM);
                elmReceptorDomicilioNode.SetAttribute("municipio", clienteBE.m_PersonaBE.ICIUDAD);
                elmReceptorDomicilioNode.SetAttribute("estado", clienteBE.m_PersonaBE.IESTADO);
                elmReceptorDomicilioNode.SetAttribute("pais", clienteBE.m_PersonaBE.IPAIS == null || clienteBE.m_PersonaBE.IPAIS.Trim().Length == 0 ? "MEXICO" : clienteBE.m_PersonaBE.IPAIS);
                elmReceptorDomicilioNode.SetAttribute("codigoPostal", clienteBE.m_PersonaBE.ICODIGOPOSTAL);



                XmlNode anode = doc.SelectSingleNode("//CiberSAT5/cfdi:Comprobante/cfdi:Conceptos", nsmRequest);
                XmlNode molde = anode.SelectSingleNode("//cfdi:Concepto", nsmRequest);
                XmlNode moldeInformacionAduanera = null;
                try
                {
                    moldeInformacionAduanera = molde.SelectSingleNode("cfdi:InformacionAduanera", nsmRequest);
                    if (moldeInformacionAduanera != null)
                        molde.RemoveChild(moldeInformacionAduanera);
                }
                catch { }
                anode.RemoveAll();


                //detalles
                foreach (DataRow dr in this.dSReportIpos2.REP_FACTURAELECTRONICA_DET.Rows)
                {

                    XmlNode concept = molde.Clone();
                    XmlElement el = (XmlElement)concept;

                    XmlNode ctaPredial = concept.SelectSingleNode("cfdi:CuentaPredial", nsmRequest);


                    decimal porcentajeiva = 0;
                    decimal porcentajeieps = 0;
                    decimal iva = 0;
                    decimal ieps = 0;
                    decimal subtotal = 0;
                    decimal cantidad = 0;
                    decimal valorUnitario = 0;
                    if (dr["CANTIDAD"] != DBNull.Value)
                    {
                        cantidad = (decimal)dr["CANTIDAD"];
                        el.SetAttribute("cantidad", cantidad.ToString("N2", nfi));
                    }
                    else
                    {
                        continue;
                    }


                    if (dr["UNIDAD"] != DBNull.Value)
                        el.SetAttribute("unidad", dr["UNIDAD"].ToString().Trim());
                    else
                        el.SetAttribute("unidad", "PZA");


                    if (dr["PRODUCTOCLAVE"] != DBNull.Value)
                        el.SetAttribute("noIdentificacion", dr["PRODUCTOCLAVE"].ToString().Trim());
                    else
                        el.SetAttribute("noIdentificacion", "");


                    if (dr["PRODUCTODESCRIPCION"] != DBNull.Value)
                        el.SetAttribute("descripcion", dr["PRODUCTODESCRIPCION"].ToString().Trim());



                    if (dr["PRODUCTODESCRIPCION"] != DBNull.Value)
                        el.SetAttribute("descripcion", dr["PRODUCTODESCRIPCION"].ToString().Trim());


                    if (dr["SUBTOTAL"] != DBNull.Value)
                    {
                        subtotal = (decimal)dr["SUBTOTAL"];
                    }


                    if (dr["PRECIO"] != DBNull.Value)
                    {
                        valorUnitario = (decimal)dr["PRECIO"];
                    }

                    if ((clienteBE.m_PersonaBE.IDESGLOSEIEPS.Equals("S") && m_empresa.IDESGLOSEIEPS.Equals("S")))
                    {

                        el.SetAttribute("valorUnitario", valorUnitario.ToString("N2", nfi));

                        el.SetAttribute("importe", subtotal.ToString("N2", nfi));

                    }
                    else
                    {

                        if (dr["PORCENTAJEIEPS"] != DBNull.Value)
                        {
                            porcentajeieps = (decimal)dr["PORCENTAJEIEPS"];
                        }

                        if (dr["IEPS"] != DBNull.Value)
                        {
                            ieps = (decimal)dr["IEPS"];
                        }

                        el.SetAttribute("valorUnitario", (Math.Round((subtotal + ieps) / cantidad, 2)).ToString("N2", nfi));

                        el.SetAttribute("importe", (subtotal + ieps).ToString("N2", nfi));
                    }



                    if (!(bool)m_empresa.isnull["IARRENDATARIO"] && m_empresa.IARRENDATARIO.Equals("S") && dr["CUENTAPREDIAL"] != DBNull.Value && dr["CUENTAPREDIAL"].ToString().Trim().Length > 0)
                    {
                        XmlElement elCtaPedial = (XmlElement)ctaPredial;
                        elCtaPedial.SetAttribute("numero", dr["CUENTAPREDIAL"].ToString().Trim());
                    }
                    else
                    {
                        concept.RemoveChild(ctaPredial);
                    }


                    //informacion aduanera
                    bool hayInformacionAduanera = false;
                    if (!(bool)m_empresa.isnull["IMANEJARLOTEIMPORTACION"] && m_empresa.IMANEJARLOTEIMPORTACION.Equals("S") && dr["STRPEDIMENTO"] != DBNull.Value && dr["STRPEDIMENTO"].ToString().Trim().Length > 0)
                    {

                        hayInformacionAduanera = true;

                    }
                    if (hayInformacionAduanera)
                    {

                        string strMovtoId = dr["MOVTOID"].ToString();

                        DataView dv = new DataView(this.dSReportIpos2.INFOIMPORTACION);
                        dv.RowFilter = "MOVTOID = " + strMovtoId;

                        if (dv.Count > 0)
                        {
                            DataTable dtFiltered = dv.ToTable();

                            foreach (DataRow drFiltered in dtFiltered.Rows)
                            {

                                XmlNode ctaInformacionAduanera = moldeInformacionAduanera.Clone();
                                XmlElement elCtaInformacionAduanera = (XmlElement)ctaInformacionAduanera;

                                DateTime? dateImpoFecha = drFiltered["IMPORTACION_FECHA"] != DBNull.Value ? (DateTime?)drFiltered["IMPORTACION_FECHA"] : null;

                                string IMPORTACION_PEDIMENTO = drFiltered["IMPORTACION_PEDIMENTO"] != DBNull.Value ? drFiltered["IMPORTACION_PEDIMENTO"].ToString().Trim() : "";
                                string IMPORTACION_FECHA = dateImpoFecha.HasValue ? dateImpoFecha.Value.ToString("yyyy-MM-dd") : "";
                                string IMPORTACION_ADUANA = drFiltered["IMPORTACION_PEDIMENTO"] != DBNull.Value ? drFiltered["IMPORTACION_ADUANA"].ToString().Trim() : "";



                                elCtaInformacionAduanera.SetAttribute("numero", IMPORTACION_PEDIMENTO);
                                elCtaInformacionAduanera.SetAttribute("fecha", IMPORTACION_FECHA);
                                elCtaInformacionAduanera.SetAttribute("aduana", IMPORTACION_ADUANA);

                                concept.AppendChild(ctaInformacionAduanera);
                            }
                        }

                    }



                    anode.AppendChild(el);


                    //calculating iva
                    if (dr["PORCENTAJEIVA"] != DBNull.Value)
                    {
                        porcentajeiva = (decimal)dr["PORCENTAJEIVA"];
                    }

                    if (dr["IVA"] != DBNull.Value)
                    {
                        iva = (decimal)dr["IVA"];
                    }

                    if (htIva.Contains(porcentajeiva))
                        htIva[porcentajeiva] = (decimal)htIva[porcentajeiva] + iva;
                    else
                        htIva[porcentajeiva] = iva;


                    if (m_empresa.IDESGLOSEIEPS.Equals("S") && clienteBE.m_PersonaBE.IDESGLOSEIEPS.Equals("S"))
                    {
                        //calculating ieps
                        if (dr["PORCENTAJEIEPS"] != DBNull.Value)
                        {
                            porcentajeieps = (decimal)dr["PORCENTAJEIEPS"];
                        }

                        if (dr["IEPS"] != DBNull.Value)
                        {
                            ieps = (decimal)dr["IEPS"];
                        }

                        if (htIeps.Contains(porcentajeieps))
                            htIeps[porcentajeieps] = (decimal)htIeps[porcentajeieps] + ieps;
                        else
                            htIeps[porcentajeieps] = ieps;
                    }





                }


                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_RECIBOELECTRONICO)
                {
                    ReCalculaImpuestosRecibo(ref htIva, ref htIeps, clienteBE);
                }



                XmlNode ImpuestosNode = doc.SelectSingleNode("//CiberSAT5/cfdi:Comprobante/cfdi:Impuestos", nsmRequest);
                XmlElement elmImpuestosNode = (XmlElement)ImpuestosNode;
                elmImpuestosNode.SetAttribute("totalImpuestosTrasladados", (m_empresa.IDESGLOSEIEPS.Equals("S") && clienteBE.m_PersonaBE.IDESGLOSEIEPS.Equals("S")) ? (m_Docto.IIMPUESTO / tipoDeCambio).ToString("N2", nfi) : (m_Docto.IIVA / tipoDeCambio).ToString("N2", nfi));


                XmlNode ImpuestosDetalleNodes = doc.SelectSingleNode("//CiberSAT5/cfdi:Comprobante/cfdi:Impuestos/cfdi:Traslados", nsmRequest);
                XmlNode moldeImpuestosDetalle = ImpuestosDetalleNodes.SelectSingleNode("//cfdi:Traslado", nsmRequest);
                ImpuestosDetalleNodes.RemoveAll();






                foreach (DictionaryEntry entry in htIva)
                {

                    decimal tasaImp = (decimal)entry.Key;
                    decimal importeImp = (decimal)entry.Value;

                    /*if (importeImp == (decimal)0)
                    {

                        continue;
                    }*/

                    XmlNode ImpuestoDetalle = moldeImpuestosDetalle.Clone();
                    XmlElement elmImpuestoDetalle = (XmlElement)ImpuestoDetalle;
                    elmImpuestoDetalle.SetAttribute("impuesto", "IVA");
                    elmImpuestoDetalle.SetAttribute("tasa", tasaImp.ToString("N2", nfi));
                    elmImpuestoDetalle.SetAttribute("importe", importeImp.ToString("N2", nfi));
                    ImpuestosDetalleNodes.AppendChild(elmImpuestoDetalle);

                    if (tasaImp == (decimal)0)
                    {
                        bShowIva0 = true;
                    }

                    if (tasaImp == (decimal)16)
                    {
                        bShowIva16 = true;
                    }

                }


                foreach (DictionaryEntry entry in htIeps)
                {

                    decimal tasaImp = (decimal)entry.Key;
                    decimal importeImp = (decimal)entry.Value;

                    XmlNode ImpuestoDetalle = moldeImpuestosDetalle.Clone();
                    XmlElement elmImpuestoDetalle = (XmlElement)ImpuestoDetalle;
                    elmImpuestoDetalle.SetAttribute("impuesto", "IEPS");
                    elmImpuestoDetalle.SetAttribute("tasa", tasaImp.ToString("N2", nfi));
                    elmImpuestoDetalle.SetAttribute("importe", importeImp.ToString("N2", nfi));
                    ImpuestosDetalleNodes.AppendChild(elmImpuestoDetalle);

                }


                XmlNode ImpuestosParentNode = doc.SelectSingleNode("//CiberSAT5/cfdi:Comprobante/cfdi:Impuestos", nsmRequest);

                XmlNode ImpuestosRetencionesNodes = doc.SelectSingleNode("//CiberSAT5/cfdi:Comprobante/cfdi:Impuestos/cfdi:Retenciones", nsmRequest);
                XmlNode moldeImpuestosRetencion = ImpuestosRetencionesNodes.SelectSingleNode("//cfdi:Retencion", nsmRequest);
                ImpuestosRetencionesNodes.RemoveAll();



                if (clienteBE.m_PersonaBE.IRETIENEIVA.Equals("S"))
                {

                    XmlNode ImpuestoRetencion = moldeImpuestosRetencion.Clone();
                    XmlElement elmImpuestoRetencion = (XmlElement)ImpuestoRetencion;
                    elmImpuestoRetencion.SetAttribute("impuesto", "IVA");
                    elmImpuestoRetencion.SetAttribute("importe", (m_Docto.IIVARETENIDO / tipoDeCambio).ToString("N2", nfi));
                    ImpuestosRetencionesNodes.AppendChild(elmImpuestoRetencion);
                }

                if (clienteBE.m_PersonaBE.IRETIENEISR.Equals("S"))
                {

                    XmlNode ImpuestoRetencion = moldeImpuestosRetencion.Clone();
                    XmlElement elmImpuestoRetencion = (XmlElement)ImpuestoRetencion;
                    elmImpuestoRetencion.SetAttribute("impuesto", "ISR");
                    elmImpuestoRetencion.SetAttribute("importe", (m_Docto.IISRRETENIDO / tipoDeCambio).ToString("N2", nfi));
                    ImpuestosRetencionesNodes.AppendChild(elmImpuestoRetencion);
                }


                if (!clienteBE.m_PersonaBE.IRETIENEISR.Equals("S") && !clienteBE.m_PersonaBE.IRETIENEIVA.Equals("S"))
                {
                    ImpuestosParentNode.RemoveChild(ImpuestosRetencionesNodes);
                    elmImpuestosNode.RemoveAttribute("totalImpuestosRetenidos");
                }
                else
                {

                    elmImpuestosNode.SetAttribute("totalImpuestosRetenidos", ((m_Docto.IIVARETENIDO + m_Docto.IISRRETENIDO) / tipoDeCambio).ToString("N2", nfi));
                }









                XmlNode TimbreFiscalNode = doc.SelectSingleNode("//CiberSAT5/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital", nsmRequest);
                XmlElement elmTimbreFiscalNode = (XmlElement)TimbreFiscalNode;
                elmTimbreFiscalNode.SetAttribute("UUID", "00000000-0000-0000-0000-000000000000");

                elmTimbreFiscalNode.SetAttribute("FechaTimbrado", m_Docto.ITIMBRADOFECHAFACTURA.AddMinutes(-5).ToString("yyyy-MM-dd'T'HH:mm:ss"));
                elmTimbreFiscalNode.SetAttribute("selloCFD", "");
                elmTimbreFiscalNode.SetAttribute("noCertificadoSAT", "12345678901234567890");
                elmTimbreFiscalNode.SetAttribute("selloSAT", "");


                doc.Save(documentoSinTimbrar);
            }
            catch (Exception ex)
            {
                if (!m_silentMode)
                {
                    MessageBox.Show("Ocurrio un error al generar el xml para ser timbrado" + ex.Message + ex.StackTrace);
                }
                else
                {
                    m_iComentario = "Ocurrio un error al generar el xml para ser timbrado" + ex.Message + ex.StackTrace;
                }
                return false;
            }

            return true;
        }



        private bool ReCalculaImpuestosRecibo(ref Hashtable htIva, ref Hashtable htIeps, CCLIENTEBE clienteBE)
        {
            htIva = new Hashtable();
            htIeps = new Hashtable();

            if (m_DoctoRef != null && m_DoctoRef.ITOTAL > 0)
            {


                decimal factor = m_Docto.ITOTAL / m_DoctoRef.ITOTAL;
                decimal sumaIva = 0;
                decimal sumaIeps = 0;
                decimal lastTasaIva = -1;
                decimal lastTasaIeps = -1;

                foreach (DataRow dr in this.dSReportIpos2.REP_FACTURAELECTRONICA_DET_REF.Rows)
                {

                    decimal porcentajeiva = 0;
                    decimal porcentajeieps = 0;
                    decimal iva = 0;
                    decimal ieps = 0;


                    //calculating iva
                    if (dr["PORCENTAJEIVA"] != DBNull.Value)
                    {
                        porcentajeiva = (decimal)dr["PORCENTAJEIVA"];
                    }

                    if (dr["IVA"] != DBNull.Value)
                    {
                        iva = ((decimal)dr["IVA"]) * factor;
                        sumaIva += iva;
                    }

                    if (htIva.Contains(porcentajeiva))
                        htIva[porcentajeiva] = (decimal)htIva[porcentajeiva] + iva;
                    else
                    {
                        htIva[porcentajeiva] = iva;
                        lastTasaIva = porcentajeiva;
                    }


                    if (m_empresa.IDESGLOSEIEPS.Equals("S") && clienteBE.m_PersonaBE.IDESGLOSEIEPS.Equals("S"))
                    {
                        //calculating ieps
                        if (dr["PORCENTAJEIEPS"] != DBNull.Value)
                        {
                            porcentajeieps = (decimal)dr["PORCENTAJEIEPS"];
                        }

                        if (dr["IEPS"] != DBNull.Value)
                        {
                            ieps = ((decimal)dr["IEPS"]) * factor;
                            sumaIeps += ieps;

                        }

                        if (htIeps.Contains(porcentajeieps))
                            htIeps[porcentajeieps] = (decimal)htIeps[porcentajeieps] + ieps;
                        else
                        {
                            htIeps[porcentajeieps] = ieps;
                            lastTasaIeps = porcentajeieps;
                        }
                    }

                }


                if (lastTasaIva != -1)
                {
                    if (sumaIva < m_Docto.IIVA)
                    {
                        htIva[lastTasaIva] = ((decimal)htIva[lastTasaIva]) + (m_Docto.IIVA - sumaIva);
                    }
                    else
                    {
                        htIva[lastTasaIva] = ((decimal)htIva[lastTasaIva]) - (sumaIva - m_Docto.IIVA);
                    }
                }


                if (lastTasaIeps != -1)
                {
                    if (sumaIeps < m_Docto.IIEPS)
                    {
                        htIeps[lastTasaIeps] = ((decimal)htIeps[lastTasaIeps]) + (m_Docto.IIEPS - sumaIeps);
                    }
                    else
                    {
                        htIeps[lastTasaIeps] = ((decimal)htIeps[lastTasaIeps]) - (sumaIeps - m_Docto.IIEPS);
                    }
                }

            }






            return true;
        }


        public ArrayList DOCTOIEPS_RECIBO(long DOCTOID, CCLIENTEBE clienteBE)
        {

            Hashtable htIva = new Hashtable();
            Hashtable htIeps = new Hashtable();
            ReCalculaImpuestosRecibo(ref htIva, ref htIeps, clienteBE);

            ArrayList listaIEPS = new ArrayList();



            foreach (DictionaryEntry entry in htIeps)
            {
                Hashtable ht = new Hashtable();

                decimal tasaImp = (decimal)entry.Key;
                decimal importeImp = (decimal)entry.Value;

                ht.Add("DOCTOID", DOCTOID);
                ht.Add("TASAIEPS", tasaImp);
                ht.Add("SUMAIEPS", importeImp);

                listaIEPS.Add(ht);

            }




            return listaIEPS;
        }




        private bool TimbrarDocumento(string documentoSinTimbrar, string documentoTimbrado)
        {
            int mivar;
            bool retorno;


            mivar = CiberPAC_SignXmlW(documentoSinTimbrar,
                                      /*".\\aaa010101aaa.cer"*/ m_empresa.ITIMBRADOARCHIVOCERTIFICADO,
                                      /*".\\aaa010101aaa.key"*/ m_empresa.ITIMBRADOARCHIVOKEY,
                                      /*"12345678a"*/ m_empresa.ITIMBRADOPASSWORD,
                                      documentoTimbrado,
                                      /*"CTE940531F58"*/ m_empresa.ITIMBRADOUSER,
                                      m_empresa.ITIMBRADOKEY,
                                      //"HwAAAHarKwEghcVR/jxG3Dd7OGKpk8uUTRjyYWdG6EI2mwOjedrfryXCjJwz5PP7;sDqjPQ==;",
                                      17);

            if (CiberPAC_GetNoError(mivar) == 0)
            {
                retorno = true;
                //SelloCFD.Text = CiberPAC_GetValueW(mivar, 512);
                //SelloSAT.Text = CiberPAC_GetValueW(mivar, 32768);
                //cbb.Load(".\\salida.xml.bmp");
                //cbb.Show();
            }
            else
            {


                if (!m_silentMode)
                {
                    MessageBox.Show("Ocurrio un error al timbrar el documento... Vaya a los siguientes archivos para saber la razon del error de timbrado : " + documentoTimbrado + ".log y " + documentoSinTimbrar + ".response");
                    Process.Start("notepad.exe", documentoTimbrado + ".log");
                }
                else
                {
                    m_iComentario = "Ocurrio un error al timbrar el documento... Vaya a los siguientes archivos para saber la razon del error de timbrado : " + documentoTimbrado + ".log y " + documentoSinTimbrar + ".response";
                    m_strFileLog = documentoTimbrado + ".log";
                }



                retorno = false;
                //SelloCFD.Text = CiberPAC_GetValueW(mivar, 2);
                //SelloSAT.Text = CiberPAC_GetValueW(mivar, 4);
                //cbb.Hide();
            }

            /*CadenaSAT.Text = CiberPAC_GetValueW(mivar, 524288);
            UUID.Text = CiberPAC_GetValueW(mivar, 262144);
            CertSAT.Text = CiberPAC_GetValueW(mivar, 65536);
            FechaTim.Text = CiberPAC_GetValueW(mivar, 131072);*/

            CiberPAC_Free(mivar);
            return retorno;
        }



        private bool CancelarDocumento(string documentoTimbrado, string outputFile, string uuid)
        {
            int mivar = -198;
            bool retorno = false;
            CDOCTOD doctoD = new CDOCTOD();

            try
            {
                
                mivar = CancelaUUID(m_empresa.IPACUSUARIO,
                                             m_empresa.IRFC,
                                            m_empresa.ITIMBRADOARCHIVOCERTIFICADO,
                                          m_empresa.ITIMBRADOARCHIVOKEY,
                                          m_empresa.ITIMBRADOPASSWORD,
                                          uuid,
                                          outputFile);



                //mivar = 0;

                /*if (mivar != 0)
                {

                    if (!m_silentMode)
                    {
                        MessageBox.Show("Ocurrio un error al cancelar el documento... Vaya a los siguientes archivos para saber la razon del error de timbrado : " + documentoTimbrado + ".log ");
                    }
                    else
                    {
                        m_iComentario = "Ocurrio un error al cancelar el documento... Vaya a los siguientes archivos para saber la razon del error de timbrado : " + documentoTimbrado + ".log ";
                    }
                    retorno = false;

                }
                else
                {*/

                string text = System.IO.File.ReadAllText(outputFile); //"UUID CANCELADO CORRECTAMENTE";
                string uuidCancelacion = "";


                if (text.ToUpper().Contains("UUID CANCELADO CORRECTAMENTE"))
                {
                    retorno = true;
                    string[] splitbuffer = text.Split(new string[] { "en el UUID:" }, StringSplitOptions.RemoveEmptyEntries);
                    if (splitbuffer.Length >= 2)
                    {
                        uuidCancelacion = splitbuffer[1].Replace(";", "").Replace("\n", "").Replace(" ", "");
                    }
                    m_Docto.ITIMBRADOCANCELADO = "S";
                    m_Docto.ITIMBRADOUUIDCANCELACION = uuidCancelacion;
                    m_Docto.ITIMBRADOFECHACANCELACION = DateTime.Now;
                    doctoD.ACTUALIZARCANCELACIONENSAT(m_Docto, null);

                }
                else if (text.ToUpper().Contains("UUID PREVIAMENTE CANCELADO"))
                {
                    retorno = true;
                    m_Docto.ITIMBRADOCANCELADO = "S";
                    m_Docto.ITIMBRADOUUIDCANCELACION = uuidCancelacion;
                    m_Docto.ITIMBRADOFECHACANCELACION = DateTime.Now;
                    doctoD.ACTUALIZARCANCELACIONENSAT(m_Docto, null);
                    Process.Start("notepad.exe", outputFile);
                }
                else
                {
                    retorno = false;
                    Process.Start("notepad.exe", outputFile);
                }

                //MessageBox.Show("No se cancelo nada en el SAT porque al parecer es una factura de prueba ");
                //retorno = false;
                //}
            }
            catch (Exception ex)
            {

                if (!m_silentMode)
                {
                    MessageBox.Show("Ocurrio un error al cancelar el documento..." + ex.Message);
                }
                else
                {
                    m_iComentario = "Ocurrio un error al cancelar el documento..." + ex.Message;
                }
                //Process.Start("notepad.exe", documentoTimbrado + ".log");
                retorno = false;
            }

            if (mivar != 0)
            {
                try
                {
                    //CiberPAC_Free(mivar);
                }
                catch
                {

                }
            }

            return retorno;
        }




        private bool ObtenerDatosDelTimbrado(string documentoTimbrado)
        {

            //file name

            //create new instance of XmlDocument
            XmlDocument doc = new XmlDocument();
            //load from file
            doc.Load(documentoTimbrado);

            XmlNamespaceManager nsmRequest = new XmlNamespaceManager(doc.NameTable);
            nsmRequest.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3");
            nsmRequest.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");
            //CiberSAT5
            XmlNode TimbreFiscalNode = doc.SelectSingleNode("//cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital", nsmRequest);
            XmlElement elmTimbreFiscalNode = (XmlElement)TimbreFiscalNode;
            //m_returnUUID = elmTimbreFiscalNode.GetAttribute("UUID");
            //m_returnFechaTimbrado = elmTimbreFiscalNode.GetAttribute("FechaTimbrado");
            //m_returnCertSAT = elmTimbreFiscalNode.GetAttribute("noCertificadoSAT");


            CDOCTOD doctoD = new CDOCTOD();
            m_Docto.ITIMBRADOUUID = elmTimbreFiscalNode.GetAttribute("UUID");
            m_Docto.ITIMBRADOFECHA = elmTimbreFiscalNode.GetAttribute("FechaTimbrado");
            m_Docto.ITIMBRADOCERTSAT = elmTimbreFiscalNode.GetAttribute("noCertificadoSAT"); ;
            m_Docto.ITIMBRADOSELLOCFDI = elmTimbreFiscalNode.GetAttribute("selloCFD");
            m_Docto.ITIMBRADOSELLOSAT = elmTimbreFiscalNode.GetAttribute("selloSAT");
            m_Docto.IFECHA = m_Docto.ITIMBRADOFECHAFACTURA != null ? m_Docto.ITIMBRADOFECHAFACTURA : DateTime.Today;
            m_Docto.IFECHAHORA = m_Docto.ITIMBRADOFECHAFACTURA != null ? m_Docto.ITIMBRADOFECHAFACTURA : DateTime.Now;

            if (m_pagotemporal)
                m_Docto.IDOCTOPAGOSAT = 0;
            else
                m_Docto.IDOCTOPAGOSAT = m_doctoPago.IID;

            m_Docto.ITIMBRADOFORMAPAGOSAT = m_nombreFormaPago;

            if (!doctoD.CambiarTIMBRADODOCTOD(m_Docto, m_Docto, m_fTrans))
                return false;



            CEXP_FILESD expFileD = new CEXP_FILESD();
            CEXP_FILESBE expFile = new CEXP_FILESBE();

            switch (m_Docto.ITIPODOCTOID)
            {
                case DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO: expFile.ITIPO = DBValues._EXP_FILES_TIPO_DEVOLUCIONELECTRONICA_XML; break;
                case DBValues._DOCTO_TIPO_RECIBOELECTRONICO: expFile.ITIPO = DBValues._EXP_FILES_TIPO_ABONOSELECTRONICOS_XML; break;
                default: expFile.ITIPO = DBValues._EXP_FILES_TIPO_FACTURAELECTRONICA_XML; break;
            }

            expFile.INOMBRE = Path.GetFileName(documentoTimbrado);
            expFile.IARCHIVOFTP = Path.GetFileName(documentoTimbrado);
            expFile.IFECHA = DateTime.Now;
            expFile.IESTATUS = DBValues._EXP_FILES_ESTATUS_GENERADO;
            expFile.IDOCTOID = m_Docto.IID;
            expFile.IDOCTOFOLIO = m_currentFolioSat;
            expFile.IDOCTOSERIE = m_currentSerieSat;
            expFile.ITIPODOCTOID = m_Docto.ITIPODOCTOID;


            expFileD.AgregarEXP_FILESD(expFile, m_fTrans);

            return true;
        }



        private bool ObtenerDatosDelTimbrado33(string documentoTimbrado, string tipoComprobante )
        {

            //file name

            //create new instance of XmlDocument
            XmlDocument doc = new XmlDocument();
            //load from file
            doc.Load(documentoTimbrado);

            XmlNamespaceManager nsmRequest = new XmlNamespaceManager(doc.NameTable);

            if(m_empresa.IVERSIONCFDI.Equals(VersionesFacturacion.V40))
                nsmRequest.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/4");
            else
                nsmRequest.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3");

            nsmRequest.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");
            //CiberSAT5
            XmlNode TimbreFiscalNode = doc.SelectSingleNode("//cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital", nsmRequest);
            XmlElement elmTimbreFiscalNode = (XmlElement)TimbreFiscalNode;
            //m_returnUUID = elmTimbreFiscalNode.GetAttribute("UUID");
            //m_returnFechaTimbrado = elmTimbreFiscalNode.GetAttribute("FechaTimbrado");
            //m_returnCertSAT = elmTimbreFiscalNode.GetAttribute("noCertificadoSAT");

            // some special treatement according to tipocomprobante
            switch(tipoComprobante)
            {

                case "T":

                    CDOCTOCOMPROBANTED comprobanteD = new CDOCTOCOMPROBANTED();
                    CDOCTOCOMPROBANTEBE comprobanteBE = new CDOCTOCOMPROBANTEBE();
                    comprobanteBE.IACTIVO = "S";
                    comprobanteBE.ICREADOPOR_USERID = CurrentUser.m_IdUserId;
                    comprobanteBE.IMODIFICADOPOR_USERID = CurrentUser.m_IdUserId;
                    comprobanteBE.IDOCTOID = m_Docto.IID;
                    comprobanteBE.ITIPOCOMPROBANTE = tipoComprobante;
                    comprobanteBE.ITIMBRADOUUID = elmTimbreFiscalNode.GetAttribute("UUID");
                    comprobanteBE.ITIMBRADOFECHA = elmTimbreFiscalNode.GetAttribute("FechaTimbrado");
                    comprobanteBE.ITIMBRADOCERTSAT = elmTimbreFiscalNode.GetAttribute("NoCertificadoSAT"); ;
                    comprobanteBE.ITIMBRADOSELLOCFDI = elmTimbreFiscalNode.GetAttribute("SelloCFD");
                    comprobanteBE.ITIMBRADOSELLOSAT = elmTimbreFiscalNode.GetAttribute("SelloSAT");

                    comprobanteD.CambiarxDOCTOyTIPOCOMPR(comprobanteBE,m_fTrans);


                    break;

                default:

                    CDOCTOD doctoD = new CDOCTOD();
                    m_Docto.ITIMBRADOUUID = elmTimbreFiscalNode.GetAttribute("UUID");
                    m_Docto.ITIMBRADOFECHA = elmTimbreFiscalNode.GetAttribute("FechaTimbrado");
                    m_Docto.ITIMBRADOCERTSAT = elmTimbreFiscalNode.GetAttribute("NoCertificadoSAT"); ;
                    m_Docto.ITIMBRADOSELLOCFDI = elmTimbreFiscalNode.GetAttribute("SelloCFD");
                    m_Docto.ITIMBRADOSELLOSAT = elmTimbreFiscalNode.GetAttribute("SelloSAT");
                    m_Docto.IFECHA = m_Docto.ITIMBRADOFECHAFACTURA != null ? m_Docto.ITIMBRADOFECHAFACTURA : DateTime.Today;
                    m_Docto.IFECHAHORA = m_Docto.ITIMBRADOFECHAFACTURA != null ? m_Docto.ITIMBRADOFECHAFACTURA : DateTime.Now;

                    if (m_pagotemporal)
                        m_Docto.IDOCTOPAGOSAT = 0;
                    else
                    {
                        if (m_doctoPago != null)
                            m_Docto.IDOCTOPAGOSAT = m_doctoPago.IID;
                    }

                    m_Docto.ITIMBRADOFORMAPAGOSAT = m_nombreFormaPago;

                    if (!doctoD.CambiarTIMBRADODOCTOD(m_Docto, m_Docto, m_fTrans))
                        return false;
                    
                    break;
            }


            CEXP_FILESD expFileD = new CEXP_FILESD();
            CEXP_FILESBE expFile = new CEXP_FILESBE();


            if(tipoComprobante == "T")
            {
                expFile.ITIPO = DBValues._EXP_FILES_TIPO_COMPROBANTETRASLADO_XML;
            }
            else
            {
                switch (m_Docto.ITIPODOCTOID)
                {
                    case DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO: expFile.ITIPO = DBValues._EXP_FILES_TIPO_DEVOLUCIONELECTRONICA_XML; break;
                    case DBValues._DOCTO_TIPO_RECIBOELECTRONICO: expFile.ITIPO = DBValues._EXP_FILES_TIPO_ABONOSELECTRONICOS_XML; break;
                    default: expFile.ITIPO = DBValues._EXP_FILES_TIPO_FACTURAELECTRONICA_XML; break;
                }

            }


            expFile.INOMBRE = Path.GetFileName(documentoTimbrado);
            expFile.IARCHIVOFTP = Path.GetFileName(documentoTimbrado);
            expFile.IFECHA = DateTime.Now;
            expFile.IESTATUS = DBValues._EXP_FILES_ESTATUS_GENERADO;
            expFile.IDOCTOID = m_Docto.IID;
            expFile.IDOCTOFOLIO = m_currentFolioSat;
            expFile.IDOCTOSERIE = m_currentSerieSat;
            expFile.ITIPODOCTOID = m_Docto.ITIPODOCTOID;


            expFileD.AgregarEXP_FILESD(expFile, m_fTrans);


            return true;
        }



        private void getIvaToDisplay()
        {
            decimal decimalBuffer = 0;

            if (m_Docto.ITIPODOCTOID != DBValues._DOCTO_TIPO_RECIBOELECTRONICO)
            {
                foreach (DataRow dr in dSReportIpos2.REP_FACTURAELECTRONICA_DET)
                {

                    if (dr["PORCENTAJEIVA"] != null && dr["PORCENTAJEIVA"] != DBNull.Value)
                    {
                        decimalBuffer = (decimal)dr["PORCENTAJEIVA"];
                        if (decimalBuffer == 0 && !this.bShowIva0)
                        {
                            this.bShowIva0 = true;
                        }
                        else if (decimalBuffer == 16 && !this.bShowIva16)
                        {
                            this.bShowIva16 = true;
                        }
                        if (bShowIva0 && bShowIva16)
                            break;


                    }
                }
            }
            else
            {

                foreach (DataRow dr in dSReportIpos2.REP_FACTURAELECTRONICA_DET_REF)
                {

                    if (dr["PORCENTAJEIVA"] != null && dr["PORCENTAJEIVA"] != DBNull.Value)
                    {
                        decimalBuffer = (decimal)dr["PORCENTAJEIVA"];
                        if (decimalBuffer == 0 && !this.bShowIva0)
                        {
                            this.bShowIva0 = true;
                        }
                        else if (decimalBuffer == 16 && !this.bShowIva16)
                        {
                            this.bShowIva16 = true;
                        }
                        if (bShowIva0 && bShowIva16)
                            break;


                    }
                }
            }
        }


        private void getPiezasCajas(ref decimal cajas, ref decimal piezas)
        {
            CDOCTOD doctoD = new CDOCTOD();
            bool bRes = doctoD.GetPiezasCajasXDocto(m_Docto.IID, ref cajas, ref piezas, null);

        }

        private CSUCURSALBE getSucursalDestino()
        {

            if (!(bool)m_Docto.isnull["ISUCURSALTID"])
            {
                CSUCURSALBE retorno = new CSUCURSALBE();
                CSUCURSALD sucursalD = new CSUCURSALD();
                retorno.IID = m_Docto.ISUCURSALTID;
                retorno = sucursalD.seleccionarSUCURSAL(retorno, null);
                return retorno;
            }
            return null;
        }

        private string GetRutaEmbarqueClave(long rutaEmbarqueId)
        {

            if (rutaEmbarqueId > 0)
            {
                CRUTAEMBARQUED rutaEmbarqueD = new CRUTAEMBARQUED();
                CRUTAEMBARQUEBE rutaEmbarqueBE = new CRUTAEMBARQUEBE();
                rutaEmbarqueBE.IID = rutaEmbarqueId;
                rutaEmbarqueBE = rutaEmbarqueD.seleccionarRUTAEMBARQUE(rutaEmbarqueBE, null);


                if (rutaEmbarqueBE != null && rutaEmbarqueBE.ICLAVE != null)
                {
                    return rutaEmbarqueBE.ICLAVE;
                }

            }

            return "";
        }

        private bool GeneratePDF(string documentoPDF, string tipoComprobante)
        {
            //actualiza el docto
            CDOCTOD doctoD = new CDOCTOD();
            m_Docto = doctoD.seleccionarDOCTO(m_Docto, null);

            //Aqui va la condicion para ver si es RDLC o FastReport
            //GeneratePDFRDLC(documentoPDF);
            if (m_empresa.IFORMATOFACTELECT != null && m_empresa.IFORMATOFACTELECT.Equals(DBValues._FORMATOFACTELECT_FASTREPORT))
            {
                //if(m_Docto.ICFDIID > 0)
                    return GeneratePDFFastReport33(documentoPDF, tipoComprobante);
                //else
                //    return GeneratePDFFastReport(documentoPDF, tipoComprobante);

            }
            else
            {
                return GeneratePDFRDLC(documentoPDF);
            }



        }

        private bool GeneratePDFFastReport(string documentoPDF, string tipoComprobante = "")
        {
            
            var prefixComprobante = obtainPrefixByTipoComprobante(tipoComprobante);

            DefinirDatosEntrega();
            CSUCURSALBE sucursalDestino = getSucursalDestino();

            decimal totalPiezas = 0, totalCajas = 0;
            getPiezasCajas(ref totalCajas, ref totalPiezas);


            //tipo de cambio
            CMONEDABE monedaBE = new CMONEDABE();
            monedaBE.ICLAVE = "MN";

            if (m_Docto.IMONEDAID != DBValues._MONEDA_PESOS)
            {

                //tipo de cambio
                CMONEDAD monedaD = new CMONEDAD();
                monedaBE.IID = ((bool)m_Docto.isnull["IMONEDAID"] || m_Docto.IMONEDAID == 0) ? DBValues._MONEDA_PESOS : m_Docto.IMONEDAID;
                monedaBE = monedaD.seleccionarMONEDA(monedaBE, m_fTrans);
                if (monedaBE == null)
                {
                    monedaBE = new CMONEDABE();
                    monedaBE.ICLAVE = "MN";
                }
            }
            string moneda = monedaBE.ICLAVE;
            if (!moneda.Equals("MN"))
            {
                moneda = moneda + " T.C. " + monedaBE.ITIPOCAMBIO.ToString("#,##0.00");
            }

            try
            {

                try
                {



                    decimal tipoCambio = (((bool)m_Docto.isnull["ITIPOCAMBIO"] || m_Docto.ITIPOCAMBIO == 0) ? 1 : m_Docto.ITIPOCAMBIO);


                    CCLIENTEBE clienteBE = new CCLIENTEBE();
                    CPERSONAD personaD = new CPERSONAD();
                    clienteBE.m_PersonaBE.IID = m_Docto.IPERSONAID;
                    clienteBE.m_PersonaBE = personaD.seleccionarPERSONA(clienteBE.m_PersonaBE, m_fTrans);

                    string rutaEmbarqueClave = GetRutaEmbarqueClave(m_Docto.IRUTAEMBARQUEID);

                    CMOVTOD movtoD = new CMOVTOD();
                    ArrayList listIEPS =
                            m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_RECIBOELECTRONICO ?
                                 this.DOCTOIEPS_RECIBO(m_Docto.IID, clienteBE) :
                                 movtoD.DOCTOIEPSVIEW(m_Docto.IID, null);



                    ////////// forma de pago credito evitarla
                    String referenciaCredito = "";
                    string strCuentaPago = "N / A";
                    string nombreFormaPagoConDesc = "";
                    m_nombreFormaPago = formaPagoTratandoEvitarPagoOtros(clienteBE, m_nombreFormaPago, m_doctoPago, ref referenciaCredito);
                    nombreFormaPagoConDesc = formaPagoConDescripcion(m_nombreFormaPago, m_fTrans);


                    if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_RECIBOELECTRONICO && m_doctoPago.ICUENTAPAGOCREDITO != null && m_doctoPago.ICUENTAPAGOCREDITO.Trim().Length > 0)
                    {
                        strCuentaPago = m_doctoPago.ICUENTAPAGOCREDITO;
                    }
                    else if (this.m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_CHEQUE || this.m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_TARJETA || this.m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_TRANSFERENCIA)
                    {
                        strCuentaPago = this.m_doctoPago.IREFERENCIABANCARIA;
                    }
                    else if (this.m_doctoPago.IFORMAPAGOID == 4 && !referenciaCredito.Equals(""))
                    {
                        strCuentaPago = referenciaCredito;
                    }

                    string bufferNumCSD = Path.GetFileName(m_empresa.ITIMBRADOARCHIVOCERTIFICADO);





                    FastReport.Report report1 = new FastReport.Report();
                    report1.Load(FastReportsConfigReport.getPathForFile("RptFacturaElectronica.frx", FastReportsConfigTipoFile.desistema));
                    report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
                    report1.SetParameterValue("US_ID", ConexionesBD.ConexionBD.CurrentUser.IID);
                    report1.SetParameterValue("US_NAME", ConexionesBD.ConexionBD.CurrentUser.IID);


                    report1.SetParameterValue("doctoId", m_Docto.IID);
                    //Aqui llenas todos los parametros


                    string strBuffer;
                    report1.SetParameterValue("num_serie_cert_csd", bufferNumCSD.Substring(0, bufferNumCSD.Length - 4).ToUpper());



                    report1.SetParameterValue("uuid", m_Docto.ITIMBRADOUUID);
                    report1.SetParameterValue("FechaTimbrado", m_Docto.ITIMBRADOFECHA);
                    report1.SetParameterValue("noCertificadoSAT", m_Docto.ITIMBRADOCERTSAT); ;
                    report1.SetParameterValue("selloCFD", m_Docto.ITIMBRADOSELLOCFDI);
                    report1.SetParameterValue("selloSAT", m_Docto.ITIMBRADOSELLOSAT);

                    report1.SetParameterValue("subTotal", (clienteBE.m_PersonaBE.IDESGLOSEIEPS.Equals("S") && m_empresa.IDESGLOSEIEPS.Equals("S")) ? (m_Docto.ISUBTOTAL / tipoCambio).ToString("#,##0.00") : ((m_Docto.ISUBTOTAL + m_Docto.IIEPS) / tipoCambio).ToString("#,##0.00")); ;
                    report1.SetParameterValue("iva", (m_Docto.IIVA / tipoCambio).ToString("#,##0.00"));



                    decimal Total = m_Docto.ITOTAL - m_Docto.IIVARETENIDO - m_Docto.IISRRETENIDO;

                    report1.SetParameterValue("Total", (Total / tipoCambio).ToString("#,##0.00"));



                    report1.SetParameterValue("clienteClave", clienteBE.m_PersonaBE.ICLAVE);
                    report1.SetParameterValue("sucursal", (!(bool)m_empresa.isnull["IFISCALNOMBRE"]) ? m_empresa.IFISCALNOMBRE : m_empresa.INOMBRE);



                    DateTime fechaVence = m_Docto.IFECHA.AddDays((bool)clienteBE.m_PersonaBE.isnull["IDIAS"] ? 0 : clienteBE.m_PersonaBE.IDIAS);

                    if (!(bool)m_Docto.isnull["IVENCE"])
                    {
                        fechaVence = m_Docto.IVENCE;
                    }
                    report1.SetParameterValue("fechaVencimiento", fechaVence.ToString("dd/MM/yyyy"));
                    report1.SetParameterValue("serie", m_Docto.ISERIESAT);


                    strBuffer = "";
                    if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO)
                    {
                        if (m_DoctoRef != null)
                            strBuffer = m_DoctoRef.IFOLIO.ToString("0");
                    }
                    else
                    {
                        strBuffer = m_Docto.IFOLIO.ToString("0");
                    }
                    report1.SetParameterValue("ventaFolio", strBuffer);


                    report1.SetParameterValue("metodoPago", nombreFormaPagoConDesc);
                    report1.SetParameterValue("cuentaPago", strCuentaPago);

                    report1.SetParameterValue("clienteNombre", clienteBE.m_PersonaBE.INOMBRES + " " + clienteBE.m_PersonaBE.IAPELLIDOS);
                    report1.SetParameterValue("clienteColonia", clienteBE.m_PersonaBE.ICOLONIA);
                    report1.SetParameterValue("clienteMunicipio", clienteBE.m_PersonaBE.ICIUDAD);
                    report1.SetParameterValue("clienteCodigoPostal", clienteBE.m_PersonaBE.ICODIGOPOSTAL);
                    report1.SetParameterValue("clienteEstado", clienteBE.m_PersonaBE.IESTADO);
                    report1.SetParameterValue("clienteRFC", clienteBE.m_PersonaBE.IRFC);


                    report1.SetParameterValue("clientePais", clienteBE.m_PersonaBE.IPAIS == null || clienteBE.m_PersonaBE.IPAIS.Trim().Length == 0 ? "MEXICO" : clienteBE.m_PersonaBE.IPAIS);
                    report1.SetParameterValue("clienteLocalidad", clienteBE.m_PersonaBE.ILOCALIDAD);
                    report1.SetParameterValue("clienteReferenciaDom", clienteBE.m_PersonaBE.IREFERENCIADOM);
                    report1.SetParameterValue("rutaEmbarque", rutaEmbarqueClave != null && rutaEmbarqueClave.Trim().Length > 0 ? "Ruta " + rutaEmbarqueClave : "");

                    report1.SetParameterValue("ordenCompra", m_Docto.IORDENCOMPRA != null && m_Docto.IORDENCOMPRA.Trim().Length > 0 ? "Orden de compra " + m_Docto.IORDENCOMPRA : "");


                    if (sucursalDestino != null)
                    {

                        report1.SetParameterValue("entregaDireccion", sucursalDestino.IENTREGACALLE +
                                                                                                    " Ext. " + sucursalDestino.IENTREGANUMEROEXTERIOR
                                                                                                    + (((bool)sucursalDestino.isnull["IENTREGANUMEROINTERIOR"] || sucursalDestino.IENTREGANUMEROINTERIOR.Trim() == "") ? "" : " , Int. " + sucursalDestino.IENTREGANUMEROINTERIOR));

                        report1.SetParameterValue("entregaColonia", sucursalDestino.IENTREGACOLONIA);
                        report1.SetParameterValue("entregaMunicipio", sucursalDestino.IENTREGAMUNICIPIO);
                        report1.SetParameterValue("entregaCodigoPostal", sucursalDestino.IENTREGACODIGOPOSTAL);
                        report1.SetParameterValue("entregaEstado", sucursalDestino.IENTREGAESTADO);
                        report1.SetParameterValue("entregaPais", "México");

                    }
                    else
                    {

                        if (!m_usaDatosDeEntregaCuandoExista || (bool)clienteBE.m_PersonaBE.isnull["IENTREGACALLE"] || clienteBE.m_PersonaBE.IENTREGACALLE.Trim().Equals(""))
                        {
                            report1.SetParameterValue("entregaDireccion", clienteBE.m_PersonaBE.IDOMICILIO +
                                                                                                        " Ext. " + clienteBE.m_PersonaBE.INUMEROEXTERIOR
                                                                                                        + (((bool)clienteBE.m_PersonaBE.isnull["INUMEROINTERIOR"] || clienteBE.m_PersonaBE.INUMEROINTERIOR.Trim() == "") ? "" : " , Int. " + clienteBE.m_PersonaBE.INUMEROINTERIOR));

                            report1.SetParameterValue("entregaColonia", clienteBE.m_PersonaBE.ICOLONIA);
                            report1.SetParameterValue("entregaMunicipio", clienteBE.m_PersonaBE.ICIUDAD);
                            report1.SetParameterValue("entregaCodigoPostal", clienteBE.m_PersonaBE.ICODIGOPOSTAL);
                            report1.SetParameterValue("entregaEstado", clienteBE.m_PersonaBE.IESTADO);
                            report1.SetParameterValue("entregaPais", clienteBE.m_PersonaBE.IPAIS == null || clienteBE.m_PersonaBE.IPAIS.Trim().Length == 0 ? "MEXICO" : clienteBE.m_PersonaBE.IPAIS);
                        }
                        else
                        {

                            report1.SetParameterValue("entregaDireccion", clienteBE.m_PersonaBE.IENTREGACALLE +
                                                                                                        " Ext. " + clienteBE.m_PersonaBE.IENTREGANUMEROEXTERIOR
                                                                                                        + (((bool)clienteBE.m_PersonaBE.isnull["IENTREGANUMEROINTERIOR"] || clienteBE.m_PersonaBE.IENTREGANUMEROINTERIOR.Trim() == "") ? "" : " , Int. " + clienteBE.m_PersonaBE.IENTREGANUMEROINTERIOR));

                            report1.SetParameterValue("entregaColonia", clienteBE.m_PersonaBE.IENTREGACOLONIA);
                            report1.SetParameterValue("entregaMunicipio", clienteBE.m_PersonaBE.IENTREGAMUNICIPIO);
                            report1.SetParameterValue("entregaCodigoPostal", clienteBE.m_PersonaBE.IENTREGACODIGOPOSTAL);
                            report1.SetParameterValue("entregaEstado", clienteBE.m_PersonaBE.IENTREGAESTADO);
                            report1.SetParameterValue("entregaPais", clienteBE.m_PersonaBE.IPAIS == null || clienteBE.m_PersonaBE.IPAIS.Trim().Length == 0 ? "MEXICO" : clienteBE.m_PersonaBE.IPAIS);

                        }
                    }


                    if (m_empresa.IUSARFISCALESENEXPEDICION == "S")
                    {

                        report1.SetParameterValue("expedicionDireccion", m_empresa.IFISCALCALLE +
                                                                                                        " Ext. " + m_empresa.IFISCALNUMEROEXTERIOR
                                                                                                        + (((bool)m_empresa.isnull["IFISCALNUMEROINTERIOR"] || m_empresa.IFISCALNUMEROINTERIOR.Trim() == "") ? "" : " , Int. " + m_empresa.IFISCALNUMEROINTERIOR));
                        report1.SetParameterValue("expedicionColonia", m_empresa.IFISCALCOLONIA);
                        report1.SetParameterValue("expedicionMunicipio", m_empresa.IFISCALMUNICIPIO);
                        report1.SetParameterValue("expedicionCodigoPostal", m_empresa.IFISCALCODIGOPOSTAL);
                        report1.SetParameterValue("expedicionEstado", m_empresa.IFISCALESTADO);
                        report1.SetParameterValue("expedicionRFC", m_empresa.IRFC);
                    }
                    else
                    {
                        report1.SetParameterValue("expedicionDireccion", m_empresa.ICALLE +
                                                                                                         " Ext. " + m_empresa.INUMEROEXTERIOR
                                                                                                        + (((bool)m_empresa.isnull["INUMEROINTERIOR"] || m_empresa.INUMEROINTERIOR.Trim() == "") ? "" : " , Int. " + m_empresa.INUMEROINTERIOR));
                        report1.SetParameterValue("expedicionColonia", m_empresa.ICOLONIA);
                        report1.SetParameterValue("expedicionMunicipio", m_empresa.ILOCALIDAD);
                        report1.SetParameterValue("expedicionCodigoPostal", m_empresa.ICP);
                        report1.SetParameterValue("expedicionEstado", m_empresa.IESTADO);
                        report1.SetParameterValue("expedicionRFC", m_empresa.IRFC);
                    }

                    report1.SetParameterValue("fiscalDireccion", m_empresa.IFISCALCALLE +
                                                                                                    " Ext. " + m_empresa.IFISCALNUMEROEXTERIOR
                                                                                                    + (((bool)m_empresa.isnull["IFISCALNUMEROINTERIOR"] || m_empresa.IFISCALNUMEROINTERIOR.Trim() == "") ? "" : " , Int. " + m_empresa.IFISCALNUMEROINTERIOR));
                    report1.SetParameterValue("fiscalColonia", m_empresa.IFISCALCOLONIA);
                    report1.SetParameterValue("fiscalMunicipio", m_empresa.IFISCALMUNICIPIO);
                    report1.SetParameterValue("fiscalCodigoPostal", m_empresa.IFISCALCODIGOPOSTAL);
                    report1.SetParameterValue("fiscalEstado", m_empresa.IFISCALESTADO);
                    report1.SetParameterValue("fiscalRFC", m_empresa.IRFC);

                    string totalEnLetra = NumaletRpt.ToCardinal((Total / tipoCambio)).ToUpper();
                    if (tipoCambio != 1)
                    {
                        totalEnLetra = totalEnLetra.Replace("PESOS", "DOLARES");
                        totalEnLetra = totalEnLetra.Replace("M N", "USD");

                    }
                    report1.SetParameterValue("totalEnLetras", "(" + totalEnLetra + ")");
                    report1.SetParameterValue("cadenaOriginalSAT", "||1.0|" + m_Docto.ITIMBRADOUUID + "|" + m_Docto.ITIMBRADOFECHA + "|" + m_Docto.ITIMBRADOSELLOCFDI + "|" + m_Docto.ITIMBRADOCERTSAT + "||");


                    report1.SetParameterValue("imagenBicode", "file:///" + /*System.AppDomain.CurrentDomain.BaseDirectory +*/ getFileLocalLocation_FE_XML_Timbrados(m_Docto.ITIPODOCTOID, m_empresa, tipoComprobante) + "\\" + prefixComprobante + m_currentSerieSat + m_currentFolioSat.ToString() + ".xml.png");
                    report1.SetParameterValue("clienteDireccion", clienteBE.m_PersonaBE.IDOMICILIO +
                                                                                                    " Ext. " + clienteBE.m_PersonaBE.INUMEROEXTERIOR
                                                                                                    + (((bool)clienteBE.m_PersonaBE.isnull["INUMEROINTERIOR"] || clienteBE.m_PersonaBE.INUMEROINTERIOR.Trim() == "") ? "" : " , Int. " + clienteBE.m_PersonaBE.INUMEROINTERIOR));


                    report1.SetParameterValue("nombreFiscal", m_empresa.IFISCALNOMBRE);

                    report1.SetParameterValue("hidePagare", (this.m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_CREDITO) ? false.ToString() : true.ToString());
                    report1.SetParameterValue("hideIva0", (!bShowIva0).ToString());
                    report1.SetParameterValue("hideIva16", (!bShowIva16).ToString());

                    report1.SetParameterValue("folioFactElec", m_currentFolioSat.ToString("0"));

                    report1.SetParameterValue("logoEmpresa", "file:///" /*+ System.AppDomain.CurrentDomain.BaseDirectory*/ + getFileLocalLocation_FE_IMG(m_empresa) + "\\logofarmafree.png");


                    report1.SetParameterValue("tipoDocumento", (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_DEVCONSOLIDADA) ? "DEVOLUCION" : ((m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_RECIBOELECTRONICO) ? "COMPROBANTE DE ABONO" : "FACTURA"));



                    report1.SetParameterValue("regimenFiscal", m_empresa.IFISCALREGIMEN);


                    report1.SetParameterValue("ivaRetenido", (m_Docto.IIVARETENIDO / tipoCambio).ToString("#,##0.00"));
                    report1.SetParameterValue("isrRetenido", (m_Docto.IISRRETENIDO / tipoCambio).ToString("#,##0.00"));

                    report1.SetParameterValue("hideIvaRetenido", (clienteBE.m_PersonaBE.IRETIENEIVA.Equals("S")) ? false.ToString() : true.ToString());
                    report1.SetParameterValue("hideIsrRetenido", (clienteBE.m_PersonaBE.IRETIENEISR.Equals("S")) ? false.ToString() : true.ToString());
                    report1.SetParameterValue("hideReciboHonorarios", (clienteBE.m_PersonaBE.IRETIENEISR.Equals("S") || clienteBE.m_PersonaBE.IRETIENEIVA.Equals("S")) ? false.ToString() : true.ToString());



                    bool bEsArrendatario = !(bool)m_empresa.isnull["IARRENDATARIO"] && m_empresa.IARRENDATARIO.Equals("S");
                    bool bHayCuentasPrediales = false;

                    if (bEsArrendatario)
                    {
                        foreach (DataRow dr in this.dSReportIpos2.REP_FACTURAELECTRONICA_DET.Rows)
                        {
                            if (!(bool)m_empresa.isnull["IARRENDATARIO"] && m_empresa.IARRENDATARIO.Equals("S") && dr["CUENTAPREDIAL"] != DBNull.Value && dr["CUENTAPREDIAL"].ToString().Trim().Length > 0)
                            {
                                bHayCuentasPrediales = true;
                                break;
                            }
                        }
                    }

                    if (bEsArrendatario && !bHayCuentasPrediales)
                    {

                        report1.SetParameterValue("tipoRecibo", "");
                        report1.SetParameterValue("hideDatosEntrega", false.ToString());
                        report1.SetParameterValue("hideCtaPredial", true.ToString());
                    }
                    else if (!(bool)m_empresa.isnull["IARRENDATARIO"])
                    {
                        report1.SetParameterValue("tipoRecibo", bEsArrendatario ? "Recibo arrendatario" : "Recibo de honorarios");
                        report1.SetParameterValue("hideDatosEntrega", bEsArrendatario ? true.ToString() : false.ToString());
                        report1.SetParameterValue("hideCtaPredial", bEsArrendatario ? false.ToString() : true.ToString());
                    }
                    else
                    {
                        report1.SetParameterValue("tipoRecibo", "Recibo de honorarios");
                        report1.SetParameterValue("hideDatosEntrega", false.ToString());
                        report1.SetParameterValue("hideCtaPredial", true.ToString());
                    }


                    if (!(bool)m_empresa.isnull["IMOSTRARDESCUENTOFACTURA"])
                    {
                        report1.SetParameterValue("hideDescuento", m_empresa.IMOSTRARDESCUENTOFACTURA.Equals("S") ? false.ToString() : true.ToString());
                    }
                    else
                    {
                        report1.SetParameterValue("hideDescuento", false.ToString());
                    }


                    report1.SetParameterValue("vendedorcliente", "");


                    report1.SetParameterValue("hidePzaCaja", m_empresa.IMOSTRARPZACAJAENFACTURA.Equals("S") ? false.ToString() : true.ToString());

                    if (!(bool)clienteBE.m_PersonaBE.isnull["IVENDEDORID"])
                    {
                        CPERSONABE vendedor = new CPERSONABE();
                        vendedor.IID = clienteBE.m_PersonaBE.IVENDEDORID;
                        vendedor = personaD.seleccionarPERSONA(vendedor, null);
                        if (vendedor != null)
                        {
                            report1.SetParameterValue("vendedorcliente", vendedor.INOMBRES + " " + vendedor.IAPELLIDOS);
                        }
                    }


                    report1.SetParameterValue("moneda", moneda);



                    if (!(bool)m_empresa.isnull["IDESGLOSEIEPS"])
                    {
                        report1.SetParameterValue("hideIEPSDetalle", m_empresa.IDESGLOSEIEPS.Equals("S") ? false.ToString() : true.ToString());
                    }
                    else
                    {
                        report1.SetParameterValue("hideIEPSDetalle", false.ToString());
                    }

                    int iIEPS = 0;

                    for (iIEPS = 0; iIEPS < 6; iIEPS++)
                    {
                        report1.SetParameterValue("hideIEPS" + (iIEPS + 1).ToString("N0"), true.ToString());
                        report1.SetParameterValue("porcIEPS" + (iIEPS + 1).ToString("N0"), "0.00");
                        report1.SetParameterValue("IEPS" + (iIEPS + 1).ToString("N0"), "0.00");
                    }



                    if (!(bool)m_empresa.isnull["IDESGLOSEIEPS"] && clienteBE.m_PersonaBE.IDESGLOSEIEPS.Equals("S") && m_empresa.IDESGLOSEIEPS.Equals("S"))
                    {
                        iIEPS = 0;
                        decimal IEPSAcumulado = 0;
                        foreach (Hashtable ht in listIEPS)
                        {

                            // cuando ya haya muchos I
                            if (iIEPS <= 4)
                            {

                                report1.SetParameterValue("hideIEPS" + (iIEPS + 1).ToString("N0"), false.ToString());
                                if (ht.ContainsKey("TASAIEPS"))
                                {
                                    report1.SetParameterValue("porcIEPS" + (iIEPS + 1).ToString("N0"), ((decimal)(ht["TASAIEPS"])).ToString("#,##0.00"));
                                }

                                if (ht.ContainsKey("SUMAIEPS"))
                                {
                                    report1.SetParameterValue("IEPS" + (iIEPS + 1).ToString("N0"), ((decimal)(ht["SUMAIEPS"])).ToString("#,##0.00"));
                                }
                                IEPSAcumulado += ((decimal)(ht["SUMAIEPS"]));

                            }
                            else
                            {

                                report1.SetParameterValue("hideIEPS" + (iIEPS + 1).ToString("N0"), false.ToString());
                                if (ht.ContainsKey("TASAIEPS"))
                                {
                                    report1.SetParameterValue("porcIEPS" + (iIEPS + 1).ToString("N0"), "(otros)");
                                }

                                if (ht.ContainsKey("SUMAIEPS"))
                                {
                                    report1.SetParameterValue("IEPS" + (iIEPS + 1).ToString("N0"), (m_Docto.IIEPS - IEPSAcumulado).ToString("#,##0.00"));
                                }
                                break;
                            }

                            iIEPS++;
                        }
                    }


                    report1.SetParameterValue("clienteDesglosaIEPS", (clienteBE.m_PersonaBE.IDESGLOSEIEPS.Equals("S")) ? true.ToString() : false.ToString());
                    report1.SetParameterValue("empresaDesglosaIEPS", (m_empresa.IDESGLOSEIEPS.Equals("S")) ? true.ToString() : false.ToString());

                    report1.SetParameterValue("notaPago", (!(bool)m_Docto.isnull["INOTAPAGO"] && m_Docto.INOTAPAGO.Trim().Length > 0) ? "Nota: " + m_Docto.INOTAPAGO : "");

                    report1.SetParameterValue("tipoCambioTexto", (tipoCambio != 1) ? "T.C. " + tipoCambio.ToString("#,##0.00") : "");


                    if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO && !(bool)m_Docto.isnull["IDOCTOREFID"])
                    {

                        CDOCTOD doctoD = new CDOCTOD();
                        CDOCTOBE doctoRef = new CDOCTOBE();
                        doctoRef.IID = m_Docto.IDOCTOREFID;
                        doctoRef = doctoD.seleccionarDOCTO(doctoRef, null);

                        if (doctoRef != null && !(bool)doctoRef.isnull["IFOLIO"] && !(bool)doctoRef.isnull["IFOLIOSAT"] && !(bool)doctoRef.isnull["ISERIESAT"])
                            report1.SetParameterValue("foliopadre", "Devolucion de venta: " + doctoRef.IFOLIO.ToString() + " Folio Sat: " + doctoRef.IFOLIOSAT.ToString("N0") + doctoRef.ISERIESAT);
                        else
                            report1.SetParameterValue("foliopadre", "");

                    }
                    if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO && !(bool)m_Docto.isnull["IDOCTOREFID"])
                    {

                        CDOCTOD doctoD = new CDOCTOD();
                        CDOCTOBE doctoRef = new CDOCTOBE();
                        doctoRef.IID = m_Docto.IDOCTOREFID;
                        doctoRef = doctoD.seleccionarDOCTO(doctoRef, null);


                        if (doctoRef != null && !(bool)doctoRef.isnull["IFOLIO"])
                        {
                            string strBuffer2 = "Traspaso con venta: " + doctoRef.IFOLIO.ToString();
                            if (!(bool)doctoRef.isnull["IFOLIOSAT"] && !(bool)doctoRef.isnull["ISERIESAT"])
                                strBuffer2 += " Folio Sat: " + doctoRef.IFOLIOSAT.ToString("N0") + doctoRef.ISERIESAT;

                            report1.SetParameterValue("foliopadre", strBuffer2);
                        }
                        else
                            report1.SetParameterValue("foliopadre", "");

                    }
                    if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_RECIBOELECTRONICO && !(bool)m_Docto.isnull["IDOCTOREFID"])
                    {

                        CDOCTOD doctoD = new CDOCTOD();
                        CDOCTOBE doctoRef = new CDOCTOBE();
                        doctoRef.IID = m_Docto.IDOCTOREFID;
                        doctoRef = doctoD.seleccionarDOCTO(doctoRef, null);
                        if (doctoRef != null && !(bool)doctoRef.isnull["IFOLIO"])
                            report1.SetParameterValue("foliopadre", "Comprobante de abono de venta: " + doctoRef.IFOLIO.ToString());
                        else
                            report1.SetParameterValue("foliopadre", "");

                    }
                    else
                    {
                        report1.SetParameterValue("foliopadre", "");
                    }

                    report1.SetParameterValue("desgloseKits", this.bDeslosaKits.ToString());

                    report1.SetParameterValue("formaPago", (clienteBE.m_PersonaBE.IPAGOPARCIALIDADES.Equals("S") ? "PAGO EN PARCIALIDADES" : "PAGO EN UNA SOLA EXHIBICION"));



                    Image bitmap = global::iPosReporting.Properties.Resources.CANCELADA_G;
                    string strImgCanc = ConvertImageToBase64(bitmap, ImageFormat.Png);
                    report1.SetParameterValue("bgImage", m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_CANCELADA ? strImgCanc : null);


                    //fijar texto footer como parametro
                    if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA &&
                        !(bool)m_empresa.isnull["IFOOTER"] &&
                        m_empresa.IFOOTER != "")
                    {
                        //fijar subcadenas a sustituir en el footer
                        Dictionary<string, string> subcadenasASustituir = FijarSubcadenasASustituir();

                        //reemplazar subcadenas en footer
                        string footer = SustituirSubcadenas(m_empresa.IFOOTER, subcadenasASustituir);

                        //fijar como parametro en reporte
                        report1.SetParameterValue("textoFooter", footer);
                    }
                    else
                    {
                        report1.SetParameterValue("textoFooter", String.Empty);
                    }


                    report1.SetParameterValue("cajas", totalCajas.ToString());
                    report1.SetParameterValue("piezas", totalPiezas.ToString());


                    if (report1.Prepare())
                    {
                        FastReport.Export.Pdf.PDFExport pdfExport = null;
                        pdfExport = new FastReport.Export.Pdf.PDFExport();

                        pdfExport.Export(report1, documentoPDF);
                    }



                    this.Close();
                }
                catch (Exception ex)
                {
                    if (!m_silentMode)
                        MessageBox.Show(ex.Message);
                    else
                        this.Close();
                }





                CEXP_FILESD expFileD = new CEXP_FILESD();
                CEXP_FILESBE expFile = new CEXP_FILESBE();

                if (tipoComprobante == "T")
                {
                    expFile.ITIPO = DBValues._EXP_FILES_TIPO_COMPROBANTETRASLADO_PDF;
                }
                else
                {

                    switch (m_Docto.ITIPODOCTOID)
                    {
                        case DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO:
                            expFile.ITIPO = DBValues._EXP_FILES_TIPO_DEVOLUCIONELECTRONICA_PDF;
                            break;
                        case DBValues._DOCTO_TIPO_RECIBOELECTRONICO:
                            expFile.ITIPO = DBValues._EXP_FILES_TIPO_ABONOSELECTRONICOS_PDF;
                            break;
                        default:
                            expFile.ITIPO = DBValues._EXP_FILES_TIPO_FACTURAELECTRONICA_PDF;
                            break;
                    }
                }

                expFile.INOMBRE = Path.GetFileName(documentoPDF);
                expFile.IARCHIVOFTP = Path.GetFileName(documentoPDF);
                expFile.IFECHA = DateTime.Now;
                expFile.IESTATUS = DBValues._EXP_FILES_ESTATUS_GENERADO;
                expFile.IDOCTOID = m_Docto.IID;
                expFile.IDOCTOFOLIO = m_currentFolioSat;
                expFile.IDOCTOSERIE = m_currentSerieSat;
                expFile.ITIPODOCTOID = m_Docto.ITIPODOCTOID;


                if (expFileD.ExisteEXP_FILESXTipoNombre(expFile, m_fTrans) == 0)
                {
                    expFileD.AgregarEXP_FILESD(expFile, m_fTrans);
                }


                return true;

            }
            catch (Exception ex)
            {

                if (!m_silentMode)
                {
                    MessageBox.Show("Error al procesar el pdf " + ex.Message + ex.StackTrace);
                }
                else
                {
                    m_iComentario = "Error al procesar el pdf " + ex.Message + ex.StackTrace;
                }
                return false;
            }
        }

        

        private bool ContainsCartaPorte()
        {
            CDOCTOD doctoD = new CDOCTOD();
            return doctoD.ContieneCartaPorte(m_Docto, m_fTrans);
           
        }

        private bool GeneratePDFFastReport33(string documentoPDF, string tipoComprobante)
        {
            
            bool esVersion40 = (m_empresa.IVERSIONCFDI != null && m_empresa.IVERSIONCFDI.Equals("4.0"));
            string frxReport = esVersion40 ? "RptFacturaElectronica40.frx" : "RptFacturaElectronica33.frx";

            var prefixComprobante = obtainPrefixByTipoComprobante(tipoComprobante);
            bool containsCartaPorte = ContainsCartaPorte();

            DefinirDatosEntrega();

            try
            {

                try
                {

                    FastReport.Report report1 = new FastReport.Report();
                    string strPath = FastReportsConfigReport.getPathForFile(frxReport, FastReportsConfigTipoFile.desistema);
                    report1.Load(strPath);
                    report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
                    report1.SetParameterValue("US_ID", ConexionesBD.ConexionBD.CurrentUser.IID);
                    report1.SetParameterValue("US_NAME", ConexionesBD.ConexionBD.CurrentUser.IID);


                    report1.SetParameterValue("doctoId", m_Docto.IID);
                    //Aqui llenas todos los parametros
                    

                    string strTimbrados = getFileLocalLocation_FE_XML_Timbrados(m_Docto.ITIPODOCTOID, m_empresa, tipoComprobante);
                    report1.SetParameterValue("desgloseKits", this.bDeslosaKits.ToString());
                    report1.SetParameterValue("imagenBicode", "file:///" + getFileLocalLocation_FE_XML_Timbrados(m_Docto.ITIPODOCTOID, m_empresa, tipoComprobante) + "\\" + prefixComprobante + m_currentSerieSat + m_currentFolioSat.ToString() + ".xml.png");
                    report1.SetParameterValue("logoEmpresa", "file:///" /*+ System.AppDomain.CurrentDomain.BaseDirectory*/ + getFileLocalLocation_FE_IMG(m_empresa) + "\\logofarmafree.png");


                    Image bitmap = global::iPosReporting.Properties.Resources.CANCELADA_G;
                    string strImgCanc = ConvertImageToBase64(bitmap, ImageFormat.Png);
                    report1.SetParameterValue("bgImage", m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_CANCELADA ? strImgCanc : null);

                    string bufferNumCSD = Path.GetFileName(m_empresa.ITIMBRADOARCHIVOCERTIFICADO);
                    report1.SetParameterValue("num_serie_cert_csd", bufferNumCSD.Substring(0, bufferNumCSD.Length - 4).ToUpper());

                    report1.SetParameterValue("tipoComprobante", tipoComprobante);

                    report1.SetParameterValue("containsCartaPorte", containsCartaPorte ? "S" : "N");


                    if (report1.Prepare())
                    {
                        FastReport.Export.Pdf.PDFExport pdfExport = null;
                        pdfExport = new FastReport.Export.Pdf.PDFExport();

                        pdfExport.Export(report1, documentoPDF);
                    }



                    this.Close();
                }
                catch (Exception ex)
                {
                    if (!m_silentMode)
                        MessageBox.Show(ex.Message);
                    else
                        this.Close();
                }





                CEXP_FILESD expFileD = new CEXP_FILESD();
                CEXP_FILESBE expFile = new CEXP_FILESBE();



                if (tipoComprobante == "T")
                {
                    expFile.ITIPO = DBValues._EXP_FILES_TIPO_COMPROBANTETRASLADO_PDF;
                }
                else
                {
                    switch (m_Docto.ITIPODOCTOID)
                    {
                        case DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO:
                            expFile.ITIPO = DBValues._EXP_FILES_TIPO_DEVOLUCIONELECTRONICA_PDF;
                            break;
                        case DBValues._DOCTO_TIPO_RECIBOELECTRONICO:
                            expFile.ITIPO = DBValues._EXP_FILES_TIPO_ABONOSELECTRONICOS_PDF;
                            break;
                        default:
                            expFile.ITIPO = DBValues._EXP_FILES_TIPO_FACTURAELECTRONICA_PDF;
                            break;
                    }
                }


                expFile.INOMBRE = Path.GetFileName(documentoPDF);
                expFile.IARCHIVOFTP = Path.GetFileName(documentoPDF);
                expFile.IFECHA = DateTime.Now;
                expFile.IESTATUS = DBValues._EXP_FILES_ESTATUS_GENERADO;
                expFile.IDOCTOID = m_Docto.IID;
                expFile.IDOCTOFOLIO = m_currentFolioSat;
                expFile.IDOCTOSERIE = m_currentSerieSat;
                expFile.ITIPODOCTOID = m_Docto.ITIPODOCTOID;


                if (expFileD.ExisteEXP_FILESXTipoNombre(expFile, m_fTrans) == 0)
                {
                    expFileD.AgregarEXP_FILESD(expFile, m_fTrans);
                }


                return true;

            }
            catch (Exception ex)
            {

                if (!m_silentMode)
                {
                    MessageBox.Show("Error al procesar el pdf " + ex.Message + ex.StackTrace);
                }
                else
                {
                    m_iComentario = "Error al procesar el pdf " + ex.Message + ex.StackTrace;
                }
                return false;
            }
        }



        private string SustituirSubcadenas(string str, Dictionary<string, string> subcadenas)
        {
            foreach (var subcadena in subcadenas)
            {
                str = str.Replace(subcadena.Key, subcadena.Value);
            }

            return str;
        }

        /// <summary>
        /// Agregar subcadenas a sustituir en el texto del footer, para esto, se necesita obtener el valor a sustituir
        /// de nuestro proveedor de datos y agregar un registro en el diccionario con su tag clave y el valor recuperado
        /// </summary>
        /// <returns>Diccionario con todas las subcadenas a sustituir con se respectivo valor</returns>
        private Dictionary<string, string> FijarSubcadenasASustituir()
        {
            Dictionary<string, string> subcadenas = new Dictionary<string, string>();

            //Subcadena nombreVendedor
            CPERSONABE vendedor = new CPERSONABE();
            CPERSONAD personaD = new CPERSONAD();
            vendedor.IID = m_Docto.IVENDEDORID;
            vendedor = personaD.seleccionarPERSONA(vendedor, null);

            if (vendedor != null)
            {
                subcadenas.Add("[nombreVendedor]", vendedor.INOMBRE);
            }

            return subcadenas;
        }

        private bool GeneratePDFRDLC(string documentoPDF, string tipoComprobante = "")
        {

            var prefixComprobante = obtainPrefixByTipoComprobante(tipoComprobante);

            bool esVersion33 = (m_empresa.IVERSIONCFDI != null && m_empresa.IVERSIONCFDI.Equals("3.3"));
            bool esVersion40 = (m_empresa.IVERSIONCFDI != null && m_empresa.IVERSIONCFDI.Equals("4.0"));
            bool esReciboElectronico = this.m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_RECIBOELECTRONICO;


            DefinirDatosEntrega();
            CSUCURSALBE sucursalDestino = getSucursalDestino();

            decimal totalPiezas = 0, totalCajas = 0;
            getPiezasCajas(ref totalCajas, ref totalPiezas);

            //tipo de cambio
            CMONEDABE monedaBE = new CMONEDABE();
            monedaBE.ICLAVE = "MN";

            if (m_Docto.IMONEDAID != DBValues._MONEDA_PESOS)
            {

                //tipo de cambio
                CMONEDAD monedaD = new CMONEDAD();
                monedaBE.IID = ((bool)m_Docto.isnull["IMONEDAID"] || m_Docto.IMONEDAID == 0) ? DBValues._MONEDA_PESOS : m_Docto.IMONEDAID;
                monedaBE = monedaD.seleccionarMONEDA(monedaBE, m_fTrans);
                if (monedaBE == null)
                {
                    monedaBE = new CMONEDABE();
                    monedaBE.ICLAVE = "MN";
                }
            }
            string moneda = monedaBE.ICLAVE;
            if (!moneda.Equals("MN"))
            {
                moneda = moneda + " T.C. " + monedaBE.ITIPOCAMBIO.ToString("#,##0.00");
            }





            string strBuffer = "";

            ReportViewer reportViewer2 = new ReportViewer(); ReportDataSource reportDataSource2 = new ReportDataSource();
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.rEP_FACTURAELECTRONICA_DETBindingSource;
            reportViewer2.LocalReport.EnableExternalImages = true;
            reportViewer2.LocalReport.SetBasePermissionsForSandboxAppDomain(new PermissionSet(PermissionState.Unrestricted));
            reportViewer2.LocalReport.DataSources.Add(reportDataSource2);
            reportViewer2.LocalReport.ReportEmbeddedResource = "iPosReporting.RptFacturaElectronica.rdlc";

            /*PermissionSet permissions = new PermissionSet(PermissionState.None);
            permissions.AddPermission(new FileIOPermission(PermissionState.Unrestricted));
            permissions.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
            reportViewer2.LocalReport.SetBasePermissionsForSandboxAppDomain(permissions);*/

            //reportViewer2.LocalReport.ExecuteReportInCurrentAppDomain(System.Reflection.Assembly.GetExecutingAssembly().Evidence);
            reportViewer2.LocalReport.ExecuteReportInCurrentAppDomain(AppDomain.CurrentDomain.Evidence);
            PermissionSet permissions = new PermissionSet(PermissionState.Unrestricted);
            reportViewer2.LocalReport.SetBasePermissionsForSandboxAppDomain(permissions);

            //reportViewer2.LocalReport.ExecuteReportInCurrentAppDomain(AppDomain.CurrentDomain.Evidence);

            try
            {

                decimal tipoCambio = (((bool)m_Docto.isnull["ITIPOCAMBIO"] || m_Docto.ITIPOCAMBIO == 0) ? 1 : m_Docto.ITIPOCAMBIO);


                CCLIENTEBE clienteBE = new CCLIENTEBE();
                CPERSONAD personaD = new CPERSONAD();
                clienteBE.m_PersonaBE.IID = m_Docto.IPERSONAID;
                clienteBE.m_PersonaBE = personaD.seleccionarPERSONA(clienteBE.m_PersonaBE, m_fTrans);


                string rutaEmbarqueClave = GetRutaEmbarqueClave(m_Docto.IRUTAEMBARQUEID);


                CMOVTOD movtoD = new CMOVTOD();
                ArrayList listIEPS =
                        m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_RECIBOELECTRONICO ?
                             this.DOCTOIEPS_RECIBO(m_Docto.IID, clienteBE) :
                             movtoD.DOCTOIEPSVIEW(m_Docto.IID, null);



                ////////// forma de pago credito evitarla
                String referenciaCredito = "";
                string strCuentaPago = "N / A";
                string nombreFormaPagoConDesc = "";
                m_nombreFormaPago = formaPagoTratandoEvitarPagoOtros(clienteBE, m_nombreFormaPago, m_doctoPago, ref referenciaCredito);
                nombreFormaPagoConDesc = formaPagoConDescripcion(m_nombreFormaPago, m_fTrans);


                if (!(esVersion33 || esVersion40) || !esReciboElectronico)
                {
                    if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_RECIBOELECTRONICO && m_doctoPago.ICUENTAPAGOCREDITO != null && m_doctoPago.ICUENTAPAGOCREDITO.Trim().Length > 0)
                    {
                        strCuentaPago = m_doctoPago.ICUENTAPAGOCREDITO;
                    }
                    else if (this.m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_CHEQUE || this.m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_TARJETA || this.m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_TRANSFERENCIA)
                    {
                        strCuentaPago = this.m_doctoPago.IREFERENCIABANCARIA;
                    }
                    else if (this.m_doctoPago.IFORMAPAGOID == 4 && !referenciaCredito.Equals(""))
                    {
                        strCuentaPago = referenciaCredito;
                    }
                }

                //if (m_nombreFormaPago.Trim().ToLower().Equals("99"/*"credito"*/))
                //{
                //    if (clienteBE.m_PersonaBE == null)
                //        m_nombreFormaPago = "99";// "N / A"/*"No Identificado"*/;
                //    if ((bool)clienteBE.m_PersonaBE.isnull["ICREDITOFORMAPAGOABONOS"] || clienteBE.m_PersonaBE.ICREDITOFORMAPAGOABONOS == 0 || clienteBE.m_PersonaBE.ICREDITOFORMAPAGOABONOS == 16)
                //        m_nombreFormaPago = "99";// "N / A"/*"No Identificado"*/;
                //    else
                //    {
                //        CDOCTOPAGOD pagoD = new CDOCTOPAGOD();
                //        m_nombreFormaPago = pagoD.obtenNombreFormaPagoSatXId(clienteBE.m_PersonaBE.ICREDITOFORMAPAGOABONOS, m_fTrans);
                //        if (m_nombreFormaPago == "")
                //            m_nombreFormaPago = "99";// "N / A"/*"No Identificado"*/;
                //        else
                //        {
                //            referenciaCredito = clienteBE.m_PersonaBE.ICREDITOREFERENCIAABONOS;
                //        }
                //    }
                //    if (referenciaCredito == null)
                //        referenciaCredito = "";
                //}
                ////


                IList<ReportParameter> Param = new List<ReportParameter>();/*Microsoft.Reporting.WinForms.ReportParameter[97]*/;

                string bufferNumCSD = Path.GetFileName(m_empresa.ITIMBRADOARCHIVOCERTIFICADO);
                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("num_serie_cert_csd", bufferNumCSD.Substring(0, bufferNumCSD.Length - 4).ToUpper()));



                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("uuid", m_Docto.ITIMBRADOUUID));
                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("FechaTimbrado", m_Docto.ITIMBRADOFECHA));
                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("noCertificadoSAT", m_Docto.ITIMBRADOCERTSAT));
                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("selloCFD", m_Docto.ITIMBRADOSELLOCFDI));
                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("selloSAT", m_Docto.ITIMBRADOSELLOSAT));

                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("subTotal", (clienteBE.m_PersonaBE.IDESGLOSEIEPS.Equals("S") && m_empresa.IDESGLOSEIEPS.Equals("S")) ?
                                                                                       (m_Docto.ISUBTOTAL / tipoCambio).ToString("#,##0.00") :
                                                                                       ((m_Docto.ISUBTOTAL + m_Docto.IIEPS) / tipoCambio).ToString("#,##0.00")));
                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("iva", (m_Docto.IIVA / tipoCambio).ToString("#,##0.00")));



                decimal Total = m_Docto.ITOTAL - m_Docto.IIVARETENIDO - m_Docto.IISRRETENIDO;

                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("Total", (Total / tipoCambio).ToString("#,##0.00")));



                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("clienteClave", clienteBE.m_PersonaBE.ICLAVE));
                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("sucursal", (!(bool)m_empresa.isnull["IFISCALNOMBRE"]) ?
                                                                                       m_empresa.IFISCALNOMBRE :
                                                                                       m_empresa.INOMBRE));

                DateTime fechaVence = m_Docto.IFECHA.AddDays((bool)clienteBE.m_PersonaBE.isnull["IDIAS"] ? 0 : clienteBE.m_PersonaBE.IDIAS);

                if (!(bool)m_Docto.isnull["IVENCE"])
                {
                    fechaVence = m_Docto.IVENCE;
                }
                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("fechaVencimiento", fechaVence.ToString("dd/MM/yyyy")));
                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("serie", m_Docto.ISERIESAT));


                strBuffer = "";
                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO)
                {
                    if (m_DoctoRef != null)
                        strBuffer = m_DoctoRef.IFOLIO.ToString("0");
                }
                else
                {
                    strBuffer = m_Docto.IFOLIO.ToString("0");
                }
                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("ventaFolio", strBuffer));


                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("metodoPago", nombreFormaPagoConDesc));
                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("cuentaPago", strCuentaPago));

                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("clienteNombre", clienteBE.m_PersonaBE.INOMBRES + " " + clienteBE.m_PersonaBE.IAPELLIDOS));
                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("clienteColonia", clienteBE.m_PersonaBE.ICOLONIA));
                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("clienteMunicipio", clienteBE.m_PersonaBE.ICIUDAD));
                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("clienteCodigoPostal", clienteBE.m_PersonaBE.ICODIGOPOSTAL));
                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("clienteEstado", clienteBE.m_PersonaBE.IESTADO));
                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("clienteRFC", clienteBE.m_PersonaBE.IRFC));


                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("clientePais", clienteBE.m_PersonaBE.IPAIS == null || clienteBE.m_PersonaBE.IPAIS.Trim().Length == 0 ? "MEXICO" : clienteBE.m_PersonaBE.IPAIS));
                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("clienteLocalidad", clienteBE.m_PersonaBE.ILOCALIDAD));
                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("clienteReferenciaDom", clienteBE.m_PersonaBE.IREFERENCIADOM));

                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("rutaEmbarque", rutaEmbarqueClave != null && rutaEmbarqueClave.Trim().Length > 0 ? "Ruta " + rutaEmbarqueClave : ""));
                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("ordenCompra", m_Docto.IORDENCOMPRA != null && m_Docto.IORDENCOMPRA.Trim().Length > 0 ? "Orden de compra " + m_Docto.IORDENCOMPRA : ""));

                //parametro entrega rfc que se manda en blanco porque no estaba considerandose antes
                Param.Add(new ReportParameter("entregaRFC", ""));
                if (sucursalDestino != null)
                {

                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("entregaDireccion", sucursalDestino.IENTREGACALLE +
                                                                                                " Ext. " + sucursalDestino.IENTREGANUMEROEXTERIOR
                                                                                                + (((bool)sucursalDestino.isnull["IENTREGANUMEROINTERIOR"] || sucursalDestino.IENTREGANUMEROINTERIOR.Trim() == "") ? "" : " , Int. " + sucursalDestino.IENTREGANUMEROINTERIOR)));

                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("entregaColonia", sucursalDestino.IENTREGACOLONIA));
                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("entregaMunicipio", sucursalDestino.IENTREGAMUNICIPIO));
                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("entregaCodigoPostal", sucursalDestino.IENTREGACODIGOPOSTAL));
                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("entregaEstado", sucursalDestino.IENTREGAESTADO));
                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("entregaPais", "México"));


                }
                else
                {

                    if (!m_usaDatosDeEntregaCuandoExista || (bool)clienteBE.m_PersonaBE.isnull["IENTREGACALLE"] || clienteBE.m_PersonaBE.IENTREGACALLE.Trim().Equals(""))
                    {
                        Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("entregaDireccion", clienteBE.m_PersonaBE.IDOMICILIO +
                                                                                                    " Ext. " + clienteBE.m_PersonaBE.INUMEROEXTERIOR
                                                                                                    + (((bool)clienteBE.m_PersonaBE.isnull["INUMEROINTERIOR"] || clienteBE.m_PersonaBE.INUMEROINTERIOR.Trim() == "") ? "" : " , Int. " + clienteBE.m_PersonaBE.INUMEROINTERIOR)));

                        Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("entregaColonia", clienteBE.m_PersonaBE.ICOLONIA));
                        Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("entregaMunicipio", clienteBE.m_PersonaBE.ICIUDAD));
                        Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("entregaCodigoPostal", clienteBE.m_PersonaBE.ICODIGOPOSTAL));
                        Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("entregaEstado", clienteBE.m_PersonaBE.IESTADO));
                        Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("entregaPais", clienteBE.m_PersonaBE.IPAIS == null || clienteBE.m_PersonaBE.IPAIS.Trim().Length == 0 ? "MEXICO" : clienteBE.m_PersonaBE.IPAIS));
                    }
                    else
                    {

                        Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("entregaDireccion", clienteBE.m_PersonaBE.IENTREGACALLE +
                                                                                                    " Ext. " + clienteBE.m_PersonaBE.IENTREGANUMEROEXTERIOR
                                                                                                    + (((bool)clienteBE.m_PersonaBE.isnull["IENTREGANUMEROINTERIOR"] || clienteBE.m_PersonaBE.IENTREGANUMEROINTERIOR.Trim() == "") ? "" : " , Int. " + clienteBE.m_PersonaBE.IENTREGANUMEROINTERIOR)));

                        Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("entregaColonia", clienteBE.m_PersonaBE.IENTREGACOLONIA));
                        Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("entregaMunicipio", clienteBE.m_PersonaBE.IENTREGAMUNICIPIO));
                        Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("entregaCodigoPostal", clienteBE.m_PersonaBE.IENTREGACODIGOPOSTAL));
                        Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("entregaEstado", clienteBE.m_PersonaBE.IENTREGAESTADO));
                        Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("entregaPais", clienteBE.m_PersonaBE.IPAIS == null || clienteBE.m_PersonaBE.IPAIS.Trim().Length == 0 ? "MEXICO" : clienteBE.m_PersonaBE.IPAIS));

                    }
                }


                if (m_empresa.IUSARFISCALESENEXPEDICION == "S")
                {

                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("expedicionDireccion", m_empresa.IFISCALCALLE +
                                                                                                    " Ext. " + m_empresa.IFISCALNUMEROEXTERIOR
                                                                                                    + (((bool)m_empresa.isnull["IFISCALNUMEROINTERIOR"] || m_empresa.IFISCALNUMEROINTERIOR.Trim() == "") ? "" : " , Int. " + m_empresa.IFISCALNUMEROINTERIOR)));
                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("expedicionColonia", m_empresa.IFISCALCOLONIA));
                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("expedicionMunicipio", m_empresa.IFISCALMUNICIPIO));
                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("expedicionCodigoPostal", m_empresa.IFISCALCODIGOPOSTAL));
                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("expedicionEstado", m_empresa.IFISCALESTADO));
                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("expedicionRFC", m_empresa.IRFC));
                }
                else
                {
                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("expedicionDireccion", m_empresa.ICALLE +
                                                                                                     " Ext. " + m_empresa.INUMEROEXTERIOR
                                                                                                    + (((bool)m_empresa.isnull["INUMEROINTERIOR"] || m_empresa.INUMEROINTERIOR.Trim() == "") ? "" : " , Int. " + m_empresa.INUMEROINTERIOR)));
                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("expedicionColonia", m_empresa.ICOLONIA));
                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("expedicionMunicipio", m_empresa.ILOCALIDAD));
                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("expedicionCodigoPostal", m_empresa.ICP));
                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("expedicionEstado", m_empresa.IESTADO));
                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("expedicionRFC", m_empresa.IRFC));
                }

                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("fiscalDireccion", m_empresa.IFISCALCALLE +
                                                                                                " Ext. " + m_empresa.IFISCALNUMEROEXTERIOR
                                                                                                + (((bool)m_empresa.isnull["IFISCALNUMEROINTERIOR"] || m_empresa.IFISCALNUMEROINTERIOR.Trim() == "") ? "" : " , Int. " + m_empresa.IFISCALNUMEROINTERIOR)));
                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("fiscalColonia", m_empresa.IFISCALCOLONIA));
                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("fiscalMunicipio", m_empresa.IFISCALMUNICIPIO));
                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("fiscalCodigoPostal", m_empresa.IFISCALCODIGOPOSTAL));
                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("fiscalEstado", m_empresa.IFISCALESTADO));
                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("fiscalRFC", m_empresa.IRFC));

                string totalEnLetra = NumaletRpt.ToCardinal((Total / tipoCambio)).ToUpper();
                if (tipoCambio != 1)
                {
                    totalEnLetra = totalEnLetra.Replace("PESOS", "DOLARES");
                    totalEnLetra = totalEnLetra.Replace("M N", "USD");

                }
                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("totalEnLetras", "(" + totalEnLetra + ")"));
                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("cadenaOriginalSAT", "||1.0|" + m_Docto.ITIMBRADOUUID + "|" + m_Docto.ITIMBRADOFECHA + "|" + m_Docto.ITIMBRADOSELLOCFDI + "|" + m_Docto.ITIMBRADOCERTSAT + "||"));


                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("imagenBicode", "file:///" + /*System.AppDomain.CurrentDomain.BaseDirectory +*/ getFileLocalLocation_FE_XML_Timbrados(m_Docto.ITIPODOCTOID, m_empresa, tipoComprobante) + "\\" + prefixComprobante + m_currentSerieSat + m_currentFolioSat.ToString() + ".xml.png"));
                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("clienteDireccion", clienteBE.m_PersonaBE.IDOMICILIO +
                                                                                                " Ext. " + clienteBE.m_PersonaBE.INUMEROEXTERIOR
                                                                                                + (((bool)clienteBE.m_PersonaBE.isnull["INUMEROINTERIOR"] || clienteBE.m_PersonaBE.INUMEROINTERIOR.Trim() == "") ? "" : " , Int. " + clienteBE.m_PersonaBE.INUMEROINTERIOR)));


                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("nombreFiscal", m_empresa.IFISCALNOMBRE));


                if (!(esVersion33 || esVersion40) || !esReciboElectronico)
                {
                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("hidePagare", (this.m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_CREDITO) ? false.ToString() : true.ToString()));
                }
                else
                {
                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("hidePagare", true.ToString()));
                }


                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("hideIva0", (!bShowIva0).ToString()));
                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("hideIva16", (!bShowIva16).ToString()));

                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("folioFactElec", m_currentFolioSat.ToString("0")));

                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("logoEmpresa", "file:///" /*+ System.AppDomain.CurrentDomain.BaseDirectory*/ + getFileLocalLocation_FE_IMG(m_empresa) + "\\logofarmafree.png"));


                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("tipoDocumento", (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_DEVCONSOLIDADA) ? "DEVOLUCION" : ((m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_RECIBOELECTRONICO) ? "COMPROBANTE DE ABONO" : "FACTURA")));



                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("regimenFiscal", m_empresa.IFISCALREGIMEN));


                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("ivaRetenido", (m_Docto.IIVARETENIDO / tipoCambio).ToString("#,##0.00")));
                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("isrRetenido", (m_Docto.IISRRETENIDO / tipoCambio).ToString("#,##0.00")));

                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("hideIvaRetenido", (clienteBE.m_PersonaBE.IRETIENEIVA.Equals("S")) ? false.ToString() : true.ToString()));
                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("hideIsrRetenido", (clienteBE.m_PersonaBE.IRETIENEISR.Equals("S")) ? false.ToString() : true.ToString()));
                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("hideReciboHonorarios", (clienteBE.m_PersonaBE.IRETIENEISR.Equals("S") || clienteBE.m_PersonaBE.IRETIENEIVA.Equals("S")) ? false.ToString() : true.ToString()));



                bool bEsArrendatario = !(bool)m_empresa.isnull["IARRENDATARIO"] && m_empresa.IARRENDATARIO.Equals("S");
                bool bHayCuentasPrediales = false;

                if (bEsArrendatario)
                {
                    foreach (DataRow dr in this.dSReportIpos2.REP_FACTURAELECTRONICA_DET.Rows)
                    {
                        if (!(bool)m_empresa.isnull["IARRENDATARIO"] && m_empresa.IARRENDATARIO.Equals("S") && dr["CUENTAPREDIAL"] != DBNull.Value && dr["CUENTAPREDIAL"].ToString().Trim().Length > 0)
                        {
                            bHayCuentasPrediales = true;
                            break;
                        }
                    }
                }

                if (bEsArrendatario && !bHayCuentasPrediales)
                {

                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("tipoRecibo", ""));
                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("hideDatosEntrega", false.ToString()));
                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("hideCtaPredial", true.ToString()));
                }
                else if (!(bool)m_empresa.isnull["IARRENDATARIO"])
                {
                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("tipoRecibo", bEsArrendatario ? "Recibo arrendatario" : "Recibo de honorarios"));
                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("hideDatosEntrega", bEsArrendatario ? true.ToString() : false.ToString()));
                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("hideCtaPredial", bEsArrendatario ? false.ToString() : true.ToString()));
                }
                else
                {
                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("tipoRecibo", "Recibo de honorarios"));
                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("hideDatosEntrega", false.ToString()));
                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("hideCtaPredial", true.ToString()));
                }


                if (!(bool)m_empresa.isnull["IMOSTRARDESCUENTOFACTURA"])
                {
                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("hideDescuento", m_empresa.IMOSTRARDESCUENTOFACTURA.Equals("S") ? false.ToString() : true.ToString()));
                }
                else
                {
                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("hideDescuento", false.ToString()));
                }




                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("hidePzaCaja", m_empresa.IMOSTRARPZACAJAENFACTURA.Equals("S") ? false.ToString() : true.ToString()));

                if (!(bool)clienteBE.m_PersonaBE.isnull["IVENDEDORID"])
                {
                    CPERSONABE vendedor = new CPERSONABE();
                    vendedor.IID = clienteBE.m_PersonaBE.IVENDEDORID;
                    vendedor = personaD.seleccionarPERSONA(vendedor, null);
                    if (vendedor != null)
                    {
                        Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("vendedorcliente", vendedor.INOMBRES + " " + vendedor.IAPELLIDOS));
                    }
                }
                else
                {

                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("vendedorcliente", ""));
                }


                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("moneda", moneda));



                if (!(bool)m_empresa.isnull["IDESGLOSEIEPS"])
                {
                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("hideIEPSDetalle", m_empresa.IDESGLOSEIEPS.Equals("S") ? false.ToString() : true.ToString()));
                }
                else
                {
                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("hideIEPSDetalle", false.ToString()));
                }

                int iIEPS = 0;



                if (!(bool)m_empresa.isnull["IDESGLOSEIEPS"] && clienteBE.m_PersonaBE.IDESGLOSEIEPS.Equals("S") && m_empresa.IDESGLOSEIEPS.Equals("S"))
                {
                    iIEPS = 0;
                    decimal IEPSAcumulado = 0;
                    foreach (Hashtable ht in listIEPS)
                    {

                        // cuando ya haya muchos I
                        if (iIEPS <= 4)
                        {

                            Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("hideIEPS" + (iIEPS + 1).ToString("N0"), false.ToString()));
                            if (ht.ContainsKey("TASAIEPS"))
                            {
                                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("porcIEPS" + (iIEPS + 1).ToString("N0"), ((decimal)(ht["TASAIEPS"])).ToString("#,##0.00")));
                            }

                            if (ht.ContainsKey("SUMAIEPS"))
                            {
                                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("IEPS" + (iIEPS + 1).ToString("N0"), ((decimal)(ht["SUMAIEPS"])).ToString("#,##0.00")));
                            }
                            IEPSAcumulado += ((decimal)(ht["SUMAIEPS"]));

                        }
                        else
                        {

                            Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("hideIEPS" + (iIEPS + 1).ToString("N0"), false.ToString()));
                            if (ht.ContainsKey("TASAIEPS"))
                            {
                                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("porcIEPS" + (iIEPS + 1).ToString("N0"), "(otros)"));
                            }

                            if (ht.ContainsKey("SUMAIEPS"))
                            {
                                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("IEPS" + (iIEPS + 1).ToString("N0"), (m_Docto.IIEPS - IEPSAcumulado).ToString("#,##0.00")));
                            }
                            break;
                        }

                        iIEPS++;
                    }
                }




                for (int iIEPS_Resto = iIEPS; iIEPS_Resto < 6; iIEPS_Resto++)
                {
                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("hideIEPS" + (iIEPS_Resto + 1).ToString("N0"), true.ToString()));
                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("porcIEPS" + (iIEPS_Resto + 1).ToString("N0"), "0.00"));
                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("IEPS" + (iIEPS_Resto + 1).ToString("N0"), "0.00"));
                }


                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("clienteDesglosaIEPS", (clienteBE.m_PersonaBE.IDESGLOSEIEPS.Equals("S")) ? true.ToString() : false.ToString()));
                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("empresaDesglosaIEPS", (m_empresa.IDESGLOSEIEPS.Equals("S")) ? true.ToString() : false.ToString()));

                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("notaPago", (!(bool)m_Docto.isnull["INOTAPAGO"] && m_Docto.INOTAPAGO.Trim().Length > 0) ? "Nota: " + m_Docto.INOTAPAGO : ""));

                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("tipoCambioTexto", (tipoCambio != 1) ? "T.C. " + tipoCambio.ToString("#,##0.00") : ""));


                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO && !(bool)m_Docto.isnull["IDOCTOREFID"])
                {

                    CDOCTOD doctoD = new CDOCTOD();
                    CDOCTOBE doctoRef = new CDOCTOBE();
                    doctoRef.IID = m_Docto.IDOCTOREFID;
                    doctoRef = doctoD.seleccionarDOCTO(doctoRef, null);


                    if (doctoRef != null && !(bool)doctoRef.isnull["IFOLIO"] && !(bool)doctoRef.isnull["IFOLIOSAT"] && !(bool)doctoRef.isnull["ISERIESAT"])
                        Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("foliopadre", "Devolucion de venta: " + doctoRef.IFOLIO.ToString() + " Folio Sat: " + doctoRef.IFOLIOSAT.ToString("N0") + doctoRef.ISERIESAT));
                    else
                        Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("foliopadre", ""));

                }
                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_RECIBOELECTRONICO && !(bool)m_Docto.isnull["IDOCTOREFID"])
                {

                    CDOCTOD doctoD = new CDOCTOD();
                    CDOCTOBE doctoRef = new CDOCTOBE();
                    doctoRef.IID = m_Docto.IDOCTOREFID;
                    doctoRef = doctoD.seleccionarDOCTO(doctoRef, null);
                    if (doctoRef != null && !(bool)doctoRef.isnull["IFOLIO"])
                        Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("foliopadre", "Comprobante de abono de venta: " + doctoRef.IFOLIO.ToString()));
                    else
                        Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("foliopadre", ""));

                }
                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO && !(bool)m_Docto.isnull["IDOCTOREFID"])
                {

                    CDOCTOD doctoD = new CDOCTOD();
                    CDOCTOBE doctoRef = new CDOCTOBE();
                    doctoRef.IID = m_Docto.IDOCTOREFID;
                    doctoRef = doctoD.seleccionarDOCTO(doctoRef, null);


                    if (doctoRef != null && !(bool)doctoRef.isnull["IFOLIO"])
                    {
                        string strBuffer2 = "Traspaso con venta: " + doctoRef.IFOLIO.ToString();
                        if (!(bool)doctoRef.isnull["IFOLIOSAT"] && !(bool)doctoRef.isnull["ISERIESAT"])
                            strBuffer2 += " Folio Sat: " + doctoRef.IFOLIOSAT.ToString("N0") + doctoRef.ISERIESAT;

                        Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("foliopadre", strBuffer2));
                    }
                    else
                        Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("foliopadre", ""));

                }
                else
                {
                    Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("foliopadre", ""));
                }

                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("desgloseKits", this.bDeslosaKits.ToString()));

                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("formaPago", (clienteBE.m_PersonaBE.IPAGOPARCIALIDADES.Equals("S") ? "PAGO EN PARCIALIDADES" : "PAGO EN UNA SOLA EXHIBICION")));



                Image bitmap = global::iPosReporting.Properties.Resources.CANCELADA_G;
                string strImgCanc = ConvertImageToBase64(bitmap, ImageFormat.Png);
                Param.Add(new Microsoft.Reporting.WinForms.ReportParameter("bgImage", m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_CANCELADA ? strImgCanc : null));
                //Param[91] = new Microsoft.Reporting.WinForms.ReportParameter("bgImage", strImgCanc);

                //Param[1] = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", DTPTo.Value.ToString("dd/MM/yyyy"));
                //Param[2] = new Microsoft.Reporting.WinForms.ReportParameter(strTipo);

                //Agregar texto footer
                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA &&
                       !(bool)m_empresa.isnull["IFOOTER"] &&
                       m_empresa.IFOOTER != "")
                {
                    //fijar subcadenas a sustituir en el footer
                    Dictionary<string, string> subcadenasASustituir = FijarSubcadenasASustituir();

                    //reemplazar subcadenas en footer
                    string footer = SustituirSubcadenas(m_empresa.IFOOTER, subcadenasASustituir);

                    //fijar como parametro en reporte
                    Param.Add(new ReportParameter("textoFooter", footer));
                }
                else
                {
                    Param.Add(new ReportParameter("textoFooter", String.Empty));
                }


                Param.Add(new ReportParameter("cajas", totalCajas.ToString()));
                Param.Add(new ReportParameter("piezas", totalPiezas.ToString()));

                /*string strTest = "";

                Dictionary<string,int> cuenta = new Dictionary<string, int>();
                string names = "";

                foreach(ReportParameter t in Param)
                {
                    if(cuenta.Keys.Contains(t.Name))
                    {
                        cuenta[t.Name] = cuenta[t.Name]++;
                    }
                    else
                    {
                        cuenta.Add(t.Name, 1);
                    }

                    names += t.Name + "\r\n";
                }*/

                reportViewer2.LocalReport.SetParameters(Param);

                reportViewer2.RefreshReport();


                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;
                string fileName = documentoPDF;




                CultureInfo ci = Thread.CurrentThread.CurrentCulture;
                byte[] bytes = reportViewer2.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                Thread.CurrentThread.CurrentCulture = ci;

                //// Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
                FileStream fs = new FileStream(fileName,
               FileMode.Create);
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();

                reportViewer2.Clear();
                reportViewer2.Dispose();
                GC.SuppressFinalize(reportViewer2);
                GC.SuppressFinalize(fs);
                reportDataSource2 = null;
                reportViewer2 = null;




                CEXP_FILESD expFileD = new CEXP_FILESD();
                CEXP_FILESBE expFile = new CEXP_FILESBE();

                switch (m_Docto.ITIPODOCTOID)
                {
                    case DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO: expFile.ITIPO = DBValues._EXP_FILES_TIPO_DEVOLUCIONELECTRONICA_PDF; break;
                    case DBValues._DOCTO_TIPO_RECIBOELECTRONICO: expFile.ITIPO = DBValues._EXP_FILES_TIPO_ABONOSELECTRONICOS_PDF; break;
                    default: expFile.ITIPO = DBValues._EXP_FILES_TIPO_FACTURAELECTRONICA_PDF; break;
                }

                expFile.INOMBRE = Path.GetFileName(documentoPDF);
                expFile.IARCHIVOFTP = Path.GetFileName(documentoPDF);
                expFile.IFECHA = DateTime.Now;
                expFile.IESTATUS = DBValues._EXP_FILES_ESTATUS_GENERADO;
                expFile.IDOCTOID = m_Docto.IID;
                expFile.IDOCTOFOLIO = m_currentFolioSat;
                expFile.IDOCTOSERIE = m_currentSerieSat;
                expFile.ITIPODOCTOID = m_Docto.ITIPODOCTOID;


                if (expFileD.ExisteEXP_FILESXTipoNombre(expFile, m_fTrans) == 0)
                {
                    expFileD.AgregarEXP_FILESD(expFile, m_fTrans);
                }


                return true;

            }
            catch (Exception ex)
            {

                if (!m_silentMode)
                {
                    MessageBox.Show("Error al procesar el pdf " + ex.Message + ex.StackTrace);
                }
                else
                {
                    m_iComentario = "Error al procesar el pdf " + ex.Message + ex.StackTrace;
                }
                return false;
            }



        }



        private bool ImprimirTicketFacturaElectronica()
        {


            DefinirDatosEntrega();
            CSUCURSALBE sucursalDestino = getSucursalDestino();




            CCLIENTEBE clienteBE = new CCLIENTEBE();
            CPERSONAD personaD = new CPERSONAD();
            clienteBE.m_PersonaBE.IID = m_Docto.IPERSONAID;
            clienteBE.m_PersonaBE = personaD.seleccionarPERSONA(clienteBE.m_PersonaBE, m_fTrans);


            CPERSONABE usuarioBE = new CPERSONABE();
            usuarioBE.IID = m_Docto.IVENDEDORID;
            usuarioBE = personaD.seleccionarPERSONA(usuarioBE, m_fTrans);




            ////////// forma de pago credito evitarla
            String referenciaCredito = "";
            string strCuentaPago = "N / A";
            m_nombreFormaPago = formaPagoTratandoEvitarPagoOtros(clienteBE, m_nombreFormaPago, m_doctoPago, ref referenciaCredito);


            if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_RECIBOELECTRONICO && m_doctoPago.ICUENTAPAGOCREDITO != null && m_doctoPago.ICUENTAPAGOCREDITO.Trim().Length > 0)
            {
                strCuentaPago = m_doctoPago.ICUENTAPAGOCREDITO;
            }
            else if (this.m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_CHEQUE || this.m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_TARJETA || this.m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_TRANSFERENCIA)
            {
                strCuentaPago = this.m_doctoPago.IREFERENCIABANCARIA;
            }
            else if (this.m_doctoPago.IFORMAPAGOID == 4 && !referenciaCredito.Equals(""))
            {
                strCuentaPago = referenciaCredito;
            }

            //tickets especuales
            if (ConexionesBD.ConexionBD.CurrentParameters.ITICKETESPECIAL != null && ConexionesBD.ConexionBD.CurrentParameters.ITICKETESPECIAL.Equals("VG") &&
                (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA))
            {
                return TicketEspecial_1.ImprimirTicketFacturaElectronica(
                                                                        m_Docto.IID,
                                                                        m_fTrans,
                                                                        m_silentMode,
                                                                        ref m_iComentario,
                                                                        m_nombreFormaPago,
                                                                        m_doctoPago,
                                                                        m_empresa,
                                                                        dSReportIpos2.REP_FACTURAELECTRONICA_DET.Rows,
                                                                        clienteBE,
                                                                        usuarioBE,
                                                                        referenciaCredito,
                                                                        strCuentaPago) == "";
            }
            else
            {
                return ImprimirTicketFacturaElectronicaDefault(
                            clienteBE,
                            usuarioBE,
                            referenciaCredito,
                            strCuentaPago);
            }

        }


        private bool ImprimirTicketFacturaElectronicaDefault(
            CCLIENTEBE clienteBE,
            CPERSONABE usuarioBE,
            String referenciaCredito,
            string strCuentaPago)
        {

            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();
            //Now force thousand separator to be empty string
            nfi.NumberGroupSeparator = "";
            Hashtable htIva = new Hashtable();
            Hashtable htIeps = new Hashtable();


            //*-DefinirDatosEntrega();
            //*-CSUCURSALBE sucursalDestino = getSucursalDestino();

            //tipo de cambio
            CMONEDABE monedaBE = new CMONEDABE();
            monedaBE.ICLAVE = "MN";

            if (m_Docto.IMONEDAID != DBValues._MONEDA_PESOS)
            {

                //tipo de cambio
                CMONEDAD monedaD = new CMONEDAD();
                monedaBE.IID = ((bool)m_Docto.isnull["IMONEDAID"] || m_Docto.IMONEDAID == 0) ? DBValues._MONEDA_PESOS : m_Docto.IMONEDAID;
                monedaBE = monedaD.seleccionarMONEDA(monedaBE, m_fTrans);
                if (monedaBE == null)
                {
                    monedaBE = new CMONEDABE();
                    monedaBE.ICLAVE = "MN";
                }
            }
            string moneda = monedaBE.ICLAVE;
            if (!moneda.Equals("MN"))
            {
                moneda = moneda + " T.C. " + monedaBE.ITIPOCAMBIO.ToString("#,##0.00");
            }


            //string strBuffer = "";


            try
            {

                decimal tipoCambio = (((bool)m_Docto.isnull["ITIPOCAMBIO"] || m_Docto.ITIPOCAMBIO == 0) ? 1 : m_Docto.ITIPOCAMBIO);


                //*-CCLIENTEBE clienteBE = new CCLIENTEBE();
                CPERSONAD personaD = new CPERSONAD();
                //*-clienteBE.m_PersonaBE.IID = m_Docto.IPERSONAID;
                //*-clienteBE.m_PersonaBE = personaD.seleccionarPERSONA(clienteBE.m_PersonaBE, m_fTrans);


                //*-CPERSONABE usuarioBE = new CPERSONABE();
                //*-usuarioBE.IID = m_Docto.IVENDEDORID;
                //*-usuarioBE = personaD.seleccionarPERSONA(usuarioBE, m_fTrans);

                CMOVTOD movtoD = new CMOVTOD();
                ArrayList listIEPS = movtoD.DOCTOIEPSVIEW(m_Docto.IID, null);

                CTICKET_FOOTERD footerD = new CTICKET_FOOTERD();
                CTICKET_FOOTERBE footerBE = new CTICKET_FOOTERBE();
                footerBE.IDOCTOID = m_Docto.IID;
                footerBE = footerD.seleccionarTICKET_FOOTER(footerBE, false, null);




                ////////// forma de pago credito evitarla
                //*-String referenciaCredito = "";
                //*-string strCuentaPago = "N / A";
                //*-m_nombreFormaPago = formaPagoTratandoEvitarPagoOtros(clienteBE, m_nombreFormaPago, m_doctoPago, ref referenciaCredito);


                //*-if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_RECIBOELECTRONICO && m_doctoPago.ICUENTAPAGOCREDITO != null && m_doctoPago.ICUENTAPAGOCREDITO.Trim().Length > 0)
                //*-{
                //*-strCuentaPago = m_doctoPago.ICUENTAPAGOCREDITO;
                //*-}
                //*-else if (this.m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_CHEQUE || this.m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_TARJETA || this.m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_TRANSFERENCIA)
                //*-{
                //*-strCuentaPago = this.m_doctoPago.IREFERENCIABANCARIA;
                //*-}
                //*-else if (this.m_doctoPago.IFORMAPAGOID == 4 && !referenciaCredito.Equals(""))
                //*-{
                //*-strCuentaPago = referenciaCredito;
                //*-}

                //if (m_nombreFormaPago.Trim().ToLower().Equals("99"/*"credito"*/))
                //{
                //    if (clienteBE.m_PersonaBE == null)
                //        m_nombreFormaPago = "99";// "N / A";
                //    if ((bool)clienteBE.m_PersonaBE.isnull["ICREDITOFORMAPAGOABONOS"] || clienteBE.m_PersonaBE.ICREDITOFORMAPAGOABONOS == 0 || clienteBE.m_PersonaBE.ICREDITOFORMAPAGOABONOS == 16)
                //        m_nombreFormaPago = "99";// "N / A";
                //    else
                //    {
                //        CDOCTOPAGOD pagoD = new CDOCTOPAGOD();
                //        m_nombreFormaPago = pagoD.obtenNombreFormaPagoSatXId(clienteBE.m_PersonaBE.ICREDITOFORMAPAGOABONOS, m_fTrans);
                //        if (m_nombreFormaPago == "")
                //            m_nombreFormaPago = "99";// "N / A";
                //        else
                //        {
                //            referenciaCredito = clienteBE.m_PersonaBE.ICREDITOREFERENCIAABONOS;
                //        }
                //    }
                //    if (referenciaCredito == null)
                //        referenciaCredito = "";

                //}
                //string strCuentaPago = (this.m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_CHEQUE || this.m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_TARJETA || this.m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_TRANSFERENCIA) ? this.m_doctoPago.IREFERENCIABANCARIA : (this.m_doctoPago.IFORMAPAGOID == 4 && !referenciaCredito.Equals("")) ? referenciaCredito : "N / A";

                ////
                string bufferNumCSD = Path.GetFileName(m_empresa.ITIMBRADOARCHIVOCERTIFICADO);
                string subtotalfact = (clienteBE.m_PersonaBE.IDESGLOSEIEPS.Equals("S") && m_empresa.IDESGLOSEIEPS.Equals("S")) ? (m_Docto.ISUBTOTAL / tipoCambio).ToString("#,##0.00") : ((m_Docto.ISUBTOTAL + m_Docto.IIEPS) / tipoCambio).ToString("#,##0.00");
                decimal Total = m_Docto.ITOTAL - m_Docto.IIVARETENIDO - m_Docto.IISRRETENIDO;
                string totalEnLetra = NumaletRpt.ToCardinal((Total / tipoCambio)).ToUpper();
                if (tipoCambio != 1)
                {
                    totalEnLetra = totalEnLetra.Replace("PESOS", "DOLARES");
                    totalEnLetra = totalEnLetra.Replace("M N", "USD");

                }

                string[] splitSeparator = new string[] { "\r\n" };



                TicketR ticket = new TicketR();
                ticket.AddHeaderLine(" ");
                ticket.AddHeaderLine(new string('=', TicketR.maxChar));

                ticket.AddQRLine("?re=" + this.m_empresa.IRFC + "&rr=" + clienteBE.m_PersonaBE.IRFC + "&tt=" + m_Docto.ITOTAL + "&id=" + m_Docto.ITIMBRADOUUID);

                ticket.AddHeaderLine("Factura: " + m_currentFolioSat.ToString("0") + m_Docto.ISERIESAT, true);

                //this.m_empresa.IRFC
                //clienteBE.m_PersonaBE.IRFC
                //m_Docto.ITOTAL
                //m_Docto.ITIMBRADOUUID


                ticket.AddHeaderLine(new string(' ', TicketR.maxChar));
                ticket.AddHeaderLine((!(bool)this.m_empresa.isnull["IFISCALNOMBRE"]) ? this.m_empresa.IFISCALNOMBRE : m_empresa.INOMBRE, true);
                ticket.AddHeaderLine("R.F.C: " + this.m_empresa.IRFC, true);
                ticket.AddHeaderLine(this.m_empresa.IFISCALCALLE + " Ext. " + this.m_empresa.IFISCALNUMEROEXTERIOR
                                                            + (((bool)this.m_empresa.isnull["IFISCALNUMEROINTERIOR"] || m_empresa.IFISCALNUMEROINTERIOR.Trim() == "") ? "" : " , Int. " + m_empresa.IFISCALNUMEROINTERIOR), true);
                ticket.AddHeaderLine("Colona: " + this.m_empresa.IFISCALCOLONIA, true);
                ticket.AddHeaderLine("Ciudad: " + this.m_empresa.IFISCALMUNICIPIO + " " + this.m_empresa.IFISCALESTADO + " " + this.m_empresa.IFISCALCODIGOPOSTAL, true);

                ticket.AddHeaderLine(new string(' ', TicketR.maxChar));
                ticket.AddHeaderLine(new string('-', TicketR.maxChar));

                if (m_empresa.IUSARFISCALESENEXPEDICION == "S")
                {

                    ticket.AddHeaderLine("Expedido en: " + m_empresa.IFISCALMUNICIPIO + " " + m_empresa.IFISCALESTADO + " C.P. " + this.m_empresa.ICP, true);
                    ticket.AddHeaderLine((!(bool)this.m_empresa.isnull["IFISCALNOMBRE"]) ? this.m_empresa.IFISCALNOMBRE : m_empresa.INOMBRE, true);
                    ticket.AddHeaderLine(m_empresa.IFISCALCALLE + " Ext. " + m_empresa.IFISCALNUMEROEXTERIOR
                                                                + (((bool)m_empresa.isnull["IFISCALNUMEROINTERIOR"] || m_empresa.IFISCALNUMEROINTERIOR.Trim() == "") ? "" : " , Int. " + m_empresa.IFISCALNUMEROINTERIOR) + " Tel: (telefono de quien expide)", true);
                    ticket.AddHeaderLine("R.F.C. : " + m_empresa.IRFC, true);
                }
                else
                {

                    ticket.AddHeaderLine("Expedido en: " + m_empresa.ILOCALIDAD + " " + m_empresa.IESTADO + " C.P. " + this.m_empresa.IFISCALCODIGOPOSTAL, true);
                    ticket.AddHeaderLine((!(bool)this.m_empresa.isnull["IFISCALNOMBRE"]) ? this.m_empresa.IFISCALNOMBRE : m_empresa.INOMBRE, true);
                    ticket.AddHeaderLine(m_empresa.ICALLE + " Ext. " + m_empresa.INUMEROEXTERIOR
                                                          + (((bool)m_empresa.isnull["INUMEROINTERIOR"] || m_empresa.INUMEROINTERIOR.Trim() == "") ? "" : " , Int. " + m_empresa.INUMEROINTERIOR), true);
                    ticket.AddHeaderLine("R.F.C. : " + m_empresa.IRFC, true);
                }

                ticket.AddHeaderLine(new string(' ', TicketR.maxChar));
                ticket.AddHeaderLine(new string('-', TicketR.maxChar));

                ticket.AddHeaderLine("Met de pago: " + m_nombreFormaPago, true);
                ticket.AddHeaderLine("Cuen Pago: " + strCuentaPago, true);
                ticket.AddHeaderLine(" ");
                ticket.AddHeaderLine("FECHA FACTURA    : " + m_Docto.ITIMBRADOFECHAFACTURA.AddMinutes(-5).ToString("yyyy-MM-dd'T'HH:mm:ss"), true);
                ticket.AddHeaderLine("No. SERIE CER CSD: " + bufferNumCSD.Substring(0, bufferNumCSD.Length - 4).ToUpper(), true);
                ticket.AddHeaderLine("No. SERIE CER SAT: " + m_Docto.ITIMBRADOCERTSAT, true);
                ticket.AddHeaderLine("FACTURA: " + m_currentFolioSat.ToString("0") + " Serie: " + m_currentSerieSat + "  Venta " + m_Docto.IFOLIO.ToString("0"), true);

                ticket.AddHeaderLine(new string(' ', TicketR.maxChar));
                ticket.AddHeaderLine(new string('-', TicketR.maxChar));
                ticket.AddHeaderLine("CTE : " + clienteBE.m_PersonaBE.ICLAVE + " " + clienteBE.m_PersonaBE.INOMBRES + " " + clienteBE.m_PersonaBE.IAPELLIDOS, true);
                ticket.AddHeaderLine(clienteBE.m_PersonaBE.IDOMICILIO + " Ext. " + clienteBE.m_PersonaBE.INUMEROEXTERIOR
                                                                                 + (((bool)clienteBE.m_PersonaBE.isnull["INUMEROINTERIOR"] || clienteBE.m_PersonaBE.INUMEROINTERIOR.Trim() == "") ? "" : " , Int. " + clienteBE.m_PersonaBE.INUMEROINTERIOR), true);
                ticket.AddHeaderLine(clienteBE.m_PersonaBE.ICOLONIA, true);
                ticket.AddHeaderLine(clienteBE.m_PersonaBE.ICIUDAD + "  " + clienteBE.m_PersonaBE.IESTADO, true);
                ticket.AddHeaderLine("RFC:" + clienteBE.m_PersonaBE.IRFC, true);


                ticket.AddHeaderLine(new string(' ', TicketR.maxChar));
                ticket.AddHeaderLine(new string('-', TicketR.maxChar));
                ticket.AddHeaderLine("VENDEDOR: " + usuarioBE.INOMBRE, true);
                ticket.AddHeaderLine("TIPO PAGO: " + m_nombreFormaPago, true);

                ticket.AddHeaderLine(new string(' ', TicketR.maxChar));
                ticket.AddHeaderLine(new string('=', TicketR.maxChar));
                ticket.AddHeaderLine("CLAVE  CANTIDAD  P/U   IVA   IMPORTE", true);
                ticket.AddHeaderLine("DESCRIPCION               ");
                ticket.AddHeaderLine(new string('-', TicketR.maxChar));
                ticket.AddHeaderLine(new string(' ', TicketR.maxChar));



                if (m_empresa.IDESGLOSEIEPS.Equals("S") && clienteBE.m_PersonaBE.IDESGLOSEIEPS.Equals("S"))
                {
                    ticket.AddHeaderLine("CANTIDAD PRECIO   %IVA %IEPS IMPORTE   ");
                }
                else
                {
                    ticket.AddHeaderLine("CANTIDAD  PRECIO     %IVA   IMPORTE    ");
                }

                ticket.AddHeaderLine(new string('-', TicketR.maxChar));


                foreach (DataRow dr in this.dSReportIpos2.REP_FACTURAELECTRONICA_DET.Rows)
                {



                    decimal porcentajeiva = 0;
                    decimal porcentajeieps = 0;
                    decimal iva = 0;
                    decimal ieps = 0;
                    decimal subtotal = 0;
                    decimal cantidad = 0;
                    decimal valorUnitario = 0;
                    string unidad = "PZA";
                    string productoClave = "";
                    string productoDescripcion = "";
                    string strPrecio = "";
                    string strImporte = "";
                    string strCantidad = "";
                    string strIva = "";
                    string strIeps = "";
                    if (dr["CANTIDAD"] != DBNull.Value)
                    {
                        cantidad = (decimal)dr["CANTIDAD"];
                        strCantidad = cantidad.ToString("N2", nfi);
                        //el.SetAttribute("cantidad", cantidad.ToString("N2", nfi));
                    }
                    else
                    {
                        continue;
                    }


                    if (dr["UNIDAD"] != DBNull.Value)
                        unidad = dr["UNIDAD"].ToString().Trim();
                    else
                        unidad = "PZA";


                    if (dr["PRODUCTOCLAVE"] != DBNull.Value)
                        productoClave = dr["PRODUCTOCLAVE"].ToString().Trim();
                    else
                        productoClave = "";


                    if (dr["PRODUCTODESCRIPCION"] != DBNull.Value)
                        productoDescripcion = dr["PRODUCTODESCRIPCION"].ToString().Trim();





                    if (dr["SUBTOTAL"] != DBNull.Value)
                    {
                        subtotal = (decimal)dr["SUBTOTAL"];
                    }


                    if (dr["PRECIO"] != DBNull.Value)
                    {
                        valorUnitario = (decimal)dr["PRECIO"];
                    }

                    if ((clienteBE.m_PersonaBE.IDESGLOSEIEPS.Equals("S") && m_empresa.IDESGLOSEIEPS.Equals("S")))
                    {

                        strPrecio = valorUnitario.ToString("N2", nfi);

                        strImporte = subtotal.ToString("N2", nfi);

                    }
                    else
                    {

                        if (dr["PORCENTAJEIEPS"] != DBNull.Value)
                        {
                            porcentajeieps = (decimal)dr["PORCENTAJEIEPS"];
                        }

                        if (dr["IEPS"] != DBNull.Value)
                        {
                            ieps = (decimal)dr["IEPS"];
                        }

                        strPrecio = (Math.Round((subtotal + ieps) / cantidad, 2)).ToString("N2", nfi);

                        strImporte = (subtotal + ieps).ToString("N2", nfi);
                    }




                    //calculating iva
                    if (dr["PORCENTAJEIVA"] != DBNull.Value)
                    {
                        porcentajeiva = (decimal)dr["PORCENTAJEIVA"];
                    }

                    if (dr["IVA"] != DBNull.Value)
                    {
                        iva = (decimal)dr["IVA"];
                    }

                    if (htIva.Contains(porcentajeiva))
                        htIva[porcentajeiva] = (decimal)htIva[porcentajeiva] + iva;
                    else
                        htIva[porcentajeiva] = iva;


                    if (m_empresa.IDESGLOSEIEPS.Equals("S") && clienteBE.m_PersonaBE.IDESGLOSEIEPS.Equals("S"))
                    {
                        //calculating ieps
                        if (dr["PORCENTAJEIEPS"] != DBNull.Value)
                        {
                            porcentajeieps = (decimal)dr["PORCENTAJEIEPS"];
                        }

                        if (dr["IEPS"] != DBNull.Value)
                        {
                            ieps = (decimal)dr["IEPS"];
                        }

                        if (htIeps.Contains(porcentajeieps))
                            htIeps[porcentajeieps] = (decimal)htIeps[porcentajeieps] + ieps;
                        else
                            htIeps[porcentajeieps] = ieps;
                    }

                    strIva = porcentajeiva.ToString("N2", nfi);
                    strIeps = porcentajeieps.ToString("N2", nfi);


                    if (m_empresa.IDESGLOSEIEPS.Equals("S") && clienteBE.m_PersonaBE.IDESGLOSEIEPS.Equals("S"))
                    {
                        ticket.AddHeaderLine(this.strFixedSize(strCantidad, 8, true) +
                                            this.strFixedSize(strPrecio, 10, true) +
                                            this.strFixedSize(strIva, 5, true) +
                                            this.strFixedSize(strIeps, 5, true) +
                                            this.strFixedSize(strImporte, 11, false), false);
                    }
                    else
                    {

                        ticket.AddHeaderLine(

                                            this.strFixedSize(strCantidad, 10, true) +
                                            this.strFixedSize(strPrecio, 11, true) +
                                            this.strFixedSize(strIva, 6, true) +
                                            this.strFixedSize(strImporte, 12, false), false);
                    }

                    ticket.AddHeaderLine(productoDescripcion, true);
                }


                ticket.AddHeaderLine(new string(' ', TicketR.maxChar));
                ticket.AddHeaderLine(new string('-', TicketR.maxChar));

                ticket.AddHeaderLine(new string(' ', TicketR.maxChar));
                ticket.AddHeaderLine("CADENA ORIGINAL DEL COMPLEMENTO DE CERTIF DEL SAT", true);
                ticket.AddHeaderLine("||1.0|" + m_Docto.ITIMBRADOUUID + "|" + m_Docto.ITIMBRADOFECHA + "|" + m_Docto.ITIMBRADOSELLOCFDI + "|" + m_Docto.ITIMBRADOCERTSAT + "||", true);

                ticket.AddHeaderLine(new string(' ', TicketR.maxChar));
                ticket.AddHeaderLine("SELLO SAT", true);
                ticket.AddHeaderLine(m_Docto.ITIMBRADOSELLOSAT, true);

                ticket.AddHeaderLine(new string(' ', TicketR.maxChar));
                ticket.AddHeaderLine("SELLO DIGITAL DEL CFDI", true);
                ticket.AddHeaderLine(m_Docto.ITIMBRADOSELLOCFDI, true);

                ticket.AddHeaderLine(new string(' ', TicketR.maxChar));
                ticket.AddHeaderLine(this.strFixedSize("SUB TOTAL: ", 18, false) + this.strFixedSize(subtotalfact, 20, false), true);



                foreach (DictionaryEntry entry in htIva)
                {

                    decimal tasaImp = (decimal)entry.Key;
                    decimal importeImp = (decimal)entry.Value;

                    ticket.AddHeaderLine(this.strFixedSize("IVA", 9, false) +
                                        this.strFixedSize("(" + tasaImp.ToString("N2", nfi), 6, false) + "%):" +
                                        this.strFixedSize(importeImp.ToString("N2", nfi), 20, false));
                }


                foreach (DictionaryEntry entry in htIeps)
                {

                    decimal tasaImp = (decimal)entry.Key;
                    decimal importeImp = (decimal)entry.Value;

                    ticket.AddHeaderLine(this.strFixedSize("IEPS", 9, false) +
                                        this.strFixedSize(tasaImp.ToString("N2", nfi), 6, false) + "%" +
                                        this.strFixedSize(importeImp.ToString("N2", nfi), 19, false));
                }



                ticket.AddHeaderLine(this.strFixedSize("TOTAL: ", 18, false) + this.strFixedSize((Total / tipoCambio).ToString("#,##0.00"), 20, false), true);

                ticket.AddHeaderLine(new string(' ', TicketR.maxChar));
                ticket.AddHeaderLine(new string('-', TicketR.maxChar));

                if (footerBE != null)
                {

                    if (footerBE.IPAGOTARJETA > 0)
                        ticket.AddHeaderLine(this.strFixedSize("Pago Tarjeta: ", 18, false) + this.strFixedSize(footerBE.IPAGOTARJETA.ToString("N2"), 20, false), false);
                    if (footerBE.IPAGOCREDITO > 0)
                        ticket.AddHeaderLine(this.strFixedSize("Pago Credito: ", 18, false) + this.strFixedSize(footerBE.IPAGOCREDITO.ToString("N2"), 20, false), false);
                    if (footerBE.IPAGOCHEQUE > 0)
                        ticket.AddHeaderLine(this.strFixedSize("Pago Cheque: ", 18, false) + this.strFixedSize(footerBE.IPAGOCHEQUE.ToString("N2"), 20, false), false);
                    if (footerBE.IPAGOVALE > 0)
                        ticket.AddHeaderLine(this.strFixedSize("Pago Vale: ", 18, false) + this.strFixedSize(footerBE.IPAGOVALE.ToString("N2"), 20, false), false);
                    if (footerBE.IPAGOMONEDERO > 0)
                        ticket.AddHeaderLine(this.strFixedSize("Pago Monedero: ", 18, false) + this.strFixedSize(footerBE.IPAGOMONEDERO.ToString("N2"), 20, false), false);
                    if (footerBE.IPAGOTRANSFERENCIA > 0)
                        ticket.AddHeaderLine(this.strFixedSize("Pago Transferencia: ", 18, false) + this.strFixedSize(footerBE.IPAGOTRANSFERENCIA.ToString("N2"), 20, false), false);
                    if (footerBE.IPAGOEFECTIVO > 0)
                        ticket.AddHeaderLine(this.strFixedSize("Pago Efectivo: ", 18, false) + this.strFixedSize(footerBE.IPAGOEFECTIVO.ToString("N2"), 20, false), false);

                    ticket.AddHeaderLine(this.strFixedSize("Cambio:", 18, false) + this.strFixedSize(footerBE.ICAMBIO.ToString("N2"), 20, false), false);
                }

                ticket.AddHeaderLine(new string('-', TicketR.maxChar));
                ticket.AddHeaderLine(new string(' ', TicketR.maxChar));


                ticket.AddHeaderLine("(" + totalEnLetra + ")", true);
                ticket.AddHeaderLine(new string(' ', TicketR.maxChar));
                ticket.AddHeaderLine(new string('-', TicketR.maxChar));

                if (!(bool)m_empresa.isnull["IFOOTER"])
                {
                    if (m_empresa.IFOOTER != "")
                    {
                        string[] splitFooter = m_empresa.IFOOTER.Split(splitSeparator, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string strFtr in splitFooter)
                        {
                            ticket.AddHeaderLine(strFtr, true);
                        }
                    }
                }

                AgregarLeyendaPlazoSiAplica(ref ticket, m_Docto.IPLAZOID);

                ticket.AddHeaderLine(new string(' ', TicketR.maxChar));
                ticket.AddHeaderLine("FORMA DE PAGO: " + (clienteBE.m_PersonaBE.IPAGOPARCIALIDADES.Equals("S") ? "PAGO EN PARCIALIDADES" : "PAGO EN UNA SOLA EXHIBICION"), true);
                ticket.AddHeaderLine(new string(' ', TicketR.maxChar));
                ticket.AddHeaderLine("REGIMEN TRIBUTARIO: " + m_empresa.IFISCALREGIMEN, true);
                ticket.AddHeaderLine(new string(' ', TicketR.maxChar));
                ticket.AddHeaderLine("ESTE DOCUMENTO ES UNA REPRESENTACION IMPRESA DE UN CFDI", true);

                ticket.AddHeaderLine(new string(' ', TicketR.maxChar));
                ticket.AddHeaderLine("Lo atendio: " + usuarioBE.ICLAVE + " hora: " + m_Docto.IFECHAHORA.ToString("HH:mm:ss"), true);




                ticket.AddFooterLine("");

                String printer = ConexionesBD.ConexionBD.currentPrinter;//TicketR.GetReceiptPrinter(m_empresa);//"IposPrinter3";//TicketR.GetReceiptPrinter(this.m_compania);
                if (printer != "")
                    ticket.PrintTicketDirect(printer);




                return true;

            }
            catch (Exception ex)
            {

                if (!m_silentMode)
                {
                    MessageBox.Show("Error al procesar el pdf " + ex.Message + ex.StackTrace);
                }
                else
                {
                    m_iComentario = "Error al procesar el pdf " + ex.Message + ex.StackTrace;
                }
                return false;
            }





        }





        public bool ImprimirTicketFacturaElectronica33(string tipoComprobante = "")
        {
            try
            {

                var prefixComprobante = obtainPrefixByTipoComprobante(tipoComprobante);

                Ticket ticket = new Ticket();
                ticket.OpenDrawer(ConexionesBD.ConexionBD.currentPrinter);//"IposPrinter3");

                FastReport.Report report = new FastReport.Report();
                report.Load(FastReportsConfig.getPathForFile(@"TicketFE33.frx", FastReportsTipoFile.desistema));
                FastReport.Utils.Config.ReportSettings.ShowProgress = false;

                report.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
                report1.SetParameterValue("US_ID", ConexionesBD.ConexionBD.CurrentUser.IID);
                report1.SetParameterValue("US_NAME", ConexionesBD.ConexionBD.CurrentUser.IID);


                report.SetParameterValue("doctoId", m_Docto.IID);
                //Aqui llenas todos los parametros

                string strTimbrados = getFileLocalLocation_FE_XML_Timbrados(m_Docto.ITIPODOCTOID, m_empresa, tipoComprobante);
                report.SetParameterValue("desgloseKits", this.bDeslosaKits.ToString());
                report.SetParameterValue("imagenBicode", "file:///" + /*System.AppDomain.CurrentDomain.BaseDirectory +*/ getFileLocalLocation_FE_XML_Timbrados(m_Docto.ITIPODOCTOID, m_empresa, tipoComprobante) + "\\" + prefixComprobante + m_currentSerieSat + m_currentFolioSat.ToString() + ".xml.png");
                report.SetParameterValue("logoEmpresa", "file:///" /*+ System.AppDomain.CurrentDomain.BaseDirectory*/ + getFileLocalLocation_FE_IMG(m_empresa) + "\\logofarmafree.png");


                Image bitmap = global::iPosReporting.Properties.Resources.CANCELADA_G;
                string strImgCanc = ConvertImageToBase64(bitmap, ImageFormat.Png);
                report.SetParameterValue("bgImage", m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_CANCELADA ? strImgCanc : null);

                string bufferNumCSD = Path.GetFileName(m_empresa.ITIMBRADOARCHIVOCERTIFICADO);
                report.SetParameterValue("num_serie_cert_csd", bufferNumCSD.Substring(0, bufferNumCSD.Length - 4).ToUpper());


                report.PrintSettings.ShowDialog = false;
                report.Prepare();

               

                report.PrintSettings.Printer = ConexionesBD.ConexionBD.currentPrinter;

                try
                {

                    report.Print();
                }
                catch (Exception ex)
                {

                    if (!m_silentMode)
                    {
                        MessageBox.Show("Error al procesar el ticket " + ex.Message + ex.StackTrace);
                    }
                    else
                    {
                        m_iComentario = "Error al procesar el ticket " + ex.Message + ex.StackTrace;
                    }
                    return false;
                }
            }
            catch(Exception ex2)
            {

                if (!m_silentMode)
                {
                    MessageBox.Show("Error al procesar el ticket " + ex2.Message + ex2.StackTrace);
                }
                else
                {
                    m_iComentario = "Error al procesar el ticket " + ex2.Message + ex2.StackTrace;
                }
                return false;
            }

            return true;
        }


        public String strFixedSize(string bufferLine, int iSize, bool padRight)
        {
            if (padRight)
                return bufferLine.Substring(0, Math.Min(iSize, bufferLine.Length)).PadRight(iSize);
            else
                return bufferLine.Substring(0, Math.Min(iSize, bufferLine.Length)).PadLeft(iSize);
        }


        private bool ChecarDatos()
        {

            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOPAGOD pagoD = new CDOCTOPAGOD();
            CDOCTOPAGOBE pagoBE;

            bool esVersion33 = (m_empresa.IVERSIONCFDI != null && m_empresa.IVERSIONCFDI.Equals("3.3"));
            bool esVersion40 = (m_empresa.IVERSIONCFDI != null && m_empresa.IVERSIONCFDI.Equals("4.0"));
            bool esReciboElectronico = this.m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_RECIBOELECTRONICO;
            string tipoComprobante = obtainTipoComprobanteByMode(this.m_mode).Trim();


            pagoBE = m_doctoPago;

            if (!(esVersion33 || esVersion40) || !esReciboElectronico)
            {

                if (!m_pagotemporal && tipoComprobante != "T")
                {

                    if (((bool)m_Docto.isnull["IDOCTOPAGOSAT"] || m_Docto.IDOCTOPAGOSAT == 0) &&
                        ((bool)m_Docto.isnull["IPAGOSAT"] || m_Docto.IPAGOSAT == 0))
                    {

                        // checar forma de pago
                        WFFacturaFormaPago wfForma_ = new WFFacturaFormaPago((int)this.m_Docto.IID, m_fTrans);
                        wfForma_.ShowDialog();

                        DataRow dr = wfForma_.m_rtnDataRow;

                        wfForma_.Dispose();
                        GC.SuppressFinalize(wfForma_);

                        if (dr == null && 
                            (m_Docto.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_VENDMOVIL ||
                             (m_Docto.ICOTI_ENRUTADA == "S")) && 
                            this.m_vendedorId != -1 )
                        {

                            if (doctoD.VENTAMOVIL_ASIGNARPAGOCREDITO(m_Docto.IID, m_vendedorId, m_fTrans))
                            {
                                wfForma_ = new WFFacturaFormaPago((int)this.m_Docto.IID, m_fTrans);
                                wfForma_.ShowDialog();
                                dr = wfForma_.m_rtnDataRow;

                                wfForma_.Dispose();
                                GC.SuppressFinalize(wfForma_);
                            }
                            else
                            {
                                MessageBox.Show("Error al asignar el pago " + doctoD.IComentario);
                            }
                        }

                        if (dr == null)
                        {
                            if (!m_silentMode)
                            {
                                MessageBox.Show("Primero defina la forma de pago de la factura");
                            }
                            else
                            {
                                m_iComentario = "Primero defina la forma de pago de la factura";
                            }
                            return false;
                        }
                        //m_nombreFormaPago = doctoD.CALCULAR_TIMBRADOFORMAPAGOSAT(m_Docto, m_fTrans);//(string)dr["NOMBRE"];
                        pagoBE = new CDOCTOPAGOBE();
                        pagoBE.IID = (long)dr["ID"];
                        pagoBE = pagoD.seleccionarDOCTOPAGO(pagoBE, m_fTrans);
                    }
                    else
                    {


                        pagoBE = new CDOCTOPAGOBE();
                        pagoBE.IID = m_Docto.IDOCTOPAGOSAT;
                        pagoBE = pagoD.seleccionarDOCTOPAGO(pagoBE, m_fTrans);
                    }


                    if (pagoBE == null)
                    {

                        if (!m_silentMode)
                        {
                            MessageBox.Show("hubo un problema no se pudo definir la forma de pago");
                        }
                        else
                        {
                            m_iComentario = "hubo un problema no se pudo definir la forma de pago";
                        }
                        return false;
                    }

                    string strTIMBRADOFORMAPAGOSAT = "";
                    if (doctoD.CALCULAR_TIMBRADOFORMAPAGOSAT(m_Docto, ref strTIMBRADOFORMAPAGOSAT, m_fTrans))
                    {
                        m_nombreFormaPago = strTIMBRADOFORMAPAGOSAT;
                    }
                    else
                    {
                        if (!m_silentMode)
                        {
                            MessageBox.Show("No se pudo determinar la forma de pago para el sat, error: " + doctoD.IComentario);
                        }
                        else
                        {
                            m_iComentario = "No se pudo determinar la forma de pago para el sat, error: " + doctoD.IComentario;
                        }
                        return false;
                    }


                }
                else
                {
                    pagoBE = new CDOCTOPAGOBE();
                    pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_EFECTIVO;
                    pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_OTRO;

                    m_nombreFormaPago = m_formapagosattemporal;

                    if (m_nombreFormaPago == "")
                        m_nombreFormaPago = "99";// "N / A"/*"No Identificado"*/;

                }

                if ((pagoBE.IFORMAPAGOID == DBValues._FORMA_PAGO_CHEQUE || pagoBE.IFORMAPAGOID == DBValues._FORMA_PAGO_TARJETA) && ((bool)pagoBE.isnull["IREFERENCIABANCARIA"] || pagoBE.IREFERENCIABANCARIA.Trim() == "" || pagoBE.IREFERENCIABANCARIA == null))
                {

                    WFReferenciaPago wfreferencia_ = new WFReferenciaPago();
                    wfreferencia_.ShowDialog();
                    string referencia_ = wfreferencia_.m_referencia;

                    wfreferencia_.Dispose();
                    GC.SuppressFinalize(wfreferencia_);

                    if (referencia_.Trim() == "")
                    {

                        if (!m_silentMode)
                        {
                            MessageBox.Show("Necesita definir la referencia de pago");
                        }
                        else
                        {
                            m_iComentario = "Necesita definir la referencia de pago";
                        }
                        return false;
                    }

                    pagoBE.IREFERENCIABANCARIA = referencia_;

                    if (!m_pagotemporal)
                    {
                        if (!pagoD.CambiarReferenciaDOCTOPAGOD(pagoBE, pagoBE, m_fTrans))
                        {
                            if (!m_silentMode)
                            {
                                MessageBox.Show("hubo un problema al guardar la referencia de pago");
                            }
                            else
                            {
                                m_iComentario = "hubo un problema al guardar la referencia de pago";
                            }
                            return false;
                        }
                    }
                }

                m_doctoPago = pagoBE;

            }
            

            //checar folio de factura
            if ((bool)m_Docto.isnull["IFOLIOSAT"] || m_Docto.IFOLIOSAT == 0 || m_Docto.IFOLIOSAT == -3 || tipoComprobante.Trim().Length > 0)
            {
                if (!doctoD.LLENAR_FOLIO_FACTURAELECTRONICA(m_Docto, tipoComprobante, m_fTrans))
                {
                    if (!m_silentMode)
                    {
                        MessageBox.Show("Ocurrio un Error " + doctoD.IComentario);
                    }
                    else
                    {
                        m_iComentario = "Ocurrio un Error " + doctoD.IComentario;
                    }
                    return false;
                }
                m_Docto = doctoD.seleccionarDOCTO(m_Docto, m_fTrans);
            }
            this.fillSerieFactura();


            return true;
        }








        private void WFFacturaElectronica_Load(object sender, EventArgs e)
        {
            ProcesarForm();

        }



        private void ProcesarForm()
        {

            // TODO: This line of code loads data into the 'dSReportIpos2.REP_FACTURAELECTRONICA_DET' table. You can move, or remove it, as needed.
            bool bRes;

            bool esVersion33 = (m_empresa.IVERSIONCFDI != null && m_empresa.IVERSIONCFDI.Equals("3.3"));
            bool esVersion40 = (m_empresa.IVERSIONCFDI != null && m_empresa.IVERSIONCFDI.Equals("4.0"));
            bool esReciboElectronico = this.m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_RECIBOELECTRONICO;


            if (this.m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_FACTCONSOLIDADA || this.m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_DEVCONSOLIDADA)
            {
                m_doctoPago = new CDOCTOPAGOBE();
                m_doctoPago.IFORMAPAGOID = 1;
                m_doctoPago.IREFERENCIABANCARIA = "";
                m_pagotemporal = true;
            }


            if (this.m_mode == _MODE_DIALOGO_FACTURA_ELECTRONICA_TIMBRAR || this.m_mode == _MODE_DIALOGO_FACTURA_ELECTRONICA_COMPROBTRASL)
            {


                bRes = ChecarDatos();
                
                //si ya se facturo
                if (this.m_mode == _MODE_DIALOGO_FACTURA_ELECTRONICA_TIMBRAR && 
                    (m_Docto.ITIMBRADOUUID != null && m_Docto.ITIMBRADOUUID.Length > 3 && m_Docto.IFOLIOSAT > 0))
                {
                    m_facturacionRealizada = bRes;
                    this.Close();
                    return;
                }

                if(this.m_mode == _MODE_DIALOGO_FACTURA_ELECTRONICA_COMPROBTRASL)
                {
                    if (ComprobanteDeTrasladoExisteYEstaTimbrado())
                    {
                        m_facturacionRealizada = bRes;
                        this.Close();
                        return;
                    }
                }


                //consideracion de tipo comprobante traslado
                var tipoComprobante = obtainTipoComprobanteByMode(this.m_mode);
                var prefixComprobante = obtainPrefixByTipoComprobante(tipoComprobante);

                //ruta de documentos
                string pathSinTimbrar = getFileLocalLocation_FE_XML_SinTimbrar(m_Docto.ITIPODOCTOID, m_empresa, tipoComprobante);
                string pathTimbrado = getFileLocalLocation_FE_XML_Timbrados(m_Docto.ITIPODOCTOID, m_empresa, tipoComprobante);
                string documentoSinTimbrar = pathSinTimbrar + "\\" + prefixComprobante + m_currentSerieSat + m_currentFolioSat.ToString() + ".xml";
                string documentoTimbrado = pathTimbrado + "\\" + prefixComprobante + m_currentSerieSat + m_currentFolioSat.ToString() + ".xml";
                makeSureFolderExists(pathSinTimbrar);
                makeSureFolderExists(pathTimbrado);

                if (bRes)
                {

                    DefinirDatosEntrega();

                    TimeSpan span = DateTime.Now.Subtract(m_Docto.IFECHAHORA);

                    if (m_Docto.IFECHAHORA.Month == DateTime.Now.Month && span.Days < 3)
                    {
                        //m_Docto.ITIMBRADOFECHAFACTURA = m_Docto.IFECHAHORA;
                        m_Docto.ITIMBRADOFECHAFACTURA = DateTime.Now;
                    }
                    else if (/*m_Docto.IFECHAHORA.Month < DateTime.Now.Month*/ span.Days >= 0)
                    {

                        m_Docto.ITIMBRADOFECHAFACTURA = DateTime.Now;
                    }
                    else
                    {
                        m_facturacionRealizada = false;
                        if (!m_silentMode)
                        {
                            MessageBox.Show("La factura no puede ser de una fecha posterior al dia de hoy");
                        }
                        else
                        {
                            m_iComentario = "La factura no puede ser de una fecha posterior al dia de hoy";
                        }
                        this.Close();
                        return;
                    }



                    if (!AsignarPedimentosSiAplica())
                    {
                        m_facturacionRealizada = false;
                        this.Close();
                        return;
                    }

                    try
                    {
                        

                        LlenarDetalles();
                        LlenarDetallesRef();
                        LlenarDetallesAduaneros();

                        if (m_empresa.IVERSIONCFDI != null && (m_empresa.IVERSIONCFDI.Equals("3.3") || m_empresa.IVERSIONCFDI.Equals("4.0")))
                        {

                            bRes = ObtenerDatosDocumentoVirtualXmlCfdi33(tipoComprobante);
                        }
                    }
                    catch (Exception ex)
                    {

                    }

                    if (!DesAsignarPedimentosSiAplica())
                    {
                        m_facturacionRealizada = false;
                        this.Close();
                        return;
                    }




                    if (File.Exists(documentoSinTimbrar))
                    {
                        File.Delete(documentoSinTimbrar);
                    }



                    if (File.Exists(documentoTimbrado))
                    {
                        if (MessageBox.Show("Parece ser que en la carpeta donde se guardan las facturas electronica ya existe el folio a ser ingresado, desea continuar con la facturacion?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            File.Delete(documentoTimbrado);

                            string documentoPDF = getFileLocalLocation_FE_PDF(m_Docto.ITIPODOCTOID, m_empresa) + "\\" + m_currentSerieSat + m_currentFolioSat.ToString() + "_" + m_empresa.IRFC + ".pdf";
                            if (File.Exists(documentoPDF))
                            {
                                File.Delete(documentoPDF);
                            }
                        }
                        else
                        {

                            m_facturacionRealizada = false;
                            this.Close();
                            return;
                        }
                    }


                    if (m_bUsarLibreriaVirtualXML)
                    {
                        if (m_empresa.IVERSIONCFDI != null && (m_empresa.IVERSIONCFDI.Equals("3.3") || m_empresa.IVERSIONCFDI.Equals("4.0")))
                        {
                            bRes = GenerarDocumentoVirtualXmlCfdi33(documentoTimbrado, tipoComprobante);
                        }
                        else
                        {
                            bRes = GenerarDocumentoVirtualXml(documentoTimbrado);
                        }

                        if (bRes)
                        {

                            if (m_empresa.IVERSIONCFDI != null && (m_empresa.IVERSIONCFDI.Equals("3.3") || m_empresa.IVERSIONCFDI.Equals("4.0")))
                            {
                                bRes =  ObtenerDatosDelTimbrado33(documentoTimbrado, tipoComprobante);
                            }
                            else
                            {
                                bRes = ObtenerDatosDelTimbrado(documentoTimbrado);
                            }
                        }
                        else
                        {
                            if(m_generarCartaPorte)
                            {

                                VirtualXml.UIHelpers.WFCartaPorteDetalles ml = new VirtualXml.UIHelpers.WFCartaPorteDetalles(virtualXmlHelper.ICARTAPORTE);
                                ml.ShowDialog();
                                ml.Dispose();
                                GC.SuppressFinalize(ml);
                            }
                        }
                    }
                    else
                    {

                        bRes = GenerateXMLSinTimbrar(documentoSinTimbrar);
                        if (bRes)
                            bRes = TimbrarDocumento(documentoSinTimbrar, documentoTimbrado);
                        if (bRes)
                            bRes = ObtenerDatosDelTimbrado(documentoTimbrado);

                        if (bRes)
                        {
                            File.Delete(documentoSinTimbrar);
                            // MessageBox.Show("La factura electronica se ha realizado");
                            // System.Diagnostics.Process.Start(documentoPDF);
                        }

                    }




                }

                m_facturacionRealizada = bRes;
            }
            else if (this.m_mode == _MODE_DIALOGO_FACTURA_ELECTRONICA_GENERARPDF || this.m_mode == _MODE_DIALOGO_FACTURA_ELECTRONICA_GENPDF_COMPROBTRASL)
            {

                this.fillSerieFactura();

                //consideracion de tipo comprobante traslado
                var tipoComprobante = obtainTipoComprobanteByMode(this.m_mode);
                var prefixComprobante = obtainPrefixByTipoComprobante(tipoComprobante);

                //llenado de datos
                LlenarDetalles();
                LlenarDetallesRef();

                //ruta de documentos
                string pathPDFNormal = getFileLocalLocation_FE_PDF(m_Docto.ITIPODOCTOID, m_empresa, tipoComprobante);
                string pathTimbrado = getFileLocalLocation_FE_XML_Timbrados(m_Docto.ITIPODOCTOID, m_empresa, tipoComprobante);
                string pathPDFCancelado = getFileLocalLocation_FE_XML_Timbrados(m_Docto.ITIPODOCTOID, m_empresa, tipoComprobante);
                string documentoPDFNormal = getFileLocalLocation_FE_PDF(m_Docto.ITIPODOCTOID, m_empresa, tipoComprobante) + "\\" + prefixComprobante + m_currentSerieSat + m_currentFolioSat.ToString() + "_" + m_empresa.IRFC + ".pdf";
                string documentoTimbrado = getFileLocalLocation_FE_XML_Timbrados(m_Docto.ITIPODOCTOID, m_empresa, tipoComprobante) + "\\" + prefixComprobante + m_currentSerieSat + m_currentFolioSat.ToString() + ".xml";
                string documentoPDFCancelado = getFileLocalLocation_FE_PDF_Cancelaciones(m_Docto.ITIPODOCTOID, m_empresa, tipoComprobante) + "\\" + prefixComprobante + m_currentSerieSat + m_currentFolioSat.ToString() + "_" + m_empresa.IRFC + ".pdf";
                makeSureFolderExists(pathPDFNormal);
                makeSureFolderExists(pathTimbrado);
                makeSureFolderExists(pathPDFCancelado);

                string documentoPDF = m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_CANCELADA || this.m_bSeEstaCancelandoVenta ? documentoPDFCancelado : documentoPDFNormal;

                bRes = true;

                bool filePDFExists = File.Exists(documentoPDF);

                CDOCTOPAGOD pagoD = new CDOCTOPAGOD();
                CDOCTOPAGOBE pagoBE = new CDOCTOPAGOBE();

                if (!filePDFExists)
                {

                    //if (!esVersion33 || esReciboElectronico)
                    //{
                        if (this.m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_FACTCONSOLIDADA || this.m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_DEVCONSOLIDADA)
                        {
                            pagoBE = m_doctoPago;
                        }
                        else if (esReciboElectronico)
                        {
                            
                            pagoBE = pagoD.seleccionarPrimerDOCTOPAGOxReciboElectronico(m_Docto, m_fTrans);
                        }
                        else
                        {
                            pagoBE.IID = m_Docto.IDOCTOPAGOSAT;
                            pagoBE = pagoD.seleccionarDOCTOPAGO(pagoBE, m_fTrans);
                        }


                        if (pagoBE == null && tipoComprobante == "T")
                        {

                            pagoBE = new CDOCTOPAGOBE();
                            pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_EFECTIVO;
                            pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_OTRO;

                            m_nombreFormaPago = m_formapagosattemporal;

                            if (m_nombreFormaPago == "")
                                m_nombreFormaPago = "99";
                        }   

                        if (pagoBE == null)
                        {

                            if (!m_silentMode)
                            {
                                MessageBox.Show("hubo un problema no se pudo definir la forma de pago");
                            }
                            else
                            {
                                m_iComentario = "hubo un problema no se pudo definir la forma de pago";
                            }
                            bRes = false;
                        }
                    //}
                }


                if (bRes)
                {

                    if (!filePDFExists)
                    {
                        //if (!esVersion33 || esReciboElectronico)
                        //{
                            m_doctoPago = pagoBE;
                            m_nombreFormaPago = m_Docto.ITIMBRADOFORMAPAGOSAT;//pagoD.obtenNombreFormaPagoSat(m_doctoPago, m_fTrans);
                            if (m_nombreFormaPago == null || m_nombreFormaPago == "")
                            {
                                string strTIMBRADOFORMAPAGOSAT = "";
                                CDOCTOD doctoDE = new CDOCTOD();
                                if (doctoDE.CALCULAR_TIMBRADOFORMAPAGOSAT(m_Docto, ref strTIMBRADOFORMAPAGOSAT, m_fTrans))
                                {
                                    m_nombreFormaPago = strTIMBRADOFORMAPAGOSAT;
                                }
                                if (m_nombreFormaPago == null || m_nombreFormaPago == "")
                                {
                                    m_nombreFormaPago = "99";// "N / A"/*"No Identificado"*/;
                                }
                            }
                        //}
                        //else
                        //{
                        //    m_nombreFormaPago = "";
                        //}
                        getIvaToDisplay();

                        bRes = GeneratePDF(documentoPDF, tipoComprobante);
                    }

                    m_facturacionRealizada = bRes;
                    if (bRes)
                    {
                        //se abrira el pdf desde la pantalla de envio mail


                        CCLIENTEBE clienteBE = new CCLIENTEBE();
                        CPERSONAD personaD = new CPERSONAD();
                        clienteBE.m_PersonaBE.IID = m_Docto.IPERSONAID;
                        clienteBE.m_PersonaBE = personaD.seleccionarPERSONA(clienteBE.m_PersonaBE, m_fTrans);

                        string tipoDocumento = m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_RECIBOELECTRONICO ? "Recibo electronico de pago " : "Factura electronica ";

                        if (!m_silentMode)
                        {
                            string mailSubject = tipoDocumento + " " + m_currentFolioSat + " de la empresa " + ((!(bool)m_empresa.isnull["IFISCALNOMBRE"]) ? m_empresa.IFISCALNOMBRE : m_empresa.INOMBRE);
                            string mailBody = "Envio de " + tipoDocumento + " " + m_currentFolioSat + " de la empresa " + ((!(bool)m_empresa.isnull["IFISCALNOMBRE"]) ? m_empresa.IFISCALNOMBRE : m_empresa.INOMBRE);

                            if (m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_CANCELADA || this.m_bSeEstaCancelandoVenta)
                            {
                                mailSubject = "Cancelacion de " + tipoDocumento + " "  + m_currentFolioSat + " de la empresa " + ((!(bool)m_empresa.isnull["IFISCALNOMBRE"]) ? m_empresa.IFISCALNOMBRE : m_empresa.INOMBRE);
                                mailBody = "Por este medio le informamos que hemos cancelado el comprobante fiscal digital #UUID " + m_Docto.ITIMBRADOUUID + ", y ha quedado sin efectos fiscales para su empresa, por lo que pedimos eliminarlo y no incluirlo en su contabilidad, ya que puede representar un problema fiscal para usted o su empresa cuando el SAT realice una futura auditoria en su contabilidad ";
                            }

                            WFFacturaEnvioMail ml = new WFFacturaEnvioMail(m_empresa.ISMTPHOST,
                                                                           m_empresa.ISMTPMAILFROM,
                                                                           mailSubject,
                                                                           mailBody,
                                                                           m_empresa.ISMTPPORT,
                                                                           m_empresa.ISMTPSSL.Equals("S"),
                                                                           m_empresa.ISMTPUSUARIO,
                                                                           m_empresa.ISMTPPASSWORD,
                                                                           documentoPDF,
                                                                           documentoTimbrado,
                                                                           clienteBE.m_PersonaBE.IEMAIL1,
                                                                           clienteBE.m_PersonaBE);
                            ml.ShowDialog();
                            ml.Dispose();
                            GC.SuppressFinalize(ml);
                        }
                        else
                        {
                            //TO DO

                            CPERSONABE vendedorBE = new CPERSONABE();
                            vendedorBE.IID = m_Docto.IVENDEDORID;
                            vendedorBE = personaD.seleccionarPERSONA(vendedorBE, m_fTrans);

                            string emailTo = clienteBE.m_PersonaBE.IEMAIL1 != null && clienteBE.m_PersonaBE.IEMAIL1.Contains("@") ? clienteBE.m_PersonaBE.IEMAIL1 : "";
                            emailTo += vendedorBE.IEMAIL1 != null && vendedorBE.IEMAIL1.Contains("@") ? (emailTo == "" ? "" : ",") + vendedorBE.IEMAIL1 : "";

                            if (emailTo != "")
                            {

                                string mailSubject = tipoDocumento + " "  +  m_currentFolioSat + " de la empresa " + ((!(bool)m_empresa.isnull["IFISCALNOMBRE"]) ? m_empresa.IFISCALNOMBRE : m_empresa.INOMBRE);
                                string mailBody = "Envio de " + tipoDocumento + " " + m_currentFolioSat + " de la empresa " + ((!(bool)m_empresa.isnull["IFISCALNOMBRE"]) ? m_empresa.IFISCALNOMBRE : m_empresa.INOMBRE);


                                if (m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_CANCELADA || this.m_bSeEstaCancelandoVenta)
                                {
                                    mailSubject = "Cancelacion de " + tipoDocumento + " "  + m_currentFolioSat + " de la empresa " + ((!(bool)m_empresa.isnull["IFISCALNOMBRE"]) ? m_empresa.IFISCALNOMBRE : m_empresa.INOMBRE);
                                    mailBody = "Por este medio le informamos que hemos cancelado el comprobante fiscal digital #UUID " + m_Docto.ITIMBRADOUUID + ", y ha quedado sin efectos fiscales para su empresa, por lo que pedimos eliminarlo y no incluirlo en su contabilidad, ya que puede representar un problema fiscal para usted o su empresa cuando el SAT realice una futura auditoria en su contabilidad ";
                                }


                                WFFacturaEnvioMail ml = new WFFacturaEnvioMail(m_empresa.ISMTPHOST,
                                                                           m_empresa.ISMTPMAILFROM,
                                                                           mailSubject,
                                                                           mailBody,
                                                                           m_empresa.ISMTPPORT,
                                                                           m_empresa.ISMTPSSL.Equals("S"),
                                                                           m_empresa.ISMTPUSUARIO,
                                                                           m_empresa.ISMTPPASSWORD,
                                                                           documentoPDF,
                                                                           documentoTimbrado,
                                                                           emailTo,
                                                                           clienteBE.m_PersonaBE);
                                ml.m_silentMode = true;
                                ml.ShowDialog();
                                ml.Dispose();
                                GC.SuppressFinalize(ml);
                            }
                        }



                    }
                }
            }
            else if (this.m_mode == _MODE_DIALOGO_FACTURA_ELECTRONICA_IMPRIMIRTICKET || this.m_mode == _MODE_DIALOGO_COMPROB_TRASL_IMPRIMIRTICKET)
            {

                //consideracion de tipo comprobante traslado
                var tipoComprobante = obtainTipoComprobanteByMode(this.m_mode);
                var prefixComprobante = obtainPrefixByTipoComprobante(tipoComprobante);

                //llenar datos
                LlenarDetalles();
                LlenarDetallesRef();


                //ruta de documentos
                string pathPDF = getFileLocalLocation_FE_PDF(m_Docto.ITIPODOCTOID, m_empresa, tipoComprobante);
                string pathTimbrado = getFileLocalLocation_FE_XML_Timbrados(m_Docto.ITIPODOCTOID, m_empresa, tipoComprobante);
                string documentoPDF = /*System.AppDomain.CurrentDomain.BaseDirectory +*/ getFileLocalLocation_FE_PDF(m_Docto.ITIPODOCTOID, m_empresa, tipoComprobante) + "\\" + prefixComprobante + m_currentSerieSat + m_currentFolioSat.ToString() + ".pdf";
                string documentoTimbrado = /*System.AppDomain.CurrentDomain.BaseDirectory +*/ getFileLocalLocation_FE_XML_Timbrados(m_Docto.ITIPODOCTOID, m_empresa, tipoComprobante) + "\\" + prefixComprobante + m_currentSerieSat + m_currentFolioSat.ToString() + ".xml";
                makeSureFolderExists(pathPDF);
                makeSureFolderExists(pathTimbrado);

                bRes = true;
                
                CDOCTOPAGOD pagoD = new CDOCTOPAGOD();
                CDOCTOPAGOBE pagoBE = new CDOCTOPAGOBE();

                if (this.m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_FACTCONSOLIDADA || this.m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_DEVCONSOLIDADA)
                {
                    pagoBE = m_doctoPago;
                }
                else
                {
                    pagoBE.IID = m_Docto.IDOCTOPAGOSAT;
                    pagoBE = pagoD.seleccionarDOCTOPAGO(pagoBE, m_fTrans);
                }



                if (pagoBE == null)
                {

                    if (!m_silentMode)
                    {
                        MessageBox.Show("hubo un problema no se pudo definir la forma de pago");
                    }
                    else
                    {
                        m_iComentario = "hubo un problema no se pudo definir la forma de pago";
                    }
                    bRes = false;
                }
                if (bRes)
                {
                    m_doctoPago = pagoBE;
                    m_nombreFormaPago = m_Docto.ITIMBRADOFORMAPAGOSAT;//pagoD.obtenNombreFormaPagoSat(m_doctoPago, m_fTrans);
                    if (m_nombreFormaPago == "")
                        m_nombreFormaPago = "99";// "N / A"/*"No Identificado"*/;

                    getIvaToDisplay();

                    if (m_empresa.IRECIBOLARGOCONFACTURA.Equals("S") || m_bForzarImpresionTicket)
                    {
                        if (m_Docto.ICFDIID > 0)
                            bRes = ImprimirTicketFacturaElectronica33();
                        else
                            bRes = ImprimirTicketFacturaElectronica();
                    }

                    m_facturacionRealizada = bRes;

                }
            }
            else if (this.m_mode == _MODE_DIALOGO_FACTURA_ELECTRONICA_CANCELAR)
            {
                //si ya esta cancelada en el SAT    
                if (m_Docto.ITIMBRADOCANCELADO != null && m_Docto.ITIMBRADOCANCELADO.Equals("S"))
                {
                    m_facturacionCancelada = true;
                }
                else
                {
                    string documentoTimbrado = getFileLocalLocation_FE_XML_Timbrados(m_Docto.ITIPODOCTOID, m_empresa) + "\\" + m_Docto.ISERIESAT + m_Docto.IFOLIOSAT.ToString() + ".xml";
                    string documentoResultado = getFileLocalLocation_FE_XML_Cancelaciones(m_Docto.ITIPODOCTOID, m_empresa) + "\\" + m_Docto.ISERIESAT + m_Docto.IFOLIOSAT.ToString() + ".txt";
                    string documentoLog = getFileLocalLocation_FE_XML_Cancelaciones(m_Docto.ITIPODOCTOID, m_empresa) + "\\" + m_Docto.ISERIESAT + m_Docto.IFOLIOSAT.ToString() + ".log";

                    string rutaPDFCancelado = getFileLocalLocation_FE_PDF_Cancelaciones(m_Docto.ITIPODOCTOID, m_empresa);


                    //obtener datos del cliente
                    CCLIENTEBE clienteBE = new CCLIENTEBE();
                    CPERSONAD personaD = new CPERSONAD();
                    clienteBE.m_PersonaBE.IID = m_Docto.IPERSONAID;
                    clienteBE.m_PersonaBE = personaD.seleccionarPERSONA(clienteBE.m_PersonaBE, m_fTrans);


                    m_facturacionCancelada = false;

                    bool bError = false;

                    decimal total = m_Docto.ITOTAL;
                    string claveMotivo = "02";
                    string folioSustitucion = "";

                    if (esVersion33 || esVersion40)
                    {
                        decimal limiteCancelacion = m_empresa.IVERSIONCFDI.Equals("4.0") ? DBValues._LIMITE_CANCELACION_40 : DBValues._LIMITE_CANCELACION_33;
                        
                        //validacion previa
                        switch (m_Docto.ITIPODOCTOID)
                        {
                            
                            case DBValues._DOCTO_TIPO_VENTA:

                                if (m_Docto.ITOTAL > limiteCancelacion && m_Docto.ITIMBRADOFECHAFACTURA.AddDays(DBValues._LIMITE_DIASCANCELACION_33).CompareTo(DateTime.Today) < 0)
                                {
                                    bRes = false;
                                    MessageBox.Show($"La cancelacion de ventas de mas de {limiteCancelacion} o de una fecha anterior a 3 dias no debe hacerse directa. Vaya al punto de venta e intente hacer la cancelacion ahi para que le salgan mas opciones");
                                }
                                    break;
                            case DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO:
                                if (m_Docto.ITIMBRADOFECHAFACTURA.AddDays(1003).CompareTo(DateTime.Today) < 0)
                                {
                                    bRes = false;
                                    bError = true;
                                    MessageBox.Show("La cancelacion de nota de credito de una fecha anterior a 3 dias no debe hacerse directa");
                                }
                                break;
                            case DBValues._DOCTO_TIPO_RECIBOELECTRONICO:
                                    total = 0;
                                    if ( m_Docto.ITIMBRADOFECHAFACTURA.AddDays(1003).CompareTo(DateTime.Today) < 0)
                                    {
                                        bRes = false;
                                        bError = true;
                                        MessageBox.Show("La cancelacion de pagos de una fecha anterior a 3 dias no debe hacerse directa");
                                    }
                                break;
                        }


                        if (!bError)
                        {
                            //if (esVersion33)
                            //    bRes = CancelarDocumento33(documentoTimbrado, documentoResultado, m_Docto.ITIMBRADOUUID,
                            //                             documentoLog, clienteBE.m_PersonaBE.IRFC, total);
                            if (esVersion40 || esVersion33)
                                bRes = CancelarDocumento40(documentoTimbrado, documentoResultado, m_Docto.ITIMBRADOUUID,
                                                         documentoLog, clienteBE.m_PersonaBE.IRFC, total, claveMotivo, folioSustitucion);
                            else
                                bRes = false;
                        }
                        else
                            bRes = false;
                    }
                    else
                    {
                        bRes = CancelarDocumento(documentoTimbrado, documentoResultado, m_Docto.ITIMBRADOUUID);
                    }

                    if (bRes)
                    {
                        m_facturacionCancelada = true;


                        // manda cancelacion 
                        try
                        {

                            bool exists = System.IO.Directory.Exists(rutaPDFCancelado);
                            bError = false;

                            try
                            {
                                if (!exists)
                                    System.IO.Directory.CreateDirectory(rutaPDFCancelado);
                            }
                            catch
                            {
                                bError = true;
                                MessageBox.Show("No se pudo crear la carpeta de canceladas en " + rutaPDFCancelado);
                            }


                            if (!bError)
                            {
                                this.m_mode = _MODE_DIALOGO_FACTURA_ELECTRONICA_GENERARPDF;
                                m_Docto.IESTATUSDOCTOID = DBValues._DOCTO_ESTATUS_CANCELADA;
                                m_bSeEstaCancelandoVenta = true;
                                ProcesarForm();
                            }

                        }
                        catch (Exception ex)
                        {

                        }

                    }




                }

            }
            this.Close();
        }


        private bool AsignarPedimentosSiAplica()
        {
            if (this.m_empresa.IMANEJARLOTEIMPORTACION != null && this.m_empresa.IMANEJARLOTEIMPORTACION.Equals("S"))
            {
                CDOCTOD doctoD = new CDOCTOD();
                if (!doctoD.ASIGNARPEDIMENTO_DOCTO(this.m_Docto, false, m_fTrans))
                {
                    this.m_iComentario = doctoD.IComentario;
                    return false;
                }
                else
                {
                    return true;
                }
            }

            return true;
        }


        private bool DesAsignarPedimentosSiAplica()
        {
            if (this.m_empresa.IMANEJARLOTEIMPORTACION != null && this.m_empresa.IMANEJARLOTEIMPORTACION.Equals("S"))
            {
                CDOCTOD doctoD = new CDOCTOD();
                if (!doctoD.DESASIGNARPEDIMENTOTEMP_DOCTO(this.m_Docto, m_fTrans))
                {
                    this.m_iComentario = doctoD.IComentario;
                    return false;
                }
                else
                {
                    return true;
                }
            }

            return true;
        }


       

        private void LlenarDetalles()
        {


            if (m_fTrans != null)
            {
                this.rEP_FACTURAELECTRONICA_DETTableAdapter.Transaction = m_fTrans;
                this.rEP_FACTURAELECTRONICA_DETTableAdapter.Connection = m_fTrans.Connection;
            }
            try
            {
                this.rEP_FACTURAELECTRONICA_DETTableAdapter.Fill(this.dSReportIpos2.REP_FACTURAELECTRONICA_DET, this.m_Docto.IID, (this.bDeslosaKits ? "S" : "N"));

            }
            catch (Exception ex)
            {
                this.dSReportIpos2.REP_FACTURAELECTRONICA_DET.Clear();



            }

        }


        private void LlenarDetallesRef()
        {

            if (m_DoctoRef == null || m_DoctoRef.IID == 0)
                return;

            if (m_fTrans != null)
            {
                this.rEP_FACTURAELECTRONICA_DET_REFTableAdapter.Transaction = m_fTrans;
                this.rEP_FACTURAELECTRONICA_DET_REFTableAdapter.Connection = m_fTrans.Connection;
            }
            try
            {
                this.rEP_FACTURAELECTRONICA_DET_REFTableAdapter.Fill(this.dSReportIpos2.REP_FACTURAELECTRONICA_DET_REF, this.m_DoctoRef.IID, (this.bDeslosaKits ? "S" : "N"));

            }
            catch (Exception ex)
            {
                this.dSReportIpos2.REP_FACTURAELECTRONICA_DET_REF.Clear();



            }

        }

        public string obtenerContenidoArchivo(string fileName)
        {
            string retorno = "";
            if (!File.Exists(fileName))
            {
                return "";
            }
            StreamReader r = File.OpenText(fileName);
            string line;
            line = r.ReadLine();
            while (line != null)
            {
                retorno = line;
                line = r.ReadLine();
            }
            r.Close();
            return retorno;
        }




        public string getFileLocalLocation_FE_XML(CPARAMETROBE parametro)
        {
            if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_RECIBOELECTRONICO)
                return FileLocalLocation_AE_XML.Replace("\\sampdata", parametro.IFACT_ELECT_FOLDER.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location))); ;
            if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO)
                return FileLocalLocation_DE_XML.Replace("\\sampdata", parametro.IFACT_ELECT_FOLDER.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location))); ;
            return FileLocalLocation_FE_XML.Replace("\\sampdata", parametro.IFACT_ELECT_FOLDER.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location))); ;
        }

        public string getFileLocalLocation_FE_XML_Molde_File(CPARAMETROBE parametro)
        {

            if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_RECIBOELECTRONICO)
                return FileLocalLocation_AE_XML_Molde_File;
            if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO)
                return FileLocalLocation_DE_XML_Molde_File;//.Replace("\\sampdata", parametro.IFACT_ELECT_FOLDER.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location))); ;
            return FileLocalLocation_FE_XML_Molde_File;//.Replace("\\sampdata", parametro.IFACT_ELECT_FOLDER.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location))); ;
        }


        public string getFileLocalLocation_FE_XML_SinTimbrar(long tipoDoctoId, CPARAMETROBE parametro, string tipoComprobante = "")
        {
            if (tipoComprobante != null && tipoComprobante.Equals("T"))
                return FileLocalLocation_CT_XML_SinTimbrar.Replace("\\sampdata", parametro.IFACT_ELECT_FOLDER.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location))); ;
            if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_RECIBOELECTRONICO)
                return FileLocalLocation_AE_XML_SinTimbrar.Replace("\\sampdata", parametro.IFACT_ELECT_FOLDER.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)));
            if (tipoDoctoId == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO)
                return FileLocalLocation_DE_XML_SinTimbrar.Replace("\\sampdata", parametro.IFACT_ELECT_FOLDER.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location))); ;
            return FileLocalLocation_FE_XML_SinTimbrar.Replace("\\sampdata", parametro.IFACT_ELECT_FOLDER.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location))); ;
        }

        public static string getFileLocalLocation_FE_XML_Timbrados(long tipoDoctoId, CPARAMETROBE parametro, string tipoComprobante = "")
        {
            if(tipoComprobante != null && tipoComprobante.Equals("T"))
                return FileLocalLocation_CT_XML_Timbrados.Replace("\\sampdata", parametro.IFACT_ELECT_FOLDER.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)));
            if (tipoDoctoId == DBValues._DOCTO_TIPO_RECIBOELECTRONICO)
                return FileLocalLocation_AE_XML_Timbrados.Replace("\\sampdata", parametro.IFACT_ELECT_FOLDER.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)));
            if (tipoDoctoId == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO)
                return FileLocalLocation_DE_XML_Timbrados.Replace("\\sampdata", parametro.IFACT_ELECT_FOLDER.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location))); ;
            return FileLocalLocation_FE_XML_Timbrados.Replace("\\sampdata", parametro.IFACT_ELECT_FOLDER.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location))); ;
        }


        public static string getFileLocalLocation_FE_PDF(long tipoDoctoId, CPARAMETROBE parametro, string tipoComprobante = "")
        {
            if (tipoComprobante != null && tipoComprobante.Equals("T"))
                return FileLocalLocation_CT_PDF.Replace("\\sampdata", parametro.IFACT_ELECT_FOLDER.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location))); ;
            if (tipoDoctoId == DBValues._DOCTO_TIPO_RECIBOELECTRONICO)
                return FileLocalLocation_AE_PDF.Replace("\\sampdata", parametro.IFACT_ELECT_FOLDER.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)));
            if (tipoDoctoId == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO)
                return FileLocalLocation_DE_PDF.Replace("\\sampdata", parametro.IFACT_ELECT_FOLDER.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location))); ;
            return FileLocalLocation_FE_PDF.Replace("\\sampdata", parametro.IFACT_ELECT_FOLDER.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location))); ;
        }


        public string getFileLocalLocation_FE_IMG(CPARAMETROBE parametro, string tipoComprobante = "")
        {
            if (tipoComprobante != null && tipoComprobante.Equals("T"))
                return FileLocalLocation_CT_IMG.Replace("\\sampdata", parametro.IFACT_ELECT_FOLDER.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)));
            if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_RECIBOELECTRONICO)
                return FileLocalLocation_AE_IMG.Replace("\\sampdata", parametro.IFACT_ELECT_FOLDER.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)));
            if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO)
                return FileLocalLocation_DE_IMG.Replace("\\sampdata", parametro.IFACT_ELECT_FOLDER.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location))); ;
            return FileLocalLocation_FE_IMG.Replace("\\sampdata", parametro.IFACT_ELECT_FOLDER.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location))); ;
        }


        public static string getFileLocalLocation_FE_XML_Cancelaciones(long tipoDoctoId, CPARAMETROBE parametro, string tipoComprobante = "")
        {
            if (tipoComprobante != null && tipoComprobante.Equals("T"))
                return FileLocalLocation_CT_XML_Cancelaciones.Replace("\\sampdata", parametro.IFACT_ELECT_FOLDER.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)));
            if (tipoDoctoId == DBValues._DOCTO_TIPO_RECIBOELECTRONICO)
                return FileLocalLocation_AE_XML_Cancelaciones.Replace("\\sampdata", parametro.IFACT_ELECT_FOLDER.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)));
            if (tipoDoctoId == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO)
                return FileLocalLocation_DE_XML_Cancelaciones.Replace("\\sampdata", parametro.IFACT_ELECT_FOLDER.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)));
            return FileLocalLocation_FE_XML_Cancelaciones.Replace("\\sampdata", parametro.IFACT_ELECT_FOLDER.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)));
        }

        public static string getFileLocalLocation_FE_PDF_Cancelaciones(long tipoDoctoId, CPARAMETROBE parametro, string tipoComprobante = "")
        {
            if (tipoComprobante != null && tipoComprobante.Equals("T"))
                return FileLocalLocation_CT_PDF_Cancelaciones.Replace("\\sampdata", parametro.IFACT_ELECT_FOLDER.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)));
            if (tipoDoctoId == DBValues._DOCTO_TIPO_RECIBOELECTRONICO)
                return FileLocalLocation_AE_PDF_Cancelaciones.Replace("\\sampdata", parametro.IFACT_ELECT_FOLDER.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)));

            return FileLocalLocation_FE_PDF_Cancelaciones.Replace("\\sampdata", parametro.IFACT_ELECT_FOLDER.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)));
        }

        public static void makeSureFolderExists(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }


        private void DefinirDatosEntrega()
        {

            m_usaDatosDeEntregaCuandoExista = true;

            if (this.m_PREGUNTARDATOSENTREGA != "S" && !this.m_silentMode)
            {
                CambiarUsoDatosEntrega(m_Docto.IID, "S");
                return;
            }


            if (!(bool)m_Docto.isnull["IDOM_ENTREGAID"] && (m_Docto.IDOM_ENTREGAID > 0))
            {
                CambiarUsoDatosEntrega(m_Docto.IID, "S");
                return;
            }

            CDOMICILIOD domicilioD = new CDOMICILIOD();
            bool existeDomicilioEntrega =  domicilioD.ExisteDOMICILIOParaPersona(m_Docto.IPERSONAID,  m_fTrans) > 0;

            

            if (!existeDomicilioEntrega)
            {
                CambiarUsoDatosEntrega(m_Docto.IID, "S");
                return;
            }

            if (!(bool)m_Docto.isnull["IUSARDATOSENTREGA"] && (m_Docto.IUSARDATOSENTREGA.Equals("S") || m_Docto.IUSARDATOSENTREGA.Equals("N")))
            {
                m_usaDatosDeEntregaCuandoExista = m_Docto.IUSARDATOSENTREGA.Equals("S");
                CambiarUsoDatosEntrega(m_Docto.IID, m_Docto.IUSARDATOSENTREGA);
                return;
            }

            if (!this.m_silentMode)
            {

                long? domicilioEntregaSelecconadoId = SeleccionarDomicilioEntrega(this.m_silentMode);
                if (domicilioEntregaSelecconadoId != null)
                {
                    CambiarUsoDatosEntrega(m_Docto.IID, "S");
                    return;
                }
            }

            m_usaDatosDeEntregaCuandoExista = false;
            CambiarUsoDatosEntrega(m_Docto.IID, "N");

        }


        private long?  SeleccionarDomicilioEntrega(bool silentMode)
        {
            long? domEntregaId = null;

            WFSeleccionarDomicilioEntregaFact rc_ = new WFSeleccionarDomicilioEntregaFact(this.m_Docto.IPERSONAID,
                "Hay datos de entrega definidos para este cliente. Si lo desea selecciona el domicilio de entrega de la lista. De lo contrario eliga usar los datos del cliente.", 
                this.m_Docto.IDOM_ENTREGAID);
            rc_.ShowDialog();

            if (rc_.DomicilioSeleccionadoId != this.m_Docto.IDOM_ENTREGAID)
            {

                CDOCTOD doctoD = new CDOCTOD();
                CDOCTOBE doctoBE = new CDOCTOBE();
                doctoBE.IID = m_Docto.IID;

                if (rc_.DomicilioSeleccionadoId != null)
                    doctoBE.IDOM_ENTREGAID = rc_.DomicilioSeleccionadoId.Value;

                if (doctoD.CambiarDomicilioEntrega(doctoBE, null))
                {
                    if(!silentMode)
                        MessageBox.Show("Se actualizo el domicilio de entrega");

                    this.m_Docto.IDOM_ENTREGAID = doctoBE.IDOM_ENTREGAID;
                    domEntregaId = doctoBE.IDOM_ENTREGAID; 
                }
                else if (!silentMode)
                {
                    MessageBox.Show("Ocurrio un error " + doctoD.IComentario);
                }
            }


            rc_.Dispose();
            GC.SuppressFinalize(rc_);

            return domEntregaId;
        }


        private void CambiarUsoDatosEntrega(long doctoId, string value)
        {

            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoBE = new CDOCTOBE();
            doctoBE.IID = doctoId;
            doctoBE.IUSARDATOSENTREGA = value;
            if (!doctoD.CambiarUsarDatosEntregaDOCTOD(doctoBE, m_fTrans))
            {
                if (!m_silentMode)
                {
                    MessageBox.Show(doctoD.IComentario);
                }
                else
                {
                    m_iComentario = doctoD.IComentario;
                }
            }


        }



        private ArrayList listFromFormaPagoSatStr(string formaPagoSatStr)
        {
            if (formaPagoSatStr == null)
            {
                return new ArrayList();
            }

            char[] separator = { ',' };
            string[] split = formaPagoSatStr.Split(separator);
            ArrayList arrayList = new ArrayList();
            arrayList.AddRange(split);
            return arrayList;
        }


        private string strFromFormaPagoSatList(ArrayList formaPagoSatList)
        {
            string retorno = "";
            bool bEsLaPrimera = true;
            foreach (string str in formaPagoSatList)
            {
                if (bEsLaPrimera)
                {
                    retorno = str;
                    bEsLaPrimera = false;
                }
                else
                {
                    retorno = retorno + "," + str;
                }
            }

            return retorno;
        }

        private string formaPagoTratandoEvitarPagoOtros(CCLIENTEBE clienteBE, string nombreFormaPago, CDOCTOPAGOBE doctoPagoBE, ref string referenciaCredito)
        {

            if (nombreFormaPago == "")
                nombreFormaPago = "99";

            ////////// forma de pago credito evitarla
            ArrayList listFormaPago = listFromFormaPagoSatStr(nombreFormaPago);
            string strFormaPagoCredito = "";
            if (listFormaPago.Contains("99"))
            {
                if (clienteBE.m_PersonaBE == null || (m_Docto != null && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO))
                {
                    strFormaPagoCredito = "99";
                }
                else if ((bool)clienteBE.m_PersonaBE.isnull["ICREDITOFORMAPAGOSATABONOS"] || clienteBE.m_PersonaBE.ICREDITOFORMAPAGOSATABONOS == 0 || clienteBE.m_PersonaBE.ICREDITOFORMAPAGOSATABONOS == 99)
                {
                    strFormaPagoCredito = "99";
                }
                else
                {
                    CDOCTOPAGOD pagoD = new CDOCTOPAGOD();
                    strFormaPagoCredito = pagoD.obtenNombreFormaPagoSatXId(clienteBE.m_PersonaBE.ICREDITOFORMAPAGOSATABONOS, m_fTrans);
                    if (strFormaPagoCredito == "")
                        strFormaPagoCredito = "99";// "N / A"/*"No Identificado"*/;
                    else
                    {
                        referenciaCredito = clienteBE.m_PersonaBE.ICREDITOREFERENCIAABONOS;
                    }
                }
                if (referenciaCredito == null)
                    referenciaCredito = "";


                listFormaPago[listFormaPago.IndexOf("99")] = strFormaPagoCredito;


            }
            else if (doctoPagoBE != null && doctoPagoBE.IFORMAPAGOID == 4)
            {
                referenciaCredito = clienteBE.m_PersonaBE.ICREDITOREFERENCIAABONOS;
                if (referenciaCredito == null)
                    referenciaCredito = "";
            }
            return strFromFormaPagoSatList(listFormaPago);

            ////

        }



        private string formaPagoConDescripcion(string nombreFormaPago, FbTransaction fTrans)
        {
            ////////// forma de pago credito evitarla
            ArrayList listFormaPago = listFromFormaPagoSatStr(nombreFormaPago);
            ArrayList listFormaPagoConDesc = new ArrayList();
            CFORMAPAGOSATD formaPagoSatD = new CFORMAPAGOSATD();
            foreach (string strFormaPagoSat in listFormaPago)
            {
                CFORMAPAGOSATBE formaPagoSatBE = new CFORMAPAGOSATBE();
                formaPagoSatBE.ICLAVE = strFormaPagoSat;
                formaPagoSatBE = formaPagoSatD.seleccionarFORMAPAGOSATXClave(formaPagoSatBE, fTrans);
                if (formaPagoSatBE != null)
                {
                    listFormaPagoConDesc.Add(strFormaPagoSat + " " + formaPagoSatBE.INOMBRE);
                }
            }


            return strFromFormaPagoSatList(listFormaPagoConDesc);

            ////

        }

        private static string ConvertImageToBase64(Image image, ImageFormat format)
        {
            if (image == null)
                return null;

            byte[] imageArray;

            using (System.IO.MemoryStream imageStream = new System.IO.MemoryStream())
            {
                image.Save(imageStream, format);
                imageArray = new byte[imageStream.Length];
                imageStream.Seek(0, System.IO.SeekOrigin.Begin);
                imageStream.Read(imageArray, 0, (int)imageStream.Length);
            }

            return Convert.ToBase64String(imageArray);
        }

        private void LlenarDetallesAduaneros()
        {


            if (m_fTrans != null)
            {
                this.iNFOIMPORTACIONTableAdapter.Transaction = m_fTrans;
                this.iNFOIMPORTACIONTableAdapter.Connection = m_fTrans.Connection;
            }
            try
            {
                this.iNFOIMPORTACIONTableAdapter.Fill(this.dSReportIpos2.INFOIMPORTACION, this.m_Docto.IID);

            }
            catch (Exception ex)
            {
                this.dSReportIpos2.INFOIMPORTACION.Clear();



            }

        }

        public bool GenerarDocumentoVirtualXmlCfdi33_OLD(string documentoTimbrado)
        {
            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";

            Hashtable htIva = new Hashtable();
            Hashtable htIeps = new Hashtable();

            bool esVersion33 = (m_empresa.IVERSIONCFDI != null && m_empresa.IVERSIONCFDI.Equals("3.3"));
            bool esVersion40 = (m_empresa.IVERSIONCFDI != null && m_empresa.IVERSIONCFDI.Equals("4.0"));
            bool esReciboElectronico = this.m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_RECIBOELECTRONICO;


            CCLIENTEBE clienteBE = new CCLIENTEBE();
            CPERSONAD personaD = new CPERSONAD();
            clienteBE.m_PersonaBE.IID = m_Docto.IPERSONAID;
            clienteBE.m_PersonaBE = personaD.seleccionarPERSONA(clienteBE.m_PersonaBE, m_fTrans);



            //tipo de cambio
            CMONEDABE monedaBE = new CMONEDABE();
            CMONEDAD monedaD = new CMONEDAD();
            monedaBE.IID = ((bool)m_Docto.isnull["IMONEDAID"] || m_Docto.IMONEDAID == 0) ? DBValues._MONEDA_PESOS : m_Docto.IMONEDAID;
            monedaBE = monedaD.seleccionarMONEDA(monedaBE, m_fTrans);
            if (monedaBE == null)
            {
                monedaBE = new CMONEDABE();
                monedaBE.ICLAVE = "MXN";
            }

            Decimal tipoDeCambio = (((bool)m_Docto.isnull["ITIPOCAMBIO"] || m_Docto.ITIPOCAMBIO == 0) ? 1 : m_Docto.ITIPOCAMBIO);

            //forma de pago credito evitarla
            String referenciaCredito = "";
            string strCuentaPago = "N / A";

            if (!(esVersion33 || esVersion40) || !esReciboElectronico)
            {
                m_nombreFormaPago = formaPagoTratandoEvitarPagoOtros(clienteBE, m_nombreFormaPago, m_doctoPago, ref referenciaCredito);

                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_RECIBOELECTRONICO && m_doctoPago.ICUENTAPAGOCREDITO != null && m_doctoPago.ICUENTAPAGOCREDITO.Trim().Length > 0)
                {
                    strCuentaPago = m_doctoPago.ICUENTAPAGOCREDITO;
                }
                else if (this.m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_CHEQUE || this.m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_TARJETA || this.m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_TRANSFERENCIA)
                {
                    strCuentaPago = this.m_doctoPago.IREFERENCIABANCARIA;
                }
                else if (this.m_doctoPago.IFORMAPAGOID == 4 && !referenciaCredito.Equals(""))
                {
                    strCuentaPago = referenciaCredito;
                }
            }

            //Proceso de generacion del documento
            try
            {
                //VirtualXML CiberSatInfo
                CiberSATInfo ciberSatIInfo = new CiberSATInfo(m_empresa.ITIMBRADOUSER, m_empresa.ITIMBRADOKEY);

                decimal Total = m_Docto.ITOTAL - m_Docto.IIVARETENIDO - m_Docto.IISRRETENIDO;




                string tipoComprobante = "";
                switch (m_Docto.ITIPODOCTOID)
                {
                    case DBValues._DOCTO_TIPO_VENTA:
                    case DBValues._DOCTO_TIPO_VENTAAPARTADO:
                        tipoComprobante = "I";
                        break;
                    case DBValues._DOCTO_TIPO_RECIBOELECTRONICO:
                        tipoComprobante = "P";
                        break;
                    case DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO:
                    case DBValues._DOCTO_TIPO_DEVOLUCION:
                    case DBValues._DOCTO_TIPO_CANCELACIONVENTAAPARTADO:
                        tipoComprobante = "E";
                        break;
                    default:
                        tipoComprobante = "I";
                        break;
                }


                string subTotalComprobante = "0", totalComprobante = "0", tipoCambioComprobante = "1", descuentoComprobante = "0.00", monedaComprobante = "MXN";
                string metodoPagoComprobante = m_empresa.ISAT_METODOPAGOCLAVE, condicionesPagoComprobante = "NA";

                switch (m_Docto.ITIPODOCTOID)
                {

                    case DBValues._DOCTO_TIPO_RECIBOELECTRONICO:
                        subTotalComprobante = "0";
                        totalComprobante = "0";
                        m_nombreFormaPago = "";
                        tipoCambioComprobante = "";
                        descuentoComprobante = "";
                        monedaComprobante = "XXX";
                        metodoPagoComprobante = "";
                        condicionesPagoComprobante = "";
                        break;
                    default:
                        subTotalComprobante = (clienteBE.m_PersonaBE.IDESGLOSEIEPS.Equals("S") && m_empresa.IDESGLOSEIEPS.Equals("S")) ? (m_Docto.ISUBTOTAL / tipoDeCambio).ToString("N2", nfi) : ((m_Docto.ISUBTOTAL + m_Docto.IIEPS) / tipoDeCambio).ToString("N2", nfi);
                        totalComprobante = (Total / tipoDeCambio).ToString("N2", nfi);
                        tipoCambioComprobante = tipoDeCambio == 1.00m ? "1" : tipoDeCambio.ToString("N2", nfi);
                        monedaComprobante = monedaBE.ICLAVE;

                        break;

                }

                //ComprobanteInfo VirtualXml
                ComprobanteInfo comprobanteInfo = new ComprobanteInfo(m_currentSerieSat,
                                                                      m_currentFolioSat.ToString(),
                                                                      m_Docto.ITIMBRADOFECHAFACTURA.AddMinutes(-5).ToString("yyyy-MM-dd'T'HH:mm:ss"),
                                                                      tipoComprobante,
                                                                      m_nombreFormaPago,
                                                                      subTotalComprobante,
                                                                      descuentoComprobante,
                                                                      totalComprobante,
                                                                       monedaComprobante,
                                                                     tipoCambioComprobante,
                                                                      condicionesPagoComprobante,
                                                                      metodoPagoComprobante,
                                                                      "X",
                                                                      m_empresa.IFISCALCODIGOPOSTAL);

                ComprobanteInfoEx comprobanteInfoEx = null;
                //ComprobanteInfoEx VirtualXml
                //if (this.m_DoctoRef != null && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_RECIBOELECTRONICO)
                //{
                decimal totalRef = this.m_DoctoRef == null ? 0 : m_DoctoRef.ITOTAL - m_DoctoRef.IIVARETENIDO - m_DoctoRef.IISRRETENIDO;
                comprobanteInfoEx = new ComprobanteInfoEx(m_empresa.IFISCALCODIGOPOSTAL,//m_empresa.ILOCALIDAD + " , " + m_empresa.IESTADO + " , MEXICO",
                                                                            strCuentaPago,
                                                                            this.m_DoctoRef == null ? null : m_DoctoRef.ISERIESAT,
                                                                            this.m_DoctoRef == null ? null : m_DoctoRef.ITIMBRADOUUID.ToString(),
                                                                            this.m_DoctoRef == null ? null : (totalRef / tipoDeCambio).ToString("N2", nfi),
                                                                            this.m_DoctoRef == null ? null : m_DoctoRef.ITIMBRADOFECHAFACTURA.AddMinutes(-5).ToString("yyyy-MM-dd'T'HH:mm:ss"));
                //}
                //EmisorInfo VirtualXml
                Domicilio emisorDomicilio = new Domicilio();
                emisorDomicilio.Calle = m_empresa.IFISCALCALLE;
                emisorDomicilio.NoExterior = m_empresa.IFISCALNUMEROEXTERIOR;
                emisorDomicilio.NoInterior = (bool)m_empresa.isnull["IFISCALNUMEROINTERIOR"] || m_empresa.IFISCALNUMEROINTERIOR.Trim().Equals("") ? "_" : m_empresa.IFISCALNUMEROINTERIOR;
                emisorDomicilio.Colonia = m_empresa.IFISCALCOLONIA;
                emisorDomicilio.Localidad = ".";
                emisorDomicilio.Referencia = ".";
                emisorDomicilio.Municipio = m_empresa.IFISCALMUNICIPIO;
                emisorDomicilio.Estado = m_empresa.IFISCALESTADO;
                emisorDomicilio.Pais = DBValues._CLAVEPAIS_DEFAULT_SAT;
                emisorDomicilio.CodigoPostal = m_empresa.IFISCALCODIGOPOSTAL;
                EmisorInfo emisorInfo = new EmisorInfo(m_empresa.IRFC, "razon social", m_empresa.ISAT_REGIMENFISCALCLAVE, emisorDomicilio);

                //EmisorExpedidoEn VirtualXml
                EmisorExpedidoEn emisorExpedidoEn = new EmisorExpedidoEn();

                if (m_empresa.IUSARFISCALESENEXPEDICION == "S")
                {
                    emisorExpedidoEn.Calle = m_empresa.IFISCALCALLE;
                    emisorExpedidoEn.NoExterior = m_empresa.IFISCALNUMEROEXTERIOR;
                    emisorExpedidoEn.NoInterior = (bool)m_empresa.isnull["IFISCALNUMEROINTERIOR"] || m_empresa.IFISCALNUMEROINTERIOR.Trim().Equals("") ? "_" : m_empresa.IFISCALNUMEROINTERIOR;
                    emisorExpedidoEn.Colonia = m_empresa.IFISCALCOLONIA;
                    emisorExpedidoEn.Localidad = ".";
                    emisorExpedidoEn.Referencia = ".";
                    emisorExpedidoEn.Municipio = m_empresa.IFISCALMUNICIPIO;
                    emisorExpedidoEn.Estado = m_empresa.IFISCALESTADO;
                    emisorExpedidoEn.Pais = DBValues._CLAVEPAIS_DEFAULT_SAT;
                    emisorExpedidoEn.CodigoPostal = m_empresa.IFISCALCODIGOPOSTAL;
                }
                else
                {
                    emisorExpedidoEn.Calle = m_empresa.ICALLE;
                    emisorExpedidoEn.NoExterior = m_empresa.INUMEROEXTERIOR;
                    emisorExpedidoEn.NoInterior = (bool)m_empresa.isnull["INUMEROINTERIOR"] || m_empresa.INUMEROINTERIOR.Trim().Equals("") ? "_" : m_empresa.INUMEROINTERIOR;
                    emisorExpedidoEn.Colonia = m_empresa.ICOLONIA;
                    emisorExpedidoEn.Localidad = ".";
                    emisorExpedidoEn.Referencia = ".";
                    emisorExpedidoEn.Municipio = m_empresa.ILOCALIDAD;
                    emisorExpedidoEn.Estado = m_empresa.IESTADO;
                    emisorExpedidoEn.Pais = DBValues._CLAVEPAIS_DEFAULT_SAT;
                    emisorExpedidoEn.CodigoPostal = m_empresa.ICP;
                }
                //Regimen Fiscal CFDI 3.3
                CSAT_REGIMENFISCALD regimenFiscalDao = new CSAT_REGIMENFISCALD();
                string claveRegimenFiscal = this.m_empresa.ISAT_REGIMENFISCALCLAVE;
                if (String.IsNullOrEmpty(claveRegimenFiscal)) claveRegimenFiscal = String.Empty;
                emisorInfo.RegimenFiscal = claveRegimenFiscal;

                //ReceptorInfo VirtualXml
                Domicilio receptorDomicilio = new Domicilio();
                receptorDomicilio.Calle = clienteBE.m_PersonaBE.IDOMICILIO;
                receptorDomicilio.NoExterior = clienteBE.m_PersonaBE.INUMEROEXTERIOR;
                receptorDomicilio.NoInterior = (bool)clienteBE.m_PersonaBE.isnull["INUMEROINTERIOR"] || clienteBE.m_PersonaBE.INUMEROINTERIOR.Trim().Equals("") ? "_" : clienteBE.m_PersonaBE.INUMEROINTERIOR;
                receptorDomicilio.Colonia = clienteBE.m_PersonaBE.ICOLONIA;
                receptorDomicilio.Localidad = clienteBE.m_PersonaBE.ILOCALIDAD == null || clienteBE.m_PersonaBE.ILOCALIDAD.Trim().Length == 0 ? "." : clienteBE.m_PersonaBE.ILOCALIDAD;
                receptorDomicilio.Referencia = clienteBE.m_PersonaBE.IREFERENCIADOM == null || clienteBE.m_PersonaBE.IREFERENCIADOM.Trim().Length == 0 ? "." : clienteBE.m_PersonaBE.IREFERENCIADOM;
                receptorDomicilio.Municipio = clienteBE.m_PersonaBE.ICIUDAD;
                receptorDomicilio.Estado = clienteBE.m_PersonaBE.IESTADO;
                receptorDomicilio.Pais = clienteBE.m_PersonaBE.ISAT_CLAVE_PAIS == null || clienteBE.m_PersonaBE.ISAT_CLAVE_PAIS.Trim().Length == 0 ? "MEX" : clienteBE.m_PersonaBE.ISAT_CLAVE_PAIS;
                receptorDomicilio.CodigoPostal = clienteBE.m_PersonaBE.ICODIGOPOSTAL;
                ReceptorInfo receptorInfo = new ReceptorInfo();
                receptorInfo.Rfc = clienteBE.m_PersonaBE.IRFC;
                receptorInfo.RazonSocial = clienteBE.m_PersonaBE.INOMBRES + " " + clienteBE.m_PersonaBE.IAPELLIDOS;
                receptorInfo.Domicilio = receptorDomicilio;

                //ReceptorInfo VirtualXml CFDI 3.3
                receptorInfo.ResidenciaFiscal = "";
                receptorInfo.Nombre = clienteBE.m_PersonaBE.INOMBRES + " " + clienteBE.m_PersonaBE.IAPELLIDOS;
                receptorInfo.NumRegIdTrib = "";


                string usoCFDIReceptor = DBValues._SAT_USO_CFDI_ADQUISICIONMERCANCIAS;
                switch (m_Docto.ITIPODOCTOID)
                {

                    case DBValues._DOCTO_TIPO_VENTA:
                    case DBValues._DOCTO_TIPO_VENTAAPARTADO:
                        usoCFDIReceptor = DBValues._SAT_USO_CFDI_ADQUISICIONMERCANCIAS;
                        break;
                    case DBValues._DOCTO_TIPO_RECIBOELECTRONICO:
                        usoCFDIReceptor = DBValues._SAT_USO_CFDI_PORDEFINIR;
                        break;
                    case DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO:
                    case DBValues._DOCTO_TIPO_DEVOLUCION:
                    case DBValues._DOCTO_TIPO_CANCELACIONVENTAAPARTADO:
                        usoCFDIReceptor = DBValues._SAT_USO_CFDI_DEVOLUCIONESDESCUENTOS;
                        break;
                    default:
                        usoCFDIReceptor = DBValues._SAT_USO_CFDI_ADQUISICIONMERCANCIAS;
                        break;
                }

                receptorInfo.UsoCFDI = usoCFDIReceptor;

                //
                decimal iepsTrasladadoXConcepto = 0.0m;
                decimal ivaTrasladadoXConcepto = 0.0m;
                decimal importeXConcepto = 0.0m;

                //Conceptos
                List<Concepto> conceptos = new List<Concepto>();

                foreach (DataRow dr in this.dSReportIpos2.REP_FACTURAELECTRONICA_DET.Rows)
                {
                    Concepto concepto = new Concepto();
                    concepto.ImpuestosRetenidos = new List<Traslado>();
                    concepto.ImpuestosTrasladados = new List<Traslado>();

                    decimal porcentajeiva = 0;
                    decimal porcentajeieps = 0;
                    decimal iva = 0;
                    decimal ieps = 0;
                    decimal subtotal = 0;
                    decimal cantidad = 0;
                    decimal valorUnitario = 0;
                    decimal ivaRetenido = 0;
                    decimal isrRetenido = 0;
                    bool desglosarIvaEnClaveProdServ = true;
                    bool desglosarIepsEnClaveProdServ = true;




                    if (dr["CANTIDAD"] != DBNull.Value)
                    {
                        cantidad = (decimal)dr["CANTIDAD"];
                        concepto.Cantidad = cantidad.ToString("N2", nfi);
                    }
                    else
                    {
                        continue;
                    }

                    if (dr["UNIDAD"] != DBNull.Value)
                    {
                        concepto.ClaveUnidad = dr["SAT_CLAVEUNIDAD"].ToString().Trim();
                        concepto.Unidad = dr["SAT_NOMBRE_UNIDAD"].ToString().Trim();
                    }
                    else
                    {
                        concepto.ClaveUnidad = DBValues._SAT_CLAVEUNIDAD_PIEZA;
                        concepto.Unidad = DBValues._SAT_UNIDAD_PIEZA;


                    }


                    if (dr["PRODUCTOCLAVE"] != DBNull.Value)
                        concepto.NoIdentificacion = dr["PRODUCTOCLAVE"].ToString().Trim();
                    else
                        concepto.NoIdentificacion = "";


                    if (dr["SAT_CLAVEPRODSERV"] != DBNull.Value)
                        concepto.ClaveProdServ = dr["SAT_CLAVEPRODSERV"].ToString().Trim();
                    else
                        concepto.ClaveProdServ = "";


                    if (dr["PRODUCTODESCRIPCION"] != DBNull.Value)
                        concepto.Descripcion = dr["PRODUCTODESCRIPCION"].ToString().Trim();


                    if (dr["SUBTOTAL"] != DBNull.Value)
                    {
                        subtotal = (decimal)dr["SUBTOTAL"];
                    }


                    if (dr["PRECIO"] != DBNull.Value)
                    {
                        valorUnitario = (decimal)dr["PRECIO"];
                    }

                    if (dr["SAT_IVATRASLADADO_CONC"] != DBNull.Value)
                    {
                        desglosarIvaEnClaveProdServ = !((string)dr["SAT_IVATRASLADADO_CONC"]).Equals("No");
                    }

                    if (dr["SAT_IEPSTRASLADADO_CONC"] != DBNull.Value)
                    {
                        desglosarIepsEnClaveProdServ = !((string)dr["SAT_IEPSTRASLADADO_CONC"]).Equals("No");
                    }

                    if ((clienteBE.m_PersonaBE.IDESGLOSEIEPS.Equals("S") && m_empresa.IDESGLOSEIEPS.Equals("S") && desglosarIepsEnClaveProdServ))
                    {

                        concepto.ValorUnitario = valorUnitario.ToString("N2", nfi);

                        concepto.Importe = subtotal.ToString("N2", nfi);

                        importeXConcepto += subtotal;

                    }
                    else
                    {

                        if (dr["PORCENTAJEIEPS"] != DBNull.Value)
                        {
                            porcentajeieps = (decimal)dr["PORCENTAJEIEPS"];
                        }

                        if (dr["IEPS"] != DBNull.Value)
                        {
                            ieps = (decimal)dr["IEPS"];
                        }

                        concepto.ValorUnitario = (Math.Round((subtotal + ieps) / cantidad, 2)).ToString("N2", nfi);

                        concepto.Importe = (subtotal + ieps).ToString("N2", nfi);


                        importeXConcepto += (subtotal + ieps);
                    }



                    if (!(bool)m_empresa.isnull["IARRENDATARIO"] && m_empresa.IARRENDATARIO.Equals("S") && dr["CUENTAPREDIAL"] != DBNull.Value && dr["CUENTAPREDIAL"].ToString().Trim().Length > 0)
                    {
                        concepto.CuentaPredial = dr["CUENTAPREDIAL"].ToString().Trim();
                    }

                    concepto.Descuento = "0.00";


                    //informacion aduanera
                    bool hayInformacionAduanera = false;
                    if (!(bool)m_empresa.isnull["IMANEJARLOTEIMPORTACION"] && m_empresa.IMANEJARLOTEIMPORTACION.Equals("S") && dr["STRPEDIMENTO"] != DBNull.Value && dr["STRPEDIMENTO"].ToString().Trim().Length > 0)
                    {

                        hayInformacionAduanera = true;

                    }


                    if (hayInformacionAduanera)
                    {
                        List<InformacionAduanera> listaInfoAduanera = new List<InformacionAduanera>();


                        string strMovtoId = dr["MOVTOID"].ToString();

                        DataView dv = new DataView(this.dSReportIpos2.INFOIMPORTACION);
                        dv.RowFilter = "MOVTOID = " + strMovtoId;

                        if (dv.Count > 0)
                        {
                            DataTable dtFiltered = dv.ToTable();

                            foreach (DataRow drFiltered in dtFiltered.Rows)
                            {
                                InformacionAduanera infoAduanera = new InformacionAduanera();

                                DateTime? dateImpoFecha = drFiltered["IMPORTACION_FECHA"] != DBNull.Value ? (DateTime?)drFiltered["IMPORTACION_FECHA"] : null;

                                string IMPORTACION_PEDIMENTO = drFiltered["IMPORTACION_PEDIMENTO"] != DBNull.Value ? drFiltered["IMPORTACION_PEDIMENTO"].ToString().Trim() : "";
                                string IMPORTACION_FECHA = dateImpoFecha.HasValue ? dateImpoFecha.Value.ToString("yyyy-MM-dd") : "";
                                string IMPORTACION_ADUANA = drFiltered["IMPORTACION_PEDIMENTO"] != DBNull.Value ? drFiltered["IMPORTACION_ADUANA_SAT"].ToString().Trim() : "";

                                infoAduanera.Aduana = IMPORTACION_ADUANA;
                                infoAduanera.Fecha = IMPORTACION_FECHA;
                                infoAduanera.Numero = IMPORTACION_PEDIMENTO;

                                infoAduanera.Numero = infoAduanera.Numero.Substring(0, 2) + "  " + infoAduanera.Numero.Substring(2, 2) +
                                                         "  " + infoAduanera.Numero.Substring(4, 4) + "  " + infoAduanera.Numero.Substring(8, 7);

                                //MessageBox.Show(numPedimentoAux.Length.ToString());

                                listaInfoAduanera.Add(infoAduanera);




                            }
                        }

                        concepto.InfoAduanera = listaInfoAduanera;
                    }




                    //calculating iva
                    if (dr["PORCENTAJEIVA"] != DBNull.Value)
                    {
                        porcentajeiva = (decimal)dr["PORCENTAJEIVA"];
                    }

                    if (dr["IVA"] != DBNull.Value)
                    {
                        iva = (decimal)dr["IVA"];
                    }

                    if (htIva.Contains(porcentajeiva))
                        htIva[porcentajeiva] = (decimal)htIva[porcentajeiva] + iva;
                    else
                        htIva[porcentajeiva] = iva;


                    //calculating ieps
                    ieps = 0;
                    if (dr["PORCENTAJEIEPS"] != DBNull.Value)
                    {
                        porcentajeieps = (decimal)dr["PORCENTAJEIEPS"];
                    }

                    if (dr["IEPS"] != DBNull.Value)
                    {
                        ieps = (decimal)dr["IEPS"];
                    }


                    if (m_empresa.IDESGLOSEIEPS.Equals("S") && clienteBE.m_PersonaBE.IDESGLOSEIEPS.Equals("S") && desglosarIepsEnClaveProdServ)
                    {


                        Traslado impuestoIepsConcepto = new Traslado();
                        impuestoIepsConcepto.ImpuestoVal = DBValues._SAT_CLAVE_IEPS;
                        impuestoIepsConcepto.Tasa = porcentajeieps.ToString("N2", nfi);
                        impuestoIepsConcepto.TasaCuota = (porcentajeieps / 100.00m).ToString("N6", nfi);
                        impuestoIepsConcepto.Importe = ieps.ToString("N2", nfi);
                        impuestoIepsConcepto.TipoFactor = DBValues._SAT_TIPOFACTOR_TASA;
                        impuestoIepsConcepto.BaseImp = subtotal.ToString("N2", nfi);
                        concepto.ImpuestosTrasladados.Add(impuestoIepsConcepto);



                        iepsTrasladadoXConcepto += ieps;

                        if (htIeps.Contains(porcentajeieps))
                            htIeps[porcentajeieps] = (decimal)htIeps[porcentajeieps] + ieps;
                        else
                            htIeps[porcentajeieps] = ieps;
                    }


                    if (desglosarIvaEnClaveProdServ)
                    {
                        Traslado impuestoIvaConcepto = new Traslado();
                        impuestoIvaConcepto.ImpuestoVal = DBValues._SAT_CLAVE_IVA;
                        impuestoIvaConcepto.Tasa = porcentajeiva.ToString("N2", nfi);
                        impuestoIvaConcepto.TasaCuota = (porcentajeiva / 100.00m).ToString("N6", nfi);
                        impuestoIvaConcepto.Importe = iva.ToString("N2", nfi);
                        impuestoIvaConcepto.TipoFactor = DBValues._SAT_TIPOFACTOR_TASA;
                        impuestoIvaConcepto.BaseImp = (subtotal + ieps).ToString("N2", nfi);
                        concepto.ImpuestosTrasladados.Add(impuestoIvaConcepto);


                        ivaTrasladadoXConcepto += iva;
                    }



                    //calculating iva retenido
                    if (clienteBE.m_PersonaBE.IRETIENEIVA.Equals("S") && m_empresa.IARRENDATARIO.Equals("S"))
                    {
                        if (dr["IVARETENIDO"] != DBNull.Value)
                        {
                            ivaRetenido = (decimal)dr["IVARETENIDO"];
                        }
                        if (ivaRetenido > 0.00m)
                        {
                            Traslado impuestoIvaRetConcepto = new Traslado();
                            impuestoIvaRetConcepto.ImpuestoVal = DBValues._SAT_CLAVE_IVA;
                            impuestoIvaRetConcepto.Tasa = m_empresa.IRETENCIONIVA.ToString("N2", nfi);
                            impuestoIvaRetConcepto.TasaCuota = (m_empresa.IRETENCIONIVA / 100.00m).ToString("N6", nfi);
                            impuestoIvaRetConcepto.Importe = ivaRetenido.ToString("N2", nfi);
                            impuestoIvaRetConcepto.TipoFactor = DBValues._SAT_TIPOFACTOR_TASA;
                            impuestoIvaRetConcepto.BaseImp = subtotal.ToString("N2", nfi);
                            concepto.ImpuestosRetenidos.Add(impuestoIvaRetConcepto);
                        }
                    }

                    //calculating iva retenido
                    if (clienteBE.m_PersonaBE.IRETIENEISR.Equals("S") && m_empresa.IARRENDATARIO.Equals("S"))
                    {
                        if (dr["ISRRETENIDO"] != DBNull.Value)
                        {
                            isrRetenido = (decimal)dr["ISRRETENIDO"];
                        }
                        if (isrRetenido > 0.00m)
                        {
                            Traslado impuestoIsrRetConcepto = new Traslado();
                            impuestoIsrRetConcepto.ImpuestoVal = DBValues._SAT_CLAVE_ISR;
                            impuestoIsrRetConcepto.Tasa = m_empresa.IRETENCIONISR.ToString("N2", nfi);
                            impuestoIsrRetConcepto.TasaCuota = (m_empresa.IRETENCIONISR / 100.00m).ToString("N6", nfi);
                            impuestoIsrRetConcepto.Importe = isrRetenido.ToString("N2", nfi);
                            impuestoIsrRetConcepto.TipoFactor = DBValues._SAT_TIPOFACTOR_TASA;
                            impuestoIsrRetConcepto.BaseImp = subtotal.ToString("N2", nfi);
                            concepto.ImpuestosRetenidos.Add(impuestoIsrRetConcepto);
                        }
                    }

                    conceptos.Add(concepto);
                }



                List<Concepto> conceptosRecibo = new List<Concepto>();
                List<PagoSAT> pagosSat = new List<PagoSAT>();

                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_RECIBOELECTRONICO)
                {
                    ReCalculaImpuestosRecibo(ref htIva, ref htIeps, clienteBE);


                    Concepto concepto = new Concepto();
                    concepto.Cantidad = "1";
                    concepto.Unidad = "";
                    concepto.Descripcion = "Pago";
                    concepto.ValorUnitario = "0";
                    concepto.Importe = "0";
                    concepto.NoIdentificacion = "";
                    concepto.CuentaPredial = "";
                    concepto.ClaveProdServ = "84111506";
                    concepto.ClaveUnidad = "ACT";
                    concepto.Descuento = "";


                    conceptosRecibo.Add(concepto);

                    //llenar los pagos
                    CPAGOSATBE auxPagoSat = new CPAGOSATBE();
                    CPAGOSATD auxDaoPagoSat = new CPAGOSATD();
                    List<CPAGODOCTOSATBE> auxDoctoPagosSat = new List<CPAGODOCTOSATBE>();
                    CPAGODOCTOSATD auxDaoDoctoPagoSat = new CPAGODOCTOSATD();

                    PagoSAT pagoSat = new PagoSAT();
                    pagoSat.DoctosRelacionados = new List<PagoDoctoSAT>();

                    auxPagoSat = auxDaoPagoSat.seleccionarPAGOSATByDOCTO(m_Docto.IID, m_fTrans);
                    if (auxPagoSat != null)
                    {
                        pagoSat.FechaPago = auxPagoSat.IFECHAPAGO.AddMinutes(-5).ToString("yyyy-MM-dd'T'HH:mm:ss");
                        pagoSat.FormaDePagoP = auxPagoSat.IFORMADEPAGOP;
                        pagoSat.MonedaP = auxPagoSat.IMONEDAP;
                        pagoSat.TipoCambioP = auxPagoSat.IMONEDAP.Equals("MXN") ? "1" : auxPagoSat.ITIPOCAMBIOP.ToString();
                        pagoSat.Monto = auxPagoSat.IMONTO.ToString("N2");
                        pagoSat.NumOperacion = auxPagoSat.INUMOPERACION;
                        pagoSat.RfcEmisorCtaOrd = auxPagoSat.IRFCEMISORCTAORD;
                        pagoSat.NomBancoOrdExt = auxPagoSat.INOMBANCOORDEXT;
                        pagoSat.CtaOrdenante = auxPagoSat.ICTAORDENANTE;
                        pagoSat.RfcEmisorCtaBen = auxPagoSat.IRFCEMISORCTABEN;
                        pagoSat.CtaBeneficiario = auxPagoSat.ICTABENEFICIARIO;
                        pagoSat.TipoCadPago = auxPagoSat.ITIPOCADPAGO;
                        pagoSat.CertPago = auxPagoSat.ICERTPAGO;
                        pagoSat.CadPago = auxPagoSat.ICADPAGO;
                        pagoSat.SelloPago = auxPagoSat.ISELLOPAGO;

                        auxDoctoPagosSat = auxDaoDoctoPagoSat.seleccionarPAGODOCTOSATByPAGOSATID(auxPagoSat.IID, m_fTrans);

                        foreach (CPAGODOCTOSATBE doctorelacionado in auxDoctoPagosSat)
                        {
                            PagoDoctoSAT doctoRel = new PagoDoctoSAT();
                            doctoRel.IdDocumento = doctorelacionado.IIDDOCUMENTO;
                            doctoRel.Serie = doctorelacionado.ISERIE;
                            doctoRel.Folio = doctorelacionado.IFOLIO;
                            doctoRel.MonedaDR = doctorelacionado.IMONEDADR;
                            doctoRel.TipoCambioDR = doctorelacionado.IMONEDADR.Equals("MXN") ? "" : doctorelacionado.ITIPOCAMBIODR;
                            doctoRel.MetodoDePagoDR = doctorelacionado.IMETODODEPAGODR;
                            doctoRel.NumParcialidad = doctorelacionado.INUMPARCIALIDAD.ToString();
                            doctoRel.ImpSaldoAnt = doctorelacionado.IIMPSALDOANT.ToString("N2");
                            doctoRel.ImpPagado = doctorelacionado.IIMPPAGADO.ToString("N2");
                            doctoRel.ImpSaldoInsoluto = doctorelacionado.IIMPSALDOINSOLUTO.ToString("N2");
                            doctoRel.ObjetoImpDR = doctorelacionado.IOBJETOIMPDR;

                            pagoSat.DoctosRelacionados.Add(doctoRel);
                        }



                    }

                    pagosSat.Add(pagoSat);

                }

                //ImpuestosLocalesInfo VirtualXml
                ImpuestosInfo impuestosInfo = new ImpuestosInfo();
                impuestosInfo.TotalTraslados = (ivaTrasladadoXConcepto + iepsTrasladadoXConcepto).ToString("N2", nfi); //(m_empresa.IDESGLOSEIEPS.Equals("S") && clienteBE.m_PersonaBE.IDESGLOSEIEPS.Equals("S")) ? (m_Docto.IIMPUESTO / tipoDeCambio).ToString("N2", nfi) : (m_Docto.IIVA / tipoDeCambio).ToString("N2", nfi);
                impuestosInfo.TotalRetenciones = (((m_Docto.IIVARETENIDO + m_Docto.IISRRETENIDO) / tipoDeCambio).ToString("N2", nfi));


                //si estan en 0 hay que pasar vacio
                if (impuestosInfo.TotalRetenciones != null && impuestosInfo.TotalRetenciones.Equals("0.00"))
                    impuestosInfo.TotalRetenciones = "";
                if (impuestosInfo.TotalTraslados != null && impuestosInfo.TotalTraslados.Equals("0.00"))
                    impuestosInfo.TotalTraslados = "";


                //actualizar el subtotal si no es recibo electronica

                if (m_Docto.ITIPODOCTOID != DBValues._DOCTO_TIPO_RECIBOELECTRONICO)
                {
                    comprobanteInfo.Subtotal = importeXConcepto.ToString("N2", nfi);
                }



                //Trasladados VirtualXml
                List<Traslado> impuestosTrasladados = new List<Traslado>();
                foreach (DictionaryEntry entry in htIva)
                {
                    Traslado impuestoTrasladado = new Traslado();
                    decimal tasaImp = (decimal)entry.Key;
                    decimal importeImp = (decimal)entry.Value;

                    impuestoTrasladado.ImpuestoVal = DBValues._SAT_CLAVE_IVA;//"IVA";
                    impuestoTrasladado.Tasa = tasaImp.ToString("N2", nfi);
                    impuestoTrasladado.TasaCuota = (tasaImp / 100.00m).ToString("N6", nfi);
                    impuestoTrasladado.Importe = importeImp.ToString("N2", nfi);
                    impuestoTrasladado.TipoFactor = DBValues._SAT_TIPOFACTOR_TASA;

                    impuestosTrasladados.Add(impuestoTrasladado);


                    if (tasaImp == (decimal)0)
                    {
                        bShowIva0 = true;
                    }

                    if (tasaImp == (decimal)16)
                    {
                        bShowIva16 = true;
                    }

                }


                foreach (DictionaryEntry entry in htIeps)
                {
                    Traslado impuestoTrasladado = new Traslado();
                    decimal tasaImp = (decimal)entry.Key;
                    decimal importeImp = (decimal)entry.Value;

                    impuestoTrasladado.ImpuestoVal = DBValues._SAT_CLAVE_IEPS;//"IEPS";
                    impuestoTrasladado.Tasa = tasaImp.ToString("N2", nfi);
                    impuestoTrasladado.TasaCuota = (tasaImp / 100.00m).ToString("N6", nfi);
                    impuestoTrasladado.Importe = importeImp.ToString("N2", nfi);
                    impuestoTrasladado.TipoFactor = DBValues._SAT_TIPOFACTOR_TASA;

                    impuestosTrasladados.Add(impuestoTrasladado);
                }


                //ImpuestosRetenidos VirtualXml
                List<Retencion> impuestosRetenidos = new List<Retencion>();

                if (clienteBE.m_PersonaBE.IRETIENEIVA.Equals("S") && m_empresa.IARRENDATARIO.Equals("S"))
                {
                    Retencion impuestoRetenido = new Retencion();
                    impuestoRetenido.ImpuestoVal = DBValues._SAT_CLAVE_IVA;//"IVA";
                    impuestoRetenido.Importe = (m_Docto.IIVARETENIDO / tipoDeCambio).ToString("N2", nfi);
                    impuestoRetenido.Tasa = m_empresa.IRETENCIONIVA.ToString("N2", nfi);

                    impuestosRetenidos.Add(impuestoRetenido);
                }

                if (clienteBE.m_PersonaBE.IRETIENEISR.Equals("S") && m_empresa.IARRENDATARIO.Equals("S"))
                {
                    Retencion impuestoRetenido = new Retencion();
                    impuestoRetenido.ImpuestoVal = DBValues._SAT_CLAVE_ISR;//"ISR";
                    impuestoRetenido.Importe = (m_Docto.IISRRETENIDO / tipoDeCambio).ToString("N2", nfi);
                    impuestoRetenido.Tasa = m_empresa.IRETENCIONISR.ToString("N2", nfi);

                    impuestosRetenidos.Add(impuestoRetenido);
                }

                Dictionary<String, List<String>> cfdiRelacionados = null;
                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO && m_DoctoRef != null && m_DoctoRef.ITIMBRADOUUID != null && m_DoctoRef.ITIMBRADOUUID.Trim().Length > 0)
                {
                    cfdiRelacionados = new Dictionary<String, List<String>>();
                    cfdiRelacionados.Add(DBValues._SAT_TIPORELACION_NOTACREDITO, new List<string>() { m_DoctoRef.ITIMBRADOUUID });
                }

                //Inicializar VirtualXmlHelper
                VirtualXmlHelper virtualXmlHelper = new VirtualXmlHelper(m_empresa.IVERSIONCFDI);

                virtualXmlHelper.ManejaAddenda = false;
                virtualXmlHelper.ManejaImpuestosLocales = false;
                virtualXmlHelper.ManejaRetenidos = impuestosRetenidos.Count() > 0;
                virtualXmlHelper.ManejaTrasladados = impuestosTrasladados.Count() > 0;

                virtualXmlHelper.CiberSatInfo = ciberSatIInfo;
                virtualXmlHelper.ComprobanteInfo = comprobanteInfo;
                virtualXmlHelper.ComprobanteInfoEx = comprobanteInfoEx;
                virtualXmlHelper.Conceptos = m_Docto.ITIPODOCTOID != DBValues._DOCTO_TIPO_RECIBOELECTRONICO ? conceptos : conceptosRecibo;
                virtualXmlHelper.EmisorExpedidoEn = emisorExpedidoEn;
                virtualXmlHelper.EmisorInfo = emisorInfo;
                virtualXmlHelper.ImpuestosInfo = impuestosInfo;
                virtualXmlHelper.ReceptorInfo = receptorInfo;
                virtualXmlHelper.ImpuestosRetenidos = impuestosRetenidos;
                virtualXmlHelper.ImpuestosTrasladados = impuestosTrasladados;
                virtualXmlHelper.RutaCsd = m_empresa.ITIMBRADOARCHIVOCERTIFICADO;
                virtualXmlHelper.Llave = m_empresa.ITIMBRADOARCHIVOKEY;
                virtualXmlHelper.ClaveLlave = m_empresa.ITIMBRADOPASSWORD;
                virtualXmlHelper.RutaXml = documentoTimbrado;
                virtualXmlHelper.VirtualPacInfo = new VirtualPACInfo(m_empresa.IPACUSUARIO, "virtual");
                virtualXmlHelper.CfdiRelacionados = cfdiRelacionados;
                virtualXmlHelper.PagosSat = pagosSat;

                string resultado = "";

                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_RECIBOELECTRONICO)
                {

                    if (this.m_empresa.IVERSIONCFDI.Equals(VersionesFacturacion.V40))
                        resultado = virtualXmlHelper.GenerarPago40(m_silentMode);
                    else
                        resultado = virtualXmlHelper.GenerarPago33(m_silentMode);
                }
                else
                {
                    resultado = virtualXmlHelper.GenerarDocumento();
                }



                return String.IsNullOrEmpty(resultado);

            }
            catch (Exception ex)
            {
                if (!m_silentMode)
                {
                    MessageBox.Show("Ocurrio un error al generar el xml para ser timbrado" + ex.Message + ex.StackTrace);
                }
                else
                {
                    m_iComentario = "Ocurrio un error al generar el xml para ser timbrado" + ex.Message + ex.StackTrace;
                }
                return false;
            }
        }

        public bool GenerarDocumentoVirtualXml(string documentoTimbrado)
        {
            //file name
            string filename = "";

            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();
            //Now force thousand separator to be empty string
            nfi.NumberGroupSeparator = "";


            Hashtable htIva = new Hashtable();
            Hashtable htIeps = new Hashtable();
            //htIva[(decimal)0] = (decimal)0.00;

            CCLIENTEBE clienteBE = new CCLIENTEBE();
            CPERSONAD personaD = new CPERSONAD();
            clienteBE.m_PersonaBE.IID = m_Docto.IPERSONAID;
            clienteBE.m_PersonaBE = personaD.seleccionarPERSONA(clienteBE.m_PersonaBE, m_fTrans);


            //tipo de cambio
            CMONEDABE monedaBE = new CMONEDABE();
            CMONEDAD monedaD = new CMONEDAD();
            monedaBE.IID = ((bool)m_Docto.isnull["IMONEDAID"] || m_Docto.IMONEDAID == 0) ? DBValues._MONEDA_PESOS : m_Docto.IMONEDAID;
            monedaBE = monedaD.seleccionarMONEDA(monedaBE, m_fTrans);
            if (monedaBE == null)
            {
                monedaBE = new CMONEDABE();
                monedaBE.ICLAVE = "MN";
            }

            Decimal tipoDeCambio = (((bool)m_Docto.isnull["ITIPOCAMBIO"] || m_Docto.ITIPOCAMBIO == 0) ? 1 : m_Docto.ITIPOCAMBIO);


            //forma de pago credito evitarla
            String referenciaCredito = "";
            string strCuentaPago = "N / A";
            m_nombreFormaPago = formaPagoTratandoEvitarPagoOtros(clienteBE, m_nombreFormaPago, m_doctoPago, ref referenciaCredito);

            if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_RECIBOELECTRONICO && m_doctoPago.ICUENTAPAGOCREDITO != null && m_doctoPago.ICUENTAPAGOCREDITO.Trim().Length > 0)
            {
                strCuentaPago = m_doctoPago.ICUENTAPAGOCREDITO;
            }
            else if (this.m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_CHEQUE || this.m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_TARJETA || this.m_doctoPago.IFORMAPAGOID == DBValues._FORMA_PAGO_TRANSFERENCIA)
            {
                strCuentaPago = this.m_doctoPago.IREFERENCIABANCARIA;
            }
            else if (this.m_doctoPago.IFORMAPAGOID == 4 && !referenciaCredito.Equals(""))
            {
                strCuentaPago = referenciaCredito;
            }

            //Proceso de generacion del documento
            try
            {
                //VirtualXML CiberSatInfo
                CiberSATInfo ciberSatIInfo = new CiberSATInfo(m_empresa.ITIMBRADOUSER, m_empresa.ITIMBRADOKEY);

                decimal Total = m_Docto.ITOTAL - m_Docto.IIVARETENIDO - m_Docto.IISRRETENIDO;

                string tipoComprobante = "";
                switch (m_Docto.ITIPODOCTOID)
                {
                    case 21:
                    case 25:
                    case DBValues._DOCTO_TIPO_RECIBOELECTRONICO:
                        tipoComprobante = "ingreso";
                        break;
                    case 22:
                    case 23:
                    case 26:
                        tipoComprobante = "egreso";
                        break;
                    default:
                        tipoComprobante = "ingreso";
                        break;
                }

                //ComprobanteInfo VirtualXml
                ComprobanteInfo comprobanteInfo = new ComprobanteInfo(m_currentSerieSat,
                                                                      m_currentFolioSat.ToString(),
                                                                      m_Docto.ITIMBRADOFECHAFACTURA.AddMinutes(-5).ToString("yyyy-MM-dd'T'HH:mm:ss"),
                                                                      tipoComprobante,
                                                                      m_nombreFormaPago,
                                                                      (clienteBE.m_PersonaBE.IDESGLOSEIEPS.Equals("S") && m_empresa.IDESGLOSEIEPS.Equals("S")) ? (m_Docto.ISUBTOTAL / tipoDeCambio).ToString("N2", nfi) : ((m_Docto.ISUBTOTAL + m_Docto.IIEPS) / tipoDeCambio).ToString("N2", nfi),
                                                                      "0.00",
                                                                      (Total / tipoDeCambio).ToString("N2", nfi),
                                                                      monedaBE.ICLAVE,
                                                                      tipoDeCambio.ToString("N2", nfi),
                                                                      "N / A",
                                                                      clienteBE.m_PersonaBE.IPAGOPARCIALIDADES.Equals("S") ? "PAGO EN PARCIALIDADES" : "PAGO EN UNA SOLA EXHIBICION",
                                                                      "X");

                ComprobanteInfoEx comprobanteInfoEx = null;
                //ComprobanteInfoEx VirtualXml
                //if (this.m_DoctoRef != null && m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_RECIBOELECTRONICO)
                //{
                decimal totalRef = this.m_DoctoRef == null ? 0 : m_DoctoRef.ITOTAL - m_DoctoRef.IIVARETENIDO - m_DoctoRef.IISRRETENIDO;
                comprobanteInfoEx = new ComprobanteInfoEx(m_empresa.ILOCALIDAD + " , " + m_empresa.IESTADO + " , MEXICO",
                                                                            strCuentaPago,
                                                                            this.m_DoctoRef == null ? null : m_DoctoRef.ISERIESAT,
                                                                            this.m_DoctoRef == null ? null : m_DoctoRef.ITIMBRADOUUID.ToString(),
                                                                            this.m_DoctoRef == null ? null : (totalRef / tipoDeCambio).ToString("N2", nfi),
                                                                            this.m_DoctoRef == null ? null : m_DoctoRef.ITIMBRADOFECHAFACTURA.AddMinutes(-5).ToString("yyyy-MM-dd'T'HH:mm:ss"));
                //}
                //EmisorInfo VirtualXml
                Domicilio emisorDomicilio = new Domicilio();
                emisorDomicilio.Calle = m_empresa.IFISCALCALLE;
                emisorDomicilio.NoExterior = m_empresa.IFISCALNUMEROEXTERIOR;
                emisorDomicilio.NoInterior = (bool)m_empresa.isnull["IFISCALNUMEROINTERIOR"] || m_empresa.IFISCALNUMEROINTERIOR.Trim().Equals("") ? "_" : m_empresa.IFISCALNUMEROINTERIOR;
                emisorDomicilio.Colonia = m_empresa.IFISCALCOLONIA;
                emisorDomicilio.Localidad = ".";
                emisorDomicilio.Referencia = ".";
                emisorDomicilio.Municipio = m_empresa.IFISCALMUNICIPIO;
                emisorDomicilio.Estado = m_empresa.IFISCALESTADO;
                emisorDomicilio.Pais = "MEXICO";
                emisorDomicilio.CodigoPostal = m_empresa.IFISCALCODIGOPOSTAL;
                EmisorInfo emisorInfo = new EmisorInfo(m_empresa.IRFC, "razon social", "regimen fiscal", emisorDomicilio);

                //EmisorExpedidoEn VirtualXml
                EmisorExpedidoEn emisorExpedidoEn = new EmisorExpedidoEn();

                if (m_empresa.IUSARFISCALESENEXPEDICION == "S")
                {
                    emisorExpedidoEn.Calle = m_empresa.IFISCALCALLE;
                    emisorExpedidoEn.NoExterior = m_empresa.IFISCALNUMEROEXTERIOR;
                    emisorExpedidoEn.NoInterior = (bool)m_empresa.isnull["IFISCALNUMEROINTERIOR"] || m_empresa.IFISCALNUMEROINTERIOR.Trim().Equals("") ? "_" : m_empresa.IFISCALNUMEROINTERIOR;
                    emisorExpedidoEn.Colonia = m_empresa.IFISCALCOLONIA;
                    emisorExpedidoEn.Localidad = ".";
                    emisorExpedidoEn.Referencia = ".";
                    emisorExpedidoEn.Municipio = m_empresa.IFISCALMUNICIPIO;
                    emisorExpedidoEn.Estado = m_empresa.IFISCALESTADO;
                    emisorExpedidoEn.Pais = "Mexico";
                    emisorExpedidoEn.CodigoPostal = m_empresa.IFISCALCODIGOPOSTAL;
                }
                else
                {
                    emisorExpedidoEn.Calle = m_empresa.ICALLE;
                    emisorExpedidoEn.NoExterior = m_empresa.INUMEROEXTERIOR;
                    emisorExpedidoEn.NoInterior = (bool)m_empresa.isnull["INUMEROINTERIOR"] || m_empresa.INUMEROINTERIOR.Trim().Equals("") ? "_" : m_empresa.INUMEROINTERIOR;
                    emisorExpedidoEn.Colonia = m_empresa.ICOLONIA;
                    emisorExpedidoEn.Localidad = ".";
                    emisorExpedidoEn.Referencia = ".";
                    emisorExpedidoEn.Municipio = m_empresa.ILOCALIDAD;
                    emisorExpedidoEn.Estado = m_empresa.IESTADO;
                    emisorExpedidoEn.Pais = "Mexico";
                    emisorExpedidoEn.CodigoPostal = m_empresa.ICP;

                }

                emisorInfo.RegimenFiscal = m_empresa.IFISCALREGIMEN;

                //ReceptorInfo VirtualXml
                Domicilio receptorDomicilio = new Domicilio();
                receptorDomicilio.Calle = clienteBE.m_PersonaBE.IDOMICILIO;
                receptorDomicilio.NoExterior = clienteBE.m_PersonaBE.INUMEROEXTERIOR;
                receptorDomicilio.NoInterior = (bool)clienteBE.m_PersonaBE.isnull["INUMEROINTERIOR"] || clienteBE.m_PersonaBE.INUMEROINTERIOR.Trim().Equals("") ? "_" : clienteBE.m_PersonaBE.INUMEROINTERIOR;
                receptorDomicilio.Colonia = clienteBE.m_PersonaBE.ICOLONIA;
                receptorDomicilio.Localidad = clienteBE.m_PersonaBE.ILOCALIDAD == null || clienteBE.m_PersonaBE.ILOCALIDAD.Trim().Length == 0 ? "." : clienteBE.m_PersonaBE.ILOCALIDAD;
                receptorDomicilio.Referencia = clienteBE.m_PersonaBE.IREFERENCIADOM == null || clienteBE.m_PersonaBE.IREFERENCIADOM.Trim().Length == 0 ? "." : clienteBE.m_PersonaBE.IREFERENCIADOM;
                receptorDomicilio.Municipio = clienteBE.m_PersonaBE.ICIUDAD;
                receptorDomicilio.Estado = clienteBE.m_PersonaBE.IESTADO;
                receptorDomicilio.Pais = clienteBE.m_PersonaBE.IPAIS;
                receptorDomicilio.CodigoPostal = clienteBE.m_PersonaBE.ICODIGOPOSTAL;
                ReceptorInfo receptorInfo = new ReceptorInfo();
                receptorInfo.Rfc = clienteBE.m_PersonaBE.IRFC;
                receptorInfo.RazonSocial = clienteBE.m_PersonaBE.INOMBRES + " " + clienteBE.m_PersonaBE.IAPELLIDOS;
                receptorInfo.Domicilio = receptorDomicilio;

                //Conceptos
                List<Concepto> conceptos = new List<Concepto>();

                foreach (DataRow dr in this.dSReportIpos2.REP_FACTURAELECTRONICA_DET.Rows)
                {
                    Concepto concepto = new Concepto();

                    decimal porcentajeiva = 0;
                    decimal porcentajeieps = 0;
                    decimal iva = 0;
                    decimal ieps = 0;
                    decimal subtotal = 0;
                    decimal cantidad = 0;
                    decimal valorUnitario = 0;

                    if (dr["CANTIDAD"] != DBNull.Value)
                    {
                        cantidad = (decimal)dr["CANTIDAD"];
                        concepto.Cantidad = cantidad.ToString("N2", nfi);
                    }
                    else
                    {
                        continue;
                    }


                    if (dr["UNIDAD"] != DBNull.Value)
                        concepto.Unidad = dr["UNIDAD"].ToString().Trim();
                    else
                        concepto.Unidad = "PZA";


                    if (dr["PRODUCTOCLAVE"] != DBNull.Value)
                        concepto.NoIdentificacion = dr["PRODUCTOCLAVE"].ToString().Trim();
                    else
                        concepto.NoIdentificacion = "";


                    if (dr["PRODUCTODESCRIPCION"] != DBNull.Value)
                        concepto.Descripcion = dr["PRODUCTODESCRIPCION"].ToString().Trim();


                    if (dr["SUBTOTAL"] != DBNull.Value)
                    {
                        subtotal = (decimal)dr["SUBTOTAL"];
                    }


                    if (dr["PRECIO"] != DBNull.Value)
                    {
                        valorUnitario = (decimal)dr["PRECIO"];
                    }

                    if ((clienteBE.m_PersonaBE.IDESGLOSEIEPS.Equals("S") && m_empresa.IDESGLOSEIEPS.Equals("S")))
                    {

                        concepto.ValorUnitario = valorUnitario.ToString("N2", nfi);

                        concepto.Importe = subtotal.ToString("N2", nfi);

                    }
                    else
                    {

                        if (dr["PORCENTAJEIEPS"] != DBNull.Value)
                        {
                            porcentajeieps = (decimal)dr["PORCENTAJEIEPS"];
                        }

                        if (dr["IEPS"] != DBNull.Value)
                        {
                            ieps = (decimal)dr["IEPS"];
                        }

                        concepto.ValorUnitario = (Math.Round((subtotal + ieps) / cantidad, 2)).ToString("N2", nfi);

                        concepto.Importe = (subtotal + ieps).ToString("N2", nfi);
                    }



                    if (!(bool)m_empresa.isnull["IARRENDATARIO"] && m_empresa.IARRENDATARIO.Equals("S") && dr["CUENTAPREDIAL"] != DBNull.Value && dr["CUENTAPREDIAL"].ToString().Trim().Length > 0)
                    {
                        concepto.CuentaPredial = dr["CUENTAPREDIAL"].ToString().Trim();
                    }


                    //informacion aduanera
                    bool hayInformacionAduanera = false;
                    if (!(bool)m_empresa.isnull["IMANEJARLOTEIMPORTACION"] && m_empresa.IMANEJARLOTEIMPORTACION.Equals("S") && dr["STRPEDIMENTO"] != DBNull.Value && dr["STRPEDIMENTO"].ToString().Trim().Length > 0)
                    {

                        hayInformacionAduanera = true;

                    }
                    if (hayInformacionAduanera)
                    {
                        List<InformacionAduanera> listaInfoAduanera = new List<InformacionAduanera>();

                        string strMovtoId = dr["MOVTOID"].ToString();

                        DataView dv = new DataView(this.dSReportIpos2.INFOIMPORTACION);
                        dv.RowFilter = "MOVTOID = " + strMovtoId;

                        if (dv.Count > 0)
                        {
                            DataTable dtFiltered = dv.ToTable();

                            foreach (DataRow drFiltered in dtFiltered.Rows)
                            {
                                InformacionAduanera infoAduanera = new InformacionAduanera();

                                DateTime? dateImpoFecha = drFiltered["IMPORTACION_FECHA"] != DBNull.Value ? (DateTime?)drFiltered["IMPORTACION_FECHA"] : null;

                                string IMPORTACION_PEDIMENTO = drFiltered["IMPORTACION_PEDIMENTO"] != DBNull.Value ? drFiltered["IMPORTACION_PEDIMENTO"].ToString().Trim() : "";
                                string IMPORTACION_FECHA = dateImpoFecha.HasValue ? dateImpoFecha.Value.ToString("yyyy-MM-dd") : "";
                                string IMPORTACION_ADUANA = drFiltered["IMPORTACION_PEDIMENTO"] != DBNull.Value ? drFiltered["IMPORTACION_ADUANA"].ToString().Trim().PadLeft(2, '0') : "";

                                infoAduanera.Aduana = IMPORTACION_ADUANA;
                                infoAduanera.Fecha = IMPORTACION_FECHA;
                                infoAduanera.Numero = IMPORTACION_PEDIMENTO;

                                listaInfoAduanera.Add(infoAduanera);
                            }
                        }

                        concepto.InfoAduanera = listaInfoAduanera;
                    }


                    //calculating iva
                    if (dr["PORCENTAJEIVA"] != DBNull.Value)
                    {
                        porcentajeiva = (decimal)dr["PORCENTAJEIVA"];
                    }

                    if (dr["IVA"] != DBNull.Value)
                    {
                        iva = (decimal)dr["IVA"];
                    }

                    if (htIva.Contains(porcentajeiva))
                        htIva[porcentajeiva] = (decimal)htIva[porcentajeiva] + iva;
                    else
                        htIva[porcentajeiva] = iva;


                    if (m_empresa.IDESGLOSEIEPS.Equals("S") && clienteBE.m_PersonaBE.IDESGLOSEIEPS.Equals("S"))
                    {
                        //calculating ieps
                        if (dr["PORCENTAJEIEPS"] != DBNull.Value)
                        {
                            porcentajeieps = (decimal)dr["PORCENTAJEIEPS"];
                        }

                        if (dr["IEPS"] != DBNull.Value)
                        {
                            ieps = (decimal)dr["IEPS"];
                        }

                        if (htIeps.Contains(porcentajeieps))
                            htIeps[porcentajeieps] = (decimal)htIeps[porcentajeieps] + ieps;
                        else
                            htIeps[porcentajeieps] = ieps;
                    }

                    conceptos.Add(concepto);
                }


                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_RECIBOELECTRONICO)
                {
                    ReCalculaImpuestosRecibo(ref htIva, ref htIeps, clienteBE);
                }

                //ImpuestosLocalesInfo VirtualXml
                ImpuestosInfo impuestosInfo = new ImpuestosInfo();
                impuestosInfo.TotalTraslados = (m_empresa.IDESGLOSEIEPS.Equals("S") && clienteBE.m_PersonaBE.IDESGLOSEIEPS.Equals("S")) ? (m_Docto.IIMPUESTO / tipoDeCambio).ToString("N2", nfi) : (m_Docto.IIVA / tipoDeCambio).ToString("N2", nfi);
                impuestosInfo.TotalRetenciones = (((m_Docto.IIVARETENIDO + m_Docto.IISRRETENIDO) / tipoDeCambio).ToString("N2", nfi));


                //si estan en 0 hay que pasar vacio
                if (impuestosInfo.TotalRetenciones != null && impuestosInfo.TotalRetenciones.Equals("0.00"))
                    impuestosInfo.TotalRetenciones = "";
                if (impuestosInfo.TotalTraslados != null && impuestosInfo.TotalTraslados.Equals("0.00"))
                    impuestosInfo.TotalTraslados = "";

                //Trasladados VirtualXml
                List<Traslado> impuestosTrasladados = new List<Traslado>();
                foreach (DictionaryEntry entry in htIva)
                {
                    Traslado impuestoTrasladado = new Traslado();
                    decimal tasaImp = (decimal)entry.Key;
                    decimal importeImp = (decimal)entry.Value;

                    impuestoTrasladado.ImpuestoVal = "IVA";
                    impuestoTrasladado.Tasa = tasaImp.ToString("N2", nfi);
                    impuestoTrasladado.Importe = importeImp.ToString("N2", nfi);

                    impuestosTrasladados.Add(impuestoTrasladado);


                    if (tasaImp == (decimal)0)
                    {
                        bShowIva0 = true;
                    }

                    if (tasaImp == (decimal)16)
                    {
                        bShowIva16 = true;
                    }

                }


                foreach (DictionaryEntry entry in htIeps)
                {
                    Traslado impuestoTrasladado = new Traslado();
                    decimal tasaImp = (decimal)entry.Key;
                    decimal importeImp = (decimal)entry.Value;

                    impuestoTrasladado.ImpuestoVal = "IEPS";
                    impuestoTrasladado.Tasa = tasaImp.ToString("N2", nfi);
                    impuestoTrasladado.Importe = importeImp.ToString("N2", nfi);

                    impuestosTrasladados.Add(impuestoTrasladado);
                }


                //ImpuestosRetenidos VirtualXml
                List<Retencion> impuestosRetenidos = new List<Retencion>();

                if (clienteBE.m_PersonaBE.IRETIENEIVA.Equals("S") && m_empresa.IARRENDATARIO.Equals("S"))
                {
                    Retencion impuestoRetenido = new Retencion();
                    impuestoRetenido.ImpuestoVal = "IVA";
                    impuestoRetenido.Importe = (m_Docto.IIVARETENIDO / tipoDeCambio).ToString("N2", nfi);
                    impuestoRetenido.Tasa = m_empresa.IRETENCIONIVA.ToString("N2", nfi);

                    impuestosRetenidos.Add(impuestoRetenido);
                }

                if (clienteBE.m_PersonaBE.IRETIENEISR.Equals("S") && m_empresa.IARRENDATARIO.Equals("S"))
                {
                    Retencion impuestoRetenido = new Retencion();
                    impuestoRetenido.ImpuestoVal = "ISR";
                    impuestoRetenido.Importe = (m_Docto.IISRRETENIDO / tipoDeCambio).ToString("N2", nfi);
                    impuestoRetenido.Tasa = m_empresa.IRETENCIONISR.ToString("N2", nfi);

                    impuestosRetenidos.Add(impuestoRetenido);
                }

                //Inicializar VirtualXmlHelper
                VirtualXmlHelper virtualXmlHelper = new VirtualXmlHelper(m_empresa.IVERSIONCFDI);

                virtualXmlHelper.ManejaAddenda = false;
                virtualXmlHelper.ManejaImpuestosLocales = false;
                virtualXmlHelper.ManejaRetenidos = impuestosRetenidos.Count() > 0;
                virtualXmlHelper.ManejaTrasladados = impuestosTrasladados.Count() > 0;

                virtualXmlHelper.CiberSatInfo = ciberSatIInfo;
                virtualXmlHelper.ComprobanteInfo = comprobanteInfo;
                virtualXmlHelper.ComprobanteInfoEx = comprobanteInfoEx;
                virtualXmlHelper.Conceptos = conceptos;
                virtualXmlHelper.EmisorExpedidoEn = emisorExpedidoEn;
                virtualXmlHelper.EmisorInfo = emisorInfo;
                virtualXmlHelper.ImpuestosInfo = impuestosInfo;
                virtualXmlHelper.ReceptorInfo = receptorInfo;
                virtualXmlHelper.ImpuestosRetenidos = impuestosRetenidos;
                virtualXmlHelper.ImpuestosTrasladados = impuestosTrasladados;
                virtualXmlHelper.RutaCsd = m_empresa.ITIMBRADOARCHIVOCERTIFICADO;
                virtualXmlHelper.Llave = m_empresa.ITIMBRADOARCHIVOKEY;
                virtualXmlHelper.ClaveLlave = m_empresa.ITIMBRADOPASSWORD;
                virtualXmlHelper.RutaXml = documentoTimbrado;
                virtualXmlHelper.VirtualPacInfo = new VirtualPACInfo(m_empresa.IPACUSUARIO, "virtual");

                string resultado = virtualXmlHelper.GenerarDocumento();
                return String.IsNullOrEmpty(resultado);

            }
            catch (Exception ex)
            {
                if (!m_silentMode)
                {
                    MessageBox.Show("Ocurrio un error al generar el xml para ser timbrado" + ex.Message + ex.StackTrace);
                }
                else
                {
                    m_iComentario = "Ocurrio un error al generar el xml para ser timbrado" + ex.Message + ex.StackTrace;
                }
                return false;
            }

            return true;
        }



        public CCARTAPORTEBE ObtenerDatosCartaPorte()
        {
            m_CartaPorteIdccp = null;


            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";

            CCARTAPORTELINEAD comprobanteD = new CCARTAPORTELINEAD();
            List<CCARTAPORTELINEABE> lineas = comprobanteD.CARTAPORTE_XML(m_Docto.IID, m_fTrans);

            CCARTAPORTEBE cartaPorte = new CCARTAPORTEBE();
            cartaPorte.ICARTAPORTEMERCANCIAList = new List<CCARTAPORTEMERCANCIABE>();
            cartaPorte.ICARTAPORTEUBICACIONList = new List<CCARTAPORTEUBICACIONBE>();
            cartaPorte.ICARTAPORTETRANSPTIPOFIGURAList = new List<CCARTAPORTETRANSPTIPOFIGURABE>();



            CCARTAPORTEUBICACIONBE iCARTAPORTEUBICACION = null;
            CCARTAPORTEMERCANCIABE iCARTAPORTEMERCANCIA = null;
            CCARTAPORTETRANSPTIPOFIGURABE iCARTAPORTETRANSPTIPOFIGURA = null;


            //Proceso de generacion del documento

            IEnumerable<CCARTAPORTELINEABE> cartaPorteItems = lineas.Where(
                                                p => p.ITIPOLINEA.Equals("CARTAPORTE", StringComparison.CurrentCultureIgnoreCase));
            if (cartaPorteItems != null && cartaPorteItems.Count() > 0)
            {
                cartaPorte.FillFromCartaPorteLinea(cartaPorteItems.First());
                m_CartaPorteIdccp = cartaPorte.IIDCCP;
            }

            IEnumerable<CCARTAPORTELINEABE> cartaPorteUbicaciones = lineas.Where(
                                                p => p.ITIPOLINEA.Equals("CARTAPORTE_UBICACION", StringComparison.CurrentCultureIgnoreCase));
            if (cartaPorteUbicaciones != null && cartaPorteUbicaciones.Count() > 0)
            {
                foreach (CCARTAPORTELINEABE item in cartaPorteUbicaciones)
                {
                    iCARTAPORTEUBICACION = new CCARTAPORTEUBICACIONBE();
                    iCARTAPORTEUBICACION.FillFromCartaPorteLinea(item);
                    cartaPorte.ICARTAPORTEUBICACIONList.Add(iCARTAPORTEUBICACION);
                }
            }



            IEnumerable<CCARTAPORTELINEABE> cartaPorteTotalMercancias = lineas.Where(
                                                p => p.ITIPOLINEA.Equals("CARTAPORTE_TOTALMERCANCIAS", StringComparison.CurrentCultureIgnoreCase));
            if (cartaPorteTotalMercancias != null && cartaPorteTotalMercancias.Count() > 0)
            {
                cartaPorte.ICARTAPORTETOTALMERCANCIAS = new CCARTAPORTETOTALMERCANCIASBE();
                cartaPorte.ICARTAPORTETOTALMERCANCIAS.FillFromCartaPorteLinea(cartaPorteTotalMercancias.First());
            }




            IEnumerable<CCARTAPORTELINEABE> cartaPorteMercancias = lineas.Where(
                                                p => p.ITIPOLINEA.Equals("CARTAPORTE_MERCANCIA", StringComparison.CurrentCultureIgnoreCase));
            if (cartaPorteMercancias != null && cartaPorteMercancias.Count() > 0)
            {
                foreach (CCARTAPORTELINEABE item in cartaPorteMercancias)
                {
                    iCARTAPORTEMERCANCIA = new CCARTAPORTEMERCANCIABE();
                    iCARTAPORTEMERCANCIA.FillFromCartaPorteLinea(item);
                    cartaPorte.ICARTAPORTEMERCANCIAList.Add(iCARTAPORTEMERCANCIA);
                }
            }



            IEnumerable<CCARTAPORTELINEABE> cartaPorteCantTransp = lineas.Where(
                                                p => p.ITIPOLINEA.Equals("CARTAPORTE_CANTTRANSP", StringComparison.CurrentCultureIgnoreCase));
            if (cartaPorteCantTransp != null && cartaPorteCantTransp.Count() > 0)
            {
                cartaPorte.ICARTAPORTECANTTRANSP = new CCARTAPORTECANTTRANSPBE();
                cartaPorte.ICARTAPORTECANTTRANSP.FillFromCartaPorteLinea(cartaPorteCantTransp.First());
            }


            IEnumerable<CCARTAPORTELINEABE> cartaPorteAutoTransp = lineas.Where(
                                                p => p.ITIPOLINEA.Equals("CARTAPORTE_AUTOTRANSP", StringComparison.CurrentCultureIgnoreCase));
            if (cartaPorteAutoTransp != null && cartaPorteAutoTransp.Count() > 0)
            {
                cartaPorte.ICARTAPORTEAUTOTRANSPBE = new CCARTAPORTEAUTOTRANSPBE();
                cartaPorte.ICARTAPORTEAUTOTRANSPBE.FillFromCartaPorteLinea(cartaPorteAutoTransp.First());
            }


            IEnumerable<CCARTAPORTELINEABE> cartaPorteTranspTipoFigura = lineas.Where(
                                                p => p.ITIPOLINEA.Equals("CARTAPORTE_TRANSPTIPOFIGURA", StringComparison.CurrentCultureIgnoreCase));
            if (cartaPorteTranspTipoFigura != null && cartaPorteTranspTipoFigura.Count() > 0)
            {
                foreach (CCARTAPORTELINEABE item in cartaPorteTranspTipoFigura)
                {
                    iCARTAPORTETRANSPTIPOFIGURA = new CCARTAPORTETRANSPTIPOFIGURABE();
                    iCARTAPORTETRANSPTIPOFIGURA.FillFromCartaPorteLinea(item);
                    cartaPorte.ICARTAPORTETRANSPTIPOFIGURAList.Add(iCARTAPORTETRANSPTIPOFIGURA);
                }
            }




            return cartaPorte;
        }



        public bool ObtenerDatosDocumentoVirtualXmlCfdi33(string tipoComprobanteEspecial = "")
        {

            bool esComisionista = EsComisionista();

            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";

            CCOMPROBANTEFISCALLINEAD comprobanteD = new CCOMPROBANTEFISCALLINEAD();
            List<CCOMPROBANTEFISCALLINEABE> lineas = comprobanteD.FACTURAELECTRONICA_XML(m_Docto.IID, tipoComprobanteEspecial, m_fTrans);


            CCOMPROBANTEFISCALLINEABE comprobanteHdr = null;
            CCOMPROBANTEFISCALLINEABE comprobanteInfoEx = null;
            CCOMPROBANTEFISCALLINEABE comprobanteEmisor = null;
            CCOMPROBANTEFISCALLINEABE comprobanteReceptor = null;
            CCOMPROBANTEFISCALLINEABE comprobanteEmisorExpedidoEn = null;
            CCOMPROBANTEFISCALLINEABE comprobanteTotalImpuestos = null;


            CCOMPROBANTEFISCALLINEABE comprobanteInformacionGlobal = null;

            CCARTAPORTEBE cartaPorte = this.m_generarCartaPorte ? ObtenerDatosCartaPorte() : null;

            //Proceso de generacion del documento
            try
            {
                //VirtualXML CiberSatInfo
                CiberSATInfo ciberSatIInfo = new CiberSATInfo(m_empresa.ITIMBRADOUSER, m_empresa.ITIMBRADOKEY);



                IEnumerable<CCOMPROBANTEFISCALLINEABE> comprobanteHeaders = lineas.Where(
                                                    p => p.ITIPOLINEA.Equals("COMPROBANTE", StringComparison.CurrentCultureIgnoreCase));
                if (comprobanteHeaders != null && comprobanteHeaders.Count() > 0)
                {
                    comprobanteHdr = comprobanteHeaders.First();
                }

                comprobanteHeaders = lineas.Where(
                                                        p => p.ITIPOLINEA.Equals("COMPROBANTEINFOEX", StringComparison.CurrentCultureIgnoreCase));
                if (comprobanteHeaders != null && comprobanteHeaders.Count() > 0)
                {
                    comprobanteInfoEx = comprobanteHeaders.First();
                }


                comprobanteHeaders = lineas.Where(
                                                        p => p.ITIPOLINEA.Equals("EMISOR", StringComparison.CurrentCultureIgnoreCase));
                if (comprobanteHeaders != null && comprobanteHeaders.Count() > 0)
                {
                    comprobanteEmisor = comprobanteHeaders.First();
                }

                comprobanteHeaders = lineas.Where(
                                                        p => p.ITIPOLINEA.Equals("RECEPTORINFO", StringComparison.CurrentCultureIgnoreCase));
                if (comprobanteHeaders != null && comprobanteHeaders.Count() > 0)
                {
                    comprobanteReceptor = comprobanteHeaders.First();
                }


                comprobanteHeaders = lineas.Where(
                                                        p => p.ITIPOLINEA.Equals("EMISOREXPEDIDOEN", StringComparison.CurrentCultureIgnoreCase));
                if (comprobanteHeaders != null && comprobanteHeaders.Count() > 0)
                {
                    comprobanteEmisorExpedidoEn = comprobanteHeaders.First();
                }


                comprobanteHeaders = lineas.Where(
                                                        p => p.ITIPOLINEA.Equals("INFORMACIONGLOBAL", StringComparison.CurrentCultureIgnoreCase));
                if (comprobanteHeaders != null && comprobanteHeaders.Count() > 0)
                {
                    comprobanteInformacionGlobal = comprobanteHeaders.First();
                }

                


                if (comprobanteHdr == null)
                {
                    return false;
                }

                //tipo comprobante especial
                //if(tipoComprobanteEspecial == "T")
                //{
                //    comprobanteHdr.ISUBTOTAL = 0;
                //    comprobanteHdr.IDESCUENTO = 0;
                //    comprobanteHdr.ITOTAL = 0;
                //    comprobanteHdr.ICONDICIONESPAGO = "";
                //    comprobanteHdr.IFORMAPAGO = "";
                //    comprobanteHdr.IMETODOPAGO = "";
                //    comprobanteHdr.ITIPOCOMPROBANTE = "T";
                //    comprobanteHdr.IMONEDA = "XXX";



                //    lineas = lineas.Where(
                //                                            p => 
                //                                                !p.ITIPOLINEA.Equals("INFORMACIONADUANERA", StringComparison.CurrentCultureIgnoreCase) &&
                //                                                !p.ITIPOLINEA.Equals("CONCEPTO_IEPS", StringComparison.CurrentCultureIgnoreCase) &&
                //                                                !p.ITIPOLINEA.Equals("CONCEPTO_IVA", StringComparison.CurrentCultureIgnoreCase) &&
                //                                                !p.ITIPOLINEA.Equals("CONCEPTO_IVARETENIDO", StringComparison.CurrentCultureIgnoreCase) &&
                //                                                !p.ITIPOLINEA.Equals("CONCEPTO_ISRRETENIDO", StringComparison.CurrentCultureIgnoreCase) &&
                //                                                !p.ITIPOLINEA.Equals("TOTAL_TRASLADOSRETENCIONES", StringComparison.CurrentCultureIgnoreCase) &&
                //                                                !p.ITIPOLINEA.Equals("COMPROBANTE_IVA", StringComparison.CurrentCultureIgnoreCase) &&
                //                                                !p.ITIPOLINEA.Equals("COMPROBANTE_IEPS", StringComparison.CurrentCultureIgnoreCase) &&
                //                                                !p.ITIPOLINEA.Equals("COMPROBANTE_IVARETENIDO", StringComparison.CurrentCultureIgnoreCase) &&
                //                                                !p.ITIPOLINEA.Equals("COMPROBANTE_ISRRETENIDO", StringComparison.CurrentCultureIgnoreCase)

                //                           ).ToList();



                //}

                decimal testNumber = 0.00m;

                //ComprobanteInfo VirtualXml
                ComprobanteInfo comprobanteInfo = new ComprobanteInfo(comprobanteHdr.ISERIE,
                                                                      comprobanteHdr.IFOLIO,
                                                                      comprobanteHdr.IFECHA.ToString("yyyy-MM-dd'T'HH:mm:ss"),
                                                                      comprobanteHdr.ITIPOCOMPROBANTE,
                                                                      comprobanteHdr.IFORMAPAGO,
                                                                      comprobanteHdr.ISUBTOTAL == 0 ? "0" : comprobanteHdr.ISUBTOTAL.ToString("N2", nfi),
                                                                      comprobanteHdr.IDESCUENTO == 0 ? "" : comprobanteHdr.IDESCUENTO.ToString("N2", nfi),
                                                                      comprobanteHdr.ITOTAL == 0 ? "0" : comprobanteHdr.ITOTAL.ToString("N2", nfi),
                                                                      comprobanteHdr.IMONEDA,
                                                                     comprobanteHdr.ITIPOCAMBIO,
                                                                      comprobanteHdr.ICONDICIONESPAGO,
                                                                      comprobanteHdr.IMETODOPAGO,
                                                                      comprobanteHdr.IMOTIVODESCUENTO,
                                                                      comprobanteHdr.ILUGAREXPEDICION,
                                                                      comprobanteHdr.IEXPORTACION);


                ComprobanteInfoEx comprobanteInfoExtra = new ComprobanteInfoEx(comprobanteInfoEx.ILUGAREXPEDICION,
                                                                            comprobanteInfoEx.INUMEROCTAPAGO,
                                                                            comprobanteInfoEx.ISERIEFOLIOFISCALORIGINAL == null ? null : comprobanteInfoEx.ISERIEFOLIOFISCALORIGINAL,
                                                                            comprobanteInfoEx.IFOLIOFISCALORIGINAL == null ? null : comprobanteInfoEx.IFOLIOFISCALORIGINAL,
                                                                             comprobanteInfoEx.IMONTOFOLIOFISCALORIGINAL.ToString("N2", nfi),
                                                                            comprobanteInfoEx.IFOLIOFISCALORIGINAL == null ? null : comprobanteInfoEx.IFECHAFOLIOFISCALORIGINAL.ToString("yyyy-MM-dd'T'HH:mm:ss"));


                InformacionGlobal informacionGlobal =
                    comprobanteInformacionGlobal != null ? 
                            new InformacionGlobal(comprobanteInformacionGlobal.IPERIODICIDAD, comprobanteInformacionGlobal.IMESES, comprobanteInformacionGlobal.IANIO)
                            : null;


                //EmisorInfo VirtualXml
                Domicilio emisorDomicilio = new Domicilio();
                emisorDomicilio.Calle = comprobanteEmisor.ICALLE;
                emisorDomicilio.NoExterior = comprobanteEmisor.INOEXTERIOR;
                emisorDomicilio.NoInterior = comprobanteEmisor.INOINTERIOR;
                emisorDomicilio.Colonia = comprobanteEmisor.ICOLONIA;
                emisorDomicilio.Localidad = comprobanteEmisor.ILOCALIDAD;
                emisorDomicilio.Referencia = comprobanteEmisor.IREFERENCIA;
                emisorDomicilio.Municipio = comprobanteEmisor.IMUNICIPIO;
                emisorDomicilio.Estado = comprobanteEmisor.IESTADO;
                emisorDomicilio.Pais = comprobanteEmisor.IPAIS;
                emisorDomicilio.CodigoPostal = comprobanteEmisor.ICODIGOPOSTAL;
                EmisorInfo emisorInfo = new EmisorInfo(comprobanteEmisor.IRFC, comprobanteEmisor.IRAZONSOCIAL, comprobanteEmisor.IREGIMENFISCAL, emisorDomicilio);




                //EmisorExpedidoEn VirtualXml
                EmisorExpedidoEn emisorExpedidoEn = new EmisorExpedidoEn();
                emisorExpedidoEn.Calle = comprobanteReceptor.ICALLE;
                emisorExpedidoEn.NoExterior = comprobanteReceptor.INOEXTERIOR;
                emisorExpedidoEn.NoInterior = comprobanteReceptor.INOINTERIOR;
                emisorExpedidoEn.Colonia = comprobanteReceptor.ICOLONIA;
                emisorExpedidoEn.Localidad = comprobanteReceptor.ILOCALIDAD;
                emisorExpedidoEn.Referencia = comprobanteReceptor.IREFERENCIA;
                emisorExpedidoEn.Municipio = comprobanteReceptor.IMUNICIPIO;
                emisorExpedidoEn.Estado = comprobanteReceptor.IESTADO;
                emisorExpedidoEn.Pais = comprobanteReceptor.IPAIS;
                emisorExpedidoEn.CodigoPostal = comprobanteReceptor.ICODIGOPOSTAL;



                

                //ReceptorInfo VirtualXml
                Domicilio receptorDomicilio = new Domicilio();
                receptorDomicilio.Calle = comprobanteReceptor.ICALLE;
                receptorDomicilio.NoExterior = comprobanteReceptor.INOEXTERIOR;
                receptorDomicilio.NoInterior = comprobanteReceptor.INOINTERIOR;
                receptorDomicilio.Colonia = comprobanteReceptor.ICOLONIA;
                receptorDomicilio.Localidad = comprobanteReceptor.ILOCALIDAD;
                receptorDomicilio.Referencia = comprobanteReceptor.IREFERENCIA;
                receptorDomicilio.Municipio = comprobanteReceptor.IMUNICIPIO;
                receptorDomicilio.Estado = comprobanteReceptor.IESTADO;
                receptorDomicilio.Pais = comprobanteReceptor.IPAIS;
                receptorDomicilio.CodigoPostal = comprobanteReceptor.ICODIGOPOSTAL;
                ReceptorInfo receptorInfo = new ReceptorInfo();
                receptorInfo.Rfc = comprobanteReceptor.IRFC;
                receptorInfo.RazonSocial = comprobanteReceptor.IRAZONSOCIAL;
                receptorInfo.Domicilio = receptorDomicilio;
                receptorInfo.ResidenciaFiscal = comprobanteReceptor.IRESIDENCIAFISCAL;
                receptorInfo.Nombre = comprobanteReceptor.INOMBRE;
                receptorInfo.NumRegIdTrib = comprobanteReceptor.INUMREGIDTRIB;
                receptorInfo.UsoCFDI = comprobanteReceptor.IUSOCFDI ;
                receptorInfo.RegimenFiscalReceptor = comprobanteReceptor.IREGIMENFISCAL;
                receptorInfo.DomicilioFiscalReceptor = comprobanteReceptor.IDOMICILIOFISCAL;


                if(tipoComprobanteEspecial == "T" && cartaPorte != null)
                {
                    
                    receptorInfo.Rfc = comprobanteEmisor.IRFC;
                    receptorInfo.RazonSocial = comprobanteEmisor.IRAZONSOCIAL;
                    receptorInfo.ResidenciaFiscal = comprobanteEmisor.IRESIDENCIAFISCAL;
                    receptorInfo.Nombre = comprobanteEmisor.INOMBRE;
                    receptorInfo.NumRegIdTrib = comprobanteEmisor.INUMREGIDTRIB;
                    receptorInfo.UsoCFDI = m_empresa.IVERSIONCFDI != null && m_empresa.IVERSIONCFDI.Equals("4.0") ? "S01" : comprobanteReceptor.IUSOCFDI;
                    receptorInfo.RegimenFiscalReceptor = comprobanteEmisor.IREGIMENFISCAL;
                    receptorInfo.DomicilioFiscalReceptor = comprobanteEmisor.IDOMICILIOFISCAL;
                }



                List<Concepto> conceptos = new List<Concepto>();


                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_RECIBOELECTRONICO)
                {
                    IEnumerable<CCOMPROBANTEFISCALLINEABE> comprobanteConceptos = lineas.Where(
                                                               p => p.ITIPOLINEA.Equals("CONCEPTO", StringComparison.CurrentCultureIgnoreCase));

                    if (comprobanteConceptos != null && comprobanteConceptos.Count() > 0)
                    {
                        var comprobanteConcepto = comprobanteConceptos.First();

                        Concepto concepto = new Concepto();
                        concepto.Cantidad = "1";
                        concepto.Unidad = "";
                        concepto.Descripcion = "Pago";
                        concepto.ValorUnitario = "0";
                        concepto.Importe = "0";
                        concepto.NoIdentificacion = "";
                        concepto.CuentaPredial = "";
                        concepto.ClaveProdServ = "84111506";
                        concepto.ClaveUnidad = "ACT";
                        concepto.Descuento = "";
                        concepto.ObjetoImp = "01";// comprobanteConcepto.IOBJETOIMP;
                        conceptos.Add(concepto);
                    }
                }
                else
                {

                    IEnumerable<CCOMPROBANTEFISCALLINEABE> comprobanteConceptos = lineas.Where(
                                                            p => p.ITIPOLINEA.Equals("CONCEPTO", StringComparison.CurrentCultureIgnoreCase));
                    if (comprobanteConceptos != null && comprobanteConceptos.Count() > 0)
                    {
                        foreach (CCOMPROBANTEFISCALLINEABE comprobanteConcepto in comprobanteConceptos)
                        {
                            Concepto concepto = new Concepto();
                            concepto.ImpuestosRetenidos = new List<Traslado>();
                            concepto.ImpuestosTrasladados = new List<Traslado>();
                            concepto.ConceptoPartes = new List<ConceptoParte>();
                            concepto.InfoAduanera = new List<InformacionAduanera>();
                            concepto.ComplementoConceptos = new List<String>();

                            concepto.Cantidad = comprobanteConcepto.ICANTIDAD.ToString("N2", nfi);
                            concepto.Unidad = comprobanteConcepto.IUNIDAD;
                            concepto.Descripcion = comprobanteConcepto.IDESCRIPCION;
                            concepto.ValorUnitario = comprobanteConcepto.IVALORUNITARIO.ToString("N2", nfi);
                            concepto.Importe = comprobanteConcepto.IIMPORTE.ToString("N2", nfi);
                            concepto.NoIdentificacion = comprobanteConcepto.INOIDENTIFICACION;
                            concepto.CuentaPredial = comprobanteConcepto.ICUENTAPREDIAL;
                            concepto.ClaveProdServ = comprobanteConcepto.ICLAVEPRODSERV;
                            concepto.ClaveUnidad = comprobanteConcepto.ICLAVEUNIDAD;
                            concepto.Descuento = comprobanteHdr.IDESCUENTO == 0 || comprobanteConcepto.IDESCUENTO == 0 ? "" : comprobanteConcepto.IDESCUENTO.ToString("N2", nfi);
                            concepto.ObjetoImp = comprobanteConcepto.IOBJETOIMP;


                            IEnumerable<CCOMPROBANTEFISCALLINEABE> comprobanteConceptoParte = lineas.Where(
                                                                    p => p.ITIPOLINEA.Equals("CONCEPTO_PARTE", StringComparison.CurrentCultureIgnoreCase) &&
                                                                         p.IPADRELINEA == comprobanteConcepto.IID);


                            foreach (CCOMPROBANTEFISCALLINEABE itemLinea in comprobanteConceptoParte)
                            {
                                ConceptoParte conceptoParte = new ConceptoParte();
                                conceptoParte.ClaveProdServ = itemLinea.ICLAVEPRODSERV;
                                conceptoParte.NoIdentificacion = itemLinea.INOIDENTIFICACION;
                                conceptoParte.Cantidad = itemLinea.ICANTIDAD.ToString("N2", nfi);
                                conceptoParte.Unidad = itemLinea.IUNIDAD;
                                conceptoParte.Descripcion = itemLinea.IDESCRIPCION;
                                conceptoParte.ValorUnitario = itemLinea.IVALORUNITARIO.ToString("N2", nfi);
                                conceptoParte.Importe = itemLinea.IIMPORTE.ToString("N2", nfi);
                                conceptoParte.NumeroPedimento = "";

                                concepto.ConceptoPartes.Add(conceptoParte);
                            }




                            IEnumerable<CCOMPROBANTEFISCALLINEABE> comprobanteAduaneros = lineas.Where(
                                                                    p => p.ITIPOLINEA.Equals("INFORMACIONADUANERA", StringComparison.CurrentCultureIgnoreCase) &&
                                                                         p.IPADRELINEA == comprobanteConcepto.IID);

                            foreach (CCOMPROBANTEFISCALLINEABE aduanero in comprobanteAduaneros)
                            {

                                InformacionAduanera infoAduanera = new InformacionAduanera();

                                infoAduanera.Aduana = aduanero.IADUANA;
                                infoAduanera.Fecha = aduanero.IFECHA.ToString("yyyy-MM-dd'T'HH:mm:ss");
                                infoAduanera.Numero = aduanero.INUMERO;

                                infoAduanera.Numero = infoAduanera.Numero.Substring(0, 2) + "  " + infoAduanera.Numero.Substring(2, 2) +
                                                         "  " + infoAduanera.Numero.Substring(4, 4) + "  " + infoAduanera.Numero.Substring(8);


                                concepto.InfoAduanera.Add(infoAduanera);
                            }


                            //CCOMPROBANTEFISCALLINEABE itemImpuesto = new CCOMPROBANTEFISCALLINEABE();

                            IEnumerable<CCOMPROBANTEFISCALLINEABE> comprobanteConceptoImpuesto = lineas.Where(
                                                                    p => p.ITIPOLINEA.Equals("CONCEPTO_IEPS", StringComparison.CurrentCultureIgnoreCase) &&
                                                                         p.IPADRELINEA == comprobanteConcepto.IID);
                            Traslado impuestoConcepto = new Traslado();
                            if (comprobanteConceptoImpuesto != null && comprobanteConceptoImpuesto.Count() > 0)
                            {
                                foreach (CCOMPROBANTEFISCALLINEABE itemImpuesto in comprobanteConceptoImpuesto)
                                {
                                    //itemImpuesto = comprobanteConceptoImpuesto.First();
                                    impuestoConcepto = new Traslado();
                                    impuestoConcepto.BaseImp = itemImpuesto.IBASEIMP.ToString("N4", nfi);
                                    impuestoConcepto.ImpuestoVal = itemImpuesto.IIMPUESTO;
                                    impuestoConcepto.Tasa = itemImpuesto.ITASA.ToString("N2", nfi);
                                    impuestoConcepto.TasaCuota = (itemImpuesto.ITASA / 100.00m).ToString("N6", nfi);
                                    impuestoConcepto.Importe = itemImpuesto.IIMPORTE.ToString("N2", nfi);
                                    impuestoConcepto.TipoFactor = itemImpuesto.ITIPOFACTOR;
                                    concepto.ImpuestosTrasladados.Add(impuestoConcepto);
                                }
                            }





                                comprobanteConceptoImpuesto = lineas.Where(
                                                                    p => p.ITIPOLINEA.Equals("CONCEPTO_IVA", StringComparison.CurrentCultureIgnoreCase) &&
                                                                         p.IPADRELINEA == comprobanteConcepto.IID);
                            if (comprobanteConceptoImpuesto != null && comprobanteConceptoImpuesto.Count() > 0)
                            {
                                foreach (CCOMPROBANTEFISCALLINEABE itemImpuesto in comprobanteConceptoImpuesto)
                                {
                                    //itemImpuesto = comprobanteConceptoImpuesto.First();
                                    impuestoConcepto = new Traslado();
                                    impuestoConcepto.BaseImp = itemImpuesto.IBASEIMP.ToString("N4", nfi);
                                    impuestoConcepto.ImpuestoVal = itemImpuesto.IIMPUESTO;
                                    impuestoConcepto.Tasa = itemImpuesto.ITASA.ToString("N2", nfi);
                                    impuestoConcepto.TasaCuota = (itemImpuesto.ITASA / 100.00m).ToString("N6", nfi);
                                    impuestoConcepto.Importe = itemImpuesto.IIMPORTE.ToString("N2", nfi);
                                    impuestoConcepto.TipoFactor = itemImpuesto.ITIPOFACTOR;
                                    concepto.ImpuestosTrasladados.Add(impuestoConcepto);

                                    if(itemImpuesto.ITASA == 16)
                                    {
                                        testNumber = testNumber + itemImpuesto.IBASEIMP;
                                    }
                                }
                            }

                            
                            comprobanteConceptoImpuesto = lineas.Where(
                                                                    p => p.ITIPOLINEA.Equals("CONCEPTO_IVARETENIDO", StringComparison.CurrentCultureIgnoreCase) &&
                                                                         p.IPADRELINEA == comprobanteConcepto.IID);
                            if (comprobanteConceptoImpuesto != null && comprobanteConceptoImpuesto.Count() > 0)
                            {
                                foreach (CCOMPROBANTEFISCALLINEABE itemImpuesto in comprobanteConceptoImpuesto)
                                {
                                    //itemImpuesto = comprobanteConceptoImpuesto.First();
                                    impuestoConcepto = new Traslado();
                                    impuestoConcepto.BaseImp = itemImpuesto.IBASEIMP.ToString("N4", nfi);
                                    impuestoConcepto.ImpuestoVal = itemImpuesto.IIMPUESTO;
                                    impuestoConcepto.Tasa = itemImpuesto.ITASA.ToString("N2", nfi);
                                    impuestoConcepto.TasaCuota = (itemImpuesto.ITASA / 100.00m).ToString("N6", nfi);
                                    impuestoConcepto.Importe = itemImpuesto.IIMPORTE.ToString("N2", nfi);
                                    impuestoConcepto.TipoFactor = itemImpuesto.ITIPOFACTOR;
                                    concepto.ImpuestosRetenidos.Add(impuestoConcepto);
                                }
                            }




                            comprobanteConceptoImpuesto = lineas.Where(
                                                                    p => p.ITIPOLINEA.Equals("CONCEPTO_ISRRETENIDO", StringComparison.CurrentCultureIgnoreCase) &&
                                                                         p.IPADRELINEA == comprobanteConcepto.IID);
                            if (comprobanteConceptoImpuesto != null && comprobanteConceptoImpuesto.Count() > 0)
                            {
                                foreach (CCOMPROBANTEFISCALLINEABE itemImpuesto in comprobanteConceptoImpuesto)
                                {
                                    //itemImpuesto = comprobanteConceptoImpuesto.First();
                                    impuestoConcepto = new Traslado();
                                    impuestoConcepto.BaseImp = itemImpuesto.IBASEIMP.ToString("N4", nfi);
                                    impuestoConcepto.ImpuestoVal = itemImpuesto.IIMPUESTO;
                                    impuestoConcepto.Tasa = itemImpuesto.ITASA.ToString("N2", nfi);
                                    impuestoConcepto.TasaCuota = (itemImpuesto.ITASA / 100.00m).ToString("N6", nfi);
                                    impuestoConcepto.Importe = itemImpuesto.IIMPORTE.ToString("N2", nfi);
                                    impuestoConcepto.TipoFactor = itemImpuesto.ITIPOFACTOR;
                                    impuestoConcepto.TipoFactor = itemImpuesto.ITIPOFACTOR;
                                    concepto.ImpuestosRetenidos.Add(impuestoConcepto);
                                }
                            }

                            
                            if (esComisionista)
                            {
                                ObtenerConceptoTrasladoComisionista(ref concepto);

                            }

                            conceptos.Add(concepto);


                        }
                    }
                }

                List<PagoSAT> pagosSat = new List<PagoSAT>();
                PagoSAT pagoSat = new PagoSAT();
                pagoSat.DoctosRelacionados = new List<PagoDoctoSAT>();
                CPAGODOCTOSAT_IMPD auxDaoDoctoPagoSat_imp = new CPAGODOCTOSAT_IMPD();

                IEnumerable<CCOMPROBANTEFISCALLINEABE> comprobantePagos = lineas.Where(
                                                        p => p.ITIPOLINEA.Equals("PAGO", StringComparison.CurrentCultureIgnoreCase));


                foreach (CCOMPROBANTEFISCALLINEABE comprobantePAGO in comprobantePagos)
                {
                    pagoSat.FechaPago = comprobantePAGO.IFECHAPAGO.ToString("yyyy-MM-dd'T'HH:mm:ss");
                    pagoSat.FormaDePagoP = comprobantePAGO.IFORMADEPAGOP;
                    pagoSat.MonedaP = comprobantePAGO.IMONEDAP;
                    pagoSat.TipoCambioP = comprobantePAGO.IMONEDAP.Equals("MXN") ? (m_empresa.IVERSIONCFDI.Equals("3.3") ? "" : "1") : comprobantePAGO.ITIPOCAMBIOP.ToString(); ;
                    pagoSat.Monto = comprobantePAGO.IMONTO.ToString("N2", nfi);
                    pagoSat.NumOperacion = comprobantePAGO.INUMOPERACION;
                    pagoSat.RfcEmisorCtaOrd = comprobantePAGO.IRFCEMISORCTAORD;
                    pagoSat.NomBancoOrdExt = comprobantePAGO.INOMBANCOORDEXT;
                    pagoSat.CtaOrdenante = comprobantePAGO.ICTAORDENANTE;
                    pagoSat.RfcEmisorCtaBen = comprobantePAGO.IRFCEMISORCTABEN;
                    pagoSat.CtaBeneficiario = comprobantePAGO.ICTABENEFICIARIO;
                    pagoSat.TipoCadPago = comprobantePAGO.ITIPOCADPAGO;
                    pagoSat.CertPago = comprobantePAGO.ICERTPAGO;
                    pagoSat.CadPago = comprobantePAGO.ICADPAGO;
                    pagoSat.SelloPago = comprobantePAGO.ISELLOPAGO;


                    IEnumerable<CCOMPROBANTEFISCALLINEABE> comprobanteDoctosRel = lineas.Where(
                                                            p => p.ITIPOLINEA.Equals("PAGODOCTO", StringComparison.CurrentCultureIgnoreCase));


                    foreach (CCOMPROBANTEFISCALLINEABE doctorelacionado in comprobanteDoctosRel)
                    {
                        PagoDoctoSAT doctoRel = new PagoDoctoSAT();
                        doctoRel.IdDocumento = doctorelacionado.IIDDOCUMENTO;
                        doctoRel.Serie = doctorelacionado.ISERIE;
                        doctoRel.Folio = doctorelacionado.IFOLIO;
                        doctoRel.MonedaDR = doctorelacionado.IMONEDADR;
                        doctoRel.TipoCambioDR = doctorelacionado.IMONEDADR.Equals("MXN") ? (m_empresa.IVERSIONCFDI.Equals("3.3") ? "" : "1") : doctorelacionado.ITIPOCAMBIODR;
                        doctoRel.MetodoDePagoDR = doctorelacionado.IMETODODEPAGODR;
                        doctoRel.NumParcialidad = doctorelacionado.INUMPARCIALIDAD.ToString();
                        doctoRel.ImpSaldoAnt = doctorelacionado.IIMPSALDOANT.ToString("N2", nfi);
                        doctoRel.ImpPagado = doctorelacionado.IIMPPAGADO.ToString("N2", nfi);
                        doctoRel.ImpSaldoInsoluto = doctorelacionado.IIMPSALDOINSOLUTO.ToString("N2", nfi);
                        doctoRel.ObjetoImpDR =  doctorelacionado.IOBJETOIMP;

                        pagoSat.DoctosRelacionados.Add(doctoRel);
                    }

                    pagoSat.DoctosImpRelacionados = auxDaoDoctoPagoSat_imp.seleccionarPAGODOCTOSAT_IMPByPAGOSATID(m_Docto.IID, m_fTrans);

                }

                pagosSat.Add(pagoSat);


                ImpuestosInfo impuestosInfo = new ImpuestosInfo();
                List<Traslado> impuestosTrasladados = new List<Traslado>();

                //if (tipoComprobanteEspecial != "T")
                //{


                    comprobanteHeaders = lineas.Where(
                                                            p => p.ITIPOLINEA.Equals("TOTAL_TRASLADOSRETENCIONES", StringComparison.CurrentCultureIgnoreCase));
                    if (comprobanteHeaders != null && comprobanteHeaders.Count() > 0)
                    {
                        comprobanteTotalImpuestos = comprobanteHeaders.First();

                        impuestosInfo.TotalTraslados = comprobanteTotalImpuestos.ITOTALTRASLADOS.ToString("N2", nfi); //(m_empresa.IDESGLOSEIEPS.Equals("S") && clienteBE.m_PersonaBE.IDESGLOSEIEPS.Equals("S")) ? (m_Docto.IIMPUESTO / tipoDeCambio).ToString("N2", nfi) : (m_Docto.IIVA / tipoDeCambio).ToString("N2", nfi);
                        impuestosInfo.TotalRetenciones = comprobanteTotalImpuestos.ITOTALRETENCIONES.ToString("N2", nfi);

                    }


                    //si estan en 0 hay que pasar vacio
                    if (impuestosInfo.TotalRetenciones != null && impuestosInfo.TotalRetenciones.Equals("0.00"))
                        impuestosInfo.TotalRetenciones = "";



                    //Trasladados VirtualXml
                    IEnumerable<CCOMPROBANTEFISCALLINEABE> comprobanteIvaSuma = lineas.Where(
                                                            p => p.ITIPOLINEA.Trim().Equals("COMPROBANTE_IVA", StringComparison.CurrentCultureIgnoreCase));


                    foreach (CCOMPROBANTEFISCALLINEABE itemImpuesto in comprobanteIvaSuma)
                    {
                        Traslado impuestoConcepto = new Traslado();


                        impuestoConcepto = new Traslado();
                        impuestoConcepto.ImpuestoVal = itemImpuesto.IIMPUESTO;
                        impuestoConcepto.Tasa = itemImpuesto.ITASA.ToString("N2", nfi);
                        impuestoConcepto.TasaCuota = (itemImpuesto.ITASA / 100.00m).ToString("N6", nfi);
                        impuestoConcepto.Importe = itemImpuesto.IIMPORTE.ToString("N2", nfi);
                        impuestoConcepto.TipoFactor = itemImpuesto.ITIPOFACTOR;
                        impuestoConcepto.BaseImp = itemImpuesto.IBASEIMP.ToString("N2", nfi);
                        impuestosTrasladados.Add(impuestoConcepto);

                    }



                    IEnumerable<CCOMPROBANTEFISCALLINEABE> comprobanteIepsSuma = lineas.Where(
                                                            p => p.ITIPOLINEA.Trim().Equals("COMPROBANTE_IEPS", StringComparison.CurrentCultureIgnoreCase));


                    foreach (CCOMPROBANTEFISCALLINEABE itemImpuesto in comprobanteIepsSuma)
                    {
                        Traslado impuestoConcepto = new Traslado();


                        impuestoConcepto = new Traslado();
                        impuestoConcepto.ImpuestoVal = itemImpuesto.IIMPUESTO;
                        impuestoConcepto.Tasa = itemImpuesto.ITASA.ToString("N2", nfi);
                        impuestoConcepto.TasaCuota = (itemImpuesto.ITASA / 100.00m).ToString("N6", nfi);
                        impuestoConcepto.Importe = itemImpuesto.IIMPORTE.ToString("N2", nfi);
                        impuestoConcepto.TipoFactor = itemImpuesto.ITIPOFACTOR;
                        impuestoConcepto.BaseImp = itemImpuesto.IBASEIMP.ToString("N2", nfi);
                        impuestosTrasladados.Add(impuestoConcepto);

                    }


                    if (impuestosInfo.TotalTraslados != null && impuestosInfo.TotalTraslados.Equals("0.00")
                        && impuestosTrasladados.Count() == 0)
                        impuestosInfo.TotalTraslados = "";
                //}


                List<Retencion> impuestosRetenidos = new List<Retencion>();

                //Trasladados VirtualXml
                IEnumerable<CCOMPROBANTEFISCALLINEABE> comprobanteIvaRetenido = lineas.Where(
                                                        p => p.ITIPOLINEA.Equals("COMPROBANTE_IVARETENIDO", StringComparison.CurrentCultureIgnoreCase));


                foreach (CCOMPROBANTEFISCALLINEABE itemImpuesto in comprobanteIvaRetenido)
                {

                    Retencion impuestoRetenido = new Retencion();
                    impuestoRetenido.ImpuestoVal = itemImpuesto.IIMPUESTO;
                    impuestoRetenido.Importe = itemImpuesto.IIMPORTE.ToString("N2", nfi);
                    impuestoRetenido.Tasa = itemImpuesto.ITASA.ToString("N2", nfi);


                    impuestosRetenidos.Add(impuestoRetenido);

                }



                IEnumerable<CCOMPROBANTEFISCALLINEABE> comprobanteIsrRetenido = lineas.Where(
                                                        p => p.ITIPOLINEA.Equals("COMPROBANTE_ISRRETENIDO", StringComparison.CurrentCultureIgnoreCase));


                foreach (CCOMPROBANTEFISCALLINEABE itemImpuesto in comprobanteIsrRetenido)
                {

                    Retencion impuestoRetenido = new Retencion();
                    impuestoRetenido.ImpuestoVal = itemImpuesto.IIMPUESTO;
                    impuestoRetenido.Importe = itemImpuesto.IIMPORTE.ToString("N2", nfi);
                    impuestoRetenido.Tasa = itemImpuesto.ITASA.ToString("N2", nfi);


                    impuestosRetenidos.Add(impuestoRetenido);

                }


                if (impuestosInfo.TotalRetenciones != null && impuestosInfo.TotalRetenciones.Equals("0.00")
                    && impuestosRetenidos.Count() == 0)
                    impuestosInfo.TotalRetenciones = "";

                IEnumerable<CCOMPROBANTEFISCALLINEABE> comprobanteCfdiRelacionado = lineas.Where(
                                                        p => p.ITIPOLINEA.Equals("DOCTORELACIONADO", StringComparison.CurrentCultureIgnoreCase));


                Dictionary<String, List<String>> cfdiRelacionados = null;
                List<String> tiposRelacion = new List<string>();
                foreach (CCOMPROBANTEFISCALLINEABE relacionado in comprobanteCfdiRelacionado)
                {
                    if (!tiposRelacion.Contains(relacionado.ITIPORELACION))
                    {
                        tiposRelacion.Add(relacionado.ITIPORELACION);
                    }

                }


                if (tiposRelacion.Count > 0)
                {
                    cfdiRelacionados = new Dictionary<String, List<String>>();
                    foreach (string strTipoRelacion in tiposRelacion)
                    {


                        List<String> uuidRelacionados = new List<string>();
                        foreach (CCOMPROBANTEFISCALLINEABE relacionado in comprobanteCfdiRelacionado)
                        {
                            if (relacionado.ITIPORELACION.Equals(strTipoRelacion))
                            {
                                uuidRelacionados.Add(relacionado.IUUID);
                            }
                        }
                        cfdiRelacionados.Add(strTipoRelacion, uuidRelacionados);
                    }
                }





                virtualXmlHelper = new VirtualXmlHelper(m_empresa.IVERSIONCFDI);

                virtualXmlHelper.ManejaAddenda = false;
                virtualXmlHelper.ManejaImpuestosLocales = false;
                virtualXmlHelper.ManejaRetenidos = impuestosRetenidos.Count() > 0;
                virtualXmlHelper.ManejaTrasladados = impuestosTrasladados.Count() > 0;

                virtualXmlHelper.CiberSatInfo = ciberSatIInfo;
                virtualXmlHelper.ComprobanteInfo = comprobanteInfo;
                virtualXmlHelper.ComprobanteInfoEx = comprobanteInfoExtra;
                virtualXmlHelper.InformacionGlobal = informacionGlobal;
                virtualXmlHelper.Conceptos = conceptos;
                virtualXmlHelper.EmisorExpedidoEn = emisorExpedidoEn;
                virtualXmlHelper.EmisorInfo = emisorInfo;
                virtualXmlHelper.ImpuestosInfo = impuestosInfo;
                virtualXmlHelper.ReceptorInfo = receptorInfo;
                virtualXmlHelper.ImpuestosRetenidos = impuestosRetenidos;
                virtualXmlHelper.ImpuestosTrasladados =  impuestosTrasladados;
                virtualXmlHelper.RutaCsd = m_empresa.ITIMBRADOARCHIVOCERTIFICADO;
                virtualXmlHelper.Llave = m_empresa.ITIMBRADOARCHIVOKEY;
                virtualXmlHelper.ClaveLlave = m_empresa.ITIMBRADOPASSWORD;
                virtualXmlHelper.VirtualPacInfo = new VirtualPACInfo(m_empresa.IPACUSUARIO, "virtual"); //demo
                virtualXmlHelper.CfdiRelacionados = cfdiRelacionados;
                virtualXmlHelper.PagosSat = pagosSat;
                virtualXmlHelper.ICARTAPORTE = cartaPorte;
                
                decimal sumaConcepto = 0m;
                foreach (Concepto cc in conceptos)
                {
                    sumaConcepto += decimal.Parse(cc.Importe);
                }
                

                string jsonString = JsonConvert.SerializeObject(conceptos);


                string resultado = "";

                return String.IsNullOrEmpty(resultado);

            }
            catch (Exception ex)
            {
                if (!m_silentMode)
                {
                    MessageBox.Show("Ocurrio un error al generar el xml para ser timbrado" + ex.Message + ex.StackTrace);
                }
                else
                {
                    m_iComentario = "Ocurrio un error al generar el xml para ser timbrado" + ex.Message + ex.StackTrace;
                }
                return false;
            }
        }

        public void ObtenerConceptoTrasladoComisionista(ref Concepto concepto)
        {


            string filename = System.AppDomain.CurrentDomain.BaseDirectory + FileLocalLocation_FE_XML_ConceptoCompl_File;
            string textMolde = System.IO.File.ReadAllText(filename);

            foreach(Traslado trasl in concepto.ImpuestosTrasladados)
            {
                string textComplemento = textMolde.Replace("[ImporteTras]", trasl.Importe).Replace("[TasaTras]", trasl.TasaCuota);
                concepto.ComplementoConceptos.Add(textComplemento);
            }
            

        }


        public bool EsComisionista()
        {
            if (m_Docto == null || m_Docto.IPLAZOID == 0)
                return false;

            CPLAZOD plazoD = new CPLAZOD();
            CPLAZOBE plazoBE = new CPLAZOBE();
            plazoBE.IID = m_Docto.IPLAZOID;
            plazoBE = plazoD.seleccionarPLAZO(plazoBE, m_fTrans);

            if (plazoBE == null || plazoBE.ICOMISIONISTA == null || !plazoBE.ICOMISIONISTA.Equals("S"))
                return false;


            return true;

            
        }


        public bool GenerarDocumentoVirtualXmlCfdi33(string documentoTimbrado, string tipoComprobante)
        {

            try
            {

                string resultado = "";
                virtualXmlHelper.RutaXml = documentoTimbrado;
                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_RECIBOELECTRONICO)
                {
                    if (this.m_empresa.IVERSIONCFDI.Equals(VersionesFacturacion.V40))
                        resultado = virtualXmlHelper.GenerarPago40(m_silentMode);
                    else
                        resultado = virtualXmlHelper.GenerarPago33(m_silentMode);
                }
                else
                {
                    resultado = virtualXmlHelper.GenerarDocumento();
                }

               if(String.IsNullOrEmpty(resultado))
                {

                    CCOMPROBANTEFISCALLINEAD cf = new CCOMPROBANTEFISCALLINEAD();
                    long cfdiId = 0;

                    bool bGuardado = cf.FACTURAELECTRONICA_GUARDAR(m_Docto.IID, tipoComprobante,m_generarCartaPorte, m_CartaPorteIdccp, ref cfdiId, m_fTrans);


                    return true;
                }
               else
                {
                    return false;
                }
               

            }
            catch (Exception ex)
            {
                if (!m_silentMode)
                {
                    MessageBox.Show("Ocurrio un error al generar el xml para ser timbrado" + ex.Message + ex.StackTrace);
                }
                else
                {
                    m_iComentario = "Ocurrio un error al generar el xml para ser timbrado" + ex.Message + ex.StackTrace;
                }
                return false;
            }
        }


        private bool CancelarDocumento33(string documentoTimbrado, string outputFile, string uuid, 
                                        string logFile, string rfcReceptor, decimal total  )
        {
            int mivar = -198;
            bool retorno = false;
            CDOCTOD doctoD = new CDOCTOD();

            string outputFileIni = outputFile + ".ini";
            bool bEsUltimoEsquema = m_empresa.IFISCALFECHACANCELACION2 <= DateTime.Today;

            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();
            //Now force thousand separator to be empty string
            nfi.NumberGroupSeparator = "";

            try
            {


                string uuidCancelacion = "";

                VirtualXmlHelper virtualXmlHelper = new VirtualXmlHelper(m_empresa.IVERSIONCFDI);
                if(bEsUltimoEsquema)
                {

                    mivar = virtualXmlHelper.CancelarCFDI(m_empresa.IPACUSUARIO,
                                                 m_empresa.IRFC,
                                                m_empresa.ITIMBRADOARCHIVOCERTIFICADO,
                                              m_empresa.ITIMBRADOARCHIVOKEY,
                                              m_empresa.ITIMBRADOPASSWORD,
                                              uuid,
                                              outputFile,
                                              rfcReceptor,
                                              total.ToString("N2", nfi),
                                              logFile,
                                              outputFileIni);

                    

                    if (!m_silentMode)
                    {
                        switch (mivar)
                        {
                            case 1:
                                MessageBox.Show("Se ha solicitado la cancelación al receptor, debe espear 72 horas");
                                break;

                            case -1:
                                MessageBox.Show("Se ha rechazado la cancelación del CFDI, revise el archivo Resultado.INI, para mas información");
                                break;

                            case -2:
                                MessageBox.Show("UUID No encontrado en los registos del SAT, intente mas tarde");
                                break;

                            case -3:
                                MessageBox.Show("Servicio de cancelaciones del SAT temporalmente fuera de servicio, reintente su operación mas tarde");
                                break;
                        }
                    }


                    string text = System.IO.File.ReadAllText(outputFileIni); //"UUID CANCELADO CORRECTAMENTE";
                    if (mivar == 0)
                    {

                        retorno = true;
                        var iniResult = new IniFile(outputFileIni);
                        uuidCancelacion = iniResult.Read("UUID");


                        m_Docto.ITIMBRADOCANCELADO = "S";
                        m_Docto.ITIMBRADOUUIDCANCELACION = uuidCancelacion;
                        m_Docto.ITIMBRADOFECHACANCELACION = DateTime.Now;
                        doctoD.ACTUALIZARCANCELACIONENSAT(m_Docto, null);
                    }
                    else if (text.ToUpper().Contains("UUID PREVIAMENTE CANCELADO"))
                    {
                        retorno = true;
                        m_Docto.ITIMBRADOCANCELADO = "S";
                        m_Docto.ITIMBRADOUUIDCANCELACION = uuidCancelacion;
                        m_Docto.ITIMBRADOFECHACANCELACION = DateTime.Now;
                        doctoD.ACTUALIZARCANCELACIONENSAT(m_Docto, null);
                        Process.Start("notepad.exe", outputFileIni);
                    }
                    else
                    {
                        retorno = false;
                        Process.Start("notepad.exe", outputFileIni);
                    }


                    if(retorno == false && !m_silentMode)
                    {
                        if (MessageBox.Show("Parece que hubo un problema con la facturacion desea consultar el estatus de la factura - esto costara un timbre fiscal-?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ConsultarEstatusFactura(documentoTimbrado, outputFile, uuid,logFile, rfcReceptor, total);
                        }

                    }
                }
                else
                {

                    mivar = virtualXmlHelper.CancelarDocumento(m_empresa.IPACUSUARIO,
                                                 m_empresa.IRFC,
                                                m_empresa.ITIMBRADOARCHIVOCERTIFICADO,
                                              m_empresa.ITIMBRADOARCHIVOKEY,
                                              m_empresa.ITIMBRADOPASSWORD,
                                              uuid,
                                              outputFile);

                    string text = System.IO.File.ReadAllText(outputFile); //"UUID CANCELADO CORRECTAMENTE";
                    if (text.ToUpper().Contains("UUID CANCELADO CORRECTAMENTE"))
                    {
                        retorno = true;
                        string[] splitbuffer = text.Split(new string[] { "en el UUID:" }, StringSplitOptions.RemoveEmptyEntries);
                        if (splitbuffer.Length >= 2)
                        {
                            uuidCancelacion = splitbuffer[1].Replace(";", "").Replace("\n", "").Replace(" ", "");
                        }
                        m_Docto.ITIMBRADOCANCELADO = "S";
                        m_Docto.ITIMBRADOUUIDCANCELACION = uuidCancelacion;
                        m_Docto.ITIMBRADOFECHACANCELACION = DateTime.Now;
                        doctoD.ACTUALIZARCANCELACIONENSAT(m_Docto, null);

                    }
                    else if (text.ToUpper().Contains("UUID PREVIAMENTE CANCELADO"))
                    {
                        retorno = true;
                        m_Docto.ITIMBRADOCANCELADO = "S";
                        m_Docto.ITIMBRADOUUIDCANCELACION = uuidCancelacion;
                        m_Docto.ITIMBRADOFECHACANCELACION = DateTime.Now;
                        doctoD.ACTUALIZARCANCELACIONENSAT(m_Docto, null);
                        Process.Start("notepad.exe", outputFile);
                    }
                    else
                    {
                        retorno = false;
                        Process.Start("notepad.exe", outputFile);
                    }
                }



                
                

            }
            catch (Exception ex)
            {

                if (!m_silentMode)
                {
                    MessageBox.Show("Ocurrio un error al cancelar el documento..." + ex.Message);
                }
                else
                {
                    m_iComentario = "Ocurrio un error al cancelar el documento..." + ex.Message;
                }
                //Process.Start("notepad.exe", documentoTimbrado + ".log");
                retorno = false;
            }

            if (mivar != 0)
            {
                try
                {
                    //CiberPAC_Free(mivar);
                }
                catch
                {

                }
            }

            return retorno;
        }


        private bool CancelarDocumento40(string documentoTimbrado, string outputFile, string uuid,
                                        string logFile, string rfcReceptor, decimal total, string claveMotivo, string folioSustitucion)
        {
            int mivar = 201;
            bool retorno = false;
            CDOCTOD doctoD = new CDOCTOD();

            string outputFileIni = outputFile + ".ini";

            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();
            //Now force thousand separator to be empty string
            nfi.NumberGroupSeparator = "";

            try
            {
                //if(m_empresa.IRFC.Equals("JES900109Q90"))
                //    uuid = "00000000" + uuid.Substring(8);

                //claveMotivo = "02";
                //folioSustitucion = "";

                string uuidCancelacion = "";

                VirtualXmlHelper virtualXmlHelper = new VirtualXmlHelper(m_empresa.IVERSIONCFDI);

                for (int i = 0; i < 2 && mivar == 201; i++)
                {
                    mivar = virtualXmlHelper.CancelaCFDI2022SSL(m_empresa.IPACUSUARIO,
                                                 m_empresa.IRFC,
                                                 claveMotivo,
                                                 uuid,
                                                 folioSustitucion,
                                                 m_empresa.ITIMBRADOARCHIVOCERTIFICADO,
                                                 m_empresa.ITIMBRADOARCHIVOKEY,
                                                 m_empresa.ITIMBRADOPASSWORD,
                                                 "virtual" ,//""demo" ),//server
                                                outputFileIni,
                                                logFile);



                    if (!m_silentMode)
                    {
                        switch (mivar)
                        {
                            case 201:
                                // Se ha solicitado la cancelación via buzon fiscal
                                MessageBox.Show("Se ha solicitado la cancelación al receptor");
                                break;
                            case 202:
                                // Se ha cancelado anteriormente el CFDI
                                MessageBox.Show("CFDI Cancelado anteriormente");
                                break;
                            case 203:
                                // UUID no encontrado o no corresponde al emisor 
                                MessageBox.Show("UUID no encontrado o no corresponde al emisor , revise el archivo Resultado.INI para mas inforamción");
                                break;
                            case 204:
                                // UUID no aplicable para cancelación
                                MessageBox.Show("UUID no aplicable para cancelación");
                                break;
                            case 205:
                                // UUID no existe
                                MessageBox.Show("UUID no existe");
                                break;
                            case 206:
                                // UUID no corresponde a un CFDI del sector primario
                                MessageBox.Show("UUID no corresponde a un CFDI del sector primario");
                                break;
                            case 301:
                                // XML Mal formado
                                MessageBox.Show("XML Mal formado");
                                break;
                            case 302:
                                // Sello mal formado o inválido
                                MessageBox.Show("Sello mal formado o inválido");
                                break;
                            case 303:
                                // Sello no corresponde al emisor
                                MessageBox.Show("Sello no corresponde al emisor");
                                break;
                            case 304:
                                // Certificado revocado o caduco
                                MessageBox.Show("Certificado revocado o caduco");
                                break;
                            case 305:
                                // Certificado inválido
                                MessageBox.Show("Certificado inválido");
                                break;
                            case 310:
                                // Uso de certificado de E.Firma inválido
                                MessageBox.Show("Uso de certificado de E.Firma inválido");
                                break;
                            case 311:
                                // Clave de motivo de cancelación no válida
                                MessageBox.Show("Clave de motivo de cancelación no válida");
                                break;
                            case 312:
                                // UUID no relacionado de acuerdo a la clave de motivo de cancelación
                                MessageBox.Show("UUID no relacionado de acuerdo a la clave de motivo de cancelación");
                                break;
                        }
                    }
                }


                string text = System.IO.File.ReadAllText(outputFileIni); //"UUID CANCELADO CORRECTAMENTE";
                if (mivar == 202 )
                {

                    retorno = true;
                    var iniResult = new IniFile(outputFileIni);
                    uuidCancelacion = iniResult.Read("UUID");


                    m_Docto.ITIMBRADOCANCELADO = "S";
                    m_Docto.ITIMBRADOUUIDCANCELACION = uuidCancelacion;
                    m_Docto.ITIMBRADOFECHACANCELACION = DateTime.Now;
                    doctoD.ACTUALIZARCANCELACIONENSAT(m_Docto, null);
                }
                else
                {
                    retorno = false;
                    Process.Start("notepad.exe", outputFileIni);
                }


                if (retorno == false && !m_silentMode)
                {
                    if (MessageBox.Show("Parece que hubo un problema con la facturacion desea consultar el estatus de la factura - esto costara un timbre fiscal-?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ConsultarEstatusFactura(documentoTimbrado, outputFile, uuid, logFile, rfcReceptor, total);
                    }

                }







            }
            catch (Exception ex)
            {

                if (!m_silentMode)
                {
                    MessageBox.Show("Ocurrio un error al cancelar el documento..." + ex.Message);
                }
                else
                {
                    m_iComentario = "Ocurrio un error al cancelar el documento..." + ex.Message;
                }
                //Process.Start("notepad.exe", documentoTimbrado + ".log");
                retorno = false;
            }

            if (mivar != 0)
            {
                try
                {
                    //CiberPAC_Free(mivar);
                }
                catch
                {

                }
            }

            return retorno;
        }



        private bool ConsultarEstatusFactura(string documentoTimbrado, string outputFile, string uuid,
                                        string logFile, string rfcReceptor, decimal total)
        {


            int mivar = -198;
            bool retorno = true;

            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();

            bool bEsUltimoEsquema = m_empresa.IFISCALFECHACANCELACION2 <= DateTime.Today;
            VirtualXmlHelper virtualXmlHelper = new VirtualXmlHelper(m_empresa.IVERSIONCFDI);


            mivar = virtualXmlHelper.GetStatusCFDI(m_empresa.IPACUSUARIO,
                                 m_empresa.IRFC,
                                 rfcReceptor,
                                 total.ToString("N2", nfi),
                                uuid,
                                 outputFile,
                                 logFile);


            switch (mivar)
            {
                case 2:
                    MessageBox.Show("CFDI Vigente y Cancelable");
                    break;
                case 1:
                    MessageBox.Show("CFDI NO Cancelable");
                    break;
                case 0:
                    MessageBox.Show("CFDI Vigente, cancelación EN PROCESO");
                    break;
                case -1:
                    MessageBox.Show("CFDI Cancelado");
                    break;
                case -2:
                    MessageBox.Show("UUID No encontrado en los registos del SAT, intente mas tarde");
                    break;
                case -3:
                    MessageBox.Show("Servicio de cancelaciones del SAT temporalmente fuera de servicio, reintente su operación mas tarde");
                    break;
            }

       

            return retorno;
        }

        private static void AgregarLeyendaPlazoSiAplica(ref TicketR ticket, long plazoId)
        {
            if (plazoId == 0)
                return;

            CPLAZOD plazoD = new CPLAZOD();
            CPLAZOBE plazoBE = new CPLAZOBE();
            plazoBE.IID = plazoId;
            plazoBE = plazoD.seleccionarPLAZO(plazoBE, null);

            if (plazoBE == null || plazoBE.ICOMISIONISTA == null || !plazoBE.ICOMISIONISTA.Equals("S"))
                return;

            ticket.AddFooterLine("");
            ticket.AddFooterLine(new string('-', Ticket.maxChar));


            ticket.AddFooterLine(plazoBE.ILEYENDA != null ? plazoBE.ILEYENDA : "");


            ticket.AddFooterLine(new string('-', Ticket.maxChar));
            ticket.AddFooterLine("");
        }

        /*private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.rEP_FACTURAELECTRONICA_DET_REFTableAdapter.Fill(this.dSReportIpos2.REP_FACTURAELECTRONICA_DET_REF, new System.Nullable<long>(((long)(System.Convert.ChangeType(dOCTOIDToolStripTextBox.Text, typeof(long))))), dESGLOSEKITSToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }*/


    }
}
