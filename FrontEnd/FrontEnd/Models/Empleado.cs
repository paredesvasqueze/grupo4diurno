﻿namespace FrontEnd.Models
{
    public class Empleado
    {
        public int nIdEmpleado { get; set; }
        public string? cNombre { get; set; }
        public string? cApellido { get; set; }
        public string? cPuesto { get; set; }
        public DateTime dFechaContrato { get; set; }
        public decimal pSalario { get; set; }
    }
}
