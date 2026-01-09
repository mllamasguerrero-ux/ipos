CREATE TABLE GUIA (
    ID                    D_PK NOT NULL /* D_PK = BIGINT NOT NULL */,
    ACTIVO                D_BOOLCS /* D_BOOLCS = CHAR(1) DEFAULT 'S' NOT NULL CHECK (VALUE IN ('S', 'N')) */,
    CREADO                D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    CREADOPOR_USERID      D_FK DEFAULT 0 /* D_FK = BIGINT */,
    MODIFICADO            D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    MODIFICADOPOR_USERID  D_FK DEFAULT 0 /* D_FK = BIGINT */,
    FOLIO                 D_DOCTOFOLIO /* D_DOCTOFOLIO = INTEGER */,
    ENCARGADOGUIAID       D_FK default 0 /* D_FK = BIGINT */,
    ESTADOGUIAID          D_FK DEFAULT 0 /* D_FK = BIGINT */,
    CAJEROID              D_FK DEFAULT 0 /* D_FK = BIGINT */,
    CORTEID               D_FK DEFAULT 0 /* D_FK = BIGINT */,
    FECHA                 D_FECHA /* D_FECHA = DATE */,
    FECHAHORA             D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    NOTA                  D_DESCRIPCION /* D_DESCRIPCION = VARCHAR(255) */
);