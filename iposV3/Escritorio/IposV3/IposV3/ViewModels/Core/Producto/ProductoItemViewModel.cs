
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
using System.Collections.ObjectModel;
using System.Threading;
using IposV3.BindingModel;

namespace IposV3.ViewModels
{

    public class ProductoItemViewModel : BaseWebRecordViewModel<ProductoBindingModel, ProductoWebController, ProductoItemVMInitialParameters, ProductoListVMEventParameters>
    {

        private KitdefinicionWebController kitDefinicionController;
        public KitdefinicionBindingModel? KitDefinicion { get; set; }
        public ObservableCollection<KitdefinicionBindingModel> KitItems { get; private set; }
        public string ModeKitDefinicion { get; protected set; }

        public string AcceptKitDefinicionRecordLabel { get { return (ModeKitDefinicion == "Add" ? "Agregar" : (ModeKitDefinicion == "Edit" ? "Cambiar" : "Eliminar")); } }

        private Prod_def_caracteristicasBindingModel? _prod_def_caracteristicas;
        public Prod_def_caracteristicasBindingModel? Prod_def_caracteristicas
        {
            get {
                return _prod_def_caracteristicas;
            }
            set {

                _prod_def_caracteristicas = value; NotifyOfPropertyChange("Prod_def_caracteristicas");
            }
        }

        private bool isBusyKitDefinicion;
        public bool IsBusyKitDefinicion
        {
            get
            {
                return isBusyKitDefinicion;
            }
            set
            {
                isBusyKitDefinicion = value;
                Opacity = isBusyKitDefinicion ? 0.5 : 1.0;
                NotifyOfPropertyChange("IsBusyKitDefinicion");

            }
        }


        public Dictionary<string, bool> BoolBindingExpression { get; set; }

        public GlobalSession? GlobalSession { get => GlobalVariable.CurrentSession; }

