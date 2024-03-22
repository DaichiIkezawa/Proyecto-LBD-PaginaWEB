namespace test_2.Models
{
    public class VistaEmpleado
    {
        public int IdEmpleado { get; set; }
        public string? NombreEmpleado { get; set; }
        public string? ApellidosEmpleado { get; set; }
        public decimal SalarioEmpleado { get; set; }
        public string? NacionalidadEmpleado { get; set; } 
        public string? EstadoEmpleado { get; set; }

        public bool EstadoEmpleado_Bool { get; set; }
        public string? PuestoEmpleado { get; set; }
        public int ConteoEmpleados { get; set; }
    }
}
