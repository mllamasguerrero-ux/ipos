create or alter procedure LIMPIARIMPORTACIONCATALOGOS
as
BEGIN
  delete from imp_files where if_tipo = 2 and if_status = 'B';
END