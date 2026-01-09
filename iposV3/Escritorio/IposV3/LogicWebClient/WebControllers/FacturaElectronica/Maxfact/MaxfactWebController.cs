
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

    public class MaxfactWebController : BaseWebController<MaxfactBindingModel, MaxfactParam>
    {
        
        public MaxfactWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Maxfact_";
        }



        public override string ContentJsonItem(MaxfactBindingModel item)
        {
            return JsonSerializer.Serialize<MaxfactBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<MaxfactParam >>(new SearchListBindingModel<MaxfactParam>((MaxfactParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<MaxfactParam >>(new SelectParamBindingModel<MaxfactParam>((MaxfactParam)param, search, fieldsSearching));
        }






  }

}



