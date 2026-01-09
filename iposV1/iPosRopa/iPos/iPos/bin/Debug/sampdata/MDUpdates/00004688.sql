EXECUTE BLOCK
AS
BEGIN


  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (350, 'Productos promocion');
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (351, 'Traslado a productos promocion');
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (352, 'Traslado de promocion a producto base');
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (353, 'Existencias por proveedor por sucursal');
  	
  	
	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (350, 12, 'Productos promocion', 'Productos promocion', 350, 2, 20);
	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (351, 350, 'Traslado a productos promocion', 'Traslado a productos promocion', 351, 2, 1);
	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (352, 350, 'Traslado de promocion a producto base', 'Traslado de promocion a producto base', 352, 2, 2);
	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (353, 350, 'Existencias por proveedor por sucursal', 'Existencias por proveedor por sucursal', 353, 2, 3);

	
	

	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 350);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 350);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 351);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 351);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 352);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 352);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 353);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 353);

  

END