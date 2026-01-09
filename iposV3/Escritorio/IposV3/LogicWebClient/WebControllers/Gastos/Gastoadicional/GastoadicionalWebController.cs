
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

    public class GastoadicionalWebController : BaseWebController<GastoadicionalBindingModel, GastoadicionalParam>
    {
        
        public GastoadicionalWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Gastoadicional_";
        }



        public override string ContentJsonItem(GastoadicionalBindingModel item)
        {
            return JsonSerializer.Serialize<GastoadicionalBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<GastoadicionalParam >>(new SearchListBindingModel<GastoadicionalParam>((GastoadicionalParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<GastoadicionalParam >>(new SelectParamBindingModel<GastoadicionalParam>((GastoadicionalParam)param, search, fieldsSearching));
        }






  }

}



