
using BindingModels;
using IposV3.Model;
using Caliburn.Micro;
using Controllers;
using Controllers.Controller;
using IposV3Sync.Controllers.Controller;
using DataAccess;
using Models.CatalogSelector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IposV3Sync.ViewModels.Threads;
using IposV3.Services;
using System.IO;
using IposV3Sync.BindingModel;
using ViewModels.BaseScreen;

namespace IposV3Sync.ViewModels
{


    public class ConfiguracionsyncItemViewModel : ConfiguracionsyncItemViewModelGenerated
    {

        private readonly GlobalController globalControllerProvider;

        public IposV3.Model.Syncr.Configuracionsync? ConfiguracionsyncPrevia { get; protected set; }

        protected ConfiguracionsyncItemViewModel(string mode, IConfiguracionsyncControllerProvider provider, SelectorWebController selectorProvider, GlobalController globalControllerProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(mode, provider, selectorProvider, aggregator, winManager, messageBoxService)
        {

            this.globalControllerProvider = globalControllerProvider;
        }

        public void ResguardaCurrentConfiguracionsync()
        {

            this.ConfiguracionsyncPrevia = GlobalVariable.CurrentSession?.CurrentConfiguracionsync;
        }

        public void ReponCurrentConfiguracion()
        {

            SetConfiguracionsyncInGlobal(this.ConfiguracionsyncPrevia);
        }

        protected void SetConfiguracionsyncInGlobal(IposV3.Model.Syncr.Configuracionsync? configsync)
        {
            if (configsync != null)
            {
                GlobalSession bufferSession = new GlobalSession();
                globalControllerProvider.llenarSesionPorConfiguracionsync(configsync, ref bufferSession);
                GlobalVariable.CurrentSession = bufferSession;

                ConfigurationManager.AppSettings.Set("itemEmpresaIdForEditing", GlobalVariable.CurrentSession.Empresaid.ToString());
                ConfigurationManager.AppSettings.Set("itemSucursalIdForEditing", GlobalVariable.CurrentSession.Sucursalid.ToString());

            }
        }



        public virtual ConfigurationAction? ContinueNavigationHandler(string currentStepTitle, string nextStepTitle, out bool cancel)
        {
            cancel = false;
            return null;
        }


        protected override void fillCatalogConfiguration()
        {


            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                    };
            lstCatalogDef = new List<CatalogDef>()
            {
                //new CatalogDef("Empresa"),
                //new CatalogDef("Sucursal")
            };

        }


        


        public void fillCatalogAfterStep(string currentStepTitle)
        {

            if (currentStepTitle == "Base local")
            {
                fillCatalog("Empresa", null, null);
            }
            else if (currentStepTitle == "Empresa")
            {

                fillCatalog("Sucursal", this.Configuracionsync!.Empresaid, null);
            }
        }

        protected void fillCatalog(string catalogName, long? empresaid, long? sucursalid)
        {
            var lstCatalogDefBuffer = new List<CatalogDef>()
            {
                new CatalogDef(catalogName)
            };
            var CatalogsBuffer = selectorProvider.ObtainCatalogs(lstCatalogDefBuffer, new BaseParam(empresaid, sucursalid));


            if(Catalogs == null)
            {
                Catalogs = new Dictionary<string, List<BaseSelector>?>();
            }

            if (CatalogsBuffer != null)
            {
                foreach (var catalogDef in CatalogsBuffer)
                {
                    if (Catalogs.ContainsKey(catalogDef.Key))
                    {
                        Catalogs[catalogDef.Key] = catalogDef.Value;
                    }
                    else
                    {
                        Catalogs.Add(catalogDef.Key, catalogDef.Value);
                    }

                }
            }
            NotifyOfPropertyChange("Catalogs");
        }


