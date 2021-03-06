USE NEGOCIOS2014
GO
--1. LISTADO DE CLIENTES
IF OBJECT_ID('SP_LISTACLIENTES') IS NOT NULL
DROP PROC SP_LISTACLIENTES
GO
CREATE PROC SP_LISTACLIENTES
AS
SELECT C.IDCLIENTE AS CODIGO,
C.NOMCLIENTE AS CLIENTE,
C.DIRCLIENTE AS DIRECCION,
P.NOMBREPAIS AS PAIS,
C.FONOCLIENTE AS FONO
FROM VENTAS.CLIENTES C
JOIN VENTAS.PAISES P ON C.IDPAIS=P.IDPAIS
GO
--2. LISTADO DE PAISES
IF OBJECT_ID('SP_LISTAPAIS') IS NOT NULL
DROP PROC SP_LISTAPAIS
GO
CREATE PROC SP_LISTAPAIS
AS
SELECT * FROM VENTAS.PAISES
GO
--3. INSERTAR UN NUEVO CLIENTE
IF OBJECT_ID('SP_INSERTACLIENTE') IS NOT NULL
DROP PROC SP_INSERTACLIENTE
GO
CREATE PROC SP_INSERTACLIENTE(@IDC CHAR(5),@NOM VARCHAR(40),
@DIR VARCHAR(40),@PAI CHAR(3),
@TEL CHAR(15))
AS
INSERT INTO VENTAS.CLIENTES VALUES (@IDC,@NOM,@DIR,@PAI,@TEL)
GO
--4. BUSCAR UN CLIENTE
IF OBJECT_ID('SP_BUSCACLIENTE') IS NOT NULL
DROP PROC SP_BUSCACLIENTE
GO
CREATE PROC SP_BUSCACLIENTE(@IDC CHAR(5))
AS
SELECT * FROM VENTAS.CLIENTES
WHERE IDCLIENTE=@IDC
GO
--5. ACTUALIZACION DE CLIENTE
IF OBJECT_ID('SP_ACTUALIZACLIENTE') IS NOT NULL
DROP PROC SP_ACTUALIZACLIENTE
GO
CREATE PROC SP_ACTUALIZACLIENTE(@IDC CHAR(5),@NOM VARCHAR(40),
@DIR VARCHAR(40),@PAI CHAR(3),
@TEL CHAR(15))
AS
UPDATE VENTAS.CLIENTES
SET NOMCLIENTE=@NOM,DIRCLIENTE=@DIR,
IDPAIS=@PAI,FONOCLIENTE=@TEL
WHERE IDCLIENTE=@IDC
GO
--6. ELIMINAR UN CLIENTE
IF OBJECT_ID('SP_ELIMINACLIENTE') IS NOT NULL
DROP PROC SP_ELIMINACLIENTE
GO
CREATE PROC SP_ELIMINACLIENTE(@IDC CHAR(5))
AS
DELETE VENTAS.CLIENTES
WHERE IDCLIENTE=@IDC
GO



-----------------------------------------------------------

--. LISTADO DE PROVEEDORES
IF OBJECT_ID('SP_LISTAPROVEEDOR') IS NOT NULL
DROP PROC SP_LISTAPROVEEDOR
GO
CREATE PROC SP_LISTAPROVEEDOR
AS
SELECT * FROM Compras.proveedores
GO

--. LISTADO DE CATEGORIAS
IF OBJECT_ID('SP_LISTACATEGORIA') IS NOT NULL
DROP PROC SP_LISTACATEGORIA
GO
CREATE PROC SP_LISTACATEGORIA
AS
SELECT * FROM Compras.categorias
GO

--. LISTADO DE CLIENTES
IF OBJECT_ID('SP_LISTAPRODUCTOS') IS NOT NULL
DROP PROC SP_LISTAPRODUCTOS
GO
CREATE PROC SP_LISTAPRODUCTOS
AS
SELECT P.IdProducto AS CODIGO,
P.NomProducto AS NOMBRE,
PR.NomProveedor AS PROVEEDOR,
C.NombreCategoria AS CATEGORIA,
P.CantxUnidad AS [CANTIDAD X UNIDAD],
P.PrecioUnidad AS [PRECIO X UNIDAD],
P.UnidadesEnExistencia AS [UNIDADES EN EXISTENCIA],
P.UnidadesEnPedido AS [UNIDADES EN PEDIDO]
FROM Compras.productos P
JOIN Compras.proveedores PR ON P.IdProveedor=PR.IdProveedor
JOIN Compras.categorias C ON P.IdCategoria=C.IdCategoria
GO

--. INSERTAR UN NUEVO PRODUCTO
IF OBJECT_ID('SP_INSERTAPRODUCTO') IS NOT NULL
DROP PROC SP_INSERTAPRODUCTO
GO
CREATE PROC SP_INSERTAPRODUCTO(@NOM VARCHAR(40),
@IDPRO INT,@IDC INT, @CAN VARCHAR(20), @PRE DECIMAL(20),
@UEE SMALLINT, @UEP SMALLINT)
AS
INSERT INTO COMPRAS.productos VALUES (@NOM, @IDPRO,@IDC, 
@CAN, @PRE, @UEE, @UEP)
GO