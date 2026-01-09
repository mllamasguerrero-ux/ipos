create or alter procedure GET_INVFIS_LISTA_P_KIT (
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
    ALMACENID D_FK,
    ALMACENNOMBRE D_NOMBRE_NULL,
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
                                    COALESCE(CANTIDADSURTIDA,0) CANTIDADSURTIDA,
                                        movto.id  AS movtoid,
                                        producto.clave AS productoclave,
                                        SUM((CASE WHEN (movto.cajas IS NULL) THEN 0 ELSE movto.cajas END)) AS cajas,
                                        SUM((CASE WHEN (movto.piezas IS NULL) THEN 0 ELSE movto.piezas END)) AS piezas,
                                        producto.pzacaja ,
                                        DOCTO.ALMACENID,
                                        almacen.nombre ALMACENNOMBRE,
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
                      
                        FROM            producto
                         LEFT OUTER JOIN
                            movto ON movto.productoid = producto.id AND movto.doctoid = :DOCTOID
                         LEFT OUTER JOIN
                            DOCTO ON DOCTO.ID = movto.doctoid
                                    LEFT OUTER JOIN
                                        almacen ON DOCTO.ALMACENID = almacen.id

                          LEFT JOIN PRODUCTOCARACTERISTICAS c ON c.productoid = PRODUCTO.ID


WHERE        (:TODOSLOSPRODUCTOS = 1) AND (producto.inventariable = 'S') OR
                         (movto.doctoid = :DOCTOID) AND (producto.inventariable = 'S')
GROUP BY movto.id, movto.doctoid, producto.id, producto.nombre, producto.descripcion1, movto.lote, movto.fechavence, movto.cantidadsurtida, producto.clave, producto.pzacaja, movto.lote, movto.fechavence, movto.cantidadsurtida,
                         DOCTO.ALMACENID, almacen.nombre,

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
        :CANTIDADFISICA ,
        :MOVTOID ,
        :PRODUCTOCLAVE ,
        :CAJAS ,
        :PIEZAS ,
        :PZACAJA ,
        :ALMACENID,
        :ALMACENNOMBRE,
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
              coalesce(fechavence,current_date) = coalesce(:FECHAVENCE,current_date) AND
              coalesce(almacenid,1) = coalesce(:almacenid,1)
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