-- Crear la Base de Datos
Use Master
Go

Create Database Contratos
Go

Use Contratos
go

-- Crear las Tablas
CREATE TABLE CONTRATO
(
        COD_CONT			char(6) 		NOT NULL,
        PROP_COD_USUA		char(6) 		NULL,
        INQ_COD_USUA		char(6) 		NULL,
        FEC_FIRMA			date			NOT NULL,
        REFERENCIA			varchar(100)	NULL,
        COD_EST				char(6)			NULL
)
 
CREATE TABLE DEPARTAMENTOS (
        COD_EDIF				char(6) NOT NULL,
        COD_DEP					varchar(6) NOT NULL,
        AREA_TOTAL_DEP			int NOT NULL,
        AREA_CONSTRUIDA_DEP		int NULL,
        NUM_AMB_DEP				int NULL,
        PISO_DEP				int NULL,
        PRECIO_ALQXMES_DEP		decimal NULL,
        COD_EST					char(6) NULL
 )
 
CREATE TABLE DETALLECONTRATO (
        COD_EDIF				char(6) NOT NULL,
        COD_DEP					varchar(6) NOT NULL,
        COD_CONT				char(6) NOT NULL,
        FEC_INI_ALQ				datetime NOT NULL,
        FEC_FIN_ALQ				datetime NOT NULL
 )
 
CREATE TABLE EDIFICIOS (
        COD_EDIF				char(6) NOT NULL,
        NOM_EDIF				varchar(60) NOT NULL,
        DIRECC_EDIF				varchar(60) NOT NULL,
        CODPOSTAL_EDIF			varchar(4) NOT NULL,
        AREA_TOTAL_EDIF			int NOT NULL,
        AREA_CONSTRUIDA_EDIF	int NULL,
        REFERENCIA_EDIF			varchar(100) NULL,
        COD_EST					char(6) NULL
 )

CREATE TABLE ESTADO (
        COD_EST					char(6) NOT NULL,
        DESC_EST				varchar(20) NOT NULL
 )
 
CREATE TABLE FAMILIARES (
        COD_FAMI				char(6) NOT NULL,
        COD_USUA				char(6) NOT NULL,
        NOM_FAMI				varchar(25) NOT NULL,
        APEPATER_FAMI			varchar(25) NOT NULL,
        APEMATER_FAMI			varchar(25) NOT NULL,
        GRADO_PARENTES_FAMI		varchar(50) NOT NULL
 )
 

CREATE TABLE INQUILINO (
        COD_USUA				char(6) NOT NULL,
        NOM_AVAL_INQ			varchar(30) NOT NULL,
        APELL_AVAL				char(30) NOT NULL,
        HABER_BAS_INQ			int NOT NULL,
        EST_CIVIL_INQ			char(1) NULL,
        LUG_TRAB_INQ			varchar(50) NULL
 )

CREATE TABLE PROPIETARIO (
        COD_USUA				char(6) NOT NULL,
        TIPO					varchar(30) NOT NULL
 )
 
CREATE TABLE USUARIO (
        COD_USUA				char(6) NOT NULL,
        NOM_USUA				varchar(25) NOT NULL,
        APEPATER_USUA			varchar(25) NOT NULL,
        APEMATER_USUA			varchar(25) NOT NULL,
        FEC_NAC_USUA			datetime NULL,
        FEC_REG_USUA			datetime NULL,
        TIPO_DOC_USUA			varchar(20) NOT NULL,
        NUM_DOC_USUA			char(8) NOT NULL,
        COD_EST					char(6) NULL
 )

-- Agregando las llaves primarias a todas las tablas

ALTER TABLE CONTRATO
        ADD PRIMARY KEY NONCLUSTERED (COD_CONT)

ALTER TABLE DEPARTAMENTOS
        ADD PRIMARY KEY NONCLUSTERED (COD_EDIF, COD_DEP)

ALTER TABLE DETALLECONTRATO
        ADD PRIMARY KEY NONCLUSTERED (COD_EDIF, COD_DEP, COD_CONT)

ALTER TABLE EDIFICIOS
        ADD PRIMARY KEY NONCLUSTERED (COD_EDIF)

ALTER TABLE ESTADO
        ADD PRIMARY KEY NONCLUSTERED (COD_EST)

ALTER TABLE FAMILIARES
        ADD PRIMARY KEY NONCLUSTERED (COD_FAMI, COD_USUA)

ALTER TABLE INQUILINO
        ADD PRIMARY KEY NONCLUSTERED (COD_USUA)

ALTER TABLE PROPIETARIO
        ADD PRIMARY KEY NONCLUSTERED (COD_USUA)

ALTER TABLE USUARIO
        ADD PRIMARY KEY NONCLUSTERED (COD_USUA)


-- Agregando llaves Foráneas y relacionando tablas

ALTER TABLE CONTRATO
        ADD FOREIGN KEY (INQ_COD_USUA) REFERENCES INQUILINO

ALTER TABLE CONTRATO
        ADD FOREIGN KEY (PROP_COD_USUA) REFERENCES PROPIETARIO

ALTER TABLE CONTRATO
        ADD FOREIGN KEY (COD_EST) REFERENCES ESTADO
 
ALTER TABLE DEPARTAMENTOS
        ADD FOREIGN KEY (COD_EDIF) REFERENCES EDIFICIOS

ALTER TABLE DEPARTAMENTOS
        ADD FOREIGN KEY (COD_EST) REFERENCES ESTADO

ALTER TABLE DETALLECONTRATO
        ADD FOREIGN KEY (COD_CONT) REFERENCES CONTRATO

ALTER TABLE DETALLECONTRATO
        ADD FOREIGN KEY (COD_EDIF, COD_DEP) REFERENCES DEPARTAMENTOS

ALTER TABLE EDIFICIOS 
        ADD FOREIGN KEY (COD_EST) REFERENCES ESTADO
 
ALTER TABLE FAMILIARES
        ADD FOREIGN KEY (COD_USUA) REFERENCES INQUILINO

ALTER TABLE INQUILINO
        ADD FOREIGN KEY (COD_USUA) REFERENCES USUARIO

ALTER TABLE PROPIETARIO
        ADD FOREIGN KEY (COD_USUA) REFERENCES USUARIO

ALTER TABLE USUARIO
        ADD FOREIGN KEY (COD_EST) REFERENCES ESTADO
GO


-- Configurar el idioma de los mensajes y el formato de fecha a dmy
-- La configurar tiene alcance 
Set Language spanish
go

-- Visualizar la configuración de idioma que se usa
-- sp_helplanguage 'spanish' 

Use Contratos
Go

--Eliminar registros de las tablas 
Delete From DetalleContrato
Go
Delete From Departamentos
Go
Delete From Edificios
Go
Delete From Contrato
Go
Delete From Familiares
Go
Delete From Inquilino
Go
Delete From Propietario
Go
Delete From Usuario
Go
Delete From Estado
Go

-- Insertar Estados
Insert Into ESTADO(COD_EST,DESC_EST)
Values('EST001','OCUPADO')
Insert Into ESTADO(COD_EST,DESC_EST)
Values('EST002','DESOCUPADO')

-- Insertar Edificios
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF001','La Posadera','Jr. Lima 123','L-01',450)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF002','El Corralito','Av. Saenz Peña 357','L-14',178)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF003','Los Alamos','Av. Del Río 666','L-21',246)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF004','El Aguajal','Jr. Urdanivia 875','L-21',285)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF005','Los Cupisnique','Av. La Mar 966','L-14',178)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF006','El Indice','Av. Las Dromelias 777','L-01',246)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF007','Los Guerreros Moche','Av. De los acá','L-17',246)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF008','Pradera','Zepita 123','L-01',450)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF009','Oh Sol','Malecón Checa 357','L-14',178)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF010','Nogal','Josè Pizarro','L-21',246)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF011','Babilonia','Parinacochas','L-01',450)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF012','Viviana','Lucanas','L-14',178)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF013','Granada','Torre Tagle','L-21',246)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF014','Estación','Planicie','L-01',450)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF015','Hawai','Loreto','L-14',178)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF016','Miverva','Los capulíes','L-10',250)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF017','Los Condes','Av. San Agustín','L-04',247)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF018','Renovación','Jr. Madre de Dios','L-11',175)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF019','San Mateo','Luringancho','L-21',178)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF020','El Epílogo','Independencia','L-15',198)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF021','Res. Urdanivia','Av. Salaverry','L-06',210)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF022','Santo Patrono','Jr. Lucanas','L-14',200)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF023','Las Rocas','Av. Manco Capac','L-18',148)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF024','Los Arbolitos','Calle Plutón','L-19',201)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF025','Madrid','Antofagasta','L-17',115)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF026','Turín','Orellana','L-15',178)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF027','Francia','Yunque','L-06',180)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF028','Res. Infante','Av. César Vallejo','L-01',170)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF029','Las Lomas','Francisco De Zela','L-02',190)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF030','La Colina','Morales Duarez','L-08',205)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF031','El Insurgente','Martín Dulanto','L-07',204)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF032','Martinica','José Ramón Pizarro','L-09',201)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF033','Universitario','Iquique','L-14',179)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF034','El Imperio','Av. Arica','L-15',187)
Insert Into EDIFICIOS(COD_EDIF,NOM_EDIF,DIRECC_EDIF,CODPOSTAL_EDIF,AREA_TOTAL_EDIF)
Values('EDF035','Terranova','Daniel Hernandez','L-16',147)
Go

-- Insertar Departamentos
Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT001',250,6,1,350)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT002',180,5,1,240)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT003',220,5,1,280)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT004',190,4,1,250)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT005',230,6,2,280)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT006',200,5,2,250)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT007',230,6,2,240)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT008',200,5,2,230)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT009',260,6,3,320)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT010',220,5,3,290)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT011',225,7,3,280)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT012',240,8,3,285)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT013',240,8,4,285)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT014',240,8,4,285)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT015',240,8,4,285)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT016',240,8,4,285)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT017',240,8,5,285)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT018',240,8,5,285)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT019',240,8,5,285)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT020',240,8,5,285)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT021',240,8,6,285)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT022',240,8,6,285)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT023',240,8,6,285)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT024',240,8,6,285)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT025',240,8,7,285)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT026',240,8,7,285)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT027',240,8,7,285)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT028',240,8,7,285)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT029',240,8,8,285)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT030',240,8,8,285)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT031',240,8,8,285)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT032',240,8,8,285)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT033',240,8,9,285)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT034',240,8,9,285)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT035',240,8,9,285)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT036',240,8,9,285)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT037',240,8,10,285)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT038',240,8,10,285)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT039',240,8,10,285)

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Values('EDF001','DPT040',240,8,10,285)
Go

-- Inserción múltiple
Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 24
	'EDF003',
	Cod_Dep, 
	Area_Total_Dep * 1.20,
	NUM_AMB_DEP,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.35
From Departamentos
Where Cod_Edif = 'EDF001'

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 20
	'EDF005',
	Cod_Dep, 
	Area_Total_Dep * 0.90,
	NUM_AMB_DEP - 1,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.15
From Departamentos
Where Cod_Edif = 'EDF001'

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 32
	'EDF002',
	Cod_Dep, 
	Area_Total_Dep * 1.50,
	NUM_AMB_DEP + 1,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.80
From Departamentos
Where Cod_Edif = 'EDF001'

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 36
	'EDF004',
	Cod_Dep, 
	Area_Total_Dep * 1.25,
	NUM_AMB_DEP,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.35
From Departamentos
Where Cod_Edif = 'EDF001'

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 32
	'EDF009',
	Cod_Dep, 
	Area_Total_Dep * 1.35,
	NUM_AMB_DEP,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.5
From Departamentos
Where Cod_Edif = 'EDF001'

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 24
	'EDF007',
	Cod_Dep, 
	Area_Total_Dep * 0.95,
	NUM_AMB_DEP - 1,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.05
From Departamentos
Where Cod_Edif = 'EDF001'

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 40
	'EDF006',
	Cod_Dep, 
	Area_Total_Dep * 0.850,
	NUM_AMB_DEP + 1,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.10
From Departamentos
Where Cod_Edif = 'EDF001'

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 24
	'EDF008',
	Cod_Dep, 
	Area_Total_Dep * 1.45,
	NUM_AMB_DEP,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.45
From Departamentos
Where Cod_Edif = 'EDF001'

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 34
	'EDF010',
	Cod_Dep, 
	Area_Total_Dep * 0.950,
	NUM_AMB_DEP + 1,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.25
From Departamentos
Where Cod_Edif = 'EDF001'

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 20
	'EDF011',
	Cod_Dep, 
	Area_Total_Dep * 0.90,
	NUM_AMB_DEP - 1,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.15
From Departamentos
Where Cod_Edif = 'EDF010'

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 24
	'EDF012',
	Cod_Dep, 
	Area_Total_Dep * 1.20,
	NUM_AMB_DEP,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.35
From Departamentos
Where Cod_Edif = 'EDF009'

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 20
	'EDF013',
	Cod_Dep, 
	Area_Total_Dep * 0.90,
	NUM_AMB_DEP - 1,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.15
From Departamentos
Where Cod_Edif = 'EDF008'

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 32
	'EDF014',
	Cod_Dep, 
	Area_Total_Dep * 1.50,
	NUM_AMB_DEP + 1,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.80
From Departamentos
Where Cod_Edif = 'EDF007'

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 36
	'EDF015',
	Cod_Dep, 
	Area_Total_Dep * 1.25,
	NUM_AMB_DEP,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.35
From Departamentos
Where Cod_Edif = 'EDF006'

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 32
	'EDF016',
	Cod_Dep, 
	Area_Total_Dep * 1.35,
	NUM_AMB_DEP,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.5
From Departamentos
Where Cod_Edif = 'EDF004'

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 24
	'EDF017',
	Cod_Dep, 
	Area_Total_Dep * 0.95,
	NUM_AMB_DEP - 1,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.05
From Departamentos
Where Cod_Edif = 'EDF001'

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 40
	'EDF018',
	Cod_Dep, 
	Area_Total_Dep * 0.850,
	NUM_AMB_DEP + 1,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.10
From Departamentos
Where Cod_Edif = 'EDF005'

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 24
	'EDF019',
	Cod_Dep, 
	Area_Total_Dep * 1.45,
	NUM_AMB_DEP,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.45
From Departamentos
Where Cod_Edif = 'EDF003'

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 34
	'EDF020',
	Cod_Dep, 
	Area_Total_Dep * 0.950,
	NUM_AMB_DEP + 1,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.25
From Departamentos
Where Cod_Edif = 'EDF002'

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 20
	'EDF021',
	Cod_Dep, 
	Area_Total_Dep * 0.90,
	NUM_AMB_DEP - 1,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.15
From Departamentos
Where Cod_Edif = 'EDF001'

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 24
	'EDF022',
	Cod_Dep, 
	Area_Total_Dep * 1.20,
	NUM_AMB_DEP,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.35
From Departamentos
Where Cod_Edif = 'EDF003'

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 20
	'EDF023',
	Cod_Dep, 
	Area_Total_Dep * 0.90,
	NUM_AMB_DEP - 1,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.15
From Departamentos
Where Cod_Edif = 'EDF002'

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 32
	'EDF024',
	Cod_Dep, 
	Area_Total_Dep * 1.50,
	NUM_AMB_DEP + 1,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.80
From Departamentos
Where Cod_Edif = 'EDF003'

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 36
	'EDF025',
	Cod_Dep, 
	Area_Total_Dep * 1.25,
	NUM_AMB_DEP,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.35
From Departamentos
Where Cod_Edif = 'EDF006'

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 32
	'EDF026',
	Cod_Dep, 
	Area_Total_Dep * 1.35,
	NUM_AMB_DEP,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.5
From Departamentos
Where Cod_Edif = 'EDF005'

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 24
	'EDF027',
	Cod_Dep, 
	Area_Total_Dep * 0.95,
	NUM_AMB_DEP - 1,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.05
From Departamentos
Where Cod_Edif = 'EDF008'

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 40
	'EDF028',
	Cod_Dep, 
	Area_Total_Dep * 0.850,
	NUM_AMB_DEP + 1,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.10
From Departamentos
Where Cod_Edif = 'EDF010'

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 24
	'EDF029',
	Cod_Dep, 
	Area_Total_Dep * 1.45,
	NUM_AMB_DEP,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.45
From Departamentos
Where Cod_Edif = 'EDF009'

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 34
	'EDF030',
	Cod_Dep, 
	Area_Total_Dep * 0.950,
	NUM_AMB_DEP + 1,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.25
From Departamentos
Where Cod_Edif = 'EDF007'

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 32
	'EDF031',
	Cod_Dep, 
	Area_Total_Dep * 1.35,
	NUM_AMB_DEP,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.5
From Departamentos
Where Cod_Edif = 'EDF015'

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 24
	'EDF032',
	Cod_Dep, 
	Area_Total_Dep * 0.95,
	NUM_AMB_DEP - 1,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.05
From Departamentos
Where Cod_Edif = 'EDF016'

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 40
	'EDF033',
	Cod_Dep, 
	Area_Total_Dep * 0.850,
	NUM_AMB_DEP + 1,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.10
From Departamentos
Where Cod_Edif = 'EDF018'

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 24
	'EDF034',
	Cod_Dep, 
	Area_Total_Dep * 1.45,
	NUM_AMB_DEP,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.45
From Departamentos
Where Cod_Edif = 'EDF019'

Insert Into Departamentos(Cod_Edif,Cod_Dep,Area_Total_Dep,NUM_AMB_DEP,PISO_DEP,PRECIO_ALQXMES_DEP)
Select Top 34
	'EDF035',
	Cod_Dep, 
	Area_Total_Dep * 0.950,
	NUM_AMB_DEP + 1,
	PISO_DEP,
	PRECIO_ALQXMES_DEP * 1.25
From Departamentos
Where Cod_Edif = 'EDF017'
Go

Update Departamentos
Set 
	Area_Construida_Dep = Area_Total_Dep * 0.8,
	Cod_Est = 'EST002'
Go

-- Insertar Usuarios
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU001','Miriam','Pardo','Zapata','DNI','38367346')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU002','Leonardo','Jimenez','Turín','DNI','26429531')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU003','Antonino','Lavalle','Trujillo','DNI','84296130')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU004','Marco','Nicolini','Flores','DNI','03154826')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU005','Juan','Juarez','Hualpa','DNI','08071827')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU006','Giselli','Perez','Saldaña','DNI','37488720')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU007','Andrés','Anselmi','Saldivar','DNI','03164975')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU008','Ramiro','Gálvez','Orellana','DNI','01483587')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU009','Gabriel','Placencia','Pomalaza','DNI','30274954')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU010','Liliana','Gómez','López','DNI','09546396')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU011','Nicolás','Arrieta','Salcedo','DNI','73486492')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU012','Ricardo','García','Belaunde','DNI','81155122')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU013','José María','Antón','Cáceres','DNI','65782349')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU014','Flor','Morote','Salinas','DNI','19734651')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU015','Franco','Damas','Poncio','DNI','97643182')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU016','Renato','Brequeros','Tello','DNI','05578436')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU017','Paula','Noriega','Ramirez','DNI','13497856')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU018','Isabel','Brescia','Marín','DNI','95745321')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU019','Julio César','Quispe','Urbina','DNI','0217896')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU020','Diego Antonio','Limay','Quiroz','DNI','23684826')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU021','ALVARO','DIAZ','SOLANO','DNI','98846655')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU022','ARMANDO','PEREZ','SORIANO','DNI','09982363')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU023','PEDRO','ADRIANZEN','LARA','DNI','09984646')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU024','LUIS','SOLANO','PAREDES','DNI','88474747')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU025','ISAC','LEON','ARIAS','DNI','08864918')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU026','JULIAN','SOLIS','PAUCAR','DNI','08865916')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU027','EDUARDO','RAMIREZ','RUIZ','DNI','08799001')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU028','JOSE LUIS','LEON','CORCUERA','DNI','08766901')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU029','EDUARDO','CRUZADO','COCA','DNI','28817127')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU030','GUILLERMO','VEGA','QUIJANDRIA','DNI','09993911')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU031','MARIO','MONTOYA','LEON','DNI','08864512')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU032','ALBERTO','ISOLA','CASTILLO','DNI','00292992')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU033','FELIPE','CABEL','LOPEZ','DNI','05959959')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU034','JOSE','PEREDA','REY','DNI','08876663')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU035','YOLANDA','CABEL','DE LEON','DNI','03456287')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU036','LUIS','CASTRO','PRADO','DNI','08864551')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU037','JUAN','GOMEZ','LAOS','DNI','08867677')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU038','PEDRO','RUIZ','CESPEDES','DNI','09975665')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU039','RUBEN','SALAS','GARCIA','DNI','08876662')
Insert Into Usuario(COD_USUA,NOM_USUA,APEPATER_USUA,APEMATER_USUA,TIPO_DOC_USUA,NUM_DOC_USUA)
Values('USU040','RAFAEL','SOLANO','PEREZ','DNI','07766531')
Go

-- Insertar Inquilinos
Insert Into Inquilino(COD_USUA,NOM_AVAL_INQ,APELL_AVAL,HABER_BAS_INQ,EST_CIVIL_INQ)
Values('USU002','Rogelio','Barbosa',1250,'C')
Insert Into Inquilino(COD_USUA,NOM_AVAL_INQ,APELL_AVAL,HABER_BAS_INQ,EST_CIVIL_INQ)
Values('USU003','Aurea','Saldivar',2500,'S')
Insert Into Inquilino(COD_USUA,NOM_AVAL_INQ,APELL_AVAL,HABER_BAS_INQ,EST_CIVIL_INQ)
Values('USU004','Luis','Orellana',1380,'C')
Insert Into Inquilino(COD_USUA,NOM_AVAL_INQ,APELL_AVAL,HABER_BAS_INQ,EST_CIVIL_INQ)
Values('USU006','Inés','Salhuana',2450,'C')
Insert Into Inquilino(COD_USUA,NOM_AVAL_INQ,APELL_AVAL,HABER_BAS_INQ,EST_CIVIL_INQ)
Values('USU007','Martha','Marín',3500,'S')
Insert Into Inquilino(COD_USUA,NOM_AVAL_INQ,APELL_AVAL,HABER_BAS_INQ,EST_CIVIL_INQ)
Values('USU010','Noe','Saldaña',3100,'C')
Insert Into Inquilino(COD_USUA,NOM_AVAL_INQ,APELL_AVAL,HABER_BAS_INQ,EST_CIVIL_INQ)
Values('USU011','Angelina','Fernandez',4100,'V')
Insert Into Inquilino(COD_USUA,NOM_AVAL_INQ,APELL_AVAL,HABER_BAS_INQ,EST_CIVIL_INQ)
Values('USU013','Gustavo','Puicón',1800,'C')
Insert Into Inquilino(COD_USUA,NOM_AVAL_INQ,APELL_AVAL,HABER_BAS_INQ,EST_CIVIL_INQ)
Values('USU015','Eugenio','Albites',1780,'C')
Insert Into Inquilino(COD_USUA,NOM_AVAL_INQ,APELL_AVAL,HABER_BAS_INQ,EST_CIVIL_INQ)
Values('USU016','Martin','Delfino',2200,'C')
Insert Into Inquilino(COD_USUA,NOM_AVAL_INQ,APELL_AVAL,HABER_BAS_INQ,EST_CIVIL_INQ)
Values('USU017','Zacarías','Mendoza',2600,'C')
Insert Into Inquilino(COD_USUA,NOM_AVAL_INQ,APELL_AVAL,HABER_BAS_INQ,EST_CIVIL_INQ)
Values('USU018','Denis','Sacovertiz',2480,'S')
Insert Into Inquilino(COD_USUA,NOM_AVAL_INQ,APELL_AVAL,HABER_BAS_INQ,EST_CIVIL_INQ)
Values('USU021','JUAN','DIAZ',1150,'S')
Insert Into Inquilino(COD_USUA,NOM_AVAL_INQ,APELL_AVAL,HABER_BAS_INQ,EST_CIVIL_INQ)
Values('USU023','IRMA','SOTO',750,'C')
Insert Into Inquilino(COD_USUA,NOM_AVAL_INQ,APELL_AVAL,HABER_BAS_INQ,EST_CIVIL_INQ)
Values('USU026','CARLOS','AREVALO',1950,'S')
Insert Into Inquilino(COD_USUA,NOM_AVAL_INQ,APELL_AVAL,HABER_BAS_INQ,EST_CIVIL_INQ)
Values('USU029','CESAR','OJEDA',900,'C')
Insert Into Inquilino(COD_USUA,NOM_AVAL_INQ,APELL_AVAL,HABER_BAS_INQ,EST_CIVIL_INQ)
Values('USU031','JULI0','VEGA',950,'V')
Insert Into Inquilino(COD_USUA,NOM_AVAL_INQ,APELL_AVAL,HABER_BAS_INQ,EST_CIVIL_INQ)
Values('USU032','ANA','ORTEGA',1650,'D')
Insert Into Inquilino(COD_USUA,NOM_AVAL_INQ,APELL_AVAL,HABER_BAS_INQ,EST_CIVIL_INQ)
Values('USU035','JOSE','PALACIOS',950,'D')
Insert Into Inquilino(COD_USUA,NOM_AVAL_INQ,APELL_AVAL,HABER_BAS_INQ,EST_CIVIL_INQ)
Values('USU037','RUBEN','SALAS',900,'S')
Insert Into Inquilino(COD_USUA,NOM_AVAL_INQ,APELL_AVAL,HABER_BAS_INQ,EST_CIVIL_INQ)
Values('USU039','PATRICIA','ARCE',1250,'V')
Insert Into Inquilino(COD_USUA,NOM_AVAL_INQ,APELL_AVAL,HABER_BAS_INQ,EST_CIVIL_INQ)
Values('USU040','RENATO','IRIARTE',1000,'S')
Go

-- Insertar Familiares
Insert Into Familiares(COD_FAMI,COD_USUA,NOM_FAMI,APEPATER_FAMI,APEMATER_FAMI,GRADO_PARENTES_FAMI)
Values('FAM001','USU010','Alex','Honores','Siancas','Hijo')
Insert Into Familiares(COD_FAMI,COD_USUA,NOM_FAMI,APEPATER_FAMI,APEMATER_FAMI,GRADO_PARENTES_FAMI)
Values('FAM001','USU017','Ulises','Jaimes','Pinto','Padre')
Insert Into Familiares(COD_FAMI,COD_USUA,NOM_FAMI,APEPATER_FAMI,APEMATER_FAMI,GRADO_PARENTES_FAMI)
Values('FAM002','USU017','Irma','Saenz','Hinojosa','Madre')
Insert Into Familiares(COD_FAMI,COD_USUA,NOM_FAMI,APEPATER_FAMI,APEMATER_FAMI,GRADO_PARENTES_FAMI)
Values('FAM001','USU031','Elías','Montoya','León','Hermano')
Insert Into Familiares(COD_FAMI,COD_USUA,NOM_FAMI,APEPATER_FAMI,APEMATER_FAMI,GRADO_PARENTES_FAMI)
Values('FAM002','USU031','Martín','Montoya','León','Hermano')
Insert Into Familiares(COD_FAMI,COD_USUA,NOM_FAMI,APEPATER_FAMI,APEMATER_FAMI,GRADO_PARENTES_FAMI)
Values('FAM003','USU031','Inés','Montoya','León','Hermana')
Insert Into Familiares(COD_FAMI,COD_USUA,NOM_FAMI,APEPATER_FAMI,APEMATER_FAMI,GRADO_PARENTES_FAMI)
Values('FAM001','USU018','Genaro','Delgado','Canedo','Abuelo')
Insert Into Familiares(COD_FAMI,COD_USUA,NOM_FAMI,APEPATER_FAMI,APEMATER_FAMI,GRADO_PARENTES_FAMI)
Values('FAM002','USU018','Eulogio','Jimenez','Salcedo','Padrino')
Insert Into Familiares(COD_FAMI,COD_USUA,NOM_FAMI,APEPATER_FAMI,APEMATER_FAMI,GRADO_PARENTES_FAMI)
Values('FAM003','USU018','Yacila','Jimenez','Zopilote','Hija')

-- Insertar Propietarios
Insert Into Propietario(COD_USUA,TIPO)
Select Cod_Usua, ''
From Usuario
Where Cod_Usua Not In(
	Select Cod_Usua From Inquilino
)

-- Insertar Contratos
Insert Into Contrato(COD_CONT,PROP_COD_USUA,INQ_COD_USUA,FEC_FIRMA)
Values('CNT001','USU012','USU010','12/04/2005')
Insert Into Contrato(COD_CONT,PROP_COD_USUA,INQ_COD_USUA,FEC_FIRMA)
Values('CNT002','USU008','USU007','21/06/2005')
Insert Into Contrato(COD_CONT,PROP_COD_USUA,INQ_COD_USUA,FEC_FIRMA)
Values('CNT003','USU020','USU015','07/07/2005')
Insert Into Contrato(COD_CONT,PROP_COD_USUA,INQ_COD_USUA,FEC_FIRMA)
Values('CNT004','USU019','USU017','09/10/2005')
Insert Into Contrato(COD_CONT,PROP_COD_USUA,INQ_COD_USUA,FEC_FIRMA)
Values('CNT005','USU005','USU003','30/01/2005')
Insert Into Contrato(COD_CONT,PROP_COD_USUA,INQ_COD_USUA,FEC_FIRMA)
Values('CNT006','USU014','USU006','17/08/2005')
Insert Into Contrato(COD_CONT,PROP_COD_USUA,INQ_COD_USUA,FEC_FIRMA)
Values('CNT007','USU009','USU013','6/08/2005')
Insert Into Contrato(COD_CONT,PROP_COD_USUA,INQ_COD_USUA,FEC_FIRMA)
Values('CNT008','USU001','USU023','28/02/2004')
Insert Into Contrato(COD_CONT,PROP_COD_USUA,INQ_COD_USUA,FEC_FIRMA)
Values('CNT009','USU009','USU002','4/12/2004')
Insert Into Contrato(COD_CONT,PROP_COD_USUA,INQ_COD_USUA,FEC_FIRMA)
Values('CNT010','USU012','USU026','3/03/2003')
Insert Into Contrato(COD_CONT,PROP_COD_USUA,INQ_COD_USUA,FEC_FIRMA)
Values('CNT011','USU014','USU016','7/08/2004')
Insert Into Contrato(COD_CONT,PROP_COD_USUA,INQ_COD_USUA,FEC_FIRMA)
Values('CNT012','USU024','USU037','18/11/2005')
Insert Into Contrato(COD_CONT,PROP_COD_USUA,INQ_COD_USUA,FEC_FIRMA)
Values('CNT013','USU025','USU004','7/04/2004')
Insert Into Contrato(COD_CONT,PROP_COD_USUA,INQ_COD_USUA,FEC_FIRMA)
Values('CNT014','USU027','USU018','5/06/2004')
Insert Into Contrato(COD_CONT,PROP_COD_USUA,INQ_COD_USUA,FEC_FIRMA)
Values('CNT015','USU028','USU035','2/07/2005')
Insert Into Contrato(COD_CONT,PROP_COD_USUA,INQ_COD_USUA,FEC_FIRMA)
Values('CNT016','USU034','USU011','30/08/2004')
Insert Into Contrato(COD_CONT,PROP_COD_USUA,INQ_COD_USUA,FEC_FIRMA)
Values('CNT017','USU036','USU031','17/09/2004')
Insert Into Contrato(COD_CONT,PROP_COD_USUA,INQ_COD_USUA,FEC_FIRMA)
Values('CNT018','USU038','USU021','1/10/2003')
Insert Into Contrato(COD_CONT,PROP_COD_USUA,INQ_COD_USUA,FEC_FIRMA)
Values('CNT019','USU001','USU035','13/04/2002')
Insert Into Contrato(COD_CONT,PROP_COD_USUA,INQ_COD_USUA,FEC_FIRMA)
Values('CNT020','USU033','USU039','18/06/2001')


-- Insertar Detalle de Contratos
Insert Into DetalleContrato(COD_EDIF,COD_DEP,COD_CONT,FEC_INI_ALQ,FEC_FIN_ALQ)
Values('EDF003','DPT009','CNT006','17/08/2005','17/08/2006')
Insert Into DetalleContrato(COD_EDIF,COD_DEP,COD_CONT,FEC_INI_ALQ,FEC_FIN_ALQ)
Values('EDF002','DPT012','CNT006','17/08/2005','17/11/2005')
Insert Into DetalleContrato(COD_EDIF,COD_DEP,COD_CONT,FEC_INI_ALQ,FEC_FIN_ALQ)
Values('EDF001','DPT007','CNT003','09/07/2005','09/03/2006')
Insert Into DetalleContrato(COD_EDIF,COD_DEP,COD_CONT,FEC_INI_ALQ,FEC_FIN_ALQ)
Values('EDF005','DPT006','CNT007','10/08/2005','10/08/2007')
Insert Into DetalleContrato(COD_EDIF,COD_DEP,COD_CONT,FEC_INI_ALQ,FEC_FIN_ALQ)
Values('EDF005','DPT002','CNT007','10/08/2005','10/08/2007')
Insert Into DetalleContrato(COD_EDIF,COD_DEP,COD_CONT,FEC_INI_ALQ,FEC_FIN_ALQ)
Values('EDF003','DPT008','CNT001','12/04/2005','12/07/2005')
Insert Into DetalleContrato(COD_EDIF,COD_DEP,COD_CONT,FEC_INI_ALQ,FEC_FIN_ALQ)
Values('EDF001','DPT004','CNT004','10/10/2005','10/04/2006')
Insert Into DetalleContrato(COD_EDIF,COD_DEP,COD_CONT,FEC_INI_ALQ,FEC_FIN_ALQ)
Values('EDF002','DPT011','CNT005','01/02/2005','01/08/2005')
Insert Into DetalleContrato(COD_EDIF,COD_DEP,COD_CONT,FEC_INI_ALQ,FEC_FIN_ALQ)
Values('EDF001','DPT010','CNT002','01/07/2005','07/06/2006')
Insert Into DetalleContrato(COD_EDIF,COD_DEP,COD_CONT,FEC_INI_ALQ,FEC_FIN_ALQ)
Values('EDF006','DPT005','CNT008','28/02/2004','28/02/2005')
Insert Into DetalleContrato(COD_EDIF,COD_DEP,COD_CONT,FEC_INI_ALQ,FEC_FIN_ALQ)
Values('EDF007','DPT007','CNT009','4/12/2004','21/03/2005')
Insert Into DetalleContrato(COD_EDIF,COD_DEP,COD_CONT,FEC_INI_ALQ,FEC_FIN_ALQ)
Values('EDF001','DPT007','CNT019','14/04/2002','25/12/2002')
Insert Into DetalleContrato(COD_EDIF,COD_DEP,COD_CONT,FEC_INI_ALQ,FEC_FIN_ALQ)
Values('EDF009','DPT004','CNT010','3/03/2003','3/03/2004')
Insert Into DetalleContrato(COD_EDIF,COD_DEP,COD_CONT,FEC_INI_ALQ,FEC_FIN_ALQ)
Values('EDF008','DPT012','CNT011','7/08/2004','7/12/2004')
Insert Into DetalleContrato(COD_EDIF,COD_DEP,COD_CONT,FEC_INI_ALQ,FEC_FIN_ALQ)
Values('EDF018','DPT010','CNT012','18/11/2005','4/05/2006')
Insert Into DetalleContrato(COD_EDIF,COD_DEP,COD_CONT,FEC_INI_ALQ,FEC_FIN_ALQ)
Values('EDF025','DPT001','CNT013','7/04/2004','7/12/2004')
Insert Into DetalleContrato(COD_EDIF,COD_DEP,COD_CONT,FEC_INI_ALQ,FEC_FIN_ALQ)
Values('EDF015','DPT020','CNT019','27/07/2002','15/01/2003')
Insert Into DetalleContrato(COD_EDIF,COD_DEP,COD_CONT,FEC_INI_ALQ,FEC_FIN_ALQ)
Values('EDF030','DPT009','CNT014','5/06/2004','5/10/2004')
Insert Into DetalleContrato(COD_EDIF,COD_DEP,COD_CONT,FEC_INI_ALQ,FEC_FIN_ALQ)
Values('EDF001','DPT004','CNT015','2/07/2005','2/01/2006')
Insert Into DetalleContrato(COD_EDIF,COD_DEP,COD_CONT,FEC_INI_ALQ,FEC_FIN_ALQ)
Values('EDF034','DPT016','CNT020','20/06/2001','20/06/2002')
Insert Into DetalleContrato(COD_EDIF,COD_DEP,COD_CONT,FEC_INI_ALQ,FEC_FIN_ALQ)
Values('EDF017','DPT020','CNT016','30/08/2004','4/12/2004')
Insert Into DetalleContrato(COD_EDIF,COD_DEP,COD_CONT,FEC_INI_ALQ,FEC_FIN_ALQ)
Values('EDF027','DPT014','CNT020','01/07/2001','13/12/2001')
Insert Into DetalleContrato(COD_EDIF,COD_DEP,COD_CONT,FEC_INI_ALQ,FEC_FIN_ALQ)
Values('EDF009','DPT004','CNT017','17/09/2004','17/12/2004')
Insert Into DetalleContrato(COD_EDIF,COD_DEP,COD_CONT,FEC_INI_ALQ,FEC_FIN_ALQ)
Values('EDF003','DPT008','CNT018','01/10/2003','1/02/2004')
Insert Into DetalleContrato(COD_EDIF,COD_DEP,COD_CONT,FEC_INI_ALQ,FEC_FIN_ALQ)
Values('EDF001','DPT004','CNT020','24/07/2001','31/12/2002')


Update Departamentos
Set 
	Cod_Est = 'EST001'
From Departamentos D
	 Inner Join DetalleContrato DC
	 On D.Cod_Edif = DC.Cod_Edif And D.Cod_Dep = DC.Cod_Dep

Select * From Estado
Select * From Edificios
Select * From Departamentos Order By Cod_Edif, Cod_Dep
Select * From Usuario
Select * From Inquilino
Select * From Familiares
Select * From Propietario
Select * From Contrato
Select * From DetalleContrato