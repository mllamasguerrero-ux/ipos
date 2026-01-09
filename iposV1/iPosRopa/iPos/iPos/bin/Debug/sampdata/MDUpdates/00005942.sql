create or alter procedure TRASPASOSALIDA_PRECIERRE (
    DOCTOID D_FK)
returns (
    DEFAULTFACTURA D_BOOLCN,
    PREPAGOHECHO D_BOOLCN,
    ERRORCODE D_ERRORCODE)
as
declare variable ESTATUSDOCTOID D_FK;
declare variable DOCTOVENTAID D_FK;
declare variable SUBTIPODOCTOID D_FK;
declare variable TIPODOCTOID D_FK;
declare variable ESTADOSURTIDOID D_FK;
declare variable SUCURSALDESTEMPPROV D_CLAVE_NULL;
declare variable SUCURSALEMPPROV D_CLAVE_NULL;
declare variable SALDO D_PRECIO;
BEGIN

   ERRORCODE  = 0;

   
    DEFAULTFACTURA = 'N';
    PREPAGOHECHO = 'N';

   -- Leer del DOCTO a cancelar.
   SELECT DOCTO.ESTATUSDOCTOID , DOCTO.DOCTOREFID  , DOCTO.TIPODOCTOID, DOCTO.SUBTIPODOCTOID,
        SUCURSAL.EMPPROV SUCURSALEMPPROV, SUCDEST.EMPPROV  SUCURSALDESTEMPPROV, SALDO
   FROM DOCTO  
   LEFT JOIN SUCURSAL ON SUCURSAL.ID = DOCTO.SUCURSALID
   LEFT JOIN SUCURSAL SUCDEST ON SUCDEST.ID = DOCTO.SUCURSALTID
   WHERE DOCTO.ID = :DOCTOID
   INTO :ESTATUSDOCTOID, :DOCTOVENTAID, :TIPODOCTOID, :SUBTIPODOCTOID,
   :SUCURSALEMPPROV, :SUCURSALDESTEMPPROV,:SALDO;


   -- Si no esta vigente: Salir.
   IF (:ESTATUSDOCTOID <> 0) THEN
   BEGIN
      ERRORCODE = 0;
      SUSPEND;
      EXIT;
   END

   
   IF (:TIPODOCTOID NOT IN (31)) THEN
   BEGIN
      ERRORCODE = 0;
      SUSPEND;
      EXIT;
   END



         
   IF(COALESCE(:SUCURSALEMPPROV,'') = COALESCE( :SUCURSALDESTEMPPROV,'') AND COALESCE( :SUCURSALDESTEMPPROV,'') <> '') THEN
   BEGIN
         PREPAGOHECHO = 'S';

         IF(COALESCE(:DOCTOVENTAID,0) <> 0) THEN
         BEGIN

                   
            SELECT ERRORCODE
            FROM DOCTOPAGO_INSERT (
            :DOCTOVENTAID,
            17,
            CURRENT_DATE, CURRENT_TIMESTAMP, -1,
            :SALDO, 0.00, 0.00 ,
            1,
            NULL ,
             'N'  ,
            1 ,
            NULL,
            NULL,
            NULL  ,
             CURRENT_DATE,
            CURRENT_DATE,
            'N',
            1,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL
            ) INTO  :ERRORCODE;

       
            IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
            BEGIN
                SUSPEND;
                EXIT;
            END
            
            SELECT ERRORCODE
            FROM DOCTO_SAVE(:DOCTOVENTAID)
            INTO :ERRORCODE;
            
            IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
            BEGIN
                SUSPEND;
                EXIT;
            END

         END



         
         IF(COALESCE(:DOCTOVENTAID,0) = 0 and COALESCE(:DOCTOID,0) <> 0) THEN
         BEGIN

                   
            SELECT ERRORCODE
            FROM DOCTOPAGO_INSERT (
            :DOCTOID,
            17,
            CURRENT_DATE, CURRENT_TIMESTAMP, -1,
            :SALDO, 0.00, 0.00 ,
            1,
            NULL ,
             'N'  ,
            1 ,
            NULL,
            NULL,
            NULL  ,
             CURRENT_DATE,
            CURRENT_DATE,
            'N',
            1,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL
            ) INTO  :ERRORCODE;

       
            IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
            BEGIN
                SUSPEND;
                EXIT;
            END
            
            SELECT ERRORCODE
            FROM DOCTO_SAVE(:DOCTOID)
            INTO :ERRORCODE;
            
            IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
            BEGIN
                SUSPEND;
                EXIT;
            END

         END


   END
   
    IF(COALESCE(:SUCURSALEMPPROV,'') <> COALESCE( :SUCURSALDESTEMPPROV,'') AND
       COALESCE( :SUCURSALDESTEMPPROV,'') <> '' AND COALESCE( :SUCURSALEMPPROV,'') <> ''  ) THEN
   BEGIN
       DEFAULTFACTURA = 'S';
        PREPAGOHECHO = 'S';

         IF(COALESCE(:DOCTOVENTAID,0) <> 0) THEN
         BEGIN

                   
            SELECT ERRORCODE
            FROM DOCTOPAGO_INSERT (
            :DOCTOVENTAID,
            4,
            CURRENT_DATE, CURRENT_TIMESTAMP, -1,
            :SALDO, 0.00, 0.00 ,
            1,
            NULL ,
             'N'  ,
            1 ,
            NULL,
            NULL,
            NULL  ,
             CURRENT_DATE,
            CURRENT_DATE,
            'N',
            1,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL
            ) INTO  :ERRORCODE;

       
            IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
            BEGIN
                SUSPEND;
                EXIT;
            END
            
            SELECT ERRORCODE
            FROM DOCTO_SAVE(:DOCTOVENTAID)
            INTO :ERRORCODE;
            
            IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
            BEGIN
                SUSPEND;
                EXIT;
            END

         END



         
         IF(COALESCE(:DOCTOVENTAID,0) = 0 and COALESCE(:DOCTOID,0) <> 0) THEN
         BEGIN

                   
            SELECT ERRORCODE
            FROM DOCTOPAGO_INSERT (
            :DOCTOID,
            4,
            CURRENT_DATE, CURRENT_TIMESTAMP, -1,
            :SALDO, 0.00, 0.00 ,
            1,
            NULL ,
             'N'  ,
            1 ,
            NULL,
            NULL,
            NULL  ,
             CURRENT_DATE,
            CURRENT_DATE,
            'N',
            1,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL
            ) INTO  :ERRORCODE;

       
            IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
            BEGIN
                SUSPEND;
                EXIT;
            END
            
            SELECT ERRORCODE
            FROM DOCTO_SAVE(:DOCTOID)
            INTO :ERRORCODE;
            
            IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
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
        ERRORCODE = 1009;
        SUSPEND;
    END
END