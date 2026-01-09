create or alter procedure PRODUCTOS_IMPORTAR_PRECIOS (
    CLAVE D_CLAVE,
    NOMBRE D_NOMBRE,
    PRECIO1 D_PRECIO,
    PRECIO2 D_PRECIO,
    PRECIO3 D_PRECIO,
    PRECIO4 D_PRECIO,
    PRECIO5 D_PRECIO)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable PRODUCTID D_FK;
BEGIN

   select min(id) productID from producto 
   where  clave = :CLAVE
   into :PRODUCTID;





   if(:PRODUCTID IS NOT NULL) Then
   BEGIN

    update  PRODUCTO

    set
    NOMBRE=:NOMBRE,
    PRECIO1=:PRECIO1,
    PRECIO2=:PRECIO2,
    PRECIO3=:PRECIO3,
    PRECIO4=:PRECIO4,
    PRECIO5=:PRECIO5
    where ID=:PRODUCTID;
   END






   ERRORCODE = 0;
   SUSPEND;

   /*WHEN ANY DO
   BEGIN
      ERRORCODE = 1022;
      SUSPEND;
   END */
END