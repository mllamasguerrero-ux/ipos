create or alter procedure REP_VENTA_CONIEPS_TASAS
returns (
    NUMERO integer,
    IEPS_01_PORC D_PORCENTAJE,
    IEPS_02_PORC D_PORCENTAJE,
    IEPS_03_PORC D_PORCENTAJE,
    IEPS_04_PORC D_PORCENTAJE,
    IEPS_05_PORC D_PORCENTAJE,
    IEPS_06_PORC D_PORCENTAJE,
    IEPS_07_PORC D_PORCENTAJE,
    IEPS_08_PORC D_PORCENTAJE,
    IEPS_09_PORC D_PORCENTAJE,
    IEPS_10_PORC D_PORCENTAJE)
as
declare variable IEPS_X_IMPORTE D_IMPORTE;
declare variable IEPS_X_PORC D_PORCENTAJE;
declare variable CUENTA integer;
BEGIN


   NUMERO = 0;
   CUENTA = 1;


    IEPS_01_PORC  = -1;
    IEPS_02_PORC  = -1;
    IEPS_03_PORC  = -1;
    IEPS_04_PORC  = -1;
    IEPS_05_PORC  = -1;
    IEPS_06_PORC  = -1;
    IEPS_07_PORC  = -1;
    IEPS_08_PORC  = -1;
    IEPS_09_PORC  = -1;
    IEPS_10_PORC  = -1;





  FOR SELECT
       coalesce(m.TASAIEPS, 0)
       FROM MOVTO M
      LEFT JOIN DOCTO D
         ON D.ID = M.DOCTOID
      WHERE/* ( D.TIPODOCTOID = :TIPODOCTOID  OR (:TIPODOCTOID = -21 AND D.TIPODOCTOID IN (21,31,23))
          OR (:TIPODOCTOID = -31 AND d.TIPODOCTOID IN (31,81)) )
     AND D.FECHA BETWEEN :FECHAINI AND :FECHAFIN
     AND*/ D.ESTATUSDOCTOID = 1
    group by m.tasaieps
    order by m.tasaieps desc
    INTO :IEPS_X_PORC
    DO
    BEGIN
        IF(:CUENTA = 1 ) THEN
        BEGIN
            IEPS_01_PORC =  :IEPS_X_PORC;
        END        
        IF(:CUENTA = 2 ) THEN
        BEGIN
            IEPS_02_PORC =  :IEPS_X_PORC;
        END        
        IF(:CUENTA = 3 ) THEN
        BEGIN
            IEPS_03_PORC =  :IEPS_X_PORC;
        END 
        IF(:CUENTA = 4 ) THEN
        BEGIN
            IEPS_04_PORC =  :IEPS_X_PORC;
        END 
        IF(:CUENTA = 5 ) THEN
        BEGIN
            IEPS_05_PORC =  :IEPS_X_PORC;
        END 
        IF(:CUENTA = 6 ) THEN
        BEGIN
            IEPS_06_PORC =  :IEPS_X_PORC;
        END 
        IF(:CUENTA = 7 ) THEN
        BEGIN
            IEPS_07_PORC =  :IEPS_X_PORC;
        END 
        IF(:CUENTA = 8 ) THEN
        BEGIN
            IEPS_08_PORC =  :IEPS_X_PORC;
        END 
        IF(:CUENTA = 9 ) THEN
        BEGIN
            IEPS_09_PORC =  :IEPS_X_PORC;
        END 
        IF(:CUENTA = 10 ) THEN
        BEGIN
            IEPS_10_PORC =  :IEPS_X_PORC;
        END
        CUENTA = CUENTA + 1;

    END

        SUSPEND;




   if (:numero = 0) then
   begin
      numero = 0;
      IEPS_01_PORC  = NULL;
      IEPS_02_PORC   = NULL;
      IEPS_03_PORC    = NULL;
      IEPS_04_PORC    = NULL;
      IEPS_05_PORC    = NULL;
      IEPS_06_PORC    = NULL;
      IEPS_07_PORC    = NULL;
      IEPS_08_PORC    = NULL;
      IEPS_09_PORC    = NULL;
      IEPS_10_PORC    = NULL;



   end

END