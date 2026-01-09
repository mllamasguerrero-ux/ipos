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
    public partial class WFAdjuntarProductos : iPos.Tools.ScreenConfigurableForm
    {
        public DataRow m_rtnDataRow = null;
        public long m_movtoId = 0;
        public long m_doctoId = 0;
        public bool m_bPermitirCambios = false;
        public WFAdjuntarProductos()
        {
            InitializeComponent();
        }

        public WFAdjuntarProductos(DataRow rtnDataRow, bool bPermitirCambios)
            : this()
        {
            m_rtnDataRow = rtnDataRow;
            m_bPermitirCambios = bPermitirCambios;
        }

        private void WFAdjuntarProductos_Load(object sender, EventArgs e)
        {
            configuraLaPantalla(false, true);

            pnlCambios.Enabled = m_bPermitirCambios;

            if(m_rtnDataRow != null)
            {
                m_movtoId = long.Parse(m_rtnDataRow["MOVTOID"].ToString());
                m_doctoId = long.Parse(m_rtnDataRow["DOCTOID"].ToString());
                this.LBMovtoRefId.Text = m_rtnDataRow["MOVTOID"].ToString();
                this.LBProducto.Text = m_rtnDataRow["DESCRIPCION"].ToString();
                this.LBCantidad.Text = m_rtnDataRow["CANTIDAD"].ToString();
                this.LBPrecioUnidad.Text = m_rtnDataRow["IMPORTE"].ToString();
                this.LBTotal.Text = m_rtnDataRow["PRECIOUNIDAD"].ToString();
                LlenarGrid();
                LlenarGridPosiblesAdjuntos();

            }
        }

        private void LlenarGrid()
        {
            try
            {
                this.gRIDPVADJUNTOSPORDETALLETableAdapter.Fill(this.dSMovil2.GRIDPVADJUNTOSPORDETALLE, (int)m_movtoId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void btnAdjuntar_Click(object sender, EventArgs e)
        {
            if(this.dSMovil2.GRIDPVADJUNTOSPORDETALLE.Rows.Count > 1)
            {

                MessageBox.Show("Solo puede haber un producto adjunto por registro");
                return;
            }


            if (this.gRIDPVPORADJUNTARDataGridView.CurrentRow.Index != this.gRIDPVPORADJUNTARDataGridView.NewRowIndex)
            {
                long movtoHijoId = (long)this.gRIDPVPORADJUNTARDataGridView.CurrentRow.Cells["DGMOVTOID"].Value;
                CPuntoDeVentaD pvd = new CPuntoDeVentaD();
                if (!pvd.AdjuntarMovtos(m_movtoId,movtoHijoId,null))
                {
                    MessageBox.Show(pvd.IComentario);
                }
                LlenarGrid();
                LlenarGridPosiblesAdjuntos();
            }

            /*long productoId = 0;
            if (TBCodigo.Text.Trim() == "")
            {
                MessageBox.Show("El texto de este control no debe estar vacio");
                return;
            }
            
            CPRODUCTOBE prod = new CPRODUCTOBE();
            if (!BuscarProducto(ref prod))
            {

                MessageBox.Show("El producto no existe");
                return;
            }
            productoId = prod.IID;


            CPuntoDeVentaD puntoDeVentaD = new CPuntoDeVentaD();
            if(!puntoDeVentaD.AgregarAdjuntoMovto(m_doctoId, m_movtoId, productoId, 1, null))
            {

                MessageBox.Show("No se pudo agregar el registro " + puntoDeVentaD.IComentario);
                return;
            }*/

        }

        private void btnEliminarAdjuntos_Click(object sender, EventArgs e)
        {

            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            if(!pvd.AdjuntarMovtosEliminar(m_movtoId, null))
            {

                MessageBox.Show("No se pudo eliminar el registro " + pvd.IComentario);
                return;
            }
            LlenarGrid();
            LlenarGridPosiblesAdjuntos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        
        private void LlenarGridPosiblesAdjuntos()
        {
            try
            {
                this.gRIDPVPORADJUNTARTableAdapter.Fill(this.dSMovil2.GRIDPVPORADJUNTAR, (int)m_movtoId, (int)m_doctoId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }








    }
}
