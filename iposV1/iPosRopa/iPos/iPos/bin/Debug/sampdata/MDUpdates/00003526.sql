EXECUTE BLOCK
AS
BEGIN

INSERT INTO EMIDARESPCODE (ID, ACTIVO, CREADO, CREADOPOR_USERID, MODIFICADO, MODIFICADOPOR_USERID, CODIGO, DESCRIPCION, NOTAS)
  VALUES (1, 'S   ', '31-AUG-2016 16:09:46', 0, '31-AUG-2016 16:09:46', 0, 0, 'Transacción Exitosa', NULL);

INSERT INTO EMIDARESPCODE (ID, ACTIVO, CREADO, CREADOPOR_USERID, MODIFICADO, MODIFICADOPOR_USERID, CODIGO, DESCRIPCION, NOTAS)
  VALUES (2, 'S   ', '31-AUG-2016 16:10:58', 0, '31-AUG-2016 16:10:58', 0, 1, 'Monto Inválido', 'El monto solicitado no coincide con la cantidad configurada en el producto.');

INSERT INTO EMIDARESPCODE (ID, ACTIVO, CREADO, CREADOPOR_USERID, MODIFICADO, MODIFICADOPOR_USERID, CODIGO, DESCRIPCION, NOTAS)
  VALUES (3, 'S   ', '31-AUG-2016 16:23:50', 0, '31-AUG-2016 16:23:50', 0, 2, 'No está autorizado', 'El terminal indicado por el SiteID, no está autorizado para vender dicho producto');

INSERT INTO EMIDARESPCODE (ID, ACTIVO, CREADO, CREADOPOR_USERID, MODIFICADO, MODIFICADOPOR_USERID, CODIGO, DESCRIPCION, NOTAS)
  VALUES (4, 'S   ', '31-AUG-2016 16:26:26', 0, '31-AUG-2016 16:26:26', 0, 3, 'Agotado', 'El producto indicado en este momento no tiene inventario disponible (Aplica para el caso de pines).');

INSERT INTO EMIDARESPCODE (ID, ACTIVO, CREADO, CREADOPOR_USERID, MODIFICADO, MODIFICADOPOR_USERID, CODIGO, DESCRIPCION, NOTAS)
  VALUES (5, 'S   ', '31-AUG-2016 16:27:54', 0, '31-AUG-2016 16:27:54', 0, 4, 'Producto deshabilitado', 'El producto solicitado está deshabilitado para el terminal indicado');

INSERT INTO EMIDARESPCODE (ID, ACTIVO, CREADO, CREADOPOR_USERID, MODIFICADO, MODIFICADOPOR_USERID, CODIGO, DESCRIPCION, NOTAS)
  VALUES (6, 'S   ', '31-AUG-2016 16:28:35', 0, '31-AUG-2016 16:28:35', 0, 5, 'Producto inválido', 'El ProductID (SKU) no pertenece a un producto conocido');

INSERT INTO EMIDARESPCODE (ID, ACTIVO, CREADO, CREADOPOR_USERID, MODIFICADO, MODIFICADOPOR_USERID, CODIGO, DESCRIPCION, NOTAS)
  VALUES (7, 'S   ', '31-AUG-2016 16:29:09', 0, '31-AUG-2016 16:29:09', 0, 7, 'Versión inválida', 'Solicitud de versión suministrada no es válida');

INSERT INTO EMIDARESPCODE (ID, ACTIVO, CREADO, CREADOPOR_USERID, MODIFICADO, MODIFICADOPOR_USERID, CODIGO, DESCRIPCION, NOTAS)
  VALUES (8, 'S   ', '31-AUG-2016 16:29:45', 0, '31-AUG-2016 16:29:45', 0, 10, 'Terminal no válido', 'El SiteID enviado no pertenece a un terminal conocido');

INSERT INTO EMIDARESPCODE (ID, ACTIVO, CREADO, CREADOPOR_USERID, MODIFICADO, MODIFICADOPOR_USERID, CODIGO, DESCRIPCION, NOTAS)
  VALUES (9, 'S   ', '31-AUG-2016 16:30:16', 0, '31-AUG-2016 16:30:16', 0, 11, 'Terminal deshabilitada', 'Terminal está desactivada');

