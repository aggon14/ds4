using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_123
{
    public class CalcularSemiperimetro
    {
        public double ladoA;
        public double ladoB;
        public double ladoC;

        public CalcularSemiperimetro(double ladoA, double ladoB, double ladoC)
        {
            this.ladoA = ladoA;
            this.ladoB = ladoB;
            this.ladoC = ladoC;
        }


        public double Semiperimetro()
        {
            return (ladoA + ladoB + ladoC / 2);
        }
    }
}
