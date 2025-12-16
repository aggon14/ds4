namespace Semestral.Models
{
    public class Ingreso
    {
        public int Id { get; set; }
        public System.DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Origen { get; set; }
    }
}
