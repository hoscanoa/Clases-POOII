USE NEGOCIOS2014
GO
--LISTADO DE PRODUCTOS
IF OBJECT_ID('SP_LISTAPRODUCTOS') IS NOT NULL
DROP PROC SP_LISTAPRODUCTOS
GO
CREATE PROCEDURE SP_LISTAPRODUCTOS
AS
SELECT P.IDPRODUCTO AS CODIGO,
P.NOMPRODUCTO AS PRODUCTO,
PR.NOMPROVEEDOR AS PROVEEDOR,
C.NOMBRECATEGORIA AS CATEGORIA,
P.CANTXUNIDAD AS CANTIDAD,
P.PRECIOUNIDAD AS PRECIO,
P.UNIDADESENEXISTENCIA AS EXISTENCIA,
P.UNIDADESENPEDIDO AS EN_PEDIDO
FROM COMPRAS.PRODUCTOS P
JOIN COMPRAS.PROVEEDORES PR
ON P.IDPROVEEDOR=PR.IDPROVEEDOR
JOIN COMPRAS.CATEGORIAS C
ON P.IDCATEGORIA=C.IDCATEGORIA
GO
--PROCEDIMIENTO PARA LISTAR SOLO LOS PROVEEDORES
IF OBJECT_ID('SP_LISTAPROVEEDORES') IS NOT NULL
DROP PROC SP_LISTAPROVEEDORES
GO
CREATE PROCEDURE SP_LISTAPROVEEDORES
AS
SELECT DISTINCT PROD.IDPROVEEDOR,PROV.NOMPROVEEDOR
FROM COMPRAS.PRODUCTOS PROD
JOIN COMPRAS.PROVEEDORES PROV
ON PROD.IDPROVEEDOR=PROV.IDPROVEEDOR
GO
--PROCEDIMIENTO QUE LISTA LAS CATEGORIAS
IF OBJECT_ID('SP_LISTACATEGORIA') IS NOT NULL
DROP PROC SP_LISTACATEGORIA
GO
CREATE PROCEDURE SP_LISTACATEGORIA
AS
SELECT DISTINCT P.IDCATEGORIA,C.NOMBRECATEGORIA
FROM COMPRAS.PRODUCTOS P
JOIN COMPRAS.CATEGORIAS C
ON P.IDCATEGORIA=C.IDCATEGORIA
GO
--DETERMINAR EL NUEVO CODIGO DE PRODUCTO
IF OBJECT_ID('ULTIMOPRODUCTO') IS NOT NULL
DROP PROC ULTIMOPRODUCTO
GO
CREATE PROCEDURE ULTIMOPRODUCTO
AS
SELECT TOP 1 (IDPRODUCTO+1) FROM COMPRAS.PRODUCTOS
ORDER BY IDPRODUCTO DESC
GO
--NUEVO PRODUCTO
IF OBJECT_ID('SP_INSERTAPRODUCTO') IS NOT NULL
DROP PROC SP_INSERTAPRODUCTO
GO
CREATE PROCEDURE SP_INSERTAPRODUCTO(
@IDPROD INT,@PRO VARCHAR(30),@IDPROV INT,@IDCAT INT,
@CANT VARCHAR(20),@PRE MONEY,@UEX INT,@UPE INT
)
AS
INSERT INTO COMPRAS.PRODUCTOS
VALUES(@IDPROD,@PRO,@IDPROV,@IDCAT,
@CANT,@PRE,@UEX,@UPE)
GO
--ACTUALIZA PRODUCTO
IF OBJECT_ID('SP_ACTUALIZAPRODUCTO') IS NOT NULL
DROP PROC SP_ACTUALIZAPRODUCTO
GO
CREATE PROCEDURE SP_ACTUALIZAPRODUCTO(
@IDPROD INT,@PRO VARCHAR(30),@IDPROV INT,@IDCAT INT,
@CANT VARCHAR(20),@PRE MONEY,@UEX INT,@UPE INT
)
AS
UPDATE COMPRAS.PRODUCTOS
SET NOMPRODUCTO=@PRO,
IDPROVEEDOR=@IDPROV,
IDCATEGORIA=@IDCAT,
CANTXUNIDAD=@CANT,
PRECIOUNIDAD=@PRE,
UNIDADESENEXISTENCIA=@UEX,
UNIDADESENPEDIDO=@UPE
WHERE IDPRODUCTO=@IDPROD
GO
--ELIMINA PRODUCTO
IF OBJECT_ID('SP_ELIMINAPRODUCTO') IS NOT NULL
DROP PROC SP_ELIMINAPRODUCTO
GO
CREATE PROCEDURE SP_ELIMINAPRODUCTO
@COD INT
AS
DELETE FROM COMPRAS.PRODUCTOS
WHERE IDPRODUCTO=@COD
GO
