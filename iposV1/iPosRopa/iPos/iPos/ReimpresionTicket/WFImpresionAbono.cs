using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPosData;
using iPosBusinessEntity;
using System.IO;
using System.Collections;

namespace iPos
{
    public partial class WFImpresionAbono : IposForm
    {

        CDOCTOPAGOBE m_doctoPago;
        CDOCTOBE m_Docto;
        string m_printer = "";
        public bool m_bTicketImpreso = false;


        public WFImpresionAbono()
        {
            InitializeComponent();
        }

        public WFImpresionAbono(CDOCTOPAGOBE doctoPagoBE, CDOCTOBE docto):this()
        {
            m_doctoPago = doctoPagoBE;
            m_Docto = docto;
        }


        private void WFImpresionAbono_Load(object sender, EventArgs e)
        {

            m_printer = Ticket.GetReceiptPrinter();
            ImprimirTicket();
        }



        private void ImprimirTicket()
        {


            //string line;
            string bufferLine = "";
            //string bufferLine2 = "";
            Ticket ticket = new Ticket();
            ArrayList alEntradas = new ArrayList();
            alEntradas.Add(DBValues._DOCTO_TIPO_COMPRA); alEntradas.Add(DBValues._DOCTO_TIPO_COMPRA_DEVO_CANCELACION);  
            alEntradas.Add(DBValues._DOCTO_TIPO_DEVOLUCION); alEntradas.Add(DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO); 
            alEntradas.Add(DBValues._DOCTO_TIPO_CANCELACIONVENTAAPARTADO);

            switch(m_Docto.ITIPODOCTOID)
            {
                case DBValues._DOCTO_TIPO_COMPRA:
                    ticket.AddHeaderLine("ABONO COMPRA");
                    break;
                case DBValues._DOCTO_TIPO_VENTA:
                    ticket.AddHeaderLine("ABONO VENTA");
                    break;
                case DBValues._DOCTO_TIPO_VENTAAPARTADO:
                    ticket.AddHeaderLine("ABONO VENTA DE APARTADO");
                    break;
                default:
                    ticket.AddHeaderLine("ABONO");
                    break;
            }

            try
            {

                

                this.gET_TICKET_ABONOTableAdapter.Fill(this.dataSet1.GET_TICKET_ABONO, m_doctoPago.IID);

                if(this.dataSet1.GET_TICKET_ABONO.Rows.Count <= 0)
                    return;

                DataRow dr = this.dataSet1.GET_TICKET_ABONO.Rows[0];


                // DATOS TIENDA
                //ticket.AddHeaderLine("");
                ticket.AddHeaderLine(new string('-', Ticket.maxChar));
                AddHeader(ref  ticket);
                 AddDatosTienda(ref  ticket,dr);
                 ticket.AddHeaderLine(new string('-', Ticket.maxChar));


                //CLIENTE
                 switch (m_Docto.ITIPODOCTOID)
                 {
                     case DBValues._DOCTO_TIPO_COMPRA:
                         ticket.AddHeaderLine("PROVEEDOR");
                         break;
                     case DBValues._DOCTO_TIPO_VENTA:
                         ticket.AddHeaderLine("CLIENTE");
                         break;
                     case DBValues._DOCTO_TIPO_VENTAAPARTADO:
                         ticket.AddHeaderLine("CLIENTE DE APARTADO");
                         break;
                     default:
                         ticket.AddHeaderLine("");
                         break;
                 }
                AddDatosCliente(ref  ticket, dr);

                ticket.AddHeaderLine(new string('-', Ticket.maxChar));


                ticket.AddHeaderLine("CAJERO : " + dr["CAJERO"].ToString());

                ticket.AddHeaderLine(new string('-', Ticket.maxChar));


                bufferLine = dr["NUMEROPAGO"].ToString();
                ticket.AddHeaderLine("#PAGO : " + bufferLine.Substring(0, Math.Min(12, bufferLine.Length)).PadRight(12) + " Fecha: " + ((DateTime)dr["FECHAPAGO"]).ToString("dd/MM/yyyy"));
                ticket.AddHeaderLine("FORMA DE PAGO : " + dr["FORMADEPAGO"].ToString());

                switch (m_Docto.ITIPODOCTOID)
                {
                    case DBValues._DOCTO_TIPO_COMPRA:
                        ticket.AddHeaderLine("FOLIO DE COMPRA : " + dr["FOLIODOCTO"].ToString());
                        break;
                    case DBValues._DOCTO_TIPO_VENTA:
                        ticket.AddHeaderLine("FOLIO DE VENTA : " + dr["FOLIODOCTO"].ToString());
                        break;
                    case DBValues._DOCTO_TIPO_VENTAAPARTADO:
                        ticket.AddHeaderLine("FOLIO VENTA DE APARTADO : " + dr["FOLIODOCTO"].ToString());
                        break;
                    default:
                        ticket.AddHeaderLine("");
                        break;
                }

                ticket.AddHeaderLine(new string('-', Ticket.maxChar));


                decimal abonoAplicado = (decimal)dr["IMPORTEPAGO"];
                ticket.AddTotal("Abono    : ", ((decimal)dr["IMPORTEPAGO"]).ToString("N2"));

                if(dr["COMISION"] != DBNull.Value && dr["IMPORTERECIBIDO"] != DBNull.Value)
                {
                    decimal comision = (decimal)dr["COMISION"];
                    if(comision > 0.0m)
                    {

                        ticket.AddTotal("Comision  : ", comision.ToString("N2") );
                        ticket.AddTotal("Total pago: ", (abonoAplicado + comision).ToString("N2"));
                    }

                }

                ticket.AddTotal("Saldo    : ", ((decimal)dr["SALDODOCTO"]).ToString("N2"));
            

                

                ticket.AddFooterLine("");

                if (m_printer != "")
                    ticket.PrintTicketDirect(this.m_printer);

                m_bTicketImpreso = true;

                this.Close();
            }
            catch( Exception ex)
            {
                MessageBox.Show("Ocurrio un error , no se pudo imprimer el ticket " + ex.Message + " " + ex.StackTrace);
                this.Close();
            }


        }



