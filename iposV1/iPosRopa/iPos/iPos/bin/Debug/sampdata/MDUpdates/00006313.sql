create or alter procedure CONTRARECIBO_INSERT (
    CREADOPOR_USERID type of D_FK,
    FECHA type of D_FECHA,
    PERSONAID type of D_FK,
    VENDEDORID type of D_FK,
    ESTATUSID type of D_FK,
    TOTAL type of D_PRECIO,
    ABONO type of D_PRECIO,
    SALDO type of D_PRECIO,
    OBSERVACIONES D_STDTEXT_LARGE,
    ESTATUSPAGOID type of D_FK)
returns (
    CONTRARECIBOID type of D_FK,
    ERRORCODE type of D_ERRORCODE)
as
declare variable FECHAULTIMA D_FECHA;
BEGIN

  ERRORCODE = 0;

   -- Validar la fecha VS ultima fecha de operacion
   SELECT FECHAULTIMA
   FROM PARAMETRO
   INTO :FECHAULTIMA;

   IF (:FECHAULTIMA IS NOT NULL)  THEN
   BEGIN
      IF (:FECHAULTIMA > CURRENT_DATE) THEN
      BEGIN
         ERRORCODE = 1067;
         SUSPEND;
         EXIT;
      END

      IF (:FECHAULTIMA < (CURRENT_DATE-3)) THEN
      BEGIN
         ERRORCODE = 1068;
         SUSPEND;
         EXIT;
      END
   END




   IF (:FECHA IS NULL) THEN
   BEGIN
      FECHA = CURRENT_DATE;
   END





   INSERT INTO CONTRARECIBOHDR (
        CREADOPOR_USERID,
        FECHA,
        PERSONAID ,
        VENDEDORID ,
        ESTATUSID ,
        TOTAL ,
        ABONO ,
        SALDO ,
        OBSERVACIONES,
        ESTATUSPAGOID)
   VALUES (
        :CREADOPOR_USERID,
        :FECHA,
        :PERSONAID ,
        :VENDEDORID ,
        :ESTATUSID ,
        :TOTAL ,
        :ABONO ,
        :SALDO,
        :OBSERVACIONES,
        :ESTATUSPAGOID)
   RETURNING ID INTO :CONTRARECIBOID;

   IF ((:CONTRARECIBOID IS NULL) OR (:CONTRARECIBOID = 0)) THEN
   BEGIN
      ERRORCODE = 1002;
   END

   SUSPEND;
END