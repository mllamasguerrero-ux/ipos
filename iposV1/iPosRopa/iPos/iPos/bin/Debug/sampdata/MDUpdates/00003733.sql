execute block
as
begin

  update menuitems set mn_desc = 'Recargas y Servicios' , mn_etiqueta = 'Recargas y Servicios' where mn_id  = 248;

  update derechos set dr_descripcion = 'Reporte de Conciliacion Servicios Emida'  where dr_derecho = 248;

  
  insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (252, 'Clerk Pago Servicios');

	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (252, 248, 'Reporte de Conciliacion Servicios Emida', 'Reporte de Conciliacion Servicios Emida', 252, 2, 2);


	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 252);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 252);


end
