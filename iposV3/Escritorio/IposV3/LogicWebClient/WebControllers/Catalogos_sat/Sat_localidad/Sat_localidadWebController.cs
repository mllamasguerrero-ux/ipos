
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

    public class Sat_localidadWebController : BaseWebController<Sat_localidadBindingModel, Sat_localidadParam>
    {
        
        public Sat_localidadWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Sat_localidad_";
        }



        public override string ContentJsonItem(Sat_localidadBindingModel item)
        {
            return JsonSerializer.Serialize<Sat_localidadBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<Sat_localidadParam >>(new SearchListBindingModel<Sat_localidadParam>((Sat_localidadParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<Sat_localidadParam >>(new SelectParamBindingModel<Sat_localidadParam>((Sat_localidadParam)param, search, fieldsSearching));
        }






  }

}



