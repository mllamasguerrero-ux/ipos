
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


namespace Controllers.Controller
{

    public class CorteWebController : BaseWebController<CorteBindingModel, CorteParam>
    {
        
        public CorteWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Corte_";
        }



        public override string ContentJsonItem(CorteBindingModel item)
        {
            return JsonSerializer.Serialize<CorteBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<CorteParam >>(new SearchListBindingModel<CorteParam>((CorteParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<CorteParam >>(new SelectParamBindingModel<CorteParam>((CorteParam)param, search, fieldsSearching));
        }



        public async Task<Boolean?> AbrirCorte(CorteBindingModel item)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/AbrirCorte";

            try
            {

                var contentJson = JsonSerializer.Serialize<CorteBindingModel>(item);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<Boolean?>();
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
    
        public async Task<Boolean?> ReabrirCorte(CorteBindingModel item)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/ReabrirCorte";

            try
            {

                var contentJson = JsonSerializer.Serialize<CorteBindingModel>(item);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<Boolean?>();
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
    
        public async Task<Boolean?> AbrirNuevoCorte(CorteBindingModel item)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/AbrirNuevoCorte";

            try
            {

                var contentJson = JsonSerializer.Serialize<CorteBindingModel>(item);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<Boolean?>();
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
    
        public async Task<Boolean?> CerrarCorte(CorteBindingModel item)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/CerrarCorte";

            try
            {

                var contentJson = JsonSerializer.Serialize<CorteBindingModel>(item);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<Boolean?>();
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
    
        public async Task<CorteBindingModel?> CorteActivoUsuario(Int64? empresaId, Int64? sucursalId, Int64? usuarioId)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/CorteActivoUsuario";

            try
            {


                var contentJson = JsonSerializer.Serialize<Corte_CorteActivoUsuario_ApiParam>(new Corte_CorteActivoUsuario_ApiParam(){
                                        EmpresaId = empresaId, SucursalId = sucursalId, UsuarioId = usuarioId
                                    });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<CorteBindingModel?>();
                    return apiResponse;
                }
                //else
                //{
                //    string responseText = await response.Content.ReadAsStringAsync();
                //    throw new Exception(responseText);
                //}
                return null;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    
        public async Task<CorteBindingModel?> CorteUsuarioFecha(Int64? empresaId, Int64? sucursalId, Int64? usuarioId, DateTimeOffset fecha)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/CorteUsuarioFecha";

            try
            {


                var contentJson = JsonSerializer.Serialize<Corte_CorteUsuarioFecha_ApiParam>(new Corte_CorteUsuarioFecha_ApiParam(){
                                        EmpresaId = empresaId, SucursalId = sucursalId, UsuarioId = usuarioId, Fecha = fecha
                                    });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<CorteBindingModel?>();
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



