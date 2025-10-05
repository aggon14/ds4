using Laboratorio_82;

internal class Program
{
    public static void Main()
    {
        const string CUENTA = "100";

        Cuenta cuenta = new Cuenta(CUENTA);
        CuentaCorriente cuentaCorriente = new CuentaCorriente(CUENTA);
        CuentaAhorro cuentaAhorro = new CuentaAhorro(CUENTA);
        cuentaCorriente.CalcularIntereses();

        cuentaCorriente.CalcularIntereses();
        Console.ReadKey();
    }
}
