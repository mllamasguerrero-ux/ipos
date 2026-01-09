
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

    public class PuntoCompra_Controller : BaseGeneric_Controller<PuntoCompraController>
    {

        PuntoCompra_ApiAux puntoCompra_ApiAux;
        MovtoController movtoController;
        public PuntoCompra_Controller(
            PuntoCompraController logicController,
            MovtoController movtoController,
            PuntoCompra_ApiAux puntoCompra_ApiAux) : base(logicController)
        {
            this.puntoCompra_ApiAux = puntoCompra_ApiAux;
            this.movtoController = movtoController;
        }






        [HttpPost("[action]")]
        public async Task<IActionResult> Select_V_movto_proveeduria_List([FromBody] PuntoCompra_Select_V_movto_proveeduria_List_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Select_V_movto_proveeduria_List(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.DoctoId!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        //DONE2 MLG 2025 Migracion web
        [HttpPost("[action]")]
        public async Task<IActionResult> Docto_prov_insert([FromBody] DoctoProvTrans doctoProvTrans)
        {
            try
            {
                return Ok(_logicController.Docto_prov_insert(doctoProvTrans));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }






        //DONE2 MLG 2025 Migracion web
        [HttpPost("[action]")]
        public async Task<IActionResult> Movto_prov_insert([FromBody] MovtoProvTrans movtoProvTrans)
        {
            try
            {
                return Ok(_logicController.Movto_prov_insert(movtoProvTrans));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }










        //DONE2 MLG 2025 Migracion web
        [HttpPost("[action]")]
        public async Task<IActionResult> Select_V_docto_proveeduria_List([FromBody] PuntoCompra_Select_V_docto_proveeduria_List_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Select_V_docto_proveeduria_List(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.UsuarioId!.Value, apiParam.TipoDoctoId!.Value, apiParam.EstatusDoctoId!.Value, apiParam.FechaIni!.Value, apiParam.FechaFin!.Value, apiParam.CorteActual!.Value, apiParam.AlmacenId!.Value,
                                                                           apiParam.TodosAlmacenes!.Value, apiParam.PorFecha ?? BoolCS.S, apiParam.TodosUsuarios ?? BoolCS.S));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        //DONE2 MLG 2025 Migracion web
        [HttpPost("[action]")]
        public async Task<IActionResult> Precioprod_ref_prov([FromBody] PuntoCompra_Precioprod_ref_prov_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Precioprod_ref_prov(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.ProductoId!.Value, apiParam.ProveedorId!.Value, apiParam.Cantidad!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        //DONE2 MLG 2025 Migracion web
        [HttpPost("[action]")]
        public async Task<IActionResult> Docto_prov_save([FromBody] PuntoCompra_Docto_prov_save_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Docto_prov_save(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.Id!.Value, apiParam.EstatusDoctoId!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        //DONE2 MLG 2025 Migracion web
        [HttpPost("[action]")]
        public async Task<IActionResult> Docto_prov_delete([FromBody] PuntoCompra_Docto_prov_delete_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Docto_prov_delete(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.Id!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        //DONE2 MLG 2025 Migracion web
        [HttpPost("[action]")]
        public async Task<IActionResult> Docto_prov_cancel([FromBody] PuntoCompra_Docto_prov_cancel_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Docto_prov_cancel(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.DoctoId!.Value, apiParam.CreadoPorId!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        //DONE2 MLG 2025 Migracion web
        [HttpPost("[action]")]
        public async Task<IActionResult> Movto_prov_delete([FromBody] PuntoCompra_Movto_prov_delete_ApiParam apiParam)
        {

            BaseResultBindingModel result = new BaseResultBindingModel();
            try
            {
                foreach (var movtoId in apiParam.ListIds)
                {

                    result = _logicController.Movto_prov_delete(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, movtoId);
                    if (result != null && result.Result < 0)
                    {
                        break;
                    }
                }

                PuntoCompraBindingModel model = new PuntoCompraBindingModel();
                model.CurrentDocto = new DoctoBindingModel()
                {
                    EmpresaId = apiParam.EmpresaId,
                    SucursalId = apiParam.SucursalId,
                    Id = apiParam.DoctoId
                };

                model.BaseResultBindingModel = result;

                puntoCompra_ApiAux.LlenarPuntoCompraInfo(ref model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }





        //DONE2 MLG 2025 Migracion web
        [HttpPost("[action]")]
        public async Task<IActionResult> Docto_prov_and_payments_save([FromBody] PuntoCompra_Docto_prov_and_payments_save_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Docto_prov_and_payments_save(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.Id!.Value, apiParam.ListPagos));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> DecipherCommand([FromBody] Movto_DecipherCommand_ApiParam apiParam)
        {
            try
            {
                PuntoCompraBindingModel pvBindingModel = new PuntoCompraBindingModel();

                pvBindingModel.CurrentDocto = apiParam.CurrentDocto;
                pvBindingModel.ManejaAlmacen = apiParam.ManejaAlmacen;
                pvBindingModel.Precionetoenpv = apiParam.Precionetoenpv;
                pvBindingModel.Tipodescuentoprodid = apiParam.Tipodescuentoprodid;
                pvBindingModel.SaveMovto = pvBindingModel.SaveMovto;
                pvBindingModel.Usuarioid = apiParam.Usuarioid;

                pvBindingModel.BaseResultBindingModel = new BaseResultBindingModel() { Result = 0 };

                if (pvBindingModel.Usuarioid == null)
                {
                    pvBindingModel.BaseResultBindingModel.Result = -10020;
                    pvBindingModel.BaseResultBindingModel.Usermessage = "Se requiere especificar el usuario";
                    pvBindingModel.BaseResultBindingModel.Devmessage = pvBindingModel.BaseResultBindingModel.Usermessage;
                    return Ok(pvBindingModel);
                }



                var decipherResult = movtoController.DecipherCommand(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.CommandText);

                pvBindingModel.DecipherResult = decipherResult;

                if (decipherResult == null || decipherResult.Productoid == null || decipherResult.Productoid == 0)
                {
                    return Ok(pvBindingModel);

                }


                pvBindingModel.CurrentMovto = new MovtoBindingModel();
                pvBindingModel.CurrentMovto.EmpresaId = pvBindingModel.CurrentDocto.EmpresaId;
                pvBindingModel.CurrentMovto.SucursalId = pvBindingModel.CurrentDocto.SucursalId;
                pvBindingModel.CurrentMovto.Cantidad = decipherResult.Cantidad == 0 ? 1 : decipherResult.Cantidad;
                pvBindingModel.CurrentMovto.Estatusmovtoid = IposV3.Model.DBValues._MOVTO_ESTATUS_BORRADOR;
                pvBindingModel.CurrentMovto.Doctoid = pvBindingModel.CurrentDocto.Id;



                puntoCompra_ApiAux.AssignProducto(decipherResult.Productoid.Value, ref pvBindingModel);
                puntoCompra_ApiAux.AssignPrecioDescuentos(null, null, ref pvBindingModel);

                if (apiParam.SaveMovto)
                {

                    var bufferMovtoItemTrans = puntoCompra_ApiAux.FillAddMovtoParameters(pvBindingModel.CurrentMovto!, pvBindingModel.CurrentDocto!, pvBindingModel.Precionetoenpv == BoolCN.S,
                                                                    pvBindingModel.CurrentMovto._Precio, pvBindingModel.CurrentMovto.Cantidad, null, null, null, pvBindingModel.Usuarioid!.Value);
                    bufferMovtoItemTrans.EsMovtoPrincipal = true;
                    pvBindingModel.MovtoTransList = new System.Collections.Generic.List<MovtoProvTrans>();
                    pvBindingModel.MovtoTransList.Add(bufferMovtoItemTrans);

                    puntoCompra_ApiAux.SaveMovtos(ref pvBindingModel);
                }


                return Ok(pvBindingModel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> SaveMovto([FromBody] PuntoCompraBindingModel pcBindingModel)
        {
            try
            {

                pcBindingModel.BaseResultBindingModel = new BaseResultBindingModel() { Result = 0 };

                puntoCompra_ApiAux.SaveMovtos(ref pcBindingModel);

                return Ok(pcBindingModel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }




        [HttpPost("[action]")]
        public async Task<IActionResult> GetDocumentInfo([FromBody] PuntoCompraBindingModel pcBindingModel)
        {
            try
            {

                pcBindingModel.BaseResultBindingModel = new BaseResultBindingModel() { Result = 0 };

                puntoCompra_ApiAux.ReLoadFullDocto(ref pcBindingModel);
                puntoCompra_ApiAux.ReloadMovtoItems(pcBindingModel.CurrentDocto.Id!.Value, ref pcBindingModel);

                return Ok(pcBindingModel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

}



