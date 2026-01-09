create or alter procedure REBAJAS_PROMODOCTO_MOVIL (
    FECHA_PAR D_FECHA,
    PERSONAID_PAR D_FK,
    PRODUCTOID_PAR D_FK,
    MARCAID_PAR D_FK,
    VENDEDORFINAL D_FK,
    ESTADO_REBAJA D_FK)
returns (
    DOCTOID D_FK,
    FECHA D_FECHA,
    DOCTOFOLIO D_DOCTOFOLIO,
    PERSONACLAVE D_CLAVE_NULL,
    PERSONANOMBRE D_NOMBRE_NULL,
    PERSONANOMBRES D_STDTEXT_MEDIUM,
    CAJEROCLAVE D_CLAVE_NULL,
    CAJERONOMBRE D_NOMBRE_NULL)
as
BEGIN

    FOR select
        docto.id,
        docto.fecha,
        docto.folio,
        persona.clave,
        persona.nombre, 
        persona.nombres,
        cajero.clave,
        cajero.nombre

        from docto left join movto on movto.doctoid = docto.id
        left join producto on producto.id = movto.productoid
        left join persona on docto.personaid = persona.id
        left join persona cajero on cajero.id = docto.vendedorid
        left join persona proveedor on producto.proveedor1id = proveedor.id
        left join marca on marca.id = producto.marcaid

        where docto.fecha >= :fecha_par
        and (:personaid_par = 0 or docto.personaid = :personaid_par )
        and (:productoid_par = 0 or movto.productoid = :productoid_par)
        and (:marcaid_par = 0 or producto.marcaid = :marcaid_par)
        and movto.cantidad > 0 and docto.estatusdoctoid = 0 and docto.tipodoctoid = 331
        and coalesce(movto.estadorebaja,0) in (COALESCE(:ESTADO_REBAJA,1))
        and (coalesce(:VENDEDORFINAL,0) = 0 or coalesce(docto.vendedorfinal,0) = coalesce(:VENDEDORFINAL,0))


        group by
        docto.id,
        docto.fecha,
        docto.folio,
        persona.clave,
        persona.nombre, 
        persona.nombres,
        cajero.clave,
        cajero.nombre
            
        INTO
        :DOCTOID,
      :FECHA ,
      :DOCTOFOLIO ,
      :PERSONACLAVE ,
      :PERSONANOMBRE ,
      :PERSONANOMBRES ,
      :CAJEROCLAVE ,
      :CAJERONOMBRE
      DO
      BEGIN

        SUSPEND;
      END

END