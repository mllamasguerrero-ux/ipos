
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

    public class KitdefinicionWebController : BaseWebController<KitdefinicionBindingModel, KitdefinicionParam>
    {
        
        public KitdefinicionWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Kitdefinicion_";
        }



        public override string ContentJsonItem(KitdefinicionBindingModel item)
        {
            return JsonSerializer.Serialize<KitdefinicionBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<KitdefinicionParam >>(new SearchListBindingModel<KitdefinicionParam>((KitdefinicionParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<KitdefinicionParam >>(new SelectParamBindingModel<KitdefinicionParam>((KitdefinicionParam)param, search, fieldsSearching));
        }




        //DONE2 MLG 2025 Migracion web -- checar el out
        public async Task<ImpuestoKitDefinicion?> InsertYModificarImpuestosSiAplica(KitdefinicionBindingModel item
                                                                                    //, out ImpuestoKitDefinicion impuestoKitDefinicion
                                                                                    )
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/InsertYModificarImpuestosSiAplica";

            try
            {


                var contentJson = JsonSerializer.Serialize<Kitdefinicion_InsertYModificarImpuestosSiAplica_ApiParam>(new Kitdefinicion_InsertYModificarImpuestosSiAplica_ApiParam()
                {
                    Item = item
                    //, ImpuestoKitDefinicion = impuestoKitDefinicion
                });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<ImpuestoKitDefinicion?>();
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


        //DONE2 MLG 2025 Migracion web -- checar el out

        public async Task<ImpuestoKitDefinicion?> UpdateYModificarImpuestosSiAplica(KitdefinicionBindingModel item
                                                                      //, out ImpuestoKitDefinicion impuestoKitDefinicion
                                                                      )
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/UpdateYModificarImpuestosSiAplica";

            try
            {


                var contentJson = JsonSerializer.Serialize<Kitdefinicion_UpdateYModificarImpuestosSiAplica_ApiParam>(new Kitdefinicion_UpdateYModificarImpuestosSiAplica_ApiParam()
                {
                    Item = item//, ImpuestoKitDefinicion = impuestoKitDefinicion
                });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<ImpuestoKitDefinicion?>();
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

        public async Task<ImpuestoKitDefinicion?> CurrentInfoImpuestosKit(Int64 empresaId, Int64 sucursalId, Int64 productoKitId)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/CurrentInfoImpuestosKit";

            try
            {


                var contentJson = JsonSerializer.Serialize<Kitdefinicion_CurrentInfoImpuestosKit_ApiParam>(new Kitdefinicion_CurrentInfoImpuestosKit_ApiParam(){
                                        EmpresaId = empresaId, SucursalId = sucursalId, ProductoKitId = productoKitId
                                    });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<ImpuestoKitDefinicion?>();
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


        //DONE2 MLG 2025 Migracion web -- checar el out
        public async Task<ImpuestoKitDefinicion?> DeleteYModificarImpuestosSiAplica(KitdefinicionBindingModel item
                                                                     //, out ImpuestoKitDefinicion impuestoKitDefinicion
                                                                     )
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/DeleteYModificarImpuestosSiAplica";

            try
            {


                var contentJson = JsonSerializer.Serialize<Kitdefinicion_DeleteYModificarImpuestosSiAplica_ApiParam>(new Kitdefinicion_DeleteYModificarImpuestosSiAplica_ApiParam()
                {
                    Item = item//, ImpuestoKitDefinicion = impuestoKitDefinicion
                });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<ImpuestoKitDefinicion?>();
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



