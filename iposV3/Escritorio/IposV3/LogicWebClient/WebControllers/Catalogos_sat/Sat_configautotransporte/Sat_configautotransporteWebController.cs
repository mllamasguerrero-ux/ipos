
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

    public class Sat_configautotransporteWebController : BaseWebController<Sat_configautotransporteBindingModel, Sat_configautotransporteParam>
    {
        
        public Sat_configautotransporteWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Sat_configautotransporte_";
        }



        public override string ContentJsonItem(Sat_configautotransporteBindingModel item)
        {
            return JsonSerializer.Serialize<Sat_configautotransporteBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<Sat_configautotransporteParam >>(new SearchListBindingModel<Sat_configautotransporteParam>((Sat_configautotransporteParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<Sat_configautotransporteParam >>(new SelectParamBindingModel<Sat_configautotransporteParam>((Sat_configautotransporteParam)param, search, fieldsSearching));
        }






  }

}



