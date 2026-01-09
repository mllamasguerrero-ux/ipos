create or alter procedure MOVTO_ADJUNTOSELIMINAR (
    MOVTOADJUNTOID D_PK)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable ESTATUSDOCTOID D_FK;
declare variable ESTATUSMOVTOID D_FK;
BEGIN
   SELECT
      D.ESTATUSDOCTOID, M.ESTATUSMOVTOID
   FROM MOVTO M
      LEFT JOIN DOCTO D
         ON D.ID = M.DOCTOID
   WHERE
      M.ID = :MOVTOADJUNTOID
   INTO
      :ESTATUSDOCTOID, :ESTATUSMOVTOID;

   
   -- No borrar si el estatus del docto o movto es borrador o si es promocion.
   IF ((:ESTATUSDOCTOID <> 0) or (:ESTATUSMOVTOID <> 0)) THEN
   BEGIN
      ERRORCODE = 1014;
      SUSPEND;
      EXIT;
   END
   
   ELSE
   BEGIN
      DELETE FROM MOVTO WHERE MOVTOADJUNTOAID = :MOVTOADJUNTOID;
   
      ERRORCODE = 0;
   END

   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1015;
      SUSPEND;
   END 
END