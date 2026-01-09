EXECUTE BLOCK
AS
BEGIN
      insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (10174, 'Imprimir ticket pedido movil');
      insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (10175, 'Imprimir recibo largo pedido movil');
      
    
    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 10174);
    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 10174);

    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 10175);
    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 10175);


      
    
END