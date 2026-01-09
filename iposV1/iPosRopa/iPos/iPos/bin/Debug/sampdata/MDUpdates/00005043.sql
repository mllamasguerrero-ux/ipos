CREATE TABLE CUENTABANCO (
    ID                    D_PK NOT NULL /* D_PK = BIGINT NOT NULL */,
    ACTIVO                D_BOOLCS /* D_BOOLCS = CHAR(1) DEFAULT 'S' NOT NULL CHECK (VALUE IN ('S', 'N')) */,
    CREADO                D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    CREADOPOR_USERID      D_FK DEFAULT 0 /* D_FK = BIGINT */,
    MODIFICADO            D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    MODIFICADOPOR_USERID  D_FK DEFAULT 0 /* D_FK = BIGINT */,
    BANCOID               D_FK /* D_FK = BIGINT */,
    NOMBRE                D_NOMBRE /* D_NOMBRE = VARCHAR(127) NOT NULL */,
    RFC                   D_STDTEXT_SHORT /* D_STDTEXT_SHORT = VARCHAR(32) */,
    NOCUENTA              D_STDTEXT_MEDIUM /* D_STDTEXT_MEDIUM = VARCHAR(128) */
);
