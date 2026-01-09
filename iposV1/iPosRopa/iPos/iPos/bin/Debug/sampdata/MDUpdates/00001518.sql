create or alter procedure REP_DOCTO_DET (
    FECHAINI D_FECHA,
    FECHAFIN D_FECHA,
    TIPODOCTOID D_FK)
returns (
    NUMERO integer,
    FECHA D_FECHA,
    FECHAHORA D_TIMESTAMP,
    TURNOCLAVE D_CLAVE,
    DOCTOFOLIO D_DOCTOFOLIO,
    PRODUCTOCLAVE D_CLAVE,
    PRODUCTODESCRIPCION D_DESCRIPCION,
    CANTIDAD D_CANTIDAD,
    PRECIO D_PRECIO,
    IMPORTE D_IMPORTE,
    DESCUENTO D_IMPORTE,
    SUBTOTAL D_IMPORTE,
    IVA D_IMPORTE,
    TOTAL D_IMPORTE,
    SUCURSALT D_NOMBRE,
    TIPODOC D_NOMBRE,
    PERSONA D_NOMBRE,
    ESTATUSDOCTONOMBRE D_NOMBRE,
    VENDEDOR D_NOMBRE,
    IEPS D_IMPORTE,
    IMPUESTO D_IMPORTE,
    TASAIEPS D_PORCENTAJE)
as
BEGIN
   NUMERO = 0;

   FOR SELECT
      D.FECHA,
      D.FECHAHORA,
      COALESCE(T.CLAVE, 'N/D'),
      D.FOLIO,
      P.CLAVE,
      P.DESCRIPCION1,
      M.CANTIDAD,
      M.PRECIO,
      M.IMPORTE,
      M.DESCUENTO,
      M.SUBTOTAL,
      M.IVA,
      M.TOTAL ,
      coalesce(S.NOMBRE,' ') as SUCURSALT ,
      coalesce(TD.nombre, ' ') AS TIPODOC,
      PR.NOMBRE as PERSONA  , 
      ed.nombre estatusdoctonombre ,
      U.nombre VENDEDORNOMBRE  ,
      M.ieps, 
      M.IMPUESTO ,
      M.TASAIEPS


   FROM MOVTO M
      LEFT JOIN DOCTO D
         ON D.ID = M.DOCTOID
      LEFT JOIN PRODUCTO P
         ON P.ID = M.PRODUCTOID
      LEFT JOIN TURNO T
         ON T.ID = D.TURNOID 
       left join SUCURSAL S
         ON S.ID = D.SUCURSALTID
        left join TIPODOCTO  TD
         on  TD.id = d.tipodoctoid
         left join PERSONA PR
          on PR.id = D.personaid  
          left join ESTATUSDOCTO ED
            on ED.id = d.estatusdoctoid
            left join PERSONA U
                on D.vendedorid = u.id
   WHERE ( D.TIPODOCTOID = :TIPODOCTOID  OR (:TIPODOCTOID = -21 AND D.TIPODOCTOID IN (21,31,23))
          OR (:TIPODOCTOID = -31 AND d.TIPODOCTOID IN (31,81)) )
     AND D.FECHA BETWEEN :FECHAINI AND :FECHAFIN
     AND D.ESTATUSDOCTOID = 1
   INTO
      :FECHA ,
      :FECHAHORA ,
      :TURNOCLAVE,
      :DOCTOFOLIO ,
      :PRODUCTOCLAVE ,
      :PRODUCTODESCRIPCION ,
      :CANTIDAD,
      :PRECIO ,
      :IMPORTE ,
      :DESCUENTO,
      :SUBTOTAL,
      :IVA ,
      :TOTAL ,
      :SUCURSALT ,
      :TIPODOC ,
      :PERSONA ,
      :ESTATUSDOCTONOMBRE  ,
      :VENDEDOR  ,
      :IEPS,
      :IMPUESTO ,
      :TASAIEPS
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
      TURNOCLAVE = 'N/D';
      doctofolio = 0;
      productoclave = '';
      productodescripcion = '';
      cantidad = 0;
      PRECIO = 0.00;
      IMPORTE = 0.00;
      SUBTOTAL = 0.00;
      IVA = 0.00;
      TOTAL = 0.00; 
      SUCURSALT = ' ';
      TIPODOC = ' ';
       PERSONA = ' ';
       ESTATUSDOCTONOMBRE = ' ';
       IEPS = 0;
       IMPUESTO = 0;
       TASAIEPS = 0;
      -- sin suspend para no regresar renglon falso
   end

END