create or alter procedure MOVTO_CAMBIAR_PRECIOCONIVA (
    MOVTOID D_PK,
    PRECIOCONIVA D_PRECIO,
    SUPERVISORID D_FK)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable ESTATUSDOCTOID D_FK;
declare variable ESTATUSMOVTOID D_FK;
declare variable PORCENTAJEIVA D_PORCENTAJE;
declare variable PRODUCTOID D_FK;
declare variable PRECIO D_PRECIO;
declare variable DOCTOID D_FK;
declare variable ALMACENID D_FK;
declare variable SUCURSALID D_FK;
declare variable LOTE D_LOTE;
declare variable FECHAVENCE D_FECHAVENCE;
declare variable TIPODIFERENCIAINVENTARIOID D_FK;
declare variable TIPODOCTOID D_FK;
declare variable PERSONAID D_FK;
declare variable COSTO D_COSTO;
BEGIN
   SELECT
      D.ESTATUSDOCTOID, M.ESTATUSMOVTOID, M.PRODUCTOID , M.DOCTOID  ,
      D.almacenid, d.sucursalid  , M.lote,  M.fechavence ,M.TIPODIFERENCIAINVENTARIOID,
      d.tipodoctoid, d.personaid , M.costo
   FROM MOVTO M
      LEFT JOIN DOCTO D
         ON D.ID = M.DOCTOID
   WHERE
      M.ID = :MOVTOID
   INTO
      :ESTATUSDOCTOID, :ESTATUSMOVTOID, :PRODUCTOID, :DOCTOID,
      :almacenid, :sucursalid  , :lote,  :fechavence ,:TIPODIFERENCIAINVENTARIOID,
      :TIPODOCTOID, :PERSONAID, :COSTO;



   -- No borrar si el estatus del docto o movto es borrador o si es promocion.
   IF ((:ESTATUSDOCTOID <> 0) or (:ESTATUSMOVTOID <> 0)) THEN
   BEGIN
      ERRORCODE = 1014;
      SUSPEND;
      EXIT;
   END
   
   ELSE
   BEGIN


      
     select tasaiva from producto
     where id = :productoid
     into :porcentajeiva;

     precio = (:precioconiva * 100)/ (100 + :porcentajeiva);
   


         SELECT ERRORCODE
      FROM MOVTO_INSERT (
         :DOCTOID, 0, :ALMACENID, :SUCURSALID, :TIPODOCTOID, 0, 0, :PERSONAID, :SUPERVISORID, 1,
         0, :PRODUCTOID, :LOTE, :FECHAVENCE, /*:CANTIDAD*/0, 0, 0, 0, 0, :PRECIO, 0,
          '',  '', :COSTO, :SUCURSALID, :ALMACENID, 'N',
         :TIPODIFERENCIAINVENTARIOID, CURRENT_DATE, CURRENT_DATE, 0.00,NULL,NULL,NULL,NULL,NULL
      ) INTO :ERRORCODE;

     if(:ERRORCODE <> 0 ) THEN
     BEGIN
      SUSPEND;
      EXIT;
     END

   END

   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1015;
      SUSPEND;
   END 
END