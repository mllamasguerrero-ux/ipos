
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

    public class CuentabancoWebController : BaseWebController<CuentabancoBindingModel, CuentabancoParam>
    {
        
        public CuentabancoWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Cuentabanco_";
        }



        public override string ContentJsonItem(CuentabancoBindingModel item)
        {
            return JsonSerializer.Serialize<CuentabancoBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<CuentabancoParam >>(new SearchListBindingModel<CuentabancoParam>((CuentabancoParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<CuentabancoParam >>(new SelectParamBindingModel<CuentabancoParam>((CuentabancoParam)param, search, fieldsSearching));
        }






  }

}



