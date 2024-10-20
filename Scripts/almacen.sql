CREATE DATABASE almacen;
USE almacen;

-- Tabla: Proveedor
CREATE TABLE Proveedor (
    nIdProveedor INT PRIMARY KEY IDENTITY,
    cNombre VARCHAR(100),
    cContacto VARCHAR(50),
    cTelefono VARCHAR(18),
    cEmail VARCHAR(60),
    cDireccion VARCHAR(60)
);

-- Tabla: Categoria
CREATE TABLE Categoria (
    nIdCategoria INT PRIMARY KEY IDENTITY,
    cNombre VARCHAR(100),
    cDescripcion VARCHAR(100)
);

-- Tabla: Empleado
CREATE TABLE Empleado (
    nIdEmpleado INT PRIMARY KEY IDENTITY,
    cNombre VARCHAR(50),
    cApellido VARCHAR(50),
    cPuesto VARCHAR(40),
    dFechaContrato DATETIME,
    pSalario DECIMAL(10, 2)
);

-- Tabla: Producto
CREATE TABLE Producto (
    nIdProducto INT PRIMARY KEY IDENTITY,
    nIdProveedor INT,
    nIdCategoria INT,
    cNombre VARCHAR(50),
    cDescripcion VARCHAR(100),
    pPrecio DECIMAL(10, 2),
    FOREIGN KEY (nIdProveedor) REFERENCES Proveedor(nIdProveedor),
    FOREIGN KEY (nIdCategoria) REFERENCES Categoria(nIdCategoria)
);

-- Tabla: OrdenCompra
CREATE TABLE OrdenCompra (
    nIdOrdenCompra INT PRIMARY KEY IDENTITY,
    nIdProveedor INT,
    dFecha DATETIME,
    pTotal DECIMAL(10, 2),
    FOREIGN KEY (nIdProveedor) REFERENCES Proveedor(nIdProveedor)
);

-- Tabla: DetallesOrdenCompra
CREATE TABLE DetallesOrdenCompra (
    nIdDetalle INT PRIMARY KEY IDENTITY,
    nIdOrdenCompra INT,
    nIdProducto INT,
    pCantidad INT,
    pPrecio DECIMAL(10, 2),
    FOREIGN KEY (nIdOrdenCompra) REFERENCES OrdenCompra(nIdOrdenCompra),
    FOREIGN KEY (nIdProducto) REFERENCES Producto(nIdProducto)
);

-- Tabla: Compra
CREATE TABLE Compra (
    nIdCompra INT PRIMARY KEY IDENTITY,
    dFecha DATETIME,
    pTotal DECIMAL(11, 2),
    nIdEmpleado INT,
    FOREIGN KEY (nIdEmpleado) REFERENCES Empleado(nIdEmpleado)
);

-- Tabla: Inventario
CREATE TABLE Inventario (
    nIdInventario INT PRIMARY KEY IDENTITY,
    nIdProducto INT,
    pCantidad INT,
    dFechaActualizar DATETIME,
    FOREIGN KEY (nIdProducto) REFERENCES Producto(nIdProducto)
);

-- Tabla: Kardex
CREATE TABLE Kardex (
    nIdKardex INT PRIMARY KEY IDENTITY,
    nIdProducto INT,
    nIdEmpleado INT,
    dFecha DATETIME,
    cTipoMovimiento VARCHAR(50),
    pCantidad INT,
    FOREIGN KEY (nIdProducto) REFERENCES Producto(nIdProducto),
    FOREIGN KEY (nIdEmpleado) REFERENCES Empleado(nIdEmpleado)
);

-- Procedimientos almacenados para las 9 tablas

-- 1. Procedimientos para Proveedor
ALTER PROCEDURE InsertarProveedor
    @cNombre VARCHAR(100),
    @cContacto VARCHAR(50),
    @cTelefono VARCHAR(18),
    @cEmail VARCHAR(60),
    @cDireccion VARCHAR(60)
AS
BEGIN
    INSERT INTO Proveedor (cNombre, cContacto, cTelefono, cEmail, cDireccion)
    VALUES (@cNombre, @cContacto, @cTelefono, @cEmail, @cDireccion);
	select cast(SCOPE_IDENTITY() as int)
