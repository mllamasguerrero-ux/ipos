EXECUTE BLOCK
AS
BEGIN
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (331, 'Reporte de Recuperacion de cobranza por mes');
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (332, 'Reporte de Lista Precio mas vendidos');
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (333, 'Reporte de comisiones por cajero');
  	
	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (331, 111, 'Recuperacion de cobranza por mes', 'Recuperacion de cobranza por mes', 331, 2, 15);
	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (332, 106, 'Reporte de Lista Precio mas vendidos', 'Reporte de Lista Precio mas vendidos', 332, 2, 25);
	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (333, 110, 'Reporte de comisiones por cajero', 'Reporte de comisiones por cajero', 333, 2, 18);

	
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 331);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 331);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 332);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 332);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 333);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 333);

END