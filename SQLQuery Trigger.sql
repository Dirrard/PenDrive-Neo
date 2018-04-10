create database LoR
use LoR
go
create table Guerreiros(
	Id int primary key,
	Name varchar(60),
	status char(1) default 'A'
);
insert into Guerreiros(id, Name, status) Values
(1, 'kopla ','A'),
(2, 'Madingu','A'),
(3, 'Lousana','I'),
(4, 'kirito', 'I'),
(5, 'juhan', 'I'),
(6, 'Posfonk','A' ),
(7, 'Nomirik', 'A'),
(8, 'Budovisk', 'A'),
(9, 'Masturbam', 'I'),
(10, 'yuiafó', 'A');

create table GurreirosLog
	(
	CodEvento int primary key identity(1,1),
	Descricao varchar(60),
	CodErro int,
	Dta varchar(200),
	IDCorreto int
	);
GO

Create trigger trigger1
on Guerreiros 
instead of insert 
as 
begin
if exists(
	select a.Id from inserted as a
	inner join Guerreiros as b
	on  a.Id = b.Id	
)
begin
	raiserror(50010, 16, 1, 'Registro já existe!')
	declare @Data varchar(200)
	Set @Data = (select convert(varchar(5), Id) + '-' + [nome] + '-' + [Status] from inserted)
	insert into GurreirosLog(descricao, CodErro, Dta, IDCorreto)
	values('Violation primary key', 2627, @Data, (select MAX(ID)+1 from Guerreiros))
end

insert into Guerreiros
values 
(1,'kopla', 'A')
select * from GurreirosLog
