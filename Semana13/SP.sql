IF OBJECT_ID('SP_LISTAPRODUCTOS') IS NOT NULL
BEGIN
DROP PROC SP_LISTAPRODUCTOS
END
GO
CREATE PROC SP_LISTAPRODUCTOS
AS
SELECT * FROM Compras.productos
GO
IF OBJECT_ID('SP_LISTAPROVEEDORES') IS NOT NULL
BEGIN
DROP PROC SP_LISTAPROVEEDORES
END
GO
CREATE PROC SP_LISTAPROVEEDORES
AS
SELECT * FROM Compras.proveedores
GO
IF OBJECT_ID('SP_LISTACATEGORIAS') IS NOT NULL
BEGIN
DROP PROC SP_LISTACATEGORIAS
END
GO
CREATE PROC SP_LISTACATEGORIAS
AS
SELECT * FROM Compras.categorias
GO
IF OBJECT_ID('SP_ULTIMOPRODUCTO') IS NOT NULL
BEGIN
DROP PROC SP_ULTIMOPRODUCTO
END
GO
CREATE PROC SP_ULTIMOPRODUCTO
AS
SELECT TOP 1 IdProducto FROM Compras.productos
ORDER BY IdProducto DESC
GO