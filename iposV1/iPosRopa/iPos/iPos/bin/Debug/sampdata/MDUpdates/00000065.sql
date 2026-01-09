
create or alter procedure GET_KARDEX_REPORT (
    PROD_CLAVE_INI varchar(31),
    PROD_CLAVE_FIN varchar(31),
    FECHAINI D_FECHA,
    FECHAFIN D_FECHA,
    ALMACENID D_FK)
returns (
    NUMERO integer,
    KARDEXID D_FK,
    DOCTOID D_FK,
    MOVTOID D_FK,
    PRODUCTOID D_FK,
    SUCURSALID D_FK,
    FECHA D_FECHA,
    FECHAHORA D_TIMESTAMP,
    SUCURSALCLAVE D_CLAVE,
    TIPODOCTOCLAVE D_CLAVE,
    DOCTOFOLIO D_DOCTOFOLIO,
    PRODUCTOCLAVE D_CLAVE,
    PRODUCTODESCRIPCION D_DESCRIPCION,
    CANTIDADINI D_CANTIDAD,
    CANTIDADMOV D_CANTIDAD,
    CANTIDADFIN D_CANTIDAD)
as
declare variable EXISTENCIAINICIAL D_CANTIDAD;
declare variable FECHAINICIAL D_FECHA;
declare variable CANTIDADMOVTOSINICIAL D_CANTIDAD;
declare variable PRODUCTO_ID D_FK;
BEGIN


   if (:PROD_CLAVE_FIN = '') then
   BEGIN
      PROD_CLAVE_FIN = 'ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ';
   END

         
   FOR SELECT
      PRODUCTO.ID
      FROM PRODUCTO
      WHERE  PRODUCTO.CLAVE BETWEEN :PROD_CLAVE_INI AND :PROD_CLAVE_FIN
      INTO   :PRODUCTO_ID
   DO
   BEGIN

   -- Tomar existencia inicial de INVENTARIO
   SELECT sum(CANTIDADINICIAL), MIN(FECHAINICIAL)
   FROM INVENTARIO
   WHERE ALMACENID = :ALMACENID
     AND PRODUCTOID = :PRODUCTO_ID
   GROUP BY ALMACENID, PRODUCTOID
   INTO :EXISTENCIAINICIAL, :FECHAINICIAL;

   -- Calcular existencia incial antes de la fecha del rango.
   IF (:FECHAINI > :FECHAINICIAL) THEN
   BEGIN
      SELECT
         COALESCE(SUM(TD.SENTIDOINVENTARIO * K.CANTIDAD), 0.00)
      FROM KARDEX K
         LEFT JOIN DOCTO D
            ON D.ID = K.DOCTOID
         LEFT JOIN TIPODOCTO TD
            ON TD.ID = D.TIPODOCTOID
      WHERE K.PRODUCTOID = :PRODUCTO_ID
        AND K.FECHA < :FECHAINI
        AND K.ALMACENID = :ALMACENID
      INTO :CANTIDADMOVTOSINICIAL;
   END
   ELSE
   BEGIN
      CANTIDADMOVTOSINICIAL = 0;
   END

   NUMERO = 0;
   CANTIDADINI = 0;
   CANTIDADFIN = :EXISTENCIAINICIAL + :CANTIDADMOVTOSINICIAL;

   FOR SELECT
      K.ID,
      K.DOCTOID,
      K.MOVTOID,
      K.PRODUCTOID,
      D.SUCURSALID,
      D.FECHA,
      D.FECHAHORA,
      S.CLAVE,
      TD.CLAVE,
      D.FOLIO,
      P.CLAVE,
      P.DESCRIPCION1,
      TD.SENTIDOINVENTARIO * K.CANTIDAD
   FROM KARDEX K
      LEFT JOIN DOCTO D
         ON D.ID = K.DOCTOID
      LEFT JOIN TIPODOCTO TD
         ON TD.ID = D.TIPODOCTOID
      LEFT JOIN PRODUCTO P
         ON P.ID = K.PRODUCTOID/*K.PRODUCTOID*/
      LEFT JOIN SUCURSAL S
         ON S.ID = D.SUCURSALID
   WHERE K.PRODUCTOID = :PRODUCTO_ID
     AND K.FECHA BETWEEN :FECHAINI AND :FECHAFIN
   INTO
      :KARDEXID,
      :DOCTOID ,
      :MOVTOID ,
      :PRODUCTOID ,
      :SUCURSALID ,
      :FECHA ,
      :FECHAHORA ,
      :SUCURSALCLAVE ,
      :TIPODOCTOCLAVE ,
      :DOCTOFOLIO ,
      :PRODUCTOCLAVE ,
      :PRODUCTODESCRIPCION ,
      :CANTIDADMOV
   DO
   BEGIN
      NUMERO = :NUMERO + 1;
      CANTIDADINI = :CANTIDADFIN ;
      CANTIDADFIN = :CANTIDADINI + :CANTIDADMOV;
      SUSPEND;
   END

   END

   if (:NUMERO = 0) then
   BEGIN
    numero = 0;
    kardexid = 0;
    doctoid = 0;
    movtoid = 0;
    productoid = 0;
    sucursalid = 0;
    fecha = current_date;
    fechahora = current_date;
    sucursalclave = '--';
    tipodoctoclave = '--';
    doctofolio = 0;
    productoclave = '--';
    productodescripcion = '-- sin movimientos --';
    cantidadini = 0;
    cantidadmov = 0;
    cantidadfin = 0;
    -- suspend; sin suspend es mejor, no regresa renglon falso
   END


END