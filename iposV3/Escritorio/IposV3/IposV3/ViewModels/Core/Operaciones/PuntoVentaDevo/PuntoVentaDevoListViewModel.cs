
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
using IposV3.ViewModels.core.operaciones.puntoventa;
using Models.CatalogSelector;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IposV3.ViewModels
{

    public class PuntoVentaDevoListViewModel : BaseGenericListViewModel<V_docto_venddevoWFBindingModel,
                                                                     PuntoVentaDevoListVMInitialParameters,  PuntoVentaDevoListVMEventParameters, V_docto_venddevoParamWFBindingModel>
    {



        protected readonly PuntoVentaDevoWebController itemsProvider;
        public V_docto_venddevoWFBindingModel? V_docto_venddevoItem { get; set; }



        public PuntoVentaDevoListViewModel(SelectorWebController selectorProvider, PuntoVentaDevoWebController controllerProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(null, selectorProvider, winManager, aggregator, messageBoxService)
        {
            V_docto_venddevoItem = new V_docto_venddevoWFBindingModel();
            V_docto_venddevoItem!.PendingChange += CatalogField_PropertyChanging;

            itemsProvider = controllerProvider;

        }



        protected override void fillCatalogConfiguration()
        {

            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("ListParam","Usuario","P_usuarioid", "P_usuarioclave", "P_usuarionombre","IposV3.ViewModels.UsuarioListViewModel","SelectedItem","Username")
                                    };
            lstCatalogDef = new List<CatalogDef>() { new CatalogDef(
                    "Tipodocto_Venddevo"),new CatalogDef(
                    "Estatusdocto_Venddevo")
         };
        }



        protected override void preFillParam()
        {

            ListParam = new V_docto_venddevoParamWFBindingModel();
            if (GlobalVariable.CurrentSession != null)
            {

                ListParam.P_empresaid = GlobalVariable.CurrentSession.Empresaid;
                ListParam.P_sucursalid = GlobalVariable.CurrentSession.Sucursalid;

                ListParam.P_tipodoctoid = DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO;
                ListParam.P_estatusdoctoid = DBValues._DOCTO_ESTATUS_COMPLETO;
                ListParam.P_fechaini = DateTimeOffset.UtcNow.AddDays(-100);
                ListParam.P_fechafin = DateTimeOffset.UtcNow.AddDays(100);

                ListParam.P_usuarioid = GlobalVariable.CurrentSession!.CurrentUsuario!.Id;
                ListParam._usuarioclave = GlobalVariable.CurrentSession!.CurrentUsuario!.Clave;
                ListParam.P_usuarionombre = GlobalVariable.CurrentSession!.CurrentUsuario!.Nombre;
            }
        }


        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);

            if (ListParam != null)
                ListParam.PendingChange += CatalogField_PropertyChanging;
        }



        public override System.Collections.Generic.List<V_docto_venddevoWFBindingModel> DoGetItems()
        {
            if (ListParam == null)
                return new List<V_docto_venddevoWFBindingModel>();

            System.Collections.Generic.List<V_docto_venddevoWFBindingModel> items = new System.Collections.Generic.List<V_docto_venddevoWFBindingModel>();

            Task.Run(async () =>
            {
                items = await itemsProvider.Select_V_docto_venddevo_List(ListParam.P_empresaid!.Value, ListParam.P_sucursalid!.Value,
                                                                  ListParam.P_usuarioid, ListParam.P_tipodoctoid!.Value,
                                                                  ListParam.P_estatusdoctoid!.Value,
                                                                  ListParam.P_fechaini!.Value, ListParam.P_fechafin!.Value) ?? items;
            }).Wait();


            return items;
        }


        public override void Edititem(V_docto_venddevoWFBindingModel selected)
        {
            this.SelectedItem = selected;
        }

        public override void ShowItem(V_docto_venddevoWFBindingModel selected)
        {
            this.SelectedItem = selected;
        }
    }
}
