CREATE OR ALTER PROCEDURE MOVTO_CAMBIAR_PRECIOCONIVA (
    movtoid d_pk,
    precioconiva d_precio,
    supervisorid d_fk)
returns (
    errorcode d_errorcode)
as
declare variable estatusdoctoid d_fk;
declare variable estatusmovtoid d_fk;
declare variable porcentajeiva d_porcentaje;
declare variable productoid d_fk;
declare variable precio d_precio;
declare variable doctoid d_fk;
declare variable almacenid d_fk;
declare variable sucursalid d_fk;
declare variable lote d_lote;
declare variable fechavence d_fechavence;
declare variable tipodiferenciainventarioid d_fk;
declare variable tipodoctoid d_fk;
declare variable personaid d_fk;
declare variable costo d_costo;
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
         :TIPODIFERENCIAINVENTARIOID, CURRENT_DATE, CURRENT_DATE, 0.00
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