        public ProductoBindingModel? Producto { get { return Record; } set { Record = value; } }
        public ProductoItemViewModel(string mode, ProductoWebController provider, UsuarioWebController usuarioController , KitdefinicionWebController kitDefinicionController , SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(mode, provider, usuarioController , selectorProvider, aggregator, winManager, messageBoxService)
        {
            this.kitDefinicionController = kitDefinicionController;
            KitItems = new ObservableCollection<KitdefinicionBindingModel>();
            ModeKitDefinicion = "Add";

            this.prefillNewKitDefinicion();
            Task.Run(async () =>
            {
                Prod_def_caracteristicas = await this.provider.ObtenerProd_def_Caracterisiticas(new Prod_def_caracteristicasBindingModel()
                {
                    EmpresaId = GlobalVariable.CurrentSession!.Empresaid,
                    SucursalId = GlobalVariable.CurrentSession.Sucursalid
                });
            }).Wait();


            BoolBindingExpression = new Dictionary<string, bool>();
            fillBoolBindingExpressions();



        }


        //public ProductoItemViewModel(string mode, ProductoWebController provider,  KitdefinicionController kitDefinicionController , SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
        //    this(mode, provider, null, kitDefinicionController , selectorProvider, aggregator, winManager, messageBoxService)
        //{

        //}



        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("Producto","Proveedor","Proveedor1id", "Proveedor1Clave", "Proveedor1Nombre","IposV3.ViewModels.ProveedorListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Producto","Proveedor","Proveedor2id", "Proveedor2Clave", "Proveedor2Nombre","IposV3.ViewModels.ProveedorListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Producto","Linea","Lineaid", "LineaClave", "LineaNombre","IposV3.ViewModels.LineaListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Producto","Marca","Marcaid", "MarcaClave", "MarcaNombre","IposV3.ViewModels.MarcaListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Producto","Unidad","Unidadid", "UnidadClave", "UnidadNombre","IposV3.ViewModels.UnidadListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Producto","Emidaproduct","Producto_emida_Emidaproductoid", "Producto_emida_EmidaproductoClave", "Producto_emida_EmidaproductoNombre","IposV3.ViewModels.EmidaproductListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Producto","Sat_productoservicio","Producto_fact_elect_Sat_productoservicioid", "Producto_fact_elect_Sat_productoservicioClave", "Producto_fact_elect_Sat_productoservicioNombre","IposV3.ViewModels.Sat_productoservicioListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Producto","Sat_claveunidadpeso","Producto_fact_elect_Sat_Claveunidadpesoid", "Producto_fact_elect_Sat_ClaveunidadpesoClave", "Producto_fact_elect_Sat_ClaveunidadpesoNombre","IposV3.ViewModels.Sat_claveunidadpesoListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Producto","Sat_matpeligroso","Producto_fact_elect_Sat_Matpeligrosoid", "Producto_fact_elect_Sat_MatpeligrosoClave", "Producto_fact_elect_Sat_MatpeligrosoNombre","IposV3.ViewModels.Sat_matpeligrosoListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Producto","Origenfiscal","Producto_origenfiscal_Ultimoorigenfiscalventa", "Producto_origenfiscal_Ultimoorigenfiscalventa_Clave", "Producto_origenfiscal_Ultimoorigenfiscalventa_Nombre","IposV3.ViewModels.OrigenfiscalListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Producto","Plazo","Producto_poliza_Plazoid", "Producto_poliza_PlazoClave", "Producto_poliza_PlazoNombre","IposV3.ViewModels.PlazoListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Producto","Producto","Producto_promocion_Baseprodpromoid", "Producto_promocion_BaseprodpromoClave", "Producto_promocion_BaseprodpromoNombre","IposV3.ViewModels.ProductoListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Producto","Clasifica","Producto_miscelanea_Clasificaid", "Producto_miscelanea_ClasificaClave", "Producto_miscelanea_ClasificaNombre","IposV3.ViewModels.ClasificaListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Producto","Contenido","Producto_miscelanea_Contenidoid", "Producto_miscelanea_ContenidoClave", "Producto_miscelanea_ContenidoNombre","IposV3.ViewModels.ContenidoListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Producto","Producto","Producto_padre_Productopadreid", "Producto_padre_ProductopadreClave", "Producto_padre_ProductopadreNombre","IposV3.ViewModels.ProductoListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Producto","Moneda","Producto_precios_Monedaid", "Producto_precios_MonedaClave", "Producto_precios_MonedaNombre","IposV3.ViewModels.MonedaListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Producto","Producto","Substitutoid", "SubstitutoClave", "SubstitutoNombre","IposV3.ViewModels.ProductoListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("KitDefinicion","Producto","Productokitid", "ProductokitClave", "ProductokitNombre","IposV3.ViewModels.ProductoListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("KitDefinicion","Producto","Productoparteid", "ProductoparteClave", "ProductoparteNombre","IposV3.ViewModels.ProductoListViewModel","SelectedItem","Clave")
                                    };
            lstCatalogDef = new List<CatalogDef>();
            
            if (!lstCatalogDef.Any(y => y.CatalogName == "Sat_tipoembalaje"))
                lstCatalogDef.Add(new CatalogDef("Sat_tipoembalaje"));  
            if (!lstCatalogDef.Any(y => y.CatalogName == "Camporeferenciaprecio"))
                lstCatalogDef.Add(new CatalogDef("Camporeferenciaprecio"));  
            if (!lstCatalogDef.Any(y => y.CatalogName == "Camporeferenciaprecio"))
                lstCatalogDef.Add(new CatalogDef("Camporeferenciaprecio")); 

        }



        public override void RecordChangedEventHandler(object? sender, PropertyChangedEventArgs e)
        {

            switch (e.PropertyName)
            {
                case "Producto_loteimportado_Loteimportadoaplicado":
                    BoolBindingExpression["permitirEditarManejaLoteimportado"] = GlobalSession?.CurrentParametro?.Manejarloteimportacion == BoolCN.S &&
                                                                       (Record == null || !(Record.Producto_loteimportado_Loteimportadoaplicado == BoolCN.N));
                    NotifyOfPropertyChange("BoolBindingExpression");
                    break;

                case "UnidadClave":
                    BoolBindingExpression["unidadEsKg"] = Record != null && Record.UnidadClave != null && Record.UnidadClave == "KG";
                    NotifyOfPropertyChange("BoolBindingExpression");
                    break;

                case "Producto_kit_Eskit":
                    BoolBindingExpression["permitirEditarImpuestos"] = Record != null && (Record.Producto_kit_Eskit != BoolCN.S || Record.Producto_kit_Kitimpfijo == BoolCN.S);
                    BoolBindingExpression["permitirVerKit"] = Record != null && Record.Producto_kit_Eskit == BoolCN.S;
                    BoolBindingExpression["permitirEditarKit"] = Record != null && Record.Producto_kit_Eskit == BoolCN.S && Record.Producto_existencia_Existencia == 0;
                    NotifyOfPropertyChange("BoolBindingExpression");
                    break;


                default:
                    break;
            }
        }

