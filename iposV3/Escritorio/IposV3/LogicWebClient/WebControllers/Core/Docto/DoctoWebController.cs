
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

    public class DoctoWebController : BaseWebController<DoctoBindingModel, DoctoParam>
    {
        
        public DoctoWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Docto_";
        }



        public override string ContentJsonItem(DoctoBindingModel item)
        {
            return JsonSerializer.Serialize<DoctoBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<DoctoParam >>(new SearchListBindingModel<DoctoParam>((DoctoParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<DoctoParam >>(new SelectParamBindingModel<DoctoParam>((DoctoParam)param, search, fieldsSearching));
        }


        //NOTNEEDED MLG 2025 Migracion web
        //public async Task<Linq.IQueryable`1[Docto?> QueryableWithIncludesSecondaryInfo(Linq.IQueryable`1[Docto itemBasicQuery)
        //{

        //    string url = $"{GetDefaultBaseUrl()}/api/{pathController}/QueryableWithIncludesSecondaryInfo";

        //    try
        //    {

        //        var contentJson = JsonSerializer.Serialize<Linq.IQueryable`1[Docto>(itemBasicQuery);


        //        var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
        //        var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
        //        HttpResponseMessage response = await httpClient.PostAsync(url, content);

        //        if (response.IsSuccessStatusCode)
        //        {

        //            var apiResponse = await response.Content.ReadFromJsonAsync<Linq.IQueryable`1[Docto?>();
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

        //public async Task<Linq.IQueryable`1[Docto?> QueryableWithIncludesFull(Linq.IQueryable`1[Docto itemBasicQuery)
        //{

        //    string url = $"{GetDefaultBaseUrl()}/api/{pathController}/QueryableWithIncludesFull";

        //    try
        //    {

        //        var contentJson = JsonSerializer.Serialize<Linq.IQueryable`1[Docto>(itemBasicQuery);


        //        var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
        //        var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
        //        HttpResponseMessage response = await httpClient.PostAsync(url, content);

        //        if (response.IsSuccessStatusCode)
        //        {

        //            var apiResponse = await response.Content.ReadFromJsonAsync<Linq.IQueryable`1[Docto?>();
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

        public async Task<DoctoBindingModel?> Get_BasicDocto(DoctoBindingModel itemSelect)
        {

            string url = $"{GetDefaultBaseUrl()}/api/{pathController}/Get_BasicDocto";

            try
            {

                var contentJson = JsonSerializer.Serialize<DoctoBindingModel>(itemSelect);


                var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    var apiResponse = await response.Content.ReadFromJsonAsync<DoctoBindingModel?>();
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



