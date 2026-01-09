CREATE OR ALTER VIEW RECIBO_MASTER(
    DOCTOID,
    HEADERCANCELACION,
    NOMBRESUCURSAL,
    DESCRIPCIONSUCURSAL,
    EMPRESA_RFC,
    EMPRESA_COLONIA,
    EMPRESA_DOMICICIO,
    EMPRESA_NUMEROEXTERIOR,
    EMPRESA_NUMEROINTERIOR,
    EMPRESA_CODIGOPOSTAL,
    EMPRESA_RAZON_SOCIAL,
    EMPRESA_TELEFONO,
    EMPRESA_CIUDAD,
    EMPRESA_ESTADO,
    EMPRESA_MUNICIPIO,
    LUGARDEEXPEDICION,
    FECHADEEXPEDICION,
    CAJERO,
    TICKET,
    TITULO,
    TITULO_PERSONA,
    DOC_REF_HEADER1,
    DOC_REF_HEADER2,
    DOC_REF_HEADER3,
    DOC_REF_HEADER4,
    DOC_REF_HEADER5,
    PERSONANOMBRES,
    PERSONANOMBRE,
    PERSONAAPELLIDOS,
    PERSONADOMICILIO,
    PERSONANUMEROINTERIOR,
    PERSONANUMEROEXTERIOR,
    PERSONACODIGOPOSTAL,
    PERSONACOLONIA,
    PERSONATELEFONO,
    PERSONARAZONSOCIAL,
    PERSONARFC,
    PERSONACIUDAD,
    PERSONAESTADO,
    SUBTOTAL,
    IVA,
    TOTAL,
    DESCUENTOVALE,
    TOTAL_CON_LETRA,
    DESCUENTO,
    CAMBIO,
    CAJA,
    TURNO,
    PAGOEFECTIVO,
    PAGOTARJETA,
    PAGOCREDITO,
    PAGOCHEQUE,
    PAGOVALE,
    ABONO,
    SALDO,
    PAGOMONEDERO,
    ABONOMONEDERO,
    SALDOMONEDERO,
    VIGENCIAMONEDERO,
    MONEDEROID,
    CUSTOMFOOTER,
    APLICADO,
    ENTREGACALLE,
    ENTREGANUMEROEXTERIOR,
    ENTREGANUMEROINTERIOR,
    ENTREGACOLONIA,
    ENTREGAMUNICIPIO,
    ENTREGAESTADO,
    ENTREGACODIGOPOSTAL,
    PAGOTRANSFERENCIA,
    PAGONOIDENTIFICADO,
    IEPS,
    IMPUESTO,
    REFERENCIAS,
    FECHAFACTURA,
    NOTAPAGO)
