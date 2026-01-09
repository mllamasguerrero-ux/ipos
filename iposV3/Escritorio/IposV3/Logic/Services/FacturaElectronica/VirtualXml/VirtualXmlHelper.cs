
using IposV3.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
//using System.Windows.Threading;
using BindingModels;

namespace IposV3.Services.FacturaElectronica
{
    public class VirtualXmlHelper
    {
        #region CFDI33Wrappers
        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetComprobanteInfo_cfdi33W")]
        public static extern void VirtualXML_SetComprobanteInfo_cfdi33(IntPtr p, String? Serie, String? Folio, String? Fecha, String? FormaPago, String? CondicionesDePago, String? SubTotal, String? Descuento, String? Moneda, String? TipoCambio, String? Total, String? TipoDeComprobante, String? MetodoPago, String? LugarExpedicion, String? Confirmacion);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetEmisorInfo_cfdi33W")]
        public static extern void VirtualXML_SetEmisorInfo_cfdi33(IntPtr p, String? Rfc, String? Nombre, String? RegimenFiscal);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetReceptorInfo_cfdi33W")]
        public static extern void VirtualXML_SetReceptorInfo_cfdi33(IntPtr p, String? Rfc, String? Nombre, String? ResidenciaFiscal, String? NumRegIdTrib, String? UsoCFDI);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_AddConcepto_cfdi33W")]
        public static extern void VirtualXML_AddConcepto_cfdi33(IntPtr p, String? ClaveProdServ, String? NoIdentificacion, String? Cantidad, String? ClaveUnidad, String? Unidad, String? Descripcion, String? ValorUnitario, String? Importe, String? Descuento);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_AddComplementoConcepto_cfdi33W")]
        public static extern void VirtualXML_AddComplementoConcepto_cfdi33(IntPtr p, String? complementoXml);


        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetCfdiRelacionados_cfdi33W")]
        public static extern void VirtualXML_SetCfdiRelacionados_cfdi33(IntPtr p, String? TipoRelacion);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_AddCfdiRelacionado_cfdi33W")]
        public static extern void VirtualXML_AddCfdiRelacionado_cfdi33(IntPtr p, String? UUID);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_AddConceptoTraslado_cfdi33W")]
        public static extern void VirtualXML_AddConceptoTraslado_cfdi33(IntPtr p, String? Base, String? Impuesto, String? TipoFactor, String? TasaOCuota, String? Importe);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_AddConceptoRetencion_cfdi33W")]
        public static extern void VirtualXML_AddConceptoRetencion_cfdi33(IntPtr p, String? Base, String? Impuesto, String? TipoFactor, String? TasaOCuota, String? Importe);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_AddConceptoInformacionAduanera_cfdi33W")]
        public static extern void VirtualXML_AddConceptoInformacionAduanera_cfdi33(IntPtr p, String? NumeroPedimento);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_AddConceptoCuentaPredial_cfdi33W")]
        public static extern void VirtualXML_AddConceptoCuentaPredial_cfdi33(IntPtr p, String? Numero);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_AddConceptoParte_cfdi33W")]
        public static extern void VirtualXML_AddConceptoParte_cfdi33(IntPtr p, String? ClaveProdServ, String? NoIdentificacion, String? Cantidad, String? Unidad, String? Descripcion, String? ValorUnitario, String? Importe, String? NumeroPedimento);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetImpuestosInfo_cfdi33W")]
        public static extern void VirtualXML_SetImpuestosInfo_cfdi33(IntPtr p, String? TotalImpuestosTrasladados, String? TotalImpuestosRetenidos);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_AddTraslado_cfdi33W")]
        public static extern void VirtualXML_AddTraslado_cfdi33(IntPtr p, String? Impuesto, String? TipoFactor, String? TasaOCuota, String? Importe);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_AddRetencion_cfdi33W")]
        public static extern void VirtualXML_AddRetencion_cfdi33(IntPtr p, String? Impuesto, String? Importe);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetAddendaText_cfdi33W")]
        public static extern void VirtualXML_SetAddendaText_cfdi33(IntPtr p, String? text);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetAddenda_cfdi33W")]
        public static extern void VirtualXML_SetAddenda_cfdi33(IntPtr p, String? text);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_AddConceptoComplementoIedu_cfdi33W")]
        public static extern void VirtualXML_AddConceptoComplementoIedu_cfdi33(IntPtr p, String? nombreAlumno, String? CURP, String? nivelEducativo, String? autRVOE, String? rfcPago);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetCompleteXML_cfdi33W")]
        public static extern void VirtualXML_SetCompleteXML_cfdi33(IntPtr p, String? inCFDI);



        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetPagos10W")]
        public static extern void VirtualXML_SetPagos10(IntPtr p);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_Pagos10SetPagoW")]
        public static extern void VirtualXML_Pagos10SetPago(IntPtr p, String? FechaPago, String? FormaDePagoP, String? MonedaP, String? TipoCambioP, String? Monto, String? NumOperacion, String? RfcEmisorCtaOrd, String? NomBancoOrdExt, String? CtaOrdenante, String? RfcEmisorCtaBen, String? CtaBeneficiario, String? TipoCadPago, String? CertPago, String? CadPago, String? SelloPago);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_Pagos10AddPagoDoctoRelacionadoW")]
        public static extern void VirtualXML_Pagos10AddPagoDoctoRelacionado(IntPtr p, String? IdDocumento, String? Serie, String? Folio, String? MonedaDR, String? TipoCambioDR, String? MetodoDePagoDR, String? NumParcialidad, String? ImpSaldoAnt, String? ImpPagado, String? ImpSaldoInsoluto);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_CancelaUUID")]
        public static extern int VirtualXML_CancelaUUID(String? szUser, String? szEmisor, String? szCert, String? szKey, String? szPwd, String? szUuid, String? szOut);


        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_CancelaCFDIW")]
        public static extern int VirtualXML_CancelaCFDI(string szUsuario, string szRfcEmisor, string szRfcReceptor, string szTotal, string szUuid, string sZCert, string szKey, string szPwd, string szResult, string szLog, string szReserved);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_GetStatusCFDIW")]
        public static extern int VirtualXML_GetStatusCFDI(string szUsuario, string szRfcEmisor, string szRfcReceptor, string szTotal, string szUuid, string szResult, string szLog, string szReserved);

        #endregion

        #region DLLIMPORTS32
        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_NewW")]
        static extern int VirtualXML_New(String? szVersion);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_ProcesaDocumentoW")]
        static extern int VirtualXML_ProcesaDocumento(int p, String? csd, String? key, String? keypwd, String? outfile);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_GetValueW")]
        static extern String? VirtualXML_GetValue(int p, int value);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_FreeW")]
        static extern void VirtualXML_Free(int p);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetVirtualPACInfoW")]
        static extern void VirtualXML_SetVirtualPACInfo(int p, String? szUser, String? servidor);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetCiberSATInfoW")]
        static extern void VirtualXML_SetCiberSATInfo(int p, String? userCiberPAC, String? llaveCiberPAC);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetComprobanteInfoW")]
        static extern void VirtualXML_SetComprobanteInfo(int p, String? serie, String? folio, String? fecha, String? tipoDeComprobante, String? formaDePago, String? subtotal, String? descuento, String? total, String? moneda, String? tipoCambio, String? condicionesDePago, String? metodoDePago, String? motivoDescuento);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetComprobanteCFDInfoW")]
        static extern void VirtualXML_SetComprobanteCFDInfo(int p, String? noAprobacion, String? anoAprobacion);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetComprobanteInfoExW")]
        static extern void VirtualXML_SetComprobanteInfoEx(int p, String? LugarExpedicion, String? NumCtaPago, String? SerieFolioFiscalOrig, String? FolioFiscalOrig, String? MontoFolioFiscalOrig, String? FechaFolioFiscalOrig);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetEmisorInfoW")]
        static extern void VirtualXML_SetEmisorInfo(int p, String? szRFC, String? szRazonSocial);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetEmisorDomicilioW")]
        static extern void VirtualXML_SetEmisorDomicilio(int p, String? calle, String? noExterior, String? noInterior, String? colonia, String? localidad, String? referencia, String? municipio, String? estado, String? pais, String? codigoPostal);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetEmisorExpedidoEnW")]
        static extern void VirtualXML_SetEmisorExpedidoEn(int p, String? calle, String? noExterior, String? noInterior, String? colonia, String? localidad, String? referencia, String? municipio, String? estado, String? pais, String? codigoPostal);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_AddEmisorRegimenFiscalW")]
        static extern void VirtualXML_AddEmisorRegimenFiscal(int p, String? regimen);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetReceptorInfoW")]
        static extern void VirtualXML_SetReceptorInfo(int p, String? szRFC, String? szRazonSocial);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetReceptorDomicilioW")]
        static extern void VirtualXML_SetReceptorDomicilio(int p, String? calle, String? noExterior, String? noInterior, String? colonia, String? localidad, String? referencia, String? municipio, String? estado, String? pais, String? codigoPostal);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_AddConceptoW")]
        static extern void VirtualXML_AddConcepto(int p, String? cantidad, String? unidad, String? descripcion, String? valorUnitario, String? importe, String? noIdentificacion);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_AddInformacionAduaneraW")]
        static extern void VirtualXML_AddInformacionAduanera(int p, String? fecha, String? numero, String? aduana);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_AddinstEducativasW")]
        static extern void VirtualXML_AddinstEducativas(int p, String? CURP, String? autRVOE, String? nivelEducativo, String? nombreAlumno, String? rfcPago);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetImpuestosInfoW")]
        static extern void VirtualXML_SetImpuestosInfo(int p, String? totalImpuestosTrasladados, String? totalImpuestosRetenidos);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_AddRetencionW")]
        static extern void VirtualXML_AddRetencion(int p, String? impuesto, String? importe);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_AddTrasladoW")]
        static extern void VirtualXML_AddTraslado(int p, String? impuesto, String? tasa, String? importe);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetImpuestosLocalesInfoW")]
        static extern void VirtualXML_SetImpuestosLocalesInfo(int p, String? TotaldeTraslados, String? TotaldeRetenciones);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_AddImpuestoLocalRetenidoW")]
        static extern void VirtualXML_AddImpuestoLocalRetenido(int p, String? ImpLocRetenido, String? TasadeRetencion, String? Importe);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_AddImpuestoLocalTrasladadoW")]
        static extern void VirtualXML_AddImpuestoLocalTrasladado(int p, String? ImpLocTrasladado, String? TasadeTraslado, String? Importe);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_AddDonatariasW")]
        static extern void VirtualXML_AddDonatarias(int p, String? fechaAutorizacion, String? noAutorizacion);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetDllPathW")]
        static extern void VirtualXML_SetDllPath(int p, String? DllPath);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetMetodoW")]
        static extern void VirtualXML_SetMetodo(int p, String? Metodo);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_GetValueInFileW")]
        static extern void VirtualXML_GetValueInFile(int p, int value, String? file);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_ProcessFileW")]
        static extern void VirtualXML_ProcessFile(String? szFile);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_CheckFileW")]
        static extern int VirtualXML_CheckFile(String? szFile);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetComprobanteFechaW")]
        static extern void VirtualXML_SetComprobanteFecha(int p, String? fecha);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetLogFileW")]
        static extern void VirtualXML_SetLogFile(int p, String? file);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetFlagsW")]
        static extern void VirtualXML_SetFlags(int p, int flags);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_ShowValueW")]
        static extern void VirtualXML_ShowValue(int p, int lValue, String? title);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetAddendaTextW")]
        static extern void VirtualXML_SetAddendaText(int p, String? text);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetAddendaW")]
        static extern void VirtualXML_SetAddenda(int p, String? text);

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_AddCuentaPredialW")]
        static extern void VirtualXML_AddCuentaPredial(int p, String? numero);



        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetCartaPorte20W")]
        public static extern void VirtualXML_SetCartaPorte20(IntPtr p, String? TranspInternac, String? EntradaSalidaMerc, String? PaisOrigenDestino, String? ViaEntradaSalida, String? TotalDistRec);
        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_CartaPorte20AddUbicacionW")]
        public static extern void VirtualXML_CartaPorte20AddUbicacion(IntPtr p, String? TipoUbicacion, String? IDUbicacion, String? RFCRemitenteDestinatario, String? NombreRemitenteDestinatario, String? NumRegIdTrib, String? ResidenciaFiscal, String? NumEstacion, String? NombreEstacion, String? NavegacionTrafico, String? FechaHoraSalidaLlegada, String? TipoEstacion, String? DistanciaRecorrida, String? Calle, String? NumeroExterior, String? NumeroInterior, String? Colonia, String? Localidad, String? Referencia, String? Municipio, String? Estado, String? Pais, String? CodigoPostal);
        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_CartaPorte20SetMercanciasW")]
        public static extern void VirtualXML_CartaPorte20SetMercancias(IntPtr p, String? PesoBrutoTotal, String? UnidadPeso, String? PesoNetoTotal, String? NumTotalMercancias, String? CargoPorTasacion);
        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_CartaPorte20AddMercanciaW")]
        public static extern void VirtualXML_CartaPorte20AddMercancia(IntPtr p, String? BienesTransp, String? ClaveSTCC, String? Descripcion, String? Cantidad, String? ClaveUnidad, String? Unidad, String? Dimensiones, String? MaterialPeligroso, String? CveMaterialPeligroso, String? Embalaje, String? DescripEmbalaje, String? PesoEnKg, String? ValorMercancia, String? Moneda, String? FraccionArancelaria, String? UUIDComercioExt, String? UnidadPesoMerc, String? PesoBruto, String? PesoNeto, String? PesoTara, String? NumPiezas);
        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_CartaPorte20AddMercanciaPedimentosW")]
        public static extern void VirtualXML_CartaPorte20AddMercanciaPedimentos(IntPtr p, String? Pedimento);
        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_CartaPorte20AddMercanciaGuiasIdentificacionW")]
        public static extern void VirtualXML_CartaPorte20AddMercanciaGuiasIdentificacion(IntPtr p, String? NumeroGuiaIdentificacion, String? DescripGuiaIdentificacion, String? PesoGuiaIdentificacion);
        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_CartaPorte20AddMercanciaCantidadTransportaW")]
        public static extern void VirtualXML_CartaPorte20AddMercanciaCantidadTransporta(IntPtr p, String? Cantidad, String? IDOrigen, String? IDDestino, String? CvesTransporte);
        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_CartaPorte20SetMercanciasAutotransporteW")]
        public static extern void VirtualXML_CartaPorte20SetMercanciasAutotransporte(IntPtr p, String? PermSCT, String? NumPermisoSCT, String? ConfigVehicular, String? PlacaVM, String? AnioModeloVM, String? AseguraRespCivil, String? PolizaRespCivil, String? AseguraMedAmbiente, String? PolizaMedAmbiente, String? AseguraCarga, String? PolizaCarga, String? PrimaSeguro, String? SubTipoRem1, String? Placa1, String? SubTipoRem2, String? Placa2);
        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_CartaPorte20SetMercanciasTransporteMaritimoW")]
        public static extern void VirtualXML_CartaPorte20SetMercanciasTransporteMaritimo(IntPtr p, String? PermSCT, String? NumPermisoSCT, String? NombreAseg, String? NumPolizaSeguro, String? TipoEmbarcacion, String? Matricula, String? NumeroOMI, String? AnioEmbarcacion, String? NombreEmbarc, String? NacionalidadEmbarc, String? UnidadesDeArqBruto, String? TipoCarga, String? NumCertITC, String? Eslora, String? Manga, String? Calado, String? LineaNaviera, String? NombreAgenteNaviero, String? NumAutorizacionNaviero, String? NumViaje, String? NumConocEmbarc, String? MatriculaContenedor, String? TipoContenedor, String? NumPrecinto);
        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_CartaPorte20AddMercanciasTransporteMaritimoContenedorW")]
        public static extern void VirtualXML_CartaPorte20AddMercanciasTransporteMaritimoContenedor(IntPtr p, String? MatriculaContenedor, String? TipoContenedor, String? NumPrecinto);
        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_CartaPorte20SetMercanciasTransporteAereoW")]
        public static extern void VirtualXML_CartaPorte20SetMercanciasTransporteAereo(IntPtr p, String? PermSCT, String? NumPermisoSCT, String? MatriculaAeronave, String? NombreAseg, String? NumPolizaSeguro, String? NumeroGuia, String? LugarContrato, String? CodigoTransportista, String? RFCEmbarcador, String? NumRegIdTribEmbarc, String? ResidenciaFiscalEmbarc, String? NombreEmbarcador);
        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_CartaPorte20SetMercanciasTransporteFerroviarioW")]
        public static extern void VirtualXML_CartaPorte20SetMercanciasTransporteFerroviario(IntPtr p, String? TipoDeServicio, String? TipoDeTrafico, String? NombreAseg, String? NumPolizaSeguro, String? TipoDerechoDePaso, String? KilometrajePagado, String? TipoCarro, String? MatriculaCarro, String? GuiaCarro, String? ToneladasNetasCarro, String? TipoContenedor, String? PesoContenedorVacio, String? PesoNetoMercancia);
        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_CartaPorte20AddMercanciasTransporteFerroviarioDerechosDePasoW")]
        public static extern void VirtualXML_CartaPorte20AddMercanciasTransporteFerroviarioDerechosDePaso(IntPtr p, String? TipoDerechoDePaso, String? KilometrajePagado);
        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_CartaPorte20AddMercanciasTransporteFerroviarioCarroW")]
        public static extern void VirtualXML_CartaPorte20AddMercanciasTransporteFerroviarioCarro(IntPtr p, String? TipoCarro, String? MatriculaCarro, String? GuiaCarro, String? ToneladasNetasCarro, String? TipoContenedor, String? PesoContenedorVacio, String? PesoNetoMercancia);
        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_CartaPorte20AddMercanciasTransporteFerroviarioCarroContenedorW")]
        public static extern void VirtualXML_CartaPorte20AddMercanciasTransporteFerroviarioCarroContenedor(IntPtr p, String? TipoContenedor, String? PesoContenedorVacio, String? PesoNetoMercancia);
        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_CartaPorte20AddFiguraTransporteTiposFiguraW")]
        public static extern void VirtualXML_CartaPorte20AddFiguraTransporteTiposFigura(IntPtr p, String? TipoFigura, String? RFCFigura, String? NumLicencia, String? NombreFigura, String? NumRegIdTribFigura, String? ResidenciaFiscalFigura, String? ParteTransporte, String? Calle, String? NumeroExterior, String? NumeroInterior, String? Colonia, String? Localidad, String? Referencia, String? Municipio, String? Estado, String? Pais, String? CodigoPostal);
        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_CartaPorte20AddFiguraTransporteTiposFiguraPartesTransporteW")]
        public static extern void VirtualXML_CartaPorte20AddFiguraTransporteTiposFigura(IntPtr p, String? TipoFigura);

