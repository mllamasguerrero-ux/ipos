create or alter procedure TICKET_DETAIL_TRASLADOS_PROC (
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
    PRECIOMASIEPS D_PRECIO,
    TASAIMPUESTO D_PRECIO,
    IMPORTEIMPUESTO D_PRECIO,
    PRECIOMASIMPUESTO D_PRECIO,
    ESKIT D_BOOLCN,
    ESPARTEKIT D_BOOLCN)
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
        (CASE WHEN docto.subtipodoctoid = 6 and  s.mostrarprecioreal = 'N' THEN
                        COALESCE(MOVTO.preciovisibletraslado,0)
                    ELSE
                        COALESCE(MOVTO.costo,0)
                    END
        ) PRECIO,

        /*MOVTO.descuento*/
        (CASE WHEN docto.subtipodoctoid = 6 and  s.mostrarprecioreal = 'N' THEN
                          0
                    ELSE
                        COALESCE(MOVTO.DESCUENTO,0)
                    END
        ),

        (CASE WHEN docto.subtipodoctoid = 6 and  s.mostrarprecioreal = 'N' THEN
                        COALESCE(MOVTO.preciovisibletraslado,0) * COALESCE(MOVTO.CANTIDAD,0)
                    ELSE
                        COALESCE(MOVTO.costo,0) * COALESCE(MOVTO.CANTIDAD,0)
                    END
        ) subtotal,

        PRODUCTO.tasaiva IVA,
        (CASE WHEN docto.subtipodoctoid = 6 and  s.mostrarprecioreal = 'N' THEN
                        COALESCE(MOVTO.preciovisibletraslado,0) * ((100 + coalesce(MOVTO.tasaiva,0)) / 100 ) *  COALESCE(MOVTO.CANTIDAD,0)
                    ELSE
                        COALESCE(MOVTO.costo,0) * ((100 + coalesce(MOVTO.tasaiva,0)) / 100 ) * COALESCE(MOVTO.CANTIDAD,0)
                    END
        ) total,
        MOVTO.lote,
        MOVTO.fechavence ,
        movto.cantidadfaltante ,
        MOVTO.cantidadsurtida  ,
        MOVTO.cantidad ,
        /*movto.IMPORTEDESCUENTO*/ 
        (CASE WHEN docto.subtipodoctoid = 6 and  s.mostrarprecioreal = 'N' THEN
                          0
                    ELSE
                        COALESCE(MOVTO.IMPORTEDESCUENTO,0)
                    END
        ),
        /*MOVTO.IVA*/ 
        (CASE WHEN docto.subtipodoctoid = 6 and  s.mostrarprecioreal = 'N' THEN
                             COALESCE(MOVTO.preciovisibletraslado,0) * (( coalesce(MOVTO.tasaiva,0)) / 100 )  * COALESCE(MOVTO.CANTIDAD,0)
                    ELSE
                        MOVTO.IVA
                    END
        ) IMPORTEIVA ,
        coalesce(MOVTO.DESCUENTOVALE,0) ,
        linea.tiporecarga ,


        (CASE WHEN docto.subtipodoctoid = 6 and  s.mostrarprecioreal = 'N' THEN
                        COALESCE(MOVTO.preciovisibletraslado,0) * ((100 + coalesce(MOVTO.tasaieps,0)) / 100 ) * ((100 + coalesce(MOVTO.tasaiva,0)) / 100 )
                    ELSE
                        COALESCE(MOVTO.costo,0) * ((100 + coalesce(MOVTO.tasaieps,0)) / 100 ) * ((100 + coalesce(MOVTO.tasaiva,0)) / 100 )
                    END
        ) PRECIOCONIVA,  

        '',
        'N' ,

        
        MOVTO.tasaIEPS,
        MOVTO.IEPS, 
        (CASE
         WHEN (docto.tipodoctoid in  (11,41)) THEN COALESCE(MOVTO.costo,0) * ((100 + coalesce(MOVTO.tasaieps,0)) / 100 )
         ELSE COALESCE(MOVTO.precio,0) * ((100 + coalesce(MOVTO.tasaieps,0)) / 100 )
        END ) PRECIOCONIEPS,
        
        MOVTO.tasaIMPUESTO,
        MOVTO.IMPUESTO,
        (CASE
         WHEN (docto.tipodoctoid in  (11,41)) THEN COALESCE(MOVTO.costo,0)  * ((100 + coalesce(MOVTO.tasaieps,0)) / 100 ) * ((100 + coalesce(MOVTO.tasaiva,0)) / 100 )
         ELSE COALESCE(MOVTO.precio,0) * ((100 + coalesce(MOVTO.tasaieps,0)) / 100 ) * ((100 + coalesce(MOVTO.tasaiva,0)) / 100 )
        END ) PRECIOCONIMPUESTO ,   
        CASE WHEN COALESCE(PARAMETRO.manejakits ,'N') = 'S' THEN COALESCE(PRODUCTO.eskit,'N') ELSE 'N' END ESKIT,
        CASE WHEN COALESCE(PARAMETRO.manejakits ,'N') = 'S' THEN COALESCE(case when mOVTO.doctoid = COALESCE(DOCTO.doctokitrefid,0) then 'S' else 'N' end, 'N')  ELSE 'N' END  ESPARTEKIT

        FROM DOCTO
            left join MOVTO ON ( MOVTO.DOCTOID IN (COALESCE(DOCTO.doctokitrefid,0), DOCTO.ID)   )
                left JOIN PRODUCTO ON MOVTO.productoid = PRODUCTO.ID
                    left join linea on linea.id = producto.lineaid
                        left join (select first 1 * FROM parametro) p on 1 = 1
                            left join sucursal s on p.sucursalid = s.id
                                left join parametro on 1 = 1  
                                    left join MOVTO MP  on MP.DOCTOID = :IDDOCTO AND MP.ID = COALESCE(MOVTO.MOVTOREFID,0) AND MP.tipodoctoid = 505 --AND COALESCE(PARAMETRO.manejakits ,'N') = 'S'
                                        left join PRODUCTO PP on PP.ID = coalesce(MP.productoid,0)
        WHERE DOCTO.ID = :IDDOCTO
        order by
        case when coalesce(parametro.ordenimpresion,'') = 'DESCRIPCION' then
                    case when MOVTO.doctoid = COALESCE(DOCTO.doctokitrefid,0) then pp.descripcion else PRODUCTO.descripcion end
            when coalesce(parametro.ordenimpresion,'') = 'DESCRIPCION1' then
                    case when MOVTO.doctoid = COALESCE(DOCTO.doctokitrefid,0) then pp.descripcion1 else PRODUCTO.descripcion1 end
            when coalesce(parametro.ordenimpresion,'') = 'DESCRIPCION2' then
                    case when MOVTO.doctoid = COALESCE(DOCTO.doctokitrefid,0) then pp.descripcion2 else PRODUCTO.descripcion2 end
            else case when MOVTO.doctoid = COALESCE(DOCTO.doctokitrefid,0) then mp.partida else MOVTO.partida end
         end,
        case when MOVTO.doctoid = COALESCE(DOCTO.doctokitrefid,0) then mp.partida else MOVTO.partida end  ,
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

    
    :IMPORTEIEPS ,
    :PRECIOMASIEPS ,
    :TASAIMPUESTO ,
    :IMPORTEIMPUESTO ,
    :PRECIOMASIMPUESTO ,

    :ESKIT,
    :ESPARTEKIT
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
    ESPARTEKIT  = 'N';
      -- sin suspend para no regresar renglon falso
   end

END