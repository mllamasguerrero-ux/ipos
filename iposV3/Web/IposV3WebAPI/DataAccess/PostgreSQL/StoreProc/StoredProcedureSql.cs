using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.DataAccess.PostgreSQL
{
    public class StoredProcedureSql
    {

        public static string View_Cfdi_master()
        {
            return $@"CREATE OR REPLACE VIEW public.cfdi_master (
    empresaid,
    sucursalid,
    id,
    doctoid,
    serie,
    folio,
    fecha,
    tipocomprobante,
    formapago,
    subtotal,
    descuento,
    total,
    moneda,
    tipocambio,
    condicionespago,
    metodopago,
    motivodescuento,
    lugarexpedicion,
    ex_lugarexpedicion,
    ex_numeroctapago,
    ex_seriefoliofiscaloriginal,
    ex_foliofiscaloriginal,
    ex_montofoliofiscaloriginal,
    ex_fechafoliofiscaloriginal,
    em_rfc,
    em_razonsocial,
    em_regimenfiscal,
    em_calle,
    em_noexterior,
    em_nointerior,
    em_colonia,
    em_localidad,
    em_referencia,
    em_municipio,
    em_estado,
    em_pais,
    em_codigopostal,
    ee_calle,
    ee_noexterior,
    ee_nointerior,
    ee_colonia,
    ee_localidad,
    ee_referencia,
    ee_municipio,
    ee_estado,
    ee_pais,
    ee_codigopostal,
    rc_rfc,
    rc_razonsocial,
    rc_residenciafiscal,
    rc_nombre,
    rc_numregidtrib,
    rc_usocfdi,
    rc_calle,
    rc_noexterior,
    rc_nointerior,
    rc_colonia,
    rc_localidad,
    rc_referencia,
    rc_municipio,
    rc_estado,
    rc_pais,
    rc_codigoopostal,
    totaltraslados,
    totalretenciones,
    rc_regimenfiscal,
    exportacion,
    periodicidad,
    meses,
    anio,
    rc_domiciliofiscal,
    timbradouuid,
    timbradofecha,
    timbradocertsat,
    timbradosellosat,
    timbradosellocfdi,
    timbradocancelado,
    timbradouuidcancelacion,
    timbradoformapagosat,
    esfacturaelectronica,
    timbradofechacancelacion,
    timbradofechafactura,
    fechafactura,
    foliosat,
    seriesat,
    sat_usocfdiid,
    sat_usocfdiclave,
    sat_usocfdidescripcion,
    ivaretenido,
    isrretenido,
    num_serie_cert_csd,
    doctofolio,
    doctoserie,
    saldo,
    clienteclave,
    vendedorclienteclave,
    vendedorclientenombre,
    entregadireccion,
    entregacolonia,
    entregamunicipio,
    entregacodigopostal,
    entregapais,
    entregarfc,
    cuentapago,
    formapagonombre,
    usocfdiclave,
    usocfdidescripcion,
    notapago,
    ordencompra,
    textofooter,
    cadenaoriginalsat,
    rutaembarqueclave,
    fiscalnombre,
    tipodocumento,
    foliopadre,
    clientedesglosaieps,
    empresadesglosaieps,
    hidepagare,
    hiderecibohonorarios,
    hidedescuento,
    hideivaretenido,
    hideisrretenido,
    hidepzacaja,
    hideiepsdetalle,
    doctoiva,
    tipodoctoid,
    regimenfiscaldescripcion,
    metodopagodescripcion,
    tipocomprobantedescripcion,
    versioncfdi,
    rc_regimenfiscaldescripcion,
    entregaestado,
    referenciatraslado,
    leyendaplazo)
AS
SELECT cfdi.""EmpresaId"" AS empresaid,
    cfdi.""SucursalId"" AS sucursalid,
    cfdi.""Id"" AS id,
    cfdi.""Doctoid"" AS doctoid,
    cfdi.""Serie"" AS serie,
    cfdi.""Folio"" AS folio,
    cfdi.""Fecha"" AS fecha,
    cfdi.""Tipocomprobante"" AS tipocomprobante,
    COALESCE(cfdi.""Formapago"", '99'::character varying) AS formapago,
    cfdi.""Subtotal"" AS subtotal,
    cfdi.""Descuento"" AS descuento,
    cfdi.""Total"" AS total,
    cfdi.""Moneda"" AS moneda,
    cfdi.""Tipocambio"" AS tipocambio,
    cfdi.""Condicionespago"" AS condicionespago,
    cfdi.""Metodopago"" AS metodopago,
    cfdi.""Motivodescuento"" AS motivodescuento,
    cfdi.""Lugarexpedicion"" AS lugarexpedicion,
    cfdi.""Ex_lugarexpedicion"" AS ex_lugarexpedicion,
    cfdi.""Ex_numeroctapago"" AS ex_numeroctapago,
    cfdi.""Ex_seriefoliofiscaloriginal"" AS ex_seriefoliofiscaloriginal,
    cfdi.""Ex_foliofiscaloriginal"" AS ex_foliofiscaloriginal,
    cfdi.""Ex_montofoliofiscaloriginal"" AS ex_montofoliofiscaloriginal,
    cfdi.""Ex_fechafoliofiscaloriginal"" AS ex_fechafoliofiscaloriginal,
    cfdi.""Em_rfc"" AS em_rfc,
    cfdi.""Em_razonsocial"" AS em_razonsocial,
    cfdi.""Em_regimenfiscal"" AS em_regimenfiscal,
    cfdi.""Em_calle"" AS em_calle,
    cfdi.""Em_noexterior"" AS em_noexterior,
    cfdi.""Em_nointerior"" AS em_nointerior,
    cfdi.""Em_colonia"" AS em_colonia,
    cfdi.""Em_localidad"" AS em_localidad,
    cfdi.""Em_referencia"" AS em_referencia,
    cfdi.""Em_municipio"" AS em_municipio,
    cfdi.""Em_estado"" AS em_estado,
    cfdi.""Em_pais"" AS em_pais,
    cfdi.""Em_codigopostal"" AS em_codigopostal,
    cfdi.""Ee_calle"" AS ee_calle,
    cfdi.""Ee_noexterior"" AS ee_noexterior,
    cfdi.""Ee_nointerior"" AS ee_nointerior,
    cfdi.""Ee_colonia"" AS ee_colonia,
    cfdi.""Ee_localidad"" AS ee_localidad,
    cfdi.""Ee_referencia"" AS ee_referencia,
    cfdi.""Ee_municipio"" AS ee_municipio,
    cfdi.""Ee_estado"" AS ee_estado,
    cfdi.""Ee_pais"" AS ee_pais,
    cfdi.""Ee_codigopostal"" AS ee_codigopostal,
    cfdi.""Rc_rfc"" AS rc_rfc,
    cfdi.""Rc_razonsocial"" AS rc_razonsocial,
    cfdi.""Rc_residenciafiscal"" AS rc_residenciafiscal,
    cfdi.""Rc_nombre"" AS rc_nombre,
    cfdi.""Rc_numregidtrib"" AS rc_numregidtrib,
    cfdi.""Rc_usocfdi"" AS rc_usocfdi,
    cfdi.""Rc_calle"" AS rc_calle,
    cfdi.""Rc_noexterior"" AS rc_noexterior,
    cfdi.""Rc_nointerior"" AS rc_nointerior,
    cfdi.""Rc_colonia"" AS rc_colonia,
    cfdi.""Rc_localidad"" AS rc_localidad,
    cfdi.""Rc_referencia"" AS rc_referencia,
    cfdi.""Rc_municipio"" AS rc_municipio,
    cfdi.""Rc_estado"" AS rc_estado,
    cfdi.""Rc_pais"" AS rc_pais,
    cfdi.""Rc_codigopostal"" AS rc_codigoopostal,
    cfdi.""Totaltraslados"" AS totaltraslados,
    cfdi.""Totalretenciones"" AS totalretenciones,
    cfdi.""Rc_Regimenfiscal"" AS rc_regimenfiscal,
    cfdi.""Exportacion"" AS exportacion,
    cfdi.""Periodicidad"" AS periodicidad,
    cfdi.""Meses"" AS meses,
    cfdi.""Anio"" AS anio,
    cfdi.""Rc_Domiciliofiscal"" AS rc_domiciliofiscal,
    dfe.""Timbradouuid"" AS timbradouuid,
    dfe.""Timbradofecha"" AS timbradofecha,
    dfe.""Timbradocertsat"" AS timbradocertsat,
    dfe.""Timbradosellosat"" AS timbradosellosat,
    dfe.""Timbradosellocfdi"" AS timbradosellocfdi,
    dfe.""Timbradocancelado"" AS timbradocancelado,
    dfe.""Timbradouuidcancelacion"" AS timbradouuidcancelacion,
    dfe.""Timbradoformapagosat"" AS timbradoformapagosat,
    dfe.""Esfacturaelectronica"" AS esfacturaelectronica,
    dfe.""Timbradofechacancelacion"" AS timbradofechacancelacion,
    dfe.""Timbradofechafactura"" AS timbradofechafactura,
    dfe.""Fechafactura"" AS fechafactura,
    dfe.""Foliosat"" AS foliosat,
    dfe.""Seriesat"" AS seriesat,
    dfe.""Sat_usocfdiid"" AS sat_usocfdiid,
    sat_usocfdi.""Sat_clave"" AS sat_usocfdiclave,
    sat_usocfdi.""Sat_descripcion"" AS sat_usocfdidescripcion,
    dfe.""Ivaretenido"" AS ivaretenido,
    dfe.""Isrretenido"" AS isrretenido,
        CASE
            WHEN COALESCE(parametro.""Timbradoarchivocertificado"", ''::character
                varying)::text <> ''::text AND length(COALESCE(parametro.""Timbradoarchivocertificado"", ''::character varying)::text) > 4 THEN ""substring""(COALESCE(parametro.""Timbradoarchivocertificado"", ''::character varying)::text, 1, length(COALESCE(parametro.""Timbradoarchivocertificado"", ''::character varying)::text) - 4)
            ELSE ''::text
        END AS num_serie_cert_csd,
    docto.""Folio"" AS doctofolio,
    docto.""Serie"" AS doctoserie,
    docto.""Saldo"" AS saldo,
    cliente.""Clave"" AS clienteclave,
    clientevendedor.""UsuarioNombre"" AS vendedorclienteclave,
    clientevendedor.""Nombre"" AS vendedorclientenombre,
        CASE
            WHEN COALESCE(dt.""Sucursaltid"", docto.""Sucursal_id"") <>
                docto.""Sucursal_id"" THEN ((sucursal_fe_t.""Entregacalle""::text || ' Ext. '::text) || sucursal_fe_t.""Entreganumeroexterior""::text) ||
            CASE
                WHEN COALESCE(sucursal_fe_t.""Entreganumerointerior"",
                    ''::character varying)::text <> ''::text THEN ' , Int. '::text || sucursal_fe_t.""Entreganumerointerior""::text
                ELSE ''::text
            END
            WHEN COALESCE(dfe.""Usardatosentrega"", 'S'::bpchar) <> 'S'::bpchar
                OR COALESCE(cliente_domicilio_entrega.""Calle"", ''::character varying)::text = ''::text THEN ((cliente_domicilio.""Calle""::text || ' Ext. '::text) || cliente_domicilio.""Numeroexterior""::text) ||
            CASE
                WHEN COALESCE(cliente_domicilio.""Numerointerior"", ''::character
                    varying)::text <> ''::text THEN ' , Int. '::text || cliente_domicilio.""Numerointerior""::text
                ELSE ''::text
            END
            ELSE ((cliente_domicilio_entrega.""Calle""::text || ' Ext. '::text)
                || cliente_domicilio_entrega.""Numeroexterior""::text) ||
            CASE
                WHEN COALESCE(cliente_domicilio_entrega.""Numerointerior"",
                    ''::character varying)::text <> ''::text THEN ' , Int. '::text || cliente_domicilio_entrega.""Numerointerior""::text
                ELSE ''::text
            END
        END AS entregadireccion,
        CASE
            WHEN COALESCE(dt.""Sucursaltid"", docto.""Sucursal_id"") <>
                docto.""Sucursal_id"" THEN sucursal_fe_t.""Entregacolonia""
            WHEN COALESCE(dfe.""Usardatosentrega"", 'S'::bpchar) <> 'S'::bpchar
                OR COALESCE(cliente_domicilio_entrega.""Calle"", ''::character varying)::text = ''::text THEN cliente_domicilio.""Colonia""
            ELSE cliente_domicilio_entrega.""Colonia""
        END AS entregacolonia,
        CASE
            WHEN COALESCE(dt.""Sucursaltid"", docto.""Sucursal_id"") <>
                docto.""Sucursal_id"" THEN sucursal_fe_t.""Entregamunicipio""
            WHEN COALESCE(dfe.""Usardatosentrega"", 'S'::bpchar) <> 'S'::bpchar
                OR COALESCE(cliente_domicilio_entrega.""Calle"", ''::character varying)::text = ''::text THEN cliente_domicilio.""Municipio""
            ELSE cliente_domicilio_entrega.""Municipio""
        END AS entregamunicipio,
        CASE
            WHEN COALESCE(dt.""Sucursaltid"", docto.""Sucursal_id"") <>
                docto.""Sucursal_id"" THEN sucursal_fe_t.""Entregacodigopostal""
            WHEN COALESCE(dfe.""Usardatosentrega"", 'S'::bpchar) <> 'S'::bpchar
                OR COALESCE(cliente_domicilio_entrega.""Calle"", ''::character varying)::text = ''::text THEN cliente_domicilio.""Codigopostal""
            ELSE cliente_domicilio_entrega.""Codigopostal""
        END AS entregacodigopostal,
        CASE
            WHEN COALESCE(dt.""Sucursaltid"", docto.""Sucursal_id"") <>
                docto.""Sucursal_id"" THEN 'México'::character varying
            WHEN COALESCE(dfe.""Usardatosentrega"", 'S'::bpchar) <> 'S'::bpchar
                OR COALESCE(cliente_domicilio_entrega.""Calle"", ''::character varying)::text = ''::text THEN COALESCE(cliente_domicilio.""Pais"", 'México'::character varying)
            ELSE COALESCE(cliente_domicilio_entrega.""Pais"", 'México'::character varying)
        END AS entregapais,
    ''::text AS entregarfc,
        CASE
            WHEN docto.""Tipodoctoid"" = 205 AND
                COALESCE(pago.""Cuentapagocredito"", ''::character varying)::text <> ''::text THEN pago.""Cuentapagocredito""
            WHEN (pago.""Formapagoid"" = ANY (ARRAY[2::bigint, 3::bigint,
                15::bigint])) AND COALESCE(pago.""Referenciabancaria"", ''::character varying)::text <> ''::text THEN pago.""Referenciabancaria""
            WHEN pago.""Formapagoid"" = 4 AND
                COALESCE(cliente_pago_parametros.""Creditoreferenciaabonos"", ''::character varying)::text <> ''::text THEN cliente_pago_parametros.""Creditoreferenciaabonos""
            ELSE 'N / A'::character varying
        END AS cuentapago,
    COALESCE(formapagosat.""Nombre"", 'POR DEFINIR'::character varying) AS
        formapagonombre,
    sat_usocfdi.""Sat_clave"" AS usocfdiclave,
    sat_usocfdi.""Sat_descripcion"" AS usocfdidescripcion,
        CASE
            WHEN COALESCE(docto_info_pago.""Notapago"", ''::character
                varying)::text = ''::text THEN ''::text
            ELSE 'Nota : '::text || docto_info_pago.""Notapago""::text
        END AS notapago,
        CASE
            WHEN COALESCE(docto_orden_compra.""Ordencompra"", ''::character
                varying)::text = ''::text THEN ''::text
            ELSE 'Orden de compra : '::text || docto_orden_compra.""Ordencompra""::text
        END AS ordencompra,
        CASE
            WHEN COALESCE(parametro.""Footer"", ''::character varying)::text =
                ''::text THEN ''::text
            ELSE replace(parametro.""Footer""::text, '[nombreVendedor]'::text,
                clientevendedor.""Nombre""::text)
        END AS textofooter,
    ((((((('||1.0|'::text || COALESCE(dfe.""Timbradouuid"", ''::character
        varying)::text) || '|'::text) || COALESCE(dfe.""Timbradofecha"", ''::character varying)::text) || '|'::text) || COALESCE(dfe.""Timbradosellocfdi"", ''::character varying)::text) || '|'::text) || COALESCE(dfe.""Timbradocertsat"", ''::character varying)::text) || '||'::text AS cadenaoriginalsat,
    re.""Clave"" AS rutaembarqueclave,
    parametro.""Fiscalnombre"" AS fiscalnombre,
        CASE
            WHEN docto.""Tipodoctoid"" = 22 OR docto.""Tipodoctoid"" = 702 THEN
                'DEVOLUCION'::text
            WHEN docto.""Tipodoctoid"" = 205 THEN 'COMPROBANTE DE ABONO'::text
            ELSE 'FACTURA'::text
        END AS tipodocumento,
        CASE
            WHEN docto.""Tipodoctoid"" = 22 AND
                COALESCE(docto_devolucion.""Doctorefid"", 0::bigint) > 0 AND COALESCE(doctodevo.""Folio"", 0) <> 0 AND COALESCE(dfe_devo.""Foliosat"", 0) <> 0 AND COALESCE(dfe_devo.""Seriesat"", ''::character varying)::text <> ''::text THEN ((('Devolucion de venta : '::text || doctodevo.""Folio""::character varying(20)::text) || ' Folio Sat : '::text) || dfe_devo.""Foliosat""::character varying(20)::text) || COALESCE(dfe_devo.""Seriesat"", ''::character varying)::text
            WHEN docto.""Tipodoctoid"" = 31 AND
                COALESCE(docto_devolucion.""Doctorefid"", 0::bigint) > 0 AND COALESCE(doctodevo.""Folio"", 0) <> 0 THEN ('Traspaso con venta: : '::text || doctodevo.""Folio""::character varying(20)::text) ||
            CASE
                WHEN COALESCE(dfe_devo.""Foliosat"", 0) <> 0 AND
                    COALESCE(dfe_devo.""Seriesat"", ''::character varying)::text <> ''::text THEN (' Folio Sat : '::text || dfe_devo.""Foliosat""::character varying(20)::text) || COALESCE(dfe_devo.""Seriesat"", ''::character varying)::text
                ELSE ''::text
            END
            WHEN docto.""Tipodoctoid"" = 205 AND
                COALESCE(docto_devolucion.""Doctorefid"", 0::bigint) > 0 AND COALESCE(doctodevo.""Folio"", 0) <> 0 THEN 'Comprobante de abono de venta: : '::text || doctodevo.""Folio""::character varying(20)::text
            ELSE ''::text
        END AS foliopadre,
        CASE
            WHEN COALESCE(cliente_fact_elect.""Desglosaieps"", 'N'::bpchar) =
                'S'::bpchar OR docto.""Tipodoctoid"" = 701 THEN 'True'::text
            ELSE 'False'::text
        END AS clientedesglosaieps,
        CASE
            WHEN COALESCE(parametro.""Desgloseieps"", 'N'::bpchar) = 'S'::bpchar
                THEN 'True'::text
            ELSE 'False'::text
        END AS empresadesglosaieps,
        CASE
            WHEN cfdi.""Formapago""::text = '99'::text OR docto.""Tipodoctoid"" =
                205 THEN 'True'::text
            ELSE 'False'::text
        END AS hidepagare,
        CASE
            WHEN COALESCE(cliente_fact_elect.""Retieneisr"", 'N'::bpchar) =
                'S'::bpchar OR COALESCE(cliente_fact_elect.""Retieneiva"", 'N'::bpchar) = 'S'::bpchar THEN 'False'::text
            ELSE 'True'::text
        END AS hiderecibohonorarios,
        CASE
            WHEN COALESCE(parametro.""Mostrardescuentofactura"", 'N'::bpchar) =
                'S'::bpchar THEN 'False'::text
            ELSE 'True'::text
        END AS hidedescuento,
        CASE
            WHEN COALESCE(cliente_fact_elect.""Retieneiva"", 'N'::bpchar) =
                'S'::bpchar THEN 'False'::text
            ELSE 'True'::text
        END AS hideivaretenido,
        CASE
            WHEN COALESCE(cliente_fact_elect.""Retieneisr"", 'N'::bpchar) =
                'S'::bpchar THEN 'False'::text
            ELSE 'True'::text
        END AS hideisrretenido,
        CASE
            WHEN COALESCE(parametro.""Mostrarpzacajaenfactura"", 'N'::bpchar) =
                'S'::bpchar THEN 'False'::text
            ELSE 'True'::text
        END AS hidepzacaja,
        CASE
            WHEN COALESCE(parametro.""Desgloseieps"", 'N'::bpchar) = 'S'::bpchar
                THEN 'False'::text
            ELSE 'True'::text
        END AS hideiepsdetalle,
    docto.""Iva"" AS doctoiva,
    docto.""Tipodoctoid"" AS tipodoctoid,
    sat_regimenfiscal_em.""Sat_description"" AS regimenfiscaldescripcion,
    sat_metodopago.""Sat_description"" AS metodopagodescripcion,
    sat_tipocomprobante.""Sat_descripcion"" AS tipocomprobantedescripcion,
    parametro.""Versioncfdi"" AS versioncfdi,
    sat_regimenfiscal_rc.""Sat_description"" AS rc_regimenfiscaldescripcion,
        CASE
            WHEN COALESCE(dt.""Sucursaltid"", docto.""Sucursal_id"") <>
                docto.""Sucursal_id"" THEN estado_suc_fe_t.""Nombre""
            WHEN COALESCE(dfe.""Usardatosentrega"", 'S'::bpchar) <> 'S'::bpchar
                OR COALESCE(cliente_domicilio_entrega.""Calle"", ''::character varying)::text = ''::text THEN cliente_domicilio.""Estado""
            ELSE cliente_domicilio_entrega.""Estado""
        END AS entregaestado,
        CASE
            WHEN COALESCE(dt.""Estraslado"", ''::bpchar) = 'S'::bpchar THEN
                docto.""Folio""::text
            ELSE ''::text
        END AS referenciatraslado,
        CASE
            WHEN COALESCE(plazo.""Comisionista"", 'N'::bpchar) = 'S'::bpchar THEN
                COALESCE(plazo.""Leyenda"", ''::character varying)
            ELSE ''::character varying
        END AS leyendaplazo
FROM ""Cfdi"" cfdi
     LEFT JOIN ""Docto"" docto ON docto.""EmpresaId"" = cfdi.""EmpresaId"" AND
         docto.""SucursalId"" = cfdi.""SucursalId"" AND docto.""Id"" = cfdi.""Doctoid""
     LEFT JOIN ""Parametro"" parametro ON parametro.""EmpresaId"" =
         docto.""EmpresaId"" AND parametro.""SucursalId"" = docto.""SucursalId""
     LEFT JOIN ""Sat_usocfdi"" sat_usocfdi ON sat_usocfdi.""Sat_clave""::text =
         cfdi.""Rc_usocfdi""::text
     LEFT JOIN ""Formapagosat"" formapagosat ON formapagosat.""Clave""::text =
         cfdi.""Formapago""::text
     LEFT JOIN ""Sat_regimenfiscal"" sat_regimenfiscal_em ON
         sat_regimenfiscal_em.""Sat_clave""::text = cfdi.""Em_regimenfiscal""::text
     LEFT JOIN ""Sat_regimenfiscal"" sat_regimenfiscal_rc ON
         sat_regimenfiscal_rc.""Sat_clave""::text = cfdi.""Rc_Regimenfiscal""::text
     LEFT JOIN ""Sat_metodopago"" sat_metodopago ON
         sat_metodopago.""Sat_clave""::text = cfdi.""Metodopago""::text
     LEFT JOIN ""Sat_tipocomprobante"" sat_tipocomprobante ON
         sat_tipocomprobante.""Sat_clave""::text = cfdi.""Tipocomprobante""::text
     LEFT JOIN ""Docto_fact_elect"" dfe ON dfe.""EmpresaId"" = docto.""EmpresaId""
         AND dfe.""SucursalId"" = docto.""SucursalId"" AND dfe.""Doctoid"" = docto.""Id""
     LEFT JOIN ""Docto_fact_elect_pagos"" dfep ON dfep.""EmpresaId"" =
         docto.""EmpresaId"" AND dfep.""SucursalId"" = docto.""SucursalId"" AND dfep.""Doctoid"" = docto.""Id""
     LEFT JOIN ""Docto_poliza"" docto_poliza ON docto_poliza.""EmpresaId"" =
         docto.""EmpresaId"" AND docto_poliza.""SucursalId"" = docto.""SucursalId"" AND docto_poliza.""Doctoid"" = docto.""Id""
     LEFT JOIN ""Plazo"" plazo ON plazo.""EmpresaId"" = docto.""EmpresaId"" AND
         plazo.""SucursalId"" = docto.""SucursalId"" AND plazo.""Id"" = docto_poliza.""Plazoid""
     LEFT JOIN ""Docto_info_pago"" docto_info_pago ON docto_info_pago.""EmpresaId""
         = docto.""EmpresaId"" AND docto_info_pago.""SucursalId"" = docto.""SucursalId"" AND docto_info_pago.""Doctoid"" = docto.""Id""
     LEFT JOIN ""Docto_ordencompra"" docto_orden_compra ON
         docto_orden_compra.""EmpresaId"" = docto.""EmpresaId"" AND docto_orden_compra.""SucursalId"" = docto.""SucursalId"" AND docto_orden_compra.""Doctoid"" = docto.""Id""
     LEFT JOIN ""Pagosat"" pagosat ON pagosat.""EmpresaId"" = docto.""EmpresaId"" AND
         pagosat.""SucursalId"" = docto.""SucursalId"" AND pagosat.""Id"" = dfep.""Pagosat""
     LEFT JOIN ""Pagodoctosat"" pagodoctosat ON pagodoctosat.""EmpresaId"" =
         docto.""EmpresaId"" AND pagodoctosat.""SucursalId"" = docto.""SucursalId"" AND pagodoctosat.""Id"" = dfep.""Doctopagosat""
     LEFT JOIN ""Doctopago"" doctopago ON doctopago.""EmpresaId"" =
         docto.""EmpresaId"" AND doctopago.""SucursalId"" = docto.""SucursalId"" AND dfep.""Doctopagosat"" = doctopago.""Id""
     LEFT JOIN ""Pago"" pago ON pago.""EmpresaId"" = docto.""EmpresaId"" AND
         pago.""SucursalId"" = docto.""SucursalId"" AND doctopago.""Pagoid"" = pago.""Id""
     LEFT JOIN ""Cliente"" cliente ON cliente.""EmpresaId"" = docto.""EmpresaId"" AND
         cliente.""SucursalId"" = docto.""SucursalId"" AND cliente.""Id"" = docto.""Clienteid""
     LEFT JOIN ""Cliente_comision"" clientecomision ON
         clientecomision.""EmpresaId"" = docto.""EmpresaId"" AND cliente.""SucursalId"" = docto.""SucursalId"" AND clientecomision.""Clienteid"" = cliente.""Id""
     LEFT JOIN ""Usuario"" clientevendedor ON clientevendedor.""EmpresaId"" =
         docto.""EmpresaId"" AND clientevendedor.""SucursalId"" = docto.""SucursalId"" AND clientevendedor.""Id"" = clientecomision.""Vendedorid""
     LEFT JOIN ""Cliente_fact_elect"" cliente_fact_elect ON
         cliente_fact_elect.""EmpresaId"" = docto.""EmpresaId"" AND cliente_fact_elect.""SucursalId"" = docto.""SucursalId"" AND cliente_fact_elect.""Clienteid"" = cliente.""Id""
     LEFT JOIN ""Cliente_pago_parametros"" cliente_pago_parametros ON
         cliente_pago_parametros.""EmpresaId"" = docto.""EmpresaId"" AND cliente_pago_parametros.""SucursalId"" = docto.""SucursalId"" AND cliente_pago_parametros.""Clienteid"" = cliente.""Id""
     LEFT JOIN ""Domicilio"" cliente_domicilio ON cliente_domicilio.""EmpresaId"" =
         docto.""EmpresaId"" AND cliente_domicilio.""SucursalId"" = docto.""SucursalId"" AND cliente_domicilio.""Id"" = cliente.""Domicilioid""
     LEFT JOIN ""Domicilio"" cliente_domicilio_entrega ON
         cliente_domicilio_entrega.""EmpresaId"" = docto.""EmpresaId"" AND cliente_domicilio_entrega.""SucursalId"" = docto.""SucursalId"" AND cliente_domicilio_entrega.""Id"" = cliente.""Domicilioentregaid""
     LEFT JOIN ""Docto_traslado"" dt ON dt.""EmpresaId"" = docto.""EmpresaId"" AND
         dt.""SucursalId"" = docto.""SucursalId"" AND dt.""Doctoid"" = docto.""Id""
     LEFT JOIN ""Sucursal_info"" sucursaltraslado ON sucursaltraslado.""EmpresaId""
         = docto.""EmpresaId"" AND sucursaltraslado.""SucursalId"" = docto.""SucursalId"" AND sucursaltraslado.""Id"" = dt.""Sucursaltid""
     LEFT JOIN ""Sucursal_info_opciones"" sucursal_op_t ON
         sucursal_op_t.""EmpresaId"" = docto.""EmpresaId"" AND sucursal_op_t.""SucursalId"" = docto.""SucursalId"" AND sucursal_op_t.""Id"" = sucursaltraslado.""Id""
     LEFT JOIN ""Sucursal_fact_elect"" sucursal_fe_t ON sucursal_fe_t.""EmpresaId""
         = docto.""EmpresaId"" AND sucursal_fe_t.""SucursalId"" = docto.""SucursalId"" AND sucursal_fe_t.""Sucursal_info_opciones_id"" = sucursal_op_t.""Id""
     LEFT JOIN ""Estadopais"" estado_suc_fe_t ON estado_suc_fe_t.""Id"" =
         sucursal_fe_t.""Entregaestadoid""
     LEFT JOIN ""Tipodocto"" td ON td.""Id"" = docto.""Tipodoctoid""
     LEFT JOIN ""Docto_rutaembarque"" drb ON drb.""EmpresaId"" = docto.""EmpresaId""
         AND drb.""SucursalId"" = docto.""SucursalId"" AND drb.""Doctoid"" = docto.""Id""
     LEFT JOIN ""Rutaembarque"" re ON re.""EmpresaId"" = docto.""EmpresaId"" AND
         re.""SucursalId"" = docto.""SucursalId"" AND re.""Id"" = drb.""Rutaembarqueid""
     LEFT JOIN ""Docto_devolucion"" docto_devolucion ON
         docto_devolucion.""EmpresaId"" = docto.""EmpresaId"" AND docto_devolucion.""SucursalId"" = docto.""SucursalId"" AND docto.""Id"" = docto_devolucion.""Doctoid""
     LEFT JOIN ""Docto"" doctodevo ON doctodevo.""EmpresaId"" = docto.""EmpresaId""
         AND doctodevo.""SucursalId"" = docto.""SucursalId"" AND docto_devolucion.""Doctorefid"" = doctodevo.""Id""
     LEFT JOIN ""Docto_fact_elect"" dfe_devo ON dfe_devo.""EmpresaId"" =
         docto.""EmpresaId"" AND dfe_devo.""SucursalId"" = docto.""SucursalId"" AND dfe_devo.""Doctoid"" = doctodevo.""Id"";
";
        }


        public static string View_recibo_cupones()
        {
            return $@"CREATE OR REPLACE VIEW public.recibo_cupones (
    empresaid,
    sucursalid,
    doctoid,
    promocioncuponid,
    cantidad,
    promocionclave,
    promocionnombre,
    leyenda,
    imagen,
    mostrardatoscliente)
AS
SELECT ca.""EmpresaId"" AS empresaid,
    ca.""SucursalId"" AS sucursalid,
    ca.""Doctoid"" AS doctoid,
    ca.""Promocioncuponid"" AS promocioncuponid,
    ca.""Cantidad"" AS cantidad,
    pr.""Clave"" AS promocionclave,
    pr.""Nombre"" AS promocionnombre,
    pr.""Descripcion"" AS leyenda,
        CASE
            WHEN COALESCE(pr.""Imagen"", ''::text) = ''::text OR
                COALESCE(parametro.""Rutaimagenesproducto"", ''::character varying)::text = ''::text THEN ''::text
            ELSE (COALESCE(parametro.""Rutaimagenesproducto"", ''::character
                varying)::text || '\'::text) || COALESCE(pr.""Imagen"", ''::text)
        END AS imagen,
    pr.""Mostrardatoscliente"" AS mostrardatoscliente
FROM ""Docto"" d
     JOIN ""Cuponesaplicados"" ca ON ca.""EmpresaId"" = d.""EmpresaId"" AND
         ca.""SucursalId"" = d.""SucursalId"" AND ca.""Doctoid"" = d.""Id""
     LEFT JOIN ""Promocion"" pr ON pr.""EmpresaId"" = d.""EmpresaId"" AND
         pr.""SucursalId"" = d.""SucursalId"" AND ca.""Promocioncuponid"" = pr.""Id""
     LEFT JOIN ""Parametro"" parametro ON parametro.""EmpresaId"" = d.""EmpresaId""
         AND parametro.""SucursalId"" = d.""SucursalId"";
";
        }

        public static string View_recibo_detail()
        {
            return $@"CREATE OR REPLACE VIEW public.recibo_detail (
    empresaid,
    sucursalid,
    doctoid,
    movtoid,
    productoid,
    orden,
    partida,
    tipodoctoid,
    manejalote,
    lote,
    fechavence,
    precio,
    tasaiva,
    tasaieps,
    tasaimpuesto,
    preciolista,
    preciovisibletraslado,
    cantidad,
    cantidadsurtida,
    cantidadfaltante,
    cantidaddevuelta,
    cantidadsaldo,
    iva,
    ieps,
    impuesto,
    importe,
    subtotal,
    total,
    totalconrebaja,
    montorebaja,
    ivaretenido,
    isrretenido,
    descuento,
    descuentovale,
    costoimporte,
    descuentoporcentaje,
    productoclave,
    ean,
    pzacaja,
    unidadclave,
    unidadnombre,
    kilogramos,
    descpzacaja,
    cajas,
    piezas,
    descripcion_comodin,
    descripcion1,
    descripcion2,
    descripcion3,
    lineaid,
    lineaclave,
    lineanombre,
    ""TIPORECARGA"",
    precioconimpuesto,
    precioconieps,
    preciomaximopublico,
    precioconimpuestosindescuento,
    descuentounitario,
    preciosugeridoconimpuestos,
    preciosugerido,
    eskit,
    texto1,
    texto2,
    texto3,
    texto4,
    texto5,
    texto6,
    numero1,
    numero2,
    numero3,
    numero4,
    fecha1,
    fecha2,
    emidarequestid,
    er_responsemessage,
    er_carriercontrolno,
    er_controlno,
    er_transactiondatetime,
    mensajeemida,
    sat_claveprodserv,
    sat_descripcion,
    sat_ivatrasladado,
    sat_iepstrasladado,
    sat_unidadid,
    sat_unidadclave,
    sat_unidaddescripcion,
    plazoid,
    plazo_dias)
AS
SELECT m.""EmpresaId"" AS empresaid,
    m.""SucursalId"" AS sucursalid,
    m.""Doctoid"" AS doctoid,
    m.""Id"" AS movtoid,
    m.""Productoid"" AS productoid,
    m.""Orden"" AS orden,
    m.""Partida"" AS partida,
    d.""Tipodoctoid"" AS tipodoctoid,
    productoinv.""Manejalote"" AS manejalote,
    m.""Lote"" AS lote,
    m.""Fechavence"" AS fechavence,
    m.""Precio"" AS precio,
    m.""Tasaiva"" AS tasaiva,
    m.""Tasaieps"" AS tasaieps,
    round(1.00 * (1.00 + COALESCE(m.""Tasaieps"", 0.00) / 100.00) * (1.00 +
        COALESCE(m.""Tasaiva"", 0.00) / 100.00), 4) - 1.00 AS tasaimpuesto,
    m.""Preciolista"" AS preciolista,
    mtrasl.""Preciovisibletraslado"" AS preciovisibletraslado,
    COALESCE(m.""Cantidad"", 0::numeric) AS cantidad,
    COALESCE(mdevo.""Cantidadsurtida"", 0::numeric) AS cantidadsurtida,
    COALESCE(mdevo.""Cantidadfaltante"", 0::numeric) AS cantidadfaltante,
    COALESCE(mdevo.""Cantidaddevuelta"", 0::numeric) AS cantidaddevuelta,
    COALESCE(mdevo.""Cantidadsaldo"", 0::numeric) AS cantidadsaldo,
    COALESCE(m.""Iva"", 0::numeric) AS iva,
    COALESCE(m.""Ieps"", 0::numeric) AS ieps,
    COALESCE(m.""Iva"" + m.""Ieps"", 0::numeric) AS impuesto,
    COALESCE(m.""Importe"", 0::numeric) AS importe,
    COALESCE(m.""Subtotal"", 0::numeric) AS subtotal,
    COALESCE(m.""Total"", 0::numeric) + COALESCE(mprecio.""Descuentovale"",
        0::numeric) AS total,
    COALESCE(mreb.""Totalconrebaja"", 0::numeric) AS totalconrebaja,
    COALESCE(mreb.""Montorebaja"", 0::numeric) AS montorebaja,
    COALESCE(m.""Ivaretenido"", 0::numeric) AS ivaretenido,
    COALESCE(m.""Isrretenido"", 0::numeric) AS isrretenido,
    COALESCE(m.""Descuento"", 0::numeric) AS descuento,
    COALESCE(mprecio.""Descuentovale"", 0::numeric) AS descuentovale,
    COALESCE(mutil.""Costoimporte"", 0::numeric) AS costoimporte,
    COALESCE(m.""Descuentoporcentaje"", 0::numeric) AS descuentoporcentaje,
        CASE
            WHEN d.""Subtipodoctoid"" = 13 THEN '[DPP]'::text
            ELSE ''::text
        END || producto.""Clave""::text AS productoclave,
    producto.""Ean"" AS ean,
    productoinv.""Pzacaja"" AS pzacaja,
    unidad.""Clave"" AS unidadclave,
    unidad.""Nombre"" AS unidadnombre,
        CASE
            WHEN unidad.""Clave""::text = 'KG'::text THEN COALESCE(m.""Cantidad"", 0.00)
            ELSE 0.00
        END AS kilogramos,
    ((floor(COALESCE(m.""Cantidad"", 0.00) /
        CASE
            WHEN COALESCE(productoinv.""Pzacaja"", 1.00) = 0.00 THEN 1.00
            ELSE COALESCE(productoinv.""Pzacaja"", 1.00)
        END)::character varying(20)::text || 'CAJAS '::text) ||
            ((COALESCE(m.""Cantidad"", 0.00) %
        CASE
            WHEN COALESCE(productoinv.""Pzacaja"", 1.00) = 0.00 THEN 1.00
            ELSE COALESCE(productoinv.""Pzacaja"", 1.00)
        END))::character varying(20)::text) || ' PIEZAS '::text AS descpzacaja,
    floor(COALESCE(m.""Cantidad"", 0.00) /
        CASE
            WHEN COALESCE(productoinv.""Pzacaja"", 1.00) = 0.00 THEN 1.00
            ELSE COALESCE(productoinv.""Pzacaja"", 1.00)
        END) AS cajas,
    COALESCE(m.""Cantidad"", 0.00) %
        CASE
            WHEN COALESCE(productoinv.""Pzacaja"", 1.00) = 0.00 THEN 1.00
            ELSE COALESCE(productoinv.""Pzacaja"", 1.00)
        END AS piezas,
    prdcmdin.""Descripcion_comodin"" AS descripcion_comodin,
        CASE
            WHEN prdcmdin.""Descripcion_comodin"" = 'S'::bpchar THEN mcmdin.""Descripcion1""
            ELSE producto.""Descripcion1""
        END AS descripcion1,
        CASE
            WHEN prdcmdin.""Descripcion_comodin"" = 'S'::bpchar THEN mcmdin.""Descripcion2""
            ELSE producto.""Descripcion1""
        END AS descripcion2,
        CASE
            WHEN prdcmdin.""Descripcion_comodin"" = 'S'::bpchar THEN mcmdin.""Descripcion3""
            ELSE producto.""Descripcion1""
        END AS descripcion3,
    linea.""Id"" AS lineaid,
    linea.""Clave"" AS lineaclave,
    linea.""Nombre"" AS lineanombre,
    linea.""Tiporecarga"" AS ""TIPORECARGA"",
    COALESCE(m.""Precio"", 0.00) + COALESCE(m.""Ieps"", 0.00) + COALESCE(m.""Iva"",
        0.00) AS precioconimpuesto,
    COALESCE(m.""Precio"", 0.00) + COALESCE(m.""Ieps"", 0.00) AS precioconieps,
    m.""Preciomaximopublico"" AS preciomaximopublico,
    COALESCE(m.""Preciolista"", 0.00) * round((100.00 + COALESCE(m.""Tasaieps"",
        0.00)) / 100.00, 4) * round((100.00 + COALESCE(m.""Tasaiva"", 0.00)) / 100.00, 4) AS precioconimpuestosindescuento,
    COALESCE(m.""Preciolista"", 0.00) * round((100.00 + COALESCE(m.""Tasaieps"",
        0.00)) / 100.00, 4) * round((100.00 + COALESCE(m.""Tasaiva"", 0.00)) / 100.00, 4) - (COALESCE(m.""Precio"", 0.00) + COALESCE(m.""Ieps"", 0.00) + COALESCE(m.""Iva"", 0.00)) AS descuentounitario,
    COALESCE(productoprecios.""Preciosugerido"", 0.00) * round((100.00 +
        COALESCE(m.""Tasaieps"", 0.00)) / 100.00, 4) * round((100.00 + COALESCE(m.""Tasaiva"", 0.00)) / 100.00, 4) AS preciosugeridoconimpuestos,
    productoprecios.""Preciosugerido"" AS preciosugerido,
    productokit.""Eskit"" AS eskit,
    productocar.""Texto1"" AS texto1,
    productocar.""Texto2"" AS texto2,
    productocar.""Texto3"" AS texto3,
    productocar.""Texto4"" AS texto4,
    productocar.""Texto5"" AS texto5,
    productocar.""Texto6"" AS texto6,
    productocar.""Numero1"" AS numero1,
    productocar.""Numero2"" AS numero2,
    productocar.""Numero3"" AS numero3,
    productocar.""Numero4"" AS numero4,
    productocar.""Fecha1"" AS fecha1,
    productocar.""Fecha2"" AS fecha2,
    COALESCE(memida.""Emidarequestid"", 0::bigint) AS emidarequestid,
    emidarequest.""Responsemessage"" AS er_responsemessage,
    emidarequest.""Carriercontrolno"" AS er_carriercontrolno,
    emidarequest.""Controlno"" AS er_controlno,
    emidarequest.""Transactiondatetime"" AS er_transactiondatetime,
    (((((((('Recarga a : '::text || COALESCE(m.""Lote"", ''::character
        varying)::text) || ' '::text) || COALESCE(emidarequest.""Responsemessage"", ''::character varying)::text) || ' '::text) ||
        CASE
            WHEN COALESCE(emidarequest.""Carriercontrolno"", ''::character
                varying)::text = ''::text THEN ''::text
            ELSE '  - Autorizacion '::text || emidarequest.""Carriercontrolno""::text
        END) || ' '::text) ||
        CASE
            WHEN COALESCE(emidarequest.""Controlno"", ''::character
                varying)::text = ''::text THEN ''::text
            ELSE '  - Control Id '::text || emidarequest.""Controlno""::text
        END) || ' '::text) ||
        CASE
            WHEN COALESCE(emidarequest.""Transactiondatetime"", ''::character
                varying)::text = ''::text THEN ('  - Fecha/Hora '::text || ''::text)::character varying
            ELSE emidarequest.""Transactiondatetime""
        END::text AS mensajeemida,
    sps.""Sat_claveprodserv"" AS sat_claveprodserv,
    sps.""Sat_descripcion"" AS sat_descripcion,
    sps.""Sat_ivatrasladado"" AS sat_ivatrasladado,
    sps.""Sat_iepstrasladado"" AS sat_iepstrasladado,
    producto_fe.""Sat_Claveunidadpesoid"" AS sat_unidadid,
    sat_unidad.""Sat_clave"" AS sat_unidadclave,
    sat_unidad.""Sat_descripcion"" AS sat_unidaddescripcion,
    producto_poliza.""Plazoid"" AS plazoid,
    plazo.""Dias"" AS plazo_dias
FROM ""Movto"" m
     LEFT JOIN ""Docto"" d ON d.""EmpresaId"" = m.""EmpresaId"" AND d.""SucursalId"" =
         m.""SucursalId"" AND d.""Id"" = m.""Doctoid""
     LEFT JOIN ""Movto_precio"" mprecio ON mprecio.""EmpresaId"" = m.""EmpresaId""
         AND mprecio.""SucursalId"" = m.""SucursalId"" AND mprecio.""Movtoid"" = m.""Id""
     LEFT JOIN ""Movto_inventario"" minv ON minv.""EmpresaId"" = m.""EmpresaId"" AND
         minv.""SucursalId"" = m.""SucursalId"" AND minv.""Movtoid"" = m.""Id""
     LEFT JOIN ""Movto_promocion"" mprom ON mprom.""EmpresaId"" = m.""EmpresaId"" AND
         mprom.""SucursalId"" = m.""SucursalId"" AND mprom.""Movtoid"" = m.""Id""
     LEFT JOIN ""Movto_rebajaespecial"" mreb ON mreb.""EmpresaId"" = m.""EmpresaId""
         AND mreb.""SucursalId"" = m.""SucursalId"" AND mreb.""Movtoid"" = m.""Id""
     LEFT JOIN ""Movto_traslado"" mtrasl ON mtrasl.""EmpresaId"" = m.""EmpresaId""
         AND mtrasl.""SucursalId"" = m.""SucursalId"" AND mtrasl.""Movtoid"" = m.""Id""
     LEFT JOIN ""Movto_devolucion"" mdevo ON mdevo.""EmpresaId"" = m.""EmpresaId""
         AND mdevo.""SucursalId"" = m.""SucursalId"" AND mdevo.""Movtoid"" = m.""Id""
     LEFT JOIN ""Movto_utilidad"" mutil ON mutil.""EmpresaId"" = m.""EmpresaId"" AND
         mutil.""SucursalId"" = m.""SucursalId"" AND mutil.""Movtoid"" = m.""Id""
     LEFT JOIN ""Movto_comodin"" mcmdin ON mcmdin.""EmpresaId"" = m.""EmpresaId"" AND
         mcmdin.""SucursalId"" = m.""SucursalId"" AND mcmdin.""Movtoid"" = m.""Id""
     LEFT JOIN ""Producto"" producto ON producto.""EmpresaId"" = m.""EmpresaId"" AND
         producto.""SucursalId"" = m.""SucursalId"" AND producto.""Id"" = m.""Productoid""
     LEFT JOIN ""Productocaracteristicas"" productocar ON productocar.""EmpresaId""
         = m.""EmpresaId"" AND productocar.""SucursalId"" = m.""SucursalId"" AND productocar.""Productoid"" = producto.""Id""
     LEFT JOIN ""Producto_comodin"" prdcmdin ON prdcmdin.""EmpresaId"" =
         m.""EmpresaId"" AND prdcmdin.""SucursalId"" = m.""SucursalId"" AND prdcmdin.""Productoid"" = producto.""Id""
     LEFT JOIN ""Linea"" linea ON linea.""EmpresaId"" = m.""EmpresaId"" AND
         linea.""SucursalId"" = m.""SucursalId"" AND linea.""Id"" = producto.""Lineaid""
     LEFT JOIN ""Producto_inventario"" productoinv ON productoinv.""EmpresaId"" =
         m.""EmpresaId"" AND productoinv.""SucursalId"" = m.""SucursalId"" AND productoinv.""Productoid"" = producto.""Id""
     LEFT JOIN ""Producto_kit"" productokit ON productokit.""EmpresaId"" =
         m.""EmpresaId"" AND productokit.""SucursalId"" = m.""SucursalId"" AND productokit.""Productoid"" = producto.""Id""
     LEFT JOIN ""Producto_precios"" productoprecios ON
         productoprecios.""EmpresaId"" = m.""EmpresaId"" AND productoprecios.""SucursalId"" = m.""SucursalId"" AND productoprecios.""Productoid"" = producto.""Id""
     LEFT JOIN ""Unidad"" unidad ON unidad.""EmpresaId"" = m.""EmpresaId"" AND
         unidad.""SucursalId"" = m.""SucursalId"" AND unidad.""Id"" = producto.""Unidadid""
     LEFT JOIN ""Movto_emida"" memida ON memida.""EmpresaId"" = m.""EmpresaId"" AND
         memida.""SucursalId"" = m.""SucursalId"" AND memida.""Movtoid"" = m.""Id""
     LEFT JOIN ""Emidarequest"" emidarequest ON emidarequest.""EmpresaId"" =
         m.""EmpresaId"" AND emidarequest.""SucursalId"" = m.""SucursalId"" AND emidarequest.""Id"" = memida.""Emidarequestid""
     LEFT JOIN ""Producto_fact_elect"" producto_fe ON producto_fe.""EmpresaId"" =
         m.""EmpresaId"" AND producto_fe.""SucursalId"" = m.""SucursalId"" AND producto_fe.""Productoid"" = producto.""Id""
     LEFT JOIN ""Sat_productoservicio"" sps ON sps.""Id"" =
         producto_fe.""Sat_productoservicioid""
     LEFT JOIN ""Sat_unidadmedida"" sat_unidad ON sat_unidad.""Id"" =
         producto_fe.""Sat_Claveunidadpesoid""
     LEFT JOIN ""Producto_poliza"" producto_poliza ON producto_poliza.""EmpresaId""
         = m.""EmpresaId"" AND producto_poliza.""SucursalId"" = m.""SucursalId"" AND producto_poliza.""Productoid"" = producto.""Id""
     LEFT JOIN ""Plazo"" plazo ON plazo.""EmpresaId"" = m.""EmpresaId"" AND
         plazo.""SucursalId"" = m.""SucursalId"" AND producto_poliza.""Plazoid"" = plazo.""Id"";
";
        }


        public static string View_recibo_detail_consolidado()
        {
            return $@"CREATE OR REPLACE VIEW public.recibo_detail_consolidado(
    empresaid,
    sucursalid,
    doctoid,
    movtoid,
    productoid,
    orden,
    partida,
    tipodoctoid,
    manejalote,
    lote,
    fechavence,
    precio,
    tasaiva,
    tasaieps,
    tasaimpuesto,
    preciolista,
    preciovisibletraslado,
    cantidad,
    cantidadsurtida,
    cantidadfaltante,
    cantidaddevuelta,
    cantidadsaldo,
    iva,
    ieps,
    impuesto,
    importe,
    subtotal,
    total,
    totalconrebaja,
    montorebaja,
    ivaretenido,
    isrretenido,
    descuento,
    descuentovale,
    costoimporte,
    descuentoporcentaje,
    productoclave,
    ean,
    pzacaja,
    unidadclave,
    unidadnombre,
    kilogramos,
    descpzacaja,
    cajas,
    piezas,
    descripcion_comodin,
    descripcion1,
    descripcion2,
    descripcion3,
    lineaid,
    lineaclave,
    lineanombre,
    ""TIPORECARGA"",
    precioconimpuesto,
    precioconieps,
    preciomaximopublico,
    precioconimpuestosindescuento,
    descuentounitario,
    preciosugeridoconimpuestos,
    preciosugerido,
    eskit,
    texto1,
    texto2,
    texto3,
    texto4,
    texto5,
    texto6,
    numero1,
    numero2,
    numero3,
    numero4,
    fecha1,
    fecha2,
    emidarequestid,
    er_responsemessage,
    er_carriercontrolno,
    er_controlno,
    er_transactiondatetime,
    mensajeemida,
    sat_claveprodserv,
    sat_descripcion,
    sat_ivatrasladado,
    sat_iepstrasladado,
    sat_unidadid,
    sat_unidadclave,
    sat_unidaddescripcion,
    plazoid,
    plazo_dias)
