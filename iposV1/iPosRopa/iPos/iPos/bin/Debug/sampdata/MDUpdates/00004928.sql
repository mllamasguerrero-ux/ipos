EXECUTE BLOCK
AS
BEGIN

  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (320, 'Submenu Vendedor Movil Procesos de matriz/sucursal');
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (321, 'Bitácora de cobranza Vendedor Movil');
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (322, 'Importacion de ventas de vendedor movil');
  	
	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (320, 155, 'Procesos de matriz/sucursal', 'Procesos de matriz/sucursal', 320, 2, 13);

	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (321, 320, 'Bitácora de cobranza', 'Bitácora de cobranza', 321, 2, 1);

	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (322, 320, 'Importacion de ventas de vendedor movil', 'Importacion de ventas de vendedor movil', 322, 2, 2);
	
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 320);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 320);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 321);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 321);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 322);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 322);

END