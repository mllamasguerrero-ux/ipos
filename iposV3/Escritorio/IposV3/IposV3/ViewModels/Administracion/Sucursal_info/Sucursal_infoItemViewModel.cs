
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
using IposV3.Services.ExtensionsLocal;

namespace IposV3.ViewModels
{

    public class Sucursal_infoItemViewModel : BaseWebRecordViewModel<Sucursal_infoBindingModel, Sucursal_infoWebController, Sucursal_infoItemVMInitialParameters, Sucursal_infoListVMEventParameters>
    {

        public Sucursal_infoBindingModel? Sucursal_info { get { return Record; } set { Record = value; } }
        public Sucursal_infoItemViewModel(string mode, Sucursal_infoWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(mode, provider, selectorProvider, aggregator, winManager, messageBoxService)
        {

        }




        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("Sucursal_info","Gruposucursal","Sucursal_info_opciones_Gruposucursalid", "Sucursal_info_opciones_GruposucursalClave", "Sucursal_info_opciones_GruposucursalNombre","IposV3.ViewModels.GruposucursalListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Sucursal_info","Cliente","Sucursal_info_opciones_Clienteid", "Sucursal_info_opciones_ClienteClave", "Sucursal_info_opciones_ClienteNombre","IposV3.ViewModels.ClienteListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Sucursal_info","Proveedor","Sucursal_info_opciones_Proveedorid", "Sucursal_info_opciones_ProveedorClave", "Sucursal_info_opciones_ProveedorNombre","IposV3.ViewModels.ProveedorListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Sucursal_info","Proveedor","Sucursal_info_opciones_Empprovid", "Sucursal_info_opciones_EmpprovClave", "Sucursal_info_opciones_EmpprovNombre","IposV3.ViewModels.ProveedorListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Sucursal_info","Estadopais","Sucursal_fact_elect_Entregaestadoid", "Sucursal_fact_elect_EntregaestadoClave", "Sucursal_fact_elect_EntregaestadoNombre","IposV3.ViewModels.EstadopaisListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Sucursal_info","Sat_colonia","Sucursal_fact_elect_Entrega_Sat_Coloniaid", "Sucursal_fact_elect_Entrega_Sat_ColoniaClave", "Sucursal_fact_elect_Entrega_Sat_ColoniaNombre","IposV3.ViewModels.Sat_coloniaListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Sucursal_info","Sat_localidad","Sucursal_fact_elect_Entrega_Sat_Localidadid", "Sucursal_fact_elect_Entrega_Sat_LocalidadClave", "Sucursal_fact_elect_Entrega_Sat_LocalidadNombre","IposV3.ViewModels.Sat_localidadListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Sucursal_info","Sat_municipio","Sucursal_fact_elect_Entrega_Sat_Municipioid", "Sucursal_fact_elect_Entrega_Sat_MunicipioClave", "Sucursal_fact_elect_Entrega_Sat_MunicipioNombre","IposV3.ViewModels.Sat_municipioListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Sucursal_info","Sucursal_info","Sucursal_importacion_Surtidorid", "Sucursal_importacion_SurtidorClave", "Sucursal_importacion_SurtidorNombre","IposV3.ViewModels.Sucursal_infoListViewModel","SelectedItem","Clave")
                                    };
            lstCatalogDef = new List<CatalogDef>();
            if (!lstCatalogDef.Any(y => y.CatalogName == "Estadopais"))
                lstCatalogDef.Add(new CatalogDef("Estadopais"));
            if (!lstCatalogDef.Any(y => y.CatalogName == "Banco"))
                lstCatalogDef.Add(new CatalogDef("Banco"));
            if (!lstCatalogDef.Any(y => y.CatalogName == "Tipoprecio"))
                lstCatalogDef.Add(new CatalogDef("Tipoprecio"));


        }


        public override void ShowPopUpSelector(string catalogClaveField)
        {

            if (!catalogClaveField.In(new string[] { "Sucursal_fact_elect_Entrega_Sat_ColoniaClave", "Sucursal_fact_elect_Entrega_Sat_LocalidadClave", "Sucursal_fact_elect_Entrega_Sat_MunicipioClave" }))
            {
                base.ShowPopUpSelector(catalogClaveField);
                return;
            }

            var catalogRelated = this.catalogRelatedFields?.Where(x => x.ClaveField == catalogClaveField).FirstOrDefault();

            Dictionary<string, object?> specialProperties = new Dictionary<string, object?>();

            if (Record?.Sucursal_fact_elect_Entregacodigopostal != null && Record?.Sucursal_fact_elect_Entregacodigopostal.Length > 0 &&
                (catalogClaveField == "Sucursal_fact_elect_Entrega_Sat_ColoniaClave"))
                specialProperties.Add("Codigopostal", Record?.Sucursal_fact_elect_Entregacodigopostal);


            if (Record!.Sucursal_fact_elect_EntregaestadoClave != null && Record?.Sucursal_fact_elect_EntregaestadoClave.Length > 0 &&
                (catalogClaveField == "Sucursal_fact_elect_Entrega_Sat_LocalidadClave" || catalogClaveField == "Sucursal_fact_elect_Entrega_Sat_MunicipioClave"))
            {
                var estadoSeleccionado = Catalogs?["Estadopais"]?.FirstOrDefault(x => x.Clave == Record!.Sucursal_fact_elect_EntregaestadoClave);

                if (estadoSeleccionado != null && estadoSeleccionado.Texto1 != null)
                {
                    specialProperties.Add("Clave_estado", estadoSeleccionado.Texto1);
                }
            }





            if (catalogRelated != null)
                ShowPopUpSelectorCatalogRelated(catalogRelated, null, specialProperties);

        }

    }


    public class Sucursal_infoShowViewModel : Sucursal_infoItemViewModel
    {
        public Sucursal_infoShowViewModel(Sucursal_infoWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class Sucursal_infoEditViewModel : Sucursal_infoItemViewModel
    {
        public Sucursal_infoEditViewModel(Sucursal_infoWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class Sucursal_infoAddViewModel : Sucursal_infoItemViewModel
    {
        public Sucursal_infoAddViewModel(Sucursal_infoWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

}


