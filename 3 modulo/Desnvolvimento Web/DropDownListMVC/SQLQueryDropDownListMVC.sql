CREATE DATABASE DropDownListMVC;
GO

USE DropDownListMVC;
GO

IF EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'estado')
   DROP TABLE estado
GO

create table estado(
	id			int identity(1,1) not null,
	nome		varchar(100) not null,
	sigla		varchar(2),
	descricao	varchar(max),
	constraint [pk_estado] primary key clustered (id)
);
GO
IF EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'cidade')
   DROP TABLE cidade 
GO

create table cidade(
	id			int identity(1,1) not null,
	nome		varchar(100) not null,
	id_estado	integer references cidade (id) not null,
	descricao	varchar(max),
	constraint [pk_cidade] primary key clustered (id)
);
GO
