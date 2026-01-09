create or alter procedure GET_CREDITO_LISTA_A_APLICAR (
    DOCTOID D_FK)
returns (
    DOCTOIDAPLICAR D_FK,
    FECHA D_FECHA,
    FOLIO D_DOCTOFOLIO,
    TIPODOCTOID D_FK,
    SALDO D_PRECIO,
    SALDOAAPLICAR D_PRECIO)
as
declare variable TIPODOCTOSOURCEID D_FK;
declare variable PERSONAID D_FK;
declare variable SALDOSOURCE D_PRECIO;
BEGIN
   

     FECHA = CURRENT_DATE;
     FOLIO = 0;
     SALDO = 0;
     SALDOAAPLICAR = 0;

     SELECT PERSONAID, TIPODOCTOID, SALDO
     FROM DOCTO
     WHERE ID = :DOCTOID INTO :PERSONAID, :TIPODOCTOSOURCEID, :SALDOSOURCE;

     --SI ES UNA VENTA QUE SE PAGO DEMAS CONSIDERALA COMO SI FUERA DEVOLUCION
     IF(:TIPODOCTOSOURCEID = 21 AND :SALDOSOURCE < 0) THEN
     BEGIN
           TIPODOCTOSOURCEID = 22;
     END

     

   if(:DOCTOID is null) then
   BEGIN
      --ERRORCODE = 1001;
      EXIT;
   END


       
   FOR 
      select d.id, d.fecha, d.folio, d.saldo, d.tipodoctoid from docto  d
      WHERE D.tipodoctoid IN (22) AND D.SALDO > 0 AND D.PERSONAID = :PERSONAID   and (D.estatusdoctoid = 1  )
      and :TIPODOCTOSOURCEID IN (21,24)
      UNION
      select d.id, d.fecha, d.folio, d.saldo, d.tipodoctoid from docto d
      WHERE (D.tipodoctoid IN (21,24)  or (D.tipodoctoid IN (25) and d.mercanciaentregada = 'S')  )AND D.SALDO > 0 AND D.PERSONAID = :PERSONAID and (D.estatusdoctoid = 1  )
      and :TIPODOCTOSOURCEID IN (22,201)
      UNION
      select d.id, d.fecha, d.folio, d.saldo, d.tipodoctoid from docto  d
      WHERE D.tipodoctoid IN (11,15) AND D.SALDO > 0 AND D.PERSONAID = :PERSONAID  and (D.estatusdoctoid = 1  )
      and :TIPODOCTOSOURCEID IN (12,202)
      UNION
      select d.id, d.fecha, d.folio, d.saldo, d.tipodoctoid from docto d
      WHERE (D.tipodoctoid IN (12) )AND D.SALDO > 0 AND D.PERSONAID = :PERSONAID  and (D.estatusdoctoid = 1  )
      and :TIPODOCTOSOURCEID IN (11,15)
      UNION
      select d.id, d.fecha, d.folio, d.saldo, d.tipodoctoid from docto d
      WHERE D.tipodoctoid IN (26) AND D.SALDO > 0 AND D.PERSONAID = :PERSONAID and (D.estatusdoctoid = 1  )
      and :TIPODOCTOSOURCEID IN (25)
      UNION
      select d.id, d.fecha, d.folio, d.saldo, d.tipodoctoid from docto d
      WHERE ((D.tipodoctoid IN (25) and d.mercanciaentregada = 'N') )AND D.SALDO > 0 AND D.PERSONAID = :PERSONAID and (D.estatusdoctoid = 1   )
      and :TIPODOCTOSOURCEID IN (26) 
      UNION
      select d.id, d.fecha, d.folio, d.saldo, d.tipodoctoid from docto  d
      WHERE D.tipodoctoid IN (1011,1015) AND D.SALDO > 0 AND D.PERSONAID = :PERSONAID  and (D.estatusdoctoid = 1  )
      and :TIPODOCTOSOURCEID IN (1012)
    INTO
            :DOCTOIDAPLICAR, :FECHA ,:FOLIO ,:SALDO, :TIPODOCTOID
             
   DO
   BEGIN
           SUSPEND;
   END








   WHEN ANY DO
   BEGIN
      --ERRORCODE = 1016;
      SUSPEND;
   END 


END