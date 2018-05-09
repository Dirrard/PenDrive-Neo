CREATE DATABASE EXEMPLO_COPIA
GO

USE EXEMPLO_COPIA

CREATE TABLE PRODUTO 
(
COD INT PRIMARY KEY,
NOME VARCHAR(50),
PRECO DEC(9,2  )

)
BULK INSERT PRODUTO
FROM 'C:\Users\Aluno\Desktop\PRODUTOSTAB.TXT'
With(CODEPAGE='ACP')

select * from PRODUTO

create table TMP_Produtos
(
CodigoBarras varchar(13) not null,
NomeProduto varchar(50) not null,
Categoria varchar(20) not null,
PrecoVenda decimal(12,2) not null
)
go

BULK INSERT TMP_PRODUTOS
FROM 'C:\Users\Aluno\Desktop\PRODUTOS.csv'
with
(
CODEPAGE='ACP',
FIELDTERMINATOR =';',
ROWTERMINATOR='\n',
FIRSTROW = 2
)
go

select * from TMP_Produtos