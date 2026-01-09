create or alter procedure DOCTO_PAGOS_PROCESO_RANGO (
    TIPODOCTOID D_FK,
    SUBTIPODOCTOID D_FK,
    FECHAINICIAL D_FECHA,
    FECHAFINAL D_FECHA,
    VENDEDORID D_FK,
    PERSONAID D_FK,
    NOTAS D_STDTEXT_MEDIUM,
    MONTOMAX D_IMPORTE)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable FORMAPAGOID D_FK;
declare variable IMPORTEPAGO D_IMPORTE;
declare variable CORTEID D_FK;
declare variable HAYCORTEACTIVO D_BOOLCN;
declare variable TIPOPAGOID D_FK;
declare variable FECHA D_FECHA;
declare variable FECHAHORA D_TIMESTAMP;
declare variable DOCTOID D_FK;
BEGIN



    IF( :FECHAINICIAL IS NULL or
        :FECHAFINAL IS NULL or
        :TIPODOCTOID IS NULL or
        COALESCE(:VENDEDORID,0) = 0) THEN
    BEGIN
        ERRORCODE = 5012;
        SUSPEND;
        EXIT;
    END


    -- ahora solo esta preparado para compras
    IF( COALESCE(:TIPODOCTOID ,0) NOT IN (11,-11,21,-21)) then
    BEGIN
        
        ERRORCODE = 1001;
        SUSPEND;
        EXIT;
    END

    
   SELECT HAYCORTEACTIVO,CORTEID,ERRORCODE
   FROM HAY_CORTE_ACTIVO(:VENDEDORID)
   INTO :HAYCORTEACTIVO, :CORTEID, :ERRORCODE;


   IF (:ERRORCODE > 0) THEN
   BEGIN
      SUSPEND;
      EXIT;
   END

   
   IF (:HAYCORTEACTIVO <> 'S') THEN
   BEGIN
      ERRORCODE = 1016;
      SUSPEND;
      EXIT;
   END


    FORMAPAGOID = 17;
    FECHA = CURRENT_DATE;
    FECHAHORA = CURRENT_TIME;




    FOR SELECT DOCTO.ID, DOCTO.saldo ,
        CASE WHEN COALESCE(TIPODOCTO.SENTIDOPAGO ,0) = 1 THEN 1
            WHEN  COALESCE(TIPODOCTO.SENTIDOPAGO ,0) = -1 THEN 2 ELSE 0
        END  TIPOPAGOID
        FROM DOCTO
        LEFT JOIN TIPODOCTO ON TIPODOCTO.ID = DOCTO.TIPODOCTOID
        WHERE
        DOCTO.ESTATUSDOCTOID = 1 AND  COALESCE(DOCTO.SALDO,0) > 0 AND
        (DOCTO.TIPODOCTOID = :TIPODOCTOID
            or (COALESCE(:TIPODOCTOID,0) = -11 AND DOCTO.TIPODOCTOID IN (11,12,13))  
            or (COALESCE(:TIPODOCTOID,0) = -21 AND DOCTO.TIPODOCTOID IN (21,22,23))

        )  AND
        (COALESCE(DOCTO.SUBTIPODOCTOID,0) = :SUBTIPODOCTOID or COALESCE(:SUBTIPODOCTOID,0) = -1 )  AND
        (COALESCE(:PERSONAID,0) = 0 or  DOCTO.PERSONAID = :PERSONAID ) AND
        DOCTO.FECHA >= :FECHAINICIAL AND DOCTO.FECHA <= :FECHAFINAL   AND
        (COALESCE(:MONTOMAX,0) = 0 or COALESCE(DOCTO.SALDO,0) <= COALESCE(:MONTOMAX,0) )
        INTO :DOCTOID, :IMPORTEPAGO, :TIPOPAGOID
        DO
        BEGIN


            IF(COALESCE(:TIPOPAGOID,0) <> 0) THEN
            BEGIN

        
               SELECT ERRORCODE
               FROM DOCTOPAGO_INSERT (
                CASE WHEN :TIPOPAGOID = 1 THEN :DOCTOID ELSE NULL END,
                :FORMAPAGOID,
                :FECHA,
                :FECHAHORA,
                :CORTEID,
                :IMPORTEPAGO,
                0.00,
                0.00 ,
                :TIPOPAGOID,
                CASE WHEN :TIPOPAGOID = 2 THEN :DOCTOID ELSE NULL END,--:DOCTOSALIDAID,
                'N',--:ESAPARTADO  ,
                1  ,
                NULL,--:BANCOTRANSFERENCIA,
                NULL,--:REFERENCIABANCARIATRANSFERENCIA ,
                :NOTAS  ,
                CURRENT_DATE,
                CURRENT_DATE ,
                'N',--:ESPAGOINICIAL ,
                1,
                NULL  ,
                NULL
                ) INTO :ERRORCODE;



               IF(COALESCE(:ERRORCODE,0) <> 0) THEN
               BEGIN
                      
                    SUSPEND;
                    EXIT;
               END

              END

        END








   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1016;
      SUSPEND;
   END
END