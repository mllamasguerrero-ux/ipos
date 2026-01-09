using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;
//using Syncfusion.Windows.Controls;
using IposV3.Services.FacturaElectronica;
using System.Globalization;
using System.IO;
using System.Xml;
using IposV3.Services.Extensions;
using static IposV3.Services.FacturaElectronica.VirtualXmlHelperModel;

namespace IposV3.Services
{
    public class FacturaElectronicaService
    {


        private MaestroConsecutivoService _maestroConsecutivoService;
        private CartaporteFacturaElectronicaService _cartaporteFacturaElectronicaService;

        public FacturaElectronicaService(
                            CartaporteFacturaElectronicaService cartaporteFacturaElectronicaService,
                            MaestroConsecutivoService maestroConsecutivoService)
        {
            _maestroConsecutivoService = maestroConsecutivoService;
            _cartaporteFacturaElectronicaService = cartaporteFacturaElectronicaService;
        }


        public bool Factura_Electronica_Preparar(long empresaId, long sucursalId, long doctoId, string? tipoComprobanteEspecial,
                    ApplicationDbContext localContext, out string message)
        {
            message = "";

            var doctoAFacturar = localContext.Docto
                .Include(d => d.Docto_fact_elect)
                .Include(d => d.Docto_comprobantes)
                .FirstOrDefault(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Id == doctoId);

            if (doctoAFacturar == null)
                throw new Exception("Docto no encontrado");

            string? serieSat = doctoAFacturar.Docto_fact_elect?.Seriesat ?? "";
            long folioDocto = doctoAFacturar.Docto_fact_elect?.Foliosat ?? 0;
            long? satUsoCfdiId = doctoAFacturar.Docto_fact_elect?.Sat_usocfdiid;

            if (folioDocto == 0)
            {
                var parametro = localContext.Parametro.AsNoTracking()
                                            .FirstOrDefault(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId);

                if(parametro == null)
                    throw new Exception("Parametro no encontrado");


                switch (doctoAFacturar.Tipodoctoid)
                {
                    case DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO:
                    case DBValues._DOCTO_TIPO_DEVOLUCION:
                        serieSat = parametro!.Seriesatdevolucion;
                        break;
                    case DBValues._DOCTO_TIPO_RECIBOELECTRONICO:
                        serieSat = parametro!.Seriesatabono;
                        break;
                    default:
                        serieSat = parametro!.Seriesat;
                        break;
                }


                _maestroConsecutivoService.GenerarConsecutivo(empresaId, sucursalId, Tipo_consecutivo.FolioSatDocto, doctoAFacturar.Tipodoctoid,
                                                                "Docto_fact_elect", "Foliosat", "public", "Seriesat", serieSat, "Tipodoctoid",
                                                                out folioDocto, localContext);

                if (folioDocto <= 0)
                {
                    throw new Exception("No se pudo crear el folio");
                }

            }


            if (satUsoCfdiId == null)
            {
                satUsoCfdiId = 2;
            }

            var currentDate = DateTimeOffset.UtcNow.ToLocalTime();
            if (tipoComprobanteEspecial == null || tipoComprobanteEspecial != "T")
            {

                if (doctoAFacturar.Docto_fact_elect == null)
                {
                    var doctoFacturaElectronica = new Docto_fact_elect()
                    {
                        EmpresaId = empresaId,
                        SucursalId = sucursalId,
                        Doctoid = doctoId,
                        Timbradofechafactura = currentDate,
                        Foliosat = (int)folioDocto,
                        Seriesat = serieSat,
                        Fechafactura = currentDate,
                        Sat_usocfdiid = satUsoCfdiId

                    };

                    doctoAFacturar.Docto_fact_elect = doctoFacturaElectronica;
                    localContext.Add(doctoAFacturar.Docto_fact_elect);
                }
                else
                {

                    doctoAFacturar.Docto_fact_elect!.Timbradofechafactura = DateTimeOffset.UtcNow.ToLocalTime();
                    doctoAFacturar.Docto_fact_elect!.Foliosat = (int)folioDocto;
                    doctoAFacturar.Docto_fact_elect!.Seriesat = serieSat;
                    doctoAFacturar.Docto_fact_elect!.Fechafactura = doctoAFacturar.Docto_fact_elect!.Timbradofechafactura;
                    doctoAFacturar.Docto_fact_elect!.Sat_usocfdiid = satUsoCfdiId;

                    localContext.Update(doctoAFacturar.Docto_fact_elect);
                }
                localContext.Update(doctoAFacturar);
                localContext.SaveChanges();
            }
            else
            {
                var doctoComprobante = doctoAFacturar?.Docto_comprobantes?.FirstOrDefault(y => y.Tipocomprobante == tipoComprobanteEspecial);
                if (doctoComprobante == null)
                {
                    var doctoComprobanteElectronico = new Doctocomprobante()
                    {
                        EmpresaId = empresaId,
                        SucursalId = sucursalId,
                        Doctoid = doctoId,
                        Timbradofecha = currentDate.ToString(),
                        Foliosat = (int)folioDocto,
                        Seriesat = serieSat,
                        Tipocomprobante = tipoComprobanteEspecial

                    };

                    localContext.Doctocomprobante.Add(doctoComprobanteElectronico);
                }
                else
                {

                    doctoComprobante.Timbradofecha = DateTimeOffset.UtcNow.ToLocalTime().ToString();
                    doctoComprobante.Foliosat = (int)folioDocto;
                    doctoComprobante.Seriesat = serieSat;

                    localContext.Doctocomprobante.Update(doctoComprobante);
                }

                localContext.SaveChanges();
            }


            return true;
        }



        public bool Factura_Electronica_FillAll(long empresaId, long sucursalId, long doctoId,
                    string documentoTimbrado, bool silentMode, string? tipocomprobanteespecial, bool generarCartaPorte,
                    ApplicationDbContext localContext,  out string message,  out VirtualXmlHelperModel virtualXmlHelper)
        {



            virtualXmlHelper = new VirtualXmlHelperModel();
            message = "";

            DatosBD_FacturaElectronica datosBD = new DatosBD_FacturaElectronica();
            datosBD.LlenarDatos(empresaId, sucursalId, doctoId, null, null, localContext);

            datosBD.Tipocomprobanteespecial = tipocomprobanteespecial;
            datosBD.Generarcartaporte = generarCartaPorte;


            virtualXmlHelper.ManejaAddenda = false;
            virtualXmlHelper.ManejaImpuestosLocales = false;

            bool? desgloseIepsParent = datosBD.DoctoInfo!.Tipodoctoid == DBValues._DOCTO_TIPO_FACTCONSOLIDADA ? datosBD.V_desgloseiepsfactura  : null;


            FillComprobanteInfo(empresaId, sucursalId, doctoId, desgloseIepsParent, null, 
                                ref datosBD, ref virtualXmlHelper);
            FillComprobanteInfoEx(empresaId, sucursalId, doctoId, desgloseIepsParent, null,
                                ref datosBD, ref virtualXmlHelper);
            FillEmisor(empresaId, sucursalId, doctoId, desgloseIepsParent, null,
                                ref datosBD, ref virtualXmlHelper);
            FillExpedidoEn(empresaId, sucursalId, doctoId, desgloseIepsParent, null,
                                ref datosBD, ref virtualXmlHelper);

            FillReceptorInfo(empresaId, sucursalId, doctoId, desgloseIepsParent, null,
                                ref datosBD, ref virtualXmlHelper);

            FillInformacionAdicional(empresaId, sucursalId, doctoId, desgloseIepsParent, null,
                            ref datosBD, ref virtualXmlHelper);

            FillConceptos(empresaId, sucursalId, doctoId, desgloseIepsParent, null, localContext,
                                ref datosBD, ref virtualXmlHelper);



            FillPago(empresaId, sucursalId, doctoId, desgloseIepsParent, null,
                                ref datosBD, ref virtualXmlHelper);

            FillRelacionados(empresaId, sucursalId, doctoId, desgloseIepsParent, null,
                                ref datosBD, ref virtualXmlHelper);


            if (generarCartaPorte)
            {
                FillCartaporte(empresaId, sucursalId, doctoId, desgloseIepsParent, null, localContext,
                                ref datosBD, ref virtualXmlHelper);
                //throw new Exception("Excepcion temporal");
            }


            if (datosBD.Tipocomprobanteespecial != "T")
            {

                FillComprobantesImpuestos(empresaId, sucursalId, doctoId, desgloseIepsParent, null,
                                    ref datosBD, ref virtualXmlHelper);


                FillComprobanteTrasladosRetenciones(empresaId, sucursalId, doctoId, desgloseIepsParent, null,
                                    ref datosBD, ref virtualXmlHelper);
            }
            else
            {
                virtualXmlHelper.ImpuestosRetenidos = new List<Retencion>();
                virtualXmlHelper.ImpuestosTrasladados = new List<Traslado>();

            }


            virtualXmlHelper.ManejaRetenidos = virtualXmlHelper.ImpuestosRetenidos != null && virtualXmlHelper.ImpuestosRetenidos.Count() > 0;
            virtualXmlHelper.ManejaTrasladados = virtualXmlHelper.ImpuestosTrasladados != null && virtualXmlHelper.ImpuestosTrasladados.Count() > 0;

            virtualXmlHelper.CiberSatInfo = new CiberSATInfo((datosBD!.Parametro!.Timbradouser ?? ""), (datosBD!.Parametro!.Timbradokey ?? ""));


            virtualXmlHelper.RutaCsd = datosBD!.Parametro!.Timbradoarchivocertificado ?? "";
            virtualXmlHelper.Llave = datosBD!.Parametro!.Timbradoarchivokey ?? "";
            virtualXmlHelper.ClaveLlave = datosBD!.Parametro!.Timbradopassword ?? "";
            virtualXmlHelper.RutaXml = documentoTimbrado;
            virtualXmlHelper.VirtualPacInfo = new VirtualPACInfo((datosBD!.Parametro!.Pacusuario ?? ""), "virtual");

            //virtualXmlHelper.ICARTAPORTE = datosBD.Cartaporte;
            return true;
        }

        public void FillComprobanteInfo(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref VirtualXmlHelperModel virtualXmlHelper)
        {
            ComprobanteInfo comprobanteInfo = new ComprobanteInfo();
            comprobanteInfo.Moneda = "MXN";
            comprobanteInfo.Exportacion = "01";
            comprobanteInfo.TipoCambio = "";
            comprobanteInfo.TipoComprobante = datosBD.Tipocomprobanteespecial != null ? datosBD.Tipocomprobanteespecial :
                                            (datosBD.DoctoInfo?.Tipodoctoid!.Value.In(21, 701) ?? false) ? "I" :
                                         (datosBD.DoctoInfo?.Tipodoctoid!.Value == 22 ? "E" : (datosBD.DoctoInfo?.Tipodoctoid!.Value == 205 ? "P" : ""));

            if (datosBD.DoctoInfo?.Tipodoctoid!.Value == 21 && datosBD.Tipocomprobanteespecial == "T")
            {

                FillComprobanteInfo_venta_comprobantetraslado(empresaId, sucursalId, doctoId, desgloseiepsparent, mostrardescuentoparent,
                                                 ref datosBD, ref comprobanteInfo);
            }
            else if (datosBD.DoctoInfo?.Tipodoctoid!.Value.In(21, 22) ?? false)
            {

               
                FillComprobanteInfo_venta_devolucion(empresaId, sucursalId, doctoId, desgloseiepsparent, mostrardescuentoparent,
                                                 ref datosBD, ref comprobanteInfo);
            }
            else if (datosBD.DoctoInfo?.Tipodoctoid!.Value.In(701) ?? false)
            {
                FillComprobanteInfo_consolidacion(empresaId, sucursalId, doctoId, desgloseiepsparent, mostrardescuentoparent,
                                                 ref datosBD, ref comprobanteInfo);
            }
            else if (datosBD.DoctoInfo?.Tipodoctoid!.Value.In(205) ?? false)
            {
                FillComprobanteInfo_pagoelectronicos(empresaId, sucursalId, doctoId, desgloseiepsparent, mostrardescuentoparent,
                                                 ref datosBD, ref comprobanteInfo);
            }

            virtualXmlHelper.ComprobanteInfo = comprobanteInfo;


        }

        public void FillComprobanteInfoEx(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref VirtualXmlHelperModel virtualXmlHelper)
        {
            ComprobanteInfoEx comprobanteInfoEx = new ComprobanteInfoEx();


            if (datosBD.DoctoInfo?.Tipodoctoid!.In(22) ?? false)
            {
                FillComprobanteInfoEx_devolucion(empresaId, sucursalId, doctoId, desgloseiepsparent, mostrardescuentoparent,
                                                 ref datosBD, ref comprobanteInfoEx);
                virtualXmlHelper.ComprobanteInfoEx = comprobanteInfoEx;
            }

        }

        public void FillEmisor(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref VirtualXmlHelperModel virtualXmlHelper)
        {

            EmisorInfo emisorInfo = new EmisorInfo();
            FacturaElectronica.Domicilio domicilio = new FacturaElectronica.Domicilio();

            domicilio.Calle = datosBD.Parametro?.Fiscalcalle ?? "";
            domicilio.NoExterior = datosBD.Parametro?.Fiscalnumeroexterior ?? "";
            domicilio.NoInterior = datosBD.Parametro?.Fiscalnumerointerior ?? "";
            domicilio.Colonia = datosBD.Parametro?.Fiscalcolonia ?? "";
            domicilio.Localidad = ".";
            domicilio.Referencia = ".";
            domicilio.Municipio = datosBD.Parametro?.Fiscalmunicipio ?? "";
            domicilio.Estado = datosBD.Parametro?.Fiscalestado ?? "";
            domicilio.Pais = "MEX";
            domicilio.CodigoPostal = datosBD.Parametro?.Fiscalcodigopostal ?? ""; 
            emisorInfo.Rfc = datosBD.Empresa?.Rfc ?? "";
            emisorInfo.RazonSocial = datosBD.Parametro?.Fiscalnombre ?? "";
            emisorInfo.RegimenFiscal = datosBD.Parametro?.Sat_regimenfiscal?.Sat_clave ?? "";


            emisorInfo.Domicilio = domicilio;
            virtualXmlHelper.EmisorInfo = emisorInfo;
        }


        public void FillExpedidoEn(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref VirtualXmlHelperModel virtualXmlHelper)
        {
            EmisorExpedidoEn emisorExpedidoEn = new EmisorExpedidoEn();

            //emisor expedido en

            if (datosBD.V_usarfiscalesenexpedicion)
            {

                emisorExpedidoEn.Calle = datosBD.Parametro?.Fiscalcalle ?? ""; ;
                emisorExpedidoEn.NoExterior = datosBD.Parametro?.Fiscalnumeroexterior ?? ""; ;
                emisorExpedidoEn.NoInterior = datosBD.Parametro?.Fiscalnumerointerior ?? ""; ;
                emisorExpedidoEn.Colonia = datosBD.Parametro?.Fiscalcolonia ?? ""; ;
                emisorExpedidoEn.Localidad = ".";
                emisorExpedidoEn.Referencia = ".";
                emisorExpedidoEn.Municipio = datosBD.Parametro?.Fiscalmunicipio ?? ""; ;
                emisorExpedidoEn.Estado = datosBD.Parametro?.Fiscalestado ?? ""; ;
                emisorExpedidoEn.Pais = "MEX";
                emisorExpedidoEn.CodigoPostal = datosBD.Parametro?.Fiscalcodigopostal ?? ""; ;
                //emisorExpedidoEn.Rfc = datosBD.Empresa?.Rfc;
                //emisorExpedidoEn.Razonsocial = datosBD.Parametro?.Fiscalnombre ?? ""; ;
                //emisorExpedidoEn.RegimenFiscal = datosBD.Parametro?.Sat_regimenfiscal?.Sat_clave;
            }
            else
            {

                emisorExpedidoEn.Calle = datosBD.Parametro?.Calle ?? ""; ;
                emisorExpedidoEn.NoExterior = datosBD.Parametro?.Numeroexterior ?? ""; ;
                emisorExpedidoEn.NoInterior = datosBD.Parametro?.Numerointerior ?? ""; ;
                emisorExpedidoEn.Colonia = datosBD.Parametro?.Colonia ?? ""; ;
                emisorExpedidoEn.Localidad = ".";
                emisorExpedidoEn.Referencia = ".";
                emisorExpedidoEn.Municipio = datosBD.Parametro?.Municipio ?? ""; ;
                emisorExpedidoEn.Estado = datosBD.Parametro?.Estado ?? ""; ;
                emisorExpedidoEn.Pais = "MEX";
                emisorExpedidoEn.CodigoPostal = datosBD.Parametro?.Codigopostal ?? ""; ;
                //emisorExpedidoEn.Rfc = datosBD.Empresa?.Rfc ?? ""; ;
                //emisorExpedidoEn.Razonsocial = datosBD.Parametro?.Nombre ?? ""; ;
                //emisorExpedidoEn.Regimenfiscal = datosBD.Parametro?.Sat_regimenfiscal?.Sat_clave ?? ""; ;
            }


            virtualXmlHelper.EmisorExpedidoEn = emisorExpedidoEn;
        }


