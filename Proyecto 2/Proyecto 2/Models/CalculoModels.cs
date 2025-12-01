using Proyecto_2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Http;
using System.Web.Http.Cors;


namespace Proyecto_2.Models
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
}