AS
  SELECT df.""EmpresaId"" AS empresaid,
         df.""SucursalId"" AS sucursalid,
         dfec.""Factconsid"" AS doctoid,
         df.""Id"" AS movtoid,
         0 AS productoid,
         df.""Id"" AS orden,
         df.""Id"" AS partida,
         df.""Tipodoctoid"" AS tipodoctoid,
         'N'::text AS manejalote,
         ''::text AS lote,
         NULL::timestamp with time zone AS fechavence,
         df.""Subtotal"" AS precio,
         0::numeric AS tasaiva,
         0::numeric AS tasaieps,
         0::numeric AS tasaimpuesto,
         df.""Subtotal"" AS preciolista,
         df.""Subtotal"" AS preciovisibletraslado,
         1::numeric AS cantidad,
         1::numeric AS cantidadsurtida,
         0::numeric AS cantidadfaltante,
         0::numeric AS cantidaddevuelta,
         0::numeric AS cantidadsaldo,
         COALESCE(df.""Iva"", 0::numeric) AS iva,
         COALESCE(df.""Ieps"", 0::numeric) AS ieps,
         COALESCE(df.""Iva"" + df.""Ieps"", 0::numeric) AS impuesto,
         COALESCE(df.""Subtotal"", 0::numeric) AS importe,
         COALESCE(df.""Subtotal"", 0::numeric) AS subtotal,
         COALESCE(df.""Total"", 0::numeric) AS total,
         COALESCE(df.""Total"", 0::numeric) AS totalconrebaja,
         0::numeric AS montorebaja,
         COALESCE(dffe.""Ivaretenido"", 0::numeric) AS ivaretenido,
         COALESCE(dffe.""Isrretenido"", 0::numeric) AS isrretenido,
         0::numeric AS descuento,
         0::numeric AS descuentovale,
         0::numeric AS costoimporte,
         0::numeric AS descuentoporcentaje,
         'FACTURACONSOLIDADA'::text AS productoclave,
         ''::text AS ean,
         1::numeric AS pzacaja,
         'PZA'::text AS unidadclave,
         'PZA'::text AS unidadnombre,
         0.00 AS kilogramos,
         '0 CAJAS 1 PIEZA'::text AS descpzacaja,
         0.00 AS cajas,
         1.00 AS piezas,
         ''::text AS descripcion_comodin,
         'FACTURACONSOLIDADA'::text AS descripcion1,
         'FACTURACONSOLIDADA'::text AS descripcion2,
         'FACTURACONSOLIDADA'::text AS descripcion3,
         NULL::bigint AS lineaid,
         NULL::text AS lineaclave,
         NULL::text AS lineanombre,
         NULL::text AS ""TIPORECARGA"",
         COALESCE(df.""Subtotal"", 0.00) + COALESCE(df.""Ieps"", 0.00) + COALESCE(
           df.""Iva"", 0.00) AS precioconimpuesto,
         COALESCE(df.""Subtotal"", 0.00) + COALESCE(df.""Ieps"", 0.00) AS
           precioconieps,
         COALESCE(df.""Subtotal"", 0.00) AS preciomaximopublico,
         COALESCE(df.""Total"", 0.00) AS precioconimpuestosindescuento,
         0.00 AS descuentounitario,
         COALESCE(df.""Total"", 0.00) AS preciosugeridoconimpuestos,
         COALESCE(df.""Subtotal"", 0.00) AS preciosugerido,
         'N'::text AS eskit,
         NULL::text AS texto1,
         NULL::text AS texto2,
         NULL::text AS texto3,
         NULL::text AS texto4,
         NULL::text AS texto5,
         NULL::text AS texto6,
         NULL::numeric AS numero1,
         NULL::numeric AS numero2,
         NULL::numeric AS numero3,
         NULL::numeric AS numero4,
         NULL::timestamp with time zone AS fecha1,
         NULL::timestamp with time zone AS fecha2,
         0::bigint AS emidarequestid,
         NULL::text AS er_responsemessage,
         NULL::text AS er_carriercontrolno,
         NULL::text AS er_controlno,
         NULL::text AS er_transactiondatetime,
         NULL::text AS mensajeemida,
         '01010101'::text AS sat_claveprodserv,
         sps.""Sat_descripcion"" AS sat_descripcion,
         sps.""Sat_ivatrasladado"" AS sat_ivatrasladado,
         sps.""Sat_iepstrasladado"" AS sat_iepstrasladado,
         sat_unidad.""Id"" AS sat_unidadid,
         'ACT'::text AS sat_unidadclave,
         sat_unidad.""Sat_descripcion"" AS sat_unidaddescripcion,
         NULL::bigint AS plazoid,
         0::numeric AS plazo_dias
  FROM ""Docto_fact_elect_consolidacion"" dfec
       LEFT JOIN ""Docto"" df ON dfec.""EmpresaId"" = df.""EmpresaId"" AND
         dfec.""SucursalId"" = df.""SucursalId"" AND dfec.""Doctoid"" = df.""Id""
       LEFT JOIN ""Docto_fact_elect"" dffe ON dfec.""EmpresaId"" = dffe.""EmpresaId""
         AND dfec.""SucursalId"" = dffe.""SucursalId"" AND dfec.""Doctoid"" =
         dffe.""Doctoid""
       LEFT JOIN ""Docto"" d ON dfec.""EmpresaId"" = d.""EmpresaId"" AND
         dfec.""SucursalId"" = d.""SucursalId"" AND dfec.""Doctoid"" = d.""Id""
       LEFT JOIN ""Sat_productoservicio"" sps ON sps.""Sat_claveprodserv""::text =
         '01010101'::text
       LEFT JOIN ""Sat_unidadmedida"" sat_unidad ON sat_unidad.""Sat_clave""::text =
         'ACT'::text;
                     ";
        }

        public static string View_recibo_detail_kit()
        {
            return $@"CREATE OR REPLACE VIEW public.recibo_detail_kit (
    empresaid,
    sucursalid,
    doctoid,
    movtoid,
    kitmovtoid,
    kitprodclave,
    kitprodnombre,
    kitdescripcion1,
    kitpreciolista,
    kitprecio,
    kittasaiva,
    kittasaieps,
    kitimpuesto,
    kitiva,
    kitieps,
    kitsubtotal,
    kittotal,
    kitcantidad,
    kitdescpzacaja,
    sat_claveprodserv,
    sat_descripcion,
    sat_ivatrasladado,
    sat_iepstrasladado,
    sat_unidadid,
    sat_unidadclave,
    sat_unidaddescripcion,
    plazoid,
    plazo_dias)
