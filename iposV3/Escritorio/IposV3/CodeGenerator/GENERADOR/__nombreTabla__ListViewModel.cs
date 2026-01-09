|||||100+++++
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
using IposV3.Controllers.Controller;
using DataAccess;
using Models;
using IposV3.Model;
using IposV3.ViewModels;

namespace IposV3.ViewModels
{

    public class (nombreTabla)ListViewModel : BaseListViewModel<(nombreTabla)BindingModel, (nombreTabla)Controller, (nombreTabla)ItemVMInitialParameters, (nombreTabla)ListVMEventParameters, (nombreTabla)Param>
    {


        public (nombreTabla)ListViewModel((nombreTabla)Controller provider, SelectorWebController selectorProvider, IWindowManager winManager, IEventAggregator aggregator, IMessageBoxService messageBoxService) :
                            base(provider, selectorProvider, winManager, aggregator, messageBoxService)
        {
        }


|||||105+++++
        protected override void preFillParam()
        {

            ListParam = new (nombreTabla)Param();
            ListParam.P_empresaid = 0;
            ListParam.P_sucursalid = 0;
        }
|||||106+++++

        protected override void preconfigureSearchParams()
        {
            KendoParams = new KendoParams("", "|||||110+++++(nombreCampo) | |||||120+++++");
        }
    
        protected override object EditViewModel()
        {
            return IoC.Get<(nombreTabla)EditViewModel>();
        }

        protected override object ShowViewModel()
        {
            return IoC.Get<(nombreTabla)ShowViewModel>();
        }


        protected override object AddViewModel()
        {
            return IoC.Get<(nombreTabla)AddViewModel>();
        }
    }
}
!!!!!
100;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR
105;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;SI
106;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR
110;1;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;2;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;SI
120;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR
