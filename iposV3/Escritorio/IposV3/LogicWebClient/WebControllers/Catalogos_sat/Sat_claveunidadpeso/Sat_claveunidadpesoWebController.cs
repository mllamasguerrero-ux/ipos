
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

    public class Sat_claveunidadpesoWebController : BaseWebController<Sat_claveunidadpesoBindingModel, Sat_claveunidadpesoParam>
    {
        
        public Sat_claveunidadpesoWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Sat_claveunidadpeso_";
        }



        public override string ContentJsonItem(Sat_claveunidadpesoBindingModel item)
        {
            return JsonSerializer.Serialize<Sat_claveunidadpesoBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<Sat_claveunidadpesoParam >>(new SearchListBindingModel<Sat_claveunidadpesoParam>((Sat_claveunidadpesoParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<Sat_claveunidadpesoParam >>(new SelectParamBindingModel<Sat_claveunidadpesoParam>((Sat_claveunidadpesoParam)param, search, fieldsSearching));
        }






  }

}



