execute block
as
begin

  
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (274, 'Menu Utilerias Emida');
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (275, 'Submenu reajustar campos de productos emida');
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (276, 'Submenu Recalcular utilidades transacciones Emida');
  	
	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (274, 263, 'Utilerias Emida', 'Utilerias Emida', 274, 2, 3);

	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (275, 274, 'Reajustar campos de productos Emida', 'Reajustar campos de productos Emida', 275, 2, 1);

	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (276, 274, 'Recalcular utilidades transacciones', 'Recalcular utilidades transacciones', 276, 2, 2);

	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 274);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 274);


	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 275);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 275);


	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 276);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 276);



end