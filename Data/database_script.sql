-- Criação do banco de dados
CREATE DATABASE VestibularAPI;
GO

-- Uso do banco de dados recém-criado
USE VestibularAPI;
GO

-- Criação da tabela ProcessoSeletivo
CREATE TABLE ProcessoSeletivo (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(255) NOT NULL,
    DataInicio DATE NOT NULL,
    DataFim DATE NOT NULL
);
GO

-- Criação da tabela Lead
CREATE TABLE Lead (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    Telefone NVARCHAR(20),
    CPF NVARCHAR(14) NOT NULL UNIQUE 
);
GO

-- Criação da tabela Oferta
CREATE TABLE Oferta (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(255) NOT NULL,
    Descricao NVARCHAR(1000),
    Vagas INT NOT NULL CHECK (Vagas >= 0)
);
GO

-- Criação da tabela Inscricão
CREATE TABLE Inscricao (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Numero_Inscricao NVARCHAR(50) NOT NULL UNIQUE,
    Data DATE NOT NULL,
    Status NVARCHAR(50) NOT NULL,
    ID_Lead INT NOT NULL,
    ID_ProcessoSeletivo INT NOT NULL,
    ID_Oferta INT NOT NULL,
    CONSTRAINT FK_Inscricao_Lead FOREIGN KEY (ID_Lead) REFERENCES Lead(ID),
    CONSTRAINT FK_Inscricao_ProcessoSeletivo FOREIGN KEY (ID_ProcessoSeletivo) REFERENCES ProcessoSeletivo(ID),
    CONSTRAINT FK_Inscricao_Oferta FOREIGN KEY (ID_Oferta) REFERENCES Oferta(ID)
);
GO