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
    public partial class WFImpresionInventario : IposForm
    {

        CDOCTOPAGOBE m_doctoPago;
        CDOCTOBE m_Docto;
        string m_printer = "";
        public bool m_bTicketImpreso = false;


        public WFImpresionInventario()
        {
            InitializeComponent();
        }

        public WFImpresionInventario(CDOCTOPAGOBE doctoPagoBE, CDOCTOBE docto):this()
        {
            m_doctoPago = doctoPagoBE;
            m_Docto = docto;
        }


        private void WFImpresionInventario_Load(object sender, EventArgs e)
        {
            CBLetraInicial.SelectedText = "A";
            CBLetraFinal.SelectedText = "Z";
            CBOption.SelectedIndex = 2;
        }



        private void ImprimirTicket()
        {


            Ticket ticket = new Ticket();

            ticket.AddHeaderLine("Inventario general");
            ticket.AddHeaderLine("Fecha           : " + DateTime.Now.ToShortDateString());
            ticket.AddHeaderLine("Hora            : " + DateTime.Now.ToShortTimeString());



            try
            {

                

                //this.gET_TICKET_ABONOTableAdapter.Fill(this.dataSet1.GET_TICKET_ABONO, m_doctoPago.IID);

                if(this.dSTicketInventario.InventarioTicket.Rows.Count <= 0)
                    return;

                foreach(DataRow dr in this.dSTicketInventario.InventarioTicket.Rows)
                {
                    decimal dExistencia = (decimal)dr["EXISTENCIA"];
                    ticket.AddHeaderLine(new string(' ', Ticket.maxChar));
                    ticket.AddHeaderLine(Ticket.FormatPrintField(dr["CLAVE"].ToString(), 18, 1) + " " + Ticket.FormatPrintField(dExistencia.ToString("N2"), 19, 0));
                    ticket.AddHeaderLine(Ticket.FormatPrintField(dr["DESCRIPCION2"].ToString(), Ticket.maxChar - 1, 1));
                    ticket.AddHeaderLine(Ticket.FormatPrintField(dr["DESCRIPCION1"].ToString(), Ticket.maxChar - 1, 1));
                }

                

                ticket.AddFooterLine("");

                if (m_printer != "")
                    ticket.PrintTicketDirect(this.m_printer);

                m_bTicketImpreso = true;

                MessageBox.Show("El inventario se imprimio");
                this.Close();
            }
            catch( Exception ex)
            {
                MessageBox.Show("Ocurrio un error , no se pudo imprimer el ticket " + ex.Message + " " + ex.StackTrace);
                this.Close();
            }


        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            pnlImprimiendo.Visible = true;
            pnlParametros.Visible = false;

            // TODO: This line of code loads data into the 'dSTicketInventario.InventarioTicket' table. You can move, or remove it, as needed.
            this.inventarioTicketTableAdapter.Fill(
                this.dSTicketInventario.InventarioTicket,
                CBLetraInicial.Text.ToUpper(), 
                CBLetraFinal.Text.ToUpper(), 
                CBOption.SelectedIndex < 0 ? 1 : CBOption.SelectedIndex + 1,  
                CBLetraInicial.Text.ToLower(), 
                CBLetraFinal.Text.ToLower());

            m_printer = Ticket.GetReceiptPrinter();
            ImprimirTicket();
        }





    }
}
