create or alter procedure CORTERECOLECCION_INSERT (
    CREADOPOR_USERID type of D_FK,
    ACTIVO type of D_BOOLCS,
    ENCARGADOID type of D_FK,
    FECHAHORA type of D_TIMESTAMP,
    MONTO type of D_PRECIO,
    OBSERVACIONES D_STDTEXT_LARGE)
returns (
    CORTERECOLECCIONID type of D_FK,
    ERRORCODE type of D_ERRORCODE)
as
declare variable FECHAULTIMA D_FECHA;
BEGIN

  ERRORCODE = 0;





   IF (:FECHAHORA IS NULL) THEN
   BEGIN
      FECHAHORA = CURRENT_TIME;
   END




        INSERT INTO CORTERECOLECCION
        (


            ACTIVO,
            CREADOPOR_USERID,
            ENCARGADOID,
            FECHAHORA,
            MONTO,
            OBSERVACIONES
         )
        Values (
            :ACTIVO,
            :CREADOPOR_USERID,
            :ENCARGADOID,
            :FECHAHORA,
            :MONTO,
            :OBSERVACIONES
        )
   RETURNING ID INTO :CORTERECOLECCIONID;

   IF ((:CORTERECOLECCIONID IS NULL) OR (:CORTERECOLECCIONID = 0)) THEN
   BEGIN
      ERRORCODE = 1002;
   END

   SUSPEND;
END