        #endregion


        #region CFDIv40

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetComprobanteInfo_cfdi40W")]
        public static extern void VirtualXML_SetComprobanteInfo_cfdi40(IntPtr p,        // Handler
            String? Serie,                               // Comprobante
            String? Folio,                               // Comprobante
            String? Fecha,                               // Comprobante
            String? FormaPago,                           // Comprobante
            String? CondicionesDePago,                   // Comprobante
            String? SubTotal,                            // Comprobante
            String? Descuento,                           // Comprobante
            String? Moneda,                              // Comprobante
            String? TipoCambio,                          // Comprobante
            String? Total,                               // Comprobante
            String? TipoDeComprobante,                   // Comprobante
            String? MetodoPago,                          // Comprobante
            String? LugarExpedicion,                     // Comprobante
            String? Confirmacion,                        // Comprobante
            String? Exportacion);                        // Comprobante (NEW)



        // (NEW)	
        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetInformacionGlobal_cfdi40W")]
        public static extern void VirtualXML_SetInformacionGlobal_cfdi40(IntPtr p,  // Handler
            String? Periodicidad,                        // Comprobante.InformacionGlobal
            String? Meses,                               // Comprobante.InformacionGlobal
            String? Año);                                // Comprobante.InformacionGlobal


        // (NEW)
        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_AddCfdiRelacionados_cfdi40W")]
        public static extern void VirtualXML_AddCfdiRelacionados_cfdi40(IntPtr p,   // Handler
            String? TipoRelacion,                        // Comprobante.CfdiRelacionados
            String? UUID1,                               // Comprobante.CfdiRelacionados.CfdiRelacionado
            String? UUID2,                               // Comprobante.CfdiRelacionados.CfdiRelacionado
            String? UUID3,                               // Comprobante.CfdiRelacionados.CfdiRelacionado
            String? UUID4,                               // Comprobante.CfdiRelacionados.CfdiRelacionado
            String? UUID5,                               // Comprobante.CfdiRelacionados.CfdiRelacionado
            String? UUID6,                               // Comprobante.CfdiRelacionados.CfdiRelacionado
            String? UUID7,                               // Comprobante.CfdiRelacionados.CfdiRelacionado
            String? UUID8,                               // Comprobante.CfdiRelacionados.CfdiRelacionado
            String? UUID9,                               // Comprobante.CfdiRelacionados.CfdiRelacionado
            String? UUID10);                             // Comprobante.CfdiRelacionados.CfdiRelacionado

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_AddCfdiRelacionado_cfdi40W")]
        public static extern void VirtualXML_AddCfdiRelacionado_cfdi40(IntPtr p,        // Handler
            String? UUID);                               // Comprobante.CfdiRelacionados.CfdiRelacionado

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetEmisorInfo_cfdi40W")]
        public static extern void VirtualXML_SetEmisorInfo_cfdi40(IntPtr p,         // Handler
            String? Rfc,                                 // Comprobante.Emisor
            String? Nombre,                              // Comprobante.Emisor
            String? RegimenFiscal,                       // Comprobante.Emisor
            String? FacAtrAdquirente);                   // Comprobante.Emisor (NEW)

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetReceptorInfo_cfdi40W")]
        public static extern void VirtualXML_SetReceptorInfo_cfdi40(IntPtr p,       // Handler
            String? Rfc,                                 // Comprobante.Receptor
            String? Nombre,                              // Comprobante.Receptor
            String? ResidenciaFiscal,                    // Comprobante.Receptor
            String? NumRegIdTrib,                        // Comprobante.Receptor
            String? UsoCFDI,                             // Comprobante.Receptor
            String? DomicilioFiscalReceptor,             // Comprobante.Receptor (NEW)
            String? RegimenFiscalReceptor);              // Comprobante.Receptor (NEW)

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_AddConcepto_cfdi40W")]
        public static extern void VirtualXML_AddConcepto_cfdi40(IntPtr p,           // Handler
            String? ClaveProdServ,                       // Comprobante.Conceptos.Concepto
            String? NoIdentificacion,                    // Comprobante.Conceptos.Concepto
            String? Cantidad,                            // Comprobante.Conceptos.Concepto
            String? ClaveUnidad,                         // Comprobante.Conceptos.Concepto
            String? Unidad,                              // Comprobante.Conceptos.Concepto
            String? Descripcion,                         // Comprobante.Conceptos.Concepto
            String? ValorUnitario,                       // Comprobante.Conceptos.Concepto
            String? Importe,                             // Comprobante.Conceptos.Concepto
            String? Descuento,                           // Comprobante.Conceptos.Concepto
            String? ObjetoImp);                          // Comprobante.Conceptos.Concepto (NEW)