        public override void SuccessEditActions(ConfiguracionsyncBindingModel record)
        {
            //var eventParam = new LSTP();
            //eventParam.fillFields(true, true,
            //                                                    BProcessSuccess ?
            //                                                                    new MessageToUserSimple("Exito", "Se actualizo el registro", "Success") :
            //                                                                    new MessageToUserSimple("Error", "Occurrio un error ", "Error"));

            //aggregator.PublishOnUIThread(eventParam);
            
            if(BProcessSuccess)
            {
                this.showPopUpMessage(new MessageToUserSimple("Exito", "Se actualizo el registro", "Success"));
            }
            else
            {

                this.showPopUpMessage(new MessageToUserSimple("Error", "Occurrio un error ", "Error"));
            }

            aggregator.PublishOnCurrentThreadAsync(new NavigationParameter(null, false, true));
        }


    }


    public class ConfiguracionsyncShowViewModel : ConfiguracionsyncItemViewModel
    {
        public ConfiguracionsyncShowViewModel(IConfiguracionsyncControllerProvider provider, SelectorWebController selectorProvider, GlobalController globalControllerProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, selectorProvider, globalControllerProvider, aggregator, winManager, messageBoxService)
        {
        }

        public override ConfigurationAction? ContinueNavigationHandler(string currentStepTitle, string nextStepTitle, out bool cancel)
        {
            cancel = false;
            return null;
        }
    }

    public class ConfiguracionsyncEditViewModel : ConfiguracionsyncItemViewModel
    {
        //private SyncInterSucursalThread syncInterSucursalThread;
        ImpoExpoController impoExpoProvider;
        ReplicacionController replicacionProvider;
        private OperationsContextFactory _operationsContextFactory;

        public ConfiguracionsyncEditViewModel(IConfiguracionsyncControllerProvider provider, ImpoExpoController impoExpoProvider, ReplicacionController replicacionProvider,
                                    OperationsContextFactory operationsContextFactory,
                                    SelectorWebController selectorProvider, GlobalController globalControllerProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, selectorProvider, globalControllerProvider, aggregator, winManager, messageBoxService)
        {
            this.impoExpoProvider = impoExpoProvider;
            this.replicacionProvider = replicacionProvider;
            this._operationsContextFactory = operationsContextFactory;
        }



        public override ConfigurationAction ContinueNavigationHandler(string currentStepTitle, string nextStepTitle, out bool cancel)
        {
            cancel = false;

            if (Configuracionsync == null)
                throw new Exception("Configuration sync es nulo.");

            if (currentStepTitle == "Base local")
            {
                string connectionStr = "Server=" + Configuracionsync.Serverlocal + ";Port=" + Configuracionsync.Portlocal + ";Database=" + Configuracionsync.Dblocal + ";Uid=" + Configuracionsync.Usuariolocal + ";Pwd=" + Configuracionsync.Passwordlocal + ";";
                return new ConfigurationAction() { Action = "cambiar_conexion", Parameters = new List<string>() { connectionStr } };
            }
            else if (currentStepTitle == "Empresa")
            {
                SetConfiguracionsyncInGlobal(this.Configuracionsync.Item);
            }
            else if (currentStepTitle == "Sucursal")
            {
                SetConfiguracionsyncInGlobal(this.Configuracionsync.Item);
            }
            else if (currentStepTitle == "Replicacion base")
            {
                SetConfiguracionsyncInGlobal(this.Configuracionsync.Item);
            }
            else if (currentStepTitle == "Sync Sucursales")
            {

                if (Configuracionsync.Activo == null)
                    Configuracionsync.Activo = "S";

                this.Accept();
            }

            return new ConfigurationAction() { Action = "None", Parameters = null };
        }

