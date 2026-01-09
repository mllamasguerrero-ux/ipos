using iPos.Tools;
using iPosData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Threading;
using FirebirdSql.Data.FirebirdClient;

namespace iPos
{
    public partial class WFActualizacionBD : Form
    {
        public static string txtFileName;
        private bool loaded;
        public bool Loaded
        {
            get { return this.loaded; }
            set { this.loaded = value; }
        }
        private bool errorInFile;
        public bool ErrorInFile
        {
            get { return this.errorInFile; }
            set { this.errorInFile = value; }
        }
        private BackgroundWorker backgroundWorker1;
        ActualizacionesBD updater;

        Dispatcher dispatcher;

        ArrayList strErrores = new ArrayList();

        public WFActualizacionBD()
        {
            InitializeComponent();
            this.dispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
        }
        public WFActualizacionBD(ActualizacionesBD updater)
        {
            InitializeComponent();
            this.dispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
            this.updater = updater;
            loaded = false;
            errorInFile = false;
            //this.txtStateOfUpdate.Text = "Preparando Archivos para la Actualización....";
            progressBarUpdateDB.Style = ProgressBarStyle.Marquee;
            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            backgroundWorker1.WorkerReportsProgress = true;

            backgroundWorker1.RunWorkerAsync();

            //txtState = this.txtStateOfUpdate;

        }

        private bool ActualizarCatalogoSatInicialDirecto()
        {
            CatalogosSatHelper catSatHelper = new CatalogosSatHelper();
            bool retorno = catSatHelper.ImportarCatalogos(ref strErrores, true);

            if (!retorno)
            {

                string strMensajeError = "";
                foreach (string str in strErrores)
                {
                    strMensajeError = str + "\n";
                }

                MessageBox.Show("Error " + strMensajeError);
            }

            return retorno;
        }


        


        private bool ActualizarCatalogoSat(bool esInicial, string versionCatalogToUpdate)
        {
            iPos.Login_and_Maintenance.WFImportacionCatalogosSat catSatImpo = new Login_and_Maintenance.WFImportacionCatalogosSat(esInicial, versionCatalogToUpdate);

            catSatImpo.ShowDialog();
            bool importSuccess = catSatImpo.importSuccess;

            catSatImpo.Dispose();
            GC.SuppressFinalize(catSatImpo);

            return importSuccess;


        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Update the UI here
            //        _userController.UpdateUsersOnMap();
            ChangeTxtStateOfUpdate(txtFileName);
            //progressBarUpdateDB.Value += e.ProgressPercentage;
        }

        private void ChangeTxtStateOfUpdate(string fileName)
        {
            txtStateOfUpdate.Items.Add(fileName);
            txtStateOfUpdate.SelectedIndex = txtStateOfUpdate.Items.Count - 1;
            txtStateOfUpdate.TopIndex = txtStateOfUpdate.Items.Count - 1;
            //txtStateOfUpdate.Focus();
            txtStateOfUpdate.SetItemChecked(txtStateOfUpdate.SelectedIndex, true);

            //txtStateOfUpdate.Text = "Ejecutando la Actualizacón: " + fileName;
        }

