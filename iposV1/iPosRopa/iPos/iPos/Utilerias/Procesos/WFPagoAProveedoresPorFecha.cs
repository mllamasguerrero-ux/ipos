using iPosData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPos.Login_and_Maintenance;
using FirebirdSql;
using FirebirdSql.Data.FirebirdClient;

namespace iPos.Utilerias.Procesos
{
    public partial class WFPagoAProveedoresPorFecha : Form
    {
        bool error = false;
        string strError;
        Int64? proveedorId = 0;

        public WFPagoAProveedoresPorFecha()
        {
            InitializeComponent();
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            if (!this.cbTodosProveedores.Checked)
            {
                try
                {
                    proveedorId = Int64.Parse(this.PERSONAIDTextBox.DbValue.ToString());
                }
                catch
                {
                    MessageBox.Show("Seleccione un cliente valido");
                    return;
                }
            }

            DialogResult anaswer = MessageBox.Show("Seguro que desea aplicar pagos?", "Confirmacion", MessageBoxButtons.YesNo);

            if(anaswer == DialogResult.Yes)
            {
                this.progressBar1.Style = ProgressBarStyle.Marquee;
                this.BTEnviar.Enabled = false;
                this.cbTodosProveedores.Enabled = false;
                this.PERSONAButton.Enabled = false;
                this.PERSONAIDTextBox.Enabled = false;
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

                if(!pagarAProveedoresStoreProc.DOCTO_PAGOS_PROCESO_RANGO(
                                                                 -11,
                                                                 -1,
                                                                 DTPFrom.Value,
                                                                 DTPTo.Value,
                                                                 CurrentUserID.CurrentUser.IID,
                                                                 (long)proveedorId,
                                                                 "",
                                                                 0, fTrans)) 
                {
                    fTrans.Rollback();
                    fConn.Close();
                    strError = "Error al llamar el procedimiento almacenado" ;
                    error = true;
                    return;
                }
                 
                fTrans.Commit();
                fConn.Close();
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
            this.cbTodosProveedores.Enabled = true;
            this.PERSONAButton.Enabled = true;
            this.PERSONAIDTextBox.Enabled = true;
            if (error)
            {
                MessageBox.Show("Ocurrio un error: " + strError, "Error", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Se han actualizado los precios", "Exito", MessageBoxButtons.OK);
                this.Close();

            }
        }
    }
}