AS
SELECT
docto.id  ,
case when docto.estatusdoctoid = 2 then cast('Cancelacion' as varchar(20)) else cast('' as varchar(20)) end  as HEADERCANCELACION ,


       SUCURSAL.nombre         NOMBRESUCURSAL,
      SUCURSAL.descripcion    DESCRIPCIONSUCURSAL,
      P.rfc                   EMPRESA_RFC,
      P.colonia               EMPRESA_COLONIA,
      P.calle                 EMPRESA_DOMICICIO,
      p.numeroexterior        EMPRESA_NUMEROEXTERIOR,
      P.numeroINterior        EMPRESA_NUMEROINTERIOR,
      P.cp                    EMPRESA_CODIGOPOSTAL,
      cast('Razon Social' as varchar(20))         EMPRESA_RAZON_SOCIAL,
      P.telefono              EMPRESA_TELEFONO,
      P.localidad             EMPRESA_CIUDAD,
      P.estado                EMPRESA_ESTADO,
      P.localidad             EMPRESA_MUNICIPIO ,
      P.localidad || p.estado lugardeexpedicion,
      docto.fecha             fechadeexpedicion,
      v.nombre                cajero,
      docto.folio             ticket,

      
      CASE WHEN DOCTO.TIPODOCTOID = 41 THEN cast('RECEPCION TRASLADO' as varchar(50))   
     WHEN DOCTO.TIPODOCTOID = 11 THEN cast(('COMPRA'  || (CASE WHEN DOCTO.ORIGENFISCALID = 3 THEN ' DE REMISION'  ELSE ' DE FACTURA' END)) as varchar(50))
     WHEN DOCTO.TIPODOCTOID = 31 THEN cast('TRASLADO' as varchar(50))
     WHEN DOCTO.TIPODOCTOID = 81 THEN cast('TRASPASO A SUCURSAL' as varchar(50))
     WHEN DOCTO.TIPODOCTOID = 12 THEN cast('DEVOLUCION DE COMPRA' as varchar(50))  
     WHEN DOCTO.TIPODOCTOID = 21 THEN (CASE WHEN DOCTO.ESTATUSDOCTOID <> 0 THEN cast('NOTA DE VENTA'as varchar(50)) ELSE cast('COTIZACION'as varchar(50)) END)
     WHEN DOCTO.TIPODOCTOID = 22 THEN cast('NOTA DE CREDITO' as varchar(50))
     WHEN DOCTO.TIPODOCTOID = 25 THEN cast('APARTADO DE MERCANCIA' as varchar(50)) 
     WHEN DOCTO.TIPODOCTOID = 201 THEN cast('ANTICIPO DE CLIENTE' as varchar(50))
     WHEN DOCTO.TIPODOCTOID = 202 THEN cast('ANTICIPO DE PROVEEDOR' as varchar(50))   
     WHEN DOCTO.TIPODOCTOID = 16 THEN cast('ORDEN DE COMPRA' as varchar(50))
     WHEN DOCTO.TIPODOCTOID = 17 THEN cast('RECEPCION DE ORDEN DE COMPRA' as varchar(50))
     ELSE cast('' as varchar(50)) end titulo  ,

           
    cast( CASE WHEN DOCTO.TIPODOCTOID in (21,201) THEN ( CASE WHEN DOCTO.PERSONAID <> 1 THEN 'CLIENTE' ELSE 'VENTA DE MOSTRADOR' END)
          WHEN DOCTO.tipodoctoid = 25 THEN 'CLIENTE APARTADO'
          WHEN DOCTO.TIPODOCTOID IN (11,12,202) THEN 'PROVEEDOR'
          ELSE ''
          END as varchar(50))  TITULO_PERSONA ,

      cast(CASE WHEN DOCTO.TIPODOCTOID = 41 then 'TRASLADO DE SUCURSAL ' ||  SUCURSALTRASLADO.CLAVE
           WHEN DOCTO.TIPODOCTOID IN (31,81) THEN  'TRASLADO A SUCURSAL ' ||  SUCURSALTRASLADO.CLAVE
           WHEN DOCTO.TIPODOCTOID IN (11,12) THEN '# DOCUMENTO ' || DOCTO.referencia
           ELSE '' END as varchar(50)) DOC_REF_HEADER1,

     cast( CASE WHEN DOCTO.TIPODOCTOID = 41 then 'SUCURSAL FUENTE ' ||  SUCURSALTRASLADO.NOMBRE
           WHEN DOCTO.TIPODOCTOID IN (31,81) THEN  'SUCURSAL DESTINO ' ||  SUCURSALTRASLADO.NOMBRE
           WHEN DOCTO.TIPODOCTOID IN (11,12) THEN '# FECHA FACTURA ' || DOCTO.FECHA
           ELSE '' END as varchar(50)) DOC_REF_HEADER2,
           
     cast( CASE WHEN DOCTO.TIPODOCTOID = 12 THEN 'Tipo Doc. ' || (CASE WHEN DOCTO.origenfiscalid <> 2 THEN 'Remision' ELSE 'Factura' END)
           ELSE '' END as varchar(50)) DOC_REF_HEADER3,
               
     cast( CASE WHEN DOCTO.TIPODOCTOID = 12 AND COALESCE(DOCTOREF.folio,0) <> 0 THEN  'Del folio de compra ' || CAST( DOCTOREF.FOLIO AS VARCHAR(20))
           WHEN DOCTO.TIPODOCTOID = 22 AND COALESCE(DOCTOREF.folio,0) <> 0 THEN  'Del folio de venta ' || CAST( DOCTOREF.FOLIO AS VARCHAR(20))
           ELSE '' END as varchar(50)) DOC_REF_HEADER4    ,   

     cast( CASE WHEN DOCTO.TIPODOCTOID in (11,12,21,22) AND P.manejaalmacen = 'S'  THEN  'DEL ALMACEN: ' ||  ALMACEN.NOMBRE
            WHEN DOCTO.TIPODOCTOID in (211) AND P.manejaalmacen = 'S'  THEN  'DEL ALMACEN: ' ||  ALMACEN.NOMBRE || ' AL ALMACEN: ' || ALMACENTRASPASO.NOMBRE
           ELSE '' END as varchar(50)) DOC_REF_HEADER5    ,


     s.nombres personanombres,
       s.nombre  personanombre,
       s.apellidos personaapellidos,
       s.domicilio personadomicilio,
       s.numerointerior personanumerointerior,
       s.numeroexterior personanumeroexterior,
       s.codigopostal personacodigopostal,
       s.colonia  personacolonia,
       s.telefono1 personatelefono,
       s.razonsocial personarazonsocial  ,

                             
       s.rfc   personarfc,
       s.ciudad personaciudad,
       s.estado personaestado,
       
       case when docto.tipodoctoid in (11,41) then sumarizado.subtotal
            when docto.tipodoctoid in (201,202) then docto.totalanticipo
            else docto.subtotal end subtotal,
       case when docto.tipodoctoid in (11,41) then sumarizado.iva else docto.iva end  iva,
       case when docto.tipodoctoid in (11,41) then coalesce(sumarizado.subtotal,0) + coalesce(sumarizado.iva,0)
            when docto.tipodoctoid in (201,202) then docto.totalanticipo else docto.total end  total,
       sumarizado.descuentovale descuentovale,
       cast('    ' as varchar(100)) total_con_letra ,
       docto.descuento ,
       coalesce(pagoEfectivo.importecambio,0) + coalesce(pagoCheque.Importecambio,0) as cambio,
       caja.nombre caja,
       turno.nombre turno,
       pagoEfectivo.Importerecibido pagoefectivo,
       pagoTarjeta.importe pagotarjeta,
       pagoCredito.importe pagocredito,
       pagoCheque.importe pagocheque,
       pagoVale.importe pagovale,
       docto.abono abono,
       docto.saldo saldo ,
       pagoMonedero.importe pagomonedero ,
       DOCTO.ABONOMONEDERO  abonomonedero ,
       MONEDERO.saldo  saldomonedero,
       MONEDERO.vigencia vigenciamonedero,
       DOCTO.MONEDERO    monederoid   ,

       case when docto.tipodoctoid = 21 then p.footer
            when docto.tipodoctoid = 25 then p.footerventaapartado
            end customfooter      ,

      (select aplicado from GET_DOCTO_MONTOTIPOAPLICACION (docto.id)) as aplicado  ,

      case when docto.sucursaltid is not null then suct.entregacalle else s.entregacalle end entregacalle,
      case when  docto.sucursaltid is not null then suct.entreganumeroexterior else s.entreganumeroexterior end entreganumeroexterior,
      case when docto.sucursaltid is not null then suct.entreganumerointerior else s.entreganumerointerior end entreganumerointerior,
      case when docto.sucursaltid is not null then suct.entregacolonia else s.entregacolonia end entregacolonia,
      case when  docto.sucursaltid is not null then suct.entregamunicipio else s.entregamunicipio end entregamunicipio,
      case when  docto.sucursaltid is not null then suct.entregaestado else s.entregaestado end entregaestado,
      case when  docto.sucursaltid is not null then suct.entregacodigopostal else s.entregacodigopostal end entregacodigopostal  ,
       pagoTransferencia.importe,
       pagoNoIdentificado.importe,
       
       case when docto.tipodoctoid in (11,41) then sumarizado.ieps else docto.ieps end  ieps,
       case when docto.tipodoctoid in (11,41) then sumarizado.impuesto else docto.impuesto end  impuesto ,
       docto.referencias     ,
       docto.fechafactura,
       coalesce(docto.notapago ,'')



   FROM DOCTO  LEFT JOIN SUCURSAL ON SUCURSAL.ID = DOCTO.SUCURSALID
        left join parametro P on p.sucursalid = sucursal.id
        left join persona V on V.id = docto.vendedorid
        LEFT JOIN DOCTO DOCTOREF ON DOCTO.doctorefid = DOCTOREF.ID
        LEFT JOIN SUCURSAL SUCURSALTRASLADO ON SUCURSALTRASLADO.ID = DOCTO.SUCURSALTID
        LEFT JOIN ALMACEN  ON ALMACEN.id = DOCTO.almacenid
        LEFT JOIN ALMACEN ALMACENTRASPASO ON ALMACENTRASPASO.ID = DOCTO.ALMACENTID


        
         left join (select doctoid, coalesce(sum(importe),0) importe, coalesce(sum(importecambio),0) importecambio, coalesce(sum(importerecibido),0) importerecibido from doctopago where formapagoid = 1 group by doctoid) pagoEfectivo on docto.id = pagoEfectivo.doctoid
         left join (select doctoid,coalesce(sum(importe),0) importe, coalesce(sum(importecambio),0) importecambio from doctopago where formapagoid = 2 group by doctoid) pagoTarjeta on docto.id = pagoTarjeta.doctoid
         left join (select doctoid, coalesce(sum(importe),0) importe, coalesce(sum(importecambio),0) importecambio from doctopago where formapagoid = 3 group by doctoid) pagoCheque on docto.id = pagoCheque.doctoid
         left join (select doctoid, coalesce(sum(importe),0) importe, coalesce(sum(importecambio),0) importecambio from doctopago where formapagoid = 4 group by doctoid) pagoCredito on docto.id = pagoCredito.doctoid  
         left join (select doctoid, coalesce(sum(importe),0) importe, coalesce(sum(importecambio),0) importecambio from doctopago where formapagoid = 5 group by doctoid) pagoVale on docto.id = pagoVale.doctoid   
         left join (select doctoid, coalesce(sum(importe),0) importe, coalesce(sum(importecambio),0) importecambio from doctopago where formapagoid = 14 group by doctoid) pagoMonedero on docto.id = pagoMonedero.doctoid  
         left join (select doctoid, coalesce(sum(importe),0) importe, coalesce(sum(importecambio),0) importecambio from doctopago where formapagoid = 15 group by doctoid) pagoTransferencia on docto.id = pagoTransferencia.doctoid   
         left join (select doctoid, coalesce(sum(importe),0) importe, coalesce(sum(importecambio),0) importecambio from doctopago where formapagoid = 16 group by doctoid) pagoNoIdentificado on docto.id = pagoNoIdentificado.doctoid
         left join (select movto.doctoid, sum(coalesce(movto.subtotal,0)) subtotal, sum(coalesce(movto.iva,0)) iva, sum(coalesce(movto.total,0)) total, sum(coalesce(movto.cantidad,0)) numeropiezas, sum(coalesce(movto.descuentovale,0)) descuentovale ,  sum(coalesce(movto.ieps,0)) ieps, sum(coalesce(movto.ieps,0)) impuesto from movto group by movto.doctoid) sumarizado on docto.id = sumarizado.doctoid
        left join caja on docto.cajaid = caja.id
        left join turno on docto.turnoid = turno.id  
        left join monedero on monedero.id = docto.monedero

        left join persona s on s.id = docto.personaid
        left join sucursal suct on docto.sucursaltid = suct.id
;