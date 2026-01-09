
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

    public class UsuarioWebController : BaseWebController<UsuarioBindingModel, UsuarioParam>
    {
        
        public UsuarioWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Usuario_";
        }



        public override string ContentJsonItem(UsuarioBindingModel item)
        {
            return JsonSerializer.Serialize<UsuarioBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<UsuarioParam >>(new SearchListBindingModel<UsuarioParam>((UsuarioParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<UsuarioParam >>(new SelectParamBindingModel<UsuarioParam>((UsuarioParam)param, search, fieldsSearching));
        }



        public async Task<Boolean?> UpdateContrasena(CambiocontrasenaWFBindingModel item)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/UpdateContrasena";

            try
            {

                var contentJson = JsonSerializer.Serialize<CambiocontrasenaWFBindingModel>(item);


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
    
        public async Task<WFLoginResultBindingModel?> ValidateLogin(WFLoginParamBindingModel param)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/ValidateLogin";

            try
            {

                var contentJson = JsonSerializer.Serialize<WFLoginParamBindingModel>(param);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<WFLoginResultBindingModel?>();
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
    
        public async Task<List<UsuarioPerfilItemBindingModel>?> GetUsuariosPerfiles(UsuarioBindingModel itemSelect, KendoParams kendoParams)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/GetUsuariosPerfiles";

            try
            {


                var contentJson = JsonSerializer.Serialize<Usuario_GetUsuariosPerfiles_ApiParam>(new Usuario_GetUsuariosPerfiles_ApiParam(){
                                        ItemSelect = itemSelect, KendoParams = kendoParams
                                    });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<UsuarioPerfilItemBindingModel>?>();
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
    
        public async Task<Boolean?> UpdateUsuariosPerfiles(UsuarioBindingModel itemSelect, List<UsuarioPerfilItemBindingModel> usuarios_perfiles)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/UpdateUsuariosPerfiles";

            try
            {


                var contentJson = JsonSerializer.Serialize<Usuario_UpdateUsuariosPerfiles_ApiParam>(new Usuario_UpdateUsuariosPerfiles_ApiParam(){
                                        ItemSelect = itemSelect, Usuarios_perfiles = usuarios_perfiles
                                    });


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
    
        public async Task<Dictionary<Int64,Boolean>?> Obtain_usuarios_derechos_List(Int64 empresaid, Int64 sucursalid, List<Int64> derechos, Int64 usuarioId)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Obtain_usuarios_derechos_List";

            try
            {


                var contentJson = JsonSerializer.Serialize<Usuario_Obtain_usuarios_derechos_List_ApiParam>(new Usuario_Obtain_usuarios_derechos_List_ApiParam(){
                                        Empresaid = empresaid, Sucursalid = sucursalid, Derechos = derechos, UsuarioId = usuarioId
                                    });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<Dictionary<Int64,Boolean>?>();
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



