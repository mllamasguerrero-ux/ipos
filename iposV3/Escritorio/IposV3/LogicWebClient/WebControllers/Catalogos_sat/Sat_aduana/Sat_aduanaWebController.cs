
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

    public class Sat_aduanaWebController : BaseWebController<Sat_aduanaBindingModel, Sat_aduanaParam>
    {
        
        public Sat_aduanaWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Sat_aduana_";
        }



        public override string ContentJsonItem(Sat_aduanaBindingModel item)
        {
            return JsonSerializer.Serialize<Sat_aduanaBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<Sat_aduanaParam >>(new SearchListBindingModel<Sat_aduanaParam>((Sat_aduanaParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<Sat_aduanaParam >>(new SelectParamBindingModel<Sat_aduanaParam>((Sat_aduanaParam)param, search, fieldsSearching));
        }






  }

}



