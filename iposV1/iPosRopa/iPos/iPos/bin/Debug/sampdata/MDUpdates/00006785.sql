CREATE OR ALTER VIEW RECIBOS_CORE(
    DOCTOID,
    DOCTOKITREFID,
    MOVTOID,
    PRODUCTOID,
    LOTE,
    FECHAVENCE,
    PRECIO,
    COSTO,
    TASAIVA,
    TASAIEPS,
    PRECIOLISTA,
    PRECIOVISIBLETRASLADO,
    CANTIDAD,
    CANTIDADSURTIDA,
    CANTIDADFALTANTE,
    CANTIDADDEVUELTA,
    CANTIDADSALDO,
    IVA,
    IEPS,
    IMPUESTO,
    IMPORTE,
    SUBTOTAL,
    TOTAL,
    TOTALCONREBAJA,
    MONTOREBAJA,
    IVARETENIDO,
    ISRRETENIDO,
    DESCUENTO,
    DESCUENTOVALE,
    COSTOIMPORTE,
    IMPORTEDESCUENTO,
    STRPEDIMENTO,
    COSTOENDOLAR,
    IMPORTEENDOLAR,
    DOCTOIMPORTEENDOLAR,
    KITMOVTOID,
    KITPRODUCTOID,
    KITPRECIOLISTA,
    KITPRECIO,
    KITTASAIVA,
    KITTASAIEPS,
    KITTASAIMPUESTO,
    KITIVA,
    KITIEPS,
    KITIMPUESTO,
    KITSUBTOTAL,
    KITTOTAL,
    KITCANTIDAD)
AS
select
basico.doctoid,
basico.doctokitrefid ,
basico.movtoid,
basico.productoid,
basico.lote,
basico.fechavence,
basico.precio,   
basico.costo,
basico.tasaiva,
basico.tasaieps,
basico.preciolista,
basico.preciovisibletraslado,
basico.cantidad,
basico.cantidadsurtida,
basico.cantidadfaltante,
basico.cantidaddevuelta,
basico.cantidadsaldo,
basico.iva,
basico.ieps,
basico.impuesto,
basico.importe,
basico.subtotal,
basico.total,
basico.totalconrebaja,
basico.montorebaja,
basico.ivaretenido,
basico.isrretenido ,
basico.descuento,
basico.descuentovale,
basico.costoimporte,
basico.importedescuento,
basico.strpedimento ,

basico.costoendolar ,
basico.importeendolar ,
basico.doctoimporteendolar ,

 MIN(coalesce(MKITREF.id,PKITREF_BORRADOR.ID)) KITMOVTOID,
 COALESCE(MKITREF.productoid, PKITREF_BORRADOR.ID) KITPRODUCTOID,
 MKITREF.preciolista KITPRECIOLISTA,
 MKITREF.precio KITPRECIO,
 MKITREF.tasaiva KITTASAIVA,
 MKITREF.tasaieps KITTASAIEPS,
 MKITREF.tasaimpuesto KITTASAIMPUESTO,

 SUM(COALESCE(MKITREF.iva,0)) KITIVA,
 SUM(COALESCE(MKITREF.ieps,0)) KITIEPS,  
 SUM(COALESCE(MKITREF.impuesto,0)) KITIMPUESTO,
 SUM(COALESCE(MKITREF.subtotal,0)) KITSUBTOTAL,
 SUM(COALESCE(MKITREF.TOTAL,0)) KITTOTAL,
 SUM(COALESCE(MKITREF.cantidad, cast(COALESCE(MOVTO.CANTIDAD,0) * COALESCE(KITDEFINICION.cantidadparte,0) as d_cantidad)  )) KITCANTIDAD

