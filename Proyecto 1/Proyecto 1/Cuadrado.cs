using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1
{
    public class Cuadrado
    {
        public double num1;

        public Cuadrado(double numero)
        {
            this.num1 = numero;
        }

        public double Operacion()
        {
            return num1 * num1;
        }
    }
}
