
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

    public class TipotransaccionWebController : BaseWebController<TipotransaccionBindingModel, TipotransaccionParam>
    {
        
        public TipotransaccionWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Tipotransaccion_";
        }



        public override string ContentJsonItem(TipotransaccionBindingModel item)
        {
            return JsonSerializer.Serialize<TipotransaccionBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<TipotransaccionParam >>(new SearchListBindingModel<TipotransaccionParam>((TipotransaccionParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<TipotransaccionParam >>(new SelectParamBindingModel<TipotransaccionParam>((TipotransaccionParam)param, search, fieldsSearching));
        }






  }

}



