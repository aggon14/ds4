using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_84
{
    public class Empleado
    {
        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
    }

    public class CuentaBancaria
    {
        private decimal saldo;
        public decimal Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }


    }

    public class Cobertura
    {
        private double radio;

        public Cobertura(double radio)
        {
            this.radio = radio;
        }

        public double Radio
        {
            get { return radio; }
        }
    }
}
