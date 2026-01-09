
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

    public class Sat_tipopermisoWebController : BaseWebController<Sat_tipopermisoBindingModel, Sat_tipopermisoParam>
    {
        
        public Sat_tipopermisoWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Sat_tipopermiso_";
        }



        public override string ContentJsonItem(Sat_tipopermisoBindingModel item)
        {
            return JsonSerializer.Serialize<Sat_tipopermisoBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<Sat_tipopermisoParam >>(new SearchListBindingModel<Sat_tipopermisoParam>((Sat_tipopermisoParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<Sat_tipopermisoParam >>(new SelectParamBindingModel<Sat_tipopermisoParam>((Sat_tipopermisoParam)param, search, fieldsSearching));
        }






  }

}



