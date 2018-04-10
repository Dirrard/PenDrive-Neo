CREATE DATABASE TESTE_CURSOR
GO
USE TESTE_CURSOR
GO
CREATE TABLE CLIENTE
(
	CodigoClienete int primary key,
	NomeCliente varchar(50) null
);
GO
insert into CLIENTE values (1,'Cliente 1')
insert into CLIENTE values (2,'Cliente 2')
insert into CLIENTE values (3,'Cliente 3')
insert into CLIENTE values (4,'Cliente 4')
insert into CLIENTE values (5,'Cliente 5')
GO
declare c_aprendendoCursor cursor for
select
CodigoClienete,
NomeCliente

from
CLIENTE

open c_aprendendoCursor
declare @cod int 
declare @nome varchar(50)

fetch next from c_aprendendoCursor into @cod, @nome
print 'Código do Cliente: ' + cast(@cod as varchar)
print 'nome do Cliente: ' + @nome
print '_____________________________'

fetch next from c_aprendendoCursor into @cod, @nome

print 'Código do Cliente: ' + cast(@cod as varchar)
print 'nome do Cliente: ' + @nome
print '_____________________________'

fetch next from c_aprendendoCursor into @cod, @nome

print 'Código do Cliente: ' + cast(@cod as varchar)
print 'nome do Cliente: ' + @nome
print '_____________________________'

fetch next from c_aprendendoCursor into @cod, @nome

print 'Código do Cliente: ' + cast(@cod as varchar)
print 'nome do Cliente: ' + @nome
print '_____________________________'

close c_aprendendoCursor
deallocate c_aprendendoCursor

declare c_aprendendoCursor2 cursor for
select
CodigoClienete,
NomeCliente

from
CLIENTE

open c_aprendendoCursor2

declare @cod int 
declare @nome varchar(50)

fetch next from c_aprendendoCursor2 into @cod, @nome
while 
begin 

print 'Código do Cliente: ' + cast(@cod as varchar)
print 'nome do Cliente: ' + @nome
print '_____________________________'

fetch next from c_aprendendoCursor2 into @cod, @nome

end 
close c_aprendendoCursor2
deallocate c_aprendendoCursor2


