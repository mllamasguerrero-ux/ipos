
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

    public class RutaembarqueWebController : BaseWebController<RutaembarqueBindingModel, RutaembarqueParam>
    {
        
        public RutaembarqueWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Rutaembarque_";
        }



        public override string ContentJsonItem(RutaembarqueBindingModel item)
        {
            return JsonSerializer.Serialize<RutaembarqueBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<RutaembarqueParam >>(new SearchListBindingModel<RutaembarqueParam>((RutaembarqueParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<RutaembarqueParam >>(new SelectParamBindingModel<RutaembarqueParam>((RutaembarqueParam)param, search, fieldsSearching));
        }






  }

}



