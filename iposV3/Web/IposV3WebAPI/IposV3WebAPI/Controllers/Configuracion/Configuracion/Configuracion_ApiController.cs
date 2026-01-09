
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

    public class Configuracion_Controller : Base_Controller<ConfiguracionController, ConfiguracionBindingModel, ConfiguracionParam>
    {


        public Configuracion_Controller(
            ConfiguracionController logicController) : base(logicController)
        {
        }
    




    
        [HttpPost("[action]")]
        public async Task<IActionResult> CrearEmpresa([FromBody] EmpresaBindingModel empresaInfo)
        {
            try
            {
                return Ok(_logicController.CrearEmpresa(empresaInfo));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateEmpresa([FromBody] EmpresaBindingModel item)
        {
            try
            {
                return Ok(_logicController.UpdateEmpresa(item));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> CrearSucursal([FromBody] SucursalBindingModel sucursalInfo)
        {
            try
            {
                return Ok(_logicController.CrearSucursal(sucursalInfo));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> CrearUnidadesDefault([FromBody] SucursalBindingModel sucursalInfo)
        {
            try
            {
                _logicController.CrearUnidadesDefault(sucursalInfo);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> CrearAlmacenDefault([FromBody] SucursalBindingModel sucursalInfo)
        {
            try
            {
                _logicController.CrearAlmacenDefault(sucursalInfo);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> CrearClientesDefault([FromBody] SucursalBindingModel sucursalInfo)
        {
            try
            {
                _logicController.CrearClientesDefault(sucursalInfo);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> CrearProveedorDefault([FromBody] SucursalBindingModel sucursalInfo)
        {
            try
            {
                _logicController.CrearProveedorDefault(sucursalInfo);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> CrearLineaDefault([FromBody] SucursalBindingModel sucursalInfo)
        {
            try
            {
                _logicController.CrearLineaDefault(sucursalInfo);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> CrearMarcaDefault([FromBody] SucursalBindingModel sucursalInfo)
        {
            try
            {
                _logicController.CrearMarcaDefault(sucursalInfo);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> CrearProductoDefault([FromBody] SucursalBindingModel sucursalInfo)
        {
            try
            {
                _logicController.CrearProductoDefault(sucursalInfo);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> CrearCaja([FromBody] CajaBindingModel cajaInfo)
        {
            try
            {
                return Ok(_logicController.CrearCaja(cajaInfo));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> CrearUsuario([FromBody] UsuarioBindingModel usuarioInfo)
        {
            try
            {
                return Ok(_logicController.CrearUsuario(usuarioInfo));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> CrearParametroDefault([FromBody] Configuracion_CrearParametroDefault_ApiParam apiParam)
        {
            try
            {
                _logicController.CrearParametroDefault(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> MigrateDataBase([FromBody] Configuracion_MigrateDataBase_ApiParam apiParam)
        {
            try
            {
                _logicController.MigrateDataBase(apiParam.CreateIfNotExist!.Value, apiParam.RutaInstalacionPostgresql, apiParam.Configuracion);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



  }

}



