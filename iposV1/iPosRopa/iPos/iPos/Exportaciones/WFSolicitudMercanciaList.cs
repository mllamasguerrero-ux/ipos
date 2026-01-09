using DataLayer.Importaciones;
using iPosBusinessEntity;
using iPosData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Exportaciones
{
    public partial class WFSolicitudMercanciaList : Form
    {
        public WFSolicitudMercanciaList()
        {
            InitializeComponent();
        }

        private void LlenarGrid()
        {
            try
            {
                string soloPendientes = CBSoloPendientes.Checked ? "S" : "N";
                this.sOLICITUDMERCAENVIADATableAdapter.Fill(this.dSExportaciones.SOLICITUDMERCAENVIADA, this.DTPFechaInicio.Value, this.DTPFechaFin.Value, soloPendientes);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {

            ExportarDBF exportarDBF = new ExportarDBF();
            bool bRes = true;
            long lPedido = 0;
            long lSucursalTId = 0;

            if (!SeleccionarSucursalTID(CurrentUserID.CurrentParameters.ISUCURSALID, ref lSucursalTId))
                return;
            
            bRes = exportarDBF.PedidoGenerar(CurrentUserID.CurrentParameters.ISUCURSALID, CurrentUserID.CurrentUser.IID, DateTime.Today, DateTime.Today, true, null, ref lPedido, false, DBValues._DOCTO_SUBTIPO_SOLICITUDMERCANCIA, true, lSucursalTId);

            if (bRes)
            {
                PedidoEditarProcesar(lPedido);
            }

            LlenarGrid();
        }

        private bool SeleccionarSucursalTID(int p_sucursalId, ref long lSucursalTId)
        {
            bool retorno = false;
            LookUpSucursales look;
            look = new LookUpSucursales(p_sucursalId);
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);


            if (dr != null)
            {
                lSucursalTId = (long)dr[0];
                
                retorno = true;
            }


            return retorno;
        }



        public bool PedidoEditarProcesar(long lPedido)
        {
            string dbFileNameDetalle = "";
            DateTime dateFrom = DateTime.Today, dateTo = DateTime.Today;
            CEXP_FILESBE expFilesBE = new CEXP_FILESBE();
            long exp_fileid = 0;
            ArrayList resultadosExportacion = new ArrayList();

            bool bRes = PedidoEditarPorUsuario(lPedido);
            if (!bRes)
            {
                LlenarGrid();
                return false;
            }


            ExportarDBF exportarDBF = new ExportarDBF();
            bRes = exportarDBF.PedidoCrearDBF(CurrentUserID.CurrentParameters.IID_DOSLETRAS, null, lPedido, ref dbFileNameDetalle);
            if (!bRes)
            {
                MessageBox.Show(exportarDBF.IComentario);
                LlenarGrid();
                return false;
            }


            bRes = exportarDBF.PedidoAgregarEnListaExpo(dbFileNameDetalle, lPedido, ref expFilesBE, dateFrom, dateTo, exp_fileid);
            if (!bRes)
            {
                MessageBox.Show(exportarDBF.IComentario);
                LlenarGrid();
                return false;
            }


            bRes = exportarDBF.PedidoEnviarAFtp(expFilesBE, ref resultadosExportacion);
            if (!bRes)
            {
                MessageBox.Show(exportarDBF.IComentario);
                LlenarGrid();
                return false;
            }


            MessageBox.Show("El pedido se ha enviado");
            LlenarGrid();
            return true;

        }

        public bool PedidoEditarPorUsuario(long lPedidoDoctoId)
        {

            iPos.WFExportarPedidosDet ep = new iPos.WFExportarPedidosDet(lPedidoDoctoId, 0);
            ep.ShowDialog();
            bool bCancelar = ep.m_bCancelar;
            ep.Dispose();
            GC.SuppressFinalize(ep);
            
            return !bCancelar;
        }


        private void WFSolicitudMercanciaList_Load(object sender, EventArgs e)
        {
            this.LlenarGrid();
        }

        

        private void sOLICITUDMERCAENVIADADataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {


                if (sOLICITUDMERCAENVIADADataGridView.Columns[e.ColumnIndex].Name == "DGBtnEliminar")
                {

                    if (MessageBox.Show("Esta seguro de querer eliminar el registro?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }

                    CDOCTOD dOCTOD = new CDOCTOD();
                    CDOCTOBE doctoBE = new CDOCTOBE();
                    doctoBE.IID = long.Parse(sOLICITUDMERCAENVIADADataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());

                    if(!dOCTOD.BorrarDOCTO(doctoBE, null))
                    {
                        MessageBox.Show("No se pudo eliminar " +  dOCTOD.IComentario);
                        return;
                    }

                    LlenarGrid();
                }
                else if (sOLICITUDMERCAENVIADADataGridView.Columns[e.ColumnIndex].Name == "DGBtnVer")
                {
                    long lPedido = long.Parse(sOLICITUDMERCAENVIADADataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());
                    
                    PedidoEditarProcesar(lPedido);
                    
                }
            }
        }
    }
}
