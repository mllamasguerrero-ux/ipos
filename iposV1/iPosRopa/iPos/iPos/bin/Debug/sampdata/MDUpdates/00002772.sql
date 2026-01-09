CREATE TABLE TTL_DOCTO_PERS_MES (
    ID                    D_ID NOT NULL /* D_ID = BIGINT NOT NULL */,
    ACTIVO                D_BOOLCS /* D_BOOLCS = CHAR(1) DEFAULT 'S' NOT NULL CHECK (VALUE IN ('S', 'N')) */,
    CREADO                D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    CREADOPOR_USERID      D_FK DEFAULT 0 /* D_FK = BIGINT */,
    MODIFICADO            D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    MODIFICADOPOR_USERID  D_FK DEFAULT 0 /* D_FK = BIGINT */,
    SUCURSALID            D_FK /* D_FK = BIGINT */,
    TIPODOCTOID           D_FK /* D_FK = BIGINT */,
    PERSONAID             D_FK /* D_FK = BIGINT */,
    MES                   D_DIAS /* D_DIAS = INTEGER */,
    ANIO                  D_DIAS /* D_DIAS = INTEGER */,
    CANTIDAD              D_DIAS /* D_DIAS = INTEGER */,
    TOTAL                 D_PRECIO /* D_PRECIO = NUMERIC(18,2) DEFAULT 0.00 */,
    UTILIDAD              D_PRECIO /* D_PRECIO = NUMERIC(18,2) DEFAULT 0.00 */,
    SUBTIPODOCTOID        D_FK /* D_FK = BIGINT */
);