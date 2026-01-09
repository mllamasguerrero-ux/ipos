create or alter procedure BITACORACOBRANZADET_RECIBIR (
    BITACORACOBRANZADETID D_FK,
    BITACORACOBRANZAID D_FK,
    ESTADO D_FK,
    CAJEROID D_FK)
returns (
    ERRORCODE type of D_ERRORCODE)
as
declare variable CUENTARECIBIDA integer;
declare variable CUENTATOTAL integer;
BEGIN

  update bitacobranzadet set estado = :ESTADO where bitacobranzadet.id = :BITACORACOBRANZADETID;
  CUENTARECIBIDA = (select count(*) from bitacobranzadet where bitacobranzadet.bitcobranzaid = :bitacoracobranzaid and coalesce(estado,0) = 2);
  CUENTATOTAL = (SELECT count(*) from bitacobranzadet where bitacobranzadet.bitcobranzaid = :bitacoracobranzaid);

  IF(:CUENTARECIBIDA = :CUENTATOTAL)THEN
  BEGIN
    update bitacobranza set estado = 2 where  bitacobranza.id = :BITACORACOBRANZAID;
  END
  ELSE IF(:CUENTARECIBIDA > 0 AND :CUENTARECIBIDA < :CUENTATOTAL)THEN
  BEGIN
     update bitacobranza set estado = 5 where  bitacobranza.id = :BITACORACOBRANZAID;
  END
  ELSE IF(:CUENTARECIBIDA = 0)THEN
  BEGIN
     update bitacobranza set estado = 1 where  bitacobranza.id = :BITACORACOBRANZAID;
  END

   ERRORCODE = 0;
   SUSPEND;
END