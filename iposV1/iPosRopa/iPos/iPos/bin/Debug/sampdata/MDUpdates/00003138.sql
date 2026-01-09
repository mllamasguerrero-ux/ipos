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
declare variable TIPODOCTOID D_FK;
declare variable TIPOMAYOREOID D_FK;
declare variable APLICARMAYOREOPORLINEA D_BOOLCN;
declare variable NUEVOTIPOMAYOREOID D_FK;
declare variable DOCTOID D_FK;
BEGIN
   SELECT
      D.ESTATUSDOCTOID, M.ESTATUSMOVTOID, M.PROMOCION  , parametro.esvendedormovil , M.TIPODOCTOID,
      PARAMETRO.aplicarmayoreoporlinea, D.tipomayoreoid , D.ID
   FROM MOVTO M
      LEFT JOIN DOCTO D
         ON D.ID = M.DOCTOID
         left join parametro on 1 = 1
   WHERE
      M.ID = :MOVTOID
   INTO
      :ESTATUSDOCTOID, :ESTATUSMOVTOID, :PROMOCION, :ESVENDEDORMOVIL, :TIPODOCTOID, :APLICARMAYOREOPORLINEA, :TIPOMAYOREOID, :DOCTOID;

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

       -- RECALCULAR DETALLES SI APLICA
       IF (:TIPODOCTOID in (21) AND :APLICARMAYOREOPORLINEA = 'S') then
      BEGIN
           SELECT TIPOMAYOREOID, ERRORCODE FROM GET_TIPOMAYOREO_DOCTO(:DOCTOID)
           INTO :NUEVOTIPOMAYOREOID, :ERRORCODE;

           IF (:ERRORCODE = 0) THEN
           BEGIN

            IF(COALESCE(:TIPOMAYOREOID,1) <> COALESCE(:NUEVOTIPOMAYOREOID,1)) THEN
            BEGIN
                UPDATE DOCTO SET TIPOMAYOREOID = :NUEVOTIPOMAYOREOID WHERE ID = :DOCTOID;

                SELECT ERRORCODE FROM DOCTO_RECALCULAR_DETALLES(:DOCTOID) INTO :ERRORCODE;
                
                IF (:ERRORCODE > 0) THEN
                BEGIN
                     SUSPEND;
                     EXIT;
                END
            END
           END

      END


   
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