END;
go
ALTER PROCEDURE ActualizarProveedor
    @nIdProveedor INT,
    @cNombre VARCHAR(100),
    @cContacto VARCHAR(50),
    @cTelefono VARCHAR(18),
    @cEmail VARCHAR(60),
    @cDireccion VARCHAR(60)
AS
BEGIN
    UPDATE Proveedor
    SET cNombre = @cNombre, cContacto = @cContacto, cTelefono = @cTelefono, cEmail = @cEmail, cDireccion = @cDireccion
    WHERE nIdProveedor = @nIdProveedor;
	select cast(@@ROWCOUNT as int)
END;
go
ALTER PROCEDURE EliminarProveedor
    @nIdProveedor INT
AS
BEGIN
    DELETE FROM Proveedor WHERE nIdProveedor = @nIdProveedor;
	select cast(@@ROWCOUNT as int)
END;
go
ALTER PROCEDURE SeleccionarProveedores
AS
BEGIN
    SELECT * FROM Proveedor;
END;
go
-- 2. Procedimientos para Categoria
ALTER PROCEDURE InsertarCategoria
    @cNombre VARCHAR(100),
    @cDescripcion VARCHAR(100)
AS
BEGIN
    INSERT INTO Categoria (cNombre, cDescripcion)
    VALUES (@cNombre, @cDescripcion);
	select cast(SCOPE_IDENTITY() as int)
END;
go
ALTER PROCEDURE ActualizarCategoria
    @nIdCategoria INT,
    @cNombre VARCHAR(100),
    @cDescripcion VARCHAR(100)
AS
BEGIN
    UPDATE Categoria
    SET cNombre = @cNombre, cDescripcion = @cDescripcion
    WHERE nIdCategoria = @nIdCategoria;
	select cast(@@ROWCOUNT as int)
END;
go
ALTER PROCEDURE EliminarCategoria
    @nIdCategoria INT
AS
BEGIN
    DELETE FROM Categoria WHERE nIdCategoria = @nIdCategoria;
	select cast(@@ROWCOUNT as int)
END;
go
ALTER PROCEDURE SeleccionarCategorias
AS
BEGIN
    SELECT * FROM Categoria;
END;
go
-- 3. Procedimientos para Empleado
ALTER PROCEDURE InsertarEmpleado
    @cNombre VARCHAR(50),
    @cApellido VARCHAR(50),
    @cPuesto VARCHAR(40),
    @dFechaContrato DATETIME,
    @pSalario DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Empleado (cNombre, cApellido, cPuesto, dFechaContrato, pSalario)
    VALUES (@cNombre, @cApellido, @cPuesto, @dFechaContrato, @pSalario);
	select cast(SCOPE_IDENTITY() as int)
END;
go
ALTER PROCEDURE ActualizarEmpleado
    @nIdEmpleado INT,
    @cNombre VARCHAR(50),
    @cApellido VARCHAR(50),
    @cPuesto VARCHAR(40),
    @dFechaContrato DATETIME,
    @pSalario DECIMAL(10,2)
AS
BEGIN
    UPDATE Empleado
    SET cNombre = @cNombre, cApellido = @cApellido, cPuesto = @cPuesto, dFechaContrato = @dFechaContrato, pSalario = @pSalario
    WHERE nIdEmpleado = @nIdEmpleado;
	select cast(@@ROWCOUNT as int)
END;
go
ALTER PROCEDURE EliminarEmpleado
    @nIdEmpleado INT
AS
BEGIN
    DELETE FROM Empleado WHERE nIdEmpleado = @nIdEmpleado;
	select cast(@@ROWCOUNT as int)
END;
go
ALTER PROCEDURE SeleccionarEmpleados
AS
BEGIN
    SELECT * FROM Empleado;
END;
go
-- 4. Procedimientos para Producto
ALTER PROCEDURE InsertarProducto
    @nIdProveedor INT,
    @nIdCategoria INT,
    @cNombre VARCHAR(50),
    @cDescripcion VARCHAR(100),
    @pPrecio DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Producto (nIdProveedor, nIdCategoria, cNombre, cDescripcion, pPrecio)
    VALUES (@nIdProveedor, @nIdCategoria, @cNombre, @cDescripcion, @pPrecio);
	select cast(SCOPE_IDENTITY() as int)
