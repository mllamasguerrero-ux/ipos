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

namespace iPos
{
    public partial class CortesDelDiaConAjuste : IposForm
    {
        string m_printer = "";
        decimal m_dSubtotalConIva = 0, m_dSubtotalSinIva = 0, m_dMontoIva = 0;

        

        public CortesDelDiaConAjuste()
        {
            InitializeComponent();
            try
            {
                m_printer = Ticket.GetReceiptPrinter();
            }
            catch {  }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ImprimirTicket(DTFecha.Value);

            decimal  ajusteIntercambioIva = 0, ajusteTasaIva = 0;

            ajusteIntercambioIva = decimal.Parse(PORC_A_IVATextBox.Text);
            ajusteTasaIva = decimal.Parse(TASAIVATextBox.Text);

            WFImpresionCorte ic_ = new WFImpresionCorte(DTFecha.Value, true, ImpresionCorteOption.SumarizadoDelDiaXCajero, ajusteIntercambioIva, ajusteTasaIva);
            ic_.ShowDialog();
            bool bTicketImpreso = ic_.m_bTicketImpreso;
            ic_.Dispose();
            GC.SuppressFinalize(ic_);

            if (bTicketImpreso)
                MessageBox.Show("El ticket se imprimio");
        }


        public void ImprimirTicket(DateTime fecha)
        {

            int iNumCortes = 0;
            Ticket ticket = new Ticket();
            decimal dVentasNetas;

            this.corteTicketFechaTableAdapter.Fill(this.dataSet1.CorteTicketFecha, fecha);
            iNumCortes = this.dataSet1.CorteTicketFecha.Rows.Count;

            if (iNumCortes < 1)
            {
                MessageBox.Show("No hay cortes a mostrar");
                return;
            }
            
            ticket.AddHeaderLine("Sucursal        : " + this.dataSet1.CorteTicketFecha.Rows[0]["SUCURSAL"].ToString());
            //ticket.AddHeaderLine("Caja            : " + this.dataSet1.CorteTicketFecha.Rows[0]["CAJA"].ToString());
            ticket.AddHeaderLine("Fecha           : " + DateTime.Now.ToShortDateString());
            ticket.AddHeaderLine("Hora            : " + DateTime.Now.ToShortTimeString());
            ticket.AddHeaderLine("Fecha de corte  : " + fecha.ToShortDateString());

            ticket.AddHeaderLine("");



            for (int iX = 0; iX < iNumCortes; iX++)
            {



                //string line = "";

                int corteId = int.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["FOLIO"].ToString());
                this.corteTrasladosTableAdapter.Fill(this.dSPuntoVenta.CorteTraslados, corteId);






                dVentasNetas = decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["INGRESO"].ToString()) - decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["DEVOLUCION"].ToString());
                ticket.AddFooterLine(new string('*', Ticket.maxChar));
                ticket.AddFooterLine(new string('-', Ticket.maxChar));
                ticket.AddFooterLine("Numero De Corte : " + this.dataSet1.CorteTicketFecha.Rows[iX]["FOLIO"].ToString());
                //ticket.AddFooterLine("Turno           : " + this.dataSet1.CorteTicketFecha.Rows[iX]["TURNO"].ToString());
                ticket.AddFooterLine("Cajero          : " + this.dataSet1.CorteTicketFecha.Rows[iX]["CAJERO"].ToString());
                ticket.AddFooterLine(new string('-', Ticket.maxChar));


