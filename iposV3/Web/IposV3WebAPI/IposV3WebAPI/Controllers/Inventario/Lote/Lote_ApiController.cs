
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

    public class Lote_Controller : BaseGeneric_Controller<LoteController>
    {
        
        public Lote_Controller(
            LoteController logicController) : base(logicController)
        {
        }






        [HttpPost("[action]")]
        public async Task<IActionResult> MovtoLoteSeleccion([FromBody] Lote_MovtoLoteSeleccion_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.MovtoLoteSeleccion(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.ProductoId!.Value, apiParam.AlmacenId!.Value, apiParam.DoctoId!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> MovtoLoteImportadoSeleccion([FromBody] Lote_MovtoLoteImportadoSeleccion_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.MovtoLoteImportadoSeleccion(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.ProductoId!.Value, apiParam.AlmacenId!.Value, apiParam.DoctoId!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



  }

}



