create or alter procedure UPD_EXP_FILES_TRADEVO (
    FOLIO D_DOCTOFOLIO)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable COUNTEXISTE integer;
BEGIN


COUNTEXISTE = 0;

select count(*) cuenta from exp_files where TIPO = 'TD'  and DOCTOFOLIO = :FOLIO
into :COUNTEXISTE;

    if (COUNTEXISTE<=0) then
    BEGIN
        /* inserta los archivos de traslados a exportar */
        INsERT INTO  EXP_FILES
        (tipo,nombre,archivoftp,doctoid,doctofolio, fecha,estatus)
        select 'TD'  tipo,
        ('M' || docto.folio  || '.' || sucursal.clave ) nombre  ,
        ('M' || docto.folio  || '.' || sucursal.clave ) archivoftp ,
         docto.id doctoid,
         docto.folio doctofolio,
         docto.fecha fecha,
          'A'  as ESTATUS
         from docto
        inner join sucursal on sucursal.id = docto.sucursalid
        where tipodoctoid = 41  and   TRASLADOAFTP = 'N'  and docto.estatusdoctoid = 1 and docto.folio = :FOLIO;


    END
    ELSE
    BEGIN

        UPDATE exp_files set  ESTATUS = 'A'
         where TIPO = 'TD'  and DOCTOFOLIO = :FOLIO  ;

    END








    update docto set trasladoaftp = 'S'
    where tipodoctoid = 41 and trasladoaftp = 'N'  and docto.estatusdoctoid = 1 and docto.folio = :FOLIO;
 








   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1004;
      SUSPEND;
   END 
END