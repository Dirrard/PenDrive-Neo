create table clientes
(
Cod int identity(1,1) primary key,
Nome varchar(100),
UF varchar(2),
CEP varchar(9)
)

insert into clientes
values
('Rafael Martin Rezende','BA','48907-130'),
('Gael Jorge Yago Nogueira','SP','07158-100'),
('Severino Luiz de Paula','AM','69092-355'),
('Samuel Thiago dos Santos','RJ','25271-300'),
('Arthur Filipe Barros','GO','72860-221'),
('Theo César Lima','RJ','20231-014'),
('Isaac Noah André da Rosa','PI','64606-340'),
('Benedito Kaique Fernando da Mata','RO','76822-128'),
('José Leonardo Enrico Caldeira','RO','76808-640'),
('José André Cardoso','AP','68928-319');

create nonclustered index idx_UF on clientes (UF ASC) Include (CEP)

update statistics clientes

select Nome from clientes where uf='RJ';