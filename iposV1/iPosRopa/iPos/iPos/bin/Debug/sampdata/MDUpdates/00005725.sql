CREATE OR ALTER trigger borrar_conectado
active on disconnect position 3
AS
begin
     DELETE FROM
      CONECTADOS
   WHERE
      CON_IDECON = CURRENT_CONNECTION;
end