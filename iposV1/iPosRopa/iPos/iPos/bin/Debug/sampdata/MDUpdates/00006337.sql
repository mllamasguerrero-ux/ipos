EXECUTE BLOCK
AS
BEGIN
      insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (10164, 'Movil - Procesar ventas de manera automatica');
      insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (10165, 'Movil - Procesar compras de manera automatica');
      insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (10166, 'Movil - Cambiar precio de compra');



    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 10166);
    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 10166);

end