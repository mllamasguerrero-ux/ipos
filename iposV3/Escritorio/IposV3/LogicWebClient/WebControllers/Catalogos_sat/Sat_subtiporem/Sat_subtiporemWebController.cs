
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

    public class Sat_subtiporemWebController : BaseWebController<Sat_subtiporemBindingModel, Sat_subtiporemParam>
    {
        
        public Sat_subtiporemWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Sat_subtiporem_";
        }



        public override string ContentJsonItem(Sat_subtiporemBindingModel item)
        {
            return JsonSerializer.Serialize<Sat_subtiporemBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<Sat_subtiporemParam >>(new SearchListBindingModel<Sat_subtiporemParam>((Sat_subtiporemParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<Sat_subtiporemParam >>(new SelectParamBindingModel<Sat_subtiporemParam>((Sat_subtiporemParam)param, search, fieldsSearching));
        }






  }

}



