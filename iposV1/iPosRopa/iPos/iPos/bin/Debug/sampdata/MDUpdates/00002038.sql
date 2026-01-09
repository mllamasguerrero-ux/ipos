create or alter procedure MOVIL_ESTA_FINALIZADO
returns (
    ESTAFINALIZADO D_BOOLCN,
    ERRORCODE D_ERRORCODE)
as
declare variable HAYCAMBIOS D_BOOLCN;
declare variable MAXFOLIOVENTA integer;
declare variable MAXFOLIOCOBRANZA integer;
declare variable LASTFINALIZEDFOLIOVENTA integer;
declare variable LASTFINALIZEDFOLIOCOBRANZA integer;
declare variable TIPOSYNCMOVIL D_TIPOSYNCMOVIL;
BEGIN


    select HAYCAMBIOS FROM movto_haypendientes_export INTO :haycambios;

    if(coalesce(:haycambios, 'N') = 'S') then
    begin
        ESTAFINALIZADO = 'N';
        ERRORCODE = 0;
        SUSPEND;
        EXIT;
    end

    MAXFOLIOVENTA = 0;
    MAXFOLIOCOBRANZA = 0;
    LASTFINALIZEDFOLIOVENTA = 0;
    LASTFINALIZEDFOLIOCOBRANZA = 0;

    
    SELECT  MAX(TIPOSYNCMOVIL), max(parametro.movilcierrecobranza), max(parametro.movilcierreventa)
     FROM parametro INTO :TIPOSYNCMOVIL, :LASTFINALIZEDFOLIOCOBRANZA, :LASTFINALIZEDFOLIOVENTA;

    select max(pagomovil.id) from PAGOMOVIL where ESTATUS = 1 and TIPOPAGOID = 5
    into :MAXFOLIOCOBRANZA ;

    IF(COALESCE(:MAXFOLIOCOBRANZA,0) > coalesce(:LASTFINALIZEDFOLIOCOBRANZA,0) ) THEN
    BEGIN
        ESTAFINALIZADO = 'N';
        ERRORCODE = 0;
        SUSPEND;
        EXIT;
    END


     IF(COALESCE(:TIPOSYNCMOVIL,'WS') = 'WS') THEN
     BEGIN

        select max(docto.folio) from DOCTO where ESTATUSDOCTOID = 1 AND TIPODOCTOID = 321
        into :MAXFOLIOVENTA ;

        IF(COALESCE(:MAXFOLIOVENTA,0) > coalesce(:LASTFINALIZEDFOLIOVENTA,0) ) THEN
        BEGIN
            ESTAFINALIZADO = 'N';
            ERRORCODE = 0;
            SUSPEND;
            EXIT;
        END

     END

       ESTAFINALIZADO = 'S';
       ERRORCODE = 0;
       SUSPEND;


END
