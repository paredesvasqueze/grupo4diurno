USE [almacen]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[nIdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[cNombre] [varchar](100) NULL,
	[cDescripcion] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[nIdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compra]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compra](
	[nIdCompra] [int] IDENTITY(1,1) NOT NULL,
	[dFecha] [datetime] NULL,
	[pTotal] [decimal](11, 2) NULL,
	[nIdEmpleado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[nIdCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallesOrdenCompra]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallesOrdenCompra](
	[nIdDetalle] [int] IDENTITY(1,1) NOT NULL,
	[nIdOrdenCompra] [int] NULL,
	[nIdProducto] [int] NULL,
	[pCantidad] [int] NULL,
	[pPrecio] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[nIdDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[nIdEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[cNombre] [varchar](50) NULL,
	[cApellido] [varchar](50) NULL,
	[cPuesto] [varchar](40) NULL,
	[dFechaContrato] [datetime] NULL,
	[pSalario] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[nIdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventario]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventario](
	[nIdInventario] [int] IDENTITY(1,1) NOT NULL,
	[nIdProducto] [int] NULL,
	[pCantidad] [int] NULL,
	[dFechaActualizar] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[nIdInventario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kardex]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kardex](
	[nIdKardex] [int] IDENTITY(1,1) NOT NULL,
	[nIdProducto] [int] NULL,
	[nIdEmpleado] [int] NULL,
	[dFecha] [datetime] NULL,
	[cTipoMovimiento] [varchar](50) NULL,
	[pCantidad] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[nIdKardex] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdenCompra]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenCompra](
	[nIdOrdenCompra] [int] IDENTITY(1,1) NOT NULL,
	[nIdProveedor] [int] NULL,
	[dFecha] [datetime] NULL,
	[pTotal] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[nIdOrdenCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[nIdProducto] [int] IDENTITY(1,1) NOT NULL,
	[nIdProveedor] [int] NULL,
	[nIdCategoria] [int] NULL,
	[cNombre] [varchar](50) NULL,
	[cDescripcion] [varchar](100) NULL,
	[pPrecio] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[nIdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[nIdProveedor] [int] IDENTITY(1,1) NOT NULL,
	[cNombre] [varchar](100) NULL,
	[cContacto] [varchar](50) NULL,
	[cTelefono] [varchar](18) NULL,
	[cEmail] [varchar](60) NULL,
	[cDireccion] [varchar](60) NULL,
PRIMARY KEY CLUSTERED 
(
	[nIdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usser]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usser](
	[nIDUsser] [int] IDENTITY(1,1) NOT NULL,
	[cUserName] [varchar](50) NULL,
	[cPassword] [varchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[nIDUsser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD FOREIGN KEY([nIdEmpleado])
REFERENCES [dbo].[Empleado] ([nIdEmpleado])
GO
ALTER TABLE [dbo].[DetallesOrdenCompra]  WITH CHECK ADD FOREIGN KEY([nIdOrdenCompra])
REFERENCES [dbo].[OrdenCompra] ([nIdOrdenCompra])
GO
ALTER TABLE [dbo].[DetallesOrdenCompra]  WITH CHECK ADD FOREIGN KEY([nIdProducto])
REFERENCES [dbo].[Producto] ([nIdProducto])
GO
ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD FOREIGN KEY([nIdProducto])
REFERENCES [dbo].[Producto] ([nIdProducto])
GO
ALTER TABLE [dbo].[Kardex]  WITH CHECK ADD FOREIGN KEY([nIdEmpleado])
REFERENCES [dbo].[Empleado] ([nIdEmpleado])
GO
ALTER TABLE [dbo].[Kardex]  WITH CHECK ADD FOREIGN KEY([nIdProducto])
REFERENCES [dbo].[Producto] ([nIdProducto])
GO
ALTER TABLE [dbo].[OrdenCompra]  WITH CHECK ADD FOREIGN KEY([nIdProveedor])
REFERENCES [dbo].[Proveedor] ([nIdProveedor])
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD FOREIGN KEY([nIdCategoria])
REFERENCES [dbo].[Categoria] ([nIdCategoria])
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD FOREIGN KEY([nIdProveedor])
REFERENCES [dbo].[Proveedor] ([nIdProveedor])
GO
/****** Object:  StoredProcedure [dbo].[ActualizarCategoria]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarCategoria]
    @nIdCategoria INT,
    @cNombre VARCHAR(100),
    @cDescripcion VARCHAR(100)
AS
BEGIN
    UPDATE Categoria
    SET cNombre = @cNombre, cDescripcion = @cDescripcion
    WHERE nIdCategoria = @nIdCategoria;
END;
GO
/****** Object:  StoredProcedure [dbo].[ActualizarCompra]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarCompra]
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
GO
/****** Object:  StoredProcedure [dbo].[ActualizarDetalleOrdenCompra]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarDetalleOrdenCompra]
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
END;
GO
/****** Object:  StoredProcedure [dbo].[ActualizarEmpleado]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarEmpleado]
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
GO
/****** Object:  StoredProcedure [dbo].[ActualizarInventario]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarInventario]
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
GO
/****** Object:  StoredProcedure [dbo].[ActualizarOrdenCompra]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarOrdenCompra]
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
GO
/****** Object:  StoredProcedure [dbo].[ActualizarProducto]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarProducto]
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
GO
/****** Object:  StoredProcedure [dbo].[ActualizarProveedor]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarProveedor]
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
GO
/****** Object:  StoredProcedure [dbo].[EliminarCategoria]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarCategoria]
    @nIdCategoria INT
AS
BEGIN
    DELETE FROM Categoria WHERE nIdCategoria = @nIdCategoria;
END;
GO
/****** Object:  StoredProcedure [dbo].[EliminarCompra]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarCompra]
    @nIdCompra INT
AS
BEGIN
    DELETE FROM Compra WHERE nIdCompra = @nIdCompra;
END;
GO
/****** Object:  StoredProcedure [dbo].[EliminarDetalleOrdenCompra]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarDetalleOrdenCompra]
    @nIdDetalle INT
AS
BEGIN
    DELETE FROM DetallesOrdenCompra WHERE nIdDetalle = @nIdDetalle;
END;
GO
/****** Object:  StoredProcedure [dbo].[EliminarInventario]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarInventario]
    @nIdInventario INT
AS
BEGIN
    DELETE FROM Inventario WHERE nIdInventario = @nIdInventario;
END;
GO
/****** Object:  StoredProcedure [dbo].[EliminarOrdenCompra]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarOrdenCompra]
    @nIdOrdenCompra INT
AS
BEGIN
    DELETE FROM OrdenCompra WHERE nIdOrdenCompra = @nIdOrdenCompra;
END;
GO
/****** Object:  StoredProcedure [dbo].[EliminarProducto]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarProducto]
    @nIdProducto INT
AS
BEGIN
    DELETE FROM Producto WHERE nIdProducto = @nIdProducto;
END;
GO
/****** Object:  StoredProcedure [dbo].[EliminarProveedor]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarProveedor]
    @nIdProveedor INT
AS
BEGIN
    DELETE FROM Proveedor WHERE nIdProveedor = @nIdProveedor;
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertarCategoria]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarCategoria]
    @cNombre VARCHAR(100),
    @cDescripcion VARCHAR(100)
AS
BEGIN
    INSERT INTO Categoria (cNombre, cDescripcion)
    VALUES (@cNombre, @cDescripcion);
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertarCompra]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarCompra]
    @dFecha DATETIME,
    @pTotal DECIMAL(11,2),
    @nIdEmpleado INT
AS
BEGIN
    INSERT INTO Compra (dFecha, pTotal, nIdEmpleado)
    VALUES (@dFecha, @pTotal, @nIdEmpleado);
END;

GO
/****** Object:  StoredProcedure [dbo].[InsertarDetalleOrdenCompra]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedimientos para DetallesOrdenCompra
CREATE PROCEDURE [dbo].[InsertarDetalleOrdenCompra]
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
GO
/****** Object:  StoredProcedure [dbo].[InsertarEmpleado]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarEmpleado]
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
GO
/****** Object:  StoredProcedure [dbo].[InsertarInventario]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarInventario]
    @nIdProducto INT,
    @pCantidad INT,
    @dFechaActualizar DATETIME
AS
BEGIN
    INSERT INTO Inventario (nIdProducto, pCantidad, dFechaActualizar)
    VALUES (@nIdProducto, @pCantidad, @dFechaActualizar);
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertarKardex]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarKardex]
    @nIdProducto INT,
    @nIdEmpleado INT,          -- Agregar el parámetro para el ID de empleado
    @cTipoMovimiento VARCHAR(50),  -- Cambiar pMovimiento a cTipoMovimiento
    @pCantidad INT,
    @dFecha DATETIME
AS
BEGIN
    INSERT INTO Kardex (nIdProducto, nIdEmpleado, dFecha, cTipoMovimiento, pCantidad)
    VALUES (@nIdProducto, @nIdEmpleado, @dFecha, @cTipoMovimiento, @pCantidad);
END;


GO
/****** Object:  StoredProcedure [dbo].[InsertarOrdenCompra]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarOrdenCompra]
    @nIdProveedor INT,
    @dFecha DATETIME,
    @pTotal DECIMAL(10,2)
AS
BEGIN
    INSERT INTO OrdenCompra (nIdProveedor, dFecha, pTotal)
    VALUES (@nIdProveedor, @dFecha, @pTotal);
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertarProducto]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarProducto]
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
GO
/****** Object:  StoredProcedure [dbo].[InsertarProveedor]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarProveedor]
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

GO
/****** Object:  StoredProcedure [dbo].[SeleccionarCategorias]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SeleccionarCategorias]
AS
BEGIN
    SELECT * FROM Categoria;
END;
GO
/****** Object:  StoredProcedure [dbo].[SeleccionarCompras]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SeleccionarCompras]
AS
BEGIN
    SELECT * FROM Compra;
END;
GO
/****** Object:  StoredProcedure [dbo].[SeleccionarDetallesOrdenCompra]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SeleccionarDetallesOrdenCompra]	 		
   -- @nIdOrdenCompra INT
AS
BEGIN
    SELECT * FROM DetallesOrdenCompra --WHERE nIdOrdenCompra = @nIdOrdenCompra;
END;

GO
/****** Object:  StoredProcedure [dbo].[SeleccionarEmpleados]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SeleccionarEmpleados]
AS
BEGIN
    SELECT * FROM Empleado;
END;
GO
/****** Object:  StoredProcedure [dbo].[SeleccionarInventarios]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SeleccionarInventarios]
AS
BEGIN
    SELECT * FROM Inventario;
END;
GO
/****** Object:  StoredProcedure [dbo].[SeleccionarOrdenesCompra]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SeleccionarOrdenesCompra]
AS
BEGIN
    SELECT * FROM OrdenCompra;
END;
GO
/****** Object:  StoredProcedure [dbo].[SeleccionarProductos]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SeleccionarProductos]
AS
BEGIN
    SELECT * FROM Producto;
END;
GO
/****** Object:  StoredProcedure [dbo].[SeleccionarProveedores]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SeleccionarProveedores]
AS
BEGIN
    SELECT * FROM Proveedor;
END;
GO
/****** Object:  StoredProcedure [dbo].[ValidarUsuario]    Script Date: 24/10/2024 10:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ValidarUsuario]
@cUserName varchar(50),
@cPassword varchar(256)
as
begin
if exists(select * from usser where 
cUserName = @cUserName and cPassword = @cPassword)
begin
select cast(1 as bit)
end
else
begin
select cast(0 as bit)
end

end

GO