        public void StartSync()
        {
            //Proceso del hilo
            //syncInterSucursalThread = new SyncInterSucursalThread(this.impoExpoProvider, _applicationDbContext);

            try
            {
                //syncInterSucursalThread.StartThread();
                Test();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        //---------------testing

        private void Test()
        {
            //string expoBufferFullPath = ImpoExpoConstants.ImpoExpoBasePath + ImpoExpoConstants.FileLocalLocation_CatalogsExpo_FolderBuffer;
            //string expoZipExpoFile = ImpoExpoConstants.ImpoExpoBasePath + ImpoExpoConstants.FileLocalLocation_CatalogsExpo_Folder + "\\" + ImpoExpoConstants.FileLocalLocation_CatalogsExpo_FileNameZip;


            //if (Directory.Exists(expoBufferFullPath))
            //    DeleteDirectory(expoBufferFullPath);

            //Directory.CreateDirectory(expoBufferFullPath);


            //ImpoExpoService.ExportLinea(5, 4, "linea", expoBufferFullPath, _applicationDbContext);
            //(new LineaImpoExpoService()).Import(5, 4, null, "linea", expoBufferFullPath, _applicationDbContext);

            //(new MarcaImpoExpoService()).Export(5, 4, "marca", expoBufferFullPath, _applicationDbContext);
            //(new MarcaImpoExpoService()).Import(5, 4, null, "marca", expoBufferFullPath, _applicationDbContext);

            //impoExpoProvider.ExportCatalogs(5, 4);

            //impoExpoProvider.ImportCatalogs(5, 4);
            //impoExpoProvider.ImportCatalogsFromServer(5, 4,
            //                                     "Compania_1/prec.zip", 1, 0, "linea", DateTime.Now);

            //string importPath = ImpoExpoConstants.ImpoExpoBasePath;
            //impoExpoProvider.ImportarArchivosPendientes(5, 4, "Compania_1", "DaoTest", 1, importPath);
            //impoExpoProvider.ExportCatalogs(5, 4, "Compania_1", "DaoTest");
            //impoExpoProvider.ImportarArchivosPendientes(5, 4, "Compania_1", "DaoTest", 1, importPath);
            //impoExpoProvider.ExportTraslado(5, 4, "DaoTest", "Compania_1", 408, null);

            string replicationPath = ImpoExpoConstants.ImpoExpoBasePath + ImpoExpoConstants.FileLocalLocation_ReplTemp_Expo;
            replicacionProvider.ReplicateData(5, 4, "Compania_1", "DaoTest", 1, replicationPath);

            //var testLst =  replicacionProvider.ListaTablasAReplicar(5,4);
            //Console.WriteLine(testLst.Count);
        }

        private void DeleteDirectory(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(target_dir, false);
        }


        //--------------- fin testing

    }

    public class ConfiguracionsyncAddViewModel : ConfiguracionsyncItemViewModel
    {

        public ConfiguracionsyncAddViewModel(IConfiguracionsyncControllerProvider provider, 
                                             SelectorWebController selectorProvider, GlobalController globalControllerProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, selectorProvider, globalControllerProvider, aggregator, winManager, messageBoxService)
        {
        }



        public override ConfigurationAction ContinueNavigationHandler(string currentStepTitle, string nextStepTitle, out bool cancel)
        {
            cancel = false;

            if (Configuracionsync == null)
                throw new Exception("Configuration sync es nulo.");
  
            if (currentStepTitle == "Base local")
            {
                string connectionStr = "Server=" + Configuracionsync.Serverlocal + ";Port=" + Configuracionsync.Portlocal + ";Database=" + Configuracionsync.Dblocal + ";Uid=" + Configuracionsync.Usuariolocal + ";Pwd=" + Configuracionsync.Passwordlocal + ";";
                return new ConfigurationAction() { Action = "cambiar_conexion", Parameters = new List<string>() { connectionStr } };
            }
            else if (currentStepTitle == "Empresa")
            {
                SetConfiguracionsyncInGlobal(this.Configuracionsync.Item);
            }
            else if (currentStepTitle == "Sucursal")
            {
                SetConfiguracionsyncInGlobal(this.Configuracionsync.Item);
            }
            else if (currentStepTitle == "Replicacion base")
            {
                SetConfiguracionsyncInGlobal(this.Configuracionsync.Item);
            }
            else if (currentStepTitle == "Sync Sucursales")
            {
                this.Accept();
            }

            return new ConfigurationAction() { Action = "None", Parameters = null };
        }


    }

}

