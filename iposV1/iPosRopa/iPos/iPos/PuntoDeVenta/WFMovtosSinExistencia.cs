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
    public partial class WFMovtosSinExistencia : IposForm
    {
        long m_doctoId = 0;
        public WFMovtosSinExistencia()
        {
            InitializeComponent();
        }

        public WFMovtosSinExistencia(long doctoId)
            :this()
        {
            m_doctoId = doctoId;
        }

        private void Llenar()
        {
            try
            {
                this.mOVTOS_SINEXISTENCIATableAdapter.Fill(this.dSPuntoDeVentaAux.MOVTOS_SINEXISTENCIA,(int)m_doctoId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void WFMovtosSinExistencia_Load(object sender, EventArgs e)
        {
            Llenar();
        }
    }
}
