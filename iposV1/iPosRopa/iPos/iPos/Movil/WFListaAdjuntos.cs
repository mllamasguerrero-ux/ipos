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

namespace iPos.Movil
{
    public partial class WFListaAdjuntos : iPos.Tools.ScreenConfigurableForm
    {
        private long m_doctoId;
        private bool m_bEliminacionEnabled;

        public WFListaAdjuntos()
        {
            InitializeComponent();
        }


        public WFListaAdjuntos(long doctoId, bool bEliminacionEnabled):this()
        {

            m_doctoId = doctoId;
            m_bEliminacionEnabled = bEliminacionEnabled;
        }

        private void LlenarGrid()
        {
            try
            {
                this.aDJUNTOSPORDOCTOTableAdapter.Fill(this.dSMovil2.ADJUNTOSPORDOCTO, m_doctoId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void WFListaAdjuntos_Load(object sender, EventArgs e)
        {
            configuraLaPantalla(true, true);
            LlenarGrid();
        }




        private void EliminarDetalle()
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            CMOVTOBE movtoBE = new CMOVTOBE();

            if (this.aDJUNTOSPORDOCTODataGridView.Rows.Count <= 0)
                return;

            //asegurarnos de que realmente se quiere eliminar el detalle y que el supervisor dio su aval
            if (MessageBox.Show("Realmente quiere eliminar el detalle de venta?", "Eliminar detalle de venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
            }
            else
                return;



            if (this.aDJUNTOSPORDOCTODataGridView.CurrentRow.Index != this.aDJUNTOSPORDOCTODataGridView.NewRowIndex)
            {
                movtoBE.IID = (long)this.aDJUNTOSPORDOCTODataGridView.CurrentRow.Cells["MOVTOID"].Value;
                if (!pvd.BorrarMOVTOVENTAS(movtoBE, null))
                {
                    MessageBox.Show(pvd.IComentario);
                }
                LlenarGrid();
            }

        }



    }
}
