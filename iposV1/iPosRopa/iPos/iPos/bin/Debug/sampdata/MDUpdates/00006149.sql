create or alter procedure AJUSTEINICIALIZACIONMOVIL
as
BEGIN
    INSERT INTO IMP_FILES
      (

    IF_FILE ,
    IF_TIPO ,
    IF_STATUS ,
    IF_FECHA,
    IF_TIME,
    IF_REMOTE_FILE,
    IF_SUCURSALCLAVE,
    IF_SUCURSALID ,
    IF_REENVIADO
         )

Values (


    'PREC.zip' ,
    2 ,
    'C' ,
    CURRENT_DATE,
    CURRENT_TIME,
    'tiendas//PREC.zip',
    NULL,
    NULL,
    'N'
);

END