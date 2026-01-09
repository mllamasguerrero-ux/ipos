
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

    public class PuntoVenta_Controller : BaseGeneric_Controller<PuntoVentaController>
    {

        PuntoVenta_ApiAux puntoVenta_ApiAux;
        MovtoController movtoController;
        public PuntoVenta_Controller(
            PuntoVentaController logicController,
            MovtoController movtoController,
            PuntoVenta_ApiAux puntoVenta_ApiAux) : base(logicController)
        {
            this.puntoVenta_ApiAux = puntoVenta_ApiAux;
            this.movtoController = movtoController;
        }






        [HttpPost("[action]")]
        public async Task<IActionResult> Select_V_movto_vendeduria_List([FromBody] PuntoVenta_Select_V_movto_vendeduria_List_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Select_V_movto_vendeduria_List(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.DoctoId!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        //DONE2 MLG 2025 Migracion web
        [HttpPost("[action]")]
        public async Task<IActionResult> Docto_vend_insert([FromBody] DoctoVendTrans doctoVendTrans)
        {
            try
            {
                return Ok(_logicController.Docto_vend_insert(doctoVendTrans));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }






        //DONE2 MLG 2025 Migracion web
        [HttpPost("[action]")]
        public async Task<IActionResult> Movto_vend_insert([FromBody] MovtoVendTrans movtoVendTrans)
        {
            try
            {
                return Ok(_logicController.Movto_vend_insert(movtoVendTrans));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }







        //DONE2 MLG 2025 Migracion web
        [HttpPost("[action]")]
        public async Task<IActionResult> Select_V_docto_vendeduria_List([FromBody] PuntoVenta_Select_V_docto_vendeduria_List_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Select_V_docto_vendeduria_List(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.UsuarioId!.Value, apiParam.TipoDoctoId!.Value, apiParam.EstatusDoctoId!.Value, apiParam.FechaIni!.Value, apiParam.FechaFin!.Value, apiParam.CorteActual!.Value, apiParam.AlmacenId, 
                                                                          apiParam.TodosAlmacenes!.Value, apiParam.PorFecha ?? BoolCS.S, apiParam.TodosUsuarios ?? BoolCS.S));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        //DONE2 MLG 2025 Migracion web
        [HttpPost("[action]")]
        public async Task<IActionResult> Precioprod_ref_vend([FromBody] PuntoVenta_Precioprod_ref_vend_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Precioprod_ref_vend(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.ProductoId!.Value, apiParam.ClienteId!.Value, apiParam.Cantidad!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        //DONE2 MLG 2025 Migracion web
        [HttpPost("[action]")]
        public async Task<IActionResult> Docto_vend_save([FromBody] PuntoVenta_Docto_vend_save_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Docto_vend_save(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.Id!.Value, apiParam.EstatusDoctoId!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        //DONE2 MLG 2025 Migracion web
        [HttpPost("[action]")]
        public async Task<IActionResult> Docto_vend_delete([FromBody] PuntoVenta_Docto_vend_delete_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Docto_vend_delete(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.Id!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        //DONE2 MLG 2025 Migracion web
        [HttpPost("[action]")]
        public async Task<IActionResult> Docto_vend_cancel([FromBody] PuntoVenta_Docto_vend_cancel_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Docto_vend_cancel(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.DoctoId!.Value, apiParam.CreadoPorId!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        //DONE2 MLG 2025 Migracion web
        [HttpPost("[action]")]
        public async Task<IActionResult> Movto_vend_delete([FromBody] PuntoVenta_Movto_vend_delete_ApiParam apiParam)
        {
            BaseResultBindingModel result = new BaseResultBindingModel();
            try
            {
                foreach (var movtoId in apiParam.ListIds)
                {

                    var movto = new MovtoBindingModel()
                    {

                        EmpresaId = apiParam.EmpresaId,
                        SucursalId = apiParam.SucursalId,
                        Id = movtoId
                    };


                    result = _logicController.Movto_vend_delete(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, movtoId);
                    if (result != null && result.Result < 0)
                    {
                        break;
                    }
                }

                PuntoVentaBindingModel model = new PuntoVentaBindingModel();
                model.CurrentDocto = new DoctoBindingModel()
                {
                    EmpresaId = apiParam.EmpresaId,
                    SucursalId = apiParam.SucursalId,
                    Id = apiParam.DoctoId
                };

                model.BaseResultBindingModel = result;

                puntoVenta_ApiAux.LlenarPuntoVentaInfo(ref model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        //DONE2 MLG 2025 Migracion web
        [HttpPost("[action]")]
        public async Task<IActionResult> Docto_vend_and_payments_save([FromBody] PuntoVenta_Docto_vend_and_payments_save_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Docto_vend_and_payments_save(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.Id!.Value, apiParam.ListPagos));
                ;
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
                PuntoVentaBindingModel pvBindingModel = new PuntoVentaBindingModel();

                pvBindingModel.CurrentDocto = apiParam.CurrentDocto;
                pvBindingModel.ManejaAlmacen = apiParam.ManejaAlmacen;
                pvBindingModel.Precionetoenpv = apiParam.Precionetoenpv;
                pvBindingModel.Tipodescuentoprodid = apiParam.Tipodescuentoprodid;
                pvBindingModel.SaveMovto = pvBindingModel.SaveMovto;
                pvBindingModel.Usuarioid = apiParam.Usuarioid;

                pvBindingModel.BaseResultBindingModel = new BaseResultBindingModel() { Result = 0 };

                if(pvBindingModel.Usuarioid == null)
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


                puntoVenta_ApiAux.AssignProducto(decipherResult.Productoid.Value, ref pvBindingModel);
                puntoVenta_ApiAux.AssignPrecioDescuentos(null, null, ref pvBindingModel);

                if (apiParam.SaveMovto)
                {

                    var bufferMovtoItemTrans = puntoVenta_ApiAux.FillAddMovtoParameters(pvBindingModel.CurrentMovto!, pvBindingModel.CurrentDocto!, pvBindingModel.Precionetoenpv == BoolCN.S,
                                                                    pvBindingModel.CurrentMovto._Precio, pvBindingModel.CurrentMovto.Cantidad, null, null, null, pvBindingModel.Usuarioid!.Value);
                    bufferMovtoItemTrans.EsMovtoPrincipal = true;
                    pvBindingModel.MovtoTransList = new System.Collections.Generic.List<MovtoVendTrans>();
                    pvBindingModel.MovtoTransList.Add(bufferMovtoItemTrans);

                    puntoVenta_ApiAux.SaveMovtos(ref pvBindingModel);
                }

                return Ok(pvBindingModel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> SaveMovto([FromBody] PuntoVentaBindingModel pvBindingModel)
        {
            try
            {

                pvBindingModel.BaseResultBindingModel = new BaseResultBindingModel() { Result = 0 };

                puntoVenta_ApiAux.SaveMovtos(ref pvBindingModel);

                return Ok(pvBindingModel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> GetDocumentInfo([FromBody] PuntoVentaBindingModel pvBindingModel)
        {
            try
            {

                pvBindingModel.BaseResultBindingModel = new BaseResultBindingModel() { Result = 0 };

                puntoVenta_ApiAux.ReLoadFullDocto(ref pvBindingModel);
                puntoVenta_ApiAux.ReloadMovtoItems(pvBindingModel.CurrentDocto.Id!.Value, ref pvBindingModel);

                return Ok(pvBindingModel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }

}



