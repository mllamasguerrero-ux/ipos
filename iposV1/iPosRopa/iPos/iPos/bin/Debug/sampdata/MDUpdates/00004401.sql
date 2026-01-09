create or alter procedure GET_INVFIS_COMPLETO (
    DOCTOID D_FK)
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
      EXIT;
   END


   FOR 
    select  
    movto.productoid  PRODCUTOID ,
    producto.clave  PRODUCTO,
    producto.descripcion DESCRIPCION ,
    movto.lote LOTE,
    movto.fechavence FECHAVENCE,
    movto.cantidad CANTIDADTEORICA,
    movto.cantidadsurtida CANTIDADFISICA ,
    (movto.cantidadsurtida - coalesce(movto.cantidad,0)) CANTIDADDIFERENCIA ,
    movto.id   ,
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


 from movto  INNER JOIN producto ON movto.productoid = producto.id
 left join parametro on 1 = 1
   where
   movto.doctoid = :DOCTOID
       --GROUP BY PRODUCTOID,LOTE,FECHAVENCE,PRODUCTO.NOMBRE,PRODUCTO.DESCRIPCION1
       INTO 
        :PRODUCTOID,
        :PRODUCTONOMBRE,
        :PRODUCTODESCRIPCION,
        :PRODUCTOLOTE, 
        :FECHAVENCE, 
        :CANTIDADTEORICA,
        :CANTIDADFISICA,
        :CANTIDADDIFERENCIA,
        :MOVTOID  ,
        :COSTOPRECIOMANEJADO
 
   DO
   BEGIN
           DIFERNECIACOSTOINVENTARIO = COALESCE(:CANTIDADDIFERENCIA,0.00) *  COALESCE(:COSTOPRECIOMANEJADO, 0.00);
           SUSPEND;
   END
    


   WHEN ANY DO
   BEGIN
      ERRORCODE = 1016;
      SUSPEND;
   END 


END