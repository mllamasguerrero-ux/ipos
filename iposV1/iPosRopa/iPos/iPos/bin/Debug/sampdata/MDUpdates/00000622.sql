create or alter procedure GET_PROMO_PRECIO (
    PRODUCTOID D_FK,
    PERSONAID D_FK,
    CANTIDAD D_CANTIDAD,
    PRECIO1 D_PRECIO,
    PRECIOPREVIO D_PRECIO)
returns (
    PRECIOPROMO D_PRECIO,
    ESPROMOCION D_BOOLCN,
    PROMOCIONID D_FK,
    PROMOCIONDESGLOSE D_STDTEXT_64,
    MONEDEROABONO D_PRECIO,
    ERRORCODE D_ERRORCODE)
as
declare variable DIASEMANA smallint;
declare variable CANTIDADLLEVATE D_CANTIDAD;
declare variable CANTIDADPROMO D_CANTIDAD;
declare variable TIPOPROMOCIONID D_FK;
declare variable IMPORTEPROMO D_PRECIO;
declare variable PORCPROMO D_PORCENTAJE;
declare variable PRECIOACTUAL D_PRECIO;
declare variable CANTIDADPROMOPORAPLICACION D_CANTIDAD;
declare variable NUMAPLICACIONES D_CANTIDAD;
declare variable APLICADOSRESIDUALES D_CANTIDAD;
declare variable CANTIDADCONPROMO D_CANTIDAD;
declare variable CANTIDADSINPROMO D_CANTIDAD;
declare variable PRECIOBUFFER D_PRECIO;
declare variable PRECIOSINPROMO D_PRECIO;
declare variable PROMOCIONIDBUFFER D_FK;
declare variable PRECIOBUFFERPROMO D_PRECIO;
declare variable ENMONEDERO D_BOOLCN;
BEGIN



     DIASEMANA = EXTRACT ( WEEKDAY FROM CURRENT_DATE);
     --0  = DOMINGO
     PRECIOACTUAL = :PRECIOPREVIO;

     PRECIOPROMO = :PRECIOPREVIO;
     ESPROMOCION = 'N';
     PROMOCIONID = NULL;
     PROMOCIONDESGLOSE = NULL;
     MONEDEROABONO = 0;

     
   FOR SELECT PROMOCION.ID,
     PROMOCION.CANTIDADLLEVATE,
     PROMOCION.cantidad,
     PROMOCION.tipopromocionid,
     PROMOCION.importe,
     PROMOCION.porcentajedescuento,
     PROMOCION.enmonedero
     FROM PROMOCION
     LEFT JOIN PRODUCTO ON PROMOCION.productoid = PRODUCTO.id
     WHERE
     ((PROMOCION.rangopromocionid = 1 AND PROMOCION.productoid = :PRODUCTOID) OR
     (PROMOCION.rangopromocionid = 2 AND PROMOCION.lineaid = PRODUCTO.lineaid AND PRODUCTO.id = :PRODUCTOID))
     AND PROMOCION.fechainicio <= CURRENT_DATE AND PROMOCION.FECHAFIN >= current_date
     AND
     (
     (PROMOCION.lunes = 'S' AND :DIASEMANA = 1 ) or
     (PROMOCION.martes = 'S' AND :DIASEMANA = 2 ) or
     (PROMOCION.miercoles = 'S' AND :DIASEMANA = 3 ) or
     (PROMOCION.jueves = 'S' AND :DIASEMANA = 4 ) or
     (PROMOCION.viernes = 'S' AND :DIASEMANA =5 ) or
     (PROMOCION.sabado = 'S' AND :DIASEMANA = 6 ) or
     (PROMOCION.domingo = 'S' AND :DIASEMANA = 0 )

     )
     AND PROMOCION.activo = 'S'
   INTO
      :PROMOCIONIDBUFFER, :CANTIDADLLEVATE, :CANTIDADPROMO,
      :tipopromocionid, :IMPORTEPROMO, :PORCPROMO, :ENMONEDERO
   DO
   BEGIN



        IF(:TIPOPROMOCIONID = 1) THEN
        BEGIN
            IF(:CANTIDAD > :CANTIDADPROMO) THEN
            BEGIN
                CANTIDADPROMOPORAPLICACION = :CANTIDADLLEVATE - :CANTIDADPROMO;
                NUMAPLICACIONES = FLOOR(:CANTIDAD/:CANTIDADLLEVATE);
                APLICADOSRESIDUALES = :CANTIDAD - (:CANTIDADLLEVATE * :NUMAPLICACIONES) - :CANTIDADPROMO;
                IF(:APLICADOSRESIDUALES < 0) THEN
                BEGIN
                    APLICADOSRESIDUALES = 0;
                END
                CANTIDADCONPROMO = (:NUMAPLICACIONES * :CANTIDADPROMOPORAPLICACION ) + :APLICADOSRESIDUALES;
                CANTIDADSINPROMO = :CANTIDAD - :CANTIDADCONPROMO;
                PRECIOBUFFER = (:CANTIDADSINPROMO * :PRECIO1)/:CANTIDAD;

                IF( :PRECIOBUFFER < :PRECIOACTUAL) THEN
                BEGIN
                   PRECIOACTUAL = :PRECIOBUFFER;
                   ESPROMOCION = 'S';
                   PROMOCIONID = :PROMOCIONIDBUFFER;
                   PROMOCIONDESGLOSE = 'GRATIS ' || CAST(:CANTIDADCONPROMO AS VARCHAR(10))
                                     || ' Y CON PRECIO ' ||  CAST(:PRECIO1 AS VARCHAR(10))
                                     || ' ' || CAST(:CANTIDADSINPROMO AS VARCHAR(10));
                                     
                   MONEDEROABONO = 0;
                END

            END
        END
        ELSE IF (:TIPOPROMOCIONID = 2) THEN
        BEGIN
            IF(:CANTIDAD > :CANTIDADPROMO) THEN
            BEGIN
                 
                PRECIOBUFFERPROMO = :CANTIDADPROMO/:IMPORTEPROMO;
                NUMAPLICACIONES = FLOOR(:CANTIDAD/:CANTIDADPROMO);
                CANTIDADCONPROMO = :NUMAPLICACIONES * :CANTIDADPROMO;
                CANTIDADSINPROMO = :CANTIDAD - :CANTIDADCONPROMO;
                PRECIOBUFFER = ((PRECIOBUFFERPROMO * CANTIDADCONPROMO) + (:PRECIO1 * :CANTIDADSINPROMO))/:CANTIDAD;
                    
                IF( :PRECIOBUFFER < :PRECIOACTUAL) THEN
                BEGIN
                   PRECIOACTUAL = :PRECIOBUFFER;
                   ESPROMOCION = 'S';
                   PROMOCIONID = :PROMOCIONIDBUFFER;
                   PROMOCIONDESGLOSE = 'CON PRECIO ' || CAST(PRECIOBUFFERPROMO AS VARCHAR(10))
                                     || ' ' || CAST(:CANTIDADCONPROMO AS VARCHAR(10))
                                     || ' Y CON PRECIO ' ||  CAST(:PRECIO1 AS VARCHAR(10))
                                     || ' ' || CAST(:CANTIDADSINPROMO AS VARCHAR(10));  
                   MONEDEROABONO = 0;
                END

            END
        END 
        ELSE IF (:TIPOPROMOCIONID = 3) THEN
        BEGIN
                PRECIOBUFFER =  (:PRECIO1 * :CANTIDAD * (1 - (COALESCE(:PORCPROMO,0)/100)))/:CANTIDAD;
                IF( :PRECIOBUFFER < :PRECIOACTUAL) THEN
                BEGIN
                    IF(COALESCE(:ENMONEDERO,'N') <> 'S' ) THEN
                    BEGIN

                        PRECIOACTUAL = :PRECIOBUFFER;
                        ESPROMOCION = 'S';
                        PROMOCIONID = :PROMOCIONIDBUFFER;
                        PROMOCIONDESGLOSE = 'GRATIS ' || CAST(:CANTIDADCONPROMO AS VARCHAR(10))
                                     || ' Y CON PRECIO ' ||  CAST(:PRECIO1 AS VARCHAR(10))
                                     || ' ' || CAST(:CANTIDADSINPROMO AS VARCHAR(10));
                        MONEDEROABONO = 0;
                   END
                   ELSE
                   BEGIN

                        MONEDEROABONO =   (:PRECIO1 - :PRECIOBUFFER)*:CANTIDAD;
                        ESPROMOCION = 'S';
                        PROMOCIONID = :PROMOCIONIDBUFFER;     
                        --INSERT INTO TRAZA(VALOR) VALUES (CAST(:PRECIOBUFFER AS VARCHAR(10)));
                        PROMOCIONDESGLOSE = 'APLICADO A MONEDERO ' || CAST(:MONEDEROABONO AS VARCHAR(10)) ;
                   END
                END
                    
        END
        
   END



  
    PRECIOPROMO = PRECIOACTUAL;




   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1051;
      SUSPEND;
   END 
END