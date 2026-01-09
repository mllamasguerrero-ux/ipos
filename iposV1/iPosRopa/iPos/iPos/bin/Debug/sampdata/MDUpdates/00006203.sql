create or alter procedure REBAJAS_PROMOVIDAS_MOVIL (
    FECHA_PAR D_FECHA,
    PERSONAID_PAR D_FK,
    PRODUCTOID_PAR D_FK,
    MARCAID_PAR D_FK,
    VENDEDORFINAL D_FK,
    DOCTOFILTROID D_FK)
returns (
    NUMERO integer,
    FECHA D_FECHA,
    DOCTOFOLIO D_DOCTOFOLIO,
    PERSONACLAVE D_CLAVE,
    PERSONANOMBRE D_NOMBRE,
    PERSONANOMBRES D_STDTEXT_MEDIUM,
    CAJEROCLAVE D_CLAVE,
    CAJERONOMBRE D_NOMBRE,
    PRODUCTOCLAVE D_CLAVE,
    PRODUCTONOMBRE D_NOMBRE,
    PRODUCTODESCRIPCION D_DESCRIPCION,
    MARCACLAVE D_CLAVE,
    MARCANOMBRE D_NOMBRE,
    CANTIDAD D_CANTIDAD,
    PRECIO_SINIMP_SINREBAJA D_PRECIO,
    PRECIO_CONIMP_SINREBAJA D_PRECIO,
    TOTAL_SINREBAJA D_IMPORTE,
    PRECIO_SINIMP_CONREBAJA D_PRECIO,
    PRECIO_CONIMP_CONREBAJA D_PRECIO,
    TOTALCONREBAJA D_IMPORTE,
    DIFERENCIA D_IMPORTE,
    CANTAUTREBAJA D_CANTIDAD,
    ESTADOREBAJA D_FK,
    DOCTOID D_FK,
    MOVTOID D_FK,
    COSTOCAJA D_PRECIO,
    PRECIOCAJA D_PRECIO,
    MARGEN D_PRECIO,
    DESCPES D_PRECIO,
    UTILIDAD D_PRECIO,
    UTILIDADPORC D_PORCENTAJE,
    COMISION D_PRECIO,
    COMISIONPORC D_PORCENTAJE,
    DESCUENTO D_PRECIO,
    DESCUENTOPORCENTAJE D_PORCENTAJE,
    CAJAS D_CANTIDAD,
    PIEZASSUELTAS D_CANTIDAD,
    NUTIL D_PORCENTAJE,
    PROVEEDORID D_FK,
    PROVEEDORCLAVE D_CLAVE_NULL,
    PROVEEDORNOMBRE D_NOMBRE_NULL,
    PRECIO D_PRECIO,
    PZACAJA D_CANTIDAD,
    ADESCPES D_PORCENTAJE,
    PRECIO1 D_PRECIO,
    POR_COME D_PORCENTAJE,
    COSTOREPOSICION D_PRECIO,
    TASAIVA D_PORCENTAJE,
    TASAIEPS D_PORCENTAJE,
    TASAIMPUESTO D_PORCENTAJE,
    RANGOENCONTRADO D_BOOLCN,
    CDESCR D_PORCENTAJE,
    NPREC D_PORCENTAJE,
    CUENTABUFFER integer,
    COMISIONPORCBUFFER D_PORCENTAJE,
    PRODUCTODESCRIPCION1 D_STDTEXT_MEDIUM,
    PRECIO4 D_PRECIO)
