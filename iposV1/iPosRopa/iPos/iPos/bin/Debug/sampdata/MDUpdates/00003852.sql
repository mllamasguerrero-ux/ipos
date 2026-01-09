execute block
as
begin

  
  insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (259, 'Faltante de Ordenes de Compra');

	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (259, 109, 'Faltante de Ordenes de Compra', 'Faltante de Ordenes de Compra', 259, 2, 6);

	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 259);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 259);


end