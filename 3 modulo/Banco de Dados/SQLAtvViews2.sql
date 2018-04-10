create  database Clinica;
use Clinica;
Go
create table Ambulatorios
(
		Id_Ambulatorios			integer identity(1,1) primary key,
		desc_Nome				varchar(50),
		Num_Capacidade			integer
);
Go
create table Medicos
(
		Id_Crm					integer identity(1,1) primary key,
		des_Nome				varchar(50),
		des_Rg					integer,
		Id_Espescialidade		integer references Espescialidades,
		Id_Ambulatorios			integer references Ambulatorios
);
Go
create table Espescialidades
(
		Id_Espescialidade		integer identity(1,1) primary key,
		descricao				varchar(50)
);
Go
create table Consulta
(
		Id_Consulta				integer identity(1,1) primary key,
		desc_diagnostico		varchar(50),
		dta_consulta			varchar(10),
		Id_Crm					integer  references Medicos,
		Id_cpf					integer  references Pacientes
);
Go
create table Pacientes 
(
		Id_cpf					integer identity(1,1) primary key,
		desc_nome				varchar(50),
		Num_idade				integer 
);
Go
create view vwMedico
as
	select Id_Crm			as CRM
		,  des_Nome			 
		,  des_Rg
from
			Medicos
Go
insert into Espescialidades
values
('Leagis'),
('Chatos'),
('fedidos')
Go
insert into Medicos
values
('Matheus',12401674,1,2),
('Lucas',12456789,2,1)
Go
insert into Ambulatorios
values
('JAO',22),
('MAO',2),
('NAO',1)
Go
insert into Consulta
values
('ferrado','10/03/2018'),
('bem','02/03/2018')
Go
insert into Pacientes
values
('Louar',15),
('Gorar',13),
('Galuhar',14)