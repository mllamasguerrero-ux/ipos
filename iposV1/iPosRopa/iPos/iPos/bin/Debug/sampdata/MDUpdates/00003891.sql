create or alter procedure EMIDA_REAJUSTARUTILIDADES (
    FECHAINICIAL D_FECHA,
    FECHAFINAL D_FECHA)
returns (
    ERRORCODE type of D_ERRORCODE)
as
declare variable EMIDAPORCUTILIDADRECARGAS D_PORCENTAJE;
declare variable EMIDAUTILIDADPAGOSERVICIOS D_PRECIO;
declare variable TIPOUTILIDADID D_PRECIO;
BEGIN


   SELECT
    EMIDAPORCUTILIDADRECARGAS,
    EMIDAUTILIDADPAGOSERVICIOS,
    TIPOUTILIDADID
   FROM
    PARAMETRO 
   WHERE 1 = 1
   INTO
    :EMIDAPORCUTILIDADRECARGAS,
    :EMIDAUTILIDADPAGOSERVICIOS,
    :TIPOUTILIDADID;


    UPDATE MOVTO
    SET UTILIDAD = COALESCE(:EMIDAUTILIDADPAGOSERVICIOS,0)
    WHERE ID IN
    (SELECT MOVTO.ID FROM DOCTO INNER JOIN MOVTO ON MOVTO.DOCTOID = DOCTO.ID AND
    DOCTO.TIPODOCTOID IN (21,23,25,26) and DOCTO.subtipodoctoid in (24)) ;

    UPDATE MOVTO
    SET UTILIDAD =  (  (case when coalesce(MOVTO.estadorebaja,0) = 1 then coalesce(MOVTO.precioconrebaja,0) else coalesce(MOVTO.precio,0) end) -
                                                        (CASE WHEN :tipoutilidadid = 1 THEN COALESCE(MOVTO.costoreposicion,0)
                                                           WHEN :tipoutilidadid = 3 THEN COALESCE(MOVTO.costoultimo,0)
                                                           ELSE COALESCE(MOVTO.costopromedio,0) END ) )
                                                            * COALESCE(MOVTO.cantidad, 0)
     WHERE ID IN
    (SELECT MOVTO.ID FROM DOCTO INNER JOIN MOVTO ON MOVTO.DOCTOID = DOCTO.ID AND
    DOCTO.TIPODOCTOID IN (21,23,25,26) and DOCTO.subtipodoctoid in (22)) ;



   ERRORCODE = 0;
   SUSPEND;
END