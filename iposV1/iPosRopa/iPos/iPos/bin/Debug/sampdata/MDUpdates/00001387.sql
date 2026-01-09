create or alter procedure GET_DOCTOS (
    FECHAINI D_FECHA,
    FECHAFIN D_FECHA)
returns (
    FECHA D_FECHA,
    FECHAHORA D_TIMESTAMP,
    TIPODOCTOCLAVE D_CLAVE,
    DOCTOFOLIO D_DOCTOFOLIO,
    SUBTOTAL D_IMPORTE,
    IVA D_IMPORTE,
    TOTAL D_IMPORTE,
    COSTOIMPORTE D_IMPORTE,
    IEPS D_IMPORTE,
    IMPUESTO D_IMPORTE)
as
declare variable NUMERO integer;
BEGIN
   NUMERO = 0;
  
   FOR SELECT
      D.FECHA,
      D.FECHAHORA,
      TD.CLAVE,
      D.FOLIO,
      SUM(M.SUBTOTAL),
      SUM(M.IVA),
      SUM(M.TOTAL),
      SUM(M.COSTOIMPORTE),
      SUM(M.IEPS),  
      SUM(M.IMPUESTO)
   FROM DOCTO D
      LEFT JOIN TIPODOCTO TD
         ON TD.ID = D.TIPODOCTOID
      LEFT JOIN MOVTO M
         ON M.DOCTOID = D.ID
   WHERE D.FECHA BETWEEN :FECHAINI AND :FECHAFIN
     AND D.ESTATUSDOCTOID = 1
   GROUP BY
      D.FECHA,
      D.FECHAHORA,
      TD.CLAVE,
      D.FOLIO
   ORDER BY D.FECHAHORA
   INTO
      :FECHA,
      :FECHAHORA,
      :TIPODOCTOCLAVE,
      :DOCTOFOLIO,
      :SUBTOTAL,
      :IVA,
      :TOTAL,
      :COSTOIMPORTE ,
      :IEPS,
      :IMPUESTO
   DO
   BEGIN
      NUMERO = :NUMERO + 1;
      SUSPEND;
   END

   if (:numero = 0) then
   begin
      FECHA = CURRENT_DATE;
      FECHAHORA = CURRENT_TIMESTAMP;
      TIPODOCTOCLAVE = '';
      DOCTOFOLIO = 0;
      SUBTOTAL = 0.00;
      IVA = 0.00;
      TOTAL = 0.00;
      IEPS = 0;
      IMPUESTO = 0;
      -- sin suspend para no regresar renglon falso
   end

END