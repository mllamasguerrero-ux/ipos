
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
using System.Threading.Tasks;

namespace IposV3.ViewModels
{

    public class MovtoLoteimportadoListViewModel : BaseGenericListViewModel<V_movto_loteimpo_selWFBindingModel,
                                                                     MovtoLoteimportadoListVMInitialParameters, MovtoLoteimportadoListVMEventParameters, V_param_movto_lote_selWFBindingModel>
    {



        protected readonly LoteWebController itemsProvider;
        public V_movto_loteimpo_selWFBindingModel? V_movto_lote_Item { get; set; }


        public System.Collections.ArrayList? SelectedItems { get; set; }
        public decimal CantidadASeleccionar { get; set; }


        private bool manejAlmacen;
        public bool ManejaAlmacen { get => manejAlmacen; set { manejAlmacen = value; NotifyOfPropertyChange("ManejaAlmacen"); } }

        public MovtoLoteimportadoListViewModel(SelectorWebController selectorProvider, LoteWebController controllerProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(null, selectorProvider, winManager, aggregator, messageBoxService)
        {
            V_movto_lote_Item = new V_movto_loteimpo_selWFBindingModel();
            V_movto_lote_Item!.PendingChange += CatalogField_PropertyChanging;

            itemsProvider = controllerProvider;

        }





        protected override void preconfigureSearchParams()
        {
            KendoParams = new KendoParams("", "");
        }


        protected override void fillCatalogConfiguration()
        {

            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("ListParam","Producto","Productoid", "Productoclave", "Productonombre","IposV3.ViewModels.ProductoListViewModel","SelectedItem","Clave")
                                    };
            lstCatalogDef = new List<CatalogDef>() { new CatalogDef(
                    "Almacen")
         };
        }



        protected override void preFillParam()
        {

            ListParam = new V_param_movto_lote_selWFBindingModel();
            if (GlobalVariable.CurrentSession != null)
            {

                ListParam.EmpresaId = GlobalVariable.CurrentSession?.Empresaid;
                ListParam.SucursalId = GlobalVariable.CurrentSession?.Sucursalid;

            }
        }


        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);

            if(ListParam != null)
             ListParam!.PendingChange += CatalogField_PropertyChanging;


            this.ManejaAlmacen = GlobalVariable.CurrentSession?.CurrentParametro?.Manejaalmacen == BoolCN.S;
        }



        public override System.Collections.Generic.List<V_movto_loteimpo_selWFBindingModel> DoGetItems()
        {
            if (ListParam == null)
                return new List<V_movto_loteimpo_selWFBindingModel>();

            System.Collections.Generic.List<V_movto_loteimpo_selWFBindingModel> items = new System.Collections.Generic.List<V_movto_loteimpo_selWFBindingModel>();


            Task.Run(async () =>
            {

                items = await itemsProvider.MovtoLoteImportadoSeleccion(ListParam.EmpresaId!.Value, ListParam.SucursalId!.Value,
                                                                      ListParam.Productoid!.Value, ListParam.Almacenid!.Value,
                                                                      ListParam.Doctoid) ?? items;
            }).Wait();

            return items;
        }


        public override void Edititem(V_movto_loteimpo_selWFBindingModel selected)
        {
            this.SelectedItem = selected;
        }

        public override void ShowItem(V_movto_loteimpo_selWFBindingModel selected)
        {
            this.SelectedItem = selected;
        }


        public void Select()
        {
            SelectedItems = new System.Collections.ArrayList();
            decimal sumSelected = 0;
            foreach (var item in Items)
            {
                if (item.CantidadATomar > 0)
                {

                    sumSelected += item.CantidadATomar;
                    SelectedItems.Add(item);

                }

            }

            if (sumSelected != CantidadASeleccionar)
            {
                showPopUpMessage("Cantidad seleccionada erronea", "Asegurese de asignar exactamente " + CantidadASeleccionar.ToString() + " elementos", "Error");
                SelectedItems = null;
                return;
            }

            TryCloseAsync();
        }

    }


    public class MovtoLoteimportadoListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public MovtoLoteimportadoListVMInitialParameters() : base(0)
        {
        }

        public MovtoLoteimportadoListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }

    public class MovtoLoteimportadoListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {


        public MovtoLoteimportadoListVMEventParameters() : base(false)
        { }

        public MovtoLoteimportadoListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public MovtoLoteimportadoListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent, hasMessage, msgSimple)
        { }
    }

}
