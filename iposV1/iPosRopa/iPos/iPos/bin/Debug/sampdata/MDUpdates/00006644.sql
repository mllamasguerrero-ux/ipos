create or alter procedure VENTA_PRECANCEL (
    DOCTOCANCELARID D_FK,
    VENDEDORID D_FK)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable ESTATUSDOCTOID D_FK;
declare variable DOCTOID D_FK;
declare variable MOVTOID D_FK;
declare variable ALMACENID D_FK;
declare variable SUCURSALID D_FK;
declare variable PERSONAID D_FK;
declare variable TIPODOCTOCANCELARID D_FK;
declare variable TIPODOCTOID D_FK;
declare variable PRODUCTOID D_FK;
declare variable LOTE D_LOTE;
declare variable FECHAVENCE D_FECHAVENCE;
declare variable CANTIDAD D_CANTIDAD;
declare variable PRECIO D_PRECIO;
declare variable COSTO D_COSTO;
declare variable REFERENCIA D_REFERENCIA;
declare variable REFERENCIAS varchar(255);
declare variable SERIE varchar(31);
declare variable FOLIO integer;
declare variable ALMACENTID D_FK;
declare variable SUCURSALTID D_FK;
declare variable TIPODIFERENCIAINVENTARIOID D_FK;
declare variable CANTIDADDEFACTURA D_CANTIDAD;
declare variable CANTIDADDEREMISION D_CANTIDAD;
declare variable CANTIDADDEINDEFINIDO D_CANTIDAD;
declare variable NEWMOVTOID D_FK;
declare variable NOTASCREDITOAPLICADAS D_FK;
declare variable DESCRIPCION1 D_STDTEXT_64;
declare variable DESCRIPCION2 D_STDTEXT_64;
declare variable DESCRIPCION3 D_STDTEXT_64;
declare variable ESTADOSURTIDOID D_FK;
declare variable HABSURTIDOPOSTPUESTO D_BOOLCN;
declare variable DOCTOFACTCONSID D_FK;
declare variable SUBTIPODOCTOID D_FK;
declare variable DOCTOREFID D_FK;
declare variable SUBTIPODOCTOIDSECUNDARIO D_FK;
declare variable VENTAFUTUID D_FK;
declare variable LOTEIMPORTADO D_FK;
declare variable PAGOSTIMBRADOSAPLICADOS integer;
declare variable VERSIONCFDI D_STDTEXT_SHORT;
BEGIN


   SELECT VERSIONCFDI FROM PARAMETRO INTO :VERSIONCFDI;


   -- Leer del DOCTO a cancelar.
   SELECT ESTATUSDOCTOID, TIPODOCTOID, FACTCONSID, SUBTIPODOCTOID, DOCTOREFID, VENTAFUTUID
   FROM DOCTO
   WHERE ID = :DOCTOCANCELARID
   INTO :ESTATUSDOCTOID, :TIPODOCTOCANCELARID, :DOCTOFACTCONSID, :SUBTIPODOCTOID, :DOCTOREFID, :VENTAFUTUID;

   -- Si no esta vigente: Salir.
   IF (:ESTATUSDOCTOID <> 1) THEN
   BEGIN
      ERRORCODE = 1007;
      SUSPEND;
      EXIT;
   END

   
   -- Si no esta vigente: Salir.
   IF (COALESCE(:DOCTOFACTCONSID,0) <> 0) THEN
   BEGIN
      ERRORCODE = 5009;
      SUSPEND;
      EXIT;
   END

   -- Si no es de los tipos b?sicos: Salir.
   IF (:TIPODOCTOCANCELARID NOT IN ( 31,21,81, 321, 121, 821)) THEN
   BEGIN
      ERRORCODE = 1011;
      SUSPEND;
      EXIT;
   END

   
   -- Si no es de los tipos b?sicos: Salir.
   IF (:TIPODOCTOCANCELARID  IN ( 821) AND COALESCE(:VENTAFUTUID,0) > 0) THEN
   BEGIN
      ERRORCODE = 1087;
      SUSPEND;
      EXIT;
   END


   SELECT COUNT(*) FROM DOCTOPAGO
   left join docto on doctopago.doctosalidaid = docto.id
   WHERE DOCTOID = :DOCTOCANCELARID AND FORMAPAGOID IN (6,1)
    and docto.estatusdoctoid = 1
    INTO :NOTASCREDITOAPLICADAS;

   IF(COALESCE(:NOTASCREDITOAPLICADAS,0) <> 0 ) then
   begin
        
      ERRORCODE = 3003;
      SUSPEND;
      EXIT;
   end




   IF(COALESCE(:VERSIONCFDI,'') = '3.3' or COALESCE(:VERSIONCFDI,'') = '4.0') THEN
   BEGIN

   
        SELECT COUNT(*) FROM DOCTOPAGO
            LEFT JOIN PAGO ON PAGO.ID = DOCTOPAGO.pagoid
        WHERE DOCTOPAGO.DOCTOID = :DOCTOCANCELARID
            AND COALESCE(DOCTOPAGO.revertido , 'N') = 'N'
            AND (COALESCE(DOCTOPAGO.reciboelectronicoid,0) > 0 OR
            COALESCE(PAGO.reciboelectronicoid,0) > 0 ) 
            AND COALESCE(DOCTOPAGO.TIPOABONOID,1) <> 3
        INTO :PAGOSTIMBRADOSAPLICADOS;

    
        IF(COALESCE(:PAGOSTIMBRADOSAPLICADOS,0) > 0 ) then
        begin
        
            ERRORCODE = 5028;
            SUSPEND;
            EXIT;
        end



   END





   ERRORCODE = 0;
   SUSPEND;
      /*
    WHEN ANY DO
    BEGIN
        ERRORCODE = 1009;
        SUSPEND;
    END  */
END