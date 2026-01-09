
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

    public class Corte_Controller : Base_Controller<CorteController, CorteBindingModel, CorteParam>
    {


        public Corte_Controller(
            CorteController logicController) : base(logicController)
        {
        }
    




    
        [HttpPost("[action]")]
        public async Task<IActionResult> AbrirCorte([FromBody] CorteBindingModel item)
        {
            try
            {
                return Ok(_logicController.AbrirCorte(item));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> ReabrirCorte([FromBody] CorteBindingModel item)
        {
            try
            {
                return Ok(_logicController.ReabrirCorte(item));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> AbrirNuevoCorte([FromBody] CorteBindingModel item)
        {
            try
            {
                return Ok(_logicController.AbrirNuevoCorte(item));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> CerrarCorte([FromBody] CorteBindingModel item)
        {
            try
            {
                return Ok(_logicController.CerrarCorte(item));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> CorteActivoUsuario([FromBody] Corte_CorteActivoUsuario_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.CorteActivoUsuario(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.UsuarioId!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> CorteUsuarioFecha([FromBody] Corte_CorteUsuarioFecha_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.CorteUsuarioFecha(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.UsuarioId!.Value, apiParam.Fecha!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



  }

}



