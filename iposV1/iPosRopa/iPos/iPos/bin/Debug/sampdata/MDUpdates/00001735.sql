create or alter procedure REASIGNARUTILIDADES (
    FECHAINICIO D_FECHA,
    FECHAFIN D_FECHA,
    CLIENTEID D_FK,
    VENDEDORUTILIDADIDNEW D_FK)
returns (
    ERRORCODE type of D_ERRORCODE)
as
declare variable MANEJAQUOTA D_BOOLCN;
declare variable DELTALOGRO D_PRECIO;
declare variable DELTAUTILIDAD D_PRECIO;
declare variable ANIO integer;
declare variable MES integer;
declare variable QUOTAIDOLD D_FK;
declare variable QUOTAIDNEW D_FK;
declare variable VENDEDORUTILIDADIDOLD D_FK;
BEGIN
       ERRORCODE = 0;

   
      SELECT MANEJAQUOTA FROM PARAMETRO INTO :MANEJAQUOTA;
         IF(:MANEJAQUOTA = 'S') THEN
         BEGIN

           FOR  SELECT SUM(COALESCE(DOCTO.total, 0) * COALESCE(TIPODOCTO.sentidopago, 0)) DELTALOGRO,
                    SUM(COALESCE(DOCTO.utilidad, 0) * COALESCE(TIPODOCTO.sentidopago, 0)) DELTAUTILIDAD ,
                    DOCTO.vendedorutilidadid ,
                     EXTRACT (YEAR FROM DOCTO.FECHA) ANIO,
                     EXTRACT (MONTH FROM DOCTO.FECHA) MES
                    FROM docto INNER JOIN TIPODOCTO ON TIPODOCTO.ID = DOCTO.TIPODOCTOID
                    WHERE DOCTO.personaid = :CLIENTEID AND DOCTO.TIPODOCTOID IN (21,22,23,24,25,26)
                    AND DOCTO.estatusdoctoid = 1
                    AND COALESCE(DOCTO.FECHA, CURRENT_DATE) >= :FECHAINICIO
                    AND COALESCE(DOCTO.FECHA, CURRENT_DATE) <= :FECHAFIN
                    GROUP BY DOCTO.vendedorutilidadid ,EXTRACT (YEAR FROM DOCTO.FECHA),  EXTRACT (MONTH FROM DOCTO.FECHA)
                     INTO :deltalogro, :DELTAUTILIDAD, :VENDEDORUTILIDADIDOLD, :ANIO , :MES
           DO
           BEGIN


            SELECT ID FROM QUOTA WHERE VENDEDORID = :VENDEDORUTILIDADIDOLD AND ANIO = :ANIO AND MES = :MES INTO :QUOTAIDOLD;
            SELECT ID FROM QUOTA WHERE VENDEDORID = :VENDEDORUTILIDADIDNEW AND ANIO = :ANIO AND MES = :MES INTO :QUOTAIDNEW;


            IF(COALESCE(:QUOTAIDOLD,0) <> 0) THEN
            BEGIN
                UPDATE QUOTA SET LOGRO = COALESCE(LOGRO,0) - :DELTALOGRO  , UTILIDAD = COALESCE(UTILIDAD, 0) - :DELTAUTILIDAD
                WHERE ID = :QUOTAIDOLD ;
            END


            IF(COALESCE(:QUOTAIDNEW,0) <> 0) THEN
            BEGIN
                UPDATE QUOTA SET LOGRO = COALESCE(LOGRO,0) + :DELTALOGRO  , UTILIDAD = COALESCE(UTILIDAD, 0) + :DELTAUTILIDAD
                WHERE ID = :QUOTAIDNEW;
            END
            ELSE
            BEGIN
                INSERT INTO QUOTA (VENDEDORID, ANIO, MES, QUOTA, LOGRO, UTILIDAD)
                VALUES ( :VENDEDORUTILIDADIDNEW, :ANIO, :MES, 0, :deltalogro,  :DELTAUTILIDAD);
            END


            
            UPDATE DOCTO SET DOCTO.vendedorutilidadid = :VENDEDORUTILIDADIDNEW WHERE
                   DOCTO.personaid = :CLIENTEID AND DOCTO.TIPODOCTOID IN (21,22,23,24,25,26)
                    AND DOCTO.estatusdoctoid = 1 AND
                    COALESCE(DOCTO.FECHA, CURRENT_DATE) >= :FECHAINICIO
                    AND COALESCE(DOCTO.FECHA, CURRENT_DATE) <= :FECHAFIN
                    AND  EXTRACT (YEAR FROM DOCTO.FECHA) = :ANIO
                    AND  EXTRACT (MONTH FROM DOCTO.FECHA) = :MES
                    AND DOCTO.vendedorutilidadid =  :VENDEDORUTILIDADIDOLD;

            END
         END



      SUSPEND;

    WHEN ANY DO
   BEGIN
      ERRORCODE = 1016;
      SUSPEND;
   END
END