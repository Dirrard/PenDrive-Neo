CREATE DATABASE MLM;
USE MLM;


CREATE TABLE MODELO(
	ID			INTEGER PRIMARY KEY IDENTITY(1,1),
	NOME		VARCHAR(100) NOT NULL,
	DESCRICAO	VARCHAR(MAX),
	PRECO		DECIMAL(10,2) NOT NULL
)

CREATE TABLE MOTOR(
	ID			INTEGER PRIMARY KEY IDENTITY(1,1),
	TRANSMISSAO	VARCHAR(100) NOT NULL,
	NOME		VARCHAR(100) NOT NULL,
	POTENCIA	INTEGER NOT NULL,
	PRECO		DECIMAL(10,2) NOT NULL
)

CREATE TABLE INTERIOR(
	ID			INTEGER PRIMARY KEY IDENTITY(1,1),
	NOME		VARCHAR(100) NOT NULL,
	BANCO		VARCHAR(100) NOT NULL,
	AC			VARCHAR(100) NOT NULL,
	RADIO		VARCHAR(100) NOT NULL,
	VOLANTE		VARCHAR(100) NOT NULL,
	PRECO		DECIMAL(10,2) NOT NULL
)

CREATE TABLE COR(
	ID			INTEGER PRIMARY KEY IDENTITY(1,1),
	NOME		VARCHAR(100) NOT NULL
)

SELECT * FROM COR;

CREATE TABLE USUARIO(
	ID_MODELO	INTEGER REFERENCES MODELO(ID),
	ID_MOTOR	INTEGER REFERENCES MOTOR(ID),
	ID_INTERIOR	INTEGER REFERENCES INTERIOR(ID),
	ID_COR		INTEGER REFERENCES COR(ID),
	ID			INTEGER PRIMARY KEY IDENTITY(1,1),
	NOME		VARCHAR(200) NOT NULL,
	EMAIL		VARCHAR(200) NOT NULL,
	SENHA		VARCHAR(20) NOT NULL,
	PERMISSAO	BIT NOT NULL,
	VALOR       DECIMAL(10,2)
)





select * from usuario

select * from carro