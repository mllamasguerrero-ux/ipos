EXECUTE BLOCK
AS
BEGIN


  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (318, 'Reasignar notas de credito');
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (10121, 'Aplicar notas de credito a cortes de un dia anterior');
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (10122, 'Aplicar notas de credito a cortes de cuaquier dia anterior');
  	
  	
	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (318, 5, 'Reasignar notas de credito', 'Reasignar notas de credito', 318, 2, 8);

	
	

	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 318);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 318);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 10121);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 10121);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 10122);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 10122);

  

END