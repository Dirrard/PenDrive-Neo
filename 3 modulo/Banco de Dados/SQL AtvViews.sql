create database ViewAtv;
use ViewAtv;
Go
create table PRODUTOS
(
	Id				integer identity(1,1) primary key,
	Nome			varchar(250),
	Fabricante		varchar(250),
	Quantidade		integer,
	ViUnitario		decimal(6,2),
	Tipo			varchar(250)
);
Go
insert into PRODUTOS
values
('Celular','LG',1,2000,'eletronicos'),
('Computador','Hp',1,5000,'eletronicos'),
('Geladeira','electrolux',1,3500,'eletronicos')
Go
create view vwPRODUTOS
as
	select Id			as Código
		,  Nome			as Produto
		,  Fabricante	
		,  ViUnitario	as [Valor Unitario]
		,  Tipo	
	from
			PRODUTOS
Go
select * from vwPRODUTOS;
Go
alter view vwPRODUTOS 
as
	select Id			as Código
		,  Nome			as Produto
		,  Fabricante	
		,  ViUnitario	as [Valor Unitario]
		,  Tipo	
	from
			PRODUTOS
	where 
		ViUnitario > 499.00
Go
Drop view vwPRODUTOS;
