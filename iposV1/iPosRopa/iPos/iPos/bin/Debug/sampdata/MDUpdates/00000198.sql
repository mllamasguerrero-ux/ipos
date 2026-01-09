CREATE OR ALTER VIEW TICKET_HEADER(
    DOCTOID,
    ESTATUSDOCTOID,
    ALMACENID,
    SUCURSALID,
    PERSONAID,
    TIPODOCTOID,
    TOTAL,
    NOMBRE,
    DESCRIPCION,
    RFC,
    COLONIA,
    DOMICICIO,
    CODIGOPOSTAL,
    RAZON_SOCIAL,
    TELEFONO,
    CIUDAD,
    ESTADO,
    MUNICIPIO,
    TICKET,
    SUCURSALTID,
    VENDEDORID)
AS
SELECT
      DOCTO.ID DOCTOID,
      DOCTO.ESTATUSDOCTOID,
      DOCTO.ALMACENID,
      DOCTO.SUCURSALID,
      DOCTO.PERSONAID,
      DOCTO.TIPODOCTOID,
      DOCTO.TOTAL   ,
      SUCURSAL.nombre         NOMBRE,
      SUCURSAL.descripcion    DESCRIPCION,


      P.rfc                     RFC,
      P.colonia                 COLONIA,
      P.calle                   DOMICICIO,
      'Codigo postal'           CODIGOPOSTAL,
      'Razon Social'            RAZON_SOCIAL,
      P.telefono                TELEFONO,
      P.localidad               CIUDAD,
      P.estado                  ESTADO,
      P.localidad               MUNICIPIO ,
      DOCTO.folio               TICKET ,
      DOCTO.SUCURSALTID          ,
      DOCTO.vendedorid          VENDEDORID

   FROM DOCTO  LEFT JOIN SUCURSAL ON SUCURSAL.ID = DOCTO.SUCURSALID
        left join parametro P on p.sucursalid = sucursal.id