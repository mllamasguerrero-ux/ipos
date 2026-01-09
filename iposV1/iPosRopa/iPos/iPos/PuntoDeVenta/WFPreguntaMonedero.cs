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
    public partial class WFPreguntaMonedero : IposForm
    {
        public decimal m_saldo;
        public decimal m_montoAAplicar;
        CDOCTOBE m_Docto;
        public CMONEDEROBE m_monedero;
        string m_titulo;
        public DateTime m_vigencia;
        public int m_iTipo;


        public WFPreguntaMonedero()
        {
            InitializeComponent();
        }

        public WFPreguntaMonedero(CDOCTOBE Docto, string titulo, string numeromonedero, int iTipo)
        {
            InitializeComponent();
            m_Docto = Docto;
            if (numeromonedero != null && numeromonedero.Trim().Length > 0)
            {
                m_monedero = new CMONEDEROBE();
                m_monedero.ICLAVE = numeromonedero;
            }
            m_monedero = null;
            m_montoAAplicar = 0;
            m_saldo = 0;

            m_titulo = "";
            m_vigencia = DateTime.MinValue;
            m_iTipo = iTipo;
        }

        private void WFPreguntaMonedero_Load(object sender, EventArgs e)
        {
            this.LBTitulo.Text = m_titulo;

            if (m_monedero != null)
            {
                this.TBMonedero.Text = m_monedero.ICLAVE;
                MostrarTotales();
            }


            this.TBMonedero.Focus();

            if (m_iTipo == 1)
            {
                LBTextMonto.Visible = false;
                LblMontoAAplicar.Visible = false;
            }
        }

        private void BTContinue_Click(object sender, EventArgs e)
        {

            this.LblMontoAAplicar.Text = "...";
            this.LBLSaldoActual.Text = "...";
            if (this.obtenTotalesMonedero())
            {
                this.Close();
            }
        }


        private void MostrarTotales()
        {
            this.LblMontoAAplicar.Text = "...";
            this.LBLSaldoActual.Text = "...";
            this.LBVigencia.Text = "...";

            if (this.obtenTotalesMonedero())
            {
                this.LblMontoAAplicar.Text = this.m_montoAAplicar.ToString("N2");
                this.LBLSaldoActual.Text = this.m_saldo.ToString("N2");
                this.LBVigencia.Text = this.m_vigencia.ToString("dd/MM/yyyy");

            }
        }

        private void BTVerSaldo_Click(object sender, EventArgs e)
        {
            MostrarTotales();
        }



        private bool obtenTotalesMonedero()
        {
            m_montoAAplicar = 0;
            m_saldo = 0;
            m_monedero = null;
            m_vigencia = DateTime.MinValue;
            if (this.TBMonedero.Text.Trim() == "")
            {
                return true;
            }

            CMONEDEROD monederoD = new CMONEDEROD();

            m_monedero = new CMONEDEROBE();
            m_monedero.ICLAVE = this.TBMonedero.Text.Trim();
            m_monedero = monederoD.seleccionarMONEDEROXClave(m_monedero, null);
            
            
            if (m_monedero != null)
            {
                m_vigencia = m_monedero.IVIGENCIA;

                if (m_monedero.IVIGENCIA >= DateTime.Today)
                {
                    m_saldo = m_monedero.ISALDO;
                }
                else
                {
                    m_saldo = 0;
                }

                if (m_saldo < CurrentUserID.CurrentParameters.IMONEDEROMONTOMINIMO)
                {
                    m_montoAAplicar = 0;
                }
                else
                {

                    if (m_saldo >= m_Docto.ITOTAL)
                    {
                        m_montoAAplicar = m_Docto.ITOTAL;
                    }
                    else
                    {
                        m_montoAAplicar = m_saldo;
                    }
                }

            }
            else
            {
                m_monedero = new CMONEDEROBE();
                m_monedero.ICLAVE = this.TBMonedero.Text.Trim();
                m_monedero.IID = 0;
                return true;
            }
            return true;
        }

        private void TBMonedero_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MostrarTotales();

            }
        }

    }
}
