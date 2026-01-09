
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

    public class ListaprecioWebController : BaseWebController<ListaprecioBindingModel, ListaprecioParam>
    {
        
        public ListaprecioWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Listaprecio_";
        }



        public override string ContentJsonItem(ListaprecioBindingModel item)
        {
            return JsonSerializer.Serialize<ListaprecioBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<ListaprecioParam >>(new SearchListBindingModel<ListaprecioParam>((ListaprecioParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<ListaprecioParam >>(new SelectParamBindingModel<ListaprecioParam>((ListaprecioParam)param, search, fieldsSearching));
        }
    




  }

}



