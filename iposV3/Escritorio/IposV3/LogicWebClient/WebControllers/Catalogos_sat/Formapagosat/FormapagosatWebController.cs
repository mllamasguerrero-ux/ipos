
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

    public class FormapagosatWebController : BaseWebController<FormapagosatBindingModel, FormapagosatParam>
    {
        
        public FormapagosatWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Formapagosat_";
        }



        public override string ContentJsonItem(FormapagosatBindingModel item)
        {
            return JsonSerializer.Serialize<FormapagosatBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<FormapagosatParam >>(new SearchListBindingModel<FormapagosatParam>((FormapagosatParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<FormapagosatParam >>(new SelectParamBindingModel<FormapagosatParam>((FormapagosatParam)param, search, fieldsSearching));
        }






  }

}



