namespace CapaEntidad
{
    public class Usser
    {
        public int nId { get; set; }
        public string? cPassword { get; set; } = string.Empty;
        public string? cUsername { get; set; } = string.Empty;
        public byte[]? cVectorInicializacion { get; set; }
    }
}
