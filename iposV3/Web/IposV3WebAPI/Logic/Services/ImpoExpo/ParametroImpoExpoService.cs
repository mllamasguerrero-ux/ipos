
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Collections;
using System.Data.Common;
using IposV3.Model;
using Microsoft.EntityFrameworkCore;
using NpgsqlTypes;
using FirebirdSql.Data.FirebirdClient;
using Controllers.Controller;
using BindingModels;
using System.Data;

namespace IposV3.Services
{



    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class ParametroImpoExpoService : BaseImpoExpoService
    {

        public void ImportarDeTablaFirebird(
                          long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                          string fbCadenaConexion,
                          string? nombreTabla, string? queryPersonalizada,
                           ApplicationDbContext localContext, ParametroController parametroController)
        {
            /**/
            FbDataReader? dr = null;
            FbConnection? pcn = null;

            var utf8 = new UTF8Encoding();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();

                String CmdTxt = @"SELECT
   PARAMETRO.NOMBRE as NOMBRE, 
PARAMETRO.CALLE as CALLE, 
PARAMETRO.COLONIA as COLONIA,
PARAMETRO.ESTADO as ESTADO,
PARAMETRO.ESTADO_DEF as ESTADO_DEF, 
PARAMETRO.LISTA_PRECIO_TRASPASO as LISTA_PRECIO_TRASPASO, 
PARAMETRO.INVENTORY_EMAIL as INVENTORY_EMAIL, 
PARAMETRO.ID_DOSLETRAS as ID_DOSLETRAS, 
PARAMETRO.FTPHOST as FTPHOST, 
PARAMETRO.FTPUSUARIO as FTPUSUARIO, 
PARAMETRO.FTPPASSWORD as FTPPASSWORD, 
PARAMETRO.SMTPHOST as SMTPHOST, 
PARAMETRO.SMTPUSUARIO as SMTPUSUARIO, 
PARAMETRO.SMTPPASSWORD as SMTPPASSWORD, 
PARAMETRO.SMTPMAILFROM as SMTPMAILFROM, 
PARAMETRO.SMTPMAILTO as SMTPMAILTO, 
PARAMETRO.HEADER as HEADER, 
PARAMETRO.FOOTER as FOOTER, 
PARAMETRO.NUMEROEXTERIOR as NUMEROEXTERIOR, 
PARAMETRO.NUMEROINTERIOR as NUMEROINTERIOR, 
PARAMETRO.FISCALCALLE as FISCALCALLE, 
PARAMETRO.FISCALNUMEROINTERIOR as FISCALNUMEROINTERIOR, 
PARAMETRO.FISCALNUMEROEXTERIOR as FISCALNUMEROEXTERIOR, 
PARAMETRO.FISCALCOLONIA as FISCALCOLONIA, 
PARAMETRO.FISCALMUNICIPIO as FISCALMUNICIPIO, 
PARAMETRO.FISCALESTADO as FISCALESTADO, 
PARAMETRO.FISCALCODIGOPOSTAL as FISCALCODIGOPOSTAL, 
PARAMETRO.CERTIFICADOCSD as CERTIFICADOCSD, 
PARAMETRO.TIMBRADOUSER as TIMBRADOUSER, 
PARAMETRO.TIMBRADOPASSWORD as TIMBRADOPASSWORD, 
PARAMETRO.TIMBRADOARCHIVOCERTIFICADO as TIMBRADOARCHIVOCERTIFICADO, 
PARAMETRO.TIMBRADOARCHIVOKEY as TIMBRADOARCHIVOKEY, 
PARAMETRO.TIMBRADOKEY as TIMBRADOKEY, 
PARAMETRO.FISCALNOMBRE as FISCALNOMBRE, 
PARAMETRO.SERIESAT as SERIESAT, 
PARAMETRO.FOOTERVENTAAPARTADO as FOOTERVENTAAPARTADO, 
PARAMETRO.FTPFOLDER as FTPFOLDER, 
PARAMETRO.FTPFOLDERPASS as FTPFOLDERPASS, 
PARAMETRO.SERIESATDEVOLUCION as SERIESATDEVOLUCION, 
PARAMETRO.PREFIJOBASCULA as PREFIJOBASCULA, 
PARAMETRO.PACNOMBRE as PACNOMBRE, 
PARAMETRO.PACUSUARIO as PACUSUARIO, 
PARAMETRO.RUTAREPORTES as RUTAREPORTES, 
PARAMETRO.RECIBOLARGOPRINTER as RECIBOLARGOPRINTER, 
PARAMETRO.FISCALREGIMEN as FISCALREGIMEN, 
PARAMETRO.RUTAIMAGENESPRODUCTO as RUTAIMAGENESPRODUCTO, 
PARAMETRO.FACT_ELECT_FOLDER as FACT_ELECT_FOLDER, 
PARAMETRO.PEDIDOS_FOLDER as PEDIDOS_FOLDER, 
PARAMETRO.PREFIJOCLIENTE as PREFIJOCLIENTE, 
PARAMETRO.CUENTAIEPS as CUENTAIEPS, 
PARAMETRO.WEBSERVICE as WEBSERVICE, 
PARAMETRO.TIPOSYNCMOVIL as TIPOSYNCMOVIL, 
PARAMETRO.ORDENIMPRESION as ORDENIMPRESION, 
PARAMETRO.LOCALFTPHOST as LOCALFTPHOST, 
PARAMETRO.LOCALWEBSERVICE as LOCALWEBSERVICE, 
PARAMETRO.MAILTOINVENTARIO as MAILTOINVENTARIO, 
PARAMETRO.RUTARESPALDOSZIP as RUTARESPALDOSZIP, 
PARAMETRO.SCREENCONFIG as SCREENCONFIG, 
PARAMETRO.TAMANOLETRATICKET as TAMANOLETRATICKET, 
PARAMETRO.BDLOCALREPL as BDLOCALREPL, 
PARAMETRO.TIPOVENDEDORMOVIL as TIPOVENDEDORMOVIL, 
PARAMETRO.BDSERVERWS as BDSERVERWS, 
PARAMETRO.BDMATRIZMOVIL as BDMATRIZMOVIL, 
PARAMETRO.RUTAREPORTESSISTEMA as RUTAREPORTESSISTEMA, 
PARAMETRO.DESCUENTOTIPO1TEXTO as DESCUENTOTIPO1TEXTO, 
PARAMETRO.DESCUENTOTIPO2TEXTO as DESCUENTOTIPO2TEXTO, 
PARAMETRO.DESCUENTOTIPO3TEXTO as DESCUENTOTIPO3TEXTO, 
PARAMETRO.DESCUENTOTIPO4TEXTO as DESCUENTOTIPO4TEXTO, 
PARAMETRO.RUTARESPALDO as RUTARESPALDO, 
PARAMETRO.MAILEJECUTIVO as MAILEJECUTIVO, 
PARAMETRO.FORMATOTICKETCORTOID as FORMATOTICKETCORTOID, 
PARAMETRO.SERIESATABONO as SERIESATABONO, 
PARAMETRO.RUTAARCHIVOSADJUNTOS as RUTAARCHIVOSADJUNTOS, 
PARAMETRO.FORMATOFACTELECT as FORMATOFACTELECT, 
PARAMETRO.WSMENSAJERIA as WSMENSAJERIA, 
PARAMETRO.IPWEBSERVICEAPPINV as IPWEBSERVICEAPPINV, 
PARAMETRO.RUTABDAPPINVENTARO as RUTABDAPPINVENTARO, 
PARAMETRO.RUTADBFEXISTENCIASUC as RUTADBFEXISTENCIASUC, 
PARAMETRO.TIPOSELECCIONCATALOGOSAT as TIPOSELECCIONCATALOGOSAT, 
PARAMETRO.VERSIONCFDI as VERSIONCFDI, 
PARAMETRO.WSESPECIALEXISTMATRIZ as WSESPECIALEXISTMATRIZ, 
PARAMETRO.RUTAREPLICADOREXE as RUTAREPLICADOREXE, 
PARAMETRO.TICKETESPECIAL as TICKETESPECIAL, 
PARAMETRO.TICKETDEFAULTPRINTER as TICKETDEFAULTPRINTER, 
PARAMETRO.RECARGASDEFAULTPRINTER as RECARGASDEFAULTPRINTER, 
PARAMETRO.PVCOLOREAR as PVCOLOREAR, 
PARAMETRO.RUTACATALOGOSUPD as RUTACATALOGOSUPD, 
PARAMETRO.RUTAIMPORTADATOS as RUTAIMPORTADATOS, 
PARAMETRO.DESTINOBDVENMOV as DESTINOBDVENMOV, 
PARAMETRO.RUTAPOLIZAPDF as RUTAPOLIZAPDF, 
PARAMETRO.RECIBOLARGOCOTIPRINTER as RECIBOLARGOCOTIPRINTER, 
PARAMETRO.WSDBF as WSDBF, 
PARAMETRO.MONEDEROCAMPOREF as MONEDEROCAMPOREF, 
PARAMETRO.IMPRESORACOMANDA as IMPRESORACOMANDA, 
PARAMETRO.SERIECOMPRTRASLSAT as SERIECOMPRTRASLSAT, 
PARAMETRO.RUTAFIRMAIMAGENES as RUTAFIRMAIMAGENES, 
PARAMETRO.PROMOCION as PROMOCION, 
PARAMETRO.HABILITAR_IMPEXP_AUT as HABILITAR_IMPEXP_AUT, 
PARAMETRO.CAMBIARPRECIO as CAMBIARPRECIO, 
PARAMETRO.COMPRAENTIENDA as COMPRAENTIENDA, 
PARAMETRO.HAB_SEL_CLIENTE as HAB_SEL_CLIENTE, 
PARAMETRO.HAB_IMPR_COTIZACION as HAB_IMPR_COTIZACION, 
PARAMETRO.MOSTRAR_EXIS_SUC as MOSTRAR_EXIS_SUC, 
PARAMETRO.REQ_APROBACION_INV as REQ_APROBACION_INV, 
PARAMETRO.REABRIRCORTES as REABRIRCORTES, 
PARAMETRO.IMP_PROD_TOTAL as IMP_PROD_TOTAL, 
PARAMETRO.USARFISCALESENEXPEDICION as USARFISCALESENEXPEDICION, 
PARAMETRO.HAB_FACTURAELECTRONICA as HAB_FACTURAELECTRONICA, 
PARAMETRO.CAMBIARPRECIOXUEMPAQUE as CAMBIARPRECIOXUEMPAQUE, 
PARAMETRO.CAMBIARPRECIOXPZACAJA as CAMBIARPRECIOXPZACAJA, 
PARAMETRO.HAYVENDEDORPISO as HAYVENDEDORPISO, 
PARAMETRO.ENVIOAUTOMATICOEXISTENCIAS as ENVIOAUTOMATICOEXISTENCIAS, 
PARAMETRO.MONEDEROAPLICAR as MONEDEROAPLICAR, 
PARAMETRO.IMPRIMIRNUMEROPIEZAS as IMPRIMIRNUMEROPIEZAS, 
PARAMETRO.CORTEPORMAIL as CORTEPORMAIL, 
PARAMETRO.CAMPOSCUSTOMALIMPORTAR as CAMPOSCUSTOMALIMPORTAR, 
PARAMETRO.RECIBOLARGOCONFACTURA as RECIBOLARGOCONFACTURA, 
PARAMETRO.RECIBOLARGOPREVIEW as RECIBOLARGOPREVIEW, 
PARAMETRO.PREGUNTARRAZONPRECIOMENOR as PREGUNTARRAZONPRECIOMENOR, 
PARAMETRO.PREGUNTARDATOSENTREGA as PREGUNTARDATOSENTREGA, 
PARAMETRO.ARRENDATARIO as ARRENDATARIO, 
PARAMETRO.MOSTRARIMAGENENVENTA as MOSTRARIMAGENENVENTA, 
PARAMETRO.MOSTRARMONTOAHORRO as MOSTRARMONTOAHORRO, 
PARAMETRO.SMTPSSL as SMTPSSL, 
PARAMETRO.MOSTRARDESCUENTOFACTURA as MOSTRARDESCUENTOFACTURA, 
PARAMETRO.EXPORTCATALOGOAUX as EXPORTCATALOGOAUX, 
PARAMETRO.UIVENTACONCANTIDAD as UIVENTACONCANTIDAD, 
PARAMETRO.MOSTRARPZACAJAENFACTURA as MOSTRARPZACAJAENFACTURA, 
PARAMETRO.DESGLOSEIEPS as DESGLOSEIEPS, 
PARAMETRO.DIVIDIR_REM_FACT as DIVIDIR_REM_FACT, 
PARAMETRO.MANEJASUPERLISTAPRECIO as MANEJASUPERLISTAPRECIO, 
PARAMETRO.MANEJAALMACEN as MANEJAALMACEN, 
PARAMETRO.MANEJARECETA as MANEJARECETA, 
PARAMETRO.AUTOCOMPPROD as AUTOCOMPPROD, 
PARAMETRO.MANEJAQUOTA as MANEJAQUOTA, 
PARAMETRO.TOUCH as TOUCH, 
PARAMETRO.ESVENDEDORMOVIL as ESVENDEDORMOVIL, 
PARAMETRO.CAJASBOTELLAS as CAJASBOTELLAS, 
PARAMETRO.PRECIONETOENPV as PRECIONETOENPV, 
PARAMETRO.MOSTRARFLASH as MOSTRARFLASH, 
PARAMETRO.AUTOCOMPCLIENTE as AUTOCOMPCLIENTE, 
PARAMETRO.PRECIOXCAJAENPV as PRECIOXCAJAENPV, 
PARAMETRO.USARCONEXIONLOCAL as USARCONEXIONLOCAL, 
PARAMETRO.PROMOENTICKET as PROMOENTICKET, 
PARAMETRO.MANEJAKITS as MANEJAKITS, 
PARAMETRO.REBAJAESPECIAL as REBAJAESPECIAL, 
PARAMETRO.HABILITARREPL as HABILITARREPL, 
PARAMETRO.PENDMOVILANTESVENTA as PENDMOVILANTESVENTA, 
PARAMETRO.PRECIOSMOVILANTESVENTA as PRECIOSMOVILANTESVENTA, 
PARAMETRO.RECALCULARCAMBIOCLIENTE as RECALCULARCAMBIOCLIENTE, 
PARAMETRO.MOVILPROCESOSURTIDO as MOVILPROCESOSURTIDO, 
PARAMETRO.MOVILVERIFICARVENTA as MOVILVERIFICARVENTA, 
PARAMETRO.REQAUTCANCELARCOTI as REQAUTCANCELARCOTI, 
PARAMETRO.REQAUTELIMDETALLECOTI as REQAUTELIMDETALLECOTI, 
PARAMETRO.ABRIRCAJONALFINCORTE as ABRIRCAJONALFINCORTE, 
PARAMETRO.HABSURTIDOPOSTPUESTO as HABSURTIDOPOSTPUESTO, 
PARAMETRO.DOBLECOPIAREMISION as DOBLECOPIAREMISION, 
PARAMETRO.REIMPRESIONESCONMARCA as REIMPRESIONESCONMARCA, 
PARAMETRO.HABTOTALIZADOS as HABTOTALIZADOS, 
PARAMETRO.MULTIPLETIPOVALE as MULTIPLETIPOVALE, 
PARAMETRO.HABILITARLOG as HABILITARLOG, 
PARAMETRO.MANEJARRETIRODECAJA as MANEJARRETIRODECAJA, 
PARAMETRO.APLICARMAYOREOPORLINEA as APLICARMAYOREOPORLINEA, 
PARAMETRO.PREGUNTACANCELACOTIZACION as PREGUNTACANCELACOTIZACION, 
PARAMETRO.HABVERIFICACIONCXC as HABVERIFICACIONCXC, 
PARAMETRO.VENTASXCORTEEMAIL as VENTASXCORTEEMAIL, 
PARAMETRO.HABVENTASAFUTURO as HABVENTASAFUTURO, 
PARAMETRO.SERVICIOSEMIDA as SERVICIOSEMIDA, 
PARAMETRO.HABIMPRESIONCORTECAJERO as HABIMPRESIONCORTECAJERO, 
PARAMETRO.HABTRASLADOPORAUTORIZACION as HABTRASLADOPORAUTORIZACION, 
PARAMETRO.HABVENTASMOSTRADOR as HABVENTASMOSTRADOR, 
PARAMETRO.HABPAGOSERVEMIDA as HABPAGOSERVEMIDA, 
PARAMETRO.HABPROMOXMONTOMIN as HABPROMOXMONTOMIN, 
PARAMETRO.PRECIOSORDENADOS as PRECIOSORDENADOS, 
PARAMETRO.EANPUEDEREPETIRSE as EANPUEDEREPETIRSE, 
PARAMETRO.BANCOMERHABPINPAD as BANCOMERHABPINPAD, 
PARAMETRO.HAB_PRECIOSCLIENTE as HAB_PRECIOSCLIENTE, 
PARAMETRO.CXCVALIDARTRASLADOS as CXCVALIDARTRASLADOS, 
PARAMETRO.PREGUNTARSIESACREDITO as PREGUNTARSIESACREDITO, 
PARAMETRO.HABMENSAJERIA as HABMENSAJERIA, 
PARAMETRO.HABDESCLINEAPERSONA as HABDESCLINEAPERSONA, 
PARAMETRO.MANEJARLOTEIMPORTACION as MANEJARLOTEIMPORTACION, 
PARAMETRO.MANEJAGASTOSADIC as MANEJAGASTOSADIC, 
PARAMETRO.HABBOTONPAGOVALE as HABBOTONPAGOVALE, 
PARAMETRO.UNICAVISITAPORDOCTO as UNICAVISITAPORDOCTO, 
PARAMETRO.PLAZOXPRODUCTO as PLAZOXPRODUCTO, 
PARAMETRO.AUTOCOMPLETECONEXISENVENTA as AUTOCOMPLETECONEXISENVENTA, 
PARAMETRO.APLICARCAMBIOSPRECAUTO as APLICARCAMBIOSPRECAUTO, 
PARAMETRO.MANEJACUPONES as MANEJACUPONES, 
PARAMETRO.HAB_DEVOLUCIONTRASLADO as HAB_DEVOLUCIONTRASLADO, 
PARAMETRO.HAB_DEVOLUCIONSURTIDOSUC as HAB_DEVOLUCIONSURTIDOSUC, 
PARAMETRO.MANEJAPRODUCTOSPROMOCION as MANEJAPRODUCTOSPROMOCION, 
PARAMETRO.PRECIONETOENGRIDS as PRECIONETOENGRIDS, 
PARAMETRO.PAGOSERVCONSOLIDADO as PAGOSERVCONSOLIDADO, 
PARAMETRO.MOSTRARINVINFOADICPROD as MOSTRARINVINFOADICPROD, 
PARAMETRO.HAB_CONSOLIDADOAUTOMATICO as HAB_CONSOLIDADOAUTOMATICO, 
PARAMETRO.PIEZACAJAENTICKET as PIEZACAJAENTICKET, 
PARAMETRO.GENERARFE as GENERARFE, 
PARAMETRO.MOVIL_TIENEVENDEDORES as MOVIL_TIENEVENDEDORES, 
PARAMETRO.IMPRIMIRCOPIAALMACEN as IMPRIMIRCOPIAALMACEN, 
PARAMETRO.MOVIL3_PREIMPORTAR as MOVIL3_PREIMPORTAR, 
PARAMETRO.BUSQUEDATIPO2 as BUSQUEDATIPO2, 
PARAMETRO.CONSFACTOMITIRVALES as CONSFACTOMITIRVALES, 
PARAMETRO.DESGLOSEIEPSFACTURA as DESGLOSEIEPSFACTURA, 
PARAMETRO.IMPRIMIRBANCOSCORTE as IMPRIMIRBANCOSCORTE, 
PARAMETRO.IMPR_CANC_VENTA as IMPR_CANC_VENTA, 
PARAMETRO.RETIROCAJAALCERRARCORTE as RETIROCAJAALCERRARCORTE, 
PARAMETRO.PAGOTARJMENORPRECIOLISTAALL as PAGOTARJMENORPRECIOLISTAALL, 
PARAMETRO.PREGUNTARSERVDOM as PREGUNTARSERVDOM, 
PARAMETRO.HABPPC as HABPPC, 
PARAMETRO.SOLOABONOAPLICADO as SOLOABONOAPLICADO, 
PARAMETRO.IMPRFORMAVENTATRASL as IMPRFORMAVENTATRASL, 
PARAMETRO.HABREVISIONFINAL as HABREVISIONFINAL, 
PARAMETRO.HABFONDODINAMICO as HABFONDODINAMICO, 
PARAMETRO.HABVENTACLISUC as HABVENTACLISUC, 
PARAMETRO.HABWSDBF as HABWSDBF, 
PARAMETRO.MANEJAUTILIDADPRECIOS as MANEJAUTILIDADPRECIOS, 
PARAMETRO.HABMULTPLAZOCOMPRA as HABMULTPLAZOCOMPRA, 
PARAMETRO.COSTOREPOIGUALCOSTOULT as COSTOREPOIGUALCOSTOULT, 
PARAMETRO.TICKET_DESC_VALE_AL_FINAL as TICKET_DESC_VALE_AL_FINAL, 
PARAMETRO.HABSURTIDOPREVIO as HABSURTIDOPREVIO, 
PARAMETRO.RECIBOPREVIEWCOMANDA as RECIBOPREVIEWCOMANDA, 
PARAMETRO.TICKET_IMPR_DESC2 as TICKET_IMPR_DESC2, 
PARAMETRO.HABSURTIDOPOSTMOVIL as HABSURTIDOPOSTMOVIL, 
PARAMETRO.AUTPRECIOLISTABAJO as AUTPRECIOLISTABAJO,
PARAMETRO.IMP_PROD_DEF as IMP_PROD_DEF, 
PARAMETRO.CANTIDAD as CANTIDAD, 
PARAMETRO.UTILIDAD as UTILIDAD, 
PARAMETRO.FECHAANTERIOR as FECHAANTERIOR, 
PARAMETRO.FECHAACTUAL as FECHAACTUAL, 
PARAMETRO.FECHAULTIMA as FECHAULTIMA, 
PARAMETRO.MAX_INV_FIS_CANT as MAX_INV_FIS_CANT, 
PARAMETRO.COMISIONMEDICO as COMISIONMEDICO, 
PARAMETRO.COMISIONDEPENDIENTE as COMISIONDEPENDIENTE, 
PARAMETRO.DESCUENTOVALE as DESCUENTOVALE, 
PARAMETRO.ULT_FECHA_IMP_PROD as ULT_FECHA_IMP_PROD, 
PARAMETRO.PORC_COMISIONENCARGADO as PORC_COMISIONENCARGADO, 
PARAMETRO.PORC_COMISIONVENDEDOR as PORC_COMISIONVENDEDOR, 
PARAMETRO.MONEDEROMONTOMINIMO as MONEDEROMONTOMINIMO, 
PARAMETRO.RETENCIONIVA as RETENCIONIVA, 
PARAMETRO.RETENCIONISR as RETENCIONISR, 
PARAMETRO.FECHAINICIOPEDIDO as FECHAINICIOPEDIDO, 
PARAMETRO.MINUTILIDAD as MINUTILIDAD, 
PARAMETRO.LASTCHANGEPRODDESC as LASTCHANGEPRODDESC, 
PARAMETRO.LASTCHANGECLIENTENOMBRE as LASTCHANGECLIENTENOMBRE, 
PARAMETRO.MOVILLASTPRECIODATE as MOVILLASTPRECIODATE, 
PARAMETRO.LASTCHANGEPRECIOPROD as LASTCHANGEPRECIOPROD, 
PARAMETRO.PRODCAMBIOPARAMOVIL as PRODCAMBIOPARAMOVIL, 
PARAMETRO.DESCUENTOTIPO1PORC as DESCUENTOTIPO1PORC, 
PARAMETRO.DESCUENTOTIPO2PORC as DESCUENTOTIPO2PORC, 
PARAMETRO.DESCUENTOTIPO3PORC as DESCUENTOTIPO3PORC, 
PARAMETRO.DESCUENTOTIPO4PORC as DESCUENTOTIPO4PORC, 
PARAMETRO.FECHARESPALDO as FECHARESPALDO, 
PARAMETRO.MONTORETIROCAJA as MONTORETIROCAJA, 
PARAMETRO.COMISIONPORTARJETA as COMISIONPORTARJETA, 
PARAMETRO.PIEZASIGUALESMEDIOMAYOREO as PIEZASIGUALESMEDIOMAYOREO, 
PARAMETRO.PIEZASDIFMEDIOMAYOREO as PIEZASDIFMEDIOMAYOREO, 
PARAMETRO.PIEZASIGUALESMAYOREO as PIEZASIGUALESMAYOREO, 
PARAMETRO.PIEZASDIFMAYOREO as PIEZASDIFMAYOREO, 
PARAMETRO.COMISIONTARJETAEMPRESA as COMISIONTARJETAEMPRESA, 
PARAMETRO.IVACOMISIONTARJETAEMPRESA as IVACOMISIONTARJETAEMPRESA, 
PARAMETRO.FECHAACTUALIZACIONEMIDA as FECHAACTUALIZACIONEMIDA, 
PARAMETRO.FECHAACTUALIZACIONEMIDASERV as FECHAACTUALIZACIONEMIDASERV, 
PARAMETRO.MONTOMAXSALDOMENOR as MONTOMAXSALDOMENOR, 
PARAMETRO.EMIDAPORCUTILIDADRECARGAS as EMIDAPORCUTILIDADRECARGAS, 
PARAMETRO.EMIDAUTILIDADPAGOSERVICIOS as EMIDAUTILIDADPAGOSERVICIOS, 
PARAMETRO.ULT_CONSOLIDADOAUTOMATICO as ULT_CONSOLIDADOAUTOMATICO, 
PARAMETRO.MOVIL_ULTCAM_SESION as MOVIL_ULTCAM_SESION, 
PARAMETRO.KITSDEF_ULTACT as KITSDEF_ULTACT, 
PARAMETRO.KITSDEF_UNNIV_ULTACT as KITSDEF_UNNIV_ULTACT, 
PARAMETRO.MAXCOMISIONXCLIENTE as MAXCOMISIONXCLIENTE, 
PARAMETRO.COMISIONDEBTARJETAEMPRESA as COMISIONDEBTARJETAEMPRESA, 
PARAMETRO.COMISIONDEBPORTARJETA as COMISIONDEBPORTARJETA, 
PARAMETRO.FACTCONSMAXPOR as FACTCONSMAXPOR, 
PARAMETRO.FISCALFECHACANCELACION2 as FISCALFECHACANCELACION2, 
PARAMETRO.PORCUTILIDADLISTADO as PORCUTILIDADLISTADO, 
PARAMETRO.SMTPPORT as SMTPPORT, 
PARAMETRO.LONGPRODBASCULA as LONGPRODBASCULA, 
PARAMETRO.LONGPESOBASCULA as LONGPESOBASCULA, 
PARAMETRO.MONEDEROCADUCIDAD as MONEDEROCADUCIDAD, 
PARAMETRO.DOBLECOPIACREDITO as DOBLECOPIACREDITO, 
PARAMETRO.DOBLECOPIATRASLADO as DOBLECOPIATRASLADO, 
PARAMETRO.CORTACADUCIDAD as CORTACADUCIDAD, 
PARAMETRO.MOVILCIERRECOBRANZA as MOVILCIERRECOBRANZA, 
PARAMETRO.MOVILCIERREVENTA as MOVILCIERREVENTA,
PARAMETRO.PENDMAXDIAS as PENDMAXDIAS, 
PARAMETRO.CLIENTECONSOLIDADOID as CLIENTECONSOLIDADOID, 
PARAMETRO.TIMEOUTPINDISTSALE as TIMEOUTPINDISTSALE, 
PARAMETRO.TIMEOUTLOOKUP as TIMEOUTLOOKUP, 
PARAMETRO.TIMEOUTPINDISTSALESERV as TIMEOUTPINDISTSALESERV, 
PARAMETRO.EMIDASERVICIOPROVEEDORID as EMIDASERVICIOPROVEEDORID, 
PARAMETRO.DECIMALESENCANTIDAD as DECIMALESENCANTIDAD, 
PARAMETRO.CADUCIDADMINIMA as CADUCIDADMINIMA, 
PARAMETRO.NUMCANCELACTAUTO as NUMCANCELACTAUTO, 
PARAMETRO.NUMCANCELACTAUTOUSUARIO as NUMCANCELACTAUTOUSUARIO, 
PARAMETRO.VERSIONWSEXISTENCIAS as VERSIONWSEXISTENCIAS, 
PARAMETRO.NUMTICKETSABONO as NUMTICKETSABONO, 
PARAMETRO.INTENTOSRETIROCAJA as INTENTOSRETIROCAJA, 
PARAMETRO.DOBLECOPIACONTADO as DOBLECOPIACONTADO, 
PARAMETRO.VERSIONTOPEID as VERSIONTOPEID, 
PARAMETRO.VERSIONCOMISIONID as VERSIONCOMISIONID, 
PARAMETRO.SEGUNDOSCICLOFTP as SEGUNDOSCICLOFTP, 
PARAMETRO.DIASMAXEXPFTP as DIASMAXEXPFTP, 
PARAMETRO.DIASMAXIMPFTP as DIASMAXIMPFTP, 
PARAMETRO.DOBLECOPIATARJETA as DOBLECOPIATARJETA, 
PARAMETRO.CANTTICKETRETIRO as CANTTICKETRETIRO, 
PARAMETRO.CANTTICKETABRIRCORTE as CANTTICKETABRIRCORTE, 
PARAMETRO.CANTTICKETCOMPRAS as CANTTICKETCOMPRAS, 
PARAMETRO.CANTTICKETFONDOCAJA as CANTTICKETFONDOCAJA, 
PARAMETRO.CANTTICKETGASTOS as CANTTICKETGASTOS, 
PARAMETRO.CANTTICKETDEPOSITOS as CANTTICKETDEPOSITOS, 
PARAMETRO.CANTTICKETCIERRECORTE as CANTTICKETCIERRECORTE, 
PARAMETRO.CANTTICKETCIERREBILLETES as CANTTICKETCIERREBILLETES, 
PARAMETRO.NUMTICKETSCOMANDA as NUMTICKETSCOMANDA,
   PARAMETRO.lista_precio_def LISTA_PRECIO_DEFCLAVE,
   'PRECIO ' || CAST(PARAMETRO.LISTAPRECIOMINIMO AS VARCHAR(10)) LISTAPRECIOMINIMO_CLAVE,
   ENCARGADO.CLAVE ENCARGADOCLAVE,
   'PRECIO ' || CAST(PARAMETRO.LISTAPRECIOXUEMPAQUE AS VARCHAR(10)) LISTAPRECIOXUEMPAQUE_CLAVE,
   'PRECIO ' || CAST(PARAMETRO.LISTAPRECIOXPZACAJA AS VARCHAR(10)) LISTAPRECIOXPZACAJA_CLAVE ,
   'PRECIO ' || CAST(PARAMETRO.LISTAPRECIOINIMAYO AS VARCHAR(10)) LISTAPRECIOINIMAYO_CLAVE,
   TIPODESCUENTOPROD.CLAVE TIPODESCUENTOPRODCLAVE  ,
   TIPOUTILIDAD.CLAVE TIPOUTILIDADCLAVE ,
   CASE WHEN PARAMETRO.CAMPOIMPOCOSTOREPO = 0 THEN 'COSTO REPOSICION' ELSE 'PRECIO ' ||  CAST(PARAMETRO.CAMPOIMPOCOSTOREPO  AS VARCHAR(10)) END CAMPOIMPOCOSTOREPOCLAVE ,
   PARAMETRO.vendedormovilclave VENDEDORMOVILCLAVE ,
   CLIENTECONSOLIDADO.CLAVE CLIENTECONSOLIDADOCLAVE,
   EMIDARECARGALINEA.CLAVE EMIDARECARGALINEACLAVE ,
   EMIDARECARGAMARCA.CLAVE EMIDARECARGAMARCACLAVE ,
   EMIDARECARGAPROVEEDOR.CLAVE EMIDARECARGAPROVEEDORCLAVE,
   EMIDASERVICIOLINEA.CLAVE EMIDASERVICIOLINEACLAVE,
   EMIDASERVICIOMARCA.CLAVE EMIDASERVICIOMARCACLAVE ,
   EMIDASERVICIOPROVEEDOR.CLAVE EMIDASERVICIOPROVEEDORCLAVE ,
   PARAMETRO.precioajustedifinv PRECIOAJUSTEDIFINVCLAVE,
   ALMACENRECEPCION.CLAVE ALMACENRECEPCIONCLAVE,
   SAT_METODOPAGO.sat_clave SAT_METODOPAGOCLAVE ,
   SAT_REGIMENFISCAL.sat_clave SAT_REGIMENFISCALCLAVE ,
   agrupacionventa.clave AGRUPACIONVENTACLAVE ,
   'PRECIO ' || CAST(PARAMETRO.MONEDEROLISTAPRECIOID AS VARCHAR(10)) MONEDEROLISTAPRECIOCLAVE ,
   'PRECIO ' || CAST(PARAMETRO.LISTAPRECIOMAYLINEA AS VARCHAR(10)) LISTAPRECIOMAYLINEA_CLAVE ,
   'PRECIO ' || CAST(PARAMETRO.LISTAPRECMEDMAYLINEA AS VARCHAR(10)) LISTAPREMEDMAYLINEA_CLAVE
   FROM parametro
   LEFT JOIN PERSONA ENCARGADO ON ENCARGADO.ID = PARAMETRO.encargadoid
   LEFT JOIN TIPODESCUENTOPROD ON TIPODESCUENTOPROD.ID = PARAMETRO.tipodescuentoprodid
   LEFT JOIN TIPOUTILIDAD ON TIPOUTILIDAD.ID = PARAMETRO.TIPOUTILIDADID
   LEFT JOIN PERSONA CLIENTECONSOLIDADO ON CLIENTECONSOLIDADO.ID = PARAMETRO.clienteconsolidadoid
   LEFT JOIN LINEA EMIDARECARGALINEA ON EMIDARECARGALINEA.ID = PARAMETRO.emidarecargalineaid
   LEFT JOIN MARCA EMIDARECARGAMARCA ON EMIDARECARGAMARCA.ID = PARAMETRO.emidarecargamarcaid
   LEFT JOIN PERSONA EMIDARECARGAPROVEEDOR ON EMIDARECARGAPROVEEDOR.ID = PARAMETRO.emidarecargaproveedorid
   LEFT JOIN LINEA EMIDASERVICIOLINEA ON EMIDASERVICIOLINEA.ID = PARAMETRO.EMIDASERVICIOlineaid
   LEFT JOIN MARCA EMIDASERVICIOMARCA ON EMIDASERVICIOMARCA.ID = PARAMETRO.EMIDASERVICIOmarcaid
   LEFT JOIN PERSONA EMIDASERVICIOPROVEEDOR ON EMIDASERVICIOPROVEEDOR.ID = PARAMETRO.EMIDASERVICIOPROVEEDORID
   LEFT JOIN ALMACEN ALMACENRECEPCION ON ALMACENRECEPCION.ID = PARAMETRO.almacenrecepcionid
   LEFT JOIN SAT_METODOPAGO ON SAT_METODOPAGO.ID = PARAMETRO.SAT_METODOPAGOID
   LEFT JOIN SAT_REGIMENFISCAL ON SAT_REGIMENFISCAL.ID = PARAMETRO.SAT_REGIMENFISCALID
   LEFT JOIN AGRUPACIONVENTA  ON AGRUPACIONVENTA.ID = PARAMETRO.agrupacionventaid";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                //PARAMETRO.PAGO_TARJMENORPRECIOLISTA as PAGO_TARJMENORPRECIOLISTA, 
                dr = FbSqlHelper.ExecuteReader(fbCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);


                while (dr.Read())
                {

                    ImportFromFirebirdReader(empresaId, sucursalId, usuarioId, ref doctoId, tipoDoctoId,
                                             dr, localContext, parametroController);
                }
                localContext.SaveChanges();
                FbSqlHelper.CloseReader(dr, pcn!);


            }
            catch (Exception e)
            {
                if (dr != null && pcn != null)
                    FbSqlHelper.CloseReader(dr, pcn);

                Console.WriteLine(e.Message);
            }

        }

