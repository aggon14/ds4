using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_122
{
    public class CalcularPromedio
    {
        public double nota1;
        public double nota2;
        public double nota3;


        public CalcularPromedio(double nota1, double nota2, double nota3)
        {
            this.nota1 = nota1;
            this.nota2 = nota2;
            this.nota3 = nota3;
        }


        public double Promedio()
        {
            return (nota1 + nota2 + nota3) / 3;
        }
    }
}
