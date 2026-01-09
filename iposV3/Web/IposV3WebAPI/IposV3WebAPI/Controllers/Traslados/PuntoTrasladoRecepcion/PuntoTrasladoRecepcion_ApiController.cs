
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

    public class PuntoTrasladoRecepcion_Controller : BaseGeneric_Controller<PuntoTrasladoRecepcionController>
    {
        
        public PuntoTrasladoRecepcion_Controller(
            PuntoTrasladoRecepcionController logicController) : base(logicController)
        {
        }






    
        [HttpPost("[action]")]
        public async Task<IActionResult> Select_docto_traslado_rec_List([FromBody] Docto_traslado_rec_lstParamWFBindingModel param)
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
        public async Task<IActionResult> Select_movto_traslado_rec_List([FromBody] Movto_traslado_rec_lstParamWFBindingModel param)
        {
            try
            {
                return Ok(_logicController.Select_movto_traslado_rec_List(param));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        //DONE2 MLG 2025 Migracion web out
        [HttpPost("[action]")]
        public async Task<IActionResult> Recibir_traslado([FromBody] PuntoTrasladoRecepcion_Recibir_traslado_ApiParam apiParam)
        {
            var resultBM = new BaseResultBindingModel();
            resultBM.Usermessage = "";
            resultBM.Devmessage = "";
            resultBM.Result = 0L;

            try
            {
                long? doctoDevolucionId = null;
                _logicController.Recibir_traslado(apiParam.Param, apiParam.MovtosARecibir, ref doctoDevolucionId);
                resultBM.Result = doctoDevolucionId;
                return Ok(resultBM);
            }
            catch (Exception ex)
            {
                resultBM.Usermessage = ex.Message;
                resultBM.Devmessage = ex.Message;
                resultBM.Result = -1L;
                return Ok(resultBM);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> Docto_update_datos_ajustables([FromBody] PuntoTrasladoRecepcion_Docto_update_datos_ajustables_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Docto_update_datos_ajustables(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.Id!.Value, apiParam.UsuarioId!.Value, apiParam.AlmacenId!.Value, apiParam.Referencias));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



  }

}



