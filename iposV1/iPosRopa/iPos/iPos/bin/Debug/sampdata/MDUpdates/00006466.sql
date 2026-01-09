CREATE TABLE SAT_CLAVEUNIDADPESO (
    ID                    D_PK NOT NULL /* D_PK = BIGINT NOT NULL */,
    ACTIVO                D_BOOLCS /* D_BOOLCS = CHAR(1) DEFAULT 'S' NOT NULL CHECK (VALUE IN ('S', 'N')) */,
    CREADO                D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    CREADOPOR_USERID      D_FK DEFAULT 0 /* D_FK = BIGINT */,
    MODIFICADO            D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    MODIFICADOPOR_USERID  D_FK DEFAULT 0 /* D_FK = BIGINT */,                
        CLAVE            D_STDTEXT_SHORT,        
        NOMBRE            D_STDTEXT_MEDIUM,        
        DESCRIPCION            D_STDTEXT_LARGE,        
        NOTA            D_STDTEXT_LARGE,        
        FECHAINICIO            D_FECHA,        
        FECHAFIN            D_FECHA,        
        SIMBOLO            D_STDTEXT_MEDIUM,        
        BANDERA            D_STDTEXT_MEDIUM        
                );
