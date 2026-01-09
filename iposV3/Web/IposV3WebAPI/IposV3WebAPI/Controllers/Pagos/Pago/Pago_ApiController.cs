
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

    public class Pago_Controller : Base_Controller<PagoController, PagoBindingModel, PagoParam>
    {


        public Pago_Controller(
            PagoController logicController) : base(logicController)
        {
        }
    




    
        [HttpPost("[action]")]
        public async Task<IActionResult> PagoCompuestoList([FromBody] V_pagos_compuestos_list_selWFBindingModel itemParam)
        {
            try
            {
                return Ok(_logicController.PagoCompuestoList(itemParam));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }






        //DONE2 MLG 2025 Migracion web
        [HttpPost("[action]")]
        public async Task<IActionResult> DoctosConSaldoList([FromBody] Pago_DoctosConSaldoList_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.DoctosConSaldoList(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.Tipodoctoid!.Value, apiParam.ClienteId!.Value, apiParam.ProveedorId!.Value, apiParam.SoloTimbrados!.Value, apiParam.UsuarioId!.Value, apiParam.CorteActivo!.Value, apiParam.Referencia,
                                                              apiParam.FechaFinal, apiParam.FechaFinal, apiParam.EstatusDoctoId));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        //DONE2 MLG 2025 Migracion web
        [HttpPost("[action]")]
        public async Task<IActionResult> DoctoPagosAplicadosList([FromBody] Pago_DoctoPagosAplicadosList_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.DoctoPagosAplicadosList(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.PagoId!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        //DONE2 MLG 2025 Migracion web
        [HttpPost("[action]")]
        public async Task<IActionResult> DoctoPagosList([FromBody] Pago_DoctoPagosList_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.DoctoPagosList(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.DoctoId!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        //DONE2 MLG 2025 Migracion web out
        [HttpPost("[action]")]
        public async Task<IActionResult> PagoCompuestoInsert([FromBody] Pago_PagoCompuestoInsert_ApiParam apiParam)
        {
            var resultBM = new BaseResultBindingModel();
            resultBM.Usermessage = "";
            resultBM.Devmessage = "";
            resultBM.Result = 0L;

            try
            {
                long? pagoId = null;
                _logicController.PagoCompuestoInsert(apiParam.PagoTransaccion, apiParam.DoctoPagoTransacciones, ref pagoId);
                resultBM.Result = pagoId;
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





        //DONE2 MLG 2025 Migracion web out
        [HttpPost("[action]")]
        public async Task<IActionResult> PagoCompuestoRevertir([FromBody] Pago_PagoCompuestoRevertir_ApiParam apiParam)
        {
            var resultBM = new BaseResultBindingModel();
            resultBM.Usermessage = "";
            resultBM.Devmessage = "";
            resultBM.Result = 0L;

            try
            {

                long? pagoId = null;
                _logicController.PagoCompuestoRevertir(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.PagoARevertirId!.Value, apiParam.UsuarioId!.Value, apiParam.CorteId!.Value, apiParam.Notas, ref pagoId);
                resultBM.Result = pagoId;
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





        //DONE2 MLG 2025 Migracion web out
        [HttpPost("[action]")]
        public async Task<IActionResult> GenerarReciboElectronico([FromBody] Pago_GenerarReciboElectronico_ApiParam apiParam)
        {
            var resultBM = new BaseResultBindingModel();
            resultBM.Usermessage = "";
            resultBM.Devmessage = "";
            resultBM.Result = 0L;

            try
            {
                long? reciboElectronicoId = null;
                _logicController.GenerarReciboElectronico(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.PagoId!.Value, apiParam.VendedorId!.Value, ref reciboElectronicoId);
                resultBM.Result = reciboElectronicoId;
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

    }

}



