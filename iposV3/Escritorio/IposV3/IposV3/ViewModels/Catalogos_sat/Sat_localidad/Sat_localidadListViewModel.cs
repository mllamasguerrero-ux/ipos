
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
using Models.CatalogSelector;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.ViewModels
{

    public class Sat_localidadListViewModel : BaseWebListViewModel<Sat_localidadBindingModel, Sat_localidadWebController, Sat_localidadItemVMInitialParameters, Sat_localidadListVMEventParameters, Sat_localidadParam>
    {

        public string clave_estado;
        public string Clave_estado { get => clave_estado; set { clave_estado = value; NotifyOfPropertyChange("Clave_estado"); } }


        public Sat_localidadListViewModel(Sat_localidadWebController provider, SelectorWebController selectorProvider, IWindowManager winManager, IEventAggregator aggregator, IMessageBoxService messageBoxService) :
                            base(provider, selectorProvider, winManager, aggregator, messageBoxService)
        {
            clave_estado = "";
        }


        protected override void fillCatalogConfiguration()
        {
            lstCatalogDef = new List<CatalogDef>();

            if (!lstCatalogDef.Any(y => y.CatalogName == "Estadopaisacronimo"))
                lstCatalogDef.Add(new CatalogDef("Estadopaisacronimo"));
        }



        protected override void preconfigureSearchParams()
        {
            KendoParams = new KendoParams("", "Clave_localidad | Clave_estado | Descripcion ");
        }
    
        protected override object EditViewModel()
        {
            return IoC.Get<Sat_localidadEditViewModel>();
        }

        protected override object ShowViewModel()
        {
            return IoC.Get<Sat_localidadShowViewModel>();
        }


        protected override object AddViewModel()
        {
            return IoC.Get<Sat_localidadAddViewModel>();
        }

        public override async Task<List<Sat_localidadBindingModel>> DoGetItems()
        {
            if (ListParam == null)
                return new List<Sat_localidadBindingModel>();

            var filterClave_estado = KendoParams?.Filter?.Filters?.FirstOrDefault(f => f.Field == "Clave_estado");
            if (this.clave_estado != null && this.clave_estado.Length > 0)
            {
                if (filterClave_estado != null)
                {
                    filterClave_estado.Value = this.clave_estado;
                }
                else
                {

                    if (KendoParams!.Filter == null)
                        KendoParams!.Filter = new KendoFilters(new List<KendoFilter>(), "and");

                    filterClave_estado = new KendoFilter(clave_estado!, "eq", "Clave_estado", "true");
                    KendoParams!.Filter!.Filters!.Add(filterClave_estado);
                }
            }
            else
            {
                if (filterClave_estado != null)
                    KendoParams!.Filter!.Filters!.Remove(filterClave_estado);

            }

            System.Collections.Generic.List<Sat_localidadBindingModel> items = new System.Collections.Generic.List<Sat_localidadBindingModel>();
            items = await itemsProvider.SelectList(ListParam, KendoParams);
            return items;
        }
    }
}
