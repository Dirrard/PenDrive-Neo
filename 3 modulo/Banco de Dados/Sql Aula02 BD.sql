create database Aula02Bd;
use Aula02Bd;


create table Aluno(
Matricula		varchar(8) primary key,
cpf				varchar(14),
nome			varchar(200),
grau_int		varchar(20),
idade			int,
cidade			varchar(50),
sexo			varchar(1)
);

create table Aula(
professor_cpf		varchar(14),
aluno_matricula		varchar(8),
data				date,
duracao				decimal(4,2),
valor				decimal(8,2)
);

create table professor(
cpf				varchar(14),
nome			varchar(200),
tempo_ensino	integer,
disciplina_id	integer,
);

create table disciplina(
id			integer,
nome		varchar(50),
area		varchar(40)
);

insert into Aluno(Matricula,cpf,nome,grau_int,idade,cidade,sexo)
values
('000001',12345678,'NumSei','ensino1',56,'Curitiba','M'),
('000002',87654321,'SeiNum','ensino2',65,'Curitiba','M'),
('000003',67890432,'MunIes','ensino3',56,'Goiania','F')

select * from Aluno;

insert into professor(cpf,nome,tempo_ensino,disciplina_id)
values
(1234555,'Matheus',25,1),
(1236575,'kaio',23,2),
(5234525,'yuolk',15,4)

select * from professor;

update Aluno set idade = 12 where Matricula = 000001;
delete Aluno where idade > 25;
