
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

    public class Sat_productoservicioWebController : BaseWebController<Sat_productoservicioBindingModel, Sat_productoservicioParam>
    {
        
        public Sat_productoservicioWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Sat_productoservicio_";
        }



        public override string ContentJsonItem(Sat_productoservicioBindingModel item)
        {
            return JsonSerializer.Serialize<Sat_productoservicioBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<Sat_productoservicioParam >>(new SearchListBindingModel<Sat_productoservicioParam>((Sat_productoservicioParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<Sat_productoservicioParam >>(new SelectParamBindingModel<Sat_productoservicioParam>((Sat_productoservicioParam)param, search, fieldsSearching));
        }






  }

}



