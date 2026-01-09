CREATE OR ALTER trigger movto_bi0_utilidad for movto
active before insert position 0
AS
declare variable UTILIDAD d_precio;
declare variable TIPOUTILIDADID d_fk;
declare variable subtipodoctoid d_fk;

begin
  /* Trigger text */
               
   if(new.estatusmovtoid = 1 ) then
   begin
          select subtipodoctoid from docto where id = new.doctoid into :subtipodoctoid;
        if( NEW.TIPODOCTOID IN (21,23,25,26) or (new.tipodoctoid in (22,24) and :subtipodoctoid NOT IN (13,22,24)) ) then
        begin

         

             SELECT TIPOUTILIDADID FROM PARAMETRO INTO :TIPOUTILIDADID;

            NEW.utilidad = (  (case when coalesce(new.estadorebaja,0) = 1 then coalesce(new.precioconrebaja,0) else coalesce(new.precio,0) end) -
                                                        (CASE WHEN :tipoutilidadid = 1 THEN COALESCE(new.costoreposicion,0)
                                                           WHEN :tipoutilidadid = 3 THEN COALESCE(new.costoultimo,0)
                                                           ELSE COALESCE(new.costopromedio,0) END ) )
                                                            * COALESCE(new.cantidad, 0);
         end



   end

end