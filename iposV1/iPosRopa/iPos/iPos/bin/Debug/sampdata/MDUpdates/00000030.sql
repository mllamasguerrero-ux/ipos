CREATE OR ALTER PROCEDURE REP_DOCTO (
    FECHAINI D_FECHA,
    FECHAFIN D_FECHA,
    TIPODOCTOID D_FK
)
RETURNS (
    NUMERO INTEGER,
    FECHA D_FECHA,
    FECHAHORA D_TIMESTAMP,
    TURNOCLAVE D_CLAVE,
    DOCTOFOLIO D_DOCTOFOLIO,
    IMPORTE D_IMPORTE,
    DESCUENTO D_IMPORTE,
    SUBTOTAL D_IMPORTE,
    IVA D_IMPORTE,
    TOTAL D_IMPORTE)
AS
BEGIN
   NUMERO = 0;
      turnoclave = 'N/D';

   FOR SELECT
      D.FECHA,
      D.FECHAHORA,
      COALESCE(T.CLAVE, ' '),
      D.FOLIO,
      D.IMPORTE,
      D.DESCUENTO,
      D.SUBTOTAL,
      D.IVA,
      D.TOTAL
   FROM DOCTO D
      LEFT JOIN TURNO T
         ON T.ID = D.TURNOID
   WHERE TIPODOCTOID = :TIPODOCTOID
     AND D.FECHA BETWEEN :FECHAINI AND :FECHAFIN
     AND D.ESTATUSDOCTOID = 1
   INTO
      :FECHA ,
      :FECHAHORA ,
      :TURNOCLAVE,
      :DOCTOFOLIO ,
      :IMPORTE ,
      :DESCUENTO,
      :SUBTOTAL,
      :IVA ,
      :TOTAL
   DO
   BEGIN
      NUMERO = :NUMERO + 1;
      SUSPEND;
   END

   if (:numero = 0) then
   begin
      numero = 0;
      fecha = current_date;
      fechahora = current_date;
      turnoclave = 'N/D';
      doctofolio = 0;
      IMPORTE = 0.00;
      SUBTOTAL = 0.00;
      IVA = 0.00;
      TOTAL = 0.00;
      -- sin suspend para no regresar renglon falso
   end

END;