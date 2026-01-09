CREATE TABLE GUIADETALLE (
    ID                    D_PK NOT NULL /* D_PK = BIGINT NOT NULL */,
    ACTIVO                D_BOOLCS /* D_BOOLCS = CHAR(1) DEFAULT 'S' NOT NULL CHECK (VALUE IN ('S', 'N')) */,
    CREADO                D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    CREADOPOR_USERID      D_FK DEFAULT 0 /* D_FK = BIGINT */,
    MODIFICADO            D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    MODIFICADOPOR_USERID  D_FK DEFAULT 0 /* D_FK = BIGINT */,
    GUIAID                D_FK DEFAULT 0 /* D_FK = BIGINT */,
    DOCTOID               D_FK DEFAULT 0 /* D_FK = BIGINT */,
    ESTADOGUIAID          D_FK DEFAULT 0 /* D_FK = BIGINT */
);
