
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

    public class Motivo_devolucionWebController : BaseWebController<Motivo_devolucionBindingModel, Motivo_devolucionParam>
    {
        
        public Motivo_devolucionWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Motivo_devolucion_";
        }



        public override string ContentJsonItem(Motivo_devolucionBindingModel item)
        {
            return JsonSerializer.Serialize<Motivo_devolucionBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<Motivo_devolucionParam >>(new SearchListBindingModel<Motivo_devolucionParam>((Motivo_devolucionParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<Motivo_devolucionParam >>(new SelectParamBindingModel<Motivo_devolucionParam>((Motivo_devolucionParam)param, search, fieldsSearching));
        }






  }

}



