create or alter procedure CONTRARECIBO_ACUMULAR_TOTALES (
    CONTRARECIBOID D_FK)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable TOTAL D_PRECIO;
declare variable ABONO D_PRECIO;
declare variable SALDO D_PRECIO;
BEGIN

   SELECT SUM(COALESCE(TOTAL,0)) TOTAL, SUM(COALESCE(ABONO,0)) ABONO, SUM(COALESCE(SALDO,0)) SALDO FROM CONTRARECIBODTL WHERE CONTRARECIBOID = :CONTRARECIBOID
   INTO :TOTAL, :ABONO, :SALDO;

   -- Tambien al actualizar otro campo que no es totales, este total va a ser cero.
   -- por ejemplo al actualizar estatus.
   UPDATE CONTRARECIBOHDR SET
   TOTAL = :TOTAL, ABONO = :ABONO, SALDO = :SALDO
   WHERE ID = :CONTRARECIBOID;

   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1011;
      SUSPEND;
   END
END