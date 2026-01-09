
EXECUTE BLOCK
AS
BEGIN


    
    insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (378, 'Reporte de faltantes de surtido a sucursales');

    INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
    VALUES (378, 110, 'Reporte de faltantes de surtido a sucursales', 'Reporte de faltantes de surtido a sucursales', 378, 2, 22);
    
    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 378);
    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 378);


END
