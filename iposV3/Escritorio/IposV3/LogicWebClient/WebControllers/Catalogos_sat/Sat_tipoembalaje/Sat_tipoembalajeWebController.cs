
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

    public class Sat_tipoembalajeWebController : BaseWebController<Sat_tipoembalajeBindingModel, Sat_tipoembalajeParam>
    {
        
        public Sat_tipoembalajeWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Sat_tipoembalaje_";
        }



        public override string ContentJsonItem(Sat_tipoembalajeBindingModel item)
        {
            return JsonSerializer.Serialize<Sat_tipoembalajeBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<Sat_tipoembalajeParam >>(new SearchListBindingModel<Sat_tipoembalajeParam>((Sat_tipoembalajeParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<Sat_tipoembalajeParam >>(new SelectParamBindingModel<Sat_tipoembalajeParam>((Sat_tipoembalajeParam)param, search, fieldsSearching));
        }






  }

}



