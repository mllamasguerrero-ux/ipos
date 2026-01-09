CREATE TABLE MENSAJEAREA (
    ID                    D_PK NOT NULL /* D_PK = BIGINT NOT NULL */,
    ACTIVO                D_BOOLCS /* D_BOOLCS = CHAR(1) DEFAULT 'S' NOT NULL CHECK (VALUE IN ('S', 'N')) */,
    CREADO                D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    CREADOPOR_USERID      D_FK DEFAULT 0 /* D_FK = BIGINT */,
    MODIFICADO            D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    MODIFICADOPOR_USERID  D_FK DEFAULT 0 /* D_FK = BIGINT */,
    IDMENSAJE             D_FK DEFAULT 0 /* D_FK = BIGINT */,
    IDAREA                D_FK DEFAULT 0 /* D_FK = BIGINT */,
    CLAVEAREA             D_CLAVE /* D_CLAVE = VARCHAR(31) NOT NULL */
);
