execute block
as
begin

  
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (290, 'Reporte Inventario por Lotes');
  	
	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (290, 106, 'Inventario por lotes', 'Inventario por lotes', 290, 2, 23);

	
	

	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 290);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 290);









end