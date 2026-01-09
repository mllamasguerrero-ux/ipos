
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

    public class PlazoWebController : BaseWebController<PlazoBindingModel, PlazoParam>
    {
        
        public PlazoWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Plazo_";
        }



        public override string ContentJsonItem(PlazoBindingModel item)
        {
            return JsonSerializer.Serialize<PlazoBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<PlazoParam >>(new SearchListBindingModel<PlazoParam>((PlazoParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<PlazoParam >>(new SelectParamBindingModel<PlazoParam>((PlazoParam)param, search, fieldsSearching));
        }






  }

}



