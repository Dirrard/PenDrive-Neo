create database ListaCursor 
use ListaCursor
go
create table produtos
(
	Cod				integer identity(1,1) primary key,
	Nome			varchar(100),
	Quantidade		integer
);
insert into produtos values ('Matheus', 1)
insert into produtos values ('Maconha', 0)
insert into produtos values ('Espada', 2)
insert into produtos values ('Escudo', 1)
insert into produtos values ('Comida', 6)
insert into produtos values ('Roupa', 7)

declare c_produtos cursor for
select
Nome,
Quantidade

from
produtos
open c_produtos

declare @Nome varchar(100)
declare @Quantidade int 

fetch next from c_produtos into @Nome, @Quantidade
while @@FETCH_STATUS = 0 
begin 
if (@Quantidade < 5)
begin
print 'Quantidade: ' + cast(@Quantidade as varchar)
print 'Itens ' + @nome + ' está acabando'
print '_____________________________'
end
fetch next from c_produtos into @Nome, @Quantidade

end
close c_produtos
deallocate c_produtos