using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections;
using System.Runtime.InteropServices;
using System.IO;
using iPosData;
using iPosBusinessEntity;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using System.Collections.Generic;

namespace iPos
{
    public partial class WFGastoImprimir : Form
    {
        long m_doctoId = 0;
        bool m_bForceTicket = false;
        public WFGastoImprimir()
        {
            InitializeComponent();
        }


        public WFGastoImprimir(long doctoId): this()
        {
            m_doctoId = doctoId;
            
        }

        private void LlenarDetalles(long doctoId)
        {
            try
            {
                this.rECIBOGASTODETALLETableAdapter.Fill(this.dSContabilidad.RECIBOGASTODETALLE, (int)doctoId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void WFGastoImprimir_Load(object sender, EventArgs e)
        {
            Imprimir(this.m_bForceTicket, m_doctoId);
            this.Close();
        }


        private static CSUCURSALBE DatosSucursal(long lSucursalTid)
        {

            CSUCURSALD sucursalD = new CSUCURSALD();
            CSUCURSALBE sucursalBE = new CSUCURSALBE();

            sucursalBE.IID = lSucursalTid;
            sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);

            return sucursalBE;

        }

        private static CPERSONABE DatosPersona(long lPersonaId)
        {

            CPERSONAD personaD = new CPERSONAD();
            CPERSONABE personaBE = new CPERSONABE();

            personaBE.IID = lPersonaId;
            personaBE = personaD.seleccionarPERSONA(personaBE, null);

            return personaBE;

        }


        private static void AddDatosTienda(ref Ticket ticket, CTICKET_HEADERBE headerBE)
        {


            ticket.AddHeaderLine("RFC: " + headerBE.IRFC);


           

            string bufferLine = ((!(bool)headerBE.isnull["IDOMICICIO"]) ? headerBE.IDOMICICIO.TrimEnd() : "") +
                           " " + ((!(bool)headerBE.isnull["INUMEROEXTERIOR"]) ? headerBE.INUMEROEXTERIOR.TrimEnd() : "") +
                           " " + ((!(bool)headerBE.isnull["INUMEROINTERIOR"]) ? headerBE.INUMEROINTERIOR.TrimEnd() : "");


            if (bufferLine.TrimEnd().Length >= 0)
            {
                if (bufferLine.TrimEnd().Length > 32)
                {
                    ticket.AddHeaderLine("Calle: " + bufferLine.TrimEnd().Substring(0, 32));
                    if (bufferLine.TrimEnd().Length > 64)
                        ticket.AddHeaderLine("       " + bufferLine.TrimEnd().Substring(32, 64));
                    else
                        ticket.AddHeaderLine("       " + bufferLine.TrimEnd().Substring(32));
                }
                else
                    ticket.AddHeaderLine("Calle: " + bufferLine.TrimEnd());
            }



            if (!(bool)headerBE.isnull["ICODIGOPOSTAL"])
            {
                if (headerBE.ICODIGOPOSTAL.TrimEnd().Length > 32)
                {
                    ticket.AddHeaderLine("CP.  : " + headerBE.ICODIGOPOSTAL.TrimEnd().Substring(0, 32));
                }
                else
                    ticket.AddHeaderLine("CP.  : " + headerBE.ICODIGOPOSTAL.TrimEnd());
            }


            if (!(bool)headerBE.isnull["ICOLONIA"])
            {
                if (headerBE.ICOLONIA.TrimEnd().Length > 32)
                {
                    ticket.AddHeaderLine("Col. : " + headerBE.ICOLONIA.TrimEnd().Substring(0, 32));
                }
                else
                {
                    ticket.AddHeaderLine("Col. : " + headerBE.ICOLONIA.TrimEnd());
                }
            }


            if (!(bool)headerBE.isnull["ITELEFONO"])
            {
                if (headerBE.ITELEFONO.TrimEnd().Length > 32)
                {
                    ticket.AddHeaderLine("Tel. : " + headerBE.ITELEFONO.TrimEnd().Substring(0, 32));
                }
                else
                {
                    ticket.AddHeaderLine("Tel. : " + headerBE.ITELEFONO.TrimEnd());
                }
            }
            else
            {
                ticket.AddHeaderLine("Tel. : ");
            }
        }



        private string Imprimir(bool bForceTicket, long doctoId)
        {

            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoBE = new CDOCTOBE();
            doctoBE.IID = doctoId;
            doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);
            if (doctoBE == null)
                return "Error al obtener los datos del documento";



            if (!bForceTicket && (doctoBE.ISALDO == 0 && CurrentUserID.CurrentUser.ITICKETLARGO.Equals("S") ))
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("pdoctoid", doctoId);
                dictionary.Add("usaDatosDeEntregaCuandoExista", "N");
                dictionary.Add("desglosekits", "N");
                string strReporte = "RECIBOGASTOLARGO.frx";


                iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
                rp.ShowDialog();
                rp.Dispose();
                GC.SuppressFinalize(rp);
                return "";

            }


            string bufferLine = "";

            string tipoImpresionDetalle = ((int)tipoImpresionItem.i_unalinea).ToString("N0");

            try
            {

                CTICKET_FOOTERD footerD = new CTICKET_FOOTERD();
                CTICKET_HEADERD headerD = new CTICKET_HEADERD();
                CTICKET_FOOTERBE footerBE = new CTICKET_FOOTERBE();
                CTICKET_HEADERBE headerBE = new CTICKET_HEADERBE();
                CSUCURSALBE sucursalBE = new CSUCURSALBE();




                string strReturn = "";


                string[] splitSeparator = new string[] { "\r\n" };

                int iXLetraRenglon = 0;
                string cantidadConLetra;

                footerBE.IDOCTOID = doctoId;
                headerBE.IDOCTOID = doctoId;

                headerBE = headerD.seleccionarTICKET_HEADER(headerBE, null);
                footerBE = footerD.seleccionarTICKET_FOOTER(footerBE, false, null);
                LlenarDetalles(m_doctoId);

                Ticket ticket = new Ticket();

                // MessageBox.Show("entra 1");

                //si es una cancelacion
                if (headerBE.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_CANCELADA)
                    ticket.AddHeaderLine("CANCELACION DEL TICKET : " + headerBE.ITICKET);


                ticket.AddHeaderLine("RECIBO DE GASTOS");


                ticket.AddHeaderLine("FOLIO NO.: " + headerBE.ITICKET);
                ticket.AddHeaderLine("LUGAR Y FECHA DE EXPEDICION: ");

                try
                {
                    ticket.AddHeaderLine(headerBE.ICIUDAD.Trim() + " , " + headerBE.IESTADO.Trim());
                }
                catch
                {
                }

                if(CurrentUserID.CurrentParameters.IMANEJAALMACEN == "S" && headerBE.IALMACENID > 0 && headerBE.IALMACENNOMBRE != null)
                {
                    ticket.AddHeaderLine("ALMACEN : " + headerBE.IALMACENNOMBRE);
                }


                ticket.AddHeaderLine("Fecha: " + DateTime.Now.ToShortDateString() + " Hora: " + DateTime.Now.ToShortTimeString());



                if (headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_DEVOLUCION
                    || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA_DEVO || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO
                    || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAAPARTADO)
                {
                    //custom header
                    ticket.AddHeaderLine(new string('-', Ticket.maxChar));

                    if (!(bool)CurrentUserID.CurrentParameters.isnull["IHEADER"])
                    {
                        if (CurrentUserID.CurrentParameters.IHEADER != "")
                        {
                            string[] splitHeader = CurrentUserID.CurrentParameters.IHEADER.Split(splitSeparator, StringSplitOptions.RemoveEmptyEntries);
                            foreach (string strHdr in splitHeader)
                            {
                                ticket.AddHeaderLine(strHdr);

                            }
                        }
                    }
                }

                AddDatosTienda(ref ticket, headerBE);




                if (headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_DEVOLUCION
                    || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO || headerBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAAPARTADO)
                {
                    ticket.AddHeaderLine(new string('-', Ticket.maxChar));
                    bufferLine = "";
                    ticket.AddHeaderLine("Numero: " + bufferLine.Substring(0, Math.Min(12, bufferLine.Length)).PadRight(12) + " Fecha: " + headerBE.IFECHA.ToString("dd/MM/yyyy"));
                }


                ticket.AddHeaderLine(new string('-', Ticket.maxChar));



               


                ticket.AddHeaderLine(new string('-', Ticket.maxChar));
                bufferLine = (headerBE.IVENDEDOR == null) ? "" : headerBE.IVENDEDOR;
                ticket.AddHeaderLine("Cajero: " + bufferLine.Substring(0, Math.Min(12, bufferLine.Length)).PadRight(12) + " FOLIO NO.: " + headerBE.ITICKET);

                

               
                ticket.AddHeaderLine(new string('=', Ticket.maxChar));

                ticket.AddHeaderLine("GASTO               ");
                ticket.AddHeaderLine("#CUENTA                         IMPORTE");

                ticket.AddHeaderLine(new string('-', Ticket.maxChar));



                foreach (iPos.Contabilidad.DSContabilidad.RECIBOGASTODETALLERow detailItem in this.dSContabilidad.RECIBOGASTODETALLE)
                {

                    ticket.AddHeaderLine(detailItem.NOMBREGASTO);

                    
                    string line = "";
                    line += Ticket.FormatPrintField(detailItem.IsNUMUCUENTANull() ? "" : detailItem.NUMUCUENTA, 20, 1) + " ";
                    line += Ticket.FormatPrintField("", 2, 0) + " ";
                    line += Ticket.FormatPrintField(detailItem.TOTAL.ToString("N2"), 15, 0);
                    ticket.AddHeaderLine(line);

                   
                }







                decimal fFooterSubTotal, fFooterTotal;
                fFooterSubTotal = footerBE.ISUBTOTAL;
                fFooterTotal = footerBE.ITOTAL;

                

                ticket.AddTotal("Total:", fFooterTotal.ToString("N2"));

                




                ticket.AddTotal("", "");
                ticket.AddTotal("", "");

                ticket.AddFooterLine(new string('-', Ticket.maxChar));

                cantidadConLetra = Numalet.ToCardinal(fFooterTotal).ToUpper();
                ticket.AddFooterLine(cantidadConLetra.Substring((Ticket.maxChar * iXLetraRenglon)));


                //ticket.AddFooterLine(footerBE.ICAJA + " Turno: " + footerBE.ITURNO);
                if (doctoBE.IREFERENCIAS != null && doctoBE.IREFERENCIAS.Trim().Length > 0)
                {
                    ticket.AddFooterLine(new string('-', Ticket.maxChar));
                    ticket.AddFooterLine("Observaciones:");
                    ticket.AddFooterLine(doctoBE.IREFERENCIAS);
                    ticket.AddFooterLine(new string('-', Ticket.maxChar));
                }




                ticket.PrintTicketDirect(CurrentUserID.currentPrinter);//"IposPrinter3");

                return strReturn;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message + ex.StackTrace);
                return "";
            }


        }
    }
}
