create or alter procedure MEDICO_GRABAR (
    NOMBRE D_STDTEXT_MEDIUM,
    CEDULA D_STDTEXT_MEDIUM,
    MEDICOPROPIO D_BOOLCN)
returns (
    IDRETORNO D_FK,
    ERRORCODE D_ERRORCODE)
as
declare variable MEDICOID D_FK;
BEGIN
    SELECT first 1 ID FROM MEDICO WHERE CEDULA = :CEDULA INTO :MEDICOID;



   if(:MEDICOID IS NOT NULL) Then
   BEGIN

    update  MEDICO

    set
    NOMBRE=:NOMBRE,
    MEDICOPROPIO = :MEDICOPROPIO
    where ID=:MEDICOID;

    IDRETORNO = :MEDICOID;

   END
   ELSE
   BEGIN
       insert into MEDICO
       (
        ACTIVO,
        NOMBRE,
        CEDULA,
        MEDICOPROPIO

   )

           VALUES
        (    
        'S',
        :NOMBRE,
        :CEDULA,
        :MEDICOPROPIO
    )
    returning id into :IDRETORNO;
   END



   ERRORCODE = 0;
   SUSPEND;

   /*WHEN ANY DO
   BEGIN
      ERRORCODE = 1022;
      SUSPEND;
   END */
END