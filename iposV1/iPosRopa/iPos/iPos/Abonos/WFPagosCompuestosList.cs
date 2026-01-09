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
using System.Collections;
using iPos.Abonos;
using FirebirdSql.Data.FirebirdClient;
using iPos.Catalogos;

namespace iPos
{
    public partial class WFPagosCompuestosList : IposForm
    {

        bool bTienePermisosEditarBitacoraMismoDia = false;
        bool bTienePermisosEditarBitacoraOtroDia = false;
        bool bTienePermisosEditarBitacoraOtroUsuario = false;
        bool bTienePermisosEliminarBitacoraMismoDia = false;
        bool bTienePermisosEliminarBitacoraOtroDia = false;
        bool bTienePermisoModificarEstadoBitacoraDet = false;
        bool todosSeleccionados = false;


        public WFPagosCompuestosList()
        {
            InitializeComponent();
        }

        private void LlenarGrid(long formaPago, string aplicados, string timbrados, long clienteId)
        {
            try
            {
                this.pAGOLISTTableAdapter.Fill(this.dSAbonos.PAGOLIST,
                                                CBSoloFiscales.Checked ? "S" : "N",
                                               dtpFechaInicial.Value,
                                               dtpFechaFinal.Value,
                                               CBIncluirCancelaciones.Checked ? "S" : "N", formaPago, aplicados, timbrados, clienteId
                                               );
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            LlenarGridPorBusqueda();
        }

        private void LlenarGridPorBusqueda()
        {

            long formaPago = ObtenerFormaPago();
            string filtroAplicados = ValorFiltroAplicados();
            string filtroTimbrados = ValorFiltroTimbrados();
            long clienteId = 0;

            if(ITEMIDTextBox.DbValue != null)
            {
                clienteId = long.Parse(ITEMIDTextBox.DbValue);
            }
            LlenarGrid(formaPago, filtroAplicados, filtroTimbrados, clienteId);
        }

        private void btnAgregarBitacora_Click(object sender, EventArgs e)
        {
            WFPagoCompuestoEdit wf = new WFPagoCompuestoEdit();
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);

            LlenarGrid(0, "T", "T", 0);
        }

        private string ValorFiltroTimbrados()
        {
            switch(timbradosComboBox.SelectedIndex)
            {
                case 0:
                    return "S";
                case 1:
                    return "N";
                case 2:
                    return "T";
                default:
                    return "T";
            }
        }

        private string ValorFiltroAplicados()
        {
            switch (aplicadosComboBox.SelectedIndex)
            {
                case 0:
                    return "S";
                case 1:
                    return "N";
                case 2:
                    return "T";
                default:
                    return "T";
            }
        }

        private long ObtenerFormaPago()
        {
            switch (FormaPagoComboBox.SelectedIndex)
            {

                case 0:
                    return DBValues._FORMA_PAGO_EFECTIVO;
                    
                case 1:
                    return DBValues._FORMA_PAGO_TARJETA;
                    
                case 2:
                    return DBValues._FORMA_PAGO_TARJETA;

                case 3:
                    return DBValues._FORMA_PAGO_TARJETA;
                    
                case 4:
                    return DBValues._FORMA_PAGO_CHEQUE;
                    
                case 5:
                    return DBValues._FORMA_PAGO_VALE;
                    
                case 6:
                    return DBValues._FORMA_PAGO_TRANSFERENCIA;
                    
                case 7:
                    return DBValues._FORMA_PAGO_INTERCAMBIOMERCANCIACREDITO;
                    
                case 8:
                    return DBValues._FORMA_PAGO_NOIDENTIFICADO;
                    
                case 9:
                    return DBValues._FORMA_PAGO_DEPOSITO;
                    
                case 10:
                    return DBValues._FORMA_PAGO_DEPOSITOTERCERO;
                case 11:
                    return 0;
                default:
                    return 0;
            }
        }



