CREATE OR ALTER PROCEDURE APLICAR_DESCUENTO_VALE (
    doctoid d_pk,
    numerovale d_descripcion)
returns (
    errorcode d_errorcode)
as
declare variable movtoid d_fk;
declare variable descuentovale d_porcentaje;
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

      /*FOR SELECT
      M.id
   FROM MOVTO M
      INNER JOIN PRODUCTO P
         ON P.ID = M.PRODUCTOID
   WHERE  M.DOCTOID = DOCTOID
       AND P.tipoabc = 'S'
   INTO
      :MOVTOID
   DO
   BEGIN

   UPDATE MOVTO
   SET

      SUBTOTAL = MOVTO.subtotal * ((100 - :DESCUENTOVALE)/100),
      IVA = MOVTO.IVA * ((100 - :DESCUENTOVALE)/100),
      TOTAL = MOVTO.TOTAL * ((100 - :DESCUENTOVALE)/100) ,
      PRECIO = MOVTO.PRECIO * ((100 - :DESCUENTOVALE)/100) ,
      DESCUENTOPORCENTAJE = COALESCE(MOVTO.DESCUENTOPORCENTAJE,0) + :DESCUENTOVALE ,

      
      DESCUENTO = COALESCE(movto.IMPORTE,0) - ( COALESCE(MOVTO.subtotal,0) * ((100 - :DESCUENTOVALE)/100))

   WHERE ID = :MOVTOID;
  END   */

     UPDATE MOVTO
   SET

      SUBTOTAL = MOVTO.subtotal * ((100 - :DESCUENTOVALE)/100),
      IVA = MOVTO.IVA * ((100 - :DESCUENTOVALE)/100),
      TOTAL = MOVTO.TOTAL * ((100 - :DESCUENTOVALE)/100) ,
      PRECIO = MOVTO.PRECIO * ((100 - :DESCUENTOVALE)/100) ,
      DESCUENTOPORCENTAJE = COALESCE(MOVTO.DESCUENTOPORCENTAJE,0) + :DESCUENTOVALE ,

      
      DESCUENTO = COALESCE(movto.IMPORTE,0) - ( COALESCE(MOVTO.subtotal,0) * ((100 - :DESCUENTOVALE)/100))

   WHERE ID in ( SELECT
      M.id
   FROM MOVTO M
      INNER JOIN PRODUCTO P
         ON P.ID = M.PRODUCTOID
   WHERE  M.DOCTOID = DOCTOID
       AND P.tipoabc = 'S' );


       update docto set referencias =:NUMEROVALE where id = :DOCTOID;

   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1011;
      SUSPEND;
   END
END