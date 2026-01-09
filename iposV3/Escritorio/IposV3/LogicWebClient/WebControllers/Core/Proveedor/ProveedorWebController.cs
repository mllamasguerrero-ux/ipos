
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

    public class ProveedorWebController : BaseWebController<ProveedorBindingModel, ProveedorParam>
    {
        
        public ProveedorWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Proveedor_";
        }



        public override string ContentJsonItem(ProveedorBindingModel item)
        {
            return JsonSerializer.Serialize<ProveedorBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<ProveedorParam >>(new SearchListBindingModel<ProveedorParam>((ProveedorParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<ProveedorParam >>(new SelectParamBindingModel<ProveedorParam>((ProveedorParam)param, search, fieldsSearching));
        }


        //NOTNEEDED MLG 2025 Migracion web
        //public async Task<Linq.IQueryable`1[Proveedor?> QueryableWithIncludesForEdit(Linq.IQueryable`1[Proveedor itemBasicQuery)
        //{

        //    string url = $"{GetDefaultBaseUrl()}/api/{pathController}/QueryableWithIncludesForEdit";

        //    try
        //    {

        //        var contentJson = JsonSerializer.Serialize<Linq.IQueryable`1[Proveedor>(itemBasicQuery);


        //        var httpClient = _httpClientFactory.CreateClient("AuthorizedClient");
        //        var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
        //        HttpResponseMessage response = await httpClient.PostAsync(url, content);

        //        if (response.IsSuccessStatusCode)
        //        {

        //            var apiResponse = await response.Content.ReadFromJsonAsync<Linq.IQueryable`1[Proveedor?>();
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