        private void WFPagosCompuestosList_Load(object sender, EventArgs e)
        {
            LlenarGrid(0, "T", "T", 0);

            CUSUARIOSD usuariosD = new CUSUARIOSD();

            bTienePermisosEditarBitacoraMismoDia = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_BITACORAEDITAR_MISMODIA, null);
            bTienePermisosEditarBitacoraOtroDia = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_BITACORAEDITAR_OTRODIA, null);
            bTienePermisosEditarBitacoraOtroUsuario = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_BITACORAEDITAR_OTROUSUARIO, null);
            bTienePermisosEliminarBitacoraMismoDia = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_BITACORAELIMINAR_MISMODIA, null);
            bTienePermisosEliminarBitacoraOtroDia = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_BITACORAELIMINAR_OTRODIA, null);
            bTienePermisoModificarEstadoBitacoraDet = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_MODIFICAR_ESTADO_BITACORA, null);
        }

       

        private void pAGOLISTDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(pAGOLISTDataGridView.Columns[e.ColumnIndex].Name == "DGVer")
            {
                if (pAGOLISTDataGridView.Rows[e.RowIndex].Cells["DGFolio"].Value != null)
                {
                    long folioId = (long)pAGOLISTDataGridView.Rows[e.RowIndex].Cells["DGFolio"].Value;

                    WFPagoCompuestoEdit wf = new WFPagoCompuestoEdit(folioId);
                    wf.ShowDialog();
                    wf.Dispose();
                    GC.SuppressFinalize(wf);

                    LlenarGridPorBusqueda();


                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timbrarPagosButton_Click(object sender, EventArgs e)
        {
            //nos aseguramos de poner solo los no cancelados
            CBIncluirCancelaciones.Checked = false;
            LlenarGridPorBusqueda();

            pAGOLISTDataGridView.Columns["TIMBRARCHECKBOX"].Visible = true;
            cancelarButton.Visible = true;
            timbrarButton.Visible = true;
            seleccionarPagosButton.Visible = true;
            timbrarPagosButton.Visible = false;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            DeshabilitarControlesTimbrado();
        }

        private void DeshabilitarControlesTimbrado()
        {
            SeleccionarPagosList(false);
            pAGOLISTDataGridView.Columns["TIMBRARCHECKBOX"].Visible = false;
            timbrarPagosButton.Visible = true;
            timbrarButton.Visible = false;
            seleccionarPagosButton.Visible = false;
            cancelarButton.Visible = false;
        }

        private void seleccionarPagosButton_Click(object sender, EventArgs e)
        {
            if(!todosSeleccionados)
            {
                SeleccionarPagosList(true);
            }
            else
            {
                SeleccionarPagosList(false);
            }
        }

        private void SeleccionarPagosList(bool valorSeleccion)
        {
            for (int rowIndex = 0; rowIndex < pAGOLISTDataGridView.Rows.Count; rowIndex++)
            {
                pAGOLISTDataGridView.Rows[rowIndex].Cells["TIMBRARCHECKBOX"].Value = valorSeleccion;
            }

            todosSeleccionados = valorSeleccion;

            seleccionarPagosButton.Text = valorSeleccion ? "Borrar Selección" : "Seleccionar Todos";
        }

        private void SeleccionaCliente()
        {
            WFClientes look = new WFClientes();
            look.m_bSelecionarRegistro = true;
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                string strBuffer = "";
                ITEMIDTextBox.DbValue = ((long)dr["ID"]).ToString();
                ITEMIDTextBox.MostrarErrores = false;
                ITEMIDTextBox.MValidarEntrada(out strBuffer, 1);
                ITEMIDTextBox.MostrarErrores = true;
            }
        }

        private void timbrarButton_Click(object sender, EventArgs e)
        {



            if (MessageBox.Show("Se procedara a generar los recibos electrónicos de pagos esta de acuerdo ?  ",
                                "Confirmacion",
                                MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return ;
            }


            m_mensajeErrorBGWorker = "";
            pnlProgresoTimbrado.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            backgroundWorker1.RunWorkerAsync();



        }

        private void ITEMButton_Click(object sender, EventArgs e)
        {
            SeleccionaCliente();
        }


        private string m_mensajeErrorBGWorker = "";
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            ReciboElectronicoHelper reciboElectronicoHelper = new ReciboElectronicoHelper();
            CPAGOD pagoDao = new CPAGOD();

            FbConnection connection = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();



                int iCount = 0;
                int iTotalCount = 0;

                //obtener el total de timbrados a hacer
                foreach (DataGridViewRow row in pAGOLISTDataGridView.Rows)
                {
                    if (row.Cells["TIMBRARCHECKBOX"]  != null &&
                        row.Cells["TIMBRARCHECKBOX"].Value != null &&
                        (bool)row.Cells["TIMBRARCHECKBOX"].Value)
                        iTotalCount++;
                }
                backgroundWorker1.ReportProgress(iCount, iTotalCount);

                foreach (DataGridViewRow row in pAGOLISTDataGridView.Rows)
                {

                    if (row.Cells["TIMBRARCHECKBOX"] != null &&
                        row.Cells["TIMBRARCHECKBOX"].Value != null &&
                        (bool)row.Cells["TIMBRARCHECKBOX"].Value)
                    {
                        CPAGOBE pago = new CPAGOBE();

                        long folio = (long)row.Cells["DGFolio"].Value;

                        pago.IID = folio;
                        pago = pagoDao.seleccionarPAGO(pago, transaction);

                        if (!reciboElectronicoHelper.Procesar(pago.IID, pago.IPERSONAID, true))
                        {
                            m_mensajeErrorBGWorker += "\r\n" + reciboElectronicoHelper.Mensaje;
                            /*string mensajeError = "Problema con pago " + folio.ToString() + ": " +
                                                   reciboElectronicoHelper.Mensaje +
                                                  "\n¿Desea continuar?";

                            if (!(MessageBox.Show(mensajeError, "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                            {
                                throw new Exception("Error: " + reciboElectronicoHelper.Mensaje);
                            }*/
                        }
                    }

                    iCount++;
                    backgroundWorker1.ReportProgress(iCount,iTotalCount);
                }

                transaction.Commit();
            }
            catch (Exception exception)
            {
                m_mensajeErrorBGWorker += "\r\n" + "Error: " + exception.Message + " StackTrace: " + exception.StackTrace;
                //MessageBox.Show("Error: " + exception.Message + " StackTrace: " + exception.StackTrace);
                transaction.Rollback();
            }
            finally
            {
                connection.Close();
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            progressBar1.Style = ProgressBarStyle.Blocks;
            pnlProgresoTimbrado.Visible = false;

            if (m_mensajeErrorBGWorker  != null && !m_mensajeErrorBGWorker.Equals(""))
            {
                MessageBox.Show("Mensajes de error " +  m_mensajeErrorBGWorker);
            }

            DeshabilitarControlesTimbrado();
            //LlenarGrid(0, "T", "T", 0);
            LlenarGridPorBusqueda();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblProgresoTimbrado.Text = e.ProgressPercentage.ToString(e.ProgressPercentage + " de " + ((int)e.UserState).ToString());
        }
    }
}