        private void fillBoolBindingExpressions()
        {

            BoolBindingExpression.Add("permitirEditarCostos" , !BIsReadOnly && (DerechosUsuario?[Model.DBValues._DERECHO_MOSTRARCOSTOS] ?? false));
            BoolBindingExpression.Add("permitirEditarCostoReposicion" , !BIsReadOnly && (DerechosUsuario?[Model.DBValues._DERECHO_EDITARCOSTOREPO] ?? false)); 

            BoolBindingExpression.Add("permisoParaVerHistorial" ,  (DerechosUsuario?[Model.DBValues._DERECHO_BITACORA_PRODUCTO] ?? false));

            BoolBindingExpression.Add("permitirEditarPrecio1", !BIsReadOnly && ((GlobalSession?.CurrentUsuario?.Usuario_Preferencias_Listaprecioid ?? 0) - 3) >= 1);
            BoolBindingExpression.Add("permitirEditarPrecio2", !BIsReadOnly && ((GlobalSession?.CurrentUsuario?.Usuario_Preferencias_Listaprecioid ?? 0) - 3) >= 2);
            BoolBindingExpression.Add("permitirEditarPrecio3", !BIsReadOnly && ((GlobalSession?.CurrentUsuario?.Usuario_Preferencias_Listaprecioid ?? 0) - 3) >= 3);
            BoolBindingExpression.Add("permitirEditarPrecio4", !BIsReadOnly && ((GlobalSession?.CurrentUsuario?.Usuario_Preferencias_Listaprecioid ?? 0) - 3) >= 4);
            BoolBindingExpression.Add("permitirEditarPrecio5", !BIsReadOnly && ((GlobalSession?.CurrentUsuario?.Usuario_Preferencias_Listaprecioid ?? 0) - 3) >= 5);


            BoolBindingExpression.Add("empresaDesglosaIeps", GlobalSession?.CurrentParametro?.Desgloseieps == BoolCN.S);
            BoolBindingExpression.Add("empresaEsArrendatario", GlobalSession?.CurrentParametro?.Arrendatario == BoolCN.S);
            BoolBindingExpression.Add("empresaManejaSuperListaPrecio", GlobalSession?.CurrentParametro?.Manejasuperlistaprecio == BoolCN.S);
            BoolBindingExpression.Add("empresaManejaUtilidadPrecios", GlobalSession?.CurrentParametro?.Manejautilidadprecios == BoolCN.S);
            BoolBindingExpression.Add("empresaManejaReceta", GlobalSession?.CurrentParametro?.Manejareceta == BoolCN.S);

            BoolBindingExpression.Add("permitirEditarManejaLoteimportado", GlobalSession?.CurrentParametro?.Manejarloteimportacion == BoolCN.S &&
                                                               (Record == null ||  !(Record.Producto_loteimportado_Loteimportadoaplicado == BoolCN.N )));


            BoolBindingExpression.Add("permitirVerManejaLoteimportado", GlobalSession?.CurrentParametro?.Manejarloteimportacion == BoolCN.S );


            BoolBindingExpression.Add("empresaManejaPlazoXProducto", GlobalSession?.CurrentParametro?.Plazoxproducto == BoolCN.S);


            BoolBindingExpression.Add("labelTexto1Asignado", Prod_def_caracteristicas != null && !string.IsNullOrEmpty(Prod_def_caracteristicas!.Texto1));
            BoolBindingExpression.Add("labelTexto2Asignado", Prod_def_caracteristicas != null && !string.IsNullOrEmpty(Prod_def_caracteristicas!.Texto2));
            BoolBindingExpression.Add("labelTexto3Asignado", Prod_def_caracteristicas != null && !string.IsNullOrEmpty(Prod_def_caracteristicas!.Texto3));
            BoolBindingExpression.Add("labelTexto4Asignado", Prod_def_caracteristicas != null && !string.IsNullOrEmpty(Prod_def_caracteristicas!.Texto4));
            BoolBindingExpression.Add("labelTexto5Asignado", Prod_def_caracteristicas != null && !string.IsNullOrEmpty(Prod_def_caracteristicas!.Texto5));
            BoolBindingExpression.Add("labelTexto6Asignado", Prod_def_caracteristicas != null && !string.IsNullOrEmpty(Prod_def_caracteristicas!.Texto6));
            BoolBindingExpression.Add("labelNumero1Asignado", Prod_def_caracteristicas != null && !string.IsNullOrEmpty(Prod_def_caracteristicas!.Numero1));
            BoolBindingExpression.Add("labelNumero2Asignado", Prod_def_caracteristicas != null && !string.IsNullOrEmpty(Prod_def_caracteristicas!.Numero2));
            BoolBindingExpression.Add("labelNumero3Asignado", Prod_def_caracteristicas != null && !string.IsNullOrEmpty(Prod_def_caracteristicas!.Numero3));
            BoolBindingExpression.Add("labelNumero4Asignado", Prod_def_caracteristicas != null && !string.IsNullOrEmpty(Prod_def_caracteristicas!.Numero4));
            BoolBindingExpression.Add("labelFecha1Asignado", Prod_def_caracteristicas != null && !string.IsNullOrEmpty(Prod_def_caracteristicas!.Fecha1));
            BoolBindingExpression.Add("labelFecha2Asignado", Prod_def_caracteristicas != null && !string.IsNullOrEmpty(Prod_def_caracteristicas!.Fecha2));

            BoolBindingExpression.Add("unidadEsKg", Record != null && Record.UnidadClave != null && Record.UnidadClave == "KG");

            BoolBindingExpression.Add("permitirEditarInventariable", ((Record?.Producto_existencia_Existencia ?? 0) == 0)); //= si no hay aun movimientos en movto de este producto

            BoolBindingExpression.Add("permitirEditarImpuestos", Record != null || (Record?.Producto_kit_Eskit != BoolCN.S || Record?.Producto_kit_Kitimpfijo == BoolCN.S));

            BoolBindingExpression.Add("permitirVerKit", Record != null && Record.Producto_kit_Eskit == BoolCN.S);
            BoolBindingExpression.Add("permitirEditarKit", Record != null && Record.Producto_kit_Eskit == BoolCN.S && Record.Producto_existencia_Existencia == 0);

            BoolBindingExpression.Add("verSucursalExportacion", Record != null && Record.Producto_kit_Eskit == BoolCN.S && GlobalSession?.CurrentSucursalInfo?.Esmatriz == BoolCN.S);


            NotifyOfPropertyChange("BoolBindingExpression");

        }

