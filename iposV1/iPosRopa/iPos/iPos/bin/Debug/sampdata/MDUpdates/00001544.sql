create or alter procedure DOCTO_INSERT (
    CREADOPOR_USERID type of D_FK,
    ALMACENID type of D_FK,
    SUCURSALID type of D_FK,
    TIPODOCTOID type of D_FK,
    ESTATUSDOCTOID type of D_FK,
    ESTATUSDOCTOPAGOID type of D_FK,
    PERSONAID type of D_FK,
    VENDEDORID type of D_FK,
    CAJAID type of D_FK,
    REFERENCIA type of D_REFERENCIA,
    REFERENCIAS varchar(255),
    SUCURSALTID D_FK,
    ALMACENTID D_FK,
    FECHA D_FECHA,
    VENCE D_FECHA,
    DOCTOREFID D_FK,
    MERCANCIAENTREGADA D_BOOLCS,
    ORIGENFISCALID D_FK)
returns (
    DOCTOID type of D_FK,
    ERRORCODE type of D_ERRORCODE)
as
declare variable HAYCORTEACTIVO D_BOOLCN;
declare variable CORTEID2 D_FK;
declare variable FECHAULTIMA D_FECHA;
declare variable ESAPARTADO D_BOOLCN;
declare variable MONEDAID D_FK;
declare variable TIPOCAMBIO D_TIPOCAMBIO;
declare variable ESMATRIZ D_BOOLCN;
declare variable ESFRANQUICIA D_BOOLCN;
declare variable CLIENTEFRANQUICIA D_FK;
BEGIN

   SELECT HAYCORTEACTIVO,CORTEID,ERRORCODE
   FROM HAY_CORTE_ACTIVO(:VENDEDORID)
   INTO :HAYCORTEACTIVO, :CORTEID2, :ERRORCODE;

   IF (:ERRORCODE > 0) THEN
   BEGIN
      DOCTOID = 0;
      SUSPEND;
      EXIT;
   END

   -- Validar MAXDOCTOSPENDIENTES
   -- Por ahora solo validar para el tipo 21: Ventas.
   IF (:TIPODOCTOID = 21) THEN
   BEGIN
      SELECT ERRORCODE 
      FROM VALIDAR_MAXDOCTOSPENDIENTES(:TIPODOCTOID)
      INTO :ERRORCODE;
   END

   IF (:ERRORCODE > 0) THEN
   BEGIN
      DOCTOID = 0;
      SUSPEND;
      EXIT;
   END

   -- Validar la fecha VS ultima fecha de operacion
   SELECT FECHAULTIMA
   FROM PARAMETRO
   INTO :FECHAULTIMA;

   IF (:FECHAULTIMA IS NOT NULL)  THEN
   BEGIN
      IF (:FECHAULTIMA > CURRENT_DATE) THEN
      BEGIN
         ERRORCODE = 1067;
         SUSPEND;
         EXIT;
      END

      IF (:FECHAULTIMA < (CURRENT_DATE-3)) THEN
      BEGIN
         ERRORCODE = 1068;
         SUSPEND;
         EXIT;
      END
   END

   IF (:FECHA IS NULL) THEN
   BEGIN
      FECHA = CURRENT_DATE;
   END

   IF (:VENCE IS NULL) THEN
   BEGIN
      VENCE = :FECHA;
   END

   ESAPARTADO = (CASE WHEN :TIPODOCTOID IN (25,26) THEN 'S' ELSE 'N' END);


  SELECT COALESCE(MONEDAID,1) FROM PERSONA WHERE ID = :PERSONAID INTO :MONEDAID;
  SELECT COALESCE(TIPOCAMBIO,1) FROM MONEDA WHERE ID = :MONEDAID INTO :TIPOCAMBIO;


   IF(:TIPODOCTOID = 31) THEN
   BEGIN
      select coalesce(sucursal.esmatriz,'N') from sucursal where id = :sucursalid into :esmatriz;

      if(coalesce(:esmatriz,'N') = 'S') then
      begin
      
        select first 1 sucursal.ESFRANQUICIA,  persona.id from sucursal
        inner join persona on persona.clave =  coalesce(sucursal.clienteclave ,'')
        where sucursal.id = :sucursaltid
        into :ESFRANQUICIA,  :CLIENTEFRANQUICIA;

        if(coalesce(:esfranquicia ,'N') = 'S' and coalesce(:clientefranquicia,0) <> 0) then
        begin
            personaid = :clientefranquicia;
        end

      end

   END



   INSERT INTO DOCTO (
      CREADOPOR_USERID, 
      ALMACENID, 
      SUCURSALID, 
      TIPODOCTOID, 
      ESTATUSDOCTOID, 
      ESTATUSDOCTOPAGOID, 
      ESTATUSDOCTOPEDIDOID,
      PERSONAID, 
      VENDEDORID,
      CAJAID,
      REFERENCIA,
      REFERENCIAS,
      SUCURSALTID,
      ALMACENTID,
      FECHA,
      VENCE,
      DOCTOREFID,
      MERCANCIAENTREGADA,
      ORIGENFISCALID,
      ESAPARTADO,
      ESFACTURAELECTRONICA,
      MONEDAID,
      TIPOCAMBIO)
   VALUES (
      :CREADOPOR_USERID, 
      :ALMACENID, 
      :SUCURSALID, 
      :TIPODOCTOID, 
      :ESTATUSDOCTOID, 
      :ESTATUSDOCTOPAGOID, 
      0,
      :PERSONAID, 
      :VENDEDORID,
      :CAJAID,
      :REFERENCIA,
      :REFERENCIAS,
      :SUCURSALTID,
      :ALMACENTID,
      :FECHA,
      :VENCE,
      :DOCTOREFID,
      :MERCANCIAENTREGADA,
      :ORIGENFISCALID,
      :ESAPARTADO,
      'N',
      :MONEDAID,
      :TIPOCAMBIO)
   RETURNING ID INTO :DOCTOID;

   IF ((:DOCTOID IS NULL) OR (:DOCTOID = 0)) THEN
   BEGIN
      ERRORCODE = 1002;
   END

   SUSPEND;
END