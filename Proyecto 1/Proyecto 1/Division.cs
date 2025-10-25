using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1
{
    internal class Division
    {
        public double num1;
        public double num2;

        public Division(double num1, double num2)
        {
            this.num1 = num1;
            this.num2 = num2;
        }

        public double Operacion()
        {
            return num1/num2;
        }
    }
}