        private void AddHeader(ref Ticket ticket)
        {
            string[] splitSeparator = new string[] { "\r\n" };
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



        private static void AddDatosTienda(ref Ticket ticket, DataRow dr)
        {

            ticket.AddHeaderLine("RFC: " + dr["RFC"].ToString());

            string bufferLine = dr["DOMICILIO"].ToString().Trim() + " " + dr["NUMEROEXTERIOR"].ToString().Trim() + " " + dr["NUMEROINTERIOR"].ToString().Trim();

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

            bufferLine = dr["CODIGOPOSTAL"].ToString();
            
            if (bufferLine.TrimEnd().Length >= 0)
            {
                if (bufferLine.TrimEnd().Length > 32)
                {
                    ticket.AddHeaderLine("CP.  : " + bufferLine.TrimEnd().Substring(0, 32));
                }
                else
                    ticket.AddHeaderLine("CP.  : " + bufferLine.TrimEnd());
            }

            
            bufferLine = dr["COLONIA"].ToString();
            if (bufferLine.TrimEnd().Length >= 0)
            {
                if (bufferLine.TrimEnd().Length > 32)
                {
                    ticket.AddHeaderLine("Col. : " + bufferLine.TrimEnd().Substring(0, 32));
                }
                else
                    ticket.AddHeaderLine("Col. : " + bufferLine.TrimEnd());
            }

            
            bufferLine = dr["TELEFONO"].ToString();
            if (bufferLine.TrimEnd().Length >= 0)
            {
                if (bufferLine.TrimEnd().Length > 32)
                {
                    ticket.AddHeaderLine("Tel. : " + bufferLine.TrimEnd().Substring(0, 32));
                }
                else
                    ticket.AddHeaderLine("Tel. : " + bufferLine.TrimEnd());
            }

            

        }




        private static void AddDatosCliente(ref Ticket ticket, DataRow dr)
        {

            string bufferLine = "";



            if (dr["PERSONANOMBRES"].ToString().Trim() != "")
                bufferLine = dr["PERSONANOMBRES"].ToString().Trim();

            if (dr["PERSONAAPELLIDOS"].ToString().Trim() != "")
                bufferLine += " " + dr["PERSONAAPELLIDOS"].ToString().Trim();


            if (bufferLine.TrimEnd().Length > 31)
            {
                ticket.AddHeaderLine("Nombre: " + bufferLine.TrimEnd().Substring(0, 31));
                if (bufferLine.TrimEnd().Length > 62)
                    ticket.AddHeaderLine("       " + bufferLine.TrimEnd().Substring(31, 31));
                else
                    ticket.AddHeaderLine("       " + bufferLine.TrimEnd().Substring(31));
            }
            else
                ticket.AddHeaderLine("Nombre: " + bufferLine.TrimEnd());


            bufferLine = dr["PERSONADOMICILIO"].ToString().Trim() + " " + dr["PERSONANUMEROEXTERIOR"].ToString().Trim() + " " + dr["PERSONANUMEROINTERIOR"].ToString().Trim();

            if (bufferLine.TrimEnd().Length > 0)
            {
                if (bufferLine.TrimEnd().Length > 32)
                {
                    ticket.AddHeaderLine("Calle: " + bufferLine.TrimEnd().Substring(0, 32));
                    if (bufferLine.TrimEnd().Length > 64)
                        ticket.AddHeaderLine("       " + bufferLine.TrimEnd().Substring(32, 32));
                    else
                        ticket.AddHeaderLine("       " + bufferLine.TrimEnd().Substring(32));
                }
                else
                    ticket.AddHeaderLine("Calle: " + bufferLine.TrimEnd());
            }


            bufferLine = dr["PERSONACODIGOPOSTAL"].ToString();

            if (bufferLine.TrimEnd().Length > 0)
            {
                if (bufferLine.TrimEnd().Length > 32)
                {
                    ticket.AddHeaderLine("CP.  : " + bufferLine.TrimEnd().Substring(0, 32));
                }
                else
                    ticket.AddHeaderLine("CP.  : " + bufferLine.TrimEnd());
            }


            bufferLine = dr["PERSONACOLONIA"].ToString();
            if (bufferLine.TrimEnd().Length > 0)
            {
                if (bufferLine.TrimEnd().Length > 32)
                {
                    ticket.AddHeaderLine("Col. : " + bufferLine.TrimEnd().Substring(0, 32));
                }
                else
                    ticket.AddHeaderLine("Col. : " + bufferLine.TrimEnd());
            }


            bufferLine = dr["PERSONATELEFONO1"].ToString();
            if (bufferLine.TrimEnd().Length > 0)
            {
                if (bufferLine.TrimEnd().Length > 32)
                {
                    ticket.AddHeaderLine("Tel. : " + bufferLine.TrimEnd().Substring(0, 32));
                }
                else
                    ticket.AddHeaderLine("Tel. : " + bufferLine.TrimEnd());
            }

        }




    }
}
