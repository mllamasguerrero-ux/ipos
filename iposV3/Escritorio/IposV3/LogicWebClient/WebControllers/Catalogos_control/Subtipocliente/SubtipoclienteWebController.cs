
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

    public class SubtipoclienteWebController : BaseWebController<SubtipoclienteBindingModel, SubtipoclienteParam>
    {
        
        public SubtipoclienteWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Subtipocliente_";
        }



        public override string ContentJsonItem(SubtipoclienteBindingModel item)
        {
            return JsonSerializer.Serialize<SubtipoclienteBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<SubtipoclienteParam >>(new SearchListBindingModel<SubtipoclienteParam>((SubtipoclienteParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<SubtipoclienteParam >>(new SelectParamBindingModel<SubtipoclienteParam>((SubtipoclienteParam)param, search, fieldsSearching));
        }






  }

}



