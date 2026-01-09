EXECUTE BLOCK
AS
BEGIN

 IF(NOT EXISTS(SELECT 1 FROM rdb$relations WHERE rdb$relation_name = 'REPLPPCVERSION')) THEN 
 BEGIN
   EXECUTE STATEMENT 
    'CREATE TABLE REPLPPCVERSION (
            PPCVERSION          INTEGER,
            PPCVERSIONSUCURSAL  INTEGER,
            PPCVERSIONMATRIZ    INTEGER
     );';
 END

 

 IF (NOT EXISTS(SELECT 1 FROM rdb$relations WHERE rdb$relation_name = 'REPLIMPOTIPO')) THEN 
 BEGIN
   EXECUTE STATEMENT 
    'CREATE TABLE REPLIMPOTIPO (
            ID                    D_PK ,
            ACTIVO                D_BOOLCS ,
            CREADO                D_TIMESTAMP ,
            CREADOPOR_USERID      D_FK DEFAULT 0 ,
            MODIFICADO            D_TIMESTAMP ,
            MODIFICADOPOR_USERID  D_FK DEFAULT 0 ,
            CLAVE                 D_CLAVE ,
            NOMBRE                D_NOMBRE 
     );';

   EXECUTE STATEMENT 
    'ALTER TABLE REPLIMPOTIPO ADD CONSTRAINT PK_REPLIMPOTIPO PRIMARY KEY (ID);';


 END


 
 IF (NOT EXISTS(SELECT 1 FROM rdb$relations WHERE rdb$relation_name = 'REPLIMPOESTATUS')) THEN 
 BEGIN

 
   EXECUTE STATEMENT 
    'CREATE TABLE REPLIMPOESTATUS (
            ID                    D_PK ,
            ACTIVO                D_BOOLCS ,
            CREADO                D_TIMESTAMP ,
            CREADOPOR_USERID      D_FK DEFAULT 0 ,
            MODIFICADO            D_TIMESTAMP ,
            MODIFICADOPOR_USERID  D_FK DEFAULT 0 ,
            CLAVE                 D_CLAVE ,
            NOMBRE                D_NOMBRE 
         );';


 
   EXECUTE STATEMENT 
    'ALTER TABLE REPLIMPOESTATUS ADD CONSTRAINT PK_REPLIMPOESTATUS PRIMARY KEY (ID);';

 END



 IF (NOT EXISTS(SELECT 1 FROM rdb$generators   where rdb$generator_name =  'SEQ_REPLIMPOCTRL')) THEN
 BEGIN

     EXECUTE STATEMENT 
    'CREATE GENERATOR SEQ_REPLIMPOCTRL;';
 END

 IF (NOT EXISTS(SELECT 1 FROM rdb$relations WHERE rdb$relation_name = 'REPLIMPOCTRL')) THEN 
 BEGIN
     EXECUTE STATEMENT 
    'CREATE TABLE REPLIMPOCTRL (
            ID                    D_PK ,
            ACTIVO                D_BOOLCS ,
            CREADO                D_TIMESTAMP ,
            CREADOPOR_USERID      D_FK DEFAULT 0 ,
            MODIFICADO            D_TIMESTAMP ,
            MODIFICADOPOR_USERID  D_FK DEFAULT 0 ,
            FUENTESUCURSALCLAVE   D_CLAVE_NULL ,
            FUENTESUCURSALID      D_FK ,
            FUENTEID              D_FK ,
            FECHAHORASYNC         D_TIMESTAMP ,
            TIPOID                D_FK ,
            DESTINOID             D_FK ,
            ESTATUS               D_FK 
     );';

    EXECUTE STATEMENT 
    'ALTER TABLE REPLIMPOCTRL ADD CONSTRAINT PK_REPLIMPOCTRL PRIMARY KEY (ID);';

 END


 IF (NOT EXISTS(SELECT 1 FROM RDB$INDICES WHERE RDB$INDEX_NAME = 'REPLIMPOCTRL_IDX1')) THEN 
 BEGIN
    EXECUTE STATEMENT 
    'CREATE INDEX REPLIMPOCTRL_IDX1 ON REPLIMPOCTRL (FUENTESUCURSALCLAVE, TIPOID, FUENTEID);';
 END



 IF (NOT EXISTS(SELECT 1 FROM rdb$relations WHERE rdb$relation_name = 'REPLEXPOTIPO')) THEN 
 BEGIN

 
    EXECUTE STATEMENT 
    '
        CREATE TABLE REPLEXPOTIPO (
                ID                    D_PK ,
                ACTIVO                D_BOOLCS ,
                CREADO                D_TIMESTAMP ,
                CREADOPOR_USERID      D_FK DEFAULT 0 ,
                MODIFICADO            D_TIMESTAMP ,
                MODIFICADOPOR_USERID  D_FK DEFAULT 0 ,
                CLAVE                 D_CLAVE ,
                NOMBRE                D_NOMBRE 
         );';


    EXECUTE STATEMENT 
    'ALTER TABLE REPLEXPOTIPO ADD CONSTRAINT PK_REPLEXPOTIPO PRIMARY KEY (ID);';
 END




 IF (NOT EXISTS(SELECT 1 FROM rdb$relations WHERE rdb$relation_name = 'REPLEXPOESTATUS')) THEN 
 BEGIN

 
    EXECUTE STATEMENT 
    '
         CREATE TABLE REPLEXPOESTATUS (
                ID                    D_PK ,
                ACTIVO                D_BOOLCS ,
                CREADO                D_TIMESTAMP ,
                CREADOPOR_USERID      D_FK DEFAULT 0 ,
                MODIFICADO            D_TIMESTAMP ,
                MODIFICADOPOR_USERID  D_FK DEFAULT 0 ,
                CLAVE                 D_CLAVE ,
                NOMBRE                D_NOMBRE 
     );';

    EXECUTE STATEMENT 
    'ALTER TABLE REPLEXPOESTATUS ADD CONSTRAINT PK_REPLEXPOESTATUS PRIMARY KEY (ID);';
 
 END



 IF (NOT EXISTS(SELECT 1 FROM rdb$generators   where rdb$generator_name =  'SEQ_REPLEXPOCTRL')) THEN
 BEGIN

 
    EXECUTE STATEMENT 
    'CREATE GENERATOR SEQ_REPLEXPOCTRL;';
 END


 IF (NOT EXISTS(SELECT 1 FROM rdb$relations WHERE rdb$relation_name = 'REPLEXPOCTRL')) THEN 
 BEGIN
    

 
    EXECUTE STATEMENT 
    'CREATE TABLE REPLEXPOCTRL (
            ID                    D_PK ,
            ACTIVO                D_BOOLCS ,
            CREADO                D_TIMESTAMP ,
            CREADOPOR_USERID      D_FK DEFAULT 0 ,
            MODIFICADO            D_TIMESTAMP ,
            MODIFICADOPOR_USERID  D_FK DEFAULT 0 ,
            DESTINOSUCURSALCLAVE  D_CLAVE_NULL ,
            DESTINOSUCURSALID     D_FK ,
            FUENTEID              D_FK ,
            FECHAHORASYNC         D_TIMESTAMP ,
            TIPOID                D_FK ,
            DESTINOID             D_FK ,
            ESTATUS               D_FK 
     );';


 
    EXECUTE STATEMENT 
    'ALTER TABLE REPLEXPOCTRL ADD CONSTRAINT PK_REPLEXPOCTRL PRIMARY KEY (ID);';
 END




 IF (NOT EXISTS(SELECT 1 FROM RDB$INDICES WHERE RDB$INDEX_NAME = 'REPLEXPOCTRL_IDX1')) THEN 
 BEGIN

 
    EXECUTE STATEMENT 
    'CREATE INDEX REPLEXPOCTRL_IDX1 ON REPLEXPOCTRL (TIPOID, ESTATUS, FECHAHORASYNC);';

 END

 


 




 

END
