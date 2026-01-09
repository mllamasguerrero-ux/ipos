
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
using IposV3.BindingModel;
//using FastReport.DevComponents.WinForms.Drawing;
using Controllers.BindingModel;

namespace IposV3.ViewModels
{

    public class ClienteItemViewModel : BaseWebRecordViewModel<ClienteBindingModel, ClienteWebController, ClienteItemVMInitialParameters, ClienteListVMEventParameters>
    {

        public GlobalSession? GlobalSession { get => GlobalVariable.CurrentSession; }

        public Dictionary<string, bool> BoolBindingExpression { get; set; }

        public ClienteBindingModel? Cliente { get { return Record; } set { Record = value; } }


        //public ClienteBindingModel? Cliente
        //{
        //    get => Record;
        //    set
        //    {
        //        Record = value; NotifyOfPropertyChange("Cliente");

        //        if (Record != null)
        //        {
        //            Record.PendingChange +=  CatalogField_PropertyChanging;
        //            Record.PropertyChanged += RecordChangedEventHandler;
        //        }
        //    }
        //}

        public ClienteItemViewModel(string mode, ClienteWebController provider, UsuarioWebController usuarioController , SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(mode, provider, usuarioController , selectorProvider, aggregator, winManager, messageBoxService)
        {

            BoolBindingExpression = new Dictionary<string, bool>();
            fillBoolBindingExpressions();

        }


        protected override void fillRecordToEdit(ClienteItemVMInitialParameters initialParameters)
        {
            base.fillRecordToEdit(initialParameters);
            fillBoolBindingExpressions();

        }
        protected override void preFillRecordToAdd()
        {
            base.preFillRecordToAdd();
            fillBoolBindingExpressions();
        }

        private void fillBoolBindingExpressions()
        {
            var boolBindingExpression = new Dictionary<string, bool>();

            boolBindingExpression.Clear();

            boolBindingExpression.Add("VendedorReadOnly",  BIsReadOnly || !(DerechosUsuario?[Model.DBValues._DERECHO_CAMBIARVENDEDORCLIENTE] ?? false));
            boolBindingExpression.Add("DesgloseIepsReadOnly", BIsReadOnly || !(GlobalSession?.CurrentParametro?.Desgloseieps == BoolCN.S));
            boolBindingExpression.Add("ArrendatarioReadOnly", BIsReadOnly || !(GlobalSession?.CurrentParametro?.Arrendatario == BoolCN.S));
            boolBindingExpression.Add("ManejaSuperListaPrecioReadOnly", BIsReadOnly || !(GlobalSession?.CurrentParametro?.Manejasuperlistaprecio == BoolCN.S));
            boolBindingExpression.Add("VersionCFDI3340Hide", !(GlobalSession?.CurrentParametro?.Versioncfdi == "3.3" || GlobalSession?.CurrentParametro?.Versioncfdi == "4.0"));
            boolBindingExpression.Add("VendedorMovilHide", !(GlobalSession?.CurrentParametro?.Esvendedormovil == BoolCN.S));
            boolBindingExpression.Add("VendedorMovilTipo2Hide", !(GlobalSession?.CurrentParametro?.Tipovendedormovil == TipoConexionMovil.Tipo2));
            boolBindingExpression.Add("TienePermisoHistorial", (DerechosUsuario?[Model.DBValues._DERECHO_BITACORA_CLIENTES] ?? false));
            boolBindingExpression.Add("TienePermisoEstadisticos", (DerechosUsuario?[Model.DBValues._DERECHO_ABRIR_ESTADISTICOSCLIENTEVENTA] ?? false));
            boolBindingExpression.Add("TienePermisoAnalisisProducto", (DerechosUsuario?[Model.DBValues._DERECHO_ABRIR_ANALISISPRODUCTO] ?? false));
            boolBindingExpression.Add("TienePermisoEditarPrecioPorCliente", (DerechosUsuario?[Model.DBValues._DERECHO_EDITARPRECIOS_POR_CLIENTE] ?? false) && GlobalSession?.CurrentParametro?.Hab_precioscliente == BoolCN.S);
            boolBindingExpression.Add("TienePermisoNotasIncidencia", (DerechosUsuario?[Model.DBValues._DERECHO_NOTASINCIDENCIA] ?? false));
            boolBindingExpression.Add("PlazoXProductoHide", !(GlobalSession?.CurrentParametro?.Plazoxproducto == BoolCN.S));
            boolBindingExpression.Add("TienePermisoRelacionarProveCliente", (DerechosUsuario?[Model.DBValues._DERECHO_RELACIONAR_PROVEE_CLIENTE] ?? false));
            boolBindingExpression.Add("TienePermisoExentarIvaClientes", (DerechosUsuario?[Model.DBValues._DERECHO_EXENTARIVACLIENTES] ?? false));
            boolBindingExpression.Add("TienePermisoCreditoCobranza", (DerechosUsuario?[Model.DBValues._DERECHO_CREDITOCOBRANZA] ?? false));
            boolBindingExpression.Add("FirmaHide", (string.IsNullOrEmpty(GlobalSession?.CurrentParametro?.Rutafirmaimagenes)));
            boolBindingExpression.Add("CuentaIepsReadOnly", BIsReadOnly || !(this.Record?.Cliente_poliza_Desgloseieps == BoolCN.S) || !(GlobalSession?.CurrentParametro?.Desgloseieps == BoolCN.S));

            BoolBindingExpression = boolBindingExpression;

            NotifyOfPropertyChange("BoolBindingExpression");
        }




        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("Cliente","Subtipocliente","Subtipoclienteid", "SubtipoclienteClave", "SubtipoclienteNombre","IposV3.ViewModels.SubtipoclienteListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Cliente","Proveedor","Proveeclienteid", "ProveeclienteClave", "ProveeclienteNombre","IposV3.ViewModels.ProveedorListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Cliente","Usuario","Cliente_comision_Vendedorid", "Cliente_comision_VendedorClave", "Cliente_comision_VendedorNombre","IposV3.ViewModels.UsuarioListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Cliente","Formapagosat","Cliente_fact_elect_Creditoformapagosatabonos", "Cliente_fact_elect_Creditoformapagosatabonos_Clave", "Cliente_fact_elect_Creditoformapagosatabonos_Nombre","IposV3.ViewModels.FormapagosatListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Cliente","Sat_usocfdi","Cliente_fact_elect_Sat_usocfdiid", "Cliente_fact_elect_Sat_usocfdiClave", "Cliente_fact_elect_Sat_usocfdiNombre","IposV3.ViewModels.Sat_usocfdiListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Cliente","Sat_pais","Cliente_fact_elect_Sat_id_pais", "Cliente_fact_elect_Sat_paisClave", "Cliente_fact_elect_Sat_paisNombre","IposV3.ViewModels.Sat_paisListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Cliente","Sat_colonia","Cliente_fact_elect_Sat_Coloniaid", "Cliente_fact_elect_Sat_ColoniaClave", "Cliente_fact_elect_Sat_ColoniaNombre","IposV3.ViewModels.Sat_coloniaListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Cliente","Sat_localidad","Cliente_fact_elect_Sat_Localidadid", "Cliente_fact_elect_Sat_LocalidadClave", "Cliente_fact_elect_Sat_LocalidadNombre","IposV3.ViewModels.Sat_localidadListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Cliente","Sat_municipio","Cliente_fact_elect_Sat_Municipioid", "Cliente_fact_elect_Sat_MunicipioClave", "Cliente_fact_elect_Sat_MunicipioNombre","IposV3.ViewModels.Sat_municipioListViewModel","SelectedItem","Clave","Descripcion", null, "Municipio SAT"),
                                          new CatalogRelatedFields("Cliente","Sat_colonia","Cliente_fact_elect_Entrega_Sat_Coloniaid", "Cliente_fact_elect_Entrega_Sat_ColoniaClave", "Cliente_fact_elect_Entrega_Sat_ColoniaNombre","IposV3.ViewModels.Sat_coloniaListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Cliente","Sat_localidad","Cliente_fact_elect_Entrega_Sat_Localidadid", "Cliente_fact_elect_Entrega_Sat_LocalidadClave", "Cliente_fact_elect_Entrega_Sat_LocalidadNombre","IposV3.ViewModels.Sat_localidadListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Cliente","Sat_municipio","Cliente_fact_elect_Entrega_Sat_Municipioid", "Cliente_fact_elect_Entrega_Sat_MunicipioClave", "Cliente_fact_elect_Entrega_Sat_MunicipioNombre","IposV3.ViewModels.Sat_municipioListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Cliente","Formapago","Cliente_pago_parametros_Creditoformapagoabonos", "Cliente_pago_parametros_Creditoformapagoabonos_Clave", "Cliente_pago_parametros_Creditoformapagoabonos_Nombre","IposV3.ViewModels.FormapagoListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Cliente","Moneda","Cliente_pago_parametros_Monedaid", "Cliente_pago_parametros_MonedaClave", "Cliente_pago_parametros_MonedaNombre","IposV3.ViewModels.MonedaListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Cliente","Rutaembarque","Cliente_rutaembarque_Rutaembarqueid", "Cliente_rutaembarque_RutaembarqueClave", "Cliente_rutaembarque_RutaembarqueNombre","IposV3.ViewModels.RutaembarqueListViewModel","SelectedItem","Clave")
                                    };
            lstCatalogDef = new List<CatalogDef>() {  };
            
