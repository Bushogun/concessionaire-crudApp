-- Usar la base de datos
USE VentasVehiculos;
GO

DROP TABLE ClientexTransacciones;
DROP TABLE Transacciones;
DROP TABLE Clientes;
DROP TABLE Concesionarios;
DROP TABLE Vehiculos;

-- Crear la tabla de vehículos
CREATE TABLE Vehiculos (
    VehiculoID INT PRIMARY KEY,
    Marca NVARCHAR(50),
    Modelo NVARCHAR(50),
    Anio INT,
    Precio DECIMAL(18, 2)
);
GO

-- Crear la tabla de concesionarios
CREATE TABLE Concesionarios (
    ConcesionarioID INT PRIMARY KEY,
    Nombre NVARCHAR(100),
    Direccion NVARCHAR(255),
    Ciudad NVARCHAR(50),
	VehiculoID INT FOREIGN KEY REFERENCES Vehiculos(VehiculoID)
);
GO


-- Crear la tabla de clientes
CREATE TABLE Clientes (
    ClienteID INT PRIMARY KEY,
    Nombre NVARCHAR(100),
    Email NVARCHAR(100),
    Telefono NVARCHAR(20),
	ConcesionarioID INT FOREIGN KEY REFERENCES Concesionarios(ConcesionarioID)
);
GO

-- Crear la tabla de transacciones
CREATE TABLE Transacciones (
    TransaccionID INT  PRIMARY KEY IDENTITY(1,1),
    FechaVenta DATETIME,
    PrecioVenta DECIMAL(18, 2)
);
GO

CREATE TABLE ClientexTransacciones (
	TransaccionID INT FOREIGN KEY REFERENCES Transacciones(TransaccionID),
    ClienteID INT FOREIGN KEY REFERENCES Clientes(ClienteID),
);
GO

INSERT INTO Vehiculos VALUES(1, 'BMW',  'X6 M60i', 2024, 450000.0);
INSERT INTO Vehiculos VALUES(2, 'BMW',  'M4 Coupé', 2022, 500000.0);
INSERT INTO Vehiculos VALUES(3, 'Mercedes',  'Maybach GLS', 2023, 280000.0);
INSERT INTO Vehiculos VALUES(4, 'Audi',  'A8', 2024, 400000.0);

INSERT INTO Concesionarios VALUES(1, 'Autogermana', 'Cl. 127b #7-15', 'Bogotá DC', 1);
INSERT INTO Concesionarios VALUES(2, 'Concesioanrio', 'Cl. 128b #8-16', 'Bogotá DC', 2);

INSERT INTO Clientes VALUES(1, 'Jonathan Soto',  'sotto_j@hotmail.com', '3206925727', 1);
INSERT INTO Clientes VALUES(2, 'Catalina',  'catalina@hotmail.com', '3206925727', 1);
INSERT INTO Clientes VALUES(3, 'Fauricio',  'Fauricio@correofalso.com', '3206925727', 2);
INSERT INTO Clientes VALUES(4, 'Valentina',  'valentina@correoverdadero.com', '3206925727', 2);

INSERT INTO Transacciones (FechaVenta, PrecioVenta) VALUES(GETDATE(), 450000.0);
INSERT INTO Transacciones (FechaVenta, PrecioVenta) VALUES(GETDATE(), 500000.0);
INSERT INTO Transacciones (FechaVenta, PrecioVenta) VALUES(GETDATE(), 280000.0);
INSERT INTO Transacciones (FechaVenta, PrecioVenta) VALUES(GETDATE(), 400000.0);
