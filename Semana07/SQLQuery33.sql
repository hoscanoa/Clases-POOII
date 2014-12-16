--Definiendo el formato de la Fecha
SET DATEFORMAT DMY
go
--Verificando la existencia de la Base a crear
if db_id('VENTAS2014') is not null
	begin
		use master
		drop database VENTAS2014
	end
go	
--Creando la Base de datos 
USE MASTER
CREATE DATABASE VENTAS2014
GO

--Activando la Base de datos Ventas
USE VENTAS2014
go

--Creando las Tablas OJO que primero se debe activar la Base de Datos
CREATE TABLE DISTRITO(
COD_DIST CHAR (3) NOT NULL PRIMARY KEY,
DESCRIP_DIST VARCHAR(50)
)
go
CREATE TABLE PRODUCTO(
COD_PRO CHAR(4) not null PRIMARY KEY,
DESCRIP_PRO VARCHAR (40) NOT NULL,
PRECIO_PRO MONEY NOT NULL,
STOCK_ACT_PRO INT NOT NULL,
STOCK_MIN_PRO INT NOT NULL,
)
GO
CREATE TABLE CLIENTE(
COD_CLI CHAR (6) NOT NULL PRIMARY KEY,
NOMBRES  VARCHAR (50) NOT NULL,
APE_PATER_CLI VARCHAR (50) NOT NULL,
APE_MATER_CLI VARCHAR (50) NOT NULL,
DIRECCION_CLI VARCHAR (50)  NULL,
TELEFONO_CLI CHAR (7) NULL,
COD_DIST CHAR (3) NOT NULL REFERENCES DISTRITO,
CORREO_E VARCHAR (50)  NULL
)
GO
CREATE TABLE BOLETA(
COD_BOL CHAR (6) NOT NULL PRIMARY KEY,
FECHA_BOL SMALLDATETIME NOT NULL,
COD_CLI CHAR (6) NOT NULL REFERENCES CLIENTE,
ESTADO_BOL CHAR(2) 
)
GO
CREATE TABLE DETALLEBOLETA(
COD_BOL char (6) not null REFERENCES BOLETA,
COD_PRO CHAR (4) NOT NULL REFERENCES PRODUCTO,
CANTIDAD INT NOT NULL,
PRECIOVENTA  MONEY
PRIMARY KEY (COD_BOL, COD_PRO)
)
GO
--Insertando los registros a las Tablas
INSERT INTO DISTRITO VALUES('L01','CERCADO')
INSERT INTO DISTRITO VALUES('L02','ANCON')
INSERT INTO DISTRITO VALUES('L03','ATE')
INSERT INTO DISTRITO VALUES('L04','BARRANCO')
INSERT INTO DISTRITO VALUES('L05','BRE�A')
INSERT INTO DISTRITO VALUES('L06','CARABAYLLO')
INSERT INTO DISTRITO VALUES('L07','COMAS')
INSERT INTO DISTRITO VALUES('L08','CHACLACAYO')
INSERT INTO DISTRITO VALUES('L09','CHORRILLOS')
INSERT INTO DISTRITO VALUES('L10','EL AGUSTINO')
INSERT INTO DISTRITO VALUES('L11','JESUS MARIA')
INSERT INTO DISTRITO VALUES('L12','LA MOLINA')
INSERT INTO DISTRITO VALUES('L13','LA VICTORIA')
INSERT INTO DISTRITO VALUES('L14','LINCE')
INSERT INTO DISTRITO VALUES('L15','LURIGANCHO')
INSERT INTO DISTRITO VALUES('L16','LURIN')
INSERT INTO DISTRITO VALUES('L17','MAGDALENA')
INSERT INTO DISTRITO VALUES('L18','MIRAFLORES')
INSERT INTO DISTRITO VALUES('L19','PACHACAMAC')
INSERT INTO DISTRITO VALUES('L20','PUCUSANA')
GO

