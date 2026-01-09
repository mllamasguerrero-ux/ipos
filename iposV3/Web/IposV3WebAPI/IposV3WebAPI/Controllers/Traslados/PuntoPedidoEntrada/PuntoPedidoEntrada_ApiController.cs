
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

    public class PuntoPedidoEntrada_Controller : BaseGeneric_Controller<PuntoPedidoEntradaController>
    {
        
        public PuntoPedidoEntrada_Controller(
            PuntoPedidoEntradaController logicController) : base(logicController)
        {
        }






    
        [HttpPost("[action]")]
        public async Task<IActionResult> Select_docto_pedido_entrada_List([FromBody] Docto_ped_entr_lstParamWFBindingModel param)
        {
            try
            {
                return Ok(_logicController.Select_docto_pedido_entrada_List(param));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> Select_movto_pedido_entrada_List([FromBody] Movto_ped_entr_lstParamWFBindingModel param)
        {
            try
            {
                return Ok(_logicController.Select_movto_pedido_entrada_List(param));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> Docto_pedido_entrada_insert([FromBody] DoctoPedidoEntradaTrans doctoProvTrans)
        {
            try
            {
                return Ok(_logicController.Docto_pedido_entrada_insert(doctoProvTrans));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> Movto_pedido_entrada_insert([FromBody] MovtoPedidoEntradaTrans movtoProvTrans)
        {
            try
            {
                return Ok(_logicController.Movto_pedido_entrada_insert(movtoProvTrans));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> Movto_pedido_entrada_ponercantidadsurtida([FromBody] MovtoPedidoEntradaTrans movtoProvTrans)
        {
            try
            {
                return Ok(_logicController.Movto_pedido_entrada_ponercantidadsurtida(movtoProvTrans));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        [HttpPost("[action]")]
        public async Task<IActionResult> Docto_pedido_entrada_save([FromBody] PuntoPedidoEntrada_Docto_pedido_entrada_save_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Docto_pedido_entrada_save(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.Id!.Value, apiParam.EstatusDoctoId!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> Movto_pedido_entrada_ajustarExistencias([FromBody] PuntoPedidoEntrada_Movto_pedido_entrada_ajustarExistencias_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Movto_pedido_entrada_ajustarExistencias(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.Id!.Value, apiParam.UsuarioId!.Value, apiParam.AlmacenId!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        //DONE2 MLG 2025 Migracion web out
        [HttpPost("[action]")]
        public async Task<IActionResult> Docto_surtir_pedido([FromBody] PuntoPedidoEntrada_Docto_surtir_pedido_ApiParam apiParam)
        {
            var resultBM = new BaseResultBindingModel();
            resultBM.Usermessage = "";
            resultBM.Devmessage = "";
            resultBM.Result = 0L;

            try
            {
                long? doctoSurtidoId = null;
                _logicController.Docto_surtir_pedido(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.Id!.Value, apiParam.UsuarioId!.Value, apiParam.AlmacenId!.Value, apiParam.Referencias, ref doctoSurtidoId);
                resultBM.Result = doctoSurtidoId;
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
        public async Task<IActionResult> Docto_update_datos_ajustables([FromBody] PuntoPedidoEntrada_Docto_update_datos_ajustables_ApiParam apiParam)
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



