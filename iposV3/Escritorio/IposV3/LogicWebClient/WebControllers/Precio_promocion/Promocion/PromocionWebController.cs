
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

    public class PromocionWebController : BaseWebController<PromocionBindingModel, PromocionParam>
    {
        
        public PromocionWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Promocion_";
        }



        public override string ContentJsonItem(PromocionBindingModel item)
        {
            return JsonSerializer.Serialize<PromocionBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<PromocionParam >>(new SearchListBindingModel<PromocionParam>((PromocionParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<PromocionParam >>(new SelectParamBindingModel<PromocionParam>((PromocionParam)param, search, fieldsSearching));
        }






  }

}