END;
go
ALTER PROCEDURE ActualizarProducto
    @nIdProducto INT,
    @nIdProveedor INT,
    @nIdCategoria INT,
    @cNombre VARCHAR(50),
    @cDescripcion VARCHAR(100),
    @pPrecio DECIMAL(10,2)
AS
BEGIN
    UPDATE Producto
    SET nIdProveedor = @nIdProveedor, nIdCategoria = @nIdCategoria, cNombre = @cNombre, cDescripcion = @cDescripcion, pPrecio = @pPrecio
    WHERE nIdProducto = @nIdProducto;
	select cast(@@ROWCOUNT as int)
END;
go
ALTER PROCEDURE EliminarProducto
    @nIdProducto INT
AS
BEGIN
    DELETE FROM Producto WHERE nIdProducto = @nIdProducto;
	select cast(@@ROWCOUNT as int)
END;
go
ALTER PROCEDURE SeleccionarProductos
AS
BEGIN
    SELECT * FROM Producto;
END;
go
-- 5. Procedimientos para OrdenCompra
ALTER PROCEDURE InsertarOrdenCompra
    @nIdProveedor INT,
    @dFecha DATETIME,
    @pTotal DECIMAL(10,2)
AS
BEGIN
    INSERT INTO OrdenCompra (nIdProveedor, dFecha, pTotal)
    VALUES (@nIdProveedor, @dFecha, @pTotal);
	select cast(SCOPE_IDENTITY() as int)
END;
go
ALTER PROCEDURE ActualizarOrdenCompra
    @nIdOrdenCompra INT,
    @nIdProveedor INT,
    @dFecha DATETIME,
    @pTotal DECIMAL(10,2)
AS
BEGIN
    UPDATE OrdenCompra
    SET nIdProveedor = @nIdProveedor, dFecha = @dFecha, pTotal = @pTotal
    WHERE nIdOrdenCompra = @nIdOrdenCompra;
	select cast(@@ROWCOUNT as int)
END;
go
ALTER PROCEDURE EliminarOrdenCompra
    @nIdOrdenCompra INT
AS
BEGIN
    DELETE FROM OrdenCompra WHERE nIdOrdenCompra = @nIdOrdenCompra;
	select cast(@@ROWCOUNT as int)
END;
go
ALTER PROCEDURE SeleccionarOrdenesCompra
AS
BEGIN
    SELECT * FROM OrdenCompra;
END;
go
-- 6. Procedimientos para DetallesOrdenCompra
CREATE PROCEDURE InsertarDetallesOrdenCompra
    @nIdOrdenCompra INT,
    @nIdProducto INT,
    @pCantidad INT,
    @pPrecio DECIMAL(10,2)
AS
BEGIN
    INSERT INTO DetallesOrdenCompra (nIdOrdenCompra, nIdProducto, pCantidad, pPrecio)
    VALUES (@nIdOrdenCompra, @nIdProducto, @pCantidad, @pPrecio);
	select cast(SCOPE_IDENTITY() as int)
END;
go
ALTER PROCEDURE ActualizarDetalleOrdenCompra
    @nIdDetalle INT,
    @nIdOrdenCompra INT,
    @nIdProducto INT,
    @pCantidad INT,
    @pPrecio DECIMAL(10,2)
AS
BEGIN
    UPDATE DetallesOrdenCompra
    SET nIdOrdenCompra = @nIdOrdenCompra, nIdProducto = @nIdProducto, pCantidad = @pCantidad, pPrecio = @pPrecio
    WHERE nIdDetalle = @nIdDetalle;
	select cast(@@ROWCOUNT as int)
END;
go
ALTER PROCEDURE EliminarDetalleOrdenCompra
    @nIdDetalle INT
AS
BEGIN
    DELETE FROM DetallesOrdenCompra WHERE nIdDetalle = @nIdDetalle;
	select cast(@@ROWCOUNT as int)

