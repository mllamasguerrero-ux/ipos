EXECUTE BLOCK
AS
BEGIN
      insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (369, 'Autorizar precios abajo del minimo - moviles');

    INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
    VALUES (369, 320, 'Autorizar precios abajo del minimo - moviles', 'Autorizar precios abajo del minimo - moviles', 369, 2,9);

    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 369);
    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 369);

end