        public void FillReceptorInfo(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref VirtualXmlHelperModel virtualXmlHelper)
        {
            ReceptorInfo receptorInfo = new ReceptorInfo();



            if (!datosBD.DoctoInfo?.Tipodoctoid!.Value.In(701) ?? false)
            {
                FillReceptorInfo_No_Consolidado(empresaId, sucursalId, doctoId, desgloseiepsparent, mostrardescuentoparent,
                                                virtualXmlHelper.EmisorInfo,  ref datosBD, ref receptorInfo);
            }
            else
            {
                FillReceptorInfo_Consolidado(empresaId, sucursalId, doctoId, desgloseiepsparent, mostrardescuentoparent,
                                                 ref datosBD, ref receptorInfo);
            }

            virtualXmlHelper.ReceptorInfo = receptorInfo;


        }



        public void FillComprobanteInfo_venta_comprobantetraslado(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref ComprobanteInfo comprobanteInfo)
        {

            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";


                comprobanteInfo.FormaPago = "99";
                datosBD.V_pagoenunasolaexibicion = true;
                datosBD.V_imprimircomprobantespago = false;

                var tipoComprobanteBuffer = datosBD.Tipocomprobanteespecial;
                var comprobante = datosBD.DoctoInfo?.Docto_comprobantes?.FirstOrDefault(d => d.Tipocomprobante == tipoComprobanteBuffer);

            decimal totalBuffer = 0m, subTotalBuffer = 0m; //, descuentoBuffer = 0m;
                comprobanteInfo.Serie = comprobante?.Seriesat ?? "";
                comprobanteInfo.Folio = comprobante?.Foliosat?.ToString() ?? "";
                comprobanteInfo.Fecha = (DateTimeOffset.Parse(comprobante?.Timbradofecha ?? DateTimeOffset.Now.ToString())).AddMinutes(-5).ToLocalTime().ToDateTime().ToString("yyyy-MM-dd'T'HH:mm:ss");
                comprobanteInfo.Moneda = "XXX";
                comprobanteInfo.TipoCambio = "";
                comprobanteInfo.CondicionesPago = "";
                comprobanteInfo.MetodoPago = "";
                comprobanteInfo.MotivoDescuento = "X";
                comprobanteInfo.LugarExpedicion = datosBD.Parametro?.Fiscalcodigopostal ?? "";
                comprobanteInfo.FormaPago = "";
                comprobanteInfo.Subtotal = subTotalBuffer.ToString("N0", nfi);
                comprobanteInfo.Total = totalBuffer.ToString("N0", nfi);
                comprobanteInfo.Descuento = ""; // descuentoBuffer.ToString("N0", nfi);
        }


            public void FillComprobanteInfo_venta_devolucion(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref ComprobanteInfo comprobanteInfo)
        {

            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";

            var cuentadoctopagocredito = datosBD.DoctoPagos?.Where(dp => dp.Formapagoid == 4 && dp.Pago != null && dp.Pago.Revertido == BoolCN.N).Count();


            var cuentapagosnocredito = datosBD.DoctoPagosTransaccion?.Where(dp => dp.Formapagoid != null && (dp.Formapagoid!.Value.In(1, 2, 3, 5, 15)) &&
                                                                                dp.Pago != null && dp.Pago.Revertido == BoolCN.N &&
                                                                                dp.Pago.Formapagosatid != null && dp.Pago.Formapagosatid != 0).Count()
                                                            ;


                if ((datosBD.DoctoInfo?.Docto_info_pago != null && datosBD.DoctoInfo?.Docto_info_pago.Pagoacredito == BoolCN.S) ||
                     (datosBD.V_pre_formapagosat == "99") ||
                    (datosBD.DoctoInfo?.Tipodoctoid!.Value == 22 && cuentadoctopagocredito > 0)
                )
                {
                    comprobanteInfo.FormaPago = "99";
                    datosBD.V_pagoenunasolaexibicion = false;

                    if (cuentapagosnocredito > 0)
                    {
                        datosBD.V_imprimircomprobantespago = true;
                    }
                }
                else
                {
                    if (datosBD.V_pre_formapagosat == "" || datosBD.V_pre_formapagosat.Contains("|"))
                    {

                        comprobanteInfo.FormaPago = datosBD.DoctoPagosTransaccion?.Where(dp => dp.Formapagoid != null && (dp.Formapagoid!.Value.In(1, 2, 3, 5, 15)) &&
                                                        dp.Pago != null && dp.Pago.Revertido == BoolCN.N &&
                                                        dp.Pago!.Formapagosat != null).
                                                GroupBy(dp => new { dp.Pago!.Formapagosatid, Formapagosatclave = dp.Pago!.Formapagosat!.Clave }).
                                                Select(g => new { g.Key.Formapagosatid, g.Key.Formapagosatclave, SumaMonto = g.Sum(j => j.Importe) }).
                                                OrderByDescending(o => o.SumaMonto).
                                                Select(g => g.Formapagosatclave).
                                                FirstOrDefault() ?? "99";

                    }
                    else
                    {
                        comprobanteInfo.FormaPago = datosBD.V_pre_formapagosat;
                    }
                    if (cuentapagosnocredito > 0)
                    {
                        datosBD.V_pagoenunasolaexibicion = true;
                    }

                }





                //linea.P_numeroctapago = datosBD.DoctoPagosTransaccion.Where(dp => dp.Formapagoid != null && (dp.Formapagoid!.Value.In(1, 2, 3, 5, 15)) &&
                //                                dp.Pago != null && dp.Pago.Revertido == BoolCN.N).
                //                        GroupBy(dp => new { dp.Pago.Formapagoid, dp.Pago.Referenciabancaria }).
                //                        Select(g => new { g.Key.Formapagoid, g.Key.Referenciabancaria, SumaMonto = g.Sum(j => j.Importe) }).
                //                        OrderByDescending(o => o.SumaMonto).
                //                        Select(g => g.Referenciabancaria).
                //                        FirstOrDefault();

                decimal totalBuffer = 0m, subTotalBuffer = 0m, descuentoBuffer;

                comprobanteInfo.Serie = datosBD.DoctoInfo?.Docto_fact_elect?.Seriesat ?? "";
                comprobanteInfo.Folio = datosBD.DoctoInfo?.Docto_fact_elect?.Foliosat?.ToString() ?? "";


                comprobanteInfo.Fecha = (datosBD.DoctoInfo?.Docto_fact_elect?.Timbradofechafactura ?? DateTimeOffset.Now).ToCDMX().AddMinutes(-5).ToString("yyyy-MM-dd'T'HH:mm:ss");
                totalBuffer = (datosBD.DoctoInfo?.Total - (datosBD.DoctoInfo?.Docto_fact_elect?.Ivaretenido ?? 0m) - (datosBD.DoctoInfo?.Docto_fact_elect?.Ivaretenido ?? 0m)) ?? 0;
                comprobanteInfo.Moneda = "MXN";
                comprobanteInfo.TipoCambio = "";
                comprobanteInfo.CondicionesPago = "";
                comprobanteInfo.MetodoPago = datosBD.V_pagoenunasolaexibicion || datosBD.DoctoInfo?.Tipodoctoid == 22 ? "PUE" : "PPD";
                comprobanteInfo.MotivoDescuento = "X";
                comprobanteInfo.LugarExpedicion = datosBD.Parametro?.Fiscalcodigopostal ?? "";

                //bool v_personadesglosaieps = datosBD.V_personadesglosaieps;
                //bool v_empresadesglosaieps = datosBD.V_empresadesglosaieps;
                bool v_desglosariepsmovto = datosBD.V_desglosariepsmovto;
                bool v_mostrardescuentoenfactura = datosBD.V_mostrardescuentoenfactura;

                subTotalBuffer = datosBD.MovtosInfo?.Sum(m =>

                                    m.Subtotal +
                                      (
                                        (
                                            //(v_personadesglosaieps && v_empresadesglosaieps) ||
                                            (v_desglosariepsmovto) ||
                                            (desgloseiepsparent != null && desgloseiepsparent!.Value)
                                        ) ? 0m : m.Ieps
                                      ) +
                                      (v_mostrardescuentoenfactura ? m.Descuento : 0m)
                              ) ?? 0m;

                descuentoBuffer = datosBD.MovtosInfo?.Sum(m => (v_mostrardescuentoenfactura ? m.Descuento : 0m)) ?? 0m;

                int cuentadescuentosnegativos = datosBD.MovtosInfo?.Where(m => m.Descuento < 0).Count() ?? 0;

                if (descuentoBuffer < 0 || cuentadescuentosnegativos > 0)
                {
                    comprobanteInfo.Subtotal = comprobanteInfo.Subtotal + comprobanteInfo.Descuento;
                    datosBD.V_mostrardescuentoenfactura = false;
                }

                comprobanteInfo.FormaPago = comprobanteInfo.FormaPago == null || comprobanteInfo.FormaPago.Trim().Count() == 0 ? "99" : comprobanteInfo.FormaPago;

                comprobanteInfo.Subtotal = subTotalBuffer.ToString("N2", nfi);
                comprobanteInfo.Total = totalBuffer.ToString("N2", nfi);
                comprobanteInfo.Descuento = descuentoBuffer.ToString("N2", nfi);
            


        }

        public void FillComprobanteInfo_consolidacion(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref ComprobanteInfo comprobanteInfo)
        {


            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";

            decimal totalBuffer = 0m, subTotalBuffer = 0m, descuentoBuffer = 0m;

            datosBD.V_pagoenunasolaexibicion = false;
            datosBD.V_imprimircomprobantespago = true;
            comprobanteInfo.FormaPago = comprobanteInfo.FormaPago == "" ? comprobanteInfo.FormaPago : "01";
            datosBD.V_personadesglosaieps = datosBD.ClienteInfo?.Cliente_poliza?.Desgloseieps == BoolCN.S;
            datosBD.V_mostrardescuentoenfactura = false;


            comprobanteInfo.FormaPago = datosBD.V_formapago_consolidada ?? "";

            comprobanteInfo.Serie = datosBD.DoctoInfo?.Docto_fact_elect?.Seriesat ?? "";
            comprobanteInfo.Folio = datosBD.DoctoInfo?.Docto_fact_elect?.Foliosat?.ToString() ?? "";
            comprobanteInfo.Fecha = (datosBD.DoctoInfo?.Docto_fact_elect?.Timbradofechafactura ?? DateTimeOffset.Now).AddMinutes(-5).ToLocalTime().ToDateTime().ToString("yyyy-MM-dd'T'HH:mm:ss");
            totalBuffer = (datosBD.DoctoInfo?.Total ?? 0m) - (datosBD.DoctoInfo?.Docto_fact_elect?.Ivaretenido ?? 0m) - (datosBD.DoctoInfo?.Docto_fact_elect?.Ivaretenido ?? 0m);
            comprobanteInfo.Moneda = "MXN";
            comprobanteInfo.TipoCambio = "";
            comprobanteInfo.CondicionesPago = "";
            comprobanteInfo.MetodoPago = "PUE";
            comprobanteInfo.MotivoDescuento = "X";
            comprobanteInfo.LugarExpedicion = datosBD.Parametro?.Fiscalcodigopostal ?? "";


            subTotalBuffer = (datosBD.DoctoInfo?.Subtotal +
                                  (
                                    (
                                        //(datosBD.V_personadesglosaieps && datosBD.V_empresadesglosaieps) ||
                                        (datosBD.V_desglosariepsmovto) ||
                                        (desgloseiepsparent != null && desgloseiepsparent!.Value)
                                    ) ? 0m : datosBD.DoctoInfo?.Ieps
                                  ) ?? 0m) +
                                  (datosBD.V_mostrardescuentoenfactura ? (datosBD.DoctoInfo?.Descuento ?? 0m) : 0m);

            descuentoBuffer = datosBD.V_mostrardescuentoenfactura ? (datosBD.DoctoInfo?.Descuento ?? 0m) : 0m;
            datosBD.V_omitirvales = datosBD.DoctoInfo?.Docto_fact_elect_consolidacion?.Omitirvales == BoolCN.S;

            comprobanteInfo.FormaPago = comprobanteInfo.FormaPago == null || comprobanteInfo.FormaPago.Trim().Count() == 0 ? "99" : comprobanteInfo.FormaPago;

            comprobanteInfo.Subtotal = subTotalBuffer.ToString("N2", nfi);
            comprobanteInfo.Total = totalBuffer.ToString("N2", nfi);
            comprobanteInfo.Descuento = descuentoBuffer.ToString("N2", nfi);

        }
        public void FillComprobanteInfo_pagoelectronicos(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref ComprobanteInfo comprobanteInfo)
        {

            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";

            decimal totalBuffer = 0m, subTotalBuffer = 0m;//, descuentoBuffer = 0m;

            comprobanteInfo.FormaPago = "";

            //linea.P_numeroctapago = doctoPagos.Where(dp => (dp.Pago?.Formapagosatid ?? 0) != 0 && dp.Pago!.Revertido != BoolCN.S && dp.Formapagoid.In(1, 2, 3, 5, 15))
            //          .OrderByDescending(dp => dp.Importe)
            //          .Select(dp => dp.Pago!.Cuentapagocredito)
            //          .FirstOrDefault();


            comprobanteInfo.Serie = datosBD.DoctoInfo?.Docto_fact_elect?.Seriesat ?? "";
            comprobanteInfo.Folio = datosBD.DoctoInfo?.Docto_fact_elect?.Foliosat?.ToString() ?? "";
            comprobanteInfo.Fecha = (datosBD.DoctoInfo?.Docto_fact_elect?.Timbradofechafactura ?? DateTimeOffset.Now).AddMinutes(-5).ToLocalTime().ToDateTime().ToString("yyyy-MM-dd'T'HH:mm:ss");
            totalBuffer = 0m;
            comprobanteInfo.Moneda = "XXX";
            comprobanteInfo.TipoCambio = "";
            comprobanteInfo.CondicionesPago = "";
            comprobanteInfo.MetodoPago = "";
            comprobanteInfo.MotivoDescuento = "X";
            comprobanteInfo.LugarExpedicion = datosBD.Parametro?.Fiscalcodigopostal ?? "";

            subTotalBuffer = 0m;
            //descuentoBuffer = 0m;

            comprobanteInfo.Subtotal = subTotalBuffer.ToString("N0", nfi);
            comprobanteInfo.Total = totalBuffer.ToString("N0", nfi);
            comprobanteInfo.Descuento = "";// descuentoBuffer.ToString("N0", nfi);

        }



        public void FillComprobanteInfoEx_devolucion(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref ComprobanteInfoEx comprobanteInfoEx)
        {
            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";

            comprobanteInfoEx.LugarExpedicion = datosBD.V_empresa_fiscalcodigopostal ?? "";
            //numeroctapago
            if (datosBD.DoctoInfo!.Tipodoctoid!.Value.In(22))
            {
                comprobanteInfoEx.SerieFolioFiscalOriginal = datosBD.DoctoInfo?.Docto_devolucion?.Docto?.Docto_fact_elect?.Seriesat ?? "";
                comprobanteInfoEx.FolioFiscalOriginal = datosBD.DoctoInfo?.Docto_devolucion?.Docto?.Docto_fact_elect?.Foliosat.ToString() ?? "";
                comprobanteInfoEx.MontoFolioFiscalOriginal = datosBD.DoctoInfo?.Docto_devolucion?.Docto?.Total.ToString("N2", nfi) ?? "0.00";
                comprobanteInfoEx.FechaFolioFiscalOriginal = datosBD.DoctoInfo?.Docto_devolucion?.Docto?.Docto_fact_elect?.Timbradofechafactura?.ToLocalTime().ToDateTime().ToString("yyyy-MM-dd'T'HH:mm:ss") ?? "";

            }
        }



