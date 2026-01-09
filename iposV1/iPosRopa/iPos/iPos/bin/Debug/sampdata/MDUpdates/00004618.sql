CREATE TABLE SAT_TIPORELACION (
    ID                             D_PK NOT NULL,
    ACTIVO                         D_BOOLCS,
    CREADO                         D_TIMESTAMP,
    CREADOPOR_USERID               D_FK DEFAULT 0,
    MODIFICADO                     D_TIMESTAMP,
    MODIFICADOPOR_USERID           D_FK DEFAULT 0,
    SAT_CLAVE        D_CLAVE,
    SAT_DESCRIPCION  D_STDTEXT_MEDIUM
);





















