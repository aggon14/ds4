namespace Semestral.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public System.DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public int? EmpleadoId { get; set; }
    }
}