            if (!lstCatalogDef.Any(y => y.CatalogName == "Sat_regimenfiscal"))
                lstCatalogDef.Add(new CatalogDef("Sat_regimenfiscal"));  
            if (!lstCatalogDef.Any(y => y.CatalogName == "Tipoprecio"))
                lstCatalogDef.Add(new CatalogDef("Tipoprecio"));
            if (!lstCatalogDef.Any(y => y.CatalogName == "Estadopais"))
                lstCatalogDef.Add(new CatalogDef("Estadopais"));
            if (!lstCatalogDef.Any(y => y.CatalogName == "DiasDeLaSemana"))
                lstCatalogDef.Add(new CatalogDef("DiasDeLaSemana"));


        }


        public override void RecordChangedEventHandler(object? sender, PropertyChangedEventArgs e)
        {

            switch (e.PropertyName)
            {
                case "Cliente_poliza_Desgloseieps":
                    BoolBindingExpression["CuentaIepsReadOnly"] =  BIsReadOnly || !(this.Record?.Cliente_poliza_Desgloseieps == BoolCN.S) || !(GlobalSession?.CurrentParametro?.Desgloseieps == BoolCN.S);
                    NotifyOfPropertyChange("BoolBindingExpression");
                    break;

                default:
                    break;
            }
        }