END;
go
CREATE PROCEDURE SeleccionarDetallesOrdenCompra
AS
BEGIN
    SELECT * FROM DetallesOrdenCompra;
END;
go
-- 7. Procedimientos para Compra
ALTER PROCEDURE InsertarCompra
    @dFecha DATETIME,
    @pTotal DECIMAL(11,2),
    @nIdEmpleado INT
AS
BEGIN
    INSERT INTO Compra (dFecha, pTotal, nIdEmpleado)
    VALUES (@dFecha, @pTotal, @nIdEmpleado);
	select cast(SCOPE_IDENTITY() as int)
END;
go
ALTER PROCEDURE ActualizarCompra
    @nIdCompra INT,
    @dFecha DATETIME,
    @pTotal DECIMAL(11,2),
    @nIdEmpleado INT
AS
BEGIN
    UPDATE Compra
    SET dFecha = @dFecha, pTotal = @pTotal, nIdEmpleado = @nIdEmpleado
    WHERE nIdCompra = @nIdCompra;
	select cast(@@ROWCOUNT as int)
END;
go
ALTER PROCEDURE EliminarCompra
    @nIdCompra INT
AS
BEGIN
    DELETE FROM Compra WHERE nIdCompra = @nIdCompra;
	select cast(@@ROWCOUNT as int)
END;
go
ALTER PROCEDURE SeleccionarCompras
AS
BEGIN
    SELECT * FROM Compra;
END;
go
-- 8. Procedimientos para Inventario
ALTER PROCEDURE InsertarInventario
    @nIdProducto INT,
    @pCantidad INT,
    @dFechaActualizar DATETIME
AS
BEGIN
    INSERT INTO Inventario (nIdProducto, pCantidad, dFechaActualizar)
    VALUES (@nIdProducto, @pCantidad, @dFechaActualizar);
	select cast(SCOPE_IDENTITY() as int)
END;
go
ALTER  PROCEDURE ActualizarInventario
    @nIdInventario INT,
    @nIdProducto INT,
    @pCantidad INT,
    @dFechaActualizar DATETIME
AS
BEGIN
    UPDATE Inventario
    SET nIdProducto = @nIdProducto, pCantidad = @pCantidad, dFechaActualizar = @dFechaActualizar
    WHERE nIdInventario = @nIdInventario;
	select cast(@@ROWCOUNT as int)
END;
go
ALTER PROCEDURE EliminarInventario
    @nIdInventario INT
AS
BEGIN
    DELETE FROM Inventario WHERE nIdInventario = @nIdInventario;
	select cast(@@ROWCOUNT as int)
END;
go
ALTER PROCEDURE SeleccionarInventarios
AS
BEGIN
    SELECT * FROM Inventario;
END;
go
-- 9. Procedimientos para Kardex
ALTER  PROCEDURE InsertarKardex
    @nIdProducto INT,
    @nIdEmpleado INT,
    @cTipoMovimiento VARCHAR(50),
    @pCantidad INT,
    @dFecha DATETIME
AS
BEGIN
    INSERT INTO Kardex (nIdProducto, nIdEmpleado, dFecha, cTipoMovimiento, pCantidad)
    VALUES (@nIdProducto, @nIdEmpleado, @dFecha, @cTipoMovimiento, @pCantidad);
	select cast(SCOPE_IDENTITY() as int)
END;
go
ALTER PROCEDURE ActualizarKardex
    @nIdKardex INT,
    @nIdProducto INT,
    @pMovimiento VARCHAR(50),
    @pCantidad INT,
    @dFecha DATETIME
AS
BEGIN
    UPDATE Kardex
    SET nIdProducto = @nIdProducto, @pMovimiento = @pMovimiento, pCantidad = @pCantidad, dFecha = @dFecha
    WHERE nIdKardex = @nIdKardex;
	select cast(@@ROWCOUNT as int)

END;
go
ALTER PROCEDURE EliminarKardex
    @nIdKardex INT
AS
BEGIN
    DELETE FROM Kardex WHERE nIdKardex = @nIdKardex;
	Select cast(@@ROWCOUNT as int)
END;
go
ALTER PROCEDURE SeleccionarKardex
AS
BEGIN
    SELECT * FROM Kardex;
END;
go