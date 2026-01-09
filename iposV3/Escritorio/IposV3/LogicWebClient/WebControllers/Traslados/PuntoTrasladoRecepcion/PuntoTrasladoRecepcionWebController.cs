
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

    public class PuntoTrasladoRecepcionWebController : BaseGenericWebController
    {
        
        public PuntoTrasladoRecepcionWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "PuntoTrasladoRecepcion_";
        }



        public async Task<List<Docto_traslado_recWFBindingModel>?> Select_docto_traslado_rec_List(Docto_traslado_rec_lstParamWFBindingModel param)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Select_docto_traslado_rec_List";

            try
            {

                var contentJson = JsonSerializer.Serialize<Docto_traslado_rec_lstParamWFBindingModel>(param);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<Docto_traslado_recWFBindingModel>?>();
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
    
        public async Task<List<Movto_traslado_recWFBindingModel>?> Select_movto_traslado_rec_List(Movto_traslado_rec_lstParamWFBindingModel param)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Select_movto_traslado_rec_List";

            try
            {

                var contentJson = JsonSerializer.Serialize<Movto_traslado_rec_lstParamWFBindingModel>(param);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<Movto_traslado_recWFBindingModel>?>();
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
        public async Task<BaseResultBindingModel?> Recibir_traslado(Recibir_traslado_ParamWFBindingModel param, List<Recepcion_movto_traslado_impo> movtosARecibir) //, out Int64 doctoDevolucionId)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Recibir_traslado";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoTrasladoRecepcion_Recibir_traslado_ApiParam>(new PuntoTrasladoRecepcion_Recibir_traslado_ApiParam()
                {
                    Param = param,
                    MovtosARecibir = movtosARecibir
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

        public async Task<BaseResultBindingModel?> Docto_update_datos_ajustables(Int64 empresaId, Int64 sucursalId, Int64 id, Int64? usuarioId, Int64? almacenId, String referencias)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Docto_update_datos_ajustables";

            try
            {


                var contentJson = JsonSerializer.Serialize<PuntoTrasladoRecepcion_Docto_update_datos_ajustables_ApiParam>(new PuntoTrasladoRecepcion_Docto_update_datos_ajustables_ApiParam(){
                                        EmpresaId = empresaId, SucursalId = sucursalId, Id = id, UsuarioId = usuarioId, AlmacenId = almacenId, Referencias = referencias
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



