using System;

namespace Proyeccto_2.Models
{
    public class Calculo
    {
        public int Id { get; set; }
        public string Operacion { get; set; }
        public double Numero1 { get; set; }
        public double Numero2 { get; set; }
        public double Resultado { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class CalculoRequest
    {
        public string Operacion { get; set; }
        public double Numero1 { get; set; }
        public double Numero2 { get; set; }
    }

    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public int? Total { get; set; }
    }
}