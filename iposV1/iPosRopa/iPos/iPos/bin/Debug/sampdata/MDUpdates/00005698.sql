create or alter procedure REPORTE_INVFIS_DIF_COMPLETO (
    DOCTOID D_FK,
    SOLODIFERENCIAS smallint,
    TODOSLOSPRODUCTOS smallint)
returns (
    PRODUCTOID D_FK,
    PRODUCTONOMBRE D_NOMBRE,
    PRODUCTODESCRIPCION varchar(40),
    PRODUCTOLOTE D_LOTE,
    FECHAVENCE D_FECHAVENCE,
    CANTIDADTEORICA D_CANTIDAD,
    CANTIDADFISICA D_CANTIDAD,
    CANTIDADDIFERENCIA D_CANTIDAD,
    MOVTOID D_FK,
    DIFERNECIACOSTOINVENTARIO D_COSTO,
    COSTOPRECIOMANEJADO D_COSTO,
    ERRORCODE D_ERRORCODE)
as
declare variable NUMERO integer;
BEGIN
   
--Initialitation
    PRODUCTONOMBRE = '';
    PRODUCTODESCRIPCION = '';
    PRODUCTOLOTE  = '';
    CANTIDADTEORICA = 0;
    CANTIDADFISICA  = 0;
    CANTIDADDIFERENCIA  = 0;
    PRODUCTOID = 0;  
    DIFERNECIACOSTOINVENTARIO = 0.00;
    COSTOPRECIOMANEJADO = 0.00;
    ERRORCODE = 0;


   if(:DOCTOID is null) then
   BEGIN
      ERRORCODE = 1001;  
      SUSPEND;
      EXIT;
   END



   NUMERO = 0;

   FOR 
    select PRODUCTOID, LOTE, FECHAVENCE, CANTIDADTEORICA, CANTIDADFISICA, CANTIDADDIFERENCIA, NOMBRE, DESCRIPCION1,  COSTOPRECIOMANEJADO  from (
      SELECT PRODUCTO.ID PRODUCTOID,
           LOTE,
           FECHAVENCE,
           MAX(COALESCE(movto.cantidad,0)) CANTIDADTEORICA,
           SUM(COALESCE(movto.cantidadsurtida,0)) CANTIDADFISICA ,
            SUM(coalesce(movto.cantidadsurtida,0)) - MAX(coalesce(movto.cantidad,0) ) CANTIDADDIFERENCIA ,

           PRODUCTO.NOMBRE,
           PRODUCTO.DESCRIPCION1,
            case coalesce(PARAMETRO.PRECIOAJUSTEDIFINV,'')
                WHEN 'PRECIO 1' THEN producto.PRECIO1
                WHEN 'PRECIO 2' THEN producto.PRECIO2
                WHEN 'PRECIO 3' THEN producto.PRECIO3
                WHEN 'PRECIO 4' THEN producto.PRECIO4
                WHEN 'PRECIO 5' THEN producto.PRECIO5
                WHEN 'COSTO ULTIMO' THEN producto.costoultimo
                WHEN 'REPOSICION' THEN producto.costoreposicion
                WHEN 'SIN PRECIO' THEN  CAST(0.00 AS D_PRECIO)
                ELSE  producto.PRECIO1
            END COSTOPRECIOMANEJADO

       FROM PRODUCTO
          LEFT JOIN MOVTO ON PRODUCTO.ID = MOVTO.PRODUCTOID   
            left join parametro on 1 = 1
       WHERE (DOCTOID = :DOCTOID)-- or (coalesce(:DOCTOID,-1) = -1 and   :TODOSLOSPRODUCTOS = 1) )
          GROUP BY
            PRODUCTO.ID,
            MOVTO.LOTE,
            MOVTO.FECHAVENCE,
           PRODUCTO.NOMBRE,
           PRODUCTO.DESCRIPCION1,
           PARAMETRO.PRECIOAJUSTEDIFINV ,
           producto.PRECIO1,
           producto.PRECIO2,
           producto.PRECIO3,
           producto.PRECIO4 ,
           producto.PRECIO5,
           producto.costoultimo,
           producto.costoreposicion
         )

       INTO 
        :PRODUCTOID,
        :PRODUCTOLOTE, 
        :FECHAVENCE,  
        :CANTIDADTEORICA,
        :CANTIDADFISICA,
        :CANTIDADDIFERENCIA ,
        :PRODUCTONOMBRE, 
        :PRODUCTODESCRIPCION ,
        :COSTOPRECIOMANEJADO
 
   DO
   BEGIN
    NUMERO = :NUMERO + 1;

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