
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

    public class RangopromocionWebController : BaseWebController<RangopromocionBindingModel, RangopromocionParam>
    {
        
        public RangopromocionWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Rangopromocion_";
        }



        public override string ContentJsonItem(RangopromocionBindingModel item)
        {
            return JsonSerializer.Serialize<RangopromocionBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<RangopromocionParam >>(new SearchListBindingModel<RangopromocionParam>((RangopromocionParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<RangopromocionParam >>(new SelectParamBindingModel<RangopromocionParam>((RangopromocionParam)param, search, fieldsSearching));
        }






  }

}



