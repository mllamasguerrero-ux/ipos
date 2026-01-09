
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

    public class CuentaWebController : BaseWebController<CuentaBindingModel, CuentaParam>
    {
        
        public CuentaWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Cuenta_";
        }



        public override string ContentJsonItem(CuentaBindingModel item)
        {
            return JsonSerializer.Serialize<CuentaBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<CuentaParam >>(new SearchListBindingModel<CuentaParam>((CuentaParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<CuentaParam >>(new SelectParamBindingModel<CuentaParam>((CuentaParam)param, search, fieldsSearching));
        }






  }

}



