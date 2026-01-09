
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

    public class PuntoVentaDevoWebController : BaseGenericWebController
    {
        
        public PuntoVentaDevoWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "PuntoVentaDevo_";
        }



        public async Task<BaseResultBindingModel?> Docto_venddevo_insert(DoctoVenddevoTrans doctoVendDevoTrans)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Docto_venddevo_insert";

            try
            {

                var contentJson = JsonSerializer.Serialize<DoctoVenddevoTrans>(doctoVendDevoTrans);


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
    
        public async Task<BaseResultBindingModel?> Movto_venddevo_insert(MovtoVenddevoTrans movtoVendDevoTrans)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Movto_venddevo_insert";

            try
            {

                var contentJson = JsonSerializer.Serialize<MovtoVenddevoTrans>(movtoVendDevoTrans);


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
    
        public async Task<List<V_movto_venddevoWFBindingModel>?> Select_V_movto_venddevo_List(Int64 empresaId, Int64 sucursalId, Int64 doctoId)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Select_V_movto_venddevo_List";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoVentaDevo_Select_V_movto_venddevo_List_ApiParam>(new PuntoVentaDevo_Select_V_movto_venddevo_List_ApiParam(){
                                        EmpresaId = empresaId, SucursalId = sucursalId, DoctoId = doctoId
                                    });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<V_movto_venddevoWFBindingModel>?>();
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
    
        public async Task<List<V_docto_venddevoWFBindingModel>?> Select_V_docto_venddevo_List(Int64 empresaId, Int64 sucursalId, Int64? usuarioId, Int64 tipoDoctoId, Int64 estatusDoctoId, DateTimeOffset fechaIni, DateTimeOffset fechaFin)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Select_V_docto_venddevo_List";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoVentaDevo_Select_V_docto_venddevo_List_ApiParam>(new PuntoVentaDevo_Select_V_docto_venddevo_List_ApiParam(){
                                        EmpresaId = empresaId, SucursalId = sucursalId, UsuarioId = usuarioId, TipoDoctoId = tipoDoctoId, EstatusDoctoId = estatusDoctoId, FechaIni = fechaIni, FechaFin = fechaFin
                                    });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<V_docto_venddevoWFBindingModel>?>();
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
    
        public async Task<List<V_docto_vend_to_devoWFBindingModel>?> Select_V_docto_vend_to_devo_List(Int64 empresaId, Int64 sucursalId, Int64? usuarioId, Int64 tipoDoctoId, Int64 estatusDoctoId, DateTimeOffset fechaIni, DateTimeOffset fechaFin)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Select_V_docto_vend_to_devo_List";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoVentaDevo_Select_V_docto_vend_to_devo_List_ApiParam>(new PuntoVentaDevo_Select_V_docto_vend_to_devo_List_ApiParam(){
                                        EmpresaId = empresaId, SucursalId = sucursalId, UsuarioId = usuarioId, TipoDoctoId = tipoDoctoId, EstatusDoctoId = estatusDoctoId, FechaIni = fechaIni, FechaFin = fechaFin
                                    });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<V_docto_vend_to_devoWFBindingModel>?>();
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
    
        public async Task<List<V_movto_vend_to_devoWFBindingModel>?> Select_V_movto_vend_to_devo_List(Int64 empresaId, Int64 sucursalId, Int64? doctoId, Int64? doctoRefId)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Select_V_movto_vend_to_devo_List";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoVentaDevo_Select_V_movto_vend_to_devo_List_ApiParam>(new PuntoVentaDevo_Select_V_movto_vend_to_devo_List_ApiParam(){
                                        EmpresaId = empresaId, SucursalId = sucursalId, DoctoId = doctoId, DoctoRefId = doctoRefId
                                    });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<V_movto_vend_to_devoWFBindingModel>?>();
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
    
        public async Task<BaseResultBindingModel?> Docto_venddevo_save(Int64 empresaId, Int64 sucursalId, Int64 id, Int64 estatusDoctoId)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Docto_venddevo_save";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoVentaDevo_Docto_venddevo_save_ApiParam>(new PuntoVentaDevo_Docto_venddevo_save_ApiParam(){
                                        EmpresaId = empresaId, SucursalId = sucursalId, Id = id, EstatusDoctoId = estatusDoctoId
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
    
        public async Task<BaseResultBindingModel?> Docto_venddevo_delete(Int64 empresaId, Int64 sucursalId, Int64 id)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Docto_venddevo_delete";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoVentaDevo_Docto_venddevo_delete_ApiParam>(new PuntoVentaDevo_Docto_venddevo_delete_ApiParam(){
                                        EmpresaId = empresaId, SucursalId = sucursalId, Id = id
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
    
        public async Task<BaseResultBindingModel?> Docto_venddevo_cancel(Int64 empresaId, Int64 sucursalId, Int64 doctoId, Int64 creadoPorId)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Docto_venddevo_cancel";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoVentaDevo_Docto_venddevo_cancel_ApiParam>(new PuntoVentaDevo_Docto_venddevo_cancel_ApiParam(){
                                        EmpresaId = empresaId, SucursalId = sucursalId, DoctoId = doctoId, CreadoPorId = creadoPorId
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
    
        public async Task<PuntoVentaDevoBindingModel?> Movto_venddevo_delete(Int64 empresaId, Int64 sucursalId, List<Int64>? listIds, Int64 doctoId)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Movto_venddevo_delete";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoVentaDevo_Movto_venddevo_delete_ApiParam>(new PuntoVentaDevo_Movto_venddevo_delete_ApiParam()
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

                    var apiResponse = await response.Content.ReadFromJsonAsync<PuntoVentaDevoBindingModel?>();
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
    
        public async Task<BaseResultBindingModel?> Docto_venddevo_and_payments_save(Int64 empresaId, Int64 sucursalId, Int64 id, List<DoctoPagoDirect> listPagos)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Docto_venddevo_and_payments_save";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoVentaDevo_Docto_venddevo_and_payments_save_ApiParam>(new PuntoVentaDevo_Docto_venddevo_and_payments_save_ApiParam(){
                                        EmpresaId = empresaId, SucursalId = sucursalId, Id = id, ListPagos = listPagos
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


        public async Task<PuntoVentaDevoBindingModel?> DecipherCommand(Int64 empresaId, Int64 sucursalId, String commandText,
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

                    var apiResponse = await response.Content.ReadFromJsonAsync<PuntoVentaDevoBindingModel?>();
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

        public async Task<PuntoVentaDevoBindingModel?> SaveMovto(PuntoVentaDevoBindingModel pvBindingModel)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/SaveMovto";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoVentaDevoBindingModel>(pvBindingModel);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<PuntoVentaDevoBindingModel?>();
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


        public async Task<PuntoVentaDevoBindingModel?> GetDocumentInfo(PuntoVentaDevoBindingModel pvBindingModel)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/GetDocumentInfo";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoVentaDevoBindingModel>(pvBindingModel);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<PuntoVentaDevoBindingModel?>();
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



        public async Task<PuntoVentaDevoBindingModel?> GetInitialDocumentInfoFromRef(PuntoVentaDevoBindingModel pvBindingModel)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/GetInitialDocumentInfoFromRef";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoVentaDevoBindingModel>(pvBindingModel);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<PuntoVentaDevoBindingModel?>();
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



