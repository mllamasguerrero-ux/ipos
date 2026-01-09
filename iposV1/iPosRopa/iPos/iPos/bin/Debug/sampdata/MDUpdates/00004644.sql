CREATE TABLE SAT_PRODUCTOSERVICIO (
    ID                             D_PK NOT NULL,
    ACTIVO                         D_BOOLCS,
    CREADO                         D_TIMESTAMP,
    CREADOPOR_USERID               D_FK DEFAULT 0,
    MODIFICADO                     D_TIMESTAMP,
    MODIFICADOPOR_USERID           D_FK DEFAULT 0,
    SAT_CLAVEPRODSERV   D_CLAVE,
    SAT_DESCRIPCION     d_stdtext_large,
    SAT_FECHAINICIO     D_FECHA,
    SAT_FECHAFIN        D_FECHA,
    SAT_IVATRASLADADO   d_stdtext_short,
    SAT_IEPSTRASLADADO  d_stdtext_short,
    SAT_COMPLEMENTO     d_stdtext_medium
);


















