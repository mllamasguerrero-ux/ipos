
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

    public class AreaWebController : BaseWebController<AreaBindingModel, AreaParam>
    {
        
        public AreaWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Area_";
        }



        public override string ContentJsonItem(AreaBindingModel item)
        {
            return JsonSerializer.Serialize<AreaBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<AreaParam >>(new SearchListBindingModel<AreaParam>((AreaParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<AreaParam >>(new SelectParamBindingModel<AreaParam>((AreaParam)param, search, fieldsSearching));
        }






  }

}



