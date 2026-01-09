
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Dynamic;
using System.Net.Mime;
using System.Windows;
using System.Windows.Input;
using IposV3.ViewModels.BaseScreen;
using ViewModels.BaseScreen;
using BindingModels;
using Caliburn.Micro;
using Controllers;
using Controllers.Controller;
//using IposV3.Controllers.Controller;
//using DataAccess;
using Models;
using IposV3.Model;
using IposV3.ViewModels;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace IposV3.ViewModels
{

    public class LineaListViewModel : BaseWebListViewModel<LineaBindingModel, LineaWebController, LineaItemVMInitialParameters, LineaListVMEventParameters, LineaParam>
    {

        ReportesWebController _reportesWebController;

        public LineaListViewModel(LineaWebController provider, UsuarioWebController usuarioControllerProvider, ReportesWebController reportesWebController,
                             SelectorWebController selectorProvider, IWindowManager winManager, IEventAggregator aggregator, IMessageBoxService messageBoxService) :
                            base(provider, usuarioControllerProvider, selectorProvider, winManager, aggregator, messageBoxService, true)
        {
            _reportesWebController = reportesWebController;
        }




        protected override System.Collections.Generic.List<long> DerechosEstandarToCheck()
        {
            return new System.Collections.Generic.List<long>{ Model.DBValues._DERECHO_LINEA_VER,
                                   Model.DBValues._DERECHO_LINEA_VER + 1000,
                                   Model.DBValues._DERECHO_LINEA_VER + 2000,
                                   Model.DBValues._DERECHO_LINEA_VER + 3000                };
        }

        protected override void preconfigureSearchParams()
        {
            KendoParams = new KendoParams("", @"""Clave""|""Nombre""");
        }

        protected override object EditViewModel()
        {
            return IoC.Get<LineaEditViewModel>();
        }

        protected override object ShowViewModel()
        {
            return IoC.Get<LineaShowViewModel>();
        }


        protected override object AddViewModel()
        {
            return IoC.Get<LineaAddViewModel>();
        }


        public async Task TestGeneral()
        {

            
            Dictionary<string, object> dictionaryReport = new Dictionary<string, object>();
            dictionaryReport.Add("empresaid", 1);
            dictionaryReport.Add("sucursalid", 1);
            dictionaryReport.Add("filtro", "%AMEX%");

            FastReportInfo fastReportInfo = new FastReportInfo()
            {
                RutaReporte = FastReportsConfig.getPathForFile("InformePrueba.frx", FastReportsTipoFile.desistema),
                DictionaryReporte = dictionaryReport,
                ConnectionString = GlobalVariable.CurrentDataBaseConnectionFnc(),
                Userid = GlobalVariable.CurrentSession!.Usuarioid!.Value,
                UserName = GlobalVariable.CurrentSession!.CurrentUsuario!.Nombre,

            };

            ReporteFrxShowingViewModel vm = IoC.Get<ReporteFrxShowingViewModel>();

            var dictTables = await _reportesWebController.GetReportData(fastReportInfo);

            fastReportInfo.DictionaryTables = dictTables;
            fastReportInfo.RutaReporte = FastReportsConfig.getPathFrxForFile("InformePrueba.frx", FastReportsTipoFile.desistema);

            vm.FastReportInfo = fastReportInfo;

            winManager.ShowDialogAsync(vm, null, CreateWinSettings("Devolucion de Compras", 0.75));
        }


    }
}
