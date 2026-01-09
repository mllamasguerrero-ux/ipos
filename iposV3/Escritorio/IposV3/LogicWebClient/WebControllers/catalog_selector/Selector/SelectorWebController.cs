
using BindingModels;
using IposV3.Model;
using System;
using IposV3.Extensions;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using ApiParam;
using System.Net.Http.Json;
using Models.CatalogSelector;


namespace Controllers.Controller
{

    public class SelectorWebController : BaseGenericWebController
    {
        
        public SelectorWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Selector_";
        }




        public string obtainCatalogTitle(CatalogRelatedFields catalogRelated)
        {

            if (!string.IsNullOrEmpty(catalogRelated.ListTitle))
                return catalogRelated.ListTitle;

            switch (catalogRelated.CatalogName)
            {


                case "Empresa":
                    return "Empresas";

                case "Sucursal":
                    return "Sucursales";
                case "Marca":
                    return "Sucursales";

                case "Linea":
                    return "Lineas";


                case "Caja":
                    return "Cajas";

                case "Perfiles":
                    return "Perfiles";

                case "Sucursal_info":
                    return "Sucursales";

                case "Usuario":
                    return "Usuarios";

                case "Vendedor":
                    return "Vendedores";


                case "Encargadoguia":
                    return "Encargados de guia";


                case "Encargadocorte":
                    return "Encargados de corte";

                case "Gruposucursal":
                    return "Grupos sucursales";

                case "Grupousuario":
                    return "Grupos de usuario";

                case "Moneda":
                    return "Monedas";

                case "Tasaieps":
                    return "Tasas Ieps";

                case "Tasaiva":
                    return "Tasas Iva";

                case "Unidad":
                    return "Unidades";

                case "Estadopais":
                    return "Estados";

                case "Estadopaisacronimo":
                    return "Paises";

                case "Subtipocliente":
                    return "Subtipos de cliente";

                case "Tiporecarga":
                    return "Tipos de recarga";

                case "Formapagosat":
                    return "Formas de pago SAT";

                case "Sat_aduana":
                    return "Aduanas SAT";

                case "Sat_claveunidadpeso":
                    return "Unidades/Pesos SAT";

                case "Sat_colonia":
                    return "Colonias SAT";

                case "Sat_localidad":
                    return "Localidades SAT";

                case "Sat_matpeligroso":
                    return "Materiales peligrosos SAT";

                case "Sat_metodopago":
                    return "Metodos de pago SAT";

                case "Sat_municipio":
                    return "Municipios SAT";

                case "Sat_pais":
                    return "Paises SAT";

                case "Sat_productoservicio":
                    return "Productos/Servicios SAT";

                case "Sat_regimenfiscal":
                    return "Regimenes fiscales";

                case "Sat_tipoembalaje":
                    return "Tipos embalaje";

                case "Sat_unidadmedida":
                    return "Unidades de medida SAT";

                case "Sat_usocfdi":
                    return "Uso CFDI SAT";

                case "Estadocobranza":
                    return "Estaods de cobranza";

                case "Estadopagocontrarecibo":
                    return "Estados de pago de contra recibo";

                case "Cliente":
                    return "Clientes";

                case "Producto":
                    return "Productos";

                case "Proveedor":
                    return "Proveedores";

                case "Tipotransaccion":
                    return "Tipos de transaccion";

                case "Clerkpagoservicio":
                    return "Clerks de pago de servicio";

                case "Emidaproduct":
                    return "Productos Emida";

                case "Merchantpagoservicio":
                    return "Merchangs de pago de servicio";

                case "Terminalpagoservicio":
                    return "Terminales de pago de servicio";

                case "Gastoadicional":
                    return "Gastos adicionales";

                case "Estadoguia":
                    return "Estados de guia";

                case "Tipoentrega":
                    return "Tipos de entrega";


                case "Almacen":
                    return "Almacenes";

                case "Anaquel":
                    return "Anaqueles";

                case "AnaquelLibre":
                    return "Anaqueles";

                case "Grupodiferenciainventario":
                    return "Grupos de diferencia de inventario";

                case "Tipodiferenciainventario":
                    return "Tipos de diferencia de inventario";

                case "Mensajenivelurgencia":
                    return "Niveles de urgencia";

                case "Banco":
                    return "Bancos";

                case "Formapago":
                    return "Formas de pago";

                case "Motivo_camfec":
                    return "Motivo de cambio de fecha";

                case "Cuenta":
                    return "Cuentas";

                case "Cuentabanco":
                    return "Cuentas de banco";

                case "Plazo":
                    return "Plazos";

                case "Tipolineapoliza":
                    return "Tipos linea de poliza";

                case "Camporeferenciaprecio":
                    return "Campos referencia de precio";

                case "Tipodescuentoprod":
                    return "Tipos descuento";

                case "Tipoutilidad":
                    return "Tipos utilidad";

                case "Promocion":
                    return "Promociones";

                case "Rangopromocion":
                    return "Rangos de promocion";

                case "Tipopromocion":
                    return "Tipos de promocion";

                case "Clasifica":
                    return "Clasificaciones";

                case "Contenido":
                    return "Contenido";

                case "Reportes":
                    return "Reportes";

                case "Rutaembarque":
                    return "Rutas de embarque";

                case "Motivo_devolucion":
                    return "Motivos de devolucion";



                case "Origenfiscal":
                    return "Origenes fiscales";




                case "Tipoprecio":
                    return "Tipos de precio";

                case "Agrupacionventa":
                    return "Agrupaciones de venta";


                case "Saludo":
                    return "Saludos";


                case "LetraEnTicket":
                    return "Letras en ticket";

                case "FormatTicketCorto":
                    return "Formatos de ticket corto";

                case "OrdenImpresion":
                    return "Orden de impresion";

                case "FormatoFactura":
                    return "Formatos de factura";

                case "FiltroProductoSat":
                    return "Filtros de producto SAT";

                case "ModoAlertaPV":
                    return "Modos alerta PV";

                case "ConfigPantalla":
                    return "Configuraciones de pantalla";

                case "Tiposyncmovil":
                    return "Tipos sincronizacion movil";

                case "TipoConexionMovil":
                    return "Tipos conexion movil";


                case "Tipodocto_Proveeduria":
                    return "Tipos de documento de proveeduria";

                case "Estatusdocto_Proveeduria":
                    return "Estados de documentos de proveeduria";


                case "Tipodocto_Vendeduria":
                    return "Tipos de documento de proveeduria";

                case "Estatusdocto_Vendeduria":
                    return "Estados de documento de vendeduria";


                case "Tipodocto_Provdevo":
                    return "Tipos de documento de devolucion de proveeduria";

                case "Estatusdocto_Provdevo":
                    return "Estados de documento de devolucion de proveeduria";


                case "Tipodocto_Venddevo":
                    return "Tipos de documento de devolucion";

                case "Estatusdocto_Venddevo":
                    return "Estados de documento de devolucion";


                case "Tipodocto_Vend_to_devo":
                    return "Tipos de documento de venta a devolver";

                case "Estatusdocto_Vend_to_devo":
                    return "Estados de documento de venta a devolver";

                case "Tipodocto_Prov_to_devo":
                    return "Tipos de documento de compra a devolver";

                case "Estatusdocto_Prov_to_devo":
                    return "Estados de documento de compra a devolver";



                case "SatFormaPagoTarjeta":
                    return "Formas de pago tarjeta SAT";



                case "Sat_figuratransporte":
                    return "Figuras de transporte SAT";

                case "Sat_partetransporte":
                    return "Parte transporte SAT";

                case "DiasDeLaSemana":
                    return "Dias de la semana";



                case "Area":
                    return "Areas";

                case "Listaprecio":
                    return "Listas de precio";




                default:
                    return catalogRelated.CatalogName ?? "";

            }
        }

