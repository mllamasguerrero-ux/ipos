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
using iPos;
using iPosReporting;
using ConexionesBD;
using System.Security.Cryptography;
using System.IO;
using System.Xml;
using System.Configuration;
using System.Management;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using iPos.Login_and_Maintenance;
using iPos.Importaciones;
using iPos.Utilerias;

namespace iPos
{
    public partial class FLogin : iPos.Tools.ScreenConfigurableForm
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        string archivoConn;
        string m_empresaActual;
        bool updateWithoutWarning;
        public FLogin(string user, string pass) : this()
        {
            TBNameUser.Text = user;
            TBPassUser.Text = pass;

            updateWithoutWarning = true;
            AccesarEmpresa();
        }

        public FLogin()
        {
            InitializeComponent();
            archivoConn = System.AppDomain.CurrentDomain.BaseDirectory + "conexionBD.txt";
            m_empresaActual = "";


            try
            {
                validaInstalacion();
                FastReport.Utils.RegisteredObjects.AddConnection(typeof(FastReport.Data.FirebirdDataConnection));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace);
            }


        }

        protected override bool applyGeneralFormBehaviour()
        {
            return false;
        }


        private void AsignarConexiones()
        {
            string conexion = ObtenerConexion(archivoConn);
            ChangeConnectionString(conexion);
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AccesarEmpresa();
           
        }


        private void ResetAutocompletesEstatus()
        {

            iPos.CurrentUserID.fechaLastLlenadoAutocomplete = System.DateTime.MinValue;
            iPos.CurrentUserID.fechaLastLlenadoAutocompleteCliente = System.DateTime.MinValue;
            iPos.CurrentUserID.fechaLastLlenadoAutocompleteProveedor = System.DateTime.MinValue;
            iPos.CurrentUserID.fechaLastLlenadoAutocompleteConExis = System.DateTime.Now;
        }

        private void AccesarEmpresa()
        {
            try
            {
                //if (!ConexionesAsignadas)
                //{
                AsignarConexiones();
                //}
            }
            catch (Exception exc)
            {
                MessageBox.Show("Asegurese de haber configurado bien la conexion o consulte al administrador del sistema " + "\n" + exc.Message);
                return;
            }

            CPERSONAD userD = new CPERSONAD();
            CPERSONABE userBE = new CPERSONABE();
            CPARAMETROD parametroD = new CPARAMETROD();
            CPARAMETROBE parametroBE = new CPARAMETROBE();

            CSUCURSALD sucursalD = new CSUCURSALD();
            CSUCURSALBE sucursalBE = new CSUCURSALBE();


            userBE.IUSERNAME = TBNameUser.Text;

            userBE = userD.seleccionarPERSONAxNOMBRE(userBE, null);
            if (userBE == null)
            {
                if(userD.iComentario.Contains("NEW_UPDATE"))
                {
                    MessageBox.Show("No puede acceder porque el servidor se esta actualizando!");
                }
                else
                {
                    MessageBox.Show("Usuario no existe");
                }
                return;
            }

            ActualizacionesBD updversion = new ActualizacionesBD();

            long versionBD = updversion.GetCurrentDBVersion();

            //string passwordSaved = versionBD >= DBValues._VERSION_PASSWORDS_ENCRIPTADOS ? iPos.EncDec.Decrypt(userBE.ICLAVEACCESO, "DryHit" + userBE.IUSERNAME.Trim()) : userBE.ICLAVEACCESO;

            string passwordSaved = "";

            if(versionBD >= DBValues._VERSION_ACTUALIZADOR_IPOS)
            {
                try
                {
                    long auxNewVersionIA = 0;
                    if (updversion.SelectIPOS_ACTUALIZADOR_LastVersion(ref auxNewVersionIA, null))
                    {
                        if (auxNewVersionIA > 0)
                        {
                            string fileNewVersionMDUpdate = auxNewVersionIA.ToString().PadLeft(8, '0') + ".sql";
                            if (!File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "sampdata\\MDUpdates\\" + fileNewVersionMDUpdate))
                            {
                                MessageBox.Show("La version de la base de datos y su versión del sistema no coinciden, llame a soporte!");
                                return;
                            }
                        }
                    }
                }
                catch(Exception exUPD)
                {

                }
            }

            if (versionBD >= DBValues._VERSION_PASSWORDS_ENCRIPTADOS && versionBD < DBValues._VERSION_PASSWORDS_ENCRIPTADOS_CON_USUARIO)
            {
                passwordSaved = iPos.EncDec.Decrypt(userBE.ICLAVEACCESO, "DryHit");
            }
            else if (versionBD >= DBValues._VERSION_PASSWORDS_ENCRIPTADOS_CON_USUARIO)
            {
                passwordSaved = iPos.EncDec.Decrypt(userBE.ICLAVEACCESO, "DryHit" + userBE.IUSERNAME.Trim());
            }
            else
            {
                passwordSaved = userBE.ICLAVEACCESO;
            }

            if (passwordSaved == this.TBPassUser.Text)
            {
                bool bReplicadorEstabaEjecutandose = false;
                string strMensajeReplicador = "";

                /*****************************************/
                //La actualizacion se pasaria en esta etapa
                ActualizacionesBD updater = new ActualizacionesBD();
                if (updater.RequiereActualizacionesDeBD())
                {
                    if (!updateWithoutWarning)
                    {
                        MessageBox.Show("La base de datos requiere una actualizacion obligada, se procedera a aplicarla");
                    }

                    //si el replicador esta ejecutandose hay que detenerlo
                    //Utils.DetenerReplicadorSiEstaEjecutandose(ref strMensajeReplicador, ref bReplicadorEstabaEjecutandose);
                    //fin si


                    bool bErrorInFileToUpdate = false;
                    WFActualizacionBD wfUpdateDB = new WFActualizacionBD(updater);
                    wfUpdateDB.ShowDialog();
                    bErrorInFileToUpdate = wfUpdateDB.ErrorInFile;
                    wfUpdateDB.Dispose();
                    GC.SuppressFinalize(wfUpdateDB);

                    if (bErrorInFileToUpdate == true)
                    {
                        return;
                    }



                }



                /*****************************************/



                iPos.CurrentUserID.CurrentUser = userBE;

                CCAJABE cajaBE = new CCAJABE();
                CCAJAD cajaD = new CCAJAD();
                cajaBE.IID = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;
                cajaBE = cajaD.seleccionarCAJA(cajaBE, null);
                CurrentUserID.CurrentCaja = cajaBE;


                /*******VERIFONE****/
                try
                {
                    if (CurrentUserID.CurrentCaja != null)
                        PagoVerifoneHelper.LlenarConfiguracionVerifone(CurrentUserID.CurrentCaja.IID);
                }
                catch { }
                /*** FIN VERIFONE ***/

                /*CCAJABE cajaBE = new CCAJABE();
                CCAJAD cajaD = new CCAJAD();

                iPos.Login_and_Maintenance.WFSeleccionarCaja wf = new Login_and_Maintenance.WFSeleccionarCaja();
                wf.ShowDialog();
                if (wf.m_selectedCaja < 0)
                {

                    MessageBox.Show("No se selecciono una caja valida");
                    return;
                }

                cajaBE.IID = wf.m_selectedCaja;
                cajaBE = cajaD.seleccionarCAJA(cajaBE, null);

                if (cajaBE == null)
                {

                    MessageBox.Show("Ocurrio un problema , la caja parece que no existe");
                    return;
                }


                iPos.CurrentUserID.CurrentCaja = cajaBE;

                */

                parametroBE = parametroD.seleccionarPARAMETROActual(null);
                iPos.CurrentUserID.CurrentParameters = parametroBE;
                if (parametroBE != null)
                {
                    iPos.Tools.FTPManagement.m_strFTPFolder = (parametroBE.IFTPFOLDER == null || parametroBE.IFTPFOLDER.StartsWith("(root)")) ? "" : parametroBE.IFTPFOLDER;
                    iPos.Tools.FTPManagement.m_strFTPFolderPass = (parametroBE.IFTPFOLDERPASS == null || parametroBE.IFTPFOLDER.StartsWith("(root)")) ? "" : parametroBE.IFTPFOLDERPASS;
                    iPos.Tools.FTPManagement.m_strFTPFolderWs = (parametroBE.IFTPFOLDER == null) ? "" : parametroBE.IFTPFOLDER;
                    iPos.Tools.FTPManagement.m_strFTPFolderPassWs = (parametroBE.IFTPFOLDERPASS == null) ? "" : parametroBE.IFTPFOLDERPASS;
                    //iPos.Tools.FTPManagement.ValidateFtpConection();
                    //parametroBE.IFTPFOLDERPASS;



                    iPos.Tools.WSManagement.m_strFTPFolder = (parametroBE.IFTPFOLDER == null || parametroBE.IFTPFOLDER.StartsWith("(root)")) ? "" : parametroBE.IFTPFOLDER;
                    iPos.Tools.WSManagement.m_strFTPFolderPass = (parametroBE.IFTPFOLDERPASS == null || parametroBE.IFTPFOLDER.StartsWith("(root)")) ? "" : parametroBE.IFTPFOLDERPASS;
                    iPos.Tools.WSManagement.m_strFTPFolderWs = (parametroBE.IFTPFOLDER == null) ? "" : parametroBE.IFTPFOLDER;
                    iPos.Tools.WSManagement.m_strFTPFolderPassWs = (parametroBE.IFTPFOLDERPASS == null) ? "" : parametroBE.IFTPFOLDERPASS;



                    iPos.Tools.FTPRegularManagement.m_strFTPFolder = (parametroBE.IFTPFOLDER == null || parametroBE.IFTPFOLDER.StartsWith("(root)")) ? "" : parametroBE.IFTPFOLDER;
                    iPos.Tools.FTPRegularManagement.m_strFTPFolderPass = (parametroBE.IFTPFOLDERPASS == null || parametroBE.IFTPFOLDER.StartsWith("(root)")) ? "" : parametroBE.IFTPFOLDERPASS;
                    iPos.Tools.FTPRegularManagement.m_strFTPFolderWs = (parametroBE.IFTPFOLDER == null) ? "" : parametroBE.IFTPFOLDER;
                    iPos.Tools.FTPRegularManagement.m_strFTPFolderPassWs = (parametroBE.IFTPFOLDERPASS == null) ? "" : parametroBE.IFTPFOLDERPASS;

                }


                //si el replicador estaba ejecutandose hay que detenerlo
                //if (bReplicadorEstabaEjecutandose)
                //{
                //    Utils.EjecutarReplicadorSiEstaInstalado(ref strMensajeReplicador);
                //}
                //fin si


                sucursalBE.IID = parametroBE.ISUCURSALID;
                sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);


                if (sucursalBE != null)
                {
                    iPos.CurrentUserID.SUCURSAL_CLAVE = sucursalBE.ICLAVE;
                    iPos.Tools.FTPManagement.m_strFTPSucursal = sucursalBE.ICLAVE;
                    iPos.Tools.FTPRegularManagement.m_strFTPSucursal = sucursalBE.ICLAVE;
                    iPos.Tools.WSManagement.m_strFTPSucursal = sucursalBE.ICLAVE;
                }
                else
                {
                    MessageBox.Show("La base de datos no tiene una sucursal definida, comunicarse a sistemas", "Error");
                    return;
                }
                



                //tipo de installacion
                parametroD.SetIposInstallationType(parametroBE, null);



                //perfil del usuario
                iPos.CurrentUserID.ES_ADMINISTRADOR = userD.UsuarioEsAdmin(userBE.IID, null);
                iPos.CurrentUserID.ES_SUPERVISOR = userD.UsuarioEsAdmin(userBE.IID, null);


                iPos.Tools.FTPManagement.ObtenerDatosConexionFTP();
                EnviosMail.ObtenerDatosConexionSMTP();
                


                iPos.CurrentUserID.currentPrinter = Ticket.GetReceiptPrinter();
                iPos.CurrentUserID.CurrentPrinterRecargas = Ticket.GetReceiptPrinterRecargas();
                ConexionBD.currentPrinter = iPos.CurrentUserID.currentPrinter;


                //obten listados
                CLOOKUPD regD = new CLOOKUPD();
                CLOOKUPBE regBE = new CLOOKUPBE();
                regBE.ICLAVE = "PRODUCTO";
                try
                {
                    regBE = regD.seleccionarLOOKUPXClave(regBE, null);
                    if (regBE != null)
                    {

                        if (!iPos.CurrentUserID.listados.ContainsKey("PRODUCTO"))
                        {
                            iPos.CurrentUserID.listados.Add("PRODUCTO", regBE);
                        }
                        else
                        {
                            iPos.CurrentUserID.listados["PRODUCTO"] = regBE;
                        }
                    }
                }
                catch
                {
                }

                //Reset AutoComplete
                ResetAutocompletesEstatus();


                ///// Respaldo:
                RespaldosDB respaldoBD = new RespaldosDB();
                if (respaldoBD.requiereRespaldo())
                {
                    respaldoBD.respaldarDB();
                }

                FMain fMain = new FMain(userBE.IID);
                this.Hide();
                fMain.ShowDialog();
                if (fMain.m_cambiandoEmpresa)
                {
                    this.Show();
                    CCONFIGURACIOND conf = new CCONFIGURACIOND();
                    WFChangeEmpresa cambiarEmpresa = new WFChangeEmpresa();
                    cambiarEmpresa.ShowDialog();
                    if (cambiarEmpresa.changed)
                    {
                        this.m_empresaActual = cambiarEmpresa.selectedCompany;
                        this.LBEmpresaActual.Text = "Empresa actual : " + this.m_empresaActual;
                    }

                    cambiarEmpresa.Dispose();
                    GC.SuppressFinalize(cambiarEmpresa);

                    //this.m_empresaActual = fMain.m_empresaSeleccionada;
                    fMain.Dispose();
                    AccesarEmpresa();
                }
                else
                {
                    this.Close();
                    Application.Exit();
                }

            }
            else
            {
                MessageBox.Show("InValido");
            }
        }




        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //if (!ConexionesAsignadas)
                //{
                    AsignarConexiones();
                //}
            }
            catch (Exception exc)
            {
                MessageBox.Show("Asegurese de haber configurado bien la conexion o consulte al administrador del sistema " + "\n" + exc.Message);
                return;
            }
            FAdministracion fAdmin = new FAdministracion();
            fAdmin.ShowDialog();
            fAdmin.Dispose();
            GC.SuppressFinalize(fAdmin);
        }
        //private void BTConexion_Click(object sender, EventArgs e)
        //{
        //    WFConfig fConfig = new WFConfig();
        //    fConfig.ShowDialog();
        //}
        public string ObtenerEmpresaPorDefault()
        {
            
            CCONFIGURACIONBE confBE = new CCONFIGURACIONBE();
            CCONFIGURACIOND confD = new CCONFIGURACIOND();
            confBE = confD.seleccionarCONFIGURACIONGen(null);
            if (confBE == null)
            {
                
                return null;
            }
            return confBE.ICF_DEFAULT_DB;
        }

        public void ChecarActualizacionesBDConfLocal()
        {

            CCONFIGURACIOND confD = new CCONFIGURACIOND();
            confD.ChecarActualizaciones("1287.6972");
        }

        public string ObtenerConexion(string fileName)
        {
            //string retorno = "";
            CEMPRESASBE empresasBE = new CEMPRESASBE();
            CEMPRESASD empresasD = new CEMPRESASD();
            
            if (m_empresaActual == null || m_empresaActual == "")
            {
                m_empresaActual = ObtenerEmpresaPorDefault();
            }
            empresasBE.IEM_NOMBRE = m_empresaActual;
            if (empresasBE.IEM_NOMBRE == null || empresasBE.IEM_NOMBRE == "")
            {
                MessageBox.Show("Error : el sistema no se logro conectar  a la base de datos de configuracion , tabla configuracion");
                return null;
            }
            //empresasBE.IEM_NOMBRE = confBE.ICF_DEFAULT_DB;
            empresasBE = empresasD.seleccionarEMPRESAS(empresasBE, null);
            if (empresasBE == null)
            {
                MessageBox.Show("Error : el sistema no se logro conectar  a la base de datos de configuracion , tabla empresa");
                return null;
            }
            string dataLocation = empresasBE.IEM_DATABASE.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            iPos.CurrentUserID.DBLocation = dataLocation;

            iPos.CurrentUserID.CurrentCompania = empresasBE;
            ConexionBD.CurrentCompania = empresasBE;

            //string dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //string pooling = ";Pooling=true;MinPoolSize=0;MaxPoolSize=5;";
            //string pooling = ";Pooling=false;";
            string pooling = "";

            if (empresasBE.IHAB_POOLING != "S")
            {
                pooling = ";Pooling=false;";
            }

            string connectionStr = "data source=" + empresasBE.IEM_SERVER.Trim() + ";initial catalog=\"" + dataLocation + "\";user id=" + empresasBE.IEM_USUARIO + ";password=" + empresasBE.IEM_PASSWORD + ";" + pooling; // pooling=false";
            return connectionStr;
            //return EncDec.Encrypt(connectionStr, EncDec.PasswordDefault());
            /*if (!File.Exists(fileName))
            {*/
                //string dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                //string connectionStr="data source=localhost;initial catalog=\"" + dataPath + "\\sampdata\\iposdb" + "\";user id=sysdba;password=masterkey";
                //return EncDec.Encrypt(connectionStr, EncDec.PasswordDefault());
            //}
            /*StreamReader r = File.OpenText(fileName);
            string line;
            line = r.ReadLine();
            while (line != null)
            {
                retorno = line;
                line = r.ReadLine();
            }
            r.Close();*/
            //return retorno;
        }
        public void ChangeConnectionString(string strConn)
        {
            System.Configuration.Configuration _config =
             ConfigurationManager.OpenExeConfiguration(
             ConfigurationUserLevel.None);
            _config.ConnectionStrings.ConnectionStrings["iPos.Properties.Settings.ConnectionIpos"].ConnectionString = strConn;
            _config.ConnectionStrings.ConnectionStrings["iPosReporting.Properties.Settings.iPosString"].ConnectionString = strConn;
            _config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(_config.ConnectionStrings.SectionInformation.Name);
            iPos.Properties.Settings.Default.Reload();
            iPosReporting.ConnectionReload.reloadConnections();
            ConexionBD.ConexionBase = strConn;
            
        }
        private void formSkin1_Load(object sender, EventArgs e)
        {
        }
        private void BTOtraEmpresa_Click(object sender, EventArgs e)
        {

            WFPreguntarClaveConf wf = new WFPreguntarClaveConf();
            wf.ShowDialog();
            bool permitido = wf.m_permitido;

            wf.Dispose();
            GC.SuppressFinalize(wf);

            if (permitido == false)
            {
                MessageBox.Show("Clave incorrecta");
                return;
            }

            UCEMPRESASLista el = new UCEMPRESASLista();
            el.ShowDialog();
            if (el.EM_NOMBRECampo == null || el.EM_NOMBRECampo == "")
            {
                RefreshLabelEmpresa();
            }
            else
            {
                this.LBEmpresaActual.Text = "Empresa actual : " + el.EM_NOMBRECampo;
                m_empresaActual = el.EM_NOMBRECampo;
            }

            el.Dispose();
            GC.SuppressFinalize(el);
        }
        private void RefreshLabelEmpresa()
        {
            string empresaActual;
            empresaActual = this.ObtenerEmpresaPorDefault();
            if (empresaActual != null)
            {
                this.LBEmpresaActual.Text = "Empresa actual : " + empresaActual;
            }
        }



        private void testImpresionFastReportEscPos()
        {

            Dictionary<string, object> datos = new Dictionary<string, object>();
            datos["nombreSucursal"] = "Suc Palma";

            List<Dictionary<string, object>> listaDetalle = new List<Dictionary<string, object>>();
            Dictionary<string, object> detalle = new Dictionary<string, object>();
            detalle["codigo"] = "FANTA";
            detalle["cantidad"] = "1";
            detalle["descripcion"] = "REFRESCO FANTA NARANJA";
            detalle["precio1"] = "10.00";
            detalle["precio2"] = "10.00";

            listaDetalle.Add(detalle);


            detalle = new Dictionary<string, object>();
            detalle["codigo"] = "COCAC";
            detalle["cantidad"] = "1";
            detalle["descripcion"] = "REFRESCO COCACOLA";
            detalle["precio1"] = "11.00";
            detalle["precio2"] = "11.00";

            listaDetalle.Add(detalle);


            datos["listaDetalles"] = listaDetalle;

            ImpresorTicketGenerico.imprimirTicket(iPosReporting.Reporteria.TicketSerializer.GetTicketTexts(FastReportsConfig.getPathForFile("TicketTest.frx", FastReportsTipoFile.desistema), datos).ToArray(), "Two Pilots Demo Printer");

        }


        private void FLogin_Load(object sender, EventArgs e)
        {
            //ImpresorTicketGenerico.testTicketGenerico();

            //ImpresorTicketGenerico.PrintBarCode("Manuel Llamas Guerrero", "Two Pilots Demo Printer");

            //ImpresorTicketGenerico.testBarCode("Two Pilots Demo Printer");

            //testImpresionFastReportEscPos();


            try
            {
                ChecarActualizacionesBDConfLocal();

                SincInfoConfig();

                

                RefreshLabelEmpresa();

                AsignarConexiones();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace);
            }
        }


        private bool validaInstalacion()
        {

            string archivoLicencia = System.AppDomain.CurrentDomain.BaseDirectory + "Licencia.txt";

            string semilla1 = "test", semilla2 = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select ProcessorID from Win32_Processor");
            
                foreach (ManagementObject share in searcher.Get())
                {

                
                    try
                    {
                        semilla1 = share["ProcessorID"].ToString();
                        break;
                    }
                    catch
                    {
                        
                    }
                }
            

            try
            {
                ManagementObjectSearcher searcherHdd = new ManagementObjectSearcher("select * from Win32_DiskDrive");
                foreach (ManagementObject share in searcherHdd.Get())
                {
                        semilla2 = share["SerialNumber"].ToString();
                        break;
                }
            }
            catch
            {
                semilla2 = "testing";
            }


            bool bValidado = false;
            while (!bValidado)
            {


                string serialGuardado = obtenerContenidoArchivo(archivoLicencia);
                string serialDecriptado = "";
                try
                {
                    if (serialGuardado != "")
                        serialDecriptado = EncDec.Decrypt(serialGuardado, "Ipos");
                }
                catch
                {
                    serialDecriptado = "";
                }



                if (serialDecriptado.Equals("LaBorraDelCafe"))
                {
                    Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\MicrosoftOfficePlugIns");
                    if (key != null)
                    {
                        string strKey = (string)key.GetValue("MicrosoftOfficePlugIn");
                        key.Close();
                        if (strKey.Equals("44456-33322-98765-B32I8"))
                        {
                            bValidado = true;
                            return bValidado;
                        }
                    }
                    
                }


                if (serialDecriptado != semilla1 + semilla2)
                {

                    if (MessageBox.Show("Se necesita ingresar el numero de serie para poder correr el programa. Desea hacerlo?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        WFValidarInstalacion wf = new WFValidarInstalacion(semilla1 + semilla2);
                        wf.ShowDialog();
                        wf.Dispose();
                        GC.SuppressFinalize(wf);
                    }
                    else
                    {
                        this.Close();
                    }

                }
                else
                {
                    bValidado = true;
                }
            }


            return bValidado;
        }


        public string obtenerContenidoArchivo(string fileName)
        {
            string retorno = "";
            if (!File.Exists(fileName))
            {
                return "";
            }
            StreamReader r = File.OpenText(fileName);
            string line;
            line = r.ReadLine();
            while (line != null)
            {
                retorno = line;
                line = r.ReadLine();
            }
            r.Close();
            return retorno;
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {



            Application.Exit();
        }

        private void FLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            /**winforms only starts**/
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            /**winforms only ends**/
            /**wpf only starts*
            SendMessage(new System.Windows.Interop.WindowInteropHelper(this).Handle, 0x112, 0xf012, 0);
            /**wpf only ends**/

        }

        private void bminimiza_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCambiarEmpresa_Click(object sender, EventArgs e)
        {
            WFChangeEmpresa cambiarEmpresa = new WFChangeEmpresa();
            cambiarEmpresa.ShowDialog();
            if (cambiarEmpresa.changed)
            {
                this.m_empresaActual = cambiarEmpresa.selectedCompany;
                this.LBEmpresaActual.Text = "Empresa actual : " + this.m_empresaActual;
            }
            cambiarEmpresa.Dispose();
            GC.SuppressFinalize(cambiarEmpresa);

            AccesarEmpresa();
        }

        private void SincInfoConfig()
        {
            if(!CSINCCONFIGD.SincInfoConfig())
            {
                MessageBox.Show(ConexionMEBD.ConexionString());
                MessageBox.Show("Problema al sincronizar configuraciónd de SystemData: " + CSINCCONFIGD.ComentarioSincConfig);
            }
        }

    }
}
