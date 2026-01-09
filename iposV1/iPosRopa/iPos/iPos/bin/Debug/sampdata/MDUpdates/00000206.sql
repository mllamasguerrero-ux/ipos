CREATE OR ALTER PROCEDURE VALIDAR_PRECIO (
    PRODUCTOID D_FK,
    PRECIO D_PRECIO,
    PRECIOSTD D_PRECIO,
    COSTO D_COSTO,
    PERSONAID D_FK)
RETURNS (
    TIENEDERECHO D_BOOLCN,
    ERRORCODE D_ERRORCODE)
AS
DECLARE VARIABLE PRECIOMINIMO D_PRECIO;
BEGIN
   -- Validar si el usuario tiene derecho a cambiar el precio.
   SELECT ACCESO
   FROM GET_DERECHO(:PERSONAID, 10002)
   INTO :TIENEDERECHO;

   -- Si el usuario no tiene derecho a cambiar precios.
   IF (:TIENEDERECHO <> 'S') THEN
   BEGIN
      ERRORCODE = 1078;
      SUSPEND;
      EXIT;
   END

   -- Si el usuario tiene derecho a cambiar precios.
   -- Validar si el precio esta bajo el minimo o no.
   SELECT PRECIOMINIMO
   FROM GET_PRECIOMINIMO(:PRODUCTOID)
   INTO :PRECIOMINIMO;

   -- Si el precio esta bajo el minimo, pero arriba del costo.
   IF ((:PRECIO < :PRECIOMINIMO) AND (:PRECIO >= :COSTO)) THEN
   BEGIN
      -- Validar si el usuario tiene derecho a cambiar el precio BAJO EL MINIMO.
      SELECT ACCESO
      FROM GET_DERECHO(:PERSONAID, 10003)
      INTO :TIENEDERECHO;

      -- Si el usuario no tiene derecho a cambiar precios BAJO EL MINIMO.
      IF (:TIENEDERECHO <> 'S') THEN
      BEGIN
         ERRORCODE = 1079;
         SUSPEND;
         EXIT;
      END
   END
   -- Si el precio esta abajo del costo pero mayor a cero.
   ELSE IF ((:PRECIO < :COSTO) AND (:PRECIO >= 0.00)) THEN
   BEGIN
      -- Validar si el usuario tiene derecho a cambiar el precio BAJO EL COSTO.
      SELECT ACCESO
      FROM GET_DERECHO(:PERSONAID, 10004)
      INTO :TIENEDERECHO;

      -- Si el usuario no tiene derecho a cambiar precios BAJO EL COSTO.
      IF (:TIENEDERECHO <> 'S') THEN
      BEGIN
         ERRORCODE = 1080;
         SUSPEND;
         EXIT;
      END
   END

   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1078;  -- No tiene derecho a cambiar precio.
      SUSPEND;
   END 
END;


