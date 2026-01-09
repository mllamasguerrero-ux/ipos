
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

    public class Inventario_Controller : BaseGeneric_Controller<InventarioController>
    {
        
        public Inventario_Controller(
            InventarioController logicController) : base(logicController)
        {
        }






    
        [HttpPost("[action]")]
        public async Task<IActionResult> Verify_existence([FromBody] Fnc_verify_existenceParam param)
        {
            try
            {
                return Ok(_logicController.Verify_existence(param));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> V_inventario_doctoList([FromBody] V_inventario_doctoParamBindingModel itemParam)
        {
            try
            {
                return Ok(_logicController.V_inventario_doctoList(itemParam));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> V_inventario_movto_detallesList([FromBody] V_inventario_movto_detalleParamBindingModel itemParam)
        {
            try
            {
                return Ok(_logicController.V_inventario_movto_detallesList(itemParam));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> V_inventario_movto_detalles_x_locList([FromBody] V_inventario_movto_detalleParamBindingModel itemParam)
        {
            try
            {
                return Ok(_logicController.V_inventario_movto_detalles_x_locList(itemParam));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> V_inventario_movto_detalles_x_loc_groupedList([FromBody] V_inventario_movto_detalleParamBindingModel itemParam)
        {
            try
            {
                return Ok(_logicController.V_inventario_movto_detalles_x_loc_groupedList(itemParam));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> V_inventario_movto_getInfo([FromBody] V_inventario_movto_getInfoParamWFBindingModel param)
        {
            try
            {
                return Ok(_logicController.V_inventario_movto_getInfo(param));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> Docto_inventario_genCompleto([FromBody] V_inventario_genComplParamWFBindingModel param)
        {
            try
            {
                return Ok(_logicController.Docto_inventario_genCompleto(param));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> Docto_inventario_finEdicion([FromBody] V_inventario_finedicionParamWFBindingModel param)
        {
            try
            {
                return Ok(_logicController.Docto_inventario_finEdicion(param));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> Docto_inventario_aplicar([FromBody] V_inventario_aplicarParamWFBindingModel param)
        {
            try
            {
                return Ok(_logicController.Docto_inventario_aplicar(param));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> Movto_inventario_insert([FromBody] MovtoInventarioTrans movtoTrans)
        {
            try
            {
                return Ok(_logicController.Movto_inventario_insert(movtoTrans));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> Inventario_movto_loteInfo([FromBody] Inventario_Inventario_movto_loteInfo_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Inventario_movto_loteInfo(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.ProductoId!.Value, apiParam.DoctoId!.Value, apiParam.Soloconexistencias!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        //DONE2 MLG 2025 Migracion web out
        [HttpPost("[action]")]
        public async Task<IActionResult> Docto_inventario_insert([FromBody] Inventario_Docto_inventario_insert_ApiParam apiParam)
        {
            var resultBM = new BaseResultBindingModel();
            resultBM.Usermessage = "";
            resultBM.Devmessage = "";
            resultBM.Result = 0L;

            try
            {

                long? doctoId = null;
                _logicController.Docto_inventario_insert(apiParam.DoctoTrans, ref doctoId);
                resultBM.Result = doctoId;
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
        public async Task<IActionResult> Docto_inventario_delete([FromBody] Inventario_Docto_inventario_delete_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Docto_inventario_delete(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.Id!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> Docto_inventario_cambiarkitdesglosado([FromBody] Inventario_Docto_inventario_cambiarkitdesglosado_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Docto_inventario_cambiarkitdesglosado(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.DoctoId!.Value, apiParam.KitDesglosado!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



  }

}



