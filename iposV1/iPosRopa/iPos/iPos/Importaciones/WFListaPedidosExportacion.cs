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
using System.Collections;

namespace iPos
{
    public partial class WFListaPedidosExportacion : IposForm
    {
        public DataRow m_rtnDataRow;

        public int m_tipo, m_statusdocto,m_tipodoctoId;
        public bool m_loadEvent = true;

        public WFListaPedidosExportacion()
        {
            InitializeComponent();
            this.m_statusdocto = (int)iPosData.DBValues._DOCTO_ESTATUS_BORRADOR;
            this.m_tipodoctoId = (int)iPosData.DBValues._DOCTO_TIPO_VENTA;
            
        }

        public WFListaPedidosExportacion(int p_statusdocto, int p_tipodoctoId)
        {
            InitializeComponent();
            this.m_statusdocto = p_statusdocto;
            this.m_tipodoctoId = p_tipodoctoId;
          

        }


        private bool LlenaGrid()
        {
            try
            {
                
                long p_cajero =  (this.CBCajerosTodos.Checked) ? 0 : Int64.Parse(this.VENDEDORIDTextBox.DbValue.ToString());
                long p_corteid = CurrentUserID.CurrentUser.ICORTEID;
                long p_subtipoid = 0;

                string p_status = "";
                switch (CBEstatus.SelectedIndex)
                {
                    case 0: p_status = "N"; break;
                    case 1: p_status = "S"; break;
                    case 2: p_status = "G"; break;
                    default: p_status = "T"; break;
                }




                DateTime fechaQuery = DateTime.Parse("1980-01-01");
                if (!CBCorteActual.Checked)
                {
                    p_corteid = 0;
                    if (CBFechaElaboracion.Checked)
                    {
                        fechaQuery = DTPFecha.Value;
                    }
                }

                switch (CBTipo.SelectedIndex)
                {
                    case 0: p_subtipoid = 1; break;
                    case 1: p_subtipoid = 2; break;
                    default: p_subtipoid = 0; break;
                }

                this.lISTAPEDIDOSTableAdapter.Fill(this.dSImportaciones.LISTAPEDIDOS, p_corteid, p_cajero, fechaQuery.ToString("yyyy-MM-dd"), p_subtipoid,p_status);

                if (this.dSImportaciones.LISTAPEDIDOS.Rows.Count <= 0)
                {
                    m_rtnDataRow = null;
                    MessageBox.Show("No hay registros");
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }


        private void WFListaPedidosExportacion_Load(object sender, EventArgs e)
        {

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_ELIMINAR_VENTA_DIASATRAS, null) &&
               !usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_VERVENTAS_OTROSCORTES, null))
            {
                this.pnlCorteActual.Enabled = false;

            }

            if (CurrentUserID.ES_ADMINISTRADOR || CurrentUserID.ES_SUPERVISOR)
            {
                this.pnlCajero.Enabled = true;
                //this.pnlTotales.Visible = true;
            }
            else
            {
                this.pnlCajero.Enabled = false;
                //this.pnlTotales.Visible = false;
            }


            string strBuffer = "";
            this.VENDEDORIDTextBox.DbValue = CurrentUserID.CurrentUser.IID.ToString();
            this.VENDEDORIDTextBox.MostrarErrores = false;
            this.VENDEDORIDTextBox.MValidarEntrada(out strBuffer, 1);
            this.VENDEDORIDTextBox.MostrarErrores = true;

            /*if (m_statusdocto == 0)
            {
                this.CBTipo.Visible = false;
                LBTIPOREG.Visible = false;
            }*/
            this.CBEstatus.SelectedIndex = 0;
            this.CBTipo.SelectedIndex = 2;  //esto automaticamente manda llenar los grids ( por el evento )
            



            //if (!
            //LlenaGrid();
            //    )
            //{
            //    this.Close();
            //}
            //LlenarTotales();

            m_loadEvent = false;
        }


        private void RetornarSeleccion(bool bEnterKey)
        {
            try
            {
                int iRetornoRowIndex = /*(bEnterKey && vENTASLISTADataGridView.CurrentRow.Index < (vENTASLISTADataGridView.RowCount - 1)) 
                                        ? vENTASLISTADataGridView.CurrentRow.Index - 1 :*/ vENTASLISTADataGridView.CurrentRow.Index;
                DataGridViewRow dr = vENTASLISTADataGridView.Rows[iRetornoRowIndex];

                m_rtnDataRow = (dr.DataBoundItem as DataRowView).Row;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }

        private void vENTASLISTADataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                RetornarSeleccion(false);
        }