        public void FillReceptorInfo_No_Consolidado(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    EmisorInfo? emisorInfo,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref ReceptorInfo receptorInfo)
        {

            FacturaElectronica.Domicilio domicilio = new FacturaElectronica.Domicilio();

            var v_personaentregacalle = datosBD.ClienteInfo?.Domicilioentrega?.Calle;

            if (!datosBD.V_preguntardatosentrega || (v_personaentregacalle ?? "") == "")
            {
                domicilio.Calle = datosBD.ClienteInfo?.Domicilio?.Calle ?? "";
                domicilio.NoExterior = datosBD.ClienteInfo?.Domicilio?.Numeroexterior ?? "";
                domicilio.NoInterior = datosBD.ClienteInfo?.Domicilio?.Numerointerior ?? "";
                domicilio.Colonia = datosBD.ClienteInfo?.Domicilio?.Colonia ?? "";
                domicilio.Localidad = ".";
                domicilio.Referencia = ".";
                domicilio.Municipio = datosBD.ClienteInfo?.Domicilio?.Municipio ?? "";
                domicilio.Estado = datosBD.ClienteInfo?.Domicilio?.Estado ?? "";
                domicilio.Pais = "MEX";
                domicilio.CodigoPostal = datosBD.ClienteInfo?.Domicilio?.Codigopostal ?? "";

                receptorInfo.Rfc = datosBD.ClienteInfo?.Rfc ?? "";
                receptorInfo.RazonSocial = (datosBD.ClienteInfo?.Nombres + " " + datosBD.ClienteInfo?.Apellidos) ?? "";
                receptorInfo.ResidenciaFiscal = "";
                receptorInfo.Nombre = (datosBD.ClienteInfo?.Nombres + " " + datosBD.ClienteInfo?.Apellidos) ?? "";
                receptorInfo.NumRegIdTrib = "";

                receptorInfo.DomicilioFiscalReceptor = datosBD.ClienteInfo?.Domicilio?.Codigopostal ?? "";
            }
            else
            {

                domicilio.Calle = datosBD.ClienteInfo?.Domicilioentrega?.Calle ?? "";
                domicilio.NoExterior = datosBD.ClienteInfo?.Domicilioentrega?.Numeroexterior ?? "";
                domicilio.NoInterior = datosBD.ClienteInfo?.Domicilioentrega?.Numerointerior ?? "";
                domicilio.Colonia = datosBD.ClienteInfo?.Domicilioentrega?.Colonia ?? "";
                domicilio.Localidad = ".";
                domicilio.Referencia = ".";
                domicilio.Municipio = datosBD.ClienteInfo?.Domicilioentrega?.Municipio ?? "";
                domicilio.Estado = datosBD.ClienteInfo?.Domicilioentrega?.Estado ?? "";
                domicilio.Pais = "MEX";
                domicilio.CodigoPostal = datosBD.ClienteInfo?.Domicilioentrega?.Codigopostal ?? "";
                receptorInfo.Rfc = datosBD.ClienteInfo?.Rfc ?? ""; 
                receptorInfo.RazonSocial = (datosBD.ClienteInfo?.Nombres + " " + datosBD.ClienteInfo?.Apellidos) ?? "";
                receptorInfo.ResidenciaFiscal = "";
                receptorInfo.Nombre = (datosBD.ClienteInfo?.Nombres + " " + datosBD.ClienteInfo?.Apellidos)  ?? "";
                receptorInfo.NumRegIdTrib = "";
                receptorInfo.DomicilioFiscalReceptor = datosBD.ClienteInfo?.Domicilioentrega?.Codigopostal ?? "";
            }

            receptorInfo.RegimenFiscalReceptor = datosBD.ClienteInfo?.Cliente_fact_elect?.Sat_Regimenfiscal?.Sat_clave ?? "";
            

            receptorInfo.UsoCFDI = datosBD.DoctoInfo?.Docto_fact_elect?.Sat_usocfdi?.Clave ?? "";




            if (receptorInfo.UsoCFDI  == "" || datosBD.DoctoInfo!.Tipodoctoid!.Value == 205)
            {
                switch (datosBD.DoctoInfo!.Tipodoctoid!.Value)
                {
                    case 21:
                        receptorInfo.UsoCFDI = "G01";
                        break;
                    case 22:
                        receptorInfo.UsoCFDI = "G02";
                        break;
                    case 205:
                        receptorInfo.UsoCFDI = datosBD.Parametro?.Versioncfdi == "4.0" ? "CP01" : "P01";
                        break;
                    default:
                        receptorInfo.UsoCFDI = "G01";
                        break;
                }
            }


            receptorInfo.Domicilio = domicilio;




            if (datosBD.Tipocomprobanteespecial == "T" && datosBD.Generarcartaporte && emisorInfo != null)
            {

                receptorInfo.Rfc = emisorInfo.Rfc;
                receptorInfo.RazonSocial = emisorInfo.RazonSocial;
                receptorInfo.ResidenciaFiscal = null;
                receptorInfo.Nombre = emisorInfo.Nombre ?? emisorInfo.RazonSocial;
                receptorInfo.NumRegIdTrib = null;
                receptorInfo.UsoCFDI = "S01";
                receptorInfo.RegimenFiscalReceptor = emisorInfo.RegimenFiscal;
                receptorInfo.DomicilioFiscalReceptor = emisorInfo.Domicilio?.CodigoPostal;
            }


        }



        public void FillInformacionAdicional(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref VirtualXmlHelperModel virtualXmlHelper)
        {
            InformacionGlobal informacionGlobal = new InformacionGlobal();
            var fechaIni = datosBD.DoctoInfo?.Docto_fact_elect_consolidacion?.Fecha_ini?.ToLocalTime().ToDateTime().Date ??
                           DateTimeOffset.Now.ToLocalTime().ToDateTime().Date;
            var fechaFin = datosBD.DoctoInfo?.Docto_fact_elect_consolidacion?.Fecha_fin?.ToLocalTime().ToDateTime().Date ??
                           DateTimeOffset.Now.ToLocalTime().ToDateTime().Date;

            informacionGlobal.Periodicidad = ((fechaFin - fechaIni).Days == 0) ? "01" : "04";

            informacionGlobal.Meses = fechaIni.Month.ToString("00");
            informacionGlobal.Anio = fechaIni.Year.ToString();
            virtualXmlHelper.InformacionGlobal = informacionGlobal;



        }

        public void FillReceptorInfo_Consolidado(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref ReceptorInfo receptorInfo)
            {


                FacturaElectronica.Domicilio domicilio = new FacturaElectronica.Domicilio();

                receptorInfo.Rfc = "XAXX010101000";
                domicilio.Calle = "";
                domicilio.NoExterior = "";
                domicilio.NoInterior = "";
                domicilio.Colonia = "";
                domicilio.Localidad = "";
                domicilio.Referencia = "";
                domicilio.Municipio = "";
                domicilio.Estado = "";
                domicilio.Pais = "";
                domicilio.CodigoPostal = "";


                receptorInfo.RazonSocial = "";
                receptorInfo.ResidenciaFiscal = "";
                receptorInfo.Nombre = "PUBLICO EN GENERAL";
                receptorInfo.NumRegIdTrib = "";
                receptorInfo.UsoCFDI = datosBD.Parametro?.Versioncfdi == "4.0" ? "S01" : "P01";
                receptorInfo.RegimenFiscalReceptor = "616";
                receptorInfo.DomicilioFiscalReceptor = datosBD.Parametro?.Fiscalcodigopostal ?? "";

                receptorInfo.Domicilio = domicilio;
            }

        public void FillConceptos(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    ApplicationDbContext localContext,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref VirtualXmlHelperModel virtualXmlHelper)
        {
            List<Concepto> conceptos = new List<Concepto>();

            if(datosBD.Tipocomprobanteespecial == "T" && datosBD.DoctoInfo!.Tipodoctoid!.Value == 21)
            {
                FillConceptos_venta_comprobantetraslado(empresaId, sucursalId, doctoId,
                                        desgloseiepsparent, mostrardescuentoparent,
                                        ref datosBD, ref conceptos);

            }
            else if (datosBD.DoctoInfo!.Tipodoctoid!.Value == 701)
            {
                FillConceptos_Consolidado(empresaId, sucursalId, doctoId,
                                        desgloseiepsparent, mostrardescuentoparent, localContext,
                                        ref datosBD, ref conceptos);
            }
            else if (datosBD.DoctoInfo!.Tipodoctoid!.Value != 205)
            {
                FillConceptos_No_Pagos(empresaId, sucursalId, doctoId,
                                        desgloseiepsparent, mostrardescuentoparent,
                                        ref datosBD, ref conceptos);
            }
            else
            {

                FillConceptos_Pagos(empresaId, sucursalId, doctoId,
                                        desgloseiepsparent, mostrardescuentoparent,
                                        ref datosBD, ref conceptos);
            }

            virtualXmlHelper.Conceptos = conceptos;
        }


        public void FillConceptos_No_Pagos(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref List<Concepto> conceptos)
        {
            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";

            if (datosBD.MovtosInfo != null)
            {
                foreach (var v_rec_movto in datosBD.MovtosInfo)
                {
                    Concepto concepto = new Concepto();


                    var dataMovtoInfo = new DatosBD_MovtoInfo();
                    dataMovtoInfo.Movtoid = v_rec_movto.Id;
                    dataMovtoInfo.Cantidad = v_rec_movto.Cantidad;
                    dataMovtoInfo.Valorunitario =
                                   Math.Round(
                                   (
                                    (
                                        v_rec_movto.Subtotal +
                                        (
                                            (
                                                //(datosBD.V_personadesglosaieps && datosBD.V_empresadesglosaieps) ||
                                                (datosBD.V_desglosariepsmovto) ||
                                                (desgloseiepsparent != null && desgloseiepsparent!.Value)
                                            ) ? 0m : v_rec_movto.Ieps
                                        ) +
                                        (datosBD.V_mostrardescuentoenfactura ? v_rec_movto.Descuento : 0m)
                                    ) / (v_rec_movto.Cantidad > 0 ? v_rec_movto.Cantidad : 1m)
                                   ), 2);


                    dataMovtoInfo.Subtotal = v_rec_movto.Subtotal +
                                          (
                                            (
                                                //(datosBD.V_personadesglosaieps && datosBD.V_empresadesglosaieps) ||
                                                (datosBD.V_desglosariepsmovto) ||
                                                (desgloseiepsparent != null && desgloseiepsparent!.Value)
                                            ) ? 0m : v_rec_movto.Ieps
                                          ) +
                                          (datosBD.V_mostrardescuentoenfactura ? v_rec_movto.Descuento : 0m);


                    dataMovtoInfo.V_subtotalmovto = dataMovtoInfo.Subtotal;

                    dataMovtoInfo.Descuento = (datosBD.V_mostrardescuentoenfactura ? v_rec_movto.Descuento : 0m);

                    dataMovtoInfo.V_porcentajeiepsmovto = (
                                            (
                                                //(datosBD.V_personadesglosaieps && datosBD.V_empresadesglosaieps) ||
                                                (datosBD.V_desglosariepsmovto) ||
                                                (desgloseiepsparent != null && desgloseiepsparent!.Value)
                                            ) ? v_rec_movto.Tasaieps : 0m
                                        );
                    dataMovtoInfo.V_porcentajeivamovto = v_rec_movto.Tasaiva;
                    dataMovtoInfo.V_montoivamovto = v_rec_movto.Iva;
                    dataMovtoInfo.V_montoiepsmovto = (
                                            (
                                                //(datosBD.V_personadesglosaieps && datosBD.V_empresadesglosaieps) ||
                                                (datosBD.V_desglosariepsmovto) ||
                                                (desgloseiepsparent != null && desgloseiepsparent!.Value)
                                            ) ? v_rec_movto.Ieps : 0m
                                        );
                    dataMovtoInfo.V_montoivaretenidomovto = v_rec_movto.Ivaretenido;
                    dataMovtoInfo.V_porcentajeivaretenidomovto = v_rec_movto.Tasaivaretenido;
                    dataMovtoInfo.V_montoisrretenidomovto = v_rec_movto.Isrretenido;
                    dataMovtoInfo.V_porcentajeisrretenidomovto = v_rec_movto.Tasaisrretenido;
                    dataMovtoInfo.V_eskit = v_rec_movto.Eskit == BoolCN.S; //v_rec_movto.Movto_kit?.Eskit == BoolCN.S;
                    dataMovtoInfo.V_kitimpfijo = v_rec_movto.Kitimpfijo == BoolCN.S;// .Movto_kit?.Kitimpfijo == BoolCN.S;

                    dataMovtoInfo.Movtorefid = v_rec_movto.Movto_devolucion?.Movtorefid;


                    dataMovtoInfo.Importe = dataMovtoInfo.Subtotal;
                    dataMovtoInfo.V_descuentomovto = dataMovtoInfo.Descuento;


                    concepto.Cantidad = v_rec_movto.Cantidad.ToString("N2", nfi);
                    concepto.Unidad = v_rec_movto.Producto?.Unidad?.Sat_unidadmedida?.Sat_clave ?? "";

                    concepto.Descripcion = (v_rec_movto.Producto?.Producto_comodin?.Descripcion_comodin == BoolCN.S &&
                                          v_rec_movto.Movto_comodin?.Descripcion1 != null && v_rec_movto.Movto_comodin?.Descripcion1 != "" ?
                                                (v_rec_movto.Movto_comodin?.Descripcion1 ?? "") + " " +
                                                (v_rec_movto.Movto_comodin?.Descripcion2 ?? "") + " " +
                                                (v_rec_movto.Movto_comodin?.Descripcion3 ?? "") :
                                         v_rec_movto.Producto?.Descripcion1) ?? "";

                    concepto.ValorUnitario = dataMovtoInfo.Valorunitario.ToString("N2", nfi);
                    concepto.Importe = dataMovtoInfo.Importe.ToString("N2", nfi);
                    concepto.NoIdentificacion = v_rec_movto.Producto?.Clave ?? "";
                    concepto.CuentaPredial = datosBD.V_esarrendatario ? "" : "";
                    concepto.ClaveProdServ = v_rec_movto.Producto?.Producto_fact_elect?.Sat_productoservicio?.Clave ?? "";
                    concepto.ClaveUnidad = v_rec_movto.Producto?.Unidad?.Sat_unidadmedida?.Clave ?? "";
                    concepto.Descuento = dataMovtoInfo.Descuento.ToString("N2", nfi);

                    concepto.ObjetoImp = "02";

                    concepto.MovtoId = dataMovtoInfo.Movtoid;
                    concepto.DoctoconceptoId = null;


                    List<Traslado> impuestos_ieps = new List<Traslado>();
                    List<Traslado> impuestos_ivas = new List<Traslado>();
                    List<Traslado> impuestos_ivas_retenido = new List<Traslado>();
                    List<Traslado> impuestos_isr_retenido = new List<Traslado>();


                    if (!dataMovtoInfo.V_eskit || dataMovtoInfo.V_kitimpfijo)
                    {
                        FillConceptoIeps_NoKit(empresaId, sucursalId, doctoId,
                                                desgloseiepsparent, mostrardescuentoparent, dataMovtoInfo,
                                                ref datosBD, ref impuestos_ieps);

                        FillConceptoIva_NoKit(empresaId, sucursalId, doctoId,
                                                desgloseiepsparent, mostrardescuentoparent, dataMovtoInfo,
                                                ref datosBD, ref impuestos_ivas);

                    }
                    else
                    {
                        FillConceptos_Partes(empresaId, sucursalId, doctoId,
                                                desgloseiepsparent, mostrardescuentoparent, dataMovtoInfo, v_rec_movto,
                                            ref datosBD, ref concepto);

                        FillConceptoIeps_Kit(empresaId, sucursalId, doctoId,
                                                desgloseiepsparent, mostrardescuentoparent, dataMovtoInfo, v_rec_movto,
                                                ref datosBD, ref impuestos_ieps);

                        FillConceptoIva_Kit(empresaId, sucursalId, doctoId,
                                                desgloseiepsparent, mostrardescuentoparent, dataMovtoInfo, v_rec_movto,
                                                ref datosBD, ref impuestos_ivas);

                    }


                    FillConceptoIsrRetenido(empresaId, sucursalId, doctoId,
                                            desgloseiepsparent, mostrardescuentoparent, dataMovtoInfo,
                                            ref datosBD, ref impuestos_isr_retenido);

                    FillConceptoIvaRetenido(empresaId, sucursalId, doctoId,
                                            desgloseiepsparent, mostrardescuentoparent, dataMovtoInfo,
                                            ref datosBD, ref impuestos_ivas_retenido);

                    concepto.ImpuestosTrasladados = new List<Traslado>();
                    concepto.ImpuestosTrasladados.AddRange(impuestos_ieps);
                    concepto.ImpuestosTrasladados.AddRange(impuestos_ivas);

                    concepto.ImpuestosRetenidos = new List<Traslado>();
                    concepto.ImpuestosRetenidos.AddRange(impuestos_ivas_retenido);
                    concepto.ImpuestosRetenidos.AddRange(impuestos_isr_retenido);

                    if (concepto.ImpuestosTrasladados.Count() == 0 && concepto.ImpuestosRetenidos.Count() == 0)
                        concepto.ObjetoImp = "01";

                    conceptos.Add(concepto);
                }

            }
        }



