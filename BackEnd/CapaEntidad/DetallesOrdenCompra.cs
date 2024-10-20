namespace CapaEntidad
{
    public class DetallesOrdenCompra
    {
        public int nIdDetalle { get; set; }
        public int nIdOrdenCompra { get; set; }
        public int nIdProducto { get; set; }
        public int pCantidad { get; set; }
        public decimal pPrecio { get; set; }
    }

}