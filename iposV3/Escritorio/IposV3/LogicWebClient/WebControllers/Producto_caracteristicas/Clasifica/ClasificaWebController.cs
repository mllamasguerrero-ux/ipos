
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

    public class ClasificaWebController : BaseWebController<ClasificaBindingModel, ClasificaParam>
    {
        
        public ClasificaWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Clasifica_";
        }



        public override string ContentJsonItem(ClasificaBindingModel item)
        {
            return JsonSerializer.Serialize<ClasificaBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<ClasificaParam >>(new SearchListBindingModel<ClasificaParam>((ClasificaParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<ClasificaParam >>(new SelectParamBindingModel<ClasificaParam>((ClasificaParam)param, search, fieldsSearching));
        }






  }

}



