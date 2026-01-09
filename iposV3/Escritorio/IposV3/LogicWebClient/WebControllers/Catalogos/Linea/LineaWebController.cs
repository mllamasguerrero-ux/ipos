
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

    public class LineaWebController : BaseWebController<LineaBindingModel, LineaParam>
    {
        
        public LineaWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Linea_";
        }



        public override string ContentJsonItem(LineaBindingModel item)
        {
            return JsonSerializer.Serialize<LineaBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<LineaParam >>(new SearchListBindingModel<LineaParam>((LineaParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<LineaParam >>(new SelectParamBindingModel<LineaParam>((LineaParam)param, search, fieldsSearching));
        }






  }

}



