
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

    public class Producto_Controller : Base_Controller<ProductoController, ProductoBindingModel, ProductoParam>
    {


        public Producto_Controller(
            ProductoController logicController) : base(logicController)
        {
        }
    




    
        [HttpPost("[action]")]
        public async Task<IActionResult> ObtenerProd_def_Caracterisiticas([FromBody] Prod_def_caracteristicasBindingModel obj)
        {
            try
            {
                return Ok(_logicController.ObtenerProd_def_Caracterisiticas(obj));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> GuardarProd_def_caracteristicas([FromBody] Prod_def_caracteristicasBindingModel item)
        {
            try
            {
                return Ok(_logicController.GuardarProd_def_caracteristicas(item));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> SelectForSimpleList([FromBody] Producto_SelectForSimpleList_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.SelectForSimpleList(apiParam.Param, apiParam.KendoParams));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



  }

}