AS
SELECT m.""EmpresaId"" AS empresaid,
    m.""SucursalId"" AS sucursalid,
    m.""Doctoid"" AS doctoid,
    m.""Id"" AS movtoid,
    mkitdef.""Id"" AS kitmovtoid,
    pkitref.""Clave"" AS kitprodclave,
    pkitref.""Nombre"" AS kitprodnombre,
    pkitref.""Descripcion1"" AS kitdescripcion1,
    mkitdef.""Precioporunidad"" AS kitpreciolista,
    mkitdef.""Precioporunidad"" AS kitprecio,
    mkitdef.""Tasaiva"" AS kittasaiva,
    mkitdef.""Tasaieps"" AS kittasaieps,
    COALESCE(mkitdef.""Montoiva"", 0.00) + COALESCE(mkitdef.""Montoieps"", 0.00) AS
        kitimpuesto,
    COALESCE(mkitdef.""Montoiva"", 0.00) AS kitiva,
    COALESCE(mkitdef.""Montoieps"", 0.00) AS kitieps,
    COALESCE(mkitdef.""Montosubtotal"", 0.00) AS kitsubtotal,
    COALESCE(mkitdef.""Montototal"", 0.00) AS kittotal,
    COALESCE(mkitdef.""Cantidadpartetotal"", 0.00) AS kitcantidad,
        CASE
            WHEN COALESCE(pkitrefinv.""Pzacaja"", 0::numeric) = 0::numeric THEN
                COALESCE(mkitdef.""Cantidadpartetotal"", 0.00)::character varying(10)::text || ' pzas'::text
            ELSE ((floor(COALESCE(mkitdef.""Cantidadpartetotal"", 0.00) /
                COALESCE(pkitrefinv.""Pzacaja"", 1.00))::character varying(10)::text || ' cajas '::text) || ((COALESCE(mkitdef.""Cantidadpartetotal"", 0.00) % COALESCE(pkitrefinv.""Pzacaja"", 1.00)))::character varying(10)::text) || ' piezas '::text
        END AS kitdescpzacaja,
    sps.""Sat_claveprodserv"" AS sat_claveprodserv,
    sps.""Sat_descripcion"" AS sat_descripcion,
    sps.""Sat_ivatrasladado"" AS sat_ivatrasladado,
    sps.""Sat_iepstrasladado"" AS sat_iepstrasladado,
    producto_fe.""Sat_Claveunidadpesoid"" AS sat_unidadid,
    sat_unidad.""Sat_clave"" AS sat_unidadclave,
    sat_unidad.""Sat_descripcion"" AS sat_unidaddescripcion,
    producto_poliza.""Plazoid"" AS plazoid,
    plazo.""Dias"" AS plazo_dias
