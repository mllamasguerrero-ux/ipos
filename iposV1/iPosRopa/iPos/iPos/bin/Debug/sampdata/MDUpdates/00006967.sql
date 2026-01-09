create or alter procedure MOVTOGASTO_INSERT (
    DOCTOACTUALID type of D_FK,
    CREADOPOR_USERID type of D_FK,
    ALMACENID type of D_FK,
    SUCURSALID type of D_FK,
    TIPODOCTOID type of D_FK,
    ESTATUSDOCTOID type of D_FK,
    ESTATUSDOCTOPAGOID type of D_FK,
    PERSONAID type of D_FK,
    VENDEDORID type of D_FK,
    CAJAID type of D_FK,
    PARTIDA smallint,
    GASTOID type of D_FK,
    IMPORTE D_PRECIO,
    DOCTOREFID D_FK,
    REFERENCIA type of D_REFERENCIA,
    REFERENCIAS varchar(255),
    FECHA D_FECHA,
    VENCE D_FECHA,
    CORTEACTUAL D_BOOLCN,
    FECHACORTE D_FECHA,
    CORTEAPLICARID D_FK,
    CAJEROID D_FK,
    SUPERVISORID D_FK,
    ORIGENFISCALID D_FK,
    CENTROCOSTOID D_FK)
returns (
    CORTEID D_FK,
    DOCTOID type of D_PK,
    MOVTOID type of D_PK,
    ERRORCODE type of D_ERRORCODE)
as
declare variable DOCTOERRORCODE type of D_FK;
declare variable MOVTOACTUALID type of D_FK;
BEGIN


   CORTEID = 0;

-- Si no se recibe valor en el parametro DoctoActualId, es docto nuevo.
   IF ((:DOCTOACTUALID IS NULL) OR (:DOCTOACTUALID = 0)) THEN
   BEGIN
      
      
    IF(COALESCE(:CORTEACTUAL,'S') = 'S') THEN
    BEGIN



      SELECT DOCTOID, ERRORCODE
      FROM DOCTO_INSERT (
         :CREADOPOR_USERID,
         :ALMACENID,
         :SUCURSALID,
         :TIPODOCTOID,
         :ESTATUSDOCTOID,
         :ESTATUSDOCTOPAGOID,
         :PERSONAID,
         :VENDEDORID,
         :CAJAID,
         :REFERENCIA,
         :REFERENCIAS,
         NULL,
         NULL,
         :FECHA,
         :VENCE,
         :DOCTOREFID  ,
         'S',
         :ORIGENFISCALID
      ) INTO :DOCTOID, :DOCTOERRORCODE;

      UPDATE docto SET  cajeroid = :CAJEROID, SUPERVISORID = :SUPERVISORID WHERE ID = :DOCTOID  ;
     END
     ELSE
     BEGIN
         

        IF(COALESCE(:CORTEAPLICARID,0) <> 0) THEN
        BEGIN

            CORTEID = :CORTEAPLICARID;
            SELECT FIRST 1 FECHACORTE FROM CORTE WHERE ID = :CORTEID INTO :FECHACORTE;
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

          UPDATE docto SET  cajeroid = :CAJEROID, SUPERVISORID = :SUPERVISORID WHERE ID = :DOCTOID  ;


     END
   END
   ELSE
   BEGIN
      DOCTOERRORCODE = 0;
      DOCTOID = :DOCTOACTUALID;
   END

   IF (:DOCTOERRORCODE > 0) THEN
   BEGIN
      ERRORCODE = :DOCTOERRORCODE;
      SUSPEND;
      EXIT;
   END


   SELECT  ID FROM MOVTOGASTO WHERE DOCTOID = :DOCTOID AND GASTOID = :GASTOID INTO :MOVTOACTUALID;

   IF ((:MOVTOACTUALID IS NULL) OR (:MOVTOACTUALID = 0)) THEN
   BEGIN

       INSERT INTO MOVTOGASTO(
            DOCTOID,
            ESTATUSMOVTOID,
            GASTOID,
            TOTAL,
            PARTIDA,
            CENTROCOSTOID
       )
       VALUES(
           :DOCTOID,
           0,
           :GASTOID,
           :IMPORTE,
           :PARTIDA,
           :CENTROCOSTOID
       ) RETURNING ID INTO :MOVTOID;


   END
   ELSE
   BEGIN

        MOVTOID = :MOVTOACTUALID;
        UPDATE MOVTOGASTO SET
           TOTAL = TOTAL + :IMPORTE
           WHERE ID = :MOVTOID;



   END


   SUSPEND;
   EXIT;


END