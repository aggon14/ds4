using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_123
{
    internal class CalcularArea
    {
        public double ladoA;
        public double ladoB;
        public double ladoC;

    public CalcularArea(double ladoA, double ladoB, double ladoC)
        {
            this.ladoA = ladoA;
            this.ladoB = ladoB;
            this.ladoC = ladoC;
        }


        public double Area()
        {
            return ladoA + ladoB + ladoC;
        }



        


    }
}