FROM ""Movto"" m
     LEFT JOIN ""Movto_kit"" mkit ON mkit.""EmpresaId"" = m.""EmpresaId"" AND
         mkit.""SucursalId"" = m.""SucursalId"" AND mkit.""Movtoid"" = m.""Id""
     JOIN ""Movto_kit_def"" mkitdef ON mkitdef.""EmpresaId"" = m.""EmpresaId"" AND
         mkitdef.""SucursalId"" = m.""SucursalId"" AND mkitdef.""Movtoid"" = m.""Id""
     LEFT JOIN ""Producto"" p ON p.""EmpresaId"" = m.""EmpresaId"" AND p.""SucursalId""
         = m.""SucursalId"" AND p.""Id"" = m.""Productoid""
     LEFT JOIN ""Producto"" pkitref ON pkitref.""EmpresaId"" = m.""EmpresaId"" AND
         pkitref.""SucursalId"" = m.""SucursalId"" AND pkitref.""Id"" = mkitdef.""Productoparteid""
     LEFT JOIN ""Producto_inventario"" pkitrefinv ON pkitrefinv.""EmpresaId"" =
         m.""EmpresaId"" AND pkitrefinv.""SucursalId"" = m.""SucursalId"" AND pkitrefinv.""Productoid"" = pkitref.""Id""
     LEFT JOIN ""Producto_fact_elect"" producto_fe ON producto_fe.""EmpresaId"" =
         m.""EmpresaId"" AND producto_fe.""SucursalId"" = m.""SucursalId"" AND producto_fe.""Productoid"" = p.""Id""
     LEFT JOIN ""Sat_productoservicio"" sps ON sps.""Id"" =
         producto_fe.""Sat_productoservicioid""
     LEFT JOIN ""Sat_unidadmedida"" sat_unidad ON sat_unidad.""Id"" =
         producto_fe.""Sat_Claveunidadpesoid""
     LEFT JOIN ""Producto_poliza"" producto_poliza ON producto_poliza.""EmpresaId""
         = m.""EmpresaId"" AND producto_poliza.""SucursalId"" = m.""SucursalId"" AND producto_poliza.""Productoid"" = p.""Id""
     LEFT JOIN ""Plazo"" plazo ON plazo.""EmpresaId"" = m.""EmpresaId"" AND
         plazo.""SucursalId"" = m.""SucursalId"" AND producto_poliza.""Plazoid"" = plazo.""Id"";
";
        }

        public static string View_recibo_master()
        {
            return $@"CREATE OR REPLACE VIEW public.recibo_master (
    empresaid,
    sucursalid,
    id,
    headercancelacion,
    nombresucursal,
    descripcionsucursal,
    empresa_rfc,
    empresa_fiscalnombre,
    empresa_colonia,
    empresa_domicicio,
    empresa_numeroexterior,
    empresa_numerointerior,
    empresa_codigopostal,
    empresa_razon_social,
    empresa_telefono,
    empresa_ciudad,
    empresa_estado,
    empresa_municipio,
    lugardeexpedicion,
    fechadeexpedicion,
    cajero,
    ticket,
    titulo,
    doc_ref_header1,
    doc_ref_header2,
    doc_ref_header3,
    doc_ref_header4,
    doc_ref_header5,
    titulo_persona,
    personanombre,
    personaapellidos,
    personadomicilio,
    personanumerointerior,
    personanumeroexterior,
    personacodigopostal,
    personacolonia,
    personaciudad,
    personaestado,
    personatelefono,
    personatelefono2,
    personaclave,
    personarazonsocial,
    personarfc,
    subtotal,
    iva,
    total,
    descuentovale,
    total_con_letra,
    descuento,
    cambio,
    caja,
    pagoefectivo,
    efectivorecibido,
    efectivocambio,
    pagotarjeta,
    pagocredito,
    pagocheque,
    pagovale,
    pagomonedero,
    pagotransferencia,
    pagonoidentificado,
    abono,
    saldo,
    abonomonedero,
    saldomonedero,
    vigenciamonedero,
    monederoid,
    customfooter,
    entregacalle,
    entreganumeroexterior,
    entreganumerointerior,
    entregacolonia,
    entregamunicipio,
    entregaestado,
    entregacodigopostal,
    ieps,
    impuesto,
    referencias,
    fechafactura,
    notapago,
    plazo,
    vence,
    montorebaja,
    totalconrebaja,
    personaauxnombres,
    personaauxapellidos,
    personaauxdomicilio,
    personaauxcolonia,
    personaauxciudad,
    personaauxmunicipio,
    personaauxestado,
    personaauxpais,
    personaauxcodigopostal,
    personaauxtelefono1,
    personaauxcelular,
    personaauxemail1,
    personaapartadoid,
    fax,
    montorebajaautorizada,
    notamovil1,
    notamovil2,
    logoimage,
    tipodoctoid,
    rutaembarqueclave,
    rutaembarquenombre,
    ordencompra,
    fechahora,
    totalsiniva,
    vendedorclienteclave,
    vendedorclientenombre,
    subtipodoctoid,
    tipodiferenciainventarioid,
    tipodiferenciainventarioclave,
    tipodiferenciainventarionombre,
    tipodiferenciainventariodescripcion,
    timbradouuid,
    timbradofecha,
    timbradocertsat,
    timbradosellosat,
    timbradosellocfdi,
    timbradocancelado,
    timbradouuidcancelacion,
    timbradoformapagosat,
    esfacturaelectronica,
    timbradofechacancelacion,
    timbradofechafactura,
    dfe_fechafactura,
    foliosat,
    seriesat,
    sat_usocfdiid,
    sat_usocfdiclave,
    sat_usocfdidescripcion,
    ivaretenido,
    isrretenido)
