EXECUTE BLOCK
AS
BEGIN
      insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (354, 'Utilerias eliminacion de  ventas pendientes');
      insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (355, 'Reporte de reversion de abonos');

    INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
    VALUES (354, 263, 'Eliminacion de ventas pendientes', 'Eliminacion de ventas pendientes', 354, 2, 92);
    INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
    VALUES (355, 111, 'Reversion de abonos', 'Reversion de abonos', 355, 2, 16);

    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 354);
    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 354);
    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 355);
    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 355);
end