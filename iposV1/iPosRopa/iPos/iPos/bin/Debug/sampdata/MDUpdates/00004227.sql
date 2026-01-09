/* View: TICKET_DETAIL_RECARGAS */
CREATE OR ALTER VIEW TICKET_DETAIL_RECARGAS(
    DOCTOID,
    CANTIDAD,
    DESCRIPCION1,
    DESCRIPCION2,
    PRECIO,
    DESCUENTO,
    SUBTOTAL,
    IVA,
    TOTAL,
    LOTE,
    FECHAVENCE,
    FALTANTE,
    CANTIDADSURTIDA,
    CANTIDADNOMINAL,
    IMPORTEDESCUENTO,
    IMPORTEIVA,
    DESCUENTOVALE,
    TIPORECARGA,
    PRECIOCONIVA,
    DESCRIPCION3,
    ES_COMODIN,
    TASAIEPS,
    IMPORTEIEPS,
    PRECIOMASIEPS,
    TASAIMPUESTO,
    IMPORTEIMPUESTO,
    PRECIOMASIMPUESTO,
    MOVTOID,
    EMIDAREQUESTID,
    LOTEIMPORTADO,
    PEDIMENTO,
    FECHAIMPORTACION,
    ADUANA,
    TIPOCAMBIOIMPO)
AS
SELECT
        MOVTO.doctoid,

        (CASE
         WHEN (docto.tipodoctoid in  (11,41)) THEN MOVTO.cantidadsurtida
         ELSE MOVTO.cantidad
        END ) cantidad,

        PRODUCTO.descripcion1,
        PRODUCTO.descripcion2,
        (CASE
         WHEN (docto.tipodoctoid in  (11,41)) THEN MOVTO.costo
         ELSE MOVTO.precio
        END ) PRECIO,

        MOVTO.descuento,

        (CASE
         WHEN (docto.tipodoctoid in  (11,41)) THEN MOVTO.costoimporte
         ELSE MOVTO.subtotal
         END ) subtotal,

        MOVTO.tasaiva IVA,
        MOVTO.total,
        MOVTO.lote,
        MOVTO.fechavence ,
        movto.cantidadfaltante ,
        MOVTO.cantidadsurtida  ,
        MOVTO.cantidad ,
        movto.IMPORTEDESCUENTO,
        MOVTO.IVA IMPORTEIVA  ,

        coalesce(MOVTO.DESCUENTOVALE,0),
        linea.tiporecarga ,
        (CASE
         WHEN (docto.tipodoctoid in  (11,41)) THEN COALESCE(MOVTO.costo,0) * ((100 + coalesce(MOVTO.tasaieps,0))/100) * ((100 + coalesce(MOVTO.tasaiva,0)) / 100 )
         ELSE COALESCE(MOVTO.precio,0)  * ((100 + coalesce(MOVTO.tasaieps,0))/100) * ((100 + coalesce(MOVTO.tasaiva,0)) / 100 )
        END ) PRECIOCONIVA,

        '',
        'N' ,
        
        MOVTO.tasaIEPS,
        MOVTO.IEPS, 
        (CASE
         WHEN (docto.tipodoctoid in  (11,41)) THEN COALESCE(MOVTO.costo,0) * ((100 + coalesce(MOVTO.tasaieps,0)) / 100 )
         ELSE COALESCE(MOVTO.precio,0) * ((100 + coalesce(MOVTO.tasaieps,0)) / 100 )
        END ) PRECIOCONIEPS,
        
        MOVTO.tasaIMPUESTO,
        (coalesce(movto.IVA,0) + coalesce(movto.ieps,0)) AS IMPUESTO,
        (CASE
         WHEN (docto.tipodoctoid in  (11,41)) THEN COALESCE(MOVTO.costo,0)   * ((100 + coalesce(MOVTO.tasaieps,0))/100) * ((100 + coalesce(MOVTO.tasaiva,0)) / 100 )
         ELSE COALESCE(MOVTO.precio,0)  * ((100 + coalesce(MOVTO.tasaieps,0))/100) * ((100 + coalesce(MOVTO.tasaiva,0)) / 100 )
        END ) PRECIOCONIMPUESTO ,

        MOVTO.ID MOVTOID ,
        MOVTO.EMIDAREQUESTID ,
        MOVTO.LOTEIMPORTADO ,
        LOTESIMPORTADOS.PEDIMENTO,
        LOTESIMPORTADOS.FECHAIMPORTACION,
        LOTESIMPORTADOS.ADUANA,
        LOTESIMPORTADOS.TIPOCAMBIO TIPOCAMBIOIMPO





        FROM MOVTO inner join docto on docto.id = movto.doctoid inner JOIN PRODUCTO ON MOVTO.productoid = PRODUCTO.ID  
        inner join linea on linea.id = producto.lineaid
         and (linea.tiporecarga is not null and (linea.tiporecarga = 'SIMPLE' OR linea.tiporecarga = 'MULTIPLE')) 
        LEFT JOIN LOTESIMPORTADOS  on LOTESIMPORTADOS.id = movto.loteimportado
;



