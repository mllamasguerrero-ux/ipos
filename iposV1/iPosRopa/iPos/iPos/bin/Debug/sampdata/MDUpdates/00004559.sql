create or alter procedure GET_INVFIS_LISTADETALLES_P (
    DOCTOID D_FK,
    SOLODIFERENCIAS smallint,
    TODOSLOSPRODUCTOS smallint)
returns (
    NUMERO integer,
    PRODUCTOID D_FK,
    PRODUCTONOMBRE D_NOMBRE,
    PRODUCTODESCRIPCION varchar(40),
    PRODUCTOLOTE D_LOTE,
    FECHAVENCE D_FECHAVENCE,
    CANTIDADTEORICA D_CANTIDAD,
    CANTIDADFISICA D_CANTIDAD,
    CANTIDADDIFERENCIA D_CANTIDAD,
    MOVTOID D_FK,
    TEXTO1 D_STDTEXT_LIGHT,
    TEXTO2 D_STDTEXT_LIGHT,
    TEXTO3 D_STDTEXT_LIGHT,
    TEXTO4 D_STDTEXT_LIGHT,
    TEXTO5 D_STDTEXT_MEDIUM,
    TEXTO6 D_STDTEXT_LARGE,
    NUMERO1 D_PRECIO,
    NUMERO2 D_PRECIO,
    NUMERO3 D_PRECIO,
    NUMERO4 D_PRECIO,
    FECHA1 D_FECHA,
    FECHA2 D_FECHA,
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


    TEXTO1 = '';
    TEXTO2 = '';
    TEXTO3 = '';
    TEXTO4 = '';
    TEXTO5 = '';
    TEXTO6 = '';
    NUMERO1 = 0;
    NUMERO2 = 0;
    NUMERO3 = 0;
    NUMERO4 = 0;
    FECHA1 = NULL;
    FECHA2 = NULL;


    ERRORCODE = 0;



   if(:DOCTOID is null) then
   BEGIN
      ERRORCODE = 1001;
      EXIT;
   END

   NUMERO = 0;

   FOR 
    SELECT PRODUCTO.ID PRODUCTOID,
           LOTE,
           FECHAVENCE,
           COALESCE(CANTIDADSURTIDA,0) CANTIDADSURTIDA,
           PRODUCTO.NOMBRE,
           PRODUCTO.DESCRIPCION1,
           MOVTO.ID ,

           c.texto1, 
     c.texto2,
     c.texto3,
     c.texto4,
     c.texto5,
     c.texto6,
     c.numero1,
     c.numero2, 
     c.numero3,
     c.numero4,
     c.fecha1, 
     c.fecha2


       FROM PRODUCTO
          LEFT JOIN MOVTO ON PRODUCTO.ID = MOVTO.PRODUCTOID  AND DOCTOID = :DOCTOID 
          LEFT JOIN PRODUCTOCARACTERISTICAS c ON c.productoid = PRODUCTO.ID
       WHERE (DOCTOID = :DOCTOID or (coalesce(DOCTOID,-1) = -1 and   :TODOSLOSPRODUCTOS = 1) )
       order by  PRODUCTO.ID
       --GROUP BY PRODUCTOID,LOTE,FECHAVENCE,PRODUCTO.NOMBRE,PRODUCTO.DESCRIPCION1
       INTO 
        :PRODUCTOID,
        :PRODUCTOLOTE, 
        :FECHAVENCE, 
        :CANTIDADFISICA,
        :PRODUCTONOMBRE, 
        :PRODUCTODESCRIPCION ,
        :MOVTOID,
        :TEXTO1 ,
        :TEXTO2 ,
        :TEXTO3 ,
        :TEXTO4 ,
        :TEXTO5 ,
        :TEXTO6 ,
        :NUMERO1 ,
        :NUMERO2 ,
        :NUMERO3 ,
        :NUMERO4 ,
        :FECHA1 ,
        :FECHA2
 
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