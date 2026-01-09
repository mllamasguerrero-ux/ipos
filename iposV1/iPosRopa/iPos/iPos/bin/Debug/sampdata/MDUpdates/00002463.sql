create or alter procedure BITACOBRANZAGENERAR (
    COBRADORID D_FK,
    FECHA D_FECHA,
    FORZARCREACION D_BOOLCN)
returns (
    IDRETORNO D_FK,
    ERRORCODE D_ERRORCODE)
as
declare variable BITACORAID D_FK;
declare variable ESTADOBITACORAID D_FK;
BEGIN
    SELECT first 1 ID, ESTADO FROM BITACOBRANZA WHERE COBRADORID = :COBRADORID
    AND FECHA = :FECHA INTO :BITACORAID, :ESTADOBITACORAID;



   if(:BITACORAID IS NOT NULL) Then
   BEGIN

       IF(COALESCE(:FORZARCREACION , 'N') <> 'S' and COALESCE(:ESTADOBITACORAID,-1) IN (1,0)) THEN
       BEGIN
         ERRORCODE = 5001;
         IDRETORNO = 0;
         SUSPEND;
       END
       ELSE
       BEGIN

           IF(COALESCE(:ESTADOBITACORAID,-1) NOT IN (1,0)) THEN
           BEGIN
           
                ERRORCODE = 5002;
                IDRETORNO = 0;
                SUSPEND;
           END
           ELSE
           BEGIN
            
                DELETE FROM BITACOBRANZADET WHERE BITCOBRANZAID = :BITACORAID;
                DELETE FROM bitacobranza WHERE ID = :BITACORAID;
           END

       END

   END


   insert into bitacobranza
       (
        FECHA,
        COBRADORID,
        TOTALABONADO,
        ESTADO

    )
    VALUES
        (    
        :FECHA,
        :COBRADORID,
        0,
        1
    )
    returning id into :IDRETORNO;




   ERRORCODE = 0;
   SUSPEND;

   /*WHEN ANY DO
   BEGIN
      ERRORCODE = 1022;
      SUSPEND;
   END */
END