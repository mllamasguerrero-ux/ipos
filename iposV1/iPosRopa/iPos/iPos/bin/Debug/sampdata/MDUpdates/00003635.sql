create or alter procedure REP_CORTESUM_GRUPOFECHA (
    FECHA D_FECHA)
returns (
    TITULO D_CLAVE_NULL,
    SUCURSAL D_CLAVE_NULL,
    FECHACORTE D_FECHA,
    GRUPOUSUARIOID D_FK,
    CLAVEGRUPOUSUARIO D_CLAVE_NULL,
    NOMBREGRUPOUSUARIO D_NOMBRE_NULL,
    NUMERO_TICKETS integer,
    NUMERO_DEVOLUCIONES integer,
    SUBTOTAL D_PRECIO,
    IVA D_PRECIO,
    MONTOIEPS D_PRECIO,
    TOTAL D_PRECIO,
    INGRESO_TARJETA D_PRECIO,
    INGRESO_EFECTIVO D_PRECIO,
    INGRESO_CREDITO D_PRECIO,
    INGRESO_VALE D_PRECIO,
    INGRESO_CHEQUE D_PRECIO,
    CAMBIO_CHEQUE D_PRECIO,
    EGRESO D_PRECIO,
    ACTIVO D_BOOLCN_NULL,
    SUBTOTALCONIVA D_PRECIO,
    SUBTOTALSINIVA D_PRECIO,
    TASAIEPS_ D_PRECIO,
    MONTOIEPS_ D_PRECIO,
    DESGLOSEIEPS D_BOOLCN_NULL,
    TOTALTRASLADOS D_PRECIO,
    TOTALSINTRASLADOS D_PRECIO,
    SALDOFINAL D_PRECIO,
    INGRESO D_PRECIO)
