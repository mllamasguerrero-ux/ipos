CREATE TABLE CONTENIDO (
    ID                    D_PK NOT NULL,
    ACTIVO                D_BOOLCS,
    CREADO                D_TIMESTAMP,
    CREADOPOR_USERID      D_FK DEFAULT 0,
    MODIFICADO            D_TIMESTAMP,
    MODIFICADOPOR_USERID  D_FK DEFAULT 0,
    CLAVE                 D_CLAVE_UNI,
    NOMBRE                D_NOMBRE
);