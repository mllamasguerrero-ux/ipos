
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

    public class GrupousuarioWebController : BaseWebController<GrupousuarioBindingModel, GrupousuarioParam>
    {
        
        public GrupousuarioWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Grupousuario_";
        }



        public override string ContentJsonItem(GrupousuarioBindingModel item)
        {
            return JsonSerializer.Serialize<GrupousuarioBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<GrupousuarioParam >>(new SearchListBindingModel<GrupousuarioParam>((GrupousuarioParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<GrupousuarioParam >>(new SelectParamBindingModel<GrupousuarioParam>((GrupousuarioParam)param, search, fieldsSearching));
        }






  }

}