AS
SELECT docto.""EmpresaId"" AS empresaid,
    docto.""SucursalId"" AS sucursalid,
    docto.""Id"" AS id,
        CASE
            WHEN docto.""Estatusdoctoid"" = 2 THEN 'Cancelacion'::character varying(20)
            ELSE ''::character varying(20)
        END AS headercancelacion,
    sucursal.""Nombre"" AS nombresucursal,
    sucursal.""Descripcion"" AS descripcionsucursal,
    empresa.""Rfc"" AS empresa_rfc,
    p.""Fiscalnombre"" AS empresa_fiscalnombre,
    p.""Fiscalcolonia"" AS empresa_colonia,
    p.""Fiscalcalle"" AS empresa_domicicio,
    p.""Fiscalnumeroexterior"" AS empresa_numeroexterior,
    p.""Fiscalnumerointerior"" AS empresa_numerointerior,
    p.""Codigopostal"" AS empresa_codigopostal,
    'Razon Social'::character varying(20) AS empresa_razon_social,
    empresa.""Telefono"" AS empresa_telefono,
    p.""Fiscalmunicipio"" AS empresa_ciudad,
    p.""Fiscalestado"" AS empresa_estado,
    p.""Fiscalmunicipio"" AS empresa_municipio,
    p.""Fiscalmunicipio""::text || p.""Fiscalestado""::text AS lugardeexpedicion,
    docto.""Fecha"" AS fechadeexpedicion,
    v.""Nombre"" AS cajero,
        CASE
            WHEN docto.""Tipodoctoid"" <> 17 THEN COALESCE(docto.""Folio""::bigint,
                docto.""Id"")
            ELSE doctoref.""Folio""::bigint
        END AS ticket,
        CASE
            WHEN docto.""Tipodoctoid"" = 41 THEN 'RECEPCION TRASLADO'::character
                varying(50)
            WHEN docto.""Tipodoctoid"" = 11 THEN (('COMPRA'::text ||
            CASE
                WHEN docto.""Origenfiscalid"" = 3 THEN ' DE REMISION'::text
                ELSE ' DE FACTURA'::text
            END))::character varying(50)
            WHEN docto.""Tipodoctoid"" = 31 THEN 'TRASLADO'::character varying(50)
            WHEN docto.""Tipodoctoid"" = 81 THEN 'TRASPASO A SUCURSAL'::character
                varying(50)
            WHEN docto.""Tipodoctoid"" = 12 THEN
                'DEVOLUCION DE COMPRA'::character varying(50)
            WHEN docto.""Tipodoctoid"" = 21 THEN
            CASE
                WHEN docto.""Estatusdoctoid"" <> 0 THEN
                    'NOTA DE VENTA'::character varying(50)
                ELSE 'COTIZACION'::character varying(50)
            END
            WHEN docto.""Tipodoctoid"" = 22 THEN 'NOTA DE CREDITO'::character varying(50)
            WHEN docto.""Tipodoctoid"" = 25 THEN
                'APARTADO DE MERCANCIA'::character varying(50)
            WHEN docto.""Tipodoctoid"" = 201 THEN
                'ANTICIPO DE CLIENTE'::character varying(50)
            WHEN docto.""Tipodoctoid"" = 202 THEN
                'ANTICIPO DE PROVEEDOR'::character varying(50)
            WHEN docto.""Tipodoctoid"" = 16 THEN 'ORDEN DE COMPRA'::character varying(50)
            WHEN docto.""Tipodoctoid"" = 17 THEN
                'POR RECIBIR ORDEN COMPRA'::character varying(50)
            WHEN docto.""Tipodoctoid"" = 63 THEN 'GASTO'::character varying(50)
            WHEN docto.""Tipodoctoid"" = 111 THEN 'OTRAS ENTRADAS'::character varying(50)
            WHEN docto.""Tipodoctoid"" = 121 THEN 'OTRAS SALIDAS'::character varying(50)
            WHEN docto.""Tipodoctoid"" = 821 THEN 'VENTA A FUTURO'::character varying(50)
            ELSE ''::character varying(50)
        END AS titulo,
        CASE
            WHEN docto.""Tipodoctoid"" = 41 THEN 'TRASLADO DE SUCURSAL '::text ||
                sucursaltraslado.""Clave""::text
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[31::bigint, 81::bigint]) THEN
                'TRASLADO A SUCURSAL '::text || sucursaltraslado.""Clave""::text
            WHEN docto.""Tipodoctoid"" = 21 AND (docto.""Subtipodoctoid"" = ANY
                (ARRAY[7::bigint, 8::bigint])) THEN 'TRASLADO A SUCURSAL '::text || sucursaltraslado.""Clave""::text
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[11::bigint, 12::bigint]) THEN
                '# DOCUMENTO '::text || docto.""Referencia""::text
            ELSE ''::text
        END::character varying(50) AS doc_ref_header1,
        CASE
            WHEN docto.""Tipodoctoid"" = 41 THEN 'SUCURSAL FUENTE '::text ||
                sucursaltraslado.""Nombre""::text
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[31::bigint, 81::bigint]) THEN
                'SUCURSAL DESTINO '::text || sucursaltraslado.""Nombre""::text
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[11::bigint, 12::bigint]) THEN
                '# FECHA FACTURA '::text || docto.""Fecha""
            ELSE ''::text
        END::character varying(50) AS doc_ref_header2,
        CASE
            WHEN docto.""Tipodoctoid"" = 12 THEN 'Tipo Doc. '::text ||
            CASE
                WHEN docto.""Origenfiscalid"" <> 2 THEN 'Remision'::text
                ELSE 'Factura'::text
            END
            ELSE ''::text
        END::character varying(50) AS doc_ref_header3,
        CASE
            WHEN docto.""Tipodoctoid"" = 12 AND COALESCE(doctoref.""Folio"", 0) <>
                0 THEN 'Del folio de compra '::text || doctoref.""Folio""::character varying(20)::text
            WHEN docto.""Tipodoctoid"" = 22 AND COALESCE(doctoref.""Folio"", 0) <>
                0 THEN 'Del folio de venta '::text || doctoref.""Folio""::character varying(20)::text
            WHEN docto.""Tipodoctoid"" = 21 AND COALESCE(doctoref.""Folio"", 0) <>
                0 THEN 'Del traslado o surtimiento: '::text || doctoref.""Folio""::character varying(20)::text
            WHEN (docto.""Tipodoctoid"" = ANY (ARRAY[31::bigint, 81::bigint]))
                AND (docto.""Subtipodoctoid"" = ANY (ARRAY[7::bigint, 8::bigint])) THEN 'VENTA REL. '::text || doctoref.""Folio""::character varying(20)::text
            ELSE ''::text
        END::character varying(50) AS doc_ref_header4,
        CASE
            WHEN (docto.""Tipodoctoid"" = ANY (ARRAY[11::bigint, 12::bigint,
                21::bigint, 22::bigint])) AND p.""Manejaalmacen"" = 'S'::bpchar THEN 'DEL ALMACEN: '::text || almacen.""Nombre""::text
            WHEN docto.""Tipodoctoid"" = 211 AND p.""Manejaalmacen"" = 'S'::bpchar
                THEN (('DEL ALMACEN: '::text || almacen.""Nombre""::text) || ' AL ALMACEN: '::text) || almacentraspaso.""Nombre""::text
            WHEN docto.""Tipodoctoid"" = 63 AND p.""Manejaalmacen"" = 'S'::bpchar
                THEN 'DEL ALMACEN: '::text || almacen.""Nombre""::text
            ELSE ''::text
        END::character varying(250) AS doc_ref_header5,
        CASE
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[21::bigint, 201::bigint]) THEN
            CASE
                WHEN docto.""Clienteid"" <> 1 THEN 'CLIENTE'::text
                ELSE 'VENTA DE MOSTRADOR'::text
            END
            WHEN docto.""Tipodoctoid"" = 25 THEN 'CLIENTE APARTADO'::text
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[11::bigint, 12::bigint,
                202::bigint]) THEN 'PROVEEDOR'::text
            ELSE ''::text
        END::character varying(50) AS titulo_persona,
        CASE
            WHEN docto.""Tipodoctoid"" = 25 THEN pa.""Nombres""
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[21::bigint, 201::bigint])
                THEN cliente.""Nombres""
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[11::bigint, 12::bigint,
                202::bigint]) THEN proveedor.""Nombres""
            ELSE COALESCE(cliente.""Nombres"", proveedor.""Nombres"")
        END AS personanombre,
        CASE
            WHEN docto.""Tipodoctoid"" = 25 THEN pa.""Apellidos""
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[21::bigint, 201::bigint])
                THEN cliente.""Apellidos""
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[11::bigint, 12::bigint,
                202::bigint]) THEN proveedor.""Apellidos""
            ELSE COALESCE(cliente.""Apellidos"", proveedor.""Apellidos"")
        END AS personaapellidos,
        CASE
            WHEN docto.""Tipodoctoid"" = 25 THEN pa_domicilio.""Calle""
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[21::bigint, 201::bigint])
                THEN cliente_domicilio.""Calle""
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[11::bigint, 12::bigint,
                202::bigint]) THEN proveedor_domicilio.""Calle""
            ELSE COALESCE(cliente_domicilio.""Calle"", proveedor_domicilio.""Calle"")
        END AS personadomicilio,
        CASE
            WHEN docto.""Tipodoctoid"" = 25 THEN pa_domicilio.""Numerointerior""
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[21::bigint, 201::bigint])
                THEN cliente_domicilio.""Numerointerior""
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[11::bigint, 12::bigint,
                202::bigint]) THEN proveedor_domicilio.""Numerointerior""
            ELSE COALESCE(cliente_domicilio.""Numerointerior"",
                proveedor_domicilio.""Numerointerior"")
        END AS personanumerointerior,
        CASE
            WHEN docto.""Tipodoctoid"" = 25 THEN pa_domicilio.""Numeroexterior""
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[21::bigint, 201::bigint])
                THEN cliente_domicilio.""Numeroexterior""
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[11::bigint, 12::bigint,
                202::bigint]) THEN proveedor_domicilio.""Numeroexterior""
            ELSE COALESCE(cliente_domicilio.""Numerointerior"",
                proveedor_domicilio.""Numeroexterior"")
        END AS personanumeroexterior,
        CASE
            WHEN docto.""Tipodoctoid"" = 25 THEN pa_domicilio.""Codigopostal""
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[21::bigint, 201::bigint])
                THEN cliente_domicilio.""Codigopostal""
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[11::bigint, 12::bigint,
                202::bigint]) THEN proveedor_domicilio.""Codigopostal""
            ELSE COALESCE(cliente_domicilio.""Codigopostal"",
                proveedor_domicilio.""Codigopostal"")
        END AS personacodigopostal,
        CASE
            WHEN docto.""Tipodoctoid"" = 25 THEN pa_domicilio.""Colonia""
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[21::bigint, 201::bigint])
                THEN cliente_domicilio.""Colonia""
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[11::bigint, 12::bigint,
                202::bigint]) THEN proveedor_domicilio.""Colonia""
            ELSE COALESCE(cliente_domicilio.""Colonia"", proveedor_domicilio.""Colonia"")
        END AS personacolonia,
        CASE
            WHEN docto.""Tipodoctoid"" = 25 THEN pa_domicilio.""Ciudad""
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[21::bigint, 201::bigint])
                THEN cliente_domicilio.""Ciudad""
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[11::bigint, 12::bigint,
                202::bigint]) THEN proveedor_domicilio.""Ciudad""
            ELSE COALESCE(cliente_domicilio.""Ciudad"", proveedor_domicilio.""Ciudad"")
        END AS personaciudad,
        CASE
            WHEN docto.""Tipodoctoid"" = 25 THEN pa_domicilio.""Estado""
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[21::bigint, 201::bigint])
                THEN cliente_domicilio.""Estado""
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[11::bigint, 12::bigint,
                202::bigint]) THEN proveedor_domicilio.""Estado""
            ELSE COALESCE(cliente_domicilio.""Estado"", proveedor_domicilio.""Estado"")
        END AS personaestado,
        CASE
            WHEN docto.""Tipodoctoid"" = 25 THEN pa.""Telefono1""
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[21::bigint, 201::bigint])
                THEN cliente.""Telefono1""
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[11::bigint, 12::bigint,
                202::bigint]) THEN proveedor.""Telefono1""
            ELSE COALESCE(cliente.""Telefono1"", proveedor.""Telefono1"")
        END AS personatelefono,
        CASE
            WHEN docto.""Tipodoctoid"" = 25 THEN ''::character varying
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[21::bigint, 201::bigint])
                THEN cliente.""Telefono2""
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[11::bigint, 12::bigint,
                202::bigint]) THEN proveedor.""Telefono2""
            ELSE COALESCE(cliente.""Telefono2"", proveedor.""Telefono2"")
        END AS personatelefono2,
        CASE
            WHEN docto.""Tipodoctoid"" = 25 THEN pa.""Clave""
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[21::bigint, 201::bigint])
                THEN cliente.""Clave""
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[11::bigint, 12::bigint,
                202::bigint]) THEN proveedor.""Clave""
            ELSE COALESCE(cliente.""Clave"", proveedor.""Clave"")
        END AS personaclave,
        CASE
            WHEN docto.""Tipodoctoid"" = 25 THEN ''::character varying
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[21::bigint, 201::bigint])
                THEN cliente.""Razonsocial""
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[11::bigint, 12::bigint,
                202::bigint]) THEN proveedor.""Razonsocial""
            ELSE COALESCE(cliente.""Razonsocial"", proveedor.""Razonsocial"")
        END AS personarazonsocial,
        CASE
            WHEN docto.""Tipodoctoid"" = 25 THEN ''::character varying
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[21::bigint, 201::bigint])
                THEN cliente.""Rfc""
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[11::bigint, 12::bigint,
                202::bigint]) THEN proveedor.""Rfc""
            ELSE COALESCE(cliente.""Rfc"", proveedor.""Rfc"")
        END AS personarfc,
        CASE
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[11::bigint, 41::bigint]) THEN
                sumarizado.subtotal
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[201::bigint, 202::bigint])
                THEN dip.""Totalanticipo""
            ELSE docto.""Subtotal""
        END AS subtotal,
        CASE
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[11::bigint, 41::bigint]) THEN
                sumarizado.iva
            ELSE docto.""Iva""
        END AS iva,
        CASE
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[11::bigint, 41::bigint]) THEN
                COALESCE(sumarizado.subtotal, 0::numeric) + COALESCE(sumarizado.iva, 0::numeric) + COALESCE(sumarizado.ieps, 0::numeric)
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[201::bigint, 202::bigint])
                THEN dip.""Totalanticipo""
            ELSE docto.""Total""
        END AS total,
    sumarizado.descuentovale,
    '    '::character varying(100) AS total_con_letra,
    docto.""Descuento"" AS descuento,
    COALESCE(dp_sumarizado.cambioefectivo, 0::numeric) +
        COALESCE(dpe_sumarizado.cambioefectivo, 0::numeric) AS cambio,
    caja.""Nombre"" AS caja,
    COALESCE(dp_sumarizado.importeefectivo, 0::numeric) *
        CASE
            WHEN td.""Sentidopago"" = 1 THEN 1
            ELSE '-1'::integer
        END::numeric + COALESCE(dpe_sumarizado.importeefectivo, 0.00) *
        CASE
            WHEN td.""Sentidopago"" = 1 THEN '-1'::integer
            ELSE 1
        END::numeric AS pagoefectivo,
    COALESCE(dp_sumarizado.recibidoefectivo, 0::numeric) *
        CASE
            WHEN td.""Sentidopago"" = 1 THEN 1
            ELSE '-1'::integer
        END::numeric + COALESCE(dpe_sumarizado.recibidoefectivo, 0.00) *
        CASE
            WHEN td.""Sentidopago"" = 1 THEN '-1'::integer
            ELSE 1
        END::numeric AS efectivorecibido,
    COALESCE(dp_sumarizado.cambioefectivo, 0::numeric) *
        CASE
            WHEN td.""Sentidopago"" = 1 THEN 1
            ELSE '-1'::integer
        END::numeric + COALESCE(dpe_sumarizado.cambioefectivo, 0.00) *
        CASE
            WHEN td.""Sentidopago"" = 1 THEN '-1'::integer
            ELSE 1
        END::numeric AS efectivocambio,
    COALESCE(dp_sumarizado.importetarjeta, 0::numeric) *
        CASE
            WHEN td.""Sentidopago"" = 1 THEN 1
            ELSE '-1'::integer
        END::numeric + COALESCE(dpe_sumarizado.importetarjeta, 0.00) *
        CASE
            WHEN td.""Sentidopago"" = 1 THEN '-1'::integer
            ELSE 1
        END::numeric AS pagotarjeta,
    COALESCE(dp_sumarizado.importecredito, 0::numeric) *
        CASE
            WHEN td.""Sentidopago"" = 1 THEN 1
            ELSE '-1'::integer
        END::numeric + COALESCE(dpe_sumarizado.importecredito, 0.00) *
        CASE
            WHEN td.""Sentidopago"" = 1 THEN '-1'::integer
            ELSE 1
        END::numeric AS pagocredito,
    COALESCE(dp_sumarizado.importecheque, 0::numeric) *
        CASE
            WHEN td.""Sentidopago"" = 1 THEN 1
            ELSE '-1'::integer
        END::numeric + COALESCE(dpe_sumarizado.importecheque, 0.00) *
        CASE
            WHEN td.""Sentidopago"" = 1 THEN '-1'::integer
            ELSE 1
        END::numeric AS pagocheque,
    COALESCE(dp_sumarizado.importevale, 0::numeric) *
        CASE
            WHEN td.""Sentidopago"" = 1 THEN 1
            ELSE '-1'::integer
        END::numeric + COALESCE(dpe_sumarizado.importevale, 0.00) *
        CASE
            WHEN td.""Sentidopago"" = 1 THEN '-1'::integer
            ELSE 1
        END::numeric AS pagovale,
    COALESCE(dp_sumarizado.importemonedero, 0::numeric) *
        CASE
            WHEN td.""Sentidopago"" = 1 THEN 1
            ELSE '-1'::integer
        END::numeric + COALESCE(dpe_sumarizado.importemonedero, 0.00) *
        CASE
            WHEN td.""Sentidopago"" = 1 THEN '-1'::integer
            ELSE 1
        END::numeric AS pagomonedero,
    COALESCE(dp_sumarizado.importetransferencia, 0::numeric) *
        CASE
            WHEN td.""Sentidopago"" = 1 THEN 1
            ELSE '-1'::integer
        END::numeric + COALESCE(dpe_sumarizado.importetransferencia, 0.00) *
        CASE
            WHEN td.""Sentidopago"" = 1 THEN '-1'::integer
            ELSE 1
        END::numeric AS pagotransferencia,
    COALESCE(dp_sumarizado.importenoidentificado, 0::numeric) *
        CASE
            WHEN td.""Sentidopago"" = 1 THEN 1
            ELSE '-1'::integer
        END::numeric + COALESCE(dpe_sumarizado.importenoidentificado, 0.00) *
        CASE
            WHEN td.""Sentidopago"" = 1 THEN '-1'::integer
            ELSE 1
        END::numeric AS pagonoidentificado,
    docto.""Abono"" AS abono,
    docto.""Saldo"" AS saldo,
    dm.""Abonomonedero"" AS abonomonedero,
    monedero.""Saldo"" AS saldomonedero,
    monedero.""Vigencia"" AS vigenciamonedero,
    dm.""Monedero"" AS monederoid,
        CASE
            WHEN docto.""Tipodoctoid"" = 21 THEN replace(COALESCE(p.""Footer"",
                ''::character varying)::text, '[nombreVendedor]'::text, v.""Nombre""::text)
            WHEN docto.""Tipodoctoid"" = 25 THEN p.""Footerventaapartado""::text
            ELSE NULL::text
        END AS customfooter,
        CASE
            WHEN dt.""Sucursaltid"" IS NOT NULL THEN sucursal_fe_t.""Entregacalle""
            ELSE sucursal_fe.""Entregacalle""
        END AS entregacalle,
        CASE
            WHEN dt.""Sucursaltid"" IS NOT NULL THEN sucursal_fe_t.""Entreganumeroexterior""
            ELSE sucursal_fe.""Entreganumeroexterior""
        END AS entreganumeroexterior,
        CASE
            WHEN dt.""Sucursaltid"" IS NOT NULL THEN sucursal_fe_t.""Entreganumerointerior""
            ELSE sucursal_fe.""Entreganumerointerior""
        END AS entreganumerointerior,
        CASE
            WHEN dt.""Sucursaltid"" IS NOT NULL THEN sucursal_fe_t.""Entregacolonia""
            ELSE sucursal_fe.""Entregacolonia""
        END AS entregacolonia,
        CASE
            WHEN dt.""Sucursaltid"" IS NOT NULL THEN sucursal_fe_t.""Entregamunicipio""
            ELSE sucursal_fe.""Entregamunicipio""
        END AS entregamunicipio,
        CASE
            WHEN dt.""Sucursaltid"" IS NOT NULL THEN sucursal_fe_t_estado.""Nombre""
            ELSE sucursal_fe_estado.""Nombre""
        END AS entregaestado,
        CASE
            WHEN dt.""Sucursaltid"" IS NOT NULL THEN sucursal_fe_t.""Entregacodigopostal""
            ELSE sucursal_fe.""Entregacodigopostal""
        END AS entregacodigopostal,
        CASE
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[11::bigint, 41::bigint]) THEN
                sumarizado.ieps
            ELSE docto.""Ieps""
        END AS ieps,
        CASE
            WHEN docto.""Tipodoctoid"" = ANY (ARRAY[11::bigint, 41::bigint]) THEN
                sumarizado.impuesto
            ELSE COALESCE(docto.""Ieps"", 0.00) + COALESCE(docto.""Iva"", 0.00)
        END AS impuesto,
    docto.""Referencias"" AS referencias,
    dc.""Fechafactura"" AS fechafactura,
    COALESCE(dip.""Notapago"", ''::character varying) AS notapago,
    plazo.""Nombre"" AS plazo,
    COALESCE(docto.""Fechavence"", docto.""Fecha"" + COALESCE(plazo.""Dias"",
        0)::double precision * '1 day'::interval) AS vence,
    dre.""Montorebaja"" AS montorebaja,
    dre.""Totalconrebaja"" AS totalconrebaja,
    pa.""Nombres"" AS personaauxnombres,
    pa.""Apellidos"" AS personaauxapellidos,
    pa_domicilio.""Calle"" AS personaauxdomicilio,
    pa_domicilio.""Colonia"" AS personaauxcolonia,
    pa_domicilio.""Ciudad"" AS personaauxciudad,
    pa_domicilio.""Municipio"" AS personaauxmunicipio,
    pa_domicilio.""Estado"" AS personaauxestado,
    pa_domicilio.""Pais"" AS personaauxpais,
    pa_domicilio.""Codigopostal"" AS personaauxcodigopostal,
    pa.""Telefono1"" AS personaauxtelefono1,
    pa.""Celular"" AS personaauxcelular,
    pa.""Email1"" AS personaauxemail1,
    COALESCE(da.""Personaapartadoid"", 0::bigint) AS personaapartadoid,
    empresa.""Fax"" AS fax,
    sumarizado.montorebajaautorizada,
        CASE
            WHEN docto.""Subtipodoctoid"" = ANY (ARRAY[15::bigint, 16::bigint])
                THEN COALESCE(docto.""Referencia"", ''::character varying)
            ELSE ''::character varying
        END AS notamovil1,
        CASE
            WHEN docto.""Subtipodoctoid"" = ANY (ARRAY[15::bigint, 16::bigint])
                THEN COALESCE(docto.""Referencias"", ''::character varying)
            ELSE ''::character varying
        END AS notamovil2,
    p.""Fact_elect_folder""::text ||
        '\facturaelectronica\IMG\logofarmafree.png'::text AS logoimage,
    docto.""Tipodoctoid"" AS tipodoctoid,
    COALESCE(re.""Clave"", ''::character varying) AS rutaembarqueclave,
    COALESCE(re.""Nombre"", ''::character varying) AS rutaembarquenombre,
    doc.""Ordencompra"" AS ordencompra,
    docto.""Fechahora"" AS fechahora,
    COALESCE(docto.""Total"", 0::numeric) - COALESCE(docto.""Iva"", 0::numeric) AS
        totalsiniva,
    clientevendedor.""UsuarioNombre"" AS vendedorclienteclave,
    clientevendedor.""Nombre"" AS vendedorclientenombre,
    docto.""Subtipodoctoid"" AS subtipodoctoid,
    COALESCE(docto.""Tipodiferenciainventarioid"", 0::bigint) AS
        tipodiferenciainventarioid,
    tipodiferenciainv.""Clave"" AS tipodiferenciainventarioclave,
    tipodiferenciainv.""Nombre"" AS tipodiferenciainventarionombre,
    tipodiferenciainv.""Descripcion"" AS tipodiferenciainventariodescripcion,
    dfe.""Timbradouuid"" AS timbradouuid,
    dfe.""Timbradofecha"" AS timbradofecha,
    dfe.""Timbradocertsat"" AS timbradocertsat,
    dfe.""Timbradosellosat"" AS timbradosellosat,
    dfe.""Timbradosellocfdi"" AS timbradosellocfdi,
    dfe.""Timbradocancelado"" AS timbradocancelado,
    dfe.""Timbradouuidcancelacion"" AS timbradouuidcancelacion,
    dfe.""Timbradoformapagosat"" AS timbradoformapagosat,
    dfe.""Esfacturaelectronica"" AS esfacturaelectronica,
    dfe.""Timbradofechacancelacion"" AS timbradofechacancelacion,
    dfe.""Timbradofechafactura"" AS timbradofechafactura,
    dfe.""Fechafactura"" AS dfe_fechafactura,
    dfe.""Foliosat"" AS foliosat,
    dfe.""Seriesat"" AS seriesat,
    dfe.""Sat_usocfdiid"" AS sat_usocfdiid,
    sat_usocfdi.""Sat_clave"" AS sat_usocfdiclave,
    sat_usocfdi.""Sat_descripcion"" AS sat_usocfdidescripcion,
    dfe.""Ivaretenido"" AS ivaretenido,
    dfe.""Isrretenido"" AS isrretenido
