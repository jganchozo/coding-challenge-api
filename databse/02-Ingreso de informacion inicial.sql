

USE Encuestas
GO

INSERT INTO Encuestas
(
	Titulo,
	Descripcion,
	Fecha
)
VALUES
(
	'Preferencias de comida',
	'Esta encuesta tiene como objetivo recopilar las preferencias de comida de los usuarios. Los participantes deberán responder una serie de preguntas relacionadas con diferentes tipos de alimentos y realizar algunos cálculos matemáticos simples.',
	GETDATE()
)


INSERT INTO TipoRespuesta (IDTipoRespuesta, Tipo)
VALUES(1, 'Simple'), (2, 'Libre')

-- Declaracion y seleccion de ids
DECLARE @idEncuesta INT, 
		@idTipoRespuestaSimple INT,
		@idTipoRespuestaLibre INT,
		@idPregunta INT;

SELECT @idEncuesta = e.IDEncuesta 
FROM Encuestas AS e
WHERE e.Titulo = 'Preferencias de comida'

SELECT @idTipoRespuestaSimple = tr.IDTipoRespuesta 
FROM TipoRespuesta tr
WHERE tr.Tipo = 'Simple'

SELECT @idTipoRespuestaLibre = tr.IDTipoRespuesta 
FROM TipoRespuesta tr
WHERE tr.Tipo = 'Libre' 

INSERT INTO Preguntas
(
	IDEncuesta,
	Pregunta,
	IDTipoRespuesta,
	Orden
)
VALUES
(
	@idEncuesta,
	'¿Cuál es tu comida favorita?',
	@idTipoRespuestaSimple,
	1
),
(
	@idEncuesta,
	'¿Cuántas veces a la semana sueles comer comida rápida?',
	@idTipoRespuestaSimple,
	2
),
(
	@idEncuesta,
	'Si tuvieras que elegir solo un tipo de comida para comer durante un mes, ¿cuál sería?',
	@idTipoRespuestaSimple,
	3
),
(
	@idEncuesta,
	'¿Cuántas porciones de frutas y verduras consumes al día, en promedio?',
	@idTipoRespuestaSimple,
	4
),
(
	@idEncuesta,
	'¿Cuál es tu postre favorito?',
	@idTipoRespuestaSimple,
	5
),
(
	@idEncuesta,
	'¿Cuántas horas a la semana dedicas a realizar ejercicio físico?',
	@idTipoRespuestaLibre,
	6
)

--Primera Pregunta
SELECT @idPregunta = p.IDPregunta 
FROM Preguntas AS p
WHERE p.Pregunta = '¿Cuál es tu comida favorita?'

INSERT INTO Opciones(IDPregunta, Opcion, Orden)
VALUES (@idPregunta, 'Pizza', 1),
	   (@idPregunta, 'Hamburguesa', 2),
	   (@idPregunta, 'Sushi', 3),
	   (@idPregunta, 'Ensalada', 4)
	   
--Segunda Pregunta	   
SELECT @idPregunta = p.IDPregunta 
FROM Preguntas AS p
WHERE p.Pregunta = '¿Cuántas veces a la semana sueles comer comida rápida?'

INSERT INTO Opciones(IDPregunta, Opcion, Orden)
VALUES (@idPregunta, 'Menos de una vez', 1),
	   (@idPregunta, 'De 1 a 3 veces', 2),
	   (@idPregunta, 'De 4 a 6 veces', 3),
	   (@idPregunta, 'Más de 6 veces', 4)
	   
	      
--Tercera Pregunta	   
SELECT @idPregunta = p.IDPregunta 
FROM Preguntas AS p
WHERE p.Pregunta = 'Si tuvieras que elegir solo un tipo de comida para comer durante un mes, ¿cuál sería?'

INSERT INTO Opciones(IDPregunta, Opcion, Orden)
VALUES (@idPregunta, 'Italiana', 1),
	   (@idPregunta, 'Mexicana', 2),
	   (@idPregunta, 'China', 3),
	   (@idPregunta, 'India', 4)
	   
--Cuarta Pregunta	   
SELECT @idPregunta = p.IDPregunta 
FROM Preguntas AS p
WHERE p.Pregunta = '¿Cuántas porciones de frutas y verduras consumes al día, en promedio?'

INSERT INTO Opciones(IDPregunta, Opcion, Orden)
VALUES (@idPregunta, 'Menos de 1 porción', 1),
	   (@idPregunta, 'De 1 a 2 porciones', 2),
	   (@idPregunta, 'De 3 a 4 porciones', 3),
	   (@idPregunta, 'Más de 4 porciones', 4)


--Quinta Pregunta	   
SELECT @idPregunta = p.IDPregunta 
FROM Preguntas AS p
WHERE p.Pregunta = '¿Cuál es tu postre favorito?'

INSERT INTO Opciones(IDPregunta, Opcion, Orden)
VALUES (@idPregunta, 'Pastel de chocolate', 1),
	   (@idPregunta, 'Helado', 2),
	   (@idPregunta, 'Frutas frescas', 3),
	   (@idPregunta, 'Flan', 4)


