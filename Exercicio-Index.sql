create database [BDAula Index]
go
use [BDAula Index]
go

create table City
(
CUST_CODE Varchar(30) primary key,
CUST_NAME varchar(50),
CUST_CITY varchar(50),
WORKING_AREA varchar(50),
CUST_COUNTRY varchar(50),
GRADE int,
OPENING_AMT decimal(9,2),
RECEIVE_AMT decimal(9,2),
PAYMENT_AMT decimal(9,2),
OUTSTANDING_AMT decimal(9,2),
PHONE_NO varchar(20),
AGENT_CODE varchar(20)

);
go

bulk insert City
from'C:\Users\Aluno\Desktop\Index.txt'
with(CodePage='ACP' ,FieldTerminator='|')
select * from City
go

create nonclustered index CustXCity on City (Cust_City ASC)
select * from City
go