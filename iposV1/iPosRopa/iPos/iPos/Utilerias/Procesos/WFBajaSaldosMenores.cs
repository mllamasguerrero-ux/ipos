using FirebirdSql.Data.FirebirdClient;
using iPosData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos.Utilerias.Procesos
{
    public partial class WFBajaSaldosMenores : Form
    {
        private bool error = false;
        private bool clientePagar = false;
        private bool proveedorPagar = false;
        private String errorStr;
        Int64? proveedorId = 0;
        Int64? clienteId = 0;
        decimal montoMinimo = 0;

        public WFBajaSaldosMenores()
        {
            InitializeComponent();
            montoMinimo = iPos.CurrentUserID.CurrentParameters.IMONTOMAXSALDOMENOR;
            TextBoxMontoParametro.Text = "Monto Actual: " + montoMinimo;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            if(decimal.Parse(MONTOMAXSALDOMENORNumericTextBox.Text) == 0)
            {
                MessageBox.Show("no puede dejar el campo de monto en 0");
                return;
            }

            if(CheckBoxSelectProveedor.Checked)
            {
                proveedorPagar = true;
                if (!this.CheckBoxTodosProveedores.Checked)
                {
                    try
                    {
                        proveedorId = Int64.Parse(this.TextBoxProveedor.DbValue.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Seleccione un proveedor valido");
                        return;
                    }
                }
            }

            if(CheckBoxSelectCliente.Checked)
            {
                clientePagar = true;
                if (!this.CheckBoxTodosClientes.Checked && CheckBoxSelectCliente.Checked)
                {
                    try
                    {
                        clienteId = Int64.Parse(this.TextBoxCliente.DbValue.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Seleccione un cliente valido");
                        return;
                    }
                }
            }

            montoMinimo = decimal.Parse(MONTOMAXSALDOMENORNumericTextBox.Text);

            DialogResult anaswer = MessageBox.Show("Seguro que desea aplicar pagos?", "Confirmacion", MessageBoxButtons.YesNo);

            if (anaswer == DialogResult.Yes)
            {
                this.progressBar1.Style = ProgressBarStyle.Marquee;
                this.BTEnviar.Enabled = false;
                this.CheckBoxTodosProveedores.Enabled = false;
                this.CheckBoxTodosClientes.Enabled = false;
                this.TextBoxCliente.Enabled = false;
                this.TextBoxProveedor.Enabled = false;
                this.ButtonClientes.Enabled = false;
                this.ButtonProveedores.Enabled = false;
                this.storProcBackgroundWorker.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            CUTILERIASD pagarAProveedoresStoreProc = new CUTILERIASD();

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();

                if (proveedorPagar)
                {
                    if (!pagarAProveedoresStoreProc.DOCTO_PAGOS_PROCESO_RANGO(
                                                                 -11,
                                                                 -1,
                                                                 DTPFrom.Value,
                                                                 DTPTo.Value,
                                                                 CurrentUserID.CurrentUser.IID,
                                                                 (long)proveedorId,
                                                                 "",
                                                                 montoMinimo, fTrans))
                    {
                        fTrans.Rollback();
                        fConn.Close();
                        errorStr = "Error al llamar el procedimiento almacenado";
                        error = true;
                        return;
                    }
                    else
                    {
                        error = false;
                    }
                }

                if (clientePagar && !error)
                {
                    if (!pagarAProveedoresStoreProc.DOCTO_PAGOS_PROCESO_RANGO(
                                                             -21,
                                                             -1,
                                                             DTPFrom.Value,
                                                             DTPTo.Value,
                                                             CurrentUserID.CurrentUser.IID,
                                                             (long)clienteId,
                                                             "",
                                                             montoMinimo, fTrans))
                    {
                        fTrans.Rollback();
                        fConn.Close();
                        errorStr = "Error al llamar el procedimiento almacenado";
                        error = true;
                        return;
                    }
                    else
                    {
                        fTrans.Commit();
                        fConn.Close();
                    }
                }
                else
                {
                    if (!error) fTrans.Commit();
                    else fTrans.Rollback();
                    fConn.Close();
                }
            }
            catch
            {
                try
                {
                    fTrans.Rollback();
                }
                catch
                {

                }

                fConn.Close();
            }
            finally
            {
                fConn.Close();
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.progressBar1.Style = ProgressBarStyle.Blocks;
            this.BTEnviar.Enabled = true;
            this.CheckBoxTodosProveedores.Enabled = true;
            this.CheckBoxTodosClientes.Enabled = true;
            this.TextBoxCliente.Enabled = true;
            this.TextBoxProveedor.Enabled = true;
            this.ButtonClientes.Enabled = true;
            this.ButtonProveedores.Enabled = true;
            if (error)
            {
                MessageBox.Show("Ocurrio un error: " + errorStr, "Error", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Se han hecho los saldos correspondientes", "Exito", MessageBoxButtons.OK);
                this.Close();

            }
        }

        private void MONTOMAXSALDOMENORNumericTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                decimal dMonto = decimal.Parse(MONTOMAXSALDOMENORNumericTextBox.Text);

                if(dMonto > montoMinimo)
                {

                    MessageBox.Show("El monto no puede ser mayor a " + montoMinimo.ToString());
                    e.Cancel = true;
                }
            }
            catch
            {
                MessageBox.Show("Ingrese un numero valido");
                e.Cancel = true;
            }
        }
    }
}