FROM ""Docto"" docto
     LEFT JOIN ""Sucursal_info"" sucursal ON sucursal.""EmpresaId"" =
         docto.""EmpresaId"" AND sucursal.""SucursalId"" = docto.""SucursalId"" AND sucursal.""Id"" = docto.""Sucursal_id""
     LEFT JOIN ""Sucursal_info_opciones"" sucursal_op ON sucursal_op.""EmpresaId""
         = docto.""EmpresaId"" AND sucursal_op.""SucursalId"" = docto.""SucursalId"" AND sucursal_op.""Id"" = sucursal.""Id""
     LEFT JOIN ""Sucursal_fact_elect"" sucursal_fe ON sucursal_fe.""EmpresaId"" =
         docto.""EmpresaId"" AND sucursal_fe.""SucursalId"" = docto.""SucursalId"" AND sucursal_fe.""Sucursal_info_opciones_id"" = sucursal_op.""Id""
     LEFT JOIN ""Estadopais"" sucursal_fe_estado ON sucursal_fe_estado.""Id"" =
         sucursal_fe.""Entregaestadoid""
     LEFT JOIN ""Parametro"" p ON p.""EmpresaId"" = docto.""EmpresaId"" AND
         p.""SucursalId"" = docto.""SucursalId""
     LEFT JOIN ""Empresa"" empresa ON empresa.""Id"" = docto.""EmpresaId""
     LEFT JOIN ""Usuario"" v ON v.""EmpresaId"" = docto.""EmpresaId"" AND
         v.""SucursalId"" = docto.""SucursalId"" AND v.""Id"" = docto.""Usuarioid""
     LEFT JOIN ""Docto_devolucion"" dd ON dd.""EmpresaId"" = docto.""EmpresaId"" AND
         dd.""SucursalId"" = docto.""SucursalId"" AND dd.""Doctoid"" = docto.""Id""
     LEFT JOIN ""Docto"" doctoref ON doctoref.""EmpresaId"" = docto.""EmpresaId"" AND
         doctoref.""SucursalId"" = docto.""SucursalId"" AND doctoref.""Id"" = dd.""Doctorefid""
     LEFT JOIN ""Docto_traslado"" dt ON dt.""EmpresaId"" = docto.""EmpresaId"" AND
         dt.""SucursalId"" = docto.""SucursalId"" AND dt.""Doctoid"" = docto.""Id""
     LEFT JOIN ""Sucursal_info"" sucursaltraslado ON sucursaltraslado.""EmpresaId""
         = docto.""EmpresaId"" AND sucursaltraslado.""SucursalId"" = docto.""SucursalId"" AND sucursaltraslado.""Id"" = dt.""Sucursaltid""
     LEFT JOIN ""Sucursal_info_opciones"" sucursal_op_t ON
         sucursal_op_t.""EmpresaId"" = docto.""EmpresaId"" AND sucursal_op_t.""SucursalId"" = docto.""SucursalId"" AND sucursal_op_t.""Id"" = sucursaltraslado.""Id""
     LEFT JOIN ""Sucursal_fact_elect"" sucursal_fe_t ON sucursal_fe_t.""EmpresaId""
         = docto.""EmpresaId"" AND sucursal_fe_t.""SucursalId"" = docto.""SucursalId"" AND sucursal_fe_t.""Sucursal_info_opciones_id"" = sucursal_op_t.""Id""
     LEFT JOIN ""Estadopais"" sucursal_fe_t_estado ON sucursal_fe_t_estado.""Id"" =
         sucursal_fe_t.""Entregaestadoid""
     LEFT JOIN ""Almacen"" almacen ON almacen.""EmpresaId"" = docto.""EmpresaId"" AND
         almacen.""SucursalId"" = docto.""SucursalId"" AND almacen.""Id"" = docto.""Almacenid""
     LEFT JOIN ""Almacen"" almacentraspaso ON almacentraspaso.""EmpresaId"" =
         docto.""EmpresaId"" AND almacentraspaso.""SucursalId"" = docto.""SucursalId"" AND almacentraspaso.""Id"" = dt.""Almacentid""
     LEFT JOIN ""Caja"" caja ON caja.""EmpresaId"" = docto.""EmpresaId"" AND
         caja.""SucursalId"" = docto.""SucursalId"" AND docto.""Cajaid"" = caja.""Id""
     LEFT JOIN ""Docto_monedero"" dm ON dm.""EmpresaId"" = docto.""EmpresaId"" AND
         dm.""SucursalId"" = docto.""SucursalId"" AND dm.""Doctoid"" = docto.""Id""
     LEFT JOIN ""Monedero"" monedero ON monedero.""EmpresaId"" = docto.""EmpresaId""
         AND monedero.""SucursalId"" = docto.""SucursalId"" AND monedero.""Id"" = dm.""Monedero""
     LEFT JOIN ""Cliente"" cliente ON cliente.""EmpresaId"" = docto.""EmpresaId"" AND
         cliente.""SucursalId"" = docto.""SucursalId"" AND cliente.""Id"" = docto.""Clienteid""
     LEFT JOIN ""Cliente_comision"" clientecomision ON
         clientecomision.""EmpresaId"" = docto.""EmpresaId"" AND cliente.""SucursalId"" = docto.""SucursalId"" AND clientecomision.""Clienteid"" = cliente.""Id""
     LEFT JOIN ""Usuario"" clientevendedor ON clientevendedor.""EmpresaId"" =
         docto.""EmpresaId"" AND clientevendedor.""SucursalId"" = docto.""SucursalId"" AND clientevendedor.""Id"" = clientecomision.""Vendedorid""
     LEFT JOIN ""Domicilio"" cliente_domicilio ON cliente_domicilio.""EmpresaId"" =
         docto.""EmpresaId"" AND cliente_domicilio.""SucursalId"" = docto.""SucursalId"" AND cliente_domicilio.""Id"" = cliente.""Domicilioid""
     LEFT JOIN ""Proveedor"" proveedor ON proveedor.""EmpresaId"" =
         docto.""EmpresaId"" AND proveedor.""SucursalId"" = docto.""SucursalId"" AND proveedor.""Id"" = docto.""Clienteid""
     LEFT JOIN ""Domicilio"" proveedor_domicilio ON
         proveedor_domicilio.""EmpresaId"" = docto.""EmpresaId"" AND proveedor_domicilio.""SucursalId"" = docto.""SucursalId"" AND proveedor_domicilio.""Id"" = proveedor.""Domicilioid""
     LEFT JOIN ""Docto_apartado"" da ON da.""EmpresaId"" = docto.""EmpresaId"" AND
         da.""SucursalId"" = docto.""SucursalId"" AND da.""Doctoid"" = docto.""Id""
     LEFT JOIN ""Personaapartado"" pa ON pa.""EmpresaId"" = docto.""EmpresaId"" AND
         pa.""SucursalId"" = docto.""SucursalId"" AND pa.""Id"" = da.""Personaapartadoid""
     LEFT JOIN ""Domicilio"" pa_domicilio ON pa_domicilio.""EmpresaId"" =
         docto.""EmpresaId"" AND pa_domicilio.""SucursalId"" = docto.""SucursalId"" AND pa_domicilio.""Id"" = pa.""Domicilioid""
     LEFT JOIN ""Tipodiferenciainventario"" tipodiferenciainv ON
         tipodiferenciainv.""Id"" = docto.""Tipodiferenciainventarioid""
     LEFT JOIN ""Docto_compra"" dc ON dc.""EmpresaId"" = docto.""EmpresaId"" AND
         dc.""SucursalId"" = docto.""SucursalId"" AND dc.""Doctoid"" = docto.""Id""
     LEFT JOIN ""Docto_ordencompra"" doc ON doc.""EmpresaId"" = docto.""EmpresaId""
         AND doc.""SucursalId"" = docto.""SucursalId"" AND doc.""Doctoid"" = docto.""Id""
     LEFT JOIN ""Docto_info_pago"" dip ON dip.""EmpresaId"" = docto.""EmpresaId"" AND
         dip.""SucursalId"" = docto.""SucursalId"" AND dip.""Doctoid"" = docto.""Id""
     LEFT JOIN ""Docto_poliza"" dpl ON dpl.""EmpresaId"" = docto.""EmpresaId"" AND
         dpl.""SucursalId"" = docto.""SucursalId"" AND dpl.""Doctoid"" = docto.""Id""
     LEFT JOIN ""Plazo"" plazo ON plazo.""EmpresaId"" = docto.""EmpresaId"" AND
         plazo.""SucursalId"" = docto.""SucursalId"" AND plazo.""Id"" = dpl.""Plazoid""
     LEFT JOIN ""Docto_rebajaespecial"" dre ON dre.""EmpresaId"" =
         docto.""EmpresaId"" AND dre.""SucursalId"" = docto.""SucursalId"" AND dre.""Doctoid"" = docto.""Id""
     LEFT JOIN ""Tipodocto"" td ON td.""Id"" = docto.""Tipodoctoid""
     LEFT JOIN ""Docto_rutaembarque"" drb ON drb.""EmpresaId"" = docto.""EmpresaId""
         AND drb.""SucursalId"" = docto.""SucursalId"" AND drb.""Doctoid"" = docto.""Id""
     LEFT JOIN ""Rutaembarque"" re ON re.""EmpresaId"" = docto.""EmpresaId"" AND
         re.""SucursalId"" = docto.""SucursalId"" AND re.""Id"" = drb.""Rutaembarqueid""
     LEFT JOIN (
    SELECT movto.""EmpresaId"",
            movto.""SucursalId"",
            movto.""Doctoid"",
            sum(
                CASE
                    WHEN (docto_1.""Tipodoctoid"" = 41 OR docto_1.""Tipodoctoid"" =
                        11 AND COALESCE(docto_1.""Subtipodoctoid"", 0::bigint) = 23) AND COALESCE(movto.""Cantidad"", 0::numeric) > 0::numeric THEN round(COALESCE(movto.""Subtotal"", 0::numeric) * (COALESCE(md.""Cantidadsurtida"", 0::numeric) / COALESCE(movto.""Cantidad"", 1::numeric)), 2)
                    ELSE COALESCE(movto.""Subtotal"", 0::numeric)
                END) AS subtotal,
            sum(
                CASE
                    WHEN (docto_1.""Tipodoctoid"" = 41 OR docto_1.""Tipodoctoid"" =
                        11 AND COALESCE(docto_1.""Subtipodoctoid"", 0::bigint) = 23) AND COALESCE(movto.""Cantidad"", 0::numeric) > 0::numeric THEN round(COALESCE(movto.""Iva"", 0::numeric) * (COALESCE(md.""Cantidadsurtida"", 0::numeric) / COALESCE(movto.""Cantidad"", 1::numeric)), 2)
                    ELSE COALESCE(movto.""Iva"", 0::numeric)
                END) AS iva,
            sum(
                CASE
                    WHEN (docto_1.""Tipodoctoid"" = 41 OR docto_1.""Tipodoctoid"" =
                        11 AND COALESCE(docto_1.""Subtipodoctoid"", 0::bigint) = 23) AND COALESCE(movto.""Cantidad"", 0::numeric) > 0::numeric THEN round(COALESCE(movto.""Total"", 0::numeric) * (COALESCE(md.""Cantidadsurtida"", 0::numeric) / COALESCE(movto.""Cantidad"", 1::numeric)), 2)
                    ELSE COALESCE(movto.""Total"", 0::numeric)
                END) AS total,
            sum(
                CASE
                    WHEN (docto_1.""Tipodoctoid"" = 41 OR docto_1.""Tipodoctoid"" =
                        11 AND COALESCE(docto_1.""Subtipodoctoid"", 0::bigint) = 23) AND COALESCE(movto.""Cantidad"", 0::numeric) > 0::numeric THEN round(COALESCE(md.""Cantidadsurtida"", 0::numeric), 2)
                    ELSE COALESCE(movto.""Cantidad"", 0::numeric)
                END) AS numeropiezas,
            sum(
                CASE
                    WHEN (docto_1.""Tipodoctoid"" = 41 OR docto_1.""Tipodoctoid"" =
                        11 AND COALESCE(docto_1.""Subtipodoctoid"", 0::bigint) = 23) AND COALESCE(movto.""Cantidad"", 0::numeric) > 0::numeric THEN round(COALESCE(mp.""Descuentovale"", 0::numeric) * (COALESCE(md.""Cantidadsurtida"", 0::numeric) / COALESCE(movto.""Cantidad"", 1::numeric)), 2)
                    ELSE COALESCE(mp.""Descuentovale"", 0::numeric)
                END) AS descuentovale,
            sum(
                CASE
                    WHEN (docto_1.""Tipodoctoid"" = 41 OR docto_1.""Tipodoctoid"" =
                        11 AND COALESCE(docto_1.""Subtipodoctoid"", 0::bigint) = 23) AND COALESCE(movto.""Cantidad"", 0::numeric) > 0::numeric THEN round(COALESCE(movto.""Ieps"", 0::numeric) * (COALESCE(md.""Cantidadsurtida"", 0::numeric) / COALESCE(movto.""Cantidad"", 1::numeric)), 2)
                    ELSE COALESCE(movto.""Ieps"", 0::numeric)
                END) AS ieps,
            sum(
                CASE
                    WHEN (docto_1.""Tipodoctoid"" = 41 OR docto_1.""Tipodoctoid"" =
                        11 AND COALESCE(docto_1.""Subtipodoctoid"", 0::bigint) = 23) AND COALESCE(movto.""Cantidad"", 0::numeric) > 0::numeric THEN round((COALESCE(movto.""Ieps"", 0::numeric) + COALESCE(movto.""Iva"", 0::numeric)) * (COALESCE(md.""Cantidadsurtida"", 0::numeric) / COALESCE(movto.""Cantidad"", 1::numeric)), 2)
                    ELSE COALESCE(movto.""Ieps"", 0::numeric) +
                        COALESCE(movto.""Iva"", 0::numeric)
                END) AS impuesto,
            sum(
                CASE
                    WHEN COALESCE(mr.""Estadorebaja"", 0::bigint) = 2 THEN
                        COALESCE(mr.""Montorebaja"", 0::numeric)
                    ELSE 0::numeric
                END) AS montorebajaautorizada
    FROM ""Movto"" movto
             LEFT JOIN ""Docto"" docto_1 ON movto.""EmpresaId"" =
                 docto_1.""EmpresaId"" AND movto.""SucursalId"" = docto_1.""SucursalId"" AND docto_1.""Id"" = movto.""Doctoid""
             LEFT JOIN ""Movto_devolucion"" md ON md.""EmpresaId"" =
                 docto_1.""EmpresaId"" AND md.""SucursalId"" = docto_1.""SucursalId"" AND movto.""Id"" = md.""Movtoid""
             LEFT JOIN ""Movto_precio"" mp ON mp.""EmpresaId"" =
                 docto_1.""EmpresaId"" AND mp.""SucursalId"" = docto_1.""SucursalId"" AND movto.""Id"" = mp.""Movtoid""
             LEFT JOIN ""Movto_rebajaespecial"" mr ON mr.""EmpresaId"" =
                 docto_1.""EmpresaId"" AND mr.""SucursalId"" = docto_1.""SucursalId"" AND movto.""Id"" = mr.""Movtoid""
    GROUP BY movto.""EmpresaId"", movto.""SucursalId"", movto.""Doctoid""
    ) sumarizado ON sumarizado.""EmpresaId"" = docto.""EmpresaId"" AND
        sumarizado.""SucursalId"" = docto.""SucursalId"" AND docto.""Id"" = sumarizado.""Doctoid""
     LEFT JOIN (
    SELECT dp.""EmpresaId"",
            dp.""SucursalId"",
            dp.""Doctoid"",
            sum(
                CASE
                    WHEN pago.""Formapagoid"" = 1 THEN COALESCE(dp.""Importe"", 0.00)
                    ELSE 0.00
                END) AS importeefectivo,
            sum(
                CASE
                    WHEN pago.""Formapagoid"" = 1 THEN
                        COALESCE(pago.""Importecambio"", 0.00)
                    ELSE 0.00
                END) AS cambioefectivo,
            sum(
                CASE
                    WHEN pago.""Formapagoid"" = 1 THEN
                        COALESCE(pago.""Importerecibido"", 0.00)
                    ELSE 0.00
                END) AS recibidoefectivo,
            sum(
                CASE
                    WHEN pago.""Formapagoid"" = 2 THEN COALESCE(dp.""Importe"", 0.00)
                    ELSE 0.00
                END) AS importetarjeta,
            sum(
                CASE
                    WHEN pago.""Formapagoid"" = 3 THEN COALESCE(dp.""Importe"", 0.00)
                    ELSE 0.00
                END) AS importecheque,
            sum(
                CASE
                    WHEN pago.""Formapagoid"" = 4 THEN COALESCE(dp.""Importe"", 0.00)
                    ELSE 0.00
                END) AS importecredito,
            sum(
                CASE
                    WHEN pago.""Formapagoid"" = 5 THEN COALESCE(dp.""Importe"", 0.00)
                    ELSE 0.00
                END) AS importevale,
            sum(
                CASE
                    WHEN pago.""Formapagoid"" = 14 THEN COALESCE(dp.""Importe"", 0.00)
                    ELSE 0.00
                END) AS importemonedero,
            sum(
                CASE
                    WHEN pago.""Formapagoid"" = 15 THEN COALESCE(dp.""Importe"", 0.00)
                    ELSE 0.00
                END) AS importetransferencia,
            sum(
                CASE
                    WHEN pago.""Formapagoid"" = 16 THEN COALESCE(dp.""Importe"", 0.00)
                    ELSE 0.00
                END) AS importenoidentificado
    FROM ""Doctopago"" dp
             LEFT JOIN ""Pago"" pago ON dp.""EmpresaId"" = pago.""EmpresaId"" AND
                 dp.""SucursalId"" = pago.""SucursalId"" AND dp.""Pagoid"" = pago.""Id""
    WHERE COALESCE(pago.""Revertido"", 'N'::bpchar) <> 'S'::bpchar AND dp.""Tipopagoid"" = 1
    GROUP BY dp.""EmpresaId"", dp.""SucursalId"", dp.""Doctoid""
    ) dp_sumarizado ON dp_sumarizado.""EmpresaId"" = docto.""EmpresaId"" AND
        dp_sumarizado.""SucursalId"" = docto.""SucursalId"" AND docto.""Id"" = dp_sumarizado.""Doctoid""
     LEFT JOIN (
    SELECT dp.""EmpresaId"",
            dp.""SucursalId"",
            dp.""Doctoid"",
            sum(
                CASE
                    WHEN pago.""Formapagoid"" = 1 THEN COALESCE(dp.""Importe"", 0.00)
                    ELSE 0.00
                END) AS importeefectivo,
            sum(
                CASE
                    WHEN pago.""Formapagoid"" = 1 THEN
                        COALESCE(pago.""Importecambio"", 0.00)
                    ELSE 0.00
                END) AS cambioefectivo,
            sum(
                CASE
                    WHEN pago.""Formapagoid"" = 1 THEN
                        COALESCE(pago.""Importerecibido"", 0.00)
                    ELSE 0.00
                END) AS recibidoefectivo,
            sum(
                CASE
                    WHEN pago.""Formapagoid"" = 2 THEN COALESCE(dp.""Importe"", 0.00)
                    ELSE 0.00
                END) AS importetarjeta,
            sum(
                CASE
                    WHEN pago.""Formapagoid"" = 3 THEN COALESCE(dp.""Importe"", 0.00)
                    ELSE 0.00
                END) AS importecheque,
            sum(
                CASE
                    WHEN pago.""Formapagoid"" = 4 THEN COALESCE(dp.""Importe"", 0.00)
                    ELSE 0.00
                END) AS importecredito,
            sum(
                CASE
                    WHEN pago.""Formapagoid"" = 5 THEN COALESCE(dp.""Importe"", 0.00)
                    ELSE 0.00
                END) AS importevale,
            sum(
                CASE
                    WHEN pago.""Formapagoid"" = 14 THEN COALESCE(dp.""Importe"", 0.00)
                    ELSE 0.00
                END) AS importemonedero,
            sum(
                CASE
                    WHEN pago.""Formapagoid"" = 15 THEN COALESCE(dp.""Importe"", 0.00)
                    ELSE 0.00
                END) AS importetransferencia,
            sum(
                CASE
                    WHEN pago.""Formapagoid"" = 16 THEN COALESCE(dp.""Importe"", 0.00)
                    ELSE 0.00
                END) AS importenoidentificado
    FROM ""Doctopago"" dp
             LEFT JOIN ""Pago"" pago ON dp.""EmpresaId"" = pago.""EmpresaId"" AND
                 dp.""SucursalId"" = pago.""SucursalId"" AND dp.""Pagoid"" = pago.""Id""
    WHERE COALESCE(pago.""Revertido"", 'N'::bpchar) <> 'S'::bpchar AND dp.""Tipopagoid"" = 2
    GROUP BY dp.""EmpresaId"", dp.""SucursalId"", dp.""Doctoid""
    ) dpe_sumarizado ON dpe_sumarizado.""EmpresaId"" = docto.""EmpresaId"" AND
        dpe_sumarizado.""SucursalId"" = docto.""SucursalId"" AND docto.""Id"" = dpe_sumarizado.""Doctoid""
     LEFT JOIN ""Docto_fact_elect"" dfe ON dfe.""EmpresaId"" = docto.""EmpresaId""
         AND dfe.""SucursalId"" = docto.""SucursalId"" AND dfe.""Doctoid"" = docto.""Id""
     LEFT JOIN ""Sat_usocfdi"" sat_usocfdi ON sat_usocfdi.""Id"" = dfe.""Sat_usocfdiid"";
