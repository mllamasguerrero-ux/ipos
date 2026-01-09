
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

    public class MonedaWebController : BaseWebController<MonedaBindingModel, MonedaParam>
    {
        
        public MonedaWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Moneda_";
        }



        public override string ContentJsonItem(MonedaBindingModel item)
        {
            return JsonSerializer.Serialize<MonedaBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<MonedaParam >>(new SearchListBindingModel<MonedaParam>((MonedaParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<MonedaParam >>(new SelectParamBindingModel<MonedaParam>((MonedaParam)param, search, fieldsSearching));
        }






  }

}



