CREATE TABLE INGRESUC_TIPOLINEA (
    ID                           D_PK NOT NULL /* D_PK = BIGINT NOT NULL */,
    ACTIVO                       D_BOOLCS /* D_BOOLCS = CHAR(1) DEFAULT 'S' NOT NULL CHECK (VALUE IN ('S', 'N')) */,
    CREADO                       D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    CREADOPOR_USERID             D_FK DEFAULT 0 /* D_FK = BIGINT */,
    MODIFICADO                   D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    MODIFICADOPOR_USERID         D_FK DEFAULT 0 /* D_FK = BIGINT */,
    CLAVE   D_CLAVE,
    DESCRIPCION D_DESCRIPCION,
    ESTEQUILENO  D_BOOLCN,
    ESFACTURA   D_BOOLCN,
    ESCREDITO  D_BOOLCN,
    TIPOREG  VARCHAR(1)
    

);