from
(
    select
    docto.id doctoid,
    DOCTO.doctokitrefid,
    min(movto.id) movtoid,
    movto.productoid,
    movto.lote,
    movto.fechavence,
    movto.precio,
    movto.costo,
    movto.tasaiva,
    movto.tasaieps, 
    movto.preciolista,
    movto.preciovisibletraslado,

    coalesce(MOVTO.cantidad,0) cantidad,
    coalesce(movto.cantidadsurtida,0) cantidadsurtida,
    coalesce(movto.cantidadfaltante,0) cantidadfaltante,
    coalesce(movto.cantidaddevuelta,0) cantidaddevuelta,
    coalesce(movto.cantidadsaldo,0) cantidadsaldo,
    coalesce(movto.iva,0) iva,
    coalesce(movto.ieps,0) ieps,
    coalesce(movto.impuesto,0) impuesto,
    coalesce(movto.importe,0) importe,
    coalesce(movto.subtotal,0) subtotal,
    coalesce(movto.total,0) total,
    coalesce(movto.totalconrebaja,0) totalconrebaja,
    coalesce(movto.montorebaja,0) montorebaja,
    coalesce(movto.ivaretenido,0) ivaretenido,
    coalesce(movto.isrretenido,0) isrretenido ,
    coalesce(movto.descuento,0) descuento ,
    coalesce(movto.descuentovale,0) descuentovale ,
    coalesce(movto.costoimporte,0) costoimporte ,
    coalesce(movto.importedescuento,0) importedescuento ,

    List(distinct (CASE WHEN COALESCE(mlp.LOTEIMPORTADO,0) > 0 THEN ' Ped.: ' || COALESCE(lotesimportados.PEDIMENTO,'') || ' fec.: ' || CAST( coalesce(lotesimportados.FECHAIMPORTACION, current_date) AS VARCHAR(20)) || ' Adu. ' ||  coalesce(sat_aduana.sat_claveaduana || ' ' || sat_ADUANA.sat_descripcion, coalesce( lotesimportados.aduana, ''))  || ' Cant. '  || CAST(CASE WHEN (docto.tipodoctoid in  (41)) THEN coalesce(mlp.cantidadsurtida,0) ELSE coalesce(mlp.cantidad,0) END AS VARCHAR(20)) else '' end)) strpedimento ,

                  
    coalesce(movto.costoendolar,0) costoendolar ,
    coalesce(movto.importeendolar,0) importeendolar ,
    coalesce(docto.importeendolar,0) doctoimporteendolar ,

    docto.estatusdoctoid


    from docto
    left join movto on movto.doctoid = docto.id
    left join movto mlp on mlp.doctoid = coalesce(docto.loteimportadodoctoid, docto.id) and mlp.productoid = movto.productoid  and coalesce(mlp.lote,'') = coalesce(movto.lote,'')
                        --and coalesce(mlp.fechavence, current_date) = coalesce(movto.fechavence, current_date)
                        and mlp.precio = movto.precio
    left join lotesimportados on lotesimportados.id = mlp.loteimportado  
    Left join sat_aduana on lotesimportados.sataduanaid = sat_aduana.id

    group by
    docto.id ,
    DOCTO.doctokitrefid,
    movto.productoid,
    movto.lote,
    movto.fechavence,
    movto.precio,
    movto.tasaiva,
    movto.tasaieps, 
    movto.preciolista  , 
    movto.preciovisibletraslado  ,
    movto.costo  ,

    MOVTO.cantidad,
    movto.cantidadsurtida,
    movto.cantidadfaltante,
    movto.cantidaddevuelta,
    movto.cantidadsaldo,
    movto.iva,
    movto.ieps,
    movto.impuesto,
    movto.importe,
    movto.subtotal,
    movto.total,
    movto.totalconrebaja,
    movto.montorebaja,
    movto.ivaretenido,
    movto.isrretenido ,
    movto.descuento,
    movto.descuentovale,
    movto.costoimporte ,
    movto.importedescuento ,
    
    movto.costoendolar ,
    movto.importeendolar ,
    docto.importeendolar ,
    docto.estatusdoctoid  ,
    movto.descripcion1,
    movto.descripcion2,
    movto.descripcion3


) basico
left join movto on
    movto.doctoid = basico.doctoid and
    movto.productoid = basico.productoid  and
    coalesce(movto.lote,'') = coalesce(basico.lote,'') and
    coalesce(movto.fechavence, current_date) = coalesce(basico.fechavence, current_date) and
    movto.precio = basico.precio and
    movto.tasaiva = basico.tasaiva and
    movto.tasaieps = basico.tasaieps and
    movto.preciolista = basico.preciolista
    
 left join MOVTO MKITREF ON MKITREF.doctoid = COALESCE(basico.doctokitrefid,0) AND MKITREF.movtorefid = MOVTO.ID  AND basico.estatusdoctoid <> 0 --and MKITREF.TIPODOCTOID = 505
 left JOIN PRODUCTO PKITREF ON MKITREF.productoid = PKITREF.ID  AND basico.estatusdoctoid <> 0

 LEFT JOIN KITDEFINICION ON KITDEFINICION.productokitid = MOVTO.PRODUCTOID AND basico.estatusdoctoid = 0
 LEFT JOIN PRODUCTO PKITREF_BORRADOR ON PKITREF_BORRADOR.id = KITDEFINICION.productoparteid AND basico.estatusdoctoid = 0


 GROUP BY
 basico.doctoid,
basico.doctokitrefid ,
basico.movtoid,
basico.productoid,
basico.lote,
basico.fechavence,
basico.precio,
basico.costo,
basico.tasaiva,
basico.tasaieps,
basico.preciolista,
basico.preciovisibletraslado,
basico.cantidad,
basico.cantidadsurtida,
basico.cantidadfaltante,
basico.cantidaddevuelta,
basico.cantidadsaldo,
basico.iva,
basico.ieps,
basico.impuesto,
basico.importe,
basico.subtotal,
basico.total,
basico.totalconrebaja,
basico.montorebaja,
basico.ivaretenido,
basico.isrretenido ,
basico.descuento,
basico.descuentovale,
basico.costoimporte,
basico.importedescuento,
basico.strpedimento ,

basico.costoendolar ,
basico.importeendolar ,
basico.doctoimporteendolar ,

MKITREF.productoid ,
 MKITREF.preciolista ,
 MKITREF.precio ,
 MKITREF.tasaiva ,
 MKITREF.tasaieps ,
 MKITREF.tasaimpuesto  ,
 PKITREF_BORRADOR.ID  ,
 KITDEFINICION.cantidadparte
;