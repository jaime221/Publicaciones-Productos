CREATE DATABASE PruebaTecnica

USE PruebaTecnica 

CREATE TABLE Roles (
Id int primary key identity (1,1) not null,
Nombre Varchar(50) not null,
Estado tinyint not null
)

CREATE TABLE Categorias (
Id int primary key identity (1,1) not null,
Nombre Varchar(50) not null,
Estado tinyint not null
)

CREATE TABLE Usuarios (
Id int primary key identity (1,1) not null,
IdRol int not null,
Correo varchar (220) not null,
Nombre varchar (220) not null,
Clave varchar (50) not null,
Estado tinyint not null

foreign key (IdRol) references Roles(Id)
)



select * from Usuarios