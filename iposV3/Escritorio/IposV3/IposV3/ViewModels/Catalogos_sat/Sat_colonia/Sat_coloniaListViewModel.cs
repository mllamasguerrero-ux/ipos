
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
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.ViewModels
{

    public class Sat_coloniaListViewModel : BaseWebListViewModel<Sat_coloniaBindingModel, Sat_coloniaWebController, Sat_coloniaItemVMInitialParameters, Sat_coloniaListVMEventParameters, Sat_coloniaParam>
    {

        public string codigopostal;
        public string Codigopostal { get => codigopostal; set { codigopostal = value; NotifyOfPropertyChange("Codigopostal"); } }

        public Sat_coloniaListViewModel(Sat_coloniaWebController provider, SelectorWebController selectorProvider, IWindowManager winManager, IEventAggregator aggregator, IMessageBoxService messageBoxService) :
                            base(provider, selectorProvider, winManager, aggregator, messageBoxService)
        {
            codigopostal = "";
        }




        protected override void preconfigureSearchParams()
        {
            KendoParams = new KendoParams("", "Colonia | Nombre ");
        }
    
        protected override object EditViewModel()
        {
            return IoC.Get<Sat_coloniaEditViewModel>();
        }

        protected override object ShowViewModel()
        {
            return IoC.Get<Sat_coloniaShowViewModel>();
        }


        protected override object AddViewModel()
        {
            return IoC.Get<Sat_coloniaAddViewModel>();
        }

        public override async Task<List<Sat_coloniaBindingModel>> DoGetItems()
        {
            if (ListParam == null)
                return new List<Sat_coloniaBindingModel>();

            var filterCodigopostal = KendoParams?.Filter?.Filters?.FirstOrDefault(f => f.Field == "Codigopostal");
            if (this.codigopostal != null && this.codigopostal.Length > 0)
            {
                if (filterCodigopostal != null)
                {
                    filterCodigopostal.Value = this.codigopostal;
                }
                else
                {

                    if (KendoParams!.Filter == null)
                        KendoParams!.Filter = new KendoFilters(new List<KendoFilter>(), "and");

                    filterCodigopostal = new KendoFilter(codigopostal!, "eq", "Codigopostal", "true");
                    KendoParams!.Filter!.Filters!.Add(filterCodigopostal);
                }
            }
            else
            {
                if (filterCodigopostal != null)
                    KendoParams!.Filter!.Filters!.Remove(filterCodigopostal);

            }

            System.Collections.Generic.List<Sat_coloniaBindingModel> items = new System.Collections.Generic.List<Sat_coloniaBindingModel>();
            items = await itemsProvider.SelectList(ListParam, KendoParams);
            return items;
        }

    }
}
