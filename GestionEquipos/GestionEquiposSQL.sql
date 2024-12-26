-- Crear la base de datos
CREATE DATABASE GestionEquipos;
GO

-- Usar la base de datos
USE GestionEquipos;
GO

-- Crear la tabla Equipos
CREATE TABLE Equipos (
    EquipoID INT IDENTITY(1,1) PRIMARY KEY,
    NombrePersona VARCHAR(50) NOT NULL,
    NombreTecnico VARCHAR(50) NOT NULL,
    NombreEquipo VARCHAR(50) NOT NULL
);
GO

-- Procedimiento para insertar equipos
CREATE PROCEDURE sp_InsertarEquipo
    @NombrePersona VARCHAR(50),
    @NombreTecnico VARCHAR(50),
    @NombreEquipo VARCHAR(50)
AS
BEGIN
    INSERT INTO Equipos (NombrePersona, NombreTecnico, NombreEquipo)
    VALUES (@NombrePersona, @NombreTecnico, @NombreEquipo);
END
GO

-- Procedimiento para leer todos los equipos
CREATE PROCEDURE sp_LeerEquipos
AS
BEGIN
    SELECT EquipoID AS 'ID', NombrePersona AS 'Persona', NombreTecnico AS 'Técnico', NombreEquipo AS 'Equipo'
    FROM Equipos;
END
GO

-- Procedimiento para actualizar equipos por ID
CREATE PROCEDURE sp_ActualizarEquipo
    @EquipoID INT,
    @NombrePersona VARCHAR(50),
    @NombreTecnico VARCHAR(50),
    @NombreEquipo VARCHAR(50)
AS
BEGIN
    UPDATE Equipos
    SET NombrePersona = @NombrePersona,
        NombreTecnico = @NombreTecnico,
        NombreEquipo = @NombreEquipo
    WHERE EquipoID = @EquipoID;
END
GO

-- Procedimiento para eliminar un equipo por NombrePersona
CREATE PROCEDURE sp_EliminarEquipo
    @NombrePersona VARCHAR(50)
AS
BEGIN
    DELETE FROM Equipos
    WHERE NombrePersona = @NombrePersona;

    DECLARE @currentId INT;
    SELECT @currentId = MAX(EquipoID) FROM Equipos;

    IF @currentId IS NULL
    BEGIN
        DBCC CHECKIDENT ('Equipos', RESEED, 0);
    END
    ELSE
    BEGIN
        DBCC CHECKIDENT ('Equipos', RESEED, @currentId);
    END
END
GO

-- Procedimiento para limpiar la tabla Equipos
CREATE PROCEDURE sp_LimpiarTabla
AS
BEGIN
    TRUNCATE TABLE Equipos;
END
GO