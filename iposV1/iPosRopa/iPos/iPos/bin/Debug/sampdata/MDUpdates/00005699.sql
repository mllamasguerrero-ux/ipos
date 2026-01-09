create or alter procedure GET_INVFIS_LISTA_PXLOC_KIT (
    DOCTOID D_FK,
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
    PRODUCTOCLAVE D_CLAVE_NULL,
    CAJAS D_CANTIDAD,
    PIEZAS D_CANTIDAD,
    PZACAJA D_CANTIDAD,
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
    CAJAS = 0;  
    PIEZAS = 0;  
    PZACAJA = 0;
    
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


   if(:DOCTOID is null) then
   BEGIN
      ERRORCODE = 1001;
      EXIT;
   END

   NUMERO = 0;


   



   FOR 
    SELECT                         producto.id AS productoid,
                                    producto.nombre AS productonombre,
                                    producto.descripcion1 AS productodescripcion,
                                    movto.lote AS productolote,
                                    movto.fechavence,
                                        0 AS movtoid,
                                        producto.clave AS productoclave,
                                        SUM((CASE WHEN (movto.cajas IS NULL) THEN 0 ELSE movto.cajas END)) AS cajas,
                                        SUM((CASE WHEN (movto.piezas IS NULL) THEN 0 ELSE movto.piezas END)) AS piezas,
                                        producto.pzacaja ,
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
                      FROM            producto LEFT OUTER JOIN
                      movto ON movto.productoid = producto.id AND movto.doctoid = :DOCTOID
                      left outer join productocaracteristicas  c on c.productoid = producto.id
                      WHERE        (:TODOSLOSPRODUCTOS = 1) OR
                      (movto.doctoid = :DOCTOID)
                      GROUP BY movto.doctoid, producto.id, producto.nombre, producto.descripcion1, movto.lote, movto.fechavence, producto.clave,
                      producto.pzacaja,
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
       INTO
        :PRODUCTOID ,
        :PRODUCTONOMBRE ,
        :PRODUCTODESCRIPCION,
        :PRODUCTOLOTE ,
        :FECHAVENCE ,
        :MOVTOID ,
        :PRODUCTOCLAVE ,
        :CAJAS ,
        :PIEZAS ,
        :PZACAJA ,
        :texto1,
        :texto2,
        :texto3,
        :texto4,
        :texto5,
        :texto6,
        :numero1,
        :numero2,
        :numero3,
        :numero4,
        :fecha1,
        :fecha2
 
   DO
   BEGIN
    NUMERO = :NUMERO + 1;



        select COALESCE(sum(cantidad),0) from inventariokitdesg_view
        where  productoid = :PRODUCTOID and
              coalesce(lote,'') = coalesce(:PRODUCTOLOTE,'') AND
              coalesce(fechavence,current_date) = coalesce(:FECHAVENCE,current_date)
        into :CANTIDADTEORICA;

        
        CANTIDADDIFERENCIA = :CANTIDADFISICA - :CANTIDADTEORICA;

           SUSPEND;

   END
    


   WHEN ANY DO
   BEGIN
      ERRORCODE = 1016;
      SUSPEND;
   END


END