               /*
                ticket.AddFooterLine(formatTotalLine("Ventas          : ", decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["INGRESO"].ToString()).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Devoluciones    : ", decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["DEVOLUCION"].ToString()).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Ventas Neta     : ", dVentasNetas.ToString("N2")));
                ticket.AddFooterLine(formatTotalLine(new string('-', Ticket.maxChar - 5), ""));
                ticket.AddFooterLine(formatTotalLine("Saldo Inicial   : ", decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["SALDOINICIAL"].ToString()).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Efectivo        : ", decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["INGRESO"].ToString()).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Tarjeta         : ", "0.00"));
                ticket.AddFooterLine(formatTotalLine("Aportacion      : ", decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["APORTACION"].ToString()).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Retiro          : ", decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["RETIRO"].ToString()).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Saldo Final     : ", decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["SALDOFINAL"].ToString()).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Saldo Real      : ", decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["SALDOREAL"].ToString()).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Diferencia      : ", (decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["SALDOREAL"].ToString()) - decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["SALDOFINAL"].ToString())).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine(new string('-', Ticket.maxChar - 5), ""));
                ticket.AddFooterLine(formatTotalLine("No. Tickets          : ", this.dataSet1.CorteTicketFecha.Rows[iX]["NUM_TICKETS"].ToString()));
                ticket.AddFooterLine(formatTotalLine("No. Devoluciones     : ", this.dataSet1.CorteTicketFecha.Rows[iX]["NUM_DEVOLUCIONES"].ToString()));

                */