        // (NEW)
        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetConceptoACuentaTerceros_cfdi40W")]
        public static extern void VirtualXML_SetConceptoACuentaTerceros_cfdi40(IntPtr p,    // Handler
            String? RfcACuentaTerceros,                      // Comprobante.Conceptos.Concepto.ACuentaTerceros
            String? NombreACuentaTerceros,                   // Comprobante.Conceptos.Concepto.ACuentaTerceros
            String? RegimenFiscalACuentaTerceros,            // Comprobante.Conceptos.Concepto.ACuentaTerceros
            String? DomicilioFiscalACuentaTerceros);         // Comprobante.Conceptos.Concepto.ACuentaTerceros

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_AddConceptoCuentaPredial_cfdi40W")]
        public static extern void VirtualXML_AddConceptoCuentaPredial_cfdi40(IntPtr p,  // Handler
            String? Numero);                                 // Comprobante.Conceptos.Concepto.CuentaPredial

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_AddConceptoParte_cfdi40W")]
        public static extern void VirtualXML_AddConceptoParte_cfdi40(IntPtr p,      // Handler
            String? ClaveProdServ,                       // Comprobante.Conceptos.Concepto.Parte
            String? NoIdentificacion,                    // Comprobante.Conceptos.Concepto.Parte
            String? Cantidad,                            // Comprobante.Conceptos.Concepto.Parte
            String? Unidad,                              // Comprobante.Conceptos.Concepto.Parte
            String? Descripcion,                         // Comprobante.Conceptos.Concepto.Parte
            String? ValorUnitario,                       // Comprobante.Conceptos.Concepto.Parte
            String? Importe,                             // Comprobante.Conceptos.Concepto.Parte
            String? NumeroPedimento1,                    // Comprobante.Conceptos.Concepto.Parte.InformacionAduanera
            String? NumeroPedimento2,                    // Comprobante.Conceptos.Concepto.Parte.InformacionAduanera (*)
            String? NumeroPedimento3,                    // Comprobante.Conceptos.Concepto.Parte.InformacionAduanera (*)
            String? NumeroPedimento4,                    // Comprobante.Conceptos.Concepto.Parte.InformacionAduanera (*)
            String? NumeroPedimento5);                   // Comprobante.Conceptos.Concepto.Parte.InformacionAduanera (*)

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_AddTraslado_cfdi40W")]
        public static extern void VirtualXML_AddTraslado_cfdi40(IntPtr p,           // Handler
            String? Impuesto,                            // Comprobante.Impuestos.Traslados.Traslado
            String? TipoFactor,                          // Comprobante.Impuestos.Traslados.Traslado
            String? TasaOCuota,                          // Comprobante.Impuestos.Traslados.Traslado
            String? Importe,                             // Comprobante.Impuestos.Traslados.Traslado
            String? Base);                               // Comprobante.Impuestos.Traslados.Traslado (NEW)





        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetComprobanteFecha_cfdi40W")]
        public static extern void VirtualXML_SetComprobanteFecha_cfdi40(IntPtr p,   // Handler
            String? fecha);                              // Comprobante

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetCompleteXML_cfdi40W")]
        public static extern void VirtualXML_SetCompleteXML_cfdi40(IntPtr p,            // Handler
            String? inCFDI);                             // Comprobante

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_AddComplementoConcepto_cfdi40W")]
        public static extern void VirtualXML_AddComplementoConcepto_cfdi40(IntPtr p,    // Handler
            String? complementoXml);                     // Comprobante.Conceptos.Concepto.ComplementoConcepto


        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_AddConceptoTraslado_cfdi40W")]
        public static extern void VirtualXML_AddConceptoTraslado_cfdi40(IntPtr p,   // Handler
            String? Base,                                // Comprobante.Conceptos.Concepto.Impuestos.Traslados.Traslado
            String? Impuesto,                            // Comprobante.Conceptos.Concepto.Impuestos.Traslados.Traslado
            String? TipoFactor,                          // Comprobante.Conceptos.Concepto.Impuestos.Traslados.Traslado
            String? TasaOCuota,                          // Comprobante.Conceptos.Concepto.Impuestos.Traslados.Traslado
            String? Importe);                            // Comprobante.Conceptos.Concepto.Impuestos.Traslados.Traslado

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_AddConceptoRetencion_cfdi40W")]
        public static extern void VirtualXML_AddConceptoRetencion_cfdi40(IntPtr p,  // Handler
            String? Base,                                // Comprobante.Conceptos.Concepto.Impuestos.Retenciones.Retencion
            String? Impuesto,                            // Comprobante.Conceptos.Concepto.Impuestos.Retenciones.Retencion
            String? TipoFactor,                          // Comprobante.Conceptos.Concepto.Impuestos.Retenciones.Retencion
            String? TasaOCuota,                          // Comprobante.Conceptos.Concepto.Impuestos.Retenciones.Retencion
            String? Importe);                            // Comprobante.Conceptos.Concepto.Impuestos.Retenciones.Retencion

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_AddConceptoInformacionAduanera_cfdi40W")]
        public static extern void VirtualXML_AddConceptoInformacionAduanera_cfdi40(IntPtr p,    // Handler
            String? NumeroPedimento);                            // Comprobante.Conceptos.Concepto.InformacionAduanera

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetImpuestosInfo_cfdi40W")]
        public static extern void VirtualXML_SetImpuestosInfo_cfdi40(IntPtr p,      // Handler
            String? TotalImpuestosTrasladados,           // Comprobante.Impuestos
            String? TotalImpuestosRetenidos);            // Comprobante.Impuestos

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_AddRetencion_cfdi40W")]
        public static extern void VirtualXML_AddRetencion_cfdi40(IntPtr p,          // Handler
            String? Impuesto,                            // Comprobante.Impuestos.Retenciones.Retencion
            String? Importe);                            // Comprobante.Impuestos.Retenciones.Retencion

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_AddComplemento_cfdi40W")]
        public static extern void VirtualXML_AddComplemento_cfdi40(IntPtr p,            // Handler
            String? complementoXml);                     // Comprobante.Complemento

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetAddendaText_cfdi40W")]
        public static extern void VirtualXML_SetAddendaText_cfdi40(IntPtr p,            // Handler
            String? text);                               // Comprobante.Addenda

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetAddenda_cfdi40W")]
        public static extern void VirtualXML_SetAddenda_cfdi40(IntPtr p,                // Handler
            String? text);                               // Comprobante.Addenda


        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_CancelaCFDI2022W")]
        public static extern int VirtualXML_CancelaCFDI2022W(String? szUsuario, String? szRfcEmisor, String? szMotivo, String? szUuid, String? szFolioSust, String? szCert, String? szKey, String? szPwd, String? szServer, String? szResult, String? szLog);
        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_CancelaCFDI2022SSLW")]
        public static extern int VirtualXML_CancelaCFDI2022SSL(String? usuario, String? rfcEmisor, String? motivo, String? uuid, String? folioSustitucion, String? csdFilePath, String? keyFilePath, String? keypwd, String? modoServer, String? outResult, String? outLog);


        #endregion


        #region Complemento Pagos 2.0

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_SetPagos20W")]
        public static extern void VirtualXML_SetPagos20(IntPtr p,               // Handler
            string? TotalRetencionesIVA,             // Pagos.Totales
            string? TotalRetencionesISR,             // Pagos.Totales
            string? TotalRetencionesIEPS,            // Pagos.Totales
            string? TotalTrasladosBaseIVA16,         // Pagos.Totales
            string? TotalTrasladosImpuestoIVA16,     // Pagos.Totales
            string? TotalTrasladosBaseIVA8,          // Pagos.Totales
            string? TotalTrasladosImpuestoIVA8,      // Pagos.Totales
            string? TotalTrasladosBaseIVA0,          // Pagos.Totales
            string? TotalTrasladosImpuestoIVA0,      // Pagos.Totales
            string? TotalTrasladosBaseIVAExento,     // Pagos.Totales
            string? MontoTotalPagos);                // Pagos.Totales

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_Pagos20AddPagoW")]
        public static extern void VirtualXML_Pagos20AddPago(IntPtr p,           // Handler
            string? FechaPago,                       // Pagos.Pago
            string? FormaDePagoP,                    // Pagos.Pago
            string? MonedaP,                         // Pagos.Pago
            string? TipoCambioP,                     // Pagos.Pago
            string? Monto,                           // Pagos.Pago
            string? NumOperacion,                    // Pagos.Pago
            string? RfcEmisorCtaOrd,                 // Pagos.Pago
            string? NomBancoOrdExt,                  // Pagos.Pago
            string? CtaOrdenante,                    // Pagos.Pago
            string? RfcEmisorCtaBen,                 // Pagos.Pago
            string? CtaBeneficiario,                 // Pagos.Pago
            string? TipoCadPago,                     // Pagos.Pago
            string? CertPago,                        // Pagos.Pago
            string? CadPago,                         // Pagos.Pago
            string? SelloPago);                      // Pagos.Pago

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_Pagos20AddPagoDoctoRelacionadoW")]
        public static extern void VirtualXML_Pagos20AddPagoDoctoRelacionado(IntPtr p,   // Handler
            string? IdDocumento,                             // Pagos.Pago.DoctoRelacionado
            string? Serie,                                   // Pagos.Pago.DoctoRelacionado
            string? Folio,                                   // Pagos.Pago.DoctoRelacionado
            string? MonedaDR,                                // Pagos.Pago.DoctoRelacionado
            string? EquivalenciaDR,                          // Pagos.Pago.DoctoRelacionado
            string? NumParcialidad,                          // Pagos.Pago.DoctoRelacionado
            string? ImpSaldoAnt,                             // Pagos.Pago.DoctoRelacionado
            string? ImpPagado,                               // Pagos.Pago.DoctoRelacionado
            string? ImpSaldoInsoluto,                        // Pagos.Pago.DoctoRelacionado
            string? ObjetoImpDR);                            // Pagos.Pago.DoctoRelacionado

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_Pagos20AddPagoDoctoRelacionadoRetencionDRW")]
        public static extern void VirtualXML_Pagos20AddPagoDoctoRelacionadoRetencionDR(IntPtr p,    // Handler
            string? BaseDR,                                          // Pagos.Pago.DoctoRelacionado.ImpuestosDR.RetencionesDR.RetencionDR
            string? ImpuestoDR,                                      // Pagos.Pago.DoctoRelacionado.ImpuestosDR.RetencionesDR.RetencionDR
            string? TipoFactorDR,                                    // Pagos.Pago.DoctoRelacionado.ImpuestosDR.RetencionesDR.RetencionDR
            string? TasaOCuotaDR,                                    // Pagos.Pago.DoctoRelacionado.ImpuestosDR.RetencionesDR.RetencionDR
            string? ImporteDR);                                      // Pagos.Pago.DoctoRelacionado.ImpuestosDR.RetencionesDR.RetencionDR

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_Pagos20AddPagoDoctoRelacionadoTrasladoDRW")]
        public static extern void VirtualXML_Pagos20AddPagoDoctoRelacionadoTrasladoDR(IntPtr p, // Handler
            string? BaseDR,                                          // Pagos.Pago.DoctoRelacionado.ImpuestosDR.TrasladosDR.TrasladoDR
            string? ImpuestoDR,                                      // Pagos.Pago.DoctoRelacionado.ImpuestosDR.TrasladosDR.TrasladoDR
            string? TipoFactorDR,                                    // Pagos.Pago.DoctoRelacionado.ImpuestosDR.TrasladosDR.TrasladoDR
            string? TasaOCuotaDR,                                    // Pagos.Pago.DoctoRelacionado.ImpuestosDR.TrasladosDR.TrasladoDR
            string? ImporteDR);                                      // Pagos.Pago.DoctoRelacionado.ImpuestosDR.TrasladosDR.TrasladoDR

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_Pagos20AddPagoImpuestosPRetencionPW")]
        public static extern void VirtualXML_Pagos20AddPagoImpuestosPRetencionP(IntPtr p,   // Handler
            string? ImpuestoP,                                   // Pagos.Pago.ImpuestosP.RetencionesP.RetencionP
            string? ImporteP);                                   // Pagos.Pago.ImpuestosP.RetencionesP.RetencionP

        [DllImport("VirtualXML.dll", CharSet = CharSet.Unicode, EntryPoint = "VirtualXML_Pagos20AddPagoImpuestosPTrasladoPW")]
        public static extern void VirtualXML_Pagos20AddPagoImpuestosPTrasladoP(IntPtr p,        // Handler
            string? BaseP,                                       // Pagos.Pago.ImpuestosP.TrasladosP.TrasladoP
            string? ImpuestoP,                                   // Pagos.Pago.ImpuestosP.TrasladosP.TrasladoP
            string? TipoFactorP,                                 // Pagos.Pago.ImpuestosP.TrasladosP.TrasladoP
            string? TasaOCuotaP,                                 // Pagos.Pago.ImpuestosP.TrasladosP.TrasladoP
            string? ImporteP);									// Pagos.Pago.ImpuestosP.TrasladosP.TrasladoP


        #endregion




        private string? mensaje;

        //private Dispatcher dispatcher;
        public delegate void DispatcherDelegate(int hXml);
        private DispatcherDelegate? _dispatcherMethodCall;

        public string? Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }

        private VirtualPACInfo? virtualPacInfo;

        public VirtualPACInfo? VirtualPacInfo
        {
            get { return virtualPacInfo; }
            set { virtualPacInfo = value; }
        }

        private CiberSATInfo? ciberSatInfo;

        public CiberSATInfo? CiberSatInfo
        {
            get { return ciberSatInfo; }
            set { ciberSatInfo = value; }
        }


        public CartaporteBindingModel? iCARTAPORTE;
        public CartaporteBindingModel? ICARTAPORTE
        {
            get
            {
                return this.iCARTAPORTE;
            }
            set
            {
                this.iCARTAPORTE = value;
            }
        }


        private ComprobanteInfo? comprobanteInfo;

        public ComprobanteInfo? ComprobanteInfo
        {
            get { return comprobanteInfo; }
            set { comprobanteInfo = value; }
        }

        private ComprobanteInfoEx? comprobanteInfoEx;

        public ComprobanteInfoEx? ComprobanteInfoEx
        {
            get { return comprobanteInfoEx; }
            set { comprobanteInfoEx = value; }
        }

        private ComprobanteCFDInfo? comprobanteCfdInfo;

        public ComprobanteCFDInfo? ComprobanteCfdInfo
        {
            get { return comprobanteCfdInfo; }
            set { comprobanteCfdInfo = value; }
        }

        private EmisorInfo? emisorInfo;

        public EmisorInfo? EmisorInfo
        {
            get { return emisorInfo; }
            set { emisorInfo = value; }
        }

        private ReceptorInfo? receptorInfo;

        public ReceptorInfo? ReceptorInfo
        {
            get { return receptorInfo; }
            set { receptorInfo = value; }
        }

        private InformacionGlobal? informacionGlobal;

        public InformacionGlobal? InformacionGlobal
        {
            get { return informacionGlobal; }
            set { informacionGlobal = value; }
        }

        private List<Concepto>? conceptos;

        public List<Concepto>? Conceptos
        {
            get { return conceptos; }
            set { conceptos = value; }
        }


        private List<PagoSAT>? pagosSat;

        public List<PagoSAT>? PagosSat
        {
            get { return pagosSat; }
            set { pagosSat = value; }
        }


