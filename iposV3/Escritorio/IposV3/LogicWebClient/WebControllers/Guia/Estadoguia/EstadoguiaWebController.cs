
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

    public class EstadoguiaWebController : BaseWebController<EstadoguiaBindingModel, EstadoguiaParam>
    {
        
        public EstadoguiaWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Estadoguia_";
        }



        public override string ContentJsonItem(EstadoguiaBindingModel item)
        {
            return JsonSerializer.Serialize<EstadoguiaBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<EstadoguiaParam >>(new SearchListBindingModel<EstadoguiaParam>((EstadoguiaParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<EstadoguiaParam >>(new SelectParamBindingModel<EstadoguiaParam>((EstadoguiaParam)param, search, fieldsSearching));
        }






  }

}



