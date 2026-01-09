CREATE TABLE STOCKALMACEN (
    ID                    D_PK NOT NULL,
    ACTIVO                D_BOOLCS,
    CREADO                D_TIMESTAMP,
    CREADOPOR_USERID      D_FK DEFAULT 0,
    MODIFICADO            D_TIMESTAMP,
    MODIFICADOPOR_USERID  D_FK DEFAULT 0,
    PRODUCTOID            D_FK,
    ALMACENID             D_FK,
    STOCKMIN              D_CANTIDAD,
    STOCKMAX              D_CANTIDAD
);