        private void vENTASLISTADataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)13)
            //    RetornarSeleccion(true);

        }

        //private void fillToolStripButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        object caja = new object();
        //        this.totalVentaTableAdapter.Fill(this.dSPuntoVenta.TotalVenta, caja);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message);
        //    }

        //}

        private void CBTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CBTipo.SelectedIndex)
            {
                case 0: this.m_tipodoctoId = 21; break;
                case 1: this.m_tipodoctoId = 31; break;
                case 2: this.m_tipodoctoId = 23; break;
                case 3: this.m_tipodoctoId = 22; break;
                case 4: this.m_tipodoctoId = 25; break;
                default: this.m_tipodoctoId = 0; break;

            }

            LlenaGrid();
            //LlenarTotales();


        }

        private void vENTASLISTADataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                RetornarSeleccion(true);
        }

        private void CBCorteActual_CheckedChanged(object sender, EventArgs e)
        {
            LlenaGrid();
            //LlenarTotales();
        }

        private void CBCajerosTodos_CheckedChanged(object sender, EventArgs e)
        {

            LlenaGrid();
            //LlenarTotales();
        }

        private void VENDEDORIDTextBox_Validated(object sender, EventArgs e)
        {

            LlenaGrid();
            //LlenarTotales();
        }

        private void DTPFecha_Validated(object sender, EventArgs e)
        {

        }

        private void DTPFecha_ValueChanged(object sender, EventArgs e)
        {
            if (!CBFechaElaboracion.Checked)
            {
                LlenaGrid();
                //LlenarTotales();
            }
        }

        private void CBFechaElaboracion_CheckedChanged(object sender, EventArgs e)
        {
            LlenaGrid();
        }

        private void vENTASLISTADataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {

                if (vENTASLISTADataGridView.Columns[e.ColumnIndex].Name == "DGContinuar")
                {

                    long pedidoId = long.Parse(vENTASLISTADataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());
                    string trasladoAFTP = vENTASLISTADataGridView.Rows[e.RowIndex].Cells["DGTRASLADOAFTP"].Value.ToString();


                    if (trasladoAFTP != "N")
                    {
                        MessageBox.Show("Solo los pedidos pendientes pueden continuar su edicion");
                        return;
                    }

                    DateTime fechaIni = DateTime.Today;
                    DateTime fechaFin = DateTime.Today;
                    
                    try{
                    fechaIni = DateTime.Parse(vENTASLISTADataGridView.Rows[e.RowIndex].Cells["DGFECHAINI"].Value.ToString());
                    fechaFin = DateTime.Parse(vENTASLISTADataGridView.Rows[e.RowIndex].Cells["DGFECHAFIN"].Value.ToString());
                    }
                    catch{
                    }
                    ContinuarExportacion(pedidoId, fechaIni, fechaFin, 0);
                    LlenaGrid();


                }
                else if (vENTASLISTADataGridView.Columns[e.ColumnIndex].Name == "DGVer")
                {
                    long pedidoId = long.Parse(vENTASLISTADataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());
                    iPos.WFExportarPedidosDet ep = new iPos.WFExportarPedidosDet(pedidoId, 0,true);
                    ep.ShowDialog();
                    ep.Dispose();
                    GC.SuppressFinalize(ep);
                }
                else if (vENTASLISTADataGridView.Columns[e.ColumnIndex].Name == "DGREENVIAR")
                {


                    if (MessageBox.Show("Si la matriz ya inicio el procesamiento del pedido, el reenvio no se tomara en cuenta. Desea continuar?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }

                    long pedidoId = long.Parse(vENTASLISTADataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());
                    string trasladoAFTP = vENTASLISTADataGridView.Rows[e.RowIndex].Cells["DGTRASLADOAFTP"].Value.ToString();


                    if (trasladoAFTP == "N")
                    {
                        MessageBox.Show("Solo los pedidos ya enviados pueden reenviarse");
                        return;
                    }

                    DateTime fechaIni = DateTime.Today;
                    DateTime fechaFin = DateTime.Today;
                    long expFileId = long.Parse(vENTASLISTADataGridView.Rows[e.RowIndex].Cells["DG_EXPFILEID"].Value.ToString());
                    
                    
                    try{
                    fechaIni = DateTime.Parse(vENTASLISTADataGridView.Rows[e.RowIndex].Cells["DGFECHAINI"].Value.ToString());
                    fechaFin = DateTime.Parse(vENTASLISTADataGridView.Rows[e.RowIndex].Cells["DGFECHAFIN"].Value.ToString());
                    }
                    catch{
                    }
                    ContinuarExportacion(pedidoId, fechaIni, fechaFin, expFileId);

                    LlenaGrid();

                }
                else if (vENTASLISTADataGridView.Columns[e.ColumnIndex].Name == "DGELIMINAR")
                {


                    if (MessageBox.Show("Esta seguro de querer eliminar el registro?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }

                    long pedidoId = long.Parse(vENTASLISTADataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());
                    string trasladoAFTP = vENTASLISTADataGridView.Rows[e.RowIndex].Cells["DGTRASLADOAFTP"].Value.ToString();


                    if (trasladoAFTP != "N")
                    {
                        MessageBox.Show("El pedido ya se envio asi que no puede eliminarse");
                        return;
                    }

                    try
                    {
                        long expFileId = long.Parse(vENTASLISTADataGridView.Rows[e.RowIndex].Cells["DG_EXPFILEID"].Value.ToString());
                        CEXP_FILESD fileD = new CEXP_FILESD();
                        CEXP_FILESBE fileBE = new CEXP_FILESBE();

                        fileBE.IID = expFileId;
                        fileD.BorrarEXP_FILESD(fileBE, null);
                        

                    }
                    catch
                    {

                    }

                    DataLayer.Importaciones.ExportarDBF exportarD = new DataLayer.Importaciones.ExportarDBF();
                    if(!exportarD.ELIMINARPEDIDO(pedidoId, null))
                    {
                        MessageBox.Show("Ocurrio un error al tratar de eliminar el pedido " );
                    }
                    

                    LlenaGrid();

                }
            }
        }

        
        private void ContinuarExportacion(long doctoId, DateTime dateFrom, DateTime dateTo, long expFileId)
        {
            ImportaDesdeFtp iDBF = new ImportaDesdeFtp();
            ArrayList resultadosExportacion = new ArrayList();
            string strResultado = "";

                iDBF.ProcesoPedido(ref resultadosExportacion,
                                                dateFrom,
                                                dateTo,
                                                doctoId,
                                                true,
                                                0,
                                                expFileId);
           

            foreach (string strComm in resultadosExportacion)
            {
                strResultado += strComm + "\n";
            }
            MessageBox.Show(strResultado);

        }

        private void CBEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!m_loadEvent)
              LlenaGrid();
        }

      
    }
}
