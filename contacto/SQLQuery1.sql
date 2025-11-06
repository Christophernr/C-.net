create database CONTACTOS2
go

use CONTACTOS2
go

create table contactos
(
	id int identity (1,1)primary key,
	nombre nvarchar(50),
	numero int,
	correo nvarchar(50)
)
go

select * from contactos
go