        protected void refillBoolBindingExpressionsByRecord()
        {

            BoolBindingExpression["permitirEditarManejaLoteimportado"] = (GlobalSession?.CurrentParametro?.Manejarloteimportacion == BoolCN.S &&
                                                               (Record == null || !(Record.Producto_loteimportado_Loteimportadoaplicado == BoolCN.N)));


            BoolBindingExpression["permitirVerManejaLoteimportado"] = (GlobalSession?.CurrentParametro?.Manejarloteimportacion == BoolCN.S);


            BoolBindingExpression["empresaManejaPlazoXProducto"] = (GlobalSession?.CurrentParametro?.Plazoxproducto == BoolCN.S);


            BoolBindingExpression["labelTexto1Asignado"] =  (Prod_def_caracteristicas != null && !string.IsNullOrEmpty(Prod_def_caracteristicas!.Texto1));
            BoolBindingExpression["labelTexto2Asignado"] =  (Prod_def_caracteristicas != null && !string.IsNullOrEmpty(Prod_def_caracteristicas!.Texto2));
            BoolBindingExpression["labelTexto3Asignado"] =  (Prod_def_caracteristicas != null && !string.IsNullOrEmpty(Prod_def_caracteristicas!.Texto3));
            BoolBindingExpression["labelTexto4Asignado"] =  (Prod_def_caracteristicas != null && !string.IsNullOrEmpty(Prod_def_caracteristicas!.Texto4));
            BoolBindingExpression["labelTexto5Asignado"] =  (Prod_def_caracteristicas != null && !string.IsNullOrEmpty(Prod_def_caracteristicas!.Texto5));
            BoolBindingExpression["labelTexto6Asignado"] =  (Prod_def_caracteristicas != null && !string.IsNullOrEmpty(Prod_def_caracteristicas!.Texto6));
            BoolBindingExpression["labelNumero1Asignado"] =  (Prod_def_caracteristicas != null && !string.IsNullOrEmpty(Prod_def_caracteristicas!.Numero1));
            BoolBindingExpression["labelNumero2Asignado"] =  (Prod_def_caracteristicas != null && !string.IsNullOrEmpty(Prod_def_caracteristicas!.Numero2));
            BoolBindingExpression["labelNumero3Asignado"] =  (Prod_def_caracteristicas != null && !string.IsNullOrEmpty(Prod_def_caracteristicas!.Numero3));
            BoolBindingExpression["labelNumero4Asignado"] = (Prod_def_caracteristicas != null && !string.IsNullOrEmpty(Prod_def_caracteristicas!.Numero4));
            BoolBindingExpression["labelFecha1Asignado"] = (Prod_def_caracteristicas != null && !string.IsNullOrEmpty(Prod_def_caracteristicas!.Fecha1));
            BoolBindingExpression["labelFecha2Asignado"] = (Prod_def_caracteristicas != null && !string.IsNullOrEmpty(Prod_def_caracteristicas!.Fecha2));

            BoolBindingExpression["unidadEsKg"] = (Record != null && Record.UnidadClave != null && Record.UnidadClave == "KG");

            BoolBindingExpression["permitirEditarInventariable"] = (((Record?.Producto_existencia_Existencia ?? 0) == 0)); //= si no hay aun movimientos en movto de este producto

            BoolBindingExpression["permitirEditarImpuestos"] = (Record != null || (Record?.Producto_kit_Eskit != BoolCN.S || Record?.Producto_kit_Kitimpfijo == BoolCN.S));

            BoolBindingExpression["permitirVerKit"] =  (Record != null && Record.Producto_kit_Eskit == BoolCN.S);
            BoolBindingExpression["permitirEditarKit"] = true; //(Record != null && Record.Producto_kit_Eskit == BoolCN.S && Record.Producto_existencia_Existencia == 0);

            BoolBindingExpression["verSucursalExportacion"] = (Record != null && Record.Producto_kit_Eskit == BoolCN.S && GlobalSession?.CurrentSucursalInfo?.Esmatriz == BoolCN.S);


            NotifyOfPropertyChange("BoolBindingExpression");
        }



