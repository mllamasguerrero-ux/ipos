execute block
as
begin

  
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (277, 'Exportar datos para inventario');
  	
	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (277, 102, 'Exportar datos para inventario', 'Exportar datos para inventario', 277, 2, 11);

	
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 277);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 277);





end