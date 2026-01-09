create or alter procedure GET_INVFIS_LISTADETAIL_XLOC (
    DOCTOID D_FK,
    SOLODIFERENCIAS smallint,
    TODOSLOSPRODUCTOS smallint,
    ANAQUELID D_FK,
    KITDESGLOSADO D_BOOLCN_NULL)
returns (
    NUMERO integer,
    ANAQUELRES D_LOCACION,
    LOCALIDAD D_LOCACION,
    PRODUCTOID D_FK,
    PRODUCTONOMBRE D_NOMBRE,
    PRODUCTODESCRIPCION D_DESCRIPCION,
    PRODUCTOLOTE D_LOTE,
    FECHAVENCE D_FECHAVENCE,
    CANTIDADTEORICA D_CANTIDAD,
    CANTIDADFISICA D_CANTIDAD,
    CANTIDADDIFERENCIA D_CANTIDAD,
    MOVTOID D_FK,
    ACUMULADOCANTIDADFISICA D_CANTIDAD,
    PRODUCTOCLAVE D_CLAVE,
    CAJAS D_CANTIDAD,
    PIEZAS D_CANTIDAD,
    PZACAJA D_CANTIDAD,
    ANAQUELIDRES D_FK,
    ERRORCODE D_ERRORCODE)
as
BEGIN
   
