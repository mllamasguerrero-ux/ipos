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
using System.Globalization;
using FirebirdSql.Data.FirebirdClient;
using System.Collections;
using Microsoft.ApplicationBlocks.Data;
using ConexionesBD;
using DataLayer.Importaciones;
using System.Net.Mail;
using System.Data;
using System.Net.Mime;
using System.IO;


namespace iPos
{
    public partial class WFVerificarCXCPedidoMovil : Form
    {


        public WFVerificarCXCPedidoMovil()
        {
            InitializeComponent();
        }


        private void WFVerificarCXCPedidoMovil_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSSurtido.CANCDEVOSURTIR' table. You can move, or remove it, as needed.

            this.DTSurtidoVenta.Value = DateTime.Today.AddDays(-30);

            LlenarGrid();
        }

        private void LlenarGrid()
        {
            long vendedorFinalId = 0;
            int estadoSurtidoId = (int)DBValues._DOCTO_SURTIDOESTADO_CXC;

            if (!CBTodosVendedores.Checked)
            {
                try
                {
                    vendedorFinalId = Int64.Parse(this.VENDEDORTextBox.DbValue.ToString());
                }
                catch
                {
                }
            }

            switch(CBMostrarOpciones.SelectedIndex)
            {
                case 1: estadoSurtidoId = (int)DBValues._DOCTO_SURTIDOESTADO_CXC_RECH; break;
                case 2: estadoSurtidoId = (int)DBValues._DOCTO_SURTIDOESTADO_SURTIDO; break;
                default: estadoSurtidoId = (int)DBValues._DOCTO_SURTIDOESTADO_CXC; break;
            }


            if(estadoSurtidoId == (int)DBValues._DOCTO_SURTIDOESTADO_CXC)
            {
                dOCTOSASURTIRDataGridView.ReadOnly = false;
                btnGuardar.Enabled = true;
                btnAprobar.Enabled = true;
                btnRechazar.Enabled = true;
                dOCTOSASURTIRDataGridView.Columns["DGAPROBAR"].Visible = true;
                dOCTOSASURTIRDataGridView.Columns["DGRECHAZADA"].Visible = true;
                dOCTOSASURTIRDataGridView.Columns["DGPENDIENTE"].Visible = false;

            }
            else if(estadoSurtidoId == (int)DBValues._DOCTO_SURTIDOESTADO_CXC_RECH)
            {

                dOCTOSASURTIRDataGridView.ReadOnly = false;
                btnGuardar.Enabled = true;
                btnAprobar.Enabled = false;
                btnRechazar.Enabled = false;
                dOCTOSASURTIRDataGridView.Columns["DGAPROBAR"].Visible = false;
                dOCTOSASURTIRDataGridView.Columns["DGRECHAZADA"].Visible = false;
                dOCTOSASURTIRDataGridView.Columns["DGPENDIENTE"].Visible = true;
            }
            else
            {

                dOCTOSASURTIRDataGridView.ReadOnly = true;
                btnGuardar.Enabled = false;
                btnAprobar.Enabled = false;
                btnRechazar.Enabled = false;
                dOCTOSASURTIRDataGridView.Columns["DGAPROBAR"].Visible = false;
                dOCTOSASURTIRDataGridView.Columns["DGRECHAZADA"].Visible = false;
                dOCTOSASURTIRDataGridView.Columns["DGPENDIENTE"].Visible = false;
            }

            this.dOCTOSMOVILAPROBARTableAdapter.Fill(this.dSMovil5.DOCTOSMOVILAPROBAR, estadoSurtidoId, DTSurtidoVenta.Value, vendedorFinalId);
        }


