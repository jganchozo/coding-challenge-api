--CREATE DATABASE Encuestas
--GO

USE Encuestas
GO

-- Tabla para almacenar las encuestas
CREATE TABLE Encuestas (
    IDEncuesta INT IDENTITY,
    Titulo VARCHAR(100),
    Descripcion VARCHAR(MAX),
    Fecha DATETIME,
    CONSTRAINT PK_Encuestas PRIMARY KEY CLUSTERED(IDEncuesta)
);


-- Tabla para catalogo de tipo de respuesta
CREATE TABLE TipoRespuesta (
	IDTipoRespuesta INT,
	Tipo VARCHAR(32),
	CONSTRAINT PK_TipoRespuesta PRIMARY KEY CLUSTERED(IDTipoRespuesta)
);


-- Tabla para almacenar las preguntas de la encuesta
CREATE TABLE Preguntas (
    IDPregunta INT IDENTITY,
    IDEncuesta INT,
    Pregunta VARCHAR(250),
    IDTipoRespuesta INT,
    Orden INT
    CONSTRAINT FK_Encuestas_Preguntas FOREIGN KEY (IDEncuesta) REFERENCES Encuestas(IDEncuesta),
    CONSTRAINT FK_TipoRespuesta_Preguntas FOREIGN KEY (IDTipoRespuesta) REFERENCES TipoRespuesta(IDTipoRespuesta),
    CONSTRAINT PK_Preguntas PRIMARY KEY CLUSTERED(IDPregunta)
);


-- Tabla para almacenar las opciones de respuesta de las preguntas de selección múltiple
CREATE TABLE Opciones (
    IDOpcion INT IDENTITY,
    IDPregunta INT,
    Opcion VARCHAR(100),
    Orden INT,
    CONSTRAINT FK_Preguntas_Opciones FOREIGN KEY (IDPregunta) REFERENCES Preguntas(IDPregunta),
    CONSTRAINT PK_Opciones PRIMARY KEY CLUSTERED(IDOpcion)
);

-- Tabla para almacenar la información de los encuestados
CREATE TABLE Encuestados (
    IDEncuestado INT IDENTITY,
    Nombre VARCHAR(100),
    Apellido VARCHAR(100),
    Email VARCHAR(100),
    uidUsuario VARCHAR(100)
    CONSTRAINT PK_Encuestados PRIMARY KEY CLUSTERED(IDEncuestado)
);


-- Tabla para almacenar las respuestas de los encuestados
CREATE TABLE Respuestas (
	IDRespuesta INT IDENTITY,
    Codigo UNIQUEIDENTIFIER,
    IDEncuesta INT,
    IDPregunta INT,
    IDEncuestado INT,
    Respuesta VARCHAR(MAX),
    Fecha DATE,
    CONSTRAINT FK_Encuestas_Respuestas FOREIGN KEY (IDEncuesta) REFERENCES Encuestas(IDEncuesta),
    CONSTRAINT FK_Preguntas_Respuestas FOREIGN KEY (IDPregunta) REFERENCES Preguntas(IDPregunta),
    CONSTRAINT FK_Encuestados_Respuestas FOREIGN KEY (IDEncuestado) REFERENCES Encuestados(IDEncuestado),
    CONSTRAINT PK_Respuestas PRIMARY KEY CLUSTERED(IDRespuesta)
);

