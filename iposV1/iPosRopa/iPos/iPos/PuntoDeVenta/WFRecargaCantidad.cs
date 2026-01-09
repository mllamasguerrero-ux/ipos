using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos
{
    public partial class WFRecargaCantidad : IposForm
    {
        public decimal m_dMontoRecarga;
        bool m_bFocus;
        public string m_compania;
        bool m_bSeleccionarCompania;
        decimal m_defaultValue = 1;

        public WFRecargaCantidad()
        {
            InitializeComponent();
        }
        public WFRecargaCantidad( bool bFocus, bool bSeleccionarCompania)
        {
            InitializeComponent();
            m_dMontoRecarga = 0;
            m_bFocus = bFocus;
            m_bSeleccionarCompania = bSeleccionarCompania;
            this.CBCompania.Visible = bSeleccionarCompania;
            this.lblCompania.Visible = bSeleccionarCompania;
        }


        public WFRecargaCantidad(bool bFocus, bool bSeleccionarCompania, decimal defaultValue) : this(bFocus, bSeleccionarCompania)
        {
            m_defaultValue = defaultValue;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            m_dMontoRecarga = decimal.Parse(TBCantidad.Text);
            if (CBCompania.SelectedIndex < 0 && m_bSeleccionarCompania)
            {
                MessageBox.Show("Porfavor seleccione la compañia");
                return;
            }
            else if (CBCompania.SelectedIndex >= 0)
            {
                m_compania = CBCompania.SelectedItem.ToString();
            }
            this.Close();
        }

        private void TBCantidad_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                m_dMontoRecarga = decimal.Parse(TBCantidad.Text);

                if (CBCompania.SelectedIndex < 0 && m_bSeleccionarCompania)
                {
                    MessageBox.Show("Porfavor seleccione la compañia");
                    return;
                }
                else if (CBCompania.SelectedIndex >= 0)
                {
                    m_compania = CBCompania.SelectedItem.ToString();
                }

                this.Close();
            }
        }

        private void WFRecargaCantidad_Load(object sender, EventArgs e)
        {
            if (m_bFocus)
            {
                this.TBCantidad.Text = this.m_defaultValue.ToString();
                this.TBCantidad.SelectAll();
                
            }
        }

        private void TBCantidad_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if ((e.KeyCode == Keys.Decimal || e.KeyCode == Keys.OemPeriod) && TBCantidad.SelectionLength == TBCantidad.Text.Length)
            {
                TBCantidad.Text = "0.000";
            }
        }
    }
}
