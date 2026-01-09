execute block
as
begin

  
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (292, 'Catalogo - Almacenes');
  	
	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (292, 1, 'Almacenes', 'Almacenes', 292, 2, 2);

	
	

	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 292);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 292);









end