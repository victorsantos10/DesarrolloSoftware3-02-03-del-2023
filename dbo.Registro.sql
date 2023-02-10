CREATE TABLE [dbo].[Registro] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [Nombre ]         NVARCHAR (50) NOT NULL,
    [Apellidos]       NVARCHAR (50) NOT NULL,
    [FechaNacimiento] DATETIME      NOT NULL,
    [FechaIngreso]    DATETIME      NOT NULL DEFAULT (getdata()),
    [Sexo]            NCHAR (50)     NOT NULL,
    [Estado]          INT           NOT NULL DEFAULT ((0)),
    [Comentario]      NCHAR (150)   NULL,
    [Cedula]          NCHAR (50)    NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

