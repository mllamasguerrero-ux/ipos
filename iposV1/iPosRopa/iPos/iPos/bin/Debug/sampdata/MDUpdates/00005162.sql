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
end