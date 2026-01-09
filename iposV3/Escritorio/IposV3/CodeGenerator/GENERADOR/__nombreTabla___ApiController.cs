|||||100+++++
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
|||||110+++++
    public class (nombreTabla)_Controller : Base_Controller<(nombreTabla)Controller, (nombreTabla)BindingModel, (nombreTabla)Param>
    {


        public (nombreTabla)_Controller(
            (nombreTabla)Controller logicController) : base(logicController)
        {
        }
    
|||||120+++++
    public class (nombreTabla)_Controller : BaseGeneric_Controller<(nombreTabla)Controller>
    {
        
        public (nombreTabla)_Controller(
            (nombreTabla)Controller logicController) : base(logicController)
        {
        }


|||||200+++++



    
        [HttpPost("[action]")]
        public async Task<IActionResult> (nombreCampo)([FromBody] (catalogoselectobjectname) (catalogoselectfieldtname))
        {
            try
            {
                return Ok(_logicController.(nombreCampo)((catalogoselectfieldtname)));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    |||||210+++++



        [HttpPost("[action]")]
        public async Task<IActionResult> (nombreCampo)([FromBody] (nombreTabla)_(nombreCampo)_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.(nombreCampo)((SUBENTIDADCAMPO)));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    |||||300+++++



  }

}



!!!!!
100;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR
110;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;NO;IGNORAR;IGNORAR
120;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;SI;IGNORAR;IGNORAR
200;1;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;UNPARAMETRO;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR
210;1;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;VARIOSPARAMETROS;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR
300;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR
