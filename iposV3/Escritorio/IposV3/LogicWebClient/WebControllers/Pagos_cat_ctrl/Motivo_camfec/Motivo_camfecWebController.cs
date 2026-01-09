
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

    public class Motivo_camfecWebController : BaseWebController<Motivo_camfecBindingModel, Motivo_camfecParam>
    {
        
        public Motivo_camfecWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Motivo_camfec_";
        }



        public override string ContentJsonItem(Motivo_camfecBindingModel item)
        {
            return JsonSerializer.Serialize<Motivo_camfecBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<Motivo_camfecParam >>(new SearchListBindingModel<Motivo_camfecParam>((Motivo_camfecParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<Motivo_camfecParam >>(new SelectParamBindingModel<Motivo_camfecParam>((Motivo_camfecParam)param, search, fieldsSearching));
        }






  }

}



