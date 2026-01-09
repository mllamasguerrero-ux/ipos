EXECUTE BLOCK
AS
BEGIN
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (346, 'Pagos a proveedores de sucursales');
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (347, 'Facturas originales compras');
  	
	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (346, 76, 'Pagos a proveedores de sucursales', 'Pagos a proveedores de sucursales', 346, 2, 5);
	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (347, 5, 'Facturas originales compras', 'Facturas originales compras', 347, 2, 11);

	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 346);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 346);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 347);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 347);

END