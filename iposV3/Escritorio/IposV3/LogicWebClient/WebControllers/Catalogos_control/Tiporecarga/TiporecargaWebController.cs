
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

    public class TiporecargaWebController : BaseWebController<TiporecargaBindingModel, TiporecargaParam>
    {
        
        public TiporecargaWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Tiporecarga_";
        }



        public override string ContentJsonItem(TiporecargaBindingModel item)
        {
            return JsonSerializer.Serialize<TiporecargaBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<TiporecargaParam >>(new SearchListBindingModel<TiporecargaParam>((TiporecargaParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<TiporecargaParam >>(new SelectParamBindingModel<TiporecargaParam>((TiporecargaParam)param, search, fieldsSearching));
        }






  }

}



