
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

    public class FormapagoWebController : BaseWebController<FormapagoBindingModel, FormapagoParam>
    {
        
        public FormapagoWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Formapago_";
        }



        public override string ContentJsonItem(FormapagoBindingModel item)
        {
            return JsonSerializer.Serialize<FormapagoBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<FormapagoParam >>(new SearchListBindingModel<FormapagoParam>((FormapagoParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<FormapagoParam >>(new SelectParamBindingModel<FormapagoParam>((FormapagoParam)param, search, fieldsSearching));
        }






  }

}



