CREATE OR ALTER PROCEDURE REP_VENTA (
    fechaini d_fecha,
    fechafin d_fecha,
    tipodoctoid d_fk)
returns (
    numero integer,
    fecha d_fecha,
    fechahora d_timestamp,
    turnoclave d_clave,
    doctofolio d_doctofolio,
    importe d_importe,
    descuento d_importe,
    subtotal d_importe,
    iva d_importe,
    total d_importe,
    sucursalT d_nombre,
    tipoDoc d_nombre)
as
BEGIN
   NUMERO = 0;


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
      SUCURSALT ,
      TIPODOC
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
      :TOTAL ,
      :SUCURSALT ,
      :TIPODOC
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
      SUCURSALT = ' ';
      TIPODOC = ' ';
      -- sin suspend para no regresar renglon falso
   end

END
