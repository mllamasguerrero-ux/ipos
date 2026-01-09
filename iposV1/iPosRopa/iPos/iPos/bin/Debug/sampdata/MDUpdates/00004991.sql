EXECUTE BLOCK
AS
declare variable ESMATRIZ D_BOOLCN_NULL ;
declare variable SURTIDOR D_CLAVE_NULL;
declare variable SUCURSALID D_FK;

declare variable PRODUCTOID D_FK;
declare variable PRECIO1 D_PRECIO;
declare variable PRECIO2 D_PRECIO;
declare variable PRECIO3 D_PRECIO;
declare variable PRECIO4 D_PRECIO;
declare variable PRECIO5 D_PRECIO;  
declare variable COSTOREPOSICION D_COSTO;
BEGIN


   SELECT FIRST 1 SUCURSALID FROM PARAMETRO INTO :SUCURSALID;

   SELECT ESMATRIZ, SURTIDOR FROM SUCURSAL WHERE ID = :SUCURSALID INTO :ESMATRIZ, :SURTIDOR;

   IF(COALESCE(:ESMATRIZ,'N') = 'S' AND COALESCE(:SURTIDOR,'') = '') THEN
   BEGIN 
        DELETE FROM PRODUCTOPRECIOLOG;

        FOR 
            select
                ID, precio1, precio2, precio3, precio4, precio5 , costoreposicion
            from producto
            into
                :PRODUCTOID,:precio1, :precio2, :precio3, :precio4, :precio5, :costoreposicion
        DO
        BEGIN

            INSERT INTO PRODUCTOPRECIOLOG
                (FECHA, PRODUCTOID, PRECIO1, PRECIO2, PRECIO3, PRECIO4, PRECIO5, COSTOREPOSICION)
            VALUES 
                (CURRENT_DATE, :PRODUCTOID, :PRECIO1, :PRECIO2, :PRECIO3, :PRECIO4, :PRECIO5, :COSTOREPOSICION);

        END

   END

END
