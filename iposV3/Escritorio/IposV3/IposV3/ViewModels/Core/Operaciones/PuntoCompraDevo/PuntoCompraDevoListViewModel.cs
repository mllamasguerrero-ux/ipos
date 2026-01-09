
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
using IposV3.ViewModels.core.operaciones.puntocompra;

namespace IposV3.ViewModels
{

    public class PuntoCompraDevoListViewModel : BaseGenericListViewModel<V_docto_provdevoWFBindingModel, 
                                                                     PuntoCompraDevoListVMInitialParameters, PuntoCompraDevoListVMEventParameters, V_docto_provdevoParamWFBindingModel>
    {

        protected readonly PuntoCompraDevoWebController itemsProvider;
        public V_docto_provdevoWFBindingModel? V_docto_provdevoItem { get; set; }



        public PuntoCompraDevoListViewModel(SelectorWebController selectorProvider, PuntoCompraDevoWebController controllerProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(null, selectorProvider,  winManager, aggregator, messageBoxService)
        {
            V_docto_provdevoItem = new V_docto_provdevoWFBindingModel();
            V_docto_provdevoItem!.PendingChange += CatalogField_PropertyChanging;

            itemsProvider = controllerProvider;

        }


        protected override void fillCatalogConfiguration()
        {

            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("ListParam","Usuario","P_usuarioid", "P_usuarioclave", "P_usuarionombre","IposV3.ViewModels.UsuarioListViewModel","SelectedItem","Username")
                                    };
            lstCatalogDef = new List<CatalogDef>() { new CatalogDef(
                    "Tipodocto_Provdevo"),new CatalogDef(
                    "Estatusdocto_Provdevo")
         };
        }



        protected override void preFillParam()
        {

            ListParam = new V_docto_provdevoParamWFBindingModel();
            if (GlobalVariable.CurrentSession != null)
            {

                ListParam.P_empresaid = GlobalVariable.CurrentSession.Empresaid;
                ListParam.P_sucursalid = GlobalVariable.CurrentSession.Sucursalid;

                ListParam.P_tipodoctoid = DBValues._DOCTO_TIPO_COMPRA_DEVO;
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

            if(ListParam != null)
                    ListParam.PendingChange += CatalogField_PropertyChanging;
        }



        public override System.Collections.Generic.List<V_docto_provdevoWFBindingModel> DoGetItems()
        {
            if (ListParam == null)
                return new List<V_docto_provdevoWFBindingModel>();

            System.Collections.Generic.List<V_docto_provdevoWFBindingModel> items = new System.Collections.Generic.List<V_docto_provdevoWFBindingModel>();

            Task.Run(async () =>
            {

                items = await itemsProvider.Select_V_docto_provdevo_List(ListParam.P_empresaid!.Value, ListParam.P_sucursalid!.Value,
                                                                      ListParam.P_usuarioid, ListParam.P_tipodoctoid!.Value,
                                                                      ListParam.P_estatusdoctoid!.Value,
                                                                      ListParam.P_fechaini!.Value, ListParam.P_fechafin!.Value) ?? items;
            }).Wait();


            return items;
        }


        public override void Edititem(V_docto_provdevoWFBindingModel selected)
        {
            this.SelectedItem = selected;
        }

        public override void ShowItem(V_docto_provdevoWFBindingModel selected)
        {
            this.SelectedItem = selected;
        }


    }


}


