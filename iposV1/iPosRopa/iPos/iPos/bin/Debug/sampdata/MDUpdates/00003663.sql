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
    ESPARTEKIT D_BOOLCN,
    MOTIVODEVOLUCION D_DESCRIPCION,
    MOVTOID d_fk,
    EMIDAREQUESTID D_FK)
as
BEGIN
   NUMERO = 0;
  
   FOR SELECT
        MOVTO.doctoid,

        (CASE
         WHEN (docto.tipodoctoid in  (/*11,*/41)) THEN MOVTO.cantidadsurtida
         ELSE MOVTO.cantidad
        END ) cantidad,

        CASE WHEN PRODUCTO.descripcion_comodin = 'S' AND MOVTO.descripcion1 IS NOT NULL AND MOVTO.descripcion1 <> '' THEN MOVTO.DESCRIPCION1 ELSE  PRODUCTO.DESCRIPCION1 END AS DESCRIPCION1,
        CASE WHEN PRODUCTO.descripcion_comodin = 'S' AND MOVTO.descripcion1 IS NOT NULL AND MOVTO.descripcion1 <> '' THEN MOVTO.DESCRIPCION2 ELSE  PRODUCTO.DESCRIPCION2 END AS DESCRIPCION2,

        (CASE
         WHEN (docto.tipodoctoid in  (11,41)) THEN MOVTO.costo
         ELSE MOVTO.precio
        END ) PRECIO,

        MOVTO.descuento,

        (CASE
         WHEN (docto.tipodoctoid in  (/*11,*/41)) THEN MOVTO.costoimporte
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
        MOVTO.IVA IMPORTEIVA ,
        coalesce(MOVTO.DESCUENTOVALE,0) ,
        linea.tiporecarga ,


        (CASE   WHEN (docto.tipodoctoid in  (11,41)) THEN

                        COALESCE(MOVTO.costo,0) * ((100 + coalesce(MOVTO.tasaieps,0)) / 100 ) * ((100 + coalesce(MOVTO.tasaiva,0)) / 100 )
                ELSE
                    COALESCE(MOVTO.precio,0) * ((100 + coalesce(MOVTO.tasaieps,0)) / 100 ) * ((100 + coalesce(MOVTO.tasaiva,0)) / 100 )
                END ) PRECIOCONIVA ,

         
        CASE WHEN PRODUCTO.descripcion_comodin = 'S' AND MOVTO.descripcion1 IS NOT NULL AND MOVTO.descripcion1 <> '' THEN MOVTO.DESCRIPCION3 ELSE  PRODUCTO.DESCRIPCION3 END AS DESCRIPCION3 ,
        coalesce(PRODUCTO.descripcion_comodin,'N') ,
        
        MOVTO.tasaieps,
        MOVTO.IEPS,
        movto.tasaimpuesto,
        movto.impuesto AS IMPUESTO  ,
        CASE WHEN COALESCE(PARAMETRO.manejakits ,'N') = 'S' THEN COALESCE(PRODUCTO.eskit,'N') ELSE 'N' END  ESKIT,
        CASE WHEN COALESCE(PARAMETRO.manejakits ,'N') = 'S' THEN COALESCE(case when mOVTO.doctoid = COALESCE(DOCTO.doctokitrefid,0) then 'S' else 'N' end, 'N')  ELSE 'N' END ESPARTEKIT,

        TIPODIFERENCIAINVENTARIO.nombre  MOTIVODEVOLUCION  ,

        MOVTO.ID MOVTOID,
        MOVTO.EMIDAREQUESTID


        FROM DOCTO
            left join MOVTO ON ( MOVTO.DOCTOID IN (COALESCE(DOCTO.doctokitrefid,0), DOCTO.ID)   )
                left JOIN PRODUCTO ON MOVTO.productoid = PRODUCTO.ID
                    left join linea on linea.id = producto.lineaid
                        left join parametro on 1 = 1
                            left join MOVTO MP  on MP.DOCTOID = :IDDOCTO AND MP.ID = COALESCE(MOVTO.MOVTOREFID,0) AND MOVTO.tipodoctoid = 505 --AND COALESCE(PARAMETRO.manejakits ,'N') = 'S'
                                left join PRODUCTO PP on PP.ID = coalesce(MP.productoid,0)
                                   left join TIPODIFERENCIAINVENTARIO on TIPODIFERENCIAINVENTARIO.id = movto.tipodiferenciainventarioid
              where docto.id = :IDDOCTO
        order by
        case when coalesce(parametro.ordenimpresion,'') = 'DESCRIPCION' then
                    case when MOVTO.doctoid = COALESCE(DOCTO.doctokitrefid,0) then pp.descripcion else PRODUCTO.descripcion end
            when coalesce(parametro.ordenimpresion,'') = 'DESCRIPCION1' then
                    case when MOVTO.doctoid = COALESCE(DOCTO.doctokitrefid,0) then pp.descripcion1 else PRODUCTO.descripcion1 end
            when coalesce(parametro.ordenimpresion,'') = 'DESCRIPCION2' then
                    case when MOVTO.doctoid = COALESCE(DOCTO.doctokitrefid,0) then pp.descripcion2 else PRODUCTO.descripcion2 end
            else case when MOVTO.doctoid = COALESCE(DOCTO.doctokitrefid,0) then mp.orden else MOVTO.orden end
        end,
        case when MOVTO.doctoid = COALESCE(DOCTO.doctokitrefid,0) then mp.orden else MOVTO.orden end,
        case when MOVTO.doctoid = COALESCE(DOCTO.doctokitrefid,0) then mp.partida else MOVTO.partida end    ,
        case when MOVTO.doctoid = COALESCE(DOCTO.doctokitrefid,0) then mp.ID else MOVTO.ID end ,
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
    :ESPARTEKIT ,
    :MOTIVODEVOLUCION     ,

    :MOVTOID,
    :EMIDAREQUESTID
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
    ESPARTEKIT  = 'N';
    MOTIVODEVOLUCION = '';
      -- sin suspend para no regresar renglon falso 
    MOVTOID = 0;
    EMIDAREQUESTID  = 0;
   end

END