        public void FillConceptos_Consolidado(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    ApplicationDbContext localContext,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref List<Concepto> conceptos)
        {
            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";


            var doctosDentroDeConsolidado = localContext.Docto.AsNoTracking()
                                                         .Include(d => d.Docto_fact_elect_consolidacion)
                                                         .Include(d => d.Docto_devolucion)
                                                         .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId &&
                                                                     d.Docto_fact_elect_consolidacion!.Factconsid == doctoId)
                                                         .Select(d => new
                                                         {
                                                             d.Id,
                                                             d.Tipodoctoid,
                                                             d.Folio, d.Serie,
                                                             d.Docto_devolucion!.Doctorefid,
                                                             d.Docto_fact_elect_consolidacion!.Factconsaplicado,
                                                             d.Docto_fact_elect_consolidacion!.Consolidado_ieps,
                                                             d.Docto_fact_elect_consolidacion!.Consolidado_iva,
                                                             d.Docto_fact_elect_consolidacion!.Consolidado_isr_ret,
                                                             d.Docto_fact_elect_consolidacion!.Consolidado_iva_ret,
                                                             d.Docto_fact_elect_consolidacion!.Consolidado_subtotal,
                                                             d.Docto_fact_elect_consolidacion!.Consolidado_total
                                                         })
                                                         .ToList();



            var doctosImpuestosDentroDeConsolidado = localContext.Docto_impuestos.AsNoTracking()
                                                         .Include(d => d.Docto).ThenInclude(d => d.Docto_fact_elect_consolidacion)
                                                         .Include(d => d.Docto).ThenInclude(d => d.Docto_devolucion)
                                                         .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId &&
                                                                     d.Docto!.Docto_fact_elect_consolidacion!.Factconsid == doctoId)
                                                         .Select(d => new
                                                         {
                                                             d.Docto!.Id,
                                                             d.Docto.Tipodoctoid,
                                                             d.Docto.Docto_devolucion!.Doctorefid,
                                                             d.Docto.Docto_fact_elect_consolidacion!.Factconsaplicado,
                                                             d.Consolidado_Base,
                                                             d.Consolidado_Monto,
                                                             d.Tasaimpuesto,
                                                             d.Tipoimpuestoid
                                                         })
                                                         .ToList();

