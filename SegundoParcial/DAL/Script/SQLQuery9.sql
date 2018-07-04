CREATE DATABASE Parcial2Db
go
USE Parcial2Db
GO
CREATE TABLE Vehiculo
(
	VehiculoId int primary key identity(1,1),
	Descripcion varchar(50),
	Mantenimiento int
);

CREATE TABLE Artiuclo
(
	ArticuloId int primary key identity(1,1),
	Descripcion varchar(50),
	Costo int,
	Ganancia int,
	Precio int,
	Inventario int

);

CREATE TABLE Mantenimiento
(
	MantenimientoId int primary key identity(1,1),
	Costo int,
	Fecha DateTime
);

CREATE TABLE Talleres
(
	TallerId int primary key identity(1,1),
	Nombre varchar(50),



);