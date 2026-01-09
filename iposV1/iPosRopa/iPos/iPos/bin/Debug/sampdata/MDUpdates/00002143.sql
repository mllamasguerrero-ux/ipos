create or alter procedure KIT_HAYEXISPARADESENSAMBLE (
    DOCTOID D_FK)
returns (
    HAYEXISTENCIA D_BOOLCS,
    ERRORCODE D_ERRORCODE)
as
declare variable CUENTASINEXIS integer;
BEGIN

    ERRORCODE = 0;
    HAYEXISTENCIA = 'S';
    CUENTASINEXIS = 0;


    select count(*)
    FROM MOVTO M
             LEFT JOIN DOCTO D
               ON D.ID = M.DOCTOID
                  LEFT JOIN PRODUCTO PKIT
                    ON PKIT.ID = M.productoid
           WHERE M.DOCTOID = :DOCTOID
              AND (M.CANTIDAD >0) AND COALESCE(PKIT.eskit,'N') = 'S'
              AND COALESCE(M.cantidad,0) > COALESCE(PKIT.existencia,0)


           INTO :CUENTASINEXIS;


           IF(COALESCE(:CUENTASINEXIS,0) > 0) THEN
           BEGIN
            HAYEXISTENCIA = 'N';
           END


   

   ERRORCODE = 0;
   SUSPEND;
   
   WHEN ANY DO
   BEGIN
     ERRORCODE = 1076;
     SUSPEND;
   END

END