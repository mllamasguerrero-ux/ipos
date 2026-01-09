create or alter procedure MOVTO_INSERT_AGRUPADO (
    DOCTOID D_FK,
    TIPODOCTOID D_FK,
    COSTO D_COSTO,
    LOTE D_LOTE,
    LOTEIMPORTADO D_FK,
    PRODUCTOID D_FK,
    FECHAVENCE D_FECHAVENCE,
    PRECIO D_PRECIO,
    PORCENTAJEDESCUENTO D_PORCENTAJE,
    P_MOVTOREFID D_FK,
    ANAQUELID D_FK,
    LOCALIDAD D_LOCACION)
returns (
    MOVTOACTUALID D_FK,
    MOVTOREFID D_FK,
    PRECIO_RET D_PRECIO,
    COSTO_RET D_COSTO,
    LOTE_RET D_LOTE,
    FECHAVENCE_RET D_FECHAVENCE,
    LOTEIMPORTADO_RET D_FK)
as
begin
  /* Procedure Text */


  -- COMPRAS
        IF (:TIPODOCTOID in (11,16,17)) THEN
        BEGIN       
               IF(:COSTO IS NOT NULL) THEN
               BEGIN
                    SELECT FIRST 1 ID FROM MOVTO
                    WHERE DOCTOID = :DOCTOID AND PRODUCTOID = :PRODUCTOID
                    AND COSTO = :COSTO --ORDER BY COSTO DESC
                    AND (COALESCE(:LOTE,'') = '' OR  (COALESCE(:LOTE,'') = LOTE AND FECHAVENCE = :FECHAVENCE ))
                    AND (COALESCE(:LOTEIMPORTADO,0) = COALESCE(LOTEIMPORTADO,0))
                    INTO :MOVTOACTUALID;
               END
               ELSE
               BEGIN    
                    SELECT FIRST 1 ID, COSTO FROM MOVTO
                    WHERE DOCTOID = :DOCTOID AND PRODUCTOID = :PRODUCTOID
                    AND (COALESCE(:LOTE,'') = '' OR  (COALESCE(:LOTE,'') = LOTE AND FECHAVENCE = :FECHAVENCE )) 
                    AND (COALESCE(:LOTEIMPORTADO,0) = COALESCE(LOTEIMPORTADO,0))
                    ORDER BY COSTO
                    INTO :MOVTOACTUALID, :COSTO;
               END
        END
        -- VENTAS Y VENTAS DE APARTADO
        ELSE if (:TIPODOCTOID IN (21,25,23, 321, 323, 31, 331,821, 823)) then
        BEGIN
               IF(:PRECIO IS NOT NULL) THEN
               BEGIN
                    SELECT FIRST 1 ID FROM MOVTO
                    WHERE DOCTOID = :DOCTOID AND PRODUCTOID = :PRODUCTOID
                    AND PRECIO = :PRECIO
                    AND (COALESCE(:LOTE,'') = '' OR  (COALESCE(:LOTE,'') = LOTE AND FECHAVENCE = :FECHAVENCE )) 
                    AND (COALESCE(:LOTEIMPORTADO,0) = COALESCE(LOTEIMPORTADO,0))
                    --AND  MOVTOADJUNTOAID IS NULL
                    INTO :MOVTOACTUALID;
               END
               ELSE
               BEGIN   
                    SELECT FIRST 1 ID, PRECIO FROM MOVTO
                    WHERE DOCTOID = :DOCTOID AND PRODUCTOID = :PRODUCTOID  
                    AND (COALESCE(:LOTE,'') = '' OR  (COALESCE(:LOTE,'') = LOTE AND FECHAVENCE = :FECHAVENCE )) 
                    AND (COALESCE(:LOTEIMPORTADO,0) = COALESCE(LOTEIMPORTADO,0))
                    AND (COALESCE(DESCUENTOPORCENTAJE,0) = COALESCE(:PORCENTAJEDESCUENTO,0) or :PORCENTAJEDESCUENTO is null)
                    --AND  MOVTOADJUNTOAID IS NULL
                    ORDER BY PRECIO DESC
                    INTO :MOVTOACTUALID, :PRECIO;
               END
        END   
        -- DEVOLUCION DE VENTA
        ELSE if (:TIPODOCTOID IN (22)) then
        BEGIN
               IF(COALESCE(:P_MOVTOREFID,0) <> 0) THEN
               BEGIN
                    MOVTOREFID = :P_MOVTOREFID;
                    select lote, fechavence, LOTEIMPORTADO from movto where id = :p_movtorefid into :lote, :fechavence, :LOTEIMPORTADO;
               END

               IF(:PRECIO IS NOT NULL) THEN
               BEGIN
                    SELECT FIRST 1 ID FROM MOVTO
                    WHERE DOCTOID = :DOCTOID AND PRODUCTOID = :PRODUCTOID
                    AND PRECIO = :PRECIO
                    AND (:P_MOVTOREFID IS NULL or MOVTOREFID = :P_MOVTOREFID)
                    AND (COALESCE(:LOTE,'') = '' OR  (COALESCE(:LOTE,'') = LOTE AND FECHAVENCE = :FECHAVENCE )) 
                    AND (COALESCE(:LOTEIMPORTADO,0) = COALESCE(LOTEIMPORTADO,0))
                    INTO :MOVTOACTUALID;

               END
               ELSE
               BEGIN
                    SELECT FIRST 1 ID, PRECIO FROM MOVTO
                    WHERE DOCTOID = :DOCTOID AND PRODUCTOID = :PRODUCTOID
                    AND (:P_MOVTOREFID IS NULL or MOVTOREFID = :P_MOVTOREFID)
                    AND (COALESCE(:LOTE,'') = '' OR  (COALESCE(:LOTE,'') = LOTE AND FECHAVENCE = :FECHAVENCE ))
                    AND (COALESCE(:LOTEIMPORTADO,0) = COALESCE(LOTEIMPORTADO,0))
                    ORDER BY  PRECIO
                    INTO :MOVTOACTUALID, :PRECIO;
               END
        END  
        -- DEVOLUCION DE COMPRA
        ELSE if (:TIPODOCTOID IN (12)) then
        BEGIN
               IF(COALESCE(:P_MOVTOREFID,0) <> 0) THEN
               BEGIN
                    MOVTOREFID = :P_MOVTOREFID; 
                    select lote, fechavence, LOTEIMPORTADO from movto where id = :p_movtorefid into :lote, :fechavence, :LOTEIMPORTADO;
              
               END

               IF(:COSTO IS NOT NULL) THEN
               BEGIN
                    SELECT FIRST 1 ID FROM MOVTO
                    WHERE DOCTOID = :DOCTOID AND PRODUCTOID = :PRODUCTOID
                    AND COSTO= :COSTO
                    AND (:P_MOVTOREFID IS NULL or MOVTOREFID = :P_MOVTOREFID)
                    AND (COALESCE(:LOTE,'') = '' OR  (COALESCE(:LOTE,'') = LOTE AND FECHAVENCE = :FECHAVENCE )) 
                    AND (COALESCE(:LOTEIMPORTADO,0) = COALESCE(LOTEIMPORTADO,0))
                    INTO :MOVTOACTUALID;

               END
               ELSE
               BEGIN   
                    SELECT FIRST 1 ID, PRECIO FROM MOVTO
                    WHERE DOCTOID = :DOCTOID AND PRODUCTOID = :PRODUCTOID
                    AND (:P_MOVTOREFID IS NULL or MOVTOREFID = :P_MOVTOREFID)
                    AND (COALESCE(:LOTE,'') = '' OR  (COALESCE(:LOTE,'') = LOTE AND FECHAVENCE = :FECHAVENCE )) 
                    AND (COALESCE(:LOTEIMPORTADO,0) = COALESCE(LOTEIMPORTADO,0))
                    ORDER BY  COSTO DESC
                    INTO :MOVTOACTUALID, :PRECIO;
               END
        END  
        ELSE if (:TIPODOCTOID IN (53)) then
        BEGIN   
            SELECT FIRST 1 COALESCE(ID, 0)
            FROM MOVTO
            WHERE DOCTOID = :DOCTOID
            AND PRODUCTOID = :PRODUCTOID
            AND COALESCE(ANAQUELID,0) = COALESCE(:ANAQUELID,0)
            AND COALESCE(LOCALIDAD,'') = COALESCE(:LOCALIDAD,'')
            INTO :MOVTOACTUALID;
        END  
        ELSE if (:TIPODOCTOID IN (81)) then
        BEGIN 
                SELECT COALESCE(ID, 0) FROM MOVTO
                WHERE DOCTOID = :DOCTOID AND PRODUCTOID = :PRODUCTOID
                AND (COALESCE(:LOTE,'') = '' OR  (COALESCE(:LOTE,'') = LOTE  
                    AND (COALESCE(:LOTEIMPORTADO,0) = COALESCE(LOTEIMPORTADO,0))
                AND FECHAVENCE = :FECHAVENCE ))
                INTO :MOVTOACTUALID;


        END
        ELSE if (:TIPODOCTOID IN (50,51,52,54,55)) then
        BEGIN 
                SELECT FIRST 1 COALESCE(ID, 0) FROM MOVTO
                WHERE DOCTOID = :DOCTOID AND PRODUCTOID = :PRODUCTOID
                AND (COALESCE(:LOTE,'') = '' OR  (COALESCE(:LOTE,'') = LOTE 
                AND (COALESCE(:LOTEIMPORTADO,0) = COALESCE(LOTEIMPORTADO,0))
                AND FECHAVENCE = :FECHAVENCE ))
                INTO :MOVTOACTUALID;


        END
        ELSE if (:TIPODOCTOID IN (505)) then
        BEGIN 
               MOVTOACTUALID = NULL;
        END
        ELSE IF (:TIPODOCTOID in ( 111)) THEN    -- OTRAS ENTRADAS
        BEGIN       
               IF(:COSTO IS NOT NULL) THEN
               BEGIN
                    SELECT FIRST 1 ID FROM MOVTO
                    WHERE DOCTOID = :DOCTOID AND PRODUCTOID = :PRODUCTOID
                    AND COSTO = :COSTO --ORDER BY COSTO DESC
                    AND (COALESCE(:LOTE,'') = '' OR  (COALESCE(:LOTE,'') = LOTE AND FECHAVENCE = :FECHAVENCE )) 
                    AND (COALESCE(:LOTEIMPORTADO,0) = COALESCE(LOTEIMPORTADO,0))
                    INTO :MOVTOACTUALID;
               END
               ELSE
               BEGIN    
                    SELECT FIRST 1 ID, COSTO FROM MOVTO
                    WHERE DOCTOID = :DOCTOID AND PRODUCTOID = :PRODUCTOID
                    AND (COALESCE(:LOTE,'') = '' OR  (COALESCE(:LOTE,'') = LOTE AND FECHAVENCE = :FECHAVENCE ))
                    AND (COALESCE(:LOTEIMPORTADO,0) = COALESCE(LOTEIMPORTADO,0))
                    ORDER BY COSTO
                    INTO :MOVTOACTUALID, :COSTO;
               END
        END 
        ELSE IF (:TIPODOCTOID in ( 121, 901,902)) THEN    -- OTRAS SALIDAS
        BEGIN       
               IF(:PRECIO IS NOT NULL) THEN
               BEGIN
                    SELECT FIRST 1 ID FROM MOVTO
                    WHERE DOCTOID = :DOCTOID AND PRODUCTOID = :PRODUCTOID
                    AND PRECIO = :PRECIO --ORDER BY COSTO DESC
                    AND (COALESCE(:LOTE,'') = '' OR  (COALESCE(:LOTE,'') = LOTE AND FECHAVENCE = :FECHAVENCE ))
                    AND (COALESCE(:LOTEIMPORTADO,0) = COALESCE(LOTEIMPORTADO,0))
                    INTO :MOVTOACTUALID;

               END
               ELSE
               BEGIN    
                    SELECT FIRST 1 ID, PRECIO FROM MOVTO
                    WHERE DOCTOID = :DOCTOID AND PRODUCTOID = :PRODUCTOID
                    AND (COALESCE(:LOTE,'') = '' OR  (COALESCE(:LOTE,'') = LOTE AND FECHAVENCE = :FECHAVENCE ))
                    AND (COALESCE(:LOTEIMPORTADO,0) = COALESCE(LOTEIMPORTADO,0))
                    ORDER BY COSTO
                    INTO :MOVTOACTUALID, :PRECIO;

               END
        END
        ELSE
        BEGIN     
            SELECT FIRST 1 COALESCE(ID, 0)
            FROM MOVTO
            WHERE DOCTOID = :DOCTOID
            AND PRODUCTOID = :PRODUCTOID
            and coalesce(lote,'') = COALESCE(:lote, '')
            AND (COALESCE(:LOTEIMPORTADO,0) = COALESCE(LOTEIMPORTADO,0))
            --AND  MOVTOADJUNTOAID IS NULL
            INTO :MOVTOACTUALID;
        END

       PRECIO_RET = :PRECIO;
       COSTO_RET = :COSTO;

       LOTE_RET = :LOTE;
       FECHAVENCE_RET = :fechavence;
       LOTEIMPORTADO_RET = :LOTEIMPORTADO;

  suspend;
end