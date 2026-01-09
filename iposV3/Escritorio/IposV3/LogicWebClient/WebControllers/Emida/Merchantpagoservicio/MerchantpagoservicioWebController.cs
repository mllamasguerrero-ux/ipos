
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

    public class MerchantpagoservicioWebController : BaseWebController<MerchantpagoservicioBindingModel, MerchantpagoservicioParam>
    {
        
        public MerchantpagoservicioWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Merchantpagoservicio_";
        }



        public override string ContentJsonItem(MerchantpagoservicioBindingModel item)
        {
            return JsonSerializer.Serialize<MerchantpagoservicioBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<MerchantpagoservicioParam >>(new SearchListBindingModel<MerchantpagoservicioParam>((MerchantpagoservicioParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<MerchantpagoservicioParam >>(new SelectParamBindingModel<MerchantpagoservicioParam>((MerchantpagoservicioParam)param, search, fieldsSearching));
        }






  }

}



