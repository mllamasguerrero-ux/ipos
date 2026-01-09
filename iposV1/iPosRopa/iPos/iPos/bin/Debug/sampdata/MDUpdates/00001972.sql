create or alter procedure MOVTO_ADJUNTARPRODUCTO (
    DOCTOID D_FK,
    MOVTOID D_FK,
    PRODUCTOID D_FK,
    CANTIDAD D_CANTIDAD,
    PRECIO D_PRECIO)
returns (
    NEWMOVTOID D_FK,
    ERRORCODE D_ERRORCODE)
as
declare variable ESTATUSDOCTOID D_FK;
declare variable TIPODOCTOID D_FK;
declare variable ALMACENID D_FK;
declare variable SUCURSALID D_FK;
declare variable PERSONAID D_FK;
declare variable SERIE varchar(31);
declare variable FOLIO integer;
declare variable ALMACENTID D_FK;
declare variable SUCURSALTID D_FK;
declare variable TOTAL D_FK;
declare variable REFERENCIA D_REFERENCIA;
declare variable REFERENCIAS varchar(255);
declare variable PRECIOPRODUCTO D_PRECIO;
declare variable COSTOREPOSICION D_PRECIO;
declare variable COSTOPROMEDIO D_PRECIO;
declare variable PRECIOMAXIMOPUBLICO D_PRECIO;
declare variable TASAIVA D_PORCENTAJE;
declare variable PRODUCTOCLAVE D_CLAVE_NULL;
BEGIN
   -- Leer del DOCTO a cancelar.
   SELECT ESTATUSDOCTOID, TIPODOCTOID
   FROM DOCTO
   WHERE ID = :DOCTOID
   INTO :ESTATUSDOCTOID, :TIPODOCTOID;

   -- Si no esta vigente: Salir.
   IF (:ESTATUSDOCTOID <> 0) THEN
   BEGIN
      ERRORCODE = 1007;
      SUSPEND;
      EXIT;
   END

   -- Si no es devolucion
   IF (:TIPODOCTOID NOT IN (321)) THEN
   BEGIN
      ERRORCODE = 1008;
      SUSPEND;
      EXIT;
   END




   select PRECIO1,COSTOREPOSICION, COSTOPROMEDIO ,PRECIOMAXIMOPUBLICO ,TASAIVA ,CLAVE
   FROM PRODUCTO WHERE ID = :PRODUCTOID
   INTO :PRECIOPRODUCTO,:COSTOREPOSICION, :COSTOPROMEDIO ,:PRECIOMAXIMOPUBLICO ,:TASAIVA ,:PRODUCTOCLAVE;


   -- Leer del DOCTO a EDITAR.
   SELECT ALMACENID, SUCURSALID, PERSONAID, SERIE, FOLIO, SUCURSALTID, ALMACENTID  , TOTAL
   FROM DOCTO
   WHERE ID = :DOCTOID
   INTO :ALMACENID, :SUCURSALID, :PERSONAID, :SERIE, :FOLIO, :SUCURSALTID, :ALMACENTID, :TOTAL;

   REFERENCIA = NULL;
   REFERENCIAS = NULL;





      INSERT INTO MOVTO (
         DOCTOID,
         ESTATUSMOVTOID,
         PARTIDA,
         PRODUCTOID,
         LOTE,
         FECHAVENCE,
         CANTIDAD,
         CANTIDADSURTIDA,
         CANTIDADFALTANTE,
         CANTIDADDEVUELTA,
         CANTIDADSALDO,
         PRECIO,
         PRECIOLISTA,
         IMPORTE,
         SUBTOTAL,
         DESCUENTO,
         IVA,
         TOTAL,
         COSTO,
         COSTOIMPORTE,
         TIPODIFERENCIAINVENTARIOID,
         PROMOCION,
         PRECIOMANUAL,
         PORCENTAJEDESCUENTOMANUAL,
         COSTOREPOSICION,
         COSTOPROMEDIO,
         PRECIOMAXIMOPUBLICO,
         PRECIOCLASIFICACION,
         TASAIVA,
         INGRESOPRECIOMANUAL,
         MOVTOREFID,
         ESAPARTADO,
         COMISIONXUNIDAD,
         TIPODOCTOID,
         ANAQUELID,
         LOCALIDAD,
         PROMOCIONID,
         PROMOCIONDESGLOSE,
         MONEDEROABONO ,
         CLAVEPROD,
         TASAISRRETENIDO,
         ISRRETENIDO,
         TASAIVARETENIDO,
         IVARETENIDO,
         TASAIEPS,
         IEPS,
         TASAIMPUESTO,
         IMPUESTO,
         DESCRIPCION1,
         DESCRIPCION2,
         DESCRIPCION3,
         DESCUENTOPORCENTAJE ,
         MOVTOADJUNTOAID
         )
      VALUES (
         :DOCTOID,
         0,
         0,
         :PRODUCTOID,
         null,
         null,
         :CANTIDAD,
         :CANTIDAD,
         :CANTIDAD,
         :CANTIDAD,
         :CANTIDAD,
         0,
         :PRECIOPRODUCTO,
         0,
         0,
         :PRECIOPRODUCTO * :CANTIDAD,
         0,
         0,
         0,
         0,
         0,
         'N',
         0,
         100,
         :COSTOREPOSICION,
         :COSTOPROMEDIO,
         :PRECIOMAXIMOPUBLICO,
         1 ,
         coalesce(:TASAIVA,0),
         'S',
         NULL,
         'N',
         0,
         :TIPODOCTOID,
         NULL,
         NULL ,
         NULL,
         NULL  ,
         0,
         :PRODUCTOCLAVE ,
         0,
         0,
         0,
         0,
         0,
         0,
         0,
         0,
         '',
         '',
         ''  ,
         100,
         :MOVTOID
      ) RETURNING ID INTO :NEWMOVTOID;




     
   IF(COALESCE(:ERRORCODE,0) <> 0) THEN
   BEGIN    
      SUSPEND;
      EXIT;
   END




   ERRORCODE = 0;
   SUSPEND;
          /*
    WHEN ANY DO
    BEGIN
        ERRORCODE = 1009;
        SUSPEND;
    END */
END