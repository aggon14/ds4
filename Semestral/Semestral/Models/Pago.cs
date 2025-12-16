namespace Semestral.Models
{
    public class Pago
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public decimal MontoPagado { get; set; }
        public System.DateTime FechaPago { get; set; }
    }
}
