create or alter procedure VALIDAR_PRECIOS_DOCTO (
    DOCTOID D_FK,
    VENDEDORID D_FK)
returns (
    MOVTOIDSNOVALIDOS D_MEMO,
    VALIDO D_BOOLCS,
    ERRORCODE D_ERRORCODE)
as
declare variable TIENEDERECHO D_BOOLCN;
declare variable PRODUCTOID D_FK;
declare variable PRECIO D_PRECIO;
declare variable PRECIOSTD D_PRECIO;
declare variable COSTOREPOSICION D_COSTO;
declare variable TIPODOCTOID D_FK;
declare variable SUBTIPODOCTOID D_FK;
declare variable PERSONAID D_FK;
declare variable CANTIDAD D_CANTIDAD;
declare variable SUCURSALID D_FK;
declare variable COSTOPROMEDIO D_COSTO;
declare variable MOVTOID D_FK;
declare variable INVALIDCOUNT integer;
declare variable PAGOCONTARJETA D_CHAR;
declare variable TIPOMAYOREOID D_FK;
declare variable PAGOACREDITO D_BOOLCN_NULL;
BEGIN


        INVALIDCOUNT = 0;
        MOVTOIDSNOVALIDOS = '';
        VALIDO = 'S';
        ERRORCODE = 0;

        SELECT FIRST 1 PARAMETRO.sucursalid FROM PARAMETRO INTO :SUCURSALID;


        -- Agrega los MOVTO.
        FOR SELECT
            MOVTO.ID, MOVTO.PRODUCTOID, MOVTO.CANTIDAD,
            MOVTO.PRECIO,
            COALESCE(MOVTO.costopromedio, PRODUCTO.costopromedio),
            COALESCE(MOVTO.costoreposicion,PRODUCTO.costoreposicion),
            DOCTO.tipodoctoid, DOCTO.SUBTIPODOCTOID , docto.PAGOCONTARJETA, docto.TIPOMAYOREOID , docto.PAGOACREDITO
            FROM MOVTO LEFT JOIN PRODUCTO ON PRODUCTO.ID = MOVTO.PRODUCTOID
            LEFT JOIN DOCTO ON DOCTO.ID = MOVTO.DOCTOID
            WHERE DOCTOID = :DOCTOID  AND DOCTO.estatusdoctoid = 0
            INTO
            :MOVTOID, :PRODUCTOID, :CANTIDAD, :PRECIO, :COSTOPROMEDIO, :COSTOREPOSICION,
            :TIPODOCTOID, :SUBTIPODOCTOID , :PAGOCONTARJETA, :TIPOMAYOREOID , :PAGOACREDITO
        DO
        BEGIN

            SELECT PRECIO, ERRORCODE FROM GET_PRODUCTO_PRECIO_DOCTO (
                :PRODUCTOID ,
                :PERSONAID ,
                :CANTIDAD ,
                :TIPODOCTOID ,
                :SUCURSALID,
                NULL,
                :COSTOPROMEDIO, :PAGOCONTARJETA, :TIPOMAYOREOID, :PAGOACREDITO) INTO :PRECIOSTD, :ERRORCODE;

            IF(COALESCE(:PRECIOSTD,0) <> COALESCE(:PRECIO,0)) THEN
            BEGIN
                  
                 SELECT ERRORCODE
                 FROM VALIDAR_PRECIO(:PRODUCTOID, :PRECIO, :PRECIOSTD, :COSTOREPOSICION, :VENDEDORID, :TIPODOCTOID, :SUBTIPODOCTOID)
                 INTO :ERRORCODE;

                 IF (:ERRORCODE <> 0) THEN
                 BEGIN
                       VALIDO = 'N' ;
                       IF(INVALIDCOUNT > 0 ) THEN
                       BEGIN
                            MOVTOIDSNOVALIDOS = :MOVTOIDSNOVALIDOS || '|';
                       END
                        MOVTOIDSNOVALIDOS = :MOVTOIDSNOVALIDOS || CAST(:MOVTOID AS VARCHAR(30));

                       INVALIDCOUNT = :INVALIDCOUNT + 1;
                 END

            END

                                         /*
            
                       IF(INVALIDCOUNT > 0 ) THEN
                       BEGIN
                            MOVTOIDSNOVALIDOS = :MOVTOIDSNOVALIDOS || '|';
                       END
                        MOVTOIDSNOVALIDOS = :MOVTOIDSNOVALIDOS || CAST(:MOVTOID AS VARCHAR(30));

                       INVALIDCOUNT = :INVALIDCOUNT + 1;
                          */



        END








   ERRORCODE = 0;

   SUSPEND;
   
   /*WHEN ANY DO
   BEGIN
      ERRORCODE = 1063;
      SUSPEND;
   END */
END