            if (doctosDentroDeConsolidado != null)
            {
                foreach (var v_rec_docto in doctosDentroDeConsolidado.Where(d => d.Tipodoctoid == 21))
                {


                    var devolucionesSumatorias = doctosDentroDeConsolidado
                                                .Where(d => d.Doctorefid == v_rec_docto.Id && d.Tipodoctoid == 22)
                                                .GroupBy(d => d.Doctorefid)
                                                .Select(d => new
                                                {
                                                    Consolidado_ieps = d.Sum(g => g.Consolidado_ieps),
                                                    Consolidado_iva = d.Sum(g => g.Consolidado_iva),
                                                    Consolidado_isr_ret = d.Sum(g => g.Consolidado_isr_ret),
                                                    Consolidado_iva_ret = d.Sum(g => g.Consolidado_iva_ret),
                                                    Consolidado_subtotal = d.Sum(g => g.Consolidado_subtotal),
                                                    Consolidado_total = d.Sum(g => g.Consolidado_total),

                                                }).FirstOrDefault();


                    Concepto concepto = new Concepto();



                    concepto.ObjetoImp = "02";
                    concepto.Cantidad = (1m).ToString("N2", nfi);
                    concepto.Unidad = "";
                    concepto.NoIdentificacion = v_rec_docto.Folio.ToString();
                    concepto.Descripcion = "Venta";


                    var bufferSubtotal = v_rec_docto.Consolidado_subtotal +
                                         (devolucionesSumatorias != null ? devolucionesSumatorias.Consolidado_subtotal : 0m);

                    if(!datosBD.V_desglosariepsmovto)
                        bufferSubtotal = bufferSubtotal + v_rec_docto.Consolidado_ieps +
                                         (devolucionesSumatorias != null ? devolucionesSumatorias.Consolidado_ieps: 0m);

                    concepto.ValorUnitario = bufferSubtotal.ToString("N2", nfi);
                    concepto.Importe = bufferSubtotal.ToString("N2", nfi);


                    concepto.CuentaPredial = "";
                    concepto.ClaveProdServ = "01010101";
                    concepto.ClaveUnidad = "ACT";
                    concepto.Descuento = (0m).ToString("N2", nfi);
                    concepto.MovtoId = null;
                    concepto.DoctoconceptoId = v_rec_docto.Id;


                    List<Traslado> impuestos_ieps = new List<Traslado>();
                    List<Traslado> impuestos_ivas = new List<Traslado>();
                    List<Traslado> impuestos_ivas_retenido = new List<Traslado>();
                    List<Traslado> impuestos_isr_retenido = new List<Traslado>();


                    //ieps
                    if (datosBD.V_desglosariepsmovto )
                    {
                        impuestos_ieps = doctosImpuestosDentroDeConsolidado.Where(d => ((d.Tipodoctoid == 21 && d.Id == v_rec_docto.Id) ||
                                                                      (d.Tipodoctoid == 22 && d.Doctorefid == v_rec_docto.Id)) &&
                                                                      d.Tipoimpuestoid == 3)
                                                          .GroupBy(d => new { d.Tasaimpuesto })
                                                          .Where(g => g.Sum(d => d.Consolidado_Monto) > 0m)
                                                          .Select(g => new Traslado()
                                                          {
                                                              ImpuestoVal = "003",
                                                              Tasa = g.Key.Tasaimpuesto.ToString("N2", nfi),
                                                              TasaCuota = (g.Key.Tasaimpuesto / 100.00m).ToString("N6", nfi),
                                                              Importe = g.Sum(d => d.Consolidado_Monto).ToString("N2", nfi),
                                                              TipoFactor = "Tasa",
                                                              BaseImp = g.Sum(d => d.Consolidado_Base).ToString("N2", nfi)

                                                          })
                                                          .ToList();

                    }

                    impuestos_ivas = doctosImpuestosDentroDeConsolidado.Where(d => ((d.Tipodoctoid == 21 && d.Id == v_rec_docto.Id) ||
                                                                  (d.Tipodoctoid == 22 && d.Doctorefid == v_rec_docto.Id)) &&
                                                                  d.Tipoimpuestoid == 2)
                                                      .GroupBy(d => new { d.Tasaimpuesto })
                                                      .Where(g => g.Sum(d => d.Consolidado_Monto) > 0m)
                                                      .Select(g => new Traslado()
                                                      {
                                                          ImpuestoVal = "002",
                                                          Tasa = g.Key.Tasaimpuesto.ToString("N2", nfi),
                                                          TasaCuota = (g.Key.Tasaimpuesto / 100.00m).ToString("N6", nfi),
                                                          Importe = g.Sum(d => d.Consolidado_Monto).ToString("N2", nfi),
                                                          TipoFactor = "Tasa",
                                                          BaseImp = g.Sum(d => d.Consolidado_Base).ToString("N2", nfi)

                                                      })
                                                      .ToList();


                    impuestos_ivas_retenido = doctosImpuestosDentroDeConsolidado.Where(d => ((d.Tipodoctoid == 21 && d.Id == v_rec_docto.Id) ||
                                                                  (d.Tipodoctoid == 22 && d.Doctorefid == v_rec_docto.Id)) &&
                                                                  d.Tipoimpuestoid == 1002)
                                                      .GroupBy(d => new { d.Tasaimpuesto })
                                                      .Where(g => g.Sum(d => d.Consolidado_Monto) > 0m)
                                                      .Select(g => new Traslado()
                                                      {
                                                          ImpuestoVal = "002",
                                                          Tasa = g.Key.Tasaimpuesto.ToString("N2", nfi),
                                                          TasaCuota = (g.Key.Tasaimpuesto / 100.00m).ToString("N6", nfi),
                                                          Importe = g.Sum(d => d.Consolidado_Monto).ToString("N2", nfi),
                                                          TipoFactor = "Tasa",
                                                          BaseImp = g.Sum(d => d.Consolidado_Base).ToString("N2", nfi)

                                                      })
                                                      .ToList();

                    impuestos_isr_retenido = doctosImpuestosDentroDeConsolidado.Where(d => ((d.Tipodoctoid == 21 && d.Id == v_rec_docto.Id) ||
                                                                  (d.Tipodoctoid == 22 && d.Doctorefid == v_rec_docto.Id)) &&
                                                                  d.Tipoimpuestoid == 1001)
                                                      .GroupBy(d => new { d.Tasaimpuesto })
                                                      .Where(g => g.Sum(d => d.Consolidado_Monto) > 0m)
                                                      .Select(g => new Traslado()
                                                      {
                                                          ImpuestoVal = "002",
                                                          Tasa = g.Key.Tasaimpuesto.ToString("N2", nfi),
                                                          TasaCuota = (g.Key.Tasaimpuesto / 100.00m).ToString("N6", nfi),
                                                          Importe = g.Sum(d => d.Consolidado_Monto).ToString("N2", nfi),
                                                          TipoFactor = "Tasa",
                                                          BaseImp = g.Sum(d => d.Consolidado_Base).ToString("N2", nfi)

                                                      })
                                                      .ToList();



                    concepto.ImpuestosTrasladados = new List<Traslado>();
                    concepto.ImpuestosTrasladados.AddRange(impuestos_ieps);
                    concepto.ImpuestosTrasladados.AddRange(impuestos_ivas);

                    concepto.ImpuestosRetenidos = new List<Traslado>();
                    concepto.ImpuestosRetenidos.AddRange(impuestos_ivas_retenido);
                    concepto.ImpuestosRetenidos.AddRange(impuestos_isr_retenido);

                    if (concepto.ImpuestosTrasladados.Count() == 0 && concepto.ImpuestosRetenidos.Count() == 0)
                        concepto.ObjetoImp = "01";

                    conceptos.Add(concepto);
                }

            }
        }

        public void FillConceptoIeps_Kit(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    DatosBD_MovtoInfo dataMovtoInfo,
                    Movto v_rec_movto,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref List<Traslado> impuestos_ieps)
        {

            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";

            Traslado impuesto = new Traslado();

            if(datosBD.V_desglosariepsmovto)
            {
                var v_rec_movtos_kit_ieps = v_rec_movto.Movto_kit_defs?
                                            .Where(m => m.Cantidadpartetotal > 0)
                                            .GroupBy(m => m.Tasaieps)
                                            .Select(m => new {
                                                Tasaieps = m.Key,
                                                Montoieps = m.Sum(p => p.Montoieps),
                                                BaseImpuestoIeps = m.Sum(p => p.Montosubtotal)
                                            })
                                            .ToList();
                if (v_rec_movtos_kit_ieps != null)
                {
                    foreach (var v_rec_movto_kit_ieps in v_rec_movtos_kit_ieps.Where(v => v.Montoieps > 0))
                    {
                        impuesto = new Traslado();
                        impuesto.ImpuestoVal = "003";
                        impuesto.Tasa = v_rec_movto_kit_ieps.Tasaieps.ToString("N2", nfi); 
                        impuesto.TasaCuota = (v_rec_movto_kit_ieps.Tasaieps / 100.00m).ToString("N6", nfi);
                        impuesto.Importe = v_rec_movto_kit_ieps.Montoieps.ToString("N2", nfi);
                        impuesto.TipoFactor = "Tasa";
                        impuesto.BaseImp = v_rec_movto_kit_ieps.BaseImpuestoIeps.ToString("N4", nfi);

                        impuestos_ieps.Add(impuesto);

                    }
                }
            }
        }
        public void FillConceptoIva_Kit(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    DatosBD_MovtoInfo dataMovtoInfo,
                    Movto v_rec_movto,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref List<Traslado> impuestos_ivas)
        {

            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";

            Traslado impuesto = new Traslado();

            var v_rec_movtos_kit_iva = v_rec_movto.Movto_kit_defs?
                                        .Where(m => m.Cantidadpartetotal > 0)
                                        .GroupBy(m => m.Tasaiva)
                                        .Select(m => new {
                                            Tasaiva = m.Key,
                                            Montoiva = m.Sum(p => p.Montoiva),
                                            BaseImpuestoIva = m.Sum(p => p.Montosubtotal + p.Montoieps)
                                        })
                                        .ToList();

            if (v_rec_movtos_kit_iva != null)
            {
                foreach (var v_rec_movto_kit_iva in v_rec_movtos_kit_iva.Where(v => v.Montoiva > 0))
                {
                    impuesto = new Traslado();
                    impuesto.ImpuestoVal = "002";
                    impuesto.Tasa = v_rec_movto_kit_iva.Tasaiva.ToString("N2", nfi);
                    impuesto.TasaCuota = (v_rec_movto_kit_iva.Tasaiva / 100.00m).ToString("N6", nfi);
                    impuesto.Importe = v_rec_movto_kit_iva.Montoiva.ToString("N2", nfi);
                    impuesto.TipoFactor = "Tasa";
                    impuesto.BaseImp = v_rec_movto_kit_iva.BaseImpuestoIva.ToString("N4", nfi);


                    impuestos_ivas.Add(impuesto);

                }
            }
        }



        public void FillConceptoIeps_NoKit(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    DatosBD_MovtoInfo dataMovtoInfo,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref List<Traslado> impuestos_ieps)
        {


            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";

            Traslado impuesto = new Traslado();

            //ieps
            if (datosBD.V_desglosariepsmovto && dataMovtoInfo.V_montoiepsmovto > 0m &&
                dataMovtoInfo.V_montoiepsmovto != 0m)
            {
                impuesto.ImpuestoVal = "003";
                impuesto.Tasa = dataMovtoInfo.V_porcentajeiepsmovto.ToString("N2", nfi);
                impuesto.TasaCuota = (dataMovtoInfo.V_porcentajeiepsmovto / 100.00m).ToString("N6", nfi);
                impuesto.Importe = dataMovtoInfo.V_montoiepsmovto.ToString("N2", nfi);
                impuesto.TipoFactor = "Tasa";
                impuesto.BaseImp = (dataMovtoInfo.V_subtotalmovto - dataMovtoInfo.V_descuentomovto).ToString("N4", nfi);
                impuestos_ieps.Add(impuesto);


            }
        }
        public void FillConceptoIva_NoKit(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    DatosBD_MovtoInfo dataMovtoInfo,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref List<Traslado> impuestos_ivas)
        {

            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";

            Traslado impuesto = new Traslado();

            //iva
            if (dataMovtoInfo.V_montoivamovto > 0m)
            {

                impuesto.ImpuestoVal = "002";
                impuesto.Tasa = dataMovtoInfo.V_porcentajeivamovto.ToString("N2", nfi); 
                impuesto.TasaCuota = (dataMovtoInfo.V_porcentajeivamovto / 100.00m).ToString("N6", nfi);
                impuesto.Importe = dataMovtoInfo.V_montoivamovto.ToString("N2", nfi); 
                impuesto.TipoFactor = "Tasa";
                impuesto.BaseImp = (dataMovtoInfo.V_subtotalmovto + dataMovtoInfo.V_montoiepsmovto - dataMovtoInfo.V_descuentomovto).ToString("N4", nfi); ;
                impuestos_ivas.Add(impuesto);


            }
        }

        public void FillConceptoIvaRetenido(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    DatosBD_MovtoInfo dataMovtoInfo,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref List<Traslado> impuestos_ivas_retenido)
        {

            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";

            Traslado impuesto = new Traslado();

            //retiene iva
            if (datosBD.V_personaretieneiva && datosBD.V_esarrendatario && dataMovtoInfo.V_montoivaretenidomovto  >= 0.01m)
            {
                impuesto.ImpuestoVal = "002";
                impuesto.Tasa = dataMovtoInfo.V_porcentajeivaretenidomovto.ToString("N2", nfi); 
                impuesto.TasaCuota = (dataMovtoInfo.V_porcentajeivaretenidomovto / 100.00m).ToString("N6", nfi);
                impuesto.Importe = dataMovtoInfo.V_montoivaretenidomovto.ToString("N2", nfi); 
                impuesto.TipoFactor = "Tasa";
                impuesto.BaseImp = (dataMovtoInfo.V_subtotalmovto - dataMovtoInfo.V_descuentomovto).ToString("N4", nfi); 

                impuestos_ivas_retenido.Add(impuesto);
            }
        }

        public void FillConceptoIsrRetenido(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    DatosBD_MovtoInfo dataMovtoInfo,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref List<Traslado> impuestos_isr_retenido)
        {
            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";

            Traslado impuesto = new Traslado();

            //retiene isr
            if (datosBD.V_personaretieneisr && datosBD.V_esarrendatario && dataMovtoInfo.V_montoisrretenidomovto >= 0.01m)
            {

                impuesto.ImpuestoVal = "001";
                impuesto.Tasa = dataMovtoInfo.V_porcentajeisrretenidomovto.ToString("N2", nfi);
                impuesto.TasaCuota = dataMovtoInfo.V_porcentajeisrretenidomovto.ToString("N6", nfi);
                impuesto.Importe = dataMovtoInfo.V_montoisrretenidomovto.ToString("N2", nfi);
                impuesto.TipoFactor = "Tasa";
                impuesto.BaseImp = (dataMovtoInfo.V_subtotalmovto - dataMovtoInfo.V_descuentomovto).ToString("N4", nfi);

                impuestos_isr_retenido.Add(impuesto);
            }
        }

        public void FillConceptos_Pagos(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref List<Concepto> conceptos)
        {

            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";


            string objImp = "01"; // (datosBD.PagosSat?.SelectMany(y => y.Pagodoctosats).Any(y => y.Objetoimpdr == "02") ?? false) ? "02" : "03";


            Concepto concepto = new Concepto();

            concepto.Cantidad =  (1m).ToString("N0", nfi);
            concepto.Unidad = "";
            concepto.Descripcion = "Pago";
            concepto.ValorUnitario = (0m).ToString("N0", nfi);
            concepto.Importe = (0m).ToString("N0", nfi);
            concepto.NoIdentificacion = "";
            concepto.CuentaPredial = "";
            concepto.ClaveProdServ = "84111506";
            concepto.ClaveUnidad = "ACT";
            concepto.Descuento = ""; // (0m).ToString("N2", nfi);

            concepto.ObjetoImp = objImp;

            conceptos.Add(concepto);
        }

        
        public void FillConceptos_venta_comprobantetraslado(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref List<Concepto> conceptos)
        {

            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";


            //string objImp = "01"; // (datosBD.PagosSat?.SelectMany(y => y.Pagodoctosats).Any(y => y.Objetoimpdr == "02") ?? false) ? "02" : "03";


            Concepto concepto = new Concepto();

            concepto.Cantidad =  (1m).ToString("N0", nfi);
            concepto.Unidad = "";
            concepto.Descripcion = "Servicio de traslado de mercancia";
            concepto.ValorUnitario = (0m).ToString("N0", nfi);
            concepto.Importe = (0m).ToString("N0", nfi);
            concepto.NoIdentificacion = "";
            concepto.CuentaPredial = "";
            concepto.ClaveProdServ = "78101802";
            concepto.ClaveUnidad = "E48";
            concepto.Descuento = ""; // (0m).ToString("N2", nfi);

            concepto.ObjetoImp = "03";

            conceptos.Add(concepto);
        }

        public void FillConceptos_Partes(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    DatosBD_MovtoInfo dataMovtoInfo,
                    Movto v_rec_movto,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref Concepto concepto)
        {
            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";

            concepto.ConceptoPartes = new List<ConceptoParte>();

            if (v_rec_movto.Movto_kit_defs != null)
            {

                foreach (var v_rec_movtokit in v_rec_movto.Movto_kit_defs.Where(m => m.Cantidadpartetotal > 0))
                {
                    ConceptoParte conceptoParte = new ConceptoParte();

                    conceptoParte.ClaveProdServ = v_rec_movtokit.Productoparte?.Producto_fact_elect?.Sat_productoservicio?.Clave ?? "";
                    conceptoParte.NoIdentificacion = v_rec_movtokit.Productoparte?.Clave ?? "";
                    conceptoParte.Cantidad = v_rec_movtokit.Cantidadpartetotal.ToString("N4", nfi);
                    conceptoParte.Unidad = v_rec_movtokit.Productoparte?.Unidad?.Sat_unidadmedida?.Sat_nombre ?? "";
                    conceptoParte.Descripcion = v_rec_movtokit.Productoparte?.Descripcion1 ?? "";
                    conceptoParte.ValorUnitario = (
                                    (
                                        //(datosBD.V_personadesglosaieps && datosBD.V_empresadesglosaieps) ||
                                        (datosBD.V_desglosariepsmovto) ||
                                        (desgloseiepsparent != null && desgloseiepsparent!.Value)
                                    ) ? v_rec_movtokit.Precioporunidad :
                                     (v_rec_movtokit.Montosubtotal + v_rec_movtokit.Montoieps) / v_rec_movtokit.Cantidadpartetotal
                                  ).ToString("N4", nfi);
                    conceptoParte.Importe = (v_rec_movtokit.Montosubtotal +
                                  (
                                    (
                                        //(datosBD.V_personadesglosaieps && datosBD.V_empresadesglosaieps) ||
                                        (datosBD.V_desglosariepsmovto) ||
                                        (desgloseiepsparent != null && desgloseiepsparent!.Value)
                                    ) ? 0m : v_rec_movtokit.Montoieps
                                  )).ToString("N4", nfi);
                    conceptoParte.NumeroPedimento = "";
                    conceptoParte.MovtoKitId = v_rec_movtokit.Movtoid;

                    concepto.ConceptoPartes.Add(conceptoParte);
                }
            }
        }

        public void FillPago(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref VirtualXmlHelperModel virtualXmlHelper)
        {
            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";

            List<PagoSAT> pagosSat = new List<PagoSAT>();
            if (datosBD.PagosSat != null)
            {

                foreach (var v_rec_pagosat in datosBD.PagosSat)
                {
                    PagoSAT pagoSat = new PagoSAT();
                    pagoSat.FechaPago = v_rec_pagosat.Fechapago?.ToLocalTime().ToDateTime().ToString("yyyy-MM-dd'T'HH:mm:ss") ?? ""; ;
                    pagoSat.FormaDePagoP = v_rec_pagosat.Formadepagop ?? "";
                    pagoSat.MonedaP = v_rec_pagosat.Monedap ?? "";
                    pagoSat.TipoCambioP = v_rec_pagosat.Tipocambiop.ToString("N0", nfi);
                    pagoSat.Monto = v_rec_pagosat.Monto.ToString("N2", nfi);
                    pagoSat.NumOperacion = v_rec_pagosat.Numoperacion ?? "";
                    pagoSat.RfcEmisorCtaOrd = v_rec_pagosat.Rfcemisorctaord ?? "";
                    pagoSat.NomBancoOrdExt = v_rec_pagosat.Nombancoordext ?? "";
                    pagoSat.CtaOrdenante = v_rec_pagosat.Ctaordenante ?? "";
                    pagoSat.RfcEmisorCtaBen = v_rec_pagosat.Rfcemisorctaben ?? "";
                    pagoSat.CtaBeneficiario = v_rec_pagosat.Ctabeneficiario ?? "";
                    pagoSat.TipoCadPago = v_rec_pagosat.Tipocadpago ?? "";
                    pagoSat.CertPago = v_rec_pagosat.Certpago ?? "";
                    pagoSat.CadPago = v_rec_pagosat.Cadpago ?? "";
                    pagoSat.SelloPago = v_rec_pagosat.Sellopago ?? "";
                    pagoSat.PagoSatId = v_rec_pagosat.Id;

                    pagoSat.DoctosImpRelacionados = new List<Pagodoctosat_imp>();

                    FillDoctoPago(empresaId, sucursalId, doctoId, desgloseiepsparent, mostrardescuentoparent,
                                   v_rec_pagosat, ref datosBD, ref pagoSat);

                    pagosSat.Add(pagoSat);
                }
            }
            virtualXmlHelper.PagosSat = pagosSat;
        }
        
        public void FillDoctoPago(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    Pagosat v_rec_pagosat,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref PagoSAT pagoSat)
        {


            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";


            List<PagoDoctoSAT> doctoPagosSat = new List<PagoDoctoSAT>();

            if (v_rec_pagosat.Pagodoctosats != null)
            {
                foreach (var v_rec_doctopagosat in v_rec_pagosat.Pagodoctosats)
                {
                    var doctoPagoSat = new PagoDoctoSAT();

                    doctoPagoSat.IdDocumento = v_rec_doctopagosat.Iddocumento ?? "";
                    doctoPagoSat.Serie = v_rec_doctopagosat.Serie ?? "";
                    doctoPagoSat.Folio = v_rec_doctopagosat.Folio ?? "";
                    doctoPagoSat.MonedaDR = v_rec_doctopagosat.Monedadr ?? "";
                    doctoPagoSat.TipoCambioDR = v_rec_doctopagosat.Tipocambiodr ?? "";
                    doctoPagoSat.MetodoDePagoDR = v_rec_doctopagosat.Metododepagodr ?? "";
                    doctoPagoSat.NumParcialidad = v_rec_doctopagosat.Numparcialidad?.ToString() ?? "";
                    doctoPagoSat.ImpSaldoAnt = v_rec_doctopagosat.Impsaldoant.ToString("N2", nfi);
                    doctoPagoSat.ImpPagado = v_rec_doctopagosat.Imppagado.ToString("N2", nfi);
                    doctoPagoSat.ImpSaldoInsoluto = v_rec_doctopagosat.Impsaldoinsoluto.ToString("N2", nfi);
                    doctoPagoSat.ObjetoImpDR =  v_rec_doctopagosat.Objetoimpdr ?? "";

                    doctoPagosSat.Add(doctoPagoSat);

                    if(v_rec_doctopagosat.Pagodoctosat_imps != null)
                        pagoSat.DoctosImpRelacionados?.AddRange(v_rec_doctopagosat.Pagodoctosat_imps);

                }

            }

            pagoSat.DoctosRelacionados = doctoPagosSat;


        }
        
        public void FillRelacionados(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref VirtualXmlHelperModel virtualXmlHelper)
        {


            Dictionary<String, List<String>> cfdiRelacionados = new Dictionary<String, List<String>>();

            if(datosBD.DoctoInfo!.Tipodoctoid!.Value == 21 && datosBD.Tipocomprobanteespecial == "T")
            {
                FillRelacionados_comprobantetrasl(empresaId, sucursalId, doctoId, desgloseiepsparent, mostrardescuentoparent,
                    ref datosBD, ref virtualXmlHelper, ref cfdiRelacionados);
            }
            if (datosBD.DoctoInfo!.Tipodoctoid!.Value == 22)
            {
                FillRelacionados_devoluciones(empresaId, sucursalId, doctoId, desgloseiepsparent, mostrardescuentoparent,
                    ref datosBD, ref virtualXmlHelper, ref cfdiRelacionados);
            }
            else if (datosBD.DoctoInfo!.Tipodoctoid!.Value == 21 && datosBD.DoctoInfo!.Subtipodoctoid != null && datosBD.DoctoInfo!.Subtipodoctoid.Value == 26)
            {
                FillRelacionados_sustituciones(empresaId, sucursalId, doctoId, desgloseiepsparent, mostrardescuentoparent,
                    ref datosBD, ref virtualXmlHelper, ref cfdiRelacionados);
            }


                virtualXmlHelper.CfdiRelacionados = cfdiRelacionados;
        }


        public void FillRelacionados_comprobantetrasl(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref VirtualXmlHelperModel virtualXmlHelper,
                    ref Dictionary<String, List<String>> cfdiRelacionados)
        {

            //ventas facturadas
            List<String> cfdiRelacionadosDevolucion = new List<string>();
                var uuid_venta = datosBD.DoctoInfo!.Docto_fact_elect?.Timbradouuid;

                if ((uuid_venta != null && uuid_venta != ""))
                {
                    cfdiRelacionados.Add("05", cfdiRelacionadosDevolucion);
                }

        }


        public void FillRelacionados_devoluciones(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref VirtualXmlHelperModel virtualXmlHelper,
                    ref Dictionary<String, List<String>> cfdiRelacionados)
        {

            //devoluciones
            List<String> cfdiRelacionadosDevolucion = new List<string>();
            if (datosBD.DoctoInfo!.Tipodoctoid!.Value == 22)
            {
                var uuid_devolucion = datosBD.DoctoInfo!.Docto_devolucion?.Doctoref?.Docto_fact_elect_consolidacion?.Factcons?.Docto_fact_elect?.Timbradouuid ??
                                    datosBD.DoctoInfo!.Docto_devolucion?.Doctoref?.Docto_fact_elect?.Timbradouuid;


                if ((uuid_devolucion != null && uuid_devolucion != ""))
                {
                    cfdiRelacionadosDevolucion.Add(uuid_devolucion);
                }
            }

            if (cfdiRelacionadosDevolucion.Count() > 0)
                cfdiRelacionados.Add("01", cfdiRelacionadosDevolucion);
        }


        public void FillRelacionados_sustituciones(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref VirtualXmlHelperModel virtualXmlHelper,
                    ref Dictionary<String, List<String>> cfdiRelacionados)
        {

            //sustituciones
            List<String> cfdiRelacionadosSustitucion = new List<string>();
            if (datosBD.DoctoInfo!.Tipodoctoid!.Value == 21 && datosBD.DoctoInfo!.Subtipodoctoid != null && datosBD.DoctoInfo!.Subtipodoctoid.Value == 26)
            {
                var uuid_sustitucion = datosBD.DoctoInfo!.Docto_fact_elect_sustitucion?.Doctoasustituir?.Docto_fact_elect?.Timbradouuid;


                if ((uuid_sustitucion != null && uuid_sustitucion != ""))
                {
                    cfdiRelacionadosSustitucion.Add(uuid_sustitucion);
                }

            }

            if (cfdiRelacionadosSustitucion.Count() > 0)
                cfdiRelacionados.Add("04", cfdiRelacionadosSustitucion);

        }

        public void FillComprobantesImpuestos(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref VirtualXmlHelperModel virtualXmlHelper)
        {
            List<Traslado> impuestosTrasladados = new List<Traslado>();
            List<Retencion> impuestosRetenidos = new List<Retencion>();


            List<Traslado> comprobantesIva = new List<Traslado>();
            List<Traslado> comprobantesIeps = new List<Traslado>();
            
            List<Retencion> comprobantesIvaRetenido = new List<Retencion>();
            List<Retencion> comprobantesIsrRetenido = new List<Retencion>();

            FillComprobanteIva(empresaId, sucursalId, doctoId,
                                desgloseiepsparent, mostrardescuentoparent,
                                ref datosBD, ref comprobantesIva);

            FillComprobanteIeps(empresaId, sucursalId, doctoId,
                                desgloseiepsparent, mostrardescuentoparent,
                                ref datosBD, ref comprobantesIeps);

            FillComprobanteIvaRetenido(empresaId, sucursalId, doctoId,
                                desgloseiepsparent, mostrardescuentoparent,
                                ref datosBD, ref comprobantesIvaRetenido);

            FillComprobanteIsrRetenido(empresaId, sucursalId, doctoId,
                                desgloseiepsparent, mostrardescuentoparent,
                                ref datosBD, ref comprobantesIsrRetenido);

            impuestosTrasladados.AddRange(comprobantesIva);
            impuestosTrasladados.AddRange(comprobantesIeps);
            impuestosRetenidos.AddRange(comprobantesIvaRetenido);
            impuestosRetenidos.AddRange(comprobantesIsrRetenido);


            virtualXmlHelper.ImpuestosTrasladados = impuestosTrasladados;
            virtualXmlHelper.ImpuestosRetenidos = impuestosRetenidos;

        }

        public void FillComprobanteIva(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref List<Traslado> comprobantesIva)
        {

            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";


            var doctoImpuestosIvaAgrupados = datosBD.DoctoInfo?.Docto_impuestos?
                     .Where(i => i.Tipoimpuestoid == 2)
                     .GroupBy(i => new { i.Tipoimpuestoid, i.Tasaimpuesto })
                     .Select(i => new {
                         i.Key.Tipoimpuestoid,
                         i.Key.Tasaimpuesto,
                         MontoImpuesto = i.Sum(j => i.Key.Tasaimpuesto > 0 ? j.Monto : 0),
                         BaseImp = i.Sum(j => j.Base)
                     })
                     .ToList();

            if (doctoImpuestosIvaAgrupados != null && doctoImpuestosIvaAgrupados.Count() > 0)
            {

                foreach (var v_rec_docto_iva in doctoImpuestosIvaAgrupados)
                {

                    Traslado impuesto = new Traslado();

                    impuesto.ImpuestoVal = "002";
                    impuesto.Tasa = v_rec_docto_iva.Tasaimpuesto.ToString("N2", nfi);
                    impuesto.TasaCuota = (v_rec_docto_iva.Tasaimpuesto / 100m).ToString("N6", nfi);
                    impuesto.Importe = v_rec_docto_iva.MontoImpuesto.ToString("N2", nfi);
                    impuesto.TipoFactor = "Tasa";
                    impuesto.BaseImp =v_rec_docto_iva.BaseImp.ToString("N2", nfi);


                    comprobantesIva.Add(impuesto);
                }
            }
            //else
            //{

            //    Traslado impuesto = new Traslado();

            //    impuesto.ImpuestoVal = "002";
            //    impuesto.Tasa = (0m).ToString("N2", nfi);
            //    impuesto.TasaCuota = (0m).ToString("N6", nfi);
            //    impuesto.Importe = (0m).ToString("N2", nfi);
            //    impuesto.TipoFactor = "Tasa";


            //    comprobantesIva.Add(impuesto);
            //}
        }

        public void FillComprobanteIeps(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref List<Traslado> comprobantesIeps)
        {

            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";

            bool v_desglosariepsmovto = datosBD.V_desglosariepsmovto;

            var doctoImpuestosIepsAgrupados = datosBD.DoctoInfo?.Docto_impuestos?
                     .Where(i => i.Tipoimpuestoid == 3 && v_desglosariepsmovto)
                     .GroupBy(i => new { i.Tipoimpuestoid, i.Tasaimpuesto })
                     .Select(i => new {
                         i.Key.Tipoimpuestoid,
                         i.Key.Tasaimpuesto,
                         MontoImpuesto = i.Sum(j => i.Key.Tasaimpuesto > 0 ? j.Monto : 0),
                         BaseImp = i.Sum(j => j.Base)
                     })
                     .ToList();

            if (doctoImpuestosIepsAgrupados != null)
            {

                foreach (var v_rec_docto_ieps in doctoImpuestosIepsAgrupados)
                {

                    Traslado impuesto = new Traslado();

                    impuesto.ImpuestoVal = "003";
                    impuesto.Tasa = v_rec_docto_ieps.Tasaimpuesto.ToString("N2", nfi);
                    impuesto.TasaCuota = (v_rec_docto_ieps.Tasaimpuesto / 100m).ToString("N6", nfi);
                    impuesto.Importe = v_rec_docto_ieps.MontoImpuesto.ToString("N2", nfi);
                    impuesto.TipoFactor = "Tasa";
                    impuesto.BaseImp = v_rec_docto_ieps.BaseImp.ToString("N2", nfi);


                    comprobantesIeps.Add(impuesto);
                }
            }


        }

        public void FillComprobanteIvaRetenido(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref List<Retencion> comprobantesIvaRetenido)
        {
            if (!datosBD.V_personaretieneiva || !datosBD.V_esarrendatario)
                return;

            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";


            var doctoImpuestosIvaRetenidoAgrupados = datosBD.DoctoInfo?.Docto_impuestos?
                     .Where(i => i.Tipoimpuestoid == 1002)
                     .GroupBy(i => new { i.Tipoimpuestoid, i.Tasaimpuesto })
                     .Select(i => new {
                         i.Key.Tipoimpuestoid,
                         i.Key.Tasaimpuesto,
                         MontoImpuesto = i.Sum(j => i.Key.Tasaimpuesto > 0 ? j.Monto : 0),
                         BaseImp = i.Sum(j => j.Base)
                     })
                     .ToList();

            if (doctoImpuestosIvaRetenidoAgrupados != null)
            {
                foreach (var v_rec_docto_iva_retenido in doctoImpuestosIvaRetenidoAgrupados)
                {
                    Retencion impuesto = new Retencion();


                    impuesto.ImpuestoVal = "002";
                    impuesto.Tasa = v_rec_docto_iva_retenido.Tasaimpuesto.ToString("N2", nfi);
                    impuesto.TasaCuota = (v_rec_docto_iva_retenido.Tasaimpuesto / 100m).ToString("N6", nfi);
                    impuesto.Importe = v_rec_docto_iva_retenido.MontoImpuesto.ToString("N2", nfi);
                    impuesto.TipoFactor = "Tasa";
                    impuesto.BaseImp = v_rec_docto_iva_retenido.BaseImp.ToString("N2", nfi);


                    comprobantesIvaRetenido.Add(impuesto);
                }
            }
        }

        public void FillComprobanteIsrRetenido(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref List<Retencion> comprobantesIsrRetenido)
        {

            if (!datosBD.V_personaretieneiva || !datosBD.V_esarrendatario)
                return;

            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";


            var doctoImpuestosIsrRetenidoAgrupados = datosBD.DoctoInfo?.Docto_impuestos?
                     .Where(i => i.Tipoimpuestoid == 1001)
                     .GroupBy(i => new { i.Tipoimpuestoid, i.Tasaimpuesto })
                     .Select(i => new {
                         i.Key.Tipoimpuestoid,
                         i.Key.Tasaimpuesto,
                         MontoImpuesto = i.Sum(j => i.Key.Tasaimpuesto > 0 ? j.Monto : 0),
                         BaseImp = i.Sum(j => j.Base)
                     })
                     .ToList();

            if (doctoImpuestosIsrRetenidoAgrupados != null)
            {
                foreach (var v_rec_docto_isr_retenido in doctoImpuestosIsrRetenidoAgrupados)
                {

                    Retencion impuesto = new Retencion();


                    impuesto.ImpuestoVal = "001";
                    impuesto.Tasa = v_rec_docto_isr_retenido.Tasaimpuesto.ToString("N2", nfi);
                    impuesto.TasaCuota = (v_rec_docto_isr_retenido.Tasaimpuesto / 100m).ToString("N6", nfi);
                    impuesto.Importe = v_rec_docto_isr_retenido.MontoImpuesto.ToString("N2", nfi);
                    impuesto.TipoFactor = "Tasa";
                    impuesto.BaseImp = v_rec_docto_isr_retenido.BaseImp.ToString("N2", nfi);


                    comprobantesIsrRetenido.Add(impuesto);
                }
            }
        }


        public void FillComprobanteTrasladosRetenciones(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref VirtualXmlHelperModel virtualXmlHelper)
        {
            

            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";

            ImpuestosInfo impuestosInfo = new ImpuestosInfo();

            bool v_desglosariepsmovto = datosBD.V_desglosariepsmovto;


            var bufferTraslados = datosBD.DoctoInfo?.Docto_impuestos?
                     .Where(i => i.Tipoimpuestoid.In(2, 3) && (i.Tipoimpuestoid != 3 || v_desglosariepsmovto))
                     .ToList();

            if (bufferTraslados == null || bufferTraslados.Count() == 0)
                impuestosInfo.TotalTraslados = "";

            else
                impuestosInfo.TotalTraslados = bufferTraslados.Sum(i => i.Monto).ToString("N2", nfi) ?? "0.00";

            //impuestosInfo.TotalTraslados = datosBD.DoctoInfo?.Docto_impuestos?
            //         .Where(i => i.Tipoimpuestoid.In(2, 3) && (i.Tipoimpuestoid != 3 || v_desglosariepsmovto))
            //         .Sum(i => i.Monto).ToString("N2", nfi) ?? "0.00";

            if (datosBD.V_personaretieneiva && datosBD.V_esarrendatario)
            {
                var bufferRetenciones = datosBD.DoctoInfo?.Docto_impuestos?
                         .Where(i => i.Tipoimpuestoid.In(1001, 1002))
                         .ToList();

                if (bufferRetenciones == null || bufferRetenciones.Count() == 0)
                    impuestosInfo.TotalRetenciones = "";

                else
                    impuestosInfo.TotalRetenciones = bufferRetenciones.Sum(i => i.Monto).ToString("N2", nfi) ?? "0.00";

                //impuestosInfo.TotalRetenciones = datosBD.DoctoInfo?.Docto_impuestos?
                //         .Where(i => i.Tipoimpuestoid.In(1001, 1002))
                //         .Sum(i => i.Monto).ToString("N2", nfi) ?? "0.00";
            }
            else
            {
                impuestosInfo.TotalRetenciones = "";
            }

            virtualXmlHelper.ImpuestosInfo = impuestosInfo;
        }


        public void FillCartaporte(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    ApplicationDbContext localContext,
                    ref DatosBD_FacturaElectronica datosBD,
                    ref VirtualXmlHelperModel virtualXmlHelper)
        {
            
            
            var cartaPorteBM = _cartaporteFacturaElectronicaService.CartaPorteDeTransaccion(
                    empresaId,
                    sucursalId,
                    doctoId,
                    localContext);
            virtualXmlHelper.ICARTAPORTE = cartaPorteBM;
        }


        public bool Facturacion_GuardarDatosTimbrado(TimbradoInfo timbradoInfo,  ApplicationDbContext localContext, out string message)
        {

            message = "";


            var doctoAFacturar = localContext.Docto.Include(d => d.Docto_fact_elect)
                                                     .FirstOrDefault(d => d.EmpresaId == timbradoInfo.EmpresaId && d.SucursalId == timbradoInfo.SucursalId &&
                                                                 d.Id == timbradoInfo.DoctoId);

            if (doctoAFacturar == null)
            {
                message = "Docto no encontrado";
                return false;
            }




            if (timbradoInfo.Tipocomprobanteespecial == null || timbradoInfo.Tipocomprobanteespecial != "T")
            {
                if (doctoAFacturar.Docto_fact_elect != null )
                {

                    doctoAFacturar.Docto_fact_elect.Timbradouuid = timbradoInfo.Timbradouuid;
                    doctoAFacturar.Docto_fact_elect.Timbradofecha = timbradoInfo.Timbradofecha;
                    doctoAFacturar.Docto_fact_elect.Timbradocertsat = timbradoInfo.Timbradocertsat;
                    doctoAFacturar.Docto_fact_elect.Timbradosellosat = timbradoInfo.Timbradosellosat;
                    doctoAFacturar.Docto_fact_elect.Timbradosellocfdi = timbradoInfo.Timbradosellocfdi;
                    doctoAFacturar.Docto_fact_elect.Timbradoformapagosat = timbradoInfo.Timbradoformapagosat;
                    doctoAFacturar.Docto_fact_elect.Esfacturaelectronica = BoolCN.S;
                    localContext.Update(doctoAFacturar.Docto_fact_elect);
                }
                else
                {
                    doctoAFacturar.Docto_fact_elect = new Docto_fact_elect()
                    {
                        EmpresaId = timbradoInfo.EmpresaId,
                        SucursalId = timbradoInfo.SucursalId,
                        Doctoid = timbradoInfo.DoctoId,
                        Timbradouuid = timbradoInfo.Timbradouuid,
                        Timbradofecha = timbradoInfo.Timbradofecha,
                        Timbradocertsat = timbradoInfo.Timbradocertsat,
                        Timbradosellosat = timbradoInfo.Timbradosellosat,
                        Timbradosellocfdi = timbradoInfo.Timbradosellocfdi,
                        Timbradoformapagosat = timbradoInfo.Timbradoformapagosat,
                        Esfacturaelectronica = BoolCN.S

                    };
                    localContext.Add(doctoAFacturar.Docto_fact_elect);




                }

                DateTimeOffset fechaFactura = DateTime.Parse(timbradoInfo.Timbradofecha!);
                doctoAFacturar.Fecha = fechaFactura.DateTime.Date;
                doctoAFacturar.Fechahora = fechaFactura;
                localContext.Update(doctoAFacturar);
                localContext.SaveChanges();
            }
            else
            {
                var doctoComprobante = doctoAFacturar?.Docto_comprobantes?.FirstOrDefault(y => y.Tipocomprobante == timbradoInfo.Tipocomprobanteespecial);
                if (doctoComprobante != null)
                {

                    doctoComprobante.Timbradouuid = timbradoInfo.Timbradouuid;
                    doctoComprobante.Timbradofecha = timbradoInfo.Timbradofecha;
                    doctoComprobante.Timbradocertsat = timbradoInfo.Timbradocertsat;
                    doctoComprobante.Timbradosellosat = timbradoInfo.Timbradosellosat;
                    doctoComprobante.Timbradosellocfdi = timbradoInfo.Timbradosellocfdi;

                    localContext.Doctocomprobante.Update(doctoComprobante);
                }
                else 
                {
                    var doctoComprobanteElectronico = new Doctocomprobante()
                    {
                        EmpresaId = timbradoInfo.EmpresaId,
                        SucursalId = timbradoInfo.SucursalId,
                        Doctoid = timbradoInfo.DoctoId,
                        Timbradouuid = timbradoInfo.Timbradouuid,
                        Timbradofecha = timbradoInfo.Timbradofecha,
                        Timbradocertsat = timbradoInfo.Timbradocertsat,
                        Timbradosellosat = timbradoInfo.Timbradosellosat,
                        Timbradosellocfdi = timbradoInfo.Timbradosellocfdi

                    };

                    localContext.Doctocomprobante.Add(doctoComprobanteElectronico);

                }

                localContext.SaveChanges();
            }

            return true;
        }



        public bool Factura_Electronica_GuardarCfdiInfo(TimbradoInfo timbradoInfo, ApplicationDbContext localContext,  out string message)
        {

            message = "";


            VirtualXmlHelperModel virtualXmlHelper = new VirtualXmlHelperModel();
            Factura_Electronica_FillAll(timbradoInfo.EmpresaId, timbradoInfo.SucursalId, timbradoInfo.DoctoId,
                    "", true, timbradoInfo.Tipocomprobanteespecial, timbradoInfo.Generarcartaporte,
                    localContext,  out message, out virtualXmlHelper);


            Cfdi cfdi = new Cfdi();

            cfdi.EmpresaId = timbradoInfo.EmpresaId;
            cfdi.SucursalId = timbradoInfo.SucursalId;
            cfdi.Doctoid = timbradoInfo.DoctoId;


            if (virtualXmlHelper.ComprobanteInfo != null)
            {
                cfdi.Serie = virtualXmlHelper.ComprobanteInfo?.Serie;
                cfdi.Folio = virtualXmlHelper.ComprobanteInfo?.Folio;
                cfdi.Tipocomprobante = virtualXmlHelper.ComprobanteInfo?.TipoComprobante;
                cfdi.Formapago = virtualXmlHelper.ComprobanteInfo?.FormaPago;
                cfdi.Moneda = virtualXmlHelper.ComprobanteInfo?.Moneda;
                cfdi.Tipocambio = virtualXmlHelper.ComprobanteInfo?.TipoCambio;
                cfdi.Condicionespago = virtualXmlHelper.ComprobanteInfo?.CondicionesPago;
                cfdi.Metodopago = virtualXmlHelper.ComprobanteInfo?.MetodoPago;
                cfdi.Motivodescuento = virtualXmlHelper.ComprobanteInfo?.MotivoDescuento;
                cfdi.Lugarexpedicion = virtualXmlHelper.ComprobanteInfo?.LugarExpedicion;



                cfdi.Subtotal = decimal.Parse(virtualXmlHelper.ComprobanteInfo?.Subtotal ?? "0.00");

                if (string.IsNullOrEmpty(virtualXmlHelper.ComprobanteInfo?.Descuento))
                    cfdi.Descuento = 0.00m;
                else 
                    cfdi.Descuento = decimal.Parse(virtualXmlHelper.ComprobanteInfo?.Descuento ?? "0.00");
           
                cfdi.Total = decimal.Parse(virtualXmlHelper.ComprobanteInfo?.Total ?? "0.00");

            }

            if (virtualXmlHelper.ComprobanteInfoEx != null)
            {

                cfdi.Ex_lugarexpedicion = virtualXmlHelper.ComprobanteInfoEx?.LugarExpedicion;
                cfdi.Ex_numeroctapago = virtualXmlHelper.ComprobanteInfoEx?.NumeroCtaPago;
                cfdi.Ex_seriefoliofiscaloriginal = virtualXmlHelper.ComprobanteInfoEx?.SerieFolioFiscalOriginal;
                cfdi.Ex_foliofiscaloriginal = virtualXmlHelper.ComprobanteInfoEx?.FolioFiscalOriginal;
            }

            if (virtualXmlHelper.EmisorInfo != null)
            {
                cfdi.Em_rfc = virtualXmlHelper.EmisorInfo?.Rfc;
                cfdi.Em_razonsocial = virtualXmlHelper.EmisorInfo?.RazonSocial;
                cfdi.Em_regimenfiscal = virtualXmlHelper.EmisorInfo?.RegimenFiscal;

                if (virtualXmlHelper.EmisorInfo?.Domicilio != null)
                {
                    cfdi.Em_calle = virtualXmlHelper.EmisorInfo?.Domicilio?.Calle;
                    cfdi.Em_noexterior = virtualXmlHelper.EmisorInfo?.Domicilio?.NoExterior;
                    cfdi.Em_nointerior = virtualXmlHelper.EmisorInfo?.Domicilio?.NoInterior;
                    cfdi.Em_colonia = virtualXmlHelper.EmisorInfo?.Domicilio?.Colonia;
                    cfdi.Em_localidad = virtualXmlHelper.EmisorInfo?.Domicilio?.Localidad;
                    cfdi.Em_referencia = virtualXmlHelper.EmisorInfo?.Domicilio?.Referencia;
                    cfdi.Em_municipio = virtualXmlHelper.EmisorInfo?.Domicilio?.Municipio;
                    cfdi.Em_estado = virtualXmlHelper.EmisorInfo?.Domicilio?.Estado;
                    cfdi.Em_pais = virtualXmlHelper.EmisorInfo?.Domicilio?.Pais;
                    cfdi.Em_codigopostal = virtualXmlHelper.EmisorInfo?.Domicilio?.CodigoPostal;
                }
            }


            if (virtualXmlHelper.EmisorExpedidoEn != null)
            {
                cfdi.Ee_calle = virtualXmlHelper.EmisorExpedidoEn?.Calle;
                cfdi.Ee_noexterior = virtualXmlHelper.EmisorExpedidoEn?.NoExterior;
                cfdi.Ee_nointerior = virtualXmlHelper.EmisorExpedidoEn?.NoInterior;
                cfdi.Ee_colonia = virtualXmlHelper.EmisorExpedidoEn?.Colonia;
                cfdi.Ee_localidad = virtualXmlHelper.EmisorExpedidoEn?.Localidad;
                cfdi.Ee_referencia = virtualXmlHelper.EmisorExpedidoEn?.Referencia;
                cfdi.Ee_municipio = virtualXmlHelper.EmisorExpedidoEn?.Municipio;
                cfdi.Ee_estado = virtualXmlHelper.EmisorExpedidoEn?.Estado;
                cfdi.Ee_pais = virtualXmlHelper.EmisorExpedidoEn?.Pais;
                cfdi.Ee_codigopostal = virtualXmlHelper.EmisorExpedidoEn?.CodigoPostal;
            }

            if (virtualXmlHelper.ReceptorInfo != null)
            {
                cfdi.Rc_rfc = virtualXmlHelper.ReceptorInfo?.Rfc;
                cfdi.Rc_razonsocial = virtualXmlHelper.ReceptorInfo?.RazonSocial;
                cfdi.Rc_residenciafiscal = virtualXmlHelper.ReceptorInfo?.ResidenciaFiscal;
                cfdi.Rc_nombre = virtualXmlHelper.ReceptorInfo?.Nombre;
                cfdi.Rc_numregidtrib = virtualXmlHelper.ReceptorInfo?.NumRegIdTrib;
                cfdi.Rc_usocfdi = virtualXmlHelper.ReceptorInfo?.UsoCFDI;

                if (virtualXmlHelper.ReceptorInfo?.Domicilio != null)
                {
                    cfdi.Rc_calle = virtualXmlHelper.ReceptorInfo?.Domicilio?.Calle;
                    cfdi.Rc_noexterior = virtualXmlHelper.ReceptorInfo?.Domicilio?.NoExterior;
                    cfdi.Rc_nointerior = virtualXmlHelper.ReceptorInfo?.Domicilio?.NoInterior;
                    cfdi.Rc_colonia = virtualXmlHelper.ReceptorInfo?.Domicilio?.Colonia;
                    cfdi.Rc_localidad = virtualXmlHelper.ReceptorInfo?.Domicilio?.Localidad;
                    cfdi.Rc_referencia = virtualXmlHelper.ReceptorInfo?.Domicilio?.Referencia;
                    cfdi.Rc_municipio = virtualXmlHelper.ReceptorInfo?.Domicilio?.Municipio;
                    cfdi.Rc_estado = virtualXmlHelper.ReceptorInfo?.Domicilio?.Estado;
                    cfdi.Rc_pais = virtualXmlHelper.ReceptorInfo?.Domicilio?.Pais;
                    cfdi.Rc_codigopostal = virtualXmlHelper.ReceptorInfo?.Domicilio?.CodigoPostal;
                }
            }

            localContext.Add(cfdi);

            localContext.SaveChanges();

            decimal bufferCantidad = 0m;
            DateTimeOffset bufferFecha ;

            cfdi.Cfdi_conceptos = new List<Cfdi_conc>();
            cfdi.Cfdi_impuestos = new List<Cfdi_imp>();
            cfdi.Cfdi_relacionados = new List<Cfdi_rel>();


            if (timbradoInfo.Tipocomprobanteespecial != "T" && virtualXmlHelper.Conceptos != null)
            {
                int consecutivoConcepto = 0;
                foreach (var concepto in virtualXmlHelper.Conceptos)
                {
                    Cfdi_conc cfdi_conc = new Cfdi_conc();
                    cfdi_conc.EmpresaId = timbradoInfo.EmpresaId;
                    cfdi_conc.SucursalId = timbradoInfo.SucursalId;
                    cfdi_conc.Cfdiid = cfdi.Id;
                    cfdi_conc.Unidad = concepto.Unidad;
                    cfdi_conc.Descripcion = concepto.Descripcion;
                    cfdi_conc.Noidentificacion = concepto.NoIdentificacion;
                    cfdi_conc.Cuentapredial = concepto.CuentaPredial;
                    cfdi_conc.Claveprodserv = concepto.ClaveProdServ;
                    cfdi_conc.Claveunidad = concepto.ClaveUnidad;

                    if (decimal.TryParse(concepto.Cantidad, out bufferCantidad))
                        cfdi_conc.Cantidad = bufferCantidad;

                    if (decimal.TryParse(concepto.ValorUnitario, out bufferCantidad))
                        cfdi_conc.Valorunitario = bufferCantidad;


                    if (decimal.TryParse(concepto.Importe, out bufferCantidad))
                        cfdi_conc.Importe = bufferCantidad;


                    if (decimal.TryParse(concepto.Descuento, out bufferCantidad))
                        cfdi_conc.Descuento = bufferCantidad;

                    cfdi_conc.Movtoid = concepto.MovtoId;
                    cfdi_conc.Doctoconceptoid = concepto.DoctoconceptoId;
                    cfdi_conc.Consecutivo = ++consecutivoConcepto;
                    cfdi_conc.Objetoimp = concepto.ObjetoImp;

                    cfdi.Cfdi_conceptos.Add(cfdi_conc);

                    localContext.Add(cfdi_conc);

                    localContext.SaveChanges();

                    cfdi_conc.ConceptoPartes = new List<Cfdi_conc_part>();
                    cfdi_conc.Impuestos = new List<Cfdi_conc_imp>();
                    cfdi_conc.InformacionesAduaneras = new List<Cfdi_conc_adu>();

                    if (concepto.ConceptoPartes != null)
                    {
                        foreach (var parte in concepto.ConceptoPartes)
                        {
                            Cfdi_conc_part cfdi_conc_part = new Cfdi_conc_part();
                            cfdi_conc_part.EmpresaId = timbradoInfo.EmpresaId;
                            cfdi_conc_part.SucursalId = timbradoInfo.SucursalId;



                            cfdi_conc_part.Claveprodserv = parte.ClaveProdServ;
                            cfdi_conc_part.Noidentificacion = parte.NoIdentificacion;
                            cfdi_conc_part.Unidad = parte.Unidad;
                            cfdi_conc_part.Descripcion = parte.Descripcion;
                            cfdi_conc_part.Numeropedimento = parte.NumeroPedimento;

                            if (decimal.TryParse(parte.Cantidad, out bufferCantidad))
                                cfdi_conc_part.Cantidad = bufferCantidad;

                            if (decimal.TryParse(parte.ValorUnitario, out bufferCantidad))
                                cfdi_conc_part.Valorunitario = bufferCantidad;

                            if (decimal.TryParse(parte.Importe, out bufferCantidad))
                                cfdi_conc_part.Importe = bufferCantidad;

                            cfdi_conc_part.Cfdi_conc_id = cfdi_conc.Id;
                            cfdi_conc_part.Movtokitid = parte.MovtoKitId;


                            cfdi_conc.ConceptoPartes.Add(cfdi_conc_part);

                            localContext.Add(cfdi_conc_part);


                        }
                    }

                    if (concepto.ImpuestosRetenidos != null)
                    {
                        foreach (var impuesto in concepto.ImpuestosRetenidos)
                        {
                            Cfdi_conc_imp conc_imp = new Cfdi_conc_imp();
                            conc_imp.EmpresaId = timbradoInfo.EmpresaId;
                            conc_imp.SucursalId = timbradoInfo.SucursalId;
                            conc_imp.Cfdi_conc_id = cfdi_conc.Cfdiid;

                            switch (impuesto.ImpuestoVal)
                            {
                                case "001":
                                    {
                                        conc_imp.Tipolinea = "CONCEPTO_ISRRETENIDO";
                                        break;
                                    }
                                case "002":
                                    {
                                        conc_imp.Tipolinea = "CONCEPTO_IVARETENIDO";
                                        break;
                                    }
                            }


                            conc_imp.Tipofactor = impuesto.TipoFactor;
                            conc_imp.Tasacuota = impuesto.TasaCuota;
                            conc_imp.Impuesto = impuesto.ImpuestoVal;

                            if (decimal.TryParse(impuesto.BaseImp, out bufferCantidad))
                                conc_imp.Baseimp = bufferCantidad;

                            if (decimal.TryParse(impuesto.Tasa, out bufferCantidad))
                                conc_imp.Tasa = bufferCantidad;

                            if (decimal.TryParse(impuesto.Importe, out bufferCantidad))
                                conc_imp.Importe = bufferCantidad;



                            cfdi_conc.Impuestos.Add(conc_imp);

                            localContext.Add(conc_imp);


                        }
                    }

                    if (concepto.ImpuestosTrasladados != null)
                    {
                        foreach (var impuesto in concepto.ImpuestosTrasladados)
                        {

                            Cfdi_conc_imp conc_imp = new Cfdi_conc_imp();
                            conc_imp.EmpresaId = timbradoInfo.EmpresaId;
                            conc_imp.SucursalId = timbradoInfo.SucursalId;
                            conc_imp.Cfdi_conc_id = cfdi_conc.Cfdiid;

                            switch (impuesto.ImpuestoVal)
                            {
                                case "003":
                                    {
                                        conc_imp.Tipolinea = "CONCEPTO_IEPS";
                                        break;
                                    }
                                case "002":
                                    {
                                        conc_imp.Tipolinea = "CONCEPTO_IVA";
                                        break;
                                    }
                            }


                            conc_imp.Tipofactor = impuesto.TipoFactor;
                            conc_imp.Tasacuota = impuesto.TasaCuota;
                            conc_imp.Impuesto = impuesto.ImpuestoVal;

                            if (decimal.TryParse(impuesto.BaseImp, out bufferCantidad))
                                conc_imp.Baseimp = bufferCantidad;

                            if (decimal.TryParse(impuesto.Tasa, out bufferCantidad))
                                conc_imp.Tasa = bufferCantidad;

                            if (decimal.TryParse(impuesto.Importe, out bufferCantidad))
                                conc_imp.Importe = bufferCantidad;



                            cfdi_conc.Impuestos.Add(conc_imp);

                            localContext.Add(conc_imp);
                        }
                    }

                    if (concepto.InfoAduanera != null)
                    {
                        foreach (var infoAduanera in concepto.InfoAduanera)
                        {
                            Cfdi_conc_adu cfdi_adu = new Cfdi_conc_adu()
                            {
                                EmpresaId = timbradoInfo.EmpresaId,
                                SucursalId = timbradoInfo.SucursalId,
                                Cfdi_conc_id = cfdi_conc.Id,
                                Numero = infoAduanera.Numero,
                                Aduana = infoAduanera.Aduana
                            };


                            if (DateTimeOffset.TryParse(infoAduanera.Fecha, out bufferFecha))
                                cfdi_adu.Fecha = bufferFecha;

                            cfdi_conc.InformacionesAduaneras.Add(cfdi_adu);
                            localContext.Add(cfdi_adu);
                        }
                    }


                    localContext.Update(cfdi_conc);
                }

                localContext.SaveChanges();
            }

            if (virtualXmlHelper.PagosSat != null)
            {
                foreach (var pago in virtualXmlHelper.PagosSat)
                {

                    var pagoSat = localContext.Pagosat.FirstOrDefault(p => p.EmpresaId == timbradoInfo.EmpresaId && p.SucursalId == timbradoInfo.SucursalId &&
                                                             p.Id == pago.PagoSatId);

                    if (pagoSat != null)
                    {
                        pagoSat.Cfdiid = cfdi.Id;
                        localContext.Update(pagoSat);

                    }

                }
            }


            if (virtualXmlHelper.CfdiRelacionados != null && timbradoInfo.Tipocomprobanteespecial != "T")
            {
                foreach (var relacionadoList in virtualXmlHelper.CfdiRelacionados)
                {
                    foreach (var relacionado in relacionadoList.Value)
                    {
                        Cfdi_rel cfdi_rel = new Cfdi_rel();
                        cfdi_rel.EmpresaId = timbradoInfo.EmpresaId;
                        cfdi_rel.SucursalId = timbradoInfo.SucursalId;
                        cfdi_rel.Cfdiid = cfdi.Id;
                        cfdi_rel.Uuid = relacionado;
                        cfdi_rel.Tiporelacion = relacionadoList.Key;


                        cfdi.Cfdi_relacionados.Add(cfdi_rel);

                        localContext.Add(cfdi_rel);
                    }

                }
            }



            if (virtualXmlHelper.ImpuestosTrasladados != null && timbradoInfo.Tipocomprobanteespecial != "T")
            {
                foreach (var impuesto in virtualXmlHelper.ImpuestosTrasladados)
                {
                    Cfdi_imp cfdi_imp = new Cfdi_imp();
                    cfdi_imp.EmpresaId = timbradoInfo.EmpresaId;
                    cfdi_imp.SucursalId = timbradoInfo.SucursalId;
                    cfdi_imp.Cfdiid = cfdi.Id;

                    switch (impuesto.ImpuestoVal)
                    {
                        case "003":
                            {
                                cfdi_imp.Tipolinea = "COMPROBANTE_IEPS";
                                break;
                            }
                        case "002":
                            {
                                cfdi_imp.Tipolinea = "COMPROBANTE_IVA";
                                break;
                            }
                    }


                    cfdi_imp.Tipofactor = impuesto.TipoFactor;
                    cfdi_imp.Tasacuota = impuesto.TasaCuota;
                    cfdi_imp.Impuesto = impuesto.ImpuestoVal;

                    if (decimal.TryParse(impuesto.BaseImp, out bufferCantidad))
                        cfdi_imp.Baseimp = bufferCantidad;

                    if (decimal.TryParse(impuesto.Tasa, out bufferCantidad))
                        cfdi_imp.Tasa = bufferCantidad;

                    if (decimal.TryParse(impuesto.Importe, out bufferCantidad))
                        cfdi_imp.Importe = bufferCantidad;

                    cfdi.Cfdi_impuestos.Add(cfdi_imp);

                    localContext.Add(cfdi_imp);

                }
            }


            if (virtualXmlHelper.ImpuestosRetenidos != null && timbradoInfo.Tipocomprobanteespecial != "T")
            {
                foreach (var impuesto in virtualXmlHelper.ImpuestosRetenidos)
                {

                    Cfdi_imp cfdi_imp = new Cfdi_imp();
                    cfdi_imp.EmpresaId = timbradoInfo.EmpresaId;
                    cfdi_imp.SucursalId = timbradoInfo.SucursalId;
                    cfdi_imp.Cfdiid = cfdi.Id;

                    switch (impuesto.ImpuestoVal)
                    {
                        case "001":
                            {
                                cfdi_imp.Tipolinea = "COMPROBANTE_ISRRETENIDO";
                                break;
                            }
                        case "002":
                            {
                                cfdi_imp.Tipolinea = "COMPROBANTE_IVARETENIDO";
                                break;
                            }
                    }


                    cfdi_imp.Tipofactor = impuesto.TipoFactor;
                    cfdi_imp.Tasacuota = impuesto.TasaCuota;
                    cfdi_imp.Impuesto = impuesto.ImpuestoVal;

                    //if (decimal.TryParse(impuesto.BaseImp, out bufferCantidad))
                    //    cfdi_imp.Baseimp = bufferCantidad;

                    cfdi_imp.Baseimp = 0m;

                    if (decimal.TryParse(impuesto.Tasa, out bufferCantidad))
                        cfdi_imp.Tasa = bufferCantidad;

                    if (decimal.TryParse(impuesto.Importe, out bufferCantidad))
                        cfdi_imp.Importe = bufferCantidad;

                    cfdi.Cfdi_impuestos.Add(cfdi_imp);

                    localContext.Add(cfdi_imp);
                }
            }


            if (decimal.TryParse(virtualXmlHelper.ImpuestosInfo?.TotalTraslados, out bufferCantidad) && timbradoInfo.Tipocomprobanteespecial != "T")
                cfdi.Totaltraslados = bufferCantidad;


            if (decimal.TryParse(virtualXmlHelper.ImpuestosInfo?.TotalRetenciones, out bufferCantidad) && timbradoInfo.Tipocomprobanteespecial != "T")
                cfdi.Totalretenciones = bufferCantidad;


            localContext.Update(cfdi);
            localContext.SaveChanges();


            return true;
        }






    }

    public class DatosBD_FacturaElectronica
    {

        public bool V_esversion33 { get; set; } = true;
        public bool V_esreciboelectronico { get; set; } = false;
        public bool V_pagoenunasolaexibicion { get; set; } = true;

        public bool V_empresadesglosaieps { get; set; } = false;
        public bool V_desgloseiepsfactura { get; set; } = false;
        public string V_pre_formapagosat { get; set; } = "";

        public bool V_mostrardescuentoenfactura { get; set; } = false;
        public bool V_personadesglosaieps{ get; set; } = true;
        public long? V_doctoidconsmayor { get; set; }
        public bool V_omitirvales { get; set; } = false;
        public int ConsecutivoLinea { get; set; } = 0;
        public bool V_desgloseiepslocal { get; set; } = false;
        public string? V_empresa_fiscalcodigopostal { get; set; } = "";
        public bool V_usarfiscalesenexpedicion { get; set; } = false;
        public string? V_personaentregacalle { get; set; } = null;
        public bool V_preguntardatosentrega { get; set; } = false;
        public bool V_esarrendatario { get; set; } = false;
        public bool V_personaretieneiva { get; set; } = false;
        public bool V_personaretieneisr { get; set; } = false;

        public string? V_formapago_consolidada { get; set; }

        public bool V_imprimircomprobantespago { get; set; } = false;

        public bool V_desglosariepsmovto { get; set; } = true;

        public Parametro? Parametro { get; set; }
        public Empresa? Empresa { get; set; }

        public Docto? DoctoInfo { get; set; }


        public List<Movto>? MovtosInfo { get; set; }

        public Cliente? ClienteInfo { get; set; }

        public List<Doctopago>? DoctoPagos { get; set; }


        public List<Doctopago>? DoctoPagos_doctoRelacionado { get; set; }

        public List<Doctopago>? DoctoPagosTransaccion { get; set; }

        public List<Pagosat>? PagosSat { get; set; }

        public Cartaporte? Cartaporte { get; set; }

        public string? Tipocomprobanteespecial { get; set; }

        public bool Generarcartaporte { get; set; } = false;


        public void LlenarDatos(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    bool? desgloseiepsparent,
                    bool? mostrardescuentoparent,
                    ApplicationDbContext localContext)
        {

            Cartaporte = localContext.Cartaporte.AsNoTracking()
                                     .Include(c => c.CartaporteAutotransps)
                                     .Include(c => c.CartaporteCanttransps)
                                     .Include(c => c.CartaporteMercancias)
                                     .Include(c => c.CartaporteTotalmercancias)
                                     .Include(c => c.CartaporteTransptipofiguras)
                                     .Include(c => c.CartaporteUbicacions)
                                     .Include(c => c.CartaporteTotalmercancias)
                                     .FirstOrDefault(c => c.EmpresaId == empresaId && c.SucursalId == sucursalId && c.Doctoid == doctoId);
                                     

            Parametro = localContext.Parametro.AsNoTracking()
               .Include(p => p.Sat_regimenfiscal)
               .FirstOrDefault(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId);

            if (Parametro == null)
                throw new Exception("Parametro no existe");

            V_empresadesglosaieps = Parametro?.Desgloseieps == BoolCN.S;
            V_desgloseiepsfactura = Parametro?.Desgloseiepsfactura == BoolCN.S;
            V_empresa_fiscalcodigopostal = Parametro?.Fiscalcodigopostal;
            V_usarfiscalesenexpedicion = (Parametro?.Usarfiscalesenexpedicion == BoolCN.S);
            V_preguntardatosentrega = (Parametro?.Preguntardatosentrega == BoolCN.S);
            V_esarrendatario = (Parametro?.Arrendatario == BoolCN.S);


            V_mostrardescuentoenfactura = mostrardescuentoparent ?? (Parametro?.Mostrardescuentofactura == BoolCN.S);

            Empresa = localContext.Empresa.AsNoTracking().FirstOrDefault(e => e.Id == empresaId);
            if (Empresa == null)
                throw new Exception("no existe la empresa");


            DoctoInfo = localContext.Docto.AsNoTracking()
                                        .Include(d => d.Docto_fact_elect).ThenInclude(f => f!.Sat_usocfdi)
                                        .Include(d => d.Docto_devolucion).ThenInclude(dev => dev!.Doctoref).ThenInclude(d => d!.Docto_fact_elect)
                                        .Include(d => d.Docto_fact_elect_sustitucion).ThenInclude(d => d!.Doctoasustituir).ThenInclude(d => d!.Docto_fact_elect)
                                        .Include(d => d.Docto_devolucion).ThenInclude(dev => dev!.Doctoref).ThenInclude(d => d!.Docto_fact_elect_consolidacion).ThenInclude(d => d!.Factcons).ThenInclude(d => d!.Docto_fact_elect)
                                        .Include(d => d.Docto_impuestos)
                                        .Include(d => d.Docto_fact_elect_consolidacion).ThenInclude(d => d!.Factcons).ThenInclude(d => d!.Docto_fact_elect)
                                        .Include(d => d.Docto_impuestos)
                                        .Include(d => d.Docto_fact_elect_pagos)
                                        .Include(d => d.Docto_info_pago)
                                        .Include(d => d.Docto_comprobantes)
                                        .FirstOrDefault(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Id == doctoId);

            if (DoctoInfo == null)
                throw new Exception("Docto no encontrado");


            MovtosInfo = localContext.Movto.AsNoTracking()
                                        .Include(d => d.Producto).ThenInclude(p => p!.Producto_fact_elect).ThenInclude(p => p!.Sat_productoservicio)
                                        .Include(d => d.Producto).ThenInclude(p => p!.Unidad).ThenInclude(u => u!.Sat_unidadmedida)
                                        .Include(d => d.Producto).ThenInclude(p => p!.Producto_comodin)
                                        .Include(m => m.Movto_comodin)
                                        .Include(m => m.Movto_devolucion)
                                        .Include(m => m.Movto_kit)
                                        .Include(m => m.Movto_kit_defs)!.ThenInclude(d => d!.Productoparte).ThenInclude(p => p!.Producto_fact_elect).ThenInclude(p => p!.Sat_productoservicio)
                                        .Include(m => m.Movto_kit_defs)!.ThenInclude(d => d.Productoparte).ThenInclude(p => p!.Unidad).ThenInclude(u => u!.Sat_unidadmedida)
                                        .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Doctoid == doctoId)
                                        .ToList();




            ClienteInfo = localContext.Cliente.AsNoTracking()
                                          .Include(c => c.Cliente_fact_elect).ThenInclude(f => f!.Sat_Regimenfiscal)
                                          .Include(c => c.Domicilio)
                                          .Include(c => c.Domicilioentrega)
                                          .Include(c => c.Cliente_poliza)
                                          .FirstOrDefault(c => c.EmpresaId == empresaId && c.SucursalId == sucursalId && c.Id == DoctoInfo!.Clienteid);

            if (ClienteInfo == null)
                throw new Exception("Cliente no encontrado");

            V_personadesglosaieps = ClienteInfo.Cliente_fact_elect?.Desglosaieps == BoolCN.S || ClienteInfo.Cliente_poliza?.Desgloseieps == BoolCN.S;
            V_personaretieneiva = ClienteInfo.Cliente_fact_elect?.Retieneiva == BoolCN.S;
            V_personaretieneisr = ClienteInfo.Cliente_fact_elect?.Retieneisr == BoolCN.S;

            V_esreciboelectronico = DoctoInfo!.Tipodoctoid == 205;

            DoctoPagos = localContext.Doctopago.AsNoTracking()
                        .Include(y => y.Pago).ThenInclude(p => p!.Formapagosat)
                        .Where(dp => dp.EmpresaId == empresaId && dp.SucursalId == sucursalId && dp.Doctoid == doctoId)
                        .ToList();


            V_pre_formapagosat = DoctoInfo.Docto_fact_elect_pagos?.Timbradoformapagosat != null ?
                                            DoctoInfo.Docto_fact_elect_pagos.Timbradoformapagosat : "";

            DoctoPagos_doctoRelacionado = DoctoInfo.Tipodoctoid!.Value == 22 ?
                                                    localContext.Doctopago.AsNoTracking()
                                                            .Include(y => y.Pago).ThenInclude(p => p!.Formapagosat)
                                                            .Where(dp => dp.EmpresaId == empresaId && dp.SucursalId == sucursalId && DoctoInfo.Docto_devolucion != null && dp.Doctoid == DoctoInfo.Docto_devolucion.Doctorefid)
                                                            .ToList()
                                                  : new List<Doctopago>();

            DoctoPagosTransaccion = (DoctoInfo.Tipodoctoid!.Value == 21 ? DoctoPagos : DoctoPagos_doctoRelacionado);


            V_desglosariepsmovto = (V_personadesglosaieps && V_empresadesglosaieps) ||
                                                (desgloseiepsparent != null && desgloseiepsparent!.Value);

            if (DoctoInfo.Tipodoctoid!.Value == 205)
            {
                PagosSat = localContext.Pagosat.AsNoTracking()
                                        .Include(p => p.Pagodoctosats)!.ThenInclude(q => q!.Pagodoctosat_imps)
                                       .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId && p.Doctosatid == doctoId)
                                       .ToList();
            }

            if (DoctoInfo.Tipodoctoid!.Value == 701)
            {
                V_doctoidconsmayor = localContext.Docto.AsNoTracking().Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId &&
                                              d.Docto_fact_elect_consolidacion != null && d.Docto_fact_elect_consolidacion.Factconsid == doctoId &&
                                              d.Docto_fact_elect_consolidacion.Factconsaplicado == BoolCN.S)
                    .OrderByDescending(d => d.Total)
                    .Select(d => d.Id)
                    .FirstOrDefault();

                var formasDePagoBuffer = new List<long>() { 1, 2, 3, 5, 15 };
                V_formapago_consolidada = localContext.Doctopago.AsNoTracking()
                            .Include(d => d.Pago).ThenInclude(p => p!.Formapagosat)
                            .Where(dp => dp.EmpresaId == empresaId && dp.SucursalId == sucursalId && dp.Doctoid == V_doctoidconsmayor &&
                                         dp.Pago != null && (dp.Pago.Formapagosatid ?? 0) != 0 && dp.Pago.Revertido == BoolCN.N &&
                                         dp.Formapagoid != null && formasDePagoBuffer.Contains(dp.Formapagoid!.Value))
                            .GroupBy(dp => new { dp!.Pago!.Formapagosatid, dp.Pago!.Formapagosat!.Clave })
                            .Select(g => new { g.Key.Clave, Importe = g.Sum(dp => dp.Importe) })
                            .OrderByDescending(g => g.Importe)
                            .Select(g => g.Clave)
                            .FirstOrDefault();

            }
        }



    }


        public class DatosBD_MovtoInfo
    {
        public long Movtoid { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Valorunitario { get; set; }
        public decimal Subtotal { get; set; }
        public decimal V_subtotalmovto { get; set; }
        public decimal Importe { get; set; }
        public decimal Descuento { get; set; }
        public decimal V_descuentomovto { get; set; }
        public decimal V_porcentajeiepsmovto { get; set; }
        public decimal V_porcentajeivamovto { get; set; }
        public decimal V_montoivamovto { get; set; }
        public decimal V_montoiepsmovto { get; set; }
        public decimal V_montoivaretenidomovto { get; set; }
        public decimal V_porcentajeivaretenidomovto { get; set; }
        public decimal V_montoisrretenidomovto { get; set; }
        public decimal V_porcentajeisrretenidomovto { get; set; }
        public bool V_eskit { get; set; }
        public bool V_kitimpfijo { get; set; }
        public long? Movtorefid { get; set; }

    }

    public class Factura_Electronica_Linea
    {

        public string? P_tipolinea { get; set; }

        public string? P_serie { get; set; }

        public string? P_folio { get; set; }

        public string? P_tipocomprobante { get; set; }

        public string? P_formapago { get; set; }

        public string? P_moneda { get; set; }

        public string? P_tipocambio { get; set; }

        public string? P_condicionespago { get; set; }

        public string? P_metodopago { get; set; }

        public string? P_motivodescuento { get; set; }

        public string? P_lugarexpedicion { get; set; }

        public string? P_numeroctapago { get; set; }

        public string? P_seriefoliofiscaloriginal { get; set; }

        public string? P_foliofiscaloriginal { get; set; }

        public string? P_rfc { get; set; }

        public string? P_razonsocial { get; set; }

        public string? P_regimenfiscal { get; set; }

        public string? P_calle { get; set; }

        public string? P_nointerior { get; set; }

        public string? P_noexterior { get; set; }

        public string? P_colonia { get; set; }

        public string? P_localidad { get; set; }

        public string? P_referencia { get; set; }

        public string? P_municipio { get; set; }

        public string? P_estado { get; set; }

        public string? P_pais { get; set; }

        public string? P_codigopostal { get; set; }

        public string? P_nombre { get; set; }

        public string? P_residenciafiscal { get; set; }

        public string? P_numregidtrib { get; set; }

        public string? P_usocfdi { get; set; }

        public string? P_unidad { get; set; }

        public string? P_descripcion { get; set; }

        public string? P_noidentificacion { get; set; }

        public string? P_cuentapredial { get; set; }

        public string? P_claveprodserv { get; set; }

        public string? P_claveunidad { get; set; }

        public string? P_numero { get; set; }

        public string? P_aduana { get; set; }

        public string? P_impuesto { get; set; }

        public string? P_tipofactor { get; set; }

        public string? P_tasacuota { get; set; }

        public string? P_formadepagop { get; set; }

        public string? P_monedap { get; set; }

        public string? P_tipocambiop { get; set; }

        public string? P_numoperacion { get; set; }

        public string? P_rfcemisorctaord { get; set; }

        public string? P_nombancoordext { get; set; }

        public string? P_ctaordenante { get; set; }

        public string? P_rfcemisorctaben { get; set; }

        public string? P_ctabeneficiario { get; set; }

        public string? P_tipocadpago { get; set; }

        public string? P_certpago { get; set; }

        public string? P_cadpago { get; set; }

        public string? P_sellopago { get; set; }

        public string? P_iddocumento { get; set; }

        public string? P_monedadr { get; set; }

        public string? P_tipocambiodr { get; set; }

        public string? P_metododepagodr { get; set; }

        public string? P_numparcialidad { get; set; }

        public string? P_tiporelacion { get; set; }

        public string? P_uuid { get; set; }

        public bool? P_imprimircomprobantespago { get; set; }

        public string? P_numeropedimento { get; set; }

        public string? P_omitirvales { get; set; }

        public string? Usermessage { get; set; }

        public string? Devmessage { get; set; }

        public long? P_id { get; set; }

        public long? P_padrelinea { get; set; }

        public int? P_ordenlinea { get; set; }

        public int? P_suborden { get; set; }

        public DateTime? P_fecha { get; set; }

        public decimal? P_subtotal { get; set; }

        public decimal? P_descuento { get; set; }

        public decimal? P_total { get; set; }

        public decimal? P_montofoliofiscaloriginal { get; set; }

        public DateTime? P_fechafoliofiscaloriginal { get; set; }

        public decimal? P_cantidad { get; set; }

        public decimal? P_valorunitario { get; set; }

        public decimal? P_importe { get; set; }

        public decimal? P_tasa { get; set; }

        public decimal? P_baseimp { get; set; }

        public DateTime? P_fechapago { get; set; }

        public decimal? P_monto { get; set; }

        public decimal? P_impsaldoant { get; set; }

        public decimal? P_imppagado { get; set; }

        public decimal? P_impsaldoinsoluto { get; set; }

        public decimal? P_totaltraslados { get; set; }

        public decimal? P_totalretenciones { get; set; }

        public long? P_movtoid { get; set; }

        public long? P_movtokitid { get; set; }

        public long? P_pagosatid { get; set; }

        public long? P_movtorefid { get; set; }
    }
}
