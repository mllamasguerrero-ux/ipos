
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

    public class Sat_paisWebController : BaseWebController<Sat_paisBindingModel, Sat_paisParam>
    {
        
        public Sat_paisWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Sat_pais_";
        }



        public override string ContentJsonItem(Sat_paisBindingModel item)
        {
            return JsonSerializer.Serialize<Sat_paisBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<Sat_paisParam >>(new SearchListBindingModel<Sat_paisParam>((Sat_paisParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<Sat_paisParam >>(new SelectParamBindingModel<Sat_paisParam>((Sat_paisParam)param, search, fieldsSearching));
        }






  }

}



