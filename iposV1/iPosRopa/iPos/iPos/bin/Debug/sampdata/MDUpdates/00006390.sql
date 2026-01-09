create or alter procedure DOCTONOTASET (
    DOCTOID D_FK,
    TIPODOCTONOTAID D_FK,
    FECHAHORA D_TIMESTAMP,
    USUARIOID D_FK,
    NOTA D_DESCRIPCION)
returns (
    IDNEW type of D_FK,
    ERRORCODE type of D_ERRORCODE)
as
BEGIN


   SELECT FIRST 1 ID FROM DOCTONOTA WHERE COALESCE(DOCTOID, 0) = COALESCE(:DOCTOID,0) AND
                                   COALESCE(TIPODOCTONOTAID,0) =  COALESCE(:TIPODOCTONOTAID,0)
               into :IDNEW;
   IF(COALESCE(:IDNEW,0) = 0) THEN
   BEGIN

      INSERT INTO DOCTONOTA
      (
        DOCTOID      ,
        TIPODOCTONOTAID,
        FECHAHORA ,
        USUARIOID ,
        NOTA
         )

       Values (
        :DOCTOID   ,
        :TIPODOCTONOTAID,
        :FECHAHORA ,
        :USUARIOID ,
        :NOTA
      )
      RETURNING ID INTO :IDNEW;

      IF ((:IDNEW IS NULL) OR (:IDNEW = 0)) THEN
      BEGIN
        ERRORCODE = 1002;
      END
    END
    ELSE
    BEGIN
        UPDATE DOCTONOTA
        SET FECHAHORA = :FECHAHORA, USUARIOID = :USUARIOID, NOTA = :NOTA
        WHERE ID = :IDNEW;
    END

   SUSPEND;
END