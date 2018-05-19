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


/*incompleto
create table Oleo
(
Codigo int primary key identity(1,1),
Nome_Oleo Varchar(40),
Categoria varchar(30) 
);
go*/

