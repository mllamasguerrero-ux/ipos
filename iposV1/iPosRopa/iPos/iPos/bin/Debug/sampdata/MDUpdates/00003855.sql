execute block
as
begin

  
  insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (270, 'Gastos Sumarizado MultiSucursal');

	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (270, 231, 'Gastos Sumarizado MultiSucursal', 'Gastos Sumarizado MultiSucursal', 270, 2, 7);

	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 270);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 270);


end