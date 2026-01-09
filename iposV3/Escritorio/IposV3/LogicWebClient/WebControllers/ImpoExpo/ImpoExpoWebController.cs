
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

    public class ImpoExpoWebController : BaseGenericWebController
    {

        public ImpoExpoWebController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            pathController = "PuntoCompra_";
        }


        //TODO MLG 2025 Migracion web
        public async Task<bool> ExportTraslado(long empresaid, long sucursalid, string sucursalFuenteClave, string empresaClave, long doctoId, long? syncExpoId)
        {
            throw new NotImplementedException();
        }






    }

}



