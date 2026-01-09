CREATE TABLE LLAMADOEMIDA (
    ID                    D_PK NOT NULL /* D_PK = BIGINT NOT NULL */,
    ACTIVO                D_BOOLCS /* D_BOOLCS = CHAR(1) DEFAULT 'S' NOT NULL CHECK (VALUE IN ('S', 'N')) */,
    CREADO                D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    CREADOPOR_USERID      D_FK DEFAULT 0 /* D_FK = BIGINT */,
    MODIFICADO            D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    MODIFICADOPOR_USERID  D_FK DEFAULT 0 /* D_FK = BIGINT */,
    OPERACION             D_DESCRIPCION /* D_DESCRIPCION = VARCHAR(255) */,
    EMIDAREQUESTID        D_FK /* D_FK = BIGINT */,
    REFERENCIA            D_STDTEXT_LIGHT /* D_STDTEXT_LIGHT = VARCHAR(64) */,
    SUCURSALID            D_FK /* D_FK = BIGINT */,
    USUARIOID             D_FK /* D_FK = BIGINT */,
    TERMINALID            D_FK /* D_FK = BIGINT */,
    INICIO                D_TIMESTAMP_NULL /* D_TIMESTAMP_NULL = TIMESTAMP DEFAULT current_timestamp */,
    FIN                   D_TIMESTAMP_NULL /* D_TIMESTAMP_NULL = TIMESTAMP DEFAULT current_timestamp */,
    DURACION              D_DIAS /* D_DIAS = INTEGER */
);