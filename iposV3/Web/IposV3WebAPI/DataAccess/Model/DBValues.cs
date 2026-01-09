using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Model
{

    public class DBValues
    {
        public const long _DOCTO_ESTATUS_BORRADOR = 0;
        public const long _MOVTO_ESTATUS_BORRADOR = 0;
        public const long _DOCTO_TIPO_VENTA = 21;
        public const long _DOCTO_TIPO_DEVOLUCION = 23;
        public const long _DOCTO_TIPO_COMPRA = 11;
        public const long _DOCTO_TIPO_COMPRA_DEVO = 12;
        public const long _DOCTO_TIPO_COMPRA_CANCELACION = 13;
        public const long _DOCTO_TIPO_COMPRA_DEVO_CANCELACION = 15;
        public const long _DOCTO_TIPO_CANCELACIONVENTAAPARTADO = 26;

        public const long _DOCTO_TIPO_ORDEN_COMPRA = 16;
        public const long _DOCTO_TIPO_RECEPCIONORDEN_COMPRA = 17;


        public const long _DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO = 22;
        public const long _DOCTO_TIPO_CANCELACIONDEVOLUCIONCOMONOTACREDITO = 24;


        public const long _DOCTO_TIPO_PEDIDO_COMPRA = 14;

        public const long _DOCTO_TIPO_INVENTARIO_FISICO = 50;
        public const long _DOCTO_TIPO_INVENTARIO_AJUSTEENTRADA = 51;
        public const long _DOCTO_TIPO_INVENTARIO_AJUSTESALIDA = 52;
        public const long _DOCTO_TIPO_INVENTARIO_FISICOXLOC = 53;
        public const long _DOCTO_TIPO_CAMBIOLOTES_ENTRADA = 54;
        public const long _DOCTO_TIPO_CAMBIOLOTES_SALIDA = 55;


        public const long _DOCTO_TIPO_CANCELACION = 23;


        public const long _DOCTO_TIPO_VENTAAPARTADO = 25;


        public const long _DOCTO_TIPO_TRASPASO_ENVIO_BORRADOR = 30;
        public const long _DOCTO_TIPO_TRASPASO_ENVIO = 31;
        public const long _DOCTO_TIPO_TRASPASO_REC = 41;

        public const long _DOCTO_TIPO_TRASPASO_ENTRADA_BORRADOR = 40;


        public const long _DOCTO_TIPO_TRASPASO_ENVIO_DEVO = 32;



        public const long _DOCTO_TIPO_PEDIDO_ENVIO_DEVO = 82;


        public const long _DOCTO_TIPO_RETIRO_PAGOPROVEEDOR = 60;
        public const long _DOCTO_TIPO_RETIRO_SUPERVISOR = 61;


        public const long _DOCTO_TIPO_RETIRO_CAJA = 62;
        public const long _DOCTO_TIPO_GASTO = 63;
        public const long _DOCTO_TIPO_RETIRO_CAJA_CANCELACION = 64;
        public const long _DOCTO_TIPO_GASTO_CANCELACION = 65;

        public const long _DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA = 81;

        public const long _DOCTO_TIPO_ANTICIPO_CLIENTES = 201;
        public const long _DOCTO_TIPO_ANTICIPO_PROVEEDORES = 202;


        public const long _DOCTO_TIPO_RECIBOELECTRONICO = 205;


        public const long _DOCTO_TIPO_TRASPASO_ALMACEN = 211;

        public const long _DOCTO_TIPO_HISTORIALMOVIL = 301;
        public const long _DOCTO_TIPO_VENTAMOVIL = 321;
        public const long _DOCTO_TIPO_CANCELACIONMOVIL = 323;


        public const long _DOCTO_TIPO_ENSAMBLE = 501;
        public const long _DOCTO_TIPO_DESENSAMBLE = 502;


        public const long _DOCTO_TIPO_FACTCONSOLIDADA = 701;
        public const long _DOCTO_TIPO_DEVCONSOLIDADA = 702;

        public const long _DOCTO_TIPO_OTRASENTRADAS = 111;
        public const long _DOCTO_TIPO_OTRASSALIDAS = 121;


        public const long _DOCTO_TIPO_VENTA_FUTURO = 821;
        public const long _DOCTO_TIPO_CANCELACION_VENTA_FUTURO = 823;


        public const long _DOCTO_TIPO_TRASLADO_PRODUCTO_PROMOCION = 1001;
        public const long _DOCTO_TIPO_DESTRASLADO_PRODUCTO_PROMOCION = 1002;
        public const long _DOCTO_TIPO_AJUSTE_TRASLADO_PRODUCTO_PROMOCION = 1003;
        public const long _DOCTO_TIPO_AJUSTE_DESTRASLADO_PRODUCTO_PROMOCION = 1004;


        public const long _DOCTO_TIPO_DEPOSITO = 66;
        public const long _DOCTO_TIPO_DEPOSITO_CANCELACION = 67;

        //Fondeo de Caja
        public const long _DOCTO_TIPO_FONDEO_CAJA = 68;
        public const long _DOCTO_TIPO_FONDEO_CAJA_CANCELACION = 69;



        public const long _DOCTO_TIPO_COMPRA_SUC = 1011;
        public const long _DOCTO_TIPO_COMPRA_DEVO_SUC = 1012;
        public const long _DOCTO_TIPO_COMPRA_CANCELACION_SUC = 1013;
        public const long _DOCTO_TIPO_COMPRA_DEVO_CANCELACION_SUC = 1015;


        public const long _DOCTO_SUBTIPO_PEDIDOXFECHA = 1;
        public const long _DOCTO_SUBTIPO_PEDIDOXSTOCK = 2;



        public const long _DOCTO_SUBTIPO_INVENTARIOCOMPLETO= 4;
        public const long _DOCTO_SUBTIPO_INVENTARIOPARCIAL = 5;
        public const long _DOCTO_SUBTIPO_INVENTARIOPARCIALXPRODUCTO = 9;

        public const long _DOCTO_SUBTIPO_PEDIDOXSTOCKMAX = 14;


        public const long _DOCTO_SUBTIPO_SOLICITUDMERCANCIA = 29;


        public const long _DOCTO_SUBTIPO_VENDMOVIL = 15;
        public const long _DOCTO_SUBTIPO_COMPRAMOVIL = 15;

        public const long _DOCTO_SUBTIPO_COMPRAPEDIDO = 6;
        public const long _DOCTO_SUBTIPO_COMPRARECORDEN = 16;
        public const long _DOCTO_SUBTIPO_COMPRAIMPORTADA = 23;

        public const long _DOCTO_SUBTIPO_TRASPASOFRANQUICIA = 7;
        public const long _DOCTO_SUBTIPO_TRASPASOFRANQUICIA_SALIDA = 8;

        public const long _DOCTO_SUBTIPO_VENTAFUTUROAPLICADA = 25;

        public const long _DOCTO_SUBTIPO_SUSTITUCION = 26;

        public const long _DOCTO_SUBTIPO_SINAFECTARINV = 28;

        public const long _DOCTO_SUBTIPO_RECARGA = 22;
        public const long _DOCTO_SUBTIPO_PAGOSERVICIO = 24;


        public const long _DOCTO_ESTATUS_COMPLETO = 1;
        public const long _DOCTO_ESTATUS_CANCELADA = 2;

        public const long _DOCTO_ESTATUS_INVENTARIOFIN = 3;

        public const long _DOCTO_UNICA_CAJAID_VENTA = 1;
        public const long _DOCTO_ESTATUS_PAGO_BORRADOR = 0;

        public const long _DOCTO_TIPO_PEDIDOMOVIL = 331;
        public const long _DOCTO_TIPO_COMPRAMOVIL = 341;


        public const long _DOCTO_ALMACEN_DEFAULT = 1;
        public const string _DOCTO_ALMACEN_CLAVE_DEFAULT = "TIENDA";

        public const long _DEFAULT_CUSTOMER_ID = 1;
        public const long _CAJA_DEFAULT = 1;

        public const long _ALMACEN_DEFAULT = 1;


        public const long _FORMA_PAGO_EFECTIVO = 1;
        public const long _FORMA_PAGO_TARJETA = 2;
        public const long _FORMA_PAGO_CREDITO = 4;
        public const long _FORMA_PAGO_CHEQUE = 3;
        public const long _FORMA_PAGO_VALE = 5;


        public const long _FORMA_PAGO_TRANSFERENCIA = 15;

        public const long _FORMA_PAGO_MONEDERO = 14;

        public const long _FORMA_PAGO_NOTACREDITO = 6;
        public const long _FORMA_PAGO_NOTADEBITO = 7;


        public const long _FORMA_PAGO_NOTACREDITO_APARTADOCREDITO = 8;
        public const long _FORMA_PAGO_NOTADEBITO_APARTADODEBITO = 9;

        public const long _FORMA_PAGO_NOIDENTIFICADO = 16;

        public const long _FORMA_PAGO_INTERCAMBIOMERCANCIACREDITO = 18;
        public const long _FORMA_PAGO_INTERCAMBIOMERCANCIADEBITO = 19;

        public const long _FORMA_PAGO_DEPOSITO = 20;
        public const long _FORMA_PAGO_DEPOSITOTERCERO = 21;


        public const long _FORMA_PAGOSAT_EFECTIVO = 1;
        public const long _FORMA_PAGOSAT_TARJETACREDITO = 4;
        public const long _FORMA_PAGOSAT_CHEQUE = 2;
        public const long _FORMA_PAGOSAT_VALE = 8;
        public const long _FORMA_PAGOSAT_TRANSFERENCIA = 3;
        public const long _FORMA_PAGOSAT_TARJETADEBITO = 28;
        public const long _FORMA_PAGOSAT_TARJETASERVICIO = 29;
        public const long _FORMA_PAGOSAT_COMPENSACION = 17;
        public const long _FORMA_PAGOSAT_OTRO = 99;


        public const long _TIPO_ABONO_INICIAL = 1;
        public const long _TIPO_ABONO_ABONO = 2;
        public const long _TIPO_ABONO_REVERSION = 3;


        public const string _DB_BOOLVALUE_NO = "N";
        public const string _DB_BOOLVALUE_SI = "S";


        public const string _DB_VALUE_FTPGENERADO = "G";

        public const string _EXP_FILES_TIPO_VENTA = "V";
        public const string _EXP_FILES_TIPO_TRASLADO = "T";
        public const string _EXP_FILES_TIPO_TRASLADOAUX = "U";
        public const string _EXP_FILES_TIPO_RECEPCIONCOMPRA = "R";
        public const string _EXP_FILES_TIPO_PEDIDO = "P";
        public const string _EXP_FILES_TIPO_TRASLADODEVO = "TD";
        public const string _EXP_FILES_TIPO_PEDIDODEVO = "PD";
        public const string _EXP_FILES_TIPO_INVENTARIO = "I";
        public const string _EXP_FILES_TIPO_INV_MAIL = "M";
        public const string _EXP_FILES_TIPO_REC_ELIM_MAIL = "L";
        public const string _EXP_FILES_TIPO_MATRIZPEDIDO = "Z";
        public const string _EXP_FILES_TIPO_MATRIZPEDIDOAUX = "Y";
        public const string _EXP_FILES_TIPO_FACTURAELECTRONICA_XML = "FX";
        public const string _EXP_FILES_TIPO_FACTURAELECTRONICA_PDF = "FP";
        public const string _EXP_FILES_TIPO_DEVOLUCIONELECTRONICA_XML = "DX";
        public const string _EXP_FILES_TIPO_DEVOLUCIONELECTRONICA_PDF = "DP";
        public const string _EXP_FILES_TIPO_ABONOSELECTRONICOS_XML = "AX";
        public const string _EXP_FILES_TIPO_ABONOSELECTRONICOS_PDF = "AP";

        public const long _EXP_FILES_TIPO_VENTA_ID = 1;
        public const long _EXP_FILES_TIPO_TRASLADO_ID = 2;
        public const long _EXP_FILES_TIPO_TRASLADOAUX_ID = 3;
        public const long _EXP_FILES_TIPO_RECEPCIONCOMPRA_ID = 4;
        public const long _EXP_FILES_TIPO_PEDIDO_ID = 5;
        public const long _EXP_FILES_TIPO_TRASLADODEVO_ID = 6;
        public const long _EXP_FILES_TIPO_PEDIDODEVO_ID = 7;
        public const long _EXP_FILES_TIPO_INVENTARIO_ID = 8;
        public const long _EXP_FILES_TIPO_INV_MAIL_ID = 9;
        public const long _EXP_FILES_TIPO_REC_ELIM_MAIL_ID = 10;
        public const long _EXP_FILES_TIPO_MATRIZPEDIDO_ID = 11;
        public const long _EXP_FILES_TIPO_MATRIZPEDIDOAUX_ID = 12;
        public const long _EXP_FILES_TIPO_FACTURAELECTRONICA_XML_ID = 13;
        public const long _EXP_FILES_TIPO_FACTURAELECTRONICA_PDF_ID = 14;
        public const long _EXP_FILES_TIPO_DEVOLUCIONELECTRONICA_XML_ID = 15;
        public const long _EXP_FILES_TIPO_DEVOLUCIONELECTRONICA_PDF_ID = 16;
        public const long _EXP_FILES_TIPO_ABONOSELECTRONICOS_XML_ID = 17;
        public const long _EXP_FILES_TIPO_ABONOSELECTRONICOS_PDF_ID = 18;

        public const string _EXP_FILES_ESTATUS_AGREGADO = "A";
        public const string _EXP_FILES_ESTATUS_GENERADO = "G";
        public const string _EXP_FILES_ESTADOS_ENVIADO = "E";
        public const string _EXP_FILES_ESTADOS_CANCELADO = "C";
        public const string _EXP_FILES_ESTADOS_ENPROCESO = "P";

        public const long _EXP_FILES_ESTATUS_AGREGADO_ID = 1;
        public const long _EXP_FILES_ESTATUS_GENERADO_ID = 2;
        public const long _EXP_FILES_ESTADOS_ENVIADO_ID = 3;
        public const long _EXP_FILES_ESTADOS_CANCELADO_ID = 4;
        public const long _EXP_FILES_ESTADOS_ENPROCESO_ID = 5;



        public const string Status_Ingresado = "I";
        public const string Status_Completo = "C";
        public const string Status_Bajado = "B";
        public const string Status_EnTablasTemporales = "T";


        public const long Status_Ingresado_id = 1;
        public const long Status_Completo_id = 2;
        public const long Status_Bajado_id = 3;
        public const long Status_EnTablasTemporales_id = 4;


        public const short FileType_RecCompras = 1;
        public const short FileType_Producto = 2;
        public const short FileType_Traslados = 3;
        public const short FileType_ExistenciasGen = 4;
        public const short FileType_MatrizPedidos = 5;
        public const short FileType_RecComprasAux = 6;
        public const short FileType_TrasladosAux = 7;
        public const short FileType_PreciosTemp = 21;
        public const short FileType_TrasladosDevo = 8;
        public const short FileType_PedidosDevo = 9;
        public const short FileType_SolicitudMercancia = 25;


        public const int _PERFIL_SUPERVISOR_ID = 12;
        public const int _PERFIL_SUPERSUPER_ID = 11;


        public const string _MENUID_PRODUCTOS = "21";
        public const string _MENUID_PUNTODEVENTA = "9";
        public const string _MENUID_COMPRA = "16";
        public const string _MENUID_CORTECERRAR = "30";
        public const string _MENUID_CORTEABRIR = "52";
        public const string _MENUID_IMPORTAR = "13";
        public const string _MENUID_EXPORTAR = "14";
        public const string _MENUID_INVENTARIOFISICO = "51";
        public const string _MENUID_NOTACREDITO = "70";
        public const string _MENUID_SURTIRPEDIDO_MOVIL = "195";

        public const long _TIPOPERSONA_PROVEEDOR = 40;
        public const long _TIPOPERSONA_CLIENTE = 50;
        public const long _TIPOPERSONA_VENDEDOR = 22;
        public const long _TIPOPERSONA_ENCARGADOGUIA = 60;
        public const long _TIPOPERSONA_ENCARGADOCORTE = 70;
        public const long _TIPOPERSONA_USUARIO = 20;




        //public static long _IPOSTYPE = (long)IposTypes.FARMAFREE;
        //public const int _ICANTMENUSEXCLUDED = 10;
        public static int[] _MENUS_EXCLUDED = {};// { 27, 6, 7, 11, 31,10,62,63,58,60 };

        public const long _ORIGENFISCAL_INDEFINIDO = 1;
        public const long _ORIGENFISCAL_REMISIONADO = 2;
        public const long _ORIGENFISCAL_FACTURADO = 3;


        public const long _SUBTIPOPAGO_SUCURSALPROVEE = 2;

        public const long _TIPOPAGO_ENTRADA = 1;
        public const long _TIPOPAGO_SALIDA = 2;

        public const long _TIPOPAGOMOVIL_ENTRADA = 5;
        public const long _TIPOPAGOMOVIL_CANCELACION = 6;

        public const long _TIPOPAGO_TEMPENTRADA = 3;
        public const long _TIPOPAGO_TEMPSALIDA = 4;

        public const long _CLIENTEMOSTRADOR = 1;


        public const long _DERECHO_DEVOLUCIONAPROV_CONSULTA = 10;

        public const long _DERECHO_MOSTRARCOSTOS = 10001;
        public const long _DERECHO_EDITARCOSTOREPO = 10007;
        public const long _DERECHO_ABONOSCAMBIARFECHAELABORACION = 10008;
        public const long _DERECHO_RETIROSSUPERVISOR = 10009;
        public const long _DERECHO_RETIROSAPAGOPROVEEDOR = 10010;
        public const long _DERECHO_CAMBIARPRECIO_VENTA = 10002;
        public const long _DERECHO_CAMBIARDESCUENTO_VENTA = 10024;
        public const long _DERECHO_CAMBIARPRECIO_DEVOLUCION = 10011;
        public const long _DERECHO_DEVOLUCIONSINVENTA = 10012;
        public const long _DERECHO_DEVOLUCIONSINCOMPRA = 10013;
        public const long _DERECHO_CAMBIARPRECIOXLISTA_VENTA = 10014;
        public const long _DERECHO_VENTASPENDIENTES_VARIOSDIAS = 10017;

        public const long _DERECHO_VENDERCONCREDITOEXCEDIDO = 10020;


        public const long _DERECHO_CAMBIARTASAIVAENVENTAS = 10021;


        public const long _DERECHO_CAMBIARDEALMACEN = 10022;
        public const long _DERECHO_TRASPASOENTREALMACENES = 10023;

        public const long _DERECHO_CREDITOCOBRANZA = 10025;

        public const long _DERECHO_REMISIONAFACTURA = 10026;
        public const long _DERECHO_FACTURARFUERADEMES = 10027;

        public const long _DERECHO_CONSULTARTRANPORFOLIO = 10029;

        public const long _DERECHO_IMPRIMIRCOTIZACION = 10031;

        public const long _DERECHO_CANCELAR_COTI = 10032;
        public const long _DERECHO_ELIM_DETALLE_COTI = 10033;



        public const long _DERECHO_CAMBIARPRECIO_OTRASENTRADAS = 10057;
        public const long _DERECHO_CAMBIARPRECIO_OTRASSALIDAS = 10058;

        public const long _DERECHO_EDITARPRECIOSNUEVOS = 10059;

        public const long _DERECHO_VERVENTAS_OTROSCORTES = 10060;

        public const long _DERECHO_CANCELAR_VENTA_PROPIA_ERRORSURTIDO = 10034;
        public const long _DERECHO_CANCELAR_VENTA_MOVIL_ERRORSURTIDO = 10035;
        public const long _DERECHO_CANCELAR_VENTA_TODAS_ERRORSURTIDO = 10036;

        public const long _DERECHO_ABRIR_VENTASCERRADAS = 10039;
        public const long _DERECHO_ABRIR_ANALISISPRODUCTO = 10043; 
        public const long _DERECHO_BITACORA_PRODUCTO = 10042;

        public const long _DERECHO_APLICARNC_DIAANTERIOR = 10121;
        public const long _DERECHO_APLICARNC_CUALQUIERDIAANTES = 10122;


        public const long _DERECHO_APLICARCANC_MISMODIA = 10140;
        public const long _DERECHO_APLICARCANC_DIAANTERIOR = 10141;
        public const long _DERECHO_APLICARCANC_CUALQUIERDIAANTES = 10142;
        public const long _DERECHO_APLICARCANC_OTROCORTE = 10143;

        public const long _DERECHO_OPCIONESAVANZADASPAGOVENTAS = 10169;

        public const long _DERECHO_FILTARPORALMACEN = 10180;




        public const long _DERECHO_ABRIR_ESTADISTICOSPROVEEDORCOMPRA = 210;
        public const long _DERECHO_ABRIR_ESTADISTICOSPRODUCTOCOMPRA = 208;
        public const long _DERECHO_ABRIR_ESTADISTICOSCLIENTEVENTA = 209;
        public const long _DERECHO_ABRIR_ESTADISTICOSPRODUCTOVENTA = 207;


        public const long _DERECHO_RETIROCAJA_CONSULTA = 219;
        public const long _DERECHO_RETIROCAJA_REGISTRO = 10046;

        public const long _DERECHO_RETIROCAJA_CAJEROS = 10044;
        public const long _DERECHO_RETIROCAJA_CORTE = 10045;


        public const long _DERECHO_BITACORA_CLIENTES = 10041;
        public const long _DERECHO_NOTASINCIDENCIA = 10159;

        public const long _DERECHO_GASTOCONSULTAR_CAJEROS = 10047;
        public const long _DERECHO_GASTOCONSULTAR_CORTE = 10048;


        public const long _DERECHO_GASTOCANCELAR_ACTUAL = 10049;
        public const long _DERECHO_GASTOCANCELAR_CAJEROS = 10050;
        public const long _DERECHO_GASTOCANCELAR_CORTE = 10051;


        public const long _DERECHO_GASTOEDITAR_ACTUAL = 10052;
        public const long _DERECHO_GASTOEDITAR_CAJEROS = 10053;
        public const long _DERECHO_GASTOEDITAR_CORTE = 10054;

        public const long _DERECHO_GASTOAGREGAR_ACTUAL = 10055;
        public const long _DERECHO_GASTOAGREGAR_OTROCORTE = 10056;


        public const long _DERECHO_VENTASFUTURO_GRABAR = 10061;


        public const long _DERECHO_REIMPRIMIR_REVISION = 10150;


        public const long _DERECHO_FINALIZAR_INVENTARIO = 10062;

        public const long _DERECHO_VER_TOTALES_LISTADOVENTAS = 10063;

        public const long _PONER_RUTA_EMBARQUE_EN_VENTA = 10064;

        public const long _DERECHO_AGREGAR_PROD_ALSURTIR_VENTAFUTURO = 10068;


        public const long _DERECHO_ATAJOCONTROLP_IRANUEVAVENTA = 10069;


        public const long _DERECHO_REVERTIR_ABONO_MISMOCAJERO = 10073;
        public const long _DERECHO_REVERTIR_ABONO_MISMODIA = 10072;
        public const long _DERECHO_REVERTIR_ABONO_OTROCAJERO = 10071;
        public const long _DERECHO_REVERTIR_ABONO_OTRODIA = 10070;
        public const long _DERECHO_EDITAR_CORTE_ACTUAL = 10074;
        public const long _DERECHO_EDITAR_CORTE_PASADO = 10075;


        public const long _DERECHO_AUTORIZAR_REFERENCIA_REPETIDA = 10156;
        public const long _DERECHO_ACTUALIZAR_AUTOM_FECHA = 10157;


        public const long _DERECHO_VEREXISTENCIAS_TODOS = 10078;
        public const long _DERECHO_VEREXISTENCIAS_MATRIZ = 10079;

        public const long _DERECHO_BITACORAEDITAR_MISMODIA = 10080;
        public const long _DERECHO_BITACORAEDITAR_OTRODIA = 10081;
        public const long _DERECHO_BITACORAEDITAR_OTROUSUARIO = 10082;
        public const long _DERECHO_BITACORAELIMINAR_MISMODIA = 10083;
        public const long _DERECHO_BITACORAELIMINAR_OTRODIA = 10084;

        public const long _DERECHO_EDITARPRECIOS_POR_CLIENTE = 10097;
        public const long _DERECHO_PRECIOABAJOMINIMO = 10004;

        public const long _DERECHO_DESCLINEAPERS = 10098;
        public const long _DERECHO_GASTOSADIC_COMPRA = 10099;
        public const long _DERECHO_ASIGNAR_VENDEDOR_EJECUTIVO = 10100;


        public const long _DERECHO_IMPORTAR_COMPRAS = 10101;
        public const long _DERECHO_CONSULTAR_DOCTO_EN_PARALELO = 10104;
        public const long _DERECHO_BORRAR_TODAS_LAS_PROMOCIONES = 10103;


        public const long _DERECHO_VERENLISTA_SALDO_PROVEEDORES = 10105;
        public const long _DERECHO_VERENLISTA_SALDO_CLIENTES = 10106;

        public const long _DERECHO_ORDENARXDESC_VENTA = 10107;

        public const long _DERECHO_REIMPRIMIR_VOUCHER = 11002;
        public const long _DERECHO_RECIBIR_PRODUCTOS_MENOR_CADUCIDADMINIMA = 11003;


        public const long _DERECHO_DEPOSITOAGREGAR = 10109;
        public const long _DERECHO_DEPOSITOAGREGAR_OTROCORTE = 10110;
        public const long _DERECHO_DEPOSITOEDITAR = 10111;
        public const long _DERECHO_DEPOSITOCANCELAR = 10112;
        public const long _DERECHO_DEPOSITOCONSULTAR = 10113;
        public const long _DERECHO_DEPOSITOCONSULTAROTROSCORTES = 10114;

        //FONDEO DE CAJA
        public const long _DERECHO_FONDEOAGREGAR = 10127;
        public const long _DERECHO_FONDEOAGREGAR_OTROCORTE = 10128;
        public const long _DERECHO_FONDEOCANCELAR = 10129;
        public const long _DERECHO_FONDEOCONSULTAR = 10130;
        public const long _DERECHO_FONDEOCONSULTAR_OTROCORTE = 10131;
        public const long _DERECHO_FONDEOEDITAR = 10132;

        public const long _DERECHO_EXENTARIVACLIENTES = 10118;

        public const long _DERECHO_IMPRIMIRDIRECTO_TICKETFACT = 10119;
        public const long _DERECHO_VERCOSTOCAMBIOPRECIO = 10123;
        public const long _DERECHO_CAJA_VER = 232;
        public const long _DERECHO_ENCARGADOCORTE_VER = 366;
        public const long _DERECHO_ENCARGADOGUIA_VER = 271;
        public const long _DERECHO_PERFILES_VER = 61;
        public const long _DERECHO_SUCURSAL_INFO_VER = 88;
        public const long _DERECHO_USUARIO_VER = 23;
        public const long _DERECHO_VENDEDOR_VER = 3;
        public const long _DERECHO_VEHICULO_VER = 370;
        public const long _DERECHO_GRUPOSUCURSAL_VER = 89;
        public const long _DERECHO_GRUPOUSUARIO_VER = 213;
        public const long _DERECHO_LINEA_VER = 19;
        public const long _DERECHO_MONEDA_VER = 82;
        public const long _DERECHO_TASAIVA_VER = 81;
        public const long _DERECHO_UNIDAD_VER = 95;
        public const long _DERECHO_ESTADOPAIS_VER = 94;
        public const long _DERECHO_SUBTIPOCLIENTE_VER = 358;
        public const long _DERECHO_SAT_ADUANA_VER = 307;
        public const long _DERECHO_SAT_PRODUCTOSERVICIO_VER = 305;
        public const long _DERECHO_SAT_USOCFDI_VER = 328;
        public const long _DERECHO_CLIENTE_VER = 2;
        public const long _DERECHO_PRODUCTO_VER = 21;
        public const long _DERECHO_PROVEEDOR_VER = 18;
        public const long _DERECHO_CLERKPAGOSERVICIO_VER = 251;
        public const long _DERECHO_EMIDAPRODUCT_VER = 248;
        public const long _DERECHO_MERCHANTPAGOSERVICIO_VER = 250;
        public const long _DERECHO_TERMINALPAGOSERVICIO_VER = 233;
        public const long _DERECHO_GASTOADICIONAL_VER = 289;
        public const long _DERECHO_ALMACEN_VER = 292;
        public const long _DERECHO_ANAQUEL_VER = 91;
        public const long _DERECHO_BANCO_VER = 83;
        public const long _DERECHO_MOTIVO_CAMFEC_VER = 349;
        public const long _DERECHO_CUENTA_VER = 217;
        public const long _DERECHO_CUENTABANCO_VER = 329;
        public const long _DERECHO_PLAZO_VER = 295;
        public const long _DERECHO_CAMPOREFERENCIAPRECIO_VER = 121;
        public const long _DERECHO_PROMOCION_VER = 97;
        public const long _DERECHO_CLASIFICA_VER = 243;
        public const long _DERECHO_CONTENIDO_VER = 242;
        public const long _DERECHO_REPORTES_VER = 26;
        public const long _DERECHO_RUTAEMBARQUE_VER = 238;
        public const long _DERECHO_MOTIVO_DEVOLUCION_VER = 246;




        public const long _DERECHO_TOTALES_GRID = 10133;

        public const long _DERECHO_REIMPRIMIRTICKET_CONT = 10155;


        public const long _ESTADO_COBRANZA_ENPROCESO = 1;
        public const long _ESTADO_COBRANZA_TERMINADA = 2;
        public const long _ESTADO_COBRANZA_ABONADA = 5;


        public const long _DERECHO_PUNTOVENTA = 9;

        public const long _DERECHO_AGREGARGASTO_OTROCAJERO = 10088;


        public const long _DERECHO_MODIFICAR_ESTADO_BITACORA = 10089;

        public const long _DERECHO_VER_EXIS_SUC_PEDIDO = 10120;

        public const long _DERECHO_CONDONARCOMISION_TARJETA = 11004;

        public const long _DERECHO_AGREGARRETIRO_OTROCAJERO = 10134;

        public const long _DERECHO_CANCELARRETIRO_CORTEACTUAL = 10135;
        public const long _DERECHO_CANCELARRETIRO_OTROCAJERO = 10136;
        public const long _DERECHO_CANCELARRETIRO_CORTENOACTIVO = 10137;
        public const long _DERECHO_AGREGARRETIRO_MISMOCORTE = 10138;
        public const long _DERECHO_AGREGARRETIRO_OTROCORTE = 10139;


        public const long _DERECHO_CUENTAS_PVC = 301;

        public const long _DERECHO_MODIFICARPAGOSERVCONSOLIDADO = 10108;


        public const long _DERECHO_ELIMINARVENTAMOVIL = 10126;
        public const long _DERECHO_ELIMINARCOMPRAMOVIL = 10167;


        public const long _DERECHO_APLICAR_CHEQUES = 10144;
        public const long _DERECHO_DESAPLICAR_CHEQUES = 10145;
        public const long _DERECHO_APLICACION_CAMBIARFECHA = 10146;
        public const long _DERECHO_DEVOLVER_CHEQUE = 10147;

        public const long _DERECHO_IMPRIMIR_COTISINTOPE = 10148;


        public const long _DERECHO_ALERTARCOMPRA_NUEVOSPROD = 10152;


        public const long _DERECHO_MOVIL_HABIMPOPRECIOS = 10153;
        public const long _DERECHO_MOVIL_ABREVIADOIMPOPROD = 10154;

        public const long _DERECHO_CAMBIARVENDEDORCLIENTE = 10158;

        public const long _DERECHO_DEJARSALDOFAVORCLIENTE = 10160;

        public const long _DERECHO_CAMBIARCOSTOREPO_LISTAPREC = 10161;

        public const long _DERECHO_PAGARVENTAPRESURTIDO = 10162;

        public const long _DERECHO_BLOQUEAR_F6 = 10163;

        public const long _DERECHO_MOVIL_PROCESAR_VENTAS_AUT = 10164;
        public const long _DERECHO_MOVIL_PROCESAR_COMPRAS_AUT = 10165;
        public const long _DERECHO_MOVIL_CAMBIAR_PRECIO_COMPRA = 10166;



        public const long _RANGOPROMOCIONXPRODUCTO = 1;
        public const long _RANGOPROMOCIONXLINEA = 2;
        public const long _RANGOPROMOCIONXBODEGAZO = 3;
        public const long _RANGOPROMOCIONGENERAL = 4;

        public const long _TIPOPROMOCIONCOMPRASXLLEVASMAS = 1;
        public const long _TIPOPROMOCIONCOMPRASXCONIMPORTE = 2;
        public const long _TIPOPROMOCIONDESCUENTOPORCENTAJE = 3;
        public const long _TIPOPROMOCIONPORCADAIMPORTELLEVATE = 4;
        public const long _TIPOPROMOCIONDESC_MONTOMIN_LINEA = 5;
        public const long _TIPOPROMOCIONCOMPRASXCONIMPORTEMANTEN = 6;
        public const long _TIPOPROMOCIONBODEGAZO = 7;
        public const long _TIPOPROMOCIONCUPONES = 8;
        public const long _TIPOPROMOCIONCUPONPORCADAMONTODEIMPORTE = 9;


        public const long _ERRORCODE_EXISTENCIAINSUFICIENTE = 1081;

        public const long _ERRORCODE_BITACORA_YAEXISTE = 5001;
        public const long _ERRORCODE_BITACORA_NOPUEDEELIMINARSE = 5002;

        public const int _ERRORCODE_NOHAYREGISTROSCONSOLIDAR = 5008;

        public const int _ERRORCODE_NOPUEDECANCELARSEPORPAGOSTIMBRADOS = 5028;


        public const long _MONEDA_PESOS = 1;


        public const string _TIPOSYNC_WS = "WS";
        public const string _TIPOSYNC_FTP = "FTP";




        // public static int[,] _MENUS_EXCLUDED = new int[2, 10] { { 27, 6, 7, 11, 31,10,62,63,58,60 }, { 27, 6, 7, 11, 14,31,10,13,14,0 } };


        public const string _HOSTS_KIKOLERIA = "kikoleria.servebeer.com";
        public const string _HOSTS_VOCERO = "vocero.vinosgiralda.com";




        public const long _TIPO_CORTENORMAL = 1;
        public const long _TIPO_CORTEABIERTO = 2;




        public const long _PERSONA_ESTATUSENVIO_SINCRONIZADO = 1;
        public const long _PERSONA_ESTATUSENVIO_CAMBIOFALTAENVIO = 2;
        public const long _PERSONA_ESTATUSENVIO_NUEVOFALTAENVIO = 3;


        public const long _DOCTO_SURTIDOESTADO_SURTIDO = 1;
        public const long _DOCTO_SURTIDOESTADO_PENDIENTE = 2;
        public const long _DOCTO_SURTIDOESTADO_ERROR = 3;
        public const long _DOCTO_SURTIDOESTADO_CXC = 4;
        public const long _DOCTO_SURTIDOESTADO_CXC_OK = 5;
        public const long _DOCTO_SURTIDOESTADO_CXC_RECH = 6;


        public const long _DOCTO_REVISIONFINAL_REVISADO = 1;
        public const long _DOCTO_REVISIONFINAL_PENDIENTE = 2;

        public const long _TIPOMONTOBILLETESID_CORTE = 1;
        public const long _TIPOMONTOBILLETESID_RETIROCAJA = 2;



        public const string _FORMATOFACTELECT_NORMAL = "Normal";
        public const string _FORMATOFACTELECT_FASTREPORT = "FastReport";



        public const long _DERECHO_PAGO_TERMINAL_BANCOMER = 10096;
        public const long _DERECHO_OBVIAR_PAGO_TERMINAL_BANCOMER = 10115;


        public const long _DERECHO_RELACIONAR_PROVEE_CLIENTE = 10116;

        public const long _DERECHO_CAMBIAR_ADESCPES = 10149;


        public const long _ESTADO_GUIA_NOASIGNADO = 0;
        public const long _ESTADO_GUIA_ENVIADA = 1;
        public const long _ESTADO_GUIA_CANCELADA = 2;
        public const long _ESTADO_GUIA_RECIBIDA = 3;
        public const long _ESTADO_GUIA_PARCIALMENTERECIBIDA = 4;


        public const long _TIPOENTREGA_DIRECTA = 1;
        public const long _TIPOENTREGA_PORPAQUETERIA = 2;


        public const long _ESTADO_MENSAJE_BORADOR = 0;
        public const long _ESTADO_MENSAJE_ENVIADO = 1;
        public const long _ESTADO_MENSAJE_RECIBIDO = 2;
        public const long _ESTADO_MENSAJE_LEIDO = 3;


        public const long _TIPO_MENSAJE_ENTRADA = 1;
        public const long _TIPO_MENSAJE_SALIDA = 2;

        public const long _VERSION_PASSWORDS_ENCRIPTADOS = 4383;

        public const long _VERSION_ACTUALIZADOR_IPOS = 5720; // CAMABIAR

        public const long _VERSION_PASSWORDS_ENCRIPTADOS_CON_USUARIO = 4457;
        public const long _VERSION_DE_SYSTEMDATA_NETWORK = 775;

        public const long _VERSION_IMPORTACIONCATALOGOSSAT = 4664;
        public const long _VERSION_IMPORTACIONCATALOGOSSAT_OCT17 = 5013;

        public const long _ERRORCODE_PRODUCTO_NOEXISTE = 1069;

        public const string _VERSION_FACTURACION = "4.0";


        public const string _CLAVEPAIS_DEFAULT_SAT = "MEX";


        public const string _SAT_USO_CFDI_ADQUISICIONMERCANCIAS = "G01";
        public const string _SAT_USO_CFDI_DEVOLUCIONESDESCUENTOS = "G02";
        public const string _SAT_USO_CFDI_GASTOSENGENERAL = "G03";
        public const string _SAT_USO_CFDI_PORDEFINIR = "P01";


        public const string _SAT_CLAVEUNIDAD_PIEZA = "EA";
        public const string _SAT_UNIDAD_PIEZA = "Pieza";



        public const string _SAT_CLAVE_IVA = "002";
        public const string _SAT_CLAVE_IEPS = "003";
        public const string _SAT_CLAVE_ISR = "001";


        public const string _SAT_TIPOFACTOR_TASA = "Tasa";
        public const string _SAT_TIPOFACTOR_CUOTA = "Cuota";


        public const string _SAT_TIPORELACION_NOTACREDITO = "01";
        public const long _DERECHO_ACTIVAR_DESACTIVAR_PROMOCION = 1098;

        public const int _PVCOLOREAR_PRECIOMINIMO_COSTO = 1;

        public const decimal _LIMITE_CANCELACION_33 = 5000.00m;
        public const int _LIMITE_DIASCANCELACION_33 = 3;//ya estara vigente



        public const long _TIPOINCIDENCIA_MAYOR_CANTIDAD = 1;
        public const long _TIPOINCIDENCIA_MENOR_CANTIDAD = 2;
        public const long _TIPOINCIDENCIA_CANCELACION_REVISION = 3;
        public const long _TIPOINCIDENCIA_NOTA_REVISION = 4;
        public const long _TIPOINCIDENCIA_CAMBIO_DIRECTO = 5;


        public const long _TIPOEVENTOTABLA_NOTA = 1;
        public const long _TIPOEVENTOTABLA_BLOQUEO = 2;
        public const long _TIPOEVENTOTABLA_DESBLOQUEO = 3;

        public const long _CONTRARECIBO_ESTATUSPAGO_SINPAGAR = 3;

    }
}
