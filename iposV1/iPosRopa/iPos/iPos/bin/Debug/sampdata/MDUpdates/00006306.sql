EXECUTE BLOCK
AS
BEGIN
      insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (10160, 'Dejar saldo a favor del cliente en nota de credito');


    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 10160);
    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 10160);

end