
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
using IposV3.Controllers.Controller;
using IposV3.BindingModel;

#pragma warning disable 1998
namespace IposV3WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class Global_Controller : BaseGeneric_Controller<GlobalController>
    {


        public Global_Controller(
            GlobalController logicController) : base(logicController)
        {
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> llenarSesionPorConfiguracion([FromBody] Configuracion config)
        {

            GlobalSession bufferSession = new GlobalSession();

            try
            {

                _logicController.llenarSesionPorConfiguracion(config, null, ref bufferSession);

                return Ok(bufferSession);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + " ---- " + ex.StackTrace);
            }

        }

        [HttpPost("[action]")]
        public async Task<ActionResult> llenarSesionUsuario([FromBody] ConfiguracionBindingModel config)
        {

            GlobalSession bufferSession = new GlobalSession();

            try
            {

                _logicController.llenarSesionUsuario(config, ref bufferSession);

                return Ok(bufferSession);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost("[action]")]
        public async Task<ActionResult> llenarSesionPorConfiguracionsync([FromBody] Configuracionsync configsync)
        {
            GlobalSession bufferSession = new GlobalSession();

            try
            {

                _logicController.llenarSesionPorConfiguracionsync(configsync,  ref bufferSession);

                return Ok(bufferSession);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> llenarProductAutoCompleteList([FromBody] BaseParam param)
        {

            GlobalSession bufferSession = new GlobalSession();

            try
            {

                _logicController.llenarProductAutoCompleteList(param, ref bufferSession);

                return Ok(bufferSession);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> llenarClienteAutoCompleteList([FromBody] BaseParam param)
        {

            GlobalSession bufferSession = new GlobalSession();

            try
            {

                _logicController.llenarClienteAutoCompleteList(param, ref bufferSession);

                return Ok(bufferSession);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

}



