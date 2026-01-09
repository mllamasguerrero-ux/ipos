CREATE TABLE TTLCONTROL (
    ID                        D_ID NOT NULL /* D_ID = BIGINT NOT NULL */,
    ACTIVO                    D_BOOLCS /* D_BOOLCS = CHAR(1) DEFAULT 'S' NOT NULL CHECK (VALUE IN ('S', 'N')) */,
    CREADO                    D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    CREADOPOR_USERID          D_FK DEFAULT 0 /* D_FK = BIGINT */,
    MODIFICADO                D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    MODIFICADOPOR_USERID      D_FK DEFAULT 0 /* D_FK = BIGINT */,
    FECHA_TTL_PROD_TIPO_MES   D_FECHA /* D_FECHA = DATE */,
    FECHA_TTL_DOCTO_PERS_MES  D_FECHA /* D_FECHA = DATE */
);