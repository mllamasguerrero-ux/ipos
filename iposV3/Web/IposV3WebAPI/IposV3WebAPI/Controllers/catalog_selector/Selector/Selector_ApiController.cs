
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
using IposV3.Controllers.Controller;

#pragma warning disable 1998
namespace IposV3WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class Selector_Controller : BaseGeneric_Controller<SelectorController>
    {
        
        public Selector_Controller(
            SelectorController logicController) : base(logicController)
        {
        }






    
        [HttpPost("[action]")]
        public async Task<IActionResult> obtainCatalogTitle([FromBody] Models.CatalogSelector.CatalogRelatedFields catalogRelatedField)
        {
            try
            {
                return Ok(_logicController.obtainCatalogTitle(catalogRelatedField));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> ObtainCatalogs([FromBody] Selector_ObtainCatalogs_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.ObtainCatalogs(apiParam.LstCatalogDef, apiParam.BaseParam));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> obtainCatalog([FromBody] Selector_obtainCatalog_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.obtainCatalog(apiParam.CatalogDef, apiParam.BaseParam));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> obtainItemByClave([FromBody] Selector_obtainItemByClave_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.obtainItemByClave(apiParam.StrCatalogo, apiParam.StrClave, apiParam.BaseParam));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> obtainItemById([FromBody] Selector_obtainItemById_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.obtainItemById(apiParam.StrCatalogo, apiParam.ItemId!.Value, apiParam.BaseParam));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



  }

}



