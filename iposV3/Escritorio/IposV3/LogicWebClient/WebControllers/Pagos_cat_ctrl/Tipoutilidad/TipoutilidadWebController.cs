
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

    public class TipoutilidadWebController : BaseWebController<TipoutilidadBindingModel, TipoutilidadParam>
    {
        
        public TipoutilidadWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Tipoutilidad_";
        }



        public override string ContentJsonItem(TipoutilidadBindingModel item)
        {
            return JsonSerializer.Serialize<TipoutilidadBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<TipoutilidadParam >>(new SearchListBindingModel<TipoutilidadParam>((TipoutilidadParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<TipoutilidadParam >>(new SelectParamBindingModel<TipoutilidadParam>((TipoutilidadParam)param, search, fieldsSearching));
        }
    




  }

}



