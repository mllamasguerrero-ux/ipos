
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

    public class Docto_Controller : Base_Controller<DoctoController, DoctoBindingModel, DoctoParam>
    {


        public Docto_Controller(
            DoctoController logicController) : base(logicController)
        {
        }




        [HttpPost("[action]")]
        public async Task<IActionResult> Get_BasicDocto([FromBody] DoctoBindingModel itemSelect)
        {
            try
            {
                return Ok(_logicController.Get_BasicDocto(itemSelect));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



  }

}



