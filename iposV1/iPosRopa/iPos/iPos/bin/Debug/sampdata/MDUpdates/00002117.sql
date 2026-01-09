CREATE OR ALTER trigger receta_bi_retenida for receta
active before insert or update position 0
AS
begin
  /* Trigger text */

  IF ((NEW.FOLIO IS NULL) AND (NEW.retenida = 'S')) THEN
  BEGIN
    NEW.FOLIO = GEN_ID(SEQ_RECETA_FOLIO, 1);
  END

end
