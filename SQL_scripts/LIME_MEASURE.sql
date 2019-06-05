DECLARE @t1 DATETIME;
DECLARE @t2 DATETIME;

-- wyswietl widoki
SET @t1 = GETDATE();
SELECT * FROM [client_order_set_view];
SET @t2 = GETDATE();
SELECT DATEDIFF(millisecond,@t1,@t2) AS elapsed_ms;

SET @t1 = GETDATE();
SELECT * FROM [warehouse_order_view];
SET @t2 = GETDATE();
SELECT DATEDIFF(millisecond,@t1,@t2) AS elapsed_ms;


-- Szukaj jednego 
DECLARE @t1 DATETIME;
DECLARE @t2 DATETIME;

SET @t1 = GETDATE();
SELECT * FROM cases
--where id = 50000;
WHERE description = 'YnPzXy-~xmLco@m>6 X{+;x."U#nlWiZO}mtK>M<p,';
SET @t2 = GETDATE();
SELECT DATEDIFF(millisecond,@t1,@t2) AS elapsed_ms;

-- po jakiejs wartosci
DECLARE @t1 DATETIME;
DECLARE @t2 DATETIME;

SET @t1 = GETDATE();
SELECT * FROM cases
WHERE id > 50000;
SET @t2 = GETDATE();
SELECT DATEDIFF(millisecond,@t1,@t2) AS elapsed_ms;

-- join
DECLARE @t1 DATETIME;
DECLARE @t2 DATETIME;

SET @t1 = GETDATE();
SELECT client_order_sets.order_date, clients.name, clients.surname
FROM clients
INNER JOIN client_order_sets ON client_order_sets.id_client=clients.id;
SET @t2 = GETDATE();
SELECT DATEDIFF(millisecond,@t1,@t2) AS elapsed_ms;
