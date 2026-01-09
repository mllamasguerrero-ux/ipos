using BindingModels;
using Controllers.Controller;
using IposV3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

#pragma warning disable 1998
namespace IposV3WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Base_Controller<L,T,U> : ControllerBase where L : BaseController<T> where T : class where U: class
    {

        protected readonly L _logicController;

        public Base_Controller(
            L logicController)
        {
            this._logicController = logicController;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetById(T itemSelect)
        {
            try
            {
                return Ok(_logicController.GetById(itemSelect));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> SelectList([FromBody] SearchListBindingModel<U> searchListParameter)
        {
            try
            {
                return Ok(_logicController.SelectList(searchListParameter.Param, searchListParameter.KendoParams));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(_logicController.GetAll());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Insert(T item)
        {

            try
            {
                return Ok(_logicController.Insert(item));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Select([FromBody] SelectParamBindingModel<U> selectParam)
        {

            try
            {
                return Ok(_logicController.Select(selectParam.Param, selectParam.Search, selectParam.FieldsSearching));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")]

        public async Task<IActionResult> SelectById(T itemSelect)
        {

            try
            {
                return Ok(_logicController.SelectById(itemSelect));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Update(T item)
        {

            try
            {
                return Ok(_logicController.Update(item));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(T item)
        {

            try
            {
                return Ok(_logicController.Delete(item));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class BaseGeneric_Controller<L>: ControllerBase where L : class
    {

        protected readonly L _logicController;

        public BaseGeneric_Controller(
            L logicController)
        {
            this._logicController = logicController;
        }
    }

}

#pragma warning restore 1998