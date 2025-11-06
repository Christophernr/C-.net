create database SimulacionBanco
go

use SimulacionBanco
go

create table BancoTabla
(
id int identity(1,1) primary key,
cedula int,
nombre nvarchar(80),
contraseña nvarchar(15),
saldo decimal(18,2) default 0 --para que aparezca cero desde 0
)
go

drop table BancoTabla
go