        public override void ShowPopUpSelector(string catalogClaveField)
        {

            if(!catalogClaveField.In(new string[] { "Cliente_fact_elect_Sat_ColoniaClave" , "Cliente_fact_elect_Sat_LocalidadClave", "Cliente_fact_elect_Sat_MunicipioClave",
                                                    "Cliente_fact_elect_Entrega_Sat_ColoniaClave", "Cliente_fact_elect_Entrega_Sat_LocalidadClave", "Cliente_fact_elect_Entrega_Sat_MunicipioClave"}))
            {
                base.ShowPopUpSelector(catalogClaveField);
                return;
            }

            var catalogRelated = this.catalogRelatedFields?.Where(x => x.ClaveField == catalogClaveField).FirstOrDefault();

            Dictionary<string, object?> specialProperties = new Dictionary<string, object?>();

            if (Record?.Domicilio_Codigopostal != null && Record?.Domicilio_Codigopostal.Length > 0 &&
                (catalogClaveField == "Cliente_fact_elect_Sat_ColoniaClave"))
                specialProperties.Add("Codigopostal", Record?.Domicilio_Codigopostal);

            if (Record?.Domicilioentrega_Codigopostal != null && Record?.Domicilioentrega_Codigopostal.Length > 0 &&
                (catalogClaveField == "Cliente_fact_elect_Entrega_Sat_ColoniaClave"))
                specialProperties.Add("Codigopostal", Record?.Domicilioentrega_Codigopostal);


            if (Record!.Domicilio_Estado != null && Record?.Domicilio_Estado.Length > 0 &&
                (catalogClaveField == "Cliente_fact_elect_Sat_LocalidadClave" || catalogClaveField == "Cliente_fact_elect_Sat_MunicipioClave"))
            {
               var estadoSeleccionado =  Catalogs?["Estadopais"]?.FirstOrDefault(x => x.Clave == Record!.Domicilio_Estado);

                if(estadoSeleccionado != null && estadoSeleccionado.Texto1 != null)
                {
                    specialProperties.Add("Clave_estado", estadoSeleccionado.Texto1);
                }
            }



            if (Record!.Domicilioentrega_Estado != null && Record?.Domicilioentrega_Estado.Length > 0 &&
                (catalogClaveField == "Cliente_fact_elect_Entrega_Sat_LocalidadClave" || catalogClaveField == "Cliente_fact_elect_Entrega_Sat_MunicipioClave"))
            {
                var estadoSeleccionado = Catalogs?["Estadopais"]?.FirstOrDefault(x => x.Clave == Record!.Domicilioentrega_Estado);

                if (estadoSeleccionado != null && estadoSeleccionado.Texto1 != null)
                {
                    specialProperties.Add("Clave_estado", estadoSeleccionado.Texto1);
                }
            }


            if (catalogRelated != null)
                ShowPopUpSelectorCatalogRelated(catalogRelated, null, specialProperties);

        }


