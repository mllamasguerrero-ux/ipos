EXECUTE BLOCK
AS
BEGIN
      insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (361, 'Autorizacion topes movil');
      insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (362, 'CXC Autorizacion Movil');
      insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (10153, 'Movil Habilitar importacion de precios');
      insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (10154, 'Movil habilitar metodo abreviado importacion productos');

    INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
    VALUES (361, 320, 'Autorizacion topes movil', 'Autorizacion topes movil', 361, 2,8);
    INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
    VALUES (362, 320, 'CXC Autorizacion Movil', 'CXC Autorizacion Movil', 362, 2,9);

    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 361);
    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 361);
    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 362);
    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 362);
end