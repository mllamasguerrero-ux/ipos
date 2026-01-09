create or alter procedure DESASIGNARPEDIMENTOTEMP_DOCTO (
    DOCTOID D_FK)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable TIPODOCTOID D_FK;
declare variable CONTADOR integer;
declare variable MANEJARLOTEIMPORTACION D_BOOLCN;
declare variable ESTATUSDOCTOLOTEIMPO D_FK;
declare variable LOTEIMPORTADODOCTOID D_FK;
BEGIN



    ERRORCODE = 0;
    LOTEIMPORTADODOCTOID = 0;







    SELECT FIRST 1 MANEJARLOTEIMPORTACION FROM PARAMETRO INTO :MANEJARLOTEIMPORTACION;

    IF(COALESCE(:MANEJARLOTEIMPORTACION ,'N') = 'N') THEN
    BEGIN
            ERRORCODE = 3012;
            SUSPEND;
            EXIT;
        
    END


    SELECT   TIPODOCTOID
    from DOCTO
    where id = :doctoid
    INTO :TIPODOCTOID;





    
    -- si ya existe el docto de loteimportado relacionado salte

    IF(COALESCE(:TIPODOCTOID,0) NOT IN (901,902)) THEN
    BEGIN
     SELECT LOTEIMPORTADODOCTOID FROM DOCTO WHERE ID = :DOCTOID INTO :LOTEIMPORTADODOCTOID;
     IF(COALESCE(:LOTEIMPORTADODOCTOID,0) <> 0) THEN
     BEGIN
         -- asegurarse de que existe el registro
       SELECT COUNT(*) FROM DOCTO WHERE ID = :loteimportadodoctoid  INTO :CONTADOR;
       IF(COALESCE(:contador, 0) > 0) THEN
       BEGIN
           -- si la opcion de completar docto esta activa.. ver si el regsitro existente esta como borrador y si es asi completarlo

               SELECT ESTATUSDOCTOID FROM DOCTO WHERE ID = :loteimportadodoctoid  INTO :ESTATUSDOCTOLOTEIMPO;
               IF(COALESCE(:ESTATUSDOCTOLOTEIMPO,0) = 0) THEN
               BEGIN
                     SELECT ERRORCODE FROM DOCTO_DELETE( :loteimportadodoctoid) INTO :ERRORCODE;
                     IF(:ERRORCODE > 0) THEN
                     BEGIN
                        SUSPEND;
                        EXIT;
                     END

                     
                        UPDATE DOCTO SET  LOTEIMPORTADODOCTOID = NULL WHERE ID =  :DOCTOID;

               END
               ELSE
               BEGIN
                    ERRORCODE = 1000;
                    SUSPEND;
                    EXIT;
               END


          
            ERRORCODE = 0;
            SUSPEND;
            EXIT;
       END
       ELSE
       BEGIN
          UPDATE DOCTO SET  LOTEIMPORTADODOCTOID = NULL WHERE ID =  :DOCTOID;
       END




     END
    END



   
   ERRORCODE = 0;
   SUSPEND;
   
   /*WHEN ANY DO
   BEGIN
      ERRORCODE = 1012;
      SUSPEND;
   END  */
END