create or alter procedure RETIRO_CAJA_INSERT (
    ALMACENID type of D_FK,
    SUCURSALID type of D_FK,
    TIPODOCTOID type of D_FK,
    VENDEDORID type of D_FK,
    PERSONAID type of D_FK,
    CAJAID type of D_FK,
    REFERENCIA type of D_REFERENCIA,
    REFERENCIAS varchar(255),
    FECHA D_FECHA,
    VENCE D_FECHA,
    CORTEAPLICARID D_FK,
    CORTEACTUAL D_BOOLCN,
    FECHACORTE D_FECHA,
    CAJEROID D_FK)
returns (
    DOCTOID type of D_PK,
    ERRORCODE type of D_ERRORCODE)
as
declare variable DOCTOERRORCODE type of D_FK;
declare variable CORTEID D_FK;
declare variable SERIE D_DOCTOSERIE;
declare variable FOLIO D_DOCTOFOLIO;
BEGIN

   ERRORCODE = 0;

   
   IF(COALESCE(:CORTEACTUAL,'S') = 'S') THEN
   BEGIN

      SELECT DOCTOID, ERRORCODE
      FROM DOCTO_INSERT (
         :VENDEDORID,
         :ALMACENID,
         :SUCURSALID,
         :TIPODOCTOID,
         0,
         1,
         :PERSONAID,
         :VENDEDORID,
         :CAJAID,
         :REFERENCIA,
         :REFERENCIAS,
         NULL,
         NULL,
         :FECHA,
         :VENCE ,
         NULL ,
         'S' ,
         1
      ) INTO :DOCTOID, :DOCTOERRORCODE;


      IF (:DOCTOERRORCODE > 0) THEN
      BEGIN
        ERRORCODE = :DOCTOERRORCODE;
        SUSPEND;
        EXIT;
      END

   END
   ELSE
   BEGIN

   
    IF(COALESCE(:CORTEAPLICARID,0) <> 0) THEN
    BEGIN
        CORTEID = :CORTEAPLICARID; 
        SELECT FIRST 1 FECHACORTE FROM CORTE WHERE ID = :CORTEID INTO :FECHA;
    END  
    ELSE
    BEGIN
            FECHA = :FECHACORTE;
           SELECT FIRST 1 ID FROM CORTE WHERE CORTE.cajeroid = :VENDEDORID AND CORTE.fechacorte = :FECHACORTE INTO :CORTEID;

           IF(COALESCE(:CORTEID,0) = 0) THEN
           BEGIN



              IF(COALESCE(:CAJEROID ,0) = COALESCE(:VENDEDORID, 0)) THEN
              BEGIN
                 INSERT INTO CORTE (
                    ACTIVO,
                    FECHACORTE,
                    SUCURSALID,
                    CAJEROID,
                    INICIA,
                    TERMINA,
                    SALDOINICIAL,
                    TIPOCORTEID
                    ) VALUES (
                    'N',
                    :FECHACORTE,
                    :SUCURSALID,
                    :VENDEDORID,
                    CAST(:FECHACORTE AS TIMESTAMP),
                    CAST(:FECHACORTE AS TIMESTAMP),
                    0,
                    1
                    ) RETURNING ID INTO :CORTEID;
              END
              ELSE
              BEGIN
                    ERRORCODE = 1001;
                    SUSPEND;
                    EXIT;
              END
           END

    END



    INSERT INTO DOCTO (
      CREADOPOR_USERID, 
      ALMACENID, 
      SUCURSALID, 
      TIPODOCTOID, 
      ESTATUSDOCTOID, 
      ESTATUSDOCTOPAGOID, 
      ESTATUSDOCTOPEDIDOID,
      PERSONAID, 
      VENDEDORID,
      CAJAID,
      REFERENCIA,
      REFERENCIAS,
      SUCURSALTID,
      ALMACENTID,
      FECHA,
      VENCE,
      DOCTOREFID,
      MERCANCIAENTREGADA,
      ORIGENFISCALID,
      ESAPARTADO,
      ESFACTURAELECTRONICA,
      MONEDAID,
      TIPOCAMBIO,
      PLAZO,
      CORTEID)
    VALUES (

    :VENDEDORID,
         :ALMACENID,
         :SUCURSALID,
         :TIPODOCTOID,
         0,
         1,
         0,
         :PERSONAID,
         :VENDEDORID,
         :CAJAID,
         :REFERENCIA,
         :REFERENCIAS,
         NULL,
         NULL,
         :FECHA,
         :VENCE ,
         NULL ,
         'S' ,
         1,
         'N',
         'N',
         1,
         1,
         0,
         :CORTEID)
   RETURNING ID INTO :DOCTOID;
     UPDATE DOCTO SET CORTEID = :CORTEID WHERE ID = :DOCTOID;

   END


   
   SELECT SERIE, FOLIO
   FROM GET_FOLIO(:SUCURSALID, :CAJAID, :TIPODOCTOID)
   INTO :SERIE, :FOLIO;

   UPDATE DOCTO SET FOLIO = :FOLIO, SERIE = :SERIE
   WHERE ID = :DOCTOID;


    ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1004;
      SUSPEND;
   END 

END