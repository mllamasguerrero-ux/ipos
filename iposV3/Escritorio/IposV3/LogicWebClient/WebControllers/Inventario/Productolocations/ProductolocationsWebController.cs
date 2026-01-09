
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

    public class ProductolocationsWebController : BaseWebController<ProductolocationsBindingModel, ProductolocationsParam>
    {
        
        public ProductolocationsWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "Productolocations_";
        }



        public override string ContentJsonItem(ProductolocationsBindingModel item)
        {
            return JsonSerializer.Serialize<ProductolocationsBindingModel >(item);
        }



        public override string ContentJsonSearchList(object? param, KendoParams? kendoParams)
        {
            return JsonSerializer.Serialize<SearchListBindingModel<ProductolocationsParam >>(new SearchListBindingModel<ProductolocationsParam>((ProductolocationsParam ?)param, kendoParams));
        }

        public override string ContentJsonSelectParamList(object param, string search, string fieldsSearching)
        {
            return JsonSerializer.Serialize<SelectParamBindingModel<ProductolocationsParam >>(new SelectParamBindingModel<ProductolocationsParam>((ProductolocationsParam)param, search, fieldsSearching));
        }






  }

}



