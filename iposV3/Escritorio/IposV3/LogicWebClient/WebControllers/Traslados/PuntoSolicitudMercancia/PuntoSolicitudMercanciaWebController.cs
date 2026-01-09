
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

    public class PuntoSolicitudMercanciaWebController : BaseGenericWebController
    {
        
        public PuntoSolicitudMercanciaWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "PuntoSolicitudMercancia_";
        }



        public async Task<List<Docto_solicitud_mercanciaWFBindingModel>?> Select_docto_traslado_rec_List(Docto_solic_merc_lstParamWFBindingModel param)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Select_docto_traslado_rec_List";

            try
            {

                var contentJson = JsonSerializer.Serialize<Docto_solic_merc_lstParamWFBindingModel>(param);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<Docto_solicitud_mercanciaWFBindingModel>?>();
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
    
        public async Task<List<Movto_solicitud_mercanciaWFBindingModel>?> Select_movto_solicitud_mercancia_List(Movto_solic_merc_lstParamWFBindingModel param)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Select_movto_solicitud_mercancia_List";

            try
            {

                var contentJson = JsonSerializer.Serialize<Movto_solic_merc_lstParamWFBindingModel>(param);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<Movto_solicitud_mercanciaWFBindingModel>?>();
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
    
        public async Task<BaseResultBindingModel?> Docto_solicitud_mercancia_insert(DoctoSolicitudMercanciaTrans doctoProvTrans)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Docto_solicitud_mercancia_insert";

            try
            {

                var contentJson = JsonSerializer.Serialize<DoctoSolicitudMercanciaTrans>(doctoProvTrans);


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
    
        public async Task<BaseResultBindingModel?> Movto_solicitud_mercancia_insert(MovtoSolicitudMercanciaTrans movtoProvTrans)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Movto_solicitud_mercancia_insert";

            try
            {

                var contentJson = JsonSerializer.Serialize<MovtoSolicitudMercanciaTrans>(movtoProvTrans);


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
    
        public async Task<BaseResultBindingModel?> Docto_solicitud_mercancia_save(Int64 empresaId, Int64 sucursalId, Int64 id, Int64 estatusDoctoId)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Docto_solicitud_mercancia_save";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoSolicitudMercancia_Docto_solicitud_mercancia_save_ApiParam>(new PuntoSolicitudMercancia_Docto_solicitud_mercancia_save_ApiParam(){
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
    



  }

}



