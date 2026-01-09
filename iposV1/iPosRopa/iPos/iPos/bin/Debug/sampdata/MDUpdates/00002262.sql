CREATE OR ALTER TRIGGER DOCTO_AUKITPROCESS FOR DOCTO
ACTIVE AFTER UPDATE POSITION 0
AS
declare variable MANEJAKITS D_BOOLCN;
declare variable ERRORCODE D_ERRORCODE; 
declare variable SENTIDOINVENTARIO D_SENTIDO;     
declare variable HACEREFERENCIA D_BOOLCN;
begin
  /* Trigger text */
      select FIRST 1 MANEJAKITS FROM PARAMETRO INTO :MANEJAKITS;

      IF(COALESCE(:MANEJAKITS,'N') = 'S' AND COALESCE(OLD.postkitestatus,0) = 0 AND COALESCE(NEW.postkitestatus,0) = 1
          AND NEW.tipodoctoid NOT IN (501,502,503,504) ) THEN
      BEGIN     

         SELECT TIPODOCTO.sentidoinventario, TIPODOCTO.HACEREFERENCIA
         FROM TIPODOCTO WHERE ID = NEW.tipodoctoid
         INTO :SENTIDOINVENTARIO, :HACEREFERENCIA;

          IF( COALESCE(:HACEREFERENCIA,'N') = 'S' AND COALESCE(:sentidoinventario, 0) = 1  ) THEN
        BEGIN
            
            SELECT ERRORCODE FROM KIT_DESAMBLARALVUELOPORCAMBIO(NEW.ID) INTO :ERRORCODE;
            IF( :ERRORCODE = 4006 ) THEN
            BEGIN
                exception KIT_GENERALERROR 'Ocurrio un error al tratar de desensamblar kits para esta operacion';
            END
        END

        IF(COALESCE(:sentidoinventario, 0) <> 0) THEN
        BEGIN
           SELECT * FROM ACTUALIZAR_TABLA_IEPS_DOCTO(NEW.ID) INTO :ERRORCODE;
        END

      END

end