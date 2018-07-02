create database VehiculosDb
go
use VehiculosDb
go
create table Vehiculos
(
	VehiculoId int primary key identity(1,1),
	Descripcion varchar,
	Mantenimiento int,
	Fecha DateTime

);


go
insert into Vehiculos(Descripcion, Mantenimiento)
values('Toyota Corolla 2005 LE','0')

go
insert into Vehiculos(Descripcion, Mantenimiento)
values ('Honda CRV 2015 Touring','0')

