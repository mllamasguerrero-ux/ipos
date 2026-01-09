
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

    public class ProductoWebController : BaseWebController<ProductoBindingModel, ProductoParam>
    {
        
        public ProductoWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Producto_";
        }



        public override string ContentJsonItem(ProductoBindingModel item)
        {
            return JsonSerializer.Serialize<ProductoBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<ProductoParam >>(new SearchListBindingModel<ProductoParam>((ProductoParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<ProductoParam >>(new SelectParamBindingModel<ProductoParam>((ProductoParam)param, search, fieldsSearching));
        }



        public async Task<Prod_def_caracteristicasBindingModel?> ObtenerProd_def_Caracterisiticas(Prod_def_caracteristicasBindingModel obj)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/ObtenerProd_def_Caracterisiticas";

            try
            {

                var contentJson = JsonSerializer.Serialize<Prod_def_caracteristicasBindingModel>(obj);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<Prod_def_caracteristicasBindingModel?>();
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
    
        public async Task<Boolean?> GuardarProd_def_caracteristicas(Prod_def_caracteristicasBindingModel item)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/GuardarProd_def_caracteristicas";

            try
            {

                var contentJson = JsonSerializer.Serialize<Prod_def_caracteristicasBindingModel>(item);


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

        //NOTNEEDED MLG 2025 Migracion web
        //public async Task<Linq.IQueryable`1[Producto?> QueryableWithIncludesBasic(Linq.IQueryable`1[Producto itemBasicQuery)
        //{

        //    string url = $"{GetDefaultBaseUrl()}/api/{pathController}/QueryableWithIncludesBasic";

        //    try
        //    {

        //        var contentJson = JsonSerializer.Serialize<Linq.IQueryable`1[Producto>(itemBasicQuery);


        //        var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
        //        var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
        //        HttpResponseMessage response = await httpClient.PostAsync(url, content);

        //        if (response.IsSuccessStatusCode)
        //        {

        //            var apiResponse = await response.Content.ReadFromJsonAsync<Linq.IQueryable`1[Producto?>();
        //            return apiResponse;
        //        }
        //        else
        //        {
        //            string responseText = await response.Content.ReadAsStringAsync();
        //            throw new Exception(responseText);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return null;
        //    }
        //}

        public async Task<List<ProductoListBindingModel>?> SelectForSimpleList(ProductoParam param, KendoParams kendoParams)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/SelectForSimpleList";

            try
            {


                var contentJson = JsonSerializer.Serialize<Producto_SelectForSimpleList_ApiParam>(new Producto_SelectForSimpleList_ApiParam(){
                                        Param = param, KendoParams = kendoParams
                                    });


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<List<ProductoListBindingModel>?>();
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