        private void dOCTOSASURTIRDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1 )
            {
                
            }
        }

        
        

        
        

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void btnActualizarCancDevo_Click(object sender, EventArgs e)
        {
            
        }
        
        private void btnAprobar_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow dr in dOCTOSASURTIRDataGridView.Rows)
            {
                dr.Cells["DGAPROBAR"].Value = true;
                dr.Cells["DGRECHAZADA"].Value = false;
            }

        }


        private void btnRechazar_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow dr in dOCTOSASURTIRDataGridView.Rows)
            {
                dr.Cells["DGAPROBAR"].Value = false;
                dr.Cells["DGRECHAZADA"].Value = true;
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Dictionary<long, List<DataGridViewRow>> mappedData = new Dictionary<long, List<DataGridViewRow>>();
            CDOCTOD doctoD = new CDOCTOD();

            foreach (DataGridViewRow dr in dOCTOSASURTIRDataGridView.Rows)
            {


                bool aprobada = dr.Cells["DGAPROBAR"].Value != null && bool.Parse(dr.Cells["DGAPROBAR"].Value.ToString());
                bool rechazada = dr.Cells["DGRECHAZADA"].Value != null && bool.Parse(dr.Cells["DGRECHAZADA"].Value.ToString());
                bool pendiente = dr.Cells["DGPENDIENTE"].Value != null && bool.Parse(dr.Cells["DGPENDIENTE"].Value.ToString());
                var decontado =  dr.Cells["DGMOVILCONTADO"].Value.ToString();



                long doctoId = Int64.Parse(dr.Cells["DGID"].Value.ToString());
                long usuarioId = CurrentUserID.CurrentUser.IID;
                decimal doctoCreditoAprobado = decimal.Parse(dr.Cells["DGCREDITOAPROBADO"].Value.ToString());
                


                if (aprobada || rechazada)
                {

                    string strAprobado = aprobada ? "S" : "N";

                    if (!doctoD.MOVILCREDITO_APROBACION(doctoId, doctoCreditoAprobado, strAprobado, usuarioId, null))
                    {

                        MessageBox.Show("Ocurrio un error al aprobar el credito " + doctoD.IComentario);
                        return;
                    }
                }

                if(pendiente)
                {
                    
                    if (!doctoD.MOVILCREDITO_PENDIENTE(doctoId, usuarioId, null))
                    {

                        MessageBox.Show("Ocurrio un error al volver a poner pendiente el credito " + doctoD.IComentario);
                        return;
                    }
                }


                CDOCTOBE doctoBE = new CDOCTOBE();
                doctoBE.IID = doctoId;
                doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);
                if(doctoBE.IMOVILCONTADO != decontado)
                {

                    doctoBE.IMOVILCONTADO = decontado;

                    if (!doctoD.CambiarMOVILCONTADO(doctoBE, null))
                    {
                        MessageBox.Show("Ocurrio un error al cambiar el estatus de contado " + doctoD.IComentario);
                        return;
                    }
                }

                

            }



            MessageBox.Show("Se completaron las operaciones");
            this.Close();
        }

        private void dOCTOSASURTIRDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
            e.ThrowException = false;
        }

        private void dOCTOSASURTIRDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string columnName = dOCTOSASURTIRDataGridView.Columns[e.ColumnIndex].Name;

            // Abort validation if cell is not in the CompanyName column.
            if (!columnName.Equals("DGCREDITOAPROBADO")) return;

            try
            {
                decimal dAprobado = decimal.Parse(e.FormattedValue.ToString());
                decimal dTotal = decimal.Parse(dOCTOSASURTIRDataGridView.Rows[e.RowIndex].Cells["DGTOTAL"].Value.ToString());
                if ( dAprobado < 0)
                {
                    MessageBox.Show("El monto aprobado no puede ser  menor que cero");
                    e.Cancel = true;
                }
                else if (dAprobado > dTotal)
                {

                    MessageBox.Show("El monto aprobado no puede ser  mayor que el total");
                    e.Cancel = true;


                }
            }
            catch
            {
            }
        }


        private void fillStatus()
        {
            foreach (DataGridViewRow row in dOCTOSASURTIRDataGridView.Rows)
            {
                if (row.Index == dOCTOSASURTIRDataGridView.NewRowIndex)
                    continue;

                DataGridViewImageCell cell = row.Cells["BOLITASALDO"] as DataGridViewImageCell;
                DataGridViewTextBoxCell cellstatus = row.Cells["STATUSSALDO"] as DataGridViewTextBoxCell;
                if (cellstatus != null)
                {
                    if (cellstatus.Value.ToString().Trim().Equals("BLOQUEADO"))
                        cell.Value = (System.Drawing.Image)iPos.Properties.Resources.redcircle;
                    else if (cellstatus.Value.ToString().Trim().Equals("EXCEDIDO"))
                        cell.Value = (System.Drawing.Image)iPos.Properties.Resources.ambarcircle;
                    else
                        cell.Value = (System.Drawing.Image)iPos.Properties.Resources.greencircle;
                }
            }
        }


        private void CBMostrarOpciones_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LlenarGrid();


        }

        private void dOCTOSASURTIRDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            fillStatus();
        }
    }
}
