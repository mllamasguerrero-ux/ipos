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
    public partial class WFListaFaltanteKitAlVuelo : IposForm
    {
        int iDoctoId = 0;
        public WFListaFaltanteKitAlVuelo()
        {
            InitializeComponent();
        }
        public WFListaFaltanteKitAlVuelo(int doctoId)
            : this()
        {
            iDoctoId = doctoId;
        }

        private void LlenarGrid()
        {
            try
            {
                this.fALTANTESKITALVUELOTableAdapter.Fill(this.dSKit2.FALTANTESKITALVUELO,  iDoctoId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void WFListaFaltanteKitAlVuelo_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }
    }
}
