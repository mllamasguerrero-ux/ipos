CREATE OR ALTER TRIGGER PERSONA_AI0_AUTOCOM FOR PERSONA
ACTIVE AFTER INSERT POSITION 0
AS
begin
  /* Trigger text */
  update parametro set lastchangeclientenombre = current_timestamp;
end