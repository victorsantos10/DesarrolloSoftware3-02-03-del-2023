CREATE PROCEDURE [dbo].[InsertaDatos]
	@Nombre NVARCHAR (50), 
	@Apellido NVARCHAR(50),
	@FechaDeNacimiento DATE, 
	@FechaDeIngreso DATE, 
	@Sexo NVARCHAR(MAX), 
	@Estado INT,
	@Comentario NCHAR(150), 
	@Cedula NVARCHAR(MAX)
AS
	INSERT INTO Registro ([Nombre ], Apellidos, FechaNacimiento, FechaIngreso, Sexo, Estado, Comentario, Cedula) 
                               VALUES (@Nombre, @Apellido, @FechaDeNacimiento, @FechaDeIngreso, @Sexo, @Estado, @Comentario, @Cedula)
RETURN 0
