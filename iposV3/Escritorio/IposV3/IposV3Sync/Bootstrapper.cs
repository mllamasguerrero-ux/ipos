using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Windows;
using Caliburn.Micro;
using Castle.Core;
using Castle.Facilities.TypedFactory; 
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DataAccess;
using IposV3.Model;
using IposV3Sync.Views;
using IposV3Sync.ViewModels;
using Microsoft.EntityFrameworkCore;
using Models;
using Component = Castle.MicroKernel.Registration.Component;
using IposV3.DataAccess;
using Controllers.Controller;
using IposV3Sync.Controllers.Controller;
using IposV3Sync.Controllers.Controller.Utils;
using BIPOS.Database.DAO;
using IposV3.Services;
using Syncfusion.Windows.Controls;
using ViewModels.BaseScreen;

namespace IposV3SyncManager
{
    public class Bootstrapper : BootstrapperBase {
        private WindsorContainer? container;

        public Bootstrapper() {
            Initialize();
        }

        protected override IEnumerable<Assembly> SelectAssemblies() {
            return new[] {
                //typeof (MainViewModel).Assembly,
                //typeof (MainView).Assembly,
                typeof (MainWindowViewModel).Assembly,
                typeof (MainWindowView).Assembly
            };
        }

        protected override void Configure() {

            Func<string> getGeneralConnectionStringPtr = GetGeneralConnectionString;
            IposV3Sync.ViewModels.GlobalVariable.CurrentDataBaseConnectionFnc = getGeneralConnectionStringPtr;


            container = new WindsorContainer();
            container.Kernel.Resolver.AddSubResolver(new AppSettingsConvention());
            container.Register(
                Component.For<IDataProvider<Student>>()
                    .ImplementedBy<StudentsXmlProvider>()
                    .DependsOn(Dependency.OnValue<string>("StudentsRepo.xml")),
                Component.For<IEventAggregator>()
                    .ImplementedBy<EventAggregator>()
                    .LifestyleSingleton(),
                Component.For<Caliburn.Micro.IWindowManager>()
                    .ImplementedBy<Caliburn.Micro.WindowManager>()
                    .LifestyleSingleton(),

                Component.For<ConfiguracionController>()
                    .ImplementedBy<ConfiguracionController>(),

                Component.For<GlobalController>()
                    .ImplementedBy<GlobalController>(),

                Component.For<SelectorController>()
                    .ImplementedBy<SelectorController>(),


                Component.For<CatalogSelector>()
                    .ImplementedBy<CatalogSelector>(),

                 Component.For<IMessageBoxService>()
                    .ImplementedBy<Controls.WPFMessageBoxService>(),


                //dao
                Component.For<ConfiguracionDao>()
                    .ImplementedBy<ConfiguracionDao>(),
                Component.For<TableinfoDao>()
                    .ImplementedBy<TableinfoDao>(),
                Component.For<ReplicacionService>()
                    .ImplementedBy<ReplicacionService>(),


                //Component.For<IConfiguracionsyncControllerProvider>()
                Component.For<IConfiguracionsyncControllerProvider>()
                    .ImplementedBy<ConfiguracionsyncController>(),

                Component.For<ImpoExpoController>()
                    .ImplementedBy<ImpoExpoController>(),

                Component.For<ReplicacionController>()
                    .ImplementedBy<ReplicacionController>(),




                Component.For<IConfiguracionsyncDaoProvider>()
                    .ImplementedBy<ConfiguracionsyncDao>()
                    .DependsOn(Dependency.OnValue<Func<string>>(getGeneralConnectionStringPtr)),



                Component.For<ApplicationDbContext>()
                    .ImplementedBy<ApplicationDbContext>(),

                Component.For<OperationsContextFactory>()
                    .ImplementedBy<OperationsContextFactory>()



                //    .DependsOn(Dependency.OnValue<Func<string>>(getGeneralConnectionStringPtr))

                );
            RegisterViewModels();
            RegisterServices();
            container.AddFacility<TypedFactoryFacility>();

            ViewLocator.NameTransformer.AddRule(
                @"StudentsManager.ViewModels.AddStudentViewModel",
                @"StudentsManager.Views.AddEditStudentView");

            ViewLocator.NameTransformer.AddRule(
                @"StudentsManager.ViewModels.EditStudentViewModel",
                @"StudentsManager.Views.AddEditStudentView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3Sync.ViewModels.HomeViewModel",
                @"IposV3Sync.Views.HomeView");



            ViewLocator.NameTransformer.AddRule(
                @"IposV3Sync.ViewModels.ConfiguracionsyncAddViewModel", //addviewmodel
                @"IposV3Sync.Views.ConfiguracionsyncAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3Sync.ViewModels.ConfiguracionsyncEditViewModel",
                @"IposV3Sync.Views.ConfiguracionsyncAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3Sync.ViewModels.ConfiguracionsyncShowViewModel",
                @"IposV3Sync.Views.ConfiguracionsyncAddEditView");


            MessageBinder.SpecialValues.Add("$pressedkey", (context) =>
            {
                // NOTE: IMPORTANT - you MUST add the dictionary key as lowercase as CM
                // does a ToLower on the param string you add in the action message, in fact ideally
                // all your param messages should be lowercase just in case. I don't really like this
                // behaviour but that's how it is!
                var keyArgs = context.EventArgs as System.Windows.Input.KeyEventArgs;

                if (keyArgs != null)
                    return keyArgs.Key;

                return null;
            });

        }




