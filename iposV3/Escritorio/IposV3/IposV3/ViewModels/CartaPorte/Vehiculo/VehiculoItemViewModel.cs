
using BindingModels;
using IposV3.Model;
using Caliburn.Micro;
using Controllers;
using Controllers.Controller;
//using IposV3.Controllers.Controller;
//using DataAccess;
using Models.CatalogSelector; 
using IposV3.ViewModels.BaseScreen;
using ViewModels.BaseScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.ViewModels
{

    public class VehiculoItemViewModel : BaseWebRecordViewModel<VehiculoBindingModel, VehiculoWebController, VehiculoItemVMInitialParameters, VehiculoListVMEventParameters>
    {

        public VehiculoBindingModel? Vehiculo { get { return Record; } set { Record = value; } }
        public VehiculoItemViewModel(string mode, VehiculoWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(mode, provider, selectorProvider, aggregator, winManager, messageBoxService)
        {

        }




        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("Vehiculo","Sat_tipopermiso","Sat_Tipopermisoid", "Sat_TipopermisoClave", "Sat_TipopermisoNombre","IposV3.ViewModels.Sat_tipopermisoListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Vehiculo","Sat_configautotransporte","Sat_Configautotransporteid", "Sat_ConfigautotransporteClave", "Sat_ConfigautotransporteNombre","IposV3.ViewModels.Sat_configautotransporteListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Vehiculo","Sat_subtiporem","Sat_Subtiporem1id", "Sat_Subtiporem1Clave", "Sat_Subtiporem1Nombre","IposV3.ViewModels.Sat_subtiporemListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Vehiculo","Sat_subtiporem","Sat_Subtiporem2id", "Sat_Subtiporem2Clave", "Sat_Subtiporem2Nombre","IposV3.ViewModels.Sat_subtiporemListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Vehiculo","Usuario","Duenioid", "DuenioClave", "DuenioNombre","IposV3.ViewModels.UsuarioListViewModel","SelectedItem","Clave")
                                    };
            lstCatalogDef = new List<CatalogDef>();
            

        }

    }


    public class VehiculoShowViewModel : VehiculoItemViewModel
    {
        public VehiculoShowViewModel(VehiculoWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class VehiculoEditViewModel : VehiculoItemViewModel
    {
        public VehiculoEditViewModel(VehiculoWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class VehiculoAddViewModel : VehiculoItemViewModel
    {
        public VehiculoAddViewModel(VehiculoWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

}


