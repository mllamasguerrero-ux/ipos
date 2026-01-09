create or alter procedure MOVTO_DELETE (
    MOVTOID D_PK,
    ESPROMOCION D_BOOLCN)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable ESTATUSDOCTOID D_FK;
declare variable ESTATUSMOVTOID D_FK;
declare variable PROMOCION D_BOOLCN;
declare variable ESVENDEDORMOVIL D_BOOLCN;
BEGIN
   SELECT
      D.ESTATUSDOCTOID, M.ESTATUSMOVTOID, M.PROMOCION  , parametro.esvendedormovil
   FROM MOVTO M
      LEFT JOIN DOCTO D
         ON D.ID = M.DOCTOID
         left join parametro on 1 = 1
   WHERE
      M.ID = :MOVTOID
   INTO
      :ESTATUSDOCTOID, :ESTATUSMOVTOID, :PROMOCION, :ESVENDEDORMOVIL;

   -- Si NO es orden de borrar promocion
   -- (lo cual se realiza desde TRIGGER DOCTO_AIU_30)
   -- Pero el registro si es de promocion
   -- no proceder.
   /*IF ((:ESPROMOCION = 'N') AND (:PROMOCION = 'S')) THEN
   BEGIN
      ERRORCODE = 1014;
      SUSPEND;
      EXIT;
   END   */
   
   -- No borrar si el estatus del docto o movto es borrador o si es promocion.
   IF ((:ESTATUSDOCTOID <> 0) or (:ESTATUSMOVTOID <> 0)) THEN
   BEGIN
      ERRORCODE = 1014;
      SUSPEND;
      EXIT;
   END
   
   ELSE
   BEGIN
      DELETE FROM MOVTO
      WHERE ID = :MOVTOID;


      IF(COALESCE(:ESVENDEDORMOVIL,'N') = 'S') THEN
      BEGIN
        UPDATE MOVTO SET MOVTOADJUNTOAID = NULL  WHERE MOVTOADJUNTOAID = :MOVTOID;
      END

      --DELETE FROM MOVTO WHERE MOVTOADJUNTOAID = :MOVTOID;
   
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