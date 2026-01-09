using Caliburn.Micro;
using Controllers.BindingModel;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Runtime.CompilerServices;
using IposV3.ViewModels;
using System.Reflection.Metadata;
using BindingModels;
using IposV3.Model;
using Models.CatalogSelector;
using Controllers.Controller;
//using IposV3.Controllers.Controller;
using ViewModels.BaseScreen;

namespace IposV3.ViewModels.BaseScreen
{
    public class BaseOperationalScreen : BaseGenericViewModel
    {
        private UsuarioWebController baseUsuarioControllerProvider;
        private CorteWebController corteControllerProvider;

        public long? CorteId { get; set; }

        public bool BIsReadOnly { get; protected set; }


        public BaseOperationalScreen(SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService, 
                                        UsuarioWebController baseUsuarioControllerProvider, CorteWebController corteControllerProvider)
            :base(selectorProvider, aggregator, winManager, messageBoxService)
        {
            this.baseUsuarioControllerProvider = baseUsuarioControllerProvider;
            this.corteControllerProvider = corteControllerProvider;


            CheckDerechos();
        }



        protected virtual List<long>? DerechosToCheck()
        {

            return null;
        }

        protected void CheckDerechos()
        {
            DerechosUsuario = new Dictionary<long, bool>();
            var derechos = DerechosToCheck();
            if (derechos == null || GlobalVariable.CurrentSession?.CurrentUsuario?.Id == null || baseUsuarioControllerProvider == null)
                return;


            Task.Run(async () =>
            {
                var buffer = await baseUsuarioControllerProvider.Obtain_usuarios_derechos_List(GlobalVariable.CurrentSession!.Empresaid!.Value, GlobalVariable.CurrentSession!.Sucursalid!.Value, derechos, GlobalVariable.CurrentSession!.CurrentUsuario!.Id!.Value);
                if (buffer != null)
                    DerechosUsuario = buffer;
            }).Wait();

        }

        public void ChecarCorteActivo(bool primeraVezLlamado = true)
        {

            try
            {
                CorteId = null;

                CorteBindingModel? resultData = null;

                Task.Run(async () =>
                {
                    resultData = await corteControllerProvider.CorteActivoUsuario(
                                    GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid,
                                    GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid,
                                    GlobalVariable.CurrentSession?.CurrentUsuario?.Id
                                    );
                }).Wait();


                if (resultData == null || resultData.Id == 0 || resultData.Activo == null || !resultData.Activo.Equals(BoolCS.S) ||
                    resultData.Fechacorte == null)
                {

                    if (AbrirCorte())
                    {
                        ChecarCorteActivo(false);
                        return;
                    }
                    else
                    {
                        PedirChecarCorteYCerrar("Por favor abra un corte antes de continuar");
                        return;
                    }
                }
                else
                {


                    TimeSpan ts = DateTimeOffset.Now - resultData!.Fechacorte!.Value;
                    if (
                        resultData.Fechacorte!.Value.Date < DateTime.Today.AddDays(-1) ||
                        (resultData!.Fechacorte!.Value.Date <= DateTime.Today.AddDays(-1) && ts.Hours > 6)
                        )
                    {
                        if(primeraVezLlamado)
                        {
                            if(CerrarCorte())
                            {
                                if(AbrirCorte())
                                {
                                    ChecarCorteActivo(false);
                                    return;
                                }
                                else
                                {
                                    PedirChecarCorteYCerrar("Por favor abra un corte antes de continuar");
                                    return;
                                }
                            }
                            else
                            {
                                PedirChecarCorteYCerrar("Se tiene abierto un corte de una fecha pasada porfavor cierrelo antes de continuar");
                                return;
                            }
                        }

                    }
                    else
                    {

                        CorteId = resultData.Id;
                    }
;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        protected bool AbrirCorte()
        {


            var vm = IoC.Get<CorteAbrirViewModel>();
            vm.IsPopupMode = true;
            winManager.ShowDialogAsync(vm, null, CreateWinSettings("Abrir Corte", 0.50));

            return vm.SeAbrioCorte;
        }

        protected bool CerrarCorte()
        {


            var vm = IoC.Get<CorteCerrarViewModel>();
            vm.IsPopupMode = true;
            vm.EsCajeroActual = true;
            winManager.ShowDialogAsync(vm, null, CreateWinSettings("Cerrar Corte", 0.50));

            return vm.SeCerroCorte;
        }

        protected void PedirChecarCorteYCerrar(string message)
        {

            MessageBox.Show(message);
            this.TryCloseAsync();
        }    

        public virtual void Back()
        {
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(null, false, true));
        }

    }
}
