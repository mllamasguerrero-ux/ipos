
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

    public class TerminalpagoservicioWebController : BaseWebController<TerminalpagoservicioBindingModel, TerminalpagoservicioParam>
    {
        
        public TerminalpagoservicioWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Terminalpagoservicio_";
        }



        public override string ContentJsonItem(TerminalpagoservicioBindingModel item)
        {
            return JsonSerializer.Serialize<TerminalpagoservicioBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<TerminalpagoservicioParam >>(new SearchListBindingModel<TerminalpagoservicioParam>((TerminalpagoservicioParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<TerminalpagoservicioParam >>(new SelectParamBindingModel<TerminalpagoservicioParam>((TerminalpagoservicioParam)param, search, fieldsSearching));
        }






  }

}



