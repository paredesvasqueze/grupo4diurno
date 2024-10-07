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

-- Procedimientos para Proveedor
CREATE PROCEDURE InsertarProveedor
    @cNombre VARCHAR(100),
    @cContacto VARCHAR(50),
    @cTelefono VARCHAR(18),
    @cEmail VARCHAR(60),
    @cDireccion VARCHAR(60)
AS
BEGIN
    INSERT INTO Proveedor (cNombre, cContacto, cTelefono, cEmail, cDireccion)
    VALUES (@cNombre, @cContacto, @cTelefono, @cEmail, @cDireccion);
END;

CREATE PROCEDURE ActualizarProveedor
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
END;

CREATE PROCEDURE EliminarProveedor
    @nIdProveedor INT
AS
BEGIN
    DELETE FROM Proveedor WHERE nIdProveedor = @nIdProveedor;
END;

CREATE PROCEDURE SeleccionarProveedores
AS
BEGIN
    SELECT * FROM Proveedor;
END;

-- Procedimientos para Categoria
CREATE PROCEDURE InsertarCategoria
    @cNombre VARCHAR(100),
    @cDescripcion VARCHAR(100)
AS
BEGIN
    INSERT INTO Categoria (cNombre, cDescripcion)
    VALUES (@cNombre, @cDescripcion);
END;

CREATE PROCEDURE ActualizarCategoria
    @nIdCategoria INT,
    @cNombre VARCHAR(100),
    @cDescripcion VARCHAR(100)
AS
BEGIN
    UPDATE Categoria
    SET cNombre = @cNombre, cDescripcion = @cDescripcion
    WHERE nIdCategoria = @nIdCategoria;
END;

CREATE PROCEDURE EliminarCategoria
    @nIdCategoria INT
AS
BEGIN
    DELETE FROM Categoria WHERE nIdCategoria = @nIdCategoria;
END;

CREATE PROCEDURE SeleccionarCategorias
AS
BEGIN
    SELECT * FROM Categoria;
END;

-- Procedimientos para Empleado
CREATE PROCEDURE InsertarEmpleado
    @cNombre VARCHAR(50),
    @cApellido VARCHAR(50),
    @cPuesto VARCHAR(40),
    @dFechaContrato DATETIME,
    @pSalario DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Empleado (cNombre, cApellido, cPuesto, dFechaContrato, pSalario)
    VALUES (@cNombre, @cApellido, @cPuesto, @dFechaContrato, @pSalario);
END;

CREATE PROCEDURE ActualizarEmpleado
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
END;

CREATE PROCEDURE EliminarEmpleado
    @nIdEmpleado INT
AS
BEGIN
    DELETE FROM Empleado WHERE nIdEmpleado = @nIdEmpleado;
END;

CREATE PROCEDURE SeleccionarEmpleados
AS
BEGIN
    SELECT * FROM Empleado;
END;

-- Procedimientos para Producto
CREATE PROCEDURE InsertarProducto
    @nIdProveedor INT,
    @nIdCategoria INT,
    @cNombre VARCHAR(50),
    @cDescripcion VARCHAR(100),
    @pPrecio DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Producto (nIdProveedor, nIdCategoria, cNombre, cDescripcion, pPrecio)
    VALUES (@nIdProveedor, @nIdCategoria, @cNombre, @cDescripcion, @pPrecio);
END;

CREATE PROCEDURE ActualizarProducto
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
END;

CREATE PROCEDURE EliminarProducto
    @nIdProducto INT
AS
BEGIN
    DELETE FROM Producto WHERE nIdProducto = @nIdProducto;
END;

CREATE PROCEDURE SeleccionarProductos
AS
BEGIN
    SELECT * FROM Producto;
END;

-- Procedimientos para OrdenCompra
CREATE PROCEDURE InsertarOrdenCompra
    @nIdProveedor INT,
    @dFecha DATETIME,
    @pTotal DECIMAL(10,2)
AS
BEGIN
    INSERT INTO OrdenCompra (nIdProveedor, dFecha, pTotal)
    VALUES (@nIdProveedor, @dFecha, @pTotal);
END;

--Actualizar

CREATE PROCEDURE ActualizarOrdenCompra
    @nIdOrdenCompra INT,
    @nIdProveedor INT,
    @dFecha DATETIME,
    @pTotal DECIMAL(10,2)
