CREATE trigger kitdefinicion_unnivel for kitdefinicion
active after insert or update or delete position 5
AS
begin
  /* Trigger text */
  UPDATE PARAMETRO SET  KITSDEF_ULTACT = CURRENT_TIMESTAMP;
end