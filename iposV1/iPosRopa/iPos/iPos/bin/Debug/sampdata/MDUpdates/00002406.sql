create or alter procedure REBAJAS_PROMOVIDAS (
    FECHA_PAR D_FECHA,
    PERSONAID_PAR D_FK,
    PRODUCTOID_PAR D_FK,
    MARCAID_PAR D_FK)
returns (
    NUMERO integer,
    FECHA D_FECHA,
    DOCTOFOLIO D_DOCTOFOLIO,
    PERSONACLAVE D_CLAVE,
    PERSONANOMBRE D_NOMBRE,
    PERSONANOMBRES D_STDTEXT_MEDIUM,
    CAJEROCLAVE D_CLAVE,
    CAJERONOMBRE D_NOMBRE,
    PRODUCTOCLAVE D_CLAVE,
    PRODUCTONOMBRE D_NOMBRE,
    PRODUCTODESCRIPCION D_DESCRIPCION,
    MARCACLAVE D_CLAVE,
    MARCANOMBRE D_NOMBRE,
    CANTIDAD D_CANTIDAD,
    PRECIO_SINIMP_SINREBAJA D_PRECIO,
    PRECIO_CONIMP_SINREBAJA D_PRECIO,
    TOTAL_SINREBAJA D_IMPORTE,
    PRECIO_SINIMP_CONREBAJA D_PRECIO,
    PRECIO_CONIMP_CONREBAJA D_PRECIO,
    TOTALCONREBAJA D_IMPORTE,
    DIFERENCIA D_IMPORTE,
    CANTAUTREBAJA D_CANTIDAD,
    ESTADOREBAJA D_FK,
    DOCTOID D_FK,
    MOVTOID D_FK)
as
BEGIN
   NUMERO = 0;


   FOR select
        docto.fecha,
        docto.folio,
        persona.clave,
        persona.nombre, 
        persona.nombres,
        cajero.clave,
        cajero.nombre,
        producto.clave, 
        producto.nombre, 
        producto.descripcion,
        marca.clave as marcaclave,
        marca.nombre as marcanombre,
        coalesce(movto.cantidad,0) - coalesce(movto.cantidaddevuelta,0) cantidad,
        movto.precio precio_sinimp_sinrebaja,
        movto.total/movto.cantidad precio_conimp_sinrebaja  ,
        movto.total total_sinrebaja,
        movto.precioconrebaja precio_sinimp_conrebaja,
        movto.totalconrebaja/movto.cantidad precio_conimp_conrebaja ,
        movto.totalconrebaja,
        movto.total - movto.totalconrebaja diferencia ,
        movto.cantautrebaja  ,
        movto.estadorebaja ,
        MOVTO.DOCTOID DOCTOID  ,
        MOVTO.ID

        from docto left join movto on movto.doctoid = docto.id
        left join producto on producto.id = movto.productoid
        left join persona on docto.personaid = persona.id
        left join persona cajero on cajero.id = docto.vendedorid
        left join marca on marca.id = producto.marcaid

        where docto.fecha >= :fecha_par
        and (:personaid_par = 0 or docto.personaid = :personaid_par )
        and (:productoid_par = 0 or movto.productoid = :productoid_par)
        and (:marcaid_par = 0 or producto.marcaid = :marcaid_par)
        and movto.cantidad > 0 and docto.estatusdoctoid = 1 and docto.tipodoctoid = 21
        and movto.estadorebaja = 1

   INTO
      :FECHA ,
      :DOCTOFOLIO ,
      :PERSONACLAVE ,
      :PERSONANOMBRE ,
      :PERSONANOMBRES ,
      :CAJEROCLAVE ,
      :CAJERONOMBRE ,
      :PRODUCTOCLAVE ,
      :PRODUCTONOMBRE ,
      :PRODUCTODESCRIPCION ,
      :MARCACLAVE ,
      :MARCANOMBRE ,
      :CANTIDAD ,
      :PRECIO_SINIMP_SINREBAJA ,
      :PRECIO_CONIMP_SINREBAJA  ,
      :TOTAL_SINREBAJA ,
      :PRECIO_SINIMP_CONREBAJA ,
      :PRECIO_CONIMP_CONREBAJA  ,
      :TOTALCONREBAJA ,
      :DIFERENCIA ,
      :CANTAUTREBAJA ,
      :ESTADOREBAJA  ,
      :DOCTOID  ,
      :MOVTOID
   DO
   BEGIN
      NUMERO = :NUMERO + 1;
      SUSPEND;
   END

   if (:numero = 0) then
   begin
        FECHA = CURRENT_DATE;
        DOCTOFOLIO  = 0;
        PERSONACLAVE = '';
        PERSONANOMBRE  = '';
        PERSONANOMBRES  = '';
        CAJEROCLAVE  = '';
        CAJERONOMBRE  = '';
        PRODUCTOCLAVE  = '';
        PRODUCTONOMBRE  = '';
        PRODUCTODESCRIPCION  = '';
        MARCACLAVE  = '';
        MARCANOMBRE  = '';
        CANTIDAD  = 0;
        PRECIO_SINIMP_SINREBAJA  = 0;
        PRECIO_CONIMP_SINREBAJA  = 0;
        TOTAL_SINREBAJA  = 0;
        PRECIO_SINIMP_CONREBAJA  = 0;
        PRECIO_CONIMP_CONREBAJA   = 0;
        TOTALCONREBAJA  = 0;
        DIFERENCIA  = 0;
        ESTADOREBAJA = 0;
        CANTAUTREBAJA = 0;
        DOCTOID = 0;
        MOVTOID = 0;

   end

END