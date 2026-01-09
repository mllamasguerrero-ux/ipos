create or alter procedure GET_PRODUCTO_MOVTOS (
    PRODUCTOID D_FK,
    FECHAINI D_FECHA,
    FECHAFIN D_FECHA,
    ALMACENID D_FK,
    SUCURSALID D_FK,
    TIPODOCTOID D_FK)
returns (
    NUMERO integer,
    FECHA D_FECHA,
    FECHAHORA D_TIMESTAMP,
    SUCURSALCLAVE D_CLAVE,
    ALMACENCLAVE D_CLAVE,
    TIPODOCTOCLAVE D_CLAVE,
    DOCTOFOLIO D_DOCTOFOLIO,
    PRODUCTOCLAVE D_CLAVE,
    PRODUCTODESCRIPCION D_DESCRIPCION,
    CANTIDADMOV D_CANTIDAD,
    NOMBREPERSONA D_NOMBRE_NULL,
    COSTOPRECIO D_PRECIO,
    DESCUENTO D_PRECIO,
    IVA D_PRECIO,
    TASAIVA D_PORCENTAJE,
    IEPS D_PRECIO,
    TASAIEPS D_PORCENTAJE,
    TOTAL D_PRECIO,
    IMPUESTO D_PRECIO,
    PRECIO_MAS_IMPUESTO D_PRECIO,
    PRECIOCAJ_MAS_IMPUESTO D_PRECIO)
as
declare variable EXISTENCIAINICIAL D_CANTIDAD;
declare variable FECHAINICIAL D_FECHA;
declare variable CANTIDADMOVTOSINICIAL D_CANTIDAD;
declare variable ALMACENES integer;
BEGIN
   NUMERO = 0;
  
   -- Por ahora tomar el parametro local.
   SELECT SUCURSALID
   FROM PARAMETRO
   INTO :SUCURSALID;

   -- Si NO se recibe parametro almacenId
   IF ((:ALMACENID IS NULL) OR (:ALMACENID = 0)) THEN
   BEGIN
      -- Contar almacenes, para validar si hay mas de 1.
      SELECT COUNT(ID)
      FROM ALMACEN
      INTO :ALMACENES;

      -- Seleccionar el primero o
      IF (:ALMACENES > 0) THEN
      BEGIN
         SELECT FIRST 1 ID
         FROM ALMACEN
         ORDER BY ID
         INTO :ALMACENID;
      END
      ELSE
      BEGIN
         ALMACENID = 1;
      END
   END

   FOR SELECT
      D.FECHA,
      D.FECHAHORA,
      S.CLAVE,
      A.CLAVE,
      TD.CLAVE,
      D.FOLIO,
      P.CLAVE,
      P.DESCRIPCION1,
      TD.SENTIDOINVENTARIO * M.CANTIDAD ,
      PRC.nombre, 
      M.PRECIO ,
      M.DESCUENTO,
      M.IVA,
      M.TASAIVA,
      M.IEPS,
      M.TASAIEPS,
      M.TOTAL,
      M.IMPUESTO,
      CASE WHEN COALESCE(M.PRECIO,0) > 0 THEN CAST(ROUND(COALESCE(M.SUBTOTAL,0.00) / COALESCE(M.PRECIO,1.00), 2) AS D_PRECIO) ELSE 0.00 END PRECIO_MAS_IMPUESTO,
      CASE WHEN COALESCE(M.PRECIO,0) > 0 THEN
            CAST(  ROUND(
                    CAST(ROUND(COALESCE(M.SUBTOTAL,0.00) / COALESCE(M.PRECIO,1.00), 2) AS D_PRECIO)
                    * (CASE WHEN COALESCE(P.PZACAJA,0) > 0 THEN COALESCE(P.PZACAJA,0) ELSE 1 END)
                    ,2) AS D_PRECIO)
            ELSE 0.00 END PRECIOCAJ_MAS_IMPUESTO

   FROM MOVTO M
      LEFT JOIN DOCTO D
         ON D.ID = M.DOCTOID
      LEFT JOIN TIPODOCTO TD
         ON TD.ID = D.TIPODOCTOID
      LEFT JOIN PRODUCTO P
         ON P.ID = M.PRODUCTOID
      LEFT JOIN SUCURSAL S
         ON S.ID = D.SUCURSALID
      LEFT JOIN ALMACEN A
         ON A.ID = D.ALMACENID
      LEFT JOIN PERSONA PRC
         ON PRC.ID = D.PERSONAID
   WHERE M.PRODUCTOID = :PRODUCTOID
     AND SUCURSALID = :SUCURSALID
     AND D.ALMACENID = :ALMACENID
     AND d.TIPODOCTOID = :TIPODOCTOID
     AND (:TIPODOCTOID <> 21 or coalesce(D.SUBTIPODOCTOID,0) not IN (6,7,8,23))
     AND (:TIPODOCTOID <> 11 or coalesce(D.SUBTIPODOCTOID,0) not IN (6,7,8,23))
     AND D.FECHA BETWEEN :FECHAINI AND :FECHAFIN
   ORDER BY D.FECHA
   INTO
      :FECHA ,
      :FECHAHORA ,
      :SUCURSALCLAVE ,
      :ALMACENCLAVE,
      :TIPODOCTOCLAVE ,
      :DOCTOFOLIO ,
      :PRODUCTOCLAVE ,
      :PRODUCTODESCRIPCION ,
      :CANTIDADMOV  ,
      :NOMBREPERSONA  ,
      :COSTOPRECIO ,
      :DESCUENTO,
      :IVA,
      :TASAIVA,
      :IEPS,
      :TASAIEPS,
      :TOTAL,
      :IMPUESTO,
      :PRECIO_MAS_IMPUESTO,
      :PRECIOCAJ_MAS_IMPUESTO
   DO
   BEGIN
      NUMERO = :NUMERO + 1;
      SUSPEND;
   END

   if (:numero = 0) then
   begin
      numero = 0;
      fecha = current_date;
      fechahora = current_date;
      sucursalclave = '';
      almacenclave  = '';
      tipodoctoclave = '';
      doctofolio = 0;
      productoclave = '';
      productodescripcion = '';
      cantidadmov = 0;
      nombrepersona = '';
      costoprecio = 0;
      descuento = 0;
      iva = 0;
      tasaiva = 0;
      ieps = 0;
      tasaieps = 0;
      total = 0;
      impuesto = 0;
      -- sin suspend para no regresar renglon falso
   end

END