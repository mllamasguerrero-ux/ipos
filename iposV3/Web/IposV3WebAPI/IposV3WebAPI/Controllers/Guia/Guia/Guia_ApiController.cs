
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

    public class Guia_Controller : Base_Controller<GuiaController, GuiaBindingModel, GuiaParam>
    {


        public Guia_Controller(
            GuiaController logicController) : base(logicController)
        {
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> InsertHeaderAndDetail([FromBody] Guia_InsertHeaderAndDetail_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.InsertHeaderAndDetail(apiParam.Item, apiParam.GuiaDetalle, apiParam.Docto));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



  }

}



