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
BEGIN
   

     FECHA = CURRENT_DATE;
     FOLIO = 0;
     SALDO = 0;
     SALDOAAPLICAR = 0;

     SELECT PERSONAID, TIPODOCTOID FROM DOCTO WHERE ID = :DOCTOID INTO :PERSONAID, :TIPODOCTOSOURCEID;

     

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