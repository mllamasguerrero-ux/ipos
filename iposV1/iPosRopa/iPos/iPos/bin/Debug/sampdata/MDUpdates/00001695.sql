CREATE TABLE QUOTA (
    ID                    D_PK NOT NULL /* D_PK = BIGINT NOT NULL */,
    ACTIVO                D_BOOLCS /* D_BOOLCS = CHAR(1) DEFAULT 'S' NOT NULL CHECK (VALUE IN ('S', 'N')) */,
    CREADO                D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    CREADOPOR_USERID      D_FK DEFAULT 0 /* D_FK = BIGINT */,
    MODIFICADO            D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    MODIFICADOPOR_USERID  D_FK DEFAULT 0 /* D_FK = BIGINT */,
    VENDEDORID            D_FK /* D_FK = BIGINT */,
    ANIO                  INTEGER,
    MES                   INTEGER,
    QUOTA                 D_PRECIO /* D_PRECIO = NUMERIC(18,2) DEFAULT 0.00 */,
    LOGRO                 D_PRECIO /* D_PRECIO = NUMERIC(18,2) DEFAULT 0.00 */,
    UTILIDAD              D_PRECIO /* D_PRECIO = NUMERIC(18,2) DEFAULT 0.00 */
);