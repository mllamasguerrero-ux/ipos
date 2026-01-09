create or alter procedure APLICAR_DESCUENTO_VALE (
    DOCTOID D_PK,
    NUMEROVALE D_DESCRIPCION)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable MOVTOID D_FK;
declare variable DESCUENTOVALE D_PORCENTAJE;
declare variable IMPORTE D_PRECIO;
declare variable SUBTOTAL D_PRECIO;
declare variable IVA D_PRECIO;
declare variable TOTAL D_PRECIO;
declare variable LISTAPRECIOCLIENTE varchar(1);
BEGIN
   -- Tambien al actualizar otro campo que no es totales, este total va a ser cero.
   -- por ejemplo al actualizar estatus.

      SELECT FIRST 1 COALESCE(DESCUENTOVALE,0)
      FROM PARAMETRO
      INTO :DESCUENTOVALE ;

      IF(:DESCUENTOVALE = 0 ) THEN
      BEGIN
         ERRORCODE = 0;
         SUSPEND;
      END


            
   SELECT CAST(COALESCE(c.LISTAPRECIOID, 1) AS CHAR(1))
   FROM   docto d
      LEFT JOIN persona c on d.personaid = c.id
   WHERE d.ID = :DOCTOID
   INTO :LISTAPRECIOCLIENTE;


   
   IF (:LISTAPRECIOCLIENTE = '1'  ) THEN
   BEGIN


      UPDATE MOVTO
      SET
        PRECIO    = ROUND((MOVTO.PRECIO * ((100 - :DESCUENTOVALE)/100)),2),
        DESCUENTO = MOVTO.PRECIOLISTA - ROUND((MOVTO.PRECIO * ((100 - :DESCUENTOVALE)/100)),2), --PRECIO LISTA - PRECIONUEVO
        SUBTOTAL =  ROUND( ROUND((MOVTO.PRECIO * ((100 - :DESCUENTOVALE)/100)),2) * MOVTO.CANTIDAD , 2) ,    --PRECIONUEVO * CANTIDAD
        IVA      =  ((ROUND( ROUND((MOVTO.PRECIO * ((100 - :DESCUENTOVALE)/100)),2) * MOVTO.CANTIDAD , 2)) * (COALESCE (MOVTO.tasaiva,0)/100)) ,  --SUBTOTAL * TASAIVA
        TOTAL    = (ROUND( ROUND((MOVTO.PRECIO * ((100 - :DESCUENTOVALE)/100)),2) * MOVTO.CANTIDAD , 2))     +       ((ROUND( ROUND((MOVTO.PRECIO * ((100 - :DESCUENTOVALE)/100)),2) * MOVTO.CANTIDAD , 2)) * (COALESCE (MOVTO.tasaiva,0)/100)), -- SUBTOTAL + IVA
        DESCUENTOPORCENTAJE = COALESCE(MOVTO.DESCUENTOPORCENTAJE,0) + :DESCUENTOVALE,
        DESCUENTOVALEPORCENTAJE = :DESCUENTOVALE ,
        DESCUENTOVALE =  ROUND(  ((:DESCUENTOVALE)/100) *  ((ROUND( ROUND((MOVTO.PRECIO),2) * MOVTO.CANTIDAD , 2))     +       ((ROUND( ROUND((MOVTO.PRECIO),2) * MOVTO.CANTIDAD , 2)) * (COALESCE (MOVTO.tasaiva,0)/100))) ,2 )

       WHERE ID in ( SELECT
                        M.id
                        FROM MOVTO M
                        INNER JOIN PRODUCTO P
                        ON P.ID = M.PRODUCTOID
                        WHERE  M.DOCTOID = :DOCTOID
                        AND P.tipoabc = 'S' AND M.ingresopreciomanual = 'N'
                        AND ( not ( coalesce(P.pzacaja,0)>1 AND coalesce(m.CANTIDAD,0)>= COALESCE(P.U_EMPAQUE,0) AND COALESCE(P.U_EMPAQUE,0)>1))
                        AND ( NOT ( coalesce(P.pzacaja,0)>1  AND coalesce(m.CANTIDAD,0)>= coalesce(P.pzacaja,0)  ) )
                        AND ( NOT  ( trim(P.UNIDAD) = 'KG'  AND coalesce(m.CANTIDAD,0)>= COALESCE(P.INI_MAYO,0) AND P.MAYOKGS = 'S') )

                        );



        update docto set referencias =:NUMEROVALE where id = :DOCTOID;

    END

   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1011;
      SUSPEND;
   END
END