as
declare variable NUMERO integer;
BEGIN
   NUMERO = 0;





   FOR
      SELECT
        maintable.TITULO, 
        coalesce(maintable.SUCURSAL,''),
        maintable.FECHACORTE, 
        maintable.GRUPOUSUARIOID ,
        coalesce(maintable.CLAVEGRUPOUSUARIO,''),
        coalesce(maintable.NOMBREGRUPOUSUARIO,''),
        maintable.NUMERO_TICKETS, 
        maintable.NUMERO_DEVOLUCIONES, 
        maintable.SUBTOTAL, 
        maintable.IVA, 
        maintable.MONTOIEPS, 
        maintable.TOTAL,
        maintable.INGRESO_TARJETA, 
        maintable.INGRESO_EFECTIVO,
        maintable.INGRESO_CREDITO, 
        maintable.INGRESO_VALE,
        maintable.INGRESO_CHEQUE, 
        maintable.CAMBIO_CHEQUE, 
        maintable.EGRESO , 
        coalesce(maintable.ACTIVO,'N'),
        maintable.SUBTOTALCONIVA,
        maintable.SUBTOTALSINIVA,
        COALESCE(detailtable.TASAIEPS_,0),
        COALESCE(detailtable.MONTOIEPS_,0),
        PARAMETRO.DESGLOSEIEPS,
        maintable.ventatraslados TOTALTRASLADOS,
        maintable.total - coalesce(maintable.ventatraslados, 0) totalsintraslados,
        --cortetraslados.TOTALTRASLADOS,
        --(maintable.total - case when cortetraslados.totaltraslados is null then 0 else cortetraslados.totaltraslados end) as TOTALSINTRASLADOS ,
        maintable.SALDOFINAL ,
        maintable.INGRESO
         FROM
        (
                 SELECT 'CORTE SUMARIZADO' AS TITULO, sucursal.clave AS SUCURSAL,
                        corte.fechacorte, 
                        persona.grupousuarioid ,
                        gu.clave clavegrupousuario,
                        gu.nombre nombregrupousuario,
                        SUM(CORTE.NUMEROTICKETS) AS NUMERO_TICKETS, 
                         SUM(CORTE.NUMERODEVOLUCIONES) AS NUMERO_DEVOLUCIONES,
                         SUM(CASE WHEN (corte.subtotalsiniva + corte.subtotalconiva) IS NOT NULL 
                            THEN (corte.subtotalsiniva + corte.subtotalconiva) ELSE INGRESOSUBTOTAL END) AS SUBTOTAL,
                         SUM(CASE WHEN corte.montoiva IS NOT NULL 
                            THEN corte.montoiva ELSE INGRESOPORIVA END) AS IVA, SUM(CASE WHEN corte.montoieps IS NOT NULL THEN corte.montoieps ELSE 0 END) AS montoieps, 
                         SUM(CASE WHEN (corte.subtotalsiniva + corte.subtotalconiva + (corte.montoiva  + corte.montoieps)) IS NOT NULL THEN (corte.subtotalsiniva + corte.subtotalconiva  + (corte.montoiva  + corte.montoieps)) ELSE INGRESO END) AS TOTAL,
                         SUM(CORTE.INGRESOTARJETA) AS INGRESO_TARJETA, SUM(CORTE.INGRESOEFECTIVO) AS INGRESO_EFECTIVO,
                         SUM(CORTE.INGRESOCREDITO) AS INGRESO_CREDITO, SUM(CORTE.INGRESOVALE) AS INGRESO_VALE, SUM(CORTE.INGRESOCHEQUE) AS INGRESO_CHEQUE, 
                         SUM(CORTE.CAMBIOCHEQUE) AS CAMBIO_CHEQUE, SUM(CORTE.EGRESO) AS EGRESO , max(CORTE.ACTIVO) ACTIVO,
                        SUM(CORTE.SUBTOTALCONIVA) SUBTOTALCONIVA, SUM(CORTE.SUBTOTALSINIVA) SUBTOTALSINIVA,
                         SUM(COALESCE(CORTE.saldofinal,0)) SALDOFINAL ,
                         SUM(COALESCE(CORTE.ingreso, 0)) INGRESO  ,
                         SUM(COALESCE(CORTE.ventatraslados, 0)) VENTATRASLADOS
                    FROM CORTE LEFT OUTER JOIN
                         sucursal ON sucursal.id = CORTE.SUCURSALID
                         left outer join persona on persona.id = corte.cajeroid
                         left outer join grupousuario gu on gu.id = persona.grupousuarioid
                    WHERE        (CORTE.FECHACORTE = :fecha)
                    GROUP BY sucursal.clave, corte.fechacorte, persona.grupousuarioid, gu.clave,  gu.nombre , CORTE.ACTIVO
        ) maintable
        left join
        (
            select
                cf.tasaieps  TASAIEPS_,
                sum(cf.monto) MONTOIEPS_,
                c.fechacorte,
                persona.grupousuarioid ,
                gu.clave clavegrupousuario,
                gu.nombre nombregrupousuario
            from CORTEieps cf
                inner join corte c on c.id = cf.corteid
                left outer join persona on persona.id = c.cajeroid
                left outer join grupousuario gu on gu.id = persona.grupousuarioid
            group by  cf.tasaieps  ,
                c.fechacorte,
                persona.grupousuarioid ,
                gu.clave ,
                gu.nombre
            order by c.fechacorte


        ) detailtable on  maintable.FECHACORTE = DETAILTABLE.FECHACORTE and  coalesce(maintable.grupousuarioid,0) = coalesce(DETAILTABLE.grupousuarioid,0)
        left join
        (
            SELECT  corte.fechacorte, persona.grupousuarioid , gu.clave clavegrupousuario,  gu.nombre nombregrupousuario, sum(docto.total) totaltraslados
            FROM    corte left outer join        
                    docto on docto.corteid = corte.id   
                left outer join persona on persona.id = corte.cajeroid
                left outer join grupousuario gu on gu.id = persona.grupousuarioid
            WHERE corte.fechacorte = :fecha and (docto.tipodoctoid = 31) and ( docto.subtipodoctoid is null or docto.subtipodoctoid <> 8)
            group by  corte.fechacorte, persona.grupousuarioid , gu.clave ,  gu.nombre
        )  cortetraslados on maintable.FECHACORTE = DETAILTABLE.FECHACORTE and  coalesce(maintable.grupousuarioid,0) = coalesce(CORTETRASLADOS.grupousuarioid,0)

        LEFT JOIN PARAMETRO ON 1 = 1
        INTO
     :TITULO ,
    :SUCURSAL,
    :FECHACORTE ,
    :GRUPOUSUARIOID ,
    :CLAVEGRUPOUSUARIO,
    :NOMBREGRUPOUSUARIO,
    :NUMERO_TICKETS ,
    :NUMERO_DEVOLUCIONES ,
    :SUBTOTAL ,
    :IVA ,
    :MONTOIEPS ,
    :TOTAL,
    :INGRESO_TARJETA ,
    :INGRESO_EFECTIVO,
    :INGRESO_CREDITO ,
    :INGRESO_VALE,
    :INGRESO_CHEQUE ,
    :CAMBIO_CHEQUE ,
    :EGRESO  ,
    :ACTIVO,
    :SUBTOTALCONIVA ,
    :SUBTOTALSINIVA,
    :TASAIEPS_,
    :MONTOIEPS_,
    :DESGLOSEIEPS,
    :TOTALTRASLADOS,
    :TOTALSINTRASLADOS ,
    :SALDOFINAL,
    :INGRESO


   DO
   BEGIN

      NUMERO = :NUMERO + 1;
      SUSPEND;
   END

   if (:numero = 0) then
   begin
      numero = 0;
          TITULO  = '' ;
    SUCURSAL    =    '' ;
    FECHACORTE  = CURRENT_DATE ;
    GRUPOUSUARIOID  = '' ;
    CLAVEGRUPOUSUARIO    =    '' ;
    NOMBREGRUPOUSUARIO    =    '' ;
    NUMERO_TICKETS  = 0 ;
    NUMERO_DEVOLUCIONES  = 0 ;
    SUBTOTAL  = 0 ;
    IVA  = 0 ;
    MONTOIEPS  = 0 ;
    TOTAL    =    0 ;
    INGRESO_TARJETA  = 0 ;
    INGRESO_EFECTIVO    =    0 ;
    INGRESO_CREDITO  = 0 ;
    INGRESO_VALE    =    0 ;
    INGRESO_CHEQUE  = 0 ;
    CAMBIO_CHEQUE  = 0 ;
    EGRESO   = 0 ;
    ACTIVO    =    '' ;
    SUBTOTALCONIVA  = 0 ;
    SUBTOTALSINIVA    =    0 ;
    TASAIEPS_    =    0 ;
    MONTOIEPS_    =    0 ;
    TOTALTRASLADOS    =    0 ;
    TOTALSINTRASLADOS    =    0;
    SALDOFINAL = 0;
    INGRESO = 0;


   end

END