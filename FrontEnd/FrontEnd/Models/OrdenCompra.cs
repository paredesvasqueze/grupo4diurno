﻿namespace FrontEnd.Models
{
    public class OrdenCompra
    {
        public int nIdOrdenCompra { get; set; }
        public int? nIdProveedor { get; set; }
        public string? cNombreProveedor { get; set; }
        public DateTime? dFecha { get; set; }
        public decimal? pTotal { get; set; }
    }
}