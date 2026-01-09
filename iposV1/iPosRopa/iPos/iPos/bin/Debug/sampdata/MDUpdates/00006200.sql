EXECUTE BLOCK
AS
BEGIN
      insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (363, 'Solicitar mercancia');

    INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
    VALUES (363, 99, 'Solicitar mercancia', 'Solicitar mercancia', 363, 2,8);

    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 363);
    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 363);

	insert into subtipodocto 
	(id, activo, clave, nombre)
	values
	(29,'S','SOLICITAR MERCANCIA','SOLICITAR MERCANCIA');
end