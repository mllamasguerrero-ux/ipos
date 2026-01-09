create or alter procedure SETESTADOREBAJA_COTIENRUTADA (
    MOVTOID D_FK,
    DOCTOID D_FK)
returns (
    ERRORCODE D_ERRORCODE)
as

declare variable TIPODOCTOID D_FK;
declare variable ESTATUSDOCTOID D_FK;
declare variable ALERTA3 D_STDTEXT_LARGE;

declare variable CURRENT_MOVTOID D_FK;
declare variable CUENTA_ESTADOREBAJA3 D_FK;
BEGIN

   ERRORCODE = 0;

   
    SELECT  DOCTO.TIPODOCTOID, DOCTO.estatusdoctoid
    FROM  DOCTO
    WHERE DOCTO.ID = :DOCTOID
    INTO  :TIPODOCTOID, :ESTATUSDOCTOID;

    IF(COALESCE(:TIPODOCTOID,0) <> 21 or COALESCE(:ESTATUSDOCTOID,0) <> 0) THEN
    BEGIN
        ERRORCODE = 1071;
        SUSPEND;
        EXIT;
    END

   
  FOR SELECT        MOVTO.ID MOVTOID,
                             CASE WHEN MOVTO.PRECIO > PRODUCTO.PRECIO1 AND PRODUCTO.precio1 > MOVTO.preciolista THEN 'PRECIO MAYOR A PRECIO1 Y PRECIO LISTA'
                             
                                   WHEN MOVTO.precio < (
                                       (CASE WHEN COALESCE(PARAMETRO.tipoutilidadid, 0) = 2 THEN COALESCE(PRODUCTO.costopromedio, PRODUCTO.costoreposicion) WHEN COALESCE(PARAMETRO.TIPOUTILIDADID,0) = 3  THEN COALESCE(PRODUCTO.costoultimo, PRODUCTO.costoreposicion) else PRODUCTO.costoreposicion END)
                                        ) THEN 'PRECIO MENOR AL COSTO'
                                   WHEN MOVTO.precio < (
                                            (CASE   WHEN COALESCE(PARAMETRO.LISTAPRECIOMINIMO, 0) = 1  THEN COALESCE(PRODUCTO.precio1, 0)
                                                    WHEN COALESCE(PARAMETRO.LISTAPRECIOMINIMO, 0) = 2  THEN COALESCE(PRODUCTO.PRECIO2, 0)  
                                                    WHEN COALESCE(PARAMETRO.LISTAPRECIOMINIMO, 0) = 3  THEN COALESCE(PRODUCTO.PRECIO3, 0)
                                                    WHEN COALESCE(PARAMETRO.LISTAPRECIOMINIMO, 0) = 4  THEN COALESCE(PRODUCTO.PRECIO4, 0)
                                                    WHEN COALESCE(PARAMETRO.LISTAPRECIOMINIMO, 0) = 5  THEN COALESCE(PRODUCTO.PRECIO5, 0)
                                                    WHEN COALESCE(PARAMETRO.LISTAPRECIOMINIMO, 0) = 6  THEN COALESCE(PRODUCTO.PRECIO6, 0)
                                                    else PRODUCTO.precio1 END
                                            )
                                        ) THEN 'PRECIO MENOR A PRECIO MINIMO'
                                    ELSE ''
                             END  AS ALERTA3
        FROM MOVTO  LEFT JOIN PRODUCTO ON PRODUCTO.ID = MOVTO.PRODUCTOID
        LEFT OUTER JOIN PARAMETRO ON 1 = 1
        WHERE ( MOVTO.ID = :MOVTOID or (COALESCE(:MOVTOID,0) = 0 AND MOVTO.DOCTOID = :DOCTOID) )
           INTO :CURRENT_MOVTOID, :ALERTA3
    DO
    BEGIN
               
    
          IF(COALESCE(:ALERTA3,'') IN ('PRECIO MENOR AL COSTO','PRECIO MENOR A PRECIO MINIMO' ) ) THEN
          BEGIN
                UPDATE MOVTO SET ESTADOREBAJA = 3 WHERE ID = :CURRENT_MOVTOID;
          END
          ELSE
          BEGIN         
                UPDATE MOVTO SET ESTADOREBAJA = NULL WHERE ID = :CURRENT_MOVTOID;
          END
    END


    SELECT COUNT(*) FROM MOVTO
    WHERE DOCTOID = :DOCTOID AND
    ESTADOREBAJA = 3 INTO :CUENTA_ESTADOREBAJA3;

    IF(COALESCE(:CUENTA_ESTADOREBAJA3,0) > 0) THEN
    BEGIN        
            UPDATE DOCTO SET ESTADOREBAJA = 3 WHERE ID = :DOCTOID;
    END
    ELSE
    BEGIN      
            UPDATE DOCTO SET ESTADOREBAJA = NULL WHERE ID = :DOCTOID;
    END


      SUSPEND;


END
