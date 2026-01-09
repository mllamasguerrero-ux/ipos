using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Surtir
{
    public partial class WFNotaIncidencia : Form
    {
        public string strNotaIncidencia = "";
        public string strEncabezadoIncidencia = "";
        public bool m_forzarIngresarNota = false;
        private string strTitulo = "Nota incidencia";
        public bool m_notaAgregada = false;
        public bool m_permitirIngresarEncabezado = false;
        public WFNotaIncidencia()
        {
            InitializeComponent();
        }

        public WFNotaIncidencia(bool forzarIngresarNota, string strTitulo) : this()
        {
            m_forzarIngresarNota = forzarIngresarNota;
            this.strTitulo = strTitulo;
        }

        public WFNotaIncidencia(bool forzarIngresarNota, string strTitulo, bool permitirIngresarEncabezado) : 
                this(forzarIngresarNota, strTitulo)
        {
            m_permitirIngresarEncabezado = permitirIngresarEncabezado;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            strNotaIncidencia = textBox1.Text;
            strEncabezadoIncidencia = EncabezadoTextBox.Text;
            if (!m_forzarIngresarNota || strNotaIncidencia.Trim().Length > 0)
            {
                m_notaAgregada = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ingrese una nota ");
            }
        }

        private void WFNotaIncidencia_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(m_forzarIngresarNota && strNotaIncidencia.Trim().Length == 0)
            {
                e.Cancel = true;
                MessageBox.Show("Ingrese una nota ");
            }
        }

        private void WFNotaIncidencia_Load(object sender, EventArgs e)
        {
            label1.Text = strTitulo;
            EncabezadoTextBox.Visible = this.m_permitirIngresarEncabezado;
        }
    }
}
