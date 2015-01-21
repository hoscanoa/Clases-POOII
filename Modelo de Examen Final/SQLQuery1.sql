-- autogenera el codigo del Producto
If OBJECT_ID('sp_generaCodigo') is not null
drop proc sp_generaCodigo
go
Create procedure sp_generaCodigo
@cod varchar (20)output
as
declare @aux varchar(20)
select @aux = max(right(COD_CLI,4)) from CLIENTE
select @cod = 'CL'+right(str(convert(int,@aux)+10001),4)
--noten que en este procedimiento el parámetro @cod dice output que quiere decir que es de salida.
go
--para probar nuestro sp seria de la siguiente manera
--(esto siempre y cuando el sp vote un parámetro de
--salida):
declare @aux varchar(20)
execute sp_generaCODIGO @aux output
select @aux