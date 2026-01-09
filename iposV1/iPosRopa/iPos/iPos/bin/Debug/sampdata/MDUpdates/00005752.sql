EXECUTE BLOCK
AS
BEGIN
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (345, 'Abonos a proveedores de sucursales');
  	
	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (345, 76, 'Abonos a proveedores de sucursales', 'Abonos a proveedores de sucursales', 345, 2, 3);

	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 345);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 345);

END