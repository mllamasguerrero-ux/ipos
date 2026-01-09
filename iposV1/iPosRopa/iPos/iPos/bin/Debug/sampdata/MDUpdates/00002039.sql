create or alter procedure MOVTO_HAYPENDIENTES_EXPORT
returns (
    HAYCAMBIOS D_BOOLCN,
    ERRORCODE D_ERRORCODE)
as
declare variable CUENTAPENDIENTES integer;
declare variable TIPOSYNCMOVIL D_TIPOSYNCMOVIL;
BEGIN

    CUENTAPENDIENTES = 0;

    select COUNT(*) from PAGOMOVIL where ESTATUS = 1 AND ENVIADOWS <> 'S'  and TIPOPAGOID = 5
    into :CUENTAPENDIENTES ;

    IF(COALESCE(:CUENTAPENDIENTES,0) > 0 ) THEN
    BEGIN
        HAYCAMBIOS = 'S';
        ERRORCODE = 0;
        SUSPEND;
        EXIT;
    END

    SELECT  MAX(TIPOSYNCMOVIL) FROM parametro INTO :TIPOSYNCMOVIL;

     IF(COALESCE(:TIPOSYNCMOVIL,'WS') = 'WS') THEN
     BEGIN

        select COUNT(*) from DOCTO where ESTATUSDOCTOID = 1 AND TIPODOCTOID = 321 AND TRASLADOAFTP <> 'S'
        into :CUENTAPENDIENTES ;
        IF(COALESCE(:CUENTAPENDIENTES,0) > 0 ) THEN
        BEGIN
            HAYCAMBIOS = 'S';
            ERRORCODE = 0;
            SUSPEND;
            EXIT;
        END

     END


       ERRORCODE = 0;
       SUSPEND;


END
