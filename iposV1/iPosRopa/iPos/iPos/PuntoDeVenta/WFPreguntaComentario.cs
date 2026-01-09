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
    public partial class WFPreguntaComentario : IposForm
    {
        public string m_labelText = "Comentario de autorizacion credito excedido:";

        public string m_comentario;
        public WFPreguntaComentario()
        {
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            m_comentario = textBox1.Text;
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

            //if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            //{
            //    m_comentario = textBox1.Text;
            //    this.Close();
            //}
        }

        private void WFPreguntaComentario_FormClosing(object sender, FormClosingEventArgs e)
        {

            m_comentario = textBox1.Text;

            if (textBox1.Text == null || textBox1.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Debe escribir algo en el campo de texto");
                e.Cancel = true;
            }
        }

        private void WFPreguntaComentario_Load(object sender, EventArgs e)
        {
            this.label1.Text = m_labelText;
        }
    }
}
