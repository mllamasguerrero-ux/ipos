
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

    public class PuntoVentaToDevoListViewModel : BaseGenericListViewModel<V_docto_vend_to_devoWFBindingModel,
                                                                     PuntoVentaToDevoListVMInitialParameters,  PuntoVentaToDevoListVMEventParameters, V_docto_vend_to_devoParamWFBindingModel>
    {



        protected readonly PuntoVentaDevoWebController itemsProvider;
        public V_docto_vend_to_devoWFBindingModel? V_docto_vendeduriaItem { get; set; }



        public PuntoVentaToDevoListViewModel(SelectorWebController selectorProvider, PuntoVentaDevoWebController controllerProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(null, selectorProvider, winManager, aggregator, messageBoxService)
        {
            V_docto_vendeduriaItem = new V_docto_vend_to_devoWFBindingModel();
            V_docto_vendeduriaItem!.PendingChange += CatalogField_PropertyChanging;

            itemsProvider = controllerProvider;

        }



        protected override void fillCatalogConfiguration()
        {

            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("ListParam","Usuario","P_usuarioid", "P_usuarioclave", "P_usuarionombre","IposV3.ViewModels.UsuarioListViewModel","SelectedItem","Username")
                                    };
            lstCatalogDef = new List<CatalogDef>() { new CatalogDef(
                    "Tipodocto_Vend_to_devo"),new CatalogDef(
                    "Estatusdocto_Vend_to_devo")
         };
        }



        protected override void preFillParam()
        {

            ListParam = new V_docto_vend_to_devoParamWFBindingModel();
            if (GlobalVariable.CurrentSession != null)
            {

                ListParam.P_empresaid = GlobalVariable.CurrentSession.Empresaid;
                ListParam.P_sucursalid = GlobalVariable.CurrentSession.Sucursalid;

                ListParam.P_tipodoctoid = DBValues._DOCTO_TIPO_VENTA;
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



        public override System.Collections.Generic.List<V_docto_vend_to_devoWFBindingModel> DoGetItems()
        {
            if (ListParam == null)
                return new List<V_docto_vend_to_devoWFBindingModel>();

            System.Collections.Generic.List<V_docto_vend_to_devoWFBindingModel> items = new System.Collections.Generic.List<V_docto_vend_to_devoWFBindingModel>();

            Task.Run(async () =>
            {
                items = await itemsProvider.Select_V_docto_vend_to_devo_List(ListParam.P_empresaid!.Value, ListParam.P_sucursalid!.Value,
                                                                      ListParam.P_usuarioid, ListParam.P_tipodoctoid!.Value,
                                                                      ListParam.P_estatusdoctoid!.Value,
                                                                      ListParam.P_fechaini!.Value, ListParam.P_fechafin!.Value) ?? items;


            }).Wait();

            return items;
        }


        public override void Edititem(V_docto_vend_to_devoWFBindingModel selected)
        {
            this.SelectedItem = selected;
        }

        public override void ShowItem(V_docto_vend_to_devoWFBindingModel selected)
        {
            this.SelectedItem = selected;
        }
    }
}
