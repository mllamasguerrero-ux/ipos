EXECUTE BLOCK
AS
BEGIN
      insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (10161, 'Cambiar costo reposicion en lista precio especiales');


    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 10161);
    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 10161);

end