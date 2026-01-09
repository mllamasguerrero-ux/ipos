CREATE TABLE TERMINALPAGOSERVICIO (
    ID                    D_PK NOT NULL /* D_PK = BIGINT NOT NULL */,
    ACTIVO                D_BOOLCS /* D_BOOLCS = CHAR(1) DEFAULT 'S' NOT NULL CHECK (VALUE IN ('S', 'N')) */,
    CREADO                D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    CREADOPOR_USERID      D_FK DEFAULT 0 /* D_FK = BIGINT */,
    MODIFICADO            D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    MODIFICADOPOR_USERID  D_FK DEFAULT 0 /* D_FK = BIGINT */,
    TERMINAL              D_CLAVE /* D_CLAVE = VARCHAR(31) NOT NULL */,
    SUCURSALCLAVE         D_CLAVE /* D_CLAVE = VARCHAR(31) NOT NULL */,
    SUCURSALID            D_FK /* D_FK = BIGINT */,
    CONSECUTIVO           D_FK /* D_FK = BIGINT */
);