create or alter procedure REP_DOCTO (
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
    PERSONA D_NOMBRE,
    SALDO D_PRECIO,
    ESTATUSDOCTONOMBRE D_NOMBRE,
    ESFACTURAELECTRONICA D_BOOLCN,
    SERIEFOLIOSAT D_NOMBRE,
    VENDEDOR D_NOMBRE,
    VENDEDORDELCLIENTEID D_ID,
    VENDEDORDELCLIENTENOMBRE D_NOMBRE,
    VENDEDORDELCLIENTECLAVE D_CLAVE_NULL)
as
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
      D.TOTAL ,
      coalesce(S.NOMBRE,' ') as SUCURSALT ,
      coalesce(TD.nombre, ' ') AS TIPODOC,
      P.NOMBRE as PERSONA ,
      D.saldo, 
      ed.nombre estatusdoctonombre ,
      D.esfacturaelectronica ,
      coalesce(D.seriesat,'') || coalesce(D.foliosat,'') SERIEFOLIOSAT ,
      U.nombre VENDEDORNOMBRE ,
      coalesce(P.vendedorid,0) VENDEDORDELCLIENTEID,
      coalesce(uc.nombre,'') VENDEDORDELCLIENTENOMBRE ,
      coalesce(uc.clave,'') VENDEDORDELCLIENTECLAVE



   FROM DOCTO D
      LEFT JOIN TURNO T
         ON T.ID = D.TURNOID
       left join SUCURSAL S
         ON S.ID = D.SUCURSALTID
        left join TIPODOCTO  TD
         on  TD.id = d.tipodoctoid
         left join PERSONA P
          on P.id = D.personaid
          left join ESTATUSDOCTO ED
            on ED.id = d.estatusdoctoid
            left join PERSONA U
                on D.vendedorid = u.id  
            left join PERSONA Uc
                on P.vendedorid = uc.id
   WHERE (TIPODOCTOID = :TIPODOCTOID  OR (:TIPODOCTOID = -21 AND TIPODOCTOID IN (21,31,23,81))
          OR (:TIPODOCTOID = -31 AND TIPODOCTOID IN (31,81)) )
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
      :TOTAL ,
      :SUCURSALT ,
      :TIPODOC ,
      :PERSONA,
      :SALDO,
      :ESTATUSDOCTONOMBRE ,
      :ESFACTURAELECTRONICA  ,
      :SERIEFOLIOSAT  ,
      :VENDEDOR        ,
      :VENDEDORDELCLIENTEID,
      :VENDEDORDELCLIENTENOMBRE ,
      :VENDEDORDELCLIENTECLAVE
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
      SUCURSALT = ' ';
      TIPODOC = ' ';
       PERSONA = ' ';
       
      SALDO = 0.0;
      ESTATUSDOCTONOMBRE = '';
      ESFACTURAELECTRONICA = 'N';
      SERIEFOLIOSAT = '';
      VENDEDOR = '';

      
      VENDEDORDELCLIENTEID = 0;
      VENDEDORDELCLIENTENOMBRE = '';

      VENDEDORDELCLIENTECLAVE  = '';
      -- sin suspend para no regresar renglon falso
   end

END
