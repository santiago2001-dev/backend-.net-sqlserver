-- SELECT * FROM SYS.tables ORDER BY name;

-- procedimientos de consultas
-- consultas tabla clientes 

CREATE PROCEDURE cliente_get_all
AS
BEGIN
 SELECT id,nombre,documento,tipoDocumento,edad FROM Clientes;
 
END

EXECUTE cliente_get_all;


CREATE PROCEDURE cliente_get_byid
@id int 
AS 
BEGIN
SELECT * FROM Clientes WHERE id =  @id
END 





CREATE PROCEDURE cliente_insert
@nombre VARCHAR(50),
@documento int,
@tipoDocumento VARCHAR(50),
@edad int 
AS
BEGIN
INSERT INTO Clientes (nombre,documento,tipoDocumento,edad)
VALUES (@nombre,@documento,@tipoDocumento,@edad)
END








CREATE PROCEDURE cliente_update
@id int,
@nombre VARCHAR(50),
@documento int,
@tipoDocumento VARCHAR(50),
@edad int 
AS
BEGIN
UPDATE  Clientes 
SET 
nombre = @nombre,
documento = @documento,
tipoDocumento = @tipoDocumento,
edad = @edad

WHERE  id  = @id
END



CREATE PROCEDURE cliente_delite
@id int 
AS 
BEGIN
DELETE FROM Clientes 
WHERE 
id = @id
END


-- DROP PROCEDURE [cliente_insert];  
-- GO


--procedimientos tabla producto


CREATE PROCEDURE producto_get_all
AS
BEGIN
 SELECT id,nombre,marca,precio,unidadesExistentes,unidadesVendidas FROM producto;
 
END

CREATE PROCEDURE producto_get_byid
@id int 
AS 
BEGIN
SELECT * FROM producto WHERE id =  @id
END 



CREATE PROCEDURE producto_insert

@nombre VARCHAR(50),
@marca VARCHAR(50),
@precio int,
@unidadesExistentes int,
@unidadesVendidas  int
AS
BEGIN
INSERT INTO producto (nombre,marca,precio,unidadesExistentes,unidadesVendidas)
VALUES (@nombre,@marca,@precio,@unidadesExistentes,@unidadesVendidas)
END


CREATE PROCEDURE producto_update
@id int,
@nombre VARCHAR(50),
@marca VARCHAR(50),
@precio int,
@unidadesExistentes int,
@unidadesVendidas  int

AS
BEGIN
UPDATE  producto 
SET 
nombre = @nombre,
marca = @marca,
precio = @precio,
unidadesExistentes = @unidadesExistentes,
unidadesVendidas = @unidadesVendidas

WHERE  id  = @id
END




CREATE PROCEDURE producto_delete
@id int 
AS 
BEGIN
DELETE FROM  producto
WHERE 
id = @id
END



--procedimientos tabla venta--

CREATE PROCEDURE get_all_ventas

AS
BEGIN 
SELECT id ,idCliente,idProducto,fecha from venta;
END 


CREATE PROCEDURE get_all_byid
@id int
AS
BEGIN
SELECT * FROM venta WHERE id = @id;
END



CREATE PROCEDURE venta_insert 
@idCliente int ,
@idProducto int,
@fecha date
AS 
BEGIN 
INSERT INTO venta (idCliente,idProducto,fecha)
VALUES (@idCliente,@idProducto,@fecha)
END



CREATE PROCEDURE venta_update 
@id int,
@idCliente int ,
@idProducto int,
@fecha date
AS
BEGIN 
UPDATE VENTA 
SET 
idCliente = @idCliente,
idProducto = @idProducto,
fecha = @fecha
WHERE id = @id 
END


CREATE PROCEDURE venta_delete 
@id int 
AS
BEGIN
DELETE FROM venta 
WHERE id = @id
END  
--Obtener la lista de productos cuya existencia en el inventario haya llegado al mínimo permitido (5 unidades)
CREATE PROCEDURE producto_minCincoUnidades

AS
BEGIN
SELECT * FROM producto WHERE unidadesExistentes = 5
END


--Obtener la lista de precios de todos los productos
CREATE PROCEDURE getpreciosprod
AS 
BEGIN 
SELECT precio from producto;
END


--Obtener el valor total vendido por cada producto en el año 2000
drop table if exists temp
select idProducto,COUNT(idProducto)cantidad INTO temp from venta WHERE YEAR(fecha) = '2000' GROUP BY idProducto;
select * from temp
select * from producto

select p.nombre,(p.precio * (COUNT(v.idProducto))) AS total from producto p inner join venta v on p.id = v.idProducto group by p.nombre, p.precio,v.idProducto;