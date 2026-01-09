CREATE OR ALTER TRIGGER PERSONA_AU2_AUTOCOMP FOR PERSONA
ACTIVE AFTER UPDATE POSITION 0
AS
begin
  /* Trigger text */
    if( coalesce(old.nombre,'') <> coalesce(new.nombre,'') or coalesce(old.nombres,'') <> coalesce(new.nombres,'')) then
  begin
    
      update parametro set lastchangeclientenombre = current_timestamp;
  end

end