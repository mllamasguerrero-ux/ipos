
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

    public class PuntoVentaWebController : BaseGenericWebController
    {
        
        public PuntoVentaWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "PuntoVenta_";
        }



        public async Task<List<V_movto_vendeduriaWFBindingModel>?> Select_V_movto_vendeduria_List(Int64 empresaId, Int64 sucursalId, Int64 doctoId)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Select_V_movto_vendeduria_List";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoVenta_Select_V_movto_vendeduria_List_ApiParam>(new PuntoVenta_Select_V_movto_vendeduria_List_ApiParam(){
                                        EmpresaId = empresaId, SucursalId = sucursalId, DoctoId = doctoId
                                    });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<V_movto_vendeduriaWFBindingModel>?>();
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
        public async Task<BaseResultBindingModel?> Docto_vend_insert(DoctoVendTrans doctoVendTrans)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Docto_vend_insert";

            try
            {

                var contentJson = JsonSerializer.Serialize<DoctoVendTrans>(doctoVendTrans);


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
        public async Task<BaseResultBindingModel?> Movto_vend_insert(MovtoVendTrans movtoVendTrans)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Movto_vend_insert";

            try
            {

                var contentJson = JsonSerializer.Serialize<MovtoVendTrans>(movtoVendTrans);


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
        public async Task<List<V_docto_vendeduriaWFBindingModel>?> Select_V_docto_vendeduria_List(Int64 empresaId, Int64 sucursalId, Int64? usuarioId, Int64 tipoDoctoId, Int64 estatusDoctoId, DateTimeOffset fechaIni, DateTimeOffset fechaFin, BoolCS corteActual, Int64? almacenId, BoolCS todosAlmacenes, BoolCS porFecha, BoolCS todosUsuarios)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Select_V_docto_vendeduria_List";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoVenta_Select_V_docto_vendeduria_List_ApiParam>(new PuntoVenta_Select_V_docto_vendeduria_List_ApiParam()
                {
                    EmpresaId = empresaId,
                    SucursalId = sucursalId,
                    UsuarioId = usuarioId,
                    TipoDoctoId = tipoDoctoId,
                    EstatusDoctoId = estatusDoctoId,
                    FechaIni = fechaIni,
                    FechaFin = fechaFin,
                    CorteActual = corteActual,
                    AlmacenId = almacenId,
                    TodosAlmacenes = todosAlmacenes,
                });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<V_docto_vendeduriaWFBindingModel>?>();
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
        public async Task<V_preciosProd_RefBindingModel?> Precioprod_ref_vend(Int64 empresaId, Int64 sucursalId, Int64 productoId, Int64 clienteId, Decimal cantidad)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Precioprod_ref_vend";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoVenta_Precioprod_ref_vend_ApiParam>(new PuntoVenta_Precioprod_ref_vend_ApiParam()
                {
                    EmpresaId = empresaId,
                    SucursalId = sucursalId,
                    ProductoId = productoId,
                    ClienteId = clienteId,
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

        public async Task<BaseResultBindingModel?> Docto_vend_save(Int64 empresaId, Int64 sucursalId, Int64 id, Int64 estatusDoctoId)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Docto_vend_save";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoVenta_Docto_vend_save_ApiParam>(new PuntoVenta_Docto_vend_save_ApiParam()
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
        public async Task<BaseResultBindingModel?> Docto_vend_delete(Int64 empresaId, Int64 sucursalId, Int64 id)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Docto_vend_delete";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoVenta_Docto_vend_delete_ApiParam>(new PuntoVenta_Docto_vend_delete_ApiParam()
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
        public async Task<BaseResultBindingModel?> Docto_vend_cancel(Int64 empresaId, Int64 sucursalId, Int64 doctoId, Int64 creadoPorId)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Docto_vend_cancel";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoVenta_Docto_vend_cancel_ApiParam>(new PuntoVenta_Docto_vend_cancel_ApiParam()
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
        public async Task<PuntoVentaBindingModel?> Movto_vend_delete(Int64 empresaId, Int64 sucursalId, List<Int64>? listIds, Int64 doctoId)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Movto_vend_delete";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoVenta_Movto_vend_delete_ApiParam>(new PuntoVenta_Movto_vend_delete_ApiParam()
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

                    var apiResponse = await response.Content.ReadFromJsonAsync<PuntoVentaBindingModel?>();
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



        public async Task<PuntoVentaBindingModel?> DecipherCommand(Int64 empresaId, Int64 sucursalId, String commandText,
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

                    var apiResponse = await response.Content.ReadFromJsonAsync<PuntoVentaBindingModel?>();
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

        public async Task<PuntoVentaBindingModel?> SaveMovto(PuntoVentaBindingModel pvBindingModel)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/SaveMovto";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoVentaBindingModel>(pvBindingModel);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<PuntoVentaBindingModel?>();
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



        public async Task<PuntoVentaBindingModel?> GetDocumentInfo(PuntoVentaBindingModel pvBindingModel)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/GetDocumentInfo";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoVentaBindingModel>(pvBindingModel);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<PuntoVentaBindingModel?>();
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
        public async Task<BaseResultBindingModel?> Docto_vend_and_payments_save(Int64 empresaId, Int64 sucursalId, Int64 id, List<DoctoPagoDirect> listPagos)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Docto_vend_and_payments_save";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoVenta_Docto_vend_and_payments_save_ApiParam>(new PuntoVenta_Docto_vend_and_payments_save_ApiParam()
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





    }

}



