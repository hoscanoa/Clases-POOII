Use master
go
if exists(select * from sysdatabases where name='BDFACTURA')
drop database BDFACTURA
go
create database BDFACTURA
go
use BDFACTURA
go
--------------------Tabla Articulos---------------------------
if exists (select name from sysobjects where name='Articulos' and type='U')
drop table Articulos
go
create table Articulos(
Art_codigo varchar(5) not null constraint pk_artcodigo primary key,
Art_nombre varchar(50),
Art_precio float,
Art_stock int
)
go
--------------------Tabla clientes---------------------------
if exists (select name from sysobjects where name='Clientes' and type='U')
drop table Clientes
go
create table Clientes(
Cli_codigo varchar(5) not null constraint pk_clicodigo primary key,
Cli_nombre varchar(50),
Cli_telefono varchar(8),
cli_ruc varchar(11),
cli_direccion varchar(50),
Estado int default 1
)
go
--------------------Tabla vendedor---------------------------
if exists (select name from sysobjects where name='Vendedor' and type='U')
drop table Vendedor
go
create table Vendedor(
Ven_cod varchar(5) not null constraint pk_vencodigo primary key,
Ven_nom varchar(30),
Ven_telefono varchar(8),
Ven_dir varchar(30),
Fecha datetime,
Usuario varchar(30),
Pass varchar(30)
)
go
--------------------Tabla factura cabecera---------------------------
if exists (select name from sysobjects where name='Fac_cabe' and type='U')
drop table Fac_cabe
go
create table Fac_cabe(
Fac_numero varchar(5) not null constraint pk_facnumero primary key,
Fac_fecha datetime,
Cli_codigo varchar(5) not null foreign key references Clientes(Cli_codigo),
Ven_cod varchar(5) not null foreign key references Vendedor(Ven_cod)
)
go
--------------------Tabla Factura Detalle---------------------------
if exists (select name from sysobjects where name='Fac_deta' and type='U')
drop table Fac_deta
go
create table Fac_deta(
Fac_numero varchar(5) not null foreign key references Fac_cabe(Fac_numero),
Art_codigo varchar(5) not null foreign key references Articulos(Art_codigo),
Art_cantidad int,
Art_Precio float
)
go
--formato de Dia,mes,año
set dateformat dmy
go
insert into Vendedor values('V0001','Eduardo Soto','577-0108','Av Arequipa 790','10/05/1999','cibertec','cibertec')
insert into Vendedor values('V0002','Manuel Virar','477-1258','Av Arica 790','18/07/1999','munuel','ss')
insert into Vendedor values('V0003','Pamela Gutierrez','','Av Los Claveles','05/02/2000','pame','123')
insert into Vendedor values('V0004','Ketty Videna','','AAHH Madre De Dios','12/10/2001','videna','videna')
insert into Vendedor values('V0005','Juan Del Carpio','','Av Nicolas De Pierola','01/01/2002','juan','juan')



insert into Clientes values('C0001','Laura Moreno Lee','1234567','10085931801','Av. La Marina 1234',1)
insert into Clientes values('C0002','Alejandro Moreno','6584503','10085931801','Av. Pardo 456',1)
insert into Clientes values('C0003','Claudia Lee','1237833','10085931801','Av. Principal 123',1)
insert into Clientes values('C0004','Castañeda Blas','7862542','10085931801','Av. Jose 456',1)
insert into Clientes values('C0005','Percy Obando','4523872','10085931801','Av. Enrique 456',1)
insert into Clientes values('C0006','Martin Aparicio','6584503','10085931801','Av. Colonial 456',1)
insert into Clientes values('C0007','Miguel Narva','6584503','10085931801','Av. Eduardo 456',1)
insert into Clientes values('C0008','Claudio Pardo','6584503','10085931801','Av. Coronel 456',1)
insert into Clientes values('C0009','Monica Gonzales','6584503','10085931801','Av. Brazil 456',1)
insert into Clientes values('C0010','Enrique LLagaz','6584503','10085931801','Av. Eduardo 456',1)
insert into Clientes values('C0011','Jhon Morales','6584503','10085931801','Av. Foose 456',1)
insert into Clientes values('C0012','Fernando Redondo','6584503','10085931801','Av. Universitaria 456',1)
insert into Clientes values('C0013','Gabriela Zapata','6584503','10085931801','Av. Peru 456',1)
insert into Clientes values('C0014','Melissa Paico','6584503','10085931801','Av. Quilca 456',1)
insert into Clientes values('C0015','Sandra Campos','6584503','10085931801','Av. Salaverry 456',1)
insert into Clientes values('C0016','Miguel Ramirez','6584503','10085931801','Av. Ejercito 456',1)
insert into Clientes values('C0017','Arturo Diaz','6584503','10085931801','Av. Naciones Unidad 456',1)
insert into Clientes values('C0018','Raul Morientes','6584503','10085931801','Av. Escalante 456',1)
insert into Clientes values('C0019','Eugenio Campos','6584503','10085931801','Av. Callao 456',1)
insert into Clientes values('C0020','Lucila Pardo','6584503','10085931801','Av. Bolognesi 456',1)
insert into Clientes values('C0021','Roberto Baggio','6584503','10085931801','Av. SanBorja 456',1)

insert into Articulos values('A0001','Mouse Genius',25.00,235)
insert into Articulos values('A0002','Pentium III 600',650.00,220)
insert into Articulos values('A0003','Pentium IV 1000',850.00,220)
insert into Articulos values('A0004','Fundas Naylon',12.00,35)
insert into Articulos values('A0005','Memoria Zip 32',60.00,80)
insert into Articulos values('A0006','Tinta BJC21 B/N',28.00,20)
insert into Articulos values('A0007','Impresora Epson 1234',170.00,120)
insert into Articulos values('A0008','Momitor SynMaster 3N',180.00,33)
insert into Articulos values('A0009','Monitor ViweSonic',220.00,92)
insert into Articulos values('A0010','Pentium MMX 260',500.00,97)
insert into Articulos values('A0011','Mouse Microsoft',50.00,320)
insert into Articulos values('A0012','Memoria Dimm 64',80.00,25)
insert into Articulos values('A0014','Impresora Canon 1000',205.00,200)
insert into Articulos values('A0016','Tinta BJC21 Color',25.00,120)
insert into Articulos values('A0019','Teclado Epson 102',30.00,122)
insert into Articulos values('A0020','Mouse Logitech',30.00,190)

insert into Fac_cabe values('F0001','02/02/2000','C0007','V0001')
insert into Fac_cabe values('F0002','03/04/2000','C0005','V0002')
insert into Fac_cabe values('F0003','03/05/2000','C0016','V0002')
insert into Fac_cabe values('F0004','08/12/2000','C0002','V0001')
insert into Fac_cabe values('F0005','08/06/2000','C0005','V0003')
insert into Fac_cabe values('F0006','09/12/2000','C0002','V0002')
insert into Fac_cabe values('F0007','10/09/2000','C0016','V0003')
insert into Fac_cabe values('F0008','12/02/2000','C0005','V0002')
insert into Fac_cabe values('F0009','12/11/2000','C0020','V0003')
insert into Fac_cabe values('F0010','01/06/2001','C0005','V0001')
insert into Fac_cabe values('F0011','01/07/2001','C0012','V0004')
insert into Fac_cabe values('F0012','01/11/2001','C0012','V0001')
insert into Fac_cabe values('F0013','02/10/2001','C0002','V0002')
insert into Fac_cabe values('F0014','02/01/2001','C0011','V0003')
insert into Fac_cabe values('F0015','03/12/2001','C0018','V0002')
insert into Fac_cabe values('F0016','03/03/2001','C0012','V0001')
insert into Fac_cabe values('F0017','03/08/2001','C0001','V0004')
insert into Fac_cabe values('F0018','03/01/2002','C0002','V0001')
insert into Fac_cabe values('F0019','11/01/2002','C0001','V0003')
insert into Fac_cabe values('F0020','05/01/2002','C0002','V0004')
insert into Fac_cabe values('F0021','07/01/2002','C0003','V0002')
insert into Fac_cabe values('F0022','12/02/2002','C0004','V0002')
insert into Fac_cabe values('F0023','10/02/2002','C0005','V0003')
insert into Fac_cabe values('F0024','09/02/2002','C0004','V0004')
insert into Fac_cabe values('F0025','03/03/2002','C0005','V0001')
insert into Fac_cabe values('F0026','05/03/2002','C0004','V0003')
insert into Fac_cabe values('F0027','06/04/2002','C0004','V0001')

insert into Fac_deta values('F0001','A0007',3,170)
insert into Fac_deta values('F0001','A0001',2,25)
insert into Fac_deta values('F0002','A0002',16,650)
insert into Fac_deta values('F0002','A0004',4,12)
insert into Fac_deta values('F0002','A0005',6,60)
insert into Fac_deta values('F0003','A0004',5,12)
insert into Fac_deta values('F0004','A0007',3,170)
insert into Fac_deta values('F0005','A0006',12,28)
insert into Fac_deta values('F0005','A0010',11,500)
insert into Fac_deta values('F0005','A0011',4,50)
insert into Fac_deta values('F0005','A0014',11,205)
insert into Fac_deta values('F0006','A0007',13,170)
insert into Fac_deta values('F0007','A0020',23,30)
insert into Fac_deta values('F0008','A0020',2,30)
insert into Fac_deta values('F0009','A0011',2,50)
insert into Fac_deta values('F0010','A0006',8,28)
insert into Fac_deta values('F0010','A0005',7,60)
insert into Fac_deta values('F0010','A0011',5,50)
insert into Fac_deta values('F0011','A0005',6,60)
insert into Fac_deta values('F0011','A0004',4,12)
insert into Fac_deta values('F0011','A0010',13,500)
insert into Fac_deta values('F0012','A0002',14,220)
insert into Fac_deta values('F0013','A0014',21,205)
insert into Fac_deta values('F0014','A0014',2,205)
insert into Fac_deta values('F0015','A0007',3,170)
insert into Fac_deta values('F0016','A0014',2,205)
insert into Fac_deta values('F0016','A0006',5,28)
insert into Fac_deta values('F0017','A0006',7,28)
insert into Fac_deta values('F0017','A0011',5,50)
insert into Fac_deta values('F0018','A0012',4,80)
insert into Fac_deta values('F0018','A0001',1,25)
insert into Fac_deta values('F0018','A0004',4,12)
insert into Fac_deta values('F0018','A0005',11,60)
insert into Fac_deta values('F0019','A0008',13,180)
insert into Fac_deta values('F0019','A0007',6,170)
insert into Fac_deta values('F0019','A0006',7,28)
insert into Fac_deta values('F0020','A0007',6,170)
insert into Fac_deta values('F0020','A0009',15,220)
insert into Fac_deta values('F0021','A0009',11,220)
insert into Fac_deta values('F0021','A0004',2,12)
insert into Fac_deta values('F0021','A0007',3,170)
insert into Fac_deta values('F0022','A0001',4,25)
insert into Fac_deta values('F0023','A0003',5,850)
insert into Fac_deta values('F0023','A0006',7,28)
insert into Fac_deta values('F0024','A0007',13,170)
insert into Fac_deta values('F0024','A0003',15,850)
insert into Fac_deta values('F0025','A0008',11,180)
insert into Fac_deta values('F0026','A0010',4,500)
insert into Fac_deta values('F0026','A0011',3,50)
insert into Fac_deta values('F0027','A0007',4,170)
insert into Fac_deta values('F0027','A0006',3,28)

select * from vendedor
select * from clientes
select * from articulos
select * from fac_cabe
select * from fac_deta
