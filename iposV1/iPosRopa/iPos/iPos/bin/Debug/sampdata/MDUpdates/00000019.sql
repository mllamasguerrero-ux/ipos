create or alter procedure UPD_EXP_FILES_TRA (
    FOLIO D_DOCTOFOLIO)
returns (
    ERRORCODE D_ERRORCODE)
as
BEGIN

/* inserta los archivos de traslados a exportar */
INsERT INTO  EXP_FILES
(tipo,nombre,archivoftp,doctoid,doctofolio, fecha,estatus)
select 'T'  tipo,
      ('M' || docto.folio  || '.' || sucursal.clave ) nombre  ,
      ('M' || docto.folio  || '.' || sucursal.clave ) archivoftp ,
      docto.id doctoid,
      docto.folio doctofolio,
      docto.fecha fecha,
      'G'  as ESTATUS
      from docto
      inner join sucursal on sucursal.id = docto.sucursalid
      where tipodoctoid = 31  and   TRASLADOAFTP = 'N'  and docto.estatusdoctoid = 1 and docto.folio = :FOLIO;


      update docto set trasladoaftp = 'S'
      where tipodoctoid = 31 and trasladoaftp = 'N'  and docto.estatusdoctoid = 1 and docto.folio = :FOLIO;



   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1004;
      SUSPEND;
   END 
END