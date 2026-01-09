
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

    public class Sat_usocfdiWebController : BaseWebController<Sat_usocfdiBindingModel, Sat_usocfdiParam>
    {
        
        public Sat_usocfdiWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Sat_usocfdi_";
        }



        public override string ContentJsonItem(Sat_usocfdiBindingModel item)
        {
            return JsonSerializer.Serialize<Sat_usocfdiBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<Sat_usocfdiParam >>(new SearchListBindingModel<Sat_usocfdiParam>((Sat_usocfdiParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<Sat_usocfdiParam >>(new SelectParamBindingModel<Sat_usocfdiParam>((Sat_usocfdiParam)param, search, fieldsSearching));
        }






  }

}



