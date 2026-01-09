
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

    public class Sat_unidadmedidaWebController : BaseWebController<Sat_unidadmedidaBindingModel, Sat_unidadmedidaParam>
    {
        
        public Sat_unidadmedidaWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Sat_unidadmedida_";
        }



        public override string ContentJsonItem(Sat_unidadmedidaBindingModel item)
        {
            return JsonSerializer.Serialize<Sat_unidadmedidaBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<Sat_unidadmedidaParam >>(new SearchListBindingModel<Sat_unidadmedidaParam>((Sat_unidadmedidaParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<Sat_unidadmedidaParam >>(new SelectParamBindingModel<Sat_unidadmedidaParam>((Sat_unidadmedidaParam)param, search, fieldsSearching));
        }






  }

}



