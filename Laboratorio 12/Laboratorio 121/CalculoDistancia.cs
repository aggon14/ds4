using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_121
{
    public class CalculoDistancia
    {

        public double velocidad;
        public double tiempo;

        public CalculoDistancia (double velocidad, double tiempo)
        {
            this.velocidad = velocidad;
            this.tiempo = tiempo;
        }

        public double Calcular()
        {
            return velocidad * tiempo;
        }

    }
}
