use BDFACTURA
go

--1.- LISTADO DE CLIENTES

if OBJECT_ID('sp_listaclientes') is not null
			drop proc sp_listaclientes
go

create proc sp_listacliente
as 
select * from Clientes
go
exec sp_listacliente

-- autogenera el codigo del Producto 
If OBJECT_ID('sp_genera') is not null
	drop proc sp_genera
go
Create procedure sp_genera 
@cod varchar (20)output 
as 
declare @aux varchar(20) 
select @aux = max(right(Cli_Codigo,4)) from Clientes 
select @cod = 'C'+right(str(convert(int,@aux)+10001),4) 
--noten que en este procedimiento el parámetro @cod dice output que quiere decir que es de salida. 
go 
 
--para probar nuestro sp seria de la siguiente manera 
--(esto siempre y cuando el sp vote un parámetro de 
--salida): 
declare @aux varchar(20) 
execute sp_genera @aux output 
select @aux 