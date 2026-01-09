using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using iPosData;
using ConexionesBD;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.ApplicationBlocks.Data;
using System.Collections;
using iPosBusinessEntity;

namespace iPos
{
    public partial class WFImportacionInicialMovil_2 : IposForm
    {
        ProgressBar[] progressBars;
        BackgroundWorker[] backgroundWorkers;
        CheckBox[] checkboxes;
        int currentProgress = 0;
        bool bError = false;
        string strError = "";

        ProgressBar progBar = null;
        BackgroundWorker bgworker = null;
        CheckBox chBox = null;

        public WFImportacionInicialMovil_2()
        {
            InitializeComponent();
        }


        void inicializar()
        {
            bError = false;
            strError = "";
            currentProgress = 0;
            foreach(CheckBox cb in checkboxes)
            {
                cb.Visible = false;
            }
        }

        void recursiveChecking()
        {
            if (currentProgress > 0 && progBar != null)
            {

                progBar.Style = ProgressBarStyle.Blocks;


                if (bError)
                {
                    MessageBox.Show(strError);
                    inicializar();
                    return;
                }
                
                chBox.Visible = true;
            }

            if (currentProgress >= 7)
            {
                MessageBox.Show("La inicialización se ha terminado ");
                this.Close();
                return;
            }


            progBar = progressBars[currentProgress];
            bgworker = backgroundWorkers[currentProgress];
            chBox = checkboxes[currentProgress];
            progBar.Style = ProgressBarStyle.Marquee;
            bgworker.RunWorkerAsync();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (LastMovilFinalized())
            {
                inicializar();
                recursiveChecking();
            }
            else
            {
                if (MessageBox.Show("Necesita primero hacer cierre de lo anterior. Desea hacerlo? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                        iPos.WFExportacionFinalMovil_02 frm = new iPos.WFExportacionFinalMovil_02();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            switch (currentProgress)
            {
                case 0: LimpiarBD(); break;
                case 1: AbrirCorte(); break;
                case 2: PreparandoInfoEnServer(); break;
                case 3: ImportarArchivos(); break;
                case 4: ImportarCatalogos(); break;
                case 5: ImportarClientes(); break;
                case 6: ImportarCobranza(); break;
                case 7: /*ImportarHistorial();*/ break;
                default: break;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            currentProgress++;
            recursiveChecking();

        }

        private void WFImportacionInicialMovil_2_Load(object sender, EventArgs e)
        {
            progressBars = new ProgressBar[] { progressBar00, progressBar01, progressBar07, progressBar02, progressBar03, progressBar04, progressBar05, progressBar06 };
            backgroundWorkers = new BackgroundWorker[] { backgroundWorker0, backgroundWorker1, backgroundWorker7, backgroundWorker2, backgroundWorker3, backgroundWorker4, backgroundWorker5, backgroundWorker6 };
            checkboxes = new CheckBox[] { checkBox0, checkBox1, checkBox7, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6 };


        }


        private void LimpiarBD()
        {
            if (ImportaFtpMovil.ZippearBackupBD())
            {

                LIMPIARPARAMOVIL(null);

                string comentario = "";
                //bError = !ImportaFtpMovil.AbrirCorte(ref comentario);

                this.strError = "";
                if (bError)
                {
                    strError = comentario;
                }
                //Thread.Sleep(2000);
            }
            else
            {
                bError = true;
                strError = "Error al respaldar la bd";
            }
        }

        private void ImportarArchivos()
        {
            //Thread.Sleep(2000);
            bError = !ImportaFtpMovil.ImportarArchivos();

            if (bError)
            {
                this.strError = "Error al importar archivos del ftp";
            }
        }

        private void ImportarCatalogos()
        {
            //return;
            ArrayList errores = new ArrayList();
            bError = !ImportaFtpMovil.ImportarCatalogo(ref errores, CurrentUserID.CurrentParameters);
            //Thread.Sleep(2000);

            this.strError = "";
            if (bError)
            {
                foreach (string str in errores)
                {
                    strError = str + "\n";
                }
            }
            else
            {
                CurrentUserID.GetAutoSourceCollectionFromTable(true);
            }
        }

        private void ImportarClientes()
        {

            ArrayList errores = new ArrayList();
            bError = !ImportaFtpMovil.ImportarClientes(ref errores, CurrentUserID.CurrentParameters);

            this.strError = "";
            if (bError)
            {
                foreach (string str in errores)
                {
                    strError = str + "\n";
                }
            }
            else
            {
                CPERSONAD personaD = new CPERSONAD();
                bError = !personaD.limpiarClientesInactivos(null);
                if (bError)
                {
                    strError = personaD.IComentario;
                }
            }
        }

        private void ImportarCobranza()
        {
            string error = "";
            bError = !ImportaFtpMovil.ImportarCobranza(ref error);

            this.strError = "";
            if (bError)
            {
                strError = error;

            }

        }

        
        private void PreparandoInfoEnServer()
        {
            
            
            string error = "";
            bError = !ImportaFtpMovil.PrepareFileInServerForMovil(ref error);

            this.strError = "";
            if (bError)
            {
                strError = error;

            }

        }

        private void ImportarHistorial()
        {


            string error = "";
            bError = !ImportaFtpMovil.ImportarHistorial(ref error);

            this.strError = "";
            if (bError)
            {
                strError = error;
                
            }
        }




        private bool LIMPIARPARAMOVIL(FbTransaction st)
        {

            try
            {
                ArrayList parts = new ArrayList();
                //FbParameter auxPar;

                string commandText = @"LIMPIARPARAMOVIL";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(ConexionesBD.ConexionBD.ConexionString(), CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);

                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
                return false;
            }

        }



        private void AbrirCorte()
        {
            CCORTED corteD = new CCORTED();
            CCORTEBE corteBE = new CCORTEBE();
            DateTime fechaCorteActiva = DateTime.MinValue;
            if (corteD.HayCorteActivo(iPos.CurrentUserID.CurrentUser.IID, null, ref fechaCorteActiva))
            {
               strError = "Ya hay un corte activo";
               bError = true;
                return;
            }
            corteBE.ISUCURSALID = CurrentUserID.CurrentParameters.ISUCURSALID;
            corteBE.ICAJAID = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;
            corteBE.ICAJEROID = CurrentUserID.CurrentUser.IID;
            corteBE.IFECHACORTE = DateTime.Now;
            corteBE.ISALDOINICIAL = 0;
            corteBE.ITIPOCORTEID = DBValues._TIPO_CORTEABIERTO;



            corteBE = corteD.AbrirCORTED(corteBE, null);
            if (corteBE == null)
            {
                bError = true;
                strError = corteD.IComentario;
            }
            else
            {
                //MessageBox.Show("El corte se ha abierto con exito");
                ActualizaCurrentUser();
            }

           
        }




        private void ActualizaCurrentUser()
        {
            CPERSONAD personaD = new CPERSONAD();
            CurrentUserID.CurrentUser = personaD.seleccionarPERSONA(CurrentUserID.CurrentUser, null);
        }



        public bool LastMovilFinalized()
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            bool bEstaFinalizado = true;
            if (!pvd.MOVIL_ESTA_FINALIZADO(null, ref bEstaFinalizado))
            {
                MessageBox.Show(pvd.IComentario);
                return true;
            }

            return bEstaFinalizado;
        }

    }
}