        private List<Traslado>? impuestosTrasladados;

        public List<Traslado>? ImpuestosTrasladados
        {
            get { return impuestosTrasladados; }
            set { impuestosTrasladados = value; }
        }

        private List<Retencion>? impuestosRetenidos;

        public List<Retencion>? ImpuestosRetenidos
        {
            get { return impuestosRetenidos; }
            set { impuestosRetenidos = value; }
        }

        private ImpuestosInfo? impuestosInfo;

        public ImpuestosInfo? ImpuestosInfo
        {
            get { return impuestosInfo; }
            set { impuestosInfo = value; }
        }

        private ImpuestosLocalesInfo? impuestosLocalesInfo;

        public ImpuestosLocalesInfo? ImpuestosLocalesInfo
        {
            get { return impuestosLocalesInfo; }
            set { impuestosLocalesInfo = value; }
        }

        private List<ImpuestoLocalTrasladado>? localesTrasladados;

        public List<ImpuestoLocalTrasladado>? LocalesTrasladados
        {
            get { return localesTrasladados; }
            set { localesTrasladados = value; }
        }

        private List<ImpuestoLocalRetenido>? localesRetenidos;

        public List<ImpuestoLocalRetenido>? LocalesRetenidos
        {
            get { return localesRetenidos; }
            set { localesRetenidos = value; }
        }

        private Addenda? addendas;

        public Addenda? Addendas
        {
            get { return addendas; }
            set { addendas = value; }
        }

        private EmisorExpedidoEn? emisorExpedidoEn;

        public EmisorExpedidoEn? EmisorExpedidoEn
        {
            get { return emisorExpedidoEn; }
            set { emisorExpedidoEn = value; }
        }

        private string? rutaCsd;

        public string? RutaCsd
        {
            get { return rutaCsd; }
            set { rutaCsd = value; }
        }

        private string? llave;

        public string? Llave
        {
            get { return llave; }
            set { llave = value; }
        }

        private string? claveLlave;

        public string? ClaveLlave
        {
            get { return claveLlave; }
            set { claveLlave = value; }
        }

        private string? rutaXml;

        public string? RutaXml
        {
            get { return rutaXml; }
            set { rutaXml = value; }
        }

        private string? rutaPdf;

        public string? RutaPdf
        {
            get { return rutaPdf; }
            set { rutaPdf = value; }
        }

        private string? version;

        public string? Version
        {
            get { return version; }
            set { version = value; }
        }

        private int hXml;
        private IntPtr hXmlPtr;


        //Flags
        private bool manejaAddenda;

        public bool ManejaAddenda
        {
            get { return manejaAddenda; }
            set { manejaAddenda = value; }
        }

        private bool manejaImpuestosLocales;

        public bool ManejaImpuestosLocales
        {
            get { return manejaImpuestosLocales; }
            set { manejaImpuestosLocales = value; }
        }

        private bool manejaTrasladados;

        public bool ManejaTrasladados
        {
            get { return manejaTrasladados; }
            set { manejaTrasladados = value; }
        }

        private bool manejaRetenidos;

        public bool ManejaRetenidos
        {
            get { return manejaRetenidos; }
            set { manejaRetenidos = value; }
        }


        private Dictionary<String, List<String>>? cfdiRelacionados;
        public Dictionary<String, List<String>>? CfdiRelacionados
        {
            get { return cfdiRelacionados; }
            set { cfdiRelacionados = value; }
        }


        public VirtualXmlHelper(DispatcherDelegate? dispatcherMethodCall)
        {

            //this.dispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
            _dispatcherMethodCall = dispatcherMethodCall;
            mensaje = String.Empty;
            version = DBValues._VERSION_FACTURACION;
        }

        public VirtualXmlHelper(string versionFacturacion, DispatcherDelegate? dispatcherMethodCall) :this(dispatcherMethodCall)
        {
            version = versionFacturacion;
        }

        public string GenerarDocumento()
        {
            if (version != null && version.Equals(VersionesFacturacion.V33))
            {
                return GenerarDocumento33();
            }
            else if(version != null && version.Equals(VersionesFacturacion.V40))
            {
                return GenerarDocumento40();
            }
            else
            {
                return GenerarDocumento32();
            }
        }

        public string GenerarPago(bool silentMode = false)
        {
            if (version != null && version.Equals(VersionesFacturacion.V33))
            {
                return GenerarPago33(silentMode);
            }
            else 
                return GenerarPago40(silentMode);
        }

        public string GenerarDocumento32()
        {
            try
            {
                string resultado = String.Empty;

                if (version == null)
                    throw new Exception("La version de facturaciondebe estar definida");

                //Version del comprobante a generar
                hXml = VirtualXML_New(this.version);

                hXmlPtr = new IntPtr(hXml);

                //Información de conexion al PAC
                if (version.Equals(VersionesFacturacion.V32.ToString()))
                {
                    //Información de conexion al PAC
                    FijarVirtualPacInfo(virtualPacInfo);
                }
                else if (version.Equals(VersionesFacturacion.V22.ToString()))
                {
                    FijarCiberSatInfo(ciberSatInfo);
                }

                //Información del comprobante
                FijarComprobanteInfo(comprobanteInfo);

                //Informacion comprobante extendido, necesario para 3.2
                if (version.Equals(VersionesFacturacion.V32.ToString()))
                {
                    FijarComprobanteInfoEx(comprobanteInfoEx);
                }

                //Información de folios, necesario para 2.0 y 2.2
                if ((version.Equals(VersionesFacturacion.V20.ToString()) || version.Equals(VersionesFacturacion.V22.ToString())) && comprobanteCfdInfo != null)
                {
                    FijarComprobanteCfdInfo(comprobanteCfdInfo);
                }

                //Addendas
                if (ManejaAddenda)
                {
                    FijarAddendas();
                }

                //Datos del emisor
                FijarEmisorInfo(emisorInfo);

                //Información del régimen fiscal versiones 2.2 y 3.2
                if ((version.Equals(VersionesFacturacion.V22.ToString()) || version.Equals(VersionesFacturacion.V32.ToString())))
                {
                    FijarEmisorRegimenFiscal(emisorInfo);
                }

                //Domicilio del Emisor
                FijarEmisorDomicilio(emisorInfo);

                //Datos del receptor
                FijarReceptorInfo(receptorInfo);

                //Domicilio del receptor
                FijarReceptorDomicilio(receptorInfo);

                //Conceptos
                FijarConceptos();

                //Impuestos locales
                if (ManejaImpuestosLocales)
                {
                    //Informacion de impuestos locales
                    FijarImpuestosLocalesInfo();

                    if (ManejaTrasladados)
                    {
                        //Impuesto local trasladado
                        FijarImpuestosLocalesTrasladados();
                    }

                    if (ManejaRetenidos)
                    {
                        //Impuesto local retenido
                        FijarImpuestosLocalesRetenidos();
                    }
                }
                else
                {
                    //Impuestos Tasa cero e IVA, cehcar si aplica
                    FijarImpuestos();
                }

                //Crear ruta de archivo con nombre
                CrearRutasDeArchivos();

                //Generar el comprobante
                int res = ProcesarDocumento();

                if (res != 0)
                {
                    MostrarError();
                    resultado = "Error";
                }

                //Obtener resultado
                //resultado = ObtenerResultadoEnModoTexto();

                //Liberar sesion en dll
                VirtualXML_Free(hXml);

                return resultado;
            }
            catch (Exception e)
            {
                mensaje = "Error al generar el documento: " + e.Message;

                return mensaje;
            }
        }



        private string GenerarDocumento33()
        {
            try
            {
                string resultado = String.Empty;

                //Version del comprobante a generar
                hXml = VirtualXML_New(this.version);

                hXmlPtr = new IntPtr(hXml);


                //Información de conexion al PAC
                FijarVirtualPacInfo(virtualPacInfo);

                //Información del comprobante
                FijarComprobanteInfo33();


                //FijarComprobanteInfoEx(comprobanteInfoEx);

                //Addendas
                if (ManejaAddenda)
                {
                    FijarAdenda33();
                }

                //Datos del emisor
                FijarEmisorInfo33();
                //FijarEmisorRegimenFiscal(emisorInfo);
                //FijarEmisorDomicilio(emisorInfo);

                //Datos del receptor
                FijarReceptorInfo33();
                //FijarReceptorDomicilio(receptorInfo);

                //Conceptos
                FijarConceptos33();


                //Impuestos Tasa cero e IVA, cehcar si aplica
                if (ManejaImpuestosLocales)
                {
                    //Informacion de impuestos locales
                    FijarImpuestosLocalesInfo();

                    if (ManejaTrasladados)
                    {
                        //Impuesto local trasladado
                        FijarImpuestosLocalesTrasladados();
                    }

                    if (ManejaRetenidos)
                    {
                        //Impuesto local retenido
                        FijarImpuestosLocalesRetenidos();
                    }
                }
                else
                {
                    FijarImpuestosInfo33();
                    //Impuestos Tasa cero e IVA, cehcar si aplica
                    FijarImpuestos33();
                }

                FijarCFDIRelacionados33();

                //if(ICARTAPORTE != null)
                //{

                //    FijarCartaPorte();
                //}



                //Crear ruta de archivo con nombre
                CrearRutasDeArchivos();


                //Generar el comprobante
                int res = ProcesarDocumento();

                if (res != 0)
                {
                    MostrarError();
                    resultado = "Error";
                }


                //if (res != 0)
                //{
                //    //Obtener resultado
                //    resultado = ObtenerResultadoEnModoTexto();
                //}

                //Liberar sesion en dll
                VirtualXML_Free(hXml);

                return resultado;
            }
            catch (Exception e)
            {
                mensaje = "Error al generar el documento: " + e.Message;

                return mensaje;
            }
        }



        private string GenerarDocumento40()
        {
            try
            {
                string resultado = String.Empty;

                //Version del comprobante a generar
                hXml = VirtualXML_New(this.version);

                hXmlPtr = new IntPtr(hXml);


                //Información de conexion al PAC
                FijarVirtualPacInfo(virtualPacInfo);

                //Información del comprobante
                FijarComprobanteInfo40();

                //informacion global
                if (InformacionGlobal != null)
                {
                    FijarInformacionGlobal40();
                }

                //Addendas
                if (ManejaAddenda)
                {
                    FijarAdenda40();
                }

                //Datos del emisor
                FijarEmisorInfo40();

                //Datos del receptor
                FijarReceptorInfo40();

                //Conceptos
                FijarConceptos40();


                //Impuestos Tasa cero e IVA, cehcar si aplica
                if (ManejaImpuestosLocales)
                {
                    //Informacion de impuestos locales
                    FijarImpuestosLocalesInfo();

                    if (ManejaTrasladados)
                    {
                        //Impuesto local trasladado
                        FijarImpuestosLocalesTrasladados();
                    }

                    if (ManejaRetenidos)
                    {
                        //Impuesto local retenido
                        FijarImpuestosLocalesRetenidos();
                    }
                }
                else
                {
                    FijarImpuestosInfo40();
                    //Impuestos Tasa cero e IVA, cehcar si aplica
                    FijarImpuestos40();
                }

                FijarCFDIRelacionados40();

                if (ICARTAPORTE != null)
                {

                    FijarCartaPorte();
                }



                //Crear ruta de archivo con nombre
                CrearRutasDeArchivos();
                

                //Generar el comprobante
                int res = ProcesarDocumento();

                if (res != 0)
                {
                    MostrarError();
                    resultado = "Error";
                }

                //Liberar sesion en dll
                VirtualXML_Free(hXml);

                return resultado;
            }
            catch (Exception e)
            {
                mensaje = "Error al generar el documento: " + e.Message;

                return mensaje;
            }
        }




        public string GenerarPago33(bool silentMode)
        {
            try
            {
                string resultado = String.Empty;

                //Version del comprobante a generar
                hXml = VirtualXML_New(this.version);

                hXmlPtr = new IntPtr(hXml);


                //Información de conexion al PAC
                FijarVirtualPacInfo(virtualPacInfo);

                //Información del comprobante
                FijarComprobanteInfo33();


                //FijarComprobanteInfoEx(comprobanteInfoEx);


                //Datos del emisor
                FijarEmisorInfo33();
                //FijarEmisorRegimenFiscal(emisorInfo);
                //FijarEmisorDomicilio(emisorInfo);

                //Datos del receptor
                FijarReceptorInfo33();
                //FijarReceptorDomicilio(receptorInfo);

                //Conceptos
                FijarConceptos33();

                //pagos
                FijarPagos33();
                
                //Crear ruta de archivo con nombre
                CrearRutasDeArchivos();

                //Generar el comprobante
                int res = ProcesarDocumento();

                if (res != 0)
                {

                    if (silentMode)
                    {
                        this.MostrarErrorInThread(hXmlPtr, hXml);
                    }
                    else
                    {
                        MostrarError();
                        VirtualXML_Free(hXml);
                    }

                    resultado = "Error";
                }
                else
                {
                    VirtualXML_Free(hXml);
                }
                //Obtener resultado
                //resultado = ObtenerResultadoEnModoTexto();

                //Liberar sesion en dll
                //VirtualXML_Free(hXml);

                return resultado;
            }
            catch (Exception e)
            {
                mensaje = "Error al generar el documento: " + e.Message;

                return mensaje;
            }
        }



