using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1
{
    public class Raiz
    {
        
            public double num1;

            public Raiz(double numero)
            {
                this.num1 = numero;
            }

            public double Operacion()
            {
                return Math.Sqrt(num1);
            }
        }
    }