INSERT INTO PRODUCTO VALUES ('P001','PYE DE MANZANA',20,500,200)
INSERT INTO PRODUCTO VALUES ('P002','TORTA DE CHOCOLATE',45,100,50)
INSERT INTO PRODUCTO VALUES ('P003','TORTA TRES LECHES',30,40,20)
INSERT INTO PRODUCTO VALUES ('P004','MOUSE DE MANZANA',35,70,30)
INSERT INTO PRODUCTO VALUES ('P005','ARROZ CON LECHE - ENVASE ESPECIAL',13.00,40,20)
INSERT INTO PRODUCTO VALUES ('P006','MAZAMORRA MORADA',1.50,70,30)
INSERT INTO PRODUCTO VALUES ('P007','YOGURT ARABE',3,100,50)
INSERT INTO PRODUCTO VALUES ('P008','PAN CON POLLO',2.00,500,300)
INSERT INTO PRODUCTO VALUES ('P009','BROWNIE',3,300,150)
INSERT INTO PRODUCTO VALUES ('P010','BESO DE MOZA',1,400,100)
INSERT INTO PRODUCTO VALUES ('P011','PYE DE LIMON',1.70,100,70)
INSERT INTO PRODUCTO VALUES ('P012','TORTA DE NARANJA',16,10,4)
INSERT INTO PRODUCTO VALUES ('P013','TORTA DE FRESA',41,100,60)
INSERT INTO PRODUCTO VALUES ('P014','ALFAJORES',0.30,400,300)
INSERT INTO PRODUCTO VALUES ('P015','CHOCOTEJAS',2,100,80)
INSERT INTO PRODUCTO VALUES ('P016','SUSPIRO A LA LIME�A',3.50,100,80)
GO


INSERT INTO CLIENTE VALUES ('CL0001','ALAN','GARCIA', 'PEREZ','Calle El Pino 346','4677352','L01','alan@peru.gob')
INSERT INTO CLIENTE VALUES ('CL0002','ALBERTO','FIJIMORI','FUJIMORI','JR. Los Reyes 475 ','6734732','L06','albershto_peru@hotmail.com')
INSERT INTO CLIENTE VALUES ('CL0003','ALEJANDRO','TOLEDO', 'MANRIQUE','Jr.Huascar 956','4676732','L04','alejandroT@gmail.com')
INSERT INTO CLIENTE VALUES ('CL0004','MELISSA','BLANCO', 'RUIZ','Calle Arequipa 451','4867438','L03','meli_87@hotmail.com')
INSERT INTO CLIENTE VALUES ('CL0005','ANA','MENDOZA','ALPEREZ','Av. Los Choches 111','2548965','L09','mendoza_ap@hotmail.com')
INSERT INTO CLIENTE VALUES ('CL0006','CRISTINA','ESTARGIDIS', 'CHUQUIN','Jr. Las Liras 456','4789658','L03','celeste@gmail.com')
INSERT INTO CLIENTE VALUES ('CL0007','JOSE','CUEVAS', 'ALARCO','Calle La Encantada 425','5698532','L11','jose_el_santo@hotmail.com')
INSERT INTO CLIENTE VALUES ('CL0008','ANTUANE','RODRIGUES','ALARCON','Av. Dorado nro 347','4589732','L15','i_live_ever@hotmail.com')
INSERT INTO CLIENTE VALUES ('CL0009','MADELINE','SUAREZ', 'ENRREDO','Jr. Los Robles 854','4576738','L19','princesita@gmail.com')
INSERT INTO CLIENTE VALUES ('CL0010','LUIGUI','PELOTA', 'CHUECO','Calle Ca�ito 456','4897421','L14','piedrita@hotmail.com')
INSERT INTO CLIENTE VALUES ('CL0011','CARLOS','COLAN','BARDALES','Av. Los Heroes 895','3698574','L19','bardales_56@hotmail.com')
INSERT INTO CLIENTE VALUES ('CL0012','MARTIN','CARRILLO', 'SALAS','Calle Los Huertos 844','8965952','L18','carrillo@gmail.com')
INSERT INTO CLIENTE VALUES ('CL0013','PEDRO','LAGARTO', 'KILLER','Jr. Agapito 452','1258965','L17','el_escamoso@hotmail.com')
INSERT INTO CLIENTE VALUES ('CL0014','KENJI','ZANABRIA','RODRIGUEZ','Av.Los Estornudos 635','1547894','L20','fujizan@hotmail.com')
INSERT INTO CLIENTE VALUES ('CL0015','LUIS','RAMOS', 'FLORES','Jr.Yamecanse 111','4587964','L13','luramos@gmail.com')
GO

INSERT INTO BOLETA VALUES ('BOL001','22/04/2008','CL0006','01')
INSERT INTO BOLETA VALUES ('BOL002','02/01/2008','CL0001','01')
INSERT INTO BOLETA VALUES ('BOL003','03/10/2008','CL0006','03')
INSERT INTO BOLETA VALUES ('BOL004','01/05/2007','CL0003','02')
INSERT INTO BOLETA VALUES ('BOL005','07/12/2008','CL0002','03')
INSERT INTO BOLETA VALUES ('BOL006','16/08/2008','CL0006','02')
INSERT INTO BOLETA VALUES ('BOL007','03/01/2007','CL0005','02')
INSERT INTO BOLETA VALUES ('BOL008','05/03/2007','CL0006','02')
INSERT INTO BOLETA VALUES ('BOL009','14/09/2008','CL0013','03')
INSERT INTO BOLETA VALUES ('BOL010','18/12/2008','CL0007','01')
INSERT INTO BOLETA VALUES ('BOL011','09/11/2007','CL0008','03')
INSERT INTO BOLETA VALUES ('BOL012','06/10/2007','CL0011','02')
GO

