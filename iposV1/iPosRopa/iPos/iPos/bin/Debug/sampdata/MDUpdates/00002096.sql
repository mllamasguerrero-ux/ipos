create or alter procedure GET_KARDEX_REPORT_POR_LOTE (
    PRODUCTO_ID D_FK,
    LOTE D_LOTE)
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
    CANTIDADFIN D_CANTIDAD,
    PROVEEDORNOMBRE D_STDTEXT_LARGE,
    PROVEEDORNOMBRES D_STDTEXT_LARGE,
    CLIENTENOMBRE D_STDTEXT_LARGE,
    CLIENTENOMBRES D_STDTEXT_LARGE)
as
declare variable EXISTENCIAINICIAL D_CANTIDAD;
declare variable FECHAINICIAL D_FECHA;
declare variable CANTIDADMOVTOSINICIAL D_CANTIDAD;
BEGIN





   -- Tomar existencia inicial de INVENTARIO
   SELECT FIRST 1 sum(CANTIDADINICIAL), MIN(FECHAINICIAL)
   FROM INVENTARIO
   WHERE PRODUCTOID = :PRODUCTO_ID
   AND COALESCE(LOTE,'') = COALESCE(:LOTE,'')
   GROUP BY PRODUCTOID , LOTE
   INTO :EXISTENCIAINICIAL, :FECHAINICIAL;

   CANTIDADMOVTOSINICIAL = 0;
   NUMERO = 0;
   CANTIDADINI = 0;
   CANTIDADFIN = 0;

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
      TD.SENTIDOINVENTARIO * K.CANTIDAD   ,
      CASE WHEN D.tipodoctoid IN (11,12,13,14,15,16,17,18) THEN PR.nombre ELSE '' END PROVEEDORNOMBRE,
      CASE WHEN D.tipodoctoid IN (11,12,13,14,15,16,17,18) THEN COALESCE(PR.nombres,'') || ' ' || COALESCE(PR.apellidos,'') ELSE '' END PROVEEDORNOMBRES,
      CASE WHEN D.tipodoctoid NOT IN (11,12,13,14,15,16,17,18) THEN PR.nombre ELSE '' END CLIENTENOMBRE,
      CASE WHEN D.tipodoctoid NOT IN (11,12,13,14,15,16,17,18) THEN COALESCE(PR.nombres,'') || ' ' || COALESCE(PR.apellidos,'') ELSE '' END CLIENTENOMBRES

   FROM KARDEX K
      LEFT JOIN DOCTO D
         ON D.ID = K.DOCTOID
      LEFT JOIN TIPODOCTO TD
         ON TD.ID = D.TIPODOCTOID
      LEFT JOIN PRODUCTO P
         ON P.ID = K.PRODUCTOID/*K.PRODUCTOID*/
      LEFT JOIN SUCURSAL S
         ON S.ID = D.SUCURSALID
      LEFT JOIN PERSONA PR ON PR.ID = D.PERSONAID
   WHERE K.PRODUCTOID = :PRODUCTO_ID AND COALESCE(K.lote,'') = COALESCE(:LOTE, '')
   --ORDER BY D.fechahora, K.creadopor_userid
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
      :CANTIDADMOV  ,
      :PROVEEDORNOMBRE,
      :PROVEEDORNOMBRES,
      :CLIENTENOMBRE,
      :CLIENTENOMBRES
   DO
   BEGIN
      NUMERO = :NUMERO + 1;
      CANTIDADINI = :CANTIDADFIN ;
      CANTIDADFIN = :CANTIDADINI + :CANTIDADMOV;
      SUSPEND;
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
    PROVEEDORNOMBRE = '';
    PROVEEDORNOMBRES = '';
    CLIENTENOMBRE = '';
    CLIENTENOMBRES = '';
    -- suspend; sin suspend es mejor, no regresa renglon falso
   END


END