
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

    public class CajaWebController : BaseWebController<CajaBindingModel, CajaParam>
    {
        
        public CajaWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Caja_";
        }



        public override string ContentJsonItem(CajaBindingModel item)
        {
            return JsonSerializer.Serialize<CajaBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<CajaParam >>(new SearchListBindingModel<CajaParam>((CajaParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<CajaParam >>(new SelectParamBindingModel<CajaParam>((CajaParam)param, search, fieldsSearching));
        }






  }

}



