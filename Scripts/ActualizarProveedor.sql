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
	select cast(@@ROWCOUNT as int)
END;