        public void ConnectDataBase()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            var _context = IoC.Get<ApplicationDbContext>();
            var _contextFactory = IoC.Get<OperationsContextFactory>();

            var configuracionProvider = IoC.Get<IConfiguracionsyncControllerProvider>();
            var defaultConfig = configuracionProvider?.GetDefaultConfiguracion();
            if (defaultConfig != null)
            {
                _context.Database.CloseConnection();
                _context.ConnectionString = "Server=" + defaultConfig.Serverlocal + ";Port=" + defaultConfig.Portlocal + ";Database=" + defaultConfig.Dblocal + ";Uid=" + defaultConfig.Usuariolocal + ";Pwd=" + defaultConfig.Passwordlocal + ";";
                _context.Database.SetConnectionString(_context.ConnectionString);

                _contextFactory.ConnectionString = "Server=" + defaultConfig.Serverlocal + ";Port=" + defaultConfig.Portlocal + ";Database=" + defaultConfig.Dblocal + ";Uid=" + defaultConfig.Usuariolocal + ";Pwd=" + defaultConfig.Passwordlocal + ";";

            }

        }

        public static string GetGeneralConnectionString()
        {

            System.Configuration.Configuration _config =
             ConfigurationManager.OpenExeConfiguration(
             ConfigurationUserLevel.None);
            return _config.ConnectionStrings.ConnectionStrings["WpfIpos.Properties.Settings.ConnectionIpos"].ConnectionString; 


        }

        protected override object GetInstance(Type service, string key) {
            return string.IsNullOrWhiteSpace(key)
                ? container!.Resolve(service)
                : container!.Resolve(key, service);
        }

        private void RegisterViewModels() {
            //container.Register(Classes.FromAssembly(typeof (MainViewModel).Assembly)
            //    .Where(x => x.Name.EndsWith("ViewModel"))
            //    .Configure(x => x.LifeStyle.Is(LifestyleType.Transient)));

            container!.Register(Classes.FromAssembly(typeof(MainWindowViewModel).Assembly)
                .Where(x => x.Name.EndsWith("ViewModel"))
                .Configure(x => x.LifeStyle.Is(LifestyleType.Transient)));

        }

        private void RegisterServices()
        {

            container!.Register(Classes.FromAssembly(typeof(UsuarioService).Assembly)
                .Where(x => x.Name.EndsWith("Service"))
                .Configure(x => x.LifeStyle.Is(LifestyleType.Transient)));



        }

        protected override void OnStartup(object sender, StartupEventArgs e) {

            ConnectDataBase();
            DisplayRootViewForAsync<MainWindowViewModel>();
        }
    }

    public class AppSettingsConvention : ISubDependencyResolver {
        public bool CanResolve(
            CreationContext context,
            ISubDependencyResolver contextHandlerResolver,
            ComponentModel model,
            DependencyModel dependency) {
            return ConfigurationManager.AppSettings.AllKeys
                .Contains(dependency.DependencyKey)
                   && TypeDescriptor
                       .GetConverter(dependency.TargetType)
                       .CanConvertFrom(typeof (string));
        }

        public object Resolve(
            CreationContext context,
            ISubDependencyResolver contextHandlerResolver,
            ComponentModel model,
            DependencyModel dependency) {
            return TypeDescriptor
                .GetConverter(dependency.TargetType)
                .ConvertFrom(
                    ConfigurationManager.AppSettings[dependency.DependencyKey] ?? new object()) ?? new object();
        }
    }
}