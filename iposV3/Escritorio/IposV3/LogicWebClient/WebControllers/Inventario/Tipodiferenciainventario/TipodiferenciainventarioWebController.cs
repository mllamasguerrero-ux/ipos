
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

    public class TipodiferenciainventarioWebController : BaseWebController<TipodiferenciainventarioBindingModel, TipodiferenciainventarioParam>
    {
        
        public TipodiferenciainventarioWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Tipodiferenciainventario_";
        }



        public override string ContentJsonItem(TipodiferenciainventarioBindingModel item)
        {
            return JsonSerializer.Serialize<TipodiferenciainventarioBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<TipodiferenciainventarioParam >>(new SearchListBindingModel<TipodiferenciainventarioParam>((TipodiferenciainventarioParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<TipodiferenciainventarioParam >>(new SelectParamBindingModel<TipodiferenciainventarioParam>((TipodiferenciainventarioParam)param, search, fieldsSearching));
        }






  }

}



