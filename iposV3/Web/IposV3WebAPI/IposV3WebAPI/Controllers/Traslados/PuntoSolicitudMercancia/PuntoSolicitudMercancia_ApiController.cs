
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
using IposV3.Services;

#pragma warning disable 1998
namespace IposV3WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PuntoSolicitudMercancia_Controller : BaseGeneric_Controller<PuntoSolicitudMercanciaController>
    {
        
        public PuntoSolicitudMercancia_Controller(
            PuntoSolicitudMercanciaController logicController) : base(logicController)
        {
        }






    
        [HttpPost("[action]")]
        public async Task<IActionResult> Select_docto_traslado_rec_List([FromBody] Docto_solic_merc_lstParamWFBindingModel param)
        {
            try
            {
                return Ok(_logicController.Select_docto_traslado_rec_List(param));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> Select_movto_solicitud_mercancia_List([FromBody] Movto_solic_merc_lstParamWFBindingModel param)
        {
            try
            {
                return Ok(_logicController.Select_movto_solicitud_mercancia_List(param));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> Docto_solicitud_mercancia_insert([FromBody] DoctoSolicitudMercanciaTrans doctoProvTrans)
        {
            try
            {
                return Ok(_logicController.Docto_solicitud_mercancia_insert(doctoProvTrans));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> Movto_solicitud_mercancia_insert([FromBody] MovtoSolicitudMercanciaTrans movtoProvTrans)
        {
            try
            {
                return Ok(_logicController.Movto_solicitud_mercancia_insert(movtoProvTrans));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> Docto_solicitud_mercancia_save([FromBody] PuntoSolicitudMercancia_Docto_solicitud_mercancia_save_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Docto_solicitud_mercancia_save(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.Id!.Value, apiParam.EstatusDoctoId!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



  }

}



