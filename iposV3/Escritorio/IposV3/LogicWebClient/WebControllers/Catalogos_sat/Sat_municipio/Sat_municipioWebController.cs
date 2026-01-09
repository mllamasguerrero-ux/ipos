
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

    public class Sat_municipioWebController : BaseWebController<Sat_municipioBindingModel, Sat_municipioParam>
    {
        
        public Sat_municipioWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Sat_municipio_";
        }



        public override string ContentJsonItem(Sat_municipioBindingModel item)
        {
            return JsonSerializer.Serialize<Sat_municipioBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<Sat_municipioParam >>(new SearchListBindingModel<Sat_municipioParam>((Sat_municipioParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<Sat_municipioParam >>(new SelectParamBindingModel<Sat_municipioParam>((Sat_municipioParam)param, search, fieldsSearching));
        }






  }

}



