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
    public partial class WFListaFaltantesEnsamble : IposForm
    {
        int iDoctoId = 0;
        public WFListaFaltantesEnsamble()
        {
            InitializeComponent();
        }
        public WFListaFaltantesEnsamble( int doctoId) : this()
        {
            iDoctoId = doctoId;
        }

        private void LlenarGrid()
        {
            try
            {
                this.fALTANTESENSAMBLETableAdapter.Fill(this.dSKits.FALTANTESENSAMBLE, iDoctoId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void WFListaFaltantesEnsamble_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }
    }
}