        public string GenerarPago40(bool silentMode)
        {
            try
            {
                string resultado = String.Empty;

                //Version del comprobante a generar
                hXml = VirtualXML_New(this.version);

                hXmlPtr = new IntPtr(hXml);


                //Información de conexion al PAC
                FijarVirtualPacInfo(virtualPacInfo);

                //Información del comprobante
                FijarComprobanteInfo40();
                


                //Datos del emisor
                FijarEmisorInfo40();

                //Datos del receptor
                FijarReceptorInfo40();
                //FijarReceptorDomicilio(receptorInfo);

                //Conceptos
                FijarConceptos40();

                //pagos
                FijarPagos40();

                //Crear ruta de archivo con nombre
                CrearRutasDeArchivos();

                //Generar el comprobante
                int res = ProcesarDocumento();

                if (res != 0)
                {

                    if (silentMode)
                    {
                        this.MostrarErrorInThread(hXmlPtr, hXml);
                    }
                    else
                    {
                        MostrarError();
                        VirtualXML_Free(hXml);
                    }

                    resultado = "Error";
                }
                else
                {
                    VirtualXML_Free(hXml);
                }
                //Obtener resultado
                //resultado = ObtenerResultadoEnModoTexto();

                //Liberar sesion en dll
                //VirtualXML_Free(hXml);

                return resultado;
            }
            catch (Exception e)
            {
                mensaje = "Error al generar el documento: " + e.Message;

                return mensaje;
            }
        }


        private void FijarAdenda33()
        {
            VirtualXML_SetAddenda_cfdi33(hXmlPtr,
                                         addendas?.Texto);
        }

        private void FijarComprobanteInfo33()
        {

            VirtualXML_SetComprobanteInfo_cfdi33(hXmlPtr,
                                                 comprobanteInfo?.Serie,
                                                 comprobanteInfo?.Folio,
                                                 comprobanteInfo?.Fecha,
                                                 comprobanteInfo?.FormaPago,
                                                 comprobanteInfo?.CondicionesPago,
                                                 comprobanteInfo?.Subtotal,
                                                 comprobanteInfo?.Descuento,
                                                 comprobanteInfo?.Moneda,
                                                 comprobanteInfo?.TipoCambio,
                                                 comprobanteInfo?.Total,
                                                 comprobanteInfo?.TipoComprobante,
                                                 comprobanteInfo?.MetodoPago,
                                                 comprobanteInfo?.LugarExpedicion,
                                                 comprobanteInfo?.Confirmacion);
        }

        private void FijarEmisorInfo33()
        {
            VirtualXML_SetEmisorInfo_cfdi33(hXmlPtr,
                                            emisorInfo?.Rfc,
                                            emisorInfo?.RazonSocial,
                                            emisorInfo?.RegimenFiscal);
        }

        private void FijarReceptorInfo33()
        {
            VirtualXML_SetReceptorInfo_cfdi33(hXmlPtr,
                                              receptorInfo?.Rfc,
                                              receptorInfo?.Nombre,
                                              receptorInfo?.ResidenciaFiscal,
                                              receptorInfo?.NumRegIdTrib,
                                              receptorInfo?.UsoCFDI);
        }

        private void FijarConceptos33()
        {

            if (conceptos == null) return;

            int iCount = 0;
            foreach (Concepto c in conceptos)
            {
                iCount++;
                VirtualXML_AddConcepto_cfdi33(hXmlPtr,
                                              c.ClaveProdServ,
                                              c.NoIdentificacion,
                                              c.Cantidad,
                                              c.ClaveUnidad,
                                              c.Unidad,
                                              c.Descripcion,
                                              c.ValorUnitario,
                                              c.Importe,
                                              c.Descuento == null ? "0.00" : c.Descuento);







                if (c.ImpuestosTrasladados != null)
                {
                    foreach (Traslado impu in c.ImpuestosTrasladados)
                    {
                        VirtualXML_AddConceptoTraslado_cfdi33(hXmlPtr, impu.BaseImp, impu.ImpuestoVal, impu.TipoFactor, impu.TasaCuota, impu.Importe);
                    }
                }

                if (c.ImpuestosRetenidos != null)
                {
                    foreach (Traslado impu in c.ImpuestosRetenidos)
                    {
                        VirtualXML_AddConceptoRetencion_cfdi33(hXmlPtr, impu.BaseImp, impu.ImpuestoVal, impu.TipoFactor, impu.TasaCuota, impu.Importe);
                    }
                }


                if (c.ComplementoConceptos != null)
                {
                    foreach (string info in c.ComplementoConceptos)
                    {
                        VirtualXML_AddComplementoConcepto_cfdi33(hXmlPtr, info);
                    }
                }


                if (c.InfoAduanera != null)
                {
                    foreach (InformacionAduanera infoAduanera in c.InfoAduanera)
                    {
                        VirtualXML_AddConceptoInformacionAduanera_cfdi33(hXmlPtr,
                                                                         infoAduanera.Numero);
                    }
                }


                if (c.ConceptoPartes != null)
                {
                    foreach (ConceptoParte info in c.ConceptoPartes)
                    {
                        VirtualXML_AddConceptoParte_cfdi33(hXmlPtr, info.ClaveProdServ, info.NoIdentificacion, info.Cantidad, info.Unidad, info.Descripcion, info.ValorUnitario, info.Importe, info.NumeroPedimento);
                    }
                }





                if (!String.IsNullOrEmpty(c.CuentaPredial))
                {
                    VirtualXML_AddConceptoCuentaPredial_cfdi33(hXmlPtr, c.CuentaPredial);
                }


            }
        }




        private void FijarPagos33()
        {
            if (pagosSat == null) return;

            foreach (PagoSAT c in pagosSat)
            {
                VirtualXML_SetPagos10(hXmlPtr);

                VirtualXML_Pagos10SetPago(hXmlPtr, c.FechaPago, c.FormaDePagoP, c.MonedaP, c.TipoCambioP, c.Monto, c.NumOperacion, c.RfcEmisorCtaOrd, c.NomBancoOrdExt, c.CtaOrdenante, c.RfcEmisorCtaBen, c.CtaBeneficiario, c.TipoCadPago, c.CertPago, c.CadPago, c.SelloPago);



                if (c.DoctosRelacionados != null)
                {
                    foreach (PagoDoctoSAT info in c.DoctosRelacionados)
                    {
                        VirtualXML_Pagos10AddPagoDoctoRelacionado(hXmlPtr, info.IdDocumento, info.Serie, info.Folio, info.MonedaDR, info.TipoCambioDR, info.MetodoDePagoDR, info.NumParcialidad, info.ImpSaldoAnt, info.ImpPagado, info.ImpSaldoInsoluto);
                    }
                }

            }
        }

        

        private void FijarPagos40()
        {

            if (pagosSat == null) return;

            CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
            NumberFormatInfo nfi = (NumberFormatInfo)ci.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";

            foreach (PagoSAT c in pagosSat)
            {

                //'CONCEPTO_ISRRETENIDO','CONCEPTO_IVARETENIDO', 'CONCEPTO_IVA', 'CONCEPTO_IEPS'
                string TotalRetencionesIVA = c.DoctosImpRelacionados == null ? "0.00" : (c.DoctosImpRelacionados.Where(y => y.Tipoimpuesto == "CONCEPTO_IVARETENIDO").Sum(y => y.Importe) ?? 0m ).ToString("N2", nfi);
                string TotalRetencionesISR = c.DoctosImpRelacionados == null ? "0.00" : (c.DoctosImpRelacionados.Where(y => y.Tipoimpuesto == "CONCEPTO_ISRRETENIDO").Sum(y => y.Importe) ?? 0m).ToString("N2", nfi);
                string TotalRetencionesIEPS = "0.00";
                string TotalTrasladosBaseIVA16 = c.DoctosImpRelacionados == null ? "0.00" : (c.DoctosImpRelacionados.Where(y => y.Tipoimpuesto == "CONCEPTO_IVA" && y.Tasa == 16.00m).Sum(y => y.Baseimp) ?? 0m).ToString("N2", nfi);
                string TotalTrasladosImpuestoIVA16 = c.DoctosImpRelacionados == null ? "0.00" : (c.DoctosImpRelacionados.Where(y => y.Tipoimpuesto == "CONCEPTO_IVA" && y.Tasa == 16.00m).Sum(y => y.Importe) ?? 0m).ToString("N2", nfi);
                string TotalTrasladosBaseIVA8 = c.DoctosImpRelacionados == null ? "0.00" : (c.DoctosImpRelacionados.Where(y => y.Tipoimpuesto == "CONCEPTO_IVA" && y.Tasa == 8.00m).Sum(y => y.Baseimp) ?? 0m).ToString("N2", nfi);
                string TotalTrasladosImpuestoIVA8 = c.DoctosImpRelacionados == null ? "0.00" : (c.DoctosImpRelacionados.Where(y => y.Tipoimpuesto == "CONCEPTO_IVA" && y.Tasa == 8.00m).Sum(y => y.Importe) ?? 0m).ToString("N2", nfi);
                string TotalTrasladosBaseIVA0 = c.DoctosImpRelacionados == null ? "0.00" : (c.DoctosImpRelacionados.Where(y => y.Tipoimpuesto == "CONCEPTO_IVA" && y.Tasa == 0.00m).Sum(y => y.Baseimp) ?? 0m).ToString("N2", nfi);
                string TotalTrasladosImpuestoIVA0 = c.DoctosImpRelacionados == null ? "0.00" : (c.DoctosImpRelacionados.Where(y => y.Tipoimpuesto == "CONCEPTO_IVA" && y.Tasa == 0.00m).Sum(y => y.Importe) ?? 0m).ToString("N2", nfi);
                string TotalTrasladosBaseIVAExento = "0.00";
                string? MontoTotalPagos = c.Monto;

                //no declararlos cuando el importe o la base sea cero
                TotalRetencionesIVA = TotalRetencionesIVA == "0.00" ? "" : TotalRetencionesIVA;
                TotalRetencionesISR = TotalRetencionesISR == "0.00" ? "" : TotalRetencionesISR;
                TotalRetencionesIEPS = TotalRetencionesIEPS == "0.00" ? "" : TotalRetencionesIEPS;
                TotalTrasladosImpuestoIVA16 = TotalTrasladosBaseIVA16 == "0.00" ? "" : TotalTrasladosImpuestoIVA16;
                TotalTrasladosBaseIVA16 = TotalTrasladosBaseIVA16 == "0.00" ? "" : TotalTrasladosBaseIVA16;
                TotalTrasladosImpuestoIVA8 = TotalTrasladosBaseIVA8 == "0.00" ? "" : TotalTrasladosImpuestoIVA8;
                TotalTrasladosBaseIVA8 = TotalTrasladosBaseIVA8 == "0.00" ? "" : TotalTrasladosBaseIVA8;
                TotalTrasladosImpuestoIVA0 = TotalTrasladosBaseIVA0 == "0.00" ? "" : TotalTrasladosImpuestoIVA0;
                TotalTrasladosBaseIVA0 = TotalTrasladosBaseIVA0 == "0.00" ? "" : TotalTrasladosBaseIVA0;
                TotalTrasladosBaseIVAExento = TotalTrasladosBaseIVAExento == "0.00" ? "" : TotalTrasladosBaseIVAExento;


                VirtualXML_SetPagos20(hXmlPtr, TotalRetencionesIVA, TotalRetencionesISR, TotalRetencionesIEPS, TotalTrasladosBaseIVA16,
                                                TotalTrasladosImpuestoIVA16, TotalTrasladosBaseIVA8, TotalTrasladosImpuestoIVA8, TotalTrasladosBaseIVA0,
                                                TotalTrasladosImpuestoIVA0, TotalTrasladosBaseIVAExento, MontoTotalPagos);


                // agregamos un pago
                VirtualXML_Pagos20AddPago(hXmlPtr, c.FechaPago, c.FormaDePagoP, c.MonedaP, c.TipoCambioP, c.Monto, c.NumOperacion, c.RfcEmisorCtaOrd, c.NomBancoOrdExt, c.CtaOrdenante, c.RfcEmisorCtaBen, c.CtaBeneficiario, c.TipoCadPago, c.CertPago, c.CadPago, c.SelloPago);


                if (c.DoctosRelacionados != null)
                {

                    foreach (PagoDoctoSAT info in c.DoctosRelacionados)
                    {

                        // agregamos un documento relacionado
                        VirtualXML_Pagos20AddPagoDoctoRelacionado(hXmlPtr, info.IdDocumento, info.Serie, info.Folio, info.MonedaDR, info.TipoCambioDR, info.NumParcialidad, info.ImpSaldoAnt, info.ImpPagado, info.ImpSaldoInsoluto, info.ObjetoImpDR);
                        // desgloce de impuestos del documento relacionado

                        if (c.DoctosImpRelacionados != null)
                        {
                            foreach (var impuesto in c.DoctosImpRelacionados.Where(y => y.Iddocumento == info.IdDocumento && y.Baseimp > 0 &&
                                                                                   (y.Tipoimpuesto == "CONCEPTO_IVA" || y.Tipoimpuesto == "CONCEPTO_IEPS")))
                            {

                                VirtualXML_Pagos20AddPagoDoctoRelacionadoTrasladoDR(hXmlPtr,
                                                (impuesto.Baseimp ?? 0m).ToString("N2", nfi),
                                                impuesto.Impuesto,
                                                impuesto.Tipofactor,
                                                (impuesto.Tasa / 100.00m).ToString("N6", nfi),
                                                (impuesto.Importe ?? 0m).ToString("N2", nfi));
                            }

                            foreach (var impuesto in c.DoctosImpRelacionados.Where(y => y.Iddocumento == info.IdDocumento && y.Baseimp > 0 &&
                                                                                       (y.Tipoimpuesto == "CONCEPTO_IVARETENIDO" || y.Tipoimpuesto == "CONCEPTO_ISRRETENIDO")))
                            {

                                VirtualXML_Pagos20AddPagoDoctoRelacionadoRetencionDR(hXmlPtr,
                                                (impuesto.Baseimp ?? 0m).ToString("N2", nfi),
                                                impuesto.Impuesto,
                                                impuesto.Tipofactor,
                                                (impuesto.Tasa / 100.00m).ToString("N6", nfi),
                                                (impuesto.Importe ?? 0m).ToString("N2", nfi));
                            }
                        }

                    }
                }

                // resumen de impuestos de todos los documentos relacionados

                if (c.DoctosImpRelacionados != null)
                {
                    foreach (var impuesto in c.DoctosImpRelacionados.Where(y => (y.Tipoimpuesto == "CONCEPTO_IVA" || y.Tipoimpuesto == "CONCEPTO_IEPS") && y.Baseimp > 0)
                                                                    .GroupBy(x => new { x.Tipoimpuesto, x.Tipofactor, x.Tasa, x.Impuesto })
                                                                    .Select(y => new
                                                                    {

                                                                        Baseimp = y.Sum(w => w.Baseimp),
                                                                        Impuesto = y.Key.Impuesto,
                                                                        Tipofactor = y.Key.Tipofactor,
                                                                        Tasa = y.Key.Tasa,
                                                                        Importe = y.Sum(w => w.Importe)
                                                                    }
                                                                    ))
                    {

                        VirtualXML_Pagos20AddPagoImpuestosPTrasladoP(hXmlPtr,
                                        (impuesto.Baseimp ?? 0m).ToString("N2", nfi),
                                        impuesto.Impuesto ?? "",
                                        impuesto.Tipofactor ?? "",
                                        (impuesto.Tasa / 100.00m).ToString("N6", nfi),
                                        (impuesto.Importe ?? 0m).ToString("N2", nfi));
                    }



                    // resumen de impuestos de todos los documentos relacionados retenidos
                    foreach (var impuesto in c.DoctosImpRelacionados.Where(y => (y.Tipoimpuesto == "CONCEPTO_IVARETENIDO" || y.Tipoimpuesto == "CONCEPTO_ISRRETENIDO") && y.Baseimp > 0)
                                                                    .GroupBy(x => new { x.Tipoimpuesto, x.Tipofactor, x.Tasa, x.Impuesto })
                                                                    .Select(y => new
                                                                    {

                                                                        Impuesto = y.Key.Impuesto,
                                                                        Importe = y.Sum(w => w.Importe)
                                                                    }
                                                                    ))
                    {

                        VirtualXML_Pagos20AddPagoImpuestosPRetencionP(hXmlPtr,
                                        impuesto.Impuesto ?? "",
                                        (impuesto.Importe ?? 0m).ToString("N2", nfi));
                    }
                }



            }
        }



