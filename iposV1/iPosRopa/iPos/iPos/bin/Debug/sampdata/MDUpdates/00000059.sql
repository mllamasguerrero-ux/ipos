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
    movto.id
 from movto  INNER JOIN producto ON movto.productoid = producto.id
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
        :MOVTOID
 
   DO
   BEGIN
           SUSPEND;
   END
    


   WHEN ANY DO
   BEGIN
      ERRORCODE = 1016;
      SUSPEND;
   END 


END