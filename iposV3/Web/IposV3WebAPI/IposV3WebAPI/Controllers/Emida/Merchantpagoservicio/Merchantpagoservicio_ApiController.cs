
using BindingModels;
using Controllers.Controller;
using IposV3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using ApiParam;

#pragma warning disable 1998
namespace IposV3WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class Merchantpagoservicio_Controller : Base_Controller<MerchantpagoservicioController, MerchantpagoservicioBindingModel, MerchantpagoservicioParam>
    {


        public Merchantpagoservicio_Controller(
            MerchantpagoservicioController logicController) : base(logicController)
        {
        }
    




  }

}



