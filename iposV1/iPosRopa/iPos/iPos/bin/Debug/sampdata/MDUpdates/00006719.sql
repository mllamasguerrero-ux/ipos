EXECUTE BLOCK
AS
BEGIN
      insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (371, 'Pagos a proveedores');
      
    INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
    VALUES (371, 76, 'Pagos a proveedoress', 'Pagos a proveedores', 371, 2, 7);
    
    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 371);
    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 371);


      insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (10172, 'Agregar notas y definir contado/factura en cotizacion');

    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 10172);
    INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 10172);
      
    
END
