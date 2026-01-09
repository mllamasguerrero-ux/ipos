create or alter procedure PRECIOSTEMP_APLICAR
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable PRODUCTOID D_FK;
declare variable PRECIO1 numeric(18,4);
declare variable PRECIO2 numeric(18,4);
declare variable PRECIO3 numeric(18,4);
declare variable PRECIO4 numeric(18,4);
declare variable PRECIO5 numeric(18,4);
declare variable SUGERIDO numeric(18,4);
declare variable TASAIVA numeric(18,4);
declare variable TASAIEPS numeric(18,4);
declare variable DESGLOSEIEPS D_BOOLCN;
BEGIN

   ERRORCODE = 0;

   SELECT FIRST 1 DESGLOSEIEPS FROM PARAMETRO INTO :DESGLOSEIEPS;


  FOR SELECT PRECIOSTEMP.PRODUCTOID, PRECIOSTEMP.PRECIO1 , PRECIOSTEMP.PRECIO2, PRECIOSTEMP.PRECIO3, PRECIOSTEMP.PRECIO4, PRECIOSTEMP.PRECIO5, PRECIOSTEMP.SUGERIDO, PRODUCTO.TASAIVA, PRODUCTO.TASAIEPS
      FROM PRECIOSTEMP
      LEFT JOIN PRODUCTO ON PRECIOSTEMP.productoid = PRODUCTO.ID
    INTO :PRODUCTOID, :PRECIO1 , :PRECIO2, :PRECIO3, :PRECIO4, :PRECIO5, :SUGERIDO , :TASAIVA, :TASAIEPS
    DO
    BEGIN

        UPDATE PRODUCTO SET
            PRECIO1 = CASE WHEN :DESGLOSEIEPS = 'S' then
                                   round( :PRECIO1 / ( (1 + ( COALESCE(:TASAIEPS,0) /100)) * (1 + ( COALESCE(:TASAIVA,0) /100)) )  , 2 )
                       ELSE
                                   round( :PRECIO1 / (  (1 + ( COALESCE(:TASAIVA,0) /100)) )  , 2 )
                       END ,    
            PRECIO2 = CASE WHEN :DESGLOSEIEPS = 'S' then
                                   round( :PRECIO2 / ( (1 + ( COALESCE(:TASAIEPS,0) /100)) * (1 + ( COALESCE(:TASAIVA,0) /100)) )   , 2 )
                       ELSE
                                   round( :PRECIO2 / (  (1 + ( COALESCE(:TASAIVA,0) /100)) )  , 2 )
                       END ,
            PRECIO3 = CASE WHEN :DESGLOSEIEPS = 'S' then
                                   round( :PRECIO3 / ( (1 + ( COALESCE(:TASAIEPS,0) /100)) * (1 + ( COALESCE(:TASAIVA,0) /100)) )  , 2 )
                       ELSE
                                   round( :PRECIO3 / (  (1 + ( COALESCE(:TASAIVA,0) /100)) )   , 2 )
                       END ,
            PRECIO4 = CASE WHEN :DESGLOSEIEPS = 'S' then
                                   round( :PRECIO4 / ( (1 + ( COALESCE(:TASAIEPS,0) /100)) * (1 + ( COALESCE(:TASAIVA,0) /100)) )   , 2 )
                       ELSE
                                   round( :PRECIO4 / (  (1 + ( COALESCE(:TASAIVA,0) /100)) ) , 2 )
                       END ,
            PRECIO5 = CASE WHEN :DESGLOSEIEPS = 'S' then
                                   round( :PRECIO5 / ( (1 + ( COALESCE(:TASAIEPS,0) /100)) * (1 + ( COALESCE(:TASAIVA,0) /100)) )  , 2 )
                       ELSE
                                   round( :PRECIO5 / (  (1 + ( COALESCE(:TASAIVA,0) /100)) )  , 2 )
                       END ,  

            PRECIOSUGERIDO = :SUGERIDO /*CASE WHEN :DESGLOSEIEPS = 'S' then
                                   round( :SUGERIDO / ( (1 + ( COALESCE(:TASAIEPS,0) /100)) * (1 + ( COALESCE(:TASAIVA,0) /100)) )  , 2 )
                       ELSE
                                   round( :SUGERIDO / (  (1 + ( COALESCE(:TASAIVA,0) /100)) ) , 2 )
                       END */

            WHERE ID = :PRODUCTOID;

    END

    SUSPEND;


END