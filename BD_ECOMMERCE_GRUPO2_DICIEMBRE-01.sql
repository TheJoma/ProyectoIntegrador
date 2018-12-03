use master
go


if exists(Select * from sys.databases  Where name='BD_PROYECTO_INTEGRADOR')
Begin
	Drop Database BD_PROYECTO_INTEGRADOR
End
go


Create database BD_PROYECTO_INTEGRADOR
go

use BD_PROYECTO_INTEGRADOR
go

/*
--CREACION TABLA PAIS
create table tb_pais(
codPais	char(3) primary key,
nomPais varchar(25) not null
)
go*/

--CREACION DEL TIPO DE USUARIO
/*create table tb_tipo_usuario(
codTipoUsu int identity(1,1) primary key,
desTipoUsu varchar(25) not null)
go

insert into tb_tipo_usuario values('ADMINISTRADOR')
insert into tb_tipo_usuario values('EMPLEADO')
insert into tb_tipo_usuario values('CLIENTE')
go

select * from tb_tipo_usuario
go*/

--CREACION TABLA EMPLEADO,CLIENTE,ADMINISTRADOR
create table tb_usuario(
codUsu	int identity(1,1) primary key ,
nomUsu	varchar(25) not null,
apePatUsu varchar(25) not null,
apeMatUsu varchar(25) not null,
dniUsu char(8) not null unique,
celUsu char(9) not null,
nickUsu	varchar(25) not null unique,
pwdUsu	varchar(25) not null,
fechaRegistroUsu date default getdate(),
/*codTipoUsu int not null foreign key references tb_tipo_usuario(codTipoUsu),*/
mailUsu	varchar(50) not null 
)
go



insert into tb_usuario values('JOSE MARIA','PARIASCA','MATEO',12345678,123456789,'JOMA','josemaria',getdate(),'joma@hotmail.com')
go
insert into tb_usuario values('RODRIGO','URDAY','VARGAS-CORBACHO',87654321,936692228,'ADM','ro',getdate(),'joma@hotmail.com')
go




--Creacion tabla categorias del producto
create table tb_producto_categoria(
codProdCat	int identity(1,1) primary key ,
nomProdCat	varchar(20) not null
)
go

insert into tb_producto_categoria values ('MOUSE')
insert into tb_producto_categoria values ('TECLADO')
go

select * from tb_producto_categoria
go


--Creacion tabla marca del producto
create table tb_producto_marca(
codProdMar	int identity(1,1) primary key ,
nomProdMar	varchar(20) not null
)
go

insert into tb_producto_marca values('LENOVO')
insert into tb_producto_marca values('HP')
go

select * from tb_producto_marca
go


--Creacion tabla producto
create table tb_producto(
codPro	int identity(1,1) primary key not null,
descripcionPro varchar(50) not null,
detallePro	varchar(255) not null,
precioPro	decimal(20,2) not null,
stockPro	int not null,
imgPro varchar(255) not null,
codProdCat	int foreign key references tb_producto_categoria(codProdCat),
codProdMar	int foreign key references tb_producto_marca(codProdMar)
)
go

--insert into tb_producto values('OPTICAL MOUSE','MOUSE ALAMBRICO COLOR NEGRO',10.20,10,'',1,2)
--insert into tb_producto values('GAMER TECLADO','TECLADO ILUMINADO DE VARIOS COLORES',100.20,12,'',2,1)
--go

select *  from tb_producto
go

create table tb_TipoTarjeta(
idTipoTarjeta int identity (1,1)primary key,
nombreTipoTarjeta varchar(20)
)
go

insert into tb_TipoTarjeta values ('Visa')
insert into tb_TipoTarjeta values ('MasterCard')
insert into tb_TipoTarjeta values ('DinersClub')

select * from tb_TipoTarjeta
go

create table tb_tarjeta(
idTarjeta int identity(1,1) primary key,
idtipoTarjeta int foreign key references tb_tipoTarjeta,
numeroTarjeta varchar(16),
nombreTarjeta varchar(50),
securityCodeTarjeta char(3),
mesExpiracionTarjeta char(2),
añoExpiracionTarjeta char(4),
tarjetaHabilitada bit,
lineaCredito decimal(10,2),
creditoDisponible decimal(10,2)
)
go


--Escenarios 
-- Activado
insert into tb_tarjeta values (1,'1234567890123451','Rodrigo Urday','111','01','2021',1,100,50)
--Desactivado
insert into tb_tarjeta values (1,'1234556789065432','Rodrigo Urday2','222','02','2022',0,100,50)
--Saldo insuficiente
insert into tb_tarjeta values (1,'1234556789065433','Rodrigo Urday3','333','03','2023',1,100,99)


select * from tb_tarjeta
 go



