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
    public partial class WFImprimirCorteCortoConAjuste : IposForm
    {
        decimal m_dSubtotalConIva = 0, m_dSubtotalSinIva = 0, m_dMontoIva = 0;
        public WFImprimirCorteCortoConAjuste()
        {
            InitializeComponent();
        }

        private void BTReimprimirCorte_Click(object sender, EventArgs e)
        {

            decimal ajusteIntercambioIva = 0, ajusteTasaIva = 0;

            ajusteIntercambioIva = decimal.Parse(PORC_A_IVATextBox.Text);
            ajusteTasaIva = decimal.Parse(TASAIVATextBox.Text);

            WFImpresionCorte ic = new WFImpresionCorte(this.DTPCorte.Value,cbSumarizado.Checked,
                                         (this.RBPorCajero.Checked) ? ImpresionCorteOption.SumarizadoDelDiaXCajero : ImpresionCorteOption.SumarizadoDelDia, ajusteIntercambioIva, ajusteTasaIva);
            ic.ShowDialog();

            if (ic.m_bTicketImpreso)
                MessageBox.Show("El ticket se imprimio");

            ic.Dispose();
            GC.SuppressFinalize(ic);
        }

        private void cbSumarizado_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSumarizado.Checked)
            {
                this.GBOpcionesSumarizado.Enabled = true;
                this.RBNormal.Checked = true;
            }
            else
            {
                this.GBOpcionesSumarizado.Enabled = false;
            }

        }

        private void WFImprimirCorteCorto_Load(object sender, EventArgs e)
        {

            WFPreguntaAutorizacion ps2 = new WFPreguntaAutorizacion();
            ps2.ShowDialog();
            CPERSONABE userBE = ps2.m_userBE;
            CPERSONABE supervisorBE = ps2.m_supervisorBE;
            bool bPassValido = ps2.m_bPassValido;
            bool bIsSupervisor = ps2.m_bIsSupervisor;
            bool bIsAdministrador = ps2.m_bIsAdministrador;
            ps2.Dispose();
            GC.SuppressFinalize(ps2);

            if (!bPassValido)
            {
                this.Close();
                return;
            }

            if (!bIsSupervisor)
            {
                MessageBox.Show("El usuario no es un supervisor");
                this.Close();
                return;
            }



            GetDatos();
            LlenarDatos();
            LlenarDatosCalculados();
        }



        private void GetDatos()
        {

            m_dSubtotalConIva = 0;
            m_dSubtotalSinIva = 0;
            m_dMontoIva = 0;

            try
            {
                this.corteTicketSumarizadoTableAdapter.Fill(this.dSReimpresionTicket.CorteTicketSumarizado, this.DTPCorte.Value);

                if (this.dSReimpresionTicket.CorteTicketSumarizado.Rows.Count > 0)
                {
                    ReimpresionTicket.DSReimpresionTicket.CorteTicketSumarizadoRow dr = (ReimpresionTicket.DSReimpresionTicket.CorteTicketSumarizadoRow)this.dSReimpresionTicket.CorteTicketSumarizado.Rows[0];

                    m_dSubtotalConIva = dr.SUBTOTALCONIVA;
                    m_dSubtotalSinIva = dr.SUBTOTALSINIVA;
                    m_dMontoIva = dr.MONTOIVA;


                }

                CAJUSTESIVABE ajusteBE = new CAJUSTESIVABE();
                CAJUSTESIVAD ajusteD = new CAJUSTESIVAD();
                ajusteBE.IFECHA = this.DTPCorte.Value;
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
            ajusteBE.IFECHA = this.DTPCorte.Value;
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
                ajusteBE.IFECHA = this.DTPCorte.Value;
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
