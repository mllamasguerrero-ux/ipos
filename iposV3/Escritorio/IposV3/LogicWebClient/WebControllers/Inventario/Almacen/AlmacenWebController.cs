
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

    public class AlmacenWebController : BaseWebController<AlmacenBindingModel, AlmacenParam>
    {
        
        public AlmacenWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Almacen_";
        }



        public override string ContentJsonItem(AlmacenBindingModel item)
        {
            return JsonSerializer.Serialize<AlmacenBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<AlmacenParam >>(new SearchListBindingModel<AlmacenParam>((AlmacenParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<AlmacenParam >>(new SelectParamBindingModel<AlmacenParam>((AlmacenParam)param, search, fieldsSearching));
        }






  }

}



