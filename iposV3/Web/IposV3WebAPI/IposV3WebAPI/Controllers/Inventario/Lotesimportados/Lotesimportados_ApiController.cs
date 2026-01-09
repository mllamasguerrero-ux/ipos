
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

    public class Lotesimportados_Controller : Base_Controller<LotesimportadosController, LotesimportadosBindingModel, LotesimportadosParam>
    {


        public Lotesimportados_Controller(
            LotesimportadosController logicController) : base(logicController)
        {
        }
    




    
        [HttpPost("[action]")]
        public async Task<IActionResult> AddOrReturn([FromBody] LotesimportadosBindingModel item)
        {
            try
            {
                return Ok(_logicController.AddOrReturn(item));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



  }

}