        protected override System.Collections.Generic.List<long> DerechosToCheck()
        {
            return new System.Collections.Generic.List<long>{

                                   Model.DBValues._DERECHO_MOSTRARCOSTOS,
                                   Model.DBValues._DERECHO_EDITARCOSTOREPO,
                                   Model.DBValues._DERECHO_BITACORA_PRODUCTO

            };
        }

        public void prefillNewKitDefinicion()
        {

            KitDefinicion = new KitdefinicionBindingModel();
            KitDefinicion.EmpresaId = GlobalVariable.CurrentSession!.Empresaid;
            KitDefinicion.SucursalId = GlobalVariable.CurrentSession.Sucursalid;
            KitDefinicion.Productokitid = Record?.Id;
            KitDefinicion.PendingChange += CatalogField_PropertyChanging;
        }
           


        public void LlenarItemsKitDefinicion()
        {

            KitItems.Clear();
            try
            {
                bool bSuccess = true;
                IsBusyKitDefinicion = true;
                var comentario = "";
                System.Collections.Generic.List<KitdefinicionBindingModel> kitItems = new System.Collections.Generic.List<KitdefinicionBindingModel>();

                
                Task.Run<List<KitdefinicionBindingModel>>(async () =>
                                                      await DoGetItemsKitDefinicion()
                                                 ).ContinueWith((t) =>
                {
                    IsBusyKitDefinicion = false;

                    if (t.IsFaulted)
                    {
                        BProcessSuccess = false;
                        if (t.Exception != null)
                        {

                            comentario = t.Exception.Message;
                        }
                        else
                        {
                            comentario = "Ocurrio un Fault";
                        }
                        showPopUpMessage("Ocurrio un error ", comentario, "Error");
                    }
                    else if (t.IsCompleted)
                    {
                        if (bSuccess)
                        {
                            kitItems = t.Result;
                            foreach (var item in kitItems)
                            {
                                this.KitItems.Add(item);
                            }
                        }
                        else { showPopUpMessage("Ocurrio un error ", comentario, "Error"); }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());

                //BackgroundWorker worker = new BackgroundWorker();
                //worker.DoWork += (o, ea) =>
                //{
                //    try
                //    {
                //        kitItems = DoGetItemsKitDefinicion();
                //    }
                //    catch (Exception ex) { bSuccess = false; comentario = ex.Message; }
                //};
                //worker.RunWorkerCompleted += (o, ea) =>
                //{
                //    IsBusyKitDefinicion = false;
                //    if (bSuccess)
                //    {
                //        foreach (var item in kitItems)
                //        {
                //            this.KitItems.Add(item);
                //        }
                //        //ItemsLoadedText = "Loaded!";
                //    }
                //    else { showPopUpMessage("Ocurrio un error ", comentario, "Error"); }

                //};
                //worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }
        }


        public virtual async Task<System.Collections.Generic.List<KitdefinicionBindingModel>> DoGetItemsKitDefinicion()
        {

            if (this.Record?.Id == null)
                return new List<KitdefinicionBindingModel>();

            KitdefinicionParam listKitParam = new KitdefinicionParam();

            listKitParam.P_empresaid = GlobalVariable.CurrentSession!.Empresaid;
            listKitParam.P_sucursalid = GlobalVariable.CurrentSession.Sucursalid;


            var kendoKitParams = new KendoParams();
            kendoKitParams.Filter = new KendoFilters(
                 new List<KendoFilter>() { new KendoFilter(this.Record.Id.ToString()!, "eq", "Productokitid", "false") }, "and");

            System.Collections.Generic.List<KitdefinicionBindingModel> items = new System.Collections.Generic.List<KitdefinicionBindingModel>();


             items = await this.kitDefinicionController.SelectList(listKitParam, kendoKitParams);
            
            
            return items;
        }


        public void GoToEdititemKitDefincion(KitdefinicionBindingModel selected)
        {
            this.ModeKitDefinicion = "Edit";
            this.KitDefinicion = selected;
            NotifyOfPropertyChange("KitDefinicion");
            NotifyOfPropertyChange("ModeKitDefinicion");
            NotifyOfPropertyChange("AcceptKitDefinicionRecordLabel");
        }

        public void GoToDeleteitemKitDefincion(KitdefinicionBindingModel selected)
        {
            this.ModeKitDefinicion = "Delete";
            this.KitDefinicion = selected;
            NotifyOfPropertyChange("KitDefinicion");
            NotifyOfPropertyChange("ModeKitDefinicion");
            NotifyOfPropertyChange("AcceptKitDefinicionRecordLabel");
        }


        public void GoToAddKitDefincion()
        {
            this.ModeKitDefinicion = "Add";
            prefillNewKitDefinicion();
            NotifyOfPropertyChange("KitDefinicion");
            NotifyOfPropertyChange("ModeKitDefinicion");
            NotifyOfPropertyChange("AcceptKitDefinicionRecordLabel");
        }


        public void CancelKitDefinicion()
        {
            GoToAddKitDefincion();
        }

        public void AcceptKitDefinicion()
        {

            if (this.ModeKitDefinicion == "Edit")
            {
                AcceptEditKitDefinicion();
            }
            else if (this.ModeKitDefinicion == "Add")
            {
                AcceptAddKitDefinicion();
            }
            else if (this.ModeKitDefinicion == "Delete")
            {
                AcceptDeleteKitDefinicion();
            }
        }

        public virtual void AcceptEditKitDefinicion()
        {

            if (KitDefinicion == null)
                return;

            KitDefinicion.ModificadoPorId = GlobalVariable.CurrentSession?.Usuarioid;

            try
            {

                bool bSuccess = true;
                IsBusyKitDefinicion = true;
                var comentario = "";


                
                Task.Run(async () =>
                                                      await doUpdateKitDefinicion()
                                                 ).ContinueWith((t) =>
                {
                    IsBusyKitDefinicion = false;

                    if (t.IsFaulted)
                    {
                        BProcessSuccess = false;
                        if (t.Exception != null)
                        {

                            comentario = t.Exception.Message;
                        }
                        else
                        {
                            comentario = "Ocurrio un Fault";
                        }
                        showPopUpMessage("Ocurrio un error ", comentario, "Error");
                    }
                    else if (t.IsCompleted)
                    {

                        BProcessSuccess = bSuccess;
                        if (BProcessSuccess)
                        {
                            LlenarItemsKitDefinicion();
                            GoToAddKitDefincion();
                        }
                        else
                        {
                            showPopUpMessage("Ocurrio un error ", comentario, "Error");
                        }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());

            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }

        }


        public virtual void AcceptAddKitDefinicion()
        {
            if (KitDefinicion == null)
                return;

            KitDefinicion.Creado = DateTime.Now;
            KitDefinicion.Modificado = DateTime.Now;
            KitDefinicion.EmpresaId = GlobalVariable.CurrentSession!.Empresaid;
            KitDefinicion.SucursalId = GlobalVariable.CurrentSession.Sucursalid;
            KitDefinicion.Productokitid = Record?.Id;

            try
            {

                bool bSuccess = true;
                IsBusyKitDefinicion = true;
                var comentario = "";
                
                Task.Run(async () =>
                                        await doInsertKitDefinicion()
                        ).ContinueWith((t) =>
                {
                    IsBusyKitDefinicion = false;

                    if (t.IsFaulted)
                    {
                        BProcessSuccess = false;
                        if (t.Exception != null)
                        {

                            comentario = t.Exception.Message;
                        }
                        else
                        {
                            comentario = "Ocurrio un Fault";
                        }
                        showPopUpMessage("Ocurrio un error ", comentario, "Error");
                    }
                    else if (t.IsCompleted)
                    {

                        BProcessSuccess = bSuccess;
                        if (BProcessSuccess)
                        {
                            LlenarItemsKitDefinicion();
                            GoToAddKitDefincion();
                        }
                        else
                        {
                            showPopUpMessage("Ocurrio un error ", comentario, "Error");
                        }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());

                //BackgroundWorker worker = new BackgroundWorker();
                //worker.DoWork += (o, ea) =>
                //{
                //    try
                //    {
                //        doInsertKitDefinicion();
                //    }
                //    catch (Exception ex) { bSuccess = false; comentario = ex.Message; }
                //};
                //worker.RunWorkerCompleted += (o, ea) =>
                //{
                //    IsBusyKitDefinicion = false;

                //    BProcessSuccess = bSuccess;
                //    if (BProcessSuccess)
                //    {
                //        LlenarItemsKitDefinicion();
                //        GoToAddKitDefincion();
                //    }
                //    else
                //    {
                //        showPopUpMessage("Ocurrio un error ", comentario, "Error");
                //    }

                //};
                //worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }
        }


        public virtual void AcceptDeleteKitDefinicion()
        {

            if (KitDefinicion == null)
                return;

            KitDefinicion.ModificadoPorId = GlobalVariable.CurrentSession?.Usuarioid;

            try
            {

                bool bSuccess = true;
                IsBusyKitDefinicion = true;
                var comentario = "";

                
                Task.Run(async () =>
                                                      await doDeleteKitDefinicion()
                                                 ).ContinueWith((t) =>
                {
                    IsBusyKitDefinicion = false;

                    if (t.IsFaulted)
                    {
                        BProcessSuccess = false;
                        if (t.Exception != null)
                        {

                            comentario = t.Exception.Message;
                        }
                        else
                        {
                            comentario = "Ocurrio un Fault";
                        }
                        showPopUpMessage("Ocurrio un error ", comentario, "Error");
                    }
                    else if (t.IsCompleted)
                    {
                        BProcessSuccess = bSuccess;
                        if (BProcessSuccess)
                        {
                            LlenarItemsKitDefinicion();
                            GoToAddKitDefincion();
                        }
                        else
                        {
                            showPopUpMessage("Ocurrio un error ", comentario, "Error");
                        }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());


                //BackgroundWorker worker = new BackgroundWorker();
                //worker.DoWork += (o, ea) =>
                //{
                //    try
                //    {
                //        doDeleteKitDefinicion();
                //    }
                //    catch (Exception ex) { bSuccess = false; comentario = ex.Message; }
                //};
                //worker.RunWorkerCompleted += (o, ea) =>
                //{
                //    IsBusyKitDefinicion = false;

                //    BProcessSuccess = bSuccess;
                //    if (BProcessSuccess)
                //    {
                //        LlenarItemsKitDefinicion();
                //        GoToAddKitDefincion();
                //    }
                //    else
                //    {
                //        showPopUpMessage("Ocurrio un error ", comentario, "Error");
                //    }
                //};
                //worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }

        }

        protected virtual async Task doInsertKitDefinicion()
        {
            if (KitDefinicion == null)
                return;

            IposV3.Services.ImpuestoKitDefinicion? impuestosKit = null;


             impuestosKit = await this.kitDefinicionController.InsertYModificarImpuestosSiAplica(KitDefinicion);



            if(impuestosKit != null)
            {
                Producto!.Iepsimpuesto = impuestosKit.Ieps;
                Producto!.Iepsimpuesto = impuestosKit.Ieps;
            }
        }

        protected virtual async Task doUpdateKitDefinicion()
        {
            if (KitDefinicion == null)
                return;

            IposV3.Services.ImpuestoKitDefinicion? impuestosKit = null;

            impuestosKit = await kitDefinicionController.UpdateYModificarImpuestosSiAplica(KitDefinicion);



            if (impuestosKit != null)
            {
                Producto!.Iepsimpuesto = impuestosKit.Ieps;
                Producto!.Iepsimpuesto = impuestosKit.Ieps;
            }
        }


        protected virtual async Task doDeleteKitDefinicion()
        {
            if (KitDefinicion == null)
                return;

            IposV3.Services.ImpuestoKitDefinicion? impuestosKit = null;

            impuestosKit = await kitDefinicionController.DeleteYModificarImpuestosSiAplica(KitDefinicion);



            if (impuestosKit != null)
            {
                Producto!.Iepsimpuesto = impuestosKit.Ieps;
                Producto!.Iepsimpuesto = impuestosKit.Ieps;
            }
        }



    }


    public class ProductoShowViewModel : ProductoItemViewModel
    {
        public ProductoShowViewModel(ProductoWebController provider, UsuarioWebController usuarioController , KitdefinicionWebController kitdefinicionController , SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, usuarioController , kitdefinicionController , selectorProvider, aggregator, winManager, messageBoxService)
        {
        }

        protected override Task OnActivateAsync(CancellationToken cancellationToken)
        {
            refillBoolBindingExpressionsByRecord();
            this.LlenarItemsKitDefinicion();
            return Task.FromResult(true);
        }

    }

    public class ProductoEditViewModel : ProductoItemViewModel
    {
        public ProductoEditViewModel(ProductoWebController provider, UsuarioWebController usuarioController , KitdefinicionWebController kitdefinicionController , SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, usuarioController , kitdefinicionController , selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
        protected override Task OnActivateAsync(CancellationToken cancellationToken)
        {
            refillBoolBindingExpressionsByRecord();
            this.LlenarItemsKitDefinicion();
            return Task.FromResult(true);
        }
    }

    public class ProductoAddViewModel : ProductoItemViewModel
    {
        public ProductoAddViewModel(ProductoWebController provider, UsuarioWebController usuarioController , KitdefinicionWebController kitdefinicionController , SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, usuarioController , kitdefinicionController , selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

}


