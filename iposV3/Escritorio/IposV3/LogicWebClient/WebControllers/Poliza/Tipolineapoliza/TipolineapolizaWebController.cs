
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

    public class TipolineapolizaWebController : BaseWebController<TipolineapolizaBindingModel, TipolineapolizaParam>
    {
        
        public TipolineapolizaWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Tipolineapoliza_";
        }



        public override string ContentJsonItem(TipolineapolizaBindingModel item)
        {
            return JsonSerializer.Serialize<TipolineapolizaBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<TipolineapolizaParam >>(new SearchListBindingModel<TipolineapolizaParam>((TipolineapolizaParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<TipolineapolizaParam >>(new SelectParamBindingModel<TipolineapolizaParam>((TipolineapolizaParam)param, search, fieldsSearching));
        }






  }

}



