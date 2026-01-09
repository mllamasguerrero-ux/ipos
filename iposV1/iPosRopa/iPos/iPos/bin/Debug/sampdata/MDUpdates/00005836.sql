EXECUTE BLOCK
AS
BEGIN
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (10147, 'Devolver cheques');

	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 10147);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 10147);

insert into subtipodocto 
(id, activo, clave, nombre)
values
(27,'S','CHEQUE DEVUELTO','CHEQUE DEVUELTO');

END