";
        }

        public static string View_recibo_sumatorias()
        {
            return $@"CREATE  OR REPLACE VIEW public.recibo_sumatorias (
    empresaid,
    sucursalid,
    doctoid,
    kilogramos,
    cajas,
    piezas,
    total)
AS
SELECT docto.""EmpresaId"" AS empresaid,
    docto.""SucursalId"" AS sucursalid,
    docto.""Id"" AS doctoid,
    sum(
        CASE
            WHEN punidad.""Clave""::text = 'KG'::text THEN movto.""Cantidad""::numeric(18,3)
            ELSE 0.00
        END) AS kilogramos,
    sum(
        CASE
            WHEN punidad.""Clave""::text = 'KG'::text THEN 0.00
            WHEN COALESCE(pinv.""Pzacaja"", 0::numeric) = 0::numeric OR
                COALESCE(pinv.""Pzacaja"", 0::numeric) = 1::numeric THEN 0.00
            ELSE floor(COALESCE(movto.""Cantidad"", 0::numeric) /
                COALESCE(pinv.""Pzacaja"", 1::numeric))
        END) AS cajas,
    sum(
        CASE
            WHEN punidad.""Clave""::text = 'KG'::text THEN 0.00
            WHEN COALESCE(pinv.""Pzacaja"", 0::numeric) = 0::numeric OR
                COALESCE(pinv.""Pzacaja"", 0::numeric) = 1::numeric THEN COALESCE(movto.""Cantidad"", 0::numeric)
            ELSE COALESCE(movto.""Cantidad"", 0::numeric) %
                COALESCE(pinv.""Pzacaja"", 1::numeric)
        END) AS piezas,
    sum(COALESCE(movto.""Total"", 0.00)) AS total
FROM ""Docto"" docto
     LEFT JOIN ""Movto"" movto ON movto.""EmpresaId"" = docto.""EmpresaId"" AND
         movto.""SucursalId"" = docto.""SucursalId"" AND docto.""Id"" = movto.""Doctoid""
     LEFT JOIN ""Producto"" producto ON producto.""EmpresaId"" = docto.""EmpresaId""
         AND producto.""SucursalId"" = docto.""SucursalId"" AND producto.""Id"" = movto.""Productoid""
     LEFT JOIN ""Unidad"" punidad ON punidad.""EmpresaId"" = docto.""EmpresaId"" AND
         punidad.""SucursalId"" = docto.""SucursalId"" AND punidad.""Id"" = producto.""Unidadid""
     LEFT JOIN ""Producto_inventario"" pinv ON pinv.""EmpresaId"" =
         docto.""EmpresaId"" AND pinv.""SucursalId"" = docto.""SucursalId"" AND pinv.""Id"" = producto.""Unidadid""
     LEFT JOIN ""Parametro"" parametro ON parametro.""EmpresaId"" =
         docto.""EmpresaId"" AND parametro.""SucursalId"" = docto.""SucursalId""
GROUP BY docto.""EmpresaId"", docto.""SucursalId"", docto.""Id"";";
        }


        public static string Function_cfdi_impuestos_agrupados()
        {
            return $@"CREATE OR REPLACE FUNCTION public.cfdi_impuestos_agrupados (
  empresa_id bigint,
  sucursal_id bigint,
  docto_id bigint,
  tipocomprobante varchar,
  out tasa_iva numeric,
  out iva numeric,
  out ieps_01_importe numeric,
  out ieps_01_porc numeric,
  out ieps_02_importe numeric,
  out ieps_02_porc numeric,
  out ieps_03_importe numeric,
  out ieps_03_porc numeric,
  out ieps_04_importe numeric,
  out ieps_04_porc numeric,
  out ieps_05_importe numeric,
  out ieps_05_porc numeric,
  out ieps_06_importe numeric,
  out ieps_06_porc numeric,
  out ieps_07_importe numeric,
  out ieps_07_porc numeric,
  out ieps_08_importe numeric,
  out ieps_08_porc numeric,
  out ieps_09_importe numeric,
  out ieps_09_porc numeric,
  out ieps_10_importe numeric,
  out ieps_10_porc numeric,
  out ivaretenido numeric,
  out isrretenido numeric
)
RETURNS record AS
$body$
declare  ieps_importe numeric(20,4);
declare  cuenta integer;
declare  cfdiid bigint;
declare  ieps_x_porc numeric(18,6);


declare imp_cursor CURSOR FOR
        select cfdi_imp.""Tasa"" ieps_x_porc , sum(cfdi_imp.""Importe"") ieps_x_importe
     	from ""Cfdi_imp"" cfdi_imp
     	where 
     	cfdi_imp.""EmpresaId"" = empresa_id  and cfdi_imp.""SucursalId"" = sucursal_id and  
     	cfdi_imp.""Tipolinea"" = 'COMPROBANTE_IEPS' and cfdi_imp.""Cfdiid"" = cfdiid
     	group by cfdi_imp.""Tasa""
     	order by ieps_x_importe desc;
    
		imp_record RECORD;