INSERT INTO EMIDARESPCODE (ID, ACTIVO, CREADO, CREADOPOR_USERID, MODIFICADO, MODIFICADOPOR_USERID, CODIGO, DESCRIPCION, NOTAS)
  VALUES (10, 'S   ', '31-AUG-2016 16:43:21', 0, '31-AUG-2016 16:43:21', 0, 12, 'ClerkId Inválido', 'Numero de operador usado no es válido');

INSERT INTO EMIDARESPCODE (ID, ACTIVO, CREADO, CREADOPOR_USERID, MODIFICADO, MODIFICADOPOR_USERID, CODIGO, DESCRIPCION, NOTAS)
  VALUES (11, 'S   ', '31-AUG-2016 16:43:52', 0, '31-AUG-2016 16:43:52', 0, 16, 'Transacción Fallida', 'Error en la transacción debido a problemas por parte del carrier.');

INSERT INTO EMIDARESPCODE (ID, ACTIVO, CREADO, CREADOPOR_USERID, MODIFICADO, MODIFICADOPOR_USERID, CODIGO, DESCRIPCION, NOTAS)
  VALUES (12, 'S   ', '31-AUG-2016 16:44:25', 0, '31-AUG-2016 16:44:25', 0, 17, 'Transacción Fallida', 'Error en la transacción debido a problemas por parte del carrier.');

INSERT INTO EMIDARESPCODE (ID, ACTIVO, CREADO, CREADOPOR_USERID, MODIFICADO, MODIFICADOPOR_USERID, CODIGO, DESCRIPCION, NOTAS)
  VALUES (13, 'S   ', '31-AUG-2016 16:45:08', 0, '31-AUG-2016 16:45:08', 0, 18, 'Transacción Fallida', 'Error en la transacción debido a problemas por parte del carrier.');

INSERT INTO EMIDARESPCODE (ID, ACTIVO, CREADO, CREADOPOR_USERID, MODIFICADO, MODIFICADOPOR_USERID, CODIGO, DESCRIPCION, NOTAS)
  VALUES (14, 'S   ', '31-AUG-2016 16:46:05', 0, '31-AUG-2016 16:46:05', 0, 20, 'MerchantId Inválido', 'El número de comercio suministrado no existe o no está asociado a la Terminal');

INSERT INTO EMIDARESPCODE (ID, ACTIVO, CREADO, CREADOPOR_USERID, MODIFICADO, MODIFICADOPOR_USERID, CODIGO, DESCRIPCION, NOTAS)
  VALUES (15, 'S   ', '31-AUG-2016 16:46:38', 0, '31-AUG-2016 16:46:38', 0, 21, 'Código de Banco inválido', 'El parámetro BankCode es requerido, pero el valor suministrado no coincide con el código de un Banco definido en la plataforma');

INSERT INTO EMIDARESPCODE (ID, ACTIVO, CREADO, CREADOPOR_USERID, MODIFICADO, MODIFICADOPOR_USERID, CODIGO, DESCRIPCION, NOTAS)
  VALUES (16, 'S   ', '31-AUG-2016 16:47:15', 0, '31-AUG-2016 16:47:15', 0, 23, 'Fecha de Documento no válida', 'La Fecha Suministrada DocumentDate no coincide con el formato MM /dd/aaaa');

INSERT INTO EMIDARESPCODE (ID, ACTIVO, CREADO, CREADOPOR_USERID, MODIFICADO, MODIFICADOPOR_USERID, CODIGO, DESCRIPCION, NOTAS)
  VALUES (17, 'S   ', '31-AUG-2016 17:00:05', 0, '31-AUG-2016 17:00:05', 0, 24, 'Error al crear el PaymentRequest (Requerimiento de Pago)', 'Se produjo un error al adicionar la Notificación de pago en la base de datos');

