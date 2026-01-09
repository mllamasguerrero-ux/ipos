CREATE OR ALTER TRIGGER MOVTO_BI20 FOR MOVTO
ACTIVE BEFORE INSERT POSITION 20
AS       
    declare variable TIPODOCTOID type of D_FK; 
   DECLARE VARIABLE INVENTARIABLE D_BOOLCS;
begin
  /* Trigger text */
           
   IF ((NEW.ESTATUSMOVTOID IS NULL) OR (NEW.ESTATUSMOVTOID = 0)) THEN
   BEGIN    
        SELECT TIPODOCTOID FROM DOCTO WHERE ID = NEW.DOCTOID INTO :TIPODOCTOID;
         /*Quita la canitdad de pedidos*/
         IF(:tipodoctoid IN (21,25,12) ) THEN
         BEGIN
            SELECT COALESCE(P.INVENTARIABLE, 'S')
            FROM PRODUCTO P
            WHERE P.ID = NEW.PRODUCTOID
            INTO :INVENTARIABLE;

            IF(:INVENTARIABLE = 'S') THEN
            BEGIN
                NEW.registroprocesosalida = 'S';
            END
         END
   END
end