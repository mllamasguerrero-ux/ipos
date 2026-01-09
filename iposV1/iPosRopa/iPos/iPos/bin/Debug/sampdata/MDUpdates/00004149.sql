CREATE TABLE DESCLINEAPERS (
    ID                    D_PK NOT NULL,
    ACTIVO                D_BOOLCS,
    CREADO                D_TIMESTAMP,
    CREADOPOR_USERID      D_FK DEFAULT 0,
    MODIFICADO            D_TIMESTAMP,
    MODIFICADOPOR_USERID  D_FK DEFAULT 0,
    PERSONAID             D_FK,
    LINEAID               D_FK,
    DESCUENTO             D_PORCENTAJE
);