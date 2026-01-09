
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

    public class GrupodiferenciainventarioWebController : BaseWebController<GrupodiferenciainventarioBindingModel, GrupodiferenciainventarioParam>
    {
        
        public GrupodiferenciainventarioWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Grupodiferenciainventario_";
        }



        public override string ContentJsonItem(GrupodiferenciainventarioBindingModel item)
        {
            return JsonSerializer.Serialize<GrupodiferenciainventarioBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<GrupodiferenciainventarioParam >>(new SearchListBindingModel<GrupodiferenciainventarioParam>((GrupodiferenciainventarioParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<GrupodiferenciainventarioParam >>(new SelectParamBindingModel<GrupodiferenciainventarioParam>((GrupodiferenciainventarioParam)param, search, fieldsSearching));
        }






  }

}