-- PROCEDURES --

-- PROCEDURE LISTAR USUARIO
if object_id('usp_listar_usuarios') is not null
begin
	drop procedure usp_listar_usuarios
end
go

create procedure usp_listar_usuarios
as
begin
	select
		u.codusu,
		u.nomUsu,
		u.apePatUsu,
		u.apeMatUsu,
		u.dniUsu,
		u.celUsu,
		u.nickUsu,
		u.pwdUsu,
		u.fechaRegistroUsu, 
		u.mailUsu 
	from tb_usuario u
end
go

execute usp_listar_usuarios
go

-- PROCEDURE PARA CREAR USUARIO
if object_id('usp_crear_usuarios') is not null
begin
	drop procedure usp_crear_usuarios
end
go

create procedure usp_crear_usuarios
@nomUsu	varchar(25),
@apePatUsu varchar(25),
@apeMatUsu varchar(25),
@dniUsu char(8),
@celUsu char(9),
@nickUsu varchar(25),
@pwdUsu	varchar(25),
@mailUsu varchar(50)
as
begin
	insert into tb_usuario 
		values(@nomUsu,@apePatUsu,@apeMatUsu,@dniUsu,@celUsu,@nickUsu,@pwdUsu,getdate(),@mailUsu)
end
go

execute usp_crear_usuarios 'RONALDO','PAUCAR','PAUCAR',87654322,123456789,'ronaldinho','ronaldo','ronaldo@gmail.com'
go

select * from tb_usuario
go

-- PROCEDURE PARA ACTUALIZAR USUARIO
if object_id('usp_actualizar_usuarios') is not null
begin
	drop procedure usp_actualizar_usuarios
end
go

create procedure usp_actualizar_usuarios
@codUsu int,
@nomUsu	varchar(25),
@apePatUsu varchar(25),
@apeMatUsu varchar(25),
@dniUsu char(8),
@celUsu char(9),
@nickUsu varchar(25),
@pwdUsu	varchar(25),
@mailUsu varchar(50)
as
begin
	update tb_usuario
	set nomUsu = @nomUsu,
		apePatUsu = @apePatUsu,
		apeMatUsu = @apeMatUsu,
		dniUsu = @dniUsu,
		celUsu = @celUsu,
		nickUsu = @nickUsu,
		pwdUsu = @pwdUsu,
		mailUsu = @mailUsu
	where codUsu = @codUsu
	
end
go

execute usp_actualizar_usuarios 3,'RONALDO','PAUCAR','PAUCAR',87654331,123456789,'ronaldinhos','ronaldo','ronaldo@gmail.com'
go

select * from tb_usuario
go

-- PROCEDURE PARA ELIMINAR USUARIO
if object_id('usp_eliminar_usuarios') is not null
begin
	drop procedure usp_eliminar_usuarios
end
go

create procedure usp_eliminar_usuarios
@codUsu int
as
begin
	delete from tb_usuario
	where codUsu = @codUsu	
end
go

execute usp_eliminar_usuarios 3
go

select * from tb_usuario
go

-- PROCEDURE PARA LISTAR COMBO TIPO EMPLEADO
/*
if object_id('usp_listar_tipoUsuario') is not null
begin
	drop procedure usp_listar_tipoUsuario
end
go

create procedure usp_listar_tipoUsuario
as
begin
	select * from tb_tipo_usuario
end
go

execute usp_listar_tipoUsuario 
go

select * from tb_tipo_usuario
go
*/


-- PARA EL PRODUCTO
-- PROCEDURE PARA LISTAR COMBO CATEGORIA
if object_id('usp_listarCombo_categoria') is not null
begin
	drop procedure usp_listarCombo_categoria
end
go

create procedure usp_listarCombo_categoria
as
begin
	select * from tb_producto_categoria
end
go

execute usp_listarCombo_categoria
go

select * from tb_producto_categoria
go



-- PROCEDURE PARA LISTAR COMBO MARCA
if object_id('usp_listarMarca_categoria') is not null
begin
	drop procedure usp_listarMarca_categoria
end
go

create procedure usp_listarMarca_categoria
as
begin
	select * from tb_producto_marca	
end
go

execute usp_listarMarca_categoria 
go

select * from tb_producto_marca
go

-- PROCEDURE LISTAR PRODUCTOS
if object_id('usp_listar_producto') is not null
begin
	drop procedure usp_listar_producto
end
go

create procedure usp_listar_producto
as
begin
	select * from tb_producto
end
go

execute usp_listar_producto
go


-- PROCEDURE OBTENER PRODUCTO
if object_id('usp_obtener_producto') is not null
begin
	drop procedure usp_obtener_producto 
end
go

