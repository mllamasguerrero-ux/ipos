CREATE TABLE SAT_TIPOCOMPROBANTE (
    ID                             D_PK NOT NULL,
    ACTIVO                         D_BOOLCS,
    CREADO                         D_TIMESTAMP,
    CREADOPOR_USERID               D_FK DEFAULT 0,
    MODIFICADO                     D_TIMESTAMP,
    MODIFICADOPOR_USERID           D_FK DEFAULT 0,
    SAT_CLAVE        D_CLAVE,
    SAT_DESCRIPCION  d_stdtext_short,
    SAT_VALORMAXIMO  d_integer,
    SAT_FECHAINICIO  D_FECHA,
    SAT_FECHAFIN     D_FECHA,
    SAT_NS           d_stdtext_short,
    SAT_NDS          d_stdtext_short
);




















