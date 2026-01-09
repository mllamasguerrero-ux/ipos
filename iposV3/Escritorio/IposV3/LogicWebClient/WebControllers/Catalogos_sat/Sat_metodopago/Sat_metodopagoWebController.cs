
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

    public class Sat_metodopagoWebController : BaseWebController<Sat_metodopagoBindingModel, Sat_metodopagoParam>
    {
        
        public Sat_metodopagoWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Sat_metodopago_";
        }



        public override string ContentJsonItem(Sat_metodopagoBindingModel item)
        {
            return JsonSerializer.Serialize<Sat_metodopagoBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<Sat_metodopagoParam >>(new SearchListBindingModel<Sat_metodopagoParam>((Sat_metodopagoParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<Sat_metodopagoParam >>(new SelectParamBindingModel<Sat_metodopagoParam>((Sat_metodopagoParam)param, search, fieldsSearching));
        }






  }

}



