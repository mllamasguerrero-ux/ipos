execute block
as
begin

  
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (281, 'Consulta de puntos');
  	
	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (281, 278, 'Consulta de puntos', 'Consulta de puntos', 281, 2, 2);


	
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 281);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 281);






end