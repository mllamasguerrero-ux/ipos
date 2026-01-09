create or alter procedure IMPORTAR_EXISTENCIA (
    PRODUCTOCLAVE type of D_CLAVE,
    CANTIDAD type of D_CANTIDAD,
    HORA type of D_HORA,
    FECHA type of D_FECHA,
    SUCURSALCLAVE type of D_CLAVE,
    ALMACENCLAVE type of D_CLAVE)
returns (
    EXISTENCIAID type of D_FK,
    ERRORCODE type of D_ERRORCODE)
as
declare variable SUCURSALID type of D_FK;
declare variable ALMACENID type of D_FK;
declare variable PRODUCTOID type of D_FK;
declare variable CUENTA D_CANTIDAD;
begin
   SELECT ID
   FROM PRODUCTO
   WHERE CLAVE = :productoClave
   INTO :PRODUCTOID;


    SELECT COALESCE(id,0)
   FROM sucursal
   WHERE clave = :sucursalClave
   INTO :sucursalId;

   
    SELECT COALESCE(id,0)
   FROM almacen
   WHERE clave = :almacenClave
   INTO :almacenId;

   select COALESCE(count(*),0) from   INVENTARIOSUCURSAL
   where   SUCURSALID =   :sucursalid and   ALMACENCLAVE =  :ALMACENCLAVE and    PRODUCTOID =  :PRODUCTOID
    into    :CUENTA;

     if(:CUENTA = 0) THEN
     BEGIN
    INSERT INTO INVENTARIOSUCURSAL
      (



SUCURSALID,

SUCURSALCLAVE,

ALMACENID,

ALMACENCLAVE,

PRODUCTOID,

PRODUCTOCLAVE,

HORA,

FECHA,

CANTIDAD,

COSTO,

COSTOULTIMO,

COSTOPROMEDIO
         )

Values (


:sucursalid,

:sucursalClave,

:almacenid,

:almacenClave,

:PRODUCTOID,

:productoClave,

:hora,

:fecha,

:cantidad,

0,

0,

0
);

 END
 ELSE
 BEGIN

     UPDATE  INVENTARIOSUCURSAL
     SET HORA = :HORA,
      FECHA = :FECHA,
      CANTIDAD = :CANTIDAD
       where   SUCURSALID =   :sucursalid and   ALMACENID =  :almacenid and    PRODUCTOID =  :PRODUCTOID    ;


 END




end