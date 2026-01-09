execute block
as
begin

UPDATE MENUITEMS 
SET MN_ETIQUETA = 'Control de embarques',
MN_DESC = 'Control de embarques'
WHERE MN_ID = 272;


UPDATE DERECHOS
SET DR_DESCRIPCION = 'Control de embarques'
WHERE DR_DERECHO = 272;


end