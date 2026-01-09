CREATE OR ALTER TRIGGER DOCTO_BU0_UTILIDAD FOR DOCTO
ACTIVE BEFORE UPDATE POSITION 0
AS
declare variable UTILIDAD d_precio;
declare variable TIPOUTILIDADID d_fk;   
declare variable VENDEDORCLIENTE d_fk;
begin
  /* Trigger text */

  
   if( NEW.TIPODOCTOID IN (21,23,25,26) or (new.tipodoctoid in (22,24) and new.subtipodoctoid <> 13) ) then
   begin

         if(new.personaid <> old.personaid)  then
         begin
            SELECT PERSONA.vendedorid FROM PERSONA WHERE ID = NEW.PERSONAID INTO :vendedorcliente;
            IF(:VENDEDORCLIENTE IS NOT NULL) THEN
            BEGIN
                NEW.vendedorutilidadid = :VENDEDORCLIENTE;
            END
            ELSE
            BEGIN  
                new.vendedorutilidadid = new.vendedorid;
            END
         end
         

         --if(new.estatusdoctoid = 1 and old.estatusdoctoid = 0) then
         --begin
             SELECT TIPOUTILIDADID FROM PARAMETRO INTO :TIPOUTILIDADID;

            select sum( (  (case when coalesce(movto.estadorebaja,0) = 1 then coalesce(movto.precioconrebaja,0) else coalesce(movto.precio,0) end) -
                                                        (CASE WHEN :tipoutilidadid = 1 THEN COALESCE(MOVTO.costoreposicion,0)
                                                           WHEN :tipoutilidadid = 3 THEN COALESCE(MOVTO.costoultimo,0)
                                                           ELSE COALESCE(MOVTO.costopromedio,0) END ) )
                                                            * COALESCE(MOVTO.cantidad, 0) )

                    FROM MOVTO WHERE MOVTO.DOCTOID = NEW.ID INTO :UTILIDAD;

            NEW.utilidad = :UTILIDAD;
         --end



   end

end