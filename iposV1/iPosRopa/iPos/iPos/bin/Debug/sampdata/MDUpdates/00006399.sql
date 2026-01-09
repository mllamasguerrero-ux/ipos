EXECUTE BLOCK
AS
BEGIN

      insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (10170, 'Cambiar precio en recepcion de orden de compra');
    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 10170);
    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 10170);

end