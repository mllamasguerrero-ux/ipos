
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

    public class PuntoVentaDevo_Controller : BaseGeneric_Controller<PuntoVentaDevoController>
    {

        PuntoVentaDevo_ApiAux puntoVentaDevo_ApiAux;
        MovtoController movtoController;
        public PuntoVentaDevo_Controller(
            PuntoVentaDevoController logicController,
            MovtoController movtoController,
            PuntoVentaDevo_ApiAux puntoVentaDevo_ApiAux) : base(logicController)
        {
            this.puntoVentaDevo_ApiAux = puntoVentaDevo_ApiAux;
            this.movtoController = movtoController;
        }






    
        [HttpPost("[action]")]
        public async Task<IActionResult> Docto_venddevo_insert([FromBody] DoctoVenddevoTrans doctoVendDevoTrans)
        {
            try
            {
                return Ok(_logicController.Docto_venddevo_insert(doctoVendDevoTrans));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> Movto_venddevo_insert([FromBody] MovtoVenddevoTrans movtoVendDevoTrans)
        {
            try
            {
                return Ok(_logicController.Movto_venddevo_insert(movtoVendDevoTrans));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> Select_V_movto_venddevo_List([FromBody] PuntoVentaDevo_Select_V_movto_venddevo_List_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Select_V_movto_venddevo_List(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.DoctoId!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> Select_V_docto_venddevo_List([FromBody] PuntoVentaDevo_Select_V_docto_venddevo_List_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Select_V_docto_venddevo_List(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.UsuarioId!.Value, apiParam.TipoDoctoId!.Value, apiParam.EstatusDoctoId!.Value, apiParam.FechaIni!.Value, apiParam.FechaFin!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> Select_V_docto_vend_to_devo_List([FromBody] PuntoVentaDevo_Select_V_docto_vend_to_devo_List_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Select_V_docto_vend_to_devo_List(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.UsuarioId!.Value, apiParam.TipoDoctoId!.Value, apiParam.EstatusDoctoId!.Value, apiParam.FechaIni!.Value, apiParam.FechaFin!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> Select_V_movto_vend_to_devo_List([FromBody] PuntoVentaDevo_Select_V_movto_vend_to_devo_List_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Select_V_movto_vend_to_devo_List(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.DoctoId!.Value, apiParam.DoctoRefId!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> Docto_venddevo_save([FromBody] PuntoVentaDevo_Docto_venddevo_save_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Docto_venddevo_save(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.Id!.Value, apiParam.EstatusDoctoId!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> Docto_venddevo_delete([FromBody] PuntoVentaDevo_Docto_venddevo_delete_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Docto_venddevo_delete(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.Id!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> Docto_venddevo_cancel([FromBody] PuntoVentaDevo_Docto_venddevo_cancel_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Docto_venddevo_cancel(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.DoctoId!.Value, apiParam.CreadoPorId!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }







        [HttpPost("[action]")]
        public async Task<IActionResult> Movto_venddevo_delete([FromBody] PuntoVentaDevo_Movto_venddevo_delete_ApiParam apiParam)
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


                    result = _logicController.Movto_venddevo_delete(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, movtoId);
                    if (result != null && result.Result < 0)
                    {
                        break;
                    }
                }

                PuntoVentaDevoBindingModel model = new PuntoVentaDevoBindingModel();
                model.CurrentDocto = new DoctoBindingModel()
                {
                    EmpresaId = apiParam.EmpresaId,
                    SucursalId = apiParam.SucursalId,
                    Id = apiParam.DoctoId
                };

                model.BaseResultBindingModel = result;

                puntoVentaDevo_ApiAux.LlenarPuntoVentaDevoInfo(ref model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost("[action]")]
        public async Task<IActionResult> Docto_venddevo_and_payments_save([FromBody] PuntoVentaDevo_Docto_venddevo_and_payments_save_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Docto_venddevo_and_payments_save(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.Id!.Value, apiParam.ListPagos));

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
                PuntoVentaDevoBindingModel pvBindingModel = new PuntoVentaDevoBindingModel();

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


                puntoVentaDevo_ApiAux.AssignProducto(decipherResult.Productoid.Value, ref pvBindingModel);
                puntoVentaDevo_ApiAux.AssignPrecioDescuentos(null, null, ref pvBindingModel);

                if (apiParam.SaveMovto)
                {

                    var bufferMovtoItemTrans = puntoVentaDevo_ApiAux.FillAddMovtoParameters(pvBindingModel.CurrentMovto!, pvBindingModel.CurrentDocto!, pvBindingModel.Precionetoenpv == BoolCN.S,
                                                                    pvBindingModel.CurrentMovto._Precio, pvBindingModel.CurrentMovto.Cantidad, null, null, null, pvBindingModel.Usuarioid!.Value);
                    
                    pvBindingModel.MovtoTransList = new System.Collections.Generic.List<MovtoVenddevoTrans>();
                    pvBindingModel.MovtoTransList.Add(bufferMovtoItemTrans);

                    puntoVentaDevo_ApiAux.SaveMovtos(ref pvBindingModel);
                }

                return Ok(pvBindingModel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> SaveMovto([FromBody] PuntoVentaDevoBindingModel pvBindingModel)
        {
            try
            {

                pvBindingModel.BaseResultBindingModel = new BaseResultBindingModel() { Result = 0 };

                puntoVentaDevo_ApiAux.SaveMovtos(ref pvBindingModel);

                return Ok(pvBindingModel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        [HttpPost("[action]")]
        public async Task<IActionResult> GetDocumentInfo([FromBody] PuntoVentaDevoBindingModel pvBindingModel)
        {
            try
            {

                pvBindingModel.BaseResultBindingModel = new BaseResultBindingModel() { Result = 0 };

                puntoVentaDevo_ApiAux.ReLoadFullDocto(ref pvBindingModel);

                if (pvBindingModel.CurrentDocto?.Docto_devolucion_Doctorefid != null)
                    puntoVentaDevo_ApiAux.ReLoadFullRefDocto(pvBindingModel.CurrentDocto!.Docto_devolucion_Doctorefid!.Value, ref pvBindingModel);

                puntoVentaDevo_ApiAux.ReloadMovtoItems(pvBindingModel.CurrentDocto.Id!.Value, ref pvBindingModel);

                if(pvBindingModel.CurrentDocto?.Docto_devolucion_Doctorefid != null)
                    puntoVentaDevo_ApiAux.ReloadMovtoToDevoItems(pvBindingModel.CurrentDocto.Id!.Value, pvBindingModel.CurrentDocto!.Docto_devolucion_Doctorefid!.Value, ref pvBindingModel);

                return Ok(pvBindingModel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        [HttpPost("[action]")]
        public async Task<IActionResult> GetInitialDocumentInfoFromRef([FromBody] PuntoVentaDevoBindingModel pvBindingModel)
        {
            try
            {

                pvBindingModel.BaseResultBindingModel = new BaseResultBindingModel() { Result = 0 };


                if (pvBindingModel.CurrentDocto?.Docto_devolucion_Doctorefid != null)
                {
                    puntoVentaDevo_ApiAux.ReLoadFullRefDocto(pvBindingModel.CurrentDocto!.Docto_devolucion_Doctorefid!.Value, ref pvBindingModel);
                    puntoVentaDevo_ApiAux.ReloadMovtoToDevoItems(0, pvBindingModel.CurrentDocto!.Docto_devolucion_Doctorefid!.Value, ref pvBindingModel);

                    

                    pvBindingModel.CurrentDocto!.Clienteid = pvBindingModel.CurrentDoctoRef!.Clienteid;

                    pvBindingModel.CurrentDocto!.Almacenid = pvBindingModel.CurrentDoctoRef!.Almacenid;
                    pvBindingModel.CurrentDocto!.Origenfiscalid = pvBindingModel.CurrentDoctoRef!.Origenfiscalid;

                    puntoVentaDevo_ApiAux.AssignClientInfo(ref pvBindingModel);


                }
                return Ok(pvBindingModel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }

}