INSERT INTO EMIDARESPCODE (ID, ACTIVO, CREADO, CREADOPOR_USERID, MODIFICADO, MODIFICADOPOR_USERID, CODIGO, DESCRIPCION, NOTAS)
  VALUES (18, 'S   ', '31-AUG-2016 17:00:37', 0, '31-AUG-2016 17:00:37', 0, 25, 'Número de documento no válido', 'El número de documento suministrado DocumentNumber tiene más de 64 bytes de longitud');

INSERT INTO EMIDARESPCODE (ID, ACTIVO, CREADO, CREADOPOR_USERID, MODIFICADO, MODIFICADOPOR_USERID, CODIGO, DESCRIPCION, NOTAS)
  VALUES (19, 'S   ', '31-AUG-2016 17:18:48', 0, '31-AUG-2016 17:18:48', 0, 32, 'Transaccion declinada por timeout.', 'El carrier no respondió la petición.');

INSERT INTO EMIDARESPCODE (ID, ACTIVO, CREADO, CREADOPOR_USERID, MODIFICADO, MODIFICADOPOR_USERID, CODIGO, DESCRIPCION, NOTAS)
  VALUES (20, 'S   ', '31-AUG-2016 17:19:19', 0, '31-AUG-2016 17:19:19', 0, 51, 'Proveedor No Disponible / Error Operativo', 'El proveedor no está disponible o Error operativo. La respuesta debe basarse en Response Code & Response Message.');

INSERT INTO EMIDARESPCODE (ID, ACTIVO, CREADO, CREADOPOR_USERID, MODIFICADO, MODIFICADOPOR_USERID, CODIGO, DESCRIPCION, NOTAS)
  VALUES (21, 'S   ', '31-AUG-2016 17:19:51', 0, '31-AUG-2016 17:19:51', 0, 95, 'Dirección IP no válida', 'Dirección IP suministrada no está autorizada');

INSERT INTO EMIDARESPCODE (ID, ACTIVO, CREADO, CREADOPOR_USERID, MODIFICADO, MODIFICADOPOR_USERID, CODIGO, DESCRIPCION, NOTAS)
  VALUES (22, 'S   ', '31-AUG-2016 17:34:42', 0, '31-AUG-2016 17:34:42', 0, 96, 'Error interno', 'Error en el Sistema interno de Emida');

INSERT INTO EMIDARESPCODE (ID, ACTIVO, CREADO, CREADOPOR_USERID, MODIFICADO, MODIFICADOPOR_USERID, CODIGO, DESCRIPCION, NOTAS)
  VALUES (23, 'S   ', '31-AUG-2016 17:35:10', 0, '31-AUG-2016 17:35:10', 0, 101, 'Información de Login No válido', 'Nombre de usuario / password vacía o invalida');

INSERT INTO EMIDARESPCODE (ID, ACTIVO, CREADO, CREADOPOR_USERID, MODIFICADO, MODIFICADOPOR_USERID, CODIGO, DESCRIPCION, NOTAS)
  VALUES (24, 'S   ', '31-AUG-2016 17:35:41', 0, '31-AUG-2016 17:35:41', 0, 102, 'Usuario no autenticado', 'El usuario no ha hecho Login y está tratando de acceder a otro de los métodos públicos');

INSERT INTO EMIDARESPCODE (ID, ACTIVO, CREADO, CREADOPOR_USERID, MODIFICADO, MODIFICADOPOR_USERID, CODIGO, DESCRIPCION, NOTAS)
  VALUES (25, 'S   ', '31-AUG-2016 17:36:28', 0, '31-AUG-2016 17:36:28', 0, 103, 'Permiso de autenticación en WebService no está habilitada', 'Si el ISO al que corresponde ese SiteId (identificación de la terminal) no tiene el permiso habilitado “Enable Webservice Authentication for Terminals”');

INSERT INTO EMIDARESPCODE (ID, ACTIVO, CREADO, CREADOPOR_USERID, MODIFICADO, MODIFICADOPOR_USERID, CODIGO, DESCRIPCION, NOTAS)
  VALUES (26, 'S   ', '31-AUG-2016 17:37:02', 0, '31-AUG-2016 17:37:02', 0, 150, 'Proveedor Deshabilitado', 'El sistema del proveedor no está disponible en ese momento');
END