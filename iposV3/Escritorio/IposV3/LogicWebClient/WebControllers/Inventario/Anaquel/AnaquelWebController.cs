
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

    public class AnaquelWebController : BaseWebController<AnaquelBindingModel, AnaquelParam>
    {
        
        public AnaquelWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Anaquel_";
        }



        public override string ContentJsonItem(AnaquelBindingModel item)
        {
            return JsonSerializer.Serialize<AnaquelBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<AnaquelParam >>(new SearchListBindingModel<AnaquelParam>((AnaquelParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<AnaquelParam >>(new SelectParamBindingModel<AnaquelParam>((AnaquelParam)param, search, fieldsSearching));
        }






  }

}