        private void FijarImpuestosInfo33()
        {
            VirtualXML_SetImpuestosInfo_cfdi33(hXmlPtr,
                                               impuestosInfo?.TotalTraslados,
                                               impuestosInfo?.TotalRetenciones);
        }

        private void FijarImpuestos33()
        {
            if (impuestosRetenidos != null)
            {
                foreach (Retencion r in impuestosRetenidos)
                {
                    VirtualXML_AddRetencion_cfdi33(hXmlPtr,
                                                   r.ImpuestoVal,
                                                   r.Importe);
                }
            }

            if (impuestosTrasladados != null)
            {

                foreach (Traslado t in impuestosTrasladados)
                {
                    VirtualXML_AddTraslado_cfdi33(hXmlPtr,
                                                  t.ImpuestoVal,
                                                  t.TipoFactor,
                                                  t.TasaCuota,
                                                  t.Importe);
                }
            }
        }

        private void FijarCFDIRelacionados33()
        {
            if (this.cfdiRelacionados != null)
            {
                foreach (KeyValuePair<string, List<String>> pair in cfdiRelacionados)
                {
                    //Console.WriteLine("{0}, {1}", pair.Key, pair.Value);
                    if (pair.Value != null && pair.Value.Count > 0)
                    {
                        VirtualXML_SetCfdiRelacionados_cfdi33(hXmlPtr, pair.Key);

                        foreach (string strUUID in pair.Value)
                        {

                            VirtualXML_AddCfdiRelacionado_cfdi33(hXmlPtr, strUUID);
                        }
                    }

                }
            }
        }




        private void FijarAdenda40()
        {
            VirtualXML_SetAddenda_cfdi40(hXmlPtr,
                                         addendas?.Texto);
        }


        private void FijarInformacionGlobal40()
        {
            VirtualXML_SetInformacionGlobal_cfdi40(hXmlPtr,
                                         informacionGlobal?.Periodicidad, informacionGlobal?.Meses, informacionGlobal?.Anio);
        }

        private void FijarComprobanteInfo40()
        {

            VirtualXML_SetComprobanteInfo_cfdi40(hXmlPtr,
                                                 comprobanteInfo?.Serie,
                                                 comprobanteInfo?.Folio,
                                                 comprobanteInfo?.Fecha,
                                                 comprobanteInfo?.FormaPago,
                                                 comprobanteInfo?.CondicionesPago,
                                                 comprobanteInfo?.Subtotal,
                                                 comprobanteInfo?.Descuento,
                                                 comprobanteInfo?.Moneda,
                                                 comprobanteInfo?.TipoCambio,
                                                 comprobanteInfo?.Total,
                                                 comprobanteInfo?.TipoComprobante,
                                                 comprobanteInfo?.MetodoPago,
                                                 comprobanteInfo?.LugarExpedicion,
                                                 comprobanteInfo?.Confirmacion,
                                                 comprobanteInfo?.Exportacion);
        }

        private void FijarEmisorInfo40()
        {
            VirtualXML_SetEmisorInfo_cfdi40(hXmlPtr,
                                            emisorInfo?.Rfc,
                                            emisorInfo?.RazonSocial,
                                            emisorInfo?.RegimenFiscal,
                                            null);
        }

        private void FijarReceptorInfo40()
        {
            VirtualXML_SetReceptorInfo_cfdi40(hXmlPtr,
                                              receptorInfo?.Rfc,
                                              receptorInfo?.Nombre,
                                              receptorInfo?.ResidenciaFiscal,
                                              receptorInfo?.NumRegIdTrib,
                                              receptorInfo?.UsoCFDI,
                                              receptorInfo?.DomicilioFiscalReceptor,
                                              receptorInfo?.RegimenFiscalReceptor);
        }

        private void FijarConceptos40()
        {
            if (conceptos == null)
                return;

            int iCount = 0;
            foreach (Concepto c in conceptos)
            {
                iCount++;
                VirtualXML_AddConcepto_cfdi40(hXmlPtr,
                                              c.ClaveProdServ,
                                              c.NoIdentificacion,
                                              c.Cantidad,
                                              c.ClaveUnidad,
                                              c.Unidad,
                                              c.Descripcion,
                                              c.ValorUnitario,
                                              c.Importe,
                                              c.Descuento == null ? "0.00" : c.Descuento,
                                              c.ObjetoImp);







                if (c.ImpuestosTrasladados != null)
                {
                    foreach (Traslado impu in c.ImpuestosTrasladados)
                    {
                        VirtualXML_AddConceptoTraslado_cfdi40(hXmlPtr, impu.BaseImp, impu.ImpuestoVal, impu.TipoFactor, impu.TasaCuota, impu.Importe);
                    }
                }

                if (c.ImpuestosRetenidos != null)
                {
                    foreach (Traslado impu in c.ImpuestosRetenidos)
                    {
                        VirtualXML_AddConceptoRetencion_cfdi40(hXmlPtr, impu.BaseImp, impu.ImpuestoVal, impu.TipoFactor, impu.TasaCuota, impu.Importe);
                    }
                }


                if (c.ComplementoConceptos != null)
                {
                    foreach (string info in c.ComplementoConceptos)
                    {
                        VirtualXML_AddComplementoConcepto_cfdi40(hXmlPtr, info);
                    }
                }


                if (c.InfoAduanera != null)
                {
                    foreach (InformacionAduanera infoAduanera in c.InfoAduanera)
                    {
                        VirtualXML_AddConceptoInformacionAduanera_cfdi40(hXmlPtr,
                                                                         infoAduanera.Numero);
                    }
                }


                if (c.ConceptoPartes != null)
                {
                    foreach (ConceptoParte info in c.ConceptoPartes)
                    {
                        VirtualXML_AddConceptoParte_cfdi40(hXmlPtr, info.ClaveProdServ, info.NoIdentificacion, info.Cantidad, info.Unidad, info.Descripcion, info.ValorUnitario, info.Importe, info.NumeroPedimento,"","","","");
                    }
                }





                if (!String.IsNullOrEmpty(c.CuentaPredial))
                {
                    VirtualXML_AddConceptoCuentaPredial_cfdi40(hXmlPtr, c.CuentaPredial);
                }


            }
        }



        


        private void FijarImpuestosInfo40()
        {
            VirtualXML_SetImpuestosInfo_cfdi40(hXmlPtr,
                                               (impuestosInfo?.TotalTraslados ?? ""),
                                               (impuestosInfo?.TotalRetenciones ?? ""));
        }

        private void FijarImpuestos40()
        {

            if (impuestosRetenidos != null)
            {
                foreach (Retencion r in impuestosRetenidos)
                {
                    VirtualXML_AddRetencion_cfdi40(hXmlPtr,
                                                   r.ImpuestoVal,
                                                   r.Importe);
                }
            }

            if (impuestosTrasladados != null)
            {

                foreach (Traslado t in impuestosTrasladados)
                {
                    VirtualXML_AddTraslado_cfdi40(hXmlPtr,
                                                  t.ImpuestoVal,
                                                  t.TipoFactor,
                                                  t.TasaCuota,
                                                  t.Importe,
                                                  t.BaseImp);
                }
            }
        }

        private void FijarCFDIRelacionados40()
        {
            if (this.cfdiRelacionados != null)
            {
                foreach (KeyValuePair<string, List<String>> pair in cfdiRelacionados)
                {
                    //Console.WriteLine("{0}, {1}", pair.Key, pair.Value);
                    if (pair.Value != null && pair.Value.Count > 0)
                    {
                        VirtualXML_AddCfdiRelacionados_cfdi40(hXmlPtr, pair.Key, "", "", "", "", "", "", "", "", "", "");

                        foreach (string strUUID in pair.Value)
                        {

                            VirtualXML_AddCfdiRelacionado_cfdi40(hXmlPtr, strUUID);
                        }
                    }

                }
            }
        }


