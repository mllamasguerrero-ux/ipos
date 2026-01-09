create or alter procedure PERSONA_AJUSTAR_SALDOS (
    PERSONAID D_FK)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable SALDOSPOSITIVOS D_PRECIO;
declare variable SALDOSNEGATIVOS D_PRECIO;
declare variable SALDOAPARTADOPOSITIVO D_PRECIO;
declare variable SALDOAPARTADONEGATIVO D_PRECIO;
BEGIN
  
      SELECT COALESCE(SUM(COALESCE(case when d.tipodoctoid = 201 then D.SALDO * -1
                                        ELSE D.SALDO end ,0)) ,0)
      FROM DOCTO D
      WHERE (D.tipodoctoid IN (22,11,15,201)  or (D.tipodoctoid IN (33) and coalesce(d.subtipodoctoid,0) <> 8) )
      AND COALESCE(case when d.tipodoctoid = 201 then D.SALDO * -1
                        ELSE D.SALDO end ,0) > 0
      AND D.PERSONAID = :PERSONAID
      and (D.estatusdoctoid = 1   )
      INTO :SALDOSPOSITIVOS;

      SELECT COALESCE(SUM(COALESCE(case when d.tipodoctoid = 202 then D.SALDO * -1 ELSE D.SALDO end ,0)) ,0)
      FROM DOCTO D
      WHERE (D.tipodoctoid IN (21,24,12,202)  or (D.tipodoctoid IN (31) and coalesce(d.subtipodoctoid,0) <> 8)  )
      AND COALESCE(case when d.tipodoctoid = 202 then D.SALDO * -1 ELSE D.SALDO end ,0) > 0
      AND D.PERSONAID = :PERSONAID
      and (D.estatusdoctoid = 1   )
      INTO :SALDOSNEGATIVOS;


      
      /*SELECT COALESCE(SUM(COALESCE(D.SALDO ,0)) ,0)
      FROM DOCTO D
      WHERE D.tipodoctoid IN (26) AND D.SALDO > 0 AND D.PERSONAID = :PERSONAID
      and (D.estatusdoctoid = 1  )
      INTO :SALDOAPARTADOPOSITIVO;

      SELECT COALESCE(SUM(COALESCE(D.SALDO ,0)) ,0)
      FROM DOCTO D
      WHERE ((D.tipodoctoid IN (25) and d.mercanciaentregada = 'N') )AND D.SALDO > 0 AND D.PERSONAID = :PERSONAID
      and (D.estatusdoctoid = 1   )
      INTO :SALDOAPARTADONEGATIVO;   */

      
      UPDATE PERSONA SET
      SALDOSPOSITIVOS = :SALDOSPOSITIVOS ,
      SALDOSNEGATIVOS = :SALDOSNEGATIVOS
      WHERE ID = :PERSONAID;

      /*update personaaapartado set
      SALDOAPARTADOPOSITIVO = :SALDOAPARTADOPOSITIVO,
      SALDOAPARTADONEGATIVO = :SALDOAPARTADONEGATIVO
      where id =  */



   ERRORCODE = 0;
   SUSPEND;
   
    WHEN ANY DO
    BEGIN
        ERRORCODE = 1009;
        SUSPEND;
    END
END