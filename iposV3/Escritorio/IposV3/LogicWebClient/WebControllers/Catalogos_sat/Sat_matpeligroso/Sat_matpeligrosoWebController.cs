
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

    public class Sat_matpeligrosoWebController : BaseWebController<Sat_matpeligrosoBindingModel, Sat_matpeligrosoParam>
    {
        
        public Sat_matpeligrosoWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Sat_matpeligroso_";
        }



        public override string ContentJsonItem(Sat_matpeligrosoBindingModel item)
        {
            return JsonSerializer.Serialize<Sat_matpeligrosoBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<Sat_matpeligrosoParam >>(new SearchListBindingModel<Sat_matpeligrosoParam>((Sat_matpeligrosoParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<Sat_matpeligrosoParam >>(new SelectParamBindingModel<Sat_matpeligrosoParam>((Sat_matpeligrosoParam)param, search, fieldsSearching));
        }






  }

}



