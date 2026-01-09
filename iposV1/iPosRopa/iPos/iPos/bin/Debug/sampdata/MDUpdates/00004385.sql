execute block
as
begin

  
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (293, 'Reporte de Transacciones Bancomers');
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (11002, 'Reimprimir Voucher - Bancomer');
  	
	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (293, 278, 'Reporte de Transacciones', 'Reporte de Transacciones', 293, 2, 5);

	
	

	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 293);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 293);


end