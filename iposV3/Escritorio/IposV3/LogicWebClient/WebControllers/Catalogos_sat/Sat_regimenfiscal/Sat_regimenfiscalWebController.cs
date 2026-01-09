
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

    public class Sat_regimenfiscalWebController : BaseWebController<Sat_regimenfiscalBindingModel, Sat_regimenfiscalParam>
    {
        
        public Sat_regimenfiscalWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Sat_regimenfiscal_";
        }



        public override string ContentJsonItem(Sat_regimenfiscalBindingModel item)
        {
            return JsonSerializer.Serialize<Sat_regimenfiscalBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<Sat_regimenfiscalParam >>(new SearchListBindingModel<Sat_regimenfiscalParam>((Sat_regimenfiscalParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<Sat_regimenfiscalParam >>(new SelectParamBindingModel<Sat_regimenfiscalParam>((Sat_regimenfiscalParam)param, search, fieldsSearching));
        }






  }

}



