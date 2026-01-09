
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

    public class Kitdefinicion_Controller : Base_Controller<KitdefinicionController, KitdefinicionBindingModel, KitdefinicionParam>
    {


        public Kitdefinicion_Controller(
            KitdefinicionController logicController) : base(logicController)
        {
        }





        //DONE2 MLG 2025 Migracion web out
        [HttpPost("[action]")]
        public async Task<IActionResult> InsertYModificarImpuestosSiAplica([FromBody] Kitdefinicion_InsertYModificarImpuestosSiAplica_ApiParam apiParam)
        {


            ImpuestoKitDefinicion resultBM = null;

            try
            {
                _logicController.InsertYModificarImpuestosSiAplica(apiParam.Item, out resultBM);
                return Ok(resultBM);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }





        //DONE2 MLG 2025 Migracion web out
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateYModificarImpuestosSiAplica([FromBody] Kitdefinicion_UpdateYModificarImpuestosSiAplica_ApiParam apiParam)
        {


            ImpuestoKitDefinicion resultBM = null;

            try
            {
                _logicController.UpdateYModificarImpuestosSiAplica(apiParam.Item, out resultBM);
                return Ok(resultBM);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }





        [HttpPost("[action]")]
        public async Task<IActionResult> CurrentInfoImpuestosKit([FromBody] Kitdefinicion_CurrentInfoImpuestosKit_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.CurrentInfoImpuestosKit(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.ProductoKitId!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        //DONE2 MLG 2025 Migracion web out
        [HttpPost("[action]")]
        public async Task<IActionResult> DeleteYModificarImpuestosSiAplica([FromBody] Kitdefinicion_DeleteYModificarImpuestosSiAplica_ApiParam apiParam)
        {


            ImpuestoKitDefinicion resultBM = null;

            try
            {
                _logicController.DeleteYModificarImpuestosSiAplica(apiParam.Item, out resultBM);
                return Ok(resultBM);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }





    }

}



