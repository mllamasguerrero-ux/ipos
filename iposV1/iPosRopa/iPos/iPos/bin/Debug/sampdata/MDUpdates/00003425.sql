EXECUTE BLOCK
AS
declare variable PRODUCTOID D_FK;
declare variable FECHAULTIMACOMPRA D_FECHA;  
declare variable FECHAULTIMAVENTA D_FECHA; 
declare variable PERSONAID D_FK;

BEGIN

  FOR   select producto.id,  max(docto.fecha) fecha
        from  docto
       inner join movto on  docto.id = movto.doctoid
       inner join producto on   movto.productoid = producto.id
       where docto.tipodoctoid = 21 and docto.estatusdoctoid = 1
      /* and docto.fecha > '01.01.2010'*/ and producto.ultimaventa is null
       group by producto.id
    INTO :productoid,  :fechaultimaventa
    DO
    BEGIN
            UPDATE PRODUCTO SET PRODUCTO.ultimaventa = :fechaultimaventa WHERE ID = :PRODUCTOID;
            
    END


  FOR   select producto.id,  max(docto.fecha) fecha
        from  docto
       inner join movto on  docto.id = movto.doctoid
       inner join producto on   movto.productoid = producto.id
       where docto.tipodoctoid = 11 and docto.estatusdoctoid = 1
       /*and docto.fecha > '01.01.2010'*/ and producto.ultimacompra is null
       group by producto.id
    INTO :productoid,  :fechaultimaCOMPRA
    DO
    BEGIN
            UPDATE PRODUCTO SET PRODUCTO.ultimacompra = :fechaultimacompra WHERE ID = :PRODUCTOID;
            
    END


  FOR   select persona.id,  max(docto.fecha) fecha
        from  docto
       inner join persona on   docto.personaid = persona.id
       where docto.tipodoctoid = 21 and docto.estatusdoctoid = 1
       /*and docto.fecha > '01.01.2010'*/ and persona.ultimaventa is null
       group by persona.id
    INTO :personaid,  :fechaultimaventa
    DO
    BEGIN
            UPDATE PERSONA SET ultimaventa = :fechaultimaventa where id = :personaid;
            
    END


END