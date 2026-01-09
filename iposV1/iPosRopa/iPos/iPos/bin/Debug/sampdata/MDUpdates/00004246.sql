create or alter procedure ASIGNARLOTE_SURTIRPEDIDO (
    DOCTOID D_FK)
returns (
    ERRORCODE D_ERRORCODE)
as
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
BEGIN

    ERRORCODE = 0;

    SELECT  ALMACENID, SUCURSALID, TIPODOCTOID, PERSONAID , REFERENCIA, REFERENCIAS
    from DOCTO
    where id = :doctoid
    INTO :ALMACENID, :SUCURSALID, :TIPODOCTOID, :PERSONAID, :REFERENCIA, :REFERENCIAS;



   FOR SELECT
      M.ID, M.PRODUCTOID, /*M.LOTE, M.FECHAVENCE,*/ M.CANTIDAD, M.PRECIO, M.COSTO,
      M.TIPODIFERENCIAINVENTARIOID  , M.CANTIDADDEFACTURA, M.CANTIDADDEREMISION, M.CANTIDADDEINDEFINIDO , M.DESCRIPCION1, M.DESCRIPCION2, M.DESCRIPCION3,M.LOTEIMPORTADO
   FROM MOVTO M
    inner join PRODUCTO P ON M.PRODUCTOID = P.ID
   WHERE M.DOCTOID = :DOCTOID AND P.MANEJALOTE = 'S'
   INTO
      :MOVTOID, :PRODUCTOID, /*:LOTE, :FECHAVENCE,*/ :CANTIDAD, :PRECIO, :COSTO,
      :TIPODIFERENCIAINVENTARIOID , :CANTIDADDEFACTURA, :CANTIDADDEREMISION, :CANTIDADDEINDEFINIDO , :DESCRIPCION1, :DESCRIPCION2, :DESCRIPCION3 , :LOTEIMPORTADO
   DO
   BEGIN


        CUENTA = 0;
        CANTIDADSUMARIZADA = 0;
        CANTIDADRESTANTE = :CANTIDAD;
        CANTIDADASIGNAR = 0;



        SELECT SUM(coalesce(CANTIDAD,0)) FROM INVENTARIO
        WHERE PRODUCTOID =:PRODUCTOID
        into :EXISTENCIA;

        IF(:EXISTENCIA < :CANTIDAD ) THEN
        begin
            ERRORCODE = 3001;
            SUSPEND;
            EXIT;

        end 



        FOR SELECT
            FECHAVENCE, LOTE, coalesce(CANTIDAD,0) , LOTEIMPORTADO
        FROM INVENTARIO
        where PRODUCTOID = :PRODUCTOID  and coalesce(cantidad,0) > 0
        order by fechavence
        INTO
            :FECHAVENCE, :LOTE, :CANTIDADINVENTARIO , :LOTEIMPORTADO
        DO
        BEGIN
                --insert into traza values(cast(:cantidad as varchar(10)));

           IF(:CANTIDADRESTANTE <= 0) THEN
           BEGIN
             BREAK;
           END

            IF( :CANTIDADINVENTARIO > :CANTIDADRESTANTE ) THEN
            BEGIN
                 CANTIDADSUMARIZADA = :CANTIDADSUMARIZADA + :CANTIDADRESTANTE;
                 CANTIDADASIGNAR = :CANTIDADRESTANTE;
                 CANTIDADRESTANTE = 0;
                 
                --insert into traza values('paso1');
            END
            ELSE
            BEGIN    
                 CANTIDADSUMARIZADA = :CANTIDADSUMARIZADA + :CANTIDADINVENTARIO;   
                 CANTIDADASIGNAR = :CANTIDADINVENTARIO;
                 CANTIDADRESTANTE = :CANTIDADRESTANTE - :CANTIDADINVENTARIO;
                 
                --insert into traza values('paso2');
            END


              IF(:CUENTA = 0) THEN
              BEGIN

                  --insert into traza values(cast(:CANTIDADASIGNAR as varchar(10)));
                  UPDATE MOVTO SET CANTIDAD = :CANTIDADASIGNAR , LOTE = :LOTE, FECHAVENCE = :FECHAVENCE, LOTEIMPORTADO = :LOTEIMPORTADO WHERE ID = :MOVTOID;
                  --insert into traza values('paso3');
                  
                  SELECT ERRORCODE
                    FROM MOVTO_INSERT (
                    :DOCTOID, 0, :ALMACENID, :SUCURSALID, :TIPODOCTOID, 0, 0, :PERSONAID, 0, 1,
                    0, :PRODUCTOID, :LOTE, :FECHAVENCE, 0, 0, 0, 0, 0, :PRECIO, 0,
                    :REFERENCIA, :REFERENCIAS, :COSTO, :SUCURSALID, :ALMACENID, 'N', 
                    :TIPODIFERENCIAINVENTARIOID, CURRENT_DATE, CURRENT_DATE, 0.00 ,NULL,NULL,NULL,:MOVTOID,NULL , :DESCRIPCION1, :DESCRIPCION2, :DESCRIPCION3  , NULL, :LOTEIMPORTADO
                ) INTO :ERRORCODE;


              END
              ELSE
              BEGIN
                SELECT ERRORCODE,MOVTOID
                FROM MOVTO_INSERT (
                :DOCTOID, 0, :ALMACENID, :SUCURSALID, :TIPODOCTOID, 0, 0, :PERSONAID, 0, 1,
                0, :PRODUCTOID, :LOTE, :FECHAVENCE, :CANTIDADASIGNAR, 0, 0, 0, 0, :PRECIO, 0,
                :REFERENCIA, :REFERENCIAS, :COSTO, :SUCURSALID, :ALMACENID, 'N', 
                :TIPODIFERENCIAINVENTARIOID, CURRENT_DATE, CURRENT_DATE, 0.00 ,NULL,NULL,NULL,NULL,NULL , :DESCRIPCION1, :DESCRIPCION2, :DESCRIPCION3 , NULL  , :LOTEIMPORTADO
                ) INTO :ERRORCODE,:NEWMOVTOID;
                     
              --  insert into traza values('paso4');

                if(:errorcode <> 0) then
                begin
                 suspend;
                 exit;
                end

                
              --  insert into traza values('paso5');


              END

              
               -- insert into traza values('paso6');

              CUENTA = :CUENTA + 1;
        END




   END


   
   ERRORCODE = 0;
   SUSPEND;
   
   /*WHEN ANY DO
   BEGIN
      ERRORCODE = 1012;
      SUSPEND;
   END  */
END