--Initialitation
    PRODUCTONOMBRE = '';
    PRODUCTODESCRIPCION = '';
    PRODUCTOLOTE  = '';
    CANTIDADTEORICA = 0;
    CANTIDADFISICA  = 0;
    CANTIDADDIFERENCIA  = 0;
    PRODUCTOID = 0;
    ERRORCODE = 0;
    ANAQUELRES = '';
    ACUMULADOCANTIDADFISICA = 0;
    LOCALIDAD = '';
    PRODUCTOCLAVE = '';
    PZACAJA = 0;  
    CAJAS = 0;
    PIEZAS = 0;  
    ANAQUELIDRES = :ANAQUELID;


   if(:DOCTOID is null) then
   BEGIN
      ERRORCODE = 1001;
      EXIT;
   END

   NUMERO = 0;


   IF( :DOCTOID IS NOT NULL AND :DOCTOID > 0) THEN
   BEGIN
        SELECT KITDESGLOSADO FROM DOCTO WHERE ID = :DOCTOID  INTO :KITDESGLOSADO;

        FOR


         SELECT ID, CLAVE, LOCALIDAD, PRODUCTOID, LOTE, FECHAVENCE, CANTIDADSURTIDA, PRODUCTONOMBRE, DESCRIPCION1, MOVTOID,
             PRODUCTOCLAVE, CAJAS, PIEZAS, PZACAJA
           FROM
           (
           SELECT
               ANAQUEL.id, 
               ANAQUEL.CLAVE,
               PRODUCTOLOCATIONS.localidad,
               PRODUCTO.ID PRODUCTOID,
               LOTE,
               FECHAVENCE,
               COALESCE(CANTIDADSURTIDA,0) CANTIDADSURTIDA,
               COALESCE(PRODUCTO.NOMBRE, '') PRODUCTONOMBRE,
               PRODUCTO.DESCRIPCION1,
               MOVTO.ID MOVTOID ,
               COALESCE(PRODUCTO.CLAVE, '') PRODUCTOCLAVE ,
               coalesce(MOVTO.CAJAS,0) CAJAS,
               coalesce(MOVTO.piezas,0) PIEZAS,
               (case WHEN COALESCE(PRODUCTO.PZACAJA,1) = 0 THEN 1 ELSE COALESCE(PRODUCTO.PZACAJA,1) END) PZACAJA
           FROM

                PRODUCTOLOCATIONS
                INNER JOIN ANAQUEL ON ANAQUEL.ID = PRODUCTOLOCATIONS.ANAQUELID

           LEFT JOIN PRODUCTO ON PRODUCTOLOCATIONS.productoid = PRODUCTO.ID
              LEFT JOIN MOVTO ON PRODUCTO.ID = MOVTO.PRODUCTOID AND DOCTOID = :DOCTOID 
               and PRODUCTOLOCATIONS.ANAQUELID = MOVTO.ANAQUELID
               AND PRODUCTOLOCATIONS.LOCALIDAD = MOVTO.LOCALIDAD
           WHERE (DOCTOID = :DOCTOID or (coalesce(DOCTOID,-1) = -1 and   :TODOSLOSPRODUCTOS = 1) )
              AND PRODUCTOLOCATIONS.ANAQUELID = :ANAQUELID  AND COALESCE(PRODUCTO.ID,0) <> 0
              AND (COALESCE(:KITDESGLOSADO,'N') <> 'S' OR COALESCE(PRODUCTO.ESKIT,'N') <> 'S')
           --order by  ANAQUEL.CLAVE, PRODUCTOLOCATIONS.localidad
           --GROUP BY PRODUCTOID,LOTE,FECHAVENCE,PRODUCTO.NOMBRE,PRODUCTO.DESCRIPCION1
           UNION
           
               SELECT
               -2 AS ID,
                'Libre' as CLAVE,
                'Libre' as LOCALIDAD,
                PRODUCTO.ID PRODUCTOID,
               LOTE,
               FECHAVENCE,
               COALESCE(CANTIDADSURTIDA,0) CANTIDADSURTIDA,
               COALESCE(PRODUCTO.NOMBRE, '') PRODUCTONOMBRE,
               PRODUCTO.DESCRIPCION1,
               MOVTO.ID MOVTOID ,
               COALESCE(PRODUCTO.CLAVE, '') PRODUCTOCLAVE ,
               coalesce(MOVTO.CAJAS,0) CAJAS,
               coalesce(MOVTO.piezas,0) PIEZAS,
               (case WHEN COALESCE(PRODUCTO.PZACAJA,1) = 0 THEN 1 ELSE COALESCE(PRODUCTO.PZACAJA,1) END) PZACAJA

               FROM
               (SELECT PRODUCTOPARTEID FROM KITSUNNIVEL WHERE :ANAQUELID = -2 GROUP BY PRODUCTOPARTEID) PRODPARTE
               INNER JOIN PRODUCTO ON PRODUCTO.ID = PRODPARTE.PRODUCTOPARTEID
                LEFT JOIN MOVTO ON PRODUCTO.ID = MOVTO.PRODUCTOID AND DOCTOID = :DOCTOID 
                    and -2 = MOVTO.ANAQUELID
                    AND 'Libre' = MOVTO.LOCALIDAD
           WHERE
             PRODUCTO.INVENTARIABLE = 'S' AND PRODUCTO.ID NOT IN (SELECT PRODUCTOID FROM PRODUCTOLOCATIONS GROUP BY PRODUCTOID) AND
             (DOCTOID = :DOCTOID or (coalesce(DOCTOID,-1) = -1 and   :TODOSLOSPRODUCTOS = 1) )
              AND -2 = :ANAQUELID  AND COALESCE(PRODUCTO.ID,0) <> 0
             )
              order by  CLAVE, localidad

           INTO 
           :ANAQUELIDRES,
           :ANAQUELRES,
           :LOCALIDAD,
            :PRODUCTOID,
            :PRODUCTOLOTE, 
            :FECHAVENCE, 
            :CANTIDADFISICA,
            :PRODUCTONOMBRE, 
            :PRODUCTODESCRIPCION ,
            :MOVTOID ,
            :PRODUCTOCLAVE ,
            :CAJAS,
            :PIEZAS,
            :PZACAJA

            

     
       DO
       BEGIN
        NUMERO = :NUMERO + 1;

            IF(COALESCE(:KITDESGLOSADO ,'N') = 'S') THEN
            BEGIN 
                select COALESCE(sum(cantidad),0) from INVENTARIOKITDESG_VIEW
                where  productoid = :PRODUCTOID and
                  coalesce(lote,'') = coalesce(:PRODUCTOLOTE,'') AND
                  coalesce(fechavence,current_date) = coalesce(:FECHAVENCE,current_date)
                into :CANTIDADTEORICA;

            END
            ELSE
            BEGIN      
                select COALESCE(sum(cantidad),0) from INVENTARIO
                where  productoid = :PRODUCTOID and
                  coalesce(lote,'') = coalesce(:PRODUCTOLOTE,'') AND
                  coalesce(fechavence,current_date) = coalesce(:FECHAVENCE,current_date)
                into :CANTIDADTEORICA;

            END
    
                     
            SELECT SUM( COALESCE(CANTIDADSURTIDA,0))
            FROM  MOVTO
            WHERE DOCTOID = :DOCTOID AND PRODUCTOID = :PRODUCTOID
            INTO :ACUMULADOCANTIDADFISICA;
            
            CANTIDADDIFERENCIA = COALESCE(:ACUMULADOCANTIDADFISICA,0) - COALESCE(:CANTIDADTEORICA,0);
    
            if(  (SOLODIFERENCIAS = 0 OR CANTIDADDIFERENCIA <> 0) AND
                  (:ANAQUELIDRES <> -2 OR COALESCE(:CANTIDADTEORICA,0) > 0 OR COALESCE(:CANTIDADFISICA,0) > 0) -- si es libre debe tener existencia teorica o fisica
             ) then
            begin   
               SUSPEND;
            end
    
       END
   END
   ELSE
   begin
      FOR


       SELECT ID, CLAVE, LOCALIDAD, PRODUCTOID, PRODUCTONOMBRE, DESCRIPCION1, PRODUCTOCLAVE, PZACAJA
        FROM
        (
        SELECT
               ANAQUEL.ID,
               ANAQUEL.CLAVE,
               PRODUCTOLOCATIONS.localidad,
               PRODUCTO.ID PRODUCTOID,
               COALESCE(PRODUCTO.NOMBRE,'') PRODUCTONOMBRE,
               PRODUCTO.DESCRIPCION1 ,
               COALESCE(PRODUCTO.CLAVE,'') PRODUCTOCLAVE,
               (case WHEN COALESCE(PRODUCTO.PZACAJA,1) = 0 THEN 1 ELSE COALESCE(PRODUCTO.PZACAJA,1) END) PZACAJA
           FROM
                PRODUCTOLOCATIONS
                INNER JOIN ANAQUEL ON ANAQUEL.ID = PRODUCTOLOCATIONS.ANAQUELID

           LEFT JOIN PRODUCTO ON PRODUCTOLOCATIONS.productoid = PRODUCTO.ID
           WHERE  PRODUCTOLOCATIONS.ANAQUELID = :ANAQUELID    AND COALESCE(PRODUCTO.ID,0) <> 0  
              AND (COALESCE(:KITDESGLOSADO,'N') <> 'S' OR COALESCE(PRODUCTO.ESKIT,'N') <> 'S')
           --order by  ANAQUEL.CLAVE, PRODUCTOLOCATIONS.localidad
            UNION

               SELECT -2 AS ID,
                      'Libre' as CLAVE,
                      'Libre' as LOCALIDAD,
                      PRODUCTO.ID PRODUCTOID,
                      COALESCE(PRODUCTO.NOMBRE,'') PRODUCTONOMBRE,
               PRODUCTO.DESCRIPCION1 ,
               COALESCE(PRODUCTO.CLAVE,'')  PRODUCTOCLAVE,
               (case WHEN COALESCE(PRODUCTO.PZACAJA,1) = 0 THEN 1 ELSE COALESCE(PRODUCTO.PZACAJA,1) END) PZACAJA

               FROM
               (SELECT PRODUCTOPARTEID FROM KITSUNNIVEL WHERE :ANAQUELID = -2 GROUP BY PRODUCTOPARTEID) PRODPARTE
               INNER JOIN PRODUCTO ON PRODUCTO.ID = PRODPARTE.PRODUCTOPARTEID
               WHERE PRODUCTO.INVENTARIABLE = 'S'
                AND PRODUCTO.ID NOT IN (SELECT PRODUCTOID FROM PRODUCTOLOCATIONS GROUP BY PRODUCTOID)
                AND :ANAQUELID = -2  AND COALESCE(PRODUCTO.ID,0) <> 0
         )q
         order by  CLAVE, localidad
             
           INTO 
           :ANAQUELIDRES,
           :ANAQUELRES,
           :LOCALIDAD,
            :PRODUCTOID,
            :PRODUCTONOMBRE, 
            :PRODUCTODESCRIPCION ,
            :PRODUCTOCLAVE ,
            :PZACAJA

     
       DO
       BEGIN
        NUMERO = :NUMERO + 1;
        
            IF(COALESCE(:KITDESGLOSADO ,'N') = 'S') THEN
            BEGIN  
                select COALESCE(sum(cantidad),0) from INVENTARIOKITDESG_VIEW
                where  productoid = :PRODUCTOID and
                  coalesce(lote,'') = coalesce(:PRODUCTOLOTE,'') AND
                  coalesce(fechavence,current_date) = coalesce(:FECHAVENCE,current_date)
                into :CANTIDADTEORICA;
            END
            ELSE
            BEGIN    
                select COALESCE(sum(cantidad),0) from inventario
                where  productoid = :PRODUCTOID and
                  coalesce(lote,'') = coalesce(:PRODUCTOLOTE,'') AND
                  coalesce(fechavence,current_date) = coalesce(:FECHAVENCE,current_date)
                into :CANTIDADTEORICA;
            END
    
             SELECT SUM( COALESCE(CANTIDADSURTIDA,0))
           FROM  MOVTO
           WHERE DOCTOID = :DOCTOID AND PRODUCTOID = :PRODUCTOID
           INTO :ACUMULADOCANTIDADFISICA;
    
    
            
            CANTIDADDIFERENCIA = COALESCE(:ACUMULADOCANTIDADFISICA,0) - COALESCE(:CANTIDADTEORICA,0);
    
           
            if(  (SOLODIFERENCIAS = 0 OR CANTIDADDIFERENCIA <> 0) AND
                  (:ANAQUELIDRES <> -2 OR COALESCE(:CANTIDADTEORICA,0) > 0 OR COALESCE(:CANTIDADFISICA,0) > 0) -- si es libre debe tener existencia teorica o fisica
             ) then
            begin   
               SUSPEND;
            end
    
       END
   end 
    

  /* WHEN ANY DO
   BEGIN
      ERRORCODE = 1016;
      SUSPEND;
   END  */


END