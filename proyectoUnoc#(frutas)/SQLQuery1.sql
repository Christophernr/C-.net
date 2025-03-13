create database frutascolor
go

use frutascolor
go


create table frutarojas(
	idfrutasrojas int  primary key,
	nombre nvarchar (30),
	--precio int
)
go

insert into frutarojas(idfrutasrojas,nombre)
values(1,'manzana')
go

insert into frutarojas(idfrutasrojas,nombre)
values(next value for sq_frutasrojas,'manzana')
go

insert into frutarojas(idfrutasrojas,nombre)
values(next value for sq_frutasrojas,'fresa')
go


--select*from frutarojas

--drop table frutarojas
create table frutasverdes(
	idfrutasverdes int primary key,
	nombre nvarchar(30),
	precio int
)
go
--secuencias de id
create sequence sq_frutasrojas
as int 
start with 2
increment by 1
no maxvalue 
no cache
go
--drop sequence sq_frutasrojas
create sequence sq_frutasverdes
as int 
start with 1
increment by 1
no maxvalue 
no cache
go


--deberia ser aqui la logica del c#

create proc spInsertarFrutasRojas
@nombreRojo nvarchar(30)
as
insert into frutarojas(idfrutasrojas,nombre)
values(next value for sq_frutasrojas,@nombreRojo)
go

--drop proc spInsertarFrutasRojas
create proc spInsertarFrutasVerdes
@nombre nvarchar(50),
@precio int
as
insert into frutasverdes(idfrutasverdes,nombre,precio)
values(next value for sq_frutasverdes,@nombre,@precio)
go

select * from frutarojas
select * from frutasverdes
