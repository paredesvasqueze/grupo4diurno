namespace FrontEnd.Models
{
    public class Producto
    {
        public int nIdProducto { get; set; }
        public int nIdProveedor { get; set; }
        public int nIdCategoria { get; set; }
        public string? cNombreCategoria { get; set; }
        public string? cNombreProveedor { get; set; }
        public string? cNombre { get; set; }
        public string? cDescripcion { get; set; }
        public decimal pPrecio { get; set; }
    }
}
