--Creación de la base de
--Datos: DATA
Create DataBase DATA
go
--Activar la Base de Datos
Use DATA
go
--Crear la tabla Productos
if OBJECT_ID('Productos') is not null
drop table Productos
go
CREATE TABLE PRODUCTOS(
CODIGO varchar(5) PRIMARY KEY,
PRODUCTO VARCHAR(50) NOT NULL,
PRECIO NUMERIC(8,2) NOT NULL,
CANTIDAD INT NOT NULL,
ESTADO INT NOT NULL
)
GO
--INSERTAR REGISTROS
INSERT INTO PRODUCTOS VALUES('P0001','TECLADO',15,250,1)
INSERT INTO PRODUCTOS VALUES('P0002','MONITOR',150,350,1)

--P.A. que lista la tabla Productos
If OBJECT_ID('sp_listaproductos') is not null
drop proc sp_listaproductos
go
Create Proc sp_listaproductos
as
Select * from Productos
WHERE ESTADO=1
go
--P.A para insertar Registros
If OBJECT_ID('SP_InsertaRegistros') is not null
drop proc SP_InsertaRegistros
go
Create Proc SP_InsertaRegistros
@Codigo Varchar(5),
@Producto Varchar(50),
@Precio Numeric(8,2),
@Cantidad int,
@ESTADO INT
as
insert into productos
values(@Codigo,@Producto,@Precio,@Cantidad,@ESTADO)
go
--P.A que actualiza registros
If OBJECT_ID('SP_ActualizaRegistro') is not null
drop proc SP_ActualizaRegistro
go
Create Proc SP_ActualizaRegistro
@Codigo Varchar(5),
@Producto Varchar(50),
@Precio numeric(8,2),
@Cantidad int,
@ESTADO INT
as
Update PRODUCTOS
set Producto=@Producto,PRECIO=@Precio,CANTIDAD=@Cantidad,
ESTADO=@ESTADO
where CODIGO=@Codigo
go
-- Autogenera el codigo del Producto
If OBJECT_ID('sp_genera') is not null
drop proc sp_genera
go
Create procedure sp_genera
@cod varchar (20)output
as
declare @aux varchar(20)
select @aux = max(right(Codigo,4)) from Productos
select @cod = 'P'+right(str(convert(int,@aux)+10001),4)
--noten que en este procedimiento el parámetro @cod dice output que quiere decir que es de salida.
go

--para probar nuestro sp seria de la siguiente manera
--(esto siempre y cuando el sp vote un parámetro de
--salida):
declare @aux varchar(20)
execute sp_genera @aux output
select @aux
--P.A para eliminar registros de
--forma Lógica(No Fisica)
if OBJECT_ID('usp_DardeBaja') is not null
drop proc usp_DardeBaja
go
Create Proc usp_DardeBaja
@Codigo char(6)
as
Update PRODUCTOS set Estado=0
where CODIGO=@Codigo
go