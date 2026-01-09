CREATE OR ALTER trigger parametro_au0 for parametro
active after update position 0
AS
declare variable ERRORCODE D_ERRORCODE;
begin
  /* Trigger text */

  if(coalesce(old.desgloseieps,'N') <> coalesce(new.desgloseieps, 'N')) then
  begin

      update producto set tasaimpuesto = round((coalesce(tasaiva,0) + (case when coalesce(new.desgloseieps, 'N') = 'S' then coalesce(tasaieps,0) else 0 end) + ((   (case when coalesce(new.desgloseieps, 'N') = 'S' then coalesce(tasaieps,0) else 0 end)    * coalesce(tasaiva,0))/100)) , 2);
      SELECT ERRORCODE FROM KIT_ACTUALIZARIMPUESTO_TODOS INTO :ERRORCODE;
  end

  
  if(coalesce(old.manejautilidadprecios,'N') <> 'S' AND  coalesce(new.manejautilidadprecios, 'N') = 'S') then
  begin

      update producto set
           PORCUTILPRECIO1  =  CASE WHEN COALESCE(COSTOREPOSICION,0) > 0  THEN CAST((100.00 * PRECIO1) / COSTOREPOSICION AS D_PRECIO) - 100.00 ELSE 0.00 END ,
           PORCUTILPRECIO2  =  CASE WHEN COALESCE(COSTOREPOSICION,0) > 0  THEN CAST((100.00 * PRECIO2) / COSTOREPOSICION AS D_PRECIO) - 100.00 ELSE 5.00 END ,
           PORCUTILPRECIO3  =  CASE WHEN COALESCE(COSTOREPOSICION,0) > 0  THEN CAST((100.00 * PRECIO3) / COSTOREPOSICION AS D_PRECIO) - 100.00 ELSE 0.00 END ,
           PORCUTILPRECIO4  =  CASE WHEN COALESCE(COSTOREPOSICION,0) > 0  THEN CAST((100.00 * PRECIO4) / COSTOREPOSICION AS D_PRECIO) - 100.00 ELSE 0.00 END ,
           PORCUTILPRECIO5  =  CASE WHEN COALESCE(COSTOREPOSICION,0) > 0  THEN CAST((100.00 * PRECIO5) / COSTOREPOSICION AS D_PRECIO)  - 100.00 ELSE 0.00 END ;
  end
end