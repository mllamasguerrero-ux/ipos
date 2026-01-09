create or alter procedure GET_INVFIS_FINEDICION (
    DOCTOID D_FK,
    SOLODIFERENCIAS smallint,
    TODOSLOSPRODUCTOS smallint)
returns (
    PRODUCTOID D_FK,
    PRODUCTONOMBRE D_NOMBRE,
    PRODUCTODESCRIPCION varchar(40) character set NONE,
    PRODUCTOLOTE D_LOTE,
    FECHAVENCE D_FECHAVENCE,
    CANTIDADTEORICA D_CANTIDAD,
    CANTIDADFISICA D_CANTIDAD,
    CANTIDADDIFERENCIA D_CANTIDAD,
    MOVTOID D_FK,
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
    ERRORCODE = 0;


   if(:DOCTOID is null) then
   BEGIN
      ERRORCODE = 1001;
      EXIT;
   END

   NUMERO = 0;

   FOR 
    select PRODUCTOID, LOTE, FECHAVENCE, CANTIDADSURTIDA, NOMBRE, DESCRIPCION1, ID from (
      SELECT PRODUCTO.ID PRODUCTOID,
           LOTE,
           FECHAVENCE,
           COALESCE(CANTIDADSURTIDA,0) CANTIDADSURTIDA,
           PRODUCTO.NOMBRE,
           PRODUCTO.DESCRIPCION1,
           MOVTO.ID
       FROM PRODUCTO
          LEFT JOIN MOVTO ON PRODUCTO.ID = MOVTO.PRODUCTOID
       WHERE (DOCTOID = :DOCTOID)-- or (coalesce(:DOCTOID,-1) = -1 and   :TODOSLOSPRODUCTOS = 1) )

       union

       SELECT PRODUCTO.ID PRODUCTOID,
           null LOTE,
           null FECHAVENCE,
           0 CANTIDADSURTIDA,
           PRODUCTO.NOMBRE,
           PRODUCTO.DESCRIPCION1,
           0  ID
       FROM PRODUCTO
       WHERE :TODOSLOSPRODUCTOS = 1 and producto.id not in (select productoid from movto where doctoid = :doctoid)

               )
       order by  PRODUCTOID
       --GROUP BY PRODUCTOID,LOTE,FECHAVENCE,PRODUCTO.NOMBRE,PRODUCTO.DESCRIPCION1
       INTO 
        :PRODUCTOID,
        :PRODUCTOLOTE, 
        :FECHAVENCE, 
        :CANTIDADFISICA,
        :PRODUCTONOMBRE, 
        :PRODUCTODESCRIPCION ,
        :MOVTOID
 
   DO
   BEGIN
    NUMERO = :NUMERO + 1;
        select COALESCE(sum(cantidad),0) from inventario
        where  productoid = :PRODUCTOID and
              coalesce(lote,'') = coalesce(:PRODUCTOLOTE,'') AND
              coalesce(fechavence,current_date) = coalesce(:FECHAVENCE,current_date)
        into :CANTIDADTEORICA;

        
        CANTIDADDIFERENCIA = :CANTIDADFISICA - :CANTIDADTEORICA;

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