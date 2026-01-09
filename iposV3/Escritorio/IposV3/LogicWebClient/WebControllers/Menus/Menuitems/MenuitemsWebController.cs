
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

    public class MenuitemsWebController : BaseGenericWebController
    {
        
        public MenuitemsWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Menuitems_";
        }



        public async Task<Boolean?> ValidMenu(String menu)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/ValidMenu";

            try
            {

                var contentJson = JsonSerializer.Serialize<String>(menu);


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
    
        public async Task<List<Controllers.BindingModel.Menu.MyMenuDataBindingModel>?> SelectPorUsuario(Int64 empresaId, Int64 sucursalId, Int64 usuarioId)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/SelectPorUsuario";

            try
            {


                var contentJson = JsonSerializer.Serialize<Menuitems_SelectPorUsuario_ApiParam>(new Menuitems_SelectPorUsuario_ApiParam(){
                                        EmpresaId = empresaId, SucursalId = sucursalId, UsuarioId = usuarioId
                                    });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<Controllers.BindingModel.Menu.MyMenuDataBindingModel>?>();
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



        public async Task<Int32?> AddMenuRecursive(Controllers.BindingModel.Menu.MyMenuDataBindingModel mnuItem, List<MenuitemsBindingModel> menuItems)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/AddMenuRecursive";

            try
            {


                var contentJson = JsonSerializer.Serialize<Menuitems_AddMenuRecursive_ApiParam>(new Menuitems_AddMenuRecursive_ApiParam(){
                                        MnuItem = mnuItem, MenuItems = menuItems
                                    });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<Int32?>();
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