        public bool ImportFromFirebirdReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               FbDataReader dataReader, ApplicationDbContext localContext, ParametroController controller)
        {

            //var clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : "";


            var Lista_precio_defClave = dataReader["LISTA_PRECIO_DEFCLAVE"] != System.DBNull.Value ? ((string)dataReader["LISTA_PRECIO_DEFCLAVE"]).Trim() : "";

            var Listapreciominimo_Clave = dataReader["LISTAPRECIOMINIMO_CLAVE"] != System.DBNull.Value ? ((string)dataReader["LISTAPRECIOMINIMO_CLAVE"]).Trim() : "";

            var EncargadoClave = dataReader["ENCARGADOCLAVE"] != System.DBNull.Value ? ((string)dataReader["ENCARGADOCLAVE"]).Trim() : "";

            var Listaprecioxuempaque_Clave = dataReader["LISTAPRECIOXUEMPAQUE_CLAVE"] != System.DBNull.Value ? ((string)dataReader["LISTAPRECIOXUEMPAQUE_CLAVE"]).Trim() : "";

            var Listaprecioxpzacaja_Clave = dataReader["LISTAPRECIOXPZACAJA_CLAVE"] != System.DBNull.Value ? ((string)dataReader["LISTAPRECIOXPZACAJA_CLAVE"]).Trim() : "";

            var Listaprecioinimayo_Clave = dataReader["LISTAPRECIOINIMAYO_CLAVE"] != System.DBNull.Value ? ((string)dataReader["LISTAPRECIOINIMAYO_CLAVE"]).Trim() : "";

            var TipodescuentoprodClave = dataReader["TIPODESCUENTOPRODCLAVE"] != System.DBNull.Value ? ((string)dataReader["TIPODESCUENTOPRODCLAVE"]).Trim() : "";

            var TipoutilidadClave = dataReader["TIPOUTILIDADCLAVE"] != System.DBNull.Value ? ((string)dataReader["TIPOUTILIDADCLAVE"]).Trim() : "";

            var CampoimpocostorepoClave = dataReader["CAMPOIMPOCOSTOREPOCLAVE"] != System.DBNull.Value ? ((string)dataReader["CAMPOIMPOCOSTOREPOCLAVE"]).Trim() : "";

            var VendedormovilClave = dataReader["VENDEDORMOVILCLAVE"] != System.DBNull.Value ? ((string)dataReader["VENDEDORMOVILCLAVE"]).Trim() : "";

            var ClienteconsolidadoClave = dataReader["CLIENTECONSOLIDADOCLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTECONSOLIDADOCLAVE"]).Trim() : "";

            var EmidarecargalineaClave = dataReader["EMIDARECARGALINEACLAVE"] != System.DBNull.Value ? ((string)dataReader["EMIDARECARGALINEACLAVE"]).Trim() : "";

            var EmidarecargamarcaClave = dataReader["EMIDARECARGAMARCACLAVE"] != System.DBNull.Value ? ((string)dataReader["EMIDARECARGAMARCACLAVE"]).Trim() : "";

            var EmidarecargaproveedorClave = dataReader["EMIDARECARGAPROVEEDORCLAVE"] != System.DBNull.Value ? ((string)dataReader["EMIDARECARGAPROVEEDORCLAVE"]).Trim() : "";

            var EmidaserviciolineaClave = dataReader["EMIDASERVICIOLINEACLAVE"] != System.DBNull.Value ? ((string)dataReader["EMIDASERVICIOLINEACLAVE"]).Trim() : "";

            var EmidaserviciomarcaClave = dataReader["EMIDASERVICIOMARCACLAVE"] != System.DBNull.Value ? ((string)dataReader["EMIDASERVICIOMARCACLAVE"]).Trim() : "";

            var EmidaservicioproveedorClave = dataReader["EMIDASERVICIOPROVEEDORCLAVE"] != System.DBNull.Value ? ((string)dataReader["EMIDASERVICIOPROVEEDORCLAVE"]).Trim() : "";

            var PrecioajustedifinvClave = dataReader["PRECIOAJUSTEDIFINVCLAVE"] != System.DBNull.Value ? ((string)dataReader["PRECIOAJUSTEDIFINVCLAVE"]).Trim() : "";

            var AlmacenrecepcionClave = dataReader["ALMACENRECEPCIONCLAVE"] != System.DBNull.Value ? ((string)dataReader["ALMACENRECEPCIONCLAVE"]).Trim() : "";

            var Sat_metodopagoClave = dataReader["SAT_METODOPAGOCLAVE"] != System.DBNull.Value ? ((string)dataReader["SAT_METODOPAGOCLAVE"]).Trim() : "";

            var Sat_regimenfiscalClave = dataReader["SAT_REGIMENFISCALCLAVE"] != System.DBNull.Value ? ((string)dataReader["SAT_REGIMENFISCALCLAVE"]).Trim() : "";

            var AgrupacionventaClave = dataReader["AGRUPACIONVENTACLAVE"] != System.DBNull.Value ? ((string)dataReader["AGRUPACIONVENTACLAVE"]).Trim() : "";

            var MonederolistaprecioClave = dataReader["MONEDEROLISTAPRECIOCLAVE"] != System.DBNull.Value ? ((string)dataReader["MONEDEROLISTAPRECIOCLAVE"]).Trim() : "";

            var Listapreciomaylinea_Clave = dataReader["LISTAPRECIOMAYLINEA_CLAVE"] != System.DBNull.Value ? ((string)dataReader["LISTAPRECIOMAYLINEA_CLAVE"]).Trim() : "";

            var Listapremedmaylinea_Clave = dataReader["LISTAPREMEDMAYLINEA_CLAVE"] != System.DBNull.Value ? ((string)dataReader["LISTAPREMEDMAYLINEA_CLAVE"]).Trim() : "";


            var itemSaved = localContext.Parametro.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId );


            var Lista_precio_defClave_obj = localContext.Tipoprecio.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == Lista_precio_defClave);

            var Listapreciominimo_Clave_obj = localContext.Tipoprecio.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == Listapreciominimo_Clave);

            var EncargadoClave_obj = localContext.Usuario.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.UsuarioNombre == EncargadoClave);

            var Listaprecioxuempaque_Clave_obj = localContext.Tipoprecio.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == Listaprecioxuempaque_Clave);

            var Listaprecioxpzacaja_Clave_obj = localContext.Tipoprecio.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == Listaprecioxpzacaja_Clave);

            var Listaprecioinimayo_Clave_obj = localContext.Tipoprecio.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == Listaprecioinimayo_Clave);

            var TipodescuentoprodClave_obj = localContext.Tipodescuentoprod.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == TipodescuentoprodClave);

            var TipoutilidadClave_obj = localContext.Tipoutilidad.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == TipoutilidadClave);

            var CampoimpocostorepoClave_obj = localContext.Tipoprecio.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == CampoimpocostorepoClave);

            var VendedormovilClave_obj = localContext.Usuario.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.UsuarioNombre == VendedormovilClave);

            var ClienteconsolidadoClave_obj = localContext.Cliente.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == ClienteconsolidadoClave);

            var EmidarecargalineaClave_obj = localContext.Linea.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == EmidarecargalineaClave);

            var EmidarecargamarcaClave_obj = localContext.Marca.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == EmidarecargamarcaClave);

            var EmidarecargaproveedorClave_obj = localContext.Proveedor.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == EmidarecargaproveedorClave);

            var EmidaserviciolineaClave_obj = localContext.Linea.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == EmidaserviciolineaClave);

            var EmidaserviciomarcaClave_obj = localContext.Marca.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == EmidaserviciomarcaClave);

            var EmidaservicioproveedorClave_obj = localContext.Proveedor.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == EmidaservicioproveedorClave);


            var PrecioajustedifinvClave_obj = localContext.Tipoprecio.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == PrecioajustedifinvClave);

            var AlmacenrecepcionClave_obj = localContext.Almacen.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == AlmacenrecepcionClave);

            var Sat_metodopagoClave_obj = localContext.Sat_metodopago.AsNoTracking()
                                            .FirstOrDefault(i => i.Sat_clave == Sat_metodopagoClave);

            var Sat_regimenfiscalClave_obj = localContext.Sat_regimenfiscal.AsNoTracking()
                                            .FirstOrDefault(i => i.Sat_clave == Sat_regimenfiscalClave);

            var AgrupacionventaClave_obj = localContext.Agrupacionventa.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == AgrupacionventaClave);

            var MonederolistaprecioClave_obj = localContext.Tipoprecio.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == MonederolistaprecioClave);

            var Listapreciomaylinea_Clave_obj = localContext.Tipoprecio.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == Listapreciomaylinea_Clave);

            var Listapremedmaylinea_Clave_obj = localContext.Tipoprecio.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == Listapremedmaylinea_Clave);


            var item = itemSaved != null ? new ParametroBindingModel(itemSaved) : new ParametroBindingModel();
            var existItem = itemSaved != null;


            //item.Nombre = dataReader["NOMBRE"] != System.DBNull.Value ? ((string)dataReader["NOMBRE"]).Trim() : "";
            //item.Calle = dataReader["CALLE"] != System.DBNull.Value ? ((string)dataReader["CALLE"]).Trim() : "";
            //item.Colonia = dataReader["COLONIA"] != System.DBNull.Value ? ((string)dataReader["COLONIA"]).Trim() : "";
            //item.Municipio = dataReader["MUNICIPIO"] != System.DBNull.Value ? ((string)dataReader["MUNICIPIO"]).Trim() : "";
            //item.Estado = dataReader["ESTADO"] != System.DBNull.Value ? ((string)dataReader["ESTADO"]).Trim() : "";
            //item.Codigopostal = dataReader["CODIGOPOSTAL"] != System.DBNull.Value ? ((string)dataReader["CODIGOPOSTAL"]).Trim() : "";


            item.Estado_def = dataReader["ESTADO_DEF"] != System.DBNull.Value ? ((string)dataReader["ESTADO_DEF"]).Trim() : "";
            item.Lista_precio_traspaso = dataReader["LISTA_PRECIO_TRASPASO"] != System.DBNull.Value ? ((string)dataReader["LISTA_PRECIO_TRASPASO"]).Trim() : "";
            item.Inventory_email = dataReader["INVENTORY_EMAIL"] != System.DBNull.Value ? ((string)dataReader["INVENTORY_EMAIL"]).Trim() : "";
            item.Id_dosletras = dataReader["ID_DOSLETRAS"] != System.DBNull.Value ? ((string)dataReader["ID_DOSLETRAS"]).Trim() : "";
            item.Ftphost = dataReader["FTPHOST"] != System.DBNull.Value ? ((string)dataReader["FTPHOST"]).Trim() : "";
            item.Ftpusuario = dataReader["FTPUSUARIO"] != System.DBNull.Value ? ((string)dataReader["FTPUSUARIO"]).Trim() : "";
            item.Ftppassword = dataReader["FTPPASSWORD"] != System.DBNull.Value ? ((string)dataReader["FTPPASSWORD"]).Trim() : "";
            item.Smtphost = dataReader["SMTPHOST"] != System.DBNull.Value ? ((string)dataReader["SMTPHOST"]).Trim() : "";
            item.Smtpusuario = dataReader["SMTPUSUARIO"] != System.DBNull.Value ? ((string)dataReader["SMTPUSUARIO"]).Trim() : "";
            item.Smtppassword = dataReader["SMTPPASSWORD"] != System.DBNull.Value ? ((string)dataReader["SMTPPASSWORD"]).Trim() : "";
            item.Smtpmailfrom = dataReader["SMTPMAILFROM"] != System.DBNull.Value ? ((string)dataReader["SMTPMAILFROM"]).Trim() : "";
            item.Smtpmailto = dataReader["SMTPMAILTO"] != System.DBNull.Value ? ((string)dataReader["SMTPMAILTO"]).Trim() : "";
            item.Header = dataReader["HEADER"] != System.DBNull.Value ? ((string)dataReader["HEADER"]).Trim() : "";
            item.Footer = dataReader["FOOTER"] != System.DBNull.Value ? ((string)dataReader["FOOTER"]).Trim() : "";
            item.Numeroexterior = dataReader["NUMEROEXTERIOR"] != System.DBNull.Value ? ((string)dataReader["NUMEROEXTERIOR"]).Trim() : "";
            item.Numerointerior = dataReader["NUMEROINTERIOR"] != System.DBNull.Value ? ((string)dataReader["NUMEROINTERIOR"]).Trim() : "";
            item.Fiscalcalle = dataReader["FISCALCALLE"] != System.DBNull.Value ? ((string)dataReader["FISCALCALLE"]).Trim() : "";
            item.Fiscalnumerointerior = dataReader["FISCALNUMEROINTERIOR"] != System.DBNull.Value ? ((string)dataReader["FISCALNUMEROINTERIOR"]).Trim() : "";
            item.Fiscalnumeroexterior = dataReader["FISCALNUMEROEXTERIOR"] != System.DBNull.Value ? ((string)dataReader["FISCALNUMEROEXTERIOR"]).Trim() : "";
            item.Fiscalcolonia = dataReader["FISCALCOLONIA"] != System.DBNull.Value ? ((string)dataReader["FISCALCOLONIA"]).Trim() : "";
            item.Fiscalmunicipio = dataReader["FISCALMUNICIPIO"] != System.DBNull.Value ? ((string)dataReader["FISCALMUNICIPIO"]).Trim() : "";
            item.Fiscalestado = dataReader["FISCALESTADO"] != System.DBNull.Value ? ((string)dataReader["FISCALESTADO"]).Trim() : "";
            item.Fiscalcodigopostal = dataReader["FISCALCODIGOPOSTAL"] != System.DBNull.Value ? ((string)dataReader["FISCALCODIGOPOSTAL"]).Trim() : "";
            item.Certificadocsd = dataReader["CERTIFICADOCSD"] != System.DBNull.Value ? ((string)dataReader["CERTIFICADOCSD"]).Trim() : "";
            item.Timbradouser = dataReader["TIMBRADOUSER"] != System.DBNull.Value ? ((string)dataReader["TIMBRADOUSER"]).Trim() : "";
            item.Timbradopassword = dataReader["TIMBRADOPASSWORD"] != System.DBNull.Value ? ((string)dataReader["TIMBRADOPASSWORD"]).Trim() : "";
            item.Timbradoarchivocertificado = dataReader["TIMBRADOARCHIVOCERTIFICADO"] != System.DBNull.Value ? ((string)dataReader["TIMBRADOARCHIVOCERTIFICADO"]).Trim() : "";
            item.Timbradoarchivokey = dataReader["TIMBRADOARCHIVOKEY"] != System.DBNull.Value ? ((string)dataReader["TIMBRADOARCHIVOKEY"]).Trim() : "";
            item.Timbradokey = dataReader["TIMBRADOKEY"] != System.DBNull.Value ? ((string)dataReader["TIMBRADOKEY"]).Trim() : "";
            item.Fiscalnombre = dataReader["FISCALNOMBRE"] != System.DBNull.Value ? ((string)dataReader["FISCALNOMBRE"]).Trim() : "";
            item.Seriesat = dataReader["SERIESAT"] != System.DBNull.Value ? ((string)dataReader["SERIESAT"]).Trim() : "";
            item.Footerventaapartado = dataReader["FOOTERVENTAAPARTADO"] != System.DBNull.Value ? ((string)dataReader["FOOTERVENTAAPARTADO"]).Trim() : "";
            item.Ftpfolder = dataReader["FTPFOLDER"] != System.DBNull.Value ? ((string)dataReader["FTPFOLDER"]).Trim() : "";
            item.Ftpfolderpass = dataReader["FTPFOLDERPASS"] != System.DBNull.Value ? ((string)dataReader["FTPFOLDERPASS"]).Trim() : "";
            item.Seriesatdevolucion = dataReader["SERIESATDEVOLUCION"] != System.DBNull.Value ? ((string)dataReader["SERIESATDEVOLUCION"]).Trim() : "";
            item.Prefijobascula = dataReader["PREFIJOBASCULA"] != System.DBNull.Value ? ((string)dataReader["PREFIJOBASCULA"]).Trim() : "";
            item.Pacnombre = dataReader["PACNOMBRE"] != System.DBNull.Value ? ((string)dataReader["PACNOMBRE"]).Trim() : "";
            item.Pacusuario = dataReader["PACUSUARIO"] != System.DBNull.Value ? ((string)dataReader["PACUSUARIO"]).Trim() : "";

            item.Rutareportes = dataReader["RUTAREPORTES"] != System.DBNull.Value ? ((string)dataReader["RUTAREPORTES"]).Trim() : "";
            item.Recibolargoprinter = dataReader["RECIBOLARGOPRINTER"] != System.DBNull.Value ? ((string)dataReader["RECIBOLARGOPRINTER"]).Trim() : "";
            item.Fiscalregimen = dataReader["FISCALREGIMEN"] != System.DBNull.Value ? ((string)dataReader["FISCALREGIMEN"]).Trim() : "";
            //item.Rutaimagenesproducto = dataReader["RUTAIMAGENESPRODUCTO"] != System.DBNull.Value ? ((string)dataReader["RUTAIMAGENESPRODUCTO"]).Trim() : "";
            item.Fact_elect_folder = dataReader["FACT_ELECT_FOLDER"] != System.DBNull.Value ? ((string)dataReader["FACT_ELECT_FOLDER"]).Trim() : "";
            item.Pedidos_folder = dataReader["PEDIDOS_FOLDER"] != System.DBNull.Value ? ((string)dataReader["PEDIDOS_FOLDER"]).Trim() : "";
            item.Prefijocliente = dataReader["PREFIJOCLIENTE"] != System.DBNull.Value ? ((string)dataReader["PREFIJOCLIENTE"]).Trim() : "";
            item.Cuentaieps = dataReader["CUENTAIEPS"] != System.DBNull.Value ? ((string)dataReader["CUENTAIEPS"]).Trim() : "";


            item.Webservice = dataReader["WEBSERVICE"] != System.DBNull.Value ? ((string)dataReader["WEBSERVICE"]).Trim() : "";
            item.Tiposyncmovil = dataReader["TIPOSYNCMOVIL"] != System.DBNull.Value ? (TipoSyncMovil)Enum.Parse(typeof(TipoSyncMovil), (string)dataReader["TIPOSYNCMOVIL"])   : TipoSyncMovil.WS;
            item.Ordenimpresion = dataReader["ORDENIMPRESION"] != System.DBNull.Value ? (OrdenImpresion)Enum.Parse(typeof(OrdenImpresion), (string)dataReader["ORDENIMPRESION"], true) : OrdenImpresion.Normal;
            item.Localftphost = dataReader["LOCALFTPHOST"] != System.DBNull.Value ? ((string)dataReader["LOCALFTPHOST"]).Trim() : "";
            item.Localwebservice = dataReader["LOCALWEBSERVICE"] != System.DBNull.Value ? ((string)dataReader["LOCALWEBSERVICE"]).Trim() : "";
            item.Mailtoinventario = dataReader["MAILTOINVENTARIO"] != System.DBNull.Value ? ((string)dataReader["MAILTOINVENTARIO"]).Trim() : "";
            item.Rutarespaldoszip = dataReader["RUTARESPALDOSZIP"] != System.DBNull.Value ? ((string)dataReader["RUTARESPALDOSZIP"]).Trim() : "";
            item.Screenconfig = dataReader["SCREENCONFIG"] != System.DBNull.Value ? (ConfigPantalla)((long)dataReader["SCREENCONFIG"]) : ConfigPantalla.Normal;
            item.Tamanoletraticket = dataReader["TAMANOLETRATICKET"] != System.DBNull.Value ? (LetraEnTicket)((short)dataReader["TAMANOLETRATICKET"]) : LetraEnTicket.Normal;


            item.Bdlocalrepl = dataReader["BDLOCALREPL"] != System.DBNull.Value ? ((string)dataReader["BDLOCALREPL"]).Trim() : "";
            item.Tipovendedormovil = dataReader["TIPOVENDEDORMOVIL"] != System.DBNull.Value ? (TipoConexionMovil)( (long)dataReader["TIPOVENDEDORMOVIL"]) : TipoConexionMovil.Ninguno;
            item.Bdserverws = dataReader["BDSERVERWS"] != System.DBNull.Value ? ((string)dataReader["BDSERVERWS"]).Trim() : "";
            item.Bdmatrizmovil = dataReader["BDMATRIZMOVIL"] != System.DBNull.Value ? ((string)dataReader["BDMATRIZMOVIL"]).Trim() : "";
            item.Rutareportessistema = dataReader["RUTAREPORTESSISTEMA"] != System.DBNull.Value ? ((string)dataReader["RUTAREPORTESSISTEMA"]).Trim() : "";
            item.Descuentotipo1texto = dataReader["DESCUENTOTIPO1TEXTO"] != System.DBNull.Value ? ((string)dataReader["DESCUENTOTIPO1TEXTO"]).Trim() : "";
            item.Descuentotipo2texto = dataReader["DESCUENTOTIPO2TEXTO"] != System.DBNull.Value ? ((string)dataReader["DESCUENTOTIPO2TEXTO"]).Trim() : "";
            item.Descuentotipo3texto = dataReader["DESCUENTOTIPO3TEXTO"] != System.DBNull.Value ? ((string)dataReader["DESCUENTOTIPO3TEXTO"]).Trim() : "";
            item.Descuentotipo4texto = dataReader["DESCUENTOTIPO4TEXTO"] != System.DBNull.Value ? ((string)dataReader["DESCUENTOTIPO4TEXTO"]).Trim() : "";
            item.Rutarespaldo = dataReader["RUTARESPALDO"] != System.DBNull.Value ? ((string)dataReader["RUTARESPALDO"]).Trim() : "";
            item.Mailejecutivo = dataReader["MAILEJECUTIVO"] != System.DBNull.Value ? ((string)dataReader["MAILEJECUTIVO"]).Trim() : "";
            item.Formatoticketcortoid = dataReader["FORMATOTICKETCORTOID"] != System.DBNull.Value ? (FormatTicketCorto)((long)dataReader["FORMATOTICKETCORTOID"] ) : FormatTicketCorto.Normal;
            item.Seriesatabono = dataReader["SERIESATABONO"] != System.DBNull.Value ? ((string)dataReader["SERIESATABONO"]).Trim() : "";
            item.Rutaarchivosadjuntos = dataReader["RUTAARCHIVOSADJUNTOS"] != System.DBNull.Value ? ((string)dataReader["RUTAARCHIVOSADJUNTOS"]).Trim() : "";
            item.Formatofactelect = dataReader["FORMATOFACTELECT"] != System.DBNull.Value ? (FormatoFactura)Enum.Parse(typeof(FormatoFactura), (string)dataReader["FORMATOFACTELECT"]) : FormatoFactura.Normal;
            item.Wsmensajeria = dataReader["WSMENSAJERIA"] != System.DBNull.Value ? ((string)dataReader["WSMENSAJERIA"]).Trim() : "";
            item.Ipwebserviceappinv = dataReader["IPWEBSERVICEAPPINV"] != System.DBNull.Value ? ((string)dataReader["IPWEBSERVICEAPPINV"]).Trim() : "";
            item.Rutabdappinventaro = dataReader["RUTABDAPPINVENTARO"] != System.DBNull.Value ? ((string)dataReader["RUTABDAPPINVENTARO"]).Trim() : "";
            item.Rutadbfexistenciasuc = dataReader["RUTADBFEXISTENCIASUC"] != System.DBNull.Value ? ((string)dataReader["RUTADBFEXISTENCIASUC"]).Trim() : "";
            item.Tiposeleccioncatalogosat = dataReader["TIPOSELECCIONCATALOGOSAT"] != System.DBNull.Value ? (FiltroProductoSat)Enum.Parse(typeof(FiltroProductoSat), (string)dataReader["TIPOSELECCIONCATALOGOSAT"]) : FiltroProductoSat.Todos;
            item.Versioncfdi = dataReader["VERSIONCFDI"] != System.DBNull.Value ? ((string)dataReader["VERSIONCFDI"]).Trim() : "";
            item.Wsespecialexistmatriz = dataReader["WSESPECIALEXISTMATRIZ"] != System.DBNull.Value ? ((string)dataReader["WSESPECIALEXISTMATRIZ"]).Trim() : "";
            item.Rutareplicadorexe = dataReader["RUTAREPLICADOREXE"] != System.DBNull.Value ? ((string)dataReader["RUTAREPLICADOREXE"]).Trim() : "";
            item.Ticketespecial = dataReader["TICKETESPECIAL"] != System.DBNull.Value ? ((string)dataReader["TICKETESPECIAL"]).Trim() : "";
            item.Ticketdefaultprinter = dataReader["TICKETDEFAULTPRINTER"] != System.DBNull.Value ? ((string)dataReader["TICKETDEFAULTPRINTER"]).Trim() : "";
            item.Recargasdefaultprinter = dataReader["RECARGASDEFAULTPRINTER"] != System.DBNull.Value ? ((string)dataReader["RECARGASDEFAULTPRINTER"]).Trim() : "";
            item.Pvcolorear = dataReader["PVCOLOREAR"] != System.DBNull.Value ? (ModoAlertaPV)((int)dataReader["PVCOLOREAR"]) : ModoAlertaPV.Ninguno_Especial;
            item.Rutacatalogosupd = dataReader["RUTACATALOGOSUPD"] != System.DBNull.Value ? ((string)dataReader["RUTACATALOGOSUPD"]).Trim() : "";
            item.Rutaimportadatos = dataReader["RUTAIMPORTADATOS"] != System.DBNull.Value ? ((string)dataReader["RUTAIMPORTADATOS"]).Trim() : "";
            item.Destinobdvenmov = dataReader["DESTINOBDVENMOV"] != System.DBNull.Value ? ((string)dataReader["DESTINOBDVENMOV"]).Trim() : "";
            item.Rutapolizapdf = dataReader["RUTAPOLIZAPDF"] != System.DBNull.Value ? ((string)dataReader["RUTAPOLIZAPDF"]).Trim() : "";
            item.Recibolargocotiprinter = dataReader["RECIBOLARGOCOTIPRINTER"] != System.DBNull.Value ? ((string)dataReader["RECIBOLARGOCOTIPRINTER"]).Trim() : "";
            item.Wsdbf = dataReader["WSDBF"] != System.DBNull.Value ? ((string)dataReader["WSDBF"]).Trim() : "";
            item.Monederocamporef = dataReader["MONEDEROCAMPOREF"] != System.DBNull.Value ? ((string)dataReader["MONEDEROCAMPOREF"]).Trim() : "";
            item.Impresoracomanda = dataReader["IMPRESORACOMANDA"] != System.DBNull.Value ? ((string)dataReader["IMPRESORACOMANDA"]).Trim() : "";
            item.Seriecomprtraslsat = dataReader["SERIECOMPRTRASLSAT"] != System.DBNull.Value ? ((string)dataReader["SERIECOMPRTRASLSAT"]).Trim() : "";
            item.Rutafirmaimagenes = dataReader["RUTAFIRMAIMAGENES"] != System.DBNull.Value ? ((string)dataReader["RUTAFIRMAIMAGENES"]).Trim() : "";
            item.Promocion = dataReader["PROMOCION"] != System.DBNull.Value && ((string)dataReader["PROMOCION"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Habilitar_impexp_aut = dataReader["HABILITAR_IMPEXP_AUT"] != System.DBNull.Value && ((string)dataReader["HABILITAR_IMPEXP_AUT"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Cambiarprecio = dataReader["CAMBIARPRECIO"] != System.DBNull.Value && ((string)dataReader["CAMBIARPRECIO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Compraentienda = dataReader["COMPRAENTIENDA"] != System.DBNull.Value && ((string)dataReader["COMPRAENTIENDA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Hab_sel_cliente = dataReader["HAB_SEL_CLIENTE"] != System.DBNull.Value && ((string)dataReader["HAB_SEL_CLIENTE"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Hab_impr_cotizacion = dataReader["HAB_IMPR_COTIZACION"] != System.DBNull.Value && ((string)dataReader["HAB_IMPR_COTIZACION"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Mostrar_exis_suc = dataReader["MOSTRAR_EXIS_SUC"] != System.DBNull.Value && ((string)dataReader["MOSTRAR_EXIS_SUC"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Req_aprobacion_inv = dataReader["REQ_APROBACION_INV"] != System.DBNull.Value && ((string)dataReader["REQ_APROBACION_INV"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Reabrircortes = dataReader["REABRIRCORTES"] != System.DBNull.Value && ((string)dataReader["REABRIRCORTES"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Imp_prod_total = dataReader["IMP_PROD_TOTAL"] != System.DBNull.Value && ((string)dataReader["IMP_PROD_TOTAL"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Usarfiscalesenexpedicion = dataReader["USARFISCALESENEXPEDICION"] != System.DBNull.Value && ((string)dataReader["USARFISCALESENEXPEDICION"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Hab_facturaelectronica = dataReader["HAB_FACTURAELECTRONICA"] != System.DBNull.Value && ((string)dataReader["HAB_FACTURAELECTRONICA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Cambiarprecioxuempaque = dataReader["CAMBIARPRECIOXUEMPAQUE"] != System.DBNull.Value && ((string)dataReader["CAMBIARPRECIOXUEMPAQUE"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Cambiarprecioxpzacaja = dataReader["CAMBIARPRECIOXPZACAJA"] != System.DBNull.Value && ((string)dataReader["CAMBIARPRECIOXPZACAJA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Hayvendedorpiso = dataReader["HAYVENDEDORPISO"] != System.DBNull.Value && ((string)dataReader["HAYVENDEDORPISO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Envioautomaticoexistencias = dataReader["ENVIOAUTOMATICOEXISTENCIAS"] != System.DBNull.Value && ((string)dataReader["ENVIOAUTOMATICOEXISTENCIAS"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Monederoaplicar = dataReader["MONEDEROAPLICAR"] != System.DBNull.Value && ((string)dataReader["MONEDEROAPLICAR"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Imprimirnumeropiezas = dataReader["IMPRIMIRNUMEROPIEZAS"] != System.DBNull.Value && ((string)dataReader["IMPRIMIRNUMEROPIEZAS"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Cortepormail = dataReader["CORTEPORMAIL"] != System.DBNull.Value && ((string)dataReader["CORTEPORMAIL"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Camposcustomalimportar = dataReader["CAMPOSCUSTOMALIMPORTAR"] != System.DBNull.Value && ((string)dataReader["CAMPOSCUSTOMALIMPORTAR"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Recibolargoconfactura = dataReader["RECIBOLARGOCONFACTURA"] != System.DBNull.Value && ((string)dataReader["RECIBOLARGOCONFACTURA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Recibolargopreview = dataReader["RECIBOLARGOPREVIEW"] != System.DBNull.Value && ((string)dataReader["RECIBOLARGOPREVIEW"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Preguntarrazonpreciomenor = dataReader["PREGUNTARRAZONPRECIOMENOR"] != System.DBNull.Value && ((string)dataReader["PREGUNTARRAZONPRECIOMENOR"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Preguntardatosentrega = dataReader["PREGUNTARDATOSENTREGA"] != System.DBNull.Value && ((string)dataReader["PREGUNTARDATOSENTREGA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Arrendatario = dataReader["ARRENDATARIO"] != System.DBNull.Value && ((string)dataReader["ARRENDATARIO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Mostrarimagenenventa = dataReader["MOSTRARIMAGENENVENTA"] != System.DBNull.Value && ((string)dataReader["MOSTRARIMAGENENVENTA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Mostrarmontoahorro = dataReader["MOSTRARMONTOAHORRO"] != System.DBNull.Value && ((string)dataReader["MOSTRARMONTOAHORRO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Smtpssl = dataReader["SMTPSSL"] != System.DBNull.Value && ((string)dataReader["SMTPSSL"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Mostrardescuentofactura = dataReader["MOSTRARDESCUENTOFACTURA"] != System.DBNull.Value && ((string)dataReader["MOSTRARDESCUENTOFACTURA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Exportcatalogoaux = dataReader["EXPORTCATALOGOAUX"] != System.DBNull.Value && ((string)dataReader["EXPORTCATALOGOAUX"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Uiventaconcantidad = dataReader["UIVENTACONCANTIDAD"] != System.DBNull.Value && ((string)dataReader["UIVENTACONCANTIDAD"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Mostrarpzacajaenfactura = dataReader["MOSTRARPZACAJAENFACTURA"] != System.DBNull.Value && ((string)dataReader["MOSTRARPZACAJAENFACTURA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Desgloseieps = dataReader["DESGLOSEIEPS"] != System.DBNull.Value && ((string)dataReader["DESGLOSEIEPS"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Dividir_rem_fact = dataReader["DIVIDIR_REM_FACT"] != System.DBNull.Value && ((string)dataReader["DIVIDIR_REM_FACT"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Manejasuperlistaprecio = dataReader["MANEJASUPERLISTAPRECIO"] != System.DBNull.Value && ((string)dataReader["MANEJASUPERLISTAPRECIO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Manejaalmacen = dataReader["MANEJAALMACEN"] != System.DBNull.Value && ((string)dataReader["MANEJAALMACEN"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Manejareceta = dataReader["MANEJARECETA"] != System.DBNull.Value && ((string)dataReader["MANEJARECETA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Autocompprod = dataReader["AUTOCOMPPROD"] != System.DBNull.Value && ((string)dataReader["AUTOCOMPPROD"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Manejaquota = dataReader["MANEJAQUOTA"] != System.DBNull.Value && ((string)dataReader["MANEJAQUOTA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Touch = dataReader["TOUCH"] != System.DBNull.Value && ((string)dataReader["TOUCH"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Esvendedormovil = dataReader["ESVENDEDORMOVIL"] != System.DBNull.Value && ((string)dataReader["ESVENDEDORMOVIL"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Cajasbotellas = dataReader["CAJASBOTELLAS"] != System.DBNull.Value && ((string)dataReader["CAJASBOTELLAS"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Precionetoenpv = dataReader["PRECIONETOENPV"] != System.DBNull.Value && ((string)dataReader["PRECIONETOENPV"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Mostrarflash = dataReader["MOSTRARFLASH"] != System.DBNull.Value && ((string)dataReader["MOSTRARFLASH"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Autocompcliente = dataReader["AUTOCOMPCLIENTE"] != System.DBNull.Value && ((string)dataReader["AUTOCOMPCLIENTE"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Precioxcajaenpv = dataReader["PRECIOXCAJAENPV"] != System.DBNull.Value && ((string)dataReader["PRECIOXCAJAENPV"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Usarconexionlocal = dataReader["USARCONEXIONLOCAL"] != System.DBNull.Value && ((string)dataReader["USARCONEXIONLOCAL"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Promoenticket = dataReader["PROMOENTICKET"] != System.DBNull.Value && ((string)dataReader["PROMOENTICKET"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Manejakits = dataReader["MANEJAKITS"] != System.DBNull.Value && ((string)dataReader["MANEJAKITS"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Rebajaespecial = dataReader["REBAJAESPECIAL"] != System.DBNull.Value && ((string)dataReader["REBAJAESPECIAL"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Habilitarrepl = dataReader["HABILITARREPL"] != System.DBNull.Value && ((string)dataReader["HABILITARREPL"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Pendmovilantesventa = dataReader["PENDMOVILANTESVENTA"] != System.DBNull.Value && ((string)dataReader["PENDMOVILANTESVENTA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Preciosmovilantesventa = dataReader["PRECIOSMOVILANTESVENTA"] != System.DBNull.Value && ((string)dataReader["PRECIOSMOVILANTESVENTA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Recalcularcambiocliente = dataReader["RECALCULARCAMBIOCLIENTE"] != System.DBNull.Value && ((string)dataReader["RECALCULARCAMBIOCLIENTE"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Movilprocesosurtido = dataReader["MOVILPROCESOSURTIDO"] != System.DBNull.Value && ((string)dataReader["MOVILPROCESOSURTIDO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Movilverificarventa = dataReader["MOVILVERIFICARVENTA"] != System.DBNull.Value && ((string)dataReader["MOVILVERIFICARVENTA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Reqautcancelarcoti = dataReader["REQAUTCANCELARCOTI"] != System.DBNull.Value && ((string)dataReader["REQAUTCANCELARCOTI"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Reqautelimdetallecoti = dataReader["REQAUTELIMDETALLECOTI"] != System.DBNull.Value && ((string)dataReader["REQAUTELIMDETALLECOTI"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Abrircajonalfincorte = dataReader["ABRIRCAJONALFINCORTE"] != System.DBNull.Value && ((string)dataReader["ABRIRCAJONALFINCORTE"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Habsurtidopostpuesto = dataReader["HABSURTIDOPOSTPUESTO"] != System.DBNull.Value && ((string)dataReader["HABSURTIDOPOSTPUESTO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Doblecopiaremision = dataReader["DOBLECOPIAREMISION"] != System.DBNull.Value && ((string)dataReader["DOBLECOPIAREMISION"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Reimpresionesconmarca = dataReader["REIMPRESIONESCONMARCA"] != System.DBNull.Value && ((string)dataReader["REIMPRESIONESCONMARCA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Habtotalizados = dataReader["HABTOTALIZADOS"] != System.DBNull.Value && ((string)dataReader["HABTOTALIZADOS"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Multipletipovale = dataReader["MULTIPLETIPOVALE"] != System.DBNull.Value && ((string)dataReader["MULTIPLETIPOVALE"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Habilitarlog = dataReader["HABILITARLOG"] != System.DBNull.Value && ((string)dataReader["HABILITARLOG"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Manejarretirodecaja = dataReader["MANEJARRETIRODECAJA"] != System.DBNull.Value && ((string)dataReader["MANEJARRETIRODECAJA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Aplicarmayoreoporlinea = dataReader["APLICARMAYOREOPORLINEA"] != System.DBNull.Value && ((string)dataReader["APLICARMAYOREOPORLINEA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Preguntacancelacotizacion = dataReader["PREGUNTACANCELACOTIZACION"] != System.DBNull.Value && ((string)dataReader["PREGUNTACANCELACOTIZACION"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Habverificacioncxc = dataReader["HABVERIFICACIONCXC"] != System.DBNull.Value && ((string)dataReader["HABVERIFICACIONCXC"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Ventasxcorteemail = dataReader["VENTASXCORTEEMAIL"] != System.DBNull.Value && ((string)dataReader["VENTASXCORTEEMAIL"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Habventasafuturo = dataReader["HABVENTASAFUTURO"] != System.DBNull.Value && ((string)dataReader["HABVENTASAFUTURO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Serviciosemida = dataReader["SERVICIOSEMIDA"] != System.DBNull.Value && ((string)dataReader["SERVICIOSEMIDA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Habimpresioncortecajero = dataReader["HABIMPRESIONCORTECAJERO"] != System.DBNull.Value && ((string)dataReader["HABIMPRESIONCORTECAJERO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Habtrasladoporautorizacion = dataReader["HABTRASLADOPORAUTORIZACION"] != System.DBNull.Value && ((string)dataReader["HABTRASLADOPORAUTORIZACION"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Habventasmostrador = dataReader["HABVENTASMOSTRADOR"] != System.DBNull.Value && ((string)dataReader["HABVENTASMOSTRADOR"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Habpagoservemida = dataReader["HABPAGOSERVEMIDA"] != System.DBNull.Value && ((string)dataReader["HABPAGOSERVEMIDA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Habpromoxmontomin = dataReader["HABPROMOXMONTOMIN"] != System.DBNull.Value && ((string)dataReader["HABPROMOXMONTOMIN"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Preciosordenados = dataReader["PRECIOSORDENADOS"] != System.DBNull.Value && ((string)dataReader["PRECIOSORDENADOS"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Eanpuederepetirse = dataReader["EANPUEDEREPETIRSE"] != System.DBNull.Value && ((string)dataReader["EANPUEDEREPETIRSE"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Bancomerhabpinpad = dataReader["BANCOMERHABPINPAD"] != System.DBNull.Value && ((string)dataReader["BANCOMERHABPINPAD"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Hab_precioscliente = dataReader["HAB_PRECIOSCLIENTE"] != System.DBNull.Value && ((string)dataReader["HAB_PRECIOSCLIENTE"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Cxcvalidartraslados = dataReader["CXCVALIDARTRASLADOS"] != System.DBNull.Value && ((string)dataReader["CXCVALIDARTRASLADOS"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Preguntarsiesacredito = dataReader["PREGUNTARSIESACREDITO"] != System.DBNull.Value && ((string)dataReader["PREGUNTARSIESACREDITO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Habmensajeria = dataReader["HABMENSAJERIA"] != System.DBNull.Value && ((string)dataReader["HABMENSAJERIA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Habdesclineapersona = dataReader["HABDESCLINEAPERSONA"] != System.DBNull.Value && ((string)dataReader["HABDESCLINEAPERSONA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Manejarloteimportacion = dataReader["MANEJARLOTEIMPORTACION"] != System.DBNull.Value && ((string)dataReader["MANEJARLOTEIMPORTACION"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Manejagastosadic = dataReader["MANEJAGASTOSADIC"] != System.DBNull.Value && ((string)dataReader["MANEJAGASTOSADIC"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Habbotonpagovale = dataReader["HABBOTONPAGOVALE"] != System.DBNull.Value && ((string)dataReader["HABBOTONPAGOVALE"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Unicavisitapordocto = dataReader["UNICAVISITAPORDOCTO"] != System.DBNull.Value && ((string)dataReader["UNICAVISITAPORDOCTO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Plazoxproducto = dataReader["PLAZOXPRODUCTO"] != System.DBNull.Value && ((string)dataReader["PLAZOXPRODUCTO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Autocompleteconexisenventa = dataReader["AUTOCOMPLETECONEXISENVENTA"] != System.DBNull.Value && ((string)dataReader["AUTOCOMPLETECONEXISENVENTA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Aplicarcambiosprecauto = dataReader["APLICARCAMBIOSPRECAUTO"] != System.DBNull.Value && ((string)dataReader["APLICARCAMBIOSPRECAUTO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Manejacupones = dataReader["MANEJACUPONES"] != System.DBNull.Value && ((string)dataReader["MANEJACUPONES"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Hab_devoluciontraslado = dataReader["HAB_DEVOLUCIONTRASLADO"] != System.DBNull.Value && ((string)dataReader["HAB_DEVOLUCIONTRASLADO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Hab_devolucionsurtidosuc = dataReader["HAB_DEVOLUCIONSURTIDOSUC"] != System.DBNull.Value && ((string)dataReader["HAB_DEVOLUCIONSURTIDOSUC"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Manejaproductospromocion = dataReader["MANEJAPRODUCTOSPROMOCION"] != System.DBNull.Value && ((string)dataReader["MANEJAPRODUCTOSPROMOCION"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Precionetoengrids = dataReader["PRECIONETOENGRIDS"] != System.DBNull.Value && ((string)dataReader["PRECIONETOENGRIDS"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Pagoservconsolidado = dataReader["PAGOSERVCONSOLIDADO"] != System.DBNull.Value && ((string)dataReader["PAGOSERVCONSOLIDADO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Mostrarinvinfoadicprod = dataReader["MOSTRARINVINFOADICPROD"] != System.DBNull.Value && ((string)dataReader["MOSTRARINVINFOADICPROD"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Hab_consolidadoautomatico = dataReader["HAB_CONSOLIDADOAUTOMATICO"] != System.DBNull.Value && ((string)dataReader["HAB_CONSOLIDADOAUTOMATICO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Piezacajaenticket = dataReader["PIEZACAJAENTICKET"] != System.DBNull.Value && ((string)dataReader["PIEZACAJAENTICKET"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Generarfe = dataReader["GENERARFE"] != System.DBNull.Value && ((string)dataReader["GENERARFE"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Movil_tienevendedores = dataReader["MOVIL_TIENEVENDEDORES"] != System.DBNull.Value && ((string)dataReader["MOVIL_TIENEVENDEDORES"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Imprimircopiaalmacen = dataReader["IMPRIMIRCOPIAALMACEN"] != System.DBNull.Value && ((string)dataReader["IMPRIMIRCOPIAALMACEN"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Movil3_preimportar = dataReader["MOVIL3_PREIMPORTAR"] != System.DBNull.Value && ((string)dataReader["MOVIL3_PREIMPORTAR"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Busquedatipo2 = dataReader["BUSQUEDATIPO2"] != System.DBNull.Value && ((string)dataReader["BUSQUEDATIPO2"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Consfactomitirvales = dataReader["CONSFACTOMITIRVALES"] != System.DBNull.Value && ((string)dataReader["CONSFACTOMITIRVALES"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Desgloseiepsfactura = dataReader["DESGLOSEIEPSFACTURA"] != System.DBNull.Value && ((string)dataReader["DESGLOSEIEPSFACTURA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Imprimirbancoscorte = dataReader["IMPRIMIRBANCOSCORTE"] != System.DBNull.Value && ((string)dataReader["IMPRIMIRBANCOSCORTE"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            //item.Pago_tarjmenorpreciolista = dataReader["PAGO_TARJMENORPRECIOLISTA"] != System.DBNull.Value && ((string)dataReader["PAGO_TARJMENORPRECIOLISTA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Impr_canc_venta = dataReader["IMPR_CANC_VENTA"] != System.DBNull.Value && ((string)dataReader["IMPR_CANC_VENTA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Retirocajaalcerrarcorte = dataReader["RETIROCAJAALCERRARCORTE"] != System.DBNull.Value && ((string)dataReader["RETIROCAJAALCERRARCORTE"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Pagotarjmenorpreciolistaall = dataReader["PAGOTARJMENORPRECIOLISTAALL"] != System.DBNull.Value && ((string)dataReader["PAGOTARJMENORPRECIOLISTAALL"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Preguntarservdom = dataReader["PREGUNTARSERVDOM"] != System.DBNull.Value && ((string)dataReader["PREGUNTARSERVDOM"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Habppc = dataReader["HABPPC"] != System.DBNull.Value && ((string)dataReader["HABPPC"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Soloabonoaplicado = dataReader["SOLOABONOAPLICADO"] != System.DBNull.Value && ((string)dataReader["SOLOABONOAPLICADO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Imprformaventatrasl = dataReader["IMPRFORMAVENTATRASL"] != System.DBNull.Value && ((string)dataReader["IMPRFORMAVENTATRASL"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Habrevisionfinal = dataReader["HABREVISIONFINAL"] != System.DBNull.Value && ((string)dataReader["HABREVISIONFINAL"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Habfondodinamico = dataReader["HABFONDODINAMICO"] != System.DBNull.Value && ((string)dataReader["HABFONDODINAMICO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Habventaclisuc = dataReader["HABVENTACLISUC"] != System.DBNull.Value && ((string)dataReader["HABVENTACLISUC"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Habwsdbf = dataReader["HABWSDBF"] != System.DBNull.Value && ((string)dataReader["HABWSDBF"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Manejautilidadprecios = dataReader["MANEJAUTILIDADPRECIOS"] != System.DBNull.Value && ((string)dataReader["MANEJAUTILIDADPRECIOS"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Habmultplazocompra = dataReader["HABMULTPLAZOCOMPRA"] != System.DBNull.Value && ((string)dataReader["HABMULTPLAZOCOMPRA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Costorepoigualcostoult = dataReader["COSTOREPOIGUALCOSTOULT"] != System.DBNull.Value && ((string)dataReader["COSTOREPOIGUALCOSTOULT"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Ticket_desc_vale_al_final = dataReader["TICKET_DESC_VALE_AL_FINAL"] != System.DBNull.Value && ((string)dataReader["TICKET_DESC_VALE_AL_FINAL"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Habsurtidoprevio = dataReader["HABSURTIDOPREVIO"] != System.DBNull.Value && ((string)dataReader["HABSURTIDOPREVIO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Recibopreviewcomanda = dataReader["RECIBOPREVIEWCOMANDA"] != System.DBNull.Value && ((string)dataReader["RECIBOPREVIEWCOMANDA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Ticket_impr_desc2 = dataReader["TICKET_IMPR_DESC2"] != System.DBNull.Value && ((string)dataReader["TICKET_IMPR_DESC2"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Habsurtidopostmovil = dataReader["HABSURTIDOPOSTMOVIL"] != System.DBNull.Value && ((string)dataReader["HABSURTIDOPOSTMOVIL"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Autpreciolistabajo = dataReader["AUTPRECIOLISTABAJO"] != System.DBNull.Value && ((string)dataReader["AUTPRECIOLISTABAJO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            //item.Activo = dataReader["ACTIVO"] != System.DBNull.Value && ((string)dataReader["ACTIVO"]).Trim() == "N" ? BoolCS.N : BoolCS.S;
            //item.Creado = dataReader["CREADO"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["CREADO"])) : DateTime.UtcNow;
            //item.Modificado = dataReader["MODIFICADO"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["MODIFICADO"])) : DateTime.UtcNow;
            item.Imp_prod_def = dataReader["IMP_PROD_DEF"] != System.DBNull.Value ? (decimal)dataReader["IMP_PROD_DEF"] : 0;
            item.Cantidad = dataReader["CANTIDAD"] != System.DBNull.Value ? (decimal)dataReader["CANTIDAD"] : 0;
            item.Utilidad = dataReader["UTILIDAD"] != System.DBNull.Value ? (decimal)dataReader["UTILIDAD"] : 0;
            item.Fechaanterior = dataReader["FECHAANTERIOR"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["FECHAANTERIOR"])) : null;
            item.Fechaactual = dataReader["FECHAACTUAL"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["FECHAACTUAL"])) : null;
            item.Fechaultima = dataReader["FECHAULTIMA"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["FECHAULTIMA"])) : null;
            item.Max_inv_fis_cant = dataReader["MAX_INV_FIS_CANT"] != System.DBNull.Value ? (decimal)dataReader["MAX_INV_FIS_CANT"] : 0;
            item.Comisionmedico = dataReader["COMISIONMEDICO"] != System.DBNull.Value ? (decimal)dataReader["COMISIONMEDICO"] : 0;
            item.Comisiondependiente = dataReader["COMISIONDEPENDIENTE"] != System.DBNull.Value ? (decimal)dataReader["COMISIONDEPENDIENTE"] : 0;
            item.Descuentovale = dataReader["DESCUENTOVALE"] != System.DBNull.Value ? (decimal)dataReader["DESCUENTOVALE"] : 0;
            item.Ult_fecha_imp_prod = dataReader["ULT_FECHA_IMP_PROD"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["ULT_FECHA_IMP_PROD"])) : null;
            item.Porc_comisionencargado = dataReader["PORC_COMISIONENCARGADO"] != System.DBNull.Value ? (decimal)dataReader["PORC_COMISIONENCARGADO"] : 0;
            item.Porc_comisionvendedor = dataReader["PORC_COMISIONVENDEDOR"] != System.DBNull.Value ? (decimal)dataReader["PORC_COMISIONVENDEDOR"] : 0;
            item.Monederomontominimo = dataReader["MONEDEROMONTOMINIMO"] != System.DBNull.Value ? (decimal)dataReader["MONEDEROMONTOMINIMO"] : 0;
            item.Retencioniva = dataReader["RETENCIONIVA"] != System.DBNull.Value ? (decimal)dataReader["RETENCIONIVA"] : 0;
            item.Retencionisr = dataReader["RETENCIONISR"] != System.DBNull.Value ? (decimal)dataReader["RETENCIONISR"] : 0;
            item.Fechainiciopedido = dataReader["FECHAINICIOPEDIDO"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["FECHAINICIOPEDIDO"])) : null;
            item.Minutilidad = dataReader["MINUTILIDAD"] != System.DBNull.Value ? (decimal)dataReader["MINUTILIDAD"] : 0;
            item.Lastchangeproddesc = dataReader["LASTCHANGEPRODDESC"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["LASTCHANGEPRODDESC"])) : null;
            item.Lastchangeclientenombre = dataReader["LASTCHANGECLIENTENOMBRE"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["LASTCHANGECLIENTENOMBRE"])) : null;
            item.Movillastpreciodate = dataReader["MOVILLASTPRECIODATE"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["MOVILLASTPRECIODATE"])) : null;
            item.Lastchangeprecioprod = dataReader["LASTCHANGEPRECIOPROD"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["LASTCHANGEPRECIOPROD"])) : null;
            item.Prodcambioparamovil = dataReader["PRODCAMBIOPARAMOVIL"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["PRODCAMBIOPARAMOVIL"])) : null;
            item.Descuentotipo1porc = dataReader["DESCUENTOTIPO1PORC"] != System.DBNull.Value ? (decimal)dataReader["DESCUENTOTIPO1PORC"] : 0;
            item.Descuentotipo2porc = dataReader["DESCUENTOTIPO2PORC"] != System.DBNull.Value ? (decimal)dataReader["DESCUENTOTIPO2PORC"] : 0;
            item.Descuentotipo3porc = dataReader["DESCUENTOTIPO3PORC"] != System.DBNull.Value ? (decimal)dataReader["DESCUENTOTIPO3PORC"] : 0;
            item.Descuentotipo4porc = dataReader["DESCUENTOTIPO4PORC"] != System.DBNull.Value ? (decimal)dataReader["DESCUENTOTIPO4PORC"] : 0;
            item.Fecharespaldo = dataReader["FECHARESPALDO"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["FECHARESPALDO"])) : null;
            item.Montoretirocaja = dataReader["MONTORETIROCAJA"] != System.DBNull.Value ? (decimal)dataReader["MONTORETIROCAJA"] : 0;
            item.Comisionportarjeta = dataReader["COMISIONPORTARJETA"] != System.DBNull.Value ? (decimal)dataReader["COMISIONPORTARJETA"] : 0;
            item.Piezasigualesmediomayoreo = dataReader["PIEZASIGUALESMEDIOMAYOREO"] != System.DBNull.Value ? (decimal)dataReader["PIEZASIGUALESMEDIOMAYOREO"] : 0;
            item.Piezasdifmediomayoreo = dataReader["PIEZASDIFMEDIOMAYOREO"] != System.DBNull.Value ? (decimal)dataReader["PIEZASDIFMEDIOMAYOREO"] : 0;
            item.Piezasigualesmayoreo = dataReader["PIEZASIGUALESMAYOREO"] != System.DBNull.Value ? (decimal)dataReader["PIEZASIGUALESMAYOREO"] : 0;
            item.Piezasdifmayoreo = dataReader["PIEZASDIFMAYOREO"] != System.DBNull.Value ? (decimal)dataReader["PIEZASDIFMAYOREO"] : 0;
            item.Comisiontarjetaempresa = dataReader["COMISIONTARJETAEMPRESA"] != System.DBNull.Value ? (decimal)dataReader["COMISIONTARJETAEMPRESA"] : 0;
            item.Ivacomisiontarjetaempresa = dataReader["IVACOMISIONTARJETAEMPRESA"] != System.DBNull.Value ? (decimal)dataReader["IVACOMISIONTARJETAEMPRESA"] : 0;
            item.Fechaactualizacionemida = dataReader["FECHAACTUALIZACIONEMIDA"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["FECHAACTUALIZACIONEMIDA"])) : null;
            item.Fechaactualizacionemidaserv = dataReader["FECHAACTUALIZACIONEMIDASERV"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["FECHAACTUALIZACIONEMIDASERV"])) : null;
            item.Montomaxsaldomenor = dataReader["MONTOMAXSALDOMENOR"] != System.DBNull.Value ? (decimal)dataReader["MONTOMAXSALDOMENOR"] : 0;
            item.Emidaporcutilidadrecargas = dataReader["EMIDAPORCUTILIDADRECARGAS"] != System.DBNull.Value ? (decimal)dataReader["EMIDAPORCUTILIDADRECARGAS"] : 0;
            item.Emidautilidadpagoservicios = dataReader["EMIDAUTILIDADPAGOSERVICIOS"] != System.DBNull.Value ? (decimal)dataReader["EMIDAUTILIDADPAGOSERVICIOS"] : 0;
            item.Ult_consolidadoautomatico = dataReader["ULT_CONSOLIDADOAUTOMATICO"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["ULT_CONSOLIDADOAUTOMATICO"])) : null;
            item.Movil_ultcam_sesion = dataReader["MOVIL_ULTCAM_SESION"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["MOVIL_ULTCAM_SESION"])) : null;
            item.Kitsdef_ultact = dataReader["KITSDEF_ULTACT"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["KITSDEF_ULTACT"])) : null;
            item.Kitsdef_unniv_ultact = dataReader["KITSDEF_UNNIV_ULTACT"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["KITSDEF_UNNIV_ULTACT"])) : null;
            item.Maxcomisionxcliente = dataReader["MAXCOMISIONXCLIENTE"] != System.DBNull.Value ? (decimal)dataReader["MAXCOMISIONXCLIENTE"] : 0;
            item.Comisiondebtarjetaempresa = dataReader["COMISIONDEBTARJETAEMPRESA"] != System.DBNull.Value ? (decimal)dataReader["COMISIONDEBTARJETAEMPRESA"] : 0;
            item.Comisiondebportarjeta = dataReader["COMISIONDEBPORTARJETA"] != System.DBNull.Value ? (decimal)dataReader["COMISIONDEBPORTARJETA"] : 0;
            item.Factconsmaxpor = dataReader["FACTCONSMAXPOR"] != System.DBNull.Value ? (decimal)dataReader["FACTCONSMAXPOR"] : 0;
            item.Fiscalfechacancelacion2 = dataReader["FISCALFECHACANCELACION2"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["FISCALFECHACANCELACION2"])) : null;
            item.Porcutilidadlistado = dataReader["PORCUTILIDADLISTADO"] != System.DBNull.Value ? (decimal)dataReader["PORCUTILIDADLISTADO"] : 0;
            item.Smtpport = dataReader["SMTPPORT"] != System.DBNull.Value ? (int)dataReader["SMTPPORT"] : (int?)null;
            item.Longprodbascula = dataReader["LONGPRODBASCULA"] != System.DBNull.Value ? (short)dataReader["LONGPRODBASCULA"] : (short?)null;
            item.Longpesobascula = dataReader["LONGPESOBASCULA"] != System.DBNull.Value ? (short)dataReader["LONGPESOBASCULA"] : (short?)null;
            item.Monederocaducidad = dataReader["MONEDEROCADUCIDAD"] != System.DBNull.Value ? (int)dataReader["MONEDEROCADUCIDAD"] : (int?)null;
            item.Doblecopiacredito = dataReader["DOBLECOPIACREDITO"] != System.DBNull.Value ? (int)dataReader["DOBLECOPIACREDITO"] : (int?)null;
            item.Doblecopiatraslado = dataReader["DOBLECOPIATRASLADO"] != System.DBNull.Value ? (int)dataReader["DOBLECOPIATRASLADO"] : (int?)null;
            item.Cortacaducidad = dataReader["CORTACADUCIDAD"] != System.DBNull.Value ? (int)dataReader["CORTACADUCIDAD"] : (int?)null;
            item.Movilcierrecobranza = dataReader["MOVILCIERRECOBRANZA"] != System.DBNull.Value ? (int)dataReader["MOVILCIERRECOBRANZA"] : (int?)null;
            item.Movilcierreventa = dataReader["MOVILCIERREVENTA"] != System.DBNull.Value ? (int)dataReader["MOVILCIERREVENTA"] : (int?)null;
            item.Pendmaxdias = dataReader["PENDMAXDIAS"] != System.DBNull.Value ? (int)dataReader["PENDMAXDIAS"] : (int?)null;
            item.Clienteconsolidadoid = dataReader["CLIENTECONSOLIDADOID"] != System.DBNull.Value ? (long)dataReader["CLIENTECONSOLIDADOID"] : (long?)null;
            item.Timeoutpindistsale = dataReader["TIMEOUTPINDISTSALE"] != System.DBNull.Value ? (int)dataReader["TIMEOUTPINDISTSALE"] : (int?)null;
            item.Timeoutlookup = dataReader["TIMEOUTLOOKUP"] != System.DBNull.Value ? (int)dataReader["TIMEOUTLOOKUP"] : (int?)null;
            item.Timeoutpindistsaleserv = dataReader["TIMEOUTPINDISTSALESERV"] != System.DBNull.Value ? (int)dataReader["TIMEOUTPINDISTSALESERV"] : (int?)null;
            item.Emidaservicioproveedorid = dataReader["EMIDASERVICIOPROVEEDORID"] != System.DBNull.Value ? (long)dataReader["EMIDASERVICIOPROVEEDORID"] : (long?)null;
            item.Decimalesencantidad = dataReader["DECIMALESENCANTIDAD"] != System.DBNull.Value ? (int)dataReader["DECIMALESENCANTIDAD"] : (int?)null;
            item.Caducidadminima = dataReader["CADUCIDADMINIMA"] != System.DBNull.Value ? (int)dataReader["CADUCIDADMINIMA"] : (int?)null;
            item.Numcancelactauto = dataReader["NUMCANCELACTAUTO"] != System.DBNull.Value ? (short)dataReader["NUMCANCELACTAUTO"] : (short?)null;
            item.Numcancelactautousuario = dataReader["NUMCANCELACTAUTOUSUARIO"] != System.DBNull.Value ? (short)dataReader["NUMCANCELACTAUTOUSUARIO"] : (short?)null;
            item.Versionwsexistencias = dataReader["VERSIONWSEXISTENCIAS"] != System.DBNull.Value ? (int)dataReader["VERSIONWSEXISTENCIAS"] : (int?)null;
            item.Numticketsabono = dataReader["NUMTICKETSABONO"] != System.DBNull.Value ? (int)dataReader["NUMTICKETSABONO"] : (int?)null;
            item.Intentosretirocaja = dataReader["INTENTOSRETIROCAJA"] != System.DBNull.Value ? (int)dataReader["INTENTOSRETIROCAJA"] : (int?)null;
            item.Doblecopiacontado = dataReader["DOBLECOPIACONTADO"] != System.DBNull.Value ? (int)dataReader["DOBLECOPIACONTADO"] : (int?)null;
            item.Versiontopeid = dataReader["VERSIONTOPEID"] != System.DBNull.Value ? (long)dataReader["VERSIONTOPEID"] : (long?)null;
            item.Versioncomisionid = dataReader["VERSIONCOMISIONID"] != System.DBNull.Value ? (long)dataReader["VERSIONCOMISIONID"] : (long?)null;
            item.Segundoscicloftp = dataReader["SEGUNDOSCICLOFTP"] != System.DBNull.Value ? (int)dataReader["SEGUNDOSCICLOFTP"] : (int?)null;
            item.Diasmaxexpftp = dataReader["DIASMAXEXPFTP"] != System.DBNull.Value ? (int)dataReader["DIASMAXEXPFTP"] : (int?)null;
            item.Diasmaximpftp = dataReader["DIASMAXIMPFTP"] != System.DBNull.Value ? (int)dataReader["DIASMAXIMPFTP"] : (int?)null;
            item.Doblecopiatarjeta = dataReader["DOBLECOPIATARJETA"] != System.DBNull.Value ? (int)dataReader["DOBLECOPIATARJETA"] : (int?)null;
            item.Cantticketretiro = dataReader["CANTTICKETRETIRO"] != System.DBNull.Value ? (int)dataReader["CANTTICKETRETIRO"] : (int?)null;
            item.Cantticketabrircorte = dataReader["CANTTICKETABRIRCORTE"] != System.DBNull.Value ? (int)dataReader["CANTTICKETABRIRCORTE"] : (int?)null;
            item.Cantticketcompras = dataReader["CANTTICKETCOMPRAS"] != System.DBNull.Value ? (int)dataReader["CANTTICKETCOMPRAS"] : (int?)null;
            item.Cantticketfondocaja = dataReader["CANTTICKETFONDOCAJA"] != System.DBNull.Value ? (int)dataReader["CANTTICKETFONDOCAJA"] : (int?)null;
            item.Cantticketgastos = dataReader["CANTTICKETGASTOS"] != System.DBNull.Value ? (int)dataReader["CANTTICKETGASTOS"] : (int?)null;
            item.Cantticketdepositos = dataReader["CANTTICKETDEPOSITOS"] != System.DBNull.Value ? (int)dataReader["CANTTICKETDEPOSITOS"] : (int?)null;
            item.Cantticketcierrecorte = dataReader["CANTTICKETCIERRECORTE"] != System.DBNull.Value ? (int)dataReader["CANTTICKETCIERRECORTE"] : (int?)null;
            item.Cantticketcierrebilletes = dataReader["CANTTICKETCIERREBILLETES"] != System.DBNull.Value ? (int)dataReader["CANTTICKETCIERREBILLETES"] : (int?)null;
            item.Numticketscomanda = dataReader["NUMTICKETSCOMANDA"] != System.DBNull.Value ? (int)dataReader["NUMTICKETSCOMANDA"] : (int?)null;
            
            if (Lista_precio_defClave_obj != null)
                item.Lista_precio_defid = Lista_precio_defClave_obj.Id;
            else
                item.Lista_precio_defid = null;

            if (Listapreciominimo_Clave_obj != null)
                item.Listapreciominimo = Listapreciominimo_Clave_obj.Id;
            else
                item.Listapreciominimo = null;

            if (EncargadoClave_obj != null)
                item.Encargadoid = EncargadoClave_obj.Id;
            else
                item.Encargadoid = null;

            if (Listaprecioxuempaque_Clave_obj != null)
                item.Listaprecioxuempaque = Listaprecioxuempaque_Clave_obj.Id;
            else
                item.Listaprecioxuempaque = null;

            if (Listaprecioxpzacaja_Clave_obj != null)
                item.Listaprecioxpzacaja = Listaprecioxpzacaja_Clave_obj.Id;
            else
                item.Listaprecioxpzacaja = null;

            if (Listaprecioinimayo_Clave_obj != null)
                item.Listaprecioinimayo = Listaprecioinimayo_Clave_obj.Id;
            else
                item.Listaprecioinimayo = null;

            if (TipodescuentoprodClave_obj != null)
                item.Tipodescuentoprodid = TipodescuentoprodClave_obj.Id;
            else
                item.Tipodescuentoprodid = null;

            if (TipoutilidadClave_obj != null)
                item.Tipoutilidadid = TipoutilidadClave_obj.Id;
            else
                item.Tipoutilidadid = null;

            if (CampoimpocostorepoClave_obj != null)
                item.Campoimpocostorepoid = CampoimpocostorepoClave_obj.Id;
            else
                item.Campoimpocostorepoid = null;

            if (VendedormovilClave_obj != null)
                item.Vendedormovilid = VendedormovilClave_obj.Id;
            else
                item.Vendedormovilid = null;

            if (ClienteconsolidadoClave_obj != null)
                item.Clienteconsolidadoid = ClienteconsolidadoClave_obj.Id;
            else
                item.Clienteconsolidadoid = null;

            if (EmidarecargalineaClave_obj != null)
                item.Emidarecargalineaid = EmidarecargalineaClave_obj.Id;
            else
                item.Emidarecargalineaid = null;

            if (EmidarecargamarcaClave_obj != null)
                item.Emidarecargamarcaid = EmidarecargamarcaClave_obj.Id;
            else
                item.Emidarecargamarcaid = null;

            if (EmidarecargaproveedorClave_obj != null)
                item.Emidarecargaproveedorid = EmidarecargaproveedorClave_obj.Id;
            else
                item.Emidarecargaproveedorid = null;

            if (EmidaserviciolineaClave_obj != null)
                item.Emidaserviciolineaid = EmidaserviciolineaClave_obj.Id;
            else
                item.Emidaserviciolineaid = null;

            if (EmidaserviciomarcaClave_obj != null)
                item.Emidaserviciomarcaid = EmidaserviciomarcaClave_obj.Id;
            else
                item.Emidaserviciomarcaid = null;

            if (EmidaservicioproveedorClave_obj != null)
                item.Emidaservicioproveedorid = EmidaservicioproveedorClave_obj.Id;
            else
                item.Emidaservicioproveedorid = null;


            if (PrecioajustedifinvClave_obj != null)
                item.Precioajustedifinvid = PrecioajustedifinvClave_obj.Id;
            else
                item.Precioajustedifinvid = null;

            if (AlmacenrecepcionClave_obj != null)
                item.Almacenrecepcionid = AlmacenrecepcionClave_obj.Id;
            else
                item.Almacenrecepcionid = null;

            if (Sat_metodopagoClave_obj != null)
                item.Sat_metodopagoid = Sat_metodopagoClave_obj.Id;
            else
                item.Sat_metodopagoid = null;

            if (Sat_regimenfiscalClave_obj != null)
                item.Sat_regimenfiscalid = Sat_regimenfiscalClave_obj.Id;
            else
                item.Sat_regimenfiscalid = null;

            if (AgrupacionventaClave_obj != null)
                item.Agrupacionventaid = AgrupacionventaClave_obj.Id;
            else
                item.Agrupacionventaid = null;

            if (MonederolistaprecioClave_obj != null)
                item.Monederolistaprecioid = MonederolistaprecioClave_obj.Id;
            else
                item.Monederolistaprecioid = null;

            if (Listapreciomaylinea_Clave_obj != null)
                item.Listapreciomaylinea = Listapreciomaylinea_Clave_obj.Id;
            else
                item.Listapreciomaylinea = null;

            if (Listapremedmaylinea_Clave_obj != null)
                item.Listaprecmedmaylinea = Listapremedmaylinea_Clave_obj.Id;
            else
                item.Listaprecmedmaylinea = null;



            if (existItem)
                controller.Update(item);
            else
                controller.Insert(item);

            localContext.SaveChanges();

            return true;
        }
    }
}
