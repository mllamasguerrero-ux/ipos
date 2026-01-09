CREATE OR ALTER PROCEDURE APLICAR_DESCUENTO_VALE (
    doctoid d_pk,
    numerovale d_descripcion)
returns (
    errorcode d_errorcode)
as
declare variable movtoid d_fk;
declare variable descuentovale d_porcentaje;
declare variable importe d_precio;
declare variable subtotal d_precio;
declare variable iva d_precio;
declare variable total d_precio;
declare variable listapreciocliente varchar(1);
BEGIN
   -- Tambien al actualizar otro campo que no es totales, este total va a ser cero.
   -- por ejemplo al actualizar estatus.

      SELECT FIRST 1 COALESCE(DESCUENTOVALE,0)
      FROM PARAMETRO
      INTO :DESCUENTOVALE ;

      IF(:DESCUENTOVALE = 0 ) THEN
      BEGIN
         ERRORCODE = 0;
         SUSPEND;
      END


            
   SELECT CAST(COALESCE(c.LISTAPRECIOID, 1) AS CHAR(1))
   FROM   docto d
      LEFT JOIN persona c on d.personaid = c.id
   WHERE d.ID = :DOCTOID
   INTO :LISTAPRECIOCLIENTE;


   
   IF (:LISTAPRECIOCLIENTE = '1'  ) THEN
   BEGIN


      UPDATE MOVTO
      SET
        PRECIO    = ROUND((MOVTO.PRECIO * ((100 - :DESCUENTOVALE)/100)),2),
        DESCUENTO = MOVTO.PRECIOLISTA - ROUND((MOVTO.PRECIO * ((100 - :DESCUENTOVALE)/100)),2), --PRECIO LISTA - PRECIONUEVO
        SUBTOTAL =  ROUND( ROUND((MOVTO.PRECIO * ((100 - :DESCUENTOVALE)/100)),2) * MOVTO.CANTIDAD , 2) ,    --PRECIONUEVO * CANTIDAD
        IVA      =  ((ROUND( ROUND((MOVTO.PRECIO * ((100 - :DESCUENTOVALE)/100)),2) * MOVTO.CANTIDAD , 2)) * (COALESCE (MOVTO.tasaiva,0)/100)) ,  --SUBTOTAL * TASAIVA
        TOTAL    = (ROUND( ROUND((MOVTO.PRECIO * ((100 - :DESCUENTOVALE)/100)),2) * MOVTO.CANTIDAD , 2))     +       ((ROUND( ROUND((MOVTO.PRECIO * ((100 - :DESCUENTOVALE)/100)),2) * MOVTO.CANTIDAD , 2)) * (COALESCE (MOVTO.tasaiva,0)/100)), -- SUBTOTAL + IVA
        DESCUENTOPORCENTAJE = COALESCE(MOVTO.DESCUENTOPORCENTAJE,0) + :DESCUENTOVALE

       WHERE ID in ( SELECT
                        M.id
                        FROM MOVTO M
                        INNER JOIN PRODUCTO P
                        ON P.ID = M.PRODUCTOID
                        WHERE  M.DOCTOID = :DOCTOID
                        AND P.tipoabc = 'S' AND M.ingresopreciomanual = 'N');



        update docto set referencias =:NUMEROVALE where id = :DOCTOID;

    END

   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1011;
      SUSPEND;
   END
END
