CREATE TABLE TIPOENTREGA (
    ID                    D_PK NOT NULL,
    ACTIVO                D_BOOLCS,
    CREADO                D_TIMESTAMP,
    CREADOPOR_USERID      D_FK,
    MODIFICADO            D_TIMESTAMP,
    MODIFICADOPOR_USERID  D_FK,
    CLAVE                 D_CLAVE,
    NOMBRE                D_NOMBRE
);
