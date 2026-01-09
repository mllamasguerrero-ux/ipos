create or alter procedure REP_COMPRA (
    FECHAINI D_FECHA,
    FECHAFIN D_FECHA)
returns (
    NUMERO integer,
    FECHA D_FECHA,
    FECHAHORA D_TIMESTAMP,
    TURNOCLAVE D_CLAVE,
    DOCTOFOLIO D_DOCTOFOLIO,
    IMPORTE D_IMPORTE,
    DESCUENTO D_IMPORTE,
    SUBTOTAL D_IMPORTE,
    IVA D_IMPORTE,
    TOTAL D_IMPORTE,
    PROVEEDOR D_NOMBRE)
as
declare variable TIPODOCTOID D_FK;
BEGIN
   NUMERO = 0;

   TIPODOCTOID = 11;

   FOR SELECT
      NUMERO,
      FECHA,
      FECHAHORA,
      TURNOCLAVE,
      DOCTOFOLIO,
      IMPORTE,
      DESCUENTO,
      SUBTOTAL,
      IVA,
      TOTAL,
      PERSONA
   FROM REP_DOCTO(:FECHAINI, :FECHAFIN, :TIPODOCTOID)
   INTO
      :NUMERO,
      :FECHA ,
      :FECHAHORA ,
      :TURNOCLAVE,
      :DOCTOFOLIO ,
      :IMPORTE ,
      :DESCUENTO,
      :SUBTOTAL,
      :IVA ,
      :TOTAL,
      :PROVEEDOR
   DO
   BEGIN
      SUSPEND;
   END

   if (:numero = 0) then
   begin
      numero = 0;
      fecha = current_date;
      fechahora = current_date;
      TURNOCLAVE = 'N/D';
      doctofolio = 0;
      IMPORTE = 0.00;
      SUBTOTAL = 0.00;
      IVA = 0.00;
      TOTAL = 0.00;
      PROVEEDOR = ' ';
      -- sin suspend para no regresar renglon falso
   end

END