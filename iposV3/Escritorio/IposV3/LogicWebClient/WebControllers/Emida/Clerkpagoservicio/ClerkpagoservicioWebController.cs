
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

    public class ClerkpagoservicioWebController : BaseWebController<ClerkpagoservicioBindingModel, ClerkpagoservicioParam>
    {
        
        public ClerkpagoservicioWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Clerkpagoservicio_";
        }



        public override string ContentJsonItem(ClerkpagoservicioBindingModel item)
        {
            return JsonSerializer.Serialize<ClerkpagoservicioBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<ClerkpagoservicioParam >>(new SearchListBindingModel<ClerkpagoservicioParam>((ClerkpagoservicioParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<ClerkpagoservicioParam >>(new SelectParamBindingModel<ClerkpagoservicioParam>((ClerkpagoservicioParam)param, search, fieldsSearching));
        }






  }

}



