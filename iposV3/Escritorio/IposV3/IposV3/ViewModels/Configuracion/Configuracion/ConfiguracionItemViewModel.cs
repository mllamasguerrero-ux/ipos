
using BindingModels;
using IposV3.Model;
using IposV3.BindingModel;
using Caliburn.Micro;
using Controllers;
using Controllers.Controller;
//using IposV3.Controllers.Controller;
//using DataAccess;
using IposV3.ViewModels.BaseScreen;
using ViewModels.BaseScreen;
using Models.CatalogSelector; 
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace IposV3.ViewModels
{


    public abstract class ConfiguracionItemViewModel : IposV3.ViewModels.BaseScreen.BaseScreen
    {
        protected readonly ConfiguracionWebController? provider;
        private readonly GlobalWebController? globalControllerProvider;
        protected readonly IEventAggregator? aggregator;

        public ConfiguracionBindingModel? Configuracion { get; set; }

        public bool? BIsReadOnly { get; protected set; }

        public bool? BProcessSuccess { get; protected set; }

        public Configuracion? ConfiguracionPrevia { get; protected set; }



        private int empresaExistente = 1;
        public int EmpresaExistente
        {
            get => empresaExistente;
            set
            {
                empresaExistente = value; NotifyOfPropertyChange("EmpresaExistente"); NotifyOfPropertyChange("ExisteEmpresa");
            }
        }

        public bool ExisteEmpresa
        {
            get => empresaExistente == 1;
        }





        private int sucursalExistente = 1;
        public int SucursalExistente
        {
            get => sucursalExistente;
            set
            {
                sucursalExistente = value; NotifyOfPropertyChange("SucursalExistente"); NotifyOfPropertyChange("ExisteSucursal");
            }
        }

        public bool ExisteSucursal
        {
            get => sucursalExistente == 1;
        }




        private int cajaExistente = 1;
        public int CajaExistente
        {
            get => cajaExistente;
            set
            {
                cajaExistente = value; NotifyOfPropertyChange("CajaExistente"); NotifyOfPropertyChange("ExisteCaja");
            }
        }

        public bool ExisteCaja
        {
            get => cajaExistente == 1;
        }



        private EmpresaBindingModel empresaNueva;
        public EmpresaBindingModel EmpresaNueva
        {
            get => empresaNueva;
            set
            {
                empresaNueva = value; NotifyOfPropertyChange("EmpresaNueva");
            }
        }



        private SucursalBindingModel sucursalNueva;
        public SucursalBindingModel SucursalNueva
        {
            get => sucursalNueva;
            set
            {
                sucursalNueva = value; NotifyOfPropertyChange("SucursalNueva");
            }
        }



        private CajaBindingModel cajaNueva;
        public CajaBindingModel CajaNueva
        {
            get => cajaNueva;
            set
            {
                cajaNueva = value; NotifyOfPropertyChange("CajaNueva");
            }
        }


        private UsuarioBindingModel usuarioNuevo;
        public UsuarioBindingModel UsuarioNuevo
        {
            get => usuarioNuevo;
            set
            {
                usuarioNuevo = value; NotifyOfPropertyChange("UsuarioNuevo");
            }
        }




        private bool crearBDSiNoExiste = false;
        public bool CrearBDSiNoExiste
        {
            get => crearBDSiNoExiste;
            set
            {
                crearBDSiNoExiste = value; NotifyOfPropertyChange("CrearBDSiNoExiste");
            }
        }



        private string rutaInstalacionPostgresql = "C:\\Program Files\\PostgreSQL\\11\\bin\\";
        public string RutaInstalacionPostgresql
        {
            get => rutaInstalacionPostgresql;
            set
            {
                rutaInstalacionPostgresql = value; NotifyOfPropertyChange("RutaInstalacionPostgresql");
            }
        }



        protected ConfiguracionItemViewModel(ConfiguracionWebController provider, SelectorWebController selectorProvider, GlobalWebController? globalControllerProvider, 
                                            IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) : base(selectorProvider, winManager, messageBoxService)
        {
            this.provider = provider;
            this.aggregator = aggregator;
            this.BIsReadOnly = false;
            this.globalControllerProvider = globalControllerProvider;

            this.empresaNueva = new EmpresaBindingModel();
            this.sucursalNueva = new SucursalBindingModel();
            this.cajaNueva = new CajaBindingModel();
            this.usuarioNuevo = new UsuarioBindingModel();

            //test
            sucursalNueva.Clave = "MATRIZ";
            sucursalNueva.Nombre = "SUCURSAL MATRIZ";
            //usuario nuevo
            usuarioNuevo.UsuarioNombre= "sistemas";
            usuarioNuevo.Nombre = "sistemas";
            usuarioNuevo.Nombres = "sistemas";
            usuarioNuevo.Apellidos = "sistemas";
            usuarioNuevo.Contrasena = "kabu";
            //caja
            cajaNueva.Clave = "PRINCIPAL";
            cajaNueva.Nombre = "PRINCIPAL";
            cajaNueva.Nombreimpresora = "IposPrinter3";


            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("Configuracion","Empresa","Empresaid", "Empresaclave", "Empresanombre","IposV3.ViewModels.EmpresaListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Configuracion","Sucursal","Sucursalid", "Sucursalclave", "Sucursalnombre","IposV3.ViewModels.SucursalListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Configuracion","Caja","Cajaid", "Cajaclave", "Cajanombre","IposV3.ViewModels.CajaListViewModel","SelectedItem","Clave")
                                    };
            lstCatalogDef = new List<CatalogDef>() { };


            if (!lstCatalogDef.Any(y => y.CatalogName == "Empresa"))
                lstCatalogDef.Add(new CatalogDef("Empresa"));

            if (!lstCatalogDef.Any(y => y.CatalogName == "Sucursal"))
                lstCatalogDef.Add(new CatalogDef("Sucursal"));

            if (!lstCatalogDef.Any(y => y.CatalogName == "Caja"))
                lstCatalogDef.Add(new CatalogDef("Caja"));

            //Catalogs = selectorProvider.ObtainCatalogs(lstCatalogDef,new Model.BaseParam(GlobalVariable.CurrentSession!.Empresaid, GlobalVariable.CurrentSession.Sucursalid));
        }

        public void ResguardaCurrentConfiguracion()
        {

            if(GlobalVariable.CurrentSession != null)
                this.ConfiguracionPrevia = GlobalVariable.CurrentSession.CurrentConfiguracion;
        }

        public void ReponCurrentConfiguracion()
        {
            if(this.ConfiguracionPrevia != null)
                SetConfiguracionInGlobal(this.ConfiguracionPrevia);
        }

        protected void SetConfiguracionInGlobal(Configuracion? config)
        {
            if (config != null)
            {
                GlobalSession bufferSession = new GlobalSession();
                globalControllerProvider?.llenarSesionPorConfiguracion(config, ref bufferSession); //null
                GlobalVariable.CurrentSession = bufferSession;

                ConfigurationManager.AppSettings.Set("itemEmpresaIdForEditing", GlobalVariable.CurrentSession.Empresaid.ToString());
                ConfigurationManager.AppSettings.Set("itemSucursalIdForEditing", GlobalVariable.CurrentSession.Sucursalid.ToString());

            }
        }


        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            ScreenExtensions.TryActivateAsync(this);
        }

       
        public virtual void Back()
        {
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(null, false, true));
        }



        public void MigrateCurrentDatabase()
        {
            try
            {
                provider!.MigrateDataBase(CrearBDSiNoExiste, rutaInstalacionPostgresql, this.Configuracion!);

                if (this.Catalogs == null)
                    this.Catalogs = new Dictionary<string, List<BaseSelector>?>();


                Task.Run(async () =>
                {
                    this.Catalogs["Empresa"] = await this.selectorProvider.obtainCatalog(this.lstCatalogDef![0], new Model.BaseParam(null, null));
                }).Wait();

            }
            catch(Exception ex)
            {

                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
                throw;
            }
               
        }

        public abstract void Accept();
        public abstract void Cancel();


        public abstract bool CanEmpresaid { get; }

        public abstract bool CanSucursalid { get; }

        public abstract bool CanId { get; }

        public abstract ConfigurationAction ContinueNavigationHandler(string currentStepTitle, string nextStepTitle, out bool cancel);



    }

    public class ConfiguracionAddViewModel : ConfiguracionItemViewModel
    {

        public ConfiguracionAddViewModel(ConfiguracionWebController provider, SelectorWebController selectorProvider, GlobalWebController globalControllerProvider,
                                   IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) : base(provider, selectorProvider, globalControllerProvider, aggregator, winManager, messageBoxService) {
            Configuracion = new ConfiguracionBindingModel();
            //Configuracion.Creadopor_userid = long.Parse(ConfigurationManager.AppSettings.Get("itemUserIdForEditing"));
            //Configuracion.Empresaid = long.Parse(ConfigurationManager.AppSettings.Get("itemEmpresaIdForEditing"));
            //Configuracion.Sucursalid = long.Parse(ConfigurationManager.AppSettings.Get("itemSucursalIdForEditing"));

            //test
            Configuracion.Nombre = "ipos_test_restore";
            Configuracion.Usuario = "postgres";
            Configuracion.Password = "Twincept.l";
            Configuracion.Servidor = "localhost";
            Configuracion.Puerto = "5432";
            Configuracion.Database = "ipos_test_restore";


            Configuracion.PendingChange  += CatalogField_PropertyChanging;
        }

        public override void Accept()
        {
            if (Configuracion == null)
                return;

            Configuracion.Creado = DateTime.Now;
            Configuracion.Modificado = DateTime.Now;

            try
            {
            	provider?.Insert(Configuracion);
                BProcessSuccess = true;
                
                aggregator.PublishOnUIThreadAsync(new ConfiguracionListVMEventParameters(true));
                aggregator.PublishOnUIThreadAsync(new NavigationParameter(null, false, true));
            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }
        }

        public override void Cancel()
        {
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(null, false, true));
        }


        public override ConfigurationAction ContinueNavigationHandler(string currentStepTitle, string nextStepTitle, out bool cancel)
        {
            cancel = false;

           if(currentStepTitle == "Base")
            {
                //cancel = true;
                //showPopUpMessage("Test ", "No se enviara nada", "Error");
                string connectionStr = "Server=" + Configuracion!.Servidor + ";Port=" + Configuracion!.Puerto + ";Database=" + Configuracion!.Database + ";Uid=" + Configuracion!.Usuario + ";Pwd=" + Configuracion.Password + ";Include Error Detail=true;";
               return new ConfigurationAction() { Action = "cambiar_conexion", Parameters = new List<string>() { connectionStr } };
            }
           else if(currentStepTitle == "Empresa")
            {

                if(!ExisteEmpresa)
                {
                    if (string.IsNullOrEmpty(EmpresaNueva.Clave) || string.IsNullOrEmpty(EmpresaNueva.Nombre))
                    {
                        cancel = true;
                        this.showPopUpMessage("Error", "Debe de escribir la clave y el nombre de la empresa nueva ", "Error");
                    }
                    else
                    {
                        try
                        {
                            EmpresaBindingModel? empresaNueva = null;


                            Task.Run(async () =>
                            {
                                empresaNueva = await provider!.CrearEmpresa(EmpresaNueva);

                            }).Wait();

                            this.Configuracion!.Empresaid = empresaNueva!.Id;
                            this.Configuracion!.Empresaclave = empresaNueva.Clave;
                            this.Configuracion!.Empresanombre = empresaNueva.Nombre;
                            SetConfiguracionInGlobal(this.Configuracion?.Item);
                        }
                        catch(Exception ex)
                        {
                            this.showPopUpMessage("Error", "Error al crear la empresa " + ex.Message, "Error");
                        }
                    }
                }
                else
                {
                    if (this.Configuracion!.Empresaid == null )
                    {
                        cancel = true;
                        this.showPopUpMessage("Error", "Debe de escribir la clave y el nombre de la empresa nueva ", "Error");
                    }

                    SetConfiguracionInGlobal(this.Configuracion?.Item);
                }

                if(!cancel)
                {

                    Task.Run(async () =>
                    {
                        this.Catalogs!["Sucursal"] = await this.selectorProvider.obtainCatalog(this.lstCatalogDef![1], new Model.BaseParam(this.Configuracion!.Empresaid, null));

                    }).Wait();
                }
            }
            else if (currentStepTitle == "Sucursal")
            {
                if (!ExisteSucursal)
                {
                    if (string.IsNullOrEmpty(SucursalNueva.Clave) || string.IsNullOrEmpty(SucursalNueva.Nombre))
                    {
                        cancel = true;
                        this.showPopUpMessage("Error", "Debe de escribir la clave y el nombre de la sucursal nueva ", "Error");
                    }
                    else if (string.IsNullOrEmpty(UsuarioNuevo.UsuarioNombre) || string.IsNullOrEmpty(UsuarioNuevo.Contrasena))
                    {
                        cancel = true;
                        this.showPopUpMessage("Error", "Debe de escribir la clave y el password del usuario administrador", "Error");
                    }
                    else
                    {
                        try
                        {
                            SucursalNueva.EmpresaId = this.Configuracion!.Empresaid!.Value;


                            SucursalBindingModel sucursalNueva = new SucursalBindingModel();

                            Task.Run(async () =>
                            {
                                var buffer = await provider!.CrearSucursal(SucursalNueva);
                                if (buffer == null)
                                    throw new Exception("No se pudo crear el usuario");

                                sucursalNueva = buffer!;

                            }).Wait();

                            UsuarioNuevo.EmpresaId = this.Configuracion!.Empresaid!.Value;
                            UsuarioNuevo.SucursalId = sucursalNueva.Id;



                            UsuarioBindingModel usuarioNuevo = new UsuarioBindingModel();

                            Task.Run(async () =>
                            {
                                var buffer = await provider!.CrearUsuario(UsuarioNuevo);
                                if (buffer == null)
                                    throw new Exception("No se pudo crear el usuario");

                                usuarioNuevo = buffer!;

                            }).Wait();


                            CajaNueva.EmpresaId = this.Configuracion!.Empresaid!.Value;
                            CajaNueva.SucursalId = sucursalNueva.Id;

                            Task.Run(async () =>
                            {

                                await provider!.CrearCaja(CajaNueva);

                                await provider!.CrearUnidadesDefault(SucursalNueva);

                                await provider!.CrearAlmacenDefault(SucursalNueva);

                                await provider!.CrearClientesDefault(SucursalNueva);

                                await provider!.CrearProveedorDefault(SucursalNueva);

                                await provider!.CrearMarcaDefault(SucursalNueva);

                                await provider!.CrearLineaDefault(SucursalNueva);

                                await provider!.CrearProductoDefault(SucursalNueva);

                                await provider!.CrearParametroDefault(this.Configuracion!.Empresaid!.Value, sucursalNueva.Id!.Value);
                            }).Wait();




                            this.Configuracion!.Sucursalid = sucursalNueva.Id;
                            this.Configuracion!.Sucursalclave = sucursalNueva.Clave;
                            this.Configuracion!.Sucursalnombre = sucursalNueva.Nombre;
                            SetConfiguracionInGlobal(this.Configuracion?.Item);
                        }
                        catch (Exception ex)
                        {
                            this.showPopUpMessage("Error", "Error al crear la sucursal " + ex.Message, "Error");
                        }
                    }
                }
                else
                {
                    SetConfiguracionInGlobal(this.Configuracion?.Item);
                }

                if (!cancel)
                {

                    Task.Run(async () =>
                    {
                        this.Catalogs!["Caja"] = await this.selectorProvider.obtainCatalog(this.lstCatalogDef![2], new Model.BaseParam(this.Configuracion!.Empresaid, this.Configuracion!.Sucursalid));

                    }).Wait();
                }
            }
            else if (currentStepTitle == "Caja")
            {
                if (!ExisteCaja)
                {
                    if (string.IsNullOrEmpty(CajaNueva.Clave) || string.IsNullOrEmpty(CajaNueva.Nombre))
                    {
                        cancel = true;
                        this.showPopUpMessage("Error", "Debe de escribir la clave y el nombre de la caja nueva ", "Error");
                    }
                    else
                    {
                        try
                        {
                            CajaNueva.EmpresaId = this.Configuracion!.Empresaid!.Value;
                            CajaNueva.SucursalId = this.Configuracion!.Sucursalid!.Value;


                            CajaBindingModel cajaNueva = new CajaBindingModel();

                            Task.Run(async () =>
                            {
                                var buffer = await provider!.CrearCaja(CajaNueva);
                                if (buffer == null)
                                    throw new Exception("No se pudo crear la caja");

                                cajaNueva = buffer!;

                            }).Wait();

                            this.Configuracion!.Cajaid = cajaNueva.Id;
                            this.Configuracion!.Cajaclave = cajaNueva.Clave;
                            this.Configuracion!.Cajanombre = cajaNueva.Nombre;
                            SetConfiguracionInGlobal(this.Configuracion?.Item);
                        }
                        catch (Exception ex)
                        {
                            this.showPopUpMessage("Error", "Error al crear la sucursal " + ex.Message, "Error");
                        }
                    }
                }
                else
                {

                    SetConfiguracionInGlobal(this.Configuracion?.Item);
                }

            }
            else if (currentStepTitle == "General")
            {
                this.Accept();
            }

            return new ConfigurationAction() { Action = "None", Parameters = null };
        }


        public override bool CanEmpresaid
        {
            get { return true; }
        }

        public override bool CanSucursalid
        {
            get { return true; }
        }

        public override bool CanId
        {
            get { return true; }
        }






    }

    public class ConfiguracionEditViewModel : ConfiguracionItemViewModel, IHandle<ConfiguracionItemVMInitialParameters>
    {
        public ConfiguracionEditViewModel(ConfiguracionWebController provider,
                                    SelectorWebController selectorProvider, GlobalWebController globalControllerProvider,
                                    IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) : base(provider, selectorProvider, globalControllerProvider, aggregator, winManager, messageBoxService)
        {
            ConfiguracionBindingModel item = new ConfiguracionBindingModel();

            aggregator.SubscribeOnUIThread(this);

        }

        public Task HandleAsync(ConfiguracionItemVMInitialParameters initialParameters, CancellationToken cancellationToken)
        {
            ConfiguracionBindingModel item = new ConfiguracionBindingModel();
            

            item.Id = initialParameters.Id;
            //item.Sucursalid = long.Parse(ConfigurationManager.AppSettings.Get("itemSucursalIdForEditing")); 
            //item.Empresaid = long.Parse(ConfigurationManager.AppSettings.Get("itemEmpresaIdForEditing"));
            

            Task.Run(async () =>
            {
                Configuracion = await provider!.GetById(item);
            }).Wait();

            if (Configuracion == null)
            {
                Configuracion = new ConfiguracionBindingModel();

            }

            Configuracion.PendingChange += CatalogField_PropertyChanging;
            Configuracion.Validate();
            return Task.CompletedTask;
        }

        public override void Accept()
        {

            Configuracion!.Modificadopor_userid = 3; // long.Parse(ConfigurationManager.AppSettings.Get("itemUserIdForEditing"));
            
            try
            {
		        provider!.Update(Configuracion);
                BProcessSuccess = true;
                
                aggregator.PublishOnUIThreadAsync(new ConfiguracionListVMEventParameters(true));
                aggregator.PublishOnUIThreadAsync(new NavigationParameter(null, false, true));
            }
            catch(Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }

        }

        public override void Cancel()
        {
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(null, false, true));
        }




        public override ConfigurationAction ContinueNavigationHandler(string currentStepTitle, string nextStepTitle, out bool cancel)
        {
            cancel = false;

            if (currentStepTitle == "Base")
            {
                //cancel = true;
                //showPopUpMessage("Test ", "No se enviara nada", "Error");
                string connectionStr = "Server=" + Configuracion!.Servidor + ";Port=" + Configuracion!.Puerto + ";Database=" + Configuracion!.Database + ";Uid=" + Configuracion!.Usuario + ";Pwd=" + Configuracion.Password + ";Include Error Detail=true;";
                return new ConfigurationAction() { Action = "cambiar_conexion", Parameters = new List<string>() { connectionStr } };
            }
            else if (currentStepTitle == "Empresa")
            {

                if (!ExisteEmpresa)
                {
                    if (string.IsNullOrEmpty(EmpresaNueva.Clave) || string.IsNullOrEmpty(EmpresaNueva.Nombre))
                    {
                        cancel = true;
                        this.showPopUpMessage("Error", "Debe de escribir la clave y el nombre de la empresa nueva ", "Error");
                    }
                    else
                    {
                        try
                        {
                            EmpresaBindingModel? empresaNueva = null;


                            Task.Run(async () =>
                            {
                                empresaNueva = await provider!.CrearEmpresa(EmpresaNueva);

                            }).Wait();


                            this.Configuracion!.Empresaid = empresaNueva!.Id;
                            this.Configuracion!.Empresaclave = empresaNueva.Clave;
                            this.Configuracion!.Empresanombre = empresaNueva.Nombre;
                            SetConfiguracionInGlobal(this.Configuracion?.Item);
                        }
                        catch (Exception ex)
                        {
                            this.showPopUpMessage("Error", "Error al crear la empresa " + ex.Message, "Error");
                        }
                    }
                }
                else
                {
                    if (this.Configuracion!.Empresaid == null)
                    {
                        cancel = true;
                        this.showPopUpMessage("Error", "Debe de escribir la clave y el nombre de la empresa nueva ", "Error");
                    }

                    SetConfiguracionInGlobal(this.Configuracion?.Item);
                }

                if (!cancel)
                {

                    Task.Run(async () =>
                    {
                        this.Catalogs!["Sucursal"] = await this.selectorProvider.obtainCatalog(this.lstCatalogDef![1], new Model.BaseParam(this.Configuracion!.Empresaid, null));

                    }).Wait();
                }
            }
            else if (currentStepTitle == "Sucursal")
            {
                if (!ExisteSucursal)
                {
                    if (string.IsNullOrEmpty(SucursalNueva.Clave) || string.IsNullOrEmpty(SucursalNueva.Nombre))
                    {
                        cancel = true;
                        this.showPopUpMessage("Error", "Debe de escribir la clave y el nombre de la sucursal nueva ", "Error");
                    }
                    else if (string.IsNullOrEmpty(UsuarioNuevo.UsuarioNombre) || string.IsNullOrEmpty(UsuarioNuevo.Contrasena))
                    {
                        cancel = true;
                        this.showPopUpMessage("Error", "Debe de escribir la clave y el password del usuario administrador", "Error");
                    }
                    else
                    {
                        try
                        {
                            SucursalNueva.EmpresaId = this.Configuracion!.Empresaid!.Value;

                            SucursalBindingModel sucursalNueva = new SucursalBindingModel();

                            Task.Run(async () =>
                            {
                                var buffer = await provider!.CrearSucursal(SucursalNueva) ;
                                if (buffer != null)
                                {
                                    throw new Exception("No se pudo crear a sucursal");
                                }

                                sucursalNueva = buffer!;
                            }).Wait();

                            UsuarioNuevo.EmpresaId = this.Configuracion!.Empresaid!.Value;
                            UsuarioNuevo.SucursalId = sucursalNueva.Id;

                            var usuarioNuevo = provider!.CrearUsuario(UsuarioNuevo);

                            CajaNueva.EmpresaId = this.Configuracion!.Empresaid!.Value;
                            CajaNueva.SucursalId = sucursalNueva.Id;

                            Task.Run(async () =>
                            {

                                await provider!.CrearCaja(CajaNueva);

                                await provider!.CrearUnidadesDefault(SucursalNueva);

                                await provider!.CrearAlmacenDefault(SucursalNueva);

                                await provider!.CrearClientesDefault(SucursalNueva);

                                await provider!.CrearProveedorDefault(SucursalNueva);

                                await provider!.CrearMarcaDefault(SucursalNueva);

                                await provider!.CrearLineaDefault(SucursalNueva);

                                await provider!.CrearProductoDefault(SucursalNueva);

                                await provider!.CrearParametroDefault(this.Configuracion!.Empresaid!.Value, sucursalNueva.Id!.Value);

                            }).Wait();




                            this.Configuracion!.Sucursalid = sucursalNueva.Id;
                            this.Configuracion!.Sucursalclave = sucursalNueva.Clave;
                            this.Configuracion!.Sucursalnombre = sucursalNueva.Nombre;
                            SetConfiguracionInGlobal(this.Configuracion?.Item);
                        }
                        catch (Exception ex)
                        {
                            this.showPopUpMessage("Error", "Error al crear la sucursal " + ex.Message, "Error");
                        }
                    }
                }
                else
                {
                    SetConfiguracionInGlobal(this.Configuracion?.Item);
                }

                if (!cancel)
                {

                    Task.Run(async () =>
                    {
                        this.Catalogs!["Caja"] = await this.selectorProvider.obtainCatalog(this.lstCatalogDef![2], new Model.BaseParam(this.Configuracion!.Empresaid, this.Configuracion!.Sucursalid));

                    }).Wait();
                }
            }
            else if (currentStepTitle == "Caja")
            {
                if (!ExisteCaja)
                {
                    if (string.IsNullOrEmpty(CajaNueva.Clave) || string.IsNullOrEmpty(CajaNueva.Nombre))
                    {
                        cancel = true;
                        this.showPopUpMessage("Error", "Debe de escribir la clave y el nombre de la caja nueva ", "Error");
                    }
                    else
                    {
                        try
                        {
                            CajaNueva.EmpresaId = this.Configuracion!.Empresaid!.Value;
                            CajaNueva.SucursalId = this.Configuracion!.Sucursalid!.Value;



                            CajaBindingModel cajaNueva = new CajaBindingModel();

                            Task.Run(async () =>
                            {
                                var buffer = await provider!.CrearCaja(CajaNueva);
                                if (buffer == null)
                                    throw new Exception("No se pudo crear la caja");

                                cajaNueva = buffer!;

                            }).Wait();

                            this.Configuracion!.Cajaid = cajaNueva.Id;
                            this.Configuracion!.Cajaclave = cajaNueva.Clave;
                            this.Configuracion!.Cajanombre = cajaNueva.Nombre;
                            SetConfiguracionInGlobal(this.Configuracion?.Item);
                        }
                        catch (Exception ex)
                        {
                            this.showPopUpMessage("Error", "Error al crear la sucursal " + ex.Message, "Error");
                        }
                    }
                }
                else
                {

                    SetConfiguracionInGlobal(this.Configuracion?.Item);
                }

            }
            else if (currentStepTitle == "General")
            {
                this.Accept();
            }

            return new ConfigurationAction() { Action = "None", Parameters = null };
        }




        public override bool CanEmpresaid
        {
            get { return false; }
        }

        public override bool CanSucursalid
        {
            get { return false; }
        }

        public override bool CanId
        {
            get { return false; }
        }





    }




    public class ConfiguracionShowViewModel : ConfiguracionItemViewModel, IHandle<ConfiguracionItemVMInitialParameters>
    {
        public ConfiguracionShowViewModel(ConfiguracionWebController provider,
                                    SelectorWebController selectorProvider, GlobalWebController globalControllerProvider,
                                    IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) : base(provider, selectorProvider, globalControllerProvider, aggregator,winManager, messageBoxService)
        {
            this.BIsReadOnly = true;

            ConfiguracionBindingModel item = new ConfiguracionBindingModel();
            aggregator.SubscribeOnUIThread(this);


        }


        public Task HandleAsync(ConfiguracionItemVMInitialParameters initialParameters, CancellationToken cancellationToken)
        {
            ConfiguracionBindingModel item = new ConfiguracionBindingModel();
            
            item.Id = initialParameters.Id;
            if(ConfigurationManager.AppSettings.Get("itemSucursalIdForEditing") != null)
                item.Sucursalid = long.Parse(ConfigurationManager.AppSettings.Get("itemSucursalIdForEditing")!); 

            if(ConfigurationManager.AppSettings.Get("itemEmpresaIdForEditing") != null)
                item.Empresaid = long.Parse(ConfigurationManager.AppSettings.Get("itemEmpresaIdForEditing")!);


            Task.Run(async () =>
            {
                Configuracion = await provider!.GetById(item);
            }).Wait();

            if (Configuracion == null)
                Configuracion = new ConfiguracionBindingModel();

            return Task.CompletedTask;
        }

        public override void Accept()
        {
            
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(null, false, true));
        }

        public override void Cancel()
        {
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(null, false, true));
        }


        public override ConfigurationAction ContinueNavigationHandler(string currentStepTitle, string nextStepTitle, out bool cancel)
        {
            cancel = false;
            return new ConfigurationAction() { Action = "None", Parameters = null };

        }

        public override bool CanEmpresaid
        {
            get { return false; }
        }

        public override bool CanSucursalid
        {
            get { return false; }
        }

        public override bool CanId
        {
            get { return false; }
        }





    }


}
