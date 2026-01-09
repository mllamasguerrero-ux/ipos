CREATE TABLE LOGEVENTOTABLA (
    ID                    D_ID NOT NULL /* D_ID = BIGINT NOT NULL */,
    ACTIVO                D_BOOLCS /* D_BOOLCS = CHAR(1) DEFAULT 'S' NOT NULL CHECK (VALUE IN ('S', 'N')) */,
    CREADO                D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    CREADOPOR_USERID      D_FK DEFAULT 0 /* D_FK = BIGINT */,
    MODIFICADO            D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    MODIFICADOPOR_USERID  D_FK DEFAULT 0 /* D_FK = BIGINT */,
    FECHAHORA             D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    TABLA                 D_NOMBRE /* D_NOMBRE = VARCHAR(127) NOT NULL */,
    USUARIOID             D_FK /* D_FK = BIGINT */,
    TIPOEVENTOTABLAID     D_FK /* D_FK = BIGINT */,
    NOTA                  D_DESCRIPCION /* D_DESCRIPCION = VARCHAR(255) */,
    RECORDID              D_FK /* D_FK = BIGINT */
);
