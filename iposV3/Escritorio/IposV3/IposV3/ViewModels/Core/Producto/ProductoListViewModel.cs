
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
using Models.CatalogSelector;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.ViewModels
{

    public class ProductoListViewModel : BaseWebListViewModel<ProductoBindingModel, ProductoWebController, ProductoItemVMInitialParameters, ProductoListVMEventParameters, ProductoParam>
    {

        public ObservableCollection<ProductoListBindingModel> ItemsSimple { get; private set; }

        //private UsuarioController _usuarioControllerProvider;

        private Dictionary<string,ColumnConfig>? columnConfigs;
        public Dictionary<string, ColumnConfig>? ColumnConfigs { get => columnConfigs; set { columnConfigs = value; NotifyOfPropertyChange("ColumnConfigs"); } }

        public string Test { get; set; } = "Test";
        public Double TestWidth { get; set; } = 100;

        public ProductoListViewModel(ProductoWebController provider, UsuarioWebController usuarioControllerProvider, SelectorWebController selectorProvider, IWindowManager winManager, IEventAggregator aggregator, IMessageBoxService messageBoxService) :
                            base(provider, usuarioControllerProvider, selectorProvider, winManager, aggregator, messageBoxService, true)
        {
            ItemsSimple = new ObservableCollection<ProductoListBindingModel>();
            //_usuarioControllerProvider = usuarioControllerProvider;

            if(GlobalVariable.CurrentSession?.CurrentLookups != null)
            {
                var listadoProducto = GlobalVariable.CurrentSession?.CurrentLookups!.FirstOrDefault(y => y.Clave == "PRODUCTO");
                

                columnConfigs = new Dictionary<string, ColumnConfig>();

                var defaultSize = (listadoProducto != null ? 0 : Double.NaN);

                columnConfigs.Add("Clave", new ColumnConfig((listadoProducto?.Lbl_campo1 ?? CampoEnLista._descripcionSistemaProductos[0].ToUpper()), (listadoProducto?.Campo1 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Descripcion1", new ColumnConfig((listadoProducto?.Lbl_campo2 ?? CampoEnLista._descripcionSistemaProductos[1].ToUpper()), (listadoProducto?.Campo2 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Descripcion2", new ColumnConfig((listadoProducto?.Lbl_campo3 ?? CampoEnLista._descripcionSistemaProductos[2].ToUpper()), (listadoProducto?.Campo3 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Productocaracteristicas_Texto1", new ColumnConfig((listadoProducto?.Lbl_campo4 ?? CampoEnLista._descripcionSistemaProductos[3].ToUpper()), (listadoProducto?.Campo4 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Productocaracteristicas_Texto2", new ColumnConfig((listadoProducto?.Lbl_campo5 ?? CampoEnLista._descripcionSistemaProductos[4].ToUpper()), (listadoProducto?.Campo5 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Productocaracteristicas_Texto3", new ColumnConfig((listadoProducto?.Lbl_campo6 ?? CampoEnLista._descripcionSistemaProductos[5].ToUpper()), (listadoProducto?.Campo6 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Productocaracteristicas_Texto4", new ColumnConfig((listadoProducto?.Lbl_campo7 ?? CampoEnLista._descripcionSistemaProductos[6].ToUpper()), (listadoProducto?.Campo7 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Productocaracteristicas_Texto5", new ColumnConfig((listadoProducto?.Lbl_campo8 ?? CampoEnLista._descripcionSistemaProductos[7].ToUpper()), (listadoProducto?.Campo8 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Productocaracteristicas_Texto6", new ColumnConfig((listadoProducto?.Lbl_campo9 ?? CampoEnLista._descripcionSistemaProductos[8].ToUpper()), (listadoProducto?.Campo9 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Productocaracteristicas_Numero1", new ColumnConfig((listadoProducto?.Lbl_campo10 ?? CampoEnLista._descripcionSistemaProductos[9].ToUpper()), (listadoProducto?.Campo10 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Productocaracteristicas_Numero2", new ColumnConfig((listadoProducto?.Lbl_campo11 ?? CampoEnLista._descripcionSistemaProductos[10].ToUpper()), (listadoProducto?.Campo11 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Productocaracteristicas_Numero3", new ColumnConfig((listadoProducto?.Lbl_campo12 ?? CampoEnLista._descripcionSistemaProductos[11].ToUpper()), (listadoProducto?.Campo12 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Productocaracteristicas_Numero4", new ColumnConfig((listadoProducto?.Lbl_campo13 ?? CampoEnLista._descripcionSistemaProductos[12].ToUpper()), (listadoProducto?.Campo13 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Producto_precios_Precio1", new ColumnConfig((listadoProducto?.Lbl_campo14 ?? CampoEnLista._descripcionSistemaProductos[13].ToUpper()), (listadoProducto?.Campo14 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Producto_precios_Precio2", new ColumnConfig((listadoProducto?.Lbl_campo15 ?? CampoEnLista._descripcionSistemaProductos[14].ToUpper()), (listadoProducto?.Campo15 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Producto_precios_Precio3", new ColumnConfig((listadoProducto?.Lbl_campo16 ?? CampoEnLista._descripcionSistemaProductos[15].ToUpper()), (listadoProducto?.Campo16 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Producto_precios_Precio4", new ColumnConfig((listadoProducto?.Lbl_campo17 ?? CampoEnLista._descripcionSistemaProductos[16].ToUpper()), (listadoProducto?.Campo17 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Producto_precios_Precio5", new ColumnConfig((listadoProducto?.Lbl_campo18 ?? CampoEnLista._descripcionSistemaProductos[17].ToUpper()), (listadoProducto?.Campo18 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Producto_precios_Precio1_conImp", new ColumnConfig((listadoProducto?.Lbl_campo19 ?? CampoEnLista._descripcionSistemaProductos[18].ToUpper()), (listadoProducto?.Campo19 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Producto_precios_Precio2_conImp", new ColumnConfig((listadoProducto?.Lbl_campo20 ?? CampoEnLista._descripcionSistemaProductos[19].ToUpper()), (listadoProducto?.Campo20 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Producto_precios_Precio3_conImp", new ColumnConfig((listadoProducto?.Lbl_campo21 ?? CampoEnLista._descripcionSistemaProductos[20].ToUpper()), (listadoProducto?.Campo21 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Producto_precios_Precio4_conImp", new ColumnConfig((listadoProducto?.Lbl_campo22 ?? CampoEnLista._descripcionSistemaProductos[21].ToUpper()), (listadoProducto?.Campo22 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Producto_precios_Precio5_conImp", new ColumnConfig((listadoProducto?.Lbl_campo23 ?? CampoEnLista._descripcionSistemaProductos[22].ToUpper()), (listadoProducto?.Campo23 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Producto_precios_caja_conImp", new ColumnConfig((listadoProducto?.Lbl_campo24 ?? CampoEnLista._descripcionSistemaProductos[23].ToUpper()), (listadoProducto?.Campo24 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Ivaimpuesto", new ColumnConfig((listadoProducto?.Lbl_campo25 ?? CampoEnLista._descripcionSistemaProductos[24].ToUpper()), (listadoProducto?.Campo25 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Producto_precios_Limiteprecio2", new ColumnConfig((listadoProducto?.Lbl_campo26 ?? CampoEnLista._descripcionSistemaProductos[25].ToUpper()), (listadoProducto?.Campo26 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Ean", new ColumnConfig((listadoProducto?.Lbl_campo27 ?? CampoEnLista._descripcionSistemaProductos[26].ToUpper()), (listadoProducto?.Campo27 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Producto_existencia_Existencia", new ColumnConfig((listadoProducto?.Lbl_campo28 ?? CampoEnLista._descripcionSistemaProductos[27].ToUpper()), (listadoProducto?.Campo28 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Existencia_Apartados", new ColumnConfig((listadoProducto?.Lbl_campo29 ?? CampoEnLista._descripcionSistemaProductos[28].ToUpper()), (listadoProducto?.Campo29 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Producto_existencia_Enprocesodesalida", new ColumnConfig((listadoProducto?.Lbl_campo30 ?? CampoEnLista._descripcionSistemaProductos[29].ToUpper()), (listadoProducto?.Campo30 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Iepsimpuesto", new ColumnConfig((listadoProducto?.Lbl_campo31 ?? CampoEnLista._descripcionSistemaProductos[30].ToUpper()), (listadoProducto?.Campo31 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Existencia_Almacen1", new ColumnConfig((listadoProducto?.Lbl_campo32 ?? "ALMACEN 1"), (listadoProducto?.Campo31 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Existencia_Almacen2", new ColumnConfig((listadoProducto?.Lbl_campo32 ?? "ALMACEN 2"), (listadoProducto?.Campo31 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Existencia_Almacen3", new ColumnConfig((listadoProducto?.Lbl_campo32 ?? "ALMACEN 3"), (listadoProducto?.Campo31 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Producto_precios_Preciomediomayoreocontarjeta", new ColumnConfig((listadoProducto?.Lbl_campo33 ?? CampoEnLista._descripcionSistemaProductos[32].ToUpper()), (listadoProducto?.Campo33 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Producto_precios_Preciomayoreocontarjeta", new ColumnConfig((listadoProducto?.Lbl_campo34 ?? CampoEnLista._descripcionSistemaProductos[33].ToUpper()), (listadoProducto?.Campo34 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Cempaque", new ColumnConfig((listadoProducto?.Lbl_campo35 ?? CampoEnLista._descripcionSistemaProductos[34].ToUpper()), (listadoProducto?.Campo35 == BoolCN.S ? Double.NaN : defaultSize)));
                columnConfigs.Add("Producto_inventario_Pzacaja", new ColumnConfig((listadoProducto?.Lbl_campo36 ?? CampoEnLista._descripcionSistemaProductos[35].ToUpper()), (listadoProducto?.Campo36 == BoolCN.S ? Double.NaN : defaultSize)));


            }
            //CheckDerechos();

            //AllowAdd = (DerechosUsuario?[Model.DBValues._DERECHO_PRODUCTO_INSERTAR] ?? false);
            //AllowEdit = (DerechosUsuario?[Model.DBValues._DERECHO_PRODUCTO_EDITAR] ?? false);
            //AllowShow = (DerechosUsuario?[Model.DBValues._DERECHO_PRODUCTO_VER] ?? false);
        }


        protected override void OnViewLoaded(object view)
        {
            if (columnConfigs != null)
                HiddenColumns = string.Join(",", columnConfigs.Where(y => y.Value.ColumnWidth == 0).Select(y => y.Key).ToList());

            base.OnViewLoaded(view);


            //if(!AllowEdit)
            //{
            //    HiddenColumns = HiddenColumns ?? "";

            //    if (HiddenColumns!.Length > 0)
            //        HiddenColumns += ",1";
            //    else
            //        HiddenColumns += "1";
            //}

        }

        protected override void preFillParam()
        {
            base.preFillParam();

            if (ListParam == null)
                return ;

            ListParam.EmpresaId = ListParam.P_empresaid;
            ListParam.SucursalId = ListParam.P_sucursalid;
            ListParam.AlmacenId1 = 1;
            ListParam.AlmacenId2 = 2;
            ListParam.TipoProductoPorPadreHijo = TipoProductoPorPadreHijo.tp_todos;
            ListParam.MostrarDescontinuados = true;

            ListParam.ClienteId = null; // 23;
            ListParam.ProveedorId = null;


        }


        protected override void fillCatalogConfiguration()
        {

            catalogRelatedFields = new List<CatalogRelatedFields>() {};
            lstCatalogDef = new List<CatalogDef>()
            {
                new CatalogDef("Almacen")
            };
            //Catalogs = selectorProvider.ObtainCatalogs(lstCatalogDef, new BaseParam(GlobalVariable.CurrentSession?.Empresaid, GlobalVariable.CurrentSession?.Sucursalid));
        }



        //protected List<long> DerechosToCheck()
        //{


        //    return new List<long>{ Model.DBValues._DERECHO_PRODUCTO_VER,
        //                           Model.DBValues._DERECHO_PRODUCTO_EDITAR,
        //                           Model.DBValues._DERECHO_PRODUCTO_ELIMINAR,
        //                           Model.DBValues._DERECHO_PRODUCTO_INSERTAR
        //        };
        //}


        protected override System.Collections.Generic.List<long> DerechosEstandarToCheck()
        {
            return new System.Collections.Generic.List<long>{ Model.DBValues._DERECHO_PRODUCTO_VER,
                                   Model.DBValues._DERECHO_PRODUCTO_VER + 1000,
                                   Model.DBValues._DERECHO_PRODUCTO_VER + 2000,
                                   Model.DBValues._DERECHO_PRODUCTO_VER + 3000                };
        }

        //protected void CheckDerechos()
        //{
        //    DerechosUsuario = new Dictionary<long, bool>();
        //    var derechos = DerechosToCheck();
        //    if (derechos == null || GlobalVariable.CurrentSession?.CurrentUsuario?.Id == null || _usuarioControllerProvider == null)
        //        return;



        //    var buffer = _usuarioControllerProvider!.Obtain_usuarios_derechos_List(GlobalVariable.CurrentSession!.Empresaid!.Value, GlobalVariable.CurrentSession!.Sucursalid!.Value, derechos, GlobalVariable.CurrentSession!.CurrentUsuario!.Id);
        //    if (buffer != null)
        //        DerechosUsuario = buffer;
        //}

        public async Task<System.Collections.Generic.List<ProductoListBindingModel>> DoGetItemsSimple()
        {
            if (ListParam == null)
                return new List<ProductoListBindingModel>();




            System.Collections.Generic.List<ProductoListBindingModel> items = new System.Collections.Generic.List<ProductoListBindingModel>();
            items = await itemsProvider.SelectForSimpleList(ListParam, KendoParams!) ?? new List<ProductoListBindingModel>();
            return items;
        }

        public override void ReloadItems()
        {
            ItemsSimple.Clear();
            try
            {
                bool bSuccess = true;
                IsBusy = true;
                var comentario = "";
                System.Collections.Generic.List<ProductoListBindingModel> items = new System.Collections.Generic.List<ProductoListBindingModel>();




                Task.Run<List<ProductoListBindingModel>>(async () => await DoGetItemsSimple()).ContinueWith((t) =>
                {
                    IsBusy = false;

                    if (t.IsFaulted)
                    {
                        //bSuccess = false;
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
                        items = t.Result;
                        foreach (var item in items)
                        {
                            ItemsSimple.Add(item);
                        }
                        ItemsLoadedText = "Loaded!";
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());

            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }
        }


        protected override void preconfigureSearchParams()
        {
            KendoParams = new KendoParams("", "Clave | Nombre | Productocaracteristicas.Clave ");
        }


        public void EdititemSimple(ProductoListBindingModel selectedSimple)
        {

            this.SelectedItem = selectedSimple.CastAsProductoBinding();
            this.Edititem(SelectedItem);

        }

        public  void ShowItemSimple(ProductoListBindingModel selectedSimple)
        {
            this.SelectedItem = selectedSimple.CastAsProductoBinding();
            this.ShowItem(SelectedItem);
        }


        public  void SelectItemSimpleByCell(ProductoListBindingModel selectedSimple)
        {
            if (IsSelectionMode)
            {
                this.SelectedItem = selectedSimple.CastAsProductoBinding();
                this.TryCloseAsync();
            }
        }


        protected override object EditViewModel()
        {
            return IoC.Get<ProductoEditViewModel>();
        }

        protected override object ShowViewModel()
        {
            return IoC.Get<ProductoShowViewModel>();
        }


        protected override object AddViewModel()
        {
            return IoC.Get<ProductoAddViewModel>();
        }

    }

    public class ColumnConfig
    {
        public string ColumnName { get; set; } = "";
        public Double ColumnWidth { get; set; } = Double.NaN;

        public ColumnConfig(string columnName, Double columnWidth)
        {
            ColumnName = columnName;
            ColumnWidth = columnWidth;
        }
    }
}
