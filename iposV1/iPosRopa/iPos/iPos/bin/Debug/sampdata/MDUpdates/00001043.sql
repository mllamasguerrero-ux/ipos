create or alter procedure REPORTES_INSERTAR (
    ACTIVO char(4),
    CREADOPOR_USERID bigint,
    NOMBRE varchar(127),
    ARCHIVO varchar(255),
    DESCRIPCION varchar(255))
returns (
    REPORTEID type of D_FK,
    ERRORCODE type of D_ERRORCODE)
as
BEGIN




      INSERT INTO REPORTES
      (


        ACTIVO,

        CREADOPOR_USERID,

        NOMBRE,

        ARCHIVO,

        DESCRIPCION
         )

    Values (

        :ACTIVO,

        :CREADOPOR_USERID,

        :NOMBRE,

        :ARCHIVO,

        :DESCRIPCION
    )RETURNING ID INTO :REPORTEID;

    
   ERRORCODE = 0;
   SUSPEND;


  END