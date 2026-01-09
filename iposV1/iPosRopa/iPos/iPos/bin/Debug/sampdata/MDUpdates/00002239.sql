CREATE OR ALTER TRIGGER DOCTO_BUKITPROCESS FOR DOCTO
ACTIVE BEFORE UPDATE POSITION 0
AS
declare variable MANEJAKITS D_BOOLCN;
declare variable ERRORCODE D_ERRORCODE; 
declare variable SENTIDOINVENTARIO D_SENTIDO;   
declare variable HACEREFERENCIA D_BOOLCN;
begin
  /* Trigger text */
      select FIRST 1 MANEJAKITS FROM PARAMETRO INTO :MANEJAKITS;


      IF(COALESCE(:MANEJAKITS,'N') = 'S' AND COALESCE(OLD.prekitestatus,0) = 0 AND COALESCE(NEW.prekitestatus,0) = 1
         AND NEW.TIPODOCTOID NOT IN (501,502,503,504)) THEN
      BEGIN
                   insert into traza(valor) values('entro a maneja kits');
         SELECT TIPODOCTO.sentidoinventario , TIPODOCTO.HACEREFERENCIA
         FROM TIPODOCTO WHERE ID = NEW.tipodoctoid
         INTO :SENTIDOINVENTARIO, :HACEREFERENCIA;

         IF( COALESCE(:HACEREFERENCIA,'N') = 'N'  AND COALESCE(:sentidoinventario, 0) = -1) THEN
         BEGIN
            
            insert into traza(valor) values('KIT_CREARALVUELOFALTANTE');

            SELECT ERRORCODE FROM KIT_CREARALVUELOFALTANTE(NEW.ID) INTO :ERRORCODE;
            IF( :ERRORCODE = 4006 ) THEN
            BEGIN
                exception KIT_GENERALERROR 'Ocurrio un error al tratar de ensamblar kits para esta operacion';
            END
         END

         IF( COALESCE(:HACEREFERENCIA,'N') = 'S' AND COALESCE(:sentidoinventario, 0) = -1 ) THEN
         BEGIN

            SELECT ERRORCODE FROM KIT_ENSAMBLARALVUELOPORCAMBIO(NEW.ID) INTO :ERRORCODE;
            IF( coalesce(:ERRORCODE,0) <> 0 ) THEN
            BEGIN
                exception KIT_GENERALERROR 'Ocurrio un error al tratar de ensamblar kits para esta operacion';
            END
        END


      END

end