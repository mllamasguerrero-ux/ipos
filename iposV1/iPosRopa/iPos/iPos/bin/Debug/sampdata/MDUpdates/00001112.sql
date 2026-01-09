create or alter procedure UPDATE_EXP_FILES
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
      where tipodoctoid = 31  and   TRASLADOAFTP = 'N'  and docto.estatusdoctoid = 1;



        INsERT INTO  EXP_FILES
        (tipo,nombre,archivoftp,doctoid,doctofolio, fecha,estatus)
        select 'U'  tipo,
        ('M' || docto.folio  || '.' || sucursal.clave || '.zip') nombre  ,
        ('M' || docto.folio  || '.' || sucursal.clave || '.zip') archivoftp ,
         docto.id doctoid,
         docto.folio doctofolio,
         docto.fecha fecha,
          'G'  as ESTATUS
         from docto
        inner join sucursal on sucursal.id = docto.sucursalid
        where tipodoctoid = 31  and   TRASLADOAFTP = 'N'  and docto.estatusdoctoid = 1;



      update docto set trasladoaftp = 'S'
      where tipodoctoid = 31 and trasladoaftp = 'N'  and docto.estatusdoctoid = 1;




  /* inserta los archivos de pedidos a exportar */
      insert into exp_files
       (tipo,nombre,archivoftp,turnoid, fecha,estatus)
      select 'P' as tipo,
             ('veds' || EXTRACT(DAY FROM (fechas.dia)) || turno.id || '.dbf') nombre,
             ('veds' || EXTRACT(DAY FROM (fechas.dia)) || turno.id || '.dbf') archivoftp,
              turno.id turnoid,  
             fechas.dia  as fecha,
              'A' as estatus
              from turno
              cross join
              --here we should put all the dates that we want to process
              fechashabiles fechas
              where turno.id <> 4 and  fechas.dia < current_date and fechas.dia > current_date - 3
                  and  (select count(*) cuenta from exp_files where tipo = 'P'
                                                               and fecha = (fechas.dia)
                                                               and turnoid = turno.id) = 0;



         /* inserta los archivos de ventas a exportar */

               insert into exp_files
       (tipo,nombre,archivoftp, fecha,estatus)
      select 'V' as tipo,
             ('vedm' || EXTRACT(DAY FROM (fechas.dia))  || '.dbf') nombre,
             ('vedm' || EXTRACT(DAY FROM (fechas.dia))  || '.dbf') archivoftp,
             fechas.dia  as fecha,
              'A' as estatus
              from
              --here we should put all the dates that we want to process
              fechashabiles fechas
              where fechas.dia < current_date and fechas.dia > current_date - 3
                  and  (select count(*) cuenta from exp_files where tipo = 'V'
                                                               and fecha = (fechas.dia)) = 0;




   /* inserta los archivos de rec compras a exportar */
INsERT INTO  EXP_FILES
(tipo,nombre,archivoftp,doctoid,doctofolio, fecha,estatus)
select 'R'  tipo,
      ( 'R' || docto.id  || '.dbf' ) nombre  ,
      ( 'R' || docto.id  || '.dbf' ) archivoftp ,
      docto.id doctoid,
      docto.folio doctofolio,
      docto.fecha fecha,
      'A'  as ESTATUS
      from docto
      inner join sucursal on sucursal.id = docto.sucursalid
      where tipodoctoid = 11  and   TRASLADOAFTP = 'N'  and docto.estatusdoctoid = 1;


      update docto set trasladoaftp = 'S'
      where tipodoctoid = 11 and trasladoaftp = 'N'  and docto.estatusdoctoid = 1  ;

   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1004;
      SUSPEND;
   END 
END