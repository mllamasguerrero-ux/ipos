
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

    public class EstadopagocontrareciboWebController : BaseWebController<EstadopagocontrareciboBindingModel, EstadopagocontrareciboParam>
    {
        
        public EstadopagocontrareciboWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Estadopagocontrarecibo_";
        }



        public override string ContentJsonItem(EstadopagocontrareciboBindingModel item)
        {
            return JsonSerializer.Serialize<EstadopagocontrareciboBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<EstadopagocontrareciboParam >>(new SearchListBindingModel<EstadopagocontrareciboParam>((EstadopagocontrareciboParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<EstadopagocontrareciboParam >>(new SelectParamBindingModel<EstadopagocontrareciboParam>((EstadopagocontrareciboParam)param, search, fieldsSearching));
        }






  }

}



