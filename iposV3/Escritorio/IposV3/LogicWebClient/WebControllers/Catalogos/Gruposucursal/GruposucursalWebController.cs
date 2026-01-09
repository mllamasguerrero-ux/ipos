
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

    public class GruposucursalWebController : BaseWebController<GruposucursalBindingModel, GruposucursalParam>
    {
        
        public GruposucursalWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Gruposucursal_";
        }



        public override string ContentJsonItem(GruposucursalBindingModel item)
        {
            return JsonSerializer.Serialize<GruposucursalBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<GruposucursalParam >>(new SearchListBindingModel<GruposucursalParam>((GruposucursalParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<GruposucursalParam >>(new SelectParamBindingModel<GruposucursalParam>((GruposucursalParam)param, search, fieldsSearching));
        }






  }

}



