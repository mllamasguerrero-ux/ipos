
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

    public class Sat_coloniaWebController : BaseWebController<Sat_coloniaBindingModel, Sat_coloniaParam>
    {
        
        public Sat_coloniaWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Sat_colonia_";
        }



        public override string ContentJsonItem(Sat_coloniaBindingModel item)
        {
            return JsonSerializer.Serialize<Sat_coloniaBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<Sat_coloniaParam >>(new SearchListBindingModel<Sat_coloniaParam>((Sat_coloniaParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<Sat_coloniaParam >>(new SelectParamBindingModel<Sat_coloniaParam>((Sat_coloniaParam)param, search, fieldsSearching));
        }






  }

}



