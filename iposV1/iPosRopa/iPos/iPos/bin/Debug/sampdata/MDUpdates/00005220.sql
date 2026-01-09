CREATE TABLE CFDI_CONC_ADU (
    ID                    D_PK NOT NULL /* D_PK = BIGINT NOT NULL */,
    ACTIVO                D_BOOLCS /* D_BOOLCS = CHAR(1) DEFAULT 'S' NOT NULL CHECK (VALUE IN ('S', 'N')) */,
    CREADO                D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    CREADOPOR_USERID      D_FK DEFAULT 0 /* D_FK = BIGINT */,
    MODIFICADO            D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    MODIFICADOPOR_USERID  D_FK DEFAULT 0 /* D_FK = BIGINT */,
    FECHA                 D_FECHA /* D_FECHA = DATE */,
    NUMERO                D_STDTEXT_64 /* D_STDTEXT_64 = VARCHAR(64) */,
    ADUANA                D_STDTEXT_64 /* D_STDTEXT_64 = VARCHAR(64) */,
    CFDI_CONC_ID          D_FK /* D_FK = BIGINT */
);