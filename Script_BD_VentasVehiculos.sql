
-- Usar la base de datos

USE VentasVehiculos;
GO

DROP TABLE Transacciones;
DROP TABLE Vehiculos;
DROP TABLE Clientes;
DROP TABLE Concesionarios;

-- Crear la tabla de vehículos
CREATE TABLE Vehiculos (
    VehiculoID INT PRIMARY KEY,
    Marca NVARCHAR(50),
    Modelo NVARCHAR(50),
    Anio INT,
    Precio DECIMAL(18, 2)
);
GO

-- Crear la tabla de clientes
CREATE TABLE Clientes (
    ClienteID INT PRIMARY KEY,
    Nombre NVARCHAR(100),
    Email NVARCHAR(100),
    Telefono NVARCHAR(20)
);
GO

-- Crear la tabla de concesionarios
CREATE TABLE Concesionarios (
    ConcesionarioID INT PRIMARY KEY,
    Nombre NVARCHAR(100),
    Direccion NVARCHAR(255),
    Ciudad NVARCHAR(50)
);
GO

-- Crear la tabla de transacciones
CREATE TABLE Transacciones (
    TransaccionID INT PRIMARY KEY,
    VehiculoID INT FOREIGN KEY REFERENCES Vehiculos(VehiculoID),
    ClienteID INT FOREIGN KEY REFERENCES Clientes(ClienteID),
    ConcesionarioID INT FOREIGN KEY REFERENCES Concesionarios(ConcesionarioID),
    FechaVenta DATETIME,
    PrecioVenta DECIMAL(18, 2)
);
GO

INSERT INTO Vehiculos VALUES(1, 'BMW',  'X6 M60i', 2024, 450000.0);
INSERT INTO Vehiculos VALUES(2, 'BMW',  'M4 Coupé', 2022, 500000.0);
INSERT INTO Vehiculos VALUES(3, 'Mercedes',  'Maybach GLS', 2023, 280000.0);
INSERT INTO Vehiculos VALUES(4, 'Audi',  'A8', 2024, 400000.0);

INSERT INTO Clientes VALUES(1, 'Jonathan Soto',  'sotto_j@hotmail.com', '3206925727');
INSERT INTO Clientes VALUES(2, 'Catalina',  'catalina@hotmail.com', '3206925727');
INSERT INTO Clientes VALUES(3, 'Fauricio',  'Fauricio@correofalso.com', '3206925727');
INSERT INTO Clientes VALUES(4, 'Valentina',  'valentina@correoverdadero.com', '3206925727');

INSERT INTO Concesionarios VALUES(1, 'Autogermana', 'Cl. 127b #7-15', 'Bogotá DC');
INSERT INTO Concesionarios VALUES(2, 'Concesioanrio', 'Cl. 128b #8-16', 'Bogotá DC');

INSERT INTO Transacciones VALUES(1, 1, 1, 1, GETDATE(), 450000.0);
INSERT INTO Transacciones VALUES(2, 2, 2, 1, GETDATE(), 500000.0);
INSERT INTO Transacciones VALUES(3, 3, 3, 1, GETDATE(), 280000.0);
INSERT INTO Transacciones VALUES(4, 4, 4, 2, GETDATE(), 400000.0);

