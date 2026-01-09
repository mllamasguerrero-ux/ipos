
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

    public class EstadocobranzaWebController : BaseWebController<EstadocobranzaBindingModel, EstadocobranzaParam>
    {
        
        public EstadocobranzaWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Estadocobranza_";
        }



        public override string ContentJsonItem(EstadocobranzaBindingModel item)
        {
            return JsonSerializer.Serialize<EstadocobranzaBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<EstadocobranzaParam >>(new SearchListBindingModel<EstadocobranzaParam>((EstadocobranzaParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<EstadocobranzaParam >>(new SelectParamBindingModel<EstadocobranzaParam>((EstadocobranzaParam)param, search, fieldsSearching));
        }






  }

}



