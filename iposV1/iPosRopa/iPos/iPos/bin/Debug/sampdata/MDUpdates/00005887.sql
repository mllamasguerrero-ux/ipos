EXECUTE BLOCK
AS
BEGIN
      insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (351, 'Reporte de compras de sucursal ');
      insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (352, 'Reporte de diferencia facturas originales');

    INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
    VALUES (351, 109, 'Compras de sucursales', 'Compras de sucursales', 351, 2, 8);
    INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
    VALUES (352, 109, 'Diferencia facturas originales', 'Diferencia facturas originales', 352, 2, 9);

    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 351);
    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 351);
    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 352);
    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 352);
end
