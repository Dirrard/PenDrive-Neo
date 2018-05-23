create database Mercado
go
use Mercado
go

create table Categoria(
IdCategoria int primary key,
NomeCategoria Varchar(50)

)
go

create table Produto
(
IdProduto int primary key,
IdCategoria int references Categoria,
NomeProduto Varchar(50),
Valor money
)
go

bulk insert Categoria
from 'C:\Users\Aluno\Desktop\Categoria.txt'
go


bulk insert Produto
from 'C:\Users\Aluno\Desktop\Produto.txt'
with(CodePage='ACP')
go
select * from Produto