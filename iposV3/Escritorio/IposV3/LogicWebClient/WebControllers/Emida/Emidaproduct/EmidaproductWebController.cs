
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

    public class EmidaproductWebController : BaseWebController<EmidaproductBindingModel, EmidaproductParam>
    {
        
        public EmidaproductWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Emidaproduct_";
        }



        public override string ContentJsonItem(EmidaproductBindingModel item)
        {
            return JsonSerializer.Serialize<EmidaproductBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<EmidaproductParam >>(new SearchListBindingModel<EmidaproductParam>((EmidaproductParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<EmidaproductParam >>(new SelectParamBindingModel<EmidaproductParam>((EmidaproductParam)param, search, fieldsSearching));
        }






  }

}



