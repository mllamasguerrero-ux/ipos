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
    public partial class WFRecalcularUtilidadesTransaccionesEmida : Form
    {
        bool error = false;
        string strError;

        public WFRecalcularUtilidadesTransaccionesEmida()
        {
            InitializeComponent();
        }

        private void btnRecalcular_Click(object sender, EventArgs e)
        {
            DialogResult anaswer = MessageBox.Show("Seguro que desea recalcular la utilidad de transacciones Emida?", "Confirmacion", MessageBoxButtons.YesNo);

            if (anaswer == DialogResult.Yes)
            {
                this.progressBar1.Style = ProgressBarStyle.Marquee;
                this.btnRecalcular.Enabled = false;
                this.backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            CEMIDAPRODUCTD adminEmidaProd = new CEMIDAPRODUCTD();

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();

                if (!adminEmidaProd.EMIDA_REAJUSTARUTILIDADES(DTPFrom.Value,
                                                                 DTPTo.Value, fTrans))
                {
                    fTrans.Rollback();
                    fConn.Close();
                    strError = "Error al llamar el procedimiento almacenado";
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
            this.btnRecalcular.Enabled = true;
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
