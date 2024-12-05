namespace FrontEnd.Models
{
    public class Compra
    {
        public int nIdCompra { get; set; }
        public int nIdEmpleado { get; set; }
        public string? cNombreEmpleado { get; set; }
        public DateTime dFecha { get; set; }
        public decimal pTotal { get; set; }
    }
}
