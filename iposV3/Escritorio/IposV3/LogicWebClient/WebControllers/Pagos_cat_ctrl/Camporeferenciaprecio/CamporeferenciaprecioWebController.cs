
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

    public class CamporeferenciaprecioWebController : BaseWebController<CamporeferenciaprecioBindingModel, CamporeferenciaprecioParam>
    {
        
        public CamporeferenciaprecioWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Camporeferenciaprecio_";
        }



        public override string ContentJsonItem(CamporeferenciaprecioBindingModel item)
        {
            return JsonSerializer.Serialize<CamporeferenciaprecioBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<CamporeferenciaprecioParam >>(new SearchListBindingModel<CamporeferenciaprecioParam>((CamporeferenciaprecioParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<CamporeferenciaprecioParam >>(new SelectParamBindingModel<CamporeferenciaprecioParam>((CamporeferenciaprecioParam)param, search, fieldsSearching));
        }
    




  }

}