INSERT INTO DETALLEBOLETA VALUES ('BOL001','P001',11,20)
INSERT INTO DETALLEBOLETA VALUES ('BOL001','P012',11,16)
INSERT INTO DETALLEBOLETA VALUES ('BOL002','P004',6,35)
INSERT INTO DETALLEBOLETA VALUES ('BOL002','P001',12,20)
INSERT INTO DETALLEBOLETA VALUES ('BOL002','P008',34,2.0)
INSERT INTO DETALLEBOLETA VALUES ('BOL003','P004',12,35)
INSERT INTO DETALLEBOLETA VALUES ('BOL003','P012',5,16)
INSERT INTO DETALLEBOLETA VALUES ('BOL003','P005',45,13.0)
INSERT INTO DETALLEBOLETA VALUES ('BOL004','P001',24,20)
INSERT INTO DETALLEBOLETA VALUES ('BOL005','P006',22,1.50)
INSERT INTO DETALLEBOLETA VALUES ('BOL005','P016',34,3.50)
INSERT INTO DETALLEBOLETA VALUES ('BOL005','P015',56,2)
INSERT INTO DETALLEBOLETA VALUES ('BOL007','P007',8,3)
INSERT INTO DETALLEBOLETA VALUES ('BOL009','P009',66,3)
INSERT INTO DETALLEBOLETA VALUES ('BOL012','P002',24,45)
GO

--Consultando las tablas creadas
SELECT * FROM CLIENTE
SELECT * FROM DISTRITO
SELECT * FROM PRODUCTO
SELECT * FROM DETALLEBOLETA
SELECT * FROM BOLETA

----------------------------------------------
--------------------------------------------

If OBJECT_ID('SP_AUTO') is not null
	drop proc SP_AUTO
go
Create procedure SP_AUTO
@cod char(4)output 
as 
declare @aux char(3) 
select @aux = max(right(COD_PRO,3)) from PRODUCTO
select @cod = 'P'+right(str(convert(int,@aux)+1001),3) 
--noten que en este procedimiento el par�metro @cod dice output que quiere decir que es de salida. 
go 

declare @aux char(4) 
execute SP_AUTO @aux output 
select @aux 

--insertar
if OBJECT_ID('SP_INSERTARPRODUCTO')is not null
drop proc SP_INSERTARPRODUCTO
go 
create proc SP_INSERTARPRODUCTO
@cod char(4),
@des varchar(40),
@precio money,
@StockAc int,
@StockMin int
as
insert into PRODUCTO values(@cod, @des, @precio, @StockAc,@StockMin)
go

----LISTADO DE PRODUCTOS

if OBJECT_ID('SP_LISTAPRODUCTO') is not null
	drop proc SP_LISTAPRODUCTO
go

create proc SP_LISTAPRODUCTO
as 
select * from PRODUCTO
go
execute SP_LISTAPRODUCTO


--modificar
if OBJECT_ID('SP_MODIFICAPRODUCTO')is not null
drop proc SP_MODIFICAPRODUCTO
go 
create proc SP_MODIFICAPRODUCTO
@cod char(4),
@des varchar(40),
@precio money,
@StockAc int,
@StockMin int
as
UPDATE PRODUCTO set [DESCRIP_PRO]=@des, [PRECIO_PRO]=@precio, [STOCK_ACT_PRO]=@StockAc,[STOCK_MIN_PRO]=@StockMin
WHERE [COD_PRO]=@cod
go


--modificar
if OBJECT_ID('SP_MODIFICAPRODUCTO2')is not null
drop proc SP_MODIFICAPRODUCTO2
go 
create proc SP_MODIFICAPRODUCTO2
@cod char(4),
@des varchar(40),
@precio money,
@StockAc int,
@StockMin int
as
BEGIN
IF NOT EXISTS(SELECT * FROM PRODUCTO WHERE [COD_PRO]=@cod)
	BEGIN
		EXEC SP_INSERTARPRODUCTO @cod, @des, @precio, @StockAc, @StockMin
	END
ELSE
	BEGIN
		UPDATE PRODUCTO set 
		[DESCRIP_PRO]=@des, [PRECIO_PRO]=@precio, [STOCK_ACT_PRO]=@StockAc,[STOCK_MIN_PRO]=@StockMin
		WHERE [COD_PRO]=@cod
	END
END
go