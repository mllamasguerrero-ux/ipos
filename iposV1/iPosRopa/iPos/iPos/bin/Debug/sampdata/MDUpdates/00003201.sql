create or alter procedure VALIDAR_PRECIO (
    PRODUCTOID D_FK,
    PRECIO D_PRECIO,
    PRECIOSTD D_PRECIO,
    COSTO D_COSTO,
    PERSONAID D_FK,
    TIPODOCTOID D_FK,
    SUBTIPODOCTOID D_FK)
returns (
    TIENEDERECHO D_BOOLCN,
    MINUTILIDADGENERAL D_PORCENTAJE,
    MINUTILIDADPRODUCTO D_PORCENTAJE,
    MINUTILIDAD D_PORCENTAJE,
    COSTOMASUTILIDADMINIMA D_PRECIO,
    ERRORCODE D_ERRORCODE)
as
declare variable PRECIOMINIMO D_PRECIO;
BEGIN
   ERRORCODE = 0;


    IF(COALESCE(:SUBTIPODOCTOID ,0) = 7 ) THEN
    BEGIN
      TIENEDERECHO = 'S';
      ERRORCODE = 0;
      SUSPEND;
      EXIT;
    END

   IF(:TIPODOCTOID IN (22)) THEN
   BEGIN
        -- Validar si el usuario tiene derecho a cambiar el precio.
        SELECT ACCESO
        FROM GET_DERECHO(:PERSONAID, 10011)
        INTO :TIENEDERECHO;
   END
   ELSE
   BEGIN  
        -- Validar si el usuario tiene derecho a cambiar el precio.
        SELECT ACCESO
        FROM GET_DERECHO(:PERSONAID, 10002)
        INTO :TIENEDERECHO;

        IF (:TIENEDERECHO <> 'S') THEN
        BEGIN     
                SELECT ACCESO
                FROM GET_DERECHO(:PERSONAID, 10014)
                INTO :TIENEDERECHO;
        END

        IF (:TIENEDERECHO <> 'S') THEN
        BEGIN     
                SELECT ACCESO
                FROM GET_DERECHO(:PERSONAID, 10024)
                INTO :TIENEDERECHO;
        END
   END




   -- Si el usuario no tiene derecho a cambiar precios.
   IF (:TIENEDERECHO <> 'S' and :PERSONAID <> 0) THEN
   BEGIN


      ERRORCODE = 1078;
      SUSPEND;
      EXIT;
   END



   -- Si el usuario tiene derecho a cambiar precios.
   -- Validar si el precio esta bajo el minimo o no.
   SELECT PRECIOMINIMO
   FROM GET_PRECIOMINIMO(:PRODUCTOID,:PERSONAID)
   INTO :PRECIOMINIMO;






   -- Si el precio esta bajo el minimo, pero arriba del costo.
   IF ((:PRECIO < :PRECIOMINIMO) AND (:PRECIO >= :COSTO)) THEN
   BEGIN


    SELECT COALESCE(MINUTILIDAD,0) FROM PRODUCTO WHERE ID = :PRODUCTOID INTO :MINUTILIDADPRODUCTO;

    IF(:MINUTILIDADPRODUCTO = 0) then
    BEGIN
        select first 1 COALESCE(minutilidad,0) from parametro into :MINUTILIDADGENERAL;

        MINUTILIDAD = :MINUTILIDADGENERAL;
    END
    ELSE
    BEGIN
        MINUTILIDAD = :MINUTILIDADPRODUCTO;
    END

    COSTOMASUTILIDADMINIMA = :COSTO * (1 + (:MINUTILIDAD/100));

    IF(  :COSTOMASUTILIDADMINIMA >  :PRECIO ) THEN
    BEGIN  
      -- Validar si el usuario tiene derecho a cambiar el precio BAJO EL MINIMO.
      SELECT ACCESO
      FROM GET_DERECHO(:PERSONAID, 10004)
      INTO :TIENEDERECHO;
    END
    ELSE
    BEGIN  
      -- Validar si el usuario tiene derecho a cambiar el precio BAJO EL MINIMO.
      SELECT ACCESO
      FROM GET_DERECHO(:PERSONAID, 10003)
      INTO :TIENEDERECHO;
    END




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
END