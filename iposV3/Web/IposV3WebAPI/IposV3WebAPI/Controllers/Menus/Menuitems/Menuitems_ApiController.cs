
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

    public class Menuitems_Controller : BaseGeneric_Controller<MenuitemsController>
    {
        
        public Menuitems_Controller(
            MenuitemsController logicController) : base(logicController)
        {
        }






    
        [HttpPost("[action]")]
        public async Task<IActionResult> ValidMenu([FromBody] String menu)
        {
            try
            {
                return Ok(_logicController.ValidMenu(menu));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> SelectPorUsuario([FromBody] Menuitems_SelectPorUsuario_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.SelectPorUsuario(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.UsuarioId!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }








        [HttpPost("[action]")]
        public async Task<IActionResult> AddMenuRecursive([FromBody] Menuitems_AddMenuRecursive_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.AddMenuRecursive(apiParam.MnuItem, apiParam.MenuItems));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



  }

}