        private void MostrarInfo()
        {

            var jsonStr = "";

            if (ICARTAPORTE != null)
            {
                jsonStr += "ICARTAPORTE" + JsonConvert.SerializeObject(ICARTAPORTE, Formatting.Indented) + System.Environment.NewLine;

            }

            jsonStr += "ComprobanteInfo " + JsonConvert.SerializeObject(ComprobanteInfo, Formatting.Indented) + System.Environment.NewLine;
            jsonStr += "ComprobanteInfoEx " + JsonConvert.SerializeObject(ComprobanteInfoEx, Formatting.Indented) + System.Environment.NewLine;
            jsonStr += "ComprobanteCfdInfo " + JsonConvert.SerializeObject(ComprobanteCfdInfo, Formatting.Indented) + System.Environment.NewLine;
            jsonStr += "EmisorInfo " + JsonConvert.SerializeObject(EmisorInfo, Formatting.Indented) + System.Environment.NewLine;
            jsonStr += "ReceptorInfo " + JsonConvert.SerializeObject(ReceptorInfo, Formatting.Indented) + System.Environment.NewLine;
            jsonStr += "Conceptos " + JsonConvert.SerializeObject(Conceptos, Formatting.Indented) + System.Environment.NewLine;
            jsonStr += "EmisorExpedidoEn " + JsonConvert.SerializeObject(EmisorExpedidoEn, Formatting.Indented) + System.Environment.NewLine;

            

            //jsonStr += "PagosSat " + JsonConvert.SerializeObject(PagosSat, Formatting.Indented) + System.Environment.NewLine;
            jsonStr += "ImpuestosTrasladados " + JsonConvert.SerializeObject(ImpuestosTrasladados, Formatting.Indented) + System.Environment.NewLine;
            jsonStr += "ImpuestosRetenidos " + JsonConvert.SerializeObject(ImpuestosRetenidos, Formatting.Indented) + System.Environment.NewLine;
            jsonStr += "ImpuestosInfo " + JsonConvert.SerializeObject(ImpuestosInfo, Formatting.Indented) + System.Environment.NewLine;
            jsonStr += "ImpuestosLocalesInfo " + JsonConvert.SerializeObject(ImpuestosLocalesInfo, Formatting.Indented) + System.Environment.NewLine;
            jsonStr += "LocalesTrasladados " + JsonConvert.SerializeObject(LocalesTrasladados, Formatting.Indented) + System.Environment.NewLine;
            jsonStr += "LocalesRetenidos " + JsonConvert.SerializeObject(LocalesRetenidos, Formatting.Indented) + System.Environment.NewLine;
            jsonStr += "Addendas " + JsonConvert.SerializeObject(Addendas, Formatting.Indented) + System.Environment.NewLine;

            //Reporteria.WFLongTextMessage rp = new Reporteria.WFLongTextMessage();
            //rp.MessageToShow = jsonStr;
            //rp.ShowDialog();
            //rp.Dispose();
            //GC.SuppressFinalize(rp);
        }


        private void MostrarError()
        {

            VirtualXML_ShowValue(hXml, 2, "Descripción del error");
            MostrarInfo();
        }

        private void MostrarErrorAsync(IntPtr hXmlPtr, int hXml)
        {
            Thread.Sleep(1000);

            if(_dispatcherMethodCall != null)
                _dispatcherMethodCall(hXml);

            //this.dispatcher.Invoke(new Action(() =>
            //{
            //    VirtualXML_ShowValue(hXml, 2, "Descripción del error");
            //    VirtualXML_Free(hXml);
            //}));


        }

        public static void ShowError(int hXml)
        {

            VirtualXML_ShowValue(hXml, 2, "Descripción del error");
            VirtualXML_Free(hXml);
        }

        private void MostrarErrorInThread(IntPtr hXmlPtr, int hXml)
        {

            Thread thread = new Thread(new ThreadStart(() => MostrarErrorAsync(hXmlPtr, hXml)));
            thread.Start();
        }


        private void FijarVirtualPacInfo(VirtualPACInfo? vpi)
        {
            if (vpi == null) return;

            VirtualXML_SetVirtualPACInfo(hXml, vpi.Usuario, vpi.Servidor);
        }

        private void FijarCiberSatInfo(CiberSATInfo? csi)
        {
            if (csi == null) return;

            VirtualXML_SetCiberSATInfo(hXml, csi.Usuario, csi.Llave);
        }

        private void FijarComprobanteInfo(ComprobanteInfo? ci)
        {
            if (ci == null) return;

            VirtualXML_SetComprobanteInfo(hXml, ci.Serie, ci.Folio, ci.Fecha, ci.TipoComprobante,
                                          ci.FormaPago, ci.Subtotal, ci.Descuento, ci.Total, ci.Moneda,
                                          ci.TipoCambio, ci.CondicionesPago, ci.MetodoPago, ci.MotivoDescuento);
        }

        private void FijarComprobanteInfoEx(ComprobanteInfoEx? cie)
        {
            if (cie == null)  return;

            VirtualXML_SetComprobanteInfoEx(hXml, cie.LugarExpedicion, cie.NumeroCtaPago, cie.SerieFolioFiscalOriginal,
                                            cie.FolioFiscalOriginal, cie.MontoFolioFiscalOriginal, cie.FechaFolioFiscalOriginal);
        }

        private void FijarComprobanteCfdInfo(ComprobanteCFDInfo? ccfdi)
        {
            if (ccfdi == null) return;

            VirtualXML_SetComprobanteCFDInfo(hXml, ccfdi.NumeroAprobacion, ccfdi.AnoAprobacion);
        }

        private void FijarEmisorInfo(EmisorInfo? e)
        {
            if (e == null) return;

            VirtualXML_SetEmisorInfo(hXml, e.Rfc, e.RazonSocial);
        }

        private void FijarEmisorRegimenFiscal(EmisorInfo? e)
        {
            if (e == null) return;

            VirtualXML_AddEmisorRegimenFiscal(hXml, e.RegimenFiscal);
        }

        private void FijarEmisorDomicilio(EmisorInfo? e)
        {
            if (e == null) return;

            VirtualXML_SetEmisorDomicilio(hXml, e.Domicilio?.Calle, e.Domicilio?.NoExterior,
                                          e.Domicilio?.NoInterior, e.Domicilio?.Colonia, e.Domicilio?.Localidad,
                                          e.Domicilio?.Referencia, e.Domicilio?.Municipio, e.Domicilio?.Estado,
                                          e.Domicilio?.Pais, e.Domicilio?.CodigoPostal);
        }

        private void FijarReceptorInfo(ReceptorInfo? ri)
        {
            if (ri == null) return;

            VirtualXML_SetReceptorInfo(hXml, ri.Rfc, ri?.RazonSocial);
        }

        private void FijarReceptorDomicilio(ReceptorInfo? ri)
        {

            if (ri == null) return;

            VirtualXML_SetReceptorDomicilio(hXml, ri?.Domicilio?.Calle, ri?.Domicilio?.NoExterior, ri?.Domicilio?.NoInterior,
                                            ri?.Domicilio?.Colonia, ri?.Domicilio?.Localidad, ri?.Domicilio?.Referencia,
                                            ri?.Domicilio?.Municipio, ri?.Domicilio?.Estado, ri?.Domicilio?.Pais, ri?.Domicilio?.CodigoPostal);
        }

        private void FijarConceptos()
        {
            if (conceptos == null) return;

            foreach (Concepto c in conceptos)
            {
                VirtualXML_AddConcepto(hXml, c.Cantidad, c.Unidad, c.Descripcion, c.ValorUnitario, c.Importe, c.NoIdentificacion);

                if (!String.IsNullOrEmpty(c.CuentaPredial))
                {
                    VirtualXML_AddCuentaPredial(hXml, c.CuentaPredial);
                }
                if (c.InfoAduanera != null)
                {
                    foreach (InformacionAduanera infoAduanera in c.InfoAduanera)
                    {
                        VirtualXML_AddInformacionAduanera(hXml, infoAduanera.Fecha, infoAduanera.Numero, infoAduanera.Aduana);
                    }
                }
            }
        }

        private void FijarImpuestos()
        {
            if (impuestosTrasladados != null)
            {
                foreach (Traslado t in impuestosTrasladados)
                {
                    VirtualXML_AddTraslado(hXml, t.ImpuestoVal, t.Tasa, t.Importe);
                }
            }

            if (impuestosRetenidos != null)
            {

                foreach (Retencion r in impuestosRetenidos)
                {
                    VirtualXML_AddRetencion(hXml, r.ImpuestoVal, r.Importe);
                }
            }
        }

        private void FijarImpuestosLocalesInfo()
        {
            VirtualXML_SetImpuestosLocalesInfo(hXml, impuestosLocalesInfo?.TotalTraslados, impuestosLocalesInfo?.TotalRetenciones);
        }

        private void FijarImpuestosLocalesTrasladados()
        {
            if (localesTrasladados == null) return;

            foreach (ImpuestoLocalTrasladado t in localesTrasladados)
            {
                VirtualXML_AddImpuestoLocalTrasladado(hXml, t.ImpuestoVal, t.Tasa, t.Importe);
            }
        }

        private void FijarImpuestosLocalesRetenidos()
        {
            if(localesRetenidos == null) return;

            foreach (ImpuestoLocalRetenido r in localesRetenidos)
            {
                VirtualXML_AddImpuestoLocalRetenido(hXml, r.ImpuestoVal, r.Tasa, r.Importe);
            }
        }

        private void FijarAddendas()
        {
            VirtualXML_SetAddenda(hXml, addendas?.Xml);
            VirtualXML_SetAddendaText(hXml, addendas?.Texto);
        }

        private void FijarEmisorExpedidoEn()
        {
            VirtualXML_SetEmisorExpedidoEn(hXml, emisorExpedidoEn?.Calle, emisorExpedidoEn?.NoExterior, emisorExpedidoEn?.NoInterior,
                                           emisorExpedidoEn?.Colonia, emisorExpedidoEn?.Localidad, emisorExpedidoEn?.Referencia,
                                           emisorExpedidoEn?.Municipio, emisorExpedidoEn?.Estado, emisorExpedidoEn?.Pais, emisorExpedidoEn?.CodigoPostal);
        }

        private void CrearRutasDeArchivos()
        {

        }

        private int ProcesarDocumento()
        {
            return VirtualXML_ProcesaDocumento(hXml, rutaCsd, llave, claveLlave, rutaXml);
        }

        private string ObtenerResultadoEnModoTexto()
        {
            int resultType = (int)VirtualXmlResultValues.DESCERROR;

            string result = VirtualXML_GetValue(hXml, resultType) ?? String.Empty;

            return result;
        }



        public int CancelarDocumento(String szUser, String szEmisor, String szCert, String szKey, String szPwd, String szUuid, String szOut)
        {



            return VirtualXML_CancelaUUID(szUser, szEmisor, szCert, szKey, szPwd, szUuid, szOut);

        }


        public int CancelarCFDI(String szUser, String szEmisor, String szCert, String szKey, String szPwd, String szUuid, String szOut, String szRfcReceptor, String szTotal, String szLog, String szOutIni)
        {

            String szReserved = "";
            return VirtualXML_CancelaCFDI(szUser, szEmisor, szRfcReceptor, szTotal, szUuid, szCert, szKey, szPwd, szOutIni, szLog, szReserved);

        }

        public int CancelaCFDI2022W(String szUsuario, String szRfcEmisor, String szMotivo, String szUuid, String szFolioSust, String szCert, String szKey, String szPwd, String szServer, String szResult, String szLog)
        {
           
            return VirtualXML_CancelaCFDI2022W(szUsuario,  szRfcEmisor, szMotivo,  szUuid,  szFolioSust,  szCert,  szKey,  szPwd,  szServer, szResult,  szLog);

        }

        public int CancelaCFDI2022SSL(String szUsuario, String szRfcEmisor, String szMotivo, String szUuid, String szFolioSust, String szCert, String szKey, String szPwd, String szServer, String szResult, String szLog)
        {

            return VirtualXML_CancelaCFDI2022SSL(szUsuario, szRfcEmisor, szMotivo, szUuid, szFolioSust, szCert, szKey, szPwd, szServer, szResult, szLog);

        }

        public int GetStatusCFDI(string szUsuario, string szRfcEmisor, string szRfcReceptor, string szTotal, string szUuid, string szResult, string szLog)
        {


            String szReserved = "";
            return VirtualXML_GetStatusCFDI(szUsuario, szRfcEmisor, szRfcReceptor, szTotal, szUuid, szResult, szLog, szReserved);

        }


        private void FijarSetCartaPorte20(CartaporteBindingModel? e)
        {
            if (e == null) return;

            VirtualXML_SetCartaPorte20(hXmlPtr, e.TranspInternac, e.EntradaSalidaMerc, e.PaisOrigenDestino, e.ViaEntradaSalida, e.TotalDistRec
        );
        }


        private void FijarCartaPorte20AddUbicacionList(List<CartaporteUbicacionBindingModel> list)
        {
            foreach (var item in list)
            {
                FijarCartaPorte20AddUbicacion(item);
            }
        }

        private void FijarCartaPorte20AddUbicacion(CartaporteUbicacionBindingModel e)
        {
            VirtualXML_CartaPorte20AddUbicacion(hXmlPtr, e.Tipoubicacion, e.Idubicacion, e.Rfcremitentedestinatario, 
                                                         e.Nombreremitentedestinatario, e.Numregidtrib, e.Residenciafiscal, 
                                                         e.Numestacion, e.Nombreestacion, e.Navegaciontrafico, 
                                                         e.Fechahorasalidallegada, e.Tipoestacion, e.Distanciarecorrida, 
                                                         e.Calle, e.Numeroexterior, e.Numerointerior, 
                                                         e.Colonia, e.Localidad, e.Referencia, 
                                                         e.Municipio, e.Estado, e.Pais, e.Codigopostal
                    );
        }

        private void FijarCartaPorte20SetMercancias(CartaporteTotalmercanciasBindingModel e)
        {
            VirtualXML_CartaPorte20SetMercancias(hXmlPtr, e.Pesobrutototal, e.Unidadpeso, e.Pesonetototal, 
                                                          e.Numtotalmercancias, e.Cargoportasacion
                        );
        }



