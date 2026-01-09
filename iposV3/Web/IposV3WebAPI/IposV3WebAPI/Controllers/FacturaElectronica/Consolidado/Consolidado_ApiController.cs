
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

    public class Consolidado_Controller : BaseGeneric_Controller<ConsolidadoController>
    {
        
        public Consolidado_Controller(
            ConsolidadoController logicController) : base(logicController)
        {
        }






    
        [HttpPost("[action]")]
        public async Task<IActionResult> ConsolidadoInfo([FromBody] Tmp_config_porconsolidarWFBindingModel config)
        {
            try
            {
                return Ok(_logicController.ConsolidadoInfo(config));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> Consolidar([FromBody] Tmp_config_porconsolidarWFBindingModel config)
        {
            try
            {
                return Ok(_logicController.Consolidar(config));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> TestGeneral2([FromBody] Int64 usuarioId)
        {
            try
            {
                _logicController.TestGeneral2(usuarioId);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



  }

}



