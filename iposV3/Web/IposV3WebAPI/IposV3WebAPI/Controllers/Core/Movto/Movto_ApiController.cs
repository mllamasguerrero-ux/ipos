
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

    public class Movto_Controller : Base_Controller<MovtoController, MovtoBindingModel, MovtoParam>
    {


        public Movto_Controller(
            MovtoController logicController) : base(logicController)
        {
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> DecipherCommand([FromBody] Movto_DecipherCommand_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.DecipherCommand(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.CommandText));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



  }

}



