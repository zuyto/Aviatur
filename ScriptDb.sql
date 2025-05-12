

CREATE DATABASE ReservaVuelosDB;
GO

USE ReservaVuelosDB;
GO

CREATE TABLE Reservas (
    Id INT PRIMARY KEY IDENTITY,
    CodigoReserva NVARCHAR(20),
    Cliente NVARCHAR(100),
    Origen NVARCHAR(3),
    Destino NVARCHAR(3),
    OrigenCiudad NVARCHAR(100),
    DestinoCiudad NVARCHAR(100),
    FechaSalida DATE,
    Estado NVARCHAR(20) DEFAULT 'Pendiente'
);

GO

CREATE UNIQUE NONCLUSTERED INDEX IX_Reservas_CodigoReserva
ON Reservas (CodigoReserva);
GO

CREATE NONCLUSTERED INDEX IX_Reservas_FechaSalida
ON Reservas (FechaSalida);
GO

CREATE NONCLUSTERED INDEX IX_Reservas_OrigenDestino
ON Reservas (Origen, Destino);
GO

CREATE NONCLUSTERED INDEX IX_Reservas_FechaOrigen
ON Reservas (FechaSalida, Origen);
GO