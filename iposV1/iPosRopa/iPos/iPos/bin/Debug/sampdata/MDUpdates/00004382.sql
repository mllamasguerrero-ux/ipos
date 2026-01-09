execute block
as
begin

  
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (291, 'Reporte de apertura y cierre de cortes');
  	
	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (291, 111, 'Reporte de apertura y cierre de cortes', 'Reporte de apertura y cierre de cortes', 291, 3, 5);

	
	

	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 291);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 291);









end