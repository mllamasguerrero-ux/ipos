
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

    public class VehiculoWebController : BaseWebController<VehiculoBindingModel, VehiculoParam>
    {
        
        public VehiculoWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Vehiculo_";
        }



        public override string ContentJsonItem(VehiculoBindingModel item)
        {
            return JsonSerializer.Serialize<VehiculoBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<VehiculoParam >>(new SearchListBindingModel<VehiculoParam>((VehiculoParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<VehiculoParam >>(new SelectParamBindingModel<VehiculoParam>((VehiculoParam)param, search, fieldsSearching));
        }






  }

}



