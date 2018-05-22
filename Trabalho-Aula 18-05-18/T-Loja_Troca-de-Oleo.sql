create database newoli
go
use newoli
go

create table Usuario
(
/*Codigo int primary key identity(1,1),*/
Codigo Numeric(2) primary key,
Email Varchar(60) not null ,
Senha Varchar(20) not null
);
go

bulk insert Usuario
from 'C:\Users\Aluno\Desktop\Usuario.txt' 
With (FieldTerminator=';')
go

create table Cliente 
(
Codigo Numeric(2) primary key,
Email Varchar(60) not null ,
Nome Varchar(100) not null,
Veiculo Varchar(50) not null,
Placa Varchar(30) not null
);
go

bulk insert Cliente
from 'C:\Users\Aluno\Desktop\Clientes.txt' 
With (FieldTerminator=';')
go

create table Cliente 
(
Codigo Numeric(2) primary key,
Email Varchar(60) not null ,
Nome Varchar(100) not null,
Veiculo Varchar(50) not null,
Placa Varchar(30) not null
);
go


/*
oleo feito
create table Oleo
(
Codigo Numeric(2) primary key,
Nome Varchar(40),
Categoria varchar(30),
Tipo Varchar(30),
Fabricante Varchar(50),
Valor decimal(9,2)
);
go*/

