
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

    public class EstadopaisWebController : BaseWebController<EstadopaisBindingModel, EstadopaisParam>
    {
        
        public EstadopaisWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Estadopais_";
        }



        public override string ContentJsonItem(EstadopaisBindingModel item)
        {
            return JsonSerializer.Serialize<EstadopaisBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<EstadopaisParam >>(new SearchListBindingModel<EstadopaisParam>((EstadopaisParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<EstadopaisParam >>(new SelectParamBindingModel<EstadopaisParam>((EstadopaisParam)param, search, fieldsSearching));
        }






  }

}



