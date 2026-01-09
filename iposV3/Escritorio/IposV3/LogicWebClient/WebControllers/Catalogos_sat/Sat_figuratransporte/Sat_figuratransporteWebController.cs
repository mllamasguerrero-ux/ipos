
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

    public class Sat_figuratransporteWebController : BaseWebController<Sat_figuratransporteBindingModel, Sat_figuratransporteParam>
    {
        
        public Sat_figuratransporteWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Sat_figuratransporte_";
        }



        public override string ContentJsonItem(Sat_figuratransporteBindingModel item)
        {
            return JsonSerializer.Serialize<Sat_figuratransporteBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<Sat_figuratransporteParam >>(new SearchListBindingModel<Sat_figuratransporteParam>((Sat_figuratransporteParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<Sat_figuratransporteParam >>(new SelectParamBindingModel<Sat_figuratransporteParam>((Sat_figuratransporteParam)param, search, fieldsSearching));
        }






  }

}



