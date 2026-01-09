
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

    public class MensajenivelurgenciaWebController : BaseWebController<MensajenivelurgenciaBindingModel, MensajenivelurgenciaParam>
    {
        
        public MensajenivelurgenciaWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Mensajenivelurgencia_";
        }



        public override string ContentJsonItem(MensajenivelurgenciaBindingModel item)
        {
            return JsonSerializer.Serialize<MensajenivelurgenciaBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<MensajenivelurgenciaParam >>(new SearchListBindingModel<MensajenivelurgenciaParam>((MensajenivelurgenciaParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<MensajenivelurgenciaParam >>(new SelectParamBindingModel<MensajenivelurgenciaParam>((MensajenivelurgenciaParam)param, search, fieldsSearching));
        }






  }

}



