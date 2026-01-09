create or alter procedure TICKET_DETAIL_RECARGAS_PROC (
    IDDOCTO D_FK,
    CREADOPOR_USERID D_FK)
returns (
    NUMERO integer,
    DOCTOID D_FK,
    CANTIDAD D_CANTIDAD,
    DESCRIPCION1 D_STDTEXT_MEDIUM,
    DESCRIPCION2 D_STDTEXT_MEDIUM,
    PRECIO D_PRECIO,
    DESCUENTO D_PRECIO,
    SUBTOTAL D_PRECIO,
    IVA D_PRECIO,
    TOTAL D_PRECIO,
    LOTE D_LOTE,
    FECHAVENCE D_FECHAVENCE,
    FALTANTE D_CANTIDAD,
    CANTIDADSURTIDA D_CANTIDAD,
    CANTIDADNOMINAL D_CANTIDAD,
    IMPORTEDESCUENTO D_PRECIO,
    IMPORTEIVA D_PRECIO,
    DESCUENTOVALE D_PRECIO,
    TIPORECARGA D_CLAVE_NULL,
    PRECIOCONIVA D_PRECIO,
    DESCRIPCION3 varchar(40),
    ES_COMODIN D_BOOLCN,
    TASAIEPS D_PRECIO,
    IMPORTEIEPS D_PRECIO,
    PRECIOMASIEPS D_PRECIO,
    TASAIMPUESTO D_PRECIO,
    IMPORTEIMPUESTO D_PRECIO,
    PRECIOMASIMPUESTO D_PRECIO,
    ESKIT D_BOOLCN,
    MOTIVODEVOLUCION D_DESCRIPCION,
    MOVTOID D_FK,
    EMIDAREQUESTID D_FK,
    EMIDACOMISION D_PRECIO,
    STRPEDIMENTO varchar(1000),
    KITMOVTOID D_FK,
    KITPRODUCTOID D_FK,
    KITPRODCLAVE D_CLAVE_NULL,
    KITPRODNOMBRE D_NOMBRE_NULL,
    KITPRODDESCRIPCION1 D_DESCRIPCION,
    KITCANTIDAD D_CANTIDAD,
    COSTOENDOLAR D_COSTO,
    IMPORTEENDOLAR D_COSTO,
    DESCPZACAJA D_STDTEXT_MEDIUM,
    KILOGRAMOS D_CANTIDAD,
    CAJAS D_CANTIDAD,
    PIEZAS D_CANTIDAD,
    PRODUCTOCLAVE D_CLAVE_NULL,
    PLAZOCLAVE D_CLAVE_NULL,
    EAN D_CLAVE_NULL)
