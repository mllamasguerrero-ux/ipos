EXECUTE BLOCK
AS
BEGIN
      insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (367, 'Reporte de abonos con la misma referencia');

    INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
    VALUES (367, 111, 'Abonos con misma referencia', 'Abonos con misma referencia', 367, 2,17);

    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 367);
    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 367);

end