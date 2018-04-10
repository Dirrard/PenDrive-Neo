-- criando base de dados
CREATE DATABASE SENAI
GO

-- usando base de dados criada
USE SENAI
GO

-- criando tabela de usuario
IF EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'usuario')
   DROP TABLE usuario
GO

create table usuario (
	id int identity(1,1) not null,
	nome varchar(100) not null,
	[login] varchar(50) not null,
	senha varchar(50) not null,
	estado varchar(2),
	cidade varchar(500),
	sexo char(1),
	administrador bit default 0,
	descricao varchar(max),
	constraint [pk_usuario] primary key clustered (id)		
);
go

-- criando tabela de estado
IF EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'estado')
   DROP TABLE estado
GO

create table estado (
	id int identity(1,1) not null,
	nome varchar(100) not null,
	sigla varchar(2) not null,
	constraint [pk_estado] primary key clustered (id)		
);
go

-- criando tabela de cidade
IF EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'cidade')
   DROP TABLE cidade
GO

create table cidade (
	id int identity(1,1) not null,
	nome varchar(100) not null,
	id_estado integer not null,
	descricao varchar(max),
	constraint [pk_cidade] primary key clustered (id)		
);
go

alter table cidade add constraint [fk_cidade_1] foreign key(id_estado) references estado (id);
go

-- criando tabela de tipo_produto
IF EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tipo_produto')
   DROP TABLE tipo_produto
GO

create table tipo_produto (
	id int identity(1,1) not null,
	nome varchar(100) not null,
	descricao varchar(500),
	constraint [pk_tipo_produto] primary key clustered (id)		
);
go

-- criando tabela de produto
IF EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'produto')
   DROP TABLE produto
GO

create table produto (
	id int identity(1,1) not null,
	nome varchar(100) not null,
	id_tipo_produto integer not null,
	preco decimal(15,2) not null,
	descricao varchar(500),
	constraint [pk_produto] primary key clustered (id)		
);
go

alter table produto add constraint [fk_produto_1] foreign key(id_tipo_produto) references tipo_produto (id);
go