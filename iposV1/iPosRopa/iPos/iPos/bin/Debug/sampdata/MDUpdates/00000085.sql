insert into derechos (DR_DERECHO,DR_DESCRIPCION)
SELECT (MN_ID + 2000) ,MN_ETIQUETA || ' - Eliminacion'from menuitems