as
declare variable VERSIONCOMISIONID D_FK;
BEGIN
   NUMERO = 0;

    SELECT VERSIONCOMISIONID FROM PARAMETRO INTO :VERSIONCOMISIONID;

   FOR select
        docto.fecha,
        docto.folio,
        persona.clave,
        persona.nombre, 
        persona.nombres,
        cajero.clave,
        cajero.nombre,
        producto.clave, 
        producto.nombre, 
        producto.descripcion, 
        producto.descripcion1,
        marca.clave as marcaclave,
        marca.nombre as marcanombre,
        coalesce(movto.cantidad,0) - coalesce(movto.cantidaddevuelta,0) cantidad,



        coalesce(producto.preciotope,0.00) precio_sinimp_sinrebaja,

         cast( cast(  coalesce(producto.preciotope,0.00) *
                (1.00 + (coalesce(producto.tasaieps,0.00) / 100.00) )
                as d_precio
                    )  *
                (1.00 + (coalesce(producto.tasaiva,0.00) / 100.00) )
                as d_precio
             )  precio_conimp_sinrebaja  ,

          cast( cast( cast(  coalesce(producto.preciotope,0.00) *
                (1.00 + (coalesce(producto.tasaieps,0.00) / 100.00) )
                as d_precio
                    )  *
                (1.00 + (coalesce(producto.tasaiva,0.00) / 100.00) )
                as d_precio
             ) * coalesce(movto.cantidad, 0.00)
                as d_precio
             ) total_sinrebaja,

        movto.precio precio_sinimp_conrebaja,
        movto.total/case when coalesce(movto.cantidad, 0.00) = 0.00 then 1 else coalesce(movto.cantidad, 0.00) end precio_conimp_conrebaja ,
        movto.total totalconrebaja,


        cast( cast( cast(  coalesce(producto.preciotope,0.00) *
                (1.00 + (coalesce(producto.tasaieps,0.00) / 100.00) )
                as d_precio
                    )  *
                (1.00 + (coalesce(producto.tasaiva,0.00) / 100.00) )
                as d_precio
             ) * coalesce(movto.cantidad, 0.00)
                as d_precio
             ) - coalesce(movto.total, 0.00) diferencia ,



        movto.cantautrebaja  ,
        movto.estadorebaja ,
        MOVTO.DOCTOID DOCTOID  ,
        MOVTO.ID  ,
        COALESCE(MOVTO.COSTOREPOSICION,0) * COALESCE(PRODUCTO.PZACAJA,0) COSTOCAJA,
        COALESCE(MOVTO.PRECIO,0) * COALESCE(PRODUCTO.PZACAJA,0) PRECIOCAJA,
        PRODUCTO.MARGEN,
        PRODUCTO.DESCPES,
        MOVTO.UTILIDAD,
        CASE WHEN COALESCE(MOVTO.TOTAL,0) > 0
                THEN COALESCE(MOVTO.UTILIDAD,0) / COALESCE(MOVTO.TOTAL,0)
                ELSE 0
         END UTILIDIDADPORC,
                    
        MOVTO.COMISION,
        MOVTO.COMISIONPORC,
        --MOVTO.DESCUENTO,
        (PRODUCTO.PRECIO1 - MOVTO.PRECIO)  * MOVTO.CANTIDAD  DESCUENTO,
        CASE WHEN PRODUCTO.PRECIO1 > 0.00 THEN (PRODUCTO.PRECIO1 - MOVTO.PRECIO) /  PRODUCTO.PRECIO1 ELSE 0.00 END * 100.00 DESCUENTOPORCENTAJE ,

        
                
        case
                    when PRODUCTO.unidad = 'KG' then
                        0.00
                    when  ( coalesce(PRODUCTO.pzacaja,0) = 0 or  coalesce(PRODUCTO.pzacaja,0) = 1 ) then
                        0.00
                    else
                        trunc(coalesce(     MOVTO.CANTIDAD   ,0)/coalesce(PRODUCTO.pzacaja,1))
                end   CAJAS ,

        case
                    when  PRODUCTO.unidad = 'KG' then
                        0.00
                    when  ( coalesce(PRODUCTO.pzacaja,0) = 0 or  coalesce(PRODUCTO.pzacaja,0) = 1 ) then
                        MOVTO.CANTIDAD
                    else
                        mod(coalesce(    MOVTO.CANTIDAD   ,0),coalesce(PRODUCTO.pzacaja,1))
         end  PIEZASSUELTAS  ,

         COALESCE(MOVTO.NUTIL,0) NUTIL ,
         PROVEEDOR.ID PROVEEDORID,
         COALESCE(PROVEEDOR.CLAVE,'') PROVEEDORCLAVE,
         PROVEEDOR.NOMBRE PROVEEDORNOMBRE ,

         COALESCE(MOVTO.PRECIO, 0.00) PRECIO  ,


         COALESCE(PRODUCTO.PZACAJA,0) PZACAJA,
         COALESCE(PROVEEDOR.ADESCPES,0) ADESCPES,
         COALESCE(PRODUCTO.PRECIO1,0) PRECIO1,
         COALESCE(PERSONA.POR_COME, 0) POR_COME,
         COALESCE(MOVTO.TASAIVA,0.00) TASAIVA ,
         COALESCE(MOVTO.TASAIEPS,0.00) TASAIEPS,
         COALESCE(MOVTO.COSTOREPOSICION, 0.00) COSTOREPOSICION,
         COALESCE(PRODUCTO.PRECIO1,0) PRECIO4



        from docto left join movto on movto.doctoid = docto.id
        left join producto on producto.id = movto.productoid
        left join persona on docto.personaid = persona.id
        left join persona cajero on cajero.id = docto.vendedorid
        left join persona proveedor on producto.proveedor1id = proveedor.id
        left join marca on marca.id = producto.marcaid

        where docto.fecha >= :fecha_par
        and (:personaid_par = 0 or docto.personaid = :personaid_par )
        and (:productoid_par = 0 or movto.productoid = :productoid_par)
        and (:marcaid_par = 0 or producto.marcaid = :marcaid_par)
        and movto.cantidad > 0 and docto.estatusdoctoid = 0 and docto.tipodoctoid = 331
        and coalesce(movto.estadorebaja,0) in (1)
        and (coalesce(:VENDEDORFINAL,0) = 0 or coalesce(docto.vendedorfinal,0) = coalesce(:VENDEDORFINAL,0))
        and docto.id = coalesce(:doctofiltroid,0)

   INTO
      :FECHA ,
      :DOCTOFOLIO ,
      :PERSONACLAVE ,
      :PERSONANOMBRE ,
      :PERSONANOMBRES ,
      :CAJEROCLAVE ,
      :CAJERONOMBRE ,
      :PRODUCTOCLAVE ,
      :PRODUCTONOMBRE ,
      :PRODUCTODESCRIPCION ,  
      :PRODUCTODESCRIPCION1 ,
      :MARCACLAVE ,
      :MARCANOMBRE ,
      :CANTIDAD ,
      :PRECIO_SINIMP_SINREBAJA ,
      :PRECIO_CONIMP_SINREBAJA  ,
      :TOTAL_SINREBAJA ,
      :PRECIO_SINIMP_CONREBAJA ,
      :PRECIO_CONIMP_CONREBAJA  ,
      :TOTALCONREBAJA ,
      :DIFERENCIA ,
      :CANTAUTREBAJA ,
      :ESTADOREBAJA  ,
      :DOCTOID  ,
      :MOVTOID  ,
      :COSTOCAJA ,
      :PRECIOCAJA ,
      :MARGEN ,
      :DESCPES ,
      :UTILIDAD ,
      :UTILIDADPORC ,
      :COMISION ,
      :COMISIONPORC,
      :DESCUENTO ,
      :DESCUENTOPORCENTAJE ,
      :CAJAS ,
      :PIEZASSUELTAS ,
      :NUTIL,
      :PROVEEDORID,
      :PROVEEDORCLAVE,
      :PROVEEDORNOMBRE ,
      :PRECIO,


      :PZACAJA ,
      :ADESCPES ,
      :PRECIO1 ,
      :POR_COME ,
      :TASAIVA  ,
      :TASAIEPS ,
      :COSTOREPOSICION,
      :PRECIO4
   DO
   BEGIN
      NUMERO = :NUMERO + 1;
           
      TASAIMPUESTO =  CAST(COALESCE(:TASAIEPS,0.00) + COALESCE(:TASAIVA,0.00)  + CAST(((COALESCE(:TASAIEPS,0.00) * COALESCE(:TASAIVA,0.00)) / 100.00) AS D_PORCENTAJE) AS D_PORCENTAJE) ;

      NPREC =
                CAST(
                       CAST(  ( COALESCE(:TOTALCONREBAJA,0.00) / CASE WHEN COALESCE(:CANTIDAD, 0.00) = 0.00 THEN 1.00 ELSE :CANTIDAD END)
                            AS D_PRECIO)
                                    * :PZACAJA
                       AS D_PRECIO ) ;

             CDESCR =
                    CAST(
                      CAST(
                            CAST(
                                    COALESCE(:COSTOREPOSICION,0.00)  *
                                    CAST( (1.00 - ((COALESCE(:DESCPES,0) + COALESCE(:ADESCPES,0))/100.00) ) AS D_PRECIO )
                                  AS D_PRECIO)
                                   *  :pzacaja
                            AS D_PRECIO
                       ) *
                        ( 1.00 + :TASAIMPUESTO/100.00)
                        AS D_PRECIO) ;






             NUTIL = CASE WHEN  COALESCE(:NPREC,0.00) > 0 THEN
                           CAST(ROUND(
                                100.00 - ( ( COALESCE(:CDESCR,0.00)/COALESCE(:NPREC,0.00) ) * 100.00)
                                , 2) AS D_PORCENTAJE)
                         ELSE 0.00
                    END;



             RANGOENCONTRADO = 'N';

             IF(COALESCE(:POR_COME,0) > 0) THEN
             BEGIN

                SELECT COUNT(*) CUENTABUFFER, MIN(COALESCE(COMISION_CALC_V2.COMISION,0))  COMISIONPORCBUFFER
                FROM COMISION_CALC_V2
                 WHERE COALESCE(PROVEEDORCLAVE,'') =  COALESCE(:PROVEEDORCLAVE,'')  AND
                       COALESCE(CLIENTEPORCOME,'N') = 'S' AND
                       MARGENMIN <= :NUTIL AND (MARGENMAX > :NUTIL  OR MARGENMAX < 0)
                INTO :CUENTABUFFER, :COMISIONPORCBUFFER;

                IF(COALESCE(:CUENTABUFFER,0) > 0) THEN
                BEGIN 
                    RANGOENCONTRADO = 'S';
                    COMISIONPORC = CASE WHEN COALESCE(:COMISIONPORCBUFFER,0) = -2 THEN COALESCE(:POR_COME,0) ELSE COALESCE(:COMISIONPORCBUFFER,0) END ;

                END


                IF(COALESCE(:RANGOENCONTRADO,'N') = 'N') THEN
                BEGIN
                
                    SELECT COUNT(*) CUENTABUFFER, MIN(COALESCE(COMISION_CALC_V2.COMISION,0))  COMISIONPORCBUFFER
                    FROM COMISION_CALC_V2
                    WHERE COALESCE(PROVEEDORCLAVE,'') = ''  AND
                       COALESCE(CLIENTEPORCOME,'N') = 'S' AND
                       MARGENMIN <= :NUTIL AND (MARGENMAX > :NUTIL  OR MARGENMAX < 0)
                    INTO :CUENTABUFFER, :COMISIONPORCBUFFER;

                    IF(COALESCE(:CUENTABUFFER,0) > 0) THEN
                    BEGIN 
                        RANGOENCONTRADO = 'S';
                        COMISIONPORC = CASE WHEN COALESCE(:COMISIONPORCBUFFER,0) = -2 THEN COALESCE(:POR_COME,0) ELSE COALESCE(:COMISIONPORCBUFFER,0) END ;

                    END
                END


             END



             
             IF(COALESCE(:RANGOENCONTRADO,'N') = 'N') THEN
             BEGIN

                SELECT COUNT(*) CUENTABUFFER, MIN(COALESCE(COMISION_CALC_V2.COMISION,0))  COMISIONPORCBUFFER
                FROM COMISION_CALC_V2
                 WHERE COALESCE(PROVEEDORCLAVE,'') =  COALESCE(:PROVEEDORCLAVE,'')  AND
                       COALESCE(CLIENTEPORCOME,'N') = 'N' AND
                       MARGENMIN <= :NUTIL AND (MARGENMAX > :NUTIL  OR MARGENMAX < 0)
                INTO :CUENTABUFFER, :COMISIONPORCBUFFER;

                IF(COALESCE(:CUENTABUFFER,0) > 0) THEN
                BEGIN 
                    RANGOENCONTRADO = 'S';
                    COMISIONPORC = CASE WHEN COALESCE(:COMISIONPORCBUFFER,0) = -2 THEN COALESCE(:POR_COME,0) ELSE COALESCE(:COMISIONPORCBUFFER,0) END ;

                END


                IF(COALESCE(:RANGOENCONTRADO,'N') = 'N') THEN
                BEGIN
                
                    SELECT COUNT(*) CUENTABUFFER, MIN(COALESCE(COMISION_CALC_V2.COMISION,0))  COMISIONPORCBUFFER
                    FROM COMISION_CALC_V2
                    WHERE COALESCE(PROVEEDORCLAVE,'') = ''  AND
                       COALESCE(CLIENTEPORCOME,'N') = 'N' AND
                       MARGENMIN <= :NUTIL AND (MARGENMAX > :NUTIL  OR MARGENMAX < 0)
                    INTO :CUENTABUFFER, :COMISIONPORCBUFFER;

                    IF(COALESCE(:CUENTABUFFER,0) > 0) THEN
                    BEGIN 
                        RANGOENCONTRADO = 'S';
                        COMISIONPORC = CASE WHEN COALESCE(:COMISIONPORCBUFFER,0) = -2 THEN COALESCE(:POR_COME,0) ELSE COALESCE(:COMISIONPORCBUFFER,0) END ;

                    END
                END
             END



      SUSPEND;
   END

   if (:numero = 0) then
   begin
        FECHA = CURRENT_DATE;
        DOCTOFOLIO  = 0;
        PERSONACLAVE = '';
        PERSONANOMBRE  = '';
        PERSONANOMBRES  = '';
        CAJEROCLAVE  = '';
        CAJERONOMBRE  = '';
        PRODUCTOCLAVE  = '';
        PRODUCTONOMBRE  = '';
        PRODUCTODESCRIPCION  = ''; 
        PRODUCTODESCRIPCION1  = '';
        MARCACLAVE  = '';
        MARCANOMBRE  = '';
        CANTIDAD  = 0;
        PRECIO_SINIMP_SINREBAJA  = 0;
        PRECIO_CONIMP_SINREBAJA  = 0;
        TOTAL_SINREBAJA  = 0;
        PRECIO_SINIMP_CONREBAJA  = 0;
        PRECIO_CONIMP_CONREBAJA   = 0;
        TOTALCONREBAJA  = 0;
        DIFERENCIA  = 0;
        ESTADOREBAJA = 0;
        CANTAUTREBAJA = 0;
        DOCTOID = 0;
        MOVTOID = 0;
        
        COSTOCAJA = 0;
        PRECIOCAJA = 0;
        MARGEN = 0;
        DESCPES = 0;
        UTILIDAD = 0;
        UTILIDADPORC = 0;
        COMISION = 0;
        COMISIONPORC = 0;
        DESCUENTO = 0;
        DESCUENTOPORCENTAJE = 0;
        CAJAS = 0;
        PIEZASSUELTAS = 0;

        NUTIL = 0;

        
        PROVEEDORID = 0;
        PROVEEDORCLAVE = '';
        PROVEEDORNOMBRE = '';

        PRECIO = 0.00;
        PRECIO4 = 0.00;

   end

END
