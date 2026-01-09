create or alter procedure GET_INVLOCALIDAD_LISTADETAIL(
    TODOSLOSPRODUCTOS smallint,
    ANAQUELINICIAL D_CLAVE_NULL,
    ANAQUELFINAL D_CLAVE_NULL,
    KITDESGLOSADO D_BOOLCN_NULL)
returns (
    NUMERO integer,
    ANAQUELRES D_LOCACION,
    LOCALIDAD D_LOCACION,
    PRODUCTOID D_FK,
    PRODUCTONOMBRE D_NOMBRE,
    PRODUCTODESCRIPCION D_DESCRIPCION,  
    PRODUCTODESCRIPCION1 D_DESCRIPCION,
    PRODUCTOLOTE D_LOTE,
    FECHAVENCE D_FECHAVENCE,
    CANTIDADTEORICA D_CANTIDAD,
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
    PRODUCTODESCRIPCION1 = '';
    PRODUCTOLOTE  = '';
    CANTIDADTEORICA = 0;
    PRODUCTOID = 0;
    ERRORCODE = 0;
    ANAQUELRES = '';
    LOCALIDAD = '';
    PRODUCTOCLAVE = '';
    PZACAJA = 0;  
    CAJAS = 0;
    PIEZAS = 0;  
    ANAQUELIDRES =0;



   NUMERO = 0;


      FOR


       SELECT ID, CLAVE, LOCALIDAD, PRODUCTOID, PRODUCTONOMBRE, DESCRIPCION, DESCRIPCION1, PRODUCTOCLAVE, PZACAJA
        FROM
        (
        SELECT
               ANAQUEL.ID,
               ANAQUEL.CLAVE,
               PRODUCTOLOCATIONS.localidad,
               PRODUCTO.ID PRODUCTOID,
               COALESCE(PRODUCTO.NOMBRE,'') PRODUCTONOMBRE,
               PRODUCTO.DESCRIPCION,
               PRODUCTO.DESCRIPCION1 ,
               COALESCE(PRODUCTO.CLAVE,'') PRODUCTOCLAVE,
               (case WHEN COALESCE(PRODUCTO.PZACAJA,1) = 0 THEN 1 ELSE COALESCE(PRODUCTO.PZACAJA,1) END) PZACAJA
           FROM
                PRODUCTOLOCATIONS
                INNER JOIN ANAQUEL ON ANAQUEL.ID = PRODUCTOLOCATIONS.ANAQUELID

           LEFT JOIN PRODUCTO ON PRODUCTOLOCATIONS.productoid = PRODUCTO.ID
           WHERE  (ANAQUEL.CLAVE >= :ANAQUELINICIAL AND ANAQUEL.CLAVE <= :ANAQUELFINAL)
               AND COALESCE(PRODUCTO.ID,0) <> 0
            UNION

               SELECT -2 AS ID,
                      'Libre' as CLAVE,
                      'Libre' as LOCALIDAD,
                      PRODUCTO.ID PRODUCTOID,
                      COALESCE(PRODUCTO.NOMBRE,'') PRODUCTONOMBRE,
                      PRODUCTO.DESCRIPCION,
               PRODUCTO.DESCRIPCION1 ,
               COALESCE(PRODUCTO.CLAVE,'')  PRODUCTOCLAVE,
               (case WHEN COALESCE(PRODUCTO.PZACAJA,1) = 0 THEN 1 ELSE COALESCE(PRODUCTO.PZACAJA,1) END) PZACAJA

               FROM
               (SELECT PRODUCTOPARTEID FROM KITSUNNIVEL WHERE ('Libre' = :ANAQUELINICIAL or 'Libre' <= :ANAQUELFINAL) GROUP BY PRODUCTOPARTEID) PRODPARTE
               INNER JOIN PRODUCTO ON PRODUCTO.ID = PRODPARTE.PRODUCTOPARTEID
               WHERE PRODUCTO.INVENTARIABLE = 'S'
                AND PRODUCTO.ID NOT IN (SELECT PRODUCTOID FROM PRODUCTOLOCATIONS GROUP BY PRODUCTOID)
                AND ('Libre' = :ANAQUELINICIAL or 'Libre' <= :ANAQUELFINAL)  AND COALESCE(PRODUCTO.ID,0) <> 0
         )q
         order by  CLAVE, localidad
             
           INTO 
           :ANAQUELIDRES,
           :ANAQUELRES,
           :LOCALIDAD,
            :PRODUCTOID,
            :PRODUCTONOMBRE, 
            :PRODUCTODESCRIPCION ,
            :PRODUCTODESCRIPCION1 ,
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

    

               SUSPEND;
    
       END
    



END
