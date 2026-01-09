
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

    public class Movtogastosadic_Controller : Base_Controller<MovtogastosadicController, MovtogastosadicBindingModel, MovtogastosadicParam>
    {


        public Movtogastosadic_Controller(
            MovtogastosadicController logicController) : base(logicController)
        {
        }



        [HttpPost("[action]")]
        public async Task<IActionResult> InsertMultiFuncional(MovtogastosadicBindingModel item)
        {
            MovtogastosadicWebBindingModel model = new MovtogastosadicWebBindingModel();
            model.BaseResultBindingModel = new BaseResultBindingModel();
            model.BaseResultBindingModel.Result = 0;

            try
            {
                bool result = _logicController.Insert(item);
                if(result == false)
                {
                    model.BaseResultBindingModel.Result = -1;
                    model.BaseResultBindingModel.Devmessage = "Error al insertar registro";
                    model.BaseResultBindingModel.Usermessage = model.BaseResultBindingModel.Devmessage;
                }


                model.Items = _logicController.SelectListByDocto(new MovtogastosadicParam(item.EmpresaId, item.SucursalId, item.Doctoid), null);

                return Ok(model);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> DeleteMultiFuncional(MovtogastosadicBindingModel item)
        {
            MovtogastosadicWebBindingModel model = new MovtogastosadicWebBindingModel();
            model.BaseResultBindingModel = new BaseResultBindingModel();
            model.BaseResultBindingModel.Result = 0;

            try
            {
                bool result = _logicController.Delete(item);
                if (result == false)
                {
                    model.BaseResultBindingModel.Result = -1;
                    model.BaseResultBindingModel.Devmessage = "Error al eliminar el registro";
                    model.BaseResultBindingModel.Usermessage = model.BaseResultBindingModel.Devmessage;
                }


                model.Items = _logicController.SelectListByDocto(new MovtogastosadicParam(item.EmpresaId, item.SucursalId, item.Doctoid), null);

                return Ok(model);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost("[action]")]
        public async Task<IActionResult> SelectListByDocto([FromBody] Movtogastosadic_SelectListByDocto_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.SelectListByDocto(apiParam.Param, apiParam.KendoParams));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



  }

}



