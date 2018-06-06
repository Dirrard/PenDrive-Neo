create database AulaBD0506
go
use AulaBD0506
go

create table [CadastroDePessoas]
(
Codigo int identity(1,1) primary key,
[NomeCompleto] nvarchar(50) not null,
RG varbinary(MAX) not null,
CPF Varbinary(max) not null,
[Login] Varbinary(max) not null,
Senha nvarchar(50) not null,
Ativo bit not null default(0) )
go

create symmetric key ChaveSimetrica01
with algorithm = triple_des_3key encryption
by password = '012345';

select * from sys.symmetric_keys
go

open symmetric key ChaveSimetrica01 decryption by password = '012345';
insert into [CadastroDePessoas](NomeCompleto,RG,CPF,[Login],Senha,Ativo)Values
('Diogo Luiz', 
ENCRYPTBYKEY(KEY_GUID('ChaveSimetrica01'), CONVERT(Varbinary, N'00.000.000-0')),
ENCRYPTBYKEY(KEY_GUID('ChaveSimetrica01'), CONVERT(Varbinary, N'000.000.000-00')),
ENCRYPTBYKEY(KEY_GUID('ChaveSimetrica01'), CONVERT(Varbinary, N'diogoluiz')),
0123456,1);
go

open symmetric key ChaveSimetrica01 decryption by password = '012345';
GO
select 
NomeCompleto,
Convert (nvarchar,DECRYPTBYKEY(RG)) as RG,
Convert (nvarchar,DECRYPTBYKEY(CPF)) as CPF,
Convert (nvarchar,DECRYPTBYKEY([Login])) as [Login],
Senha,
Ativo
 from CadastroDePessoas
 go

 create asymmetric key Chav
 with algorithm = RSA_2048 
 encryption by password=N'Show';
 go

select * from sys.asymmetric_keys
go