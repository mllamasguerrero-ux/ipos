
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
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.ViewModels
{

    public class PuntoVentaListViewModel : BaseGenericListViewModel<V_docto_vendeduriaWFBindingModel,
                                                                     PuntoVentaListVMInitialParameters,  PuntoVentaListVMEventParameters, V_docto_vendeduriaParamWFBindingModel>
    {



        protected readonly PuntoVentaWebController itemsProvider;
        public V_docto_vendeduriaWFBindingModel? V_docto_vendeduriaItem { get; set; }


        public bool BShowAlmacen { get; set; }
        public bool BEnableAlmacen { get; set; }

        public PuntoVentaListViewModel(SelectorWebController selectorProvider, PuntoVentaWebController controllerProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(null, selectorProvider, winManager, aggregator, messageBoxService)
        {
            V_docto_vendeduriaItem = new V_docto_vendeduriaWFBindingModel();
            V_docto_vendeduriaItem!.PendingChange += CatalogField_PropertyChanging;

            itemsProvider = controllerProvider;

        }



        protected override List<long> DerechosEstandarToCheck()
        {
            List<long> list = new List<long>();
            list.Add(DBValues._DERECHO_FILTARPORALMACEN);
            return list;
        }


        protected override void fillCatalogConfiguration()
        {

            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("ListParam","Usuario","P_usuarioid", "P_usuarioclave", "P_usuarionombre","IposV3.ViewModels.UsuarioListViewModel","SelectedItem","Username")
                                    };
            lstCatalogDef = new List<CatalogDef>() { new CatalogDef(
                    "Tipodocto_Vendeduria"),new CatalogDef(
                    "Estatusdocto_Vendeduria"),new CatalogDef(
                    "Almacen")
         };
        }



        protected override void preFillParam()
        {

            ListParam = new V_docto_vendeduriaParamWFBindingModel();
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
                ListParam.P_corteActual = BoolCS.S;
                ListParam.P_todosUsuarios = BoolCS.N;
                ListParam.P_todosAlmacenes = BoolCS.S;
                ListParam.P_porFecha = BoolCS.S;
            }
        }


        public void FillParamsByConfig()
        {
            ListParam!.P_todosAlmacenes = BoolCS.S;
            if (GlobalVariable.CurrentSession!.CurrentParametro!.Manejaalmacen == BoolCN.S)
            {

                this.BShowAlmacen = true;
                this.BEnableAlmacen = this.DerechosUsuario![DBValues._DERECHO_FILTARPORALMACEN] == true;

                var almacenItem = this.Catalogs!["Almacen"]!.FirstOrDefault(a => a.Id == DBValues._ALMACEN_DEFAULT);

                if (almacenItem != null)
                {

                    this.ListParam.P_almacenid = almacenItem.Id;
                    this.ListParam.P_almacenclave = almacenItem.Clave;
                    this.ListParam.P_almacennombre = almacenItem.Nombre;
                }


            }
            else
            {
                this.BShowAlmacen = false;
                this.BEnableAlmacen = false;

            }
        }


        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);

            if (ListParam != null)
                ListParam.PendingChange += CatalogField_PropertyChanging;
        }



        public override System.Collections.Generic.List<V_docto_vendeduriaWFBindingModel> DoGetItems()
        {
            if (ListParam == null)
                return new List<V_docto_vendeduriaWFBindingModel>();

            System.Collections.Generic.List<V_docto_vendeduriaWFBindingModel> items = new System.Collections.Generic.List<V_docto_vendeduriaWFBindingModel>();


            

            Task.Run(async () =>
            {
                items = await itemsProvider.Select_V_docto_vendeduria_List(ListParam.P_empresaid!.Value, ListParam.P_sucursalid!.Value,
                                                                  ListParam.P_usuarioid, ListParam.P_tipodoctoid!.Value,
                                                                  ListParam.P_estatusdoctoid!.Value,
                                                                  ListParam.P_fechaini!.Value, ListParam.P_fechafin!.Value, ListParam.P_corteActual,
                                                                  ListParam.P_almacenid, ListParam.P_todosAlmacenes, ListParam.P_porFecha, ListParam.P_todosUsuarios) ?? items;
            }).Wait();

            return items;
        }


        public override void Edititem(V_docto_vendeduriaWFBindingModel selected)
        {
            this.SelectedItem = selected;
        }

        public override void ShowItem(V_docto_vendeduriaWFBindingModel selected)
        {
            this.SelectedItem = selected;
        }
    }
}
