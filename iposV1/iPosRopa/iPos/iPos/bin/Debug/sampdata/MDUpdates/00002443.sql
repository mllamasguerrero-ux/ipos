CREATE OR ALTER TRIGGER PARAMETRO_AU0 FOR PARAMETRO
ACTIVE AFTER UPDATE POSITION 0
AS
begin
  /* Trigger text */

  if(coalesce(old.desgloseieps,'N') <> coalesce(new.desgloseieps, 'N')) then
  begin

      update producto set tasaimpuesto = round((coalesce(tasaiva,0) + (case when coalesce(new.desgloseieps, 'N') = 'S' then coalesce(tasaieps,0) else 0 end) + ((   (case when coalesce(new.desgloseieps, 'N') = 'S' then coalesce(tasaieps,0) else 0 end)    * coalesce(tasaiva,0))/100)) , 2);

  end
end