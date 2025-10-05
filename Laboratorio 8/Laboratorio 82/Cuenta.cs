using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratorio_82;

namespace Laboratorio_82
{
    public class Cuenta
    {
        private string idCuenta;

        public Cuenta(string prmtIdCuenta)
        {
            this.idCuenta = prmtIdCuenta;
            System.Console.WriteLine("Constructor clase base para{0}", prmtIdCuenta);

        }

        public virtual void CalcularIntereses()
        {
            System.Console.WriteLine("ID de la cuenta: {0}", idCuenta);
        }

        public string getIdCuenta()
        {
            return this.idCuenta;
        }
    }
}

public class CuentaAhorro : Cuenta
{
    public CuentaAhorro(string prmtIdCuenta) : base(prmtIdCuenta)
    {
    }

    public override void CalcularIntereses()
    {
        System.Console.WriteLine("CuentaCorriente.CalcularIntereses() efectuado para" + "La cuenta {0}", getIdCuenta());
    }
}

public class CuentaCorriente: Cuenta
{
    public CuentaCorriente(string prmtIdCuenta): base(prmtIdCuenta)
    {
    }

    public override void CalcularIntereses()
    {
        System.Console.WriteLine("CuentaCorriente.CalcularIntereses() efectuado para" + "La cuenta {0}", getIdCuenta());
    }
}








