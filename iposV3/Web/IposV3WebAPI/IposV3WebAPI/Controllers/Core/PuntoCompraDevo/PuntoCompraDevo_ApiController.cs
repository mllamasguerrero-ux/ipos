
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

    public class PuntoCompraDevo_Controller : BaseGeneric_Controller<PuntoCompraDevoController>
    {

        PuntoCompraDevo_ApiAux puntoCompraDevo_ApiAux;
        MovtoController movtoController;

        public PuntoCompraDevo_Controller(
            PuntoCompraDevoController logicController,
            MovtoController movtoController,
            PuntoCompraDevo_ApiAux puntoCompraDevo_ApiAux) : base(logicController)
        {
            this.puntoCompraDevo_ApiAux = puntoCompraDevo_ApiAux;
            this.movtoController = movtoController;
        }






    
        [HttpPost("[action]")]
        public async Task<IActionResult> Docto_provdevo_insert([FromBody] DoctoProvDevoTrans doctoProvDevoTrans)
        {
            try
            {
                return Ok(_logicController.Docto_provdevo_insert(doctoProvDevoTrans));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    



    
        [HttpPost("[action]")]
        public async Task<IActionResult> Movto_provdevo_insert([FromBody] MovtoProvDevoTrans movtoProvDevoTrans)
        {
            try
            {
                return Ok(_logicController.Movto_provdevo_insert(movtoProvDevoTrans));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> Select_V_movto_provdevo_List([FromBody] PuntoCompraDevo_Select_V_movto_provdevo_List_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Select_V_movto_provdevo_List(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.DoctoId!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> Select_V_docto_provdevo_List([FromBody] PuntoCompraDevo_Select_V_docto_provdevo_List_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Select_V_docto_provdevo_List(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.UsuarioId!.Value, apiParam.TipoDoctoId!.Value, apiParam.EstatusDoctoId!.Value, apiParam.FechaIni!.Value, apiParam.FechaFin!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> Select_V_docto_prov_to_devo_List([FromBody] PuntoCompraDevo_Select_V_docto_prov_to_devo_List_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Select_V_docto_prov_to_devo_List(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.UsuarioId!.Value, apiParam.TipoDoctoId!.Value, apiParam.EstatusDoctoId!.Value, apiParam.FechaIni!.Value, apiParam.FechaFin!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> Select_V_movto_prov_to_devo_List([FromBody] PuntoCompraDevo_Select_V_movto_prov_to_devo_List_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Select_V_movto_prov_to_devo_List(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.DoctoId!.Value, apiParam.DoctoRefId!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> Docto_provdevo_save([FromBody] PuntoCompraDevo_Docto_provdevo_save_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Docto_provdevo_save(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.Id!.Value, apiParam.EstatusDoctoId!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> Docto_provdevo_delete([FromBody] PuntoCompraDevo_Docto_provdevo_delete_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Docto_provdevo_delete(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.Id!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> Docto_provdevo_cancel([FromBody] PuntoCompraDevo_Docto_provdevo_cancel_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Docto_provdevo_cancel(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.DoctoId!.Value, apiParam.CreadoPorId!.Value));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> Movto_provdevo_delete([FromBody] PuntoCompraDevo_Movto_provdevo_delete_ApiParam apiParam)
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


                    result = _logicController.Movto_provdevo_delete(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, movtoId);
                    if (result != null && result.Result < 0)
                    {
                        break;
                    }
                }

                PuntoCompraDevoBindingModel model = new PuntoCompraDevoBindingModel();
                model.CurrentDocto = new DoctoBindingModel()
                {
                    EmpresaId = apiParam.EmpresaId,
                    SucursalId = apiParam.SucursalId,
                    Id = apiParam.DoctoId
                };

                model.BaseResultBindingModel = result;

                puntoCompraDevo_ApiAux.LlenarPuntoCompraDevoInfo(ref model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> Docto_provdevo_and_payments_save([FromBody] PuntoCompraDevo_Docto_provdevo_and_payments_save_ApiParam apiParam)
        {
            try
            {
                return Ok(_logicController.Docto_provdevo_and_payments_save(apiParam.EmpresaId!.Value, apiParam.SucursalId!.Value, apiParam.Id!.Value, apiParam.ListPagos));

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
                PuntoCompraDevoBindingModel pvBindingModel = new PuntoCompraDevoBindingModel();

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


                puntoCompraDevo_ApiAux.AssignProducto(decipherResult.Productoid.Value, ref pvBindingModel);
                puntoCompraDevo_ApiAux.AssignPrecioDescuentos(null, null, ref pvBindingModel);

                if (apiParam.SaveMovto)
                {

                    var bufferMovtoItemTrans = puntoCompraDevo_ApiAux.FillAddMovtoParameters(pvBindingModel.CurrentMovto!, pvBindingModel.CurrentDocto!, pvBindingModel.Precionetoenpv == BoolCN.S,
                                                                    pvBindingModel.CurrentMovto._Precio, pvBindingModel.CurrentMovto.Cantidad, null, null, null, pvBindingModel.Usuarioid!.Value);

                    pvBindingModel.MovtoTransList = new System.Collections.Generic.List<MovtoProvDevoTrans>();
                    pvBindingModel.MovtoTransList.Add(bufferMovtoItemTrans);

                    puntoCompraDevo_ApiAux.SaveMovtos(ref pvBindingModel);
                }

                return Ok(pvBindingModel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> SaveMovto([FromBody] PuntoCompraDevoBindingModel pvBindingModel)
        {
            try
            {

                pvBindingModel.BaseResultBindingModel = new BaseResultBindingModel() { Result = 0 };

                puntoCompraDevo_ApiAux.SaveMovtos(ref pvBindingModel);

                return Ok(pvBindingModel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost("[action]")]
        public async Task<IActionResult> GetDocumentInfo([FromBody] PuntoCompraDevoBindingModel pvBindingModel)
        {
            try
            {

                pvBindingModel.BaseResultBindingModel = new BaseResultBindingModel() { Result = 0 };

                puntoCompraDevo_ApiAux.ReLoadFullDocto(ref pvBindingModel);

                if (pvBindingModel.CurrentDocto?.Docto_devolucion_Doctorefid != null)
                    puntoCompraDevo_ApiAux.ReLoadFullRefDocto(pvBindingModel.CurrentDocto!.Docto_devolucion_Doctorefid!.Value, ref pvBindingModel);

                puntoCompraDevo_ApiAux.ReloadMovtoItems(pvBindingModel.CurrentDocto.Id!.Value, ref pvBindingModel);

                if (pvBindingModel.CurrentDocto?.Docto_devolucion_Doctorefid != null)
                    puntoCompraDevo_ApiAux.ReloadMovtoToDevoItems(pvBindingModel.CurrentDocto.Id!.Value, pvBindingModel.CurrentDocto!.Docto_devolucion_Doctorefid!.Value, ref pvBindingModel);

                return Ok(pvBindingModel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        [HttpPost("[action]")]
        public async Task<IActionResult> GetInitialDocumentInfoFromRef([FromBody] PuntoCompraDevoBindingModel pvBindingModel)
        {
            try
            {

                pvBindingModel.BaseResultBindingModel = new BaseResultBindingModel() { Result = 0 };


                if (pvBindingModel.CurrentDocto?.Docto_devolucion_Doctorefid != null)
                {
                    puntoCompraDevo_ApiAux.ReLoadFullRefDocto(pvBindingModel.CurrentDocto!.Docto_devolucion_Doctorefid!.Value, ref pvBindingModel);
                    puntoCompraDevo_ApiAux.ReloadMovtoToDevoItems(0, pvBindingModel.CurrentDocto!.Docto_devolucion_Doctorefid!.Value, ref pvBindingModel);



                    pvBindingModel.CurrentDocto!.Clienteid = pvBindingModel.CurrentDoctoRef!.Clienteid;

                    pvBindingModel.CurrentDocto!.Almacenid = pvBindingModel.CurrentDoctoRef!.Almacenid;
                    pvBindingModel.CurrentDocto!.Origenfiscalid = pvBindingModel.CurrentDoctoRef!.Origenfiscalid;

                    puntoCompraDevo_ApiAux.AssignProveedorInfo(ref pvBindingModel);


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