        public override void AcceptEdit()
        {

            if (Record != null)
            {
                Record.Domicilio_Pais = Record.Cliente_fact_elect_Sat_paisClave ?? "MEX";
                Record.Domicilioentrega_Pais = Record.Cliente_fact_elect_Sat_paisClave ?? "MEX";
            }
            
            base.AcceptEdit();
        }

        public override void AcceptAdd()
        {
            if (Record != null)
            {
                Record.Domicilio_Pais = Record.Cliente_fact_elect_Sat_paisClave ?? "MEX";
                Record.Domicilioentrega_Pais = Record.Cliente_fact_elect_Sat_paisClave ?? "MEX";
            }

            base.AcceptAdd();
        }


        protected override void preFillRecordToAddWithPropertyChangingEvent()
        {
            base.preFillRecordToAddWithPropertyChangingEvent();
            Record.Cliente_fact_elect_Sat_paisClave = "MEX";
        }


        protected override System.Collections.Generic.List<long> DerechosToCheck()
        {
            return new System.Collections.Generic.List<long>{ 

                                   Model.DBValues._DERECHO_BITACORA_CLIENTES,
                                   Model.DBValues._DERECHO_ABRIR_ESTADISTICOSCLIENTEVENTA,
                                   Model.DBValues._DERECHO_ABRIR_ANALISISPRODUCTO,
                                   Model.DBValues._DERECHO_EDITARPRECIOS_POR_CLIENTE,
                                   Model.DBValues._DERECHO_NOTASINCIDENCIA,
                                   Model.DBValues._DERECHO_CAMBIARVENDEDORCLIENTE,
                                   Model.DBValues._DERECHO_RELACIONAR_PROVEE_CLIENTE,
                                   Model.DBValues._DERECHO_EXENTARIVACLIENTES,
                                   Model.DBValues._DERECHO_CREDITOCOBRANZA

            };
        }
    }


    public class ClienteShowViewModel : ClienteItemViewModel
    {
        public ClienteShowViewModel(ClienteWebController provider, UsuarioWebController usuarioController , SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, usuarioController , selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class ClienteEditViewModel : ClienteItemViewModel
    {
        public ClienteEditViewModel(ClienteWebController provider, UsuarioWebController usuarioController , SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, usuarioController , selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class ClienteAddViewModel : ClienteItemViewModel
    {
        public ClienteAddViewModel(ClienteWebController provider, UsuarioWebController usuarioController , SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, usuarioController , selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }




}


