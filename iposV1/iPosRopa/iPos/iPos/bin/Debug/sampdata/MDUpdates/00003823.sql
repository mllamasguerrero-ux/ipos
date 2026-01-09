execute block
as
begin

  
  insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (255, 'Inventario Costeado MultiSucursal');
  insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (256, 'Ventas por Proveedor MultiSucursal');
  insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (257, 'Diario de Compras MultiSucursal');

	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (255, 231, 'Inventario Costeado MultiSucursal', 'Inventario Costeado MultiSucursal', 255, 2, 4);

	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (256, 231, 'Ventas por Proveedor MultiSucursal', 'Ventas por Proveedor MultiSucursal', 256, 2, 5);

	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (257, 231, 'Diario de Compras MultiSucursal', 'Diario de Compras MultiSucursal', 257, 2, 6);

	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 255);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 255);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 256);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 256);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 257);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 257);


end