        private void ProcesoCompletoActualizar()
        {
            ArrayList files = new ArrayList();
            FileInfo file;
            files = updater.FilesForUpdate(
                CurrentUserID.DBLocation, 
                CurrentUserID.CurrentCompania.IEM_NOMBRE, 
                CurrentUserID.CurrentCompania
                
                );
            // int percentageByFile;
            // percentageByFile = 100 / files.Capacity;

            bool bEsInicial = true; //false cuando ya se importen los nuevos catalogos

            if (files != null)
            {
                foreach (string str in files)
                {
                    try
                    {
                        file = new FileInfo(str);
                        txtFileName = file.Name;
                        backgroundWorker1.ReportProgress(0, txtFileName);

                        string neededInitializationCatalogSatVersion =
                                    txtFileName.Equals(DBValues._VERSION_IMPORTACIONCATALOGOSSAT_2022.ToString().PadLeft(8, '0') + ".sql") ? "2022" :
                                    txtFileName.Equals(DBValues._VERSION_IMPORTACIONCATALOGOSSAT_2022A.ToString().PadLeft(8, '0') + ".sql") ? "2022A" :
                                    (txtFileName.Equals(DBValues._VERSION_IMPORTACIONCATALOGOSSAT.ToString().PadLeft(8, '0') + ".sql") ? "201x" : null);

                        if (neededInitializationCatalogSatVersion != null)
                        {
                            dispatcher.Invoke(new Action(() =>
                            {
                                try
                                {
                                    errorInFile = !ActualizarCatalogoSat(bEsInicial, neededInitializationCatalogSatVersion);
                                }
                                catch
                                {

                                    errorInFile = true;
                                }
                            }));    

                            if (errorInFile)
                            {
                                break;
                            }
                        }

                        bool compactar = false;
                        bool corregir = false;

                        if (!updater.ActualizarBD(file, ref compactar, ref corregir))
                        {
                            if (compactar )
                            {
                                if (!updater.CompactarBD(
                                    CurrentUserID.DBLocation, 
                                    CurrentUserID.CurrentCompania.IEM_NOMBRE))
                                {
                                        errorInFile = true;
                                        break;
                                }
                                else
                                {
                                    if (!updater.ActualizarBD(file, ref compactar, ref corregir))
                                    {
                                        errorInFile = true;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                errorInFile = true;
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Error al intentar aplicar la Actualizacón " + str + " " + ex.Message,
                            "Error!",
                            MessageBoxButtons.OK
                        );

                        errorInFile = true;
                        break;
                    }
                }
            }

            loaded = true;
            backgroundWorker1.ReportProgress(100, loaded);
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            ProcesoCompletoActualizar();
        }

        /* public fileNameUpdate fileNameUpdateS(string strD)
         {
             txtStateOfUpdate.Text = strD;
             return "";
         }*/

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

           FbConnection.ClearAllPools();

            if (!errorInFile)
            {
                progressBarUpdateDB.Style = ProgressBarStyle.Blocks;
                MessageBox.Show("Se han aplicado las actualizaciónes!", "Base de datos Actualizada", MessageBoxButtons.OK);
            }
            else
            {
                progressBarUpdateDB.Style = ProgressBarStyle.Blocks;

                DialogResult dialogResult = MessageBox.Show(
                    "Se detecto un problema con un archivo de actualización, desea intentar repararlo? Ojo: si no tiene credenciales contacte a sistemas",
                    "Error",
                    MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    WFPreguntarClaveConf wf = new WFPreguntarClaveConf();
                    wf.ShowDialog();
                    bool permitido = wf.m_permitido;
                    wf.Dispose();
                    GC.SuppressFinalize(wf);

                    if (!permitido)
                    {
                        MessageBox.Show("Clave incorrecta");
                    }
                    else
                    {
                        WFFbDbFixer dbFixerForm = new WFFbDbFixer(CurrentUserID.DBLocation);
                        dbFixerForm.ShowDialog();

                        if(dbFixerForm.NoErrorsFound)
                        {
                            MessageBox.Show(
                                "Se han solucionado los errores encontrados, vuelva a iniciar sesion para aplciar las actualizaciones", 
                                "Exito", 
                                MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show(
                                "No fue posible resolver los conflictos con los comandos predefinidos", 
                                "Error", 
                                MessageBoxButtons.OK);
                        }
                        dbFixerForm.Dispose();
                        GC.SuppressFinalize(dbFixerForm);
                    }
                }
            }

            Close();
        }

        private void WFActualizacionBD_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case System.Windows.Forms.CloseReason.UserClosing:
                    if (loaded == false)
                    {
                        MessageBox.Show("Se estan aplicando la actualizaciónes, espere un momento", "Proceso en ejecución!");
                        e.Cancel = true;
                    }
                    break;
            }

        }

        private void WFActualizacionBD_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void progressBarUpdateDB_Click(object sender, EventArgs e)
        {

        }

        private void dbFixBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void dbFixBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
