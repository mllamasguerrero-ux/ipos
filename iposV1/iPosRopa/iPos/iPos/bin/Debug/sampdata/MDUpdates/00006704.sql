create or alter procedure REPLIMPO_USUARIOPPC
returns (
    PERSONAID type of D_FK,
    ERRORCODE type of D_ERRORCODE)
as
BEGIN

   ERRORCODE = 0; 

   SELECT ID FROM PERSONA WHERE CLAVE = 'USUARIOPPC'
   INTO :PERSONAID;

   IF(COALESCE(:PERSONAID,0) = 0) THEN
   BEGIN
        SELECT PERSONAID, ERRORCODE FROM
        PERSONA_USUARIO_INSERT (
            'USUARIOPPC',--CLAVE D_CLAVE,
            'USUARIOPPC',--NOMBRE D_NOMBRE,
            'USUARIOPPC',--USERNAME D_STDTEXT_SHORT,
            '123',--CLAVEACCESO D_STDTEXT_SHORT,
            NULL,--EMPRESAID D_FK,
            '01.01.2099',--VIGENCIA D_FECHA,
            0,--RESET_PASS D_BOOLEAN,
            NULL,--GAFFETE D_CLAVE_NULL,
            1,--LISTAPRECIOID D_FK,
            'S',--TICKETLARGO D_BOOLCN,
            NULL,--ALMACENID D_FK,
            'S',--CAJASBOTELLAS D_STDTEXT_MEDIUM,
            'S',--TICKETLARGOCREDITO D_BOOLCN,
            NULL,--VENDEDORID D_FK,
            0,--PENDMAXDIAS D_DIAS,
            NULL,--GRUPOUSUARIOID D_FK,
            '',--EMAIL1 D_STDTEXT_MEDIUM,
            NULL,--CLERKPAGOSERVICIOSID D_FK,
            NULL,--CLERKSERVICIOS D_FK,
            'S',---TICKETLARGOCOTIZACION D_BOOLCN,
            NULL,--CODIGOAUTORIZACION D_STDTEXT_SHORT,
            NULL ,--CLIEFORMASPAGODEF D_STDTEXT_MEDIUM
            NULL
            )
            INTO :PERSONAID, :ERRORCODE;
            
            IF(COALESCE(:ERRORCODE,0) <> 0) THEN
            BEGIN
                SUSPEND;
                EXIT;
            END

            INSERT INTO USUARIO_PERFIL
            (UP_PERFIL,UP_PERSONAID)
            VALUES
            (11, :PERSONAID);
            
            INSERT INTO USUARIO_PERFIL
            (UP_PERFIL,UP_PERSONAID)
            VALUES
            (12, :PERSONAID);





   END




    ERRORCODE = 0;
   SUSPEND;

   /*WHEN ANY DO
   BEGIN
      ERRORCODE = 1004;
      SUSPEND;
   END  */

END