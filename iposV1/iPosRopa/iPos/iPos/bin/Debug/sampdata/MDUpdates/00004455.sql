create or alter procedure PLAZO_DIVIDIRPLAZOSMEZCLADOS (
    DOCTOID D_FK)
returns (
    DOCTOPLAZOORIGENID D_FK,
    ERRORCODE D_ERRORCODE)
as
declare variable HAYPLAZOSMEZCLADOS D_BOOLCN;
declare variable PLAZOXPRODUCTO D_BOOLCN;
declare variable GRUPO_PLAZOID D_FK;
declare variable GRUPO_DOCTOID D_FK;
declare variable GRUPO_MOVTOCUENTA D_FK;
declare variable MOVTOID D_FK;
declare variable PRODUCTOID D_FK;
declare variable CANTIDADINVENTARIO D_CANTIDAD;
declare variable CANTIDAD D_CANTIDAD;
declare variable ORDEN D_ORDEN;
declare variable LOTE D_LOTE;
declare variable CUENTA integer;
declare variable FECHAVENCE D_FECHAVENCE;
declare variable PRECIO D_PRECIO;
declare variable COSTO D_COSTO;
declare variable TIPODIFERENCIAINVENTARIOID D_FK;
declare variable CANTIDADDEFACTURA D_CANTIDAD;
declare variable CANTIDADDEREMISION D_CANTIDAD;
declare variable CANTIDADDEINDEFINIDO D_CANTIDAD;
declare variable NEWMOVTOID D_FK;
declare variable ALMACENID D_FK;
declare variable SUCURSALID D_FK;
declare variable PERSONAID D_FK;
declare variable TIPODOCTOID D_FK;
declare variable CANTIDADSUMARIZADA D_CANTIDAD;
declare variable CANTIDADRESTANTE D_CANTIDAD;
declare variable CANTIDADASIGNAR D_CANTIDAD;
declare variable REFERENCIA D_REFERENCIA;
declare variable REFERENCIAS varchar(255);
declare variable EXISTENCIA D_CANTIDAD;
declare variable DESCRIPCION1 D_STDTEXT_64;
declare variable DESCRIPCION2 D_STDTEXT_64;
declare variable DESCRIPCION3 D_STDTEXT_64;
declare variable LOTEIMPORTADO D_FK;
declare variable ALMACENTID D_FK;
declare variable SUCURSALTID D_FK;
declare variable ESTATUSDOCTOID D_FK;
declare variable VENDEDORID D_FK;
declare variable DIASPLAZO D_DIAS;
declare variable VENCE D_FECHA;
declare variable FECHA D_FECHA;
declare variable ORIGENFISCALID D_FK;
declare variable CAJAID D_FK;


declare variable PAGOCONTARJETA  D_BOOLCN_NULL;
declare variable COMISIONPAGOTARJETA D_PORCENTAJE;
declare variable PAGOACREDITO  D_BOOLCN_NULL;

BEGIN

    ERRORCODE = 0;
    HAYPLAZOSMEZCLADOS = 'N';
    PLAZOXPRODUCTO = 'N';
    doctoplazoorigenid = NULL;

    SELECT PLAZOXPRODUCTO FROM PARAMETRO INTO :PLAZOXPRODUCTO;

    IF(COALESCE(:PLAZOXPRODUCTO,'N') = 'N') THEN
    BEGIN
    
        HAYPLAZOSMEZCLADOS = 'N';
        ERRORCODE = 0;
        SUSPEND;
        EXIT;
    END


    SELECT HAYPLAZOSMEZCLADOS FROM PLAZO_HAYPLAZOSMEZCLADOS (:DOCTOID ) INTO :HAYPLAZOSMEZCLADOS;

       
    IF(COALESCE(:HAYPLAZOSMEZCLADOS,'N') = 'N') THEN
    BEGIN

        ERRORCODE = 0;
        SUSPEND;
        EXIT;
    END



    
    SELECT  ALMACENID, SUCURSALID, TIPODOCTOID, PERSONAID , REFERENCIA, REFERENCIAS ,
            ALMACENTID, SUCURSALTID  , ESTATUSDOCTOID, VENDEDORID , FECHA, ORIGENFISCALID , CAJAID , PAGOCONTARJETA  , COMISIONPAGOTARJETA , PAGOACREDITO
    from DOCTO
    where id = :doctoid
    INTO :ALMACENID, :SUCURSALID, :TIPODOCTOID, :PERSONAID, :REFERENCIA, :REFERENCIAS,
            :ALMACENTID, :SUCURSALTID, :ESTATUSDOCTOID, :VENDEDORID, :FECHA, :ORIGENFISCALID, :CAJAID, :PAGOCONTARJETA  , :COMISIONPAGOTARJETA , :PAGOACREDITO  ;


    IF(COALESCE(:TIPODOCTOID,0) not in (21, 31) ) THEN
    BEGIN
         
        ERRORCODE = 5019;
        SUSPEND;
        EXIT;
    END

    
    IF(COALESCE(:ESTATUSDOCTOID,0) <> 0 ) THEN
    BEGIN
         
        ERRORCODE = 5020;
        SUSPEND;
        EXIT;
    END

    




    FOR SELECT COALESCE(PRODUCTO.plazoid,0) GRUPO_PLAZOID FROM DOCTO
     INNER JOIN MOVTO ON DOCTO.ID = MOVTO.DOCTOID
     INNER JOIN PRODUCTO ON MOVTO.PRODUCTOID = PRODUCTO.ID
     WHERE DOCTO.ID = :DOCTOID
     GROUP BY  COALESCE(PRODUCTO.plazoid,0)
     INTO :GRUPO_PLAZOID
    DO
    BEGIN



       GRUPO_DOCTOID = NULL;
       GRUPO_MOVTOCUENTA = 0;


       
        --CALCULAR PLAZO POR DIA
        SELECT PLAZO.dias FROM PLAZO WHERE ID =  COALESCE(:GRUPO_PLAZOID,0) INTO :DIASPLAZO;

        IF(COALESCE(:DIASPLAZO,0) = 0) THEN
        BEGIN
            SELECT PERSONA.dias FROM PERSONA WHERE ID = :PERSONAID INTO :DIASPLAZO;
        END

        IF(COALESCE(:DIASPLAZO,0) = 0) THEN
        BEGIN
          DIASPLAZO = 0;
        END

        VENCE = dateadd( :DIASPLAZO day to CURRENT_DATE );

    
        FOR SELECT
            M.ID, M.PRODUCTOID, M.LOTE, M.FECHAVENCE, M.CANTIDAD, M.PRECIO, M.COSTO,
            M.TIPODIFERENCIAINVENTARIOID  , M.CANTIDADDEFACTURA, M.CANTIDADDEREMISION, M.CANTIDADDEINDEFINIDO , M.DESCRIPCION1, M.DESCRIPCION2, M.DESCRIPCION3,M.LOTEIMPORTADO
            FROM MOVTO M
                inner join PRODUCTO P ON M.PRODUCTOID = P.ID
            WHERE M.DOCTOID = :DOCTOID AND COALESCE(P.plazoid ,0) = COALESCE(:GRUPO_PLAZOID,0)
            INTO
            :MOVTOID, :PRODUCTOID, :LOTE, :FECHAVENCE, :CANTIDAD, :PRECIO, :COSTO,
            :TIPODIFERENCIAINVENTARIOID , :CANTIDADDEFACTURA, :CANTIDADDEREMISION, :CANTIDADDEINDEFINIDO , :DESCRIPCION1, :DESCRIPCION2, :DESCRIPCION3 , :LOTEIMPORTADO
            DO
            BEGIN



                IF(/*:GRUPO_MOVTOCUENTA = 0*/ COALESCE(:GRUPO_DOCTOID,0) = 0) THEN
                BEGIN


                      
                    SELECT DOCTOID, ERRORCODE
                    FROM DOCTO_INSERT (
                        :VENDEDORID,
                        :ALMACENID,
                        :SUCURSALID,
                        :TIPODOCTOID,
                        :ESTATUSDOCTOID,
                        0,
                        :PERSONAID,
                        :VENDEDORID,
                        :CAJAID,
                        :REFERENCIA,
                        '',
                        :SUCURSALTID,
                        :ALMACENTID,
                        CURRENT_DATE,
                        :VENCE,
                        NULL ,
                        'S' ,
                        :ORIGENFISCALID
                     ) INTO :GRUPO_DOCTOID, :ERRORCODE;

      
                    IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
                    BEGIN
                        SUSPEND;
                        EXIT;
                    END

                       -- SE TOMA COMO ORIGEN EL PRIMER DOCTO CREADO
                      IF(COALESCE(:doctoplazoorigenid,0) = 0) then
                      BEGIN
                        DOCTOPLAZOORIGENID = :GRUPO_DOCTOID;
                      END

                      UPDATE DOCTO
                      SET  plazo = :DIASPLAZO,
                            doctoplazoorigenid = :DOCTOPLAZOORIGENID,
                            PAGOCONTARJETA  = :PAGOCONTARJETA ,
                            COMISIONPAGOTARJETA = :COMISIONPAGOTARJETA ,
                            PAGOACREDITO = :PAGOACREDITO
                        WHERE ID = :GRUPO_DOCTOID;
                END



                DELETE FROM MOVTO WHERE ID = :MOVTOID ;
         
                SELECT ERRORCODE,DOCTOID
                FROM MOVTO_INSERT (
                :GRUPO_DOCTOID, 0, :ALMACENID, :SUCURSALID, :TIPODOCTOID, 0, 0, :PERSONAID, :VENDEDORID, 1,
                0, :PRODUCTOID, :LOTE, :FECHAVENCE, :CANTIDAD, 0, 0, 0, 0, :PRECIO, 0,
                :REFERENCIA, :REFERENCIAS, :COSTO, :SUCURSALTID, :ALMACENTID, 'N',
                :TIPODIFERENCIAINVENTARIOID, CURRENT_DATE, :VENCE, 0.00 ,NULL,NULL,NULL,NULL,NULL , :DESCRIPCION1, :DESCRIPCION2, :DESCRIPCION3 , NULL  , :LOTEIMPORTADO
                ) INTO :ERRORCODE,:GRUPO_DOCTOID;

                     
                if(:errorcode <> 0) then
                begin
                 suspend;
                 exit;
                end



             GRUPO_MOVTOCUENTA = :GRUPO_MOVTOCUENTA + 1;

          END

    END




    SELECT ERRORCODE FROM DOCTO_DELETE(:DOCTOID) INTO :ERRORCODE;

    if(:errorcode <> 0) then
    begin
                 suspend;
                 exit;
    end


   

   ERRORCODE = 0;
   SUSPEND;
   
  /* WHEN ANY DO
   BEGIN
     ERRORCODE = 1076;
     SUSPEND;
   END */

END