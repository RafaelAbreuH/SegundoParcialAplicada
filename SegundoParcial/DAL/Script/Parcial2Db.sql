CREATE DATABASE Parcial2Db
GO
USE Parcial2Db
GO
CREATE TABLE Vehiculo
(
	VehiculoId int primary key identity(1,1),
	Descripcion varchar(50),
	Mantenimiento int
);

