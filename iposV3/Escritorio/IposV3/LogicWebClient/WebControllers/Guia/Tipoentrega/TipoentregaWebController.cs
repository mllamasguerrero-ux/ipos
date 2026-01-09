
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

    public class TipoentregaWebController : BaseWebController<TipoentregaBindingModel, TipoentregaParam>
    {
        
        public TipoentregaWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Tipoentrega_";
        }



        public override string ContentJsonItem(TipoentregaBindingModel item)
        {
            return JsonSerializer.Serialize<TipoentregaBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<TipoentregaParam >>(new SearchListBindingModel<TipoentregaParam>((TipoentregaParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<TipoentregaParam >>(new SelectParamBindingModel<TipoentregaParam>((TipoentregaParam)param, search, fieldsSearching));
        }






  }

}



