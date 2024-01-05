--Crear base de datos 
CREATE DATABASE db_acme;
GO

--Crear tablas

USE db_acme;
GO

CREATE TABLE tabla_sucursales (
    id INT PRIMARY KEY,
    nombre VARCHAR(255) NOT NULL
);

CREATE TABLE tabla_productos (
    id INT PRIMARY KEY,
    nombre VARCHAR(255) NOT NULL,
    codigoBarras VARCHAR(255) NOT NULL,
    precio DECIMAL(10,2) NOT NULL
);

CREATE TABLE tabla_inventario (
    id INT PRIMARY KEY IDENTITY(1,1),
    sucursal_id INT,
    producto_id INT,
    cantidadTotalDeProductosDisponibles INT NOT NULL,
    fechaActualizacion DATETIME NOT NULL,
    FOREIGN KEY (sucursal_id) REFERENCES tabla_sucursales(id),
    FOREIGN KEY (producto_id) REFERENCES tabla_productos(id)
);
GO

--Ejemplo de datos
-- Insertando datos en tabla_sucursales
INSERT INTO tabla_sucursales VALUES (1, 'Sucursal_A'), (2, 'Sucursal_B'), (3, 'Sucursal_C');

-- Insertando datos en tabla_productos
INSERT INTO tabla_productos VALUES 
(1, 'Café', '10010', 7.00),
(2, 'Chocolate', '10011', 15.00),
(3, 'Bonafina', '10012', 12.00);

-- Suponiendo que cada sucursal tiene un inventario inicial que luego se actualizará
INSERT INTO tabla_inventario (sucursal_id, producto_id, cantidadTotalDeProductosDisponibles, fechaActualizacion) VALUES 
(1, 1, 20, GETDATE()), 
(1, 2, 10, GETDATE()), 
(2, 1, 20, GETDATE()), 
(2, 2, 10, GETDATE()), 
(2, 3, 10, GETDATE()), 
(3, 2, 10, GETDATE()), 
(3, 3, 10, GETDATE())  
