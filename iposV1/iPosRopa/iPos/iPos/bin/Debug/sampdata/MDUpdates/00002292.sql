create or alter procedure ACTUALIZAR_TABLA_IEPS_DOCTO (
    DOCTOID D_FK)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable IEPS_X_IMPORTE D_IMPORTE;
declare variable IEPS_X_PORC D_PORCENTAJE;
declare variable CUENTA integer;
declare variable MAX_FECHA D_FECHA;
declare variable MIN_FECHA D_FECHA;
declare variable REPETIDO integer;
declare variable FECHADOCTO D_FECHA;
declare variable CUENTAEXISTENTES INTEGER;
BEGIN

   CUENTA = 1;
   ERRORCODE = 0;


  FOR SELECT
       CASE WHEN COALESCE(M.ESKIT,'N') <> 'S' AND COALESCE(T.sentidoinventario,0) <> 0 THEN  coalesce(m.TASAIEPS, 0)  ELSE -1 END,
       COUNT(*) REPETIDO,
       MAX(D.FECHA) MAX_FECHA,
       MIN(D.FECHA) MIN_FECHA
       FROM DOCTO D
      LEFT JOIN MOVTO M
         ON  (M.DOCTOID = D.ID or M.DOCTOID = COALESCE(D.DOCTOKITREFID,0)) --(M.DOCTOID IN ( D.ID, COALESCE(D.doctokitrefid,0))  )
      LEFT JOIN TIPODOCTO T ON T.id = D.tipodoctoid
      WHERE   D.ID = :DOCTOID
    group by (CASE WHEN COALESCE(M.ESKIT,'N') <> 'S' AND COALESCE(T.sentidoinventario,0) <> 0 THEN  coalesce(m.TASAIEPS, 0)  ELSE -1 END)
    order by (CASE WHEN COALESCE(M.ESKIT,'N') <> 'S' AND COALESCE(T.sentidoinventario,0) <> 0 THEN  coalesce(m.TASAIEPS, 0)  ELSE -1 END) desc
    INTO :IEPS_X_PORC  , :REPETIDO , :MAX_FECHA, :MIN_FECHA
    DO
    BEGIN
        IF(COALESCE(:IEPS_X_PORC ,-1) <> -1) THEN
        BEGIN

            SELECT COUNT(*) FROM TASASIEPS WHERE TASA = :ieps_x_porc INTO :CUENTAEXISTENTES;

            IF(coalesce(:CUENTAEXISTENTES,0) = 0) THEN
            BEGIN
            
                INSERT INTO TASASIEPS(ACTIVO, TASA, CANTIDADREG, PRIMERAFECHA, ULTIMAFECHA)
                VALUES('S', :IEPS_X_PORC, :REPETIDO, :MIN_FECHA, :MAX_FECHA);
            END
            ELSE
            BEGIN
                UPDATE TASASIEPS SET CANTIDADREG = CANTIDADREG + 1,
                                     PRIMERAFECHA = MINVALUE(PRIMERAFECHA, :MIN_FECHA),
                                     ULTIMAFECHA = MAXVALUE(ULTIMAFECHA, :MAX_FECHA)
                                  WHERE TASA = :IEPS_X_PORC;
            END


        END

    END


    SUSPEND;


END