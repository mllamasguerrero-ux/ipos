create or alter procedure GET_INVFIS_FINEDICION_XLOC (
    DOCTOID D_FK,
    SOLODIFERENCIAS smallint,
    TODOSLOSPRODUCTOS smallint)
returns (
    ANAQUEL D_LOCACION,
    LOCALIDAD D_LOCACION,
    PRODUCTOID D_FK,
    PRODUCTONOMBRE D_NOMBRE,
    PRODUCTODESCRIPCION varchar(40),
    PRODUCTOLOTE D_LOTE,
    FECHAVENCE D_FECHAVENCE,
    CANTIDADTEORICA D_CANTIDAD,
    CANTIDADCAJAS D_CANTIDAD,
    CANTIDADPIEZAS D_CANTIDAD,
    CANTIDADFISICA D_CANTIDAD,
    CANTIDADDIFERENCIA D_CANTIDAD,
    MOVTOID D_FK,
    DIFERNECIACOSTOINVENTARIO D_COSTO,
    COSTOPRECIOMANEJADO D_COSTO,
    ERRORCODE D_ERRORCODE)
as
declare variable NUMERO integer;
declare variable KITDESGLOSADO D_BOOLCN;
BEGIN
   
--Initialitation
    PRODUCTONOMBRE = '';
    PRODUCTODESCRIPCION = '';
    PRODUCTOLOTE  = '';
    CANTIDADTEORICA = 0;
    CANTIDADFISICA  = 0;
    CANTIDADDIFERENCIA  = 0;
    PRODUCTOID = 0;
    ANAQUEL = '';
    LOCALIDAD = '';

    CANTIDADCAJAS = 0;
    CANTIDADPIEZAS = 0;
                     
    DIFERNECIACOSTOINVENTARIO = 0.00;
    COSTOPRECIOMANEJADO = 0.00;

    ERRORCODE = 0;


   if(:DOCTOID is null) then
   BEGIN
      ERRORCODE = 1001;
      EXIT;
   END
       
   SELECT KITDESGLOSADO FROM DOCTO WHERE ID = :DOCTOID INTO :KITDESGLOSADO;
   NUMERO = 0;

   FOR 
    SELECT PRODUCTO.ID PRODUCTOID,
           LOTE,
           FECHAVENCE,
           COALESCE(CANTIDADSURTIDA,0) CANTIDADSURTIDA,
           PRODUCTO.NOMBRE,
           PRODUCTO.DESCRIPCION1,
           MOVTO.ID    ,
           ANAQUEL.CLAVE ,
           PRODUCTOLOCATIONS.LOCALIDAD,
           COALESCE(MOVTO.CAJAS,0), 
           COALESCE(MOVTO.PIEZAS,0) ,
           -- case coalesce(PARAMETRO.PRECIOAJUSTEDIFINV,'')
           --     WHEN 'PRECIO 1' THEN producto.PRECIO1
           --     WHEN 'PRECIO 2' THEN producto.PRECIO2
           --     WHEN 'PRECIO 3' THEN producto.PRECIO3
           --     WHEN 'PRECIO 4' THEN producto.PRECIO4
           --     WHEN 'PRECIO 5' THEN producto.PRECIO5
           --     WHEN 'COSTO ULTIMO' THEN producto.costoultimo
           --     WHEN 'REPOSICION' THEN producto.costoreposicion
           --     WHEN 'SIN PRECIO' THEN  CAST(0.00 AS D_PRECIO)
           --     ELSE  producto.PRECIO1
           -- END COSTOPRECIOMANEJADO
           COALESCE(MOVTO.PRECIO, 0.00) COSTOPRECIOMANEJADO

       FROM PRODUCTO
          LEFT JOIN PRODUCTOLOCATIONS ON PRODUCTOLOCATIONS.PRODUCTOID = PRODUCTO.ID 
           LEFT JOIN MOVTO ON PRODUCTO.ID = MOVTO.PRODUCTOID
                  AND MOVTO.ANAQUELID = PRODUCTOLOCATIONS.anaquelID
                   AND MOVTO.LOCALIDAD = PRODUCTOLOCATIONS.LOCALIDAD 
          left join anaquel on productolocations.anaquelid = anaquel.id  
            left join parametro on 1 = 1

       WHERE (DOCTOID = :DOCTOID or (coalesce(DOCTOID,-1) = -1 and   :TODOSLOSPRODUCTOS = 1) )
       order by  ANAQUEL.CLAVE,  PRODUCTOLOCATIONS.LOCALIDAD , PRODUCTO.ID
       --GROUP BY PRODUCTOID,LOTE,FECHAVENCE,PRODUCTO.NOMBRE,PRODUCTO.DESCRIPCION1
       INTO 
        :PRODUCTOID,
        :PRODUCTOLOTE, 
        :FECHAVENCE, 
        :CANTIDADFISICA,
        :PRODUCTONOMBRE, 
        :PRODUCTODESCRIPCION ,
        :MOVTOID ,
        :ANAQUEL,
        :LOCALIDAD,
        :CANTIDADCAJAS,
        :CANTIDADPIEZAS   ,
        :COSTOPRECIOMANEJADO
 
   DO
   BEGIN
    NUMERO = :NUMERO + 1;



        
    IF(COALESCE( :KITDESGLOSADO,'N') = 'S') THEN
    BEGIN
        
        select COALESCE(sum(cantidad),0) from inventariokitdesg_view
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


        
        CANTIDADDIFERENCIA = :CANTIDADFISICA - :CANTIDADTEORICA;   
        DIFERNECIACOSTOINVENTARIO = COALESCE(:CANTIDADDIFERENCIA,0.00) *  COALESCE(:COSTOPRECIOMANEJADO, 0.00);

        if(  SOLODIFERENCIAS = 0 OR CANTIDADDIFERENCIA <> 0 ) then
        begin   
           SUSPEND;
        end

   END
    


   WHEN ANY DO
   BEGIN
      ERRORCODE = 1016;
      SUSPEND;
   END 


END