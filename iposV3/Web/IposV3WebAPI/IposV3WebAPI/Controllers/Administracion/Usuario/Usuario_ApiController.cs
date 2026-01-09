
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

    public class Usuario_Controller : Base_Controller<UsuarioController, UsuarioBindingModel, UsuarioParam>
    {


        public Usuario_Controller(
            UsuarioController logicController) : base(logicController)
        {
        }
    




    
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateContrasena([FromBody] CambiocontrasenaWFBindingModel item)
        {
            try
            {
                return Ok(_logicController.UpdateContrasena(item));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> ValidateLogin([FromBody] WFLoginParamBindingModel param)
        {
            try
            {
                return Ok(_logicController.ValidateLogin(param));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> GetUsuariosPerfiles([FromBody] Usuario_GetUsuariosPerfiles_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.GetUsuariosPerfiles(apiParam.ItemSelect, apiParam.KendoParams));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateUsuariosPerfiles([FromBody] Usuario_UpdateUsuariosPerfiles_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.UpdateUsuariosPerfiles(apiParam.ItemSelect, apiParam.Usuarios_perfiles));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> Obtain_usuarios_derechos_List([FromBody] Usuario_Obtain_usuarios_derechos_List_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Obtain_usuarios_derechos_List(apiParam.Empresaid!.Value, apiParam.Sucursalid!.Value, apiParam.Derechos, apiParam.UsuarioId!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



  }

}



