create or alter procedure TICKET_DETAIL_PROC (
    IDDOCTO D_FK)
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
    TASAIMPUESTO D_PRECIO,
    IMPUESTO D_PRECIO,
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
    IMPORTEENDOLAR D_COSTO)
as
BEGIN
   NUMERO = 0;
  
   FOR SELECT
        MOVTO.doctoid,

        (CASE
         WHEN (docto.tipodoctoid in  (/*11,*/41)) THEN core.cantidadsurtida
         ELSE core.cantidad
        END ) cantidad,

        CASE WHEN PRODUCTO.descripcion_comodin = 'S' AND MOVTO.descripcion1 IS NOT NULL AND MOVTO.descripcion1 <> '' THEN MOVTO.DESCRIPCION1 ELSE  PRODUCTO.DESCRIPCION1 END AS DESCRIPCION1,
        CASE WHEN PRODUCTO.descripcion_comodin = 'S' AND MOVTO.descripcion1 IS NOT NULL AND MOVTO.descripcion1 <> '' THEN MOVTO.DESCRIPCION2 ELSE  PRODUCTO.DESCRIPCION2 END AS DESCRIPCION2,

        (CASE
         WHEN (docto.tipodoctoid in  (11,41)) THEN MOVTO.costo
         ELSE MOVTO.precio
        END ) PRECIO,

        core.descuento,

        (CASE
         WHEN (docto.tipodoctoid in  (/*11,*/41)) THEN core.costoimporte
         ELSE core.subtotal
         END ) subtotal,

        MOVTO.tasaiva IVA,
        core.total,
        MOVTO.lote,
        MOVTO.fechavence ,
        core.cantidadfaltante ,
        core.cantidadsurtida  ,
        core.cantidad ,
        core.IMPORTEDESCUENTO,
        core.IVA IMPORTEIVA ,
        coalesce(core.DESCUENTOVALE,0) ,
        linea.tiporecarga ,


        (CASE   WHEN (docto.tipodoctoid in  (11,41)) THEN

                        COALESCE(MOVTO.costo,0) * ((100 + coalesce(MOVTO.tasaieps,0)) / 100 ) * ((100 + coalesce(MOVTO.tasaiva,0)) / 100 )
                ELSE
                    COALESCE(MOVTO.precio,0) * ((100 + coalesce(MOVTO.tasaieps,0)) / 100 ) * ((100 + coalesce(MOVTO.tasaiva,0)) / 100 )
                END ) PRECIOCONIVA ,

         
        CASE WHEN PRODUCTO.descripcion_comodin = 'S' AND MOVTO.descripcion1 IS NOT NULL AND MOVTO.descripcion1 <> '' THEN MOVTO.DESCRIPCION3 ELSE  PRODUCTO.DESCRIPCION3 END AS DESCRIPCION3 ,
        coalesce(PRODUCTO.descripcion_comodin,'N') ,
        
        MOVTO.tasaieps,
        CORE.IEPS,
        movto.tasaimpuesto,
        CORE.impuesto AS IMPUESTO  ,
        CASE WHEN COALESCE(PARAMETRO.manejakits ,'N') = 'S' THEN COALESCE(PRODUCTO.eskit,'N') ELSE 'N' END  ESKIT,
        --CASE WHEN COALESCE(PARAMETRO.manejakits ,'N') = 'S' THEN COALESCE(case when mOVTO.doctoid = COALESCE(DOCTO.doctokitrefid,0) then 'S' else 'N' end, 'N')  ELSE 'N' END ESPARTEKIT,

        TIPODIFERENCIAINVENTARIO.nombre  MOTIVODEVOLUCION  ,

        MOVTO.ID MOVTOID,
        MOVTO.EMIDAREQUESTID  ,
       MOVTO.EMIDACOMISION ,
       CORE.STRPEDIMENTO ,
       CORE.KITMOVTOID ,
       CORE.KITPRODUCTOID ,
       PKITREF.CLAVE KITPRODCLAVE,
       PKITREF.NOMBRE KITPRODNOMBRE,
       PKITREF.DESCRIPCION1  KITPRODDESCRIPCION1,
       CORE.KITCANTIDAD,
       CORE.COSTOENDOLAR,
       CORE.IMPORTEENDOLAR


        FROM
         (SELECT * FROM RECIBOS_CORE WHERE DOCTOID = :IDDOCTO) CORE
          LEFT JOIN DOCTO ON ID = CORE.DOCTOID
            left join MOVTO ON MOVTO.DOCTOID = CORE.DOCTOID AND MOVTO.id = CORE.MOVTOID
                left JOIN PRODUCTO ON MOVTO.productoid = PRODUCTO.ID
                    left join linea on linea.id = producto.lineaid
                        left join parametro on 1 = 1
                         LEFT JOIN PRODUCTO PKITREF ON PKITREF.ID = CORE.KITPRODUCTOID
                                   left join TIPODIFERENCIAINVENTARIO on TIPODIFERENCIAINVENTARIO.id = movto.tipodiferenciainventarioid
              where docto.id = :IDDOCTO
        order by
        case when coalesce(parametro.ordenimpresion,'') = 'DESCRIPCION' then  PRODUCTO.descripcion
            when coalesce(parametro.ordenimpresion,'') = 'DESCRIPCION1' then  PRODUCTO.descripcion1
            when coalesce(parametro.ordenimpresion,'') = 'DESCRIPCION2' then PRODUCTO.descripcion2
            else  MOVTO.orden
        end,
         MOVTO.orden ,
         MOVTO.partida     ,
         MOVTO.ID

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
    :IMPORTEIEPS,
    :TASAIMPUESTO,
    :IMPUESTO,
    :ESKIT,
    --:ESPARTEKIT ,
    :MOTIVODEVOLUCION     ,

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
    :IMPORTEENDOLAR

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
    IMPORTEIEPS  = 0.0;
    TASAIMPUESTO  = 0.0;
    IMPUESTO  = 0.0;
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


   end

END