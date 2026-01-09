
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

    public class ClienteWebController : BaseWebController<ClienteBindingModel, ClienteParam>
    {
        
        public ClienteWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Cliente_";
        }



        public override string ContentJsonItem(ClienteBindingModel item)
        {
            return JsonSerializer.Serialize<ClienteBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<ClienteParam >>(new SearchListBindingModel<ClienteParam>((ClienteParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<ClienteParam >>(new SelectParamBindingModel<ClienteParam>((ClienteParam)param, search, fieldsSearching));
        }


        //NOTNEEDED MLG 2025 Migracion web
        //public async Task<Linq.IQueryable`1[Cliente?> QueryableWithIncludesWithEdit(Linq.IQueryable`1[Cliente itemBasicQuery)
        //{

        //    string url = $"{GetDefaultBaseUrl()}/api/{pathController}/QueryableWithIncludesWithEdit";

        //    try
        //    {

        //        var contentJson = JsonSerializer.Serialize<Linq.IQueryable`1[Cliente>(itemBasicQuery);


        //        var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
        //        var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
        //        HttpResponseMessage response = await httpClient.PostAsync(url, content);

        //        if (response.IsSuccessStatusCode)
        //        {

        //            var apiResponse = await response.Content.ReadFromJsonAsync<Linq.IQueryable`1[Cliente?>();
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
    



  }

}



