--DDL

CREATE DATABASE Sp_Medical_Group;
GO

USE Sp_Medical_Group;

CREATE TABLE Clinica
(
	idClinica			INT PRIMARY KEY IDENTITY,
	CRM					VARCHAR(200),
	CPNJ				NUMERIC(14),
	Endereco			VARCHAR(200),
	NomeFantasia		VARCHAR(200),
	RazaoSocial			VARCHAR(200)
);

CREATE TABLE Situacao
(
	idSituacao			INT PRIMARY KEY IDENTITY,
	Situacao			VARCHAR(200)
);

CREATE TABLE Especialidade
(
	idEspecialidade		INT PRIMARY KEY IDENTITY,
	Especialidade		VARCHAR(200)
);

CREATE TABLE TipoUsuario
(
	idTipoUsuario		INT PRIMARY KEY IDENTITY,
	Tipo				VARCHAR(200)
);

CREATE TABLE Usuario
(
	idUsuario			INT PRIMARY KEY IDENTITY,
	idTipoUsuario		INT FOREIGN KEY REFERENCES TipoUsuario (idTipoUsuario),
	idClinica			INT FOREIGN KEY REFERENCES Clinica (idClinica),
	Nome				VARCHAR(200),
	Email				VARCHAR(200),
	Senha				VARCHAR(200)
);

CREATE TABLE Paciente
(
	idPaciente			INT PRIMARY KEY IDENTITY,
	idUsuario			INT FOREIGN KEY REFERENCES Usuario (idUsuario),
	Descricao			VARCHAR(200),
	Situacao			INT,
	DataNascimento		DATE,
	Telefone			BIGINT,
	RG					BIGINT,
	CPF					BIGINT,
	Endereco			VARCHAR(200)
);

CREATE TABLE Medico
(
	idMedico			INT PRIMARY KEY IDENTITY,
	idEspecialidade		INT FOREIGN KEY REFERENCES Especialidade (idEspecialidade),
	idUsuario			INT FOREIGN KEY REFERENCES Usuario (idUsuario)
);

CREATE TABLE Consulta
(
	idConsulta			INT PRIMARY KEY IDENTITY,
	idPaciente			INT FOREIGN KEY REFERENCES Paciente (idPaciente),
	idSituacao			INT FOREIGN KEY REFERENCES Situacao (idSituacao),
	idMedico			INT FOREIGN KEY REFERENCES Medico (idMedico),
	DataConsulta		DATETIME,
	Descricao			VARCHAR(200)
);