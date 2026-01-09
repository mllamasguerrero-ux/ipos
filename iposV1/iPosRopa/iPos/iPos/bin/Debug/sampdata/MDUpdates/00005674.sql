create or alter procedure GET_INVFIS_LISTADETAIL_XLOC (
    DOCTOID D_FK,
    SOLODIFERENCIAS smallint,
    TODOSLOSPRODUCTOS smallint,
    ANAQUELID D_FK,
    KITDESGLOSADO D_BOOLCN)
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
        SELECT
               ANAQUEL.id, 
               ANAQUEL.CLAVE,
               PRODUCTOLOCATIONS.localidad,
               PRODUCTO.ID PRODUCTOID,
               LOTE,
               FECHAVENCE,
               COALESCE(CANTIDADSURTIDA,0) CANTIDADSURTIDA,
               COALESCE(PRODUCTO.NOMBRE, ''),
               PRODUCTO.DESCRIPCION1,
               MOVTO.ID  ,
               COALESCE(PRODUCTO.CLAVE, '') ,
               coalesce(MOVTO.CAJAS,0),--FLOOR( COALESCE(CANTIDADSURTIDA,0)/(CASE WHEN COALESCE(PRODUCTO.pzacaja,0)= 0 THEN 1 else PRODUCTO.pzacaja END)) CAJAS,
               coalesce(MOVTO.piezas,0), --(MOD( COALESCE(CANTIDADSURTIDA,0), (CASE WHEN COALESCE(PRODUCTO.pzacaja,0)= 0 THEN 1 else PRODUCTO.pzacaja END))) PIEZAS ,
               (case WHEN COALESCE(MOVTO.PZACAJA,1) = 0 THEN 1 ELSE COALESCE(MOVTO.PZACAJA,1) END)
           FROM PRODUCTOLOCATIONS        
           INNER JOIN ANAQUEL ON ANAQUEL.ID = PRODUCTOLOCATIONS.ANAQUELID
           LEFT JOIN PRODUCTO ON PRODUCTOLOCATIONS.productoid = PRODUCTO.ID
              LEFT JOIN MOVTO ON PRODUCTO.ID = MOVTO.PRODUCTOID AND DOCTOID = :DOCTOID 
               and PRODUCTOLOCATIONS.ANAQUELID = MOVTO.ANAQUELID
               AND PRODUCTOLOCATIONS.LOCALIDAD = MOVTO.LOCALIDAD
           WHERE (DOCTOID = :DOCTOID or (coalesce(DOCTOID,-1) = -1 and   :TODOSLOSPRODUCTOS = 1) )
              AND PRODUCTOLOCATIONS.ANAQUELID = :ANAQUELID  AND COALESCE(PRODUCTO.ID,0) <> 0
           order by  ANAQUEL.CLAVE, PRODUCTOLOCATIONS.localidad
           --GROUP BY PRODUCTOID,LOTE,FECHAVENCE,PRODUCTO.NOMBRE,PRODUCTO.DESCRIPCION1
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
                select COALESCE(sum(cantidad),0) from INVENTARIOKITDESG_VIEW
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
    
            if(  SOLODIFERENCIAS = 0 OR CANTIDADDIFERENCIA <> 0 ) then
            begin   
               SUSPEND;
            end
    
       END
   END
   ELSE
   begin
            FOR
        SELECT
               ANAQUEL.ID,
               ANAQUEL.CLAVE,
               PRODUCTOLOCATIONS.localidad,
               PRODUCTO.ID PRODUCTOID,
               COALESCE(PRODUCTO.NOMBRE,''),
               PRODUCTO.DESCRIPCION1 ,
               COALESCE(PRODUCTO.CLAVE,''),
               (case WHEN COALESCE(PRODUCTO.PZACAJA,1) = 0 THEN 1 ELSE COALESCE(PRODUCTO.PZACAJA,1) END)
           FROM PRODUCTOLOCATIONS   
           INNER JOIN ANAQUEL ON ANAQUEL.ID = PRODUCTOLOCATIONS.ANAQUELID
           LEFT JOIN PRODUCTO ON PRODUCTOLOCATIONS.productoid = PRODUCTO.ID
           WHERE  PRODUCTOLOCATIONS.ANAQUELID = :ANAQUELID    AND COALESCE(PRODUCTO.ID,0) <> 0
           order by  ANAQUEL.CLAVE, PRODUCTOLOCATIONS.localidad
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
    
            if(  SOLODIFERENCIAS = 0 OR CANTIDADDIFERENCIA <> 0 ) then
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