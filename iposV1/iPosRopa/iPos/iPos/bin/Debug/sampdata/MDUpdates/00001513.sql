create or alter procedure MOVTO_CAMBIAR_PRECIOCONIVA (
    MOVTOID D_PK,
    PRECIOCONIVA D_PRECIO,
    SUPERVISORID D_FK)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable ESTATUSDOCTOID D_FK;
declare variable ESTATUSMOVTOID D_FK;
declare variable PORCENTAJEIMPUESTO D_PORCENTAJE;
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
declare variable DESCRIPCION1 D_STDTEXT_64;  
declare variable DESCRIPCION2 D_STDTEXT_64;
declare variable DESCRIPCION3 D_STDTEXT_64;
BEGIN
   SELECT
      D.ESTATUSDOCTOID, M.ESTATUSMOVTOID, M.PRODUCTOID , M.DOCTOID  ,
      D.almacenid, d.sucursalid  , M.lote,  M.fechavence ,M.TIPODIFERENCIAINVENTARIOID,
      d.tipodoctoid, d.personaid , M.costo , M.DESCRIPCION1, M.DESCRIPCION2, M.DESCRIPCION3
   FROM MOVTO M
      LEFT JOIN DOCTO D
         ON D.ID = M.DOCTOID
   WHERE
      M.ID = :MOVTOID
   INTO
      :ESTATUSDOCTOID, :ESTATUSMOVTOID, :PRODUCTOID, :DOCTOID,
      :almacenid, :sucursalid  , :lote,  :fechavence ,:TIPODIFERENCIAINVENTARIOID,
      :TIPODOCTOID, :PERSONAID, :COSTO, :DESCRIPCION1, :DESCRIPCION2, :DESCRIPCION3;



   -- No borrar si el estatus del docto o movto es borrador o si es promocion.
   IF ((:ESTATUSDOCTOID <> 0) or (:ESTATUSMOVTOID <> 0)) THEN
   BEGIN
      ERRORCODE = 1014;
      SUSPEND;
      EXIT;
   END
   
   ELSE
   BEGIN


      
     select tasaimpuesto from producto
     where id = :productoid
     into :porcentajeimpuesto;

     precio = (:precioconiva * 100)/ (100 + :porcentajeimpuesto);
   


         SELECT ERRORCODE
      FROM MOVTO_INSERT (
         :DOCTOID, 0, :ALMACENID, :SUCURSALID, :TIPODOCTOID, 0, 0, :PERSONAID, :SUPERVISORID, 1,
         0, :PRODUCTOID, :LOTE, :FECHAVENCE, /*:CANTIDAD*/0, 0, 0, 0, 0, :PRECIO, 0,
          '',  '', :COSTO, :SUCURSALID, :ALMACENID, 'N',
         :TIPODIFERENCIAINVENTARIOID, CURRENT_DATE, CURRENT_DATE, 0.00,NULL,NULL,NULL,NULL,NULL , :DESCRIPCION1, :DESCRIPCION2, :DESCRIPCION3
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
