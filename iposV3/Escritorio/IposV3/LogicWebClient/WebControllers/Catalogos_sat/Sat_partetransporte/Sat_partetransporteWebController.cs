
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

    public class Sat_partetransporteWebController : BaseWebController<Sat_partetransporteBindingModel, Sat_partetransporteParam>
    {
        
        public Sat_partetransporteWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Sat_partetransporte_";
        }



        public override string ContentJsonItem(Sat_partetransporteBindingModel item)
        {
            return JsonSerializer.Serialize<Sat_partetransporteBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<Sat_partetransporteParam >>(new SearchListBindingModel<Sat_partetransporteParam>((Sat_partetransporteParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<Sat_partetransporteParam >>(new SelectParamBindingModel<Sat_partetransporteParam>((Sat_partetransporteParam)param, search, fieldsSearching));
        }






  }

}



