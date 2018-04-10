CREATE  database mvc02
use mvc02

create table usuario(
id			integer primary key identity(1,1),
nome		varchar(200),
endereco	varchar(1000),
telefone	varchar(50)
);

select * from usuario