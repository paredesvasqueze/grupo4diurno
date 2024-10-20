namespace CapaEntidad
{
    public class Inventario
    {
        public int nIdInventario { get; set; }
        public int? nIdProducto { get; set; }
        public decimal? pCantidad { get; set; }
        public DateTime? dFechaActualizar { get; set; }
    }

}