        private void FijarCartaPorte20AddMercanciaList(List<CartaporteMercanciaBindingModel> list)
        {
            foreach (var item in list)
            {
                FijarCartaPorte20AddMercancia(item);
            }
        }

        private void FijarCartaPorte20AddMercancia(CartaporteMercanciaBindingModel e)
        {
            string? materialPeligroso = e.Materialpeligroso == "Si" ? "Sí" : e.Materialpeligroso;
            VirtualXML_CartaPorte20AddMercancia(hXmlPtr, e.Bienestransp, e.Clavestcc, e.Descripcion, e.Cantidad,
                                                         e.Claveunidad, e.Unidad, e.Dimensiones, materialPeligroso, 
                                                         e.Cvematerialpeligroso, e.Embalaje, e.Descripembalaje, e.Pesoenkg, 
                                                         e.Valormercancia, e.Moneda, e.Fraccionarancelaria, e.Uuidcomercioext, 
                                                         e.Unidadpesomerc, e.Pesobruto, e.Pesoneto, e.Pesotara, e.Numpiezas
                                            );
        }

        private void FijarCartaPorte20AddMercanciaCantidadTransporta(CartaporteCanttranspBindingModel e)
        {
            VirtualXML_CartaPorte20AddMercanciaCantidadTransporta(hXmlPtr, e.Cantidad, e.Idorigen, 
                                                                           e.Iddestino, e.Cvestransporte
                                                                );
        }



        private void FijarCartaPorte20AddFiguraTransporteTiposFiguraList(List<CartaporteTransptipofiguraBindingModel> list)
        {
            foreach (var item in list)
            {
                FijarCartaPorte20AddFiguraTransporteTiposFigura(item);
            }
        }

        private void FijarCartaPorte20AddFiguraTransporteTiposFigura(CartaporteTransptipofiguraBindingModel e)
        {
            VirtualXML_CartaPorte20AddFiguraTransporteTiposFigura(hXmlPtr, e.Tipofigura, e.Rfcfigura, e.Numlicencia, 
                                                                           e.Nombrefigura, e.Numregidtribfigura, e.Residenciafiscalfigura, 
                                                                           e.Partetransporte, e.Calle, e.Numeroexterior, e.Numerointerior, 
                                                                           e.Colonia, e.Localidad, e.Referencia, e.Municipio, e.Estado, 
                                                                           e.Pais, e.Codigopostal
                                                                    );
        }


        private void FijarCartaPorte20SetMercanciasAutotransporte(CartaporteAutotranspBindingModel e)
        {
            VirtualXML_CartaPorte20SetMercanciasAutotransporte(hXmlPtr, e.Permsct, e.Numpermisosct, e.Configvehicular, 
                                                                        e.Placavm, e.Aniomodelovm, e.Asegurarespcivil, 
                                                                        e.Polizarespcivil, e.Aseguramedambiente, e.Polizamedambiente,
                                                                        e.Aseguracarga, e.Polizacarga, e.Primaseguro, 
                                                                        e.Subtiporem1, e.Placa1, e.Subtiporem2, e.Placa2);
        }



        private void FijarCartaPorte()
        {
            if (ICARTAPORTE == null) return;

            try
            {
                FijarSetCartaPorte20(ICARTAPORTE);
                if (ICARTAPORTE.CartaporteUbicacions != null)
                    FijarCartaPorte20AddUbicacionList(ICARTAPORTE.CartaporteUbicacions!.ToList());


                if (ICARTAPORTE.CartaporteTotalmercancias != null)
                    FijarCartaPorte20SetMercancias(ICARTAPORTE.CartaporteTotalmercancias);
                
                if(ICARTAPORTE.CartaporteMercancias != null)
                    FijarCartaPorte20AddMercanciaList(ICARTAPORTE.CartaporteMercancias!.ToList());

                if (ICARTAPORTE.CartaporteCanttransps != null)
                    FijarCartaPorte20AddMercanciaCantidadTransporta(ICARTAPORTE.CartaporteCanttransps!);

                if(ICARTAPORTE.CartaporteAutotransps != null)
                    FijarCartaPorte20SetMercanciasAutotransporte(ICARTAPORTE.CartaporteAutotransps!);

                if(ICARTAPORTE.CartaporteTransptipofiguras != null)
                    FijarCartaPorte20AddFiguraTransporteTiposFiguraList(ICARTAPORTE.CartaporteTransptipofiguras!.ToList());
            }
            catch
            {
            }
        }




        public static void FacturaSimple(string szVersion)
        {

            int hXml = 0;

            // Version del comprobante a generar

            hXml = VirtualXML_New("3.2");

            // Informacion de conexion al PAC ( para versiones 3.2 y 3.0 )

            VirtualXML_SetVirtualPACInfo(hXml,

            "demo_i-pos", // Nombre del distribuidor de VirtualPAC

            "virtual"
            ); // Servidor al que va a enviar a timbrar

            // Informacion del Comprobante

            VirtualXML_SetComprobanteInfo(hXml,

            "NOM", // Serie

            "1", // Folio

            "2017-06-14T11:10:10", // Fecha de emision en formato AAAA-MM-DDTHH:MM:SS ó macro %cb_date que toma la hora del equipo

            "egreso", // Para nomina, la leyenda egreso

            "Pago en una sola exhibición", // Forma de pago del documento pago en una sola exhibición|parcialidad n de n

            "2470.50", // Sumatoria de los importes de los conceptos ( que es la suma de las percepciones gravadas y excentas )

            "765.77", // Descuento total de las deducciones excepto el ISR

            "1704.73", // Pago realizado al trabajado

            "Pesos", // Moneda en la que esta expresada el comprobante, si se usa se debe de especificar tipo de cambio

            "1.00", // Tipo de cambio

            "", // Condiciones de Pago

            "Deposito Bancario", // Metodo de pago

            "Deducciones Nomina"); // Motivo de descuento debe de llevar la leyenda deducciones nomina

            // necesario en versiones 2.2 y 3.2

            // Informacion extendica del comprobante

            VirtualXML_SetComprobanteInfoEx(hXml,

            "Pachuca de soto, hidalgo", // Plaza donde labora el empleado

            "", // Ultimos 4 digitos de la cuenta de pago

            "", // Serie del comprobante original ( para parcialidades )

            "", // Folio del comprobante original ( para parcialidades )

            "", // Monto del comprobante original ( para parcialidades )

            ""); // Fecha del comprobante original ( para parcialidades )

            // Datos del emisor

            VirtualXML_SetEmisorInfo(hXml,

            "AAA010101AAA", // rfc del emisor ( Patron )

            "Patron de prueba"); // Patron ( el que paga la nomina )

            // Informacion del Regimen Fiscal para versiones 2.2 y 3.2

            VirtualXML_AddEmisorRegimenFiscal(hXml,

            "Persona Física Actividad Empresarial"); // Regimen Fiscal

            // Domicilio del emisor

            VirtualXML_SetEmisorDomicilio(hXml,

            "CALZ DEL HUESO", // Calle

            "77", // Numero Exterior

            "DEPTO 201", // Numero Interior

            "COAPA", // Colonia

            "COYOACAN", // Localidad

            "", // Referencia

            "COYOACAN", // Municipio

            "DISTRITO FEDERAL", // Estado

            "MEXICO", // Pais

            "03020"); // Codigo Postal

            // Datos del receptor

            VirtualXML_SetReceptorInfo(hXml,

            "LILO781103XX3", // RFC del receptor

            "Limon Lopez Osvaldo"); // Nombre del receptor

            // Domicilio del emisor ( Para cuestiones practicas solo se puso el Pais que es el unico obligatorio

            VirtualXML_SetReceptorDomicilio(hXml, "", "", "", "", "", "", "", "", "Mexico", "");

            // Conceptos

            VirtualXML_AddConcepto(hXml,

            "1", // Cantidad ( siempre va a ir 1 )

            "Servicio", // Unidad de medida ( servicio )

            "Pago de Nomina", // Descripcion ( se podra incluir Pago de Nomina, Aguinaldo, Vacaciones, Fondo de ahorro, Liqudacion, Finiquito, etc )

            "2470.50", // Precio ( El total de las percepciones gravadas y excentas )

            "2470.50", // Importe ( El total de las percepciones gravadas y excentas )

            ""); // Numero de identificacion ( dejar vacio )

            //VirtualXML_SetNomina(hXml,

            //"63", // Numero de trabajador

            //"PUXB571021HNELXR00", // Curp

            //"2", // Regimen de contratacion pueder ser del 1 al 4 ( revisar catalogo en la pagina del SAT )

            //"2013-05-15", // Fecha de pago

            //"2013-12-01", // Fecha inicial de pago

            //"2013-12-07", // Fecha final de pago

            //"15", // Numero de dias pagados

            //"Quincenal", // Periocidad de pago

            //"100", // Antiguedad (Opcional ) Numero de semanas que el empleado a mantenido relacion laboral

            //"002", // Banco ( Opcional ) Banco conforme al catalogo donde se deposita al empleado

            //"123456789012345678", // Clabe ( Opcional ) Numero de cuenta interbancario donde se deposita al empleado

            //"", // Departamente ( Opcional )

            //"", // Fecha de inicio de relacion Laboral ( opcional )

            //"", // Numero de seguro social (opcional)

            //"", // Puesto opcional

            //"1234567890", // Registro patronal

            //"", // Riesgo Puesto ( Opcional ) ver catalogo del SAT

            //"", // Salario Base ( Opcional )

            //"", // Salario Integrado ( Opcional )

            //"", // Tipo de contrato ( Opcional )

            //""); // Tipo de jornada ( Opcional )

            //VirtualXML_NominaSetPercepciones(hXml,

            //"2470.50", // total Gravado

            //"0.00"); // Total Excento

            //VirtualXML_NominaAddPercepcion(hXml,

            //"001", // Clave de acuerdo al catalogo del SAT

            //"SAL01", // CLave interna del patron

            //"SUELDO", // Descripcion

            //"2470.50", // Total Gravado

            //"0.00"); // Total Excento

            //VirtualXML_NominaSetDeducciones(hXml,

            //"0.00",

            //"765.77");

            //VirtualXML_NominaAddDeduccion(hXml, "002", "ISR", "ISR RETENIDO", "0.00", "4.36");

            //VirtualXML_NominaAddDeduccion(hXml, "004", "COLEG", "ESTUDIOS POS", "0.00", "700.00");

            //VirtualXML_NominaAddDeduccion(hXml, "001", "S.S.", "SEGURIDAD SOCIAL", "0.00", "61.41");

            VirtualXML_SetImpuestosInfo(hXml, "", "4.36");

            // Impuestos

            VirtualXML_AddRetencion(hXml,

            "ISR", // Impuesto

            "4.36"); // Importe

            //Procesamos el documento

            int nResult = VirtualXML_ProcesaDocumento(hXml,

             "CSD01_AAA010101AAA.cer", // Certificado de Sello Digital

             "CSD01_AAA010101AAA.key", // Llave privada

             "12345678a", // Password de la llave privada

             "salida.xml"); // Fichero de salida





            if (nResult != 0)
            {
                if (nResult == -2)
                {

                    VirtualXML_ShowValue(hXml, 2, "test");
                }

                if (nResult == -12)
                {

                    VirtualXML_ShowValue(hXml, 2, "test");
                }
                // Ocurrio un Error, mostramos el valor 1 y 2
                //VirtualXML_ShowError(hXml, 1);    // Error en modo texto
                //VirtualXML_ShowError(hXml, 2);    // Descripcion detallada del Error
            }


            // Obtenemos resultados

            //string resultado = VirtualXML_GetValue(hXml, VIRTUALXML_GET_DESCERROR); // 1

            //VirtualXML_ShowValue(hXml, VIRTUALXML_GET_ERROR, VirtualXML_GetValue(hXml, VIRTUALXML_GET_ERROR));

            // Liberamos Memoria

            VirtualXML_Free(hXml);

        }


        public static List<bool> MatchPatronFormaPagoList(string str, List<string> patterns, bool exact)
        {
            List<bool> results = new List<bool>();

            foreach (string pattern in patterns)
            {
                results.Add(Regex.IsMatch(str, CuentaFormaPagoPattern(pattern, exact)));
            }

            return results;
        }

        public static bool MatchPatronFormaPago(string str, string pattern, bool exact)
        {

            return Regex.IsMatch(str, CuentaFormaPagoPattern(pattern, exact));

        }





        private static string CuentaFormaPagoPattern(string pattern, bool exact)
        {
            string[] splittedPatterns = pattern.Split('|');

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < splittedPatterns.Count(); i++)
            {
                string p = splittedPatterns[i];

                stringBuilder.Append("^");
                stringBuilder.Append(p);
                stringBuilder.Append("$");

                if (!exact)
                    stringBuilder.Append("*");


                if (i < splittedPatterns.Count() - 1)
                    stringBuilder.Append("|");
            }

            return stringBuilder.ToString();
        }


    }
}