begin

   cuenta = 1;

    tasa_iva = 0;
    iva = 0;
    
    ieps_01_porc  = -1;
    ieps_02_porc  = -1;
    ieps_03_porc  = -1;
    ieps_04_porc  = -1;
    ieps_05_porc  = -1;
    ieps_06_porc  = -1;
    ieps_07_porc  = -1;
    ieps_08_porc  = -1;
    ieps_09_porc  = -1;
    ieps_10_porc  = -1;
                        
    ieps_01_importe  = 0;
    ieps_02_importe  = 0;
    ieps_03_importe  = 0;
    ieps_04_importe  = 0;
    ieps_05_importe  = 0;
    ieps_06_importe  = 0;
    ieps_07_importe  = 0;
    ieps_08_importe  = 0;
    ieps_09_importe  = 0;
    ieps_10_importe  = 0;
    
    ivaretenido = 0;
    isrretenido = 0;

  
  
    
    select cfdi.""Id"" from ""Cfdi"" cfdi
         where cfdi.""EmpresaId"" = empresa_id  and cfdi.""SucursalId"" = sucursal_id and cfdi.""Doctoid"" = docto_id  and
          ( coalesce(tipocomprobante, '') = cfdi.""Tipocomprobante"" or
            (coalesce(tipocomprobante,'') <> 'T' and coalesce(cfdi.""Tipocomprobante"",'') in  ('I','E','P') ) )
    limit 1 
    into cfdiid;


    select sum(cfdi_imp.""Importe"") importe
    from ""Cfdi_imp"" cfdi_imp
    where cfdi_imp.""EmpresaId"" = empresa_id  and cfdi_imp.""SucursalId"" = sucursal_id and  
          cfdi_imp.""Tipolinea"" = 'COMPROBANTE_ISRRETENIDO'  and cfdi_imp.""Cfdiid"" = cfdiid
    into isrretenido;
    
    
    select sum(cfdi_imp.""Importe"") importe
    from ""Cfdi_imp"" cfdi_imp
    where cfdi_imp.""EmpresaId"" = empresa_id  and cfdi_imp.""SucursalId"" = sucursal_id and  
          cfdi_imp.""Tipolinea"" = 'COMPROBANTE_IVARETENIDO'  and cfdi_imp.""Cfdiid"" = cfdiid
    into ivaretenido;
    
    
    select cfdi_imp.""Tasa"" tasa, sum(cfdi_imp.""Importe"") importe
    from ""Cfdi_imp"" cfdi_imp
    where cfdi_imp.""EmpresaId"" = empresa_id  and cfdi_imp.""SucursalId"" = sucursal_id and  
          cfdi_imp.""Tipolinea"" = 'COMPROBANTE_IVA'  and cfdi_imp.""Cfdiid"" = cfdiid
    group by cfdi_imp.""Tasa""
    limit 1
    into tasa_iva, iva;


    -- Open cursor
    OPEN imp_cursor;

    -- Fetch rows and return
    LOOP
        FETCH NEXT FROM imp_cursor INTO imp_record;
        EXIT WHEN NOT FOUND;

        if(cuenta = 1 ) then
            ieps_01_porc =  imp_record.ieps_x_porc;   
            ieps_01_importe = imp_record.ieps_x_importe;
        end if;    
        if(cuenta = 2 ) then
            ieps_02_porc =  imp_record.ieps_x_porc; 
            ieps_02_importe = imp_record.ieps_x_importe;
        end if;       
        if(cuenta = 3 ) then
            ieps_03_porc =  imp_record.ieps_x_porc; 
            ieps_03_importe = imp_record.ieps_x_importe;
        end if;
        if(cuenta = 4 ) then
            ieps_04_porc =  imp_record.ieps_x_porc;
            ieps_04_importe = imp_record.ieps_x_importe;
        end if; 
        if(cuenta = 5 ) then
            ieps_05_porc =  imp_record.ieps_x_porc;
            ieps_05_importe = imp_record.ieps_x_importe;
        end if;
        if(cuenta = 6 ) then
            ieps_06_porc =  imp_record.ieps_x_porc;
            ieps_06_importe = imp_record.ieps_x_importe;
        end if;
        if(cuenta = 7 ) then
            ieps_07_porc =  imp_record.ieps_x_porc; 
            ieps_07_importe = imp_record.ieps_x_importe;
        end if;
        if(cuenta = 8 ) then
            ieps_08_porc =  imp_record.ieps_x_porc; 
            ieps_08_importe = imp_record.ieps_x_importe;
        end if;
        if(cuenta = 9 ) then
            ieps_09_porc =  imp_record.ieps_x_porc; 
            ieps_09_importe = imp_record.ieps_x_importe;
        end if; 
        if(cuenta = 10 ) then
            ieps_10_porc =  imp_record.ieps_x_porc;
            ieps_10_importe = imp_record.ieps_x_importe;
        end if;
        cuenta = cuenta + 1;
        
        
        
    END LOOP;

    -- Close cursor
    CLOSE imp_cursor;





end;
$body$
LANGUAGE 'plpgsql'
VOLATILE
CALLED ON NULL INPUT
SECURITY INVOKER
COST 100;";
        }

        public static string Function_cfdi_impuestos_agrupados_movto()
        {
            return $@"CREATE OR REPLACE FUNCTION public.cfdi_impuestos_agrupados_movto (
  empresa_id bigint,
  sucursal_id bigint,
  docto_id bigint,
  tipocomprobante varchar
)
RETURNS TABLE (
  movto_id bigint,
  tasa_iva numeric,
  iva numeric,
  ieps_01_importe numeric,
  ieps_01_porc numeric,
  ieps_02_importe numeric,
  ieps_02_porc numeric,
  ieps_03_importe numeric,
  ieps_03_porc numeric,
  ieps_04_importe numeric,
  ieps_04_porc numeric,
  ieps_05_importe numeric,
  ieps_05_porc numeric,
  ieps_06_importe numeric,
  ieps_06_porc numeric,
  ieps_07_importe numeric,
  ieps_07_porc numeric,
  ieps_08_importe numeric,
  ieps_08_porc numeric,
  ieps_09_importe numeric,
  ieps_09_porc numeric,
  ieps_10_importe numeric,
  ieps_10_porc numeric,
  ivaretenido numeric,
  isrretenido numeric
) AS
$body$
declare  ieps_importe numeric(20,4);
declare  cuenta integer;
declare  cfdiid bigint;
declare  ieps_x_porc numeric(18,6);

declare cfdi_conc_id bigint;


declare imp_cursor CURSOR FOR
        select cfdi_conc.""Movtoid"" movtoid, 
            cfdi_conc_imp.""Tipolinea"" tipolinea,
        	cfdi_conc_imp.""Tasa"" imp_x_porc , 
            sum(cfdi_conc_imp.""Importe"") imp_x_importe
     	from 
           ""Cfdi"" cfdi 
           left join ""Cfdi_conc"" cfdi_conc on cfdi.""EmpresaId"" = cfdi_conc.""EmpresaId"" and 
        						cfdi.""SucursalId"" = cfdi_conc.""SucursalId"" and
                                cfdi_conc.""Cfdiid"" = cfdi.""Id""
           left join ""Cfdi_conc_imp"" cfdi_conc_imp on cfdi.""EmpresaId"" = cfdi_conc_imp.""EmpresaId"" and 
        						cfdi.""SucursalId"" = cfdi_conc_imp.""SucursalId"" and
                                cfdi_conc_imp.""Cfdi_conc_id"" = cfdi_conc.""Id""
        
     	where 
     	cfdi.""EmpresaId"" = empresa_id  and cfdi.""SucursalId"" = sucursal_id and  
     	(cfdi_conc_imp.""Tipolinea"" = 'CONCEPTO_IEPS' or cfdi_conc_imp.""Tipolinea"" = 'CONCEPTO_IVA' ) and 
        cfdi.""Id"" = cfdiid
     	group by ""cfdi_conc"".""Movtoid"",cfdi_conc_imp.""Tipolinea"", cfdi_conc_imp.""Tasa""
     	order by movtoid, tipolinea, imp_x_porc, imp_x_importe desc;
    
		imp_record RECORD;
        
        

begin

   cuenta = 1;

    tasa_iva = 0;
    iva = 0;
    
    movto_id = -1;
    ieps_01_porc  = -1;
    ieps_02_porc  = -1;
    ieps_03_porc  = -1;
    ieps_04_porc  = -1;
    ieps_05_porc  = -1;
    ieps_06_porc  = -1;
    ieps_07_porc  = -1;
    ieps_08_porc  = -1;
    ieps_09_porc  = -1;
    ieps_10_porc  = -1;
                        
    ieps_01_importe  = 0;
    ieps_02_importe  = 0;
    ieps_03_importe  = 0;
    ieps_04_importe  = 0;
    ieps_05_importe  = 0;
    ieps_06_importe  = 0;
    ieps_07_importe  = 0;
    ieps_08_importe  = 0;
    ieps_09_importe  = 0;
    ieps_10_importe  = 0;
    
    
    select cfdi.""Id"" from ""Cfdi"" cfdi
         where cfdi.""EmpresaId"" = empresa_id  and cfdi.""SucursalId"" = sucursal_id and cfdi.""Doctoid"" = docto_id  and
          ( coalesce(tipocomprobante, '') = cfdi.""Tipocomprobante"" or
            (coalesce(tipocomprobante,'') <> 'T' and coalesce(cfdi.""Tipocomprobante"",'') in  ('I','E','P') ) )
    limit 1 
    into cfdiid;


            RAISE NOTICE 'Cfdiid (%)', cfdiid;
    

        -- Open cursor
        OPEN imp_cursor;

        -- Fetch rows and return
        LOOP
            FETCH NEXT FROM imp_cursor INTO imp_record;
            EXIT WHEN NOT FOUND;
            
            RAISE NOTICE 'Movtoid (%)', imp_record.movtoid;
            
            if(movto_id <> imp_record.movtoid) then
            
            	if(movto_id <> -1) then
                	return next;
                end if;
                
            	cuenta = 1;

    			tasa_iva = 0;
    			iva = 0;
    
    			movto_id = -1;
    			ieps_01_porc  = -1;
    			ieps_02_porc  = -1;
    			ieps_03_porc  = -1;
    			ieps_04_porc  = -1;
    			ieps_05_porc  = -1;
    			ieps_06_porc  = -1;
    			ieps_07_porc  = -1;
    			ieps_08_porc  = -1;
    			ieps_09_porc  = -1;
    			ieps_10_porc  = -1;
                        
    			ieps_01_importe  = 0;
    			ieps_02_importe  = 0;
    			ieps_03_importe  = 0;
    			ieps_04_importe  = 0;
    			ieps_05_importe  = 0;
    			ieps_06_importe  = 0;
    			ieps_07_importe  = 0;
    			ieps_08_importe  = 0;
    			ieps_09_importe  = 0;
    			ieps_10_importe  = 0;
                
                movto_id = imp_record.movtoid;
            end if;
            
            if(imp_record.tipolinea = 'CONCEPTO_IVA' ) then
               tasa_iva = imp_record.imp_x_porc;
               iva = imp_record.imp_x_importe;
            elsif(imp_record.tipolinea = 'CONCEPTO_IEPS') then
            
            
            	if(cuenta = 1 ) then
                	ieps_01_porc =  imp_record.imp_x_porc;   
                	ieps_01_importe = imp_record.imp_x_importe;
           	 	end if;    
            	if(cuenta = 2 ) then
                	ieps_02_porc =  imp_record.imp_x_porc; 
                	ieps_02_importe = imp_record.imp_x_importe;
            	end if;       
            	if(cuenta = 3 ) then
                	ieps_03_porc =  imp_record.imp_x_porc; 
                	ieps_03_importe = imp_record.imp_x_importe;
            	end if;
            	if(cuenta = 4 ) then
                	ieps_04_porc =  imp_record.imp_x_porc;
                	ieps_04_importe = imp_record.imp_x_importe;
            	end if; 
            	if(cuenta = 5 ) then
                	ieps_05_porc =  imp_record.imp_x_porc;
                	ieps_05_importe = imp_record.imp_x_importe;
            	end if;
            	if(cuenta = 6 ) then
                	ieps_06_porc =  imp_record.imp_x_porc;
                	ieps_06_importe = imp_record.imp_x_importe;
            	end if;
            	if(cuenta = 7 ) then
                	ieps_07_porc =  imp_record.imp_x_porc; 
                	ieps_07_importe = imp_record.imp_x_importe;
            	end if;
            	if(cuenta = 8 ) then
                	ieps_08_porc =  imp_record.imp_x_porc; 
                	ieps_08_importe = imp_record.imp_x_importe;
            	end if;
            	if(cuenta = 9 ) then
                	ieps_09_porc =  imp_record.imp_x_porc; 
                	ieps_09_importe = imp_record.imp_x_importe;
            	end if; 
            	if(cuenta = 10 ) then
                	ieps_10_porc =  imp_record.imp_x_porc;
                	ieps_10_importe = imp_record.imp_x_importe;
            	end if;
            	cuenta = cuenta + 1;
            
            
            end if;

            
            
            
        END LOOP;

        -- Close cursor
        CLOSE imp_cursor;
        
        if(movto_id <> -1) then
        	return next;
        end if;





end;
$body$
LANGUAGE 'plpgsql'
VOLATILE
CALLED ON NULL INPUT
SECURITY INVOKER
COST 100 ROWS 1000;";
        }

        public static string Function_cfdi_master_aux()
        {
            return $@"CREATE OR REPLACE FUNCTION public.cfdi_master_aux (
  empresa_id bigint,
  sucursal_id bigint,
  docto_id bigint,
  tipocomprobante varchar,
  out tiporecibo varchar,
  out hidedatosentrega varchar,
  out hidectapredial varchar,
  out hideiva0 varchar,
  out hideiva16 varchar,
  out kilogramos numeric,
  out cajas numeric,
  out piezas numeric
)
RETURNS record AS
$body$
declare  cuenta integer;
declare  cuentaiva0 integer;
declare  cuentaiva16 integer;
declare  cuentapredial integer;
declare  cfdiid bigint;
declare  arrendatario varchar(1);

begin

   cuenta = 1;

    tiporecibo = '';
    hidedatosentrega = 'False';
    hidectapredial = 'False';
    hideiva0 = 'False';
    hideiva16 = 'False';
    kilogramos = 0;
    cajas = 0;
    piezas = 0;

  

    select sum(case when coalesce(movto.""Tasaiva"", 0.0) = 0.0 then 1 else 0 end  ) cuentaiva0,
           sum(case when coalesce(movto.""Tasaiva"", 0.0) = 16.0 then 1 else 0 end  ) cuentaiva16
    from ""Movto"" movto 
    where movto.""EmpresaId"" = empresa_id and movto.""SucursalId"" = sucursal_id and 
          movto.""Doctoid"" = docto_id 
    into cuentaiva0, cuentaiva16;
    
    select count(*) cuenta 
    from ""Movto"" movto 
    left join ""Producto"" producto on producto.""EmpresaId"" = movto.""EmpresaId"" and 
               producto.""SucursalId"" = movto.""SucursalId"" and producto.""Id"" = movto.""Productoid""
    left join ""Producto_poliza"" producto_poliza on producto_poliza.""EmpresaId"" = movto.""EmpresaId"" and 
               producto_poliza.""SucursalId"" = movto.""SucursalId"" and producto_poliza.""Productoid"" = producto.""Id""
    where movto.""EmpresaId"" = empresa_id and movto.""SucursalId"" = sucursal_id and 
          movto.""Doctoid"" = docto_id and coalesce(producto_poliza.""Cuentapredial"",'') <> ''
    into cuentapredial;
    
    select parametro.""Arrendatario""
    from ""Parametro"" parametro
    where parametro.""EmpresaId"" = empresa_id and parametro.""SucursalId"" = sucursal_id
    limit 1
    into  arrendatario;
    
    
    if(cuentaiva0 <= 0) then
    	hideiva0 = 'True';
    end if;
    
    
    if(cuentaiva16 <= 0) then
    	hideiva16 = 'True';
    end if;
    
    if(cuentapredial = 0 and coalesce(arrendatario,'N') <> 'S') then
    	tiporecibo = '';
        hidedatosentrega = 'False';
        hidectapredial = 'True';
    elsif(coalesce(arrendatario,'N') = 'S') then
        tiporecibo = 'Recibo arrendatario';
        hidedatosentrega = 'True';
        hidectapredial = 'False';
    elsif(cuentapredial > 0) then
    	tiporecibo = 'Recibo de honorarios';
        hidedatosentrega = 'False';
        hidectapredial = 'True';
    else
    	tiporecibo = '';
        hidedatosentrega = 'False';
        hidectapredial = 'False';
    end if;
    
    
    select 
        sum(case when unidad.""Clave"" = 'KG' then m.""Cantidad"" else 0 end) as kilogramos,
    
    	sum(
         case when unidad.""Clave"" = 'KG' then 0
              else
                floor(COALESCE(m.""Cantidad"", 0.00) / CASE
                                                    WHEN COALESCE(
                                                      productoinv.""Pzacaja"", 1.00) =
                                                      0.00 THEN 1.00
                                                    ELSE COALESCE(
                                                      productoinv.""Pzacaja"", 1.00)
                                                  END)
              end
                                              
           ) AS cajas,
         sum(
         
         case when unidad.""Clave"" = 'KG' then 0
              else
                      COALESCE(m.""Cantidad"", 0.00) % CASE
                                          WHEN COALESCE(productoinv.""Pzacaja"",
                                            1.00) = 0.00 THEN 1.00
                                          ELSE COALESCE(productoinv.""Pzacaja"",
                                            1.00)
                                        END
              end
         ) AS piezas
                                        
     from ""Movto"" m
       LEFT JOIN ""Producto"" producto ON producto.""EmpresaId"" = m.""EmpresaId"" AND
         producto.""SucursalId"" = m.""SucursalId"" AND producto.""Id"" =
         m.""Productoid""
       LEFT JOIN ""Producto_inventario"" productoinv ON productoinv.""EmpresaId"" =
         m.""EmpresaId"" AND productoinv.""SucursalId"" = m.""SucursalId"" AND
         productoinv.""Productoid"" = producto.""Id""
       LEFT JOIN ""Unidad"" unidad ON unidad.""EmpresaId"" = m.""EmpresaId"" AND
         unidad.""SucursalId"" = m.""SucursalId"" AND unidad.""Id"" =
         producto.""Unidadid""
      where m.""EmpresaId"" = empresa_id and m.""SucursalId"" = sucursal_id and 
          m.""Doctoid"" = docto_id 
      into kilogramos, cajas, piezas;
         
    
    
    





end;
$body$
LANGUAGE 'plpgsql'
VOLATILE
CALLED ON NULL INPUT
SECURITY INVOKER
COST 100;";
        }


    }
}
