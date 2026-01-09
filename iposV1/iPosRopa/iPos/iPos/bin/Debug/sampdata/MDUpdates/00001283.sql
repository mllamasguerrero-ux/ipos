create or alter procedure REP_VENTA (
    FECHAINI D_FECHA,
    FECHAFIN D_FECHA,
    TIPODOCTOID D_FK)
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
    SUCURSALT D_NOMBRE,
    TIPODOC D_NOMBRE,
    SALDO D_PRECIO,
    ESTATUSDOCTONOMBRE D_NOMBRE,
    ESFACTURAELECTRONICA D_BOOLCN,
    SERIEFOLIOSAT D_NOMBRE,
    PERSONA D_NOMBRE,
    VENDEDOR D_NOMBRE)
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
      TIPODOC ,
      SALDO ,
      ESTATUSDOCTONOMBRE ,
      ESFACTURAELECTRONICA ,
      SERIEFOLIOSAT ,
      PERSONA   ,
      VENDEDOR
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
      :TIPODOC ,
      :SALDO ,
      :ESTATUSDOCTONOMBRE ,
      :ESFACTURAELECTRONICA ,
      :SERIEFOLIOSAT ,
      :PERSONA ,
      :VENDEDOR
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
      SALDO  = 0.00;
      ESTATUSDOCTONOMBRE  = ' ';
      ESFACTURAELECTRONICA  = 'N';
      SERIEFOLIOSAT  = ' ';
      PERSONA = ' ';
      VENDEDOR = '';
      -- sin suspend para no regresar renglon falso
   end

END