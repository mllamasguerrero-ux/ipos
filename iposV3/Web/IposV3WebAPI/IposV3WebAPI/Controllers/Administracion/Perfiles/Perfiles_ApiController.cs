
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

    public class Perfiles_Controller : Base_Controller<PerfilesController, PerfilesBindingModel, PerfilesParam>
    {


        public Perfiles_Controller(
            PerfilesController logicController) : base(logicController)
        {
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> GetPerfilesDerechos([FromBody] Perfiles_GetPerfilesDerechos_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.GetPerfilesDerechos(apiParam.ItemSelect, apiParam.KendoParams));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> UpdatePerfilesDerechos([FromBody] Perfiles_UpdatePerfilesDerechos_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.UpdatePerfilesDerechos(apiParam.ItemSelect, apiParam.Perfiles_derechos));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



  }

}



