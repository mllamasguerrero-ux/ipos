CREATE OR ALTER trigger movto_bu0_utilidad for movto
active before update position 0
AS
declare variable UTILIDAD d_precio;
declare variable TIPOUTILIDADID d_fk;
declare variable subtipodoctoid d_fk; 
declare variable EMIDAUTILIDADPAGOSERVICIOS  D_PRECIO;

begin
  /* Trigger text */
               
   if(new.estatusmovtoid = 1 and old.estatusmovtoid = 0) then
   begin
          select subtipodoctoid from docto where id = new.doctoid into :subtipodoctoid;  
          subtipodoctoid = coalesce(:subtipodoctoid, 0);

        if( (NEW.TIPODOCTOID IN (21,23,25,26) and :subtipodoctoid NOT IN (24)) or (new.tipodoctoid in (22,24) and :subtipodoctoid NOT IN (13)) ) then
        begin

         

             SELECT TIPOUTILIDADID FROM PARAMETRO INTO :TIPOUTILIDADID;

            NEW.utilidad = (  (case when coalesce(new.estadorebaja,0) = 1 then cast(coalesce(new.precioconrebaja,0.0) as d_precio) else cast(coalesce(new.precio,0.0) as d_precio) end) -
                                                        (CASE WHEN :tipoutilidadid = 1 THEN cast(COALESCE(new.costoreposicion,0.0) as d_precio)
                                                           WHEN :tipoutilidadid = 3 THEN cast(COALESCE(new.costoultimo,0.0) as d_precio)
                                                           ELSE cast(COALESCE(new.costopromedio,0.0) as d_precio) END ) )
                                                            * COALESCE(new.cantidad, 0.0);
         end
         else if( (NEW.TIPODOCTOID IN (21,23,25,26) and :subtipodoctoid  in (24)) ) then
         begin
             SELECT TIPOUTILIDADID,EMIDAUTILIDADPAGOSERVICIOS FROM PARAMETRO INTO :TIPOUTILIDADID, :EMIDAUTILIDADPAGOSERVICIOS ;
             NEW.utilidad = COALESCE(:EMIDAUTILIDADPAGOSERVICIOS,0);

         end



   end

end