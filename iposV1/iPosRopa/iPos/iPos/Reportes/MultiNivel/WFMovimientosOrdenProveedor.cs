using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPosBusinessEntity;
using iPosData;

namespace iPos
{
    public partial class WFMovimientosOrdenProveedor : IposForm
    {
        long m_clienteID = 0;
        string m_conSaldo = "N";

        long m_currentDoctoId = 0;
        long m_currentPersonaId = 0;

        public WFMovimientosOrdenProveedor()
        {
            InitializeComponent();
        }

        public WFMovimientosOrdenProveedor(long clienteID, string conSaldo):this()
        {
            m_clienteID = clienteID;
            m_conSaldo = conSaldo;
        }

        private void LlenarMovimientos()
        {
            int personaId = 0;
            try
            {
                personaId = Int32.Parse(this.PERSONAIDTextBox.DbValue.ToString());
                if(personaId == 0)
                {
                    MessageBox.Show("Seleccione un cliente valido");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Seleccione un cliente valido");
                return;
            }


            try
            {


                this.mOVIMIENTOSTableAdapter.Fill(this.dSFastReports.MOVIMIENTOS, "N", GetTipoDocto(),DTPFrom.Value,DTPTo.Value,
                    (Int32.Parse(this.PERSONAIDTextBox.DbValue.ToString())),
                    "T",
                    ("N"));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private int GetTipoDocto()
        {
            return 16;
        }

        private void BTMostrar_Click(object sender, EventArgs e)
        {

            LimpiarDetalles();
            LimpiarRecepciones();
            LimpiarRecepcionDetalle();
            //this.dSFastReports.GET_LISTA_ABONOS_DOCTO.Clear();
            LlenarMovimientos();
        }

        private void LlenaDetalles(long lDoctoId)
        {
            try
            {
                this.mOVIMIENTOSDETALLETableAdapter.Fill(this.dSFastReports.MOVIMIENTOSDETALLE, (int)lDoctoId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void LimpiarDetalles()
        {
            this.dSFastReports.MOVIMIENTOSDETALLE.Clear();
        }

        private void mOVIMIENTOSDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                m_currentDoctoId = long.Parse(mOVIMIENTOSDataGridView.Rows[e.RowIndex].Cells["DOCTOID"].Value.ToString());
                m_currentPersonaId = long.Parse(mOVIMIENTOSDataGridView.Rows[e.RowIndex].Cells["DGPERSONAID"].Value.ToString());
                LlenaDetalles(m_currentDoctoId);

                LimpiarRecepciones();
                LimpiarRecepcionDetalle();
            }
            catch
            {
            }
        }


        private void WFMovimientosOrdenProveedor_Load(object sender, EventArgs e)
        {
            this.DTPFrom.Value = DateTime.Parse("01/01/2012");
            this.DTPTo.Value = DateTime.Parse("31/12/" + DateTime.Today.ToString("yyyy"));


            if (m_clienteID != 0)
            {
                string strBuffer = "";
                this.PERSONAIDTextBox.DbValue = m_clienteID.ToString();
                this.PERSONAIDTextBox.MostrarErrores = false;
                this.PERSONAIDTextBox.MValidarEntrada(out strBuffer, 1);
                this.PERSONAIDTextBox.MostrarErrores = true;
            }



            if (m_clienteID != 0)
            {
                LlenarMovimientos();
            }

        }

        private void LlenarRecepciones(long doctoOrdenId, long personaId, long productoId)
        {
            try
            {
                this.mOVIMIENTOSRECEPCIONORDENTableAdapter.Fill(this.dSFastReports.MOVIMIENTOSRECEPCIONORDEN,(int)personaId,(int) doctoOrdenId, (int) productoId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void LimpiarRecepciones()
        {
            this.dSFastReports.MOVIMIENTOSRECEPCIONORDEN.Clear();
        }

        private void LlenarRecepcionesDetalle(long doctoRecepcionId)
        {
            try
            {
                this.mOVIMIENTOSRECEPCIONDETALLETableAdapter.Fill(this.dSFastReports.MOVIMIENTOSRECEPCIONDETALLE,(int)doctoRecepcionId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void LimpiarRecepcionDetalle()
        {
            this.dSFastReports.MOVIMIENTOSRECEPCIONDETALLE.Clear();

        }

        private void mOVIMIENTOSDETALLEDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                long lProductoId = long.Parse(mOVIMIENTOSDETALLEDataGridView.Rows[e.RowIndex].Cells["DGPRODUCTOID"].Value.ToString());
                this.LlenarRecepciones(m_currentDoctoId, m_currentPersonaId, lProductoId);

                LimpiarRecepcionDetalle();
            }
            catch
            {
            }
        }



        private void mOVIMIENTOSRECEPCIONORDENDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.RowIndex < 0)
                    return;

                long doctoId = long.Parse(mOVIMIENTOSRECEPCIONORDENDataGridView.Rows[e.RowIndex].Cells["DGDOCTOIDREC"].Value.ToString());
                LlenarRecepcionesDetalle(doctoId);
            }
            catch
            {
            }
        }

        private void mOVIMIENTOSRECEPCIONORDENDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (mOVIMIENTOSRECEPCIONORDENDataGridView.Columns[e.ColumnIndex].Name == "DGRECIMPRIMIR")
            {
                CUSUARIOSD usuariosD = new CUSUARIOSD();
                Boolean usuarioTienePermisoDesgloseKit = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null);
                Boolean usuarioTienePermisoImprimirOrdenCompra = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_IMPRIMIR_COMPRASYORDEN, null);
                
                if(!usuarioTienePermisoImprimirOrdenCompra)
                {
                    MessageBox.Show("No tiene derecho a reimprimir la compra/orden de compra");
                    return;
                }

                long dgDoctoId = (long)mOVIMIENTOSRECEPCIONORDENDataGridView.Rows[e.RowIndex].Cells["DGDOCTOIDREC"].Value;

                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("pdoctoid", dgDoctoId);
                dictionary.Add("usaDatosDeEntregaCuandoExista", "N");
                dictionary.Add("desglosekits", usuarioTienePermisoDesgloseKit ? "S" : "N");
                dictionary.Add("creadoPorUserId", 0);
                string strReporte = "recibolargo.frx";


                iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.deusuario), dictionary);
                rp.ShowDialog();
                rp.Dispose();
                GC.SuppressFinalize(rp);
            }
        }

        private void mOVIMIENTOSDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (mOVIMIENTOSDataGridView.Columns[e.ColumnIndex].Name == "DGOCIMPRIMIR")
            {
                CUSUARIOSD usuariosD = new CUSUARIOSD();
                Boolean usuarioTienePermisoDesgloseKit = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null);
                Boolean usuarioTienePermisoImprimirOrdenCompra = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_IMPRIMIR_COMPRASYORDEN, null);

                if (!usuarioTienePermisoImprimirOrdenCompra)
                {
                    MessageBox.Show("No tiene derecho a reimprimir la compra/orden de compra");
                    return;
                }

                long dgDoctoId = (long)mOVIMIENTOSDataGridView.Rows[e.RowIndex].Cells["DOCTOID"].Value;

                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("pdoctoid", dgDoctoId);
                dictionary.Add("usaDatosDeEntregaCuandoExista", "N");
                dictionary.Add("desglosekits", usuarioTienePermisoDesgloseKit ? "S" : "N");
                dictionary.Add("creadoPorUserId", 0);
                string strReporte = "recibolargo.frx";


                iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.deusuario), dictionary);
                rp.ShowDialog();
                rp.Dispose();
                GC.SuppressFinalize(rp);
            }
        }

       
    }
}
