create or alter procedure UPD_EXP_FILES_MATRIZPEDIDOS (
    FOLIO D_DOCTOFOLIO)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable COUNTEXISTE integer;
BEGIN


COUNTEXISTE = 0;

select count(*) cuenta from exp_files where TIPO = 'Z'  and DOCTOFOLIO = :FOLIO
into :COUNTEXISTE;

    if (COUNTEXISTE<=0) then
    BEGIN

        /* inserta los archivos de traslados a exportar */
        INsERT INTO  EXP_FILES
        (tipo,nombre,archivoftp,doctoid,doctofolio, fecha,estatus)
        select 'Z'  tipo,
        ('V' || LPAD(coalesce(cast(docto.folio as varchar(20)),''),5,'0') || '.dbf' ) nombre  ,
        ('V' || LPAD(coalesce(cast(docto.folio as varchar(20)),''),5,'0')  || '.dbf' ) archivoftp ,
         docto.id doctoid,
         docto.folio doctofolio,
         docto.fecha fecha,
          'G'  as ESTATUS
         from docto
        inner join sucursal on sucursal.id = docto.sucursalid
        where tipodoctoid = 81  and   coalesce(TRASLADOAFTP,'N') = 'N'  and docto.estatusdoctoid = 1 and docto.folio = :FOLIO;


    END
    ELSE
    BEGIN

        UPDATE exp_files set  ESTATUS = 'G'
         where TIPO = 'Z'  and DOCTOFOLIO = :FOLIO  ;

    END

          /* ahora con el archivo auxiliar de catalogos del pedido */

    COUNTEXISTE = 0;

select count(*) cuenta from exp_files where TIPO = 'Y'  and DOCTOFOLIO = :FOLIO
into :COUNTEXISTE;

    if (COUNTEXISTE<=0) then
    BEGIN

        /* inserta los archivos de traslados a exportar */
        INsERT INTO  EXP_FILES
        (tipo,nombre,archivoftp,doctoid,doctofolio, fecha,estatus)
        select 'Y'  tipo,
        ('V' || LPAD(coalesce(cast(docto.folio as varchar(20)),''),5,'0') || '.zip' ) nombre  ,
        ('V' || LPAD(coalesce(cast(docto.folio as varchar(20)),''),5,'0')  || '.zip' ) archivoftp ,
         docto.id doctoid,
         docto.folio doctofolio,
         docto.fecha fecha,
          'G'  as ESTATUS
         from docto
        inner join sucursal on sucursal.id = docto.sucursalid
        where tipodoctoid = 81  and   coalesce(TRASLADOAFTP,'N') = 'N'  and docto.estatusdoctoid = 1 and docto.folio = :FOLIO;


    END
    ELSE
    BEGIN

        UPDATE exp_files set  ESTATUS = 'G'
         where TIPO = 'Y'  and DOCTOFOLIO = :FOLIO  ;

    END





    update docto set trasladoaftp = 'S'
    where tipodoctoid = 81 and trasladoaftp = 'N'  and docto.estatusdoctoid = 1 and docto.folio = :FOLIO;
 


   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1004;
      SUSPEND;
   END 
END