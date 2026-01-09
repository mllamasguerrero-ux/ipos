execute block
as
begin

  
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (280, 'Reporte de prueba Bancomer');
  	
	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (280, 278, 'Reporte de prueba', 'Reporte de prueba', 280, 2, 2);


	
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 280);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 280);






end