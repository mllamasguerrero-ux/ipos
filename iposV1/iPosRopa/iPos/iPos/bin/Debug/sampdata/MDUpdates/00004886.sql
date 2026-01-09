EXECUTE BLOCK
AS
BEGIN

        --update parametro set generarfe = 'N';

  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (1098, 'Promociones - Activar/Desactivar');
  	

	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 1098);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 1098);


END