as
BEGIN
   NUMERO = 0;
  
   FOR SELECT
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
        END ) PRECIOCONIMPUESTO  ,
         'N' ESKIT,
         --'N' ESPARTEKIT ,
         ''  MOTIVODEVOLUCION ,

        MOVTO.ID MOVTOID,
        MOVTO.EMIDAREQUESTID ,
       MOVTO.EMIDACOMISION ,

        '' STRPEDIMENTO,
        0 KITMOVTOID,
        0 KITPRODUCTOID,
        '' KITPRODCLAVE,
        '' KITPRODNOMBRE,
        '' KITPRODDESCRIPCION1,
        0.0 KITCANTIDAD ,
        0.0 COSTOENDOLAR,
        0.0 IMPORTEENDOLAR,
        '' DESCPZACAJA      ,

        0.0 KILOGRAMOS,
        0.0 CAJAS ,
        0.0 PIEZAS ,
        PRODUCTO.CLAVE PRODUCTOCLAVE ,
        PLAZO.CLAVE PLAZOCLAVE ,

        PRODUCTO.EAN

        FROM MOVTO inner join docto on docto.id = movto.doctoid inner JOIN PRODUCTO ON MOVTO.productoid = PRODUCTO.ID  
        inner join linea on linea.id = producto.lineaid
         and (linea.tiporecarga is not null and (linea.tiporecarga = 'SIMPLE' OR linea.tiporecarga = 'MULTIPLE'))
         LEFT JOIN LOTESIMPORTADOS  on LOTESIMPORTADOS.id = movto.loteimportado   
           LEFT JOIN PLAZO ON PRODUCTO.plazoid = PLAZO.ID

         WHERE MOVTO.DOCTOID = :IDDOCTO
   INTO
    :DOCTOID,
    :CANTIDAD,
    :DESCRIPCION1,
    :DESCRIPCION2,
    :PRECIO,
    :DESCUENTO,
    :SUBTOTAL,
    :IVA,
    :TOTAL,
    :LOTE,
    :FECHAVENCE,
    :FALTANTE,
    :CANTIDADSURTIDA,
    :CANTIDADNOMINAL,
    :IMPORTEDESCUENTO,
    :IMPORTEIVA,
    :DESCUENTOVALE,
    :TIPORECARGA,
    :PRECIOCONIVA,
    :DESCRIPCION3,
    :ES_COMODIN,
    :TASAIEPS,

    
    :IMPORTEIEPS ,
    :PRECIOMASIEPS ,
    :TASAIMPUESTO ,
    :IMPORTEIMPUESTO ,
    :PRECIOMASIMPUESTO ,

    :ESKIT,
    --:ESPARTEKIT   ,
    :MOTIVODEVOLUCION  ,

    :MOVTOID,
    :EMIDAREQUESTID  ,
    :EMIDACOMISION ,
    
    :STRPEDIMENTO ,
    :KITMOVTOID ,
    :KITPRODUCTOID ,
    :KITPRODCLAVE ,
    :KITPRODNOMBRE ,
    :KITPRODDESCRIPCION1 ,
    :KITCANTIDAD ,
    :COSTOENDOLAR,
    :IMPORTEENDOLAR,
    :DESCPZACAJA   ,
    :KILOGRAMOS,
    :CAJAS,
    :PIEZAS,
    :PRODUCTOCLAVE  ,
    :PLAZOCLAVE  ,
    :EAN

    --:LOTEIMPORTADO,
    --:PEDIMENTO,
    --:FECHAIMPORTACION,
    --:ADUANA,
    --:TIPOCAMBIOIMPO
   DO
   BEGIN
      NUMERO = :NUMERO + 1;
      SUSPEND;
   END

   if (:numero = 0) then
   begin
      
    NUMERO = 0;
    DOCTOID = 0;
    CANTIDAD = 0.0;
    DESCRIPCION1 = '';
    DESCRIPCION2  = '';
    PRECIO  = 0.0;
    DESCUENTO  = 0.0;
    SUBTOTAL  = 0.0;
    IVA  = 0.0;
    TOTAL  = 0.0;
    LOTE = '';
    FECHAVENCE = CURRENT_DATE;
    FALTANTE  = 0.0;
    CANTIDADSURTIDA  = 0.0;
    CANTIDADNOMINAL  = 0.0;
    IMPORTEDESCUENTO  = 0.0;
    IMPORTEIVA  = 0.0;
    DESCUENTOVALE  = 0.0;
    TIPORECARGA  = '';
    PRECIOCONIVA  = 0.0;
    DESCRIPCION3  = '';
    ES_COMODIN = 'N';
    TASAIEPS  = 0.0;

    IMPORTEIEPS = 0.0;
    PRECIOMASIEPS  = 0.0;
    TASAIMPUESTO = 0.0;
    IMPORTEIMPUESTO  = 0.0;
    PRECIOMASIMPUESTO  = 0.0;


    ESKIT  = 'N';
    --ESPARTEKIT  = 'N';
    MOTIVODEVOLUCION = '';
      -- sin suspend para no regresar renglon falso 
    MOVTOID = 0;
    EMIDAREQUESTID  = 0;   
    EMIDACOMISION = 0;


    STRPEDIMENTO = '';
    KITMOVTOID  = 0;
    KITPRODUCTOID  = 0;
    KITPRODCLAVE  = '';
    KITPRODNOMBRE  = '';
    KITPRODDESCRIPCION1 = '';
    KITCANTIDAD  = 0.0; 
    COSTOENDOLAR = 0.0;
    IMPORTEENDOLAR = 0.0; 
    DESCPZACAJA = ''; 
    KILOGRAMOS = 0.0;
    CAJAS = 0.0;
    PIEZAS = 0.0;
    PRODUCTOCLAVE = '';   
    PLAZOCLAVE = '';
    EAN = '';

   end

END