AS
BEGIN
    UPDATE OrdenCompra
    SET nIdProveedor = @nIdProveedor, dFecha = @dFecha, pTotal = @pTotal
    WHERE nIdOrdenCompra = @nIdOrdenCompra;

END;
--Eliminar
CREATE PROCEDURE EliminarOrdenCompra
    @nIdOrdenCompra INT
AS
BEGIN
    DELETE FROM OrdenCompra WHERE nIdOrdenCompra = @nIdOrdenCompra;
	select cast(@@ROWCOUNT as int)
END;

--Seleccionar
CREATE PROCEDURE SeleccionarOrdenesCompra
AS
BEGIN
    SELECT * FROM OrdenCompra;
END;

-- Procedimientos para DetallesOrdenCompra
ALTER PROCEDURE InsertarDetalleOrdenCompra
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

CREATE PROCEDURE ActualizarDetalleOrdenCompra
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

CREATE PROCEDURE EliminarDetalleOrdenCompra
    @nIdDetalle INT
AS
BEGIN
    DELETE FROM DetallesOrdenCompra WHERE nIdDetalle = @nIdDetalle;
		
	select cast(@@ROWCOUNT as int)
END;

ALTER PROCEDURE SeleccionarDetallesOrdenCompra	 		
   -- @nIdOrdenCompra INT
AS
BEGIN
    SELECT * FROM DetallesOrdenCompra --WHERE nIdOrdenCompra = @nIdOrdenCompra;
END;

-- Procedimientos para Compra
CREATE PROCEDURE InsertarCompra
    @dFecha DATETIME,
    @pTotal DECIMAL(11,2),
    @nIdEmpleado INT
AS
BEGIN
    INSERT INTO Compra (dFecha, pTotal, nIdEmpleado)
    VALUES (@dFecha, @pTotal, @nIdEmpleado);
END;

CREATE PROCEDURE ActualizarCompra
    @nIdCompra INT,
    @dFecha DATETIME,
    @pTotal DECIMAL(11,2),
    @nIdEmpleado INT
AS
BEGIN
    UPDATE Compra
    SET dFecha = @dFecha, pTotal = @pTotal, nIdEmpleado = @nIdEmpleado
    WHERE nIdCompra = @nIdCompra;
END;

CREATE PROCEDURE EliminarCompra
    @nIdCompra INT
AS
BEGIN
    DELETE FROM Compra WHERE nIdCompra = @nIdCompra;
END;

CREATE PROCEDURE SeleccionarCompras
AS
BEGIN
    SELECT * FROM Compra;
END;

-- Procedimientos para Inventario
CREATE PROCEDURE InsertarInventario
    @nIdProducto INT,
    @pCantidad INT,
    @dFechaActualizar DATETIME
AS
BEGIN
    INSERT INTO Inventario (nIdProducto, pCantidad, dFechaActualizar)
    VALUES (@nIdProducto, @pCantidad, @dFechaActualizar);
END;

CREATE PROCEDURE ActualizarInventario
    @nIdInventario INT,
    @nIdProducto INT,
    @pCantidad INT,
    @dFechaActualizar DATETIME
AS
BEGIN
    UPDATE Inventario
    SET nIdProducto = @nIdProducto, pCantidad = @pCantidad, dFechaActualizar = @dFechaActualizar
    WHERE nIdInventario = @nIdInventario;
END;

CREATE PROCEDURE EliminarInventario
    @nIdInventario INT
AS
BEGIN
    DELETE FROM Inventario WHERE nIdInventario = @nIdInventario;
END;

CREATE PROCEDURE SeleccionarInventarios
AS
BEGIN
    SELECT * FROM Inventario;
END;

-- Procedimientos para Kardex
CREATE PROCEDURE InsertarKardex
    @nIdProducto INT,
    @nIdEmpleado INT,          
    @cTipoMovimiento VARCHAR(50),  
    @pCantidad INT,
    @dFecha DATETIME
AS
BEGIN
    INSERT INTO Kardex (nIdProducto, nIdEmpleado, dFecha, cTipoMovimiento, pCantidad)
    VALUES (@nIdProducto, @nIdEmpleado, @dFecha, @cTipoMovimiento, @pCantidad);
END;




