CREATE PROCEDURE EliminarProveedor
    @nIdProveedor INT
AS
BEGIN
    DELETE FROM Proveedor WHERE nIdProveedor = @nIdProveedor;
	select cast(@@ROWCOUNT as int)
END;