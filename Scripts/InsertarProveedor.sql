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
	select cast(SCOPE_IDENTITY() as int)
END;