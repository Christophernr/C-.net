create database porHacer
go


use porHacer 
go

create table TAREAS(
id int identity(1,1) primary key,
tarea nvarchar (50),
prioridad int,
fecha date
)
go

drop table TAREAS
GO
select * from TAREAS 
go