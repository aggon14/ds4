using Laboratorio_84;

internal class Prongram
{
    private static void Main()
    {
        Empleado empleado = new Empleado();
        empleado.Nombre = "John Doe";
        Console.WriteLine("Nombre del empleado:" + ( empleado.Nombre));

        CuentaBancaria cuenta = new CuentaBancaria();
        cuenta.Saldo = 100;
        Console.WriteLine("Saldo de la cuenta:" + (cuenta.Saldo));

        Cobertura cobertura = new Cobertura(5);
        Console.WriteLine("Radio de la cobertura:" + (cobertura.Radio)); 

    }
   
}