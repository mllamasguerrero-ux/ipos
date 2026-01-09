
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
using IposV3.Services.FacturaElectronica;

#pragma warning disable 1998
namespace IposV3WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class Cfdi_Controller : BaseGeneric_Controller<CfdiController>
    {
        
        public Cfdi_Controller(
            CfdiController logicController) : base(logicController)
        {
        }






    
        [HttpPost("[action]")]
        public async Task<IActionResult> obtainPrefixByTipoComprobante([FromBody] string tipoComprobante)
        {
            try
            {
                return Ok(CfdiController.obtainPrefixByTipoComprobante(tipoComprobante));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost("[action]")]
        public async Task<IActionResult> Factura_Electronica_Preparar([FromBody] Cfdi_ApiParam apiParam)
        {

            var resultBM = new BaseResultBindingModel();
            resultBM.Usermessage = "";
            resultBM.Devmessage = "";
            resultBM.Result = 0L;

            try
            {
                string? resultMessage = null;
                bool bSuccess = _logicController.Factura_Electronica_Preparar(apiParam.TimbradoInfo, out resultMessage);
                resultBM.Usermessage = resultMessage;
                if (!bSuccess)
                {
                    resultBM.Result = -1L;
                }
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
        public async Task<IActionResult> ObtenDatosParaFacturar([FromBody] Cfdi_ApiParam apiParam)
        {


            var virtualXMLHelperModel = new VirtualXmlHelperModel();

            try
            {
                string? resultMessage = null;
                bool bSuccess = _logicController.ObtenDatosParaFacturar(apiParam.TimbradoInfo, out virtualXMLHelperModel, out resultMessage);
                if (bSuccess)
                {
                    return Ok(virtualXMLHelperModel);
                }
                else
                {
                    return BadRequest(resultMessage);
                }
                
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }




        [HttpPost("[action]")]
        public async Task<IActionResult> Facturacion_GuardarDatosTimbrado([FromBody] Cfdi_ApiParam apiParam)
        {

            var resultBM = new BaseResultBindingModel();
            resultBM.Usermessage = "";
            resultBM.Devmessage = "";
            resultBM.Result = 0L;

            try
            {
                string? resultMessage = null;
                bool bSuccess = _logicController.Facturacion_GuardarDatosTimbrado(apiParam.TimbradoInfo, out resultMessage);
                resultBM.Usermessage = resultMessage;
                if (!bSuccess)
                {
                    resultBM.Result = -1L;
                }
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
        public async Task<IActionResult> Facturacion_DeshacerPreparacion([FromBody] Cfdi_ApiParam apiParam)
        {

            var resultBM = new BaseResultBindingModel();
            resultBM.Usermessage = "";
            resultBM.Devmessage = "";
            resultBM.Result = 0L;

            try
            {
                string? resultMessage = null;
                bool bSuccess = _logicController.Facturacion_DeshacerPreparacion(apiParam.TimbradoInfo, out resultMessage);
                resultBM.Usermessage = resultMessage;
                if (!bSuccess)
                {
                    resultBM.Result = -1L;
                }
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



