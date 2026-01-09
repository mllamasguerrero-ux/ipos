using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.PuntoDeVenta
{
    public partial class WFPreguntaConfirmacion : Form
    {
        public bool BoolAceptar { get; set; }
        private string Message { get; set; }

        private string LeyendaBotonAceptar { get; set; }
        private string LeyendaBotonCancelar { get; set; }
        public WFPreguntaConfirmacion()
        {
            InitializeComponent();
            BoolAceptar = false;
        }


        public WFPreguntaConfirmacion(string message):this()
        {
            Message = message;
        }

        public WFPreguntaConfirmacion(string message, string leyendaBotonAceptar, string leyendaBotonCancelar) : this(message)
        {
            LeyendaBotonAceptar = leyendaBotonAceptar;
            LeyendaBotonCancelar = leyendaBotonCancelar;
    }

        private void WFPreguntaPagoCredito_Load(object sender, EventArgs e)
        {
            textBox1.Text = Message;
        }

        private void BTAceptar_Click(object sender, EventArgs e)
        {
            BoolAceptar = true;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
