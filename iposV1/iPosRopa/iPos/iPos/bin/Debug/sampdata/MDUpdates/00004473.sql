execute block
as
begin

  
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (298, 'Pedidos por Existencia');
  	
	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (298, 84, 'Pedidos por Existencia', 'Pedidos por Existencia', 298, 2, 3);

	
	

	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 298);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 298);


end