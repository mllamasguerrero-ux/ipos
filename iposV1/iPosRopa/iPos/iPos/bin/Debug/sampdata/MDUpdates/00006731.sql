EXECUTE BLOCK
AS
BEGIN
      insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (372, 'Surtido Pendiente Movil');
      
    INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
    VALUES (372, 320, 'Surtido Pendiente Movil', 'Surtido pendiente movil', 372, 2, 10);
    
    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 372);
    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 372);

      
    
END
