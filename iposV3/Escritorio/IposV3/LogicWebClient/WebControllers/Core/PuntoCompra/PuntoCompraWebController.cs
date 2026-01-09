
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
using IposV3.Services;


namespace Controllers.Controller
{

    public class PuntoCompraWebController : BaseGenericWebController
    {

        public PuntoCompraWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "PuntoCompra_";
        }



        public async Task<List<V_movto_proveeduriaWFBindingModel>?> Select_V_movto_proveeduria_List(Int64 empresaId, Int64 sucursalId, Int64 doctoId)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Select_V_movto_proveeduria_List";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoCompra_Select_V_movto_proveeduria_List_ApiParam>(new PuntoCompra_Select_V_movto_proveeduria_List_ApiParam()
                {
                    EmpresaId = empresaId,
                    SucursalId = sucursalId,
                    DoctoId = doctoId
                });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<V_movto_proveeduriaWFBindingModel>?>();
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



        //DONE2 MLG 2025 Migracion web
        public async Task<BaseResultBindingModel?> Docto_prov_insert(DoctoProvTrans doctoProvTrans)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Docto_prov_insert";

            try
            {

                var contentJson = JsonSerializer.Serialize<DoctoProvTrans>(doctoProvTrans);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<BaseResultBindingModel?>();
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

        //DONE2 MLG 2025 Migracion web
        public async Task<BaseResultBindingModel?> Movto_prov_insert(MovtoProvTrans movtoProvTrans)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Movto_prov_insert";

            try
            {

                var contentJson = JsonSerializer.Serialize<MovtoProvTrans>(movtoProvTrans);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<BaseResultBindingModel?>();
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

        //DONE2 MLG 2025 Migracion web
        public async Task<List<V_docto_proveeduriaWFBindingModel>?> Select_V_docto_proveeduria_List(Int64 empresaId, Int64 sucursalId, Int64? usuarioId, Int64 tipoDoctoId, Int64 estatusDoctoId, DateTimeOffset fechaIni, DateTimeOffset fechaFin, BoolCS corteActual, Int64? almacenId, BoolCS todosAlmacenes, BoolCS porFecha, BoolCS todosUsuarios)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Select_V_docto_proveeduria_List";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoCompra_Select_V_docto_proveeduria_List_ApiParam>(new PuntoCompra_Select_V_docto_proveeduria_List_ApiParam()
                {
                    EmpresaId = empresaId,
                    SucursalId = sucursalId,
                    UsuarioId = usuarioId,
                    TipoDoctoId = tipoDoctoId,
                    EstatusDoctoId = estatusDoctoId,
                    FechaIni = fechaIni,
                    FechaFin = fechaFin,
                    CorteActual = corteActual,
                    AlmacenId = almacenId ?? 1,
                    TodosAlmacenes = todosAlmacenes,
                });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<V_docto_proveeduriaWFBindingModel>?>();
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

        //DONE2 MLG 2025 Migracion web
        public async Task<V_preciosProd_RefBindingModel?> Precioprod_ref_prov(Int64 empresaId, Int64 sucursalId, Int64 productoId, Int64 proveedorId, Decimal cantidad)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Precioprod_ref_prov";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoCompra_Precioprod_ref_prov_ApiParam>(new PuntoCompra_Precioprod_ref_prov_ApiParam()
                {
                    EmpresaId = empresaId,
                    SucursalId = sucursalId,
                    ProductoId = productoId,
                    ProveedorId = proveedorId,
                    Cantidad = cantidad
                });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<V_preciosProd_RefBindingModel?>();
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

        //DONE2 MLG 2025 Migracion web
        public async Task<BaseResultBindingModel?> Docto_prov_save(Int64 empresaId, Int64 sucursalId, Int64 id, Int64 estatusDoctoId)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Docto_prov_save";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoCompra_Docto_prov_save_ApiParam>(new PuntoCompra_Docto_prov_save_ApiParam()
                {
                    EmpresaId = empresaId,
                    SucursalId = sucursalId,
                    Id = id,
                    EstatusDoctoId = estatusDoctoId
                });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<BaseResultBindingModel?>();
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

        //DONE2 MLG 2025 Migracion web
        public async Task<BaseResultBindingModel?> Docto_prov_delete(Int64 empresaId, Int64 sucursalId, Int64 id)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Docto_prov_delete";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoCompra_Docto_prov_delete_ApiParam>(new PuntoCompra_Docto_prov_delete_ApiParam()
                {
                    EmpresaId = empresaId,
                    SucursalId = sucursalId,
                    Id = id
                });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<BaseResultBindingModel?>();
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

        //DONE2 MLG 2025 Migracion web
        public async Task<BaseResultBindingModel?> Docto_prov_cancel(Int64 empresaId, Int64 sucursalId, Int64 doctoId, Int64 creadoPorId)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Docto_prov_cancel";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoCompra_Docto_prov_cancel_ApiParam>(new PuntoCompra_Docto_prov_cancel_ApiParam()
                {
                    EmpresaId = empresaId,
                    SucursalId = sucursalId,
                    DoctoId = doctoId,
                    CreadoPorId = creadoPorId
                });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<BaseResultBindingModel?>();
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

        //DONE2 MLG 2025 Migracion web
        public async Task<PuntoCompraBindingModel?> Movto_prov_delete(Int64 empresaId, Int64 sucursalId, List<Int64>? listIds, Int64 doctoId)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Movto_prov_delete";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoCompra_Movto_prov_delete_ApiParam>(new PuntoCompra_Movto_prov_delete_ApiParam()
                {
                    EmpresaId = empresaId,
                    SucursalId = sucursalId,
                    ListIds = listIds,
                    DoctoId = doctoId
                });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<PuntoCompraBindingModel?>();
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

        //DONE2 MLG 2025 Migracion web
        public async Task<BaseResultBindingModel?> Docto_prov_and_payments_save(Int64 empresaId, Int64 sucursalId, Int64 id, List<DoctoPagoDirect> listPagos)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Docto_prov_and_payments_save";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoCompra_Docto_prov_and_payments_save_ApiParam>(new PuntoCompra_Docto_prov_and_payments_save_ApiParam()
                {
                    EmpresaId = empresaId,
                    SucursalId = sucursalId,
                    Id = id,
                    ListPagos = listPagos
                });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<BaseResultBindingModel?>();
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



        public async Task<PuntoCompraBindingModel?> DecipherCommand(Int64 empresaId, Int64 sucursalId, String commandText,
        BoolCN? precionetoenpv, long? tipodescuentoprodid, bool saveMovto, bool manejaAlmacen,
        DoctoBindingModel currentDocto, long usuarioId)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/DecipherCommand";

            try
            {


                var contentJson = JsonSerializer.Serialize<Movto_DecipherCommand_ApiParam>(new Movto_DecipherCommand_ApiParam()
                {
                    EmpresaId = empresaId,
                    SucursalId = sucursalId,
                    CommandText = commandText,
                    Precionetoenpv = precionetoenpv,
                    Tipodescuentoprodid = tipodescuentoprodid,
                    SaveMovto = saveMovto,
                    ManejaAlmacen = manejaAlmacen,
                    CurrentDocto = currentDocto,
                    Usuarioid = usuarioId
                });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<PuntoCompraBindingModel?>();
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

        public async Task<PuntoCompraBindingModel?> SaveMovto(PuntoCompraBindingModel pvBindingModel)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/SaveMovto";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoCompraBindingModel>(pvBindingModel);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<PuntoCompraBindingModel?>();
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


        public async Task<PuntoCompraBindingModel?> GetDocumentInfo(PuntoCompraBindingModel pvBindingModel)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/GetDocumentInfo";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoCompraBindingModel>(pvBindingModel);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<PuntoCompraBindingModel?>();
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