        public async Task<Dictionary<String, List<BaseSelector>?>?> ObtainCatalogs(List<Models.CatalogSelector.CatalogDef> lstCatalogDef, BaseParam baseParam)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/ObtainCatalogs";

            try
            {


                var contentJson = JsonSerializer.Serialize<Selector_ObtainCatalogs_ApiParam>(new Selector_ObtainCatalogs_ApiParam()
                {
                    LstCatalogDef = lstCatalogDef,
                    BaseParam = baseParam
                });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<Dictionary<String, List<BaseSelector>?>?>();
                    return apiResponse;
                }
                else
                {
                    string responseText = await response.Content.ReadAsStringAsync();
                    throw new Exception(responseText);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<List<BaseSelector>?> obtainCatalog(Models.CatalogSelector.CatalogDef catalogDef, BaseParam baseParam)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/obtainCatalog";

            try
            {


                var contentJson = JsonSerializer.Serialize<Selector_obtainCatalog_ApiParam>(new Selector_obtainCatalog_ApiParam(){
                                        CatalogDef = catalogDef, BaseParam = baseParam
                                    });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<BaseSelector>?>();
                    return apiResponse;
                }
                else
                {
                    string responseText = await response.Content.ReadAsStringAsync();
                    throw new Exception(responseText);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    
        public async Task<BaseSelector?> obtainItemByClave(String strCatalogo, String strClave, BaseParam baseParam)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/obtainItemByClave";

            try
            {


                var contentJson = JsonSerializer.Serialize<Selector_obtainItemByClave_ApiParam>(new Selector_obtainItemByClave_ApiParam(){
                                        StrCatalogo = strCatalogo, StrClave = strClave, BaseParam = baseParam
                                    });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<BaseSelector?>();
                    return apiResponse;
                }
                else
                {
                    string responseText = await response.Content.ReadAsStringAsync();
                    throw new Exception(responseText);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    
        public async Task<BaseSelector?> obtainItemById(String strCatalogo, Int64 itemId, BaseParam baseParam)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/obtainItemById";

            try
            {


                var contentJson = JsonSerializer.Serialize<Selector_obtainItemById_ApiParam>(new Selector_obtainItemById_ApiParam(){
                                        StrCatalogo = strCatalogo, ItemId = itemId, BaseParam = baseParam
                                    });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<BaseSelector?>();
                    return apiResponse;
                }
                else
                {
                    string responseText = await response.Content.ReadAsStringAsync();
                    throw new Exception(responseText);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    



  }

}



