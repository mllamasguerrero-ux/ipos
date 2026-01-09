
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

    public class Sucursal_infoWebController : BaseWebController<Sucursal_infoBindingModel, Sucursal_infoParam>
    {
        
        public Sucursal_infoWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Sucursal_info_";
        }



        public override string ContentJsonItem(Sucursal_infoBindingModel item)
        {
            return JsonSerializer.Serialize<Sucursal_infoBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<Sucursal_infoParam >>(new SearchListBindingModel<Sucursal_infoParam>((Sucursal_infoParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<Sucursal_infoParam >>(new SelectParamBindingModel<Sucursal_infoParam>((Sucursal_infoParam)param, search, fieldsSearching));
        }






  }

}



