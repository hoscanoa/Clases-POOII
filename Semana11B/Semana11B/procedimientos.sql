IF OBJECT_ID('Sp_ListaPedidos') IS NOT NULL
BEGIN
DROP PROC Sp_ListaPedidos
END
GO
Create Proc Sp_ListaPedidos
as
Select * from Ventas.pedidoscabe
go


--LISTA DE FACTURAS POR RANGO DE FECHAS
IF OBJECT_ID('Sp_PedidosxRangoFecha') IS NOT NULL
BEGIN
DROP PROC Sp_PedidosxRangoFecha
END
GO
Create Proc Sp_PedidosxRangoFecha
@f1 datetime,
@f2 datetime
as
Select * from Ventas.pedidoscabe
where FechaPedido between @f1 and @f2
go
--EJECUTAR
Exec Sp_PedidosxRangoFecha '01/01/1997','07/01/1997'


