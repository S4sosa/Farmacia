CREATE DATABASE farmacia_db;
GO
USE farmacia_db;
GO

CREATE TABLE [Personas] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Nombre] VARCHAR(100) NOT NULL,
    [Apellidos] VARCHAR(100) NOT NULL,
    [Documento] VARCHAR(30) NOT NULL,
    [Telefono] VARCHAR(20)
);

CREATE TABLE [Cargos] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Nombre] VARCHAR(100) NOT NULL
);

CREATE TABLE [Empleados] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Persona] INT NOT NULL REFERENCES [Personas]([Id]),
    [Cargo] INT NOT NULL REFERENCES [Cargos]([Id])
);

CREATE TABLE [Clientes] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Persona] INT NOT NULL REFERENCES [Personas]([Id]),
    [FechaRegistro] DATETIME NOT NULL,
    [Activo] BIT NOT NULL
);

CREATE TABLE [Categorias] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Nombre] VARCHAR(100) NOT NULL
);

CREATE TABLE [Presentaciones] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Nombre] VARCHAR(100) NOT NULL
);

CREATE TABLE [MetodosPagos] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Nombre] VARCHAR(100) NOT NULL
);

CREATE TABLE [Laboratorios] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Nombre] VARCHAR(100) NOT NULL
);

CREATE TABLE [Sucursales] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Nombre] VARCHAR(100) NOT NULL,
    [Direccion] VARCHAR(200) NOT NULL,
    [Telefono] VARCHAR(20),
    [Activo] BIT NOT NULL
);

CREATE TABLE [Productos] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Nombre] VARCHAR(150) NOT NULL,
    [Precio] DECIMAL(10,2) NOT NULL,
    [Categoria] INT NOT NULL REFERENCES [Categorias]([Id])
);

CREATE TABLE [Inventarios] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Producto] INT NOT NULL REFERENCES [Productos]([Id]),
    [Sucursal] INT NOT NULL REFERENCES [Sucursales]([Id]),
    [Cantidad] INT NOT NULL
);

CREATE TABLE [Lotes] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Producto] INT NOT NULL REFERENCES [Productos]([Id]),
    [NumLote] VARCHAR(50) NOT NULL,
    [FechaVencimiento] DATE NOT NULL
);

CREATE TABLE [Medicamentos] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Producto] INT NOT NULL REFERENCES [Productos]([Id]),
    [Presentacion] INT NOT NULL REFERENCES [Presentaciones]([Id])
);

CREATE TABLE [Recetas] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Cliente] INT NOT NULL REFERENCES [Clientes]([Id]),
    [MedicoNombre] VARCHAR(150) NOT NULL,
    [FechaEmision] DATETIME NOT NULL
);

CREATE TABLE [DetallesRecetas] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Receta] INT NOT NULL REFERENCES [Recetas]([Id]),
    [Medicamento] INT NOT NULL REFERENCES [Medicamentos]([Id]),
    [Cantidad] INT NOT NULL
);

CREATE TABLE [Ventas] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Cliente] INT NOT NULL REFERENCES [Clientes]([Id]),
    [Fecha] DATETIME NOT NULL,
    [Total] DECIMAL(12,2) NOT NULL
);

CREATE TABLE [DetallesVentas] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Venta] INT NOT NULL REFERENCES [Ventas]([Id]),
    [Producto] INT NOT NULL REFERENCES [Productos]([Id]),
    [Cantidad] INT NOT NULL
);

CREATE TABLE [Facturas] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Venta] INT NOT NULL REFERENCES [Ventas]([Id]),
    [MetodoPago] INT NOT NULL REFERENCES [MetodosPagos]([Id])
);

CREATE TABLE [Compras] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Laboratorio] INT NOT NULL REFERENCES [Laboratorios]([Id]),
    [Fecha] DATETIME NOT NULL,
    [Total] DECIMAL(12,2) NOT NULL
);

CREATE TABLE [DetallesCompras] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Compra] INT NOT NULL REFERENCES [Compras]([Id]),
    [Producto] INT NOT NULL REFERENCES [Productos]([Id]),
    [Cantidad] INT NOT NULL,
    [Precio] DECIMAL(10,2) NOT NULL
);

--insertando valores en cada una de las tablas mientras se hacen las pruebas unitarias. 
--Primero tablas padre y luego hijas.

USE farmacia_db;
GO
 
-- Un registro por tabla, en orden de padres a hijos.
-- Los Id empiezan en 1 (IDENTITY), por eso las claves foraneas usan 1.
 
-- 1. Sin claves foraneas
INSERT INTO [Personas] ([Nombre], [Apellidos], [Documento], [Telefono])
VALUES ('Ana', 'Gomez', '1001', '3001112233');

INSERT INTO [Cargos] ([Nombre]) VALUES ('Farmaceutico');

INSERT INTO [Categorias] ([Nombre]) VALUES ('Analgesicos');

INSERT INTO [Presentaciones] ([Nombre]) VALUES ('Tabletas');

INSERT INTO [MetodosPagos] ([Nombre]) VALUES ('Efectivo');

INSERT INTO [Laboratorios] ([Nombre]) VALUES ('Laboratorio Central');

INSERT INTO [Sucursales] ([Nombre], [Direccion], [Telefono], [Activo])
VALUES ('Sucursal Centro', 'Calle 10 # 20-30', '6041234567', 1);
 
-- 2
INSERT INTO [Empleados] ([Persona], [Cargo]) VALUES (1, 1);
 
INSERT INTO [Clientes] ([Persona], [FechaRegistro], [Activo])
VALUES (1, '20260919', 1);
 
INSERT INTO [Productos] ([Nombre], [Precio], [Categoria])
VALUES ('Acetaminofen 500 mg', 2500.00, 1);
 
INSERT INTO [Compras] ([Laboratorio], [Fecha], [Total])
VALUES (1, '20260919', 50000.00);
 
-- 3
INSERT INTO [Inventarios] ([Producto], [Sucursal], [Cantidad]) VALUES (1, 1, 100);
 
INSERT INTO [Lotes] ([Producto], [NumLote], [FechaVencimiento])
VALUES (1, 'L-001', '20281231');
 
INSERT INTO [Medicamentos] ([Producto], [Presentacion]) VALUES (1, 1);
 
INSERT INTO [Recetas] ([Cliente], [MedicoNombre], [FechaEmision])
VALUES (1, 'Dr. Carlos Ruiz', '20260919');
 
INSERT INTO [Ventas] ([Cliente], [Fecha], [Total])
VALUES (1, '20260919', 5000.00);
 
INSERT INTO [DetallesCompras] ([Compra], [Producto], [Cantidad], [Precio])
VALUES (1, 1, 20, 2000.00);
 
-- 4
INSERT INTO [DetallesRecetas] ([Receta], [Medicamento], [Cantidad]) VALUES (1, 1, 2);

INSERT INTO [DetallesVentas] ([Venta], [Producto], [Cantidad]) VALUES (1, 1, 2);

INSERT INTO [Facturas] ([Venta], [MetodoPago]) VALUES (1, 1);
GO