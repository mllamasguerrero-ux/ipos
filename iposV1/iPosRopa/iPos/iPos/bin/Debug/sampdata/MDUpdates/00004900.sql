EXECUTE BLOCK
AS
BEGIN


  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (316, 'Bloquear clientes con ventas vencidas');
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (317, 'Generar poliza formato PDF');
  	
  	
	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (316, 263, 'Bloquear clientes con ventas vencidas', 'Bloquear clientes con ventas vencidas', 316, 2, 12);
	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (317, 218, 'Generar poliza formato PDF', 'Generar poliza formato PDF', 317, 2, 9);

	
	

	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 316);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 316);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 317);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 317);

  

END