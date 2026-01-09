using iPosBusinessEntity;
using iPosData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos.PuntoDeVenta
{
    public partial class WFSeleccionarRutaEmbarque : Form
    {
        long m_RutaEmbarqueId;
        public long rutaEmbarqueId;
        bool canExit;
        iPos.Catalogos.WFRutasEmbarque look = new iPos.Catalogos.WFRutasEmbarque();
        long m_personaId;

        public WFSeleccionarRutaEmbarque(bool canExit)
        {
            InitializeComponent();
            this.canExit = canExit;
            m_personaId = 0;
        }
        public WFSeleccionarRutaEmbarque(bool canExit, long personaId) : this(canExit)
        {
            m_personaId = personaId;
        }


         private void BTRutaEmbarque_Click(object sender, EventArgs e)
        {
            SeleccionaRutaEmbarque();
        }

        private void SeleccionaRutaEmbarque()
        {
            look = new iPos.Catalogos.WFRutasEmbarque();
            //look.m_bSelecionarRegistro = true;
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                LBClienteNombre.Text = dr["NOMBRE"].ToString().Trim();
                ITEMIDTextBox.Text = dr["CLAVE"].ToString().Trim();
                m_RutaEmbarqueId = (long)dr["ID"];
            }

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (LBClienteNombre.Text.Equals("..."))
            {
                MessageBox.Show("Debe seleccionar una ruta!");
                //BTRutaEmbarque.Focus();
                return;
            }

           /* if (this.ITEMIDTextBox.DbValue.ToString() != null && this.ITEMIDTextBox.DbValue.ToString() != "0")
            {
                m_RutaEmbarqueId = long.Parse(this.ITEMIDTextBox.DbValue.ToString());
            }*/
            if (m_RutaEmbarqueId == 0)
            {
                if (!this.ITEMIDTextBox.DbValue.ToString().Equals(null) && !this.ITEMIDTextBox.DbValue.ToString().Equals("") && !this.ITEMIDTextBox.DbValue.ToString().Equals("0"))
                {
                    m_RutaEmbarqueId = Int64.Parse(this.ITEMIDTextBox.DbValue.ToString());
                }
            }

            if (m_RutaEmbarqueId == 0)
            {
                MessageBox.Show("Seleccione una Ruta");
                return;
            }
            else
            {
                this.rutaEmbarqueId = m_RutaEmbarqueId;
                canExit = true;
                this.Close();
            }
        }

        private void LBClienteNombre_Click(object sender, EventArgs e)
        {

        }

        private void ITEMButton_Click(object sender, EventArgs e)
        {
            SeleccionaRutaEmbarque();
        }

        private void WFSeleccionarRutaEmbarque_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!canExit)
            {
                e.Cancel = true;
                MessageBox.Show("No se puede omitir la seleccion de la ruta de embarque, favor de seleccionar una ruta!");
            }
        }

        private void ITEMIDTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataRow dr = look.m_rtnDataRow;

                if (dr != null)
                {
                    m_RutaEmbarqueId = (long)dr["ID"];
                }
            }
        }

        private void WFSeleccionarRutaEmbarque_Load(object sender, EventArgs e)
        {
            if(m_personaId != 0)
            {
                CPERSONAD personaD = new CPERSONAD();
                CPERSONABE personaBE = new CPERSONABE();
                personaBE.IID = m_personaId;
                personaBE = personaD.seleccionarPERSONA(personaBE, null);
                string strBuffer = "";
                if(personaBE != null && personaBE.IRUTAEMBARQUEID != 0)
                {

                    this.ITEMIDTextBox.DbValue = personaBE.IRUTAEMBARQUEID.ToString();
                    this.ITEMIDTextBox.MostrarErrores = false;
                    this.ITEMIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.ITEMIDTextBox.MostrarErrores = true;
                }
            }
        }
    }
}
