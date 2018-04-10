CREATE DATABASE SENAI;
USE SENAI;

CREATE TABLE contato(
id			integer primary key identity(1,1),
nome		varchar(200),
endereco	varchar(1000),
telefone	varchar(50),
mensagem	varchar(2000)
);
drop table contato;
select * from contato;