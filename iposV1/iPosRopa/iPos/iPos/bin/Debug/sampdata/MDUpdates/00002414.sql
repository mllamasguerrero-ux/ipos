create or alter procedure REBAJA_RECHAZA_DETALLE (
    MOVTOREFID D_FK,
    CANTIDAD D_CANTIDAD,
    DOCTOID D_FK)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable UTILIDAD D_PRECIO;
declare variable TIPOUTILIDADID D_FK;
BEGIN


       SELECT TIPOUTILIDADID FROM PARAMETRO INTO :TIPOUTILIDADID;

      update  movto set estadorebaja = 3 ,
      utilidad =   (  coalesce(precio,0)  -
                                                        (CASE WHEN :tipoutilidadid = 1 THEN COALESCE(costoreposicion,0)
                                                           WHEN :tipoutilidadid = 3 THEN COALESCE(costoultimo,0)
                                                           ELSE COALESCE(costopromedio,0) END ) )
                                                            * COALESCE(cantidad, 0)
      where ID =  :MOVTOREFID;
      
      IF (:ERRORCODE <> 0) THEN
      BEGIN
         SUSPEND;
         EXIT;
      END



      select sum( (  (case when coalesce(movto.estadorebaja,0) = 1 then coalesce(movto.precioconrebaja,0) else coalesce(movto.precio,0) end) -
                                                        (CASE WHEN :tipoutilidadid = 1 THEN COALESCE(MOVTO.costoreposicion,0)
                                                           WHEN :tipoutilidadid = 3 THEN COALESCE(MOVTO.costoultimo,0)
                                                           ELSE COALESCE(MOVTO.costopromedio,0) END ) )
                                                            * COALESCE(MOVTO.cantidad, 0) )

       FROM MOVTO WHERE MOVTO.DOCTOID = :DOCTOID INTO :UTILIDAD;

       UPDATE DOCTO SET UTILIDAD = :UTILIDAD WHERE ID = :DOCTOID;

       
      IF (:ERRORCODE <> 0) THEN
      BEGIN
         SUSPEND;
         EXIT;
      END



    
   IF(COALESCE(:ERRORCODE,0) <> 0) THEN
   BEGIN    
      SUSPEND;
      EXIT;
   END









   ERRORCODE = 0;
   SUSPEND;
   
    WHEN ANY DO
    BEGIN
        ERRORCODE = 1009;
        SUSPEND;
    END
END