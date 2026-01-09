
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

    public class InventarioWebController : BaseGenericWebController
    {
        
        public InventarioWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Inventario_";
        }



        public async Task<Fnc_verify_existenceResult?> Verify_existence(Fnc_verify_existenceParam param)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Verify_existence";

            try
            {

                var contentJson = JsonSerializer.Serialize<Fnc_verify_existenceParam>(param);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<Fnc_verify_existenceResult?>();
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
    
        public async Task<List<V_inventario_doctoWFBindingModel>?> V_inventario_doctoList(V_inventario_doctoParamBindingModel itemParam)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/V_inventario_doctoList";

            try
            {

                var contentJson = JsonSerializer.Serialize<V_inventario_doctoParamBindingModel>(itemParam);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<V_inventario_doctoWFBindingModel>?>();
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
    
        public async Task<List<V_inventario_movto_detalleWFBindingModel>?> V_inventario_movto_detallesList(V_inventario_movto_detalleParamBindingModel itemParam)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/V_inventario_movto_detallesList";

            try
            {

                var contentJson = JsonSerializer.Serialize<V_inventario_movto_detalleParamBindingModel>(itemParam);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<V_inventario_movto_detalleWFBindingModel>?>();
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
    
        public async Task<List<V_inventario_movto_detalleWFBindingModel>?> V_inventario_movto_detalles_x_locList(V_inventario_movto_detalleParamBindingModel itemParam)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/V_inventario_movto_detalles_x_locList";

            try
            {

                var contentJson = JsonSerializer.Serialize<V_inventario_movto_detalleParamBindingModel>(itemParam);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<V_inventario_movto_detalleWFBindingModel>?>();
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
    
        public async Task<List<V_inventario_movto_detalleWFBindingModel>?> V_inventario_movto_detalles_x_loc_groupedList(V_inventario_movto_detalleParamBindingModel itemParam)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/V_inventario_movto_detalles_x_loc_groupedList";

            try
            {

                var contentJson = JsonSerializer.Serialize<V_inventario_movto_detalleParamBindingModel>(itemParam);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<V_inventario_movto_detalleWFBindingModel>?>();
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
    
        public async Task<V_inventario_movto_getInfoWFBindingModel?> V_inventario_movto_getInfo(V_inventario_movto_getInfoParamWFBindingModel param)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/V_inventario_movto_getInfo";

            try
            {

                var contentJson = JsonSerializer.Serialize<V_inventario_movto_getInfoParamWFBindingModel>(param);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<V_inventario_movto_getInfoWFBindingModel?>();
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
    
        public async Task<BaseResultBindingModel?> Docto_inventario_genCompleto(V_inventario_genComplParamWFBindingModel param)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Docto_inventario_genCompleto";

            try
            {

                var contentJson = JsonSerializer.Serialize<V_inventario_genComplParamWFBindingModel>(param);


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
    
        public async Task<BaseResultBindingModel?> Docto_inventario_finEdicion(V_inventario_finedicionParamWFBindingModel param)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Docto_inventario_finEdicion";

            try
            {

                var contentJson = JsonSerializer.Serialize<V_inventario_finedicionParamWFBindingModel>(param);


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
    
        public async Task<BaseResultBindingModel?> Docto_inventario_aplicar(V_inventario_aplicarParamWFBindingModel param)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Docto_inventario_aplicar";

            try
            {

                var contentJson = JsonSerializer.Serialize<V_inventario_aplicarParamWFBindingModel>(param);


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
    
        public async Task<BaseResultBindingModel?> Movto_inventario_insert(MovtoInventarioTrans movtoTrans)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Movto_inventario_insert";

            try
            {

                var contentJson = JsonSerializer.Serialize<MovtoInventarioTrans>(movtoTrans);


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
    
        public async Task<List<Tmp_Inventario_movto_loteInfo>?> Inventario_movto_loteInfo(Int64 empresaId, Int64 sucursalId, Int64 productoId, Int64? doctoId, Boolean soloconexistencias)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Inventario_movto_loteInfo";

            try
            {


                var contentJson = JsonSerializer.Serialize<Inventario_Inventario_movto_loteInfo_ApiParam>(new Inventario_Inventario_movto_loteInfo_ApiParam(){
                                        EmpresaId = empresaId, SucursalId = sucursalId, ProductoId = productoId, DoctoId = doctoId, Soloconexistencias = soloconexistencias
                                    });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<Tmp_Inventario_movto_loteInfo>?>();
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


        //DONE2 MLG 2025 Migracion web out
        public async Task<BaseResultBindingModel?> Docto_inventario_insert(DoctoInventarioTrans doctoTrans) //ref doctoId
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Docto_inventario_insert";

            try
            {


                var contentJson = JsonSerializer.Serialize<DoctoInventarioTrans>(doctoTrans);


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

        public async Task<BaseResultBindingModel?> Docto_inventario_delete(Int64 empresaId, Int64 sucursalId, Int64 id)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Docto_inventario_delete";

            try
            {


                var contentJson = JsonSerializer.Serialize<Inventario_Docto_inventario_delete_ApiParam>(new Inventario_Docto_inventario_delete_ApiParam(){
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
    
        public async Task<BaseResultBindingModel?> Docto_inventario_cambiarkitdesglosado(Int64 empresaId, Int64 sucursalId, Int64 doctoId, BoolCN kitDesglosado)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Docto_inventario_cambiarkitdesglosado";

            try
            {


                var contentJson = JsonSerializer.Serialize<Inventario_Docto_inventario_cambiarkitdesglosado_ApiParam>(new Inventario_Docto_inventario_cambiarkitdesglosado_ApiParam(){
                                        EmpresaId = empresaId, SucursalId = sucursalId, DoctoId = doctoId, KitDesglosado = kitDesglosado
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