                ticket.AddFooterLine(formatTotalLine("Ingresos Subtotal: ", decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["INGRESOSUBTOTAL"].ToString()).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Ingresos IVA     : ", decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["INGRESOPORIVA"].ToString()).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Ingresos Venta   : ", decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["INGRESO"].ToString()).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Devoluciones     : ", decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["DEVOLUCION"].ToString()).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Ventas Neta      : ", dVentasNetas.ToString("N2")));
                ticket.AddFooterLine(formatTotalLine(new string('-', Ticket.maxChar - 5), ""));
                ticket.AddFooterLine(formatTotalLine("Saldo Inicial    : ", decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["SALDOINICIAL"].ToString()).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Efectivo         : ", decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["INGRESOEFECTIVO"].ToString()).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Tarjeta          : ", decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["INGRESOTARJETA"].ToString()).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Credito          : ", decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["INGRESOCREDITO"].ToString()).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Cheque           : ", decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["INGRESOCHEQUE"].ToString()).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Cambio cheque    : ", (decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["CAMBIOCHEQUE"].ToString()) * -1).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Vale             : ", decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["INGRESOVALE"].ToString()).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Aportacion       : ", decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["APORTACION"].ToString()).ToString("N2")));



                ticket.AddFooterLine(formatTotalLine("Retiro           : ", (decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["RETIRO"].ToString()) * -1).ToString("N2")));

                if (CurrentUserID.CurrentParameters.IHABFONDODINAMICO != null && CurrentUserID.CurrentParameters.IHABFONDODINAMICO.Equals("S"))
                    ticket.AddFooterLine(formatTotalLine("Fondo dinamico   : ", (decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["FONDODINAMICODIFERENCIA"].ToString())).ToString("N2")));

                ticket.AddFooterLine(formatTotalLine("Egreso           : ", (decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["EGRESO"].ToString()) * -1).ToString("N2")));


                ticket.AddFooterLine(formatTotalLine("Saldo Final      : ", decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["SALDOFINAL"].ToString()).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Saldo Real       : ", decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["SALDOREAL"].ToString()).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine("Diferencia       : ", (decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["SALDOREAL"].ToString()) - decimal.Parse(this.dataSet1.CorteTicketFecha.Rows[iX]["SALDOFINAL"].ToString())).ToString("N2")));
                ticket.AddFooterLine(formatTotalLine(new string('-', Ticket.maxChar - 5), ""));
                ticket.AddFooterLine(formatTotalLine("No. Tickets          : ", this.dataSet1.CorteTicketFecha.Rows[iX]["NUM_TICKETS"].ToString()));
                ticket.AddFooterLine(formatTotalLine("No. Devoluciones     : ", this.dataSet1.CorteTicketFecha.Rows[iX]["NUM_DEVOLUCIONES"].ToString()));

                
                ticket.AddFooterLine(new string('*', Ticket.maxChar));




                ticket.AddFooterLine("");
                ticket.AddFooterLine("");
            }


            ticket.AddFooterLine("");

            if (m_printer != "")
            {
                ticket.PrintTicketDirect(this.m_printer);
                MessageBox.Show("El ticket se imprimio");
            }


        }

        private string formatTotalLine(string name, string total)
        {
            
            string line = Ticket.FormatPrintField(name, 28, 0);
            line += Ticket.FormatPrintField(total, 11, 0);
            line = AlignRightText(line.Length) + line;
            return line;
        }

        private string AlignRightText(int lenght)
        {
            string espacios = "";
            int spaces = 39 - lenght;
            for (int x = 0; x < spaces; x++)
                espacios += " ";
            return espacios;
        }

        private void CortesDelDia_Load(object sender, EventArgs e)
        {

            m_printer = Ticket.GetReceiptPrinter();


            GetDatos();
            LlenarDatos();
            LlenarDatosCalculados();
        }

        /*private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                object fecha = new object();
                this.corteTicketFechaTableAdapter.Fill(this.dataSet1.CorteTicketFecha, fecha);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }*/

        private void button2_Click(object sender, EventArgs e)
        {

        }


        private void GetDatos()
        {
            try
            {
                this.corteTicketSumarizadoTableAdapter.Fill(this.dSReimpresionTicket.CorteTicketSumarizado,this.DTFecha.Value);

                if (this.dSReimpresionTicket.CorteTicketSumarizado.Rows.Count > 0)
                {
                    ReimpresionTicket.DSReimpresionTicket.CorteTicketSumarizadoRow dr = (ReimpresionTicket.DSReimpresionTicket.CorteTicketSumarizadoRow)this.dSReimpresionTicket.CorteTicketSumarizado.Rows[0];
                    
                    m_dSubtotalConIva = dr.SUBTOTALCONIVA;
                    m_dSubtotalSinIva = dr.SUBTOTALSINIVA; 
                    m_dMontoIva = dr.MONTOIVA;


                }

                CAJUSTESIVABE ajusteBE = new CAJUSTESIVABE();
                CAJUSTESIVAD ajusteD = new CAJUSTESIVAD();
                ajusteBE.IFECHA = this.DTFecha.Value;
                ajusteBE = ajusteD.seleccionarAJUSTESIVAxFecha(ajusteBE, null);

                if (ajusteBE != null)
                {
                    if (!(bool)ajusteBE.isnull["IPORC_A_IVA"])
                    {
                        this.PORC_A_IVATextBox.Text = ajusteBE.IPORC_A_IVA.ToString();
                    }
                    if (!(bool)ajusteBE.isnull["ITASAIVA"])
                    {
                        this.TASAIVATextBox.Text = ajusteBE.ITASAIVA.ToString();
                    }

                }
                else
                {
                    this.PORC_A_IVATextBox.Text = "0";
                    this.TASAIVATextBox.Text = "0";
                }

               

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }


        private void LlenarDatos()
        {

            subTotalConIvaTextBox.Text = m_dSubtotalConIva.ToString();
            subTotalSinIvaTextBox.Text = m_dSubtotalSinIva.ToString();
            subtotalesTextBox.Text = (m_dSubtotalConIva + m_dSubtotalSinIva).ToString();
            this.impuestoConIvaTextBox.Text = m_dMontoIva.ToString();
            this.totalConIvaTextBox.Text = (m_dMontoIva + m_dSubtotalConIva).ToString();
            this.totalSinIvaTextBox.Text = m_dSubtotalSinIva.ToString();
            this.impuestoTotalesTextBox.Text = m_dMontoIva.ToString();
            this.totalTextBox.Text = (m_dMontoIva + m_dSubtotalConIva + m_dSubtotalSinIva).ToString();

        }

        private void LlenarDatosCalculados()
        {


            decimal m_dSubtotalConIvaAjustado = 0, m_dSubtotalSinIvaAjustado = 0, m_dMontoIvaAjustado = 0;
            decimal montomenossiniva = 0, montoadicionalconiva = 0, ajusteIntercambioIva = 0, ajusteTasaIva = 0;

            ajusteIntercambioIva = decimal.Parse(PORC_A_IVATextBox.Text);
            ajusteTasaIva = decimal.Parse(TASAIVATextBox.Text);

            montomenossiniva = m_dSubtotalSinIva * (ajusteIntercambioIva / 100);
            montoadicionalconiva = montomenossiniva / (1 + (ajusteTasaIva / 100));
            m_dSubtotalConIvaAjustado = m_dSubtotalConIva + montoadicionalconiva;
            m_dSubtotalSinIvaAjustado = m_dSubtotalSinIva - montomenossiniva;
            m_dMontoIvaAjustado = m_dMontoIva + (montomenossiniva - montoadicionalconiva);



            subTotalConIvaAjustadoTextBox.Text = m_dSubtotalConIvaAjustado.ToString();
            subTotalSinIvaAjustadoTextBox.Text = m_dSubtotalSinIvaAjustado.ToString();
            subtotalesAjustadoTextBox.Text = (m_dSubtotalConIvaAjustado + m_dSubtotalSinIvaAjustado).ToString();
            this.impuestoConIvaAjustadoTextBox.Text = m_dMontoIvaAjustado.ToString();
            this.totalConIvaAjustadoTextBox.Text = (m_dMontoIvaAjustado + m_dSubtotalConIvaAjustado).ToString();
            this.totalSinIvaAjustadoTextBox.Text = m_dSubtotalSinIvaAjustado.ToString();
            this.impuestoTotalesAjustadoTextBox.Text = m_dMontoIvaAjustado.ToString();
            this.totalAjustadoTextBox.Text = (m_dMontoIvaAjustado + m_dSubtotalConIvaAjustado + m_dSubtotalSinIvaAjustado).ToString();
        }
        

        private void DTFecha_ValueChanged(object sender, EventArgs e)
        {
            GetDatos();
            LlenarDatos();
            LlenarDatosCalculados();
        }

        private void DTFecha_Validated(object sender, EventArgs e)
        {
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {

            LlenarDatos();
            LlenarDatosCalculados();
        }

        private void btnAplicarPorcentaje_Click(object sender, EventArgs e)
        {


            CAJUSTESIVABE ajusteBE = new CAJUSTESIVABE();
            CAJUSTESIVAD ajusteD = new CAJUSTESIVAD();
            ajusteBE.IFECHA = this.DTFecha.Value;
            ajusteBE = ajusteD.seleccionarAJUSTESIVAxFecha(ajusteBE, null);

            if (ajusteBE != null)
            {
                ajusteBE.IPORC_A_IVA = decimal.Parse(PORC_A_IVATextBox.Text);
                ajusteBE.ITASAIVA = decimal.Parse(TASAIVATextBox.Text);

                if (ajusteD.CambiarAJUSTESIVAD(ajusteBE, ajusteBE, null))
                {
                    MessageBox.Show("Se ha guardado el ajuste");
                }
                else
                {
                    MessageBox.Show("Ocurrio un error " + ajusteD.IComentario);

                }
            }
            else
            {
                ajusteBE = new CAJUSTESIVABE();
                ajusteBE.IFECHA = this.DTFecha.Value;
                ajusteBE.IPORC_A_IVA = decimal.Parse(PORC_A_IVATextBox.Text);
                ajusteBE.ITASAIVA = decimal.Parse(TASAIVATextBox.Text);

                if (ajusteD.AgregarAJUSTESIVAD(ajusteBE, null) != null)
                {
                    MessageBox.Show("Se ha guardado el ajuste");
                }
                else
                {
                    MessageBox.Show("Ocurrio un error " + ajusteD.IComentario);

                }

            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void PORC_A_IVATextBox_Validated(object sender, EventArgs e)
        {
            LlenarDatosCalculados();

        }

        private void TASAIVATextBox_Validated(object sender, EventArgs e)
        {

            LlenarDatosCalculados();
        }





    }
}
