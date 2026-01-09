CREATE OR ALTER PROCEDURE PRODUCTOS_IMPORTAR (
    clave d_clave,
    nombre d_nombre,
    descripcion d_descripcion,
    ean d_clave,
    descripcion1 varchar(40),
    descripcion2 varchar(40),
    descripcion3 varchar(40),
    proveedor1id integer,
    proveedor2id integer,
    clave_linea d_clave,
    clave_marca d_clave,
    precio1 d_precio,
    precio2 d_precio,
    precio3 d_precio,
    precio4 d_precio,
    precio5 d_precio,
    tasaivaid d_fk,
    tasaiva d_porcentaje,
    clave_moneda d_clave,
    costoreposicion d_costo,
    costoultimo d_costo,
    costopromedio d_costo,
    clave_sustituto d_clave,
    manejalote d_boolcn,
    eskit d_boolcn,
    imprimir d_boolcs,
    inventariable d_boolcs,
    negativos d_boolcn,
    limiteprecio2 d_cantidad,
    preciomaximopublico d_precio,
    clave_proveedor1 d_clave,
    clave_proveedor2 d_clave)
returns (
    errorcode d_errorcode)
as
declare variable productid d_fk;
declare variable productosustitutoid d_fk;
declare variable lineaid integer;
declare variable marcaid integer;
declare variable monedaid d_fk;
BEGIN

   select min(id) productID from producto 
   where  clave = :CLAVE
   into :PRODUCTID;


   if(:CLAVE_SUSTITUTO = '') then
   begin
       PRODUCTOSUSTITUTOID = null;
   end
   else
   begin
      select min(id) productID from producto
       where  clave = :CLAVE_SUSTITUTO
        into :PRODUCTOSUSTITUTOID;
   end


   select min(id) lineaID from linea 
   where  clave = :CLAVE_LINEA
  into :LINEAID;



   select min(id) marcaID from marca
   where  clave = :CLAVE_MARCA
   into :MARCAID;




   select min(id) monedaID from moneda
   where  clave = :CLAVE_MONEDA
   into :MONEDAID;

   
   select min(id) proveedor1ID from persona
   where  clave = :clave_proveedor1 and  tipopersonaid = 40
   into :proveedor1id;

   select min(id) proveedor2ID from persona
   where  clave = :clave_proveedor2  and  tipopersonaid = 40
   into :proveedor2id;


   if(:PRODUCTID IS NOT NULL) Then
   BEGIN

    update  PRODUCTO

    set
    NOMBRE=:NOMBRE,
    DESCRIPCION=:DESCRIPCION,
    EAN=:EAN,
    DESCRIPCION1=:DESCRIPCION1,
    DESCRIPCION2=:DESCRIPCION2,
    DESCRIPCION3=:DESCRIPCION3,
    LINEAID=:LINEAID,
    MARCAID=:MARCAID,
    PRECIO1=:PRECIO1,
    PRECIO2=:PRECIO2,
    PRECIO3=:PRECIO3,
    PRECIO4=:PRECIO4,
    PRECIO5=:PRECIO5,
    TASAIVAID=:TASAIVAID,
    TASAIVA=:TASAIVA,
    MONEDAID=:MONEDAID,
    COSTOREPOSICION=:COSTOREPOSICION,
    COSTOULTIMO=:COSTOULTIMO,
    COSTOPROMEDIO=:COSTOPROMEDIO,
    PRODUCTOSUSTITUTOID=:PRODUCTOSUSTITUTOID,
    MANEJALOTE=:MANEJALOTE,
    ESKIT=:ESKIT,
    IMPRIMIR=:IMPRIMIR,
    INVENTARIABLE=:INVENTARIABLE,
    NEGATIVOS=:NEGATIVOS,
    LIMITEPRECIO2=:LIMITEPRECIO2,
    PRECIOMAXIMOPUBLICO =:PRECIOMAXIMOPUBLICO ,
    proveedor1id = :proveedor1id , 
    proveedor2id = :proveedor2id
    
    where ID=:PRODUCTID;
   END
   ELSE
   BEGIN
       insert into producto
       (
        ACTIVO,
        CLAVE,
    NOMBRE,
    DESCRIPCION,
    EAN,
    DESCRIPCION1,
    DESCRIPCION2,
    DESCRIPCION3,
    LINEAID,
    MARCAID,
    PRECIO1,
    PRECIO2,
    PRECIO3,
    PRECIO4,
    PRECIO5,
    TASAIVAID,
    TASAIVA,
    MONEDAID,
    COSTOREPOSICION,
    COSTOULTIMO,
    COSTOPROMEDIO,
    PRODUCTOSUSTITUTOID,
    MANEJALOTE,
    ESKIT,
    IMPRIMIR,
    INVENTARIABLE,
    NEGATIVOS,
    LIMITEPRECIO2,
    PRECIOMAXIMOPUBLICO)

           VALUES
        (    
        'S',
        :CLAVE,
    :NOMBRE,
    :DESCRIPCION,
    :EAN,
    :DESCRIPCION1,
    :DESCRIPCION2,
    :DESCRIPCION3,
    :LINEAID,
    :MARCAID,
    :PRECIO1,
    :PRECIO2,
    :PRECIO3,
    :PRECIO4,
    :PRECIO5,
    :TASAIVAID,
    :TASAIVA,
    :MONEDAID,
    :COSTOREPOSICION,
    :COSTOULTIMO,
    :COSTOPROMEDIO,
    :PRODUCTOSUSTITUTOID,
    :MANEJALOTE,
    :ESKIT,
    :IMPRIMIR,
    :INVENTARIABLE,
    :NEGATIVOS,
    :LIMITEPRECIO2,
    :PRECIOMAXIMOPUBLICO);
   END




   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1022;
      SUSPEND;
   END 
END