create procedure usp_obtener_producto @codPro int
as
begin
	select top 1 * from tb_producto where codPro=@codPro
end
go

execute usp_obtener_producto 10
go

if object_id('usp_obtener_categoria') is not null
begin
	drop procedure usp_obtener_categoria 
end
go

create procedure usp_obtener_categoria @codProdCat int
as
begin
	select top 1 * from tb_producto_categoria where codProdCat=@codProdCat
end
go

execute usp_obtener_categoria 1
go


if object_id('usp_obtener_marca') is not null
begin
	drop procedure usp_obtener_marca
end
go

create procedure usp_obtener_marca @codProdMar int
as
begin
	select top 1 * from tb_producto_marca where codProdMar=@codProdMar
end
go

execute usp_obtener_marca 1
go

-- PROCEDURE PARA CREAR PRODUCTOS
if object_id('usp_crear_producto') is not null
begin
	drop procedure usp_crear_producto
end
go

create procedure usp_crear_producto
@descripcionPro	varchar(50),
@detallePro	varchar(255),
@precioPro	decimal(20,2),
@stockPro	int,
@imgPro varchar(255),
@codProdCat	int,
@codProdMar	int
as
begin
	insert into tb_producto 
		values(@descripcionPro,@detallePro,@precioPro,@stockPro,@imgPro,@codProdCat,@codProdMar)
end
go

--execute usp_crear_producto 'ACER NITRO','LAPTOP GAMER ILUMINADO',4500.50,15,'',1,2
--go

select * from tb_producto
go

-- PROCEDURE PARA ACTUALIZAR PRODUCTOS
if object_id('usp_actualizar_producto') is not null
begin
	drop procedure usp_actualizar_producto
end
go

create procedure usp_actualizar_producto
@codPro int,
@descripcionPro	varchar(50),
@detallePro	varchar(255),
@precioPro	decimal(20,2),
@stockPro	int,
@codProdCat	int,
@codProdMar	int
as
begin
	update tb_producto
	set descripcionPro = @descripcionPro,
		detallePro = @detallePro,
		precioPro = @precioPro,
		stockPro = @stockPro,
		codProdCat = @codProdCat,
		codProdMar = @codProdMar
	where codPro = @codPro
end
go

if object_id('usp_actualizar_producto_con_imagen') is not null
begin
	drop procedure usp_actualizar_producto_con_imagen
end
go

create procedure usp_actualizar_producto_con_imagen
@codPro int,
@descripcionPro	varchar(50),
@detallePro	varchar(255),
@precioPro	decimal(20,2),
@stockPro	int,
@imgPro varchar(255),
@codProdCat	int,
@codProdMar	int
as
begin
	update tb_producto
	set descripcionPro = @descripcionPro,
		detallePro = @detallePro,
		precioPro = @precioPro,
		stockPro = @stockPro,
		imgPro=@imgPro,
		codProdCat = @codProdCat,
		codProdMar = @codProdMar
	where codPro = @codPro
end
go

--execute usp_actualizar_producto 6,'ACER NITRO4','LAPTOP GAMER ILUMINADO',4500.50,15,'',1,2
--go

select * from tb_producto
go

-- PROCEDURE PARA ELIMINAR USUARIO
if object_id('usp_eliminar_producto') is not null
begin
	drop procedure usp_eliminar_producto
end
go

create procedure usp_eliminar_producto
@codPro int
as
begin
	delete from tb_producto
	where codPro = @codPro	
end
go

--execute usp_eliminar_producto 6
--go

select * from tb_producto
go

select * from tb_producto_marca 
go

select * from tb_producto_categoria
go 

exec usp_obtener_producto 1
go

exec usp_listarCombo_categoria
go



 create proc sp_GetTarjetaByInfo(
 @idTipoTarjeta int ,
 @numeroTarjeta varchar(16),
 @nombreTarjeta	varchar(50),
 @securityCodeTarjeta char(3),
 @mesExpiracionTarjeta char(2),
 @añoExpiracionTarjeta char(4)
 )
 as
 begin
 select tar.numeroTarjeta,tar.nombreTarjeta,tar.tarjetaHabilitada,tar.creditoDisponible 
 from tb_tarjeta tar where tar.idtipoTarjeta = @idTipoTarjeta 
						
						and tar.numeroTarjeta=@numeroTarjeta 
						and tar.nombreTarjeta = @nombreTarjeta 
						and tar.securityCodeTarjeta=@securityCodeTarjeta 
						and tar.mesExpiracionTarjeta = @mesExpiracionTarjeta
						and tar.añoExpiracionTarjeta=@añoExpiracionTarjeta
 end
 go

 exec sp_GetTarjetaByInfo 1,'1234567890123451','Rodrigo Urday','111','01','2021'

