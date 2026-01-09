insert into derechos (DR_DERECHO,DR_DESCRIPCION)
SELECT (MN_ID + 1000) ,MN_ETIQUETA